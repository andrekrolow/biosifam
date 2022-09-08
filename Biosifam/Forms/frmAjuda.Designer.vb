<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAjuda
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtMAC = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtUltimaAtualizacao = New System.Windows.Forms.TextBox()
        Me.lblIdSetup = New System.Windows.Forms.Label()
        Me.txtIdSetup = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtVersao = New System.Windows.Forms.TextBox()
        Me.txtLicenca = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbModo = New System.Windows.Forms.ComboBox()
        Me.btnGravar = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.lblMedico = New System.Windows.Forms.Label()
        Me.cmbMedicoVinculado = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnEstacao = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtMAC)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtUltimaAtualizacao)
        Me.GroupBox1.Controls.Add(Me.lblIdSetup)
        Me.GroupBox1.Controls.Add(Me.txtIdSetup)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtVersao)
        Me.GroupBox1.Controls.Add(Me.txtLicenca)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(728, 53)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Workstation"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(372, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(36, 13)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "MAC :"
        '
        'txtMAC
        '
        Me.txtMAC.BackColor = System.Drawing.SystemColors.Window
        Me.txtMAC.Enabled = False
        Me.txtMAC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMAC.Location = New System.Drawing.Point(414, 17)
        Me.txtMAC.Name = "txtMAC"
        Me.txtMAC.Size = New System.Drawing.Size(119, 21)
        Me.txtMAC.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(539, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Última Atualização:"
        '
        'txtUltimaAtualizacao
        '
        Me.txtUltimaAtualizacao.Enabled = False
        Me.txtUltimaAtualizacao.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUltimaAtualizacao.Location = New System.Drawing.Point(639, 17)
        Me.txtUltimaAtualizacao.Name = "txtUltimaAtualizacao"
        Me.txtUltimaAtualizacao.Size = New System.Drawing.Size(80, 21)
        Me.txtUltimaAtualizacao.TabIndex = 6
        '
        'lblIdSetup
        '
        Me.lblIdSetup.AutoSize = True
        Me.lblIdSetup.Location = New System.Drawing.Point(6, 22)
        Me.lblIdSetup.Name = "lblIdSetup"
        Me.lblIdSetup.Size = New System.Drawing.Size(19, 13)
        Me.lblIdSetup.TabIndex = 5
        Me.lblIdSetup.Text = "Id:"
        '
        'txtIdSetup
        '
        Me.txtIdSetup.Enabled = False
        Me.txtIdSetup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdSetup.Location = New System.Drawing.Point(31, 17)
        Me.txtIdSetup.Name = "txtIdSetup"
        Me.txtIdSetup.Size = New System.Drawing.Size(48, 21)
        Me.txtIdSetup.TabIndex = 4
        Me.txtIdSetup.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(85, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Versão :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(199, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Licença :"
        '
        'txtVersao
        '
        Me.txtVersao.Enabled = False
        Me.txtVersao.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVersao.Location = New System.Drawing.Point(137, 18)
        Me.txtVersao.Name = "txtVersao"
        Me.txtVersao.Size = New System.Drawing.Size(56, 21)
        Me.txtVersao.TabIndex = 1
        '
        'txtLicenca
        '
        Me.txtLicenca.BackColor = System.Drawing.SystemColors.Window
        Me.txtLicenca.Enabled = False
        Me.txtLicenca.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLicenca.Location = New System.Drawing.Point(256, 18)
        Me.txtLicenca.Name = "txtLicenca"
        Me.txtLicenca.Size = New System.Drawing.Size(110, 21)
        Me.txtLicenca.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 83)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(185, 13)
        Me.Label6.TabIndex = 67
        Me.Label6.Text = "Modo de funcionamento  da Estação:"
        '
        'cmbModo
        '
        Me.cmbModo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbModo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbModo.FormattingEnabled = True
        Me.cmbModo.Items.AddRange(New Object() {"Retaguarda", "Verificação de  Digitais", "Atendimento de Consultas", "Exames Clínicos", "Pronto Atendimento", "Hospitalar"})
        Me.cmbModo.Location = New System.Drawing.Point(12, 98)
        Me.cmbModo.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbModo.Name = "cmbModo"
        Me.cmbModo.Size = New System.Drawing.Size(182, 23)
        Me.cmbModo.TabIndex = 66
        '
        'btnGravar
        '
        Me.btnGravar.Font = New System.Drawing.Font("Tahoma", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGravar.Location = New System.Drawing.Point(607, 79)
        Me.btnGravar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGravar.Name = "btnGravar"
        Me.btnGravar.Size = New System.Drawing.Size(124, 23)
        Me.btnGravar.TabIndex = 69
        Me.btnGravar.Text = "Gravar"
        '
        'ButtonCancel
        '
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Font = New System.Drawing.Font("Tahoma", 7.2!)
        Me.ButtonCancel.Location = New System.Drawing.Point(607, 107)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(124, 24)
        Me.ButtonCancel.TabIndex = 68
        Me.ButtonCancel.Text = "Cancel"
        '
        'lblMedico
        '
        Me.lblMedico.AutoSize = True
        Me.lblMedico.Location = New System.Drawing.Point(211, 83)
        Me.lblMedico.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblMedico.Name = "lblMedico"
        Me.lblMedico.Size = New System.Drawing.Size(96, 13)
        Me.lblMedico.TabIndex = 71
        Me.lblMedico.Text = "Médico Vnculado :"
        '
        'cmbMedicoVinculado
        '
        Me.cmbMedicoVinculado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMedicoVinculado.FormattingEnabled = True
        Me.cmbMedicoVinculado.Location = New System.Drawing.Point(214, 98)
        Me.cmbMedicoVinculado.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbMedicoVinculado.Name = "cmbMedicoVinculado"
        Me.cmbMedicoVinculado.Size = New System.Drawing.Size(327, 23)
        Me.cmbMedicoVinculado.TabIndex = 70
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(18, 131)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(466, 13)
        Me.Label3.TabIndex = 72
        Me.Label3.Text = "? Permite sobrepor durante o login ativo o médico vinculado ao login, função some" &
    "nte para testes"
        '
        'btnEstacao
        '
        Me.btnEstacao.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnEstacao.Enabled = False
        Me.btnEstacao.Font = New System.Drawing.Font("Tahoma", 7.2!)
        Me.btnEstacao.Location = New System.Drawing.Point(607, 137)
        Me.btnEstacao.Name = "btnEstacao"
        Me.btnEstacao.Size = New System.Drawing.Size(124, 24)
        Me.btnEstacao.TabIndex = 73
        Me.btnEstacao.Text = "Desativa Modo Estação"
        '
        'frmAjuda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(749, 167)
        Me.Controls.Add(Me.btnEstacao)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblMedico)
        Me.Controls.Add(Me.cmbMedicoVinculado)
        Me.Controls.Add(Me.btnGravar)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmbModo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmAjuda"
        Me.Text = "Configuração da Estação"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtMAC As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtUltimaAtualizacao As System.Windows.Forms.TextBox
    Friend WithEvents lblIdSetup As System.Windows.Forms.Label
    Friend WithEvents txtIdSetup As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtVersao As System.Windows.Forms.TextBox
    Friend WithEvents txtLicenca As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbModo As System.Windows.Forms.ComboBox
    Friend WithEvents btnGravar As System.Windows.Forms.Button
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents lblMedico As System.Windows.Forms.Label
    Friend WithEvents cmbMedicoVinculado As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnEstacao As Button
End Class
