<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Boleta
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Boleta))
        Me.DGVBOLETA = New System.Windows.Forms.DataGridView()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BTNimprimir = New System.Windows.Forms.Button()
        Me.PrintForm1 = New Microsoft.VisualBasic.PowerPacks.Printing.PrintForm(Me.components)
        Me.lblfechaboleta = New System.Windows.Forms.Label()
        Me.txbfechaboleta = New System.Windows.Forms.TextBox()
        Me.TXTIVA = New System.Windows.Forms.TextBox()
        Me.TXTTotalGeneral = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXTSubtotal = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LBLNombreclientev = New System.Windows.Forms.Label()
        Me.lblidventabo = New System.Windows.Forms.Label()
        Me.lblapellidoenboleta = New System.Windows.Forms.Label()
        CType(Me.DGVBOLETA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGVBOLETA
        '
        Me.DGVBOLETA.AllowUserToAddRows = False
        Me.DGVBOLETA.AllowUserToDeleteRows = False
        Me.DGVBOLETA.AllowUserToResizeColumns = False
        Me.DGVBOLETA.AllowUserToResizeRows = False
        Me.DGVBOLETA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGVBOLETA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVBOLETA.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column4, Me.Column5, Me.Column6, Me.Column1, Me.Column2, Me.Column3})
        Me.DGVBOLETA.GridColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.DGVBOLETA.Location = New System.Drawing.Point(8, 104)
        Me.DGVBOLETA.Name = "DGVBOLETA"
        Me.DGVBOLETA.ReadOnly = True
        Me.DGVBOLETA.RowHeadersVisible = False
        Me.DGVBOLETA.Size = New System.Drawing.Size(619, 240)
        Me.DGVBOLETA.TabIndex = 2
        '
        'Column4
        '
        Me.Column4.HeaderText = "Ganado"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'Column5
        '
        Me.Column5.HeaderText = "Raza"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "Sexo"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "Peso(KG)"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'Column2
        '
        Me.Column2.HeaderText = "Precio($)"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'Column3
        '
        Me.Column3.HeaderText = "Subtotal"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'BTNimprimir
        '
        Me.BTNimprimir.Location = New System.Drawing.Point(8, 352)
        Me.BTNimprimir.Name = "BTNimprimir"
        Me.BTNimprimir.Size = New System.Drawing.Size(94, 71)
        Me.BTNimprimir.TabIndex = 3
        Me.BTNimprimir.Text = "IMPRIMIR"
        Me.BTNimprimir.UseVisualStyleBackColor = True
        '
        'PrintForm1
        '
        Me.PrintForm1.DocumentName = "document"
        Me.PrintForm1.Form = Me
        Me.PrintForm1.PrintAction = System.Drawing.Printing.PrintAction.PrintToPrinter
        Me.PrintForm1.PrinterSettings = CType(resources.GetObject("PrintForm1.PrinterSettings"), System.Drawing.Printing.PrinterSettings)
        Me.PrintForm1.PrintFileName = Nothing
        '
        'lblfechaboleta
        '
        Me.lblfechaboleta.AutoSize = True
        Me.lblfechaboleta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfechaboleta.Location = New System.Drawing.Point(316, 55)
        Me.lblfechaboleta.Name = "lblfechaboleta"
        Me.lblfechaboleta.Size = New System.Drawing.Size(51, 13)
        Me.lblfechaboleta.TabIndex = 4
        Me.lblfechaboleta.Text = "FECHA "
        '
        'txbfechaboleta
        '
        Me.txbfechaboleta.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txbfechaboleta.Location = New System.Drawing.Point(367, 52)
        Me.txbfechaboleta.Name = "txbfechaboleta"
        Me.txbfechaboleta.ReadOnly = True
        Me.txbfechaboleta.Size = New System.Drawing.Size(111, 20)
        Me.txbfechaboleta.TabIndex = 0
        '
        'TXTIVA
        '
        Me.TXTIVA.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.TXTIVA.Location = New System.Drawing.Point(516, 378)
        Me.TXTIVA.Name = "TXTIVA"
        Me.TXTIVA.ReadOnly = True
        Me.TXTIVA.Size = New System.Drawing.Size(111, 20)
        Me.TXTIVA.TabIndex = 7
        '
        'TXTTotalGeneral
        '
        Me.TXTTotalGeneral.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.TXTTotalGeneral.Location = New System.Drawing.Point(516, 404)
        Me.TXTTotalGeneral.Name = "TXTTotalGeneral"
        Me.TXTTotalGeneral.ReadOnly = True
        Me.TXTTotalGeneral.Size = New System.Drawing.Size(111, 20)
        Me.TXTTotalGeneral.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(451, 381)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "I.V.A (%22)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(440, 407)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Total General"
        '
        'TXTSubtotal
        '
        Me.TXTSubtotal.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.TXTSubtotal.Location = New System.Drawing.Point(516, 351)
        Me.TXTSubtotal.Name = "TXTSubtotal"
        Me.TXTSubtotal.ReadOnly = True
        Me.TXTSubtotal.Size = New System.Drawing.Size(111, 20)
        Me.TXTSubtotal.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(465, 354)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Subtotal"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "SNOWCOMPANY"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(319, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "E-ticket Contado"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(513, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(125, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "RUT: 210000480010"
        '
        'LBLNombreclientev
        '
        Me.LBLNombreclientev.AutoSize = True
        Me.LBLNombreclientev.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLNombreclientev.Location = New System.Drawing.Point(12, 59)
        Me.LBLNombreclientev.Name = "LBLNombreclientev"
        Me.LBLNombreclientev.Size = New System.Drawing.Size(40, 13)
        Me.LBLNombreclientev.TabIndex = 15
        Me.LBLNombreclientev.Text = "asdsa"
        '
        'lblidventabo
        '
        Me.lblidventabo.AutoSize = True
        Me.lblidventabo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblidventabo.Location = New System.Drawing.Point(515, 57)
        Me.lblidventabo.Name = "lblidventabo"
        Me.lblidventabo.Size = New System.Drawing.Size(133, 13)
        Me.lblidventabo.TabIndex = 17
        Me.lblidventabo.Text = "N°: ""codigo de venta"""
        '
        'lblapellidoenboleta
        '
        Me.lblapellidoenboleta.AutoSize = True
        Me.lblapellidoenboleta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblapellidoenboleta.Location = New System.Drawing.Point(107, 59)
        Me.lblapellidoenboleta.Name = "lblapellidoenboleta"
        Me.lblapellidoenboleta.Size = New System.Drawing.Size(40, 13)
        Me.lblapellidoenboleta.TabIndex = 18
        Me.lblapellidoenboleta.Text = "asdsa"
        '
        'Boleta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(672, 427)
        Me.Controls.Add(Me.lblapellidoenboleta)
        Me.Controls.Add(Me.lblidventabo)
        Me.Controls.Add(Me.LBLNombreclientev)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TXTTotalGeneral)
        Me.Controls.Add(Me.TXTIVA)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TXTSubtotal)
        Me.Controls.Add(Me.lblfechaboleta)
        Me.Controls.Add(Me.BTNimprimir)
        Me.Controls.Add(Me.DGVBOLETA)
        Me.Controls.Add(Me.txbfechaboleta)
        Me.Name = "Boleta"
        Me.Text = "Factura"
        CType(Me.DGVBOLETA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGVBOLETA As System.Windows.Forms.DataGridView
    Friend WithEvents BTNimprimir As System.Windows.Forms.Button
    Friend WithEvents PrintForm1 As Microsoft.VisualBasic.PowerPacks.Printing.PrintForm
    Friend WithEvents lblfechaboleta As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TXTTotalGeneral As System.Windows.Forms.TextBox
    Friend WithEvents TXTIVA As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXTSubtotal As System.Windows.Forms.TextBox
    Friend WithEvents txbfechaboleta As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LBLNombreclientev As System.Windows.Forms.Label
    Friend WithEvents lblidventabo As System.Windows.Forms.Label
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblapellidoenboleta As System.Windows.Forms.Label
End Class
