<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_jeu
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_jeu))
        Me.label_nom = New System.Windows.Forms.Label()
        Me.label_seconde = New System.Windows.Forms.Label()
        Me.label_temps = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.button_abandonner = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.Button16 = New System.Windows.Forms.Button()
        Me.Button17 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.button_pause = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.button_suivant = New System.Windows.Forms.Button()
        Me.button_precedent = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'label_nom
        '
        Me.label_nom.AutoSize = True
        Me.label_nom.BackColor = System.Drawing.Color.Transparent
        Me.label_nom.Font = New System.Drawing.Font("Arial Rounded MT Bold", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_nom.ForeColor = System.Drawing.Color.White
        Me.label_nom.Location = New System.Drawing.Point(129, 9)
        Me.label_nom.Name = "label_nom"
        Me.label_nom.Size = New System.Drawing.Size(90, 28)
        Me.label_nom.TabIndex = 0
        Me.label_nom.Text = "Label1"
        '
        'label_seconde
        '
        Me.label_seconde.AutoSize = True
        Me.label_seconde.BackColor = System.Drawing.Color.Transparent
        Me.label_seconde.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!)
        Me.label_seconde.ForeColor = System.Drawing.Color.White
        Me.label_seconde.Location = New System.Drawing.Point(98, 381)
        Me.label_seconde.Name = "label_seconde"
        Me.label_seconde.Size = New System.Drawing.Size(88, 17)
        Me.label_seconde.TabIndex = 2
        Me.label_seconde.Text = "seconde(s)"
        '
        'label_temps
        '
        Me.label_temps.AutoSize = True
        Me.label_temps.BackColor = System.Drawing.Color.Transparent
        Me.label_temps.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!)
        Me.label_temps.ForeColor = System.Drawing.Color.White
        Me.label_temps.Location = New System.Drawing.Point(36, 381)
        Me.label_temps.Name = "label_temps"
        Me.label_temps.Size = New System.Drawing.Size(57, 17)
        Me.label_temps.TabIndex = 3
        Me.label_temps.Text = "Label2"
        '
        'Timer1
        '
        Me.Timer1.Interval = 60000
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'button_abandonner
        '
        Me.button_abandonner.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.button_abandonner.FlatAppearance.BorderSize = 0
        Me.button_abandonner.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.button_abandonner.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.25!)
        Me.button_abandonner.ForeColor = System.Drawing.Color.White
        Me.button_abandonner.Location = New System.Drawing.Point(230, 472)
        Me.button_abandonner.Name = "button_abandonner"
        Me.button_abandonner.Size = New System.Drawing.Size(95, 39)
        Me.button_abandonner.TabIndex = 4
        Me.button_abandonner.Text = "STOP"
        Me.button_abandonner.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button2.Location = New System.Drawing.Point(4, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(40, 40)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.White
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button3.Location = New System.Drawing.Point(54, 4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(40, 40)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.White
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button4.Location = New System.Drawing.Point(158, 4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(40, 40)
        Me.Button4.TabIndex = 8
        Me.Button4.Text = "Button4"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.White
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button5.Location = New System.Drawing.Point(106, 4)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(40, 40)
        Me.Button5.TabIndex = 7
        Me.Button5.Text = "Button5"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.White
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button6.Location = New System.Drawing.Point(158, 54)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(40, 40)
        Me.Button6.TabIndex = 12
        Me.Button6.Text = "Button6"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.White
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button7.Location = New System.Drawing.Point(106, 54)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(40, 40)
        Me.Button7.TabIndex = 11
        Me.Button7.Text = "Button7"
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.White
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button8.Location = New System.Drawing.Point(54, 54)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(40, 40)
        Me.Button8.TabIndex = 10
        Me.Button8.Text = "Button8"
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.White
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button9.Location = New System.Drawing.Point(3, 54)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(40, 40)
        Me.Button9.TabIndex = 9
        Me.Button9.Text = "Button9"
        Me.Button9.UseVisualStyleBackColor = False
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.Color.White
        Me.Button10.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button10.Location = New System.Drawing.Point(158, 103)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(40, 40)
        Me.Button10.TabIndex = 16
        Me.Button10.Text = "Button10"
        Me.Button10.UseVisualStyleBackColor = False
        '
        'Button11
        '
        Me.Button11.BackColor = System.Drawing.Color.White
        Me.Button11.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button11.Location = New System.Drawing.Point(106, 103)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(40, 40)
        Me.Button11.TabIndex = 15
        Me.Button11.Text = "Button11"
        Me.Button11.UseVisualStyleBackColor = False
        '
        'Button12
        '
        Me.Button12.BackColor = System.Drawing.Color.White
        Me.Button12.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button12.Location = New System.Drawing.Point(54, 103)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(40, 40)
        Me.Button12.TabIndex = 14
        Me.Button12.Text = "Button12"
        Me.Button12.UseVisualStyleBackColor = False
        '
        'Button13
        '
        Me.Button13.BackColor = System.Drawing.Color.White
        Me.Button13.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button13.Location = New System.Drawing.Point(3, 103)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(40, 40)
        Me.Button13.TabIndex = 13
        Me.Button13.Text = "Button13"
        Me.Button13.UseVisualStyleBackColor = False
        '
        'Button14
        '
        Me.Button14.BackColor = System.Drawing.Color.White
        Me.Button14.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button14.Location = New System.Drawing.Point(158, 152)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(40, 40)
        Me.Button14.TabIndex = 20
        Me.Button14.Text = "Button14"
        Me.Button14.UseVisualStyleBackColor = False
        '
        'Button15
        '
        Me.Button15.BackColor = System.Drawing.Color.White
        Me.Button15.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button15.Location = New System.Drawing.Point(106, 152)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(40, 40)
        Me.Button15.TabIndex = 19
        Me.Button15.Text = "Button15"
        Me.Button15.UseVisualStyleBackColor = False
        '
        'Button16
        '
        Me.Button16.BackColor = System.Drawing.Color.White
        Me.Button16.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button16.Location = New System.Drawing.Point(54, 152)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(40, 40)
        Me.Button16.TabIndex = 18
        Me.Button16.Text = "Button16"
        Me.Button16.UseVisualStyleBackColor = False
        '
        'Button17
        '
        Me.Button17.BackColor = System.Drawing.Color.White
        Me.Button17.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button17.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button17.Location = New System.Drawing.Point(4, 152)
        Me.Button17.Name = "Button17"
        Me.Button17.Size = New System.Drawing.Size(40, 40)
        Me.Button17.TabIndex = 17
        Me.Button17.Text = "Button17"
        Me.Button17.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Button14)
        Me.Panel1.Controls.Add(Me.Button15)
        Me.Panel1.Controls.Add(Me.Button16)
        Me.Panel1.Controls.Add(Me.Button17)
        Me.Panel1.Controls.Add(Me.Button10)
        Me.Panel1.Controls.Add(Me.Button11)
        Me.Panel1.Controls.Add(Me.Button12)
        Me.Panel1.Controls.Add(Me.Button13)
        Me.Panel1.Controls.Add(Me.Button6)
        Me.Panel1.Controls.Add(Me.Button7)
        Me.Panel1.Controls.Add(Me.Button8)
        Me.Panel1.Controls.Add(Me.Button9)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(71, 43)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(204, 198)
        Me.Panel1.TabIndex = 21
        '
        'button_pause
        '
        Me.button_pause.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.button_pause.FlatAppearance.BorderSize = 0
        Me.button_pause.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.button_pause.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.button_pause.ForeColor = System.Drawing.Color.White
        Me.button_pause.Location = New System.Drawing.Point(36, 419)
        Me.button_pause.Name = "button_pause"
        Me.button_pause.Size = New System.Drawing.Size(147, 30)
        Me.button_pause.TabIndex = 22
        Me.button_pause.Text = "Button18"
        Me.button_pause.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.button_suivant)
        Me.Panel2.Controls.Add(Me.button_precedent)
        Me.Panel2.Location = New System.Drawing.Point(12, 290)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(309, 62)
        Me.Panel2.TabIndex = 28
        '
        'button_suivant
        '
        Me.button_suivant.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.button_suivant.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.button_suivant.FlatAppearance.BorderSize = 0
        Me.button_suivant.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.button_suivant.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.0!)
        Me.button_suivant.ForeColor = System.Drawing.Color.White
        Me.button_suivant.Location = New System.Drawing.Point(169, 12)
        Me.button_suivant.Name = "button_suivant"
        Me.button_suivant.Size = New System.Drawing.Size(94, 40)
        Me.button_suivant.TabIndex = 27
        Me.button_suivant.Text = "Résoudre"
        Me.button_suivant.UseVisualStyleBackColor = False
        '
        'button_precedent
        '
        Me.button_precedent.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.button_precedent.FlatAppearance.BorderSize = 0
        Me.button_precedent.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.button_precedent.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.0!)
        Me.button_precedent.ForeColor = System.Drawing.Color.White
        Me.button_precedent.Location = New System.Drawing.Point(50, 12)
        Me.button_precedent.Name = "button_precedent"
        Me.button_precedent.Size = New System.Drawing.Size(94, 40)
        Me.button_precedent.TabIndex = 24
        Me.button_precedent.Text = "Pas en arrière"
        Me.button_precedent.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(196, 244)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 12)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Label1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(71, 244)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 12)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "nombre de coups :"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(39, 263)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(260, 21)
        Me.ProgressBar1.TabIndex = 32
        Me.ProgressBar1.Value = 100
        '
        'Form_jeu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(340, 520)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.button_pause)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.button_abandonner)
        Me.Controls.Add(Me.label_temps)
        Me.Controls.Add(Me.label_seconde)
        Me.Controls.Add(Me.label_nom)
        Me.Name = "Form_jeu"
        Me.Text = "Form2"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents label_nom As Label
    Friend WithEvents label_seconde As Label
    Friend WithEvents label_temps As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Timer2 As Timer
    Friend WithEvents button_abandonner As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents Button11 As Button
    Friend WithEvents Button12 As Button
    Friend WithEvents Button13 As Button
    Friend WithEvents Button14 As Button
    Friend WithEvents Button15 As Button
    Friend WithEvents Button16 As Button
    Friend WithEvents Button17 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents button_pause As Button
    Friend WithEvents button_precedent As Button
    Friend WithEvents button_suivant As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ProgressBar1 As ProgressBar
End Class
