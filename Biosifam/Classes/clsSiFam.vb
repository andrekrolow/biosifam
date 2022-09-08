Imports GrFingerXLib

'-------------------------------------------------------------------------------
'GrFinger Sample
'(c) 2005 - 2010 Griaule Biometrics Ltda.
'http://www.griaulebiometrics.com
'-------------------------------------------------------------------------------
'
'This sample is provided with "GrFinger Fingerprint Recognition Library" and
'can't run without it. It's provided just as an example of using GrFinger
'Fingerprint Recognition Library and should not be used as basis for any
'commercial product.
'
'Griaule Biometrics makes no represfentations concerning either the merchantability
'of this software or the suitability of this sample for any particular purpose.
'
'THIS SAMPLE IS PROVIDED BY THE AUTHOR "AS IS" AND ANY EXPRESS OR
'IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES
'OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
'IN NO EVENT SHALL GRIAULE BE LIABLE FOR ANY DIRECT, INDIRECT,
'INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT
'NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
'DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
'THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
'(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
'THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
'
'You can download the trial version of GrFinger directly from Griaule website.
'
'These notices must be retained in any copies of any part of this
'documentation and/or sample.
'
'-------------------------------------------------------------------------------

' -----------------------------------------------------------------------------------
' Support and fingerprint management routines
' -----------------------------------------------------------------------------------

' Tipo de dados Raw image .
Public Structure RawImage
    Public img As Object    ' Imagem (binário).
    Public width As Long    ' Tamanho.
    Public height As Long   ' Altura.
    Public res As Long      ' Resolução.
End Structure

