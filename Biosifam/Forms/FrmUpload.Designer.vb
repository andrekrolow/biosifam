<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmUpload
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUpload))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grpIdentificação = New System.Windows.Forms.GroupBox()
        Me.PicCapturarDocumentoCelular = New System.Windows.Forms.PictureBox()
        Me.CmbAno = New System.Windows.Forms.ComboBox()
        Me.CmbMes = New System.Windows.Forms.ComboBox()
        Me.btnAuditagem = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CmbTipo = New System.Windows.Forms.ComboBox()
        Me.GrpUpload = New System.Windows.Forms.GroupBox()
        Me.btnGravar = New System.Windows.Forms.Button()
        Me.txtArquivo = New System.Windows.Forms.TextBox()
        Me.PicBuscarArquivo = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.grdUploads = New System.Windows.Forms.DataGridView()
        Me.btnPesquisar = New System.Windows.Forms.Button()
        Me.lblMes = New System.Windows.Forms.Label()
        Me.grpIdentificação.SuspendLayout()
        CType(Me.PicCapturarDocumentoCelular, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpUpload.SuspendLayout()
        CType(Me.PicBuscarArquivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdUploads, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpIdentificação
        '
        Me.grpIdentificação.BackColor = System.Drawing.SystemColors.Control
        Me.grpIdentificação.Controls.Add(Me.PicCapturarDocumentoCelular)
        Me.grpIdentificação.Controls.Add(Me.CmbAno)
        Me.grpIdentificação.Controls.Add(Me.CmbMes)
        Me.grpIdentificação.Controls.Add(Me.btnAuditagem)
        Me.grpIdentificação.Controls.Add(Me.Label1)
        Me.grpIdentificação.Controls.Add(Me.CmbTipo)
        Me.grpIdentificação.Controls.Add(Me.GrpUpload)
        Me.grpIdentificação.Controls.Add(Me.Label3)
        Me.grpIdentificação.Controls.Add(Me.grdUploads)
        Me.grpIdentificação.Controls.Add(Me.btnPesquisar)
        Me.grpIdentificação.Controls.Add(Me.lblMes)
        Me.grpIdentificação.ForeColor = System.Drawing.Color.Maroon
        Me.grpIdentificação.Location = New System.Drawing.Point(11, 11)
        Me.grpIdentificação.Margin = New System.Windows.Forms.Padding(2)
        Me.grpIdentificação.Name = "grpIdentificação"
        Me.grpIdentificação.Padding = New System.Windows.Forms.Padding(2)
        Me.grpIdentificação.Size = New System.Drawing.Size(534, 386)
        Me.grpIdentificação.TabIndex = 16
        Me.grpIdentificação.TabStop = False
        '
        'PicCapturarDocumentoCelular
        '
        Me.PicCapturarDocumentoCelular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicCapturarDocumentoCelular.Image = CType(resources.GetObject("PicCapturarDocumentoCelular.Image"), System.Drawing.Image)
        Me.PicCapturarDocumentoCelular.Location = New System.Drawing.Point(490, 11)
        Me.PicCapturarDocumentoCelular.Name = "PicCapturarDocumentoCelular"
        Me.PicCapturarDocumentoCelular.Size = New System.Drawing.Size(39, 37)
        Me.PicCapturarDocumentoCelular.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicCapturarDocumentoCelular.TabIndex = 95
        Me.PicCapturarDocumentoCelular.TabStop = False
        Me.PicCapturarDocumentoCelular.Tag = "Autorização de atendimento por SMS"
        '
        'CmbAno
        '
        Me.CmbAno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbAno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbAno.FormattingEnabled = True
        Me.CmbAno.Items.AddRange(New Object() {"2022", "2023", "2024", "2025", "2026", "2027", "2028", "2029", "2030", "2031", "2032", "2033"})
        Me.CmbAno.Location = New System.Drawing.Point(133, 24)
        Me.CmbAno.Margin = New System.Windows.Forms.Padding(2)
        Me.CmbAno.Name = "CmbAno"
        Me.CmbAno.Size = New System.Drawing.Size(52, 24)
        Me.CmbAno.Sorted = True
        Me.CmbAno.TabIndex = 94
        '
        'CmbMes
        '
        Me.CmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbMes.FormattingEnabled = True
        Me.CmbMes.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.CmbMes.Location = New System.Drawing.Point(46, 24)
        Me.CmbMes.Margin = New System.Windows.Forms.Padding(2)
        Me.CmbMes.Name = "CmbMes"
        Me.CmbMes.Size = New System.Drawing.Size(48, 24)
        Me.CmbMes.Sorted = True
        Me.CmbMes.TabIndex = 93
        '
        'btnAuditagem
        '
        Me.btnAuditagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAuditagem.Image = CType(resources.GetObject("btnAuditagem.Image"), System.Drawing.Image)
        Me.btnAuditagem.Location = New System.Drawing.Point(457, 24)
        Me.btnAuditagem.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAuditagem.Name = "btnAuditagem"
        Me.btnAuditagem.Size = New System.Drawing.Size(29, 25)
        Me.btnAuditagem.TabIndex = 92
        Me.btnAuditagem.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(202, 28)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 15)
        Me.Label1.TabIndex = 91
        Me.Label1.Text = "Tipo:"
        '
        'CmbTipo
        '
        Me.CmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbTipo.FormattingEnabled = True
        Me.CmbTipo.Location = New System.Drawing.Point(240, 24)
        Me.CmbTipo.Margin = New System.Windows.Forms.Padding(2)
        Me.CmbTipo.Name = "CmbTipo"
        Me.CmbTipo.Size = New System.Drawing.Size(183, 24)
        Me.CmbTipo.Sorted = True
        Me.CmbTipo.TabIndex = 90
        '
        'GrpUpload
        '
        Me.GrpUpload.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GrpUpload.Controls.Add(Me.btnGravar)
        Me.GrpUpload.Controls.Add(Me.txtArquivo)
        Me.GrpUpload.Controls.Add(Me.PicBuscarArquivo)
        Me.GrpUpload.ForeColor = System.Drawing.Color.Maroon
        Me.GrpUpload.Location = New System.Drawing.Point(11, 297)
        Me.GrpUpload.Name = "GrpUpload"
        Me.GrpUpload.Size = New System.Drawing.Size(506, 78)
        Me.GrpUpload.TabIndex = 89
        Me.GrpUpload.TabStop = False
        Me.GrpUpload.Text = "Selecione ou informe o arquivo. (PDF/JPG/JPEG)"
        '
        'btnGravar
        '
        Me.btnGravar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGravar.Location = New System.Drawing.Point(373, 42)
        Me.btnGravar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGravar.Name = "btnGravar"
        Me.btnGravar.Size = New System.Drawing.Size(116, 23)
        Me.btnGravar.TabIndex = 90
        Me.btnGravar.Text = "Enviar Arquivo"
        '
        'txtArquivo
        '
        Me.txtArquivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArquivo.Location = New System.Drawing.Point(5, 16)
        Me.txtArquivo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtArquivo.Name = "txtArquivo"
        Me.txtArquivo.Size = New System.Drawing.Size(458, 22)
        Me.txtArquivo.TabIndex = 92
        '
        'PicBuscarArquivo
        '
        Me.PicBuscarArquivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicBuscarArquivo.Image = CType(resources.GetObject("PicBuscarArquivo.Image"), System.Drawing.Image)
        Me.PicBuscarArquivo.Location = New System.Drawing.Point(464, 12)
        Me.PicBuscarArquivo.Name = "PicBuscarArquivo"
        Me.PicBuscarArquivo.Size = New System.Drawing.Size(27, 25)
        Me.PicBuscarArquivo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicBuscarArquivo.TabIndex = 89
        Me.PicBuscarArquivo.TabStop = False
        Me.PicBuscarArquivo.Tag = "Localize o Conveniado no Google Maps."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(98, 28)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 15)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Ano:"
        '
        'grdUploads
        '
        Me.grdUploads.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.grdUploads.AllowUserToAddRows = False
        Me.grdUploads.AllowUserToDeleteRows = False
        Me.grdUploads.AllowUserToResizeColumns = False
        Me.grdUploads.AllowUserToResizeRows = False
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Maroon
        Me.grdUploads.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdUploads.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdUploads.BackgroundColor = System.Drawing.Color.White
        Me.grdUploads.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.grdUploads.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdUploads.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdUploads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdUploads.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdUploads.DefaultCellStyle = DataGridViewCellStyle3
        Me.grdUploads.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.grdUploads.EnableHeadersVisualStyles = False
        Me.grdUploads.GridColor = System.Drawing.Color.Maroon
        Me.grdUploads.Location = New System.Drawing.Point(11, 62)
        Me.grdUploads.Margin = New System.Windows.Forms.Padding(2)
        Me.grdUploads.MultiSelect = False
        Me.grdUploads.Name = "grdUploads"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdUploads.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.grdUploads.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.grdUploads.RowTemplate.Height = 24
        Me.grdUploads.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdUploads.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.grdUploads.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdUploads.ShowCellErrors = False
        Me.grdUploads.ShowCellToolTips = False
        Me.grdUploads.ShowEditingIcon = False
        Me.grdUploads.ShowRowErrors = False
        Me.grdUploads.Size = New System.Drawing.Size(506, 221)
        Me.grdUploads.TabIndex = 15
        '
        'btnPesquisar
        '
        Me.btnPesquisar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPesquisar.Image = CType(resources.GetObject("btnPesquisar.Image"), System.Drawing.Image)
        Me.btnPesquisar.Location = New System.Drawing.Point(427, 24)
        Me.btnPesquisar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnPesquisar.Name = "btnPesquisar"
        Me.btnPesquisar.Size = New System.Drawing.Size(29, 25)
        Me.btnPesquisar.TabIndex = 14
        Me.btnPesquisar.UseVisualStyleBackColor = True
        '
        'lblMes
        '
        Me.lblMes.AutoSize = True
        Me.lblMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMes.Location = New System.Drawing.Point(8, 27)
        Me.lblMes.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblMes.Name = "lblMes"
        Me.lblMes.Size = New System.Drawing.Size(34, 15)
        Me.lblMes.TabIndex = 13
        Me.lblMes.Text = "Mês:"
        '
        'FrmUpload
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(554, 408)
        Me.Controls.Add(Me.grpIdentificação)
        Me.Name = "FrmUpload"
        Me.Text = "Controle de Uploads"
        Me.grpIdentificação.ResumeLayout(False)
        Me.grpIdentificação.PerformLayout()
        CType(Me.PicCapturarDocumentoCelular, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpUpload.ResumeLayout(False)
        Me.GrpUpload.PerformLayout()
        CType(Me.PicBuscarArquivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdUploads, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grpIdentificação As GroupBox
    Friend WithEvents Label3 As Label
    Protected WithEvents grdUploads As DataGridView
    Friend WithEvents btnPesquisar As Button
    Friend WithEvents lblMes As Label
    Friend WithEvents GrpUpload As GroupBox
    Friend WithEvents txtArquivo As TextBox
    Friend WithEvents PicBuscarArquivo As PictureBox
    Friend WithEvents btnGravar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents CmbTipo As ComboBox
    Friend WithEvents btnAuditagem As Button
    Friend WithEvents CmbAno As ComboBox
    Friend WithEvents CmbMes As ComboBox
    Friend WithEvents PicCapturarDocumentoCelular As PictureBox
End Class
