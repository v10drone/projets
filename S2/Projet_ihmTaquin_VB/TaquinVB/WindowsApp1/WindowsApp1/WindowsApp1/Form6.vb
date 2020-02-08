Imports System.ComponentModel

Public Class form_nvtaquin

    Dim listeTexte As New List(Of String)
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Nouveau taquin"
        Label1.Text = "Nouvelle configuration de taquin"
        For Each t As TextBox In Panel1.Controls
            t.TextAlign = HorizontalAlignment.Center
        Next
        Panel1.Controls.Item(0).Focus()
    End Sub

    Private Sub Button_ajoutez_Click(sender As Object, e As EventArgs) Handles button_ajoutez.Click
        If (txtbox_nom.Text.Length = 0) Then
            MsgBox("N'oubliez pas de lui donner un nom")
        ElseIf (CaseRestante() = False) Then
            listeTexte = GetTexte(listeTexte)
            CréerNouveauxType()
            MsgBox("Nouveau type créé vous pouvez à présent essayer de le résoudre")
            form_option.listbox_type.Items.Add(txtbox_nom.Text)
            Me.Close()
        End If
    End Sub

    Private Sub Txtbox_nom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbox_nom.KeyPress
        If (Asc(e.KeyChar) = 34 Or Asc(e.KeyChar) = 47 Or Asc(e.KeyChar) = 92) Then
            MsgBox("N'utilisez pas ce symbole s'il vous plait")
            txtbox_nom.ResetText()
        End If
    End Sub

    Private Function CaseRestante()
        Dim b As Boolean = True
        For Each t As TextBox In Panel1.Controls
            If (t.Text.Length = 0) Then
                b = True
            Else
                b = False
            End If
        Next
        Return b
    End Function

    Private Function GetTexte(liste As List(Of String))
        For Each t As TextBox In Panel1.Controls
            liste.Add(t.Text)
        Next
        liste.Reverse()
        Return liste
    End Function

    Private Sub CréerNouveauxType()
        Dim fichier As Integer = 0
        Dim nomFichier As String = ""
        fichier = FreeFile()
        '
        nomFichier = form_option.defaut + "Types\" + txtbox_nom.Text + ".txt"
        FileOpen(fichier, nomFichier, OpenMode.Output)
        For Each s As String In listeTexte
            Print(fichier, s + vbCrLf)
        Next
        FileClose(fichier)
    End Sub

    Private Sub Form_nvtaquin_FormClosing(sender As Object, e As CancelEventArgs) Handles Me.FormClosing
        Dim fichier As Integer = 0
        Dim nomFichier As String = ""
        fichier = FreeFile()
        '
        nomFichier = form_option.defaut + "types.txt"
        form_option.Types.Add(txtbox_nom.Text)
        FileOpen(fichier, nomFichier, OpenMode.Output)
        For Each s As String In form_option.Types
            Print(fichier, s + vbCrLf)
        Next
        FileClose(fichier)
    End Sub

    Private Sub TextBox1_LostFocus(sender As Object, e As EventArgs) _
        Handles TextBox1.LostFocus, TextBox2.LostFocus, TextBox3.LostFocus, TextBox4.LostFocus, TextBox5.LostFocus,
        TextBox6.LostFocus, TextBox7.LostFocus, TextBox8.LostFocus, TextBox9.LostFocus, TextBox10.LostFocus, TextBox11.LostFocus, TextBox12.LostFocus, TextBox13.LostFocus,
        TextBox14.LostFocus, TextBox15.LostFocus, TextBox16.LostFocus

        For Each t As TextBox In Panel1.Controls
            If (sender.Equals(t) = False And sender.text.CompareTo("") <> 0) Then
                If (sender.text.CompareTo(t.Text) = 0) Then
                    sender.resetText()
                    MsgBox("Cette case existe déjà")
                    Exit Sub
                End If
            End If
        Next

    End Sub

End Class