Public Class clsSiFam

    ' Constantes (otimização de código)
    Public Const ERR_CANT_OPEN_BD As Integer = -999
    Public Const ERR_INVALID_ID As Integer = -998
    Public Const ERR_INVALID_TEMPLATE As Integer = -997

    ' Importação de funções HDC do sistema Operacional
    Private Declare Function GetDC Lib "user32" (ByVal hwnd As Int32) As Int32
    Private Declare Function ReleaseDC Lib "user32" (ByVal hwnd As Int32, ByVal hdc As Int32) As Int32

    Private _banco As ClsBancoNPG
    Private _util As clsUtil
    Private strTabela As String = "digital"

    ' The last acquired image.
    Public raw As RawImage

    ' Último template adquirido.
    Public template As New TTemplate
    ' Reference to main form log.
    ReadOnly _lbLog As ListBox
    ' Reference to main form Image.
    Private _pbPic As PictureBox
    ' GrFingerX component
    Private _GrFingerX As AxGrFingerXLib.AxGrFingerXCtrl

    ' This class creates an Util class with some functions
    ' to help us to develop our GrFinger Application
    Public Sub New(ByRef lbLog As ListBox, ByRef pbPic As PictureBox, ByRef GrFingerX As AxGrFingerXLib.AxGrFingerXCtrl)
        _lbLog = lbLog
        _pbPic = pbPic
        _GrFingerX = GrFingerX
    End Sub

    ' Write a message in box.
    Public Sub WriteLog(ByVal message As String)
        _lbLog.Items.Add(message)
        _lbLog.SelectedIndex = _lbLog.Items.Count - 1
        _lbLog.ClearSelected()
    End Sub

    ' Interpretação de erros do driver
    Public Function ErroGriaule(ByVal errorCode As Integer) As String
        ErroGriaule = ""
        Select Case errorCode
            Case GrFinger.GR_ERROR_INITIALIZE_FAIL
                ErroGriaule = "Fail to Initialize GrFingerX. (Error:" & errorCode & ")"
            Case GrFinger.GR_ERROR_NOT_INITIALIZED
                ErroGriaule = "The GrFingerX Library is not initialized. (Error:" & errorCode & ")"
            Case GrFinger.GR_ERROR_FAIL_LICENSE_READ
                ErroGriaule = "License not found. See manual for troubleshooting. (Error:" & errorCode & ")"
                'MessageBox.Show("License not found. See manual for troubleshooting.")
            Case GrFinger.GR_ERROR_NO_VALID_LICENSE
                ErroGriaule = "The license is not valid. See manual for troubleshooting. (Error:" & errorCode & ")"
                'MessageBox.Show("The license is not valid. See manual for troubleshooting.")
            Case GrFinger.GR_ERROR_NULL_ARGUMENT
                ErroGriaule = "The parameter have a null value. (Error:" & errorCode & ")"
            Case GrFinger.GR_ERROR_FAIL
                ErroGriaule = "Fail to create a GDI object. (Error:" & errorCode & ")"
            Case GrFinger.GR_ERROR_ALLOC
                ErroGriaule = "Fail to create a context. Cannot allocate memory. (Error:" & errorCode & ")"
            Case GrFinger.GR_ERROR_PARAMETERS
                ErroGriaule = "One or more parameters are out of bound. (Error:" & errorCode & ")"
            Case GrFinger.GR_ERROR_WRONG_USE
                ErroGriaule = "This function cannot be called at this time. (Error:" & errorCode & ")"
            Case GrFinger.GR_ERROR_EXTRACT
                ErroGriaule = "Template Extraction failed. (Error:" & errorCode & ")"
            Case GrFinger.GR_ERROR_SIZE_OFF_RANGE
                ErroGriaule = "Image is too larger or too short.  (Error:" & errorCode & ")"
            Case GrFinger.GR_ERROR_RES_OFF_RANGE
                ErroGriaule = "Image have too low or too high resolution. (Error:" & errorCode & ")"
            Case GrFinger.GR_ERROR_CONTEXT_NOT_CREATED
                ErroGriaule = "The Context could not be created. (Error:" & errorCode & ")"
            Case GrFinger.GR_ERROR_INVALID_CONTEXT
                ErroGriaule = "The Context does not exist. (Error:" & errorCode & ")"
            Case GrFinger.GR_ERROR_CONNECT_SENSOR
                ErroGriaule = "Error while connection to sensor. (Error:" & errorCode & ")"
            Case GrFinger.GR_ERROR_CAPTURING
                ErroGriaule = "Error while capturing from sensor. (Error:" & errorCode & ")"
            Case GrFinger.GR_ERROR_CANCEL_CAPTURING
                ErroGriaule = "Error while stop capturing from sensor. (Error:" & errorCode & ")"
            Case GrFinger.GR_ERROR_INVALID_ID_SENSOR
                ErroGriaule = "The idSensor is invalid. (Error:" & errorCode & ")"
            Case GrFinger.GR_ERROR_SENSOR_NOT_CAPTURING
                ErroGriaule = "The sensor is not capturing. (Error:" & errorCode & ")"
            Case GrFinger.GR_ERROR_INVALID_EXT
                ErroGriaule = "The File have a unknown extension. (Error:" & errorCode & ")"
            Case GrFinger.GR_ERROR_INVALID_FILENAME
                ErroGriaule = "The filename is invalid. (Error:" & errorCode & ")"
            Case GrFinger.GR_ERROR_INVALID_FILETYPE
                ErroGriaule = "The file type is invalid. (Error:" & errorCode & ")"
            Case GrFinger.GR_ERROR_SENSOR
                ErroGriaule = "The sensor raise an error. (Error:" & errorCode & ")"
            Case ERR_INVALID_TEMPLATE
                ErroGriaule = "Invalid Template. (Error:" & errorCode & ")"
            Case ERR_INVALID_ID
                ErroGriaule = "Invalid ID. (Error:" & errorCode & ")"
            Case ERR_CANT_OPEN_BD
                ErroGriaule = "Unable to connect to DataBase. (Error:" & errorCode & ")"
            Case Else
                ErroGriaule = "Error:" & errorCode
        End Select
    End Function

    ' Verifica validade do Template
    private function TemplateIsValid() As Boolean
        ' Verifica tamanho do template
        Return template.Size > 0
    End Function

    ' Inicializa componente Grfinger 
    Public Function InitializeGrFinger() As Integer
        dim err As Integer
        _pbPic.Image = Nothing

        template.Size = 0
        raw.img = Nothing
        raw.width = 0
        raw.height = 0

        ' Initializing library

        err = _GrFingerX.Initialize()
        If err < 0 Then Return err
        Return _GrFingerX.CapInitialize()

    End Function

    Public Sub FinalizeGrFinger()
        ' finalize library
        Try
            _GrFingerX.Finalize()
            _GrFingerX.CapFinalize()
        Catch

        End Try

    End Sub

    Public Sub PrintBiometricDisplay(ByVal biometricDisplay As Boolean, ByVal context As Integer)

        ' handle to finger image
        dim handle As System.Drawing.Image = Nothing

        ' screen HDC
        dim hdc As Integer = GetDC(0)

        If biometricDisplay Then
            ' get image with biometric info
            _GrFingerX.BiometricDisplay(template.tpt, raw.img, raw.width, raw.height, raw.res, hdc, handle, context)
        Else
            ' get raw image
            _GrFingerX.CapRawImageToHandle(raw.img, raw.width, raw.height, hdc, handle)
        End If

        ' draw image on picture box
        If Not (handle Is Nothing) Then
            _pbPic.Image = handle
            _pbPic.Update()
        End If
        ' release screen HDC
        ReleaseDC(0, hdc)
    End Sub

    Public Function Enroll(ByRef Tipo As Integer, ByVal iD As String, ByVal Login As String) As Integer
        If TemplateIsValid() Then
            Return AdicionaTemplate(template, Tipo, iD, Login)
        Else
            Return -1
        End If
    End Function

    ' Adiciona template à base de dados. Retorna o ID do template adicionado.
    Public Function AdicionaTemplate(ByRef template As TTemplate, ByRef Tipo As Integer, ByVal iD As String, ByVal Login As String) As Long
        AdicionaTemplate = 0
        If _PG.Conectar() = False Then Exit Function
        Dim _util As New clsUtil

        Dim strIP As String = _t.ObtemEnderecoIP()
        Dim strHora As String = Date.Now.ToShortTimeString()
        Dim datData As Date = Date.Now.ToShortDateString()
        Dim vsQuery As String = ""
        Dim strCampo As String = ""

        If Tipo = 0 Then
            strCampo = "usuario"
            strTabela = "digital_usuario"
            vsQuery = "SELECT * FROM digital_usuario where usuario='" & iD & "'"
        Else
            strCampo = "id_pessoa"
            strTabela = "digital"
            vsQuery = "SELECT * FROM digital where id_pessoa=" & iD
        End If

        Dim da As New Npgsql.NpgsqlDataAdapter(vsQuery, _PG.conn)
        ' Cria comando SQL contendo ? parametros de BLOB.
        ' da.InsertCommand = New Npgsql.NpgsqlCommand("INSERT INTO " & strTabela & " (binario," & strCampo & ",login,ip,dt_alteracao,hr_alteracao) Values(?,?,?,?,?,?)", _PG.Conn)
        da.InsertCommand = New Npgsql.NpgsqlCommand("INSERT INTO " & strTabela & " (binario," & strCampo & ",login,ip,dt_alteracao,hr_alteracao) Values(:binario, :" & strCampo & ",:login, :ip, :dt_alteracao, :hr_alteracao)", _PG.Conn)

        da.InsertCommand.CommandType = CommandType.Text

        'da.InsertCommand.Parameters.Add("binario", System.Data.Odbc.OdbcType.Binary, template.Size, "binario")
        da.InsertCommand.Parameters.Add("binario", NpgsqlTypes.NpgsqlDbType.Bytea, template.Size, "binario")
        If Tipo = 0 Then
            da.InsertCommand.Parameters.Add(strCampo, NpgsqlTypes.NpgsqlDbType.Char, 20, strCampo)
        Else
            da.InsertCommand.Parameters.Add(strCampo, NpgsqlTypes.NpgsqlDbType.Integer, 10, strCampo)
        End If
        da.InsertCommand.Parameters.Add("login", NpgsqlTypes.NpgsqlDbType.Char, 20, "login")
        da.InsertCommand.Parameters.Add("ip", NpgsqlTypes.NpgsqlDbType.Char, 20, "ip")
        da.InsertCommand.Parameters.Add("dt_alteracao", NpgsqlTypes.NpgsqlDbType.Date, 7, "dt_alteracao")
        da.InsertCommand.Parameters.Add("hr_alteracao", NpgsqlTypes.NpgsqlDbType.Char, 5, "hr_alteracao")

        ' Abre conexão
        'connection.Open()
        ' Filtra Dataset
        Dim digitais As DataSet = New DataSet
        da.Fill(digitais, strTabela)
        ' Adiciona nova coluna.
        Dim newRow As DataRow = digitais.Tables(strTabela).NewRow()
        newRow("binario") = template.tpt
        newRow(strCampo) = iD
        newRow("ip") = strIP
        newRow("login") = "" & Login
        newRow("hr_alteracao") = strHora.ToString()
        newRow("dt_alteracao") = datData
        digitais.Tables(strTabela).Rows.Add(newRow)
        AddHandler da.RowUpdated, New Npgsql.NpgsqlRowUpdatedEventHandler(AddressOf onRowUpdated) '  OnRowUpdated)
        ' Atualiza DataSet.
        On Error GoTo erro
        da.Update(digitais, strTabela)
        Return newRow(0)
