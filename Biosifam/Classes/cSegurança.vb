Imports System.Math
Imports System.Environment
Imports System.Net.Dns      ' gethostname
Imports System.Security.Cryptography    ' necessária rotinas de criptografia
Imports System.Text                     ' necessária rotinas de criptografia
Imports System.Configuration

Public Class cSegurança
    ' igualar a classe do k2 - iniciado para sem uso

    ' configuração padrão para app rodando sem conexao com base nenhuma ===============
    ' variaveis precisam ser alimentada apos carga da empresa
    Public idEmpresa As Long = 0
    Public UsaLogRemoto As Boolean = False
    Public UsaLogRastreamento As Boolean = False
    Public UsaLogLocalTxt As Boolean = True
    '==================================================================================

    Dim myKey As String = "obiwan"

    Dim Email As ClsMail

    Public vbTemMensagemUsuario As Boolean = False
    Public MensagemUsuarioNaoVisualizada As String = ""

    Function Ocorrencias(ByVal vnTipo As Integer, ByVal vsOcorrencia As String, ByVal vsForm As String, ByVal vsSubrotina As String, ByVal vsDetalhe As String, ByVal vbMostraMensagem As Boolean, Optional ByVal vbGravaBanco As Boolean = False, Optional ByVal vbGravaTXT As Boolean = True, Optional ByVal vbEmail As Boolean = False) As Long

        Dim vsNomeArquivoLog As String = Application.ProductName & ".log"
        Dim swINI As IO.StreamWriter
        Dim vbAbriuArquivo As Boolean = False

        'vntipo 0-alertas, 1-erros 2-tracker 
        On Error GoTo erro
        Ocorrencias = 0
        If UsaLogRemoto And vbGravaBanco Then
            If vnTipo = 2 And UsaLogRastreamento = False Then GoTo MostraOcorrencia
            On Error GoTo erro
            ' deu erro no windows 7 e xp nao sei porque
            'If _t.IP_Externo = "" Then _t.ObtemEnderecoIPExterno()

            Dim StrSql As String = "insert into dashboard.log " &
                    "(datahora, id_empresa, programa, versao, aplicativo, sub, ocorrencia, detalhe, usuario, workstation, ip, tipo, exportado)" &
                    " VALUES (current_timestamp, " & idEmpresa & ",'" & Application.ProductName & "','" & Application.ProductVersion & "','" &
                    vsForm & "','" & vsSubrotina & "','" & vsOcorrencia & "','" & Left$(Replace(vsDetalhe, "'", ""), 100) & "',''," &
                    "'" & _w.Nome & "','" & _t.IP_Externo & "'," & vnTipo & ", null)"
            If _s.Controle_Manager(StrSql) = False Then vbEmail = True
        End If
MostraOcorrencia:
        If vbMostraMensagem Then
            _t.msgK2("Aplicação   : " & IIf(vsForm = "", "Siacks", vsForm) & Chr(13) &
                    "Subrotina   : " & vsSubrotina & Chr(13) &
                    "Ocorrência : " & vsOcorrencia & Chr(13) & Chr(13) &
                    IIf(vnTipo = 0, "Alerta : ", "Erro : ") & vsDetalhe, " Controle de Ocorrências " & IIf(UsaLogRemoto, " N. " & Ocorrencias, ""), 8, IIf(vnTipo = 0, vbInformation, vbCritical))

        End If

        ' grava log TEXTO ============================================================================================
        ' todos logs ficarão no diretório da aplicação
        ' rotina que nao fazem log quando desativado.
        If UsaLogLocalTxt = False Or vbGravaTXT = False Then Exit Function

