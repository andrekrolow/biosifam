'SIFAM - Sistema Informatizado do Fundo de Assistência Médica
'Copyright (c) 2010 COINPEL
'Responsável: André Krolow (andrekrolow@gmail.com)
'Criação    : 24/08/2010
'Modificação: 16/01/2017

Imports System.Data.OleDb
Imports System.Data
Imports System.IO
Imports Microsoft.VisualBasic
Imports System.Net

Public Class cBancoPG
    Public ConexaoBancoPrincipal As System.Data.Odbc.OdbcConnection = Nothing
    Public id_BiosifamSetup As Integer
    Public vnModo As Integer            ' modo=1 ativa modo TESTE, impedindo atualizações locais na base real no ambiente de teste
    Dim fluxoTexto As IO.StreamReader   'Classe de leitura de arquivos (txt)

    'Dim strHost As String = "192.168.0.75"
    Dim strHost As String = "db3.pelotas.com.br"    ' www4 - 192.168.0.211
    Dim strBase As String = "prevpel2"
    Dim vsDatabaseUser As String = "ubiosifam"
    Dim vsDatabasePassaword As String = "d4t4b4nk" '"CXFvPhWcPkNgvGTBsN+FcQ=="  ' senha é d4t4b4nk

    Dim A_ConexaoBancoPrincipal As System.Data.Odbc.OdbcConnection = Nothing
    Dim vsA_Host As String = "db3.pelotas.com.br"    ' www4 - 192.168.0.211
    Dim vsA_Base As String = "prevpel2"
    Dim vsA_DatabaseUser As String = "ubiosifam"
    Dim vsA_DatabasePassaword As String = "d4t4b4nk" '"CXFvPhWcPkNgvGTBsN+FcQ=="  ' senha é d4t4b4nk

    Dim linhaTexto As String = ""
    Dim _criptografia As New Criptografia()
    Dim _util As New clsUtil()

    Dim vsDetalheLog As String = ""

    Public Id As Long
    Public vbTemMensagemUsuario As Boolean = False
    Public MensagemUsuarioNaoVisualizada As String = ""

    Dim vsAppNome As String = "biosifam"
    Dim vsAppLocalizacao As String = "http:\\downloads\pelotas.com.br\"   ' the web location of the files
    Dim vsAppNuvemExe As String = ""

    Dim myWebClient As New WebClient ' the web client

    Public Sub Log_Gravar(ByVal Fonte As String, ByVal Descricao As String, ByVal vbMostraLog As Boolean, ByVal idSelecionado As String, ByVal idMedico As Integer)
        Dim idAplicativo As Long = LocalizaAplicativo(Fonte, Descricao)
        If idAplicativo = 0 Then
            _util.Mensagem_LogLocal("erro ao localizar aplicativo-" & Fonte & "-" & Descricao, False, "Log_Gravar", True, "")
        Else
            Try
                executaQuery("insert into LOG (codaplicacao, login, datahora, detalhe, id_medico) VALUES (" & idAplicativo & ",'" & vsGlo_Login & "',current_date + current_time,'" & idSelecionado & "'," & idMedico & ")")
            Catch
            End Try
        End If
        If vbMostraLog Then MsgBox(Descricao)
    End Sub

    Public Function LocalizaAplicativo(ByVal vsAplicativoChave As String, ByVal vsAplicativoNome As String) As Long
        'modTitulosOnLine
        Dim drGeneric As Npgsql.NpgsqlDataReader
        LocalizaAplicativo = 0
        Try
            If ConexaoBancoPrincipal.State = False Then Conectar(False, False)
            drGeneric = _PG.drQuery("select codaplicacao from aplicacao where fonte='" & vsAplicativoChave & "'")
            If drGeneric.HasRows Then
                drGeneric.Read()
                LocalizaAplicativo = drGeneric.Item(0)
            Else
                _util.Mensagem_LogLocal("criado aplicativo-" & vsAplicativoChave, False, "LocalizaAplicativo", True, "")
                _PG.Execute("insert into aplicacao (superior, fonte, descricao, tipo, situacao) values (" &
                                    "0, '" & vsAplicativoChave & "','" & vsAplicativoNome & "', 'a',1)")
                drGeneric = drQuery("select codaplicacao from aplicacao where fonte='" & vsAplicativoChave & "'")
                If drGeneric.HasRows Then
                    drGeneric.Read()
                    LocalizaAplicativo = drGeneric.Item(0)
                End If
            End If
        Catch
        End Try
        drGeneric = Nothing
    End Function

    Public Function Conectar(ByVal vbMostrarErro As Boolean, ByVal vsModoTeste As Boolean) As Boolean
        Conectar = False
        ' _criptografia.CriptaTexto(vsDatabasePassaword, False) 

        Try
            ConexaoBancoPrincipal = New System.Data.Odbc.OdbcConnection("Provider=sqloledb;DRIVER={PostgreSQL ANSI};UID=" & vsDatabaseUser & ";pwd=" & vsDatabasePassaword & ";SERVER=" & strHost & ";Port=5432;Database=" & strBase & ";")

            'local para testes
            'ConexaoBancoPrincipal = New System.Data.Odbc.OdbcConnection("Provider=sqloledb;DRIVER={PostgreSQL ANSI};UID=postgres;pwd=postgre;SERVER=localhost;Port=5432;Database=prevpel2;")
            'ConexaoBancoPrincipal = New System.Data.Odbc.OdbcConnection("Provider=sqloledb;DRIVER={PostgreSQL UNICODE};UID=prevpel;pwd=" & _criptografia.CriptaTexto(vsDatabasePassaword, False) & ";SERVER=" & strHost & ";Port=5432;Database=" & strBase & ";")

            'muito bom sobre provedires e conections https://www.connectionstrings.com/postgresql/

            ConexaoBancoPrincipal.Open()
            Conectar = True
        Catch ex As Exception
            If Err.Number = 5 And ex.Message = "ERROR [IM002] [Microsoft][ODBC Driver Manager] Nome da fonte de dados não encontrado e nenhum driver padrão especificado" Then
                ' nome da fonte de dados não encontrato - odbc não instalado

                ' da loop e trava
                ' _util.ExecutaShell("setup_odbc_postgreSQL_x86.exe", "Driver ODBC Postgre", "", 1, "http://downloads.pelotas.com.br/ferramentas/setup_odbc_postgreSQL_x86.exe", True)

                If MsgBox("O drive de comunicação com o banco de dados não foi localizado, deseja tentar instalá-lo automaticamente ? ", vbYesNo, Application.ProductName) = vbYes Then
                    Try
                        myWebClient.DownloadFile("http://downloads.pelotas.com.br/ferramentas/setup_odbc_postgreSQL_x86.exe", Application.StartupPath & "\setup_odbc_postgreSQL_x86.exe")        ' download the new version    
                        System.Diagnostics.Process.Start(Application.StartupPath & "\setup_odbc_postgreSQL_x86.exe", "")
                    Catch ex1 As Exception
                        MsgBox("Erro a tentar instalar a fonte de dados ODBC." & Chr(13) & "Mensagem: " & ex1.Message)
                    End Try
                Else
                    MsgBox("Não é possível estabelecer uma conexão com o servidor de banco de dados sem a presença do driver de comunicação, Procure apoio Técnico..")
                End If

                Exit Function
                MsgBox("Erro a tentar estabelecer uma conexão com o Servidor de Banco de Dados. " & Chr(13) & "Servidor: " & strHost & ", base :  " & strBase & Chr(13) & "Mensagem: " & Err.Number & ", " & Err.Description)
            End If
        End Try

    End Function

    Public Sub Desconecta()
        ConexaoBancoPrincipal.Close()
        ConexaoBancoPrincipal.Dispose()
    End Sub
    Public Function PopulaCombo(ByVal vsSql As String, ByVal COMBO As ComboBox) As Boolean
        Dim drGeneric As Npgsql.NpgsqlDataReader
        drGeneric = _PG.drQuery(vsSql)
        If drGeneric.HasRows Then
            While drGeneric.Read
                COMBO.Items.Add(New MeuItemData(drGeneric.Item(0).ToString, Trim(drGeneric.Item(1).ToString)))
            End While
        End If
        PopulaCombo = True
    End Function

    Public Function ObtemDados(ByVal tabela As String, ByVal campos As String, ByVal condicao As String) As DataSet
        Dim ds As New DataSet
        Dim da As New System.Data.Odbc.OdbcDataAdapter("SELECT " & campos & " FROM " & tabela & " WHERE " & condicao, ConexaoBancoPrincipal)
        'Dim tpt As New TTemplate
        da.Fill(ds)
        'Dim Usuarios As DataRowCollection = ds.Tables(0).Rows
        Return ds
    End Function

    Public Function ObtemQuery(ByVal query As String) As DataSet
        Dim ds As New DataSet
        Dim da As New System.Data.Odbc.OdbcDataAdapter(query, ConexaoBancoPrincipal)
        'Dim tpt As New TTemplate
        da.Fill(ds)
        'Dim Usuarios As DataRowCollection = ds.Tables(0).Rows
        Return ds
    End Function

    Public Function ObtemQueryCount(ByVal vsSQL As String) As Integer
        ObtemQueryCount = 0
        Dim dr As Npgsql.NpgsqlDataReader
        dr = drQuery(vsSQL)
        If dr.HasRows Then
            While dr.Read
                ObtemQueryCount = dr.Item(0)
            End While
        End If
    End Function

    Public Function drQuery(ByVal query As String) As Npgsql.NpgsqlDataReader
        drQuery = Nothing
        Try
            Dim cm As System.Data.Odbc.OdbcCommand = New System.Data.Odbc.OdbcCommand(query, ConexaoBancoPrincipal)
            Dim dr As Npgsql.NpgsqlDataReader = cm.ExecuteReader
            Return (dr)
        Catch ex As Exception
            MsgBox("Erro de execução de instrução (drQuery) " & strHost & ", base : " & strBase & Chr(13) & Err.Number & ", " & Err.Description)
        End Try
    End Function

    Public Sub executaQuery(ByVal query As String)
        Id = 0
        Try
            'If ConexaoBancoPrincipal.State = False Then Conecta()
            Dim comando As New System.Data.Odbc.OdbcCommand(query, ConexaoBancoPrincipal)
            ''comando.ExecuteReader()
            'retorna o numero de linhas afetadas...
            Id = comando.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Erro de execução de instrução (executaQuery) " & strHost & ", base : " & strBase & Chr(13) & Err.Number & ", " & Err.Description)
        End Try
    End Sub

    Public Property RetornoExecute() As Long
        Get
            RetornoExecute = Id
        End Get
        Set(ByVal Value As Long)
            Id = Value
        End Set
    End Property

    Public Function VerificaMensagemUsuario(ByVal vsLogin As String) As String
        VerificaMensagemUsuario = ""
        vbTemMensagemUsuario = False
        Conectar(False, False)
        Dim drGeneric As Npgsql.NpgsqlDataReader
        drGeneric = drQuery("select id_mensagem, mensagem, data from mensagem where id_mensagem not in (select id_mensagem from mensagem_usuario where login='" & vsLogin & "')")
        If drGeneric.HasRows Then
            drGeneric.Read()
            If MsgBox("Mensagem N. " & drGeneric.Item(0) & " de " & drGeneric.Item(2) & Chr(13) & Chr(13) & drGeneric.Item(1) & Chr(13) & Chr(13) & "Clique OK se você entendeu a mensagem, cancelar para ler mais tarde.", vbOK, "Mensagem do Administrador do sistema") = vbOK Then
                executaQuery("insert into mensagem_usuario (id_mensagem, login, data_leitura) values (" & drGeneric.Item(0) & ",'" & vsLogin & "', current_date + current_time)")
            End If
        End If
        Desconecta()
    End Function

    Public Function AutorizaAcesso() As Boolean
        AutorizaAcesso = False
        '"elmer""csyjwezy""csyjwezy""HdeQ2qBv3sXGIfIKsmFOh2cHTxmgIMkC"
        vsA_Host = _criptografia.CriptaTexto("0LVjOUxeN5hc9CmuL1Zc8Rq3ZC+/nkmbk6NaoGlMnuM=", False)
        vsA_Base = _criptografia.CriptaTexto("3lAiA+gguEaTo1qgaUye4w==", False)
        vsA_DatabaseUser = _criptografia.CriptaTexto("3lAiA+gguEaTo1qgaUye4w==", False)
        vsA_DatabasePassaword = _criptografia.CriptaTexto("Mjf4q+zEIh0TELczXhrif7skMJFcAML/8Bu1MJAk396To1qgaUye4w==", False)

        Try
            A_ConexaoBancoPrincipal = New System.Data.Odbc.OdbcConnection("Provider=sqloledb;DRIVER={PostgreSQL ANSI};UID=" & vsA_DatabaseUser & ";pwd=" & vsA_DatabasePassaword & ";SERVER=" & vsA_Host & ";Port=5432;Database=" & vsA_Base & ";")
            A_ConexaoBancoPrincipal.Open()

            Dim cm As System.Data.Odbc.OdbcCommand = New System.Data.Odbc.OdbcCommand("select * from dashboard.licenciamento where app='biosifam'", A_ConexaoBancoPrincipal)
            Dim dr As Npgsql.NpgsqlDataReader = cm.ExecuteReader

            If dr.HasRows = False Then
                ' se não consegue achar cliente no postgre, validação da licença segue padrão (agora de 3 em 3 meses)
                ' ou seja se em 3 meses não conseguir conexão com o postgre sistema vai travar
                GoTo fim
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
            End If
            AutorizaAcesso = True
        Catch ex As Exception
            'MsgBox("Erro na localização do servidor de autorização de acesso. " & vsA_Host & ", base : " & vsA_Base & Chr(13) & Err.Number & ", " & Err.Description)
        End Try
