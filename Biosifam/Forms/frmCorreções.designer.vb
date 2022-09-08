<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCorreções
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCorreções))
        Me.cmbMedico = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblMedico = New System.Windows.Forms.Label()
        Me.lblIdSetup = New System.Windows.Forms.Label()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.txtPaciente = New System.Windows.Forms.TextBox()
        Me.txtDataConsulta = New System.Windows.Forms.TextBox()
        Me.lblSituacaoConsulta = New System.Windows.Forms.Label()
        Me.btnPesquisar = New System.Windows.Forms.Button()
        Me.lblValor = New System.Windows.Forms.Label()
        Me.mskValor2 = New System.Windows.Forms.MaskedTextBox()
        Me.mskValor = New System.Windows.Forms.MaskedTextBox()
        Me.cmbProcedimento2 = New System.Windows.Forms.ComboBox()
        Me.lblProcecimento = New System.Windows.Forms.Label()
        Me.cmbProcedimento = New System.Windows.Forms.ComboBox()
        Me.mskTotal = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnLimpar = New System.Windows.Forms.Button()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnUpload = New System.Windows.Forms.Button()
        Me.BtnSalvar = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbMedico
        '
        Me.cmbMedico.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMedico.FormattingEnabled = True
        Me.cmbMedico.Location = New System.Drawing.Point(125, 136)
        Me.cmbMedico.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbMedico.Name = "cmbMedico"
        Me.cmbMedico.Size = New System.Drawing.Size(435, 26)
        Me.cmbMedico.TabIndex = 67
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(84, 84)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 57
        Me.Label4.Text = "Data :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(65, 114)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "Paciente :"
        '
        'lblMedico
        '
        Me.lblMedico.AutoSize = True
        Me.lblMedico.Location = New System.Drawing.Point(72, 143)
        Me.lblMedico.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblMedico.Name = "lblMedico"
        Me.lblMedico.Size = New System.Drawing.Size(48, 13)
        Me.lblMedico.TabIndex = 53
        Me.lblMedico.Text = "Médico :"
        '
        'lblIdSetup
        '
        Me.lblIdSetup.Location = New System.Drawing.Point(14, 56)
        Me.lblIdSetup.Name = "lblIdSetup"
        Me.lblIdSetup.Size = New System.Drawing.Size(106, 14)
        Me.lblIdSetup.TabIndex = 70
        Me.lblIdSetup.Text = "Id do Atendimento :"
        Me.lblIdSetup.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtId
        '
        Me.txtId.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtId.Location = New System.Drawing.Point(125, 49)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(91, 24)
        Me.txtId.TabIndex = 69
        Me.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPaciente
        '
        Me.txtPaciente.Enabled = False
        Me.txtPaciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPaciente.Location = New System.Drawing.Point(125, 107)
        Me.txtPaciente.Name = "txtPaciente"
        Me.txtPaciente.Size = New System.Drawing.Size(435, 24)
        Me.txtPaciente.TabIndex = 73
        '
        'txtDataConsulta
        '
        Me.txtDataConsulta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDataConsulta.Location = New System.Drawing.Point(125, 77)
        Me.txtDataConsulta.Name = "txtDataConsulta"
        Me.txtDataConsulta.Size = New System.Drawing.Size(91, 24)
        Me.txtDataConsulta.TabIndex = 74
        Me.txtDataConsulta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSituacaoConsulta
        '
        Me.lblSituacaoConsulta.AutoSize = True
        Me.lblSituacaoConsulta.BackColor = System.Drawing.Color.Red
        Me.lblSituacaoConsulta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSituacaoConsulta.ForeColor = System.Drawing.Color.White
        Me.lblSituacaoConsulta.Location = New System.Drawing.Point(383, 13)
        Me.lblSituacaoConsulta.Name = "lblSituacaoConsulta"
        Me.lblSituacaoConsulta.Size = New System.Drawing.Size(108, 20)
        Me.lblSituacaoConsulta.TabIndex = 76
        Me.lblSituacaoConsulta.Text = "CANCELADO"
        Me.lblSituacaoConsulta.Visible = False
        '
        'btnPesquisar
        '
        Me.btnPesquisar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPesquisar.Image = CType(resources.GetObject("btnPesquisar.Image"), System.Drawing.Image)
        Me.btnPesquisar.Location = New System.Drawing.Point(221, 47)
        Me.btnPesquisar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnPesquisar.Name = "btnPesquisar"
        Me.btnPesquisar.Size = New System.Drawing.Size(29, 27)
        Me.btnPesquisar.TabIndex = 78
        Me.btnPesquisar.UseVisualStyleBackColor = True
        '
        'lblValor
        '
        Me.lblValor.AutoSize = True
        Me.lblValor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValor.Location = New System.Drawing.Point(485, 175)
        Me.lblValor.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblValor.Name = "lblValor"
        Me.lblValor.Size = New System.Drawing.Size(35, 15)
        Me.lblValor.TabIndex = 87
        Me.lblValor.Text = "Valor"
        '
        'mskValor2
        '
        Me.mskValor2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskValor2.Location = New System.Drawing.Point(465, 224)
        Me.mskValor2.Name = "mskValor2"
        Me.mskValor2.Size = New System.Drawing.Size(95, 26)
        Me.mskValor2.TabIndex = 86
        '
        'mskValor
        '
        Me.mskValor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskValor.Location = New System.Drawing.Point(465, 196)
        Me.mskValor.Name = "mskValor"
        Me.mskValor.Size = New System.Drawing.Size(95, 26)
        Me.mskValor.TabIndex = 85
        '
        'cmbProcedimento2
        '
        Me.cmbProcedimento2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProcedimento2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProcedimento2.FormattingEnabled = True
        Me.cmbProcedimento2.Location = New System.Drawing.Point(13, 224)
        Me.cmbProcedimento2.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbProcedimento2.Name = "cmbProcedimento2"
        Me.cmbProcedimento2.Size = New System.Drawing.Size(447, 24)
        Me.cmbProcedimento2.Sorted = True
        Me.cmbProcedimento2.TabIndex = 84
        '
        'lblProcecimento
        '
        Me.lblProcecimento.AutoSize = True
        Me.lblProcecimento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcecimento.Location = New System.Drawing.Point(14, 175)
        Me.lblProcecimento.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblProcecimento.Name = "lblProcecimento"
        Me.lblProcecimento.Size = New System.Drawing.Size(141, 15)
        Me.lblProcecimento.TabIndex = 83
        Me.lblProcecimento.Text = "Procedimento realizado:"
        '
        'cmbProcedimento
        '
        Me.cmbProcedimento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProcedimento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProcedimento.FormattingEnabled = True
        Me.cmbProcedimento.Location = New System.Drawing.Point(13, 196)
        Me.cmbProcedimento.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbProcedimento.Name = "cmbProcedimento"
        Me.cmbProcedimento.Size = New System.Drawing.Size(447, 24)
        Me.cmbProcedimento.Sorted = True
        Me.cmbProcedimento.TabIndex = 82
        '
        'mskTotal
        '
        Me.mskTotal.Enabled = False
        Me.mskTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskTotal.Location = New System.Drawing.Point(465, 261)
        Me.mskTotal.Name = "mskTotal"
        Me.mskTotal.Size = New System.Drawing.Size(95, 26)
        Me.mskTotal.TabIndex = 88
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(425, 267)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 15)
        Me.Label1.TabIndex = 89
        Me.Label1.Text = "Total:"
        '
        'btnLimpar
        '
        Me.btnLimpar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpar.Image = CType(resources.GetObject("btnLimpar.Image"), System.Drawing.Image)
        Me.btnLimpar.Location = New System.Drawing.Point(9, 5)
        Me.btnLimpar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnLimpar.Name = "btnLimpar"
        Me.btnLimpar.Size = New System.Drawing.Size(39, 38)
        Me.btnLimpar.TabIndex = 48
        '
        'BtnImprimir
        '
        Me.BtnImprimir.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnImprimir.Image = CType(resources.GetObject("BtnImprimir.Image"), System.Drawing.Image)
        Me.BtnImprimir.Location = New System.Drawing.Point(84, 5)
        Me.BtnImprimir.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(39, 38)
        Me.BtnImprimir.TabIndex = 86
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Panel2.Controls.Add(Me.BtnUpload)
        Me.Panel2.Controls.Add(Me.BtnSalvar)
        Me.Panel2.Controls.Add(Me.BtnImprimir)
        Me.Panel2.Controls.Add(Me.btnLimpar)
        Me.Panel2.Controls.Add(Me.lblSituacaoConsulta)
        Me.Panel2.Location = New System.Drawing.Point(4, -4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(567, 46)
        Me.Panel2.TabIndex = 92
        '
        'BtnUpload
        '
        Me.BtnUpload.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BtnUpload.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpload.Location = New System.Drawing.Point(128, 5)
        Me.BtnUpload.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnUpload.Name = "BtnUpload"
        Me.BtnUpload.Size = New System.Drawing.Size(82, 38)
        Me.BtnUpload.TabIndex = 94
        Me.BtnUpload.Text = "UpLoads"
        Me.BtnUpload.UseVisualStyleBackColor = False
        '
        'BtnSalvar
        '
        Me.BtnSalvar.Enabled = False
        Me.BtnSalvar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalvar.Image = CType(resources.GetObject("BtnSalvar.Image"), System.Drawing.Image)
        Me.BtnSalvar.Location = New System.Drawing.Point(45, 5)
        Me.BtnSalvar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnSalvar.Name = "BtnSalvar"
        Me.BtnSalvar.Size = New System.Drawing.Size(41, 38)
        Me.BtnSalvar.TabIndex = 92
        '
        'frmCorreções
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(572, 333)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.mskTotal)
        Me.Controls.Add(Me.lblValor)
        Me.Controls.Add(Me.mskValor2)
        Me.Controls.Add(Me.mskValor)
        Me.Controls.Add(Me.cmbProcedimento2)
        Me.Controls.Add(Me.lblProcecimento)
        Me.Controls.Add(Me.cmbProcedimento)
        Me.Controls.Add(Me.btnPesquisar)
        Me.Controls.Add(Me.txtDataConsulta)
        Me.Controls.Add(Me.txtPaciente)
        Me.Controls.Add(Me.lblIdSetup)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.cmbMedico)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblMedico)
        Me.Name = "frmCorreções"
        Me.Text = "Correções Especiais"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbMedico As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblMedico As System.Windows.Forms.Label
    Friend WithEvents lblIdSetup As System.Windows.Forms.Label
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents txtPaciente As System.Windows.Forms.TextBox
    Friend WithEvents txtDataConsulta As System.Windows.Forms.TextBox
    Friend WithEvents lblSituacaoConsulta As System.Windows.Forms.Label
    Friend WithEvents btnPesquisar As System.Windows.Forms.Button
    Friend WithEvents lblValor As Label
    Friend WithEvents mskValor2 As MaskedTextBox
    Friend WithEvents mskValor As MaskedTextBox
    Friend WithEvents cmbProcedimento2 As ComboBox
    Friend WithEvents lblProcecimento As Label
    Friend WithEvents cmbProcedimento As ComboBox
    Friend WithEvents mskTotal As MaskedTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnLimpar As Button
    Friend WithEvents BtnImprimir As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents BtnSalvar As Button
    Friend WithEvents BtnUpload As Button
End Class
