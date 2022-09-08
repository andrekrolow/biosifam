Imports System.Environment

Public Class ClsEstação
    ' Máq ZERO
    ' Login-> Tem Médico ?  -> SIM -> Carrega Medico e Modo de Funcionamento e Cadastra Nova Máq no médico localizado
    '                       -> NAO -> Usuário é ADM/Suporte ? -> SIM -> Cadastra Nova Máq, ATIVA Modo Retaguarda para pode testar e configurar 
    '                                                         -> NAO -> Cadastra Máq -> Ativa Modo CONSULTA

    Public Modo As Long = 1
    ' 0-Retaguarda,             tarefas de manutenção em consultas e digitais

    ' 1-Consulta situação cadastro,   somente consultas mediante digital ou senha

    ' 2-Consultório Médico,     registros de consultas  - tabelas MEDICOS e consultas e consulta_retorno
    '                           se dentista usa         - + consulta_odontologica_procedimentos     - OBRIGATORIO GRAVAR PROCEdimENTO
    '                           se anestesista          - NOVAS tabelas atendimento e atendimento_servico - OBRIGATORIO GRAVAR PROCEdimENTO
    '                           se faz exames em consultorio - NOVAs tabelas atendimento e atendimento_servico - FACULTATIVO GRAVAR PROCEdimENTO

    ' 3-Exames,                 registros de exames     -  JURIDICA e NOVAs tabelas atendimento e atendimento_servico

    ' 4-Fisioterapia, (=2)      registros de consultas e SESSOES - tabelas medicos e consultas e consulta_retorno + fisioterapia_sessoes

    ' =====================esse é o objetivo final em todos os outros processos - tabela medicos e atendimento e atendimento_servico ================
    ' 5-Pronto Atendimento      registros de consultas -  MEDICOS e NOVAs tabelas atendimento e atendimento_servico - OBRIGATORIO GRAVAR PROCEdimENTO

    Public idWorkstation As Long = 0
    Public idPrestador As Long = 0
    Public Versao As String = ""
    Public UltimaAtualizacao As String = ""
    Public AtualizacaoConcluida As Boolean = False

    Dim StrLicenca As String = ""
    Dim idLeitor As Integer = 0

    Dim vsQuery As String = ""

    Public Property Nome() As String
        Get
            Nome = Environment.MachineName.ToString
        End Get
        Set(ByVal value As String)
        End Set
    End Property

    Public Property Licença() As String
        Get
            Licença = StrLicenca
        End Get
        Set(ByVal value As String)
        End Set
    End Property

    Public Property LeitorId() As Integer
        Get
            LeitorId = idLeitor
        End Get
        Set(ByVal value As Integer)
        End Set
    End Property
    Public Sub New()
        Modo = 1
    End Sub

    Public Sub Carregar(ByVal MAC As String)
        '"70:69:79:A6:C5:31"
        Dim drEstacao As Npgsql.NpgsqlDataReader
        Dim vsQuery As String = ""
        Versao = My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & Format(My.Application.Info.Version.Build, "0#")
        Modo = 1  ' em caso de erro

        If _PG.Conectar = False Then End
        'MAC = "fe80::4c3e:13b9:df8b:8027%14"
        ' paliativo para dignostica - erro ao buscar MAC
        If MAC = "" Then MAC = "' or id_prestador='" & _u.IdPrestador
        drEstacao = _PG.DrQuery("SELECT id_workstation,id_prestador, versao_atual, to_ascii(nome_maquina,'LATIN1') as nome,licenca,modo,ultimo_acesso,id_leitor_biometrico FROM workstation WHERE mac='" & MAC & "'")
        If drEstacao.HasRows Then
            drEstacao.Read()
            idWorkstation = drEstacao.Item("id_workstation")
            ' confere dados gravados no setup com dados da máquina
            If Trim(drEstacao.Item("versao_atual")) <> Versao Then
                ' versão é diferente, só atualizar
                vsQuery = ", versao_atual='" & Trim(My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & Format(My.Application.Info.Version.Build, "0#")) & "'"
                AtualizacaoConcluida = True
            End If
            ' como agora a estação pode ser usada por vários médico, o campo prestador nao significa que a estacao petence a determinado medico.
            ' agora significa o ultimo que usuou a estacao
            If drEstacao.Item("id_prestador") = 0 And _u.IdPrestador > 0 Then vsQuery = ", id_prestador=" & _u.IdPrestador
            UltimaAtualizacao = Format(drEstacao.Item("ultimo_acesso"), "dd/MM/yyyy")

            _PG.Execute("update workstation set login='" & _u.Login & "', ip='" & _t.ObtemEnderecoIP & "', ultimo_acesso=CURRENT_TIMESTAMP(0) " & vsQuery & " where id_workstation=" & idWorkstation, False)

            idLeitor = drEstacao.Item("id_leitor_biometrico")
            idPrestador = drEstacao.Item("id_prestador")
            StrLicenca = drEstacao.Item("licenca")
            Modo = drEstacao.Item("modo")

        Else
            ' se for carregar estação e ela nao existir tem que cadastrar
            Licença = Trim(NumeroLicençaGriaule())
            idLeitor = 0     ' quando pugar o leitor a rotina lá vai atualizar o id correto
            idPrestador = _u.IdPrestador
            CadastraWorkstation()
        End If
        _PG.Desconectar()
    End Sub

    Public Function CadastraWorkstation() As Boolean
        CadastraWorkstation = False
        Try
            If _PG.Conectar = False Then End
            vsQuery = "insert into workstation (id_prestador, versao_atual, licenca, mac, login, ip, nome_maquina,  ultimo_acesso, id_leitor_biometrico) values " &
            "(" & idPrestador & ",'" & Versao & "','" & Licença & "','" & _t.ObtemMAC & "','" & _u.Login & "','" & _t.ObtemEnderecoIP & "','" & _w.Nome & "', current_timestamp, " & vnGlo_idLeitor & ")"
            Dim drMax As Npgsql.NpgsqlDataReader
            _PG.Execute(vsQuery)
            drMax = _PG.DrQuery("select lastval()")
            If drMax.HasRows Then drMax.Read() : idWorkstation = drMax.Item(0)
            _PG.Desconectar()
            CadastraWorkstation = True
        Catch

        End Try

    End Function

    Public Function AtualizaWorkstation() As Boolean
        If _PG.Conectar = False Then End
        vsQuery = " id_prestador=" & idPrestador
        vsQuery &= ", versao_atual='" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & Format(My.Application.Info.Version.Build, "0#") & "'"
        vsQuery &= ", licenca='" & Trim(NumeroLicençaGriaule()) & "'"
        vsQuery &= ", mac='" & _t.ObtemMAC & "'"
        vsQuery &= ", login='" & _u.Login & "'"
        vsQuery &= ", ip='" & _t.ObtemEnderecoIP & "'"
        vsQuery &= ", nome_maquina='" & _w.Nome & "'"
        vsQuery &= ", ultimo_acesso=current_timestamp"
        vsQuery &= ", id_leitor_biometrico=" & vnGlo_idLeitor
        vsQuery &= ", modo=" & Modo
        vsQuery = "update workstation set " & vsQuery & " where id_workstation=" & idWorkstation
        _PG.Execute(vsQuery)
        _PG.Desconectar()
        AtualizaWorkstation = True
    End Function

End Class
