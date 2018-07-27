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
        Me.LabelInfo = New System.Windows.Forms.Label()
        Me.BotonAceptar = New System.Windows.Forms.Button()
        Me.BotonVolver = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LabelUser
        '
        Me.LabelUser.AutoSize = True
        Me.LabelUser.Location = New System.Drawing.Point(13, 13)
        Me.LabelUser.Name = "LabelUser"
        Me.LabelUser.Size = New System.Drawing.Size(65, 13)
        Me.LabelUser.TabIndex = 0
        Me.LabelUser.Text = "Usuario (CI):"
        '
        'TextBoxUser
        '
        Me.TextBoxUser.Location = New System.Drawing.Point(12, 38)
        Me.TextBoxUser.Name = "TextBoxUser"
        Me.TextBoxUser.Size = New System.Drawing.Size(244, 20)
        Me.TextBoxUser.TabIndex = 1
        '
        'LabelInfo
        '
        Me.LabelInfo.AutoSize = True
        Me.LabelInfo.Location = New System.Drawing.Point(13, 61)
        Me.LabelInfo.Name = "LabelInfo"
        Me.LabelInfo.Size = New System.Drawing.Size(0, 13)
        Me.LabelInfo.TabIndex = 4
        '
        'BotonAceptar
        '
        Me.BotonAceptar.Location = New System.Drawing.Point(181, 86)
        Me.BotonAceptar.Name = "BotonAceptar"
        Me.BotonAceptar.Size = New System.Drawing.Size(75, 23)
        Me.BotonAceptar.TabIndex = 5
        Me.BotonAceptar.Text = ">>"
        Me.BotonAceptar.UseVisualStyleBackColor = True
        '
        'BotonVolver
        '
        Me.BotonVolver.Location = New System.Drawing.Point(12, 86)
        Me.BotonVolver.Name = "BotonVolver"
        Me.BotonVolver.Size = New System.Drawing.Size(75, 23)
        Me.BotonVolver.TabIndex = 6
        Me.BotonVolver.Text = "<<"
        Me.BotonVolver.UseVisualStyleBackColor = True
        Me.BotonVolver.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(268, 112)
        Me.Controls.Add(Me.BotonVolver)
        Me.Controls.Add(Me.BotonAceptar)
        Me.Controls.Add(Me.LabelInfo)
        Me.Controls.Add(Me.TextBoxUser)
        Me.Controls.Add(Me.LabelUser)
        Me.MaximumSize = New System.Drawing.Size(284, 150)
        Me.MinimumSize = New System.Drawing.Size(284, 150)
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingresar"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelUser As System.Windows.Forms.Label
    Friend WithEvents TextBoxUser As System.Windows.Forms.TextBox
    Friend WithEvents LabelInfo As System.Windows.Forms.Label
    Friend WithEvents BotonAceptar As System.Windows.Forms.Button
    Friend WithEvents BotonVolver As System.Windows.Forms.Button

End Class
