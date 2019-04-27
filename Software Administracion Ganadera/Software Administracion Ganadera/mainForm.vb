Imports MySql.Data.MySqlClient
Imports System.Windows.Forms.DataVisualization.Charting

Public Class mainForm

    'Objetos necesarios para realizar la conexion con la base de datos
    Dim data As String = ("Server=localhost;Database=vacas2;User id=root;Password=;Port=3306;")
    Dim connection As New MySqlConnection(data)

    'Objetos necesario para ejecutar consultas a la DB y tratar los datos recibidos
    Dim command As New MySqlCommand
    Dim reader As MySqlDataReader

    'Metodo de reportaje de errores
    Private Function report(ByVal origen As String, ByRef err As Exception)

        MsgBox(origen + vbNewLine + err.ToString)

        Return Nothing
    End Function

    'Esto establece los valores iniciales de los objetos tales como el objeto seleccionado de los combobox
    Private Function valoresDefault()

        command.CommandType = CommandType.Text
        command.Connection = connection

        CBXFiltros.SelectedIndex = 1

        LBLFiltros.Text = ""

        actualizarGanadoActivo()

        Return Nothing
    End Function

    'Inicio del programa
    Private Sub mainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        valoresDefault()

    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                  TAB GANADO
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    'String en el que se guardaran los filtros de busqueda con los que se este trabajando
    Dim filtros As String = ""

    'Se consulta a la base de datos informacion segun los paramentros establecidos en el combobox de busqueda y el
    'textbox de busqueda, tambien se tienen en cuenta los filtros asignados como permanentes
    Private Sub BTNBusqueda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBusqueda.Click

        command.CommandText = ("select vaca.id, vaca.sexo, raza.nombre as raza, estado.nombre as estado, vaca.nacimiento from vaca, raza, estado where vaca.raza=raza.id and vaca.estado=estado.id and " + CBXBusqueda.SelectedItem + " in (select id from " + CBXBusqueda.SelectedItem + " where nombre='" + TXBBusqueda.Text + "') " + filtros)

        If CBXBusqueda.SelectedItem = "Sexo" Then
            command.CommandText = ("select vaca.id, vaca.sexo, raza.nombre as raza, estado.nombre as estado, vaca.nacimiento from vaca, raza, estado where vaca.raza=raza.id and vaca.estado=estado.id and sexo='" + TXBBusqueda.Text + "' " + filtros)
        End If

        DGVGanado.Rows.Clear()

        Try
            connection.Open()

            reader = command.ExecuteReader()

            While (reader.Read())
                DGVGanado.Rows.Add()

                DGVGanado.Rows(DGVGanado.Rows.GetLastRow(False)).Cells(0).Value = reader.GetInt32(0)
                DGVGanado.Rows(DGVGanado.Rows.GetLastRow(False)).Cells(1).Value = reader.GetString(1)
                DGVGanado.Rows(DGVGanado.Rows.GetLastRow(False)).Cells(2).Value = reader.GetValue(2)
                DGVGanado.Rows(DGVGanado.Rows.GetLastRow(False)).Cells(3).Value = reader.GetValue(3)
                DGVGanado.Rows(DGVGanado.Rows.GetLastRow(False)).Cells(4).Value = reader.GetMySqlDateTime(4)

            End While

            connection.Close()
        Catch ex As Exception
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If

            report("BTNBusqueda_Click", ex)
        End Try

    End Sub

    'Consulta la cantidad de ganado vivo y lo carga a un label
    Private Function actualizarGanadoActivo()

        command.CommandText = "select count(id) from vaca where estado in (select id from estado where nombre='Vivo')"

        Try
            connection.Open()

            reader = command.ExecuteReader()

            reader.Read()

            LBLGanadoActivo.Text = ("Ganado activo: " + reader.GetInt32(0).ToString)

            connection.Close()
        Catch ex As Exception
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If

            report("actualizarGanadoActivo", ex)
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

    'Esto establece los valores de busqueda y realiza dicha busqueda
    Private Function actualizarGrilla(ByVal condicion As String)

        CBXBusqueda.SelectedIndex = CBXFiltros.SelectedIndex

        TXBBusqueda.Text = condicion

        BTNBusqueda.PerformClick()

        Return Nothing
    End Function

    'Cada que se cambia el objeto seleccionado el combobox 'CBXFiltros', se actualiza el grafico
    Private Sub CBXFiltros_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBXFiltros.SelectedIndexChanged

        actualizarGrafico()

    End Sub

    'Cuando se hace doble click en algun valor de la grafica se agrega este parametro de busqueda como permantente
    'para poder realizar busquedas mas elaboradas
    Private Sub Chart1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Chart1.MouseDoubleClick

        Dim hittest As HitTestResult

        Dim point As DataPoint

        point = Nothing

        hittest = Chart1.HitTest(e.X, e.Y)

        If (hittest.ChartElementType = ChartElementType.DataPoint) Then

            point = hittest.Object

            If (CBXFiltros.SelectedItem = "Sexo") Then
                filtros = filtros + ("and sexo='" + TXBBusqueda.Text + "'")
            Else
                filtros = filtros + ("and " + CBXFiltros.SelectedItem + " in (select id from " + CBXFiltros.SelectedItem + " where nombre='" + TXBBusqueda.Text + "')")
            End If

            LBLFiltros.Text = LBLFiltros.Text + (CBXFiltros.SelectedItem + "=" + TXBBusqueda.Text + " | ")

        End If

    End Sub

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

    'Boton que quita todas las etiquetas de busqueda
    Private Sub BTNLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNLimpiar.Click

        filtros = ""
        LBLFiltros.Text = filtros

        actualizarGrafico()
        actualizarGrilla("")

    End Sub

    'Elimina la vaca segun la id de la fila seleccionada en el data grid
    Private Sub BTNEliminarGanado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNEliminarGanado.Click
        If DGVGanado.SelectedCells.Count <> 0 Then

            command.CommandText = ("delete from vaca where id='" + DGVGanado.SelectedCells(0).Value.ToString + "'")

            Try
                connection.Open()

                command.ExecuteNonQuery()

                connection.Close()

                actualizarGrafico()

                actualizarGrilla("")

            Catch ex As Exception
                If connection.State = ConnectionState.Open Then
                    connection.Close()
                End If
                report("BTNEliminarGanado_Click", ex)
            End Try

        End If
    End Sub

    Private Sub BTNAgregarGanado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNAgregarGanado.Click

        command.CommandText = ("select nombre from raza")

        CBXAgregarGanadoRaza.Items.Clear()

        Try
            connection.Open()

            reader = command.ExecuteReader()

            While reader.Read()
                CBXAgregarGanadoRaza.Items.Add(reader.GetString(0))
            End While

            connection.Close()

            DGVGanado.Visible = False
            PNLAgregarGanado.Visible = True

        Catch ex As Exception
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If

            report("BTNAgregarGanado_Click", ex)
        End Try

    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                  FIN TAB GANADO
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

End Class