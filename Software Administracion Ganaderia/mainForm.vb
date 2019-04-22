Imports MySql.Data.MySqlClient


Public Class mainForm

    'Objetos necesarios para realizar la conexion con la base de datos
    Dim data As String = ("Server=localhost;Database=vacas2;User id=root;Password=;Port=3306;")
    Dim connection As New MySqlConnection(Data)

    'Objetos necesario para ejecutar consultas a la DB y tratar los datos recibidos
    Dim command As New MySqlCommand
    Dim reader As MySqlDataReader

    'Array asociativo donde se almacenan todas las razas y su correspondiente id
    Dim razas As New Dictionary(Of Integer, String)

    'Metodo de reportaje de errores
    Private Function report(ByRef err As Exception)

        MsgBox(err.Message)

        Return Nothing
    End Function

    Private Sub BTNBusqueda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBusqueda.Click

        command.CommandText = ("select * from vaca where " + CBXBusqueda.SelectedItem + "='" + TXBBusqueda.Text + "'")

        DGVGanado.Rows.Clear()

        Try
            connection.Open()

            reader = command.ExecuteReader()

            While (reader.Read())
                DGVGanado.Rows.Add()

                DGVGanado.Rows(DGVGanado.Rows.GetLastRow(False)).Cells(0).Value = reader.GetInt32(0)
                DGVGanado.Rows(DGVGanado.Rows.GetLastRow(False)).Cells(1).Value = reader.GetString(1)
                DGVGanado.Rows(DGVGanado.Rows.GetLastRow(False)).Cells(2).Value = razas.Item(reader.GetInt32(2))
                DGVGanado.Rows(DGVGanado.Rows.GetLastRow(False)).Cells(3).Value = reader.GetMySqlDateTime(3)
                DGVGanado.Rows(DGVGanado.Rows.GetLastRow(False)).Cells(4).Value = reader.GetString(4)
                DGVGanado.Rows(DGVGanado.Rows.GetLastRow(False)).Cells(5).Value = reader.GetValue(5)
                DGVGanado.Rows(DGVGanado.Rows.GetLastRow(False)).Cells(6).Value = reader.GetValue(6)

            End While
        Catch ex As Exception
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If

            report(ex)
        End Try

        connection.Close()

    End Sub

    Private Function actualizarRazas()

        command.CommandText = "select * from raza"

        Try
            connection.Open()

            reader = command.ExecuteReader()

            While reader.Read()
                razas.Add(reader.GetInt32(0), reader.GetString(1))
            End While

            connection.Close()
        Catch ex As Exception

            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If

            report(ex)
        End Try

        Return Nothing

    End Function

    Private Sub mainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        command.CommandType = CommandType.Text
        command.Connection = connection

        actualizarRazas()

    End Sub
End Class