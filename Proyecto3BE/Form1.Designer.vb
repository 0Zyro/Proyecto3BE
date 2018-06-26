<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list. hola
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.LabelUser = New System.Windows.Forms.Label()
        Me.TextBoxUser = New System.Windows.Forms.TextBox()
        Me.LabelPasswd = New System.Windows.Forms.Label()
        Me.TextBoxPasswd = New System.Windows.Forms.TextBox()
        Me.LabelInfo = New System.Windows.Forms.Label()
        Me.ButtonAceptar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LabelUser
        '
        Me.LabelUser.AutoSize = True
        Me.LabelUser.Location = New System.Drawing.Point(13, 13)
        Me.LabelUser.Name = "LabelUser"
        Me.LabelUser.Size = New System.Drawing.Size(46, 13)
        Me.LabelUser.TabIndex = 0
        Me.LabelUser.Text = "Usuario:"
        '
        'TextBoxUser
        '
        Me.TextBoxUser.Location = New System.Drawing.Point(12, 29)
        Me.TextBoxUser.Name = "TextBoxUser"
        Me.TextBoxUser.Size = New System.Drawing.Size(244, 20)
        Me.TextBoxUser.TabIndex = 1
        '
        'LabelPasswd
        '
        Me.LabelPasswd.AutoSize = True
        Me.LabelPasswd.Location = New System.Drawing.Point(13, 57)
        Me.LabelPasswd.Name = "LabelPasswd"
        Me.LabelPasswd.Size = New System.Drawing.Size(64, 13)
        Me.LabelPasswd.TabIndex = 2
        Me.LabelPasswd.Text = "Contraseña:"
        '
        'TextBoxPasswd
        '
        Me.TextBoxPasswd.Location = New System.Drawing.Point(12, 73)
        Me.TextBoxPasswd.Name = "TextBoxPasswd"
        Me.TextBoxPasswd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(43)
        Me.TextBoxPasswd.Size = New System.Drawing.Size(244, 20)
        Me.TextBoxPasswd.TabIndex = 3
        '
        'LabelInfo
        '
        Me.LabelInfo.AutoSize = True
        Me.LabelInfo.Location = New System.Drawing.Point(13, 115)
        Me.LabelInfo.Name = "LabelInfo"
        Me.LabelInfo.Size = New System.Drawing.Size(0, 13)
        Me.LabelInfo.TabIndex = 4
        '
        'ButtonAceptar
        '
        Me.ButtonAceptar.Location = New System.Drawing.Point(181, 105)
        Me.ButtonAceptar.Name = "ButtonAceptar"
        Me.ButtonAceptar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonAceptar.TabIndex = 5
        Me.ButtonAceptar.Text = "Aceptar"
        Me.ButtonAceptar.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(268, 134)
        Me.Controls.Add(Me.ButtonAceptar)
        Me.Controls.Add(Me.LabelInfo)
        Me.Controls.Add(Me.TextBoxPasswd)
        Me.Controls.Add(Me.LabelPasswd)
        Me.Controls.Add(Me.TextBoxUser)
        Me.Controls.Add(Me.LabelUser)
        Me.MaximumSize = New System.Drawing.Size(284, 172)
        Me.MinimumSize = New System.Drawing.Size(284, 172)
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingresar"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelUser As System.Windows.Forms.Label
    Friend WithEvents TextBoxUser As System.Windows.Forms.TextBox
    Friend WithEvents LabelPasswd As System.Windows.Forms.Label
    Friend WithEvents TextBoxPasswd As System.Windows.Forms.TextBox
    Friend WithEvents LabelInfo As System.Windows.Forms.Label
    Friend WithEvents ButtonAceptar As System.Windows.Forms.Button

End Class
