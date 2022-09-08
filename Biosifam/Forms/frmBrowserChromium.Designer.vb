<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBrowserChromium
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
        Me.PanBrowser = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'PanBrowser
        '
        Me.PanBrowser.Location = New System.Drawing.Point(12, 12)
        Me.PanBrowser.Name = "PanBrowser"
        Me.PanBrowser.Size = New System.Drawing.Size(776, 426)
        Me.PanBrowser.TabIndex = 0
        '
        'frmBrowserChromium
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.PanBrowser)
        Me.Name = "frmBrowserChromium"
        Me.Text = "frmBrowserChromium"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanBrowser As Panel
End Class
