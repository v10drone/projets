Public Class Form_jeu

    Dim NbCoups As Integer = 0
    Dim tab As New List(Of Object)
    Dim caseVide As New Button
    Dim taquin(3, 3) As Button
    Dim solution As New List(Of String)
    Dim mémoire As New List(Of Button(,))

    Dim commencer As Boolean = False
    Dim joueurAvecTemps As Boolean = True

    Private Sub Form_jeu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Jeu"
        Me.ControlBox = False
        Label1.Text = NbCoups
        button_pause.Text = "Pause"
        If (Form_menu.combobox_nom.Text.CompareTo("") = 0) Then
            label_nom.Text = "pas_de_nom"
        Else
            label_nom.Text = Form_menu.combobox_nom.Text
        End If

        If (joueurAvecTemps = True) Then
            Timer1.Enabled = True
            Timer2.Enabled = True
            Timer1.Interval = Module1.GetTemps() * 1000
            Timer2.Interval = 1000
            label_temps.Text = Module1.GetTemps()
            ProgressBar1.Maximum = Module1.GetTemps
            ProgressBar1.Value = ProgressBar1.Maximum
        Else
            Timer1.Enabled = False
            label_temps.Visible = False
            label_seconde.Visible = False
            ProgressBar1.Visible = False
            ProgressBar1.Enabled = False
        End If

        tab = Init(tab)
        Dim liste As New List(Of Button)

        For i As Integer = Panel1.Controls.Count - 1 To 0 Step -1
            Panel1.Controls.Item(i).Text = tab(0)
            If (Panel1.Controls.Item(i).Text.CompareTo("X") = 0) Then
                liste.Add(caseVide)
            Else
                liste.Add(Panel1.Controls.Item(i))
            End If
            Panel1.Controls.Item(i).BackColor = form_option.ColorDialog1.Color
            tab.RemoveAt(0)
        Next
        For i As Integer = 0 To 3
            For j As Integer = 0 To 3
                If (liste.Item(0).Equals(caseVide)) Then
                    taquin(i, j) = caseVide
                Else
                    taquin(i, j) = liste.Item(0)
                End If
                liste.RemoveAt(0)
            Next
        Next

        Supprimer()

        Module2.Chambouler()

        tab = Init(tab)
        Module2.Main(tab)
        solution = Module2.GetSolution()

        If (form_option.BoutonPause) Then
            button_pause.Visible = True
        Else
            button_pause.Visible = False
        End If

        If (form_option.Progress) Then
            ProgressBar1.Visible = True
        Else
            ProgressBar1.Visible = False
        End If

        If (form_option.BoutonS) Then
            Panel2.Visible = True
            button_precedent.Enabled = False
        Else
            Panel2.Visible = False
        End If

        While (mémoire.Count > 0)
            mémoire.RemoveAt(mémoire.Count - 1)
        End While

        mémoire.Add(taquin.Clone)

        commencer = True

    End Sub

    Private Sub Supprimer()
        For Each b As Button In Panel1.Controls
            If (b.Text.CompareTo("X") = 0) Then
                caseVide.Location = b.Location
                Panel1.Controls.Remove(b)
            End If
        Next
    End Sub
    Private Function Init(tab As List(Of Object))
        Dim fichier As Integer = 0
        Dim nomFichier As String = ""

        fichier = FreeFile()
        nomFichier = form_option.defaut + "\Data\Types\" + form_option.typeActuel + ".txt"

        FileOpen(fichier, nomFichier, OpenMode.Input)
        While EOF(fichier) = False
            tab.Add(LineInput(fichier))
        End While
        FileClose(fichier)

        Return tab
    End Function

    Private Sub Timer(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Close()
        Timer1.Enabled = False
        If (MsgBox("Perdu !", MsgBoxStyle.OkOnly) = MsgBoxResult.Ok) Then
            Form_menu.Show()
            Form_menu.combobox_nom.ResetText()
        End If
    End Sub

    Private Sub Affichage_Compte_A_Rebour(sender As Object, e As EventArgs) Handles Timer2.Tick
        label_temps.Text -= 1
        ProgressBar1.Value -= 1
    End Sub

    Private Sub Button_abandonner_Click(sender As Object, e As EventArgs) Handles button_abandonner.Click
        If (MsgBox("Voulez-vous vraiment abandonner ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes) Then
            Me.Close()
            Form_menu.Show()
        End If
    End Sub

    Private Sub Button_Click(sender As Object, e As EventArgs) _
        Handles Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click,
        Button9.Click, Button10.Click, Button11.Click, Button12.Click, Button13.Click, Button14.Click, Button15.Click,
        Button16.Click, Button17.Click

        If (DéplacementPossible(sender)) Then
            Dim var As New Button With {.Location = sender.location}
            sender.location = caseVide.Location
            caseVide.Location = var.Location

            For i As Integer = 0 To 3
                For j As Integer = 0 To 3
                    If (taquin.GetValue(i, j).Equals(sender)) Then
                        taquin.SetValue(caseVide, i, j)
                    ElseIf (taquin.GetValue(i, j).Equals(caseVide)) Then
                        taquin.SetValue(sender, i, j)
                    End If
                Next
            Next

            mémoire.Add(taquin.Clone)
            AfficherCoups()
            button_precedent.Enabled = True
        End If

        If (commencer = True) Then
            If (EstGagné()) Then
                Timer1.Stop()
                Timer2.Stop()
                MsgBox("Vous avez gagné !!!", MsgBoxStyle.OkOnly)
                Form_menu.Show()
                Module1.Enregistrer()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub AfficherCoups()
        NbCoups += 1
        Label1.Text = NbCoups
    End Sub
    Private Function DéplacementPossible(b As Button)
        For i As Integer = 0 To 3
            For j As Integer = 0 To 3
                If (taquin.GetValue(i, j).Equals(b)) Then
                    If (i = 0) Then
                        If (j = 0) Then
                            Return taquin.GetValue(i + 1, j).Equals(caseVide) Or taquin.GetValue(i, j + 1).Equals(caseVide) Or taquin.GetValue(i, 3).Equals(caseVide)
                        ElseIf (j = 3) Then
                            Return taquin.GetValue(i + 1, j).Equals(caseVide) Or taquin.GetValue(i, j - 1).Equals(caseVide) Or taquin.GetValue(i, 0).Equals(caseVide)
                        Else
                            Return taquin.GetValue(i + 1, j).Equals(caseVide) Or taquin.GetValue(i, j + 1).Equals(caseVide) Or taquin.GetValue(i, j - 1).Equals(caseVide)
                        End If
                    ElseIf (i = 3) Then
                        If (j = 0) Then
                            Return taquin.GetValue(i - 1, j).Equals(caseVide) Or taquin.GetValue(i, j + 1).Equals(caseVide) Or taquin.GetValue(i, 3).Equals(caseVide)
                        ElseIf (j = 3) Then
                            Return taquin.GetValue(i - 1, j).Equals(caseVide) Or taquin.GetValue(i, j - 1).Equals(caseVide) Or taquin.GetValue(i, 0).Equals(caseVide)
                        Else
                            Return taquin.GetValue(i - 1, j).Equals(caseVide) Or taquin.GetValue(i, j + 1).Equals(caseVide) Or taquin.GetValue(i, j - 1).Equals(caseVide)
                        End If
                    ElseIf (j = 0) Then
                        Return taquin.GetValue(i + 1, j).Equals(caseVide) Or taquin.GetValue(i, j + 1).Equals(caseVide) Or taquin.GetValue(i - 1, j).Equals(caseVide) Or taquin.GetValue(i, 3).Equals(caseVide)
                    ElseIf (j = 3) Then
                        Return taquin.GetValue(i - 1, j).Equals(caseVide) Or taquin.GetValue(i, j - 1).Equals(caseVide) Or taquin.GetValue(i + 1, j).Equals(caseVide) Or taquin.GetValue(i, 0).Equals(caseVide)

                    Else
                        Return taquin.GetValue(i + 1, j).Equals(caseVide) Or taquin.GetValue(i - 1, j).Equals(caseVide) Or
                                taquin.GetValue(i, j + 1).Equals(caseVide) Or taquin.GetValue(i, j - 1).Equals(caseVide)
                    End If
                End If
            Next
        Next
#Disable Warning BC42105 ' La fonction ne renvoie pas de valeur sur tous les chemins de code
    End Function
#Enable Warning BC42105 ' La fonction ne renvoie pas de valeur sur tous les chemins de code

    Private Function EstGagné()
        tab.RemoveRange(0, tab.Count)
        tab = Init(tab)
        Dim b As Boolean = False
        For i As Integer = 0 To 3
            For j As Integer = 0 To 3
                If (tab(0).ToString.CompareTo("X") = 0) Then
                    If (taquin(i, j).Equals(caseVide)) Then
                        b = True
                    Else
                        Return False
                    End If
                Else
                    If (taquin(i, j).Text.CompareTo(tab(0).ToString) = 0) Then
                        b = True
                    Else
                        Return False
                    End If
                End If
                tab.RemoveAt(0)
            Next
        Next
        Return b
    End Function

    Private Sub Button_pause_Click(sender As Object, e As EventArgs) Handles button_pause.Click
        Timer1.Enabled = Not Timer1.Enabled
        Timer2.Enabled = Not Timer2.Enabled
        JouerPossible(Timer1.Enabled)
        If (button_pause.Text.CompareTo("Pause") = 0) Then
            button_pause.Text = "Continuer"
        Else
            button_pause.Text = "Pause"
        End If
    End Sub

    Private Sub JouerPossible(b As Boolean)
        If (b = False) Then
            For Each bouton As Button In Panel1.Controls
                bouton.Enabled = b
                bouton.BackColor = Color.DarkSlateGray
            Next
        Else
            For Each bouton As Button In Panel1.Controls
                bouton.Enabled = b
                bouton.BackColor = Color.WhiteSmoke
            Next
        End If
    End Sub

    Public Function GetTemps()
        Return joueurAvecTemps
    End Function

    Public Sub SetTemps(b As Boolean)
        joueurAvecTemps = b
    End Sub

    Private Sub Button_precedent_Click(sender As Object, e As EventArgs) Handles button_precedent.Click
        mémoire.RemoveAt(mémoire.Count - 1)
        If (mémoire.Count = 0) Then
            button_precedent.Enabled = False
        Else
            Dim var As New Button
            For i As Integer = 0 To 3
                For j As Integer = 0 To 3
                    If (mémoire(mémoire.Count - 1)(i, j).Equals(taquin(i, j)) = False) Then
                        var.Location = taquin(i, j).Location
                        For x As Integer = 0 To 3
                            For y As Integer = 0 To 3
                                If (mémoire(mémoire.Count - 1)(i, j).Equals(caseVide)) Then
                                    taquin(i, j).Location = caseVide.Location
                                    caseVide.Location = var.Location
                                    taquin = mémoire(mémoire.Count - 1)
                                    Exit Sub
                                End If
                            Next
                        Next
                    End If
                Next
            Next
        End If
    End Sub
    Public Function GetTaquin()
        Return taquin
    End Function

    Private Sub Button_suivant_Click(sender As Object, e As EventArgs) Handles button_suivant.Click
        taquin = mémoire(0)

        While solution.Count > 0
            Effectuer_mvt(solution.Item(0))
            solution.RemoveAt(0)
        End While
        If (MsgBox("Voulez-vous voir les étapes de la solution", MsgBoxStyle.YesNo) = MsgBoxResult.Yes) Then
            Form7.Show()
        Else
            Form_menu.Show()
        End If
    End Sub

    Private Sub Effectuer_mvt(s As String)
        If (s.CompareTo("NORD") = 0) Then
            For i As Integer = 0 To 3
                For j As Integer = 0 To 3
                    If (taquin(i, j).Equals(caseVide)) Then
                        taquin(i - 1, j).PerformClick()
                        Exit Sub
                    End If
                Next
            Next
        ElseIf (s.CompareTo("EST") = 0) Then
            For i As Integer = 0 To 3
                For j As Integer = 0 To 3
                    If (taquin(i, j).Equals(caseVide)) Then
                        If (j = 3) Then
                            taquin(i, 0).PerformClick()
                        Else
                            taquin(i, j + 1).PerformClick()
                        End If
                        Exit Sub
                    End If
                Next
            Next
        ElseIf (s.CompareTo("OUEST") = 0) Then
            For i As Integer = 0 To 3
                For j As Integer = 0 To 3
                    If (taquin(i, j).Equals(caseVide)) Then
                        If (j = 0) Then
                            taquin(i, 3).PerformClick()
                        Else
                            taquin(i, j - 1).PerformClick()
                        End If
                        Exit Sub
                    End If
                Next
            Next
        ElseIf (s.CompareTo("SUD") = 0) Then
            For i As Integer = 0 To 3
                For j As Integer = 0 To 3
                    If (taquin(i, j).Equals(caseVide)) Then
                        taquin(i + 1, j).PerformClick()
                        Exit Sub
                    End If
                Next
            Next
        End If
    End Sub

    Public Function GetCaseVide()
        Return caseVide
    End Function

End Class