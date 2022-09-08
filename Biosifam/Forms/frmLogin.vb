'Imports Microsoft.VisualBasic
'Imports GrFingerXLib
'Imports System.Drawing.Drawing2D

Public Class frmLogin

    Dim dr As Npgsql.NpgsqlDataReader

    Public vsUsuarioSenha As String = ""
    Public vbPassou As Boolean
    Public vbDigitalContribuinte As Boolean
    Dim vnRetardo As Integer
    Dim splash As New formSplash

    Private Sub frmLogin_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        'System.Threading.Thread.Sleep(5000)   ' antigo delay
        'If VerificaAbreBanco = False Then Call Encerra_Sistema()

        TxtUsuario.Focus()

        'If txtUsuario.Text <> "" And mskSenha.Text <> "" Then ' btnLogin.PerformClick()

    End Sub

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'StrConection_NPG_Biosifam = _appConfig.GetSection("f1")
            'StrConection_NPG_Biosifam = _appConfig.GetSection("pe")
            'StrConection_NPG_BiosifamInterno = _appConfig.GetSection("f2")
            'StrConection_NPG_BiosifamInterno = _appConfig.GetSection("pi")

            StrConection_NPG_Biosifam = _s.CriptaTexto("NEYeXFU2QIRGCHlsfRHpDvtFhg3yam8WcgIw7j9MUQOmGyOcXk9TgVJnEYRIOoEsmv+xdtO5v1dlv9aJrvqVsCnzHGjgS9iBW49nPiOIpLzWJD01Och4SiZpRo4VmKg9mnYMC41cLa9IpcnJYfVzEJRuVBP8TF7H", False, "basepe")
            StrConection_NPG_BiosifamInterno = _s.CriptaTexto("JyP5SbNrwlLNtnHv6Er+KUKyh6+nbzBCDKDvjKEJT0ZPXmBQ9VuBrEbtG0uB8tiW9DUUssWPFcSsM0nrWDNsao3KIfGOUKS11ieukWZMzxpDafEyvI0SogdcyK7zegPZrRB31N+Ixs8=", False, "basepi")

        Catch ex As Exception
            MsgBox(ex.Message & " Erro na Descriptografia Padrão, utilizando nivel 2 de segurança.")
        End Try

        'StrConection_NPG_Biosifam = "server=dbsifam.pelotas.com.br;port=54320;database=prevpel;userId=ubiosifam;password=d4t4b4nk;preload reader=true;pooling=false"

        ' ao colocar o maxpoolsize em 5 para garantir que nao haja mais de cinco conexoes presas no postgres, quando outrapassa trava o banco de retorna time out 
        ' a principio a aplicação sempre encerra bem suas conexoes, mas com o maxpool em 20 (dafault) parece ficar muito grande a fila de conexoess
        ' pelo que percebi ao usar clearpool ele perde o controle do maxpoolsize e permite tipo 50 60 conexoes
        ' a conclusao é que parece melhor nao usar o pool, pois ele funciona para um open, e estou usando para cada acesso um open, entao nao faz sentido o pool

        StrConection_NPG_Biosifam &= "pooling=false"        ' 2.2.19
        StrConection_NPG_BiosifamInterno &= "pooling=false"

        _PG = New ClsBancoNPG(StrConection_NPG_Biosifam, "", StrConection_NPG_BiosifamInterno)

        Dim toolTip1 As New ToolTip()
        ' Define o delay para a ToolTip.
        toolTip1.AutoPopDelay = 5000
        toolTip1.InitialDelay = 1000
        toolTip1.ReshowDelay = 250 '500
        ' Força a o texto da ToolTip a ser exibido mesmo que o form não esta ativo
        toolTip1.ShowAlways = True
        ' Define o texto da ToolTip para o Button, TextBox, Checkbox e Label
        toolTip1.SetToolTip(Me.ProgressBar1, "mostrar log biométrico")

        Call MostrarSplash()

        ' checa alguns componente essenciais e faz download se nao existirem
        Dim oUpdate As New cUpdate
        oUpdate.VerificaAtualizacoes()

        'otimiza a rotina de gradiente
        'SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.DoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)
        Left = (Screen.PrimaryScreen.Bounds.Width - Width) / 2   ' Center form horizontally.
        Top = (Screen.PrimaryScreen.Bounds.Height - Height) / 2  ' Center form vertically.

        lblVersao.Text = " Versão " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & Format(My.Application.Info.Version.Build, "0#")
        '_util.Mensagem_LogLocal(Me.Text, False, Me.Name, True, "")

        Me.Refresh()

        _setup.Carregar()       ' atualiza versao atual da estação
        splash.Visible = False

        Timer1.Enabled = False


        'frmSetup.chkLoginBiometrico.Checked = False
        ' desativei login biometrico usuarios... a partir versao 2.1.06, 28/08/2021
        'If frmSetup.chkLoginBiometrico.Checked Then
        '   GroupBox1.Visible = True
        '    Dim err As Integer
        ' initialize util class
        '     _toolsSiFam = New clsSiFam(LogList, picDigital, AxGrFingerXCtrl1)
        ' Initialize GrFingerX Library
        '      err = _toolsSiFam.InitializeGrFinger()
        ' Print result in log
        '       If err < 0 Then
        '            _toolsSiFam.ErroGriaule(err)
        '         Else
        '              _toolsSiFam.WriteLog("**GrFingerX Inicializado com Sucesso**")
        '               Timer1.Enabled = True
        '            End If
        'End If

    End Sub

    Private Sub MostrarSplash()
        splash.Opacity = 0
        splash.Show()
        splash.Left = ((My.Computer.Screen.Bounds.Width - splash.Width) / 2)
        splash.Top = ((My.Computer.Screen.Bounds.Height - splash.Height) / 2)
        Dim i As Integer
        For i = 1 To 200
            splash.Opacity = splash.Opacity + 0.005
            System.Threading.Thread.Sleep(4)
            System.Windows.Forms.Application.DoEvents()
        Next
        System.Threading.Thread.Sleep(50)
        'splash.Visible = False
    End Sub


    Public Sub Desativa()
        '     _toolsSiFam.FinalizeGrFinger()
    End Sub

    ' -----------------------------------------------------------------------------------
    ' GrFingerX events
    ' -----------------------------------------------------------------------------------
    ' A fingerprint reader was plugged on system
    Private Sub AxGrFingerXCtrl1_SensorPlug(ByVal sender As System.Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_SensorPlugEvent) Handles AxGrFingerXCtrl1.SensorPlug
        '    _toolsSiFam.WriteLog("Sensor: " & e.idSensor & ". Evento: Conectado.")
        '    AxGrFingerXCtrl1.CapStartCapture(e.idSensor)
    End Sub
    ' A fingerprint reader was unplugged from system
    Private Sub AxGrFingerXCtrl1_SensorUnplug(ByVal sender As System.Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_SensorUnplugEvent) Handles AxGrFingerXCtrl1.SensorUnplug
        '    _toolsSiFam.WriteLog("Sensor: " & e.idSensor & ". Evento: Desconectado.")
        '    AxGrFingerXCtrl1.CapStopCapture(e.idSensor)
    End Sub
    ' A finger was placed on reader
    Private Sub AxGrFingerXCtrl1_FingerDown(ByVal sender As System.Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_FingerDownEvent) Handles AxGrFingerXCtrl1.FingerDown
        '   _toolsSiFam.WriteLog("Sensor: " & e.idSensor & ". Evento: Dedo Posicionado.")
    End Sub
    ' A finger was removed from reader
    Private Sub AxGrFingerXCtrl1_FingerUp(ByVal sender As System.Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_FingerUpEvent) Handles AxGrFingerXCtrl1.FingerUp
        '  _toolsSiFam.WriteLog("Sensor: " & e.idSensor & ". Event: Dedo removido.")
    End Sub
    ' An image was acquired from reader
    Private Sub AxGrFingerXCtrl1_ImageAcquired(ByVal sender As System.Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_ImageAcquiredEvent) Handles AxGrFingerXCtrl1.ImageAcquired
        ' Copying aquired image
        ' _toolsSiFam.raw.height = e.height
        ' _toolsSiFam.raw.width = e.width
        ' _toolsSiFam.raw.res = e.res
        ' _toolsSiFam.raw.img = e.rawImage

        ' Signaling that an Image Event occurred.
        ' _toolsSiFam.WriteLog("Sensor: " & e.idSensor & ". Event: Imagem Capturada.")

        ' display fingerprint image
        ' _toolsSiFam.PrintBiometricDisplay(False, GRConstants.GR_DEFAULT_CONTEXT)

        ' now we have a fingerprint, so we can extract template
        'ExtractButton.Enabled = True
        'EnrollButton.Enabled = False
        'IdentifyButton.Enabled = False
        'VerifyButton.Enabled = False

        ' extracting template from image
        'If ckAutoExtract.Checked Then ExtractButton.PerformClick()

        ' identify fingerprint
        'If ckBoxAutoIdentify.Checked Then IdentifyButton().PerformClick()

        ' Dim vbLiberaBiometria As Boolean = False
        ' Dim ret As Integer

        ' vsGlo_Log = ""

        '        ret = _toolsSiFam.ExtractTemplate()
        '        If ret = GrFinger.GR_BAD_QUALITY Then
        '       vsGlo_Log = "A Digital extraída está com Qualidade RUIM, Por favor tente novamente."
        '      MsgBox(vsGlo_Log)
        '     vbPassou = False
        '    ElseIf ret = GrFinger.GR_MEDIUM_QUALITY Then
        '   'vsGlo_Log = "A Digital extraída está com Qualidade MÉDIA."
        '  'MsgBox(vsGlo_Log)
        ' vbLiberaBiometria = True
        'ElseIf ret = GrFinger.GR_HIGH_QUALITY Then
        'vbLiberaBiometria = True
        'Else
        ' vsGlo_Log = "Digital informada não foi localizada !"
        'MsgBox(vsGlo_Log, MsgBoxStyle.Information, "Impossível prosseguir !")
        'End If

        '        TxtUsuario.Text = ""
        '       txtSenha.Text = ""

        '        Dim score As Integer
        '       If vbLiberaBiometria Then
        '      score = 0
        '     _toolsSiFam.PrintBiometricDisplay(True, GRConstants.GR_NO_CONTEXT)
        '
        ' ret = _toolsSiFam.Identify(score, 0, 0, False, "")
        'If ret > 0 Then
        '_toolsSiFam.WriteLog("Digital Identificada. ID = " & ret & ". Score = " & score & ".")
        'vsGlo_Log = "Digital identificada. ID = " & ret & ". Escore = " & score & "."
        '' imprime matriz de ponto sobre a digital
        '_toolsSiFam.PrintBiometricDisplay(True, GRConstants.GR_DEFAULT_CONTEXT)
        '_u.LocalizaViaDigital(ret)
        'If TxtUsuario.Text <> "" And txtSenha.Text <> "" Then btnLogin.PerformClick()
        'Else
        '_toolsSiFam.WriteLog("Digital não Encontrada.")
        'vsGlo_Log = "Digital Não identificada. = " & ret & ". Escore = " & score & "."
        'End If
        'ElseIf ret = 0 Then
        '_toolsSiFam.WriteLog("Digital não Encontrada.")
        'vsGlo_Log = "Digital Não identificada. = " & ret & ". Escore = " & score & "."
        'Else
        '_toolsSiFam.WriteLog(ret)
        'vsGlo_Log = "Erro - Digital Não identificada. = " & ret & ". Escore = " & score & "."
        'End If


        'GC.Collect()

        'vnGlo_idDigital = ret
        'vbGlo_InseriuDigital = True


    End Sub
    ' Sobrescreva o evento OnPaint do formulário
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        ' Declare uma variável do tipo Graphics chamada formGraphics.
        ' Atribua o endereço (Refereência) a deste objeto a variável FromGraphics
        'Dim formGraphics As Graphics = e.Graphics
        ' Declare uma variável do tipo LinearGradientBrush chamada gradientBrush.
        ' Use o construtor LinearGradientBrush para criar um novo objeto LinearGradientBrush
        ' Atribua o endereço do novo objeto a variável gradientBrush

        'versão 1.9.9
        'Dim gradientBrush As New LinearGradientBrush(New Point(0, 0), New Point(Width, 0), Color.Maroon, Color.White)

        'Dim gradientBrush As New LinearGradientBrush(New Point(0, 0), New Point(Width, 0), Color.Maroon, Color.White)
        'formGraphics.FillRectangle(gradientBrush, ClientRectangle)
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Application.Exit()
        _PG.Desconectar()
        Me.Close()
        End
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        'StrConection_NPG_Biosifam = "Server=db3.pelotas.com.br;Database=prevpel2;UserId=ubiosifam;Password=d4t4b4nk;preload reader=true;Encoding=sql-ascii;;" 'ClientEncoding=sql-ascii;
        '_PG = New ClsBancoNPG(StrConection_NPG_Biosifam, "")

        If _u.ValidarUsuario(TxtUsuario.Text, txtSenha.Text, False) = False Then
            If _u.vbUsuarioLocalizado = False Then
                TxtUsuario.SelectionStart = 0 : TxtUsuario.SelectionLength = TxtUsuario.TextLength
                TxtUsuario.Focus()
            Else
                If _u.vbUsuarioValidado = False Then txtSenha.SelectionStart = 0 : txtSenha.SelectionLength = txtSenha.TextLength : txtSenha.Focus()
            End If
            Exit Sub
        End If
        _u.BuscarDados(TxtUsuario.Text)
        _u.BuscarDadosTipoFamiliar()
        _u.BuscarGrupos()

        Timer1.Enabled = False
        vbGlo_InseriuDigital = False
        vbDigitalContribuinte = True

        'If frmSetup.chkLoginBiometrico.Checked Then _toolsSiFam.FinalizeGrFinger()

        If _u.vbUsuarioDigitador Then
            If (_u.vbUsuarioPrevpel = False And _u.vbUsuarioSuporte = False) And _u.IdPrestador = 0 Then
                MsgBox("Seu usuário não está classificado corretamente, entre em contato com o suporte técnico para corrigir seu cadastro. ", MsgBoxStyle.Critical, Me.Name & " - Usuário sem Acesso.")
                _PG.Desconectar()
                End
            End If
        End If

        If frmMain.vbLoad Then
            frmMain.ConfiguraForm()  ' só carrega aqui se já existe, significa que quer trocar de usuario
            MsgBox("Reiniciado novo usuário vinculado a " & _u.NomePrestador)
        End If
        frmMain.Show()
        frmMain.Activate()
        frmMain.txtMatricula.Focus()
        Me.Hide()

    End Sub


    Private Sub btnTrocaSenha_Click(sender As Object, e As EventArgs) Handles btnTrocaSenha.Click
        If TxtUsuario.Text = "" Or txtSenha.Text = "" Then
            MsgBox("Informe o usuário e a senha atual e após clique em TROCAR SENHA.")
            Exit Sub
        End If
        Dim vsNovaSenha As String = InputBox("Informe a nova senha. Deixe em branco se quiser cancelar a operação.", vbInformation, "")
        If vsNovaSenha = "" Then Exit Sub

        Dim vsConfirmaNovaSenha As String = InputBox("Repeta a senha anterior.  Deixe em branco se quiser cancelar a operação.", vbInformation, "Confirme a nova senha")
        If vsConfirmaNovaSenha = "" Then Exit Sub

        If vsNovaSenha <> vsConfirmaNovaSenha Then
            MsgBox("As senhas informadas não são iguais, por favor clique em TROCAR SENHA e repita o procedimento.")
            Exit Sub
        End If
        If _u.ValidarUsuario(TxtUsuario.Text, txtSenha.Text, False) = False Then Exit Sub

        If _u.vbUsuarioLocalizado Then
            TxtUsuario.SelectionStart = 0 : TxtUsuario.SelectionLength = TxtUsuario.TextLength
            TxtUsuario.Focus()
            _PG.Execute("update usuario set senha='" & vsNovaSenha & "' where login='" & TxtUsuario.Text & "'")

            Dim Email = New ClsMail("Prevpel - Biosifam")
            Dim DrPrestador As Npgsql.NpgsqlDataReader

            _u.BuscarGrupos()

            If _u.vbUsuarioSuporte Or _u.vbUsuarioPrevpel Then
                Email.vsEmail = _u.Email
            ElseIf _u.IdPrestador > 0 Then
                DrPrestador = _PG.DrQuery("Select email from prestador where id_prestador=" & _u.IdPrestador)
                If DrPrestador.HasRows Then
                    DrPrestador.Read()
                    Email.vsEmail = DrPrestador.Item("email")
                End If
            End If

            If _u.Email <> "" Then
                Email.vsAssunto = "Alteração de Senha"
                Email.vsMensagem = "Comunicamos que o usuário " & TxtUsuario.Text & ", vinculado a seu acesso ao sistema BIOSIFAM, teve a alteração de senha realizada com sucesso as " & Format(Date.Now, "hh:mm") & " de " & Format(Date.Today, "dd/MM/yyyy") & "."
                Email.vsMensagem &= Chr(13) & " PREVPEL/Biosifam"
                Email.vbAutomatico = True
                Email.vbAutenticacaoSegura = True
                Email.vbMostrarMensagem = False
                Email.Enviar()
            End If
            MsgBox("Senha atualizada com sucesso. " & Chr(13) & Chr(13) & "Identifique-se novamente, agora com a nova senha.")
            txtSenha.Focus()
        End If

    End Sub

    Private Sub txtUsuario_GotFocus(sender As Object, e As EventArgs) Handles TxtUsuario.GotFocus
        TxtUsuario.SelectionStart = 0
        TxtUsuario.SelectionLength = TxtUsuario.Text.Length
    End Sub

    Private Sub txtSenha_GotFocus(sender As Object, e As EventArgs) Handles txtSenha.GotFocus
        txtSenha.SelectionStart = 0
        txtSenha.SelectionLength = txtSenha.Text.Length
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If ProgressBar1.Value > 100 Then ProgressBar1.Value += 2 Else ProgressBar1.Value += 4
        If ProgressBar1.Value > 118 Then ProgressBar1.Value = 0

    End Sub

    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs) Handles ProgressBar1.Click
        If LogList.Visible Then LogList.Visible = False Else LogList.Visible = True

    End Sub

    Private Sub frmLogin_KeyDown(ByVal sender As Object, ByVal EventArgs As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Dim KeyCode As Short = EventArgs.KeyCode
        vsGlo_frmAtivo = Me.Text

        ' teclou ENTER põe o foco no próximo controle 
        If KeyCode = System.Windows.Forms.Keys.Return Then System.Windows.Forms.SendKeys.Send("{TAB}") ' + é{tab} o shit

        'se teclar ESC sai
        If KeyCode = System.Windows.Forms.Keys.Escape Then
            End
        End If

    End Sub

 
End Class
