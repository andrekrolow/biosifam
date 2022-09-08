
Imports CefSharp
Imports CefSharp.WinForms

Public Class frmBrowserChromium

    Public WithEvents browser As ChromiumWebBrowser

    Public Sub New(URL As String)
        InitializeComponent()

        ' Dim settings As New CefSettings()
        ' If CefSharp.Cef.Is Nothing Then CefSharp.Cef.Initialize(settings)
        If URL = "" Then URL = "http://sifam.pelotas.com.br/boletocloud_2via.php"
        browser = New ChromiumWebBrowser(URL) With {.Dock = DockStyle.Fill}
        PanBrowser.Controls.Add(browser)

    End Sub

    Private Sub frmBrowserChromium_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PanBrowser_Paint(sender As Object, e As PaintEventArgs) Handles PanBrowser.Paint

    End Sub
End Class