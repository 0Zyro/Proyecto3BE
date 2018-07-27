Imports System.Data
Imports System.Data.OleDb
Imports MySql.Data.MySqlClient

Public Class Form2
    'Dim data As String = ("Server=localhost;Database=dbproyecto;User id=root;Password=;Port=3306;")
    Dim data As String = ("Server=www.db4free.net;Database=database_vacas;User id=zero22394;Password=zero22394;Port=3306;")

    Public Conexion As MySqlDataAdapter
    Public Tabla As DataTable
    Public Consulta As String
    Public MysqlConexion As MySqlConnection = New MySqlConnection(Data)

    Public Sub consultar()
        Try
            Conexion = New MySqlDataAdapter(Consulta, data)
            Tabla = New DataTable
            Conexion.Fill(Tabla)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TabGanado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabGanado.Click

        Consulta = "select * from ganado"
        consultar()
        DataGridView1.DataSource = Tabla

        'Cambiamos los headers
        DataGridView1.Columns(0).HeaderText = "Codigo de Ganado"
        DataGridView1.Columns(1).HeaderText = "Raza"
        DataGridView1.Columns(2).HeaderText = "Sexo"
        DataGridView1.Columns(3).HeaderText = "Eatado"
        DataGridView1.Columns(4).HeaderText = "Codigo de venta"
        DataGridView1.Columns(5).HeaderText = "Precio de Vompra"
        DataGridView1.Columns(6).HeaderText = "Codigo de Compra"
        DataGridView1.Columns(7).HeaderText = "Precio de Compra"
        DataGridView1.Columns(8).HeaderText = "Peso Inicial"
        DataGridView1.Columns(9).HeaderText = "Edad"

        ' raza	sexo	estado	idventa	precioventa	idcompra	preciocompra	peso_inicial	edad
        DataGridView1.Columns(4).Visible = False
        DataGridView1.Columns(5).Visible = False
        DataGridView1.Columns(6).Visible = False
        DataGridView1.Columns(7).Visible = False

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Agregar_Ganado.Click

        If TexRaza.Text <> "" And TexSexo.Text <> "" And TexEdad.Text <> "" And TexEstado.Text <> "" And TexPeso.Text <> "" Then
            Consulta = "INSERT INTO ganado(raza,sexo,estado,peso_inicial,edad) values('" & TexRaza.Text & "','" & TexSexo.Text & "','" & TexEstado.Text & "','" & TexPeso.Text & "'','" & TexEdad.Text & "')"
            consultar()
            Consulta = "select * from ganado"
            consultar()
            DataGridViewClientes.DataSource = Tabla
            TexRaza.Text = ""
            TexSexo.Text = ""
            TexEstado.Text = ""
            TexPeso.Text = ""
            TexEdad.Text = ""
        End If
    End Sub

    'Boton "Agregar" de tab "Clientes"
    Private Sub Buttonagregarcliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttonagregarcliente.Click
        If TextBox6.Text <> "" And TextBox7.Text <> "" And TextBox8.Text <> "" And TextBox9.Text <> "" Then

            If IsNumeric(TextBox6.Text) Then
                Consulta = "INSERT INTO cliente values('" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','" & TextBox9.Text & "' )"
                consultar()
                Consulta = "select * from cliente"
                consultar()
                DataGridViewClientes.DataSource = Tabla
                TextBox6.Text = ""
                TextBox7.Text = ""
                TextBox8.Text = ""
                TextBox9.Text = ""
            Else
                MsgBox("Cedula solo valores numericos")

            End If
        Else
            MsgBox("Complete todos los campos vacios")
        End If
    End Sub

    'Se cargan los datos cuando se cambia de tab
    Private Sub TabClientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabClientes.Click

        'CARGA DATAGRIDCLIENTES
        Consulta = "select * from cliente"
        consultar()
        DataGridViewClientes.DataSource = Tabla
        DataGridViewClientes.Columns(0).HeaderText = "Cedúla"
        DataGridViewClientes.Columns(1).HeaderText = "Nombre y apellido"
        DataGridViewClientes.Columns(2).HeaderText = "Dirección"
        DataGridViewClientes.Columns(3).HeaderText = "Teléfono"
    End Sub

    'Boton "Borrar" de tab "Clientes"
    Private Sub Buttonquitarcliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttonquitarcliente.Click

        Consulta = "delete from cliente where ci='" & TextBox6.Text & "'"
        consultar()

        Consulta = "select * from cliente"
        consultar()
        DataGridViewClientes.DataSource = Tabla
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
    End Sub

    'Boton "Seleccionar" de tab "Clientes"
    Private Sub Buttonseleccionarcliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttonseleccionarcliente.Click

        TextBox6.Text = DataGridViewClientes.Item(0, DataGridViewClientes.CurrentRow.Index).Value
        TextBox7.Text = DataGridViewClientes.Item(1, DataGridViewClientes.CurrentRow.Index).Value
        TextBox8.Text = DataGridViewClientes.Item(2, DataGridViewClientes.CurrentRow.Index).Value
        TextBox9.Text = DataGridViewClientes.Item(3, DataGridViewClientes.CurrentRow.Index).Value
    End Sub

    '/////VENTAS/////
    'boton agregar
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

        Consulta = ("insert into ventas (FECHA,TOTALDEVENTA,COMENTARIO)values('" & TexRaza.Text & "','" & TexSexo.Text & "','" & TexEdad.Text & "')")

        consultar()
        MessageBox.Show("Conexión exitosa")
        TXTID.Text = ""
        TexRaza.Text = ""
        TexSexo.Text = ""
        TexEdad.Text = ""
    End Sub

    'boton modificar con sus respectivos checkbox's con la opcion de poner la id
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        If CheckBoxTODO.Checked = True Then
            Consulta = ("update ventas set IDVENTA='" & TXTID.Text & "',FECHA='" & TexRaza.Text & "',TOTALDEVENTA='" & TexSexo.Text & "',COMENTARIO='" & TexEdad.Text & "'where IDVENTA='" & TXTID.Text & "'")
            consultar()
            TXTID.Text = ""
            TexRaza.Text = ""
            TexSexo.Text = ""
            TexEdad.Text = ""

        End If

        If CheckBox1.Checked = True Then
            Consulta = ("update ventas set IDVENTA='" & TXTID.Text & "',FECHA='" & TexRaza.Text & "'where IDVENTA='" & TXTID.Text & "'")
            consultar()
            TexRaza.Text = ""
        End If
        If CheckBox2.Checked = True Then
            Consulta = ("update ventas set IDVENTA='" & TXTID.Text & "',TOTALDEVENTA='" & TexSexo.Text & "'where IDVENTA='" & TXTID.Text & "'")
            consultar()
            TexSexo.Text = ""
        End If
        If CheckBox3.Checked = True Then
            Consulta = ("update ventas set IDVENTA='" & TXTID.Text & "',COMENTARIO='" & TexEdad.Text & "'where IDVENTA='" & TXTID.Text & "'")
            consultar()
            TexEdad.Text = ""
        End If
    End Sub

    'boton borrar con opcion de poner la id para borrar
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttonborrarventas.Click
        Consulta = ("delete from ventas where IDVENTA= '" & TXTID.Text & "'")
        consultar()
        MsgBox("Borrado" + TXTID.Text)
        TXTID.Text = ""
        TexRaza.Text = ""
        TexSexo.Text = ""
        TexEdad.Text = ""
    End Sub

    Private Sub DataGridViewClientes_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewClientes.CellContentClick
        Consulta = "select * from cliente"
        consultar()
        DataGridViewClientes.DataSource = Tabla
        DataGridViewClientes.Columns(0).HeaderText = "Cedúla"
        DataGridViewClientes.Columns(1).HeaderText = "Nombre y apellido"
        DataGridViewClientes.Columns(2).HeaderText = "Dirección"
        DataGridViewClientes.Columns(3).HeaderText = "Teléfono"
    End Sub

    'Objetos auxiliares de busqueda
    Dim campos() As String = {"ci", "nombre", "permisos"}
    Dim rows(0) As String

    'Objetos necesarios para la conexion
    Dim connection As New MySqlConnection(data)
    Dim comando As New MySqlCommand
    Dim reader As MySqlDataReader

    'Boton de busqueda de usuarios
    Private Sub BotonBusquedaUsuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BotonBusquedaUsuarios.Click

        'Se borra el contenido anterior del label de informes y el listbox
        LabelInfoUsuarios.Text = ""
        ListBoxUsuarios.Items.Clear()

        'Si el panel de busqueda esta vacio se buscaran todos, en caso contrario se busca lo especificado
        If TextBoxBusquedaUsuarios.Text = "" Then
            comando.CommandText = "select ci from usuario"
        Else
            comando.CommandText = ("select ci from usuario where " + campos(ComboBoxUsuarios.SelectedIndex) + "='" + TextBoxBusquedaUsuarios.Text + "'")
        End If

        'Info necesaria para ejecutar el comando
        comando.CommandType = CommandType.Text
        comando.Connection = connection

        Try
            'Se abre la conexion, se ejecuta el comando y se guardan los resultados en "reader"
            connection.Open()
            reader = comando.ExecuteReader()

            'Si hay resultados...
            If reader.HasRows Then

                'Se limpian la lista de usuarios y el array auxiliar
                ListBoxUsuarios.Items.Clear()
                ReDim rows(0)

                'Mientras "reader" tenga mas filas por leer...
                While (reader.Read())
                    'Se leen las filas y se guardan los resultados en el array "rows"
                    rows(rows.Length - 1) = reader.GetInt32(0)
                    'Se redimensiona el array "rows" en cada lectura para albergar el siguiente dato
                    ReDim Preserve rows(rows.Length)
                End While

                'Se redimensiona "rows" para borrar los espacios vacios
                ReDim Preserve rows(rows.Length - 2)

                'Se agregan todos los elementos de "rows" a "ListBoxUsuarios" para ser mostrados
                ListBoxUsuarios.Items.AddRange(rows)

                'Se Cierra la conexion
                connection.Close()

                'Se selecciona el primer item por defecto para evitar excepciones
                ListBoxUsuarios.SetSelected(0, True)
            Else
                'Se Cierra la conexion
                connection.Close()

                'Si no se encontraron resultados se informa
                LabelInfoUsuarios.Text = "No se encontraron resultados"
            End If
        Catch ex As Exception
            'Se reportan errores
            MsgBox(ex.Message)
        End Try
    End Sub

    'Ci del usuario seleccionado actualmente
    Dim CiSeleccionado As String = ""

    'Cuando se cambia el item seleccionado en "ListBoxUsuarios"
    Private Sub ListBoxUsuarios_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBoxUsuarios.SelectedIndexChanged

        'Limpieza de busquedas anteriores
        TextBoxCiUsuarios.Text = ""
        TextBoxNombreUsuarios.Text = ""
        TextBoxPasswdUsuarios.Text = ""
        TextBoxRangoUsuarios.Text = ""

        'Informacion necesaria para el comando
        comando.CommandType = CommandType.Text
        comando.Connection = connection
        'Se hace la consulta segun que ah seleccionado el usuario en "ListBoxUsuarios"
        comando.CommandText = ("select * from usuario where ci='" + ListBoxUsuarios.SelectedItem + "'")

        Try
            'Se abre la conexion, se ejecuta el comando y se guarda el resultado en "reader"
            connection.Open()
            reader = comando.ExecuteReader()

            'Se leen los datos otenidos
            reader.Read()

            'Se mueven los datos desde "reader" a los textbox para ser mostrados
            TextBoxCiUsuarios.Text = reader.GetInt32(0).ToString
            TextBoxNombreUsuarios.Text = reader.GetString(1)
            TextBoxPasswdUsuarios.Text = reader.GetString(2)
            TextBoxRangoUsuarios.Text = reader.GetString(3)

            'Se guarda la ci del usuario seleccionado
            CiSeleccionado = TextBoxCiUsuarios.Text

            'Se cierra la conexion
            connection.Close()

        Catch ex As Exception
            'Se reportan errores
            MsgBox(ex.Message)
        End Try
    End Sub

    'Boton de eliminacion de Usuarios
    Private Sub BotonEliminarUsuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BotonEliminarUsuarios.Click

        Try
            'Se pide una confirmacion antes de proceder
            If MessageBox.Show("¿Seguro que desea eliminar a este Usuario?", "titulo xD", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                'Se ingresan los datos necesarios paras el comando
                comando.CommandType = CommandType.Text
                comando.Connection = connection
                'El usuario eliminado sera el seleccionado en "ListBoxUsuarios"
                comando.CommandText = ("delete from usuario where ci='" + ListBoxUsuarios.SelectedItem + "'")

                'Se abre la conexion
                connection.Open()

                'Se ejecuta el comando
                comando.ExecuteNonQuery()

                'Se cierra la conexion
                connection.Close()

                'Se actualiza "ListBoxUsuarios"
                BotonBusquedaUsuarios.PerformClick()

                'Se informa de la correcta eliminacion del usuario
                LabelInfoUsuarios.Text = "Usuario eliminado"

            End If
        Catch ex As Exception
            'Se reportan errores
            MsgBox(ex.Message)
        End Try
    End Sub

    'boton agregar compras
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAgregarC.Click
        If TextBoxFechadecompra.Text <> "" And TextBoxTotal.Text <> "" And TextBoxComentario.Text <> "" Then
            If IsNumeric(TextBoxTotal.Text) Then
                'Agrega los valores de los campos a cada tabla correspondiente
                Consulta = "insert into compras values ('" & TextBoxFechadecompra.Text & "','" & TextBoxTotal.Text & "','" & TextBoxComentario.Text & "')"
                consultar()
                Consulta = "select * from compras"
                consultar()
                'Actualiza la BD
                DataGridViewCompras.DataSource = Tabla
                TextBoxFechadecompra.Text = ""
                TextBoxTotal.Text = ""
                TextBoxComentario.Text = ""
            Else
                'Muestra mensaje diciendo que no se ingresaron valores numericos o que solo acepta valores numericos
                MsgBox("Igrese solo valor numerico en total")
            End If
        Else
            'Muestra mensaje que todos los campos no estan completos
            MsgBox("Complete todos los campos vacios")
        End If
    End Sub

    'Datagrid compras
    Private Sub DataGridView3_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewCompras.CellContentClick
        'Hace la consulta de los datos a la BD
        Consulta = "select * from compras"
        consultar()
        DataGridViewClientes.DataSource = Tabla
        'Cambia los titulos del datagrid
        DataGridViewClientes.Columns(0).HeaderText = "ID"
        DataGridViewClientes.Columns(1).HeaderText = "Fecha de Compra"
        DataGridViewClientes.Columns(2).HeaderText = "Total"
        DataGridViewClientes.Columns(3).HeaderText = "Comentario"
    End Sub

    'Selecciona items del datagrid
    Private Sub ButtonSeleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSeleccionarC.Click
        TextBoxID.Text = DataGridViewCompras.Item(0, DataGridViewCompras.CurrentRow.Index).Value
        TextBoxFechadecompra.Text = DataGridViewCompras.Item(1, DataGridViewCompras.CurrentRow.Index).Value
        TextBoxTotal.Text = DataGridViewCompras.Item(2, DataGridViewCompras.CurrentRow.Index).Value
        TextBoxComentario.Text = DataGridViewCompras.Item(3, DataGridViewCompras.CurrentRow.Index).Value
    End Sub

    'Boton Eliminar compras
    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminarC.Click
        'Elimina el id de una compra juntos con todos los datos de ese id
        Consulta = "delete from compras where ID='" & TextBoxID.Text & "'"
        consultar()

        Consulta = "select * from compras"
        consultar()
        'Actualiza la BD
        DataGridViewCompras.DataSource = Tabla
        TextBoxID.Text = ""
        TextBoxFechadecompra.Text = ""
        TextBoxTotal.Text = ""
        TextBoxComentario.Text = ""
        MsgBox("Datos eliminados correctamente")

    End Sub

    Private Sub ButtonBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscar.Click
        'Si el buscador esta vacio muestra todo, si no muestra lo especificado
        If TextBoxBuscador.Text = "" Then
            comando.CommandText = "select IDC from compras"
        Else
            comando.CommandText = ("select IDC from compras where " + campos(ComboBoxBuscador.SelectedIndex) + "='" + TextBoxBuscador.Text + "'")
        End If
    End Sub

    Public Sub ButtonImprimirC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonImprimirC.Click

        '    Dim Header As String
        '   Dim mAllowAddNew As Boolean
        '  mAllowAddNew = DataGridViewCompras.mAllowAddNew
        ' DataGridViewCompras.mAllowAddNew = False
        ' DataGridViewCompras.row = 0
        ' Screen.MousePointer = vbHourglass
        ' Header = " - Página n°: "
        ' REcupera los encabezados de columna  
        ' For c = 1 To DataGrid.Columns.Count
        ' MyArray(c) = Len(DataGrid.Columns(c - 1).Caption) + 10
        ' Titles = Titles & Space(10) & DataGrid.Columns(c - 1).Caption
        ' Next
        ' Configura la fuente de la impresión para el encabezado  
        ' Printer.Font.Size = 8
        ' Printer.Font.Bold = True
        ' Printer.Font.Name = "Courier New"

        '        Printer.Orientation = vbPRORPortrait
        '        l = 82

        ' imprime el titulo , el encabezado y el número de página  
        'Printer.Print(Space(40) & Titulo)
        'Printer.Print Header; Printer.Page  
        '   Printer.Print(Titles)
        '  Printer.Font.Bold = False

        'DataGridViewCompras.Refresh()
    End Sub

    'Boton de modificacion de datos de tab "Usuarios"
    Private Sub BotonModificarUsuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BotonModificarUsuarios.Click

        'Se ingresa al modo de edicion
        'donde dejan de ser visibles los botones "Agregar", "Modificar" y "Eliminar"
        BotonModificarUsuarios.Visible = False
        BotonAceptarUsuarios.Visible = True
        BotonCancelarUsuarios.Visible = True

        'No se puede cambiar el usuario seleccionado en este modo
        ListBoxUsuarios.Enabled = False

        'pasan a ser visibles los botones "Aceptar" y "Cancelar"
        BotonAgregarUsuarios.Visible = False
        BotonEliminarUsuarios.Visible = False

        'los textbox pasan a ser editables por el usuario
        TextBoxCiUsuarios.ReadOnly = False
        TextBoxNombreUsuarios.ReadOnly = False
        TextBoxPasswdUsuarios.ReadOnly = False
        TextBoxRangoUsuarios.ReadOnly = False

    End Sub

    'Boton de cancelacion de edicion de tab "Usuarios"
    Private Sub BotonCancelarUsuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BotonCancelarUsuarios.Click

        'Se actualiza "ListBoxUsuarios" para deshacer cualquier cambio realizado a los textbox
        BotonBusquedaUsuarios.PerformClick()

        'Se regresa al modo de visualizacion de datos
        BotonModificarUsuarios.Visible = True
        BotonAceptarUsuarios.Visible = False
        BotonCancelarUsuarios.Visible = False

        BotonAgregarUsuarios.Visible = True
        BotonEliminarUsuarios.Visible = True

        TextBoxCiUsuarios.ReadOnly = True
        TextBoxNombreUsuarios.ReadOnly = True
        TextBoxPasswdUsuarios.ReadOnly = True
        TextBoxRangoUsuarios.ReadOnly = True

        ListBoxUsuarios.Enabled = True
    End Sub

    'Boton 'Aceptar' de edicion de datos de tab "Usuarios"
    Private Sub BotonAceptarUsuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BotonAceptarUsuarios.Click

        'Info necesaria para el comando
        comando.CommandType = CommandType.Text
        comando.Connection = connection
        'Comando a ejecutar
        comando.CommandText = ("update usuario set ci='" + TextBoxCiUsuarios.Text +
                               "', contrasena='" + TextBoxPasswdUsuarios.Text +
                               "', nombre='" + TextBoxNombreUsuarios.Text +
                               "', permisos='" + TextBoxRangoUsuarios.Text +
                               "' where ci='" + CiSeleccionado + "'")

        Try

            'Se abre la conexion
            connection.Open()

            'Se ejecuta el comando
            comando.ExecuteNonQuery()

            'Se cierra la conexion
            connection.Close()

            'Se actualiza "ListBoxUsuarios"
            BotonBusquedaUsuarios.PerformClick()

            'Se informa de la correcta modificacion del usuario
            LabelInfoUsuarios.Text = "Usuario modificado"
        Catch ex As Exception
            'Se informan errores
            MsgBox(ex.Message)
        End Try

        'Se regresa el modo de visualizacion de datos
        BotonModificarUsuarios.Visible = True
        BotonAceptarUsuarios.Visible = False
        BotonCancelarUsuarios.Visible = False

        BotonAgregarUsuarios.Visible = True
        BotonEliminarUsuarios.Visible = True

        ListBoxUsuarios.Enabled = True

        TextBoxCiUsuarios.ReadOnly = True
        TextBoxNombreUsuarios.ReadOnly = True
        TextBoxPasswdUsuarios.ReadOnly = True
        TextBoxRangoUsuarios.ReadOnly = True
    End Sub
End Class
