<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_menu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_menu))
        Me.label_nom = New System.Windows.Forms.Label()
        Me.combobox_nom = New System.Windows.Forms.ComboBox()
        Me.button_quitter = New System.Windows.Forms.Button()
        Me.button_commencer = New System.Windows.Forms.Button()
        Me.button_score = New System.Windows.Forms.Button()
        Me.label_presentation = New System.Windows.Forms.Label()
        Me.button_option = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'label_nom
        '
        Me.label_nom.AutoSize = True
        Me.label_nom.BackColor = System.Drawing.Color.Transparent
        Me.label_nom.ForeColor = System.Drawing.Color.White
        Me.label_nom.Location = New System.Drawing.Point(98, 188)
        Me.label_nom.Name = "label_nom"
        Me.label_nom.Size = New System.Drawing.Size(43, 12)
        Me.label_nom.TabIndex = 0
        Me.label_nom.Text = "Label1"
        '
        'combobox_nom
        '
        Me.combobox_nom.FormattingEnabled = True
        Me.combobox_nom.Location = New System.Drawing.Point(147, 185)
        Me.combobox_nom.Name = "combobox_nom"
        Me.combobox_nom.Size = New System.Drawing.Size(202, 20)
        Me.combobox_nom.TabIndex = 1
        '
        'button_quitter
        '
        Me.button_quitter.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.button_quitter.FlatAppearance.BorderSize = 0
        Me.button_quitter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.button_quitter.ForeColor = System.Drawing.Color.White
        Me.button_quitter.Location = New System.Drawing.Point(260, 354)
        Me.button_quitter.Name = "button_quitter"
        Me.button_quitter.Size = New System.Drawing.Size(89, 29)
        Me.button_quitter.TabIndex = 3
        Me.button_quitter.Text = "Button2"
        Me.button_quitter.UseVisualStyleBackColor = False
        '
        'button_commencer
        '
        Me.button_commencer.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.button_commencer.Enabled = False
        Me.button_commencer.FlatAppearance.BorderSize = 0
        Me.button_commencer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.button_commencer.ForeColor = System.Drawing.Color.White
        Me.button_commencer.Location = New System.Drawing.Point(187, 242)
        Me.button_commencer.Name = "button_commencer"
        Me.button_commencer.Size = New System.Drawing.Size(162, 29)
        Me.button_commencer.TabIndex = 4
        Me.button_commencer.Text = "Button1"
        Me.button_commencer.UseVisualStyleBackColor = False
        '
        'button_score
        '
        Me.button_score.BackColor = System.Drawing.Color.Transparent
        Me.button_score.FlatAppearance.BorderSize = 0
        Me.button_score.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.button_score.ForeColor = System.Drawing.Color.White
        Me.button_score.Location = New System.Drawing.Point(19, 275)
        Me.button_score.Name = "button_score"
        Me.button_score.Size = New System.Drawing.Size(38, 32)
        Me.button_score.TabIndex = 5
        Me.button_score.UseVisualStyleBackColor = False
        '
        'label_presentation
        '
        Me.label_presentation.AutoSize = True
        Me.label_presentation.BackColor = System.Drawing.Color.Transparent
        Me.label_presentation.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.25!)
        Me.label_presentation.ForeColor = System.Drawing.Color.White
        Me.label_presentation.Location = New System.Drawing.Point(98, 219)
        Me.label_presentation.Name = "label_presentation"
        Me.label_presentation.Size = New System.Drawing.Size(32, 12)
        Me.label_presentation.TabIndex = 7
        Me.label_presentation.Text = "Label2"
        '
        'button_option
        '
        Me.button_option.BackColor = System.Drawing.Color.Transparent
        Me.button_option.FlatAppearance.BorderSize = 0
        Me.button_option.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.button_option.ForeColor = System.Drawing.Color.Transparent
        Me.button_option.Location = New System.Drawing.Point(19, 233)
        Me.button_option.Name = "button_option"
        Me.button_option.Size = New System.Drawing.Size(38, 36)
        Me.button_option.TabIndex = 8
        Me.button_option.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Location = New System.Drawing.Point(10, 371)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(47, 20)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Stop"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Form_menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(363, 399)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.button_option)
        Me.Controls.Add(Me.label_presentation)
        Me.Controls.Add(Me.button_score)
        Me.Controls.Add(Me.button_commencer)
        Me.Controls.Add(Me.button_quitter)
        Me.Controls.Add(Me.combobox_nom)
        Me.Controls.Add(Me.label_nom)
        Me.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Form_menu"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents label_nom As Label
    Friend WithEvents combobox_nom As ComboBox
    Friend WithEvents button_quitter As Button
    Friend WithEvents button_commencer As Button
    Friend WithEvents button_score As Button
    Friend WithEvents label_presentation As Label
    Friend WithEvents button_option As Button
    Friend WithEvents Button1 As Button
End Class