fim:
        A_ConexaoBancoPrincipal.Close()
    End Function


    ' padroa K2--------------------------
    Public Property dbConn() As System.Data.Odbc.OdbcConnection ' NpgsqlConnection
        Get
            dbConn = ConexaoBancoPrincipal
        End Get
        Set(ByVal value As System.Data.Odbc.OdbcConnection)
            'Set(ByVal value As NpgsqlConnection)
            ConexaoBancoPrincipal = value
        End Set

    End Property

    Public Function dbExecute(ByVal query As String) As Boolean
        dbExecute = 0
        Try
            'Dim cmP As New NpgsqlCommand(query, connection)
            Dim cmP As New System.Data.Odbc.OdbcCommand(query, ConexaoBancoPrincipal)

            dbExecute = cmP.ExecuteNonQuery()
            cmP.Dispose()
            dbExecute = True
        Catch
            dbExecute = Err.Number
            ' não gravar ocorrencia no banco

            ' ERROR: 53100: could not extend file "base/23766/35378259": No space left on device, 5
            Dim vbEnviaemail As Boolean = False
            If Err.Number = 53100 Then vbEnviaemail = True
            _s.Ocorrencias(1, "Conexão Postgre", "cBancoPg", "dbExecute", "Erro ao executar SQL, " & query & "," & Err.Description & ", " & Err.Number, True, False, True, vbEnviaemail)
        End Try

    End Function
    '-------------------------------------------------
End Class

Public Class MeuItemData

    Public Id As Object
    Public Descricao As String
    
    Public Sub New(ByVal NovoValor As Object, ByVal NovaDescricao As String)
        Id = NovoValor
        Descricao = NovaDescricao
    End Sub

    Public Overrides Function ToString() As String
        Return Descricao
    End Function

End Class
