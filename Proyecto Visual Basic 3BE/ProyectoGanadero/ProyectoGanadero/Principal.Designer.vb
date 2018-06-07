<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPrincipal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.Muestra = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VentasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClientesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Texb1 = New System.Windows.Forms.TextBox()
        Me.Texb2 = New System.Windows.Forms.TextBox()
        Me.Texb3 = New System.Windows.Forms.TextBox()
        Me.Texb4 = New System.Windows.Forms.TextBox()
        Me.Texb5 = New System.Windows.Forms.TextBox()
        Me.Texb9 = New System.Windows.Forms.TextBox()
        Me.Texb8 = New System.Windows.Forms.TextBox()
        Me.Texb7 = New System.Windows.Forms.TextBox()
        Me.Texb6 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        CType(Me.Muestra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Muestra
        '
        Me.Muestra.AllowUserToAddRows = False
        Me.Muestra.AllowUserToDeleteRows = False
        Me.Muestra.AllowUserToResizeColumns = False
        Me.Muestra.AllowUserToResizeRows = False
        Me.Muestra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Muestra.Location = New System.Drawing.Point(30, 61)
        Me.Muestra.Name = "Muestra"
        Me.Muestra.ReadOnly = True
        Me.Muestra.RowHeadersVisible = False
        Me.Muestra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Muestra.Size = New System.Drawing.Size(943, 287)
        Me.Muestra.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(41, 545)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(163, 31)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Agregar Registro"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Menu
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Image = Global.ProyectoGanadero.My.Resources.Resources.rosadito
        Me.Label1.Location = New System.Drawing.Point(313, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(291, 21)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Tabla de Control y Regristro del Ganado"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(236, 545)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(169, 32)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Modificar Registro"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.Control
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(435, 545)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(160, 32)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = "Eliminar Registro"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.MenuStrip1.BackgroundImage = Global.ProyectoGanadero.My.Resources.Resources.images2
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClientesToolStripMenuItem, Me.VentasToolStripMenuItem, Me.ClientesToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(995, 24)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ClientesToolStripMenuItem
        '
        Me.ClientesToolStripMenuItem.BackgroundImage = Global.ProyectoGanadero.My.Resources.Resources.images3
        Me.ClientesToolStripMenuItem.Name = "ClientesToolStripMenuItem"
        Me.ClientesToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.ClientesToolStripMenuItem.Text = "Clientes"
        '
        'VentasToolStripMenuItem
        '
        Me.VentasToolStripMenuItem.BackgroundImage = Global.ProyectoGanadero.My.Resources.Resources.images3
        Me.VentasToolStripMenuItem.Name = "VentasToolStripMenuItem"
        Me.VentasToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.VentasToolStripMenuItem.Text = "Ventas"
        '
        'ClientesToolStripMenuItem1
        '
        Me.ClientesToolStripMenuItem1.BackgroundImage = Global.ProyectoGanadero.My.Resources.Resources.images3
        Me.ClientesToolStripMenuItem1.Name = "ClientesToolStripMenuItem1"
        Me.ClientesToolStripMenuItem1.Size = New System.Drawing.Size(61, 20)
        Me.ClientesToolStripMenuItem1.Text = "Clientes"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(77, 375)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Raza"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(358, 375)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Sexo"
        '
        'Texb1
        '
        Me.Texb1.Location = New System.Drawing.Point(128, 375)
        Me.Texb1.Name = "Texb1"
        Me.Texb1.Size = New System.Drawing.Size(100, 20)
        Me.Texb1.TabIndex = 14
        '
        'Texb2
        '
        Me.Texb2.Location = New System.Drawing.Point(128, 409)
        Me.Texb2.Name = "Texb2"
        Me.Texb2.Size = New System.Drawing.Size(100, 20)
        Me.Texb2.TabIndex = 15
        '
        'Texb3
        '
        Me.Texb3.Location = New System.Drawing.Point(128, 443)
        Me.Texb3.Name = "Texb3"
        Me.Texb3.Size = New System.Drawing.Size(100, 20)
        Me.Texb3.TabIndex = 16
        '
        'Texb4
        '
        Me.Texb4.Location = New System.Drawing.Point(128, 478)
        Me.Texb4.Name = "Texb4"
        Me.Texb4.Size = New System.Drawing.Size(100, 20)
        Me.Texb4.TabIndex = 17
        '
        'Texb5
        '
        Me.Texb5.Location = New System.Drawing.Point(399, 372)
        Me.Texb5.Name = "Texb5"
        Me.Texb5.Size = New System.Drawing.Size(100, 20)
        Me.Texb5.TabIndex = 18
        '
        'Texb9
        '
        Me.Texb9.Location = New System.Drawing.Point(624, 368)
        Me.Texb9.Name = "Texb9"
        Me.Texb9.Size = New System.Drawing.Size(268, 20)
        Me.Texb9.TabIndex = 19
        '
        'Texb8
        '
        Me.Texb8.Location = New System.Drawing.Point(400, 474)
        Me.Texb8.Name = "Texb8"
        Me.Texb8.Size = New System.Drawing.Size(100, 20)
        Me.Texb8.TabIndex = 20
        '
        'Texb7
        '
        Me.Texb7.Location = New System.Drawing.Point(400, 439)
        Me.Texb7.Name = "Texb7"
        Me.Texb7.Size = New System.Drawing.Size(100, 20)
        Me.Texb7.TabIndex = 21
        '
        'Texb6
        '
        Me.Texb6.Location = New System.Drawing.Point(400, 402)
        Me.Texb6.Name = "Texb6"
        Me.Texb6.Size = New System.Drawing.Size(100, 20)
        Me.Texb6.TabIndex = 22
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(558, 371)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Estado"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(297, 478)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 13)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Precio de venta"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(288, 443)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(106, 13)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "Precio de compra"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(358, 405)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 13)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "Edad"
        '
        'FormPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.HighlightText
        Me.BackgroundImage = Global.ProyectoGanadero.My.Resources.Resources.images2
        Me.ClientSize = New System.Drawing.Size(995, 598)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Texb6)
        Me.Controls.Add(Me.Texb7)
        Me.Controls.Add(Me.Texb8)
        Me.Controls.Add(Me.Texb9)
        Me.Controls.Add(Me.Texb5)
        Me.Controls.Add(Me.Texb4)
        Me.Controls.Add(Me.Texb3)
        Me.Controls.Add(Me.Texb2)
        Me.Controls.Add(Me.Texb1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Muestra)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gestion y control de la Empresa"
        CType(Me.Muestra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Muestra As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ClientesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VentasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClientesToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Texb1 As System.Windows.Forms.TextBox
    Friend WithEvents Texb2 As System.Windows.Forms.TextBox
    Friend WithEvents Texb3 As System.Windows.Forms.TextBox
    Friend WithEvents Texb4 As System.Windows.Forms.TextBox
    Friend WithEvents Texb5 As System.Windows.Forms.TextBox
    Friend WithEvents Texb9 As System.Windows.Forms.TextBox
    Friend WithEvents Texb8 As System.Windows.Forms.TextBox
    Friend WithEvents Texb7 As System.Windows.Forms.TextBox
    Friend WithEvents Texb6 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label

End Class
