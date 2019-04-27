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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
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
        Me.BTNAgregarGanado = New System.Windows.Forms.Button()
        Me.BTNEliminarGanado = New System.Windows.Forms.Button()
        Me.LBLAgregarGanadoSexo = New System.Windows.Forms.Label()
        Me.LBLAgregarGanadoNacimiento = New System.Windows.Forms.Label()
        Me.LBLAgregarGanadoRaza = New System.Windows.Forms.Label()
        Me.CBXAgregarGanadoSexo = New System.Windows.Forms.ComboBox()
        Me.CBXAgregarGanadoRaza = New System.Windows.Forms.ComboBox()
        Me.DTPAgregarGanadoNacimiento = New System.Windows.Forms.DateTimePicker()
        Me.BTNAgregarGanadoOtro = New System.Windows.Forms.Button()
        Me.PNLAgregarGanado = New System.Windows.Forms.Panel()
        CType(Me.DGVGanado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PNLAgregarGanado.SuspendLayout()
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
        Me.DGVGanado.Location = New System.Drawing.Point(318, 322)
        Me.DGVGanado.MultiSelect = False
        Me.DGVGanado.Name = "DGVGanado"
        Me.DGVGanado.ReadOnly = True
        Me.DGVGanado.RowHeadersVisible = False
        Me.DGVGanado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVGanado.Size = New System.Drawing.Size(88, 61)
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
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(12, 39)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series1.Legend = "Legend1"
        Series1.Name = "serie"
        Me.Chart1.Series.Add(Series1)
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
        'BTNAgregarGanado
        '
        Me.BTNAgregarGanado.Location = New System.Drawing.Point(421, 322)
        Me.BTNAgregarGanado.Name = "BTNAgregarGanado"
        Me.BTNAgregarGanado.Size = New System.Drawing.Size(75, 63)
        Me.BTNAgregarGanado.TabIndex = 10
        Me.BTNAgregarGanado.Text = "Agregar"
        Me.BTNAgregarGanado.UseVisualStyleBackColor = True
        '
        'BTNEliminarGanado
        '
        Me.BTNEliminarGanado.Location = New System.Drawing.Point(502, 320)
        Me.BTNEliminarGanado.Name = "BTNEliminarGanado"
        Me.BTNEliminarGanado.Size = New System.Drawing.Size(75, 65)
        Me.BTNEliminarGanado.TabIndex = 11
        Me.BTNEliminarGanado.Text = "Eliminar"
        Me.BTNEliminarGanado.UseVisualStyleBackColor = True
        '
        'LBLAgregarGanadoSexo
        '
        Me.LBLAgregarGanadoSexo.AutoSize = True
        Me.LBLAgregarGanadoSexo.Location = New System.Drawing.Point(27, 66)
        Me.LBLAgregarGanadoSexo.Name = "LBLAgregarGanadoSexo"
        Me.LBLAgregarGanadoSexo.Size = New System.Drawing.Size(31, 13)
        Me.LBLAgregarGanadoSexo.TabIndex = 12
        Me.LBLAgregarGanadoSexo.Text = "Sexo"
        '
        'LBLAgregarGanadoNacimiento
        '
        Me.LBLAgregarGanadoNacimiento.AutoSize = True
        Me.LBLAgregarGanadoNacimiento.Location = New System.Drawing.Point(27, 116)
        Me.LBLAgregarGanadoNacimiento.Name = "LBLAgregarGanadoNacimiento"
        Me.LBLAgregarGanadoNacimiento.Size = New System.Drawing.Size(60, 13)
        Me.LBLAgregarGanadoNacimiento.TabIndex = 13
        Me.LBLAgregarGanadoNacimiento.Text = "Nacimiento"
        '
        'LBLAgregarGanadoRaza
        '
        Me.LBLAgregarGanadoRaza.AutoSize = True
        Me.LBLAgregarGanadoRaza.Location = New System.Drawing.Point(27, 171)
        Me.LBLAgregarGanadoRaza.Name = "LBLAgregarGanadoRaza"
        Me.LBLAgregarGanadoRaza.Size = New System.Drawing.Size(32, 13)
        Me.LBLAgregarGanadoRaza.TabIndex = 14
        Me.LBLAgregarGanadoRaza.Text = "Raza"
        '
        'CBXAgregarGanadoSexo
        '
        Me.CBXAgregarGanadoSexo.FormattingEnabled = True
        Me.CBXAgregarGanadoSexo.Items.AddRange(New Object() {"Hembra", "Macho"})
        Me.CBXAgregarGanadoSexo.Location = New System.Drawing.Point(30, 83)
        Me.CBXAgregarGanadoSexo.Name = "CBXAgregarGanadoSexo"
        Me.CBXAgregarGanadoSexo.Size = New System.Drawing.Size(113, 21)
        Me.CBXAgregarGanadoSexo.TabIndex = 15
        '
        'CBXAgregarGanadoRaza
        '
        Me.CBXAgregarGanadoRaza.FormattingEnabled = True
        Me.CBXAgregarGanadoRaza.Location = New System.Drawing.Point(30, 187)
        Me.CBXAgregarGanadoRaza.Name = "CBXAgregarGanadoRaza"
        Me.CBXAgregarGanadoRaza.Size = New System.Drawing.Size(131, 21)
        Me.CBXAgregarGanadoRaza.TabIndex = 16
        '
        'DTPAgregarGanadoNacimiento
        '
        Me.DTPAgregarGanadoNacimiento.Location = New System.Drawing.Point(30, 133)
        Me.DTPAgregarGanadoNacimiento.Name = "DTPAgregarGanadoNacimiento"
        Me.DTPAgregarGanadoNacimiento.Size = New System.Drawing.Size(184, 20)
        Me.DTPAgregarGanadoNacimiento.TabIndex = 17
        '
        'BTNAgregarGanadoOtro
        '
        Me.BTNAgregarGanadoOtro.Location = New System.Drawing.Point(167, 187)
        Me.BTNAgregarGanadoOtro.Name = "BTNAgregarGanadoOtro"
        Me.BTNAgregarGanadoOtro.Size = New System.Drawing.Size(47, 23)
        Me.BTNAgregarGanadoOtro.TabIndex = 20
        Me.BTNAgregarGanadoOtro.Text = "Otro"
        Me.BTNAgregarGanadoOtro.UseVisualStyleBackColor = True
        '
        'PNLAgregarGanado
        '
        Me.PNLAgregarGanado.Controls.Add(Me.CBXAgregarGanadoSexo)
        Me.PNLAgregarGanado.Controls.Add(Me.BTNAgregarGanadoOtro)
        Me.PNLAgregarGanado.Controls.Add(Me.LBLAgregarGanadoSexo)
        Me.PNLAgregarGanado.Controls.Add(Me.LBLAgregarGanadoNacimiento)
        Me.PNLAgregarGanado.Controls.Add(Me.LBLAgregarGanadoRaza)
        Me.PNLAgregarGanado.Controls.Add(Me.DTPAgregarGanadoNacimiento)
        Me.PNLAgregarGanado.Controls.Add(Me.CBXAgregarGanadoRaza)
        Me.PNLAgregarGanado.Location = New System.Drawing.Point(318, 39)
        Me.PNLAgregarGanado.Name = "PNLAgregarGanado"
        Me.PNLAgregarGanado.Size = New System.Drawing.Size(259, 275)
        Me.PNLAgregarGanado.TabIndex = 21
        Me.PNLAgregarGanado.Visible = False
        '
        'mainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(589, 397)
        Me.Controls.Add(Me.PNLAgregarGanado)
        Me.Controls.Add(Me.BTNEliminarGanado)
        Me.Controls.Add(Me.BTNAgregarGanado)
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
        Me.PNLAgregarGanado.ResumeLayout(False)
        Me.PNLAgregarGanado.PerformLayout()
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
    Friend WithEvents BTNAgregarGanado As System.Windows.Forms.Button
    Friend WithEvents BTNEliminarGanado As System.Windows.Forms.Button
    Friend WithEvents LBLAgregarGanadoSexo As System.Windows.Forms.Label
    Friend WithEvents LBLAgregarGanadoNacimiento As System.Windows.Forms.Label
    Friend WithEvents LBLAgregarGanadoRaza As System.Windows.Forms.Label
    Friend WithEvents CBXAgregarGanadoSexo As System.Windows.Forms.ComboBox
    Friend WithEvents CBXAgregarGanadoRaza As System.Windows.Forms.ComboBox
    Friend WithEvents DTPAgregarGanadoNacimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents BTNAgregarGanadoOtro As System.Windows.Forms.Button
    Friend WithEvents PNLAgregarGanado As System.Windows.Forms.Panel

End Class
