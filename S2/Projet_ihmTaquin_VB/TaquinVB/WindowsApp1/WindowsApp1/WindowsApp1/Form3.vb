Public Class Form_score

    Dim tableau As List(Of Joueur) = Module1.GetTableauJoueur
    Private Sub Form_score_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Score"

        button_retour.Text = "Retour"
        button_ordrealpha.Text = "Ordre alphabétique"
        button_meilleurtemps.Text = "Meilleur temps"
        button_caractéristiques.Enabled = False
        button_caractéristiques.Text = "Caractéristiques complètes"

        For i As Integer = 0 To Module1.GetSize() - 1
            listbox_nom.Items.Add(tableau.Item(i).nom)
            listbox_temps.Items.Add(tableau.Item(i).MeilleurTemps)
        Next

        listbox_temps.Enabled = False

    End Sub
    Private Sub Button_retour_Click(sender As Object, e As EventArgs) Handles button_retour.Click
        Me.Close()
        Form_menu.Show()
    End Sub

    Private Sub Button_ordrealpha_Click(sender As Object, e As EventArgs) Handles button_ordrealpha.Click
        Dim var As String
        Dim var2 As Integer
        For i As Integer = 0 To listbox_nom.Items.Count - 2
            For j As Integer = 0 To listbox_nom.Items.Count - 2
                If (LCase(listbox_nom.Items(j)) > LCase(listbox_nom.Items(j + 1))) Then
                    var = listbox_nom.Items(j)
                    listbox_nom.Items(j) = listbox_nom.Items(j + 1)
                    listbox_nom.Items(j + 1) = var
                    var2 = listbox_temps.Items(j)
                    listbox_temps.Items(j) = listbox_temps.Items(j + 1)
                    listbox_temps.Items(j + 1) = var2
                End If
            Next
        Next
    End Sub

    Private Sub Button_meilleurtemps_Click(sender As Object, e As EventArgs) Handles button_meilleurtemps.Click
        Dim var As String
        Dim var2 As Integer
        For i As Integer = 0 To listbox_temps.Items.Count - 2
            For j As Integer = 0 To listbox_temps.Items.Count - 2
                If (listbox_temps.Items(j) > listbox_temps.Items(j + 1)) Then
                    var = listbox_nom.Items(j)
                    listbox_nom.Items(j) = listbox_nom.Items(j + 1)
                    listbox_nom.Items(j + 1) = var
                    var2 = listbox_temps.Items(j)
                    listbox_temps.Items(j) = listbox_temps.Items(j + 1)
                    listbox_temps.Items(j + 1) = var2
                End If
            Next
        Next
    End Sub

    Private Sub Combobos_nom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles combobox_nom.KeyPress
        If (Asc(e.KeyChar) = 13) Then
            combobox_nom.Text = StrConv(combobox_nom.Text, VbStrConv.ProperCase)
            For i As Integer = 0 To listbox_nom.Items.Count - 1
                If (combobox_nom.Text.CompareTo(listbox_nom.Items(i)) = 0) Then
                    listbox_nom.SetSelected(i, True)
                End If
            Next
        End If
    End Sub

    Private Sub Listbox_nom_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listbox_nom.SelectedIndexChanged
        combobox_nom.Text = listbox_nom.Items(listbox_nom.SelectedIndex)
        button_caractéristiques.Enabled = True
    End Sub

    Private Sub Button_caractéristiques_Click(sender As Object, e As EventArgs) Handles button_caractéristiques.Click
        Dim nb As Integer = 0
        Dim t As Integer = 0
        For i As Integer = 0 To tableau.Count - 1
            If (tableau.Item(i).nom.CompareTo(listbox_nom.Items(listbox_nom.SelectedIndex)) = 0) Then
                nb = tableau.Item(i).NbParties
                t = tableau.Item(i).Temps
            End If
        Next

        MsgBox("Nom : " & listbox_nom.Items(listbox_nom.SelectedIndex) & Chr(10) _
               & "Meilleur temps : " & listbox_temps.Items(listbox_nom.SelectedIndex) & Chr(10) _
               & "Nombre de partie(s) jouées : " & nb & Chr(10) _
               & "Temps passé à jouer : " & t)
    End Sub

End Class