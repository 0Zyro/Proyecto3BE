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
        Me.BTNAgregarGanado = New System.Windows.Forms.Button()
        Me.BTNModificarGanado = New System.Windows.Forms.Button()
        CType(Me.DGVGanado, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.CBXBusqueda.Items.AddRange(New Object() {"Sexo", "Raza", "Estado"})
        Me.CBXBusqueda.Location = New System.Drawing.Point(283, 12)
        Me.CBXBusqueda.Name = "CBXBusqueda"
        Me.CBXBusqueda.Size = New System.Drawing.Size(88, 21)
        Me.CBXBusqueda.TabIndex = 1
        '
        'TXBBusqueda
        '
        Me.TXBBusqueda.Location = New System.Drawing.Point(377, 12)
        Me.TXBBusqueda.Name = "TXBBusqueda"
        Me.TXBBusqueda.Size = New System.Drawing.Size(145, 20)
        Me.TXBBusqueda.TabIndex = 2
        '
        'DGVGanado
        '
        Me.DGVGanado.AllowUserToAddRows = False
        Me.DGVGanado.AllowUserToDeleteRows = False
        Me.DGVGanado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVGanado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Sexo, Me.Raza, Me.Nacimiento, Me.Estado, Me.Compra, Me.Venta})
        Me.DGVGanado.Location = New System.Drawing.Point(283, 38)
        Me.DGVGanado.Name = "DGVGanado"
        Me.DGVGanado.ReadOnly = True
        Me.DGVGanado.RowHeadersVisible = False
        Me.DGVGanado.Size = New System.Drawing.Size(294, 325)
        Me.DGVGanado.TabIndex = 3
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
        'BTNAgregarGanado
        '
        Me.BTNAgregarGanado.Location = New System.Drawing.Point(202, 9)
        Me.BTNAgregarGanado.Name = "BTNAgregarGanado"
        Me.BTNAgregarGanado.Size = New System.Drawing.Size(75, 58)
        Me.BTNAgregarGanado.TabIndex = 4
        Me.BTNAgregarGanado.Text = "Agregar"
        Me.BTNAgregarGanado.UseVisualStyleBackColor = True
        '
        'BTNModificarGanado
        '
        Me.BTNModificarGanado.Location = New System.Drawing.Point(202, 73)
        Me.BTNModificarGanado.Name = "BTNModificarGanado"
        Me.BTNModificarGanado.Size = New System.Drawing.Size(75, 58)
        Me.BTNModificarGanado.TabIndex = 5
        Me.BTNModificarGanado.Text = "Modificar"
        Me.BTNModificarGanado.UseVisualStyleBackColor = True
        '
        'mainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(589, 375)
        Me.Controls.Add(Me.BTNModificarGanado)
        Me.Controls.Add(Me.BTNAgregarGanado)
        Me.Controls.Add(Me.DGVGanado)
        Me.Controls.Add(Me.TXBBusqueda)
        Me.Controls.Add(Me.CBXBusqueda)
        Me.Controls.Add(Me.BTNBusqueda)
        Me.Name = "mainForm"
        Me.Text = "Form1"
        CType(Me.DGVGanado, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents BTNAgregarGanado As System.Windows.Forms.Button
    Friend WithEvents BTNModificarGanado As System.Windows.Forms.Button

End Class