Abre_Arquivo:
        vbAbriuArquivo = False
        swINI = New IO.StreamWriter(vsGlo_AppPath & "\" & vsNomeArquivoLog, True)
        vbAbriuArquivo = True
        swINI.WriteLine(Now & ";" & Application.ProductVersion & ";" & _w.Nome & ";" & VsNomeUsuario & ";" & vsForm & ";" & vsSubrotina & ";" & vsOcorrencia & ";" & vsDetalhe)
        swINI.Close()

Envia_Email:
        If vbEmail Then
            Email = New ClsMail("MonitorKrolow")
            'Email.vsRemetenteEmail = "k2solucoes.monitor@gmail.com"
            'Email.vsRemetenteSenha = "G@dimensao"
            Email.vsAssunto = "Ocorrência " & _e.Nome
            Email.vsEmail = "k2solucoes.suporte@gmail.com"
            Email.vsMensagem = Now & ";" & Application.ProductVersion & ";" & _w.Nome & ";" & VsNomeUsuario & ";" & vsForm & ";" & vsSubrotina & ";" & vsOcorrencia & ";" & vsDetalhe
            Email.vbAutomatico = True
            Email.vbAutenticacaoSegura = True
            Email.Enviar()
        End If

        Ocorrencias = True
        Exit Function
erro:
        'MsgBox(Err.Number)
        If Err.Number = 57 Then
            ' arquivo bloqueado
            vsNomeArquivoLog = Replace(vsNomeArquivoLog, ".", Format(Now, "ddMMyyyyhhmmss") & ".")
            GoTo Abre_Arquivo
            'ElseIf Err.Number = 76 Then
            ' pasta nao existe
            '    MkDir("logs")
            '    GoTo Abre_Arquivo
        Else
            If vbAbriuArquivo = True Then swINI.Close()
            _t.msgK2(Err.Description & " - N." & Err.Number & ". Erro ao tentar salvar o arquivo de logs " & vsNomeArquivoLog, "_s.Ocorrencias", 5)
        End If
    End Function

    Public Function GravaLogTXT(ByVal Login As String, ByVal vsEstacaoNome As String,
                                ByRef vsNomeArquivoLog As String, ByVal vsQuemChamou As String, ByVal vsQuemChamou2 As String,
                                ByVal vsDetalhe As String, Optional ByVal vbMostrarMensagem As Boolean = False) As Boolean

        ' esta função é necessária para os erros no banco de dados.
        Dim i As Integer, vbAbriuArquivo As Boolean = False
        GravaLogTXT = False
        On Error GoTo erro
Abre_Arquivo:
        If vsNomeArquivoLog = "" Then vsNomeArquivoLog = Application.ProductName & ".log"
        If vbMostrarMensagem Then MsgBox(vsQuemChamou2 & IIf(vsQuemChamou2 <> "" And vsDetalhe <> "", " - ", "") & vsDetalhe, vbInformation, "cSegurança.GravaLogTXT -> " & vsQuemChamou)
        If _e.vbUsaLogTxt = False Then Exit Function

        Dim swINI As New IO.StreamWriter(vsGlo_AppPath & vsNomeArquivoLog, True)
        vbAbriuArquivo = True
        swINI.WriteLine(Now & "-" & Application.ProductVersion & "-" & vsEstacaoNome & "-" & Login & "-" & vsQuemChamou & "-" & vsQuemChamou2 & "-" & vsDetalhe)
        swINI.Close()
        GravaLogTXT = True
        Exit Function
erro:
        'MsgBox(Err.Number)

        If Err.Number = 57 Then
            ' arquivo bloqueado
            vsNomeArquivoLog = Replace(vsNomeArquivoLog, ".", Format(Now, "ddMMyyyyhhmmss") & ".")
            GoTo Abre_Arquivo
            'ElseIf Err.Number = 76 Then
            ' arquivo bloqueado
            'MkDir("logs")
            'GoTo Abre_Arquivo

        ElseIf Err.Number <> 0 Then
            If vbAbriuArquivo = True Then swINI.Close()
            _s.msgK2(Err.Description & " - N." & Err.Number & ". Erro ao tentar salvar o arquivo de logs " & vsNomeArquivoLog, "_s.GravaLogTXT", 5)
        End If
    End Function

    Public Function LiberaAcesso(ByVal login As String, ByVal vsAplicativo As String, ByVal vsDescricaoAplicativo As String, ByVal vbMostraErros As Boolean, ByVal vbGravaLog As Boolean) As Boolean
        On Error GoTo erro
        vh_UltimaAtividade = TimeOfDay
        LiberaAcesso = False  ' trava acesso em caso de erro na rotina

        _PG.Conectar()

        Dim drGeneric As Npgsql.NpgsqlDataReader
        Dim drAplicacao As Npgsql.NpgsqlDataReader
        Dim drUsuGrupos As Npgsql.NpgsqlDataReader

        drUsuGrupos = _PG.DrQuery("Select * from usuario_grupo where login='" & login & "'")
        If drUsuGrupos Is Nothing Then
            _s.Ocorrencias(0, "LiberaAcesso", Application.ProductName, Trim(vsAplicativo) & " - " & Trim(vsDescricaoAplicativo), "Usuário sem classificação de grupo, acesso negado.", vbMostraErros, vbGravaLog, False)
            If vbMostraErros Then MsgBox(" Utilize o cadastro de Usuários e Grupos para a complementação de seu cadastro.")
            GoTo Fim
        End If
        If drUsuGrupos.HasRows = False Then
            _s.Ocorrencias(0, "LiberaAcesso", Application.ProductName, Trim(vsAplicativo) & " - " & Trim(vsDescricaoAplicativo), "Usuário sem classificação de grupo, acesso negado.", vbMostraErros, vbGravaLog, False)
            If vbMostraErros Then MsgBox(" Utilize o cadastro de Usuários e Grupos para a complementação de seu cadastro.")
            GoTo Fim
        End If

        drAplicacao = _PG.DrQuery("Select * From aplicacao where fonte='" & vsAplicativo & "'")
        drAplicacao.Read()
        If drAplicacao.HasRows = False Then
            ' verifica se nome já existe
            drAplicacao = _PG.DrQuery("Select * From aplicacao where descricao='" & vsDescricaoAplicativo & "'")
            REM cadastra programa encontrado
            If drAplicacao.HasRows Then
                drAplicacao.Read()
                MsgBox("Foi localizada uma duplicidade de aplicações. O sistema ajustará automaticamente este problema. ")
                _PG.Execute("delete from aplicacao where codaplicacao=" & drAplicacao.Item(0))
            End If
            _PG.Execute("insert into aplicacao (superior, fonte, descricao, tipo, situacao) values (0, '" & vsAplicativo & "','" & vsDescricaoAplicativo & "', 'a', 0)")
            MsgBox("Encontrada nova aplicação:" & vsAplicativo & "-" & vsDescricaoAplicativo & " ! Para liberar o acesso classifique corretamente a aplicação de acordo com o Perfil dos Grupos e dos Usuários.")
            GoTo Fim

            ' abaixo desativado momentaneamente
            If vsAplicativo = "frm_CadUsuariosGrupos" Or vsAplicativo = "frm_CadUsuarios" Then
                ' Localiza Grupo Suporte
                drGeneric = _PG.DrQuery("Select * From grupos where nome='SUPORTE'")
                If drGeneric.HasRows = False Then
                    _PG.Execute("insert into grupos values (" & _PG.ProximoCodigo("grupos", "codigo") & ",'SUPORTE' )")
                    drGeneric = _PG.DrQuery("Select * From grupos where nome='SUPORTE'")
                    If drGeneric.HasRows = False Then MsgBox("Não é possível inserir a aplicação no grupo 'SUPORTE', pois não foi possível criá-lo. Tente realizar o processo manualmente.") : GoTo Fim
                    drAplicacao = _PG.DrQuery("Select * From Programas where prg_funcao='" & Left(vsDescricaoAplicativo, 50) & "'")
                End If
                ' para não travar acesso ao sistema, inserir CadUsuariosGrupos no grupo do atual usuário
                _PG.DrQuery("insert into programasgrupos values (" & drGeneric.Item("codigo") & "," & drAplicacao.Item("codigo") & " )")
                MsgBox("Esta aplicação é de uso prioritário ao sistema, como nenhum usuário tem acesso a aplicação, ela foi inserida no grupo 'SUPORTE'. Após o encerramento deste formulário é necessário recarregar o sistema com a nova classificação do Aplicativo e do Usuário.")
            End If
            GoTo Fim
        End If

        ' aqui obtenho os grupos em que o usuário está inserido
        ' para cada grupo devo verificar se existe o programa que esta sendo acessado
        drUsuGrupos = _PG.DrQuery("Select * from usuario_grupo where login='" & login & "'")
        While (drUsuGrupos.Read)
            drGeneric = _PG.DrQuery("Select * From grupo_aplicacao where codgrupo=" & drUsuGrupos.Item("codgrupo") & " and codaplicacao=" & drAplicacao.Item("codaplicacao"))
            If drGeneric.HasRows Then
                ' achou programa e usuário tem acesso !!!!!
                _s.Ocorrencias(0, "LiberaAcesso", Application.ProductName, Trim(vsAplicativo) & " - " & Trim(vsDescricaoAplicativo), "Acesso autorizado", False, vbGravaLog, False)
                LiberaAcesso = True
                GoTo Fim
            End If
        End While

        If LiberaAcesso = False Then
            _s.Ocorrencias(0, "LiberaAcesso", Application.ProductName, Trim(vsAplicativo) & " - " & Trim(vsDescricaoAplicativo), "Acesso não autorizado", vbMostraErros, vbGravaLog, False)
            GoTo Fim
        End If

erro:
        _s.Ocorrencias(0, "LiberaAcesso", Application.ProductName, Err.Description, Err.Number, True, vbGravaLog, False)

Fim:
        drGeneric = Nothing
        drAplicacao = Nothing
        _PG.Desconectar()

    End Function

    Public Function Criptografar(ByVal js_senha As String) As String
        ' MsgBox js_senha
        On Error Resume Next
        Dim js_cadeia As String
        Dim jn_Sum As Object
        Dim ji_counti, ji_countj As Integer
        Dim ji_asc1, ji_asc2 As Integer
        Dim js_Char, js_Char1, js_Char2 As String
        Dim jsCrypt As String

        js_cadeia = "w29hy1Kp"
        jn_Sum = 0
        If js_senha Is DBNull.Value Then js_senha = ""
        js_senha = Left(js_senha, 8)
        Trim(js_senha)
        jsCrypt = ""
        For ji_counti = 1 To (Len(js_senha))
            js_Char1 = Mid(js_senha, ji_counti, 1)
            ji_asc1 = Asc(js_Char1)
            For ji_countj = 1 To (Len(js_cadeia))
                js_Char2 = Mid(js_cadeia, ji_countj, 1)
                ji_asc2 = Asc(js_Char2)
                jn_Sum = (ji_asc1 + ji_asc2) * 16 * ji_asc1 + jn_Sum
            Next
            jn_Sum = Sqrt(jn_Sum) / Len(js_senha)
            While jn_Sum > 255
                jn_Sum -= -255
            End While
            js_Char = Chr(jn_Sum)  'tirei chrW
            'MsgBox "chr = " & Chr(Jn_sum) & " e chrW=" & ChrW(Jn_sum) & " ju_sum=" & Jn_sum
            jsCrypt = jsCrypt + js_Char
        Next
        Criptografar = jsCrypt
        ' MsgBox jsCrypt
    End Function

    Public Function ContraSenha1(ByVal Data As Date, ByVal Hora As Date, ByVal vsEstNome As String) As String
        On Error Resume Next
        Dim I, vn_Estacao As Integer
        For I = 1 To Len(vsEstNome)
            vn_Estacao = vn_Estacao + Asc(Mid(vsEstNome, I, 1))
        Next I
        ContraSenha1 = (Data.Day + Month(Data) + Year(Data) + Val(Left(Hora, 2)) + Val(Mid(Hora, 4, 2)) + Val(Right(Hora, 2)) + vn_Estacao) * Data.Day
    End Function

    Public Function ContraSenha0(ByVal Data As Date, ByVal Hora As Date, ByVal vsEstNome As String) As String
        On Error Resume Next
        Dim I, vn_Estacao As Integer
        For I = 1 To Len(vsEstNome)
            vn_Estacao += Asc(Mid(vsEstNome, I, 1))
        Next I
        ContraSenha0 = (Data.Day + Month(Data) + Year(Data) + Val(Left(Hora, 2)) + Val(Mid(Hora, 4, 2)) + Val(Right(Hora, 2)) + vn_Estacao) * (Data.Day + Month(Data))
    End Function

    Public Function UltimoAcesso(ByVal newUltimoAcesso As Date, ByVal Recebe As Boolean) As Date
        On Error Resume Next
        If Recebe = True Then vh_UltimaAtividade = newUltimoAcesso
        UltimoAcesso = vh_UltimaAtividade
    End Function

    'Rotinas de criptografia==========================================================================

    Function HashMD5(Senha As String) As String
        Dim md5Hasher As New System.Security.Cryptography.MD5CryptoServiceProvider()
        Dim hashedBytes As Byte()
        Dim encoder As New System.Text.UTF8Encoding()
        Dim saida As String = ""
        hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(Senha))
        For Each y In hashedBytes
            saida &= y
        Next y
        HashMD5 = saida
    End Function


    Public Function CriptaTexto(ByVal texto As String, ByVal Operacao As Boolean, Key As String) As String
        If Operacao Then
            CriptaTexto = Cifra(texto, Key)
        Else
            CriptaTexto = DeCifra(texto, Key)
        End If
    End Function

    Private Function DeCifra(ByVal texto As String, Key As String) As String
        Key = myKey & Key
        Dim des As New TripleDESCryptoServiceProvider()
        Dim hashmd5 As New MD5CryptoServiceProvider()
        DeCifra = ""
        If texto = "" Then Exit Function
        des.Key = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(Key))
        des.Mode = CipherMode.ECB
        Dim desdencrypt As ICryptoTransform = des.CreateDecryptor()
        Dim buff() As Byte = Convert.FromBase64String(texto)
        DeCifra = ASCIIEncoding.ASCII.GetString(desdencrypt.TransformFinalBlock(buff, 0, buff.Length))
    End Function
    Private Function Cifra(ByVal texto As String, Key As String) As String
        Key = myKey & Key
        Dim des As New TripleDESCryptoServiceProvider()
        Dim hashmd5 As New MD5CryptoServiceProvider()
        Cifra = ""
        If texto = "" Then Exit Function
        des.Key = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(Key))
        des.Mode = CipherMode.ECB
        Dim desdencrypt As ICryptoTransform = des.CreateEncryptor()
        Dim MyASCIIEncoding = New ASCIIEncoding()
        Dim buff() As Byte = ASCIIEncoding.ASCII.GetBytes(texto)
        Cifra = Convert.ToBase64String(desdencrypt.TransformFinalBlock(buff, 0, buff.Length))
    End Function
    'Fim Rotinas de criptografia==========================================================================

    Public Function EncryptStringVB6(ByVal UserKey As String, ByVal Text As String, ByVal Action As Single) As String

        'define as variaveis usadas
        Dim Temp As Integer
        Dim J As Integer
        Dim n As Integer
        Dim rtn As String

        '//Obtem os caracteres da chave do usuário
        'define o comprimento da chave do usuario usada na criptografia
        n = Len(UserKey)

        'redimensiona o array para o tamanho definido
        Dim userKeyASCIIS(1)
        ReDim userKeyASCIIS(n)


        'preenche o array com caracteres asc
        'Debug.Print UserKey; "=> ";
        For I = 1 To n
            userKeyASCIIS(I) = Asc(Mid$(UserKey, I, 1))
            'Debug.Print userKeyASCIIS(I); " ";
        Next

        '//redimensiona o array com o tamanho do texto
        'obtem o caractere de texto
        Dim TEXTAsciis(1) As Integer
        ReDim TEXTAsciis(Len(Text))

        'preenche o array com caracteres asc
        'Debug.Print()
        'Debug.Print Text; " => ";
        For I = 1 To Len(Text)
            TEXTAsciis(I) = Asc(Mid$(Text, I, 1))
            'Debug.Print TEXTAsciis(I); " ";
        Next

        '//cifra/decifra
        'Debug.Print()
        'Debug.Print("Criptografando")
        If Action = 0 Then
            For I = 1 To Len(Text)
                J = IIf(J + 1 >= n, 1, J + 1)
                Temp = TEXTAsciis(I) + userKeyASCIIS(J)
                If Temp > 255 Then
                    Temp = Temp - 255
                End If
                'Debug.Print Temp; " ";
                rtn = rtn + Convert.ToChar(Temp)
                'Debug.Print(rtn)
            Next
        Else
            For I = 1 To Len(Text)
                J = IIf(J + 1 >= n, 1, J + 1)
                Temp = TEXTAsciis(I) - userKeyASCIIS(J)
                If Temp < 0 Then
                    Temp = Temp + 255
                End If
                rtn = rtn + Convert.ToChar(Temp)
            Next
        End If

        '//Retorna o texto
        EncryptStringVB6 = rtn
    End Function

    Public Function VerificaVersaoApp(ByVal vsApp As String) As String
        Dim fvi As System.Diagnostics.FileVersionInfo
        Try
            fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(Application.StartupPath & "\" & vsApp & ".exe")
            VerificaVersaoApp = (fvi.FileVersion)
        Catch
            ' nada
            VerificaVersaoApp = ""
        End Try
    End Function

    Public Function StatusSistema(ByVal vsNomeForm As String, ByVal SituaçãoAtual As Integer, ByVal Usuario As String) As Integer
        StatusSistema = 0   ' liberado
        If SituaçãoAtual > 0 And SituaçãoAtual <> 5 Then
            If SituaçãoAtual = 1 Then
                If MsgBox("O Sistema identificou um BACKUP de DADOS iniciado e não finalizado, por favor aguarde finalização da tarefa ou caso ela já tenha sido concluída informe isso ao sistema. " & Chr(13) & Chr(13) & "Deseja informar que o backup foi finalizado ?", vbYesNo) = vbYes Then
                    _s.Ocorrencias(0, "Controle de Acesso", vsNomeForm, "cDll_Seguranca.StatusSistema", "Backup concluído pelo usuário", True, True, False)
                    _PG.DrQuery("Update empresa set emp_situa_sistema=0")
                End If
            End If
            If SituaçãoAtual = 2 Then MsgBox("Administrador realizando manutenção no BANCO de DADOS!" & Chr(13) & Chr(13) & "Por favor aguarde liberação!")
            If SituaçãoAtual = 3 Then MsgBox("Sistema SUSPENSO por sinalização do administrador." & Chr(13) & Chr(13) & "Verifique a situação com o suporte técnico.")
            If SituaçãoAtual = 4 Then MsgBox("k2match.exe não localizado. Sistema Suspenso." & Chr(13) & Chr(13) & "Verifique o caminho do servidor de aplicação ou procure o suporte técnico.")
            'If SituaçãoAtual = 4 Then MsgBox "K2Syncronizador não localizado." & Chr(13) & Chr(13) & "Verifique a situação com o suporte técnico."
            If UCase$(Usuario) <> "ADMINISTRADOR" And vsNomeForm <> "frm_Utilitarios" Then StatusSistema = 1 'trava
        End If

    End Function

    Public Sub msgK2(ByVal vsMensagem As String, ByVal vsTitulo As String, ByVal vnTempo As Integer, Optional ByVal vsTipoMensagem As String = "vbOKOnly + vbInformation")
        Try
            CreateObject("WScript.Shell").Popup(vsMensagem, vnTempo, Application.ProductName.ToString & " " & Application.ProductVersion & ", " & vsTitulo, vbOKOnly + vbInformation)
        Catch
            MsgBox(vsMensagem, vbOKOnly + vbInformation, Application.ProductName.ToString & " " & Application.ProductVersion & ", " & vsTitulo)
        End Try
    End Sub

    Public Function IP() As String
        Dim sEndereco As String
        ' http://labs.developerfusion.co.uk/SourceViewer/browse.aspx?assembly=SSCLI&namespace=System.Net&type=Dns
        sEndereco = ""
        Try
            Dim result As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(GetHostName)
            Dim add As System.Net.IPAddress
            For Each add In result.AddressList
                sEndereco = add.ToString()
            Next
        Catch ex As Exception
            Debug.WriteLine("Não foi possível identificar o IP desta máquina. Erro: " + ex.Message)
        End Try

        IP = sEndereco
    End Function

    Public Property NomeMaquina() As String
        Get
            NomeMaquina = Environment.MachineName.ToString
        End Get
        Set(ByVal value As String)
        End Set
    End Property

    Public Function MAC() As String
        Dim mc As System.Management.ManagementClass
        Dim mo As System.Management.ManagementBaseObject
        MAC = ""
        mc = New Management.ManagementClass("Win32_NetworkAdapterConfiguration")
        Dim moc As Management.ManagementObjectCollection = mc.GetInstances

        For Each mo In moc
            If mo.Item("IPenabled") = True Then MAC = Trim(mo.Item("MacAddress"))
        Next
    End Function

    Private Function AplicacaoJaRodou(ByVal vsAplicacao As String) As Boolean
        AplicacaoJaRodou = False
        ' indica ao siacks que está executou o k2tools em menos de X minutos, para controlar multiplas execuções na rede
        Dim drGenericPG As Npgsql.NpgsqlDataReader
        Try
            Dim vsTempoSincronizacao As String = "'00:05:00'"
            'vsTempoSincronizacao = "'00:" & Format(_e.Tempo_Sincronizador, "00") & ":00'"
            drGenericPG = _PG.DrQuery("select max(datahora) from dashboard.log where date(datahora)=current_date and id_empresa=" & _e.Id & " and programa='" & vsAplicacao & "' and sub='load' and detalhe='concluido' and age(now(),datahora) < " & vsTempoSincronizacao)
            If drGenericPG.HasRows Then
                drGenericPG.Read()
                If drGenericPG.IsDBNull(0) = vbFalse Then
                    ' se é FALSE , não achou então pode prosseguir
                    _s.Ocorrencias(2, Application.ProductName, _u.Nome, "AplicacaoJaRodou", "Executado em menos de 5 min.(" & drGenericPG.Item(0) & ")", False, False, True)
                    AplicacaoJaRodou = True
                End If
            End If
        Catch ex As Exception
            _s.Ocorrencias(1, Application.ProductName, _u.Nome, "AplicacaoJaRodou", "erro ao localizar aplicação já executada. " & Application.ProductName & ", " & Err.Description, VbGlo_Console, True, True)
        End Try
        _PG = Nothing
    End Function

    Private Function LoginAplicativo() As Long
        LoginAplicativo = 0
        Dim drUsuario As Npgsql.NpgsqlDataReader
        drUsuario = _PG.DrQuery("select * from usuarios where usu_nome='k2tools'")
        drUsuario.Read()
        If drUsuario.HasRows Then
            LoginAplicativo = drUsuario.Item("usu_codigo")
        Else
            _s.Ocorrencias(1, Application.ProductName, "cTools", "_u.loginAplicativo", "Usuário k2tools não localizado", True, True, True)
            LoginAplicativo = _PG.ProximoCodigo("usuarios", "usu_codigo")
            _PG.Execute("insert into usuarios (usu_codigo, usu_senha, usu_nome) values (" & LoginAplicativo + 1 & ",'','k2tools')")
            _s.Ocorrencias(0, Application.ProductName, "cTools", "_u.loginAplicativo", "Usuário inserido, " & LoginAplicativo + 1, False, True, True)
        End If
        ' _u.BuscaDadosUsuario(idUsuario)
        _s.Ocorrencias(0, Application.ProductName, "cTools", "_u.loginAplicativo", "Usuário localizado, " & LoginAplicativo, VbGlo_Console, True, True)

    End Function

    Public Function Controle_Manager(strSql As String) As Boolean
        ' <add key = "pm" value="server=209.209.40.85;port=34688;database=manager;userId=User;password=UserPassaword;preload reader=True;"/>

        Controle_Manager = True

        If InStr(_PG.DbConn.ConnectionString, "dbsifam") = False Then
            ' se conexao interna <> dbsifam, desvia da rotina
            Exit Function
        End If

        Dim vsDetalheLog As String
        Dim StrUser As String = "user_" & LCase(Application.ProductName)
        Dim StrPassword As String = Replace(StrUser, "a", "4")   ' senha é o usuario troc
        StrPassword = Replace(StrPassword, "e", "3")
        StrPassword = Replace(StrPassword, "i", "1")
        StrPassword = Replace(StrPassword, "o", "0")

        Dim drSetup As Npgsql.NpgsqlDataReader
        If _PG.Conectar() = False Then End
        drSetup = _PG.DrQuery("select * from setup_host where name='manager'")
        If drSetup.HasRows = False Then _PG.Desconectar() : Exit Function
        drSetup.Read()
        Dim StrConection As String = "server=Host;port=Porta;database=Database;userId=User;password=UserPassaword;preload reader=True;"
        StrConection = Replace(StrConection, "UserPassaword", StrPassword)
        StrConection = Replace(StrConection, "User", StrUser)
        StrConection = Replace(StrConection, "Database", drSetup.Item(1))
        StrConection = Replace(StrConection, "Porta", drSetup.Item("host_port"))
        StrConection = Replace(StrConection, "Host", drSetup.Item("host"))
        _PG.Desconectar()

        Dim _PG_Controle As New ClsBancoNPG(StrConection, "", "")
        Try
            ' linha abaixo é para conexoes odbc
            'A_ConexaoBancoPrincipal = New NpgsqlConnection("Provider=sqloledb;DRIVER={PostgreSQL ANSI};UserID=" & vsA_DatabaseUser & ";pwd=" & vsA_DatabasePassaword & ";SERVER=" & vsA_Host & ";Port=5432;Database=" & vsA_Base & ";")

            If _PG_Controle.Conectar(False) = False Then
                Exit Function
            End If
            Dim dr As Npgsql.NpgsqlDataReader = _PG_Controle.DrQuery("Select * from dashboard.licenciamento where app='" & LCase(Application.ProductName) & "'")
            If dr.HasRows = False Then
                ' se não consegue achar cliente no postgre, validação da licença segue padrão (agora de 3 em 3 meses)
                ' ou seja se em 3 meses não conseguir conexão com o postgre sistema vai travar
                _PG_Controle.Desconectar()
                Exit Function
            Else
                dr.Read()
                Dim vnSituacao As Integer = dr.Item("situacao")
                If vnSituacao = 1 Then
                    ' parada com mensagem
                    vsDetalheLog = dr.Item("instrucao")
                    MsgBox(vsDetalheLog)
                    End
                ElseIf vnSituacao = 9 Then
                    ' parada sem mensagem
                    End
                Else
                    vsDetalheLog = "Sistema liberado."
                End If

                If strSql <> "" Then
                    Try
                        _PG_Controle.Execute(strSql)
                    Catch ex As Exception
                        vbResult = _s.GravaLogTXT(_u.Login, _w.Nome, vsGlo_Log, "cBancoNPG.Controle_Acesso(Execute)", ex.Message & "-query:", strSql, False)
                    End Try

                End If

            End If
            Controle_Manager = True
            _PG_Controle.Desconectar()
        Catch ex As Exception
            MsgBox(ex.Message)
            'MsgBox("Erro na localização do servidor de autorização de acesso. " & vsA_Host & ", base : " & vsA_Base & Chr(13) & Err.Number & ", " & Err.Description)
        End Try
fim:
    End Function

    Public Function VerificaMensagemUsuario(ByVal vsLogin As String) As String
        VerificaMensagemUsuario = ""
        vbTemMensagemUsuario = False
        If _PG.Conectar() = False Then Exit Function
        Dim drGeneric As Npgsql.NpgsqlDataReader
        drGeneric = _PG.DrQuery("select id_mensagem,to_ascii(mensagem,'LATIN1') as mensagem, data from mensagem where situacao='A' and (destinatario_login='" & vsLogin & "' or destinatario_login='') and id_mensagem not in (select id_mensagem from mensagem_usuario where login='" & vsLogin & "')")
        If drGeneric.HasRows Then
            drGeneric.Read()
            If MsgBox("Mensagem N. " & drGeneric.Item(0) & " de " & drGeneric.Item(2) & Chr(13) & Chr(13) & drGeneric.Item(1) & Chr(13) & Chr(13) & "Clique OK se você entendeu a mensagem, cancelar para ler mais tarde.", vbOK, "Mensagem do Administrador do sistema") = vbOK Then
                _PG.Execute("insert into mensagem_usuario (id_mensagem, login, data_leitura) values (" & drGeneric.Item(0) & ",'" & vsLogin & "', current_date + current_time)")
            End If
        End If
        _PG.Desconectar()
    End Function

End Class

Public Class AppConfig

    ' nao utilizada, falta aprender mais sobre ...
    Public _config As Configuration
    Dim section As ConnectionStringsSection
    Dim appName As String = "biosifam.exe"
    Dim LoginAppConfig As String

    Public Sub New()
        Try
            LoginAppConfig = ConfigurationManager.AppSettings("login")

            'Toma o nome do arquivo EXE sem a extensão .config'
            _config = ConfigurationManager.OpenExeConfiguration(appName)
            section = DirectCast(_config.GetSection("connectionStrings"), ConnectionStringsSection)
            'MsgBox(StringConnection)

        Catch ex As Exception
            'MsgBox(ex.Message & " - " & appName)
        End Try

    End Sub

    Public Function GetProperty(ByVal SectionName As String) As String
        GetProperty = ""
        For i = 0 To section.ConnectionStrings.Count - 1
            If section.ConnectionStrings.Item(i).Name = SectionName Then
                GetProperty = section.ConnectionStrings.Item(i).ConnectionString
                Return _s.CriptaTexto(section.ConnectionStrings.Item(i).ConnectionString, False, "")
            End If
        Next
    End Function

    Public Function GetSection(ByVal SectionName As String) As String
        GetSection = ""
        If IsDBNull(_config.AppSettings.Settings.Item(SectionName).Value) Then Exit Function
        GetSection = _config.AppSettings.Settings.Item(SectionName).Value
        If GetSection.Substring(0, 6) = "server" Then
            ' se alguma das string de conexao nao estiver criptografada aqui vai criptograr
            ' so deve passar aqui na compilacao
            _config.AppSettings.Settings.Remove(SectionName)
            _config.AppSettings.Settings.Add(SectionName, _s.CriptaTexto(GetSection, True, "base" & SectionName))
            _config.Save(ConfigurationSaveMode.Modified)
            ConfigurationManager.RefreshSection("appSettings")
            VerificaConfigEncryption()

        End If
        Return _s.CriptaTexto(_config.AppSettings.Settings.Item(SectionName).Value, False, "base" & SectionName)

    End Function
    Public Sub VerificaConfigEncryption()

        ' tem que refenciar system.configuration,procurar dentro do microsoft net
        ' http://www.macoratti.net/07/06/vbn5_psc.htm
        ' https://docs.microsoft.com/pt-br/dotnet/framework/data/adonet/connection-string-builders
        Try
            If section.SectionInformation.IsProtected Then
                ' Remove a cifragem
                ' section.SectionInformation.UnprotectSection()
            Else
                ' Cifra a seção
                ' section.SectionInformation.ProtectSection("RSAProtectedConfigurationProvider")
                section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider")
                ' Salva a configuração atual.
                _config.Save()
            End If

            'MsgBox("Protegido={0}" & section.SectionInformation.IsProtected)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


End Class


