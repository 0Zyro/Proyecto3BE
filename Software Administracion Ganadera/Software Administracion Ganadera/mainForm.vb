Imports MySql.Data.MySqlClient
Imports System.Windows.Forms.DataVisualization.Charting


Public Class mainForm

    'Objetos necesarios para realizar la conexion con la base de datos
    Dim data As String = ("Server=localhost;Database=vacas2;User id=root;Password=;Port=3306;")
    Dim connection As New MySqlConnection(data)

    'Objetos necesario para ejecutar consultas a la DB y tratar los datos recibidos
    Dim command As New MySqlCommand
    Dim reader As MySqlDataReader

    'Array asociativo donde se almacenan todas las razas, estados y sexos, y sus correspondientes id
    Dim razas As New Dictionary(Of Integer, String)
    Dim estados As New Dictionary(Of Integer, String)
    Dim sexos As New Dictionary(Of Integer, String) From {{1, "macho"}, {2, "hembra"}}

    'Metodo de reportaje de errores
    Private Function report(ByVal origen As String, ByRef err As Exception)

        MsgBox(origen + vbNewLine + err.ToString)

        Return Nothing
    End Function

    Private Sub BTNBusqueda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBusqueda.Click

        Select Case CBXBusqueda.SelectedItem
            Case "Raza"
                command.CommandText = ("select * from vaca where raza in (select id from raza where nombre='" + TXBBusqueda.Text + "')")
            Case "Estado"
                command.CommandText = ("select * from vaca where estado in (select id from estado where nombre='" + TXBBusqueda.Text + "')")
            Case "Sexo"
                command.CommandText = ("select * from vaca where sexo='" + TXBBusqueda.Text + "'")
        End Select

        'command.CommandText = ("select * from vaca where " + CBXBusqueda.SelectedItem + "='" + TXBBusqueda.Text + "'")

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
                DGVGanado.Rows(DGVGanado.Rows.GetLastRow(False)).Cells(4).Value = reader.GetValue(4)
                DGVGanado.Rows(DGVGanado.Rows.GetLastRow(False)).Cells(5).Value = reader.GetValue(5)
                DGVGanado.Rows(DGVGanado.Rows.GetLastRow(False)).Cells(6).Value = estados.Item(reader.GetInt32(6))

            End While

            connection.Close()
        Catch ex As Exception
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If

            report("BTNBusqueda_Click", ex)
        End Try

    End Sub

    'Estos dos metodos cargan una lista con todos los posible estados y razas de una vaca
    Private Function actualizarEstados()
        command.CommandText = "select * from estado"

        Try
            connection.Open()

            reader = command.ExecuteReader()

            While reader.Read()
                estados.Add(reader.GetInt32(0), reader.GetString(1))
            End While

            connection.Close()
        Catch ex As Exception

            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If

            report("actualizarEstados", ex)
        End Try

        Return Nothing
    End Function
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

            report("actualizarRazas", ex)
        End Try

        Return Nothing

    End Function

    'Esto descarga informacion de la base de datos segun lo que se haya seleccionado en el combobox 'CBXFiltros'
    Private Function actualizarGrafico()

        Chart1.Series(0).Points.Clear()

        Select Case CBXFiltros.SelectedItem
            Case "Raza"
                command.CommandText = "select raza.nombre, count(raza.nombre) as cantidad from raza, vaca where vaca.raza=raza.id group by raza.nombre"

                Try
                    connection.Open()
                    reader = command.ExecuteReader()

                    While reader.Read()
                        Chart1.Series(0).Points.Add(reader.GetInt32(1))
                        Chart1.Series(0).Points.Last.Label = reader.GetString(0)
                    End While

                    connection.Close()
                Catch ex As Exception
                    If connection.State = ConnectionState.Open Then
                        connection.Close()
                    End If
                    report("actualizarGrafico > Case 'Raza'", ex)
                End Try

            Case "Estado"
                command.CommandText = "select estado.nombre, count(estado.nombre) as cantidad from estado, vaca where vaca.estado=estado.id group by estado"

                Try
                    connection.Open()
                    reader = command.ExecuteReader()

                    While reader.Read()
                        Chart1.Series(0).Points.Add(reader.GetInt32(1))
                        Chart1.Series(0).Points.Last.Label = reader.GetString(0)
                    End While
                    connection.Close()
                Catch ex As Exception
                    If connection.State = ConnectionState.Open Then
                        connection.Close()
                    End If
                    report("actualizarGrafico > Case 'Estado'", ex)
                End Try
            Case "Sexo"
                command.CommandText = "select sexo, count(sexo) as cantidad from vaca group by sexo"

                Try
                    connection.Open()
                    reader = command.ExecuteReader()

                    While reader.Read()
                        Chart1.Series(0).Points.Add(reader.GetInt32(1))
                        Chart1.Series(0).Points.Last.Label = reader.GetString(0)
                    End While
                    connection.Close()
                Catch ex As Exception
                    If connection.State = ConnectionState.Open Then
                        connection.Close()
                    End If
                    report("actualizarGrafico > Case 'Sexo'", ex)
                End Try
        End Select

        Return Nothing
    End Function

    'Esto establece los valores iniciales de los objetos tales como el objeto seleccionado de los combobox
    Private Function valoresDefault()

        command.CommandType = CommandType.Text
        command.Connection = connection

        CBXFiltros.SelectedIndex = 1

        Return Nothing
    End Function

    'Inicio del programa
    Private Sub mainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        valoresDefault()

        actualizarRazas()
        actualizarEstados()

    End Sub

    'Cada que se cambia el objeto seleccionado el combobox 'CBXFiltros', se actualiza el grafico
    Private Sub CBXFiltros_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBXFiltros.SelectedIndexChanged

        actualizarGrafico()

    End Sub

    'Esto establece los valores de busqueda y realiza dicha busqueda
    Private Function actualizarGrilla(ByVal condicion As String)

        CBXBusqueda.SelectedIndex = CBXFiltros.SelectedIndex

        TXBBusqueda.Text = condicion

        BTNBusqueda.PerformClick()

        Return Nothing
    End Function

    'Cuando se hace click en algun valor de la grafica, se muestran en el datagrid dichos valores en detalle
    Private Sub Chart1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Chart1.MouseDown

        Dim hittest As HitTestResult

        Dim point As DataPoint

        point = Nothing

        hittest = Chart1.HitTest(e.X, e.Y)

        If (hittest.ChartElementType = ChartElementType.DataPoint) Then

            point = hittest.Object

            actualizarGrilla(point.Label)

        End If

    End Sub

    'Cuando se mueve el mouse sobre el grafico, se resaltan los valores sobre los que se pasa, es una ayuda para
    'poder apreciar de manera mas grafica lo que se esta haciendo
    Private Sub Chart1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Chart1.MouseMove

        Dim hittest As HitTestResult

        Dim point As DataPoint

        hittest = Chart1.HitTest(e.X, e.Y)

        point = Nothing

        For Each p As DataPoint In Chart1.Series(0).Points
            p.BorderColor = Nothing
            p.BorderWidth = 1
        Next

        If hittest.ChartElementType = ChartElementType.DataPoint Then

            point = hittest.Object

            point.BorderColor = Color.Red
            point.BorderWidth = 3

        End If

    End Sub
End Class
