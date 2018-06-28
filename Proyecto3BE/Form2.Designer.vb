<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.PanelUsuario = New System.Windows.Forms.Panel()
        Me.TabbedPane = New System.Windows.Forms.TabControl()
        Me.TabGanado = New System.Windows.Forms.TabPage()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TabVentas = New System.Windows.Forms.TabPage()
        Me.TabCompras = New System.Windows.Forms.TabPage()
        Me.TabClientes = New System.Windows.Forms.TabPage()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Labeltelcliente = New System.Windows.Forms.Label()
        Me.Labeldireccioncliente = New System.Windows.Forms.Label()
        Me.LabelNombreyApellidocliente = New System.Windows.Forms.Label()
        Me.LabelCedulacliente = New System.Windows.Forms.Label()
        Me.DataGridViewClientes = New System.Windows.Forms.DataGridView()
        Me.Buttonmodificarcliente = New System.Windows.Forms.Button()
        Me.Buttonseleccionarcliente = New System.Windows.Forms.Button()
        Me.Buttonquitarcliente = New System.Windows.Forms.Button()
        Me.Buttonagregarcliente = New System.Windows.Forms.Button()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabbedPane.SuspendLayout()
        Me.TabGanado.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabClientes.SuspendLayout()
        CType(Me.DataGridViewClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelUsuario
        '
        Me.PanelUsuario.Location = New System.Drawing.Point(0, 0)
        Me.PanelUsuario.Name = "PanelUsuario"
        Me.PanelUsuario.Size = New System.Drawing.Size(100, 460)
        Me.PanelUsuario.TabIndex = 0
        '
        'TabbedPane
        '
        Me.TabbedPane.Controls.Add(Me.TabGanado)
        Me.TabbedPane.Controls.Add(Me.TabVentas)
        Me.TabbedPane.Controls.Add(Me.TabCompras)
        Me.TabbedPane.Controls.Add(Me.TabClientes)
        Me.TabbedPane.Controls.Add(Me.TabPage1)
        Me.TabbedPane.Location = New System.Drawing.Point(101, 0)
        Me.TabbedPane.Name = "TabbedPane"
        Me.TabbedPane.SelectedIndex = 0
        Me.TabbedPane.Size = New System.Drawing.Size(685, 463)
        Me.TabbedPane.TabIndex = 1
        '
        'TabGanado
        '
        Me.TabGanado.Controls.Add(Me.Button3)
        Me.TabGanado.Controls.Add(Me.Button2)
        Me.TabGanado.Controls.Add(Me.Button1)
        Me.TabGanado.Controls.Add(Me.TextBox5)
        Me.TabGanado.Controls.Add(Me.TextBox4)
        Me.TabGanado.Controls.Add(Me.Label5)
        Me.TabGanado.Controls.Add(Me.Label4)
        Me.TabGanado.Controls.Add(Me.Label3)
        Me.TabGanado.Controls.Add(Me.TextBox3)
        Me.TabGanado.Controls.Add(Me.TextBox2)
        Me.TabGanado.Controls.Add(Me.Label2)
        Me.TabGanado.Controls.Add(Me.TextBox1)
        Me.TabGanado.Controls.Add(Me.Label1)
        Me.TabGanado.Controls.Add(Me.DataGridView1)
        Me.TabGanado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabGanado.Location = New System.Drawing.Point(4, 22)
        Me.TabGanado.Name = "TabGanado"
        Me.TabGanado.Padding = New System.Windows.Forms.Padding(3)
        Me.TabGanado.Size = New System.Drawing.Size(677, 437)
        Me.TabGanado.TabIndex = 0
        Me.TabGanado.Text = "Ganado"
        Me.TabGanado.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(448, 323)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 13
        Me.Button3.Text = "Eliminar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(448, 268)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 12
        Me.Button2.Text = "Modificar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(446, 215)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Agregar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(516, 162)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(156, 20)
        Me.TextBox5.TabIndex = 10
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(516, 129)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(47, 20)
        Me.TextBox4.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(438, 162)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Estado"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(438, 129)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Peso inicial"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(437, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Edad"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(516, 97)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(47, 20)
        Me.TextBox3.TabIndex = 5
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(516, 65)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(62, 20)
        Me.TextBox2.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(437, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Sexo"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(516, 32)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(436, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Raza"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(6, 6)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(412, 428)
        Me.DataGridView1.TabIndex = 0
        '
        'TabVentas
        '
        Me.TabVentas.Location = New System.Drawing.Point(4, 22)
        Me.TabVentas.Name = "TabVentas"
        Me.TabVentas.Padding = New System.Windows.Forms.Padding(3)
        Me.TabVentas.Size = New System.Drawing.Size(677, 437)
        Me.TabVentas.TabIndex = 1
        Me.TabVentas.Text = "Ventas"
        Me.TabVentas.UseVisualStyleBackColor = True
        '
        'TabCompras
        '
        Me.TabCompras.Location = New System.Drawing.Point(4, 22)
        Me.TabCompras.Name = "TabCompras"
        Me.TabCompras.Padding = New System.Windows.Forms.Padding(3)
        Me.TabCompras.Size = New System.Drawing.Size(677, 437)
        Me.TabCompras.TabIndex = 2
        Me.TabCompras.Text = "Compras"
        Me.TabCompras.UseVisualStyleBackColor = True
        '
        'TabClientes
        '
        Me.TabClientes.Controls.Add(Me.TextBox9)
        Me.TabClientes.Controls.Add(Me.TextBox8)
        Me.TabClientes.Controls.Add(Me.TextBox7)
        Me.TabClientes.Controls.Add(Me.TextBox6)
        Me.TabClientes.Controls.Add(Me.Labeltelcliente)
        Me.TabClientes.Controls.Add(Me.Labeldireccioncliente)
        Me.TabClientes.Controls.Add(Me.LabelNombreyApellidocliente)
        Me.TabClientes.Controls.Add(Me.LabelCedulacliente)
        Me.TabClientes.Controls.Add(Me.DataGridViewClientes)
        Me.TabClientes.Controls.Add(Me.Buttonmodificarcliente)
        Me.TabClientes.Controls.Add(Me.Buttonseleccionarcliente)
        Me.TabClientes.Controls.Add(Me.Buttonquitarcliente)
        Me.TabClientes.Controls.Add(Me.Buttonagregarcliente)
        Me.TabClientes.Location = New System.Drawing.Point(4, 22)
        Me.TabClientes.Name = "TabClientes"
        Me.TabClientes.Padding = New System.Windows.Forms.Padding(3)
        Me.TabClientes.Size = New System.Drawing.Size(677, 437)
        Me.TabClientes.TabIndex = 3
        Me.TabClientes.Text = "Clientes"
        Me.TabClientes.UseVisualStyleBackColor = True
        '
        'TextBox9
        '
        Me.TextBox9.Location = New System.Drawing.Point(537, 120)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(100, 20)
        Me.TextBox9.TabIndex = 12
        '
        'TextBox8
        '
        Me.TextBox8.Location = New System.Drawing.Point(537, 94)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(100, 20)
        Me.TextBox8.TabIndex = 11
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(537, 69)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(100, 20)
        Me.TextBox7.TabIndex = 10
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(537, 43)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(100, 20)
        Me.TextBox6.TabIndex = 9
        '
        'Labeltelcliente
        '
        Me.Labeltelcliente.AutoSize = True
        Me.Labeltelcliente.Location = New System.Drawing.Point(440, 127)
        Me.Labeltelcliente.Name = "Labeltelcliente"
        Me.Labeltelcliente.Size = New System.Drawing.Size(49, 13)
        Me.Labeltelcliente.TabIndex = 8
        Me.Labeltelcliente.Text = "Telefono"
        '
        'Labeldireccioncliente
        '
        Me.Labeldireccioncliente.AutoSize = True
        Me.Labeldireccioncliente.Location = New System.Drawing.Point(440, 101)
        Me.Labeldireccioncliente.Name = "Labeldireccioncliente"
        Me.Labeldireccioncliente.Size = New System.Drawing.Size(52, 13)
        Me.Labeldireccioncliente.TabIndex = 7
        Me.Labeldireccioncliente.Text = "Direccion"
        '
        'LabelNombreyApellidocliente
        '
        Me.LabelNombreyApellidocliente.AutoSize = True
        Me.LabelNombreyApellidocliente.Location = New System.Drawing.Point(439, 76)
        Me.LabelNombreyApellidocliente.Name = "LabelNombreyApellidocliente"
        Me.LabelNombreyApellidocliente.Size = New System.Drawing.Size(92, 13)
        Me.LabelNombreyApellidocliente.TabIndex = 6
        Me.LabelNombreyApellidocliente.Text = "Nombre y Apellido"
        '
        'LabelCedulacliente
        '
        Me.LabelCedulacliente.AutoSize = True
        Me.LabelCedulacliente.Location = New System.Drawing.Point(439, 50)
        Me.LabelCedulacliente.Name = "LabelCedulacliente"
        Me.LabelCedulacliente.Size = New System.Drawing.Size(40, 13)
        Me.LabelCedulacliente.TabIndex = 5
        Me.LabelCedulacliente.Text = "Cedula"
        '
        'DataGridViewClientes
        '
        Me.DataGridViewClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewClientes.Location = New System.Drawing.Point(3, 43)
        Me.DataGridViewClientes.Name = "DataGridViewClientes"
        Me.DataGridViewClientes.Size = New System.Drawing.Size(419, 271)
        Me.DataGridViewClientes.TabIndex = 4
        '
        'Buttonmodificarcliente
        '
        Me.Buttonmodificarcliente.Location = New System.Drawing.Point(511, 291)
        Me.Buttonmodificarcliente.Name = "Buttonmodificarcliente"
        Me.Buttonmodificarcliente.Size = New System.Drawing.Size(75, 23)
        Me.Buttonmodificarcliente.TabIndex = 3
        Me.Buttonmodificarcliente.Text = "Modificar"
        Me.Buttonmodificarcliente.UseVisualStyleBackColor = True
        '
        'Buttonseleccionarcliente
        '
        Me.Buttonseleccionarcliente.Location = New System.Drawing.Point(592, 291)
        Me.Buttonseleccionarcliente.Name = "Buttonseleccionarcliente"
        Me.Buttonseleccionarcliente.Size = New System.Drawing.Size(75, 23)
        Me.Buttonseleccionarcliente.TabIndex = 2
        Me.Buttonseleccionarcliente.Text = "seleccionar"
        Me.Buttonseleccionarcliente.UseVisualStyleBackColor = True
        '
        'Buttonquitarcliente
        '
        Me.Buttonquitarcliente.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.Buttonquitarcliente.Location = New System.Drawing.Point(428, 320)
        Me.Buttonquitarcliente.Name = "Buttonquitarcliente"
        Me.Buttonquitarcliente.Size = New System.Drawing.Size(75, 23)
        Me.Buttonquitarcliente.TabIndex = 1
        Me.Buttonquitarcliente.Text = "Quitar"
        Me.Buttonquitarcliente.UseVisualStyleBackColor = True
        '
        'Buttonagregarcliente
        '
        Me.Buttonagregarcliente.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.Buttonagregarcliente.Location = New System.Drawing.Point(428, 291)
        Me.Buttonagregarcliente.Name = "Buttonagregarcliente"
        Me.Buttonagregarcliente.Size = New System.Drawing.Size(75, 23)
        Me.Buttonagregarcliente.TabIndex = 0
        Me.Buttonagregarcliente.Text = "Agregar"
        Me.Buttonagregarcliente.UseVisualStyleBackColor = True
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(677, 437)
        Me.TabPage1.TabIndex = 4
        Me.TabPage1.Text = "Usuarios"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 462)
        Me.Controls.Add(Me.TabbedPane)
        Me.Controls.Add(Me.PanelUsuario)
        Me.MaximumSize = New System.Drawing.Size(800, 500)
        Me.MinimumSize = New System.Drawing.Size(800, 500)
        Me.Name = "Form2"
        Me.ShowIcon = False
        Me.Text = "Form2"
        Me.TabbedPane.ResumeLayout(False)
        Me.TabGanado.ResumeLayout(False)
        Me.TabGanado.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabClientes.ResumeLayout(False)
        Me.TabClientes.PerformLayout()
        CType(Me.DataGridViewClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelUsuario As System.Windows.Forms.Panel
    Friend WithEvents TabbedPane As System.Windows.Forms.TabControl
    Friend WithEvents TabGanado As System.Windows.Forms.TabPage
    Friend WithEvents TabVentas As System.Windows.Forms.TabPage
    Friend WithEvents TabCompras As System.Windows.Forms.TabPage
    Friend WithEvents TabClientes As System.Windows.Forms.TabPage
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Labeltelcliente As System.Windows.Forms.Label
    Friend WithEvents Labeldireccioncliente As System.Windows.Forms.Label
    Friend WithEvents LabelNombreyApellidocliente As System.Windows.Forms.Label
    Friend WithEvents LabelCedulacliente As System.Windows.Forms.Label
    Friend WithEvents DataGridViewClientes As System.Windows.Forms.DataGridView
    Friend WithEvents Buttonmodificarcliente As System.Windows.Forms.Button
    Friend WithEvents Buttonseleccionarcliente As System.Windows.Forms.Button
    Friend WithEvents Buttonquitarcliente As System.Windows.Forms.Button
    Friend WithEvents Buttonagregarcliente As System.Windows.Forms.Button
End Class
