Imports System.Net

'<add key = "sm_sa" value="server=http://54.233.99.254/webservice-rest;userid=andrekro;password=S4Rrlqnl9;"/>
'<add key = "sm_t"  value="server=http://54.233.99.254/webservice-rest;userid=andrekrolow@gmail.com;password=T4Rrlqnl9;"/>
'<add key = "sm_sp" value="server=http://54.233.99.254/webservice-rest;userid=prevpel;password=s@pr3vp3l;"/>

Public Class ClsSMS
    ' copia da classe mobile do k2tools -13/07/2021


    ' classe para conexões de mensagens eletronica SMS e WHATSUP

    ' speed market - não gostei pois força o pagamento mensal com expiração em 30 dias
    '   consigo fazer o valor de R$0,11 o whatsapp e o SMS R$0,06 para vc na revenda, sem Nfe pagamento via transferência bancaria
    '   SMS MARKETING? (SHORT CODE)  remetente de número curto com 5 digitos, somente para envios, 
    '   Pra revenda mínimo de 2.000 créditos
    '   Itau, AG:0143,  CC:10022-0, SpeedMarket soluções inteligente Marketing ltda ME, CNPJ 06.016.937/0001-31
    '   http://serverspeedmarket.com.br/plataforma
    '   https://integracao.docs.apiary.io  


    ' trend - valor 0,18 mas NÃO expira e não tem mensalidade - https://www.trendmens.com.br - login andrekrolow@gmail.com
    '           200, 500, 1000, 3000, 5000
    '            36   75   140   390   600
    '          0,18  0,15  0,14   0,13    0,12

    ' zenvia - usado pelo sanep https://www.zenvia.com/

    Public viType As Integer = 0
    'type	Tipo do Serviço     https://integracao.docs.apiary.io/#introduction/parametro-type
    '0:     SMS()
    '1:  	SMS Interativo(Modo Flash)
    '2:     SMS(Interativo)
    '3:  	Torpedo de Voz (Apenas Texto)
    '4: 	Torpedo de Voz (Áudio)
    '5: 	Whatsapp (Apenas Texto)
    '6:     Whatsapp(Imagem)
    '7:     Whatsapp(Áudio)
    '8:     Whatsapp(Vídeo)
    '9:     vai escolher aqui - lista de vários clientes

    Public SystemName As String = "siacks"
    Public vbGlo_Console As Boolean = True ' identifica se foi chamado pelo usuario via manual (console=true) ou via aplicativo (console=false)
    Public vsArquivoLista As String = ""
    Public vsDestino As String = ""
    Public vsMensagem As String = ""
    Public vsUsuario As String = ""
    Public vsSituação As String = ""
    Public vsProvedorSMS As String = ""
    Public idCliente As Long = 0
    Public vsRemetente As String = ""

    Public StrUltimoErro As String

    Dim fluxoTexto As IO.StreamReader                             'Classe de leitura de arquivos (txt)
    Dim linhaTexto As String

    Dim URLSingle As String = ""
    Dim URLRelatorio As String = ""
    Dim vsAuth_User As String = ""
    Dim vsAuth_Password As String = ""
    ' the web location of the files
    Dim _Tools As New cTools
    Dim _Data As New Clsdata

    Dim vsDataInicio As String, vsDataFinal As String, vsPeriodo As String
    Dim drGenericPG As Npgsql.NpgsqlDataReader

    Dim vsEscopo As String
    Dim vsPreferencia As String
    Dim vsCelular As String
    Dim vsTelefone As String
    Dim vsEmail As String



    Public Function Inicializa() As Boolean
        Inicializa = False
        vsSituação = ""
        vsSituação = "Inicializando cSMS, " & Now
        vsSituação = "Parâmetros recebidos: tipo " & viType & ", " & vsDestino
        'MsgBox("cheguei enviamensagem")

        Dim drSetup As Npgsql.NpgsqlDataReader
        If _PG.Conectar() = False Then End
        drSetup = _PG.DrQuery("select * from setup_host where name='sms_speedmarket'")
        If drSetup.HasRows = False Then GoTo Fim_Bloco
        drSetup.Read()

        If vsProvedorSMS = "speed" Then
            URLSingle = drSetup.Item("host")
            vsAuth_User = drSetup.Item("host_user")
            vsAuth_Password = drSetup.Item("host_password")
            URLSingle = URLSingle & "/send-single"
            URLRelatorio = URLSingle & "/mt_date"

        ElseIf vsProvedorSMS = "trend" Then
            URLSingle = drSetup.Item("host")
            vsAuth_User = drSetup.Item("host_user")
            vsAuth_Password = drSetup.Item("host_password")
            URLSingle = URLSingle & "/send-single"
            URLRelatorio = URLSingle & "/mt_date"

        Else
            'speed
            URLSingle = drSetup.Item("host")
            vsAuth_User = drSetup.Item("host_user")
            vsAuth_Password = drSetup.Item("host_password")
            URLSingle = "http://54.233.99.254/webservice-rest/send-single"
            URLRelatorio = "http://54.233.99.254/webservice-rest/mt_date"

        End If

        If viType = 9 Then
            'EnviarMensagem em massa - arquivo lista
            'desativa modo automatico para operador preencher a mensagem
            'vbGlo_Console = True
            vsArquivoLista = vsGlo_AppPath & vsDestino
        End If
        Inicializa = True
