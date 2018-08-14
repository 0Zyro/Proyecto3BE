Imports System.Data
Imports System.Data.OleDb
Imports MySql.Data.MySqlClient
Imports System.IO

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

    '///SECCION USUARIOS

    'Objetos auxiliares de busqueda
    Dim rows(0) As String

    'Objetos necesarios para la conexion
    Dim connection As New MySqlConnection(data)
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
            LabelInfoUsuarios.Text = ("Error: " + ex.Message)

            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If

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
        'Se hace la consulta segun que ha seleccionado el usuario en "ListBoxUsuarios"
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

            If Dir$("../../Res/profile/" + reader.GetString(5) + ".bmp") <> "" Then
                PictureBoxUsuarios.Image = Image.FromFile("../../Res/profile/" + reader.GetString(5) + ".bmp")
            Else
                PictureBoxUsuarios.Image = Image.FromFile("../../Res/profile/default.bmp")
            End If

            'Se guarda la ci del usuario seleccionado
            CiSeleccionado = TextBoxCiUsuarios.Text

            'Se cierra la conexion
            connection.Close()

        Catch ex As Exception
            'Se reportan errores
            LabelInfoUsuarios.Text = ("Error: " + ex.Message)
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
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
                               "', perfil='" + StringImagenUsuarios +
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
                                comando.CommandText = ("insert into usuario values ('" + TextBoxCiUsuarios.Text + "','" + TextBoxNombreUsuarios.Text + "','" + TextBoxPasswdUsuarios.Text + "','" + TextBoxRangoUsuarios.Text + "','activo','" + StringImagenUsuarios + "')")
                                Try
                                    If connection.State Then
                                        MsgBox("asds")
                                    End If
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
        estadoVisualizar()
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
        CheckBoxUsuarios.Enabled = False

        ListBoxUsuarios.Enabled = False

        ComboBoxUsuarios.Enabled = False

        BotonAgregarUsuarios.Visible = False
        BotonEliminarUsuarios.Visible = False
        BotonModificarUsuarios.Visible = False

        TextBoxCiUsuarios.ReadOnly = False
        TextBoxNombreUsuarios.ReadOnly = False
        TextBoxPasswdUsuarios.ReadOnly = False
        TextBoxRangoUsuarios.ReadOnly = False
        PictureBoxUsuarios.Enabled = True

        TextBoxBusquedaUsuarios.ReadOnly = True

    End Sub
    Private Sub estadoAgregar()

        estadoModificar()

        estadoUsuario = "agregar"

        PictureBoxUsuarios.Image = Image.FromFile("../../Res/profile/nueva.bmp")

        TextBoxCiUsuarios.Text = ""
        TextBoxNombreUsuarios.Text = ""
        TextBoxPasswdUsuarios.Text = ""
        TextBoxRangoUsuarios.Text = ""

        CheckBoxUsuarios.Checked = False

    End Sub
    Private Sub estadoVisualizar()

        estadoUsuario = "visualizar"

        BotonAceptarUsuarios.Visible = False
        BotonCancelarUsuarios.Visible = False

        BotonBusquedaUsuarios.Enabled = True
        CheckBoxUsuarios.Enabled = True

        ListBoxUsuarios.Enabled = True

        ComboBoxUsuarios.Enabled = True

        BotonModificarUsuarios.Visible = True
        BotonAgregarUsuarios.Visible = True
        BotonEliminarUsuarios.Visible = True

        TextBoxCiUsuarios.ReadOnly = True
        TextBoxNombreUsuarios.ReadOnly = True
        TextBoxPasswdUsuarios.ReadOnly = True
        TextBoxRangoUsuarios.ReadOnly = True
        PictureBoxUsuarios.Enabled = False

        TextBoxBusquedaUsuarios.ReadOnly = False

        BotonBusquedaUsuarios.PerformClick()

        StringImagenUsuarios = "default"

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

    Dim openFileDialog As New OpenFileDialog()

    Dim StringImagenUsuarios As String = "default"

    Private Sub PictureBoxUsuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxUsuarios.Click
        BuscarImagen()
    End Sub

    Private Sub BuscarImagen()

        openFileDialog.InitialDirectory = "c:\"
        openFileDialog.Filter = "Image Files (*.bmp)|*.bmp"
        openFileDialog.FilterIndex = 1
        openFileDialog.RestoreDirectory = True

        Dim aux() As String

        Dim ImagenUsuarios As Image

        If openFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            If openFileDialog.FileName.Split(".")(1) = "bmp" Then
                Try
                    ImagenUsuarios = Image.FromFile(openFileDialog.FileName)
                    If ImagenUsuarios.Height <= 90 And ImagenUsuarios.Width <= 90 Then
                        aux = openFileDialog.FileName.Split("\")
                        aux = aux(aux.Length - 1).Split(".")
                        StringImagenUsuarios = aux(0)
                    Else
                        openFileDialog.FileName = ""
                        MsgBox("La imagen seleccionda no debe superar 90 x 90")
                    End If
                Catch Ex As Exception
                    openFileDialog.FileName = ""
                    LabelInfoUsuarios.Text = ("Error: " + Ex.Message)
                End Try
            Else
                openFileDialog.FileName = ""
                MsgBox("Imagenes .BMP unicamente")
                BuscarImagen()
            End If
        End If
    End Sub

    '///FIN SECCION USUARIOS

    
    'Se cargan los datos cuando se cambia de tab
    Private Sub TabClientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabClientes.Click

    End Sub





    '/////VENTAS/////
    'boton agregar







    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/////// CONSULTA VENTA
        Consulta = "select * from venta"
        consultar()
        'actualiza la dgvw
        DataGridViewVENTAS.DataSource = Tabla
        labeldeventa.Visible = False
        'label's hide
        txbcedulaclienteventa.Visible = False
        labelidv.Visible = False




        '////////////USUARIOS
        ComboBoxUsuarios.SelectedIndex = 0

        '////////////CLIENTES
        PanelPrincipalclientes.Enabled = True
        PanelPrincipalclientes.Visible = True
        PanelPrincipalclientes.BringToFront()

        PanelAgregarcliente.Enabled = False
        PanelAgregarcliente.Visible = False

        'CARGA DATAGRIDCLIENTES
        Consulta = "select * from cliente"
        consultar()
        DataGridViewClientes.DataSource = Tabla
        DataGridViewClientes.Columns(0).HeaderText = "Cedúla"
        DataGridViewClientes.Columns(1).HeaderText = "Nombre y apellido"
        DataGridViewClientes.Columns(2).HeaderText = "Dirección"
        DataGridViewClientes.Columns(3).HeaderText = "Teléfono"

        'CONSULTA DE TABLA(CARGA COMPRA)
        Consulta = "select * from compra"
        consultar()
        DataGridViewCompras.DataSource = Tabla
        DataGridViewCompras.Columns(0).HeaderText = "Id"
        DataGridViewCompras.Columns(1).HeaderText = "Fecha de Compra"
        DataGridViewCompras.Columns(2).HeaderText = "Comentario"
        DataGridViewCompras.Columns(3).HeaderText = "Total"

        'Nose que es esto
        ComboBoxUsuarios.SelectedIndex = 0

        'Muestra el panel principal de Compras y oculta los otros
        Panelprincipalcompras.BringToFront()
        Panelmodificarcompras.Visible = False
        Panelagregarcompras.Visible = False

        'CONSULTA DE TABLA GANADO
        Consulta = "select * from ganado"
        consultar()
        DataGridViewganado.DataSource = Tabla

        'Cambiamos los headers
        DataGridViewganado.Columns(0).HeaderText = "Codigo de ganado"
        DataGridViewganado.Columns(1).HeaderText = "Raza"
        DataGridViewganado.Columns(2).HeaderText = "Sexo"
        DataGridViewganado.Columns(3).HeaderText = "Fecha nacimiento"
        DataGridViewganado.Columns(4).HeaderText = "Estado"
        DataGridViewganado.Columns(5).HeaderText = "Precio de venta"
        DataGridViewganado.Columns(6).HeaderText = "Precio de compra"
        DataGridViewganado.Columns(7).HeaderText = "Codigo de vompra"
        DataGridViewganado.Columns(8).HeaderText = "Codigo de venta"

        ' raza	sexo	estado	idventa	precioventa	idcompra	preciocompra	peso_inicial	edad
        DataGridViewganado.Columns(5).Visible = False
        DataGridViewganado.Columns(6).Visible = False
        DataGridViewganado.Columns(7).Visible = False
        DataGridViewganado.Columns(8).Visible = False

    End Sub

    '///////////////////////////////////////////////////////////Datagried Compras///////////////////////////////////
    Private Sub DataGridViewCompras_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewCompras.CellContentClick
        DataGridViewCompras.Rows(e.RowIndex).Selected = True
        'Hace la consulta de los datos a la BD
        'Consulta = "select * from compra"
        'consultar()
        'DataGridViewCompras.DataSource = Tabla
        'consultar()
        ''Cambia los titulos del datagrid
        'DataGridViewCompras.Columns(0).HeaderText = "Id"
        'DataGridViewCompras.Columns(1).HeaderText = "Fecha de Compra"
        'DataGridViewCompras.Columns(2).HeaderText = "Comentario"
        'DataGridViewCompras.Columns(3).HeaderText = "Total"
    End Sub
    '//////////////Boton volver de agregar compras////////////
    Private Sub Volveragregarcompras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Volveragregarcompras.Click
        'Muestra panel pricipal de compras
        Panelprincipalcompras.Enabled = True
        Panelprincipalcompras.Visible = True
        Panelprincipalcompras.BringToFront()


        'Oculta panel de agregar compras
        Panelagregarcompras.SendToBack()
        Panelagregarcompras.Visible = False
        Panelagregarcompras.Enabled = False

    End Sub
    '/////////////////////////Boton de agregar compras////////////
    Private Sub Agregarcompra1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Agregarcompra1.Click
        'Muestra el panel de agregar compras
        Panelagregarcompras.BringToFront()
        Panelagregarcompras.Visible = True
        Panelagregarcompras.Enabled = True

        'Oculta el panel principal de compras
        Panelprincipalcompras.SendToBack()
        Panelprincipalcompras.Enabled = False
        Panelprincipalcompras.Visible = False
    End Sub
    '////////////Boton volver modificar compras///////////////
    Private Sub Volvermodificarcompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Volvermodificarcompra.Click
        'Oculta el panel de modificar compra
        Panelmodificarcompras.Enabled = False
        Panelmodificarcompras.Visible = False
        Panelmodificarcompras.SendToBack()

        'Muestra el panel principal de compra
        Panelprincipalcompras.Enabled = True
        Panelprincipalcompras.Visible = True
        Panelprincipalcompras.BringToFront()

        'Actualiza el datagrid del panel principal de compras
        Consulta = "select * from compra"
        consultar()
        DataGridViewCompras.DataSource = Tabla
        'Cambia los headers de las tablas
        DataGridViewCompras.Columns(0).HeaderText = "Id"
        DataGridViewCompras.Columns(1).HeaderText = "Fecha de Compra"
        DataGridViewCompras.Columns(2).HeaderText = "Comentario"
        DataGridViewCompras.Columns(3).HeaderText = "Total Pagado"
    End Sub
    '/////////////////////Boton clear de modificar compras//////////////////
    Private Sub Limpiarmodificarcompras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Limpiarmodificarcompras.Click
        'Deja los textbox vacios
        Modificarcomentariocompra.Clear()
        Modificarfechacompra.Clear()
        Modificartotalapagarcompra.Clear()
    End Sub
    '//////////////boton que agrega la compra/////////////////////////
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
    '////////////////Boton clear de agregar compra//////////////
    Private Sub Clearagregarcompras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Clearagregarcompras.Click
        'Deja los textbox vacios
        Fechacompra.Clear()
        Comentariocompras.Clear()
        Totalpagadocompras.Clear()
    End Sub
    '////////////////////Boton muestra panel de modificar compras///////////////////
    Private Sub Modificarcompra1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Modificarcompra1.Click
        'Muestra el panel de modificar compras
        Panelmodificarcompras.BringToFront()
        Panelmodificarcompras.Visible = True
        Panelmodificarcompras.Enabled = True

        'Actualiza datagrid de panel modificar compras
        Consulta = "select * from compra"
        consultar()
        DataGridViewModificarCompras.DataSource = Tabla
        'Cambia los headers
        DataGridViewModificarCompras.Columns(0).HeaderText = "Id"
        DataGridViewModificarCompras.Columns(1).HeaderText = "Fecha de Compra"
        DataGridViewModificarCompras.Columns(2).HeaderText = "Comentario"
        DataGridViewModificarCompras.Columns(3).HeaderText = "Total Pagado"

        'Oculta panel principal compras
        Panelprincipalcompras.SendToBack()
        Panelprincipalcompras.Visible = False
        Panelprincipalcompras.Enabled = False
    End Sub

    Private Sub Clearagregarclientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Clearagregarclientes.Click
        Texcedula.Clear()
        Texdireccion.Clear()
        Texnombreapellido.Clear()
        Texttelefono.Clear()

    End Sub

    Private Sub Volveragregarclientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Volveragregarclientes.Click
        PanelPrincipalclientes.BringToFront()
        PanelPrincipalclientes.Visible = True
        PanelPrincipalclientes.Enabled = True

        Consulta = "select * from cliente"
        consultar()
        DataGridViewClientes.DataSource = Tabla


        PanelAgregarcliente.Enabled = False
        PanelAgregarcliente.Visible = False
        PanelAgregarcliente.SendToBack()

    End Sub

    Private Sub Agregarclientes1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Agregarclientes1.Click
        PanelAgregarcliente.BringToFront()
        PanelAgregarcliente.Visible = True
        PanelAgregarcliente.Enabled = True

        PanelPrincipalclientes.SendToBack()
        PanelPrincipalclientes.Visible = False
        PanelPrincipalclientes.Enabled = False
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim consulta As String
        Dim lista As Byte
        Dim datos As DataSet
        If Texbuscarcliente.Text <> "" Then
            consulta = " select * from cliente where id = '" & Texbuscarcliente.Text & "'"
            Conexion = New MySqlDataAdapter(consulta, data)
            datos = New DataSet
            Conexion.Fill(datos, "cliente")
            lista = datos.Tables("cliente").Rows.Count

            If lista <> 0 Then
                Nombreyapellidomodificarcliente.Text = datos.Tables("cliente").Rows(0).Item(1)
                Cedulamodificarcliente.Text = datos.Tables("cliente").Rows(0).Item(0)
                Direccionmodificarcliente.Text = datos.Tables("cliente").Rows(0).Item(2)
                Telefonomodificarcliente.Text = datos.Tables("cliente").Rows(0).Item(3)

            Else
                MsgBox("Datos no encontrados")
            End If

        End If

    End Sub
    Private Sub Agregarcliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Agregarcliente.Click
        If Texcedula.Text <> "" And Texnombreapellido.Text <> "" And Texdireccion.Text <> "" And Texttelefono.Text <> "" Then

            If IsNumeric(Texcedula.Text) Then
                Consulta = "INSERT INTO cliente values('" & Texcedula.Text & "','" & Texnombreapellido.Text & "','" & Texdireccion.Text & "','" & Texttelefono.Text & "' )"
                consultar()
                Consulta = "select * from cliente"
                consultar()
                DataGridViewClientes.DataSource = Tabla
                Texcedula.Text = ""
                Texnombreapellido.Text = ""
                Texdireccion.Text = ""
                Texttelefono.Text = ""
                MsgBox("Registro exitoso")
            Else
                MsgBox("Cedula solo valores numericos")

            End If
        Else
            MsgBox("Complete todos los campos vacios")
        End If
    End Sub

    Private Sub Volvermodificarcliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Volvermodificarcliente.Click
        PanelPrincipalclientes.BringToFront()
        PanelPrincipalclientes.Visible = True
        PanelPrincipalclientes.Enabled = True

        Consulta = "select * from cliente"
        consultar()
        DataGridViewClientes.DataSource = Tabla
        'DataGridViewClientes.Columns(0).HeaderText = "Cédula"
        'DataGridViewClientes.Columns(1).HeaderText = "Nombre y apellido"
        'DataGridViewClientes.Columns(2).HeaderText = "Dirección"
        'DataGridViewClientes.Columns(3).HeaderText = "Teléfono"

        PanelModificarclientes.SendToBack()
        PanelModificarclientes.Visible = False
        PanelModificarclientes.Enabled = False
    End Sub

    Private Sub DataGridViewModificarCompras_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewModificarCompras.CellContentClick
        Modificarfechacompra.Clear()
        Modificarcomentariocompra.Clear()
        Modificartotalapagarcompra.Clear()
        idocultomodificarcompras.Clear()



        idocultomodificarcompras.Text = DataGridViewModificarCompras.Item(0, DataGridViewModificarCompras.CurrentRow.Index).Value
        Modificarfechacompra.Text = DataGridViewModificarCompras.Item(1, DataGridViewModificarCompras.CurrentRow.Index).Value
        Modificarcomentariocompra.Text = DataGridViewModificarCompras.Item(2, DataGridViewModificarCompras.CurrentRow.Index).Value
        Modificartotalapagarcompra.Text = DataGridViewModificarCompras.Item(3, DataGridViewModificarCompras.CurrentRow.Index).Value
    End Sub

    Private Sub DataGridViewModificarclientes_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewModificarclientes.CellContentClick

        Nombreyapellidomodificarcliente.Clear()
        Cedulamodificarcliente.Clear()
        Direccionmodificarcliente.Clear()
        Telefonomodificarcliente.Clear()

        Nombreyapellidomodificarcliente.Text = DataGridViewModificarclientes.Item(1, DataGridViewModificarclientes.CurrentRow.Index).Value
        Cedulamodificarcliente.Text = DataGridViewModificarclientes.Item(0, DataGridViewModificarclientes.CurrentRow.Index).Value
        Direccionmodificarcliente.Text = DataGridViewModificarclientes.Item(2, DataGridViewModificarclientes.CurrentRow.Index).Value
        Telefonomodificarcliente.Text = DataGridViewModificarclientes.Item(3, DataGridViewModificarclientes.CurrentRow.Index).Value

    End Sub

    Private Sub Clearmodificarclientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Clearmodificarclientes.Click
        Nombreyapellidomodificarcliente.Clear()
        Cedulamodificarcliente.Clear()
        Direccionmodificarcliente.Clear()
        Telefonomodificarcliente.Clear()

    End Sub

    Private Sub Eliminarmodificacioncliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Eliminarmodificacioncliente.Click
        'Elimina el id de una compra juntos con todos los datos de ese id
        Consulta = "delete from cliente where id='" & Cedulamodificarcliente.Text & "'"
        consultar()

        Consulta = "select * from cliente"
        consultar()
        'Actualiza la BD
        DataGridViewModificarclientes.DataSource = Tabla
        Cedulamodificarcliente.Text = ""
        Nombreyapellidomodificarcliente.Text = ""
        Direccionmodificarcliente.Text = ""
        Telefonomodificarcliente.Text = ""
        MsgBox("Datos eliminados correctamente")

        'Me.DataGridViewModificarclientes.CurrentCell.RowIndex

        'Consulta = "select * from cliente"
        'consultar()
        'DataGridViewModificarclientes.DataSource = Tabla
        'DataGridViewModificarclientes.Columns(0).HeaderText = "Cédula"
        'DataGridViewModificarclientes.Columns(1).HeaderText = "Nombre y apellido"
        'DataGridViewModificarclientes.Columns(2).HeaderText = "Dirección"
        'DataGridViewModificarclientes.Columns(3).HeaderText = "Teléfono"
    End Sub

    Private Sub ModificarClientes1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarClientes1.Click
        PanelModificarclientes.BringToFront()
        PanelModificarclientes.Visible = True
        PanelModificarclientes.Enabled = True

        Consulta = "select * from cliente"
        consultar()
        DataGridViewModificarclientes.DataSource = Tabla
        'DataGridViewModificarclientes.Columns(0).HeaderText = "Cédula"
        'DataGridViewModificarclientes.Columns(1).HeaderText = "Nombre y apellido"
        'DataGridViewModificarclientes.Columns(2).HeaderText = "Dirección"
        'DataGridViewModificarclientes.Columns(3).HeaderText = "Teléfono"

        PanelPrincipalclientes.SendToBack()
        PanelPrincipalclientes.Visible = False
        PanelPrincipalclientes.Enabled = False
    End Sub

    Private Sub Agregarmodificacioncliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Agregarmodificacioncliente.Click
        'dsfvsddd
        Consulta = "update cliente set id='" + Cedulamodificarcliente.Text + "', nombre='" + Nombreyapellidomodificarcliente.Text + "', direccion='" + Direccionmodificarcliente.Text + "', telefono='" + Telefonomodificarcliente.Text + "' where id='" + Cedulamodificarcliente.Text + "'"
        consultar()
        Consulta = "select * from cliente"
        consultar()
        Cedulamodificarcliente.Text = ""
        Nombreyapellidomodificarcliente.Text = ""
        Direccionmodificarcliente.Text = ""
        Cedulamodificarcliente.Text = ""
        'DataGridViewModificarclientes.DataSource = Tabla
        'DataGridViewModificarclientes.Columns(0).HeaderText = "Cédula"
        'DataGridViewModificarclientes.Columns(1).HeaderText = "Nombre y apellido"
        'DataGridViewModificarclientes.Columns(2).HeaderText = "Dirección"
        'DataGridViewModificarclientes.Columns(3).HeaderText = "Teléfono"

        MsgBox("Editado con exito")
    End Sub
    '/////NO BORRARasdkjbasdbashjsshjssddsdssdkejejerkjer

    'Private Sub BOTONquitarcliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONquitarcliente.Click
    '    Consulta = "delete from cliente where id='" & Texcedula.Text & "'"
    '    consultar()

    '    Consulta = "select * from cliente"
    '    consultar()
    '    DataGridViewClientes.DataSource = Tabla
    '    Texcedula.Text = ""
    '    Texnombreapellido.Text = ""
    '    Texdireccion.Text = ""
    '    Texttelefono.Text = ""
    'End Sub



    Private Sub Agregarmodificarcompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Agregarmodificarcompra.Click


        Consulta = "update compra set idc ='" + idocultomodificarcompras.Text + "', fechacompra='" + Modificarfechacompra.Text + "', comentarioc='" + Modificarcomentariocompra.Text + "', totalc='" + Modificartotalapagarcompra.Text + "' where idc='" + idocultomodificarcompras.Text + "'"
        consultar()
        Consulta = "select * from compra"
        consultar()


        DataGridViewModificarCompras.DataSource = Tabla
        DataGridViewModificarCompras.Columns(0).HeaderText = "Id"
        DataGridViewModificarCompras.Columns(1).HeaderText = "Fecha de compra"
        DataGridViewModificarCompras.Columns(2).HeaderText = "Comentario"
        DataGridViewModificarCompras.Columns(3).HeaderText = "Total a pagado"
        MsgBox("La compra se modifico con exito")
    End Sub



    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Texbuscarcliente.TextChanged

    End Sub

    '////////////////////agregar en  ventas///////////////////

    Private Sub agregarventa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles agregarventa.Click



        Try


            Dim fecha As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")
            Dim comentario As String = txbcomentarioventa.Text
            Dim totalv As Integer = txbtotalventa.Text
            Dim id As Integer = txbcedulaclienteventa.Text
            'consulta
            Consulta = "insert into venta (fechaventa,comentariov,totalv,id) values('" & fecha & "','" & comentario & "','" & totalv & "','" & id & "');"
            consultar()
            'select hacia venta
            Consulta = "select * from venta"
            consultar()
            'actualiza la dgvw
            DataGridViewVENTAS.DataSource = Tabla
            MsgBox("se agregó con exito")
        Catch ex As Exception
            MsgBox(ex)
        End Try

    End Sub
    'BORRAR EN VENTA//////////////////////////////////////////



    Private Sub Buttonborrarventas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttonborrarventas.Click

        Try
            Consulta = "delete from venta where idv='" & txbcedulaclienteventa.Text & "'"
            consultar()

            Consulta = "select * from venta"
            consultar()

            DataGridViewVENTAS.DataSource = Tabla
            MsgBox("Se borro con exito")
            'cambia de nombre el label
            labeldeventa.Text = "Cédula cliente"
        Catch ex As Exception
            MsgBox(ex)
        End Try


    End Sub
    '////////////////////////////////////////////////////////////////////////////////////////////////
    'esto hace que el label cambie al pasar el boton por el boton de borrar
    Private Sub Buttonborrarventas_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Buttonborrarventas.MouseMove
        labeldeventa.Visible = False
        labelidv.Visible = True
        txbcedulaclienteventa.Visible = True
    End Sub




    Private Sub agregarventa_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles agregarventa.MouseMove
        labeldeventa.Visible = True
        txbcedulaclienteventa.Visible = True
        labelidv.Visible = False
    End Sub

    Private Sub btnclearventa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclearventa.Click
        txbcedulaclienteventa.Text = ""
        txbcomentarioventa.Text = ""
        txbtotalventa.Text = ""
    End Sub






    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub paneldebotones_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        'If paneldebotones.Top = 10 Then
        '    paneldebotones.Top = 67
        'End If
    End Sub

    Private Sub paneldebotones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        'If paneldebotones.Height = 10 Then
        '    paneldebotones.Height = 83
        'End If
    End Sub

    Private Sub DataGridViewVENTAS_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewVENTAS.CellContentClick

        'txbcedulaclienteventa.Clear()
        'txbcomentarioventa.Clear()
        'txbtotalventa.Clear()


        txbcedulaclienteventa.Text = DataGridViewVENTAS.Item(4, DataGridViewVENTAS.CurrentRow.Index).Value

        txbcomentarioventa.Text = DataGridViewVENTAS.Item(2, DataGridViewVENTAS.CurrentRow.Index).Value
        txbtotalventa.Text = DataGridViewVENTAS.Item(3, DataGridViewVENTAS.CurrentRow.Index).Value
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    '''//////////////TABLA GANADO(CODIGO PARA INGRESAR DATOS)
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim CodG As Integer = Texcodigoganado.Text
        Dim sexo As String = Texsexoganado.Text
        Dim raza As String = Texrazaganado.Text
        Dim fechaN As String = DateTimePickerGanado.Value.ToString("yyyy-MM-dd")
        Dim estadoG As String = Texestadoganado.Text


        Consulta = "INSERT INTO ganado values('" & CodG & "','" & sexo & "','" & raza & "','" & fechaN & "','" & estadoG & "' )"
        consultar()

        Consulta = " select * from ganado"
        consultar()

        DataGridViewganado.DataSource = Tabla
    End Sub

  

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Panelagregarganando.Visible = False
    End Sub

    Private Sub DataGridViewganado_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewganado.CellContentClick
        TexSelecCodigoG.Clear()

        TexSelecCodigoG.Text = DataGridViewganado.Item(0, DataGridViewganado.CurrentRow.Index).Value
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        Consulta = " delete from ganado where idg='" & TexSelecCodigoG.Text & "'"
        consultar()

        Consulta = " select * from ganado"
        consultar()
        DataGridViewganado.DataSource = Tabla
        TexSelecCodigoG.Text = ""

    End Sub

    Private Sub Butagregarganado_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Butagregarganado.Click
        Panelagregarganando.Visible = True
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

    End Sub

    Private Sub Modificarfechacompra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Modificarfechacompra.TextChanged

    End Sub
End Class