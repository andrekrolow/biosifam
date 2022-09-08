'
'     SIFAM - Sistema Informatizado do Fundo de Assistência Médica
' 
'				Copyright (c) 2010 COINPEL
' 
'     Descrição : Classe frmPrincipal
'     Autor:  Cauê Duarte (caueduar@gmail.com)
'     Criação:   24/08/2010
'     Modificação:  24/08/2010

' quando der erro de classe não registrada tem que instalada o finger sdk

Imports Microsoft.VisualBasic
Imports System.IO

Public Class frmApoio
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
    Friend WithEvents grpIdentificação As System.Windows.Forms.GroupBox
    Friend WithEvents btnMatricula As System.Windows.Forms.Button
    Friend WithEvents lblMatricula As System.Windows.Forms.Label
    Friend WithEvents txtMatricula As System.Windows.Forms.TextBox
    Friend WithEvents grpStatus As System.Windows.Forms.GroupBox
    Friend WithEvents LogList As System.Windows.Forms.ListBox
    Protected WithEvents grdContribuintes As System.Windows.Forms.DataGridView
    Friend WithEvents btnGravar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rtbApoio As System.Windows.Forms.RichTextBox
    Friend WithEvents btnEncerrar As System.Windows.Forms.Button
    Friend WithEvents rtbPessoa As System.Windows.Forms.RichTextBox
    Public WithEvents grdIdentifica As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents GroupBiometria As System.Windows.Forms.GroupBox
    Public WithEvents picMain As System.Windows.Forms.PictureBox
    Friend WithEvents lblSituacao As System.Windows.Forms.Label
    Friend WithEvents AxGrFingerXCtrl1 As AxGrFingerXLib.AxGrFingerXCtrl
    Friend WithEvents lblSenha As System.Windows.Forms.Label
    Friend WithEvents grpSenha As System.Windows.Forms.GroupBox
    Friend WithEvents btnValidaSenha As System.Windows.Forms.Button
    Friend WithEvents mskSenha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents grpSenhaConfirmacao As System.Windows.Forms.GroupBox
    Friend WithEvents btnValidaSenhaConfirmacao As System.Windows.Forms.Button
    Friend WithEvents mskSenhaConfirmacao As System.Windows.Forms.MaskedTextBox

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmApoio))
        Me.grpDigital = New System.Windows.Forms.GroupBox()
        Me.grpSenha = New System.Windows.Forms.GroupBox()
        Me.btnValidaSenha = New System.Windows.Forms.Button()
        Me.mskSenha = New System.Windows.Forms.MaskedTextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.GroupBiometria = New System.Windows.Forms.GroupBox()
        Me.lblSenha = New System.Windows.Forms.Label()
        Me.picMain = New System.Windows.Forms.PictureBox()
        Me.lblSituacao = New System.Windows.Forms.Label()
        Me.grdIdentifica = New System.Windows.Forms.DataGridView()
        Me.btnEncerrar = New System.Windows.Forms.Button()
        Me.rtbApoio = New System.Windows.Forms.RichTextBox()
        Me.btnGravar = New System.Windows.Forms.Button()
        Me.grpIdentificação = New System.Windows.Forms.GroupBox()
        Me.rtbPessoa = New System.Windows.Forms.RichTextBox()
        Me.grdContribuintes = New System.Windows.Forms.DataGridView()
        Me.btnMatricula = New System.Windows.Forms.Button()
        Me.lblMatricula = New System.Windows.Forms.Label()
        Me.txtMatricula = New System.Windows.Forms.TextBox()
        Me.grpStatus = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LogList = New System.Windows.Forms.ListBox()
        Me.AxGrFingerXCtrl1 = New AxGrFingerXLib.AxGrFingerXCtrl()
        Me.grpSenhaConfirmacao = New System.Windows.Forms.GroupBox()
        Me.btnValidaSenhaConfirmacao = New System.Windows.Forms.Button()
        Me.mskSenhaConfirmacao = New System.Windows.Forms.MaskedTextBox()
        Me.grpDigital.SuspendLayout()
        Me.grpSenha.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBiometria.SuspendLayout()
        CType(Me.picMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdIdentifica, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpIdentificação.SuspendLayout()
        CType(Me.grdContribuintes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpStatus.SuspendLayout()
        CType(Me.AxGrFingerXCtrl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSenhaConfirmacao.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpDigital
        '
        Me.grpDigital.BackColor = System.Drawing.SystemColors.Control
        Me.grpDigital.Controls.Add(Me.grpSenha)
        Me.grpDigital.Controls.Add(Me.GroupBox1)
        Me.grpDigital.Controls.Add(Me.GroupBiometria)
        Me.grpDigital.Controls.Add(Me.grdIdentifica)
        Me.grpDigital.Controls.Add(Me.btnEncerrar)
        Me.grpDigital.Controls.Add(Me.rtbApoio)
        Me.grpDigital.Controls.Add(Me.btnGravar)
        Me.grpDigital.ForeColor = System.Drawing.Color.Maroon
        Me.grpDigital.Location = New System.Drawing.Point(12, 85)
        Me.grpDigital.Margin = New System.Windows.Forms.Padding(2)
        Me.grpDigital.Name = "grpDigital"
        Me.grpDigital.Padding = New System.Windows.Forms.Padding(2)
        Me.grpDigital.Size = New System.Drawing.Size(538, 271)
        Me.grpDigital.TabIndex = 11
        Me.grpDigital.TabStop = False
        Me.grpDigital.Visible = False
        '
        'grpSenha
        '
        Me.grpSenha.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grpSenha.Controls.Add(Me.btnValidaSenha)
        Me.grpSenha.Controls.Add(Me.mskSenha)
        Me.grpSenha.Location = New System.Drawing.Point(195, 201)
        Me.grpSenha.Margin = New System.Windows.Forms.Padding(2)
        Me.grpSenha.Name = "grpSenha"
        Me.grpSenha.Padding = New System.Windows.Forms.Padding(2)
        Me.grpSenha.Size = New System.Drawing.Size(176, 49)
        Me.grpSenha.TabIndex = 36
        Me.grpSenha.TabStop = False
        Me.grpSenha.Text = "Senha"
        Me.grpSenha.Visible = False
        '
        'btnValidaSenha
        '
        Me.btnValidaSenha.Enabled = False
        Me.btnValidaSenha.Font = New System.Drawing.Font("Tahoma", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnValidaSenha.Location = New System.Drawing.Point(135, 20)
        Me.btnValidaSenha.Margin = New System.Windows.Forms.Padding(2)
        Me.btnValidaSenha.Name = "btnValidaSenha"
        Me.btnValidaSenha.Size = New System.Drawing.Size(25, 20)
        Me.btnValidaSenha.TabIndex = 9
        Me.btnValidaSenha.Text = "ok"
        '
        'mskSenha
        '
        Me.mskSenha.Location = New System.Drawing.Point(17, 20)
        Me.mskSenha.Name = "mskSenha"
        Me.mskSenha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.mskSenha.Size = New System.Drawing.Size(116, 20)
        Me.mskSenha.TabIndex = 7
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.WebBrowser1)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(298, 14)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(102, 152)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Tag = "DuploClick amplia a foto."
        Me.GroupBox1.Text = "Foto"
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Location = New System.Drawing.Point(13, 18)
        Me.WebBrowser1.Margin = New System.Windows.Forms.Padding(2)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(15, 16)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.ScrollBarsEnabled = False
        Me.WebBrowser1.Size = New System.Drawing.Size(80, 116)
        Me.WebBrowser1.TabIndex = 26
        '
        'GroupBiometria
        '
        Me.GroupBiometria.BackColor = System.Drawing.Color.Maroon
        Me.GroupBiometria.Controls.Add(Me.lblSenha)
        Me.GroupBiometria.Controls.Add(Me.picMain)
        Me.GroupBiometria.Controls.Add(Me.lblSituacao)
        Me.GroupBiometria.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBiometria.ForeColor = System.Drawing.Color.White
        Me.GroupBiometria.Location = New System.Drawing.Point(404, 14)
        Me.GroupBiometria.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBiometria.Name = "GroupBiometria"
        Me.GroupBiometria.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBiometria.Size = New System.Drawing.Size(110, 154)
        Me.GroupBiometria.TabIndex = 29
        Me.GroupBiometria.TabStop = False
        Me.GroupBiometria.Text = "Leitor Biométrico"
        '
        'lblSenha
        '
        Me.lblSenha.BackColor = System.Drawing.Color.Yellow
        Me.lblSenha.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSenha.ForeColor = System.Drawing.Color.Black
        Me.lblSenha.Location = New System.Drawing.Point(13, 18)
        Me.lblSenha.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSenha.Name = "lblSenha"
        Me.lblSenha.Size = New System.Drawing.Size(85, 114)
        Me.lblSenha.TabIndex = 27
        Me.lblSenha.Text = "Identificação digital desativada. Usuário utilizando senha."
        Me.lblSenha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'picMain
        '
        Me.picMain.BackColor = System.Drawing.SystemColors.Control
        Me.picMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picMain.Location = New System.Drawing.Point(11, 16)
        Me.picMain.Margin = New System.Windows.Forms.Padding(2)
        Me.picMain.Name = "picMain"
        Me.picMain.Size = New System.Drawing.Size(88, 119)
        Me.picMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picMain.TabIndex = 26
        Me.picMain.TabStop = False
        '
        'lblSituacao
        '
        Me.lblSituacao.Location = New System.Drawing.Point(13, 136)
        Me.lblSituacao.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSituacao.Name = "lblSituacao"
        Me.lblSituacao.Size = New System.Drawing.Size(86, 15)
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
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdIdentifica.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdIdentifica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdIdentifica.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdIdentifica.DefaultCellStyle = DataGridViewCellStyle3
        Me.grdIdentifica.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.grdIdentifica.EnableHeadersVisualStyles = False
        Me.grdIdentifica.GridColor = System.Drawing.Color.Maroon
        Me.grdIdentifica.Location = New System.Drawing.Point(5, 104)
        Me.grdIdentifica.Margin = New System.Windows.Forms.Padding(2)
        Me.grdIdentifica.MultiSelect = False
        Me.grdIdentifica.Name = "grdIdentifica"
        Me.grdIdentifica.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.grdIdentifica.RowTemplate.Height = 24
        Me.grdIdentifica.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdIdentifica.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.grdIdentifica.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdIdentifica.ShowCellErrors = False
        Me.grdIdentifica.ShowCellToolTips = False
        Me.grdIdentifica.ShowEditingIcon = False
        Me.grdIdentifica.ShowRowErrors = False
        Me.grdIdentifica.Size = New System.Drawing.Size(282, 64)
        Me.grdIdentifica.TabIndex = 26
        '
        'btnEncerrar
        '
        Me.btnEncerrar.Font = New System.Drawing.Font("Tahoma", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEncerrar.Location = New System.Drawing.Point(460, 173)
        Me.btnEncerrar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnEncerrar.Name = "btnEncerrar"
        Me.btnEncerrar.Size = New System.Drawing.Size(64, 23)
        Me.btnEncerrar.TabIndex = 24
        Me.btnEncerrar.Text = "Encerrar"
        '
        'rtbApoio
        '
        Me.rtbApoio.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.rtbApoio.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbApoio.Location = New System.Drawing.Point(7, 17)
        Me.rtbApoio.Margin = New System.Windows.Forms.Padding(2)
        Me.rtbApoio.Name = "rtbApoio"
        Me.rtbApoio.Size = New System.Drawing.Size(282, 83)
        Me.rtbApoio.TabIndex = 23
        Me.rtbApoio.Text = ""
        '
        'btnGravar
        '
        Me.btnGravar.Enabled = False
        Me.btnGravar.Font = New System.Drawing.Font("Tahoma", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGravar.Location = New System.Drawing.Point(298, 173)
        Me.btnGravar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGravar.Name = "btnGravar"
        Me.btnGravar.Size = New System.Drawing.Size(87, 23)
        Me.btnGravar.TabIndex = 3
        Me.btnGravar.Text = "Gravar"
        '
        'grpIdentificação
        '
        Me.grpIdentificação.BackColor = System.Drawing.SystemColors.Control
        Me.grpIdentificação.Controls.Add(Me.rtbPessoa)
        Me.grpIdentificação.Controls.Add(Me.grdContribuintes)
        Me.grpIdentificação.Controls.Add(Me.btnMatricula)
        Me.grpIdentificação.Controls.Add(Me.lblMatricula)
        Me.grpIdentificação.Controls.Add(Me.txtMatricula)
        Me.grpIdentificação.ForeColor = System.Drawing.Color.Maroon
        Me.grpIdentificação.Location = New System.Drawing.Point(11, 30)
        Me.grpIdentificação.Margin = New System.Windows.Forms.Padding(2)
        Me.grpIdentificação.Name = "grpIdentificação"
        Me.grpIdentificação.Padding = New System.Windows.Forms.Padding(2)
        Me.grpIdentificação.Size = New System.Drawing.Size(538, 51)
        Me.grpIdentificação.TabIndex = 15
        Me.grpIdentificação.TabStop = False
        Me.grpIdentificação.Text = "Identificação do Contribuinte"
        '
        'rtbPessoa
        '
        Me.rtbPessoa.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.rtbPessoa.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbPessoa.Location = New System.Drawing.Point(256, 12)
        Me.rtbPessoa.Margin = New System.Windows.Forms.Padding(2)
        Me.rtbPessoa.Name = "rtbPessoa"
        Me.rtbPessoa.Size = New System.Drawing.Size(270, 27)
        Me.rtbPessoa.TabIndex = 24
        Me.rtbPessoa.Text = ""
        '
        'grdContribuintes
        '
        Me.grdContribuintes.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.grdContribuintes.AllowUserToAddRows = False
        Me.grdContribuintes.AllowUserToDeleteRows = False
        Me.grdContribuintes.AllowUserToResizeColumns = False
        Me.grdContribuintes.AllowUserToResizeRows = False
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Maroon
        Me.grdContribuintes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.grdContribuintes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdContribuintes.BackgroundColor = System.Drawing.Color.White
        Me.grdContribuintes.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.grdContribuintes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdContribuintes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.grdContribuintes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdContribuintes.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdContribuintes.DefaultCellStyle = DataGridViewCellStyle6
        Me.grdContribuintes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.grdContribuintes.EnableHeadersVisualStyles = False
        Me.grdContribuintes.GridColor = System.Drawing.Color.Maroon
        Me.grdContribuintes.Location = New System.Drawing.Point(22, 62)
        Me.grdContribuintes.Margin = New System.Windows.Forms.Padding(2)
        Me.grdContribuintes.MultiSelect = False
        Me.grdContribuintes.Name = "grdContribuintes"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdContribuintes.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.grdContribuintes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.grdContribuintes.RowTemplate.Height = 24
        Me.grdContribuintes.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdContribuintes.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.grdContribuintes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdContribuintes.ShowCellErrors = False
        Me.grdContribuintes.ShowCellToolTips = False
        Me.grdContribuintes.ShowEditingIcon = False
        Me.grdContribuintes.ShowRowErrors = False
        Me.grdContribuintes.Size = New System.Drawing.Size(414, 161)
        Me.grdContribuintes.TabIndex = 15
        '
        'btnMatricula
        '
        Me.btnMatricula.Location = New System.Drawing.Point(156, 17)
        Me.btnMatricula.Margin = New System.Windows.Forms.Padding(2)
        Me.btnMatricula.Name = "btnMatricula"
        Me.btnMatricula.Size = New System.Drawing.Size(95, 21)
        Me.btnMatricula.TabIndex = 14
        Me.btnMatricula.Text = "Carregar Dados"
        Me.btnMatricula.UseVisualStyleBackColor = True
        '
        'lblMatricula
        '
        Me.lblMatricula.AutoSize = True
        Me.lblMatricula.Location = New System.Drawing.Point(5, 20)
        Me.lblMatricula.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblMatricula.Name = "lblMatricula"
        Me.lblMatricula.Size = New System.Drawing.Size(53, 13)
        Me.lblMatricula.TabIndex = 13
        Me.lblMatricula.Text = "Matricula:"
        '
        'txtMatricula
        '
        Me.txtMatricula.Location = New System.Drawing.Point(62, 19)
        Me.txtMatricula.Margin = New System.Windows.Forms.Padding(2)
        Me.txtMatricula.Name = "txtMatricula"
        Me.txtMatricula.Size = New System.Drawing.Size(91, 20)
        Me.txtMatricula.TabIndex = 12
        '
        'grpStatus
        '
        Me.grpStatus.BackColor = System.Drawing.SystemColors.Control
        Me.grpStatus.Controls.Add(Me.Panel1)
        Me.grpStatus.Controls.Add(Me.LogList)
        Me.grpStatus.ForeColor = System.Drawing.Color.Maroon
        Me.grpStatus.Location = New System.Drawing.Point(13, 365)
        Me.grpStatus.Margin = New System.Windows.Forms.Padding(2)
        Me.grpStatus.Name = "grpStatus"
        Me.grpStatus.Padding = New System.Windows.Forms.Padding(2)
        Me.grpStatus.Size = New System.Drawing.Size(538, 85)
        Me.grpStatus.TabIndex = 16
        Me.grpStatus.TabStop = False
        Me.grpStatus.Text = "Log do Leitor Digital"
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(338, 102)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(106, 33)
        Me.Panel1.TabIndex = 9
        '
        'LogList
        '
        Me.LogList.Location = New System.Drawing.Point(9, 17)
        Me.LogList.Margin = New System.Windows.Forms.Padding(2)
        Me.LogList.Name = "LogList"
        Me.LogList.ScrollAlwaysVisible = True
        Me.LogList.Size = New System.Drawing.Size(515, 56)
        Me.LogList.TabIndex = 8
        '
        'AxGrFingerXCtrl1
        '
        Me.AxGrFingerXCtrl1.Enabled = True
        Me.AxGrFingerXCtrl1.Location = New System.Drawing.Point(494, 0)
        Me.AxGrFingerXCtrl1.Margin = New System.Windows.Forms.Padding(2)
        Me.AxGrFingerXCtrl1.Name = "AxGrFingerXCtrl1"
        Me.AxGrFingerXCtrl1.OcxState = CType(resources.GetObject("AxGrFingerXCtrl1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxGrFingerXCtrl1.Size = New System.Drawing.Size(32, 32)
        Me.AxGrFingerXCtrl1.TabIndex = 23
        '
        'grpSenhaConfirmacao
        '
        Me.grpSenhaConfirmacao.BackColor = System.Drawing.Color.Yellow
        Me.grpSenhaConfirmacao.Controls.Add(Me.btnValidaSenhaConfirmacao)
        Me.grpSenhaConfirmacao.Controls.Add(Me.mskSenhaConfirmacao)
        Me.grpSenhaConfirmacao.Location = New System.Drawing.Point(207, 322)
        Me.grpSenhaConfirmacao.Margin = New System.Windows.Forms.Padding(2)
        Me.grpSenhaConfirmacao.Name = "grpSenhaConfirmacao"
        Me.grpSenhaConfirmacao.Padding = New System.Windows.Forms.Padding(2)
        Me.grpSenhaConfirmacao.Size = New System.Drawing.Size(176, 49)
        Me.grpSenhaConfirmacao.TabIndex = 37
        Me.grpSenhaConfirmacao.TabStop = False
        Me.grpSenhaConfirmacao.Text = "Confirmação de Senha "
        Me.grpSenhaConfirmacao.Visible = False
        '
        'btnValidaSenhaConfirmacao
        '
        Me.btnValidaSenhaConfirmacao.Font = New System.Drawing.Font("Tahoma", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnValidaSenhaConfirmacao.Location = New System.Drawing.Point(135, 20)
        Me.btnValidaSenhaConfirmacao.Margin = New System.Windows.Forms.Padding(2)
        Me.btnValidaSenhaConfirmacao.Name = "btnValidaSenhaConfirmacao"
        Me.btnValidaSenhaConfirmacao.Size = New System.Drawing.Size(25, 20)
        Me.btnValidaSenhaConfirmacao.TabIndex = 9
        Me.btnValidaSenhaConfirmacao.Text = "ok"
        '
        'mskSenhaConfirmacao
        '
        Me.mskSenhaConfirmacao.Location = New System.Drawing.Point(17, 20)
        Me.mskSenhaConfirmacao.Name = "mskSenhaConfirmacao"
        Me.mskSenhaConfirmacao.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.mskSenhaConfirmacao.Size = New System.Drawing.Size(116, 20)
        Me.mskSenhaConfirmacao.TabIndex = 7
        '
        '
        'frmApoio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.ClientSize = New System.Drawing.Size(559, 462)
        Me.Controls.Add(Me.grpSenhaConfirmacao)
        Me.Controls.Add(Me.AxGrFingerXCtrl1)
        Me.Controls.Add(Me.grpIdentificação)
        Me.Controls.Add(Me.grpDigital)
        Me.Controls.Add(Me.grpStatus)
        Me.ForeColor = System.Drawing.Color.Maroon
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.Name = "frmApoio"
        Me.Tag = ""
        Me.Text = "Biosifam"
        Me.grpDigital.ResumeLayout(False)
        Me.grpSenha.ResumeLayout(False)
        Me.grpSenha.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBiometria.ResumeLayout(False)
        CType(Me.picMain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdIdentifica, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpIdentificação.ResumeLayout(False)
        Me.grpIdentificação.PerformLayout()
        CType(Me.grdContribuintes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpStatus.ResumeLayout(False)
        CType(Me.AxGrFingerXCtrl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSenhaConfirmacao.ResumeLayout(False)
        Me.grpSenhaConfirmacao.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim strSQL As String
    Public drDigitais As System.Data.Odbc.OdbcDataReader
    Public drProcedimentos_AMB As System.Data.Odbc.OdbcDataReader
    Public drGeneric As System.Data.Odbc.OdbcDataReader

    Dim OptionsForm1 As New OptionsForm

    Public _util As New clsUtil
    Public _toolsSiFam As clsSiFam

    Public vsIPLocal As String = ""
    Public idSelecionado As Long, idDigital As Long
    Public NomeSelecionado As String, vsEmailPaciente As String
    Public vbUsuarioSuporte As Boolean = False

    Dim NascimentoSelecionado As Date
    Dim Selecionado_Sexo As String
    Dim vbIdadeFertil As Boolean

    Dim vbPassou As Boolean
    Dim vbFirst As Boolean = True
    Dim vsSenhaDaPessoaNoBanco As String
    Dim vsSenhaDaPessoa_Data As Date
    Dim vbSenhaValidada As Boolean

    Dim vnContaDigitalRuim As Integer
    Dim vnContaDigitalNaoIdentificada As Integer
    Dim vsSenha As String
    Dim vbIdentificouDigital As Boolean = False
    Dim vnConsultasMedicasRealizadas As Integer
    Dim vnConsultasOdontologicasRealizadas As Integer
    Dim vnBonusUtilizados As Integer
    Dim vnExcedenteUtilizados As Integer
    Dim vbMenor12 As Boolean

    'variaveis para o relatórios consultas
    Dim vdData As Date, vdDataFim As Date
    Dim vsFiltro As String = "", vsRetorno As String = "", vsFiltroTexto As String = "", idMedico As Integer, vsMedico As String
    Dim drContribuinte As System.Data.Odbc.OdbcDataReader
    Dim vbModoOFFLine As Boolean = False, vsLicençaGriaule As String

    Dim toolTip1 As New ToolTip()
    Dim toolTip2 As New ToolTip()
    Dim toolTip3 As New ToolTip()
    Dim vnModeloRelatorio As Integer    '0-digital, 1-consulta, 2-exame
    Dim vtTempoConexao As TimeSpan, vdInicioConexao As DateTime, vbEncerrar As Boolean, vnPosicaoMouse As Long
    Dim vnContribuinte As Long = 0
    Dim vbPacoteAberto As Boolean = False
    Dim vbSelecionouMedico As Boolean = False
    Dim oVerificaNovaVersãoAplicativo As New cUpdate

    Private Sub frmMain_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        vsGlo_frmAtivo = Me.Text
        ' frmLogin.Activate()
    End Sub

    Private Sub frmMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        On Error Resume Next
        _toolsSiFam.FinalizeGrFinger()
        Application.Exit()
        End
    End Sub

    Private Sub frmMain_KeyDown(ByVal sender As Object, ByVal EventArgs As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Dim KeyCode As Short = EventArgs.KeyCode
        ' teclou ENTER põe o foco no próximo controle 
        If KeyCode = System.Windows.Forms.Keys.Return Then System.Windows.Forms.SendKeys.Send("{TAB}") ' + é{tab} o shit
    End Sub

    Public Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ConfiguraForm()
        Left = (Screen.PrimaryScreen.Bounds.Width - Width) / 2   ' Center form horizontally.
        Top = (Screen.PrimaryScreen.Bounds.Height - Height) / 2  ' Center form vertically.

        Call oVerificaNovaVersãoAplicativo.VerificaNovaVersão(False, idMedico, idSelecionado)

        vnPosicaoMouse = MousePosition.X
        vdInicioConexao = Now

    End Sub

    Public Sub ConfiguraForm()
        Me.Text = Application.ProductName.ToString & " Versão " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build
        If _banco.Conecta() = False Then End

        InicializaBotaoGravar()

        _banco.Desconecta()
    End Sub

    Private Sub ClearLogButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LogList.Items.Clear()
    End Sub

    Private Sub btnMatricula_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMatricula.Click
        ' inicializa controles do relatório ============================================
       
        If txtMatricula.Text = "" Then MsgBox("A matrícula deve conter um valor !") : Exit Sub
        Dim ds As DataSet

        'data nascimento limite para 24 anos, deixa de ser dependente
        Dim vd_datanascimento24anos As Date
        ' vd_datanascimento24anos = Date.Today - 24  - filhos maiores de 24 anos nao podem mais fazer consultas
        vd_datanascimento24anos = DateTime.Now.AddYears(-24)
        If _banco.Conecta() = False Then Exit Sub
        ds = _banco.obtemDados("pessoas inner join tipo_usuario on id_tipo_usuario=id_tipo ", "id_pessoa as Codigo, nome as Nome, descricao as Tipo, senha as Senha, dt_nascimento as Data_Nascimento, sexo as Sexo ", "matricula = '" & txtMatricula.Text & "' and situacao='A' and ((dt_nascimento > '" & Format(vd_datanascimento24anos.Date, "yyyy/MM/dd") & "' and id_tipo=4) or id_tipo<>4)")
        'ds = _banco.obtemDados("pessoas inner join tipo_usuario on id_tipo_usuario=id_tipo ", "id_pessoa as Codigo, nome as Nome, descricao as Tipo, senha as Senha ", "matricula = '" & txtMatricula.Text & "'")
        grdContribuintes.DataSource = ds.Tables(0)

        'grdContribuintes.Columns(4).Visible = False
        grdContribuintes.Columns(3).Visible = False
        grdContribuintes.Width = 495

        grdContribuintes.Columns(0).Width = 50
        grdContribuintes.Columns(1).Width = 220
        grdContribuintes.Columns(2).Width = 90
        grdContribuintes.Columns(4).Width = 80
        grdContribuintes.Columns(5).Width = 40

        grpIdentificação.Height = 300
        grpDigital.Visible = False

        vnConsultasMedicasRealizadas = 0
        vnConsultasOdontologicasRealizadas = 0
        vnExcedenteUtilizados = 0
        vnBonusUtilizados = 0

        If vbFirst = True Then
            vbFirst = False
            Dim err As Integer
            ' initialize util class
            _toolsSiFam = New clsSiFam(LogList, picMain, AxGrFingerXCtrl1)

            ' Initialize GrFingerX Library
            err = _toolsSiFam.InitializeGrFinger()
            ' Print result in log
            If err < 0 Then
                _toolsSiFam.ErroGriaule(err)
                Exit Sub
            Else
                _toolsSiFam.WriteLog("**GrFingerX Inicializado com Sucesso**")
            End If
        End If

        InicializaBotoes()
        _banco.Desconecta()
    End Sub

    Private Sub InicializaBotaoGravar()
        If frmSetup.vsModo = "0" Then
            btnGravar.Text = "Gravar Biometria"
        ElseIf frmSetup.vsModo = "1" Then
            btnGravar.Visible = False
            btnGravar.Text = ""
        ElseIf frmSetup.vsModo = "3" Then
            btnGravar.Text = "Gravar EXAME"
        Else
            btnGravar.Text = "Gravar Consulta"
        End If

    End Sub

    Private Sub InicializaBotoes()
        InicializaBotaoGravar()
        lblSenha.Visible = False
        rtbApoio.Text = ""
        rtbPessoa.Text = ""
        vnGlo_IdPessoa = 0 : idDigital = 0
        grdIdentifica.DataSource = Nothing
        btnGravar.Enabled = False
        WebBrowser1.Visible = False
        LogList.Items.Clear()
        vsSenhaDaPessoaNoBanco = ""
        vbIdentificouDigital = False
        btnValidaSenha.Enabled = True
        grpSenha.Visible = False
        mskSenha.Text = ""
        vbSenhaValidada = False
        vnContribuinte = 0
        vbPacoteAberto = False
        ' Initialize GrFingerX Library
        ' _toolsSiFam.InitializeGrFinger()

    End Sub

    Private Sub grdContribuintes_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdContribuintes.CellDoubleClick
        idSelecionado = grdContribuintes.CurrentRow.Cells(0).Value()
        NomeSelecionado = grdContribuintes.CurrentRow.Cells(1).Value()
        vsSenhaDaPessoaNoBanco = grdContribuintes.CurrentRow.Cells(3).Value()
        NascimentoSelecionado = grdContribuintes.CurrentRow.Cells(4).Value()
        Selecionado_Sexo = grdContribuintes.CurrentRow.Cells(5).Value()
        If Int(DateDiff("d", grdContribuintes.CurrentRow.Cells(4).Value, Date.Today) / 365) < 12 Then vbMenor12 = True Else vbMenor12 = False
        If Int(DateDiff("d", grdContribuintes.CurrentRow.Cells(4).Value, Date.Today) / 365) > 12 And _
           Int(DateDiff("d", grdContribuintes.CurrentRow.Cells(4).Value, Date.Today) / 365) < 50 Then vbIdadeFertil = True Else vbIdadeFertil = False
        CarregaIdentificador(idSelecionado, NomeSelecionado)
        vnContaDigitalRuim = 0
        vnContaDigitalNaoIdentificada = 0

    End Sub

    Private Sub CarregaIdentificador(ByVal idSelecionado As Long, ByVal NomeSelecionado As String)
        vnGlo_IdPessoa = 0
        vbPassou = True
        LogList.Items.Clear()
        If _banco.Conecta() = False Then Exit Sub
        Try
            vnGlo_IdPessoa = idSelecionado
            grpDigital.Visible = True
            grpIdentificação.Height = 53
            rtbApoio.Text = "Identificador: " & idSelecionado & Chr(13)
            rtbPessoa.Text = "Nome: " & NomeSelecionado & Chr(13)
            WebBrowser1.Visible = True
            Dim vbUsaDigital As Boolean = False

            lblSenha.Visible = False
            lblSituacao.Text = "aguardando..."

            drDigitais = _banco.drQuery("SELECT * FROM digital WHERE id_pessoa=" & vnGlo_IdPessoa)
            If drDigitais.HasRows Then

                drDigitais.Read()
                If _toolsSiFam.raw.height > 0 Then _toolsSiFam.PrintBiometricDisplay(False, GrFinger.GR_DEFAULT_CONTEXT)
                rtbApoio.Text = rtbApoio.Text & "Biometrias existentes: " & drDigitais.RecordsAffected & Chr(13)     'dr.Item(2)
                vbUsaDigital = True
            Else
                'se for menor libera uso da senha
                'se nao for menor, so libera uso da senha pelo método de 3 tentativas
                If vbMenor12 = False And vsSenhaDaPessoaNoBanco = "" Then
                    If frmSetup.vsModo = "1" Or frmSetup.vsModo = "2" Then
                        MsgBox("Matricula não possui digital nem senha. Dirija-se a PREVPEL para realizar o cadastro.")
                        Exit Sub
                    End If
                    ' se passar é para informar a digital na retaguarda
                    vbUsaDigital = True
                End If
            End If

            ' nao vai utilizae digital
            If vbUsaDigital = False Or vbModoOFFLine Then
                btnGravar.Enabled = True
                If vbMenor12 = True Then
                    'se é menor, vou ter de verificar se senha informada pertence a 'algum' dos Respon'sáveis (matricula)
                    'então não vou verificar a senha agora e sim apos recebela, dai 
                    'verifico se ela é compativel com alguns dos 'outros' da matricula

                    'se é menor e nao tem digital, vou ter de verificar se algum' dos Respon'sáveis (matricula) tem digital
                    'então vou verificar se há digital, se houver testamos lá no final
                    drDigitais = _banco.drQuery("SELECT binario FROM pessoas, digital WHERE matricula='" & txtMatricula.Text & "' and digital.id_pessoa=pessoas.id_pessoa")
                    If drDigitais.HasRows Then
                        While drDigitais.Read()
                            If drDigitais.Item(0).ToString <> "" Then
                                vbUsaDigital = True
                                lblSenha.Visible = False
                            End If
                        End While
                    End If
                Else
                    _toolsSiFam.FinalizeGrFinger()
                    If vbModoOFFLine Then GroupBiometria.Visible = False Else GroupBiometria.Visible = True
                    If vbModoOFFLine Then GoTo PulouSenha
                    lblSenha.Visible = True

                    'carrega senha e verificar se expirou
                    Dim dr As System.Data.Odbc.OdbcDataReader
                    dr = _banco.drQuery("SELECT senha, senha_data FROM pessoas where id_pessoa=" & vnGlo_IdPessoa)
                    vsSenhaDaPessoaNoBanco = ""
                    vsSenhaDaPessoa_Data = vbNullString

                    If dr.HasRows Then vsSenhaDaPessoaNoBanco = dr.Item(0)
                    If vsSenhaDaPessoaNoBanco <> "" Then
                        If dr.Item(1).ToString <> "" Then
                            vsSenhaDaPessoa_Data = dr.Item(1).ToString
                            If Int(DateDiff("d", vsSenhaDaPessoa_Data, Date.Today)) > 180 Then
                                MsgBox("A senha expirou a mais de 180 dias (" & vsSenhaDaPessoa_Data & ") e precisa ser revalidada.")
                                If frmSetup.vsModo = "1" Then
                                    MsgBox("A revalidação precisa ser realizada na PREVPEL.")
                                    grpSenha.Visible = False
                                Else
                                    btnGravar.Text = "Nova Senha"
                                    grpSenha.Visible = True
                                    mskSenha.Focus()
                                End If
                                Exit Sub
                            End If
                        Else
                            'atualiza data para forçar expiração da senha
                            _banco.executaQuery("update pessoas set senha_data=current_date where id_pessoa=" & vnGlo_IdPessoa)
                        End If
                    End If

                End If

                'vai usar identificacao por senha - ultima modificação 29/09/2014
                If (frmSetup.vsModo = "1" Or frmSetup.vsModo = "2" Or frmSetup.vsModo = "4") And vbUsaDigital = False Then
                    grpSenha.Visible = True
                    mskSenha.Focus()
                    'Exit Sub
                ElseIf frmSetup.vsModo = "0" Then
                    'RETAGUARDA
                    btnGravar.Text = "Nova Senha"
                     lblSituacao.Text = "Desativado"
                End If
            Else
                _toolsSiFam.InitializeGrFinger()
            End If

PulouSenha:
            vnConsultasOdontologicasRealizadas = _banco.obtemQueryCount(_toolsSiFam.obtemConsultas(txtMatricula.Text, "O"))
            vnConsultasMedicasRealizadas = _banco.obtemQueryCount(_toolsSiFam.obtemConsultas(txtMatricula.Text, "M"))
            vnBonusUtilizados = _banco.obtemQueryCount(_toolsSiFam.obtemBonus(txtMatricula.Text))
            vnExcedenteUtilizados = _banco.obtemQueryCount(_toolsSiFam.obtemExcedente(txtMatricula.Text))

            If vnConsultasMedicasRealizadas > 0 Then rtbApoio.Text = rtbApoio.Text & "Consultas Médicas realizadas : " & vnConsultasMedicasRealizadas & Chr(13)
            If vnConsultasOdontologicasRealizadas > 0 Then rtbApoio.Text = rtbApoio.Text & "Consultas Odontológicas realizadas : " & vnConsultasOdontologicasRealizadas & Chr(13)
            If vnBonusUtilizados > 0 Then rtbApoio.Text = rtbApoio.Text & "Bônus utilizados : " & vnBonusUtilizados & Chr(13)
            If vnExcedenteUtilizados > 0 Then rtbApoio.Text = rtbApoio.Text & "Excedentes utilizados: " & vnExcedenteUtilizados & Chr(13)
            If vnConsultasMedicasRealizadas = 0 And vnConsultasOdontologicasRealizadas = 0 And vnBonusUtilizados = 0 And vnExcedenteUtilizados = 0 Then rtbApoio.Text = rtbApoio.Text & "Nenhuma consulta nos últimos 30 dias." & Chr(13)

            WebBrowser1.Navigate("http:\\server.pelotas.com.br\xxx\sifam\foto_pessoa.php?id_pessoa=" & vnGlo_IdPessoa, False)

        Catch ex As Exception
            MsgBox("Name cannot be resolved. Error: " + ex.Message)
        End Try
        _banco.Desconecta()
    End Sub

    Private Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
        Dim id As Integer
        If _banco.Conecta() = False Then Exit Sub
        drContribuinte = _banco.drQuery("SELECT id_pessoa as Codigo, nome as Nome FROM pessoas WHERE id_tipo_usuario=2 and matricula = '" & txtMatricula.Text & "'")
        If drContribuinte.HasRows Then
            drContribuinte.Read()
            vnContribuinte = drContribuinte.Item(0)
        Else
            MsgBox(" Contribuinte não foi localizado !", MsgBoxStyle.Information, "Impossível gravar consulta")
            GoTo Fim_Bloco
        End If

        If frmSetup.vsModo = "2" Or frmSetup.vsModo = "4" Then
            If lblSenha.Visible = True Then

                If grpSenha.Visible = False And vbSenhaValidada = False Then
                    grpSenha.Visible = True
                    mskSenha.Focus()
                    GoTo Fim_Bloco
                End If

                If vbSenhaValidada = False Then   'mskSenha.Text <> vsSenhaDaPessoaNoBanco Then
                    MsgBox("Senha informada não confere !")
                    grpSenha.Visible = True
                    GoTo Fim_Bloco
                End If
                grpSenha.Visible = False
            Else
                If vbIdentificouDigital = False And vbModoOFFLine = False And vbSenhaValidada = False Then
                    MsgBox("Digital não foi identificada, Por Favor, informe-a novamente.")
                    GoTo Fim_Bloco
                End If
            End If

        
            'verifica limitação nas consultas mensais
            Dim vsTipoConsulta As String = frmSetup.vsTipo
            Dim vsTipoExcedente As String = "N"
            Dim drGeneric As System.Data.Odbc.OdbcDataReader
            Dim vbPossivelGravida As Boolean = False
            Dim vbGravidaAutorizada As Boolean = False
            Dim vsDataDigitaçãoOFFLine As String = "", vdDataServidor As Date, vbLiberaDigitacao As Boolean
PegaData:
            If vbModoOFFLine Then
                drGeneric = _banco.drQuery("select current_date, libera_digitacao from medicos where id_medicos=" & idMedico)
                If drGeneric.HasRows Then
                    drGeneric.Read()
                    vdDataServidor = Format(drGeneric.Item(0), "dd/MM/yyyy")
                    vbLiberaDigitacao = drGeneric.Item(1)
                End If

                vsDataDigitaçãoOFFLine = InputBox("Informe a data de realização da consulta:", "Modo OFF-Line de registro", Format(Now, "dd/MM/yyyy"))
                If vsDataDigitaçãoOFFLine = "" Then GoTo Fim_Bloco
                If Not IsDate(vsDataDigitaçãoOFFLine) Then
                    MsgBox(" Data Invalida, por favor informe uma data no formato dd/mm/yyyy ", vbCritical, " Data inválida ")
                    GoTo pegadata
                End If
                If CDate(vsDataDigitaçãoOFFLine).AddDays(5) < vdDataServidor Then
                    If vbLiberaDigitacao = False Then
                        MsgBox("Você só tem permissão para digitar datas retroativas até 5 dias. Caso seja necessário ultrapassar este limite, solicite à PREVPEL autorização para o procedimento.", vbCritical, " Data inválida ")
                        GoTo pegadata
                    End If
                End If

                If vnContaDigitalRuim < 5 Then
                    ' se digital ruim > = 5 entao passa direto e libera digitação
                    ' controle de digitais não identificadas é diferente de ruins
                    drGeneric = _banco.drQuery("SELECT biometrias_invalidas FROM pessoas WHERE matricula = '" & txtMatricula.Text & "'")
                    If drGeneric.HasRows Then
                        drGeneric.Read()
                        If vdDataServidor = vsDataDigitaçãoOFFLine Then
                            If drGeneric.Item(0).ToString <> "" Then
                                If drGeneric.Item(0) <> vdDataServidor Then
                                    ' se no mesmo dia nao tiver 5 tentativas nao liberar
                                    MsgBox("O modo OFF-Line só é permitido após 5 tentativas inválidas e essa situação não ocorre ainda hoje.")
                                    GoTo Fim_Bloco
                                End If
                            Else
                                MsgBox("O modo OFF-Line só é permitido após 5 tentativas inválidas e essa situação não ocorre ainda hoje.")
                                GoTo Fim_Bloco
                            End If
                        End If
                    End If
                End If
            End If

            Dim drEspecialidade As System.Data.Odbc.OdbcDataReader, idEspecialidade As Integer = 0
            drEspecialidade = _banco.drQuery("select id_especialidades from medicos where id_medicos=" & idMedico)
            If drEspecialidade.HasRows Then
                drEspecialidade.Read()
                idEspecialidade = drEspecialidade.Item(0)
            End If

            If frmSetup.vsTipo = "M" Then
                ' desvio especial para gestantes
                ' se é mulher, se idade > 12 and < 50, e médico é Ginecologista =id=13
                If Selecionado_Sexo = "F" And vbIdadeFertil And idEspecialidade = 13 Then vbPossivelGravida = True
                ' coloquei o if abaixo dentro do i superior "M"  29/05/2015
                If vnConsultasMedicasRealizadas >= 3 Then
                    If vbPossivelGravida Then
                        If MsgBox(" Esta é uma consulta de Gestante de último mês ? e você deseja mesmo autorizar a consulta EXTRA sem custo ao paciente  ?", vbYesNo, "O sistema identificou uma possível Gestante com Limite de consultas excedido !") = vbNo Then
                            If vnBonusUtilizados >= 5 Then
                                ' estourou o limite de consultas e bonus
                                If MsgBox("O número de consultas nos últimos 30 dias já atingiu o limite(3), os todos os bônus já foram utilizados. Deseja mesmo assim realizar uma consulta EXTRA (paga) ?", vbYesNo, "Limite de Consultas atingido !") = vbNo Then
                                    GoTo Fim_Bloco
                                Else
                                    vsTipoExcedente = "S"
                                End If
                            Else
                                If MsgBox("O número de consultas médicas nos últimos 30 dias já atingiu o limite(3), deseja utilizar seus bônus ?", vbYesNo, "Limite de Consultas atingido !") = vbNo Then
                                    GoTo Fim_Bloco
                                Else
                                    vsTipoConsulta = "B"
                                End If
                            End If
                        Else
                            vbGravidaAutorizada = True
                        End If
                    Else
                        If vnBonusUtilizados >= 5 Then
                            ' estourou o limite de consultas e bonus
                            If MsgBox("O número de consultas nos últimos 30 dias já atingiu o limite(3), os todos os bônus já foram utilizados. Deseja mesmo assim realizar uma consulta EXTRA (paga) ?", vbYesNo, "Limite de Consultas atingido !") = vbNo Then
                                GoTo Fim_Bloco
                            Else
                                vsTipoExcedente = "S"
                            End If
                        Else
                            If MsgBox("O número de consultas médicas nos últimos 30 dias já atingiu o limite(3), deseja utilizar seus bônus ?", vbYesNo, "Limite de Consultas atingido !") = vbNo Then
                                If MsgBox("Deseja realizar uma consulta EXTRA (paga) ?", vbYesNo, "Limite de Consultas atingido !") = vbNo Then
                                    GoTo Fim_Bloco
                                Else
                                    vsTipoExcedente = "S"
                                End If
                            Else
                                vsTipoConsulta = "B"
                            End If
                        End If
                    End If
                End If
            End If


            If vsGlo_UsuarioId = "" Then vsGlo_UsuarioId = idMedico
            If vsIPLocal = "" Then vsIPLocal = "no-ip"

            ' id_requisitante=pessoa que fez a consulta, id_pessoa é o titular
            drGeneric = _banco.drQuery("select count(id_consulta) from consulta where id_requisitante=" & vnGlo_IdPessoa & " and dt_alteracao=CURRENT_DATE and id_medicos=" & idMedico)
            If drGeneric.HasRows Then
                drGeneric.Read()
                If drGeneric.Item(0) > 0 Then
                    MsgBox("O paciente já realizou consulta Hoje !", vbInformation, "Impossível registrar nova consulta!")
                    GoTo Fim_Bloco
                End If
            End If

            ' Vai gravar RETORNO, sempre precisa VALOR
            Dim vnValorConsulta As Decimal
            'ver valor da consulta
            Dim drMedico As System.Data.Odbc.OdbcDataReader
            drMedico = _banco.drQuery("SELECT v.consulta_med, v.consulta_odo, trim(m.categoria), id_especialidades from medicos as m, valores as v where m.id_medicos =" & idMedico)
            If drMedico.HasRows Then
                If drMedico.Item(2) <> "O" Then vnValorConsulta = drMedico.Item(0) Else vnValorConsulta = drMedico.Item(1)
            Else
                ' vai salvar mesmo sem valor, nao pode ficar sem retorno
                vnValorConsulta = 0
                'MsgBox("Valor da consulta não encontrado, Por favor, informe este erro ao suporte técnico. A finalização desta consulta NÃO será gravada.")
            End If

            Dim vnPrazo As Integer = 15
            If frmSetup.vsTipo = "M" Or idEspecialidade = 42 Then    ' id_especialidades = 42 - bucomaxilo - geralmente dentistas
                ' id_requisitante=pessoa que fez a consulta, id_pessoa é o titular
                If drMedico.Item("id_especialidades") = 18 Then vnPrazo = 30 ' Nutrição
                drGeneric = _banco.drQuery("select count(id_consulta) from consulta where id_requisitante=" & vnGlo_IdPessoa & " and dt_alteracao>=CURRENT_DATE-" & vnPrazo & " and id_medicos=" & idMedico)
                If drGeneric.HasRows Then
                    drGeneric.Read()
                    If drGeneric.Item(0) > 0 Then
                        If vbPossivelGravida And vbGravidaAutorizada = False Then
                            If MsgBox(" Esta é uma consulta de Gestante de último mês ? e você deseja mesmo autorizar a consulta EXTRA sem custo ao paciente  ?", vbYesNo, "O sistema identificou uma possível Gestante com Limite 15 dias excedido !") = vbYes Then
                                vbGravidaAutorizada = True
                            End If
                        Else
                            MsgBox("O paciente já realizou consulta nos últimos " & vnPrazo & " dias !", vbInformation, "Impossível registrar nova consulta!")
                            GoTo Fim_Bloco
                        End If
                    End If
                End If
            End If

            If vbUsuarioSuporte Then
                ' desvio para usuario de suporte e manutenção
                If MsgBox("Deseja realmente gravar a consulta para este paciente ?", MsgBoxStyle.YesNo, "Confirme a operação de gravação.") = vbNo Then
                    GoTo Fim_Bloco
                End If
            End If

            Dim vsDataConsulta As String = "CURRENT_DATE"
            If vbModoOFFLine Then vsDataConsulta = "'" & Format(CDate(vsDataDigitaçãoOFFLine), "yyyy/MM/dd") & "'"

            _banco.executaQuery("begin")

            'id_pessoa é o código do contribuinte tipo_usuario=2 - rContribuinte.Item(0) - rContribuinte.Item(1) 
            'requisitante e id_requisitante é a pessoa que está consultando - (idSelecionado,vnGlo_IdPessoa) / NomeSelecionado 
            _banco.executaQuery("INSERT INTO consulta (id_pessoa, id_medicos, requisitante," & _
            "tipo_consulta, cancelado, login, ip, dt_alteracao, hr_alteracao, excedente, id_requisitante, aux) " & _
            " VALUES ( " & vnContribuinte & ", " & idMedico & ", '" & NomeSelecionado & "', '" & vsTipoConsulta & "', 'N', '" & vsGlo_UsuarioId & "', '" & vsIPLocal & _
            "'," & vsDataConsulta & ", '" & Date.Now.ToShortTimeString() & " ', '" & vsTipoExcedente & "'," & vnGlo_IdPessoa & ",1);")

            'update consulta set id_pessoa=id_requisitante, id_requisitante=pessoa.id_pessoa, requisitante=pessoa.nome
            'where id_requisitante in (select id_pessoa, nome from pessoas where id_pessoa=consulta.id_requisitante and tipo_usuario <>2)
            'dt_alteracao > '2012/08/01' and ip <>'201.3.160.198' and id_pessoa<>id_requisitante

            Dim drMax As System.Data.Odbc.OdbcDataReader, vnId As Long
            drMax = _banco.drQuery("select max(id_consulta) from consulta")
            If drMax.HasRows Then vnId = drMax.Item(0)

            If vbPossivelGravida And vbGravidaAutorizada And vnId > 0 Then
                'vai permitir identifica se a consulta foi liberada ou nao pelo operador
                _banco.executaQuery("INSERT INTO consulta_gravida (id_consulta) VALUES ( " & vnId & ");")
            End If

            'Grava retorno da consulta
            _banco.executaQuery("INSERT INTO consulta_retorno (id_consulta_origem, valor, data, login, ip, dt_alteracao, hr_alteracao) " & _
            " VALUES ( " & vnId & ", " & Replace(vnValorConsulta.ToString, ",", ".") & ",  CURRENT_DATE , '" & vsGlo_UsuarioId & "', '" & vsIPLocal & "'," & vsDataConsulta & ", '" & Date.Now.ToShortTimeString() & "')")

            _banco.executaQuery("commit")

            If lblSenha.Visible = True Then
                _banco.LogValidacao("biosifam_ValidacaoSenha", "Consulta registrada por Senha", False, vnId, idMedico)
            Else
                If vbModoOFFLine Then
                    _banco.LogValidacao("biosifam_erro7", "Consulta registrada off-line", False, idSelecionado, idMedico)
                Else
                    _banco.LogValidacao("biosifam_ValidacaoBiometrica", "Consulta registrada por Biometria", False, vnId, idMedico)
                End If
            End If

            ' envia email aqui... - paciente ainda nao tem emnail no cadastro
            ' SiacksMail(vsEmailPaciente, "Consulta PREVPEL", "Confirmação de registro de consulta, N." & vnId, "", "", "SIM", "SIM")            

            MsgBox("Consulta gravada com Sucesso. Identificador N. " & vnId)

        ElseIf frmSetup.vsModo = "3" Then ' modo exame

            If lblSenha.Visible = True Then
                If grpSenha.Visible = False Then
                    grpSenha.Visible = True
                    mskSenha.Focus()
                    GoTo Fim_Bloco
                End If
                If vbSenhaValidada = False Then ' mskSenha.Text <> vsSenhaDaPessoaNoBanco Then
                    MsgBox("Senha informada não confere !")
                    grpSenha.Visible = True
                    GoTo Fim_Bloco
                End If
                grpSenha.Visible = False
            Else
                If vbIdentificouDigital = False Then
                    MsgBox("Digital não foi identificada, Por Favor, informe-a novamente.")
                    GoTo Fim_Bloco
                End If
            End If

            Dim drMax As System.Data.Odbc.OdbcDataReader, vnId As Long
            drMax = _banco.drQuery("select max(id_consulta) from consulta")
            If drMax.HasRows Then vnId = drMax.Item(0)

            _banco.executaQuery("commit")

            MsgBox("Exame gravado com Sucesso. Identificador N. " & vnId)

        Else
            If btnGravar.Text = "Gravar Senha" Then GoTo Fim_Bloco
            id = _toolsSiFam.Enroll(0, vnGlo_IdPessoa, vsGlo_UsuarioId)
            ' localizar outras matriculas da mesma pessoa
            Dim drPessoa2 As System.Data.Odbc.OdbcDataReader
            Dim id2 As Long
            drPessoa2 = _banco.drQuery("SELECT id_pessoa, nome, matricula FROM pessoas WHERE nome='" & Trim(NomeSelecionado) & "' and dt_nascimento='" & Format(NascimentoSelecionado, "yyyy/MM/dd ") & "' and id_pessoa <>" & vnGlo_IdPessoa)
            ' drPessoa2 = _banco.drQuery("SELECT id_pessoa, nome, matricula FROM pessoas WHERE nome='" & Trim(NomeSelecionado) & "' and id_pessoa <>" & vnGlo_IdPessoa)
            If drPessoa2.HasRows Then
                drPessoa2.Read()
                'gravar digital na outra matricula
                'nao vou dar mensagem , simplesmente vou gravar as duas
                'MsgBox("Encontrada outra matricula para o mesmo Contribuinte ! (N. " & Trim(drContribuinte2.Item(2)) & ")")
                id2 = _toolsSiFam.Enroll(0, drPessoa2.Item(0), vsGlo_UsuarioId)
            End If

            If id > 0 Then
                If id2 > 0 Then
                    MsgBox("Digitais gravadas com Sucesso. IDs = " & id & " e " & id2)
                Else
                    MsgBox("Digital gravada com Sucesso. ID = " & id)
                End If
                _banco.LogValidacao("biosifam_erro4", "Digital nova cadastrada com sucesso", True, idSelecionado, idMedico)

                CarregaIdentificador(idSelecionado, NomeSelecionado)
            Else
                MsgBox("Erro ao gravar digital. Digital não localizada.")
            End If

        End If
Fim_Bloco:
        _banco.Desconecta()
        btnGravar.Enabled = False
        vbModoOFFLine = False
        Me.BackColor = Color.White

    End Sub

    Private Sub VerifyButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ret As Integer
        Dim score As Integer
        Dim sid As String

        score = 0
        sid = InputBox("Digite o ID  para verificar", "Verificar", "")
        If sid <> "" Then
            ret = _toolsSiFam.Verify(_banco, Val(sid), score)
            If ret < 0 Then
                atualizaLogList(ret)
            ElseIf ret = GrFinger.GR_NOT_MATCH Then
                atualizaLogList("Não encontrada com escore = " & score)
            Else
                atualizaLogList("Encontrada com escore = " & score)
                _toolsSiFam.PrintBiometricDisplay(True, GrFinger.GR_DEFAULT_CONTEXT)
            End If
        End If
    End Sub

    Private Sub btnEncerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEncerrar.Click
        InicializaBotoes()
        txtMatricula.Text = ""
        txtMatricula.Focus()
        _toolsSiFam.FinalizeGrFinger()
        _banco.Desconecta()
        End
    End Sub


    Private Sub grdContribuintes_KeyDown(ByVal sender As Object, ByVal EventArgs As System.Windows.Forms.KeyEventArgs) Handles grdContribuintes.KeyDown
        Dim KeyCode As Short = EventArgs.KeyCode
        ' teclou ENTER põe o foco no próximo controle 
        If KeyCode = System.Windows.Forms.Keys.Return Then
            idSelecionado = grdContribuintes.CurrentRow.Cells(0).Value()
            NomeSelecionado = grdContribuintes.CurrentRow.Cells(1).Value()
            CarregaIdentificador(idSelecionado, NomeSelecionado)
        End If
    End Sub

    ' Escreve Status no list box.
    Public Sub atualizaLogList(ByVal message As String)
        LogList.Items.Add(message)
        LogList.SelectedIndex = LogList.Items.Count - 1
        LogList.ClearSelected()
        Dim _util As New clsUtil
        _util.Mensagem_LogLocal(message, False, "FormMain", True, "")
    End Sub

    Private Function IdentificaContribuinte(ByVal ret As Integer) As Boolean
        IdentificaContribuinte = False
        If _banco.Conecta() = False Then Exit Function
        Dim dr As System.Data.Odbc.OdbcDataReader
        dr = _banco.drQuery("SELECT pessoas.id_pessoa, nome, senha, matricula FROM pessoas INNER JOIN digital USING (id_pessoa) WHERE id_digital = " & ret)
        If dr.HasRows Then
            dr.Read()
            If dr.Item(0) <> vnGlo_IdPessoa Then
                'quando for menor, apenas Digitais da matricula estarão PRESENTES no select
                If vbMenor12 = True Then
                    If Trim(dr.Item(3)) = txtMatricula.Text Then
                        vsGlo_Log = "Identificado paciente com menos de 12 anos !" & Chr(13) & "Validação aceita pela Matricula: " & dr.Item(1)
                        MsgBox(vsGlo_Log)
                    Else
                        vsGlo_Log = "Digital pertence a outro paciente, " & dr.Item(1)
                        MsgBox(vsGlo_Log)
                        Exit Function
                    End If
                Else
                    vsGlo_Log = "Digital pertence a outro paciente, " & dr.Item(1)
                    MsgBox(vsGlo_Log)
                    Exit Function
                End If
            End If
        End If
        IdentificaContribuinte = True
        _banco.Desconecta()
    End Function


    ' -----------------------------------------------------------------------------------
    ' GrFingerX events
    ' -----------------------------------------------------------------------------------
    ' A fingerprint reader was plugged on system
    Private Sub AxGrFingerXCtrl1_SensorPlug(ByVal sender As System.Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_SensorPlugEvent) Handles AxGrFingerXCtrl1.SensorPlug
        _toolsSiFam.WriteLog("Sensor: " & e.idSensor & ". Evento: Conectado.")
        AxGrFingerXCtrl1.CapStartCapture(e.idSensor)
        lblSituacao.BackColor = Color.Green
        lblSituacao.ForeColor = Color.White
        lblSituacao.Text = "aguardando..."
    End Sub

    ' A fingerprint reader was unplugged from system
    Private Sub AxGrFingerXCtrl1_SensorUnplug(ByVal sender As System.Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_SensorUnplugEvent) Handles AxGrFingerXCtrl1.SensorUnplug
        _toolsSiFam.WriteLog("Sensor: " & e.idSensor & ". Evento: Desconectado.")
        AxGrFingerXCtrl1.CapStopCapture(e.idSensor)
        lblSituacao.BackColor = Color.Red
        lblSituacao.ForeColor = Color.White
        lblSituacao.Text = "Desconectado"
    End Sub

    ' A finger was placed on reader
    Private Sub AxGrFingerXCtrl1_FingerDown(ByVal sender As System.Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_FingerDownEvent) Handles AxGrFingerXCtrl1.FingerDown
        _toolsSiFam.WriteLog("Sensor: " & e.idSensor & ". Evento: Dedo posicionado.")
        lblSituacao.BackColor = Color.Red
        lblSituacao.ForeColor = Color.White
        lblSituacao.Text = "Dedo Posicionado"
    End Sub

    ' A finger was removed from reader
    Private Sub AxGrFingerXCtrl1_FingerUp(ByVal sender As System.Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_FingerUpEvent) Handles AxGrFingerXCtrl1.FingerUp
        _toolsSiFam.WriteLog("Sensor: " & e.idSensor & ". Evento: Dedo removido.")
        lblSituacao.BackColor = Color.Red
        lblSituacao.ForeColor = Color.White
        lblSituacao.Text = "Dedo Removido"
    End Sub

    ' An image was acquired from reader
    Private Sub AxGrFingerXCtrl1_ImageAcquired(ByVal sender As System.Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_ImageAcquiredEvent) Handles AxGrFingerXCtrl1.ImageAcquired

        Dim ret As Integer
        Dim _util As New clsUtil
        Dim vbLiberaBiometria As Boolean = False

        grdIdentifica.DataSource = Nothing
        idDigital = 0
        vbIdentificouDigital = False
        vbSenhaValidada = False

        btnGravar.Enabled = False
     
        lblSituacao.BackColor = Color.Yellow
        lblSituacao.ForeColor = Color.Black
        lblSituacao.Text = "Conectado, avaliando digital."

        _toolsSiFam.raw.height = e.height
        _toolsSiFam.raw.width = e.width
        _toolsSiFam.raw.res = e.res
        _toolsSiFam.raw.img = e.rawImage
        _toolsSiFam.PrintBiometricDisplay(False, GrFinger.GR_DEFAULT_CONTEXT)

        If _banco.Conecta() = False Then Exit Sub

        ret = _toolsSiFam.ExtractTemplate()
        If ret = GrFinger.GR_BAD_QUALITY Then
            _toolsSiFam.WriteLog("Digital extraída com Qualidade RUIM.")
            vsGlo_Log = "A Digital extraída está com Qualidade RUIM, Por favor tente novamente.(Tentativa:" & vnContaDigitalRuim + 1 & ")"
            MsgBox(vsGlo_Log)
            vbPassou = False
            vnContaDigitalRuim = vnContaDigitalRuim + 1
            If vnContaDigitalRuim >= 5 Then
                If frmSetup.vsModo <> "0" Then    ' era   frmsetup.vsModo = "0"
                    _banco.LogValidacao("biosifam_erro1", "A Digital extraída está com Qualidade RUIM. ", True, idSelecionado, idMedico)
                    MsgBox("Cinco digitais RUINS foram informadas, nesta situação, talvez o paciente precise utilizar o modo senha, esta avaliação deve ser realizada na PREVPEL. Para prosseguir o atendimento, o modo Off Line será ativado permitindo o registro desta consulta.")
                    vbModoOFFLine = True
                    Me.BackColor = Color.Yellow
                    btnGravar.Enabled = True
                    btnGravar.Focus()
                Else
                    GoTo fim_bloco
                End If

                Exit Sub
            End If
        ElseIf ret = GrFinger.GR_MEDIUM_QUALITY Then
            _banco.LogValidacao("biosifam_erro2", "A Digital extraída está com Qualidade MÉDIA.", False, idSelecionado, idMedico)
            _toolsSiFam.WriteLog("Digital extraída com Qualidade Média.")
            vbLiberaBiometria = True
            'vnContaDigitalRuim = 0
        ElseIf ret = GrFinger.GR_HIGH_QUALITY Then
            vbLiberaBiometria = True
            vnContaDigitalRuim = 0
            _banco.LogValidacao("biosifam_erro8", "Digital extraída com Alta Qualidade.", False, idSelecionado, idMedico)
            _toolsSiFam.WriteLog("Digital extraída com Alta Qualidade.")
        Else
            _banco.LogValidacao("biosifam_erro3", "Digital não capturada, Digital ilegível !, Tentativa: " & vnContaDigitalNaoIdentificada + 1, True, idSelecionado, idMedico)
            'vnContaDigitalRuim = 0     elimimei esta opção
            vnContaDigitalNaoIdentificada = vnContaDigitalNaoIdentificada + 1
            If vnContaDigitalNaoIdentificada >= 5 And frmSetup.vsModo <> "1" Then
                _banco.LogValidacao("biosifam_erro6", "Digital com 5 tentativas de identificação sem sucesso, modo OFF-Line habilitado", True, idSelecionado, idMedico)
                _banco.executaQuery("update pessoas set biometrias_invalidas=current_date where id_pessoa=" & vnGlo_IdPessoa)
                vbModoOFFLine = True
                Me.BackColor = Color.Yellow
                MsgBox("Recarregue o Paciente e prossiga no modo OFF_Line")
                btnMatricula.Focus()
                GoTo fim_bloco
            End If
        End If

        If vbLiberaBiometria = True Then
            Dim score As Integer

            score = 0
            ' imprime matriz de ponto sobre a digital
            _toolsSiFam.PrintBiometricDisplay(True, GrFinger.GR_NO_CONTEXT)

            ret = _toolsSiFam.Identify(score, 1, vnGlo_IdPessoa, vbMenor12, txtMatricula.Text)
            If ret > 0 Then
                _banco.LogValidacao("biosifam_biometria_ok", "Digital identificada com sucesso", True, idSelecionado, idMedico)
                atualizaLogList("Digital identificada. ID = " & ret & ". Escore = " & score & ".")

                'identificou a digital 
                Dim ds As New DataSet
                grdIdentifica.DataSource = Nothing
                idDigital = ret
                If idDigital > 0 Then
                    btnGravar.Enabled = True
                    btnGravar.Visible = True
                    If frmSetup.vsModo = "0" Then
                        btnGravar.Text = "Gravar Nova Digital"
                    Else
                        InicializaBotaoGravar()
                        If frmSetup.vsModo = "1" Then MsgBox("Digital identificada com sucesso !")
                    End If
                    If IdentificaContribuinte(idDigital) = True Then
                        If _banco.Conecta() = False Then Exit Sub
                        ds = _banco.obtemQuery("SELECT id_digital, nome FROM pessoas INNER JOIN digital USING (id_pessoa) WHERE id_digital = " & idDigital)
                        vbIdentificouDigital = True
                        grdIdentifica.DataSource = ds.Tables(0)
                        'ds.Tables.Item(0).Columns(1).ToString
                        grdIdentifica.Columns(0).Width = 50
                        grdIdentifica.Refresh()
                     Else
                        btnGravar.Enabled = False
                     End If
                Else
                    ' strModo -> 0=Retaguarda, 1=Consulta, 2=Consultório, 3-exames, 4-fisioterapeuta
                    If frmSetup.vsModo = "0" Then
                        btnGravar.Text = "Gravar Digital"
                        btnGravar.Enabled = True
                    End If
                End If
            Else
                ' strModo -> 0=Retaguarda, 1=Consulta, 2=Consultório, 3-exames, 4-fisioterapeuta
                If frmSetup.vsModo = "0" Then
                    btnGravar.Text = "Gravar Digital"
                    btnGravar.Enabled = True
                Else
                    _banco.LogValidacao("biosifam_erro5", "Digital informada não localizada na base de dados !", True, idSelecionado, idMedico)
                End If
                vsGlo_Log = "Digital Não identificada. = " & ret & ". Escore = " & score & "."
            End If
            vnGlo_IdDigital = ret
            vbGlo_InseriuDigital = True
        End If
Fim_Bloco:
        _banco.Desconecta()

    End Sub


    Private Sub txtMatricula_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMatricula.GotFocus
        ' _banco.Desconecta()
    End Sub

 
    Private Function UltimoDiaMes(ByVal vnMes As Integer) As Integer
        UltimoDiaMes = 31
        If vnMes = 2 Then UltimoDiaMes = 28
        If vnMes = 4 Or vnMes = 6 Or vnMes = 9 Or vnMes = 11 Then UltimoDiaMes = 30

    End Function


End Class

