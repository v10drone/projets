<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class form_option
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(form_option))
        Me.label_temps = New System.Windows.Forms.Label()
        Me.label_timer = New System.Windows.Forms.Label()
        Me.txtbox_temps = New System.Windows.Forms.TextBox()
        Me.label_seconde = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rb_non1 = New System.Windows.Forms.RadioButton()
        Me.rb_oui1 = New System.Windows.Forms.RadioButton()
        Me.button_enregistrer = New System.Windows.Forms.Button()
        Me.label_btnpause = New System.Windows.Forms.Label()
        Me.rb_oui2 = New System.Windows.Forms.RadioButton()
        Me.rb_non2 = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rb_non3 = New System.Windows.Forms.RadioButton()
        Me.rb_oui3 = New System.Windows.Forms.RadioButton()
        Me.label_btnsolution = New System.Windows.Forms.Label()
        Me.combobox_chemin = New System.Windows.Forms.ComboBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.label_sauvegarde = New System.Windows.Forms.Label()
        Me.button_points = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.listbox_type = New System.Windows.Forms.ListBox()
        Me.button_plus = New System.Windows.Forms.Button()
        Me.label_type = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.SuspendLayout()
        '
        'label_temps
        '
        Me.label_temps.AutoSize = True
        Me.label_temps.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_temps.ForeColor = System.Drawing.Color.White
        Me.label_temps.Location = New System.Drawing.Point(19, 26)
        Me.label_temps.Name = "label_temps"
        Me.label_temps.Size = New System.Drawing.Size(42, 12)
        Me.label_temps.TabIndex = 0
        Me.label_temps.Text = "Temps"
        '
        'label_timer
        '
        Me.label_timer.AutoSize = True
        Me.label_timer.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_timer.ForeColor = System.Drawing.Color.White
        Me.label_timer.Location = New System.Drawing.Point(19, 95)
        Me.label_timer.Name = "label_timer"
        Me.label_timer.Size = New System.Drawing.Size(43, 12)
        Me.label_timer.TabIndex = 3
        Me.label_timer.Text = "Timer :"
        '
        'txtbox_temps
        '
        Me.txtbox_temps.Location = New System.Drawing.Point(74, 91)
        Me.txtbox_temps.Name = "txtbox_temps"
        Me.txtbox_temps.Size = New System.Drawing.Size(81, 20)
        Me.txtbox_temps.TabIndex = 4
        '
        'label_seconde
        '
        Me.label_seconde.AutoSize = True
        Me.label_seconde.ForeColor = System.Drawing.Color.White
        Me.label_seconde.Location = New System.Drawing.Point(161, 95)
        Me.label_seconde.Name = "label_seconde"
        Me.label_seconde.Size = New System.Drawing.Size(59, 13)
        Me.label_seconde.TabIndex = 5
        Me.label_seconde.Text = "seconde(s)"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.rb_non1)
        Me.Panel1.Controls.Add(Me.rb_oui1)
        Me.Panel1.Controls.Add(Me.label_seconde)
        Me.Panel1.Controls.Add(Me.txtbox_temps)
        Me.Panel1.Controls.Add(Me.label_timer)
        Me.Panel1.Controls.Add(Me.label_temps)
        Me.Panel1.Location = New System.Drawing.Point(16, 30)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(236, 125)
        Me.Panel1.TabIndex = 6
        '
        'rb_non1
        '
        Me.rb_non1.AutoSize = True
        Me.rb_non1.ForeColor = System.Drawing.Color.White
        Me.rb_non1.Location = New System.Drawing.Point(84, 36)
        Me.rb_non1.Name = "rb_non1"
        Me.rb_non1.Size = New System.Drawing.Size(45, 17)
        Me.rb_non1.TabIndex = 8
        Me.rb_non1.TabStop = True
        Me.rb_non1.Text = "Non"
        Me.rb_non1.UseVisualStyleBackColor = True
        '
        'rb_oui1
        '
        Me.rb_oui1.AutoSize = True
        Me.rb_oui1.ForeColor = System.Drawing.Color.White
        Me.rb_oui1.Location = New System.Drawing.Point(84, 13)
        Me.rb_oui1.Name = "rb_oui1"
        Me.rb_oui1.Size = New System.Drawing.Size(41, 17)
        Me.rb_oui1.TabIndex = 7
        Me.rb_oui1.TabStop = True
        Me.rb_oui1.Text = "Oui"
        Me.rb_oui1.UseVisualStyleBackColor = True
        '
        'button_enregistrer
        '
        Me.button_enregistrer.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.button_enregistrer.FlatAppearance.BorderSize = 0
        Me.button_enregistrer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.button_enregistrer.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.25!)
        Me.button_enregistrer.ForeColor = System.Drawing.Color.White
        Me.button_enregistrer.Location = New System.Drawing.Point(446, 387)
        Me.button_enregistrer.Name = "button_enregistrer"
        Me.button_enregistrer.Size = New System.Drawing.Size(179, 37)
        Me.button_enregistrer.TabIndex = 7
        Me.button_enregistrer.Text = "Enregistrer"
        Me.button_enregistrer.UseVisualStyleBackColor = False
        '
        'label_btnpause
        '
        Me.label_btnpause.AutoSize = True
        Me.label_btnpause.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_btnpause.ForeColor = System.Drawing.Color.White
        Me.label_btnpause.Location = New System.Drawing.Point(29, 32)
        Me.label_btnpause.Name = "label_btnpause"
        Me.label_btnpause.Size = New System.Drawing.Size(167, 12)
        Me.label_btnpause.TabIndex = 8
        Me.label_btnpause.Text = "Activation d'un bouton pause"
        '
        'rb_oui2
        '
        Me.rb_oui2.AutoSize = True
        Me.rb_oui2.ForeColor = System.Drawing.Color.White
        Me.rb_oui2.Location = New System.Drawing.Point(48, 71)
        Me.rb_oui2.Name = "rb_oui2"
        Me.rb_oui2.Size = New System.Drawing.Size(41, 17)
        Me.rb_oui2.TabIndex = 9
        Me.rb_oui2.TabStop = True
        Me.rb_oui2.Text = "Oui"
        Me.rb_oui2.UseVisualStyleBackColor = True
        '
        'rb_non2
        '
        Me.rb_non2.AutoSize = True
        Me.rb_non2.ForeColor = System.Drawing.Color.White
        Me.rb_non2.Location = New System.Drawing.Point(133, 71)
        Me.rb_non2.Name = "rb_non2"
        Me.rb_non2.Size = New System.Drawing.Size(43, 17)
        Me.rb_non2.TabIndex = 10
        Me.rb_non2.TabStop = True
        Me.rb_non2.Text = "non"
        Me.rb_non2.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.rb_non2)
        Me.Panel2.Controls.Add(Me.rb_oui2)
        Me.Panel2.Controls.Add(Me.label_btnpause)
        Me.Panel2.Location = New System.Drawing.Point(16, 170)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(236, 107)
        Me.Panel2.TabIndex = 11
        '
        'rb_non3
        '
        Me.rb_non3.AutoSize = True
        Me.rb_non3.BackColor = System.Drawing.Color.Transparent
        Me.rb_non3.ForeColor = System.Drawing.Color.White
        Me.rb_non3.Location = New System.Drawing.Point(99, 4)
        Me.rb_non3.Name = "rb_non3"
        Me.rb_non3.Size = New System.Drawing.Size(43, 17)
        Me.rb_non3.TabIndex = 10
        Me.rb_non3.TabStop = True
        Me.rb_non3.Text = "non"
        Me.rb_non3.UseVisualStyleBackColor = False
        '
        'rb_oui3
        '
        Me.rb_oui3.AutoSize = True
        Me.rb_oui3.BackColor = System.Drawing.Color.Transparent
        Me.rb_oui3.ForeColor = System.Drawing.Color.White
        Me.rb_oui3.Location = New System.Drawing.Point(14, 4)
        Me.rb_oui3.Name = "rb_oui3"
        Me.rb_oui3.Size = New System.Drawing.Size(41, 17)
        Me.rb_oui3.TabIndex = 9
        Me.rb_oui3.TabStop = True
        Me.rb_oui3.Text = "Oui"
        Me.rb_oui3.UseVisualStyleBackColor = False
        '
        'label_btnsolution
        '
        Me.label_btnsolution.AutoSize = True
        Me.label_btnsolution.BackColor = System.Drawing.Color.Transparent
        Me.label_btnsolution.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_btnsolution.ForeColor = System.Drawing.Color.White
        Me.label_btnsolution.Location = New System.Drawing.Point(30, 318)
        Me.label_btnsolution.Name = "label_btnsolution"
        Me.label_btnsolution.Size = New System.Drawing.Size(208, 12)
        Me.label_btnsolution.TabIndex = 8
        Me.label_btnsolution.Text = "Activation d'un bouton de précedent"
        '
        'combobox_chemin
        '
        Me.combobox_chemin.FormattingEnabled = True
        Me.combobox_chemin.Location = New System.Drawing.Point(21, 36)
        Me.combobox_chemin.Name = "combobox_chemin"
        Me.combobox_chemin.Size = New System.Drawing.Size(164, 21)
        Me.combobox_chemin.TabIndex = 13
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.Controls.Add(Me.label_sauvegarde)
        Me.Panel4.Controls.Add(Me.combobox_chemin)
        Me.Panel4.Location = New System.Drawing.Point(286, 31)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(236, 68)
        Me.Panel4.TabIndex = 12
        '
        'label_sauvegarde
        '
        Me.label_sauvegarde.AutoSize = True
        Me.label_sauvegarde.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_sauvegarde.ForeColor = System.Drawing.Color.White
        Me.label_sauvegarde.Location = New System.Drawing.Point(59, 15)
        Me.label_sauvegarde.Name = "label_sauvegarde"
        Me.label_sauvegarde.Size = New System.Drawing.Size(133, 12)
        Me.label_sauvegarde.TabIndex = 8
        Me.label_sauvegarde.Text = "Chemin de sauvegarde"
        '
        'button_points
        '
        Me.button_points.BackColor = System.Drawing.Color.White
        Me.button_points.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!)
        Me.button_points.ForeColor = System.Drawing.Color.Black
        Me.button_points.Location = New System.Drawing.Point(477, 67)
        Me.button_points.Name = "button_points"
        Me.button_points.Size = New System.Drawing.Size(32, 21)
        Me.button_points.TabIndex = 13
        Me.button_points.Text = "..."
        Me.button_points.UseVisualStyleBackColor = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Transparent
        Me.Panel5.Controls.Add(Me.listbox_type)
        Me.Panel5.Controls.Add(Me.button_plus)
        Me.Panel5.Controls.Add(Me.label_type)
        Me.Panel5.Location = New System.Drawing.Point(286, 108)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(236, 82)
        Me.Panel5.TabIndex = 14
        '
        'listbox_type
        '
        Me.listbox_type.FormattingEnabled = True
        Me.listbox_type.Location = New System.Drawing.Point(12, 31)
        Me.listbox_type.Name = "listbox_type"
        Me.listbox_type.Size = New System.Drawing.Size(173, 43)
        Me.listbox_type.TabIndex = 15
        '
        'button_plus
        '
        Me.button_plus.BackColor = System.Drawing.Color.White
        Me.button_plus.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!)
        Me.button_plus.ForeColor = System.Drawing.Color.Black
        Me.button_plus.Location = New System.Drawing.Point(191, 45)
        Me.button_plus.Name = "button_plus"
        Me.button_plus.Size = New System.Drawing.Size(32, 21)
        Me.button_plus.TabIndex = 15
        Me.button_plus.Text = "+"
        Me.button_plus.UseVisualStyleBackColor = False
        '
        'label_type
        '
        Me.label_type.AutoSize = True
        Me.label_type.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_type.ForeColor = System.Drawing.Color.White
        Me.label_type.Location = New System.Drawing.Point(79, 12)
        Me.label_type.Name = "label_type"
        Me.label_type.Size = New System.Drawing.Size(90, 12)
        Me.label_type.TabIndex = 8
        Me.label_type.Text = "Type de Taquin"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Transparent
        Me.Panel6.Controls.Add(Me.RadioButton1)
        Me.Panel6.Controls.Add(Me.RadioButton2)
        Me.Panel6.Controls.Add(Me.Label1)
        Me.Panel6.Location = New System.Drawing.Point(286, 200)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(236, 61)
        Me.Panel6.TabIndex = 13
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.ForeColor = System.Drawing.Color.White
        Me.RadioButton1.Location = New System.Drawing.Point(133, 36)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(43, 17)
        Me.RadioButton1.TabIndex = 10
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "non"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.ForeColor = System.Drawing.Color.White
        Me.RadioButton2.Location = New System.Drawing.Point(48, 36)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(41, 17)
        Me.RadioButton2.TabIndex = 9
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Oui"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(28, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(181, 12)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Affichage d'une barre du temps"
        '
        'ColorDialog1
        '
        Me.ColorDialog1.AnyColor = True
        Me.ColorDialog1.Color = System.Drawing.Color.White
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(550, 169)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(89, 45)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "Couleur du taquin"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'TrackBar1
        '
        Me.TrackBar1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TrackBar1.Location = New System.Drawing.Point(286, 317)
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(236, 45)
        Me.TrackBar1.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(382, 292)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Difficulté"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(270, 296)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Facile"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(499, 297)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Difficile"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(35, 383)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(190, 12)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Activation d'un bouton de suivant"
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton4.ForeColor = System.Drawing.Color.White
        Me.RadioButton4.Location = New System.Drawing.Point(17, 5)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(41, 17)
        Me.RadioButton4.TabIndex = 9
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "Oui"
        Me.RadioButton4.UseVisualStyleBackColor = False
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton3.ForeColor = System.Drawing.Color.White
        Me.RadioButton3.Location = New System.Drawing.Point(102, 5)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(43, 17)
        Me.RadioButton3.TabIndex = 10
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "non"
        Me.RadioButton3.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.rb_oui3)
        Me.Panel3.Controls.Add(Me.rb_non3)
        Me.Panel3.Location = New System.Drawing.Point(50, 341)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(161, 32)
        Me.Panel3.TabIndex = 20
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Transparent
        Me.Panel7.Controls.Add(Me.RadioButton4)
        Me.Panel7.Controls.Add(Me.RadioButton3)
        Me.Panel7.Location = New System.Drawing.Point(47, 402)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(164, 33)
        Me.Panel7.TabIndex = 21
        '
        'form_option
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(660, 450)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.label_btnsolution)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TrackBar1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.button_points)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.button_enregistrer)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "form_option"
        Me.Text = "Form4"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents label_temps As Label
    Friend WithEvents label_timer As Label
    Friend WithEvents txtbox_temps As TextBox
    Friend WithEvents label_seconde As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents rb_non1 As RadioButton
    Friend WithEvents rb_oui1 As RadioButton
    Friend WithEvents button_enregistrer As Button
    Friend WithEvents label_btnpause As Label
    Friend WithEvents rb_oui2 As RadioButton
    Friend WithEvents rb_non2 As RadioButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents rb_non3 As RadioButton
    Friend WithEvents rb_oui3 As RadioButton
    Friend WithEvents label_btnsolution As Label
    Friend WithEvents combobox_chemin As ComboBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents label_sauvegarde As Label
    Friend WithEvents button_points As Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents label_type As Label
    Friend WithEvents button_plus As Button
    Friend WithEvents listbox_type As ListBox
    Friend WithEvents Panel6 As Panel
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents Button1 As Button
    Friend WithEvents TrackBar1 As TrackBar
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents RadioButton4 As RadioButton
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel7 As Panel
End Class
