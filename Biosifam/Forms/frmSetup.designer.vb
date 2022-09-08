<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetup
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    dim components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    private sub InitializeComponent()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.btnGravar = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkLogLocal = New System.Windows.Forms.CheckBox()
        Me.chkLoginBiometrico = New System.Windows.Forms.CheckBox()
        Me.chkVoz = New System.Windows.Forms.CheckBox()
        Me.chkEmail = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbMedico4 = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbMedico3 = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbMedico2 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbMedico1 = New System.Windows.Forms.ComboBox()
        Me.lblMedico = New System.Windows.Forms.Label()
        Me.cmbMedicoP = New System.Windows.Forms.ComboBox()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonCancel
        '
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Font = New System.Drawing.Font("Tahoma", 7.2!)
        Me.ButtonCancel.Location = New System.Drawing.Point(404, 202)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(80, 24)
        Me.ButtonCancel.TabIndex = 15
        Me.ButtonCancel.Text = "Cancel"
        '
        'btnGravar
        '
        Me.btnGravar.Font = New System.Drawing.Font("Tahoma", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGravar.Location = New System.Drawing.Point(305, 202)
        Me.btnGravar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGravar.Name = "btnGravar"
        Me.btnGravar.Size = New System.Drawing.Size(87, 23)
        Me.btnGravar.TabIndex = 16
        Me.btnGravar.Text = "Gravar"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkLogLocal)
        Me.GroupBox2.Controls.Add(Me.chkLoginBiometrico)
        Me.GroupBox2.Controls.Add(Me.chkVoz)
        Me.GroupBox2.Controls.Add(Me.chkEmail)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.cmbMedico4)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cmbMedico3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.cmbMedico2)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.cmbMedico1)
        Me.GroupBox2.Controls.Add(Me.lblMedico)
        Me.GroupBox2.Controls.Add(Me.cmbMedicoP)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 13)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(481, 182)
        Me.GroupBox2.TabIndex = 50
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Setup Biosifam"
        '
        'chkLogLocal
        '
        Me.chkLogLocal.Checked = True
        Me.chkLogLocal.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkLogLocal.Location = New System.Drawing.Point(490, 88)
        Me.chkLogLocal.Name = "chkLogLocal"
        Me.chkLogLocal.Size = New System.Drawing.Size(179, 17)
        Me.chkLogLocal.TabIndex = 63
        Me.chkLogLocal.Text = "Ativa log local"
        Me.chkLogLocal.Visible = False
        '
        'chkLoginBiometrico
        '
        Me.chkLoginBiometrico.Checked = True
        Me.chkLoginBiometrico.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkLoginBiometrico.Location = New System.Drawing.Point(490, 71)
        Me.chkLoginBiometrico.Name = "chkLoginBiometrico"
        Me.chkLoginBiometrico.Size = New System.Drawing.Size(179, 17)
        Me.chkLoginBiometrico.TabIndex = 62
        Me.chkLoginBiometrico.Text = "Ativa login biométrico"
        Me.chkLoginBiometrico.Visible = False
        '
        'chkVoz
        '
        Me.chkVoz.Checked = True
        Me.chkVoz.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkVoz.Location = New System.Drawing.Point(490, 54)
        Me.chkVoz.Name = "chkVoz"
        Me.chkVoz.Size = New System.Drawing.Size(179, 17)
        Me.chkVoz.TabIndex = 61
        Me.chkVoz.Text = "Ativa rotinas com uso de voz"
        Me.chkVoz.Visible = False
        '
        'chkEmail
        '
        Me.chkEmail.Checked = True
        Me.chkEmail.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEmail.Location = New System.Drawing.Point(490, 37)
        Me.chkEmail.Name = "chkEmail"
        Me.chkEmail.Size = New System.Drawing.Size(179, 17)
        Me.chkEmail.TabIndex = 60
        Me.chkEmail.Text = "Ativa rotinas com envio de email"
        Me.chkEmail.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(24, 140)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 13)
        Me.Label8.TabIndex = 59
        Me.Label8.Text = "Médico Extra 4 :"
        '
        'cmbMedico4
        '
        Me.cmbMedico4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMedico4.FormattingEnabled = True
        Me.cmbMedico4.Location = New System.Drawing.Point(112, 137)
        Me.cmbMedico4.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbMedico4.Name = "cmbMedico4"
        Me.cmbMedico4.Size = New System.Drawing.Size(327, 23)
        Me.cmbMedico4.TabIndex = 58
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(24, 114)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 13)
        Me.Label5.TabIndex = 57
        Me.Label5.Text = "Médico Extra 3 :"
        '
        'cmbMedico3
        '
        Me.cmbMedico3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMedico3.FormattingEnabled = True
        Me.cmbMedico3.Location = New System.Drawing.Point(112, 111)
        Me.cmbMedico3.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbMedico3.Name = "cmbMedico3"
        Me.cmbMedico3.Size = New System.Drawing.Size(327, 23)
        Me.cmbMedico3.TabIndex = 56
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 88)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 13)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = "Médico Extra 2 :"
        '
        'cmbMedico2
        '
        Me.cmbMedico2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMedico2.FormattingEnabled = True
        Me.cmbMedico2.Location = New System.Drawing.Point(112, 85)
        Me.cmbMedico2.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbMedico2.Name = "cmbMedico2"
        Me.cmbMedico2.Size = New System.Drawing.Size(327, 23)
        Me.cmbMedico2.TabIndex = 54
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 62)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Médico Extra 1 :"
        '
        'cmbMedico1
        '
        Me.cmbMedico1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMedico1.FormattingEnabled = True
        Me.cmbMedico1.Location = New System.Drawing.Point(112, 59)
        Me.cmbMedico1.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbMedico1.Name = "cmbMedico1"
        Me.cmbMedico1.Size = New System.Drawing.Size(327, 23)
        Me.cmbMedico1.TabIndex = 52
        '
        'lblMedico
        '
        Me.lblMedico.AutoSize = True
        Me.lblMedico.Location = New System.Drawing.Point(17, 36)
        Me.lblMedico.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblMedico.Name = "lblMedico"
        Me.lblMedico.Size = New System.Drawing.Size(91, 13)
        Me.lblMedico.TabIndex = 51
        Me.lblMedico.Text = "Médico Principal :"
        '
        'cmbMedicoP
        '
        Me.cmbMedicoP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMedicoP.FormattingEnabled = True
        Me.cmbMedicoP.Location = New System.Drawing.Point(112, 33)
        Me.cmbMedicoP.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbMedicoP.Name = "cmbMedicoP"
        Me.cmbMedicoP.Size = New System.Drawing.Size(327, 23)
        Me.cmbMedicoP.TabIndex = 50
        '
        'frmSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 236)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnGravar)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Name = "frmSetup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configurações Médico"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents btnGravar As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkLogLocal As System.Windows.Forms.CheckBox
    Friend WithEvents chkLoginBiometrico As System.Windows.Forms.CheckBox
    Friend WithEvents chkVoz As System.Windows.Forms.CheckBox
    Friend WithEvents chkEmail As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbMedico4 As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbMedico3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbMedico2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbMedico1 As System.Windows.Forms.ComboBox
    Friend WithEvents lblMedico As System.Windows.Forms.Label
    Friend WithEvents cmbMedicoP As System.Windows.Forms.ComboBox
End Class
