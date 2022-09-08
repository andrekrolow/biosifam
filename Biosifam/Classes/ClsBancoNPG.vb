' classe especializada em conexão POSTGRES - driver npg (native postgres)

Imports Npgsql            ' driver postgre - adicionar como referencia - https://nhatkiemphi.blogspot.com/2013/08/npgsql-users-manual.html
Imports System.IO

' sobre conexoes, uma coisa é o tipo de conexao ODBC x Nativo outra coisa é driver de cada banco para cada tipo de conexao.

' estudar-->  dim drLeitura As Data.IDataReader , este idatareader pode trabalhar com conexao npg e odbc
'           idatareader nao tem o hasrow, usar direto o read
'            a principio o idatareade parece show.. nao sei sobre desempenho.

Public Class ClsBancoNPG
    Public Dr As NpgsqlDataReader
    Public Conn As New NpgsqlConnection
    Public UltimoErro As String = ""

    Private Cm As NpgsqlCommand
    Private VsConectionString As String = ""
    Private VsConectionStringRedeInterna As String = ""
    Private DrGeneric As NpgsqlDataReader
    Public vsLogNome As String = vsGlo_Log

    Private ViRetorno As Long = 0

    Public Sub New(ByVal vsConnectionString As String, ByVal Logname As String, Optional vsConnectionStringInterna As String = "")

        VsConectionString = vsConnectionString
        VsConectionStringRedeInterna = vsConnectionStringInterna
        If Logname <> "" Then vsLogNome = Logname
    End Sub

    Public Function Conectar(Optional BolMostrarErros As Boolean = True) As Boolean
        Conectar = False
        UltimoErro = ""
        Dim IntContador As Integer = 0
