<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_enregistrersous
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
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.button_precedent = New System.Windows.Forms.Button()
        Me.button_suivant = New System.Windows.Forms.Button()
        Me.txtbox_chemin = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Top
        Me.WebBrowser1.Location = New System.Drawing.Point(0, 0)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(800, 389)
        Me.WebBrowser1.TabIndex = 0
        Me.WebBrowser1.Url = New System.Uri("C:\", System.UriKind.Absolute)
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.25!)
        Me.Button1.Location = New System.Drawing.Point(605, 400)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(183, 42)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'button_precedent
        '
        Me.button_precedent.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.25!)
        Me.button_precedent.Location = New System.Drawing.Point(12, 400)
        Me.button_precedent.Name = "button_precedent"
        Me.button_precedent.Size = New System.Drawing.Size(75, 42)
        Me.button_precedent.TabIndex = 2
        Me.button_precedent.Text = "Button2"
        Me.button_precedent.UseVisualStyleBackColor = True
        '
        'button_suivant
        '
        Me.button_suivant.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.25!)
        Me.button_suivant.Location = New System.Drawing.Point(93, 400)
        Me.button_suivant.Name = "button_suivant"
        Me.button_suivant.Size = New System.Drawing.Size(75, 42)
        Me.button_suivant.TabIndex = 3
        Me.button_suivant.Text = "Button3"
        Me.button_suivant.UseVisualStyleBackColor = True
        '
        'txtbox_chemin
        '
        Me.txtbox_chemin.Location = New System.Drawing.Point(187, 412)
        Me.txtbox_chemin.Name = "txtbox_chemin"
        Me.txtbox_chemin.Size = New System.Drawing.Size(153, 20)
        Me.txtbox_chemin.TabIndex = 4
        '
        'form_enregistrersous
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(29, Byte), Integer), CType(CType(93, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.txtbox_chemin)
        Me.Controls.Add(Me.button_suivant)
        Me.Controls.Add(Me.button_precedent)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Name = "form_enregistrersous"
        Me.Text = "Form5"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents Button1 As Button
    Friend WithEvents button_precedent As Button
    Friend WithEvents button_suivant As Button
    Friend WithEvents txtbox_chemin As TextBox
End Class
