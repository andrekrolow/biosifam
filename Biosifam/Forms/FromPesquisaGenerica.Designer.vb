<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPesquisaGenerica
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
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

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPesquisaGenerica))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GrpUpload = New System.Windows.Forms.GroupBox()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.PicBuscarArquivo = New System.Windows.Forms.PictureBox()
        Me.GrdPesquisaServicos = New System.Windows.Forms.GroupBox()
        Me.DgvServicosDisponiveis = New System.Windows.Forms.DataGridView()
        Me.GrpUpload.SuspendLayout()
        CType(Me.PicBuscarArquivo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrdPesquisaServicos.SuspendLayout()
        CType(Me.DgvServicosDisponiveis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpUpload
        '
        Me.GrpUpload.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GrpUpload.Controls.Add(Me.txtFiltro)
        Me.GrpUpload.Controls.Add(Me.PicBuscarArquivo)
        Me.GrpUpload.ForeColor = System.Drawing.Color.Maroon
        Me.GrpUpload.Location = New System.Drawing.Point(12, 5)
        Me.GrpUpload.Name = "GrpUpload"
        Me.GrpUpload.Size = New System.Drawing.Size(622, 44)
        Me.GrpUpload.TabIndex = 90
        Me.GrpUpload.TabStop = False
        Me.GrpUpload.Text = "Selecione ou informe o serviço a pesquisar."
        '
        'txtFiltro
        '
        Me.txtFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFiltro.Location = New System.Drawing.Point(15, 17)
        Me.txtFiltro.Margin = New System.Windows.Forms.Padding(2)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(458, 22)
        Me.txtFiltro.TabIndex = 92
        '
        'PicBuscarArquivo
        '
        Me.PicBuscarArquivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicBuscarArquivo.Image = CType(resources.GetObject("PicBuscarArquivo.Image"), System.Drawing.Image)
        Me.PicBuscarArquivo.Location = New System.Drawing.Point(474, 16)
        Me.PicBuscarArquivo.Name = "PicBuscarArquivo"
        Me.PicBuscarArquivo.Size = New System.Drawing.Size(27, 23)
        Me.PicBuscarArquivo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicBuscarArquivo.TabIndex = 89
        Me.PicBuscarArquivo.TabStop = False
        Me.PicBuscarArquivo.Tag = "Localize o Conveniado no Google Maps."
        '
        'GrdPesquisaServicos
        '
        Me.GrdPesquisaServicos.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GrdPesquisaServicos.Controls.Add(Me.DgvServicosDisponiveis)
        Me.GrdPesquisaServicos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrdPesquisaServicos.ForeColor = System.Drawing.Color.Maroon
        Me.GrdPesquisaServicos.Location = New System.Drawing.Point(12, 55)
        Me.GrdPesquisaServicos.Name = "GrdPesquisaServicos"
        Me.GrdPesquisaServicos.Size = New System.Drawing.Size(622, 285)
        Me.GrdPesquisaServicos.TabIndex = 93
        Me.GrdPesquisaServicos.TabStop = False
        Me.GrdPesquisaServicos.Text = "Serviços localizados"
        Me.GrdPesquisaServicos.Visible = False
        '
        'DgvServicosDisponiveis
        '
        Me.DgvServicosDisponiveis.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.DgvServicosDisponiveis.AllowUserToAddRows = False
        Me.DgvServicosDisponiveis.AllowUserToDeleteRows = False
        Me.DgvServicosDisponiveis.AllowUserToResizeColumns = False
        Me.DgvServicosDisponiveis.AllowUserToResizeRows = False
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Maroon
        Me.DgvServicosDisponiveis.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvServicosDisponiveis.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DgvServicosDisponiveis.BackgroundColor = System.Drawing.Color.White
        Me.DgvServicosDisponiveis.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.DgvServicosDisponiveis.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvServicosDisponiveis.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgvServicosDisponiveis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvServicosDisponiveis.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvServicosDisponiveis.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgvServicosDisponiveis.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.DgvServicosDisponiveis.EnableHeadersVisualStyles = False
        Me.DgvServicosDisponiveis.GridColor = System.Drawing.Color.Maroon
        Me.DgvServicosDisponiveis.Location = New System.Drawing.Point(15, 20)
        Me.DgvServicosDisponiveis.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DgvServicosDisponiveis.MultiSelect = False
        Me.DgvServicosDisponiveis.Name = "DgvServicosDisponiveis"
        Me.DgvServicosDisponiveis.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvServicosDisponiveis.RowTemplate.Height = 24
        Me.DgvServicosDisponiveis.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvServicosDisponiveis.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.DgvServicosDisponiveis.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvServicosDisponiveis.ShowCellErrors = False
        Me.DgvServicosDisponiveis.ShowCellToolTips = False
        Me.DgvServicosDisponiveis.ShowEditingIcon = False
        Me.DgvServicosDisponiveis.ShowRowErrors = False
        Me.DgvServicosDisponiveis.Size = New System.Drawing.Size(588, 249)
        Me.DgvServicosDisponiveis.TabIndex = 54
        '
        'FrmPesquisaGenerica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(646, 346)
        Me.Controls.Add(Me.GrdPesquisaServicos)
        Me.Controls.Add(Me.GrpUpload)
        Me.Name = "FrmPesquisaGenerica"
        Me.Text = "Pesquisa Genérica"
        Me.GrpUpload.ResumeLayout(False)
        Me.GrpUpload.PerformLayout()
        CType(Me.PicBuscarArquivo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrdPesquisaServicos.ResumeLayout(False)
        CType(Me.DgvServicosDisponiveis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GrpUpload As GroupBox
    Friend WithEvents txtFiltro As TextBox
    Friend WithEvents PicBuscarArquivo As PictureBox
    Friend WithEvents GrdPesquisaServicos As GroupBox
    Protected WithEvents DgvServicosDisponiveis As DataGridView
End Class
