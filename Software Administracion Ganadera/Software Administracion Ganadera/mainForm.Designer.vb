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
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.BTNBusqueda = New System.Windows.Forms.Button()
        Me.CBXBusqueda = New System.Windows.Forms.ComboBox()
        Me.TXBBusqueda = New System.Windows.Forms.TextBox()
        Me.DGVGanado = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sexo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Raza = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nacimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Compra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Venta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.BTNLimpiar = New System.Windows.Forms.Button()
        Me.CBXFiltros = New System.Windows.Forms.ComboBox()
        Me.LBLGanadoActivo = New System.Windows.Forms.Label()
        Me.LBLFiltros = New System.Windows.Forms.Label()
        CType(Me.DGVGanado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BTNBusqueda
        '
        Me.BTNBusqueda.Location = New System.Drawing.Point(528, 9)
        Me.BTNBusqueda.Name = "BTNBusqueda"
        Me.BTNBusqueda.Size = New System.Drawing.Size(49, 23)
        Me.BTNBusqueda.TabIndex = 0
        Me.BTNBusqueda.Text = "Buscar"
        Me.BTNBusqueda.UseVisualStyleBackColor = True
        '
        'CBXBusqueda
        '
        Me.CBXBusqueda.FormattingEnabled = True
        Me.CBXBusqueda.Items.AddRange(New Object() {"Raza", "Estado", "Sexo"})
        Me.CBXBusqueda.Location = New System.Drawing.Point(306, 11)
        Me.CBXBusqueda.Name = "CBXBusqueda"
        Me.CBXBusqueda.Size = New System.Drawing.Size(88, 21)
        Me.CBXBusqueda.TabIndex = 1
        '
        'TXBBusqueda
        '
        Me.TXBBusqueda.Location = New System.Drawing.Point(400, 12)
        Me.TXBBusqueda.Name = "TXBBusqueda"
        Me.TXBBusqueda.Size = New System.Drawing.Size(122, 20)
        Me.TXBBusqueda.TabIndex = 2
        '
        'DGVGanado
        '
        Me.DGVGanado.AllowUserToAddRows = False
        Me.DGVGanado.AllowUserToDeleteRows = False
        Me.DGVGanado.AllowUserToResizeColumns = False
        Me.DGVGanado.AllowUserToResizeRows = False
        Me.DGVGanado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DGVGanado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVGanado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Sexo, Me.Raza, Me.Nacimiento, Me.Estado, Me.Compra, Me.Venta})
        Me.DGVGanado.Location = New System.Drawing.Point(306, 38)
        Me.DGVGanado.Name = "DGVGanado"
        Me.DGVGanado.ReadOnly = True
        Me.DGVGanado.RowHeadersVisible = False
        Me.DGVGanado.Size = New System.Drawing.Size(271, 276)
        Me.DGVGanado.TabIndex = 3
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        Me.Id.Width = 41
        '
        'Sexo
        '
        Me.Sexo.HeaderText = "Sexo"
        Me.Sexo.Name = "Sexo"
        Me.Sexo.ReadOnly = True
        Me.Sexo.Width = 56
        '
        'Raza
        '
        Me.Raza.HeaderText = "Raza"
        Me.Raza.Name = "Raza"
        Me.Raza.ReadOnly = True
        Me.Raza.Width = 57
        '
        'Nacimiento
        '
        Me.Nacimiento.HeaderText = "Nacimiento"
        Me.Nacimiento.Name = "Nacimiento"
        Me.Nacimiento.ReadOnly = True
        Me.Nacimiento.Width = 85
        '
        'Estado
        '
        Me.Estado.HeaderText = "Estado"
        Me.Estado.Name = "Estado"
        Me.Estado.ReadOnly = True
        Me.Estado.Width = 65
        '
        'Compra
        '
        Me.Compra.HeaderText = "Compra"
        Me.Compra.Name = "Compra"
        Me.Compra.ReadOnly = True
        Me.Compra.Width = 68
        '
        'Venta
        '
        Me.Venta.HeaderText = "Venta"
        Me.Venta.Name = "Venta"
        Me.Venta.ReadOnly = True
        Me.Venta.Width = 60
        '
        'Chart1
        '
        ChartArea3.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea3)
        Legend3.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend3)
        Me.Chart1.Location = New System.Drawing.Point(12, 39)
        Me.Chart1.Name = "Chart1"
        Series3.ChartArea = "ChartArea1"
        Series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series3.Legend = "Legend1"
        Series3.Name = "serie"
        Me.Chart1.Series.Add(Series3)
        Me.Chart1.Size = New System.Drawing.Size(288, 275)
        Me.Chart1.TabIndex = 4
        Me.Chart1.Text = "Chart1"
        '
        'BTNLimpiar
        '
        Me.BTNLimpiar.Location = New System.Drawing.Point(13, 340)
        Me.BTNLimpiar.Name = "BTNLimpiar"
        Me.BTNLimpiar.Size = New System.Drawing.Size(69, 23)
        Me.BTNLimpiar.TabIndex = 5
        Me.BTNLimpiar.Text = "Limpiar"
        Me.BTNLimpiar.UseVisualStyleBackColor = True
        '
        'CBXFiltros
        '
        Me.CBXFiltros.DisplayMember = "0"
        Me.CBXFiltros.Items.AddRange(New Object() {"Raza", "Estado", "Sexo"})
        Me.CBXFiltros.Location = New System.Drawing.Point(88, 340)
        Me.CBXFiltros.Name = "CBXFiltros"
        Me.CBXFiltros.Size = New System.Drawing.Size(121, 21)
        Me.CBXFiltros.TabIndex = 7
        '
        'LBLGanadoActivo
        '
        Me.LBLGanadoActivo.AutoSize = True
        Me.LBLGanadoActivo.Location = New System.Drawing.Point(12, 9)
        Me.LBLGanadoActivo.Name = "LBLGanadoActivo"
        Me.LBLGanadoActivo.Size = New System.Drawing.Size(98, 13)
        Me.LBLGanadoActivo.TabIndex = 8
        Me.LBLGanadoActivo.Text = "Ganado Activo: XX"
        '
        'LBLFiltros
        '
        Me.LBLFiltros.AutoSize = True
        Me.LBLFiltros.Location = New System.Drawing.Point(15, 370)
        Me.LBLFiltros.Name = "LBLFiltros"
        Me.LBLFiltros.Size = New System.Drawing.Size(112, 13)
        Me.LBLFiltros.TabIndex = 9
        Me.LBLFiltros.Text = "filtros filtros filtros filtros"
        '
        'mainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(589, 397)
        Me.Controls.Add(Me.LBLFiltros)
        Me.Controls.Add(Me.LBLGanadoActivo)
        Me.Controls.Add(Me.CBXFiltros)
        Me.Controls.Add(Me.BTNLimpiar)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.DGVGanado)
        Me.Controls.Add(Me.TXBBusqueda)
        Me.Controls.Add(Me.CBXBusqueda)
        Me.Controls.Add(Me.BTNBusqueda)
        Me.Name = "mainForm"
        Me.Text = "Form1"
        CType(Me.DGVGanado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BTNBusqueda As System.Windows.Forms.Button
    Friend WithEvents CBXBusqueda As System.Windows.Forms.ComboBox
    Friend WithEvents TXBBusqueda As System.Windows.Forms.TextBox
    Friend WithEvents DGVGanado As System.Windows.Forms.DataGridView
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sexo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Raza As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nacimiento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Estado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Compra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Venta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents BTNLimpiar As System.Windows.Forms.Button
    Friend WithEvents CBXFiltros As System.Windows.Forms.ComboBox
    Friend WithEvents LBLGanadoActivo As System.Windows.Forms.Label
    Friend WithEvents LBLFiltros As System.Windows.Forms.Label

End Class
