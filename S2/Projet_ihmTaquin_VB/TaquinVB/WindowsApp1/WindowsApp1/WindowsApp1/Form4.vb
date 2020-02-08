Imports System.IO
Public Class form_option

    Dim bouton As Boolean = True
    Public defaut As String = GetChemin()
    Public Types As New List(Of String)
    Public typeActuel As String = ""

    Private Function GetChemin()
        Dim s As String = Path.GetFullPath("TaquinVB")
        s = s.Replace("WindowsApp1\WindowsApp1\WindowsApp1\bin\Debug\TaquinVB", "")
        Return s.ToString
    End Function

    Private Sub Form_option_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Options"
        txtbox_temps.Text = Module1.GetTemps()
        combobox_chemin.Items.Add(Module1.chemin)
        combobox_chemin.Text = Module1.chemin
        For Each s As String In Types
            listbox_type.Items.Add(s)
        Next
        listbox_type.SetSelected(listbox_type.FindStringExact(typeActuel), True)
    End Sub

    Private Sub Rb_non1_CheckedChanged(sender As Object, e As EventArgs) Handles rb_non1.CheckedChanged
        If (rb_non1.Checked = True) Then
            label_timer.Enabled = False
            label_seconde.Enabled = False
            txtbox_temps.Clear()
            txtbox_temps.Enabled = False
            Form_jeu.SetTemps(False)
            rb_oui2.Checked = False
            rb_non2.Checked = False
            rb_oui2.Enabled = False
            rb_non2.Enabled = False
            RadioButton1.Checked = False
            RadioButton2.Checked = False
            RadioButton1.Enabled = False
            RadioButton2.Enabled = False
        Else
            label_timer.Enabled = True
            label_seconde.Enabled = True
            txtbox_temps.Text = Module1.GetTemps()
            txtbox_temps.Enabled = True
            Form_jeu.SetTemps(True)
            rb_oui2.Enabled = True
            rb_oui2.Checked = True
            rb_non2.Enabled = True
            RadioButton1.Enabled = True
            RadioButton1.Checked = True
            RadioButton2.Enabled = True
        End If
    End Sub

    Public Function BoutonPause()
        Return rb_oui2.Checked
    End Function

    Public Function Progress()
        Return RadioButton2.Checked
    End Function
    Public Function TempsTimer()
        Return Integer.Parse(txtbox_temps.Text)
    End Function

    Public Function BoutonS()
        Return rb_oui3.Checked
    End Function

    Private Sub Button_enregistrer_Click(sender As Object, e As EventArgs) Handles button_enregistrer.Click
        typeActuel = listbox_type.Items(listbox_type.SelectedIndex).ToString
        chemin = combobox_chemin.Text
        Dim s As String = GetPram()
        Module1.EnregistrerParam(s)
        Me.Hide()
    End Sub

    Private Sub Txtbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbox_temps.KeyPress
        If (Char.IsNumber(e.KeyChar) = False And Asc(e.KeyChar) <> 8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Txtbox_temps_(sender As Object, e As EventArgs) Handles txtbox_temps.LostFocus
        If (txtbox_temps.Text.Length = 0) Then
            txtbox_temps.Text = Module1.GetTemps
            MsgBox("Temps par defaut appliqué")
        ElseIf (Integer.Parse(txtbox_temps.Text) <= 0) Then
            MsgBox("Un chiffre positif et non nul est demandé !")
            txtbox_temps.ResetText()
        Else
            Module1.SetTemps(Integer.Parse(txtbox_temps.Text))
        End If
    End Sub

    Public Function GetPram()
        Dim chaineS As String = ""
        Dim i As Integer = 0
        If (txtbox_temps.Text.Length = 0) Then
            i = 60
        Else
            i = Integer.Parse(txtbox_temps.Text)
        End If

        If (rb_oui1.Checked = True) Then
            chaineS += "AvecTemps_" & i.ToString & vbCrLf
        Else
            chaineS += "SansTemps" & vbCrLf
        End If
        If (rb_oui2.Checked = True) Then
            chaineS += "AvecBouton" & vbCrLf
        Else
            chaineS += "SansBouton" & vbCrLf
        End If
        If (rb_oui3.Checked = True) Then
            chaineS += "AvecBoutonS" & vbCrLf
        Else
            chaineS += "SansBoutonS" & vbCrLf
        End If
        If (RadioButton2.Checked = True) Then
            chaineS += "AvecBarreTemps" & vbCrLf
        Else
            chaineS += "SansBarreTemps" & vbCrLf
        End If
        Dim s As String = ColorDialog1.Color.ToString
        s = s.Replace(s.First, "")
        s = s.Replace(s.Last, "")
        s = s.Remove(0, 6)
        chaineS += s & vbCrLf
        chaineS += typeActuel & vbCrLf
        chaineS += "Difficulté_" + TrackBar1.Value.ToString
        Return chaineS
    End Function

    Public Function EstUnType(s As String)
        For Each chaine As String In Types
            If (chaine.CompareTo(s) = 0) Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Sub RecupererTypes()
        Dim fichier As Integer = 0
        Dim nomFichier As String = ""
        fichier = FreeFile()
        nomFichier = defaut + "\Data\types.txt"
        FileOpen(fichier, nomFichier, OpenMode.Input)
        While EOF(fichier) = False
            Types.Add(LineInput(fichier))
        End While
        FileClose(fichier)
    End Sub
    Private Sub Button_points_Click(sender As Object, e As EventArgs) Handles button_points.Click
        Form_enregistrersous.Show()
    End Sub

    Private Sub Button_plus_Click(sender As Object, e As EventArgs) Handles button_plus.Click
        form_nvtaquin.Show()
    End Sub

    Private Sub Listbox_type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listbox_type.SelectedIndexChanged
        typeActuel = listbox_type.SelectedItem()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (ColorDialog1.ShowDialog() = DialogResult.OK) Then
            For Each b As Button In Form_jeu.Panel1.Controls
                b.BackColor = ColorDialog1.Color
            Next
        End If
    End Sub

End Class