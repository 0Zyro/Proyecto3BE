<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mainForm
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
        Me.Main = New System.Windows.Forms.TabControl()
        Me.TABGanado = New System.Windows.Forms.TabPage()
        Me.CRGBar = New System.Windows.Forms.ProgressBar()
        Me.DGVGanado = New System.Windows.Forms.DataGridView()
        Me.CBXBusqueda = New System.Windows.Forms.ComboBox()
        Me.TXBBusqueda = New System.Windows.Forms.TextBox()
        Me.BTNBusqueda = New System.Windows.Forms.Button()
        Me.TABVentas = New System.Windows.Forms.TabPage()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sexo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Raza = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nacimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Compra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Venta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Main.SuspendLayout()
        Me.TABGanado.SuspendLayout()
        CType(Me.DGVGanado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Main
        '
        Me.Main.Controls.Add(Me.TABGanado)
        Me.Main.Controls.Add(Me.TABVentas)
        Me.Main.Location = New System.Drawing.Point(12, 12)
        Me.Main.Name = "Main"
        Me.Main.SelectedIndex = 0
        Me.Main.Size = New System.Drawing.Size(640, 329)
        Me.Main.TabIndex = 0
        Me.Main.Tag = ""
        '
        'TABGanado
        '
        Me.TABGanado.Controls.Add(Me.CRGBar)
        Me.TABGanado.Controls.Add(Me.DGVGanado)
        Me.TABGanado.Controls.Add(Me.CBXBusqueda)
        Me.TABGanado.Controls.Add(Me.TXBBusqueda)
        Me.TABGanado.Controls.Add(Me.BTNBusqueda)
        Me.TABGanado.Location = New System.Drawing.Point(4, 22)
        Me.TABGanado.Name = "TABGanado"
        Me.TABGanado.Padding = New System.Windows.Forms.Padding(3)
        Me.TABGanado.Size = New System.Drawing.Size(632, 303)
        Me.TABGanado.TabIndex = 0
        Me.TABGanado.Text = "Ganado"
        Me.TABGanado.UseVisualStyleBackColor = True
        '
        'CRGBar
        '
        Me.CRGBar.Location = New System.Drawing.Point(306, 271)
        Me.CRGBar.Name = "CRGBar"
        Me.CRGBar.Size = New System.Drawing.Size(39, 23)
        Me.CRGBar.TabIndex = 4
        '
        'DGVGanado
        '
        Me.DGVGanado.AllowUserToAddRows = False
        Me.DGVGanado.AllowUserToDeleteRows = False
        Me.DGVGanado.AllowUserToResizeColumns = False
        Me.DGVGanado.AllowUserToResizeRows = False
        Me.DGVGanado.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DGVGanado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVGanado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Sexo, Me.Raza, Me.Nacimiento, Me.Estado, Me.Compra, Me.Venta})
        Me.DGVGanado.Location = New System.Drawing.Point(7, 34)
        Me.DGVGanado.MultiSelect = False
        Me.DGVGanado.Name = "DGVGanado"
        Me.DGVGanado.ReadOnly = True
        Me.DGVGanado.RowHeadersVisible = False
        Me.DGVGanado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVGanado.Size = New System.Drawing.Size(293, 260)
        Me.DGVGanado.TabIndex = 3
        '
        'CBXBusqueda
        '
        Me.CBXBusqueda.FormattingEnabled = True
        Me.CBXBusqueda.Items.AddRange(New Object() {"Raza", "Edad", "Estado", "Sexo"})
        Me.CBXBusqueda.Location = New System.Drawing.Point(7, 6)
        Me.CBXBusqueda.Name = "CBXBusqueda"
        Me.CBXBusqueda.Size = New System.Drawing.Size(90, 21)
        Me.CBXBusqueda.TabIndex = 0
        '
        'TXBBusqueda
        '
        Me.TXBBusqueda.Location = New System.Drawing.Point(103, 7)
        Me.TXBBusqueda.Name = "TXBBusqueda"
        Me.TXBBusqueda.Size = New System.Drawing.Size(118, 20)
        Me.TXBBusqueda.TabIndex = 2
        '
        'BTNBusqueda
        '
        Me.BTNBusqueda.Location = New System.Drawing.Point(227, 7)
        Me.BTNBusqueda.Name = "BTNBusqueda"
        Me.BTNBusqueda.Size = New System.Drawing.Size(73, 23)
        Me.BTNBusqueda.TabIndex = 1
        Me.BTNBusqueda.Text = "Buscar"
        Me.BTNBusqueda.UseVisualStyleBackColor = True
        '
        'TABVentas
        '
        Me.TABVentas.Location = New System.Drawing.Point(4, 22)
        Me.TABVentas.Name = "TABVentas"
        Me.TABVentas.Padding = New System.Windows.Forms.Padding(3)
        Me.TABVentas.Size = New System.Drawing.Size(632, 303)
        Me.TABVentas.TabIndex = 1
        Me.TABVentas.Text = "Ventas"
        Me.TABVentas.UseVisualStyleBackColor = True
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        '
        'Sexo
        '
        Me.Sexo.HeaderText = "Sexo"
        Me.Sexo.Name = "Sexo"
        Me.Sexo.ReadOnly = True
        '
        'Raza
        '
        Me.Raza.HeaderText = "Raza"
        Me.Raza.Name = "Raza"
        Me.Raza.ReadOnly = True
        '
        'Nacimiento
        '
        Me.Nacimiento.HeaderText = "Nacimiento"
        Me.Nacimiento.Name = "Nacimiento"
        Me.Nacimiento.ReadOnly = True
        '
        'Estado
        '
        Me.Estado.HeaderText = "Estado"
        Me.Estado.Name = "Estado"
        Me.Estado.ReadOnly = True
        '
        'Compra
        '
        Me.Compra.HeaderText = "Compra"
        Me.Compra.Name = "Compra"
        Me.Compra.ReadOnly = True
        '
        'Venta
        '
        Me.Venta.HeaderText = "Venta"
        Me.Venta.Name = "Venta"
        Me.Venta.ReadOnly = True
        '
        'mainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(664, 353)
        Me.Controls.Add(Me.Main)
        Me.Name = "mainForm"
        Me.Text = "Ganaderia"
        Me.Main.ResumeLayout(False)
        Me.TABGanado.ResumeLayout(False)
        Me.TABGanado.PerformLayout()
        CType(Me.DGVGanado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Main As System.Windows.Forms.TabControl
    Friend WithEvents TABGanado As System.Windows.Forms.TabPage
    Friend WithEvents TABVentas As System.Windows.Forms.TabPage
    Friend WithEvents CBXBusqueda As System.Windows.Forms.ComboBox
    Friend WithEvents TXBBusqueda As System.Windows.Forms.TextBox
    Friend WithEvents BTNBusqueda As System.Windows.Forms.Button

    Private Sub CBXBusqueda_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBXBusqueda.SelectedIndexChanged

    End Sub
    Friend WithEvents CRGBar As System.Windows.Forms.ProgressBar
    Friend WithEvents DGVGanado As System.Windows.Forms.DataGridView
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sexo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Raza As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nacimiento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Estado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Compra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Venta As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
