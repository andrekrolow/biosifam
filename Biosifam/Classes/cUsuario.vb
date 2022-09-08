
Public Class cUsuario
    ' classe localiza na pasta _public com finalidade  multisistema
    ' utilizada nos projetos biosifam e netsan
    ' classe utilizando conecto nativo postgres NpgSql e datareaders 
    ' sem dependencias

    Dim vsLogin As String = "", vsTipoFamiliar As String = "", vsNome As String = "", vsSenha As String = "", VsEmail As String = ""
    Dim IdUsuarioAnterior As Long = 0, IdUsuario As Long = 0, IdCaixa = 0, IdDeposito As Integer = 0
    Dim IdConta As Integer = 0
    Dim vnModeloPadraoImpressaoConta As Integer = 0
    Dim vnExpirar = 360 ' minutos

    Public vbUsuarioValidado As Boolean = False
    Public vbUsuarioLocalizado As Boolean = False
    Public vbSomenteConsulta As Boolean = False

    Public vbUsuarioSuporte As Boolean = False
    Public vbUsuarioDigitador As Boolean = False
    Public vbUsuarioPrevpel As Boolean = False

    Public IdPrestador As Long = 0
    Public NomePrestador As String = ""

    Dim drGeneric As Npgsql.NpgsqlDataReader
    Dim vsSql As String = ""

    Public Function ValidarUsuario(ByVal vsloginDigitado As String, ByVal vsSenhaDigitada As String, ByVal vbSomenteConsulta As Boolean) As Boolean

        ValidarUsuario = False : vbUsuarioValidado = False : vsLogin = "" : vsSenha = "" : vsNome = ""
        If vbSomenteConsulta Then
            vsNome = "Modo consulta"
            Exit Function
        End If
        If BuscarDados(vsloginDigitado) Then
            If Senha = vsSenhaDigitada Then
                vbUsuarioValidado = True : ValidarUsuario = True
            Else
                MsgBox("Usuário/Senha inválida ")
            End If
        End If

    End Function
    Public Function BuscarDados(ByVal vsloginValidacao As String)
        On Error Resume Next
        Dim drUsuario As Npgsql.NpgsqlDataReader
        vbUsuarioValidado = False

        _PG.Conectar()
        drUsuario = _PG.DrQuery("Select to_ascii(u.nome,'LATIN1') as nome, u.login, u.senha, u.id_prestador, u.email, to_ascii(p.nome ,'LATIN1') as nome_prestador from usuario u left join prestador p using (id_prestador) where u.login='" & vsloginValidacao & "'")
        IdUsuarioAnterior = IdUsuario
        If drUsuario.HasRows Then
            drUsuario.Read()

            'idDeposito = drUsuario.Item("usu_deposito")
            'idCaixa = drUsuario.Item("usu_caixa")
            'IdUsuario = drUsuario.Item("id_usuario")
            vsNome = Trim(drUsuario.Item("nome"))
            vsLogin = Trim(drUsuario.Item("login"))
            vsSenha = Trim(drUsuario.Item("senha"))
            'vnModeloPadraoImpressaoConta = drUsuario.Item("modelo_conta")
            IdPrestador = Trim(drUsuario.Item("id_prestador"))
            NomePrestador = Trim(drUsuario.Item("nome_prestador"))
            VsEmail = Trim(drUsuario.Item("email"))
            BuscarDados = True
            vbUsuarioLocalizado = True
        Else
            MsgBox("Usuário NÃO localizado !")
            IdUsuario = 0 : IdDeposito = 0 : IdCaixa = 0
            vsLogin = "" : vsNome = "" : vsSenha = "" : vsTipoFamiliar = "" : VsEmail = ""
            vbUsuarioValidado = False
            BuscarDados = False
            vbUsuarioLocalizado = False
            vnModeloPadraoImpressaoConta = 0
        End If
        drUsuario = Nothing
        _PG.Desconectar()

    End Function

    Public Function BuscarDadosTipoFamiliar() As Boolean
        ' exclusivo problema biosifam
        On Error Resume Next
        vsTipoFamiliar = ""

        If IdUsuario = 0 Then Exit Function ' usuario precisa estar carregado

        Dim drTipoFamiliar As Npgsql.NpgsqlDataReader
        Dim drUsuario As Npgsql.NpgsqlDataReader
        _PG.Conectar()

        drUsuario = _PG.DrQuery("Select id_tipo_usuario from usuario where login='" & vsLogin & "'")
        If drUsuario.HasRows Then
            drUsuario.Read()
            drTipoFamiliar = _PG.DrQuery("Select descr_tipo_usuario from tipo_usuario where id_tipo_usuario=" & drUsuario.Item("id_tipo_usuario"))
            If drTipoFamiliar.HasRows Then
                drTipoFamiliar.Read()
                vsTipoFamiliar = Trim(drTipoFamiliar.Item(0))
            End If
        End If
        BuscarDadosTipoFamiliar = True
        drTipoFamiliar = Nothing
        _PG.Desconectar()

    End Function

    Public Function BuscarGrupos() As Boolean
        BuscarGrupos = False
        If _PG.Conectar = False Then Exit Function

        Dim drUsuario As Npgsql.NpgsqlDataReader

        vbUsuarioSuporte = False : vbUsuarioDigitador = False : vbUsuarioPrevpel = False

        drUsuario = _PG.DrQuery("SELECT * FROM grupo, usuario_grupo where usuario_grupo.codgrupo=grupo.codgrupo and upper(descricao)='SUPORTE' and usuario_grupo.login='" & vsLogin & "'")
        If drUsuario.HasRows Then vbUsuarioSuporte = True

        drUsuario = _PG.DrQuery("SELECT * FROM grupo, usuario_grupo where usuario_grupo.codgrupo=grupo.codgrupo and (upper(descricao)='DIRETORIA' or upper(descricao)='ADMINISTRAÇÃO' or upper(descricao)='FINANCEIRO') and usuario_grupo.login='" & vsLogin & "'")
        If drUsuario.HasRows Then vbUsuarioPrevpel = True

        drUsuario = _PG.DrQuery("SELECT * FROM grupo, usuario_grupo where usuario_grupo.codgrupo=grupo.codgrupo and trim(descricao)='BioSiFAM Acesso' and usuario_grupo.login='" & vsLogin & "'")
        If drUsuario.HasRows = False Then
            MsgBox("Seu usuário não tem permissão de acesso ao Biosfiam, entre em contato com o suporte técnico para corrigir seu cadastro. ", MsgBoxStyle.Critical, Application.ProductName & " - Estação Bloqueada.")
            _PG.Desconectar()
            End
        Else
            vbUsuarioDigitador = True
        End If
        BuscarGrupos = True
        _PG.Desconectar()
    End Function

    Public Sub LocalizaViaDigital(ByVal ret As Integer)
        If _PG.Conectar = False Then Exit Sub
        Dim dr As Npgsql.NpgsqlDataReader
        dr = _PG.DrQuery("SELECT usuario.login, to_ascii(nome,'LATIN1') as nome, senha FROM usuario, digital_usuario  WHERE usuario.login=usuario and id_digital_usuario = " & ret)
        If dr.HasRows Then
            dr.Read()
            BuscarDados(dr.Item(0))
        Else
            MsgBox("A Digital informada não foi localizada na Base de dados. ")
        End If
        _PG.Desconectar()

    End Sub

    Public Function LocalizaUsuarioPG(ByVal userId As String) As Long
        LocalizaUsuarioPG = 0
        _PG.Conectar()
        vsSql = "select login_sau from zim.usuario where user_id='" & userId & "'"
        drGeneric = _PG.DrQuery(vsSql)
        If drGeneric.HasRows Then
            drGeneric.Read()
            LocalizaUsuarioPG = drGeneric.Item(0)
        Else
            If MsgBox("Não existe a vinculação do Usuário SAU com o usuário ZIM (comnet). Deseja vincular os usuários agora ? ", vbYesNo, "") = vbYes Then
                LocalizaUsuarioPG = Val(InputBox("Informe seu usuário no sistema SAU, para vinculá-lo ao sistema ZIM "))
                If LocalizaUsuarioPG = 0 Then Exit Function
                vsSql = "select * from usuario where login='" & LocalizaUsuarioPG & "'"
                drGeneric = _PG.DrQuery(vsSql)
                If drGeneric.HasRows = False Then
                    LocalizaUsuarioPG = 0
                    MsgBox("O código informado não foi localizado no sistema SAU, tente novamente ou cadstre um novo usuário no sistema SAU.")
                    Exit Function
                Else
                    If MsgBox("Localizado o usuário " & drGeneric.Item("nome") & ". Confirma a vinculação ? ", vbYesNo, "") = vbNo Then Exit Function
                End If
                _PG.Execute("update zim.usuario set user_id='" & userId & "' where user_id=" & LocalizaUsuarioPG)
            End If
        End If
        _PG.Desconectar()
    End Function


    Public Property Id() As Integer
        Get
            Id = IdUsuario
        End Get
        Set(ByVal value As Integer)
        End Set
    End Property
    Public Property Login() As String
        Get
            Login = vsLogin
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Public Property Nome() As String
        Get
            Nome = vsNome
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Public Property TipoFamiliar() As String
        ' utilizado para identifica a relação do usuário com o usuário titular, contribuinte, esposo, filho, etc...
        Get
            TipoFamiliar = vsTipoFamiliar
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Public Property Senha() As String
        Get
            Senha = vsSenha
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Public Property ModeloPadraoImpressaoConta() As Integer
        Get
            ModeloPadraoImpressaoConta = vnModeloPadraoImpressaoConta
        End Get
        Set(ByVal value As Integer)
        End Set
    End Property
    Public Property Expirar() As Integer
        Get
            Expirar = vnExpirar
        End Get
        Set(ByVal value As Integer)
        End Set
    End Property
    Public Property Email() As String
        Get
            Email = VsEmail
        End Get
        Set(ByVal value As String)
        End Set
    End Property
End Class
