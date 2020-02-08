Public Class Form7
    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.ResetText()
        Module2.RecupererAffichage()
        Me.ControlBox = False
        TextBox1.ScrollBars = ScrollBars.Both
        WebBrowser1.Navigate("https://media.giphy.com/media/7Sj86u4qZH6Uw/giphy.gif")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form_menu.Show()
        Me.Close()
    End Sub

End Class