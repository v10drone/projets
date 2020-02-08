Imports System.IO
Module Module2

    Private ReadOnly mouvement() As String = {"NORD", "EST", "OUEST", "SUD"}
    Dim solution As New List(Of String)
    Dim chaineText As String = ""
    Dim difficulté As Integer = 0
    Public Sub Main(l As List(Of Object))
        CréerBat()
        CréerIn(l)
        LanceSousProgramme()
    End Sub

    Private Sub LanceSousProgramme()


        Dim nomFichier As String = Path.GetFullPath("Desktop")
        nomFichier = nomFichier.Replace("TaquinVB\WindowsApp1\WindowsApp1\WindowsApp1\bin\Debug\Desktop", "")
        File.Create(nomFichier + "solution.txt").Dispose()

        Dim s As String = nomFichier + "bat.bat"
        Shell(s, AppWinStyle.MinimizedFocus, True)

        Dim fichier As Integer = FreeFile()
        Dim chaine As String = ""

        FileOpen(fichier, nomFichier + "solution.txt", OpenMode.Input)
        While EOF(fichier) = False
            chaine = LineInput(fichier)
            chaineText += chaine + vbCrLf
            If (MouvementExiste(chaine)) Then
                solution.Add(chaine)
            End If
        End While
        FileClose(fichier)

        My.Computer.FileSystem.DeleteFile(nomFichier + "solution.txt")
        My.Computer.FileSystem.DeleteFile(nomFichier + "in.txt")
        My.Computer.FileSystem.DeleteFile(nomFichier + "bat.bat")

    End Sub

    Private Function MouvementExiste(s As String)
        For Each chaine As String In mouvement
            If (s.CompareTo(chaine) = 0) Then
                Return True
            End If
        Next
        Return False
    End Function
	
    Private Sub CréerIn(l As List(Of Object))
        Dim fichier As Integer = FreeFile()
        Dim nomFichier As String = Path.GetFullPath("Desktop")
        nomFichier = nomFichier.Replace("TaquinVB\WindowsApp1\WindowsApp1\WindowsApp1\bin\Debug\Desktop", "")
        FileOpen(fichier, nomFichier + "in.txt", OpenMode.Output)
        Print(fichier, "4 4" & vbCrLf)

        For i As Integer = 0 To 3
            For j As Integer = 0 To 3
                For x As Integer = 0 To l.Count - 1
                    If (Form_jeu.GetTaquin()(i, j).text.CompareTo(l(x).ToString) = 0) Then
                        Print(fichier, x + 1)
                        Exit For
                    ElseIf (Form_jeu.GetTaquin()(i, j).Equals(Form_jeu.GetCaseVide)) Then
                        Print(fichier, "#")
                        Exit For
                    End If

                Next
            Next
            Print(fichier, vbCrLf)
        Next
        FileClose(fichier)

    End Sub

    Private Sub CréerBat()
        Dim fichier As Integer = FreeFile()
        Dim nomFichier As String = Path.GetFullPath("Desktop")
        nomFichier = nomFichier.Replace("TaquinVB\WindowsApp1\WindowsApp1\WindowsApp1\bin\Debug\Desktop", "")
        FileOpen(fichier, nomFichier + "bat.bat", OpenMode.Output)
        Print(fichier, form_option.defaut + "Data\Resolveur\Taquin.exe" + " < " +
              nomFichier + "in.txt" + " > " +
              nomFichier + "solution.txt")
        FileClose(fichier)
    End Sub
    Public Function GetSolution()
        Return solution
    End Function

    Public Sub SetDifficulté(dif As Integer)
        difficulté = dif
    End Sub
    Public Sub Chambouler()
        Dim r As New Random
        For i As Integer = 0 To difficulté
            Dim aléa As Integer = r.Next(3)
            For x As Integer = 0 To 3
                For y As Integer = 0 To 3
                    If (Form_jeu.GetTaquin(x, y).Equals(Form_jeu.GetCaseVide)) Then
                        Possible(x, y, aléa)
                        Exit For
                    End If
                Next
            Next
        Next

    End Sub

    Private Sub Possible(i As Integer, j As Integer, aléa As Integer)
        If (i = 0) Then
            If (j = 0) Then
                If aléa = 0 Then
                    Form_jeu.GetTaquin.GetValue(i + 1, j).performClick()
                ElseIf aléa = 1 Then
                    Form_jeu.GetTaquin.GetValue(i, j + 1).performClick()
                Else
                    Form_jeu.GetTaquin.GetValue(i, 3).performClick()
                End If
            ElseIf (j = 3) Then
                If (aléa = 0) Then
                    Form_jeu.GetTaquin.GetValue(i + 1, j).performClick()
                ElseIf (aléa = 1) Then
                    Form_jeu.GetTaquin.GetValue(i, j - 1).performClick()
                Else
                    Form_jeu.GetTaquin.GetValue(i, 0).performClick()
                End If
            Else
                If (aléa = 0) Then
                    Form_jeu.GetTaquin.GetValue(i + 1, j).performClick()
                ElseIf (aléa = 1) Then
                    Form_jeu.GetTaquin.GetValue(i, j + 1).performClick()
                Else
                    Form_jeu.GetTaquin.GetValue(i, j - 1).performClick()
                End If
            End If
        ElseIf (i = 3) Then
            If (j = 0) Then
                If (aléa = 0) Then
                    Form_jeu.GetTaquin.GetValue(i - 1, j).performClick()
                ElseIf (aléa = 1) Then
                    Form_jeu.GetTaquin.GetValue(i, j + 1).performClick()
                Else
                    Form_jeu.GetTaquin.GetValue(i, 3).performClick()
                End If
            ElseIf (j = 3) Then
                If (aléa = 0) Then
                    Form_jeu.GetTaquin.GetValue(i - 1, j).performClick()
                ElseIf (aléa = 1) Then
                    Form_jeu.GetTaquin.GetValue(i, j - 1).performClick()
                Else
                    Form_jeu.GetTaquin.GetValue(i, 0).performClick()
                End If
            Else
                If (aléa = 0) Then
                    Form_jeu.GetTaquin.GetValue(i - 1, j).performClick()
                ElseIf (aléa = 1) Then
                    Form_jeu.GetTaquin.GetValue(i, j + 1).performClick()
                Else
                    Form_jeu.GetTaquin.GetValue(i, j - 1).performClick()
                End If
            End If
        ElseIf (j = 0) Then
            If (aléa = 0) Then
                Form_jeu.GetTaquin.GetValue(i + 1, j).performClick()
            ElseIf (aléa = 1) Then
                Form_jeu.GetTaquin.GetValue(i, j + 1).performClick()
            ElseIf (aléa = 2) Then
                Form_jeu.GetTaquin.GetValue(i - 1, j).performClick()
            Else
                Form_jeu.GetTaquin.GetValue(i, 3).performClick()
            End If
        ElseIf (j = 3) Then
            If (aléa = 0) Then
                Form_jeu.GetTaquin.GetValue(i - 1, j).performClick()
            ElseIf (aléa = 1) Then
                Form_jeu.GetTaquin.GetValue(i, j - 1).performClick()
            ElseIf (aléa = 2) Then
                Form_jeu.GetTaquin.GetValue(i + 1, j).performClick()
            Else
                Form_jeu.GetTaquin.GetValue(i, 0).performClick()
            End If
        Else
            If (aléa = 0) Then
                Form_jeu.GetTaquin.GetValue(i + 1, j).performClick()
            ElseIf (aléa = 1) Then
                Form_jeu.GetTaquin.GetValue(i - 1, j).performClick()
            ElseIf (aléa = 2) Then
                Form_jeu.GetTaquin.GetValue(i, j + 1).performClick()
            Else
                Form_jeu.GetTaquin.GetValue(i, j - 1).performClick()
            End If
        End If
    End Sub
    Public Sub RecupererAffichage()
        Form7.TextBox1.Text = chaineText
    End Sub

End Module
