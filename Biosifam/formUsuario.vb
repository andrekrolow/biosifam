'
'     SIFAM - Sistema Informatizado do Fundo de Assistência Médica
' 
'				Copyright (c) 2010 COINPEL
' 
'     Descrição : Classe frmUsuario
'     Autor:  Cauê Duarte (caueduar@gmail.com)
'     Criação:   24/08/2010
'     Modificação:  24/08/2010

Imports Microsoft.VisualBasic

Public Class frmUsuario
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "


    Public Sub New()
        MyBase.New()

        InitializeComponent()

    End Sub


    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    Private components As System.ComponentModel.IContainer

    Friend WithEvents grpDigital As System.Windows.Forms.GroupBox
    Friend WithEvents grpStatus As System.Windows.Forms.GroupBox
    Friend WithEvents LogList As System.Windows.Forms.ListBox
    Friend WithEvents btnGravar As System.Windows.Forms.Button
    Friend WithEvents btnExcluir As System.Windows.Forms.Button
    Protected WithEvents grdIdentifica As System.Windows.Forms.DataGridView
    Friend WithEvents lblUsuarioCorrente As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rtbApoio As System.Windows.Forms.RichTextBox
    Friend WithEvents btnEncerrar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents picDigital As System.Windows.Forms.PictureBox
    Friend WithEvents AxGrFingerXCtrl1 As AxGrFingerXLib.AxGrFingerXCtrl
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents lblSituacao As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUsuario))
        Me.grpDigital = New System.Windows.Forms.GroupBox()
        Me.btnEncerrar = New System.Windows.Forms.Button()
        Me.rtbApoio = New System.Windows.Forms.RichTextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.picDigital = New System.Windows.Forms.PictureBox()
        Me.lblSituacao = New System.Windows.Forms.Label()
        Me.grdIdentifica = New System.Windows.Forms.DataGridView()
        Me.btnGravar = New System.Windows.Forms.Button()
        Me.btnExcluir = New System.Windows.Forms.Button()
        Me.grpStatus = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LogList = New System.Windows.Forms.ListBox()
        Me.lblUsuarioCorrente = New System.Windows.Forms.Label()
        Me.AxGrFingerXCtrl1 = New AxGrFingerXLib.AxGrFingerXCtrl()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.grpDigital.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.picDigital, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdIdentifica, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpStatus.SuspendLayout()
        CType(Me.AxGrFingerXCtrl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpDigital
        '
        Me.grpDigital.Controls.Add(Me.btnEncerrar)
        Me.grpDigital.Controls.Add(Me.rtbApoio)
        Me.grpDigital.Controls.Add(Me.GroupBox1)
        Me.grpDigital.Controls.Add(Me.grdIdentifica)
        Me.grpDigital.Controls.Add(Me.btnGravar)
        Me.grpDigital.Controls.Add(Me.btnExcluir)
        Me.grpDigital.ForeColor = System.Drawing.Color.Maroon
        Me.grpDigital.Location = New System.Drawing.Point(17, 36)
        Me.grpDigital.Name = "grpDigital"
        Me.grpDigital.Size = New System.Drawing.Size(550, 261)
        Me.grpDigital.TabIndex = 11
        Me.grpDigital.TabStop = False
        Me.grpDigital.Text = "Verificador Biométrico"
        Me.grpDigital.Visible = False
        '
        'btnEncerrar
        '
        Me.btnEncerrar.Location = New System.Drawing.Point(261, 213)
        Me.btnEncerrar.Name = "btnEncerrar"
        Me.btnEncerrar.Size = New System.Drawing.Size(78, 28)
        Me.btnEncerrar.TabIndex = 24
        Me.btnEncerrar.Text = "Encerrar"
        '
        'rtbApoio
        '
        Me.rtbApoio.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.rtbApoio.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbApoio.Location = New System.Drawing.Point(6, 24)
        Me.rtbApoio.Name = "rtbApoio"
        Me.rtbApoio.Size = New System.Drawing.Size(332, 101)
        Me.rtbApoio.TabIndex = 23
        Me.rtbApoio.Text = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.SeaGreen
        Me.GroupBox1.Controls.Add(Me.picDigital)
        Me.GroupBox1.Controls.Add(Me.lblSituacao)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(375, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(146, 190)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Leitor Biométrico"
        '
        'picDigital
        '
        Me.picDigital.BackColor = System.Drawing.SystemColors.Control
        Me.picDigital.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picDigital.Location = New System.Drawing.Point(16, 20)
        Me.picDigital.Name = "picDigital"
        Me.picDigital.Size = New System.Drawing.Size(116, 145)
        Me.picDigital.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picDigital.TabIndex = 26
        Me.picDigital.TabStop = False
        '
        'lblSituacao
        '
        Me.lblSituacao.Location = New System.Drawing.Point(17, 168)
        Me.lblSituacao.Name = "lblSituacao"
        Me.lblSituacao.Size = New System.Drawing.Size(114, 19)
        Me.lblSituacao.TabIndex = 25
        Me.lblSituacao.Text = "Conexão"
        Me.lblSituacao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grdIdentifica
        '
        Me.grdIdentifica.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.grdIdentifica.AllowUserToAddRows = False
        Me.grdIdentifica.AllowUserToDeleteRows = False
        Me.grdIdentifica.AllowUserToResizeColumns = False
        Me.grdIdentifica.AllowUserToResizeRows = False
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Maroon
        Me.grdIdentifica.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdIdentifica.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdIdentifica.BackgroundColor = System.Drawing.Color.White
        Me.grdIdentifica.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.grdIdentifica.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdIdentifica.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdIdentifica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdIdentifica.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdIdentifica.DefaultCellStyle = DataGridViewCellStyle3
        Me.grdIdentifica.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.grdIdentifica.EnableHeadersVisualStyles = False
        Me.grdIdentifica.GridColor = System.Drawing.Color.Maroon
        Me.grdIdentifica.Location = New System.Drawing.Point(7, 128)
        Me.grdIdentifica.MultiSelect = False
        Me.grdIdentifica.Name = "grdIdentifica"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdIdentifica.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.grdIdentifica.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.grdIdentifica.RowTemplate.Height = 24
        Me.grdIdentifica.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdIdentifica.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.grdIdentifica.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdIdentifica.ShowCellErrors = False
        Me.grdIdentifica.ShowCellToolTips = False
        Me.grdIdentifica.ShowEditingIcon = False
        Me.grdIdentifica.ShowRowErrors = False
        Me.grdIdentifica.Size = New System.Drawing.Size(332, 79)
        Me.grdIdentifica.TabIndex = 22
        '
        'btnGravar
        '
        Me.btnGravar.Enabled = False
        Me.btnGravar.Location = New System.Drawing.Point(85, 213)
        Me.btnGravar.Name = "btnGravar"
        Me.btnGravar.Size = New System.Drawing.Size(169, 28)
        Me.btnGravar.TabIndex = 3
        Me.btnGravar.Text = "Gravar"
        '
        'btnExcluir
        '
        Me.btnExcluir.Location = New System.Drawing.Point(7, 213)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(71, 28)
        Me.btnExcluir.TabIndex = 20
        Me.btnExcluir.Text = "Excluir"
        '
        'grpStatus
        '
        Me.grpStatus.Controls.Add(Me.Panel1)
        Me.grpStatus.Controls.Add(Me.LogList)
        Me.grpStatus.ForeColor = System.Drawing.Color.Maroon
        Me.grpStatus.Location = New System.Drawing.Point(17, 303)
        Me.grpStatus.Name = "grpStatus"
        Me.grpStatus.Size = New System.Drawing.Size(550, 82)
        Me.grpStatus.TabIndex = 16
        Me.grpStatus.TabStop = False
        Me.grpStatus.Text = "Informações"
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(451, 126)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(142, 41)
        Me.Panel1.TabIndex = 9
        '
        'LogList
        '
        Me.LogList.ItemHeight = 16
        Me.LogList.Location = New System.Drawing.Point(7, 22)
        Me.LogList.Name = "LogList"
        Me.LogList.ScrollAlwaysVisible = True
        Me.LogList.Size = New System.Drawing.Size(525, 52)
        Me.LogList.TabIndex = 8
        '
        'lblUsuarioCorrente
        '
        Me.lblUsuarioCorrente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUsuarioCorrente.ForeColor = System.Drawing.Color.White
        Me.lblUsuarioCorrente.Location = New System.Drawing.Point(14, 9)
        Me.lblUsuarioCorrente.Name = "lblUsuarioCorrente"
        Me.lblUsuarioCorrente.Size = New System.Drawing.Size(153, 25)
        Me.lblUsuarioCorrente.TabIndex = 17
        Me.lblUsuarioCorrente.Text = "Selecione um Usuário:"
        '
        'AxGrFingerXCtrl1
        '
        Me.AxGrFingerXCtrl1.Enabled = True
        Me.AxGrFingerXCtrl1.Location = New System.Drawing.Point(570, 6)
        Me.AxGrFingerXCtrl1.Name = "AxGrFingerXCtrl1"
        Me.AxGrFingerXCtrl1.OcxState = CType(resources.GetObject("AxGrFingerXCtrl1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxGrFingerXCtrl1.Size = New System.Drawing.Size(40, 40)
        Me.AxGrFingerXCtrl1.TabIndex = 24
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(173, 6)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(392, 24)
        Me.ComboBox1.Sorted = True
        Me.ComboBox1.TabIndex = 25
        '
        'frmUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.CadetBlue
        Me.ClientSize = New System.Drawing.Size(589, 409)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.AxGrFingerXCtrl1)
        Me.Controls.Add(Me.lblUsuarioCorrente)
        Me.Controls.Add(Me.grpStatus)
        Me.Controls.Add(Me.grpDigital)
        Me.ForeColor = System.Drawing.Color.Maroon
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmUsuario"
        Me.Tag = ""
        Me.Text = "Biometria SIFAM "
        Me.grpDigital.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.picDigital, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdIdentifica, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpStatus.ResumeLayout(False)
        CType(Me.AxGrFingerXCtrl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim strSQL As String
    Dim drDigitais As System.Data.Odbc.OdbcDataReader
    Dim drUsuarios As System.Data.Odbc.OdbcDataReader

    Dim OptionsForm1 As New OptionsForm
    Dim _toolsSiFam As clsSiFam
    Dim _util As clsUtil
    Public id_pessoa As Integer
    Public vsIPLocal As String = "", strUsuario As String
    Dim idSelecionado As Long, idDigital As Long
    Dim NomeSelecionado As String

    Public vsUsuarioNome As String = ""
    Public vsUsuarioId As String = ""

    Dim _banco As New clsBanco()

    Private Sub frmUsuario_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        vsGlo_frmAtivo = Me.Text
    End Sub

    Private Sub frmUsuario_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        _toolsSiFam.FinalizeGrFinger()
        frmMain.Show()

    End Sub

    Private Sub frmUsuario_KeyDown(ByVal sender As Object, ByVal EventArgs As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Dim KeyCode As Short = EventArgs.KeyCode

        ' teclou ENTER põe o foco no próximo controle 
        If KeyCode = System.Windows.Forms.Keys.Return Then
            'TextBox2.Focus()
            System.Windows.Forms.SendKeys.Send("{TAB}") ' + é{tab} o shit
        End If
    End Sub

    Private Sub frmUsuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _banco.BuscaConfig()
        _banco.Conecta()
        grpDigital.Visible = False
        InicializaBotoes()

        drUsuarios = _banco.drQuery("SELECT nome FROM usuario")
        Dim i As Integer
        For i = 0 To drUsuarios.RecordsAffected - 1
            drUsuarios.Read()
            ComboBox1.Items.Add(drUsuarios.Item(0))
        Next i

        Dim err As Integer

        ' initialize util class
        _toolsSiFam = New clsSiFam(LogList, picDigital, AxGrFingerXCtrl1)

        ' Initialize GrFingerX Library
        err = _toolsSiFam.InitializeGrFinger()
        ' Print result in log
        If err < 0 Then
            _toolsSiFam.ErroGriaule(err)
            Exit Sub
        Else
            _toolsSiFam.WriteLog("**GrFingerX Inicializado com Sucesso**")
        End If

    End Sub

    Private Sub InicializaBotoes()
        rtbApoio.Text = ""
        If frmsetup.vsModo = "0" Then btnGravar.Text = "Gravar Biometria" Else btnGravar.Text = "Gravar Consulta"
        vnGlo_IdPessoa = 0 : idDigital = 0
        grdIdentifica.DataSource = Nothing
        btnGravar.Enabled = False
        btnExcluir.Enabled = False

    End Sub

    Private Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
        Dim id As Integer
        id = _toolsSiFam.Enroll(1, strUsuario, vsUsuarioId)
        If id >= 0 Then
            MsgBox("Digital gravada com Sucesso. ID = " & id)
        Else
            MsgBox("Erro: Digital não gravada")
        End If
        btnGravar.Enabled = False
    End Sub

    Private Sub btnEncerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEncerrar.Click
        _banco.Desconecta()
        Me.Close()
        frmMain.Show()
        Exit Sub
    End Sub

    Private Sub btnExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcluir.Click
        If idDigital = 0 Then
            MsgBox("o Identificador da digital selecionada está vazio. Procure apoio técnico", MsgBoxStyle.Information, "Impossível proceder com a exclusão.")
        End If
        If MsgBox("Deseja realmente excluir esta digital ?", MsgBoxStyle.YesNo, "Confirme a operação de exclusão.") = vbYes Then
            _banco.executaQuery("delete from digital_usuario where id_digital_usuario=" & idDigital)
            grdIdentifica.DataSource = Nothing
            btnExcluir.Enabled = False

        End If

    End Sub

    ' Escreve Status no list box.
    Public Sub atualizaLogList(ByVal message As String)
        LogList.Items.Add(message)
        LogList.SelectedIndex = LogList.Items.Count - 1
        LogList.ClearSelected()
        Dim _util As New clsUtil
        _util.Mensagem_LogLocal(message, False, "FormUsuario", True, "")
    End Sub

    Private Sub IdentificaContribuinte(ByVal ret As Integer)
        Dim dr As System.Data.Odbc.OdbcDataReader
        dr = _banco.drQuery("SELECT id_digital_usuario, nome FROM usuario, digital_usuario WHERE usuario.login=usuario and id_digital_usuario = " & ret)
        If frmsetup.vsModo = "2" Or frmsetup.vsModo = "4" Then      ' medico = consultorio
            If dr.HasRows Then
                dr.Read()
                If dr.Item(0) <> vnGlo_IdPessoa Then
                    _util.Mensagem_LogLocal("Digital informada pertence a outro usuário.", True, "FormMain", True, "")
                    vsGlo_Log = "Digital pertence a outro usuário. Localizado para " & dr.Item(1)
                    btnGravar.Enabled = False
                Else
                    btnGravar.Text = "Gravar Consulta"
                    rtbApoio.Text = "Identificador: " & idSelecionado & Chr(13)
                    rtbApoio.Text = rtbApoio.Text & "Biometrias existentes: " & drDigitais.RecordsAffected & Chr(13)     'dr.Item(2)
                End If
            Else
                _util.Mensagem_LogLocal("Erro ao tentar localizar Digital na Base de dados. ID " & ret, False, "FormMain", True, "")
                btnGravar.Enabled = False
            End If
        Else
            If dr.HasRows Then
                dr.Read()
                If dr.Item(0) <> vnGlo_IdPessoa Then
                    vsGlo_Log = "Digital pertence a outro usuário. Localizado para " & dr.Item(1)
                    MsgBox(vsGlo_Log)
                    btnGravar.Enabled = False
                    btnExcluir.Visible = False
                End If
            End If
        End If
    End Sub

    ' -----------------------------------------------------------------------------------
    ' GrFingerX events
    ' -----------------------------------------------------------------------------------

    ' A fingerprint reader was plugged on system
    Private Sub AxGrFingerXCtrl1_SensorPlug(ByVal sender As System.Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_SensorPlugEvent)
        _toolsSiFam.WriteLog("Sensor: " & e.idSensor & ". Evento: Conectado.")
        AxGrFingerXCtrl1.CapStartCapture(e.idSensor)
        lblSituacao.BackColor = Color.Green
        lblSituacao.ForeColor = Color.White
        lblSituacao.Text = "Aguardando..."
        GroupBox1.Text = "Leitor Digital - Conectado"
    End Sub
    ' A fingerprint reader was unplugged from system
    Private Sub AxGrFingerXCtrl1_SensorUnplug(ByVal sender As System.Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_SensorUnplugEvent)
        _toolsSiFam.WriteLog("Sensor: " & e.idSensor & ". Evento: Desconectado.")
        AxGrFingerXCtrl1.CapStopCapture(e.idSensor)
        lblSituacao.BackColor = Color.Red
        lblSituacao.ForeColor = Color.White
        lblSituacao.Text = "Desconectado"
        GroupBox1.Text = "Leitor Digital "
    End Sub

    ' A finger was placed on reader
    Private Sub AxGrFingerXCtrl1_FingerDown(ByVal sender As System.Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_FingerDownEvent)
        _toolsSiFam.WriteLog("Sensor: " & e.idSensor & ". Evento: Dedo Posicionado.")
        lblSituacao.BackColor = Color.Red
        lblSituacao.ForeColor = Color.White
        lblSituacao.Text = "Dedo Posicionado"
    End Sub

    ' A finger was removed from reader
    Private Sub AxGrFingerXCtrl1_FingerUp(ByVal sender As System.Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_FingerUpEvent)
        _toolsSiFam.WriteLog("Sensor: " & e.idSensor & ". Event: Dedo removido.")
        lblSituacao.BackColor = Color.Red
        lblSituacao.ForeColor = Color.White
        lblSituacao.Text = "Dedo Removido"
    End Sub

    Private Sub AxGrFingerXCtrl1_ImageAcquired(ByVal sender As System.Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_ImageAcquiredEvent)

        ' An image was acquired from reader

        Dim ret As Integer
        Dim _util As New clsUtil
        Dim vbLiberaBiometria As Boolean = False

        vsGlo_Log = ""

        lblSituacao.BackColor = Color.Yellow
        lblSituacao.ForeColor = Color.Black
        lblSituacao.Text = "Conectado, avaliando digital."

        _toolsSiFam.raw.height = e.height
        _toolsSiFam.raw.width = e.width
        _toolsSiFam.raw.res = e.res
        _toolsSiFam.raw.img = e.rawImage

        _toolsSiFam.PrintBiometricDisplay(False, GrFinger.GR_DEFAULT_CONTEXT)

        ret = _toolsSiFam.ExtractTemplate()
        If ret = GrFinger.GR_BAD_QUALITY Then
            vsGlo_Log = "A Digital extraída está com Qualidade RUIM, Por favor tente novamente."
            MsgBox(vsGlo_Log)
        ElseIf ret = GrFinger.GR_MEDIUM_QUALITY Then
            vsGlo_Log = "A Digital extraída está com Qualidade MÉDIA."
            MsgBox(vsGlo_Log)
            vbLiberaBiometria = True
        ElseIf ret = GrFinger.GR_HIGH_QUALITY Then
            vbLiberaBiometria = True
        Else
            vsGlo_Log = "Digital informada não foi localizada !"
            MsgBox(vsGlo_Log, MsgBoxStyle.Information, "Impossível prosseguir !")
        End If

        If vbLiberaBiometria = True Then
            Dim score As Integer
            score = 0
            ' imprime matriz de ponto sobre a digital
            _toolsSiFam.PrintBiometricDisplay(True, GrFinger.GR_NO_CONTEXT)

            ret = _toolsSiFam.Identify(score, 1, "", False, "")
            If ret > 0 Then
                vsGlo_Log = "Digital identificada. ID = " & ret & ". Escore = " & score & "."

                atualizaLogList(vsGlo_Log)

                'identificou a digital 
                btnGravar.Text = "Gravar Nova Biometria"

                Dim ds As New DataSet
                grdIdentifica.DataSource = Nothing
                idDigital = vnGlo_IdDigital
                If idDigital > 0 Then
                    btnGravar.Enabled = True
                    btnGravar.Visible = True
                    btnExcluir.Enabled = True
                    btnExcluir.Visible = True
                    IdentificaContribuinte(idDigital)
                Else
                    MsgBox("Nova Digital informada, sistema pronto para atualização.")
                    If frmsetup.vsModo = "0" Then btnGravar.Text = "Gravar Biometria" Else btnGravar.Text = "Gravar Consulta"
                    btnGravar.Enabled = True
                    btnExcluir.Visible = False
                End If

                ds = _banco.obtemQuery("SELECT id_digital, nome FROM pessoas INNER JOIN digital USING (id_pessoa) WHERE id_digital = " & vnGlo_IdDigital)

                grdIdentifica.DataSource = ds.Tables(0)
                'ds.Tables.Item(0).Columns(1).ToString
                grdIdentifica.Columns(0).Width = 50
                grdIdentifica.Refresh()
            Else
                vsGlo_Log = "Digital Não identificada. = " & ret & ". Escore = " & score & "."
            End If

            vnGlo_IdDigital = ret
            vbGlo_InseriuDigital = True
        End If
    End Sub


    Private Sub ComboBox1_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        grpDigital.Visible = True
        drUsuarios = _banco.drQuery("SELECT * FROM usuario WHERE nome='" & ComboBox1.Text & "'")
        If drUsuarios.HasRows Then
            drUsuarios.Read()
            strUsuario = drUsuarios.Item(0)
            btnGravar.Enabled = True
            IdentificaContribuinte(idDigital)
        End If

    End Sub
End Class

