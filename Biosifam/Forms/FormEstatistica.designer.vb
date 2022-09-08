<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formEstatistica
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
        Me.grpDigital = New System.Windows.Forms.GroupBox()
        Me.chkResumoDia = New System.Windows.Forms.CheckBox()
        Me.chkModoResumo = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbTipoEstatistica = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbMedico = New System.Windows.Forms.ComboBox()
        Me.btnGerarEstatistica = New System.Windows.Forms.Button()
        Me.grpDigital.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpDigital
        '
        Me.grpDigital.BackColor = System.Drawing.SystemColors.Control
        Me.grpDigital.Controls.Add(Me.chkResumoDia)
        Me.grpDigital.Controls.Add(Me.chkModoResumo)
        Me.grpDigital.Controls.Add(Me.Label2)
        Me.grpDigital.Controls.Add(Me.cmbTipoEstatistica)
        Me.grpDigital.Controls.Add(Me.Label1)
        Me.grpDigital.Controls.Add(Me.cmbMedico)
        Me.grpDigital.Controls.Add(Me.btnGerarEstatistica)
        Me.grpDigital.ForeColor = System.Drawing.Color.Maroon
        Me.grpDigital.Location = New System.Drawing.Point(11, 11)
        Me.grpDigital.Margin = New System.Windows.Forms.Padding(2)
        Me.grpDigital.Name = "grpDigital"
        Me.grpDigital.Padding = New System.Windows.Forms.Padding(2)
        Me.grpDigital.Size = New System.Drawing.Size(539, 104)
        Me.grpDigital.TabIndex = 12
        Me.grpDigital.TabStop = False
        '
        'chkResumoDia
        '
        Me.chkResumoDia.AutoSize = True
        Me.chkResumoDia.Location = New System.Drawing.Point(220, 77)
        Me.chkResumoDia.Name = "chkResumoDia"
        Me.chkResumoDia.Size = New System.Drawing.Size(100, 17)
        Me.chkResumoDia.TabIndex = 49
        Me.chkResumoDia.Text = "Resumo por dia"
        Me.chkResumoDia.UseVisualStyleBackColor = True
        '
        'chkModoResumo
        '
        Me.chkModoResumo.AutoSize = True
        Me.chkModoResumo.Location = New System.Drawing.Point(126, 77)
        Me.chkModoResumo.Name = "chkModoResumo"
        Me.chkModoResumo.Size = New System.Drawing.Size(91, 17)
        Me.chkModoResumo.TabIndex = 48
        Me.chkModoResumo.Text = "Resumo geral"
        Me.chkModoResumo.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 49)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 13)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "Tipo de Estatística :"
        '
        'cmbTipoEstatistica
        '
        Me.cmbTipoEstatistica.FormattingEnabled = True
        Me.cmbTipoEstatistica.Location = New System.Drawing.Point(118, 46)
        Me.cmbTipoEstatistica.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbTipoEstatistica.Name = "cmbTipoEstatistica"
        Me.cmbTipoEstatistica.Size = New System.Drawing.Size(408, 21)
        Me.cmbTipoEstatistica.TabIndex = 46
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 24)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "Médico:"
        '
        'cmbMedico
        '
        Me.cmbMedico.FormattingEnabled = True
        Me.cmbMedico.Location = New System.Drawing.Point(118, 21)
        Me.cmbMedico.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbMedico.Name = "cmbMedico"
        Me.cmbMedico.Size = New System.Drawing.Size(408, 21)
        Me.cmbMedico.TabIndex = 44
        '
        'btnGerarEstatistica
        '
        Me.btnGerarEstatistica.Font = New System.Drawing.Font("Tahoma", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGerarEstatistica.Location = New System.Drawing.Point(423, 71)
        Me.btnGerarEstatistica.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGerarEstatistica.Name = "btnGerarEstatistica"
        Me.btnGerarEstatistica.Size = New System.Drawing.Size(103, 23)
        Me.btnGerarEstatistica.TabIndex = 39
        Me.btnGerarEstatistica.Text = "Gerar Relatório"
        '
        'formEstatistica
        '
        Me.AutoScaledimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(562, 123)
        Me.Controls.Add(Me.grpDigital)
        Me.Name = "formEstatistica"
        Me.Text = "Estatistica de Validações Biométricas"
        Me.grpDigital.ResumeLayout(False)
        Me.grpDigital.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpDigital As System.Windows.Forms.GroupBox
    Friend WithEvents btnGerarEstatistica As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoEstatistica As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbMedico As System.Windows.Forms.ComboBox
    Friend WithEvents chkModoResumo As System.Windows.Forms.CheckBox
    Friend WithEvents chkResumoDia As System.Windows.Forms.CheckBox
End Class
