Imports System.Data
Imports System.Data.OleDb
Imports MySql.Data.MySqlClient
Public Class Boleta
    Public Conexion As MySqlDataAdapter
    Public Tabla As DataTable
    Public Consulta As String
    Dim data As String = ("Server=localhost;Database=vacas;User id=root;Password=;Port=3306;")
    Dim connection As New MySqlConnection(data)
    Dim comando As New MySqlCommand
    Dim reader As MySqlDataReader
    Public Sub clear()
        DGVBOLETA.Rows.Clear()
    End Sub
    Public Sub cargardatos(ByVal peso As Double, ByVal precio As Double, ByVal subtotal As Double, ByVal idganado As Integer, ByVal fechaventa As String, ByVal total As Double)
        txbfechaboleta.Text = fechaventa
        DGVBOLETA.Rows.Add()
        DGVBOLETA.Item(0, DGVBOLETA.Rows.Count - 1).Value = idganado
        DGVBOLETA.Item(1, DGVBOLETA.Rows.Count - 1).Value = peso
        DGVBOLETA.Item(2, DGVBOLETA.Rows.Count - 1).Value = precio
        DGVBOLETA.Item(3, DGVBOLETA.Rows.Count - 1).Value = subtotal
        TXTSubtotal.Text = (total * 100) / 122
        TXTIVA.Text = ((total * 22) / 122).ToString
        TXTTotalGeneral.Text = total.ToString
    End Sub
    Private Sub imprimir()
        Try
            Cursor.Current = Cursors.WaitCursor 'flecha  redonda
            With Me.PrintForm1
                .PrintAction = Printing.PrintAction.PrintToPreview ' evento q hace que imprima el form
                .PrinterSettings.DefaultPageSettings.Landscape = True 'vista preeliminar
                .Print(Me, PowerPacks.Printing.PrintForm.PrintOption.ClientAreaOnly)
            End With
            Cursor.Current = Cursors.Default ' cambia el cursor al normal
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "error al tratar de imprimir")
        End Try
    End Sub
    Private Sub BTNimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNimprimir.Click
        BTNimprimir.Hide()
        imprimir()
        BTNimprimir.Show()
    End Sub
End Class