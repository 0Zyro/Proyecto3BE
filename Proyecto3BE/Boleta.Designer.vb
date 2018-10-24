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
        Me.txbfechaboleta = New System.Windows.Forms.TextBox()
        Me.DGVBOLETA = New System.Windows.Forms.DataGridView()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BTNimprimir = New System.Windows.Forms.Button()
        Me.PrintForm1 = New Microsoft.VisualBasic.PowerPacks.Printing.PrintForm(Me.components)
        Me.lblfechaboleta = New System.Windows.Forms.Label()
        CType(Me.DGVBOLETA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txbfechaboleta
        '
        Me.txbfechaboleta.Location = New System.Drawing.Point(104, 20)
        Me.txbfechaboleta.Name = "txbfechaboleta"
        Me.txbfechaboleta.Size = New System.Drawing.Size(111, 20)
        Me.txbfechaboleta.TabIndex = 0
        '
        'DGVBOLETA
        '
        Me.DGVBOLETA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVBOLETA.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column4, Me.Column1, Me.Column2, Me.Column3})
        Me.DGVBOLETA.Location = New System.Drawing.Point(56, 135)
        Me.DGVBOLETA.Name = "DGVBOLETA"
        Me.DGVBOLETA.ReadOnly = True
        Me.DGVBOLETA.Size = New System.Drawing.Size(443, 240)
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
        Me.BTNimprimir.Location = New System.Drawing.Point(573, 350)
        Me.BTNimprimir.Name = "BTNimprimir"
        Me.BTNimprimir.Size = New System.Drawing.Size(97, 76)
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
        Me.lblfechaboleta.Location = New System.Drawing.Point(53, 23)
        Me.lblfechaboleta.Name = "lblfechaboleta"
        Me.lblfechaboleta.Size = New System.Drawing.Size(45, 13)
        Me.lblfechaboleta.TabIndex = 4
        Me.lblfechaboleta.Text = "FECHA "
        '
        'Boleta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(736, 458)
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
    Friend WithEvents txbfechaboleta As System.Windows.Forms.TextBox
    Friend WithEvents DGVBOLETA As System.Windows.Forms.DataGridView
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BTNimprimir As System.Windows.Forms.Button
    Friend WithEvents PrintForm1 As Microsoft.VisualBasic.PowerPacks.Printing.PrintForm
    Friend WithEvents lblfechaboleta As System.Windows.Forms.Label
End Class
