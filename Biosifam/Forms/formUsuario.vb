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

    dim components As System.ComponentModel.IContainer

    Friend WithEvents grpDigital As System.Windows.Forms.GroupBox
    Friend WithEvents grpStatus As System.Windows.Forms.GroupBox
    Friend WithEvents LogList As System.Windows.Forms.ListBox
    Friend WithEvents btnGravar As System.Windows.Forms.Button
    Friend WithEvents btnExcluir As System.Windows.Forms.Button
    Protected WithEvents grdIdentifica As System.Windows.Forms.DataGridView
    Friend WithEvents lblUsuarioCorrente As System.Windows.Forms.Label
    Friend WithEvents btnEncerrar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents picDigital As System.Windows.Forms.PictureBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents AxGrFingerXCtrl1 As AxGrFingerXLib.AxGrFingerXCtrl
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents lblSituacao As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> private sub InitializeComponent()
        dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUsuario))
        Me.grpDigital = New System.Windows.Forms.GroupBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.btnEncerrar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.picDigital = New System.Windows.Forms.PictureBox()
        Me.lblSituacao = New System.Windows.Forms.Label()
        Me.grdIdentifica = New System.Windows.Forms.DataGridView()
        Me.btnGravar = New System.Windows.Forms.Button()
        Me.btnExcluir = New System.Windows.Forms.Button()
        Me.grpStatus = New System.Windows.Forms.GroupBox()
        Me.LogList = New System.Windows.Forms.ListBox()
        Me.lblUsuarioCorrente = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.AxGrFingerXCtrl1 = New AxGrFingerXLib.AxGrFingerXCtrl()
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
        Me.grpDigital.BackColor = System.Drawing.Color.CadetBlue
        Me.grpDigital.Controls.Add(Me.ComboBox2)
        Me.grpDigital.Controls.Add(Me.btnEncerrar)
        Me.grpDigital.Controls.Add(Me.GroupBox1)
        Me.grpDigital.Controls.Add(Me.grdIdentifica)
        Me.grpDigital.Controls.Add(Me.btnGravar)
        Me.grpDigital.Controls.Add(Me.btnExcluir)
        Me.grpDigital.ForeColor = System.Drawing.Color.White
        Me.grpDigital.Location = New System.Drawing.Point(13, 29)
        Me.grpDigital.Margin = New System.Windows.Forms.Padding(2)
        Me.grpDigital.Name = "grpDigital"
        Me.grpDigital.Padding = New System.Windows.Forms.Padding(2)
        Me.grpDigital.Size = New System.Drawing.Size(412, 183)
        Me.grpDigital.TabIndex = 11
        Me.grpDigital.TabStop = False
        Me.grpDigital.Text = "Biometrias Existentes"
        Me.grpDigital.Visible = False
        '
        'ComboBox2
        '
        Me.ComboBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(69, 0)
        Me.ComboBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(185, 24)
        Me.ComboBox2.Sorted = True
        Me.ComboBox2.TabIndex = 28
        Me.ComboBox2.Text = "login - invisivel"
        Me.ComboBox2.Visible = False
        '
        'btnEncerrar
        '
        Me.btnEncerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEncerrar.ForeColor = System.Drawing.Color.White
        Me.btnEncerrar.Location = New System.Drawing.Point(186, 145)
        Me.btnEncerrar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnEncerrar.Name = "btnEncerrar"
        Me.btnEncerrar.Size = New System.Drawing.Size(80, 23)
        Me.btnEncerrar.TabIndex = 24
        Me.btnEncerrar.Text = "Encerrar"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.CadetBlue
        Me.GroupBox1.Controls.Add(Me.picDigital)
        Me.GroupBox1.Controls.Add(Me.lblSituacao)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(281, 17)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(110, 154)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Leitor Biométrico"
        '
        'picDigital
        '
        Me.picDigital.BackColor = System.Drawing.SystemColors.Control
        Me.picDigital.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picDigital.Location = New System.Drawing.Point(12, 16)
        Me.picDigital.Margin = New System.Windows.Forms.Padding(2)
        Me.picDigital.Name = "picDigital"
        Me.picDigital.Size = New System.Drawing.Size(88, 119)
        Me.picDigital.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picDigital.TabIndex = 26
        Me.picDigital.TabStop = False
        '
        'lblSituacao
        '
        Me.lblSituacao.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdIdentifica.DefaultCellStyle = DataGridViewCellStyle3
        Me.grdIdentifica.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.grdIdentifica.EnableHeadersVisualStyles = False
        Me.grdIdentifica.GridColor = System.Drawing.Color.Maroon
        Me.grdIdentifica.Location = New System.Drawing.Point(16, 28)
        Me.grdIdentifica.Margin = New System.Windows.Forms.Padding(2)
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
        Me.grdIdentifica.Size = New System.Drawing.Size(249, 102)
        Me.grdIdentifica.TabIndex = 22
        '
        'btnGravar
        '
        Me.btnGravar.Enabled = False
        Me.btnGravar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGravar.ForeColor = System.Drawing.Color.White
        Me.btnGravar.Location = New System.Drawing.Point(78, 145)
        Me.btnGravar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGravar.Name = "btnGravar"
        Me.btnGravar.Size = New System.Drawing.Size(104, 23)
        Me.btnGravar.TabIndex = 3
        Me.btnGravar.Text = "Gravar"
        '
        'btnExcluir
        '
        Me.btnExcluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcluir.ForeColor = System.Drawing.Color.White
        Me.btnExcluir.Location = New System.Drawing.Point(16, 145)
        Me.btnExcluir.Margin = New System.Windows.Forms.Padding(2)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(55, 23)
        Me.btnExcluir.TabIndex = 20
        Me.btnExcluir.Text = "Excluir"
        '
        'grpStatus
        '
        Me.grpStatus.Controls.Add(Me.LogList)
        Me.grpStatus.ForeColor = System.Drawing.Color.White
        Me.grpStatus.Location = New System.Drawing.Point(13, 216)
        Me.grpStatus.Margin = New System.Windows.Forms.Padding(2)
        Me.grpStatus.Name = "grpStatus"
        Me.grpStatus.Padding = New System.Windows.Forms.Padding(2)
        Me.grpStatus.Size = New System.Drawing.Size(412, 132)
        Me.grpStatus.TabIndex = 16
        Me.grpStatus.TabStop = False
        Me.grpStatus.Text = "Log de operações "
        '
        'LogList
        '
        Me.LogList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LogList.ItemHeight = 15
        Me.LogList.Location = New System.Drawing.Point(5, 18)
        Me.LogList.Margin = New System.Windows.Forms.Padding(2)
        Me.LogList.Name = "LogList"
        Me.LogList.ScrollAlwaysVisible = True
        Me.LogList.Size = New System.Drawing.Size(395, 109)
        Me.LogList.TabIndex = 8
        '
        'lblUsuarioCorrente
        '
        Me.lblUsuarioCorrente.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblUsuarioCorrente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuarioCorrente.ForeColor = System.Drawing.Color.White
        Me.lblUsuarioCorrente.Location = New System.Drawing.Point(15, 7)
        Me.lblUsuarioCorrente.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblUsuarioCorrente.Name = "lblUsuarioCorrente"
        Me.lblUsuarioCorrente.Size = New System.Drawing.Size(63, 20)
        Me.lblUsuarioCorrente.TabIndex = 17
        Me.lblUsuarioCorrente.Text = "Usuário:"
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(80, 4)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(345, 24)
        Me.ComboBox1.Sorted = True
        Me.ComboBox1.TabIndex = 25
        '
        'AxGrFingerXCtrl1
        '
        Me.AxGrFingerXCtrl1.Enabled = True
        Me.AxGrFingerXCtrl1.Location = New System.Drawing.Point(205, 150)
        Me.AxGrFingerXCtrl1.Margin = New System.Windows.Forms.Padding(2)
        Me.AxGrFingerXCtrl1.Name = "AxGrFingerXCtrl1"
        Me.AxGrFingerXCtrl1.OcxState = CType(resources.GetObject("AxGrFingerXCtrl1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxGrFingerXCtrl1.Size = New System.Drawing.Size(32, 32)
        Me.AxGrFingerXCtrl1.TabIndex = 27
        '
        'frmUsuario
        '
        Me.AutoScaledimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.CadetBlue
        Me.ClientSize = New System.Drawing.Size(442, 356)
        Me.Controls.Add(Me.AxGrFingerXCtrl1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.lblUsuarioCorrente)
        Me.Controls.Add(Me.grpStatus)
        Me.Controls.Add(Me.grpDigital)
        Me.ForeColor = System.Drawing.Color.Maroon
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(2)
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

    Dim drUsuarios As Npgsql.NpgsqlDataReader

    Public IdUsuario As Integer ' era id_pessoa
    Public strUsuario As String
    Dim idDigital As Long

    Public vsUsuarioNome As String = ""
    Public vsUsuarioId As String = ""

    private sub frmUsuario_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        vsGlo_frmAtivo = Me.Text
    End Sub

    private sub frmUsuario_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        _toolsSiFam.FinalizeGrFinger()
        frmMain.Show()
    End Sub

    private sub frmUsuario_KeyDown(ByVal sender As Object, ByVal EventArgs As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        dim KeyCode As Short = EventArgs.KeyCode

        ' teclou ENTER põe o foco no próximo controle 
        If KeyCode = System.Windows.Forms.Keys.Return Then
            'TextBox2.Focus()
            System.Windows.Forms.SendKeys.Send("{TAB}") ' + é{tab} o shit
        End If
    End Sub

    private sub frmUsuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If _PG.Conectar = False Then Exit Sub
        Me.Text = "Cadastro de Biometria de Usuários"
        grpDigital.Visible = False
        InicializaBotoes()

        ' initialize util class
        _toolsSiFam = New clsSiFam(LogList, picDigital, AxGrFingerXCtrl1)

        Dim ds As DataSet
        If _u.vbUsuarioSuporte Then
            ds = _PG.DsQuery("SELECT to_ascii(nome,'LATIN1') as nome, login FROM usuario")
        Else
            ds = _PG.DsQuery("SELECT to_ascii(nome,'LATIN1') as nome, login FROM usuario where login='" & _u.Login & "'")
        End If

        Dim i As Integer
        If ds.Tables(0).Rows.Count > 0 Then
            For i = 0 To ds.Tables(0).Rows.Count - 1
                ComboBox1.Items.Add(ds.Tables(0).Rows(i).Item(0).ToString)
                ComboBox2.Items.Add(ds.Tables(0).Rows(i).Item(1).ToString)
            Next i
        End If

        Dim err As Integer
        If i = 1 Then ComboBox1.SelectedIndex = 0 : ComboBox2.SelectedIndex = 0


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

    private sub InicializaBotoes()
        idDigital = 0
        grdIdentifica.DataSource = Nothing
        btnGravar.Enabled = False
        btnExcluir.Enabled = False

    End Sub

    private sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
        dim id As Integer
        id = _toolsSiFam.Enroll(0, strUsuario, vsUsuarioId)
        If id >= 0 Then
            MsgBox("Digital gravada com Sucesso. ID = " & id)
        Else
            MsgBox("Erro: Digital não gravada")
        End If
        btnGravar.Enabled = False
        AtualizaGridBiometrias(ComboBox2.Text)

    End Sub

    private sub btnEncerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEncerrar.Click
        _toolsSiFam.FinalizeGrFinger()
        Me.Close()
        frmMain.Show()
        Exit Sub
    End Sub

    private sub btnExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcluir.Click
        If MsgBox("Deseja realmente excluir as biometrias ?", MsgBoxStyle.YesNo, "Confirme a operação de exclusão.") = vbYes Then
            '_PG.execute("delete from digital_usuario where id_digital_usuario=" & idDigital)
            If _pg.Conectar() = False Then Exit Sub
            _PG.execute("delete from digital_usuario where usuario='" & ComboBox2.Text & "'")
            _pg.Desconectar()
            grdIdentifica.DataSource = Nothing
            btnExcluir.Enabled = False
        End If

    End Sub

    ' Escreve Status no list box.
    Public Sub atualizaLogList(ByVal message As String)
        LogList.Items.Add(message)
        LogList.SelectedIndex = LogList.Items.Count - 1
        LogList.ClearSelected()
        dim _util As New clsUtil
        _util.Mensagem_LogLocal(message, False, "FormUsuario", True, "")
    End Sub

    private sub IdentificaContribuinte(ByVal ret As Integer)
        If _pg.Conectar() = False Then Exit Sub
        dim dr As Npgsql.NpgsqlDataReader
        dr = _PG.DrQuery("SELECT id_digital_usuario, to_ascii(nome,'LATIN1') as nome FROM usuario, digital_usuario WHERE usuario.login=usuario and id_digital_usuario = " & ret)
        If _w.Modo >= "2" Then      ' medico = consultorio
            If dr.HasRows Then
                dr.Read()
                If dr.Item(0) <> strUsuario Then
                    _util.Mensagem_LogLocal("Digital informada pertence a outro usuário.", True, "FormMain", True, "")
                    vsGlo_Log = "Digital pertence a outro usuário. Localizado para " & dr.Item(1)
                    btnGravar.Enabled = False
                    btnExcluir.Enabled = False
                Else
                    _toolsSiFam.WriteLog("Identificador: " & ret)
                    _toolsSiFam.WriteLog("Biometrias existentes: " & dr.RecordsAffected)
                End If
            Else
                _util.Mensagem_LogLocal("Erro ao tentar localizar Digital na Base de dados. ID " & ret, False, "FormMain", True, "")
                btnExcluir.Enabled = False
                btnGravar.Enabled = False
            End If
        Else
            If dr.HasRows Then
                dr.Read()
                If dr.Item(0) <> strUsuario Then
                    vsGlo_Log = "Digital pertence a outro usuário. Localizado para " & dr.Item(1)
                    MsgBox(vsGlo_Log)
                    btnGravar.Enabled = False
                    btnExcluir.Enabled = False
                End If
            End If
        End If

        _pg.Desconectar()

    End Sub

    private sub ComboBox1_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        InicializaBotoes()
        If _pg.Conectar() = False Then Exit Sub
        grpDigital.Visible = True
        ComboBox2.SelectedIndex = ComboBox1.SelectedIndex
        drUsuarios = _PG.drQuery("SELECT * FROM usuario WHERE login='" & ComboBox2.Text & "'")
        If drUsuarios.HasRows Then
            drUsuarios.Read()
            strUsuario = drUsuarios.Item(0)
            'btnGravar.Enabled = True
            'IdentificaContribuinte(idDigital)
            AtualizaGridBiometrias(drUsuarios.Item(0))
        End If
fim:
        _pg.Desconectar()
    End Sub

    Private Function AtualizaGridBiometrias(ByVal vsLogin As String) As Boolean
        AtualizaGridBiometrias = False
        Dim ds As New DataSet
        grdIdentifica.DataSource = Nothing
        ds = _PG.DsQuery("SELECT id_digital_usuario, to_ascii(nome,'LATIN1') as nome FROM usuario, digital_usuario WHERE usuario.login=usuario and usuario.login='" & vsLogin & "'")
        If ds.Tables(0).Rows.Count = 0 Then
            _toolsSiFam.WriteLog("Nenhuma digital existente para o usuário selecionado!")
            GoTo fim
        End If
        grdIdentifica.DataSource = ds.Tables(0)
        'ds.Tables.Item(0).Columns(1).ToString()
        grdIdentifica.Columns(0).Width = 40
        grdIdentifica.Refresh()
        btnExcluir.Enabled = True
        AtualizaGridBiometrias = True
fim:
    End Function

    ' -----------------------------------------------------------------------------------
    ' GrFingerX events
    ' -----------------------------------------------------------------------------------

    Private sub AxGrFingerXCtrl1_FingerDown1(ByVal sender As Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_FingerDownEvent) Handles AxGrFingerXCtrl1.FingerDown
        _toolsSiFam.WriteLog("Sensor: " & e.idSensor & ", Dedo Posicionado.")
        lblSituacao.BackColor = Color.Red
        lblSituacao.ForeColor = Color.White
        lblSituacao.Text = "Dedo Inserido"
    End Sub

    private sub AxGrFingerXCtrl1_FingerUp1(ByVal sender As Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_FingerUpEvent) Handles AxGrFingerXCtrl1.FingerUp
        _toolsSiFam.WriteLog("Sensor: " & e.idSensor & ", Dedo removido.")
        lblSituacao.BackColor = Color.Red
        lblSituacao.ForeColor = Color.White
        lblSituacao.Text = "Aguardando..."
    End Sub

    private sub AxGrFingerXCtrl1_ImageAcquired1(ByVal sender As Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_ImageAcquiredEvent) Handles AxGrFingerXCtrl1.ImageAcquired

        ' An image was acquired from reader

        dim ret As Integer
        dim vbLiberaBiometria As Boolean = False

        vsGlo_Log = ""

        lblSituacao.BackColor = Color.Yellow
        lblSituacao.ForeColor = Color.Black
        lblSituacao.Text = "Matching..."

        _toolsSiFam.raw.height = e.height
        _toolsSiFam.raw.width = e.width
        _toolsSiFam.raw.res = e.res
        _toolsSiFam.raw.img = e.rawImage

        _toolsSiFam.PrintBiometricDisplay(False, GrFinger.GR_DEFAULT_CONTEXT)

        ret = _toolsSiFam.ExtractTemplate()
        If ret = GrFinger.GR_BAD_QUALITY Then
            vsGlo_Log = "Digital extraída está com Qualidade RUIM, Por favor tente novamente."
            MsgBox(vsGlo_Log)
        ElseIf ret = GrFinger.GR_MEDIUM_QUALITY Then
            _toolsSiFam.WriteLog("Digital extraída está com Qualidade MÉDIA.")
            vbLiberaBiometria = True
        ElseIf ret = GrFinger.GR_HIGH_QUALITY Then
            _toolsSiFam.WriteLog("Digital extraída está qualidade Máxima.")
            vbLiberaBiometria = True
        Else
            vsGlo_Log = "Digital informada não foi localizada !"
            MsgBox(vsGlo_Log, MsgBoxStyle.Information, "Impossível prosseguir !")
        End If

        If _pg.Conectar() = False Then Exit Sub

        If vbLiberaBiometria = True Then
            dim score As Integer
            score = 0
            ' imprime matriz de ponto sobre a digital
            _toolsSiFam.PrintBiometricDisplay(True, GrFinger.GR_NO_CONTEXT)

            ret = _toolsSiFam.Identify(score, 0, 0, False, _u.login)

            If ret > 0 Then
                'identificou a digital 
                atualizaLogList("Digital identificada. ID = " & ret & ". Escore = " & score & ".")

                grdIdentifica.DataSource = Nothing
                idDigital = vnGlo_idDigital
                If idDigital > 0 Then
                    btnGravar.Enabled = True
                    btnGravar.Visible = True
                    btnExcluir.Enabled = True
                    IdentificaContribuinte(idDigital)
                End If
            End If

            MsgBox("Nova Digital informada, sistema pronto para atualização." & Chr(13) & "Clique em gravar para concluir a atualização.")
            btnGravar.Enabled = True
            btnExcluir.Enabled = False

            AtualizaGridBiometrias(drUsuarios.Item(0))

            vnGlo_idDigital = ret
            vbGlo_InseriuDigital = True
        End If
        _pg.Desconectar()
        lblSituacao.Text = ""

    End Sub

    private sub AxGrFingerXCtrl1_SensorPlug_1(ByVal sender As System.Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_SensorPlugEvent) Handles AxGrFingerXCtrl1.SensorPlug
        _toolsSiFam.WriteLog("Sensor: " & e.idSensor & ", Conectado.")
        AxGrFingerXCtrl1.CapStartCapture(e.idSensor)
        lblSituacao.BackColor = Color.Green
        lblSituacao.ForeColor = Color.White
        lblSituacao.Text = "Aguardando..."
    End Sub

    private sub AxGrFingerXCtrl1_SensorUnplug1(ByVal sender As Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_SensorUnplugEvent) Handles AxGrFingerXCtrl1.SensorUnplug
        _toolsSiFam.WriteLog("Sensor: " & e.idSensor & ", Desconectado.")
        AxGrFingerXCtrl1.CapStopCapture(e.idSensor)
        lblSituacao.BackColor = Color.Red
        lblSituacao.ForeColor = Color.White
        lblSituacao.Text = "Desconectado"
    End Sub

End Class

