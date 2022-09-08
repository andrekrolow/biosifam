Imports System.Net.Mail

Public Class ClsMail
    ' igualar a classe do k2 - iniciado para sem uso

    'MailMessage() - representa uma mensagem de e-mail e possui as propriedades : From, To , Subject , Body , etc.;
    'SmtpClient() - envia uma instância especificada de MailMessage para um servidor SMTP definido.

    Public vsSMTP As String = "" ' "smtp.gmail.com"
    Public vsPorta As String = "" '"587"
    Public vsRemetenteEmail As String = "" ' "prevpel.sifam@gmail.com"    '"biosifam.monitor@gmail.com"
    Public vsRemetenteNome As String = "" '"PREVPEL - Biosifam"
    Public vsRemetenteSenha As String = "" ' "pr3vp3ls1f4m"

    Public vsAssunto As String = ""
    Public vsEmail As String = ""
    Public vsEmailComCopia As String = ""
    Public vsEmailComCopiaOculta As String = ""
    Public vsMensagem As String = ""
    Public lstAnexo As ListBox
    Public vbHTML As Boolean
    Public vbAutomatico As Boolean = False
    Public vbAutenticacaoSegura As Boolean = False
    Public vbMostrarMensagem As Boolean

    Dim _sl As New cSegurança ' para envitar recursividade 

    Public Sub New(Chave As String)
        Dim drSetup As Npgsql.NpgsqlDataReader
        If _PG.Conectar() = False Then End
        drSetup = _PG.DrQuery("select * from setup_host where name='" & Chave & "'")
        If drSetup.HasRows Then
            drSetup.Read()
            vsRemetenteNome = drSetup.Item("name")
            vsSMTP = drSetup.Item("host")
            vsRemetenteEmail = drSetup.Item("host_user")
            vsRemetenteSenha = drSetup.Item("host_password")
            vsPorta = drSetup.Item("host_port")
        End If
        _PG.Desconectar()
    End Sub

    Function Enviar() As Boolean
        Enviar = False

        _sl.Ocorrencias(0, "Envio de Email", "clsMail", "Enviar", "Iniciando Email, assunto: " & vsAssunto, False, True)

        ' inverte
        If vbAutomatico Then vbAutomatico = False Else vbAutomatico = True
        Dim vsErro As String = ""
        If vsSMTP = "" Then vsErro += "SMTP vazio, "
        If vsRemetenteEmail = "" Then vsErro += "Email do Remetente vazio, "
        If vsRemetenteSenha = "" Then vsErro += "Senha do Remetente vazia, "
        If vsAssunto = "" Then vsErro += "Assunto do email vazio, "
        If vsEmail = "" Then vsErro += "Email Destinatário vazio, "
        If vsMensagem = "" Then vsErro += "Mensagem do email vazia, "
        If vsErro <> "" Then
            vsErro += "impossível enviar email."
            _sl.Ocorrencias(1, "Envio de Email", "clsMail", "Enviar", "Erro na preparação do email, " & vsErro, True, True) : Exit Function
        End If

        Dim _Email As New System.Net.Mail.MailMessage()
        _Email.From = New System.Net.Mail.MailAddress(IIf(vsRemetenteNome <> "", vsRemetenteNome, "") & "<" & vsRemetenteEmail & ">")
        _Email.ReplyTo = New System.Net.Mail.MailAddress(vsRemetenteNome & " <" & vsRemetenteEmail & ">")
        Dim vsAux As String = vsEmail
        While (vsAux <> "")
            If InStr(vsAux, ";") > 0 Then vsEmail = Mid(vsAux, 1, InStr(vsAux, ";") - 1) Else vsEmail = vsAux
            _Email.To.Add(vsEmail)
            If InStr(vsAux, ";") > 0 Then vsAux = Mid(vsAux, InStr(vsAux, ";") + 1) Else vsAux = ""
        End While
        _Email.Priority = System.Net.Mail.MailPriority.Normal
        _Email.IsBodyHtml = vbHTML
        _Email.Subject = vsAssunto
        _Email.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1")
        _Email.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1")

        If vbHTML = False Then _Email.Body = vsMensagem

        'first we create the Plain Text part
        'dim plainView As AlternateView = AlternateView.CreateAlternateViewFromString("This is my plain text content, viewable by those clients that don't support html", Nothing, "text/plain")

        'then we create the Html part
        'to embed images, we need to use the prefix 'cid' in the img src value
        'the cid value will map to the Content-Id of a Linked resource.
        'thus <img src='cid:companylogo'> will map to a LinkedResource with a ContentId of 'companylogo'
        'dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString("Here is an embedded image.<img src=cid:companylogo>", Nothing, "text/html")

        'create the LinkedResource (embedded image)
        'dim logo As New LinkedResource("c:\temp\logo.gif")
        'logo.ContentId = "companylogo"
        'add the LinkedResource to the appropriate view
        'htmlView.LinkedResources.Add(logo)

        'add the views
        '_Email.AlternateViews.Add(plainView)
        '_Email.AlternateViews.Add(htmlView)

        Dim i As Integer
        If lstAnexo IsNot Nothing Then
            For i = 0 To lstAnexo.Items.Count - 1
                If vbHTML Then
                    'dim plainView As AlternateView = AlternateView.CreateAlternateViewFromString(vsMensagem, Nothing, "text/plain")
                    '_Email.AlternateViews.Add(plainView)

                    Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString(vsMensagem & "<BR><img src=cid:K2Software>", Nothing, "text/html")
                    Dim vsTipo As String = ""
                    If InStr(UCase(lstAnexo.Items(i).ToString), "PDF") > 0 Then vsTipo = "application/pdf"
                    Dim logo As New LinkedResource(lstAnexo.Items(i).ToString, vsTipo)
                    logo.ContentId = vsAssunto
                    htmlView.LinkedResources.Add(logo)
                    _Email.AlternateViews.Add(htmlView)
                Else
                    If lstAnexo.Items(i).ToString <> "" Then _Email.Attachments.Add(New Attachment(lstAnexo.Items(i)))
                End If
            Next
        End If

        ' para testes - funcionando 10/08/2020
        'vsRemetenteEmail = "k2solucoes.financeiro@gmail.com"
        'vsRemetenteSenha = "G@D1m3ns40"

        'Cria objeto com os dados do SMTP
        Dim SmtpServer As New System.Net.Mail.SmtpClient(vsSMTP, vsPorta)
        SmtpServer.UseDefaultCredentials = True
        SmtpServer.Credentials = New System.Net.NetworkCredential(vsRemetenteEmail, vsRemetenteSenha)
        SmtpServer.EnableSsl = vbAutenticacaoSegura
        Try
            SmtpServer.Send(_Email)
            _sl.Ocorrencias(0, "Envio de Email", "clsMail", "Enviar", "concluído com sucesso, " & vsAssunto, vbMostrarMensagem, True, True)
            Enviar = True
        Catch ex As Exception
            _sl.Ocorrencias(1, "Envio de Email", "clsMail", "Enviar", "Erro, " & ex.Message, vbMostrarMensagem, True, True)
        End Try

        'excluímos o objeto de e-mail da memória
        _Email.Dispose()
        'anexo.Dispose();
    End Function
End Class