Fim_Bloco:
        _PG.Desconectar()

    End Function

    Public Sub EnviarLista(ByVal vnTipo As Integer)

        vsSituação = "Mensagem vazia"
        If vsMensagem = "" Then _s.Ocorrencias(1, "EnviaMensagem", "DisparaMens", "cSMS", vsSituação, vbGlo_Console, True, True) : Exit Sub
        vsSituação = "Celular vazio"
        If vsDestino = "" Then _s.Ocorrencias(1, "EnviaMensagem", "DisparaMens", "cSMS", vsSituação, vbGlo_Console, True, True) : Exit Sub

        Dim vsNome As String = ""
        Dim vsEmail As String = ""
        Dim vsMensagemOriginal As String = vsMensagem

        If vsMensagem.Length > 160 Then
            MsgBox("A mensagem estourou o limite máximo de 160 caracteres. Nenhuma mensagem será enviada. Ajuste primeiro a mensagem.")
            Exit Sub
        End If

        If IO.File.Exists(vsArquivoLista) Then
            fluxoTexto = New IO.StreamReader(vsArquivoLista)
            Try
                While fluxoTexto.EndOfStream = False
                    linhaTexto = fluxoTexto.ReadLine
                    vsDestino = _Tools.ExtraiItemLista(linhaTexto, 1, ";")
                    vsNome = _Tools.ExtraiItemLista(linhaTexto, 2, ";")
                    vsEmail = _Tools.ExtraiItemLista(linhaTexto, 3, ";")
                    vsMensagem = Replace(vsMensagemOriginal, "<CLIENTE>", Trim(vsNome))
                    If vsMensagem.Length > 159 Then ' nome maximo é 10 e <CILENTE> é 9
                        vsMensagem = Replace(vsMensagemOriginal, "<CLIENTE>", Left(Mid(vsNome, 1, InStr(vsNome, " ") - 1), 10))
                    End If

                    Call EnviarMensagem(vnTipo)

                End While
                fluxoTexto.Close()
                _s.Ocorrencias(0, "EnviaMensagem", "DisparaMens", "cSMS", "Fim de envio da Lista", True, True, True)
                Exit Sub
            Catch
                _s.Ocorrencias(1, "EnviaMensagem", "DisparaMens", "cSMS", Err.Description & " - N." & Err.Number, True, True, True)
            End Try
        Else
            MsgBox("Arquivo " & vsArquivoLista & " não encontrado.")
        End If

    End Sub

    Public Sub EnviarMensagem(ByVal vnTipoMensagem As Integer)
        '0=sms, 1=SMS Interativo(Modo Flash), 2=SMS(Interativo), 5= whats Texto,6=Whatsapp(Imagem), 7=Whatsapp(Áudio), 8=Whatsapp(Vídeo), 99 email

        vsSituação = "Mensagem vazia"
        If vsMensagem = "" Then _s.Ocorrencias(1, "EnviaMensagem", "Envia", "cSMS", vsSituação, vbGlo_Console, True, True) : Exit Sub

        If vnTipoMensagem = 99 Then
            vsSituação = "Email vazio"
            If vsDestino = "" Then _s.Ocorrencias(1, "EnviaMensagem", "Envia", "cSMS", vsSituação, vbGlo_Console, True, True) : Exit Sub

            Dim Email = New ClsMail("Prevpel - Biosifam")
            Email.vsAssunto = "Registro de Atendimento PREVPEL"
            Email.vsMensagem = vsMensagem
            Email.vsMensagem &= Chr(13) & " PREVPEL/Biosifam"
            Email.vbAutomatico = True
            Email.vbAutenticacaoSegura = True
            Email.vsEmail = vsDestino
            Email.Enviar()
            Exit Sub
        End If

        vsSituação = "Celular vazio"
        If vsDestino = "" Then _s.Ocorrencias(1, "EnviaMensagem", "Envia", "cSMS", vsSituação, vbGlo_Console, True, True) : Exit Sub

        ' whats com anexo = 6 - imagem - usa somente url, nao anexa arquivo - vai dentro do ´content´ junto com a mensagem

        Dim QueryString As String = ""
        QueryString = "?user=" & vsAuth_User & "&password=" & vsAuth_Password & "&number=55" & vsDestino & "&content=" & vsRemetente & " enviou : " & vsMensagem & "&type=" & vnTipoMensagem

        Dim myWebClient As New WebClient ' the web client
        Dim Arquivo As New System.IO.StreamReader(myWebClient.OpenRead(URLSingle & QueryString))
        Dim Contents As String = Arquivo.ReadToEnd()
        Arquivo.Close()

        ' if something was read
        If Contents <> "" Then
            ' Break the contents 
            Contents = Replace(Contents, "{", "")
            Contents = Replace(Contents, "}", "")
            Contents = Replace(Contents, """", "")
            Dim Parametros() As String = Split(Contents, ",")
            Dim vsAux As String
            vsAux = Parametros(0).ToString.Trim
            Dim RetornoStatus() As String = Split(vsAux, ":")       ' status => success true/false
            vsAux = Parametros(1).ToString.Trim
            Dim RetornoCodigo() As String = Split(vsAux, ":")       ' resposta codigo
            vsAux = Parametros(2).ToString.Trim
            Dim RetornoDescricao() As String = Split(vsAux, ":")    ' resposta descrição

            If Parametros.Length > 3 Then
                vsAux = Parametros(3).ToString.Trim
                Dim RetornoCredito() As String = Split(vsAux, ":")      ' crédito - quantidade usada
            End If

            If Parametros.Length > 4 Then
                vsAux = Parametros(4).ToString.Trim
                Dim RetornoBalanco() As String = Split(vsAux, ":")      ' balanco - saldo disponivel
            End If

            Dim RetornoId As Long = 0
            If Parametros.Length > 5 Then                               ' pelo que vi so entra aqui se mensagem foi enviada
                vsAux = Parametros(5).ToString.Trim
                Dim RetornoIdM() As String = Split(vsAux, ":")
                RetornoId = Val(RetornoIdM(1))
            End If

            If Val(RetornoCodigo(1)) = 0 Then

                'responseCode	responseDescription	success
                '000	Success queued	true
                '001	Batch processed	true
                '002    Scheduled(True)
                '200	Successful search	true

                _s.Ocorrencias(0, "EnviaMensagem", "cSMS", "EnviaMens", "Mensagem enviada com sucesso", vbGlo_Console, True, True)

                StrUltimoErro = vsDestino & ", Enviada, " & vsMensagem

            Else
                '010	User or password is invalid	false
                '020	Empty or invalid type	false
                '030	Empty message content	false
                '040	Scheduling date invalid or incorrect	false
                '050	Empty or invalid number	false
                '060	International sending not allowed	false
                '070	Message rejected by server	false
                '080	Insufficient or expired balance	false
                '090	Blocked account - Please contact support	false
                '100	This service is currently under maintenance	false
                '110	There was an error processing, please try again, or contact us	false
                '120	Message array cannot exceed 5000	false
                '130	Message array is empty	false
                '140	Incorrect time zone	false
                '150	File extension not allowed	false
                '160	Unknown method or unknown parameter	false
                '170	Invalid search attributes	false
                If Val(RetornoCodigo(1)) = 10 Then RetornoDescricao(1) = "Usuário/Senha inválido."
                If Val(RetornoCodigo(1)) = 20 Then RetornoDescricao(1) = "tipo vazio ou inválido."
                If Val(RetornoCodigo(1)) = 30 Then RetornoDescricao(1) = "mensagem vazia."
                If Val(RetornoCodigo(1)) = 40 Then RetornoDescricao(1) = "Scheduling date invalid or incorrect."
                If Val(RetornoCodigo(1)) = 50 Then RetornoDescricao(1) = "número inválido ou vazio."
                If Val(RetornoCodigo(1)) = 60 Then RetornoDescricao(1) = "mensagem internacional nao permitida."
                If Val(RetornoCodigo(1)) = 70 Then RetornoDescricao(1) = "servidor rejeitou messagem."
                If Val(RetornoCodigo(1)) = 80 Then RetornoDescricao(1) = "Saldo insuficente."
                If Val(RetornoCodigo(1)) = 90 Then RetornoDescricao(1) = "Conta bloqueada."
                If Val(RetornoCodigo(1)) = 100 Then RetornoDescricao(1) = "Servidor em manutenção."
                If Val(RetornoCodigo(1)) = 110 Then RetornoDescricao(1) = "Erro ao processar, tenat novamente."
                If Val(RetornoCodigo(1)) = 120 Then RetornoDescricao(1) = "Lista de Mensagem excedeu 5000."
                If Val(RetornoCodigo(1)) = 130 Then RetornoDescricao(1) = "Lista de mensagem vazia."
                If Val(RetornoCodigo(1)) = 140 Then RetornoDescricao(1) = "Time Zone incorreto."
                If Val(RetornoCodigo(1)) = 150 Then RetornoDescricao(1) = "Extensão do arquivo não permitida."
                If Val(RetornoCodigo(1)) = 160 Then RetornoDescricao(1) = "método ou parametro desconhecido."
                If Val(RetornoCodigo(1)) = 170 Then RetornoDescricao(1) = "atributos de pesquisa invalidos."

                _s.Ocorrencias(0, "EnviaMensagem", "cSMS", "EnviaMens", "Mensagem NÂO enviada, retorno: " & RetornoCodigo(1) & ", " & RetornoDescricao(1), vbGlo_Console, True, True)

                StrUltimoErro = vsDestino & ", NãO Enviada, " & RetornoCodigo(1) & ", " & RetornoDescricao(1) & ", " & vsMensagem


            End If
        Else
            _s.Ocorrencias(1, "EnviaMensagem", "cSMS", "EnviaMens", "Mensagem NÂO enviada, Retorno Vazio. ->" & vsMensagem, False, True, True)

            StrUltimoErro = vsDestino & ", NãO Enviada, " & Contents & ", " & vsMensagem

        End If

    End Sub

    Public Sub Gerados(ByVal idEmpresa As Long)

        vsPeriodo = InputBox("informe o perído do relatório: (ex. 01/01/2017-31/01/2017)", "", "")
        If vsPeriodo = "" Then Exit Sub
        vsDataInicio = Format(CDate(_Data.k2Left(vsPeriodo, 10)), "yyyy-MM-dd") & "+00:00:00"
        vsDataFinal = Format(CDate(Mid(vsPeriodo, InStr(vsPeriodo, "-") + 1, 10)), "yyyy-MM-dd") & "+23:59:59"
        'vsDataInicio = "2014-02-28+00:00:00"
        'vsDataFinal = "2014-02-28+23:59:59"
        System.Diagnostics.Process.Start(URLRelatorio & "?user=" & vsAuth_User & "&password=" & vsAuth_Password & "&start_date=" & vsDataInicio & "&end_date=" & vsDataFinal & "&type=2&status=0,1", 1)

    End Sub

    Public Sub Recebidos()
        vsPeriodo = InputBox("informe o perído do relatório: (ex. 01/01/2017-31/01/2017)", "", "")
        If vsPeriodo = "" Then Exit Sub
        vsDataInicio = Format(CDate(_Data.k2Left(vsPeriodo, 10)), "yyyy-MM-dd") & "T00:00:00"
        vsDataFinal = Format(CDate(Mid(vsPeriodo, InStr(vsPeriodo, "-") + 1, 10)), "yyyy-MM-dd") & "T23:59:59"
        'vsDataInicio = "2014-02-28+00:00:00"
        'vsDataFinal = "2014-02-28+23:59:59"
        'Aqui você poderá alterar o site
        System.Diagnostics.Process.Start(URLRelatorio & "?user=" & vsAuth_User & "&password=" & vsAuth_Password & "&start_date=" & vsDataInicio & "&end_date=" & vsDataFinal, 1)
        'Dim myWebClient As New WebClient ' the web client
        'Dim Arquivo As New System.IO.StreamReader(myWebClient.OpenRead(URLRelatorio & "?user=" & vsAuth_User & "&password=" & vsAuth_Password & "&start_date=" & vsDataInicio & "&end_date=" & vsDataFinal))
        'Dim Contents As String = Arquivo.ReadToEnd()
        'Arquivo.Close()

        '-1 - Mensagem na Fila para Envio.
        ' 0 - Mensagem Enviada com Sucesso.
        '-2 - Erro - Possível Erro na Entrega.
        '-3 - Erro - Número Inválido.
        '-4 - Erro - Número de Telefone Fixo.
        '-5 - Erro – Bloqueio por Opt-out.
    End Sub

    Public Function AjustaTelefoneDisponivel(vsTelefone As String, vsCelular As String) As String
        AjustaTelefoneDisponivel = ""
        If Trim(vsTelefone) <> "" Or Trim(vsCelular) <> "" Then
            ' verifica se colocou o celular no campo telefone
            If Trim(vsTelefone) <> "" Then
                AjustaTelefoneDisponivel = Trim(Replace(vsTelefone, "-", ""))
            Else
                AjustaTelefoneDisponivel = Trim(Replace(vsCelular, "-", ""))
            End If
            If AjustaTelefoneDisponivel <> "" And Val(Mid(AjustaTelefoneDisponivel, 3, 10)) < 80000000 Then
                ' telefone não é celular, procurar pelo campo celular.
                If Trim(vsCelular) <> "" Then AjustaTelefoneDisponivel = Trim(Replace(vsCelular, "-", ""))
                If AjustaTelefoneDisponivel <> "" And Val(Mid(AjustaTelefoneDisponivel, 3, 10)) < 80000000 Then AjustaTelefoneDisponivel = ""
            End If
        End If

    End Function

End Class

