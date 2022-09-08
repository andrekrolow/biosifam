<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExames
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
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblMedico = New System.Windows.Forms.Label()
        Me.cmbExame = New System.Windows.Forms.ComboBox()
        Me.btnGravar = New System.Windows.Forms.Button()
        Me.btnCadastrarExame = New System.Windows.Forms.Button()
        Me.btnTodosExame = New System.Windows.Forms.Button()
        Me.lblProcecimento = New System.Windows.Forms.Label()
        Me.txtValor = New System.Windows.Forms.TextBox()
        Me.btnExamedoLAboratorio = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblMedico
        '
        Me.lblMedico.AutoSize = True
        Me.lblMedico.Location = New System.Drawing.Point(29, 21)
        Me.lblMedico.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblMedico.Name = "lblMedico"
        Me.lblMedico.Size = New System.Drawing.Size(109, 13)
        Me.lblMedico.TabIndex = 54
        Me.lblMedico.Text = "Exames Disponíveis :"
        '
        'cmbExame
        '
        Me.cmbExame.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbExame.FormattingEnabled = True
        Me.cmbExame.Location = New System.Drawing.Point(142, 16)
        Me.cmbExame.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbExame.Name = "cmbExame"
        Me.cmbExame.Size = New System.Drawing.Size(307, 23)
        Me.cmbExame.TabIndex = 53
        '
        'btnGravar
        '
        Me.btnGravar.Font = New System.Drawing.Font("Tahoma", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGravar.Location = New System.Drawing.Point(247, 50)
        Me.btnGravar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGravar.Name = "btnGravar"
        Me.btnGravar.Size = New System.Drawing.Size(87, 23)
        Me.btnGravar.TabIndex = 52
        Me.btnGravar.Text = "Gravar Preço"
        Me.btnGravar.Visible = False
        '
        'btnCadastrarExame
        '
        Me.btnCadastrarExame.Font = New System.Drawing.Font("Tahoma", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCadastrarExame.Location = New System.Drawing.Point(453, 16)
        Me.btnCadastrarExame.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCadastrarExame.Name = "btnCadastrarExame"
        Me.btnCadastrarExame.Size = New System.Drawing.Size(185, 23)
        Me.btnCadastrarExame.TabIndex = 70
        Me.btnCadastrarExame.Text = "Cadastrar Novo Exame"
        Me.btnCadastrarExame.Visible = False
        '
        'btnTodosExame
        '
        Me.btnTodosExame.Font = New System.Drawing.Font("Tahoma", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTodosExame.Location = New System.Drawing.Point(453, 44)
        Me.btnTodosExame.Margin = New System.Windows.Forms.Padding(2)
        Me.btnTodosExame.Name = "btnTodosExame"
        Me.btnTodosExame.Size = New System.Drawing.Size(185, 23)
        Me.btnTodosExame.TabIndex = 71
        Me.btnTodosExame.Text = "Imprimir Todos Exames Disponíveis"
        '
        'lblProcecimento
        '
        Me.lblProcecimento.AutoSize = True
        Me.lblProcecimento.Location = New System.Drawing.Point(31, 58)
        Me.lblProcecimento.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblProcecimento.Name = "lblProcecimento"
        Me.lblProcecimento.Size = New System.Drawing.Size(107, 13)
        Me.lblProcecimento.TabIndex = 73
        Me.lblProcecimento.Text = "Valor do Exame (R$):"
        Me.lblProcecimento.Visible = False
        '
        'txtValor
        '
        Me.txtValor.Location = New System.Drawing.Point(142, 51)
        Me.txtValor.Margin = New System.Windows.Forms.Padding(2)
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Size = New System.Drawing.Size(91, 20)
        Me.txtValor.TabIndex = 74
        '
        'btnExamedoLAboratorio
        '
        Me.btnExamedoLAboratorio.Font = New System.Drawing.Font("Tahoma", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExamedoLAboratorio.Location = New System.Drawing.Point(454, 71)
        Me.btnExamedoLAboratorio.Margin = New System.Windows.Forms.Padding(2)
        Me.btnExamedoLAboratorio.Name = "btnExamedoLAboratorio"
        Me.btnExamedoLAboratorio.Size = New System.Drawing.Size(184, 23)
        Me.btnExamedoLAboratorio.TabIndex = 75
        Me.btnExamedoLAboratorio.Text = "Imprimir Somentes Exames Realizáveis"
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.Font = New System.Drawing.Font("Tahoma", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(453, 98)
        Me.Button2.Margin = New System.Windows.Forms.Padding(2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(184, 23)
        Me.Button2.TabIndex = 76
        Me.Button2.Text = "Imprimir Exames Completo"
        '
        'frmExames
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(656, 130)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnExamedoLAboratorio)
        Me.Controls.Add(Me.txtValor)
        Me.Controls.Add(Me.lblProcecimento)
        Me.Controls.Add(Me.btnTodosExame)
        Me.Controls.Add(Me.btnCadastrarExame)
        Me.Controls.Add(Me.lblMedico)
        Me.Controls.Add(Me.cmbExame)
        Me.Controls.Add(Me.btnGravar)
        Me.Name = "frmExames"
        Me.Text = "Exames"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblMedico As System.Windows.Forms.Label
    Friend WithEvents cmbExame As System.Windows.Forms.ComboBox
    Friend WithEvents btnGravar As System.Windows.Forms.Button
    Friend WithEvents btnCadastrarExame As System.Windows.Forms.Button
    Friend WithEvents btnTodosExame As System.Windows.Forms.Button
    Friend WithEvents lblProcecimento As System.Windows.Forms.Label
    Friend WithEvents txtValor As System.Windows.Forms.TextBox
    Friend WithEvents btnExamedoLAboratorio As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
