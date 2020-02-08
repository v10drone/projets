Public Class Form_menu

    Dim MusiqueActive As Boolean = True
    Private Sub Form_menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Taquin"
        label_nom.Text = "Nom :"
        label_presentation.Text = "Créé par Alessio Di Giacomo (104) et Daran Vignarajah (111)"
        button_commencer.Text = "Commencer >"
        button_quitter.Text = "< Quitter"
        combobox_nom.Focus()
        Module1.RecupererData()
        form_option.RecupererTypes()
        Module1.RecupererParam()
        Module1.RecupererFichier()
        Module1.JouerMusique()
    End Sub

    Private Sub Combobox_nom_TextChanged(sender As Object, e As EventArgs) Handles combobox_nom.TextChanged
        If (combobox_nom.Text.Length > 0) Then
            button_commencer.Enabled = True
        Else
            button_commencer.Enabled = False
        End If
    End Sub
    Private Sub Combobox_nom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles combobox_nom.KeyPress

        If (combobox_nom.Text.Length > 10) Then
            MsgBox("Taille limite atteinte")
        Else
            If (Char.IsLetter(e.KeyChar) = False And Asc(e.KeyChar) <> 32 And Asc(e.KeyChar) <> 8) Then
                e.Handled = True
            Else
                combobox_nom.DroppedDown = True
                combobox_nom.SelectedItem = combobox_nom.FindString(combobox_nom.Text)
            End If
        End If

    End Sub

    Private Sub Combobox_nom_LostFocus(sender As Object, e As EventArgs) Handles combobox_nom.LostFocus
        combobox_nom.Text = StrConv(combobox_nom.Text, VbStrConv.ProperCase)
    End Sub

    Private Sub Button_commencer_Click(sender As Object, e As EventArgs) Handles button_commencer.Click
        Module1.Main(combobox_nom.Text)
        Me.Hide()
        Form_jeu.Show()
    End Sub

    Private Sub Button_quitter_Click(sender As Object, e As EventArgs) Handles button_quitter.Click
        If (MsgBox("Etes-vous sûr ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes) Then
            If (MsgBox("Certains ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes) Then
                Me.Close()
            End If
        End If
    End Sub

    Private Sub Button_score_Click(sender As Object, e As EventArgs) Handles button_score.Click
        Form_score.Show()
    End Sub
    Public Sub Ajout(s As String)
        combobox_nom.Items.Add(s)
    End Sub

    Private Sub Button_option_Click(sender As Object, e As EventArgs) Handles button_option.Click
        form_option.Show()
    End Sub

    Private Sub Form_menu_FormClosing(sender As Object, e As EventArgs) Handles MyBase.FormClosing
        Dim s As String = form_option.GetPram()
        Module1.EnregistrerFichier()
        Module1.EnregistrerParam(s)
        Module1.EnregistrerData()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MusiqueActive = Not MusiqueActive
        If (MusiqueActive) Then
            Module1.JouerMusique()
            Button1.Text = "STOP"
        Else
            Module1.StopMusique()
            Button1.Text = "PLAY"
        End If
    End Sub

End Class
