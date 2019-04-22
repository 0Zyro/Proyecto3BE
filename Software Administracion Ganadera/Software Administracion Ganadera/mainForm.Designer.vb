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
        CType(Me.DGVGanado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BTNBusqueda
        '
        Me.BTNBusqueda.Location = New System.Drawing.Point(217, 10)
        Me.BTNBusqueda.Name = "BTNBusqueda"
        Me.BTNBusqueda.Size = New System.Drawing.Size(44, 23)
        Me.BTNBusqueda.TabIndex = 0
        Me.BTNBusqueda.Text = "Button1"
        Me.BTNBusqueda.UseVisualStyleBackColor = True
        '
        'CBXBusqueda
        '
        Me.CBXBusqueda.FormattingEnabled = True
        Me.CBXBusqueda.Location = New System.Drawing.Point(12, 12)
        Me.CBXBusqueda.Name = "CBXBusqueda"
        Me.CBXBusqueda.Size = New System.Drawing.Size(74, 21)
        Me.CBXBusqueda.TabIndex = 1
        '
        'TXBBusqueda
        '
        Me.TXBBusqueda.Location = New System.Drawing.Point(92, 12)
        Me.TXBBusqueda.Name = "TXBBusqueda"
        Me.TXBBusqueda.Size = New System.Drawing.Size(119, 20)
        Me.TXBBusqueda.TabIndex = 2
        '
        'DGVGanado
        '
        Me.DGVGanado.AllowUserToAddRows = False
        Me.DGVGanado.AllowUserToDeleteRows = False
        Me.DGVGanado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVGanado.Location = New System.Drawing.Point(12, 38)
        Me.DGVGanado.Name = "DGVGanado"
        Me.DGVGanado.ReadOnly = True
        Me.DGVGanado.Size = New System.Drawing.Size(294, 325)
        Me.DGVGanado.TabIndex = 3
        '
        'mainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(589, 375)
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

End Class
