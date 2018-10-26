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
        CType(Me.DGVBOLETA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGVBOLETA
        '
        Me.DGVBOLETA.AllowUserToAddRows = False
        Me.DGVBOLETA.AllowUserToDeleteRows = False
        Me.DGVBOLETA.AllowUserToResizeColumns = False
        Me.DGVBOLETA.AllowUserToResizeRows = False
        Me.DGVBOLETA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVBOLETA.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column4, Me.Column1, Me.Column2, Me.Column3})
        Me.DGVBOLETA.Location = New System.Drawing.Point(7, 55)
        Me.DGVBOLETA.Name = "DGVBOLETA"
        Me.DGVBOLETA.ReadOnly = True
        Me.DGVBOLETA.RowHeadersVisible = False
        Me.DGVBOLETA.Size = New System.Drawing.Size(403, 240)
        Me.DGVBOLETA.TabIndex = 2
        '
        'Column4
        '
        Me.Column4.HeaderText = "Ganado"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
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
        Me.BTNimprimir.Location = New System.Drawing.Point(7, 301)
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
        Me.lblfechaboleta.Location = New System.Drawing.Point(4, 15)
        Me.lblfechaboleta.Name = "lblfechaboleta"
        Me.lblfechaboleta.Size = New System.Drawing.Size(45, 13)
        Me.lblfechaboleta.TabIndex = 4
        Me.lblfechaboleta.Text = "FECHA "
        '
        'txbfechaboleta
        '
        Me.txbfechaboleta.Location = New System.Drawing.Point(55, 12)
        Me.txbfechaboleta.Name = "txbfechaboleta"
        Me.txbfechaboleta.Size = New System.Drawing.Size(111, 20)
        Me.txbfechaboleta.TabIndex = 0
        '
        'TXTIVA
        '
        Me.TXTIVA.Location = New System.Drawing.Point(299, 326)
        Me.TXTIVA.Name = "TXTIVA"
        Me.TXTIVA.Size = New System.Drawing.Size(111, 20)
        Me.TXTIVA.TabIndex = 7
        '
        'TXTTotalGeneral
        '
        Me.TXTTotalGeneral.Location = New System.Drawing.Point(299, 352)
        Me.TXTTotalGeneral.Name = "TXTTotalGeneral"
        Me.TXTTotalGeneral.Size = New System.Drawing.Size(111, 20)
        Me.TXTTotalGeneral.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(234, 329)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "I.V.A (%22)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(223, 355)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Total General"
        '
        'TXTSubtotal
        '
        Me.TXTSubtotal.Location = New System.Drawing.Point(299, 299)
        Me.TXTSubtotal.Name = "TXTSubtotal"
        Me.TXTSubtotal.Size = New System.Drawing.Size(111, 20)
        Me.TXTSubtotal.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(248, 302)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Subtotal"
        '
        'Boleta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(420, 387)
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
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
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
End Class