Conectar:
        IntContador += 1
        Try
            Conn = New NpgsqlConnection(VsConectionString)
            Conn.Open()
            Conectar = True

        Catch ex As Exception
            UltimoErro = ex.ToString()
            'If UltimoErro.Substring(0, 63) = "System.Exception: Timeout while getting a connection from pool." Then
            '    vbResult = _s.GravaLogTXT(_u.Login, _w.Nome, vsLogNome, "cBancoNPG.Conectar", "Erro ao conectar no banco de dados", ex.Message, False)
            '    If IntContador = 1 Then GoTo Conectar
            ' End If
            If VsConectionStringRedeInterna <> "" And VsConectionStringRedeInterna <> VsConectionString Then
                Try
                    ' nas maquinas da rede interna ñão consegue localizar servidor pelo dns e porta externa, então preciso
                    ' utilizar direto o ip interno 192.16.0.214 e a porta interna 5432 
                    Conn = New NpgsqlConnection(VsConectionStringRedeInterna)
                    Conn.Open()
                    Conectar = True
                    ' para melhor performanca, quando identifica que deu na rede interna passa a usar sempre essa conexao
                    VsConectionString = VsConectionStringRedeInterna
                Catch ex2 As Exception
                    UltimoErro = ex2.ToString()
                    'If UltimoErro.Substring(0, 63) = "System.Exception: Timeout while getting a connection from pool." Then
                    '   vbResult = _s.GravaLogTXT(_u.Login, _w.Nome, vsLogNome, "cBancoNPG.Conectar", "Erro ao conectar no banco de dados Interno", ex2.Message, False)
                    '   Conn.ClearPool()
                    '   If IntContador = 1 Then GoTo Conectar
                    'End If
                    vbResult = _s.GravaLogTXT(_u.Login, _w.Nome, vsLogNome, "cBancoNPG.Conectar", "Erro ao conectar no banco de dados", ex.Message, BolMostrarErros)
                    vbResult = _s.GravaLogTXT(_u.Login, _w.Nome, vsLogNome, "cBancoNPG.Conectar", "Erro ao conectar no banco de dados Interno", ex2.Message, BolMostrarErros)

                    If _t.VerificaConexao_TcpSocket = False Then
                        vbResult = _s.GravaLogTXT(_u.Login, _w.Nome, vsLogNome, "cBancoNPG.Conectar", "Sistema sem Conexão com Internet", "", BolMostrarErros)
                    End If
                End Try
            Else
                vbResult = _s.GravaLogTXT(_u.Login, _w.Nome, vsLogNome, "cBancoNPG.Conectar", "Erro ao conectar no banco de dados", ex.Message, BolMostrarErros)
            End If
        Finally
        End Try

    End Function

    Public Function DrQuery(ByVal query As String, Optional ByVal vbMostraErro As Boolean = True) As NpgsqlDataReader
        'If DrQuery.IsClosed = False Then DrQuery.Close() ' conector npgsql exite fechamento, odbc não
        DrQuery = Nothing
        UltimoErro = ""
        Try
            Cm = New NpgsqlCommand(query, Conn)
            DrQuery = Cm.ExecuteReader()
            Cm.Dispose()
        Catch ex As Exception
            UltimoErro = ex.Message
            vbResult = _s.GravaLogTXT(_u.Login, _w.Nome, vsLogNome, "cBancoNPG.drQuery", ex.Message & "-query:", query, vbMostraErro)
        End Try
    End Function

    Public Function Execute(ByVal query As String, Optional ByVal vbMostraErro As Boolean = True) As Boolean
        Execute = False
        ViRetorno = 0
        UltimoErro = ""
        If _PG.Conectar() = False Then Exit Function

        Try
            Cm = New NpgsqlCommand(query, Conn)
            ViRetorno = Cm.ExecuteNonQuery()
            Cm.Dispose()
            Execute = True
        Catch ex As Exception
            UltimoErro = ex.Message
            vbResult = _s.GravaLogTXT(_u.Login, _w.Nome, vsLogNome, "cBancoNPG.Execute", ex.Message & "-query:", query, vbMostraErro)
        End Try
    End Function

    Public Function InsereArquivoBinario(ByVal PiIdPrestador As Integer, PsTipo As String, PsIdentificador As String, StrArquivo As String) As Boolean
        'http://www.macoratti.net/13/03/vbn_pdf1.htm
        ' esta rotina grava pdf e imagens (jpg ou jpeg) tudo é binario, os pdf podem ser identificados pela string ´%PDF' bem no inicio do arquivo
        InsereArquivoBinario = False
        ViRetorno = 0
        UltimoErro = ""

        Try
            Dim IdAutorizacao As Integer = 0
            If PsTipo = "P" Then
                ' autorizacao é de prescricao medica
                If StrArquivo.ToString.Substring(0, 15) = "Autorizaçao N. " Then
                    ' usou uma autorização já existente, entao upload ja´foi realizado entao é só vincular atraves do id_atendimentop_autorizacao
                    IdAutorizacao = Trim(StrArquivo.ToString.Substring(15, StrArquivo.ToString.Length - 15))
                    _PG.Execute("update atendimento_autorizacao set situacao='F' where id_atendimento_autorizacao=" & IdAutorizacao)
                    ' troca o medico que gerou a prescricao e a autorizacao para a clinica que usou a prescricao
                    _PG.Execute("update upload set id_autorizacao='" & IdAutorizacao & "', identificador='" & PsIdentificador & "', id_prestador=" & oMedicoConveniado.Id & " where tipo='P' and identificador='" & IdAutorizacao & "'")

                    ' vsSql = "select * from upload where tipo='A' and identificador='" & IntAutorizacao & "'"

                    Exit Function
                Else
                    ' procedimento normal, faz upload da imagem

                End If
            End If


            'Dim fileSize As Double = GetFileSize(txtArquivo.Text)
            Dim fileSize As New System.IO.FileInfo(StrArquivo)
            If fileSize.Length > 5242880 Then
                MsgBox("O tamanho do arquivo excedeu o valor permitido de 5Mbytes. Necessário reduzir o tamanho do arquivo. Utilize o formulário de 'Upload de Documentos' para tentar enviar este documento novamente.")
                Exit Function
            End If

            If Conectar() = False Then End



            Dim da As New Npgsql.NpgsqlDataAdapter("SELECT * FROM upload where id_prestador=" & PiIdPrestador & " and tipo='" & PsTipo & "' and identificador='" & PsIdentificador & "'", _PG.Conn)
            ' Cria comando SQL contendo ? parametros de BLOB.
            ' da.InsertCommand = New Npgsql.NpgsqlCommand("INSERT INTO " & strTabela & " (binario," & strCampo & ",login,ip,dt_alteracao,hr_alteracao) Values(?,?,?,?,?,?)", _PG.Conn)
            da.InsertCommand = New Npgsql.NpgsqlCommand("INSERT INTO UPLOAD (id_prestador, tipo, identificador, login, ip, dt_alteracao, hr_alteracao,arquivo,situacao,id_autorizacao) Values(:id_prestador, :tipo, :identificador,:login, :ip, :dt_alteracao, :hr_alteracao,:arquivo,:situacao,:id_autorizacao)", _PG.Conn)
            da.InsertCommand.CommandType = CommandType.Text
            da.InsertCommand.Parameters.Add("id_prestador", NpgsqlTypes.NpgsqlDbType.Integer, 10, "id_prestador")
            da.InsertCommand.Parameters.Add("tipo", NpgsqlTypes.NpgsqlDbType.Char, 2, "tipo")
            da.InsertCommand.Parameters.Add("identificador", NpgsqlTypes.NpgsqlDbType.Char, 10, "identificador")
            da.InsertCommand.Parameters.Add("login", NpgsqlTypes.NpgsqlDbType.Char, 20, "login")
            da.InsertCommand.Parameters.Add("ip", NpgsqlTypes.NpgsqlDbType.Char, 20, "ip")
            da.InsertCommand.Parameters.Add("dt_alteracao", NpgsqlTypes.NpgsqlDbType.Date, 7, "dt_alteracao")
            da.InsertCommand.Parameters.Add("hr_alteracao", NpgsqlTypes.NpgsqlDbType.Char, 5, "hr_alteracao")
            da.InsertCommand.Parameters.Add("arquivo", NpgsqlTypes.NpgsqlDbType.Bytea, 500, "arquivo")
            da.InsertCommand.Parameters.Add("situacao", NpgsqlTypes.NpgsqlDbType.Char, 1, "situacao")
            da.InsertCommand.Parameters.Add("id_autorizacao", NpgsqlTypes.NpgsqlDbType.Integer, 10, "id_autorizacao")

            ' situacao P=pendente, A-auditado, R-rejeitado
            ' situacao_data
            ' situacao_detalhe

            Dim digitais As DataSet = New DataSet
            da.Fill(digitais, "upload")
            ' Adiciona nova coluna.
            Dim newRow As DataRow = digitais.Tables("upload").NewRow()
            newRow("id_prestador") = PiIdPrestador
            newRow("tipo") = PsTipo
            newRow("identificador") = PsIdentificador
            newRow("ip") = _t.ObtemEnderecoIP
            newRow("login") = "" & _u.Login
            newRow("hr_alteracao") = Date.Now.ToShortTimeString()
            newRow("dt_alteracao") = Date.Now.ToShortDateString()
            newRow("arquivo") = File.ReadAllBytes(StrArquivo)
            newRow("situacao") = "P"
            newRow("id_autorizacao") = IdAutorizacao

            digitais.Tables("upload").Rows.Add(newRow)
            AddHandler da.RowUpdated, New Npgsql.NpgsqlRowUpdatedEventHandler(AddressOf onRowUpdated) '  OnRowUpdated)
            ' Atualiza DataSet.
            da.Update(digitais, "upload")

            InsereArquivoBinario = True

            Return newRow(0)

        Catch ex As Exception
            MsgBox(Err.Description & " Verifique o problema e informe posteriomente o documento através do menu Upload de Documentos.")
        End Try
        Desconectar()
    End Function

    ' Procedure de evento para  OnRowUpdated
    Private Sub onRowUpdated(ByVal sender As Object, ByVal args As NpgsqlRowUpdatedEventArgs)
        'Private Sub onRowUpdated(ByVal sender As Object, ByVal args As NpgsqlRowUpdatedEventArgs)
        '.OdbcRowUpdatedEventArgs
        If _PG.Conectar() = False Then Exit Sub

        ' Inclui a variavel na linha de comando e retorna o valor identificado do banco de dados.
        Dim newID As Integer = 0
        Dim idCMD As Npgsql.NpgsqlCommand = New Npgsql.NpgsqlCommand("SELECT last_value FROM upload_id_upload_seq", _PG.Conn)
        If args.StatementType = StatementType.Insert Then
            newID = CInt(idCMD.ExecuteScalar())
            args.Row(0) = newID
        End If
        _PG.Desconectar()
    End Sub

    Public Property RetornoExecute() As Long
        Get
            RetornoExecute = ViRetorno
        End Get
        Set(ByVal Value As Long)
            ViRetorno = Value
        End Set
    End Property

    Public Function RecordCount(ByVal vsSQL As String) As Integer
        RecordCount = 0
        Dim dr As Npgsql.NpgsqlDataReader
        dr = DrQuery(vsSQL)
        If dr.HasRows Then
            While dr.Read
                RecordCount = dr.Item(0)
            End While
        End If
    End Function

    Public Function DsQuery(ByVal query As String) As DataSet
        Try
            DsQuery = Nothing
            Dim ds As New DataSet
            If Conectar() = False Then Exit Function
            Dim da As New NpgsqlDataAdapter(query, Conn)
            da.Fill(ds)
            DsQuery = ds
        Finally
            Desconectar()
        End Try
    End Function

    Public Function LastVal() As Long
        LastVal = 0
        dim drPG As Npgsql.NpgsqlDataReader
        Try
            drPG = DrQuery("select lastval()")
            If drPG.HasRows Then drPG.Read()
            LastVal = drPG.Item(0)
        Catch ex As Exception

        End Try
    End Function

    Public Function ProximoCodigo(ByVal vsTabela As String, ByVal vsCampo As String) As Long
        ProximoCodigo = 0
        DrGeneric = DrQuery("select max(" & vsCampo & ") as maximo from " & vsTabela)
        If DrGeneric.HasRows Then
            DrGeneric.Read()
            ProximoCodigo = IIf(IsDBNull(DrGeneric.Item(0)), 0, DrGeneric.Item(0))
            ProximoCodigo += 1
        End If
    End Function

    Public Function DataServidor() As Date
        DataServidor = Nothing
        Dim ds As DataSet
        ds = DsQuery("select current_date ")
        If ds.Tables(0).Rows.Count = 0 Then Exit Function
        DataServidor = Format(ds.Tables(0).Rows(0).Item(0), "dd/MM/yyyy")
    End Function

    Public Sub Desconectar()
        Try
            Conn.Close()
            Conn.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Public Property DbConn() As NpgsqlConnection
        Get
            DbConn = Conn
        End Get
        Set(ByVal value As NpgsqlConnection)
            Conn = value
        End Set
    End Property

End Class



