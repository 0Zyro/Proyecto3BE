Imports System.Data
Imports System.Data.OleDb
Imports MySql.Data.MySqlClient
Public Class Boleta
    Public Conexion As MySqlDataAdapter
    Public Tabla As DataTable
    Public Consulta As String
    Dim data As String = ("Server=localhost;Database=vacas;User id=root;Password=;Port=3306;")
    'Dim data As String = ("Server=www.db4free.net;Database=database_vacas;User id=zero22394;Password=zero22394;Port=3306;")
    'Objetos necesarios para la conexion
    Dim connection As New MySqlConnection(data)
    Dim comando As New MySqlCommand
    Dim reader As MySqlDataReader

    Private Sub Boleta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txbfechaboleta.Text = fechaventa

        For i As Integer = 0 To DGVBOLETA.Rows.Count - 1


            DGVBOLETA.Rows.Add()

            DGVBOLETA.Item(0, i).Value = idganado

            DGVBOLETA.Item(1, i).Value = peso
            DGVBOLETA.Item(2, i).Value = precio
            DGVBOLETA.Item(3, i).Value = subtotal


        Next





    End Sub


    Private Sub imprimir()
      
        Try
            Cursor.Current = Cursors.WaitCursor
            With Me.PrintForm1
                .PrintAction = Printing.PrintAction.PrintToPreview
                .PrinterSettings.DefaultPageSettings.Landscape = True
                .Print(Me, PowerPacks.Printing.PrintForm.PrintOption.ClientAreaOnly)
            End With
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "error al tratar de imprimir")
        End Try
    End Sub

    Private Sub BTNimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNimprimir.Click
        imprimir()
    End Sub
End Class