Erro:
        MsgBox(Err.Number & Err.Description)


        ' conexao.Close()
        ' Retorna ID
        _PG.Desconectar()

    End Function

    ' Procedure de evento para  OnRowUpdated
    Private Sub onRowUpdated(ByVal sender As Object, ByVal args As NpgsqlRowUpdatedEventArgs)
        'Private Sub onRowUpdated(ByVal sender As Object, ByVal args As NpgsqlRowUpdatedEventArgs)
        '.OdbcRowUpdatedEventArgs
        If _PG.Conectar() = False Then Exit Sub

        ' Inclui a variavel na linha de comando e retorna o valor identificado do banco de dados.
        Dim newID As Integer = 0
        Dim idCMD As Npgsql.NpgsqlCommand = New Npgsql.NpgsqlCommand("SELECT last_value FROM " & strTabela & "_id_" & strTabela & "_seq", _PG.Conn)
        If args.StatementType = StatementType.Insert Then
            newID = CInt(idCMD.ExecuteScalar())
            args.Row(0) = newID
        End If
        _PG.Desconectar()
    End Sub

    Function ExtractTemplate() As Integer
        dim ret As Integer

        ' set current buffer size for extract template
        template.Size = template.tpt.Length

        ret = _GrFingerX.Extract(raw.img, raw.width, raw.height, raw.res, template.tpt, template.Size, GRConstants.GR_DEFAULT_CONTEXT)
        ' if error, set template size to 0
        ' Result < 0 => extraction problem
        If ret < 0 Then template.Size = 0
        Return ret

    End Function

    Public Class TTemplate
        Public tpt As System.Array = Array.CreateInstance(GetType(Byte), GrFingerXLib.GRConstants.GR_MAX_SIZE_TEMPLATE)
        Public Size As Long
    End Class
    Public Structure TTemplates
        Public ID As Integer
        Public template As TTemplate
    End Structure

    Public Function Identify(ByRef score As Integer, ByRef Tipo As Integer, ByRef IdPessoa As Integer, ByVal vbMenor12 As Boolean, ByVal Matricula As String) As Integer
        dim ret As Integer
        dim i As Integer

        ' Checking if template is valid.
        If Not TemplateIsValid() Then Return ERR_INVALID_TEMPLATE

        ' Starting identification process and supplying query template.
        dim tmpTpt As Array = Array.CreateInstance(GetType(Byte), template.Size)
        Array.Copy(template.tpt, tmpTpt, template.Size)
        ret = _GrFingerX.IdentifyPrepare(tmpTpt, GRConstants.GR_DEFAULT_CONTEXT)
        ' error?
        If ret < 0 Then Return ret
        ' Getting enrolled templates from database.
        dim templates As TTemplates() = ObtemTemplates(Tipo, IdPessoa, vbMenor12, Matricula)
        ' Iterate over all templates in database
        For i = 1 To templates.Length
            ' Comparing the current template.
            If Not (templates(i - 1).template Is Nothing) Then
                dim tempTpt As Array = Array.CreateInstance(GetType(Byte), templates(i - 1).template.Size)
                Array.Copy(templates(i - 1).template.tpt, tempTpt, templates(i - 1).template.Size)
                ret = _GrFingerX.Identify(tempTpt, score, GRConstants.GR_DEFAULT_CONTEXT)
            End If
            ' Checking if query template and reference template match.
            If ret = GRConstants.GR_MATCH Then
                Return templates(i - 1).ID
            End If
            If ret < 0 Then Return ret
        Next
        ' end of database, return "no match" code
        Return GRConstants.GR_NOT_MATCH

    End Function

    ' Obtém, para um objeto do tipo DataTable, as digitais do banco de dados
    Public Function ObtemTemplates(ByRef Tipo As Integer, ByVal IdPessoa As Integer, ByVal vbMenor12 As Boolean, ByVal Matricula As String) As TTemplates()
        _PG.Conectar()
        If Tipo = 0 Then strTabela = "digital_usuario" Else strTabela = "digital"
        dim ds As New DataSet
        dim vsFiltro As String = ""

        ' strModo -> 0=Retaguarda, 1=Consulta, 2=Consultório
        'para melhorar a performance de pesquisa, vou restringir a pesquisa as digitais da matricula
        'quando não for no medico, vou liberar em todos o banco, para permitir encontrar duplicidades e/ou erros
        If Tipo = 1 Then
            vsFiltro = " where id_pessoa= " & IdPessoa
            If (vnGlo_ModoAtual >= "1") And vbMenor12 Then
                vsFiltro = " where id_pessoa in (select id_pessoa from pessoas where matricula='" & Matricula & "')"
            End If
        End If

        Dim da As New Npgsql.NpgsqlDataAdapter("select * from " & strTabela & vsFiltro, _PG.Conn)
        Dim ttpts As TTemplates()
        dim i As Integer
        ' Obtém resposta da query.
        da.Fill(ds)
        dim tpts As DataRowCollection = ds.Tables(0).Rows
        ' Cria um vetor com o retorno.
        Redim ttpts(tpts.Count)
        ' Sem resultados?
        If tpts.Count = 0 Then Return ttpts
        ' Coloca cada template no vetor
        For i = 1 To tpts.Count
            ttpts(i).template = New TTemplate
            ttpts(i).ID = tpts.Item(i - 1).Item(0)              'id_digital
            ttpts(i).template.tpt = tpts.Item(i - 1).Item(1)    'digital
            ttpts(i).template.Size = ttpts(i).template.tpt.Length
        Next
        _PG.Desconectar()

        Return ttpts
    End Function

    Public Function Verify(ByVal DB As ClsBancoNPG, ByVal id As Integer, ByRef score As Integer) As Integer
        dim tptref As System.Array
        If Not (TemplateIsValid()) Then Return ERR_INVALID_TEMPLATE
        tptref = ObtemTemplate(id)
        If tptref Is Nothing Then Return ERR_INVALID_ID
        dim tempTpt As Array = Array.CreateInstance(GetType(Byte), template.Size)
        Array.Copy(template.tpt, tempTpt, template.Size)
        Return _GrFingerX.Verify(tempTpt, tptref, score, GRConstants.GR_DEFAULT_CONTEXT)

    End Function


    ' Retorna template com o ID fornecido.
    Public Function ObtemTemplate(ByVal id As Long) As Byte()
        _PG.Conectar()

        dim ds As New DataSet
        dim da As New Npgsql.NpgsqlDataAdapter("SELECT * FROM digital WHERE id_digital = " & id, _banco.Conn)

        dim tpt As New TTemplate
        ' Retorna resposta da query.
        da.Fill(ds)

        dim tpts As DataRowCollection = ds.Tables(0).Rows
        ' Sem resultados?
        If tpts.Count <> 1 Then Return Nothing
        ' Deserializa o Template.
        Return tpts.Item(0).Item("binario")
        _pg.Desconectar()

    End Function


    ' Show GrFinger version and type
    Public Sub MessageVersion()
        dim majorVersion As Integer = 0
        dim minorVersion As Integer = 0
        dim result As GRConstants
        dim vStr As String = ""

        result = _GrFingerX.GetGrFingerVersion(majorVersion, minorVersion)
        If result = GRConstants.GRFINGER_FULL Then vStr = "FULL"
        If result = GRConstants.GRFINGER_LIGHT Then vStr = "LIGHT"
        If result = GrFinger.GRFINGER_FREE Then vStr = "FREE"
        MessageBox.Show("GrFinger DLL versão " & majorVersion & _
          "." & minorVersion & "." & vbCrLf & "Tipo da licença : " & vStr & "." & vbCrLf & _
         "Responsável Técnico: André Kütter Krolow.", "GrFinger Version")

    End Sub

    Public Function ObtemConsultas(ByVal Matricula As String, ByVal Tipo As String, ByVal Prazo As Integer, ByVal IdAutorizacao As Long) As String
        Dim StrQueryApoio As String = ""

        ' em 23/08/2021- versao 2.1.05 nutricionista não sao mais considerados atendimento medicos e nao entram nas consultas de bonus - especilidade=18
        If Tipo = "CM" Then StrQueryApoio = " and id_Especialidades<>18 and id_Especialidades2<>18 "

        ' especialidade 34- fisioterapia - não é mais considerada consulta médica e não entra no calculo
        ' tipo CF é fisioterapia e garante que pesquisa nao compute fisioterapias.
        If Tipo = "CF" Then StrQueryApoio = " and autorizacao=" & IdAutorizacao  ' tipo especifico no banco CF - consulta fisioterapia

        If Tipo = "CO" Then StrQueryApoio = "" ' tipo especifico no banco CO - consulta odontologica- na realidade qualquer atendimento

        ' tipo BB nao existe no banco, só parametro  'especialidade=24=pediatria
        If Tipo = "BB" Then
            StrQueryApoio = " and (id_especialidades=24 or id_especialidades2=24) AND pessoas.dt_nascimento > CURRENT_DATE-365 "
            Tipo = "CM"
        End If

        ' consulta nutricionsita
        If Tipo = "CN" Then
            StrQueryApoio = " and (id_Especialidades=18 Or id_Especialidades2=18) " ' tipo CN a partir da versao 2.2.00 existe no banco
            Tipo = "CM' or tipo_servico='CN"
        End If

        ' nao comparecimentos nao devem ser computados nas somas de atendimentos para bonus/excedentes => 16982 (medica),16985 (odontologica), 16986(fisioteparia)
        ' parece que é melhor pensar em trocar os 3 codigos de servico s por um novo tipo de situacao - assim sei o servico e se ele foi não comparecido, algo situacao='N'
        ' como esse no procedimento nao precisa fazer nada aqui, pois só soma consultas tipo A-ativa
        ' situacoes hoje A-ativo, B-bonus, C-cancelado, G-glosado, P-pendente, N=nao compareceu
        ' versao 2.2.14 - 01/01/2022

        ObtemConsultas = " SELECT COUNT(*) FROM atendimento INNER JOIN pessoas using(id_pessoa) " &
                         " INNER JOIN prestador on id_prestador=id_medico WHERE pessoas.matricula='" & Matricula & "' " &
                         " AND (tipo_servico='" & Tipo & "')" &
                         " AND atendimento.dt_alteracao BETWEEN CURRENT_DATE-" & Prazo & " AND CURRENT_DATE " &
                         " AND atendimento.situacao='A' AND excedente='N' " & StrQueryApoio

    End Function

    Public Function ObtemBonus(ByVal matricula As String, ByVal vnPrazo As Integer) As String
        ' pode ter 3 consulta médicas 2 odontológicas por mês
        ' pode ter 5 bonus a cada 365 por matricula
        ' apartir de 05/01/2022 - versao 2.2.18 nao tem mais bonus para dentistas
        ObtemBonus = "SELECT count(*) FROM atendimento INNER JOIN pessoas USING (id_pessoa) WHERE atendimento.situacao='B' " &
                         "  AND atendimento.dt_alteracao BETWEEN CURRENT_DATE-" & vnPrazo & " AND CURRENT_DATE " &
                         "  AND matricula='" & matricula & "'"
    End Function

    Public Function ObtemExcedente(ByVal matricula As String, ByVal vnprazo As Integer) As String
        ' após as 3 ou 2 consultas do mês(ultimos 30 dias) e apos estourar os bonus entra o excedente que é PAGO (consginado em folha)
        ObtemExcedente = "SELECT count(*) FROM atendimento" &
                         " INNER JOIN pessoas USING (id_pessoa) WHERE atendimento.situacao='A' " &
                         "  AND atendimento.dt_alteracao BETWEEN CURRENT_DATE-" & vnprazo & " AND CURRENT_DATE " &
                         "  AND matricula='" & matricula & "' AND excedente='S'"
    End Function

    Public Function ObtemProximaConsultaLiberada(ByVal matricula As String) As String
        ObtemProximaConsultaLiberada = "SELECT to_char(atendimento.dt_alteracao+30, 'dd/mm/yy') FROM atendimento " &
                         " INNER JOIN pessoas USING(id_pessoa) WHERE pessoas.matricula='" & matricula & "' And " &
                         " atendimento.tipo_servico='CM' AND atendimento.dt_alteracao BETWEEN CURRENT_DATE-30 AND CURRENT_DATE AND atendimento.situacao='A' AND " &
                         " excedente='N' order by atendimento.dt_alteracao limit 1"
    End Function

    Public Function ObtemProximaFisioterapiaLiberada(ByVal idPessoa As Long) As String
        ObtemProximaFisioterapiaLiberada = "SELECT to_char(dt_realizada+365, 'dd/mm/yyyy') FROM fisioterapia_sessoes " &
                         " WHERE id_pessoa=" & idPessoa & " And realizada='S' and " &
                         " dt_realizada BETWEEN CURRENT_DATE-365 AND CURRENT_DATE order by dt_realizada limit 1"
    End Function


End Class
