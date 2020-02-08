Imports System.IO
Module Module1
    Public Structure Joueur
        Public nom As String
        Public MeilleurTemps As Integer
        Public NbParties As Integer
        Public Temps As Integer
    End Structure

    Dim temps As Integer = 60
    Dim tableau As New List(Of Joueur)
    Public chemin As String = ""
    Public Sub Main(s As String)
        If (Existedeja(s) = False) Then
            Initialisation(s)
        End If
    End Sub

    Private Sub Initialisation(s As String)
        Dim j As New Joueur With {.nom = s, .MeilleurTemps = vbNull, .NbParties = 0, .Temps = 0}
        tableau.Add(j)
        Form_menu.Ajout(j.nom)
    End Sub

    Private Sub InitialisationExistant(s As String)
        Dim j As New Joueur

        Dim list As List(Of Char) = s.ToList()

        For i As Integer = 0 To list.Count - 1
            Dim chaine As String = list.Item(0)
            If (chaine.CompareTo("/") <> 0) Then
                j.nom += chaine
            Else
                list.RemoveAt(0)
                Exit For
            End If
            list.RemoveAt(0)
        Next

        Dim m As String = ""
        For i As Integer = 0 To list.Count - 1
            Dim chaine As String = list.Item(0)
            If (chaine.CompareTo("/") <> 0) Then
                m += chaine
            Else
                list.RemoveAt(0)
                Exit For
            End If
            list.RemoveAt(0)
        Next

        j.MeilleurTemps = Integer.Parse(m)
        m = ""

        For i As Integer = 0 To list.Count - 1
            Dim chaine As String = list.Item(0)
            If (chaine.CompareTo("/") <> 0) Then
                m += chaine
            Else
                list.RemoveAt(0)
                Exit For
            End If
            list.RemoveAt(0)
        Next

        j.Temps = Integer.Parse(m)
        m = ""

        For i As Integer = 0 To list.Count - 1
            Dim chaine As String = list.Item(0)
            If (chaine.CompareTo("/") <> 0) Then
                m += chaine
            Else
                list.RemoveAt(0)
                Exit For
            End If
            list.RemoveAt(0)
        Next
        j.NbParties = m
        tableau.Add(j)
        Form_menu.Ajout(j.nom)
    End Sub

    Public Sub Enregistrer()
        If (Form_jeu.GetTemps()) Then
            Dim t As Integer = 60 - Form_jeu.label_temps.Text
            Dim j1 As New Joueur
            For i As Integer = 0 To tableau.Count - 1
                If (tableau.Item(i).nom.CompareTo(Form_jeu.label_nom.Text) = 0) Then
                    j1 = tableau.Item(i)
                    tableau.RemoveAt(i)
                    j1.NbParties += 1
                    j1.Temps += t
                    If (j1.MeilleurTemps < t) Then
                        j1.MeilleurTemps = t
                    End If
                    tableau.Add(j1)
                End If
            Next
        Else
            Dim j1 As New Joueur
            For i As Integer = 0 To tableau.Count - 1
                If (tableau.Item(i).nom.CompareTo(Form_jeu.label_nom.Text) = 0) Then
                    j1 = tableau.Item(i)
                    tableau.RemoveAt(i)
                    j1.NbParties += 1
                    tableau.Add(j1)
                End If
            Next
        End If
    End Sub

    Private Function Existedeja(s As String)
        For Each j As Joueur In tableau
            If (j.nom.CompareTo(s) = 0) Then
                Return True
            End If
        Next
        Return False
    End Function
    Public Function GetTableauJoueur()
        Return tableau
    End Function
    Public Function GetSize()
        Return tableau.Count
    End Function

    Public Function Première_partie()
        Return tableau.Count = 0
    End Function

    Public Sub SetTemps(i As Integer)
        temps = i
    End Sub
    Public Function GetTemps()
        Return temps
    End Function

    Public Sub EnregistrerFichier()
        Dim fichier As Integer = 0
        Dim s As String = ""
        Dim nomFichier As String = ""
        For i As Integer = 0 To tableau.Count - 1
            s += tableau.Item(i).nom & "/" & tableau.Item(i).MeilleurTemps & "/" _
                & tableau.Item(i).Temps & "/" & tableau.Item(i).NbParties & vbCrLf
        Next
        fichier = FreeFile()
        nomFichier = chemin + "/Joueurs.txt"
        FileOpen(fichier, nomFichier, OpenMode.Output)
        Print(fichier, s)
        FileClose(fichier)
    End Sub

    Public Sub RecupererFichier()
        Dim fichier As Integer = 0
        Dim s As String = ""
        Dim nomFichier As String = ""
        fichier = FreeFile()
        nomFichier = chemin + "/Joueurs.txt"
        FileOpen(fichier, nomFichier, OpenMode.Input)
        While EOF(fichier) = False
            s = LineInput(fichier)
            InitialisationExistant(s)
        End While
        FileClose(fichier)
    End Sub

    Public Sub EnregistrerParam(chaine As String)
        Dim fichier As Integer = 0
        Dim s As String = ""
        Dim nomFichier As String = ""
        fichier = FreeFile()
        nomFichier = chemin + "/Paramètres.txt"
        s = chaine
        FileOpen(fichier, nomFichier, OpenMode.Output)
        Print(fichier, s)
        FileClose(fichier)
    End Sub

    Public Sub RecupererParam()
        Dim fichier As Integer = 0
        Dim s As String = ""
        Dim Chaines As String() = {}
        Dim nomFichier As String = ""
        fichier = FreeFile()
        nomFichier = chemin + "/Paramètres.txt"
        FileOpen(fichier, nomFichier, OpenMode.Input)
        While EOF(fichier) = False
            s = LineInput(fichier)
            If (s.Length <> 0) Then
                If (s.CompareTo("SansTemps") = 0) Then
                    form_option.rb_non1.Checked = True
                ElseIf (s.CompareTo("SansBouton") = 0) Then
                    form_option.rb_non2.Checked = True
                ElseIf (s.CompareTo("AvecBouton") = 0) Then
                    form_option.rb_oui2.Checked = True
                ElseIf (s.CompareTo("SansBoutonS") = 0) Then
                    form_option.rb_non3.Checked = True
                ElseIf (s.CompareTo("AvecBoutonS") = 0) Then
                    form_option.rb_oui3.Checked = True
                ElseIf (s.CompareTo("AvecBarreTemps") = 0) Then
                    form_option.RadioButton2.Checked = True
                ElseIf (s.CompareTo("SansBarreTemps") = 0) Then
                    form_option.RadioButton1.Checked = True
                ElseIf (s.Contains("AvecTemps")) Then
                    form_option.rb_oui1.Checked = True
                    Chaines = s.Split("_")
                    If (Chaines.Length = 1) Then
                        temps = 60
                    Else
                        temps = Integer.Parse(Chaines(1))
                    End If
                ElseIf (s.Contains("Difficulté")) Then
                    s = s.Replace("Difficulté_", "")
                    Module2.SetDifficulté(Integer.Parse(s))
                    form_option.TrackBar1.Minimum = 20
                    form_option.TrackBar1.Maximum = 300
                    form_option.TrackBar1.Value = Integer.Parse(s)
                ElseIf (form_option.EstUnType(s)) Then
                    form_option.typeActuel = s
                Else
                    If (s.Contains(",")) Then
                        form_option.ColorDialog1.Color = Color.White
                    Else
                        form_option.ColorDialog1.Color = Color.FromName(s)
                    End If
                End If
            Else
                form_option.rb_oui1.Checked = True
                form_option.rb_non2.Checked = True
            End If
        End While
        FileClose(fichier)
    End Sub
    Public Sub EnregistrerData()
        Dim fichier As Integer = 0
        Dim nomFichier As String = ""
        Dim s As String = ""
        fichier = FreeFile()
        nomFichier = form_option.defaut + "Data\" + "data.txt"
        s = form_option.combobox_chemin.Text
        FileOpen(fichier, nomFichier, OpenMode.Output)
        Print(fichier, s)
        FileClose(fichier)
    End Sub

    Public Sub RecupererData()
        Dim fichier As Integer = 0
        Dim nomFichier As String = ""
        Dim s As String = ""
        fichier = FreeFile()
        nomFichier = form_option.defaut + "\Data\data.txt"

        While (File.Exists(nomFichier) = False)
            nomFichier = InputBox("Le chemin précedent à été modifié, veuiller entrer le nouvel emplacement des ressources : ")
        End While

        FileOpen(fichier, nomFichier, OpenMode.Input)
        While EOF(fichier) = False
            s = LineInput(fichier)
        End While
        FileClose(fichier)

        While (Directory.Exists(s) = False)
            s = InputBox("Le chemin précedent à été modifié, veuiller entrer le nouvel emplacement des données : ")
        End While
        chemin = s
    End Sub
    Public Sub JouerMusique()
        My.Computer.Audio.Play(form_option.defaut + "\Data\Musiques\Lofi.wav")
    End Sub
    Public Sub StopMusique()
        My.Computer.Audio.Stop()
    End Sub

End Module
