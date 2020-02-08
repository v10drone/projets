<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_score
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_score))
        Me.listbox_nom = New System.Windows.Forms.ListBox()
        Me.button_retour = New System.Windows.Forms.Button()
        Me.listbox_temps = New System.Windows.Forms.ListBox()
        Me.button_ordrealpha = New System.Windows.Forms.Button()
        Me.button_meilleurtemps = New System.Windows.Forms.Button()
        Me.combobox_nom = New System.Windows.Forms.ComboBox()
        Me.button_caractéristiques = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'listbox_nom
        '
        Me.listbox_nom.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listbox_nom.FormattingEnabled = True
        Me.listbox_nom.ItemHeight = 12
        Me.listbox_nom.Location = New System.Drawing.Point(40, 50)
        Me.listbox_nom.Name = "listbox_nom"
        Me.listbox_nom.Size = New System.Drawing.Size(240, 328)
        Me.listbox_nom.TabIndex = 0
        '
        'button_retour
        '
        Me.button_retour.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.25!)
        Me.button_retour.Location = New System.Drawing.Point(469, 401)
        Me.button_retour.Name = "button_retour"
        Me.button_retour.Size = New System.Drawing.Size(142, 40)
        Me.button_retour.TabIndex = 1
        Me.button_retour.Text = "Button1"
        Me.button_retour.UseVisualStyleBackColor = True
        '
        'listbox_temps
        '
        Me.listbox_temps.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listbox_temps.FormattingEnabled = True
        Me.listbox_temps.ItemHeight = 12
        Me.listbox_temps.Location = New System.Drawing.Point(434, 50)
        Me.listbox_temps.Name = "listbox_temps"
        Me.listbox_temps.Size = New System.Drawing.Size(177, 328)
        Me.listbox_temps.TabIndex = 2
        '
        'button_ordrealpha
        '
        Me.button_ordrealpha.Font = New System.Drawing.Font("Arial Rounded MT Bold", 7.25!)
        Me.button_ordrealpha.Location = New System.Drawing.Point(301, 50)
        Me.button_ordrealpha.Name = "button_ordrealpha"
        Me.button_ordrealpha.Size = New System.Drawing.Size(109, 45)
        Me.button_ordrealpha.TabIndex = 3
        Me.button_ordrealpha.Text = "Button2"
        Me.button_ordrealpha.UseVisualStyleBackColor = True
        '
        'button_meilleurtemps
        '
        Me.button_meilleurtemps.Font = New System.Drawing.Font("Arial Rounded MT Bold", 7.25!)
        Me.button_meilleurtemps.Location = New System.Drawing.Point(301, 117)
        Me.button_meilleurtemps.Name = "button_meilleurtemps"
        Me.button_meilleurtemps.Size = New System.Drawing.Size(109, 45)
        Me.button_meilleurtemps.TabIndex = 4
        Me.button_meilleurtemps.Text = "Button3"
        Me.button_meilleurtemps.UseVisualStyleBackColor = True
        '
        'combobox_nom
        '
        Me.combobox_nom.FormattingEnabled = True
        Me.combobox_nom.Location = New System.Drawing.Point(159, 23)
        Me.combobox_nom.Name = "combobox_nom"
        Me.combobox_nom.Size = New System.Drawing.Size(121, 21)
        Me.combobox_nom.TabIndex = 5
        '
        'button_caractéristiques
        '
        Me.button_caractéristiques.Font = New System.Drawing.Font("Arial Rounded MT Bold", 7.25!)
        Me.button_caractéristiques.Location = New System.Drawing.Point(301, 185)
        Me.button_caractéristiques.Name = "button_caractéristiques"
        Me.button_caractéristiques.Size = New System.Drawing.Size(109, 45)
        Me.button_caractéristiques.TabIndex = 6
        Me.button_caractéristiques.Text = "Button4"
        Me.button_caractéristiques.UseVisualStyleBackColor = True
        '
        'form_score
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(646, 461)
        Me.Controls.Add(Me.button_caractéristiques)
        Me.Controls.Add(Me.combobox_nom)
        Me.Controls.Add(Me.button_meilleurtemps)
        Me.Controls.Add(Me.button_ordrealpha)
        Me.Controls.Add(Me.listbox_temps)
        Me.Controls.Add(Me.button_retour)
        Me.Controls.Add(Me.listbox_nom)
        Me.Name = "form_score"
        Me.Text = "Form3"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents listbox_nom As ListBox
    Friend WithEvents button_retour As Button
    Friend WithEvents listbox_temps As ListBox
    Friend WithEvents button_ordrealpha As Button
    Friend WithEvents button_meilleurtemps As Button
    Friend WithEvents combobox_nom As ComboBox
    Friend WithEvents button_caractéristiques As Button
End Class
