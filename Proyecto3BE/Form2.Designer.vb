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
        Me.TabVentas = New System.Windows.Forms.TabPage()
        Me.TabCompras = New System.Windows.Forms.TabPage()
        Me.TabUsuarios = New System.Windows.Forms.TabPage()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabbedPane.SuspendLayout()
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
        Me.TabbedPane.Controls.Add(Me.TabUsuarios)
        Me.TabbedPane.Controls.Add(Me.TabPage1)
        Me.TabbedPane.Location = New System.Drawing.Point(101, 0)
        Me.TabbedPane.Name = "TabbedPane"
        Me.TabbedPane.SelectedIndex = 0
        Me.TabbedPane.Size = New System.Drawing.Size(685, 463)
        Me.TabbedPane.TabIndex = 1
        '
        'TabGanado
        '
        Me.TabGanado.Location = New System.Drawing.Point(4, 22)
        Me.TabGanado.Name = "TabGanado"
        Me.TabGanado.Padding = New System.Windows.Forms.Padding(3)
        Me.TabGanado.Size = New System.Drawing.Size(677, 437)
        Me.TabGanado.TabIndex = 0
        Me.TabGanado.Text = "Ganado"
        Me.TabGanado.UseVisualStyleBackColor = True
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
        'TabUsuarios
        '
        Me.TabUsuarios.Location = New System.Drawing.Point(4, 22)
        Me.TabUsuarios.Name = "TabUsuarios"
        Me.TabUsuarios.Padding = New System.Windows.Forms.Padding(3)
        Me.TabUsuarios.Size = New System.Drawing.Size(677, 437)
        Me.TabUsuarios.TabIndex = 3
        Me.TabUsuarios.Text = "Clientes"
        Me.TabUsuarios.UseVisualStyleBackColor = True
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
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelUsuario As System.Windows.Forms.Panel
    Friend WithEvents TabbedPane As System.Windows.Forms.TabControl
    Friend WithEvents TabGanado As System.Windows.Forms.TabPage
    Friend WithEvents TabVentas As System.Windows.Forms.TabPage
    Friend WithEvents TabCompras As System.Windows.Forms.TabPage
    Friend WithEvents TabUsuarios As System.Windows.Forms.TabPage
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
End Class
