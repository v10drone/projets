Imports System.ComponentModel

Public Class Form_enregistrersous
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = "Enregistrer sous"
        Button1.Text = "Enregistrer"
        button_precedent.Text = "<"
        button_suivant.Text = ">"
        txtbox_chemin.Text = WebBrowser1.Url.ToString
        txtbox_chemin.Enabled = False
    End Sub

    Private Sub Button_precedent_Click(sender As Object, e As EventArgs) Handles button_precedent.Click
        WebBrowser1.GoBack()
        MAJ()
    End Sub

    Private Sub Button_suivant_Click(sender As Object, e As EventArgs) Handles button_suivant.Click
        WebBrowser1.GoForward()
        MAJ()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        form_option.combobox_chemin.Text = Module1.chemin
    End Sub

    Private Sub MAJ()
        Dim chaine As String = WebBrowser1.Url.ToString
        txtbox_chemin.Text = chaine.Replace("file:///", "")
    End Sub

    Private Sub Form_enregistrersous_FormClosing(sender As Object, e As CancelEventArgs) Handles Me.FormClosing
        Module1.chemin = txtbox_chemin.Text
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        MAJ()
    End Sub
End Class