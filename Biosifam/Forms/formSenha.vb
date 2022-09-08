
Imports Microsoft.VisualBasic

Public Class frmSenha

    private sub frmSenha_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.mskSenha.Text = ""
    End Sub

    private sub frmSenha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'dim KeyCode As Short = EventArgs.KeyCode
        vsGlo_frmAtivo = Me.Text

        ' teclou ENTER põe o foco no próximo controle 
        If Keys.Return = e.KeyCode Then
            'TextBox2.Focus()
            System.Windows.Forms.SendKeys.Send("{TAB}") ' + é{tab} o shit
            Me.Close()
        End If

        'se teclar ESC sai
        If Keys.Escape = e.KeyCode Then Me.Close()

    End Sub

    private sub frmSenha_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Left = (Screen.PrimaryScreen.Bounds.Width - Width) / 2   ' Center form horizontally.
        Top = (Screen.PrimaryScreen.Bounds.Height - Height) / 2  ' Center form vertically.

    End Sub
End Class