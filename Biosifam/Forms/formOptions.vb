'
'     SIFAM - Sistema Informatizado do Fundo de Assistência Médica
'
'				Copyright (c) 2010 COINPEL
'
'     Autor:  Cauê Duarte (caueduar@gmail.com)
'     Criação:   24/08/2010
'     Modificação:  24/08/2010

Public Class OptionsForm
    Inherits System.Windows.Forms.Form

    dim clMinutiaeColor As Color
    dim clMinutiaeMatchColor As Color
    dim clSegmentsColor As Color
    dim clSegmentsMatchColor As Color
    dim clDirectionsColor As Color
    dim clDirectionsMatchColor As Color
    dim bShowMinutiae As Boolean
    dim bShowMinutiaeMatch As Boolean
    dim bShowSegments As Boolean
    dim bShowSegmentsMatch As Boolean
    dim bShowDirections As Boolean
    dim bShowDirectionsMatch As Boolean
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCriptografa As System.Windows.Forms.Button
    Friend WithEvents txtTextoCifrado As System.Windows.Forms.TextBox
    Friend WithEvents txtCifrador As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    dim initialized As Boolean

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    dim components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents RotationMaxIdTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ThresholdIdTextBox As System.Windows.Forms.TextBox
    Friend WithEvents RotationMaxVrTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ThresholdVrTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents pbMinutiaeMatchColor As System.Windows.Forms.PictureBox
    Friend WithEvents pbMinutiaeColor As System.Windows.Forms.PictureBox
    Friend WithEvents pbSegmentsMatchColor As System.Windows.Forms.PictureBox
    Friend WithEvents pbSegmentsColor As System.Windows.Forms.PictureBox
    Friend WithEvents cbShowMinutiaeMatched As System.Windows.Forms.CheckBox
    Friend WithEvents cbShowMinutiae As System.Windows.Forms.CheckBox
    Friend WithEvents cbShowSegmentsMatched As System.Windows.Forms.CheckBox
    Friend WithEvents cbShowSegments As System.Windows.Forms.CheckBox
    Friend WithEvents cbShowDirections As System.Windows.Forms.CheckBox
    Friend WithEvents pbDirectionsMatchColor As System.Windows.Forms.PictureBox
    Friend WithEvents pbDirectionsColor As System.Windows.Forms.PictureBox
    Friend WithEvents cbShowDirectionsMatched As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> private sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OptionsForm))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RotationMaxIdTextBox = New System.Windows.Forms.TextBox()
        Me.ThresholdIdTextBox = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.RotationMaxVrTextBox = New System.Windows.Forms.TextBox()
        Me.ThresholdVrTextBox = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cbShowMinutiaeMatched = New System.Windows.Forms.CheckBox()
        Me.cbShowMinutiae = New System.Windows.Forms.CheckBox()
        Me.pbMinutiaeMatchColor = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pbMinutiaeColor = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.OkButton = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cbShowSegmentsMatched = New System.Windows.Forms.CheckBox()
        Me.cbShowSegments = New System.Windows.Forms.CheckBox()
        Me.pbSegmentsMatchColor = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pbSegmentsColor = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.cbShowDirectionsMatched = New System.Windows.Forms.CheckBox()
        Me.cbShowDirections = New System.Windows.Forms.CheckBox()
        Me.pbDirectionsMatchColor = New System.Windows.Forms.PictureBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.pbDirectionsColor = New System.Windows.Forms.PictureBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnCriptografa = New System.Windows.Forms.Button()
        Me.txtTextoCifrado = New System.Windows.Forms.TextBox()
        Me.txtCifrador = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.pbMinutiaeMatchColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbMinutiaeColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.pbSegmentsMatchColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbSegmentsColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.pbDirectionsMatchColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbDirectionsColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.RotationMaxIdTextBox)
        Me.GroupBox1.Controls.Add(Me.ThresholdIdTextBox)
        Me.GroupBox1.Location = New System.Drawing.Point(241, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(192, 80)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Identificação"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Margem rotação:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(77, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Limiar:"
        '
        'RotationMaxIdTextBox
        '
        Me.RotationMaxIdTextBox.Location = New System.Drawing.Point(120, 48)
        Me.RotationMaxIdTextBox.Name = "RotationMaxIdTextBox"
        Me.RotationMaxIdTextBox.Size = New System.Drawing.Size(64, 20)
        Me.RotationMaxIdTextBox.TabIndex = 1
        '
        'ThresholdIdTextBox
        '
        Me.ThresholdIdTextBox.Location = New System.Drawing.Point(120, 16)
        Me.ThresholdIdTextBox.Name = "ThresholdIdTextBox"
        Me.ThresholdIdTextBox.Size = New System.Drawing.Size(64, 20)
        Me.ThresholdIdTextBox.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.RotationMaxVrTextBox)
        Me.GroupBox2.Controls.Add(Me.ThresholdVrTextBox)
        Me.GroupBox2.Location = New System.Drawing.Point(439, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(192, 80)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Verificação"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Margem rotação:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(77, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Limiar:"
        '
        'RotationMaxVrTextBox
        '
        Me.RotationMaxVrTextBox.Location = New System.Drawing.Point(120, 48)
        Me.RotationMaxVrTextBox.Name = "RotationMaxVrTextBox"
        Me.RotationMaxVrTextBox.Size = New System.Drawing.Size(64, 20)
        Me.RotationMaxVrTextBox.TabIndex = 1
        '
        'ThresholdVrTextBox
        '
        Me.ThresholdVrTextBox.Location = New System.Drawing.Point(120, 16)
        Me.ThresholdVrTextBox.Name = "ThresholdVrTextBox"
        Me.ThresholdVrTextBox.Size = New System.Drawing.Size(64, 20)
        Me.ThresholdVrTextBox.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cbShowMinutiaeMatched)
        Me.GroupBox3.Controls.Add(Me.cbShowMinutiae)
        Me.GroupBox3.Controls.Add(Me.pbMinutiaeMatchColor)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.pbMinutiaeColor)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 184)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(214, 80)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Cores minúcias"
        '
        'cbShowMinutiaeMatched
        '
        Me.cbShowMinutiaeMatched.Checked = True
        Me.cbShowMinutiaeMatched.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbShowMinutiaeMatched.Location = New System.Drawing.Point(144, 48)
        Me.cbShowMinutiaeMatched.Name = "cbShowMinutiaeMatched"
        Me.cbShowMinutiaeMatched.Size = New System.Drawing.Size(64, 16)
        Me.cbShowMinutiaeMatched.TabIndex = 5
        Me.cbShowMinutiaeMatched.Text = "Mostra"
        '
        'cbShowMinutiae
        '
        Me.cbShowMinutiae.Checked = True
        Me.cbShowMinutiae.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbShowMinutiae.Location = New System.Drawing.Point(144, 24)
        Me.cbShowMinutiae.Name = "cbShowMinutiae"
        Me.cbShowMinutiae.Size = New System.Drawing.Size(64, 18)
        Me.cbShowMinutiae.TabIndex = 4
        Me.cbShowMinutiae.Text = "Mostra"
        '
        'pbMinutiaeMatchColor
        '
        Me.pbMinutiaeMatchColor.BackColor = System.Drawing.Color.Purple
        Me.pbMinutiaeMatchColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbMinutiaeMatchColor.Location = New System.Drawing.Point(64, 48)
        Me.pbMinutiaeMatchColor.Name = "pbMinutiaeMatchColor"
        Me.pbMinutiaeMatchColor.Size = New System.Drawing.Size(72, 16)
        Me.pbMinutiaeMatchColor.TabIndex = 3
        Me.pbMinutiaeMatchColor.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Combina:"
        '
        'pbMinutiaeColor
        '
        Me.pbMinutiaeColor.BackColor = System.Drawing.Color.Blue
        Me.pbMinutiaeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbMinutiaeColor.Location = New System.Drawing.Point(64, 24)
        Me.pbMinutiaeColor.Name = "pbMinutiaeColor"
        Me.pbMinutiaeColor.Size = New System.Drawing.Size(72, 16)
        Me.pbMinutiaeColor.TabIndex = 1
        Me.pbMinutiaeColor.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Comum:"
        '
        'OkButton
        '
        Me.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OkButton.Location = New System.Drawing.Point(554, 237)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(80, 24)
        Me.OkButton.TabIndex = 9
        Me.OkButton.Text = "OK"
        '
        'ButtonCancel
        '
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Location = New System.Drawing.Point(554, 208)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(80, 24)
        Me.ButtonCancel.TabIndex = 0
        Me.ButtonCancel.Text = "Cancel"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cbShowSegmentsMatched)
        Me.GroupBox4.Controls.Add(Me.cbShowSegments)
        Me.GroupBox4.Controls.Add(Me.pbSegmentsMatchColor)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.pbSegmentsColor)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 98)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(214, 80)
        Me.GroupBox4.TabIndex = 11
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Cores dos Segmentos"
        '
        'cbShowSegmentsMatched
        '
        Me.cbShowSegmentsMatched.Checked = True
        Me.cbShowSegmentsMatched.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbShowSegmentsMatched.Location = New System.Drawing.Point(144, 48)
        Me.cbShowSegmentsMatched.Name = "cbShowSegmentsMatched"
        Me.cbShowSegmentsMatched.Size = New System.Drawing.Size(64, 16)
        Me.cbShowSegmentsMatched.TabIndex = 5
        Me.cbShowSegmentsMatched.Text = "Mostra"
        '
        'cbShowSegments
        '
        Me.cbShowSegments.Checked = True
        Me.cbShowSegments.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbShowSegments.Location = New System.Drawing.Point(144, 24)
        Me.cbShowSegments.Name = "cbShowSegments"
        Me.cbShowSegments.Size = New System.Drawing.Size(64, 18)
        Me.cbShowSegments.TabIndex = 4
        Me.cbShowSegments.Text = "Mostra"
        '
        'pbSegmentsMatchColor
        '
        Me.pbSegmentsMatchColor.BackColor = System.Drawing.Color.Purple
        Me.pbSegmentsMatchColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbSegmentsMatchColor.Location = New System.Drawing.Point(64, 48)
        Me.pbSegmentsMatchColor.Name = "pbSegmentsMatchColor"
        Me.pbSegmentsMatchColor.Size = New System.Drawing.Size(72, 16)
        Me.pbSegmentsMatchColor.TabIndex = 3
        Me.pbSegmentsMatchColor.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Combina:"
        '
        'pbSegmentsColor
        '
        Me.pbSegmentsColor.BackColor = System.Drawing.Color.Lime
        Me.pbSegmentsColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbSegmentsColor.Location = New System.Drawing.Point(64, 24)
        Me.pbSegmentsColor.Name = "pbSegmentsColor"
        Me.pbSegmentsColor.Size = New System.Drawing.Size(72, 16)
        Me.pbSegmentsColor.TabIndex = 1
        Me.pbSegmentsColor.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Comum:"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cbShowDirectionsMatched)
        Me.GroupBox5.Controls.Add(Me.cbShowDirections)
        Me.GroupBox5.Controls.Add(Me.pbDirectionsMatchColor)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.pbDirectionsColor)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(214, 80)
        Me.GroupBox5.TabIndex = 12
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Cores das direções das  minúcias"
        '
        'cbShowDirectionsMatched
        '
        Me.cbShowDirectionsMatched.Checked = True
        Me.cbShowDirectionsMatched.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbShowDirectionsMatched.Location = New System.Drawing.Point(144, 48)
        Me.cbShowDirectionsMatched.Name = "cbShowDirectionsMatched"
        Me.cbShowDirectionsMatched.Size = New System.Drawing.Size(64, 17)
        Me.cbShowDirectionsMatched.TabIndex = 5
        Me.cbShowDirectionsMatched.Text = "Mostra"
        '
        'cbShowDirections
        '
        Me.cbShowDirections.Checked = True
        Me.cbShowDirections.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbShowDirections.Location = New System.Drawing.Point(144, 24)
        Me.cbShowDirections.Name = "cbShowDirections"
        Me.cbShowDirections.Size = New System.Drawing.Size(64, 16)
        Me.cbShowDirections.TabIndex = 4
        Me.cbShowDirections.Text = "Mostra"
        '
        'pbDirectionsMatchColor
        '
        Me.pbDirectionsMatchColor.BackColor = System.Drawing.Color.Purple
        Me.pbDirectionsMatchColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbDirectionsMatchColor.Location = New System.Drawing.Point(64, 48)
        Me.pbDirectionsMatchColor.Name = "pbDirectionsMatchColor"
        Me.pbDirectionsMatchColor.Size = New System.Drawing.Size(72, 16)
        Me.pbDirectionsMatchColor.TabIndex = 3
        Me.pbDirectionsMatchColor.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(10, 48)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 13)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Combina:"
        '
        'pbDirectionsColor
        '
        Me.pbDirectionsColor.BackColor = System.Drawing.Color.Red
        Me.pbDirectionsColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbDirectionsColor.Location = New System.Drawing.Point(64, 24)
        Me.pbDirectionsColor.Name = "pbDirectionsColor"
        Me.pbDirectionsColor.Size = New System.Drawing.Size(72, 16)
        Me.pbDirectionsColor.TabIndex = 1
        Me.pbDirectionsColor.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 24)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(45, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Comum:"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label15)
        Me.GroupBox6.Controls.Add(Me.Label14)
        Me.GroupBox6.Controls.Add(Me.btnCriptografa)
        Me.GroupBox6.Controls.Add(Me.txtTextoCifrado)
        Me.GroupBox6.Controls.Add(Me.txtCifrador)
        Me.GroupBox6.Location = New System.Drawing.Point(241, 98)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(390, 80)
        Me.GroupBox6.TabIndex = 13
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Criptografia da senha "
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(12, 49)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(63, 13)
        Me.Label15.TabIndex = 42
        Me.Label15.Text = "Criptografia:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(34, 25)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(41, 13)
        Me.Label14.TabIndex = 41
        Me.Label14.Text = "Senha:"
        '
        'btnCriptografa
        '
        Me.btnCriptografa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCriptografa.Location = New System.Drawing.Point(243, 18)
        Me.btnCriptografa.Name = "btnCriptografa"
        Me.btnCriptografa.Size = New System.Drawing.Size(111, 23)
        Me.btnCriptografa.TabIndex = 40
        Me.btnCriptografa.Text = "Criptografa"
        Me.btnCriptografa.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCriptografa.UseVisualStyleBackColor = True
        '
        'txtTextoCifrado
        '
        Me.txtTextoCifrado.Location = New System.Drawing.Point(81, 48)
        Me.txtTextoCifrado.Name = "txtTextoCifrado"
        Me.txtTextoCifrado.Size = New System.Drawing.Size(273, 20)
        Me.txtTextoCifrado.TabIndex = 39
        '
        'txtCifrador
        '
        Me.txtCifrador.Location = New System.Drawing.Point(81, 22)
        Me.txtCifrador.Name = "txtCifrador"
        Me.txtCifrador.Size = New System.Drawing.Size(148, 20)
        Me.txtCifrador.TabIndex = 38
        '
        'OptionsForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(646, 273)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "OptionsForm"
        Me.Text = "Opções"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.pbMinutiaeMatchColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbMinutiaeColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.pbSegmentsMatchColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbSegmentsColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.pbDirectionsMatchColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbDirectionsColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' Commit changes made by user
    Public Sub AcceptChanges()
        clMinutiaeColor = pbMinutiaeColor.BackColor
        clMinutiaeMatchColor = pbMinutiaeMatchColor.BackColor
        clSegmentsColor = pbSegmentsColor.BackColor
        clSegmentsMatchColor = pbSegmentsMatchColor.BackColor
        clDirectionsColor = pbDirectionsColor.BackColor
        clDirectionsMatchColor = pbDirectionsMatchColor.BackColor
        bShowMinutiae = cbShowMinutiae.Checked
        bShowMinutiaeMatch = cbShowMinutiaeMatched.Checked
        bShowSegments = cbShowSegments.Checked
        bShowSegmentsMatch = cbShowSegmentsMatched.Checked
        bShowDirections = cbShowDirections.Checked
        bShowDirectionsMatch = cbShowDirectionsMatched.Checked
    End Sub

    ' Set current values of threshold and rotation for verification and identification
    Public Sub setParameters(ByVal thresholdId As Integer, ByVal rotationMaxId As Integer, ByVal thresholdVr As Integer, ByVal rotationMaxVr As Integer)
        ThresholdIdTextBox.Text = thresholdId
        RotationMaxIdTextBox.Text = rotationMaxId
        ThresholdVrTextBox.Text = thresholdVr
        RotationMaxVrTextBox.Text = rotationMaxVr
    End Sub

    ' convert Color type to BGR format used by GrFinger
    Private Function Color2BGR(ByVal color As Color) As Integer
        Dim rgb As Integer = color.ToArgb And &HFFFFFF
        Return ((rgb And &HFF00) + ((rgb And &HFF) * 65536) + ((rgb And &HFF0000) / 65536))
    End Function

    ' Get new values set by user
    Public Sub getParameters(ByRef thresholdId As Integer, ByRef rotationMaxId As Integer, ByRef thresholdVr As Integer, ByRef rotationMaxVr As Integer,
        ByRef minutiaeColor As Integer, ByRef minutiaeMatchColor As Integer, ByRef segmentsColor As Integer, ByRef segmentsMatchColor As Integer,
        ByRef directionsColor As Integer, ByRef directionsMatchColor As Integer)
        ' convert threshold and rotation values
        thresholdId = Integer.Parse(ThresholdIdTextBox.Text)
        rotationMaxId = Integer.Parse(RotationMaxIdTextBox.Text)
        thresholdVr = Integer.Parse(ThresholdVrTextBox.Text)
        rotationMaxVr = Integer.Parse(RotationMaxVrTextBox.Text)
        ' convert colors to BGR
        minutiaeColor = Color2BGR(pbMinutiaeColor.BackColor)
        minutiaeMatchColor = Color2BGR(pbMinutiaeMatchColor.BackColor)
        segmentsColor = Color2BGR(pbSegmentsColor.BackColor)
        segmentsMatchColor = Color2BGR(pbSegmentsMatchColor.BackColor)
        directionsColor = Color2BGR(pbDirectionsColor.BackColor)
        directionsMatchColor = Color2BGR(pbDirectionsMatchColor.BackColor)
        ' check if anything should not be displayed
        If Not (cbShowMinutiae.Checked) Then minutiaeColor = GrFinger.GR_IMAGE_NO_COLOR
        If Not (cbShowMinutiaeMatched.Checked) Then minutiaeMatchColor = GrFinger.GR_IMAGE_NO_COLOR
        If Not (cbShowSegments.Checked) Then segmentsColor = GrFinger.GR_IMAGE_NO_COLOR
        If Not (cbShowSegmentsMatched.Checked) Then segmentsMatchColor = GrFinger.GR_IMAGE_NO_COLOR
        If Not (cbShowDirections.Checked) Then directionsColor = GrFinger.GR_IMAGE_NO_COLOR
        If Not (cbShowDirectionsMatched.Checked) Then directionsMatchColor = GrFinger.GR_IMAGE_NO_COLOR
    End Sub

    ' Set current values in GUI
    Private Sub OptionsForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' if not initialized, get initial values
        If Not (initialized) Then AcceptChanges()
        ' set current values in GUI
        pbMinutiaeColor.BackColor = clMinutiaeColor
        pbMinutiaeMatchColor.BackColor = clMinutiaeMatchColor
        pbSegmentsColor.BackColor = clSegmentsColor
        pbSegmentsMatchColor.BackColor = clSegmentsMatchColor
        pbDirectionsColor.BackColor = clDirectionsColor
        pbDirectionsMatchColor.BackColor = clDirectionsMatchColor
        cbShowMinutiae.Checked = bShowMinutiae
        cbShowMinutiaeMatched.Checked = bShowMinutiaeMatch
        cbShowSegments.Checked = bShowSegments
        cbShowSegmentsMatched.Checked = bShowSegmentsMatch
        cbShowDirections.Checked = bShowDirections
        cbShowDirectionsMatched.Checked = bShowDirectionsMatch
        ' flag as already initialized
        initialized = True
    End Sub

    ' display color dialog and set minutiae color
    Private Sub pbMinutiaeColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbMinutiaeColor.DoubleClick
        ColorDialog1.Color = pbMinutiaeColor.BackColor
        If ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then pbMinutiaeColor.BackColor = ColorDialog1.Color
    End Sub

    ' display color dialog and set matching minutiae color
    Private Sub pbMinutiaeMatchColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbMinutiaeMatchColor.DoubleClick
        ColorDialog1.Color = pbMinutiaeMatchColor.BackColor
        If ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then pbMinutiaeMatchColor.BackColor = ColorDialog1.Color
    End Sub

    ' display color dialog and set segments color
    Private Sub pbSegmentsColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbSegmentsColor.DoubleClick
        ColorDialog1.Color = pbSegmentsColor.BackColor
        If ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then pbSegmentsColor.BackColor = ColorDialog1.Color
    End Sub

    ' display color dialog and set matching segments color
    Private Sub pbSegmentsMatchColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbSegmentsMatchColor.DoubleClick
        ColorDialog1.Color = pbSegmentsMatchColor.BackColor
        If ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then pbSegmentsMatchColor.BackColor = ColorDialog1.Color
    End Sub

    ' display color dialog and set directions color
    Private Sub pbDirectionsColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbDirectionsColor.DoubleClick
        ColorDialog1.Color = pbDirectionsColor.BackColor
        If ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then pbDirectionsColor.BackColor = ColorDialog1.Color
    End Sub

    ' display color dialog and set matching directions color
    Private Sub pbDirectionsMatchColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbDirectionsMatchColor.DoubleClick
        ColorDialog1.Color = pbDirectionsMatchColor.BackColor
        If ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then pbDirectionsMatchColor.BackColor = ColorDialog1.Color
    End Sub

    Private Sub btnCriptografa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCriptografa.Click
        Try
            txtTextoCifrado.Text = _s.CriptaTexto(txtCifrador.Text, True, "")
        Catch

        End Try
    End Sub

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click

    End Sub

    Private Sub ThresholdIdTextBox_TextChanged(sender As Object, e As EventArgs) Handles ThresholdIdTextBox.TextChanged

    End Sub
End Class
