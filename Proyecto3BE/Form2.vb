Imports System.Data
Imports System.Data.OleDb
Imports MySql.Data.MySqlClient

Public Class Form2

    Dim data As String = ("Server=localhost;Database=vacas;User id=root;Password=;Port=3306;")
    'Dim data As String = ("Server=www.db4free.net;Database=database_vacas;User id=zero22394;Password=zero22394;Port=3306;")



    Public Conexion As MySqlDataAdapter
    Public Tabla As DataTable
    Public Consulta As String
    Public MysqlConexion As MySqlConnection = New MySqlConnection(data)
    
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
    'Dim campos() As String = {"ci", "nombre", "rango"}
    Dim rows(0) As String

    'Objetos necesarios para la conexion
    Dim connection As New MySqlConnection(Data)
    Dim comando As New MySqlCommand
    Dim reader As MySqlDataReader

    'Boton de busqueda de usuarios
    Private Sub BotonBusquedaUsuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BotonBusquedaUsuarios.Click

        'Se borra el contenido anterior del listbox
        ListBoxUsuarios.Items.Clear()

        'Si el panel de busqueda esta vacio se buscaran todos, en caso contrario se busca lo especificado
        If TextBoxBusquedaUsuarios.Text = "" Then
            If CheckBoxUsuarios.Checked Then
                comando.CommandText = ("select ci, nombre from usuario")
            Else
                comando.CommandText = ("select ci, nombre from usuario where estado='activo'")
            End If
        Else
            If CheckBoxUsuarios.Checked Then
                comando.CommandText = ("select ci, nombre from usuario where " + ComboBoxUsuarios.SelectedItem + "='" + TextBoxBusquedaUsuarios.Text + "'")
            Else
                comando.CommandText = ("select ci, nombre from usuario where estado='activo' and " + ComboBoxUsuarios.SelectedItem + "='" + TextBoxBusquedaUsuarios.Text + "'")
            End If
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
                    rows(rows.Length - 1) = (Convert.ToString(reader.GetInt32(0)) + " " + reader.GetString(1))
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
            MsgBox("Error: " + ex.Message)
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
            LabelEstadoUsuarios.Text = reader.GetString(4)

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
            If MessageBox.Show("¿Seguro que desea eliminar a este Usuario?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                'Se ingresan los datos necesarios paras el comando
                comando.CommandType = CommandType.Text
                comando.Connection = connection
                'El usuario eliminado sera el seleccionado en "ListBoxUsuarios"
                comando.CommandText = ("update usuario set estado='inactivo' where ci='" + (ListBoxUsuarios.SelectedItem).ToString.Split(" ")(0) + "'")

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
    'Boton de modificacion de datos de tab "Usuarios"
    Private Sub BotonModificarUsuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BotonModificarUsuarios.Click

        LabelInfoUsuarios.Text = ""
        estadoModificar()

    End Sub

    'Boton de cancelacion de edicion de tab "Usuarios"
    Private Sub BotonCancelarUsuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BotonCancelarUsuarios.Click

        LabelInfoUsuarios.Text = ""
        estadoVisualizar()

    End Sub

    'Boton 'Aceptar' de edicion de datos de tab "Usuarios"
    Private Sub BotonAceptarUsuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BotonAceptarUsuarios.Click

        'Info necesaria para el comando
        comando.CommandType = CommandType.Text
        comando.Connection = connection

        Select Case estadoUsuario
            Case "modificar"
                comando.CommandText = ("update usuario set ci='" + TextBoxCiUsuarios.Text +
                               "', contrasena='" + TextBoxPasswdUsuarios.Text +
                               "', nombre='" + TextBoxNombreUsuarios.Text +
                               "', rango='" + TextBoxRangoUsuarios.Text +
                               "' where ci='" + CiSeleccionado + "'")
                Try
                    'Se abre la conexion
                    connection.Open()
                    'Se ejecuta el comando
                    comando.ExecuteNonQuery()
                    'Se cierra la conexion
                    connection.Close()
                    'Se informa de la correcta modificacion del usuario
                    LabelInfoUsuarios.Text = "Usuario modificado"
                Catch ex As Exception
                    'Se informan errores
                    MsgBox("Error: " + ex.Message)
                End Try
                estadoVisualizar()
                Exit Select
            Case "agregar"
                If verificarCedula(TextBoxCiUsuarios.Text) Then
                    If TextBoxCiUsuarios.Text.Length > 6 Then
                        If TextBoxPasswdUsuarios.Text.Length > 7 Then
                            If TextBoxRangoUsuarios.Text.Length > 3 Then
                                comando.CommandText = ("insert into usuario values ('" + TextBoxCiUsuarios.Text + "','" + TextBoxNombreUsuarios.Text + "','" + TextBoxPasswdUsuarios.Text + "','" + TextBoxRangoUsuarios.Text + "','activo')")
                                Try
                                    connection.Open()
                                    comando.ExecuteNonQuery()
                                    connection.Close()
                                Catch ex As Exception
                                    LabelInfoUsuarios.Text = ("Error:" + ex.Message)
                                End Try
                            Else
                                LabelInfoUsuarios.Text = "Rango erroneo"
                            End If
                        Else
                            LabelInfoUsuarios.Text = "Contraseña erronea"
                        End If
                    Else
                        LabelInfoUsuarios.Text = "Nombre erroneo"
                    End If
                Else
                    LabelInfoUsuarios.Text = "Cedula erronea"
                End If
        End Select
    End Sub

    Private Function verificarCedula(ByVal cedula As String)

        If Not IsNumeric(cedula) Or Not cedula.Length = 8 Then
            Return False
        End If

        Dim codigoVerificador() As Integer = {2, 9, 8, 7, 6, 3, 4}
        Dim arrayCedula() As Char = cedula.ToCharArray

        Dim auxSum As Integer = 0
        Dim auxTemp, auxFin As Integer

        For i As Integer = 0 To 6
            auxTemp = Char.GetNumericValue(arrayCedula(i)) * codigoVerificador(i)
            auxSum = auxSum + auxTemp
        Next

        auxTemp = auxSum Mod 10
        auxFin = (10 - auxTemp) Mod 10

        If Char.GetNumericValue(arrayCedula(7)) = auxFin Then
            Return True
        Else
            Return False
        End If
    End Function

    Dim estadoUsuario As String = "visualizar"

    Private Sub BotonAgregarUsuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BotonAgregarUsuarios.Click
        LabelInfoUsuarios.Text = ""
        estadoAgregar()
    End Sub

    Private Sub estadoModificar()

        estadoUsuario = "modificar"

        BotonAceptarUsuarios.Visible = True
        BotonCancelarUsuarios.Visible = True

        BotonBusquedaUsuarios.Enabled = False

        ListBoxUsuarios.Enabled = False

        ComboBoxUsuarios.Enabled = False

        BotonAgregarUsuarios.Visible = False
        BotonEliminarUsuarios.Visible = False
        BotonModificarUsuarios.Visible = False

        TextBoxCiUsuarios.ReadOnly = False
        TextBoxNombreUsuarios.ReadOnly = False
        TextBoxPasswdUsuarios.ReadOnly = False
        TextBoxRangoUsuarios.ReadOnly = False

        TextBoxBusquedaUsuarios.ReadOnly = True

    End Sub
    Private Sub estadoAgregar()

        estadoModificar()

        estadoUsuario = "agregar"

        TextBoxCiUsuarios.Text = ""
        TextBoxNombreUsuarios.Text = ""
        TextBoxPasswdUsuarios.Text = ""
        TextBoxRangoUsuarios.Text = ""

    End Sub
    Private Sub estadoVisualizar()

        estadoUsuario = "visualizar"

        BotonAceptarUsuarios.Visible = False
        BotonCancelarUsuarios.Visible = False

        BotonBusquedaUsuarios.Enabled = True

        ListBoxUsuarios.Enabled = True

        ComboBoxUsuarios.Enabled = True

        BotonModificarUsuarios.Visible = True
        BotonAgregarUsuarios.Visible = True
        BotonEliminarUsuarios.Visible = True

        TextBoxCiUsuarios.ReadOnly = True
        TextBoxNombreUsuarios.ReadOnly = True
        TextBoxPasswdUsuarios.ReadOnly = True
        TextBoxRangoUsuarios.ReadOnly = True

        TextBoxBusquedaUsuarios.ReadOnly = False

        BotonBusquedaUsuarios.PerformClick()

    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Consulta = "select * from compra"
        consultar()
        DataGridViewCompras.DataSource = Tabla
        ComboBoxUsuarios.SelectedIndex = 0
        Panelprincipalcompras.BringToFront()
        Panelagregarcompras.SendToBack()
        Panelmodificarcompras.SendToBack()
        Panelmodificarcompras.Visible = False
        Panelmodificarcompras.Enabled = False
        Panelagregarcompras.Visible = False
        Panelagregarcompras.Enabled = False
        DataGridViewCompras.Columns(0).HeaderText = "Id"
        DataGridViewCompras.Columns(1).HeaderText = "Fecha de Compra"
        DataGridViewCompras.Columns(2).HeaderText = "Comentario"
        DataGridViewCompras.Columns(3).HeaderText = "Total"

    End Sub

    Private Sub CheckBoxUsuarios_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxUsuarios.CheckStateChanged
        BotonBusquedaUsuarios.PerformClick()

        If CheckBoxUsuarios.Checked Then
            LabelEstadoUsuarios.Visible = True
        Else
            LabelEstadoUsuarios.Visible = False
        End If
    End Sub

    Private Sub CheckBoxPasswdUsuarios_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxPasswdUsuarios.CheckStateChanged
        If CheckBoxPasswdUsuarios.Checked Then
            TextBoxPasswdUsuarios.PasswordChar = ""
        Else
            TextBoxPasswdUsuarios.PasswordChar = "+"
        End If
    End Sub
    '///////////////////////////////////////////////////////////Datagried Compras///////////////////////////////////
    Private Sub DataGridViewCompras_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewCompras.CellContentClick
        'Hace la consulta de los datos a la BD
        Consulta = "select * from compra"
        consultar()
        DataGridViewCompras.DataSource = Tabla
        consultar()
        'Cambia los titulos del datagrid
        DataGridViewCompras.Columns(0).HeaderText = "Id"
        DataGridViewCompras.Columns(1).HeaderText = "Fecha de Compra"
        DataGridViewCompras.Columns(2).HeaderText = "Comentario"
        DataGridViewCompras.Columns(3).HeaderText = "Total"
    End Sub
    Private Sub Volveragregarcompras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Volveragregarcompras.Click



        '/////////Panel agregar compras/////////////
        Panelagregarcompras.SendToBack()
        Panelagregarcompras.Visible = False
        Panelagregarcompras.Enabled = False


        '////////Panel principal compras///////////////
        Panelprincipalcompras.Enabled = True
        Panelprincipalcompras.Visible = True
        Panelprincipalcompras.BringToFront()



    End Sub

    Private Sub Agregarcompra1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Agregarcompra1.Click
        '/////////Panel agregar compras/////////////
        Panelagregarcompras.BringToFront()
        Panelagregarcompras.Visible = True
        Panelagregarcompras.Enabled = True
        Panelmodificarcompras.Visible = False
        Panelmodificarcompras.Enabled = False

        Volveragregarcompras.Visible = True


    End Sub

    Private Sub Volvermodificarcompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Volvermodificarcompra.Click
        Panelmodificarcompras.Enabled = False
        Panelmodificarcompras.Visible = False
        Panelmodificarcompras.SendToBack()




        Panelprincipalcompras.Enabled = True
        Panelprincipalcompras.Visible = True
        Panelprincipalcompras.BringToFront()
    End Sub

    Private Sub Limpiarmodificarcompras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Limpiarmodificarcompras.Click
        Modificarcomentariocompra.Clear()
        Modificarfechacompra.Clear()
        Modificartotalapagarcompra.Clear()



    End Sub

    Private Sub Agregarmodificacioncompras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Agregarmodificacioncompras.Click
        If Modificarfechacompra.Text <> "" And Modificarcomentariocompra.Text <> "" And Modificartotalapagarcompra.Text <> "" Then
            If IsNumeric(Modificartotalapagarcompra.Text) Then
                'Agrega los valores de los campos a cada tabla correspondiente
                Consulta = "upgrade compra set (0,'" & Modificarfechacompra.Text & "','" & Modificarcomentariocompra.Text & "','" & Modificartotalapagarcompra.Text & "')"
                consultar()
                Consulta = "select * from compra"
                consultar()
                'Actualiza la BD
                DataGridViewCompras.DataSource = Tabla
                'Deja a los textbox vacios para ingresar nuevos datos
                Modificarfechacompra.Text = ""
                Modificarcomentariocompra.Text = ""
                Modificartotalapagarcompra.Text = ""
            Else
                'Muestra mensaje diciendo que no se ingresaron valores numericos o que solo acepta valores numericos
                MsgBox("Igrese solo valor numerico en total")
            End If
        Else
            'Muestra mensaje que todos los campos no estan completos
            MsgBox("Complete todos los campos vacios")
        End If
    End Sub

    Private Sub Agregarcompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Agregarcompra.Click
        If Fechacompra.Text <> "" And Comentariocompras.Text <> "" And Totalpagadocompras.Text <> "" Then
            If IsNumeric(Totalpagadocompras.Text) Then
                'Agrega los valores de los campos a cada tabla correspondiente
                Consulta = "insert into compra values (0,'" & Fechacompra.Text & "','" & Comentariocompras.Text & "','" & Totalpagadocompras.Text & "')"
                consultar()
                Consulta = "select * from compra"
                consultar()
                'Actualiza la BD
                DataGridViewCompras.DataSource = Tabla
                'Deja a los textbox vacios para ingresar nuevos datos
                Fechacompra.Text = ""
                Comentariocompras.Text = ""
                Totalpagadocompras.Text = ""
            Else
                'Muestra mensaje diciendo que no se ingresaron valores numericos o que solo acepta valores numericos
                MsgBox("Igrese solo valor numerico en total")
            End If
        Else
            'Muestra mensaje que todos los campos no estan completos
            MsgBox("Complete todos los campos vacios")
        End If

    End Sub
    Private Sub Clearagregarcompras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Clearagregarcompras.Click
        Fechacompra.Clear()
        Comentariocompras.Clear()
        Totalpagadocompras.Clear()
    End Sub
End Class