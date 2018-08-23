Imports System.Data
Imports System.Data.OleDb
Imports MySql.Data.MySqlClient
Imports System.IO

Public Class Programa




    Dim data As String = ("Server=localhost;Database=vacas;User id=root;Password=;Port=3306;")
    'Dim data As String = ("Server=www.db4free.net;Database=database_vacas;User id=zero22394;Password=zero22394;Port=3306;")

    Public Conexion As MySqlDataAdapter
    Public Tabla As DataTable
    Public Consulta As String
    Public MysqlConexion As MySqlConnection = New MySqlConnection(data)

    Private PasswdUsuario As String
    Private ImagenUsuario As String

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

    Public Sub setUser(ByVal ci As String, ByVal nombre As String, ByVal passwd As String, ByVal rango As String, ByVal imagen As String)
        LBLCiUsuario.Text = ci
        LBLNombreUsuario.Text = nombre
        LBLRangoUsuario.Text = rango
        'ImagenUsuario = imagen
        PasswdUsuario = passwd

        PICUsuarioLogueado.ImageLocation = ("../../Res/profile/" + imagen + ".bmp")
    End Sub

    'Boton de busqueda de usuarios
    Private Sub BotonBusquedaUsuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBusquedaUsuarios.Click

        'Se borra el contenido anterior del listbox
        DGVUsuarios.DataSource = Nothing

        'Si el panel de busqueda esta vacio se buscaran todos, en caso contrario se busca lo especificado
        If TXTBusquedaUsuarios.Text = "" Then
            If CHBUsuariosInactivos.Checked Then
                Consulta = ("select ci, nombre from usuario")
            Else
                Consulta = ("select ci, nombre from usuario where estado='activo'")
            End If
        Else
            If CHBUsuariosInactivos.Checked Then
                Consulta = ("select ci, nombre from usuario where " + CBXBusquedaUsuarios.SelectedItem + "='" + TXTBusquedaUsuarios.Text + "'")
            Else
                Consulta = ("select ci, nombre from usuario where estado='activo' and " + CBXBusquedaUsuarios.SelectedItem + "='" + TXTBusquedaUsuarios.Text + "'")
            End If
        End If

        consultar()

        DGVUsuarios.DataSource = Tabla
    End Sub

    'Ci del usuario seleccionado actualmente
    Dim CiSeleccionado As String = ""

    'Cuando se cambia el item seleccionado en "DGVUsuarios"
    Private Sub DGVUsuarios_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGVUsuarios.SelectionChanged

        'Limpieza de busquedas anteriores
        TXTCiUsuarios.Text = ""
        TXTNombreUsuarios.Text = ""
        TXTPasswdUsuarios.Text = ""
        TXTRangoUsuarios.Text = ""

        'Informacion necesaria para el comando
        comando.CommandType = CommandType.Text
        comando.Connection = connection
        'Se hace la consulta segun que ha seleccionado el usuario en "ListBoxUsuarios"

        CiSeleccionado = DGVUsuarios.Item(0, DGVUsuarios.CurrentRow.Index).Value
        comando.CommandText = ("select * from usuario where ci='" + CiSeleccionado + "'")

        'MsgBox(CiSeleccionado)

        Try
            'Se abre la conexion, se ejecuta el comando y se guarda el resultado en "reader"
            connection.Open()
            reader = comando.ExecuteReader()

            'Se leen los datos otenidos
            reader.Read()

            'Se mueven los datos desde "reader" a los textbox para ser mostrados
            TXTCiUsuarios.Text = reader.GetInt32(0).ToString
            TXTNombreUsuarios.Text = reader.GetString(1)
            TXTPasswdUsuarios.Text = reader.GetString(2)
            TXTRangoUsuarios.Text = reader.GetString(3)
            LabelEstadoUsuarios.Text = reader.GetString(4)

            If Dir$("../../Res/profile/" + reader.GetString(5) + ".bmp") <> "" Then
                'PICUsuarios.Image = Image.FromFile("../../Res/profile/" + reader.GetString(5) + ".bmp")
                PICUsuarios.ImageLocation = ("../../Res/profile/" + reader.GetString(5) + ".bmp")
            Else
                'PICUsuarios.Image = Image.FromFile("../../Res/profile/default.bmp")
                PICUsuarios.ImageLocation = ("../../Res/profile/default.bmp")
            End If

            'Se guarda la ci del usuario seleccionado
            CiSeleccionado = TXTCiUsuarios.Text

            'Se cierra la conexion
            connection.Close()

        Catch ex As Exception
            'Se reportan errores
            LBLInfoUsuarios.Text = ("Error: " + ex.Message)
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    'Boton de eliminacion de Usuarios
    Private Sub BotonEliminarUsuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNEliminarUsuarios.Click

        Try
            'Se pide una confirmacion antes de proceder
            If MessageBox.Show("¿Seguro que desea eliminar a este Usuario?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                'Se ingresan los datos necesarios paras el comando
                comando.CommandType = CommandType.Text
                comando.Connection = connection
                'El usuario eliminado sera el seleccionado en "ListBoxUsuarios"
                comando.CommandText = ("update usuario set estado='inactivo' where ci='" + CiSeleccionado + "'")

                'Se abre la conexion
                connection.Open()

                'Se ejecuta el comando
                comando.ExecuteNonQuery()

                'Se cierra la conexion
                connection.Close()

                'Se actualiza "ListBoxUsuarios"
                BTNBusquedaUsuarios.PerformClick()

                'Se informa de la correcta eliminacion del usuario
                LBLInfoUsuarios.Text = "Usuario eliminado"

            End If
        Catch ex As Exception
            'Se reportan errores
            MsgBox(ex.Message)
        End Try
    End Sub

    'Boton de modificacion de datos de tab "Usuarios"
    Private Sub BotonModificarUsuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNModificarUsuarios.Click
        LBLInfoUsuarios.Text = ""
        estadoModificar()
    End Sub

    'Boton de cancelacion de edicion de tab "Usuarios"
    Private Sub BotonCancelarUsuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCancelarUsuarios.Click
        LBLInfoUsuarios.Text = ""
        estadoVisualizar()
    End Sub

    'Boton 'Aceptar' de edicion de datos de tab "Usuarios"
    Private Sub BotonAceptarUsuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNAceptarUsuarios.Click

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Dim stringaux() As String
        stringaux = PICUsuarios.ImageLocation.Split("/")
        stringaux = stringaux(stringaux.Length - 1).Split(".")
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        'Info necesaria para el comando
        comando.CommandType = CommandType.Text
        comando.Connection = connection

        Select Case estadoUsuario
            Case "modificar"
                comando.CommandText = ("update usuario set ci='" + TXTCiUsuarios.Text +
                               "', contrasena='" + TXTPasswdUsuarios.Text +
                               "', nombre='" + TXTNombreUsuarios.Text +
                               "', rango='" + TXTRangoUsuarios.Text +
                               "', perfil='" + stringaux(0) +
                               "' where ci='" + CiSeleccionado + "'")
                Try
                    'Se abre la conexion
                    connection.Open()
                    'Se ejecuta el comando
                    comando.ExecuteNonQuery()
                    'Se cierra la conexion
                    connection.Close()
                    'Se informa de la correcta modificacion del usuario
                    LBLInfoUsuarios.Text = "Usuario modificado"
                Catch ex As Exception
                    'Se informan errores
                    MsgBox("Error: " + ex.Message)
                End Try
                estadoVisualizar()
                Exit Select
            Case "agregar"
                If verificarCedula(TXTCiUsuarios.Text) Then
                    If verificarNombre() Then
                        If verificarPasswd() Then
                            comando.CommandText = ("insert into usuario values ('" + TXTCiUsuarios.Text + "','" + TXTNombreUsuarios.Text + "','" + TXTPasswdUsuarios.Text + "','" + TXTRangoUsuarios.Text + "','activo','" + StringImagenUsuarios + "')")
                            Try
                                connection.Open()
                                comando.ExecuteNonQuery()
                                connection.Close()
                            Catch ex As Exception
                                LBLInfoUsuarios.Text = ("Error:" + ex.Message)
                            End Try
                        Else
                            LBLInfoUsuarios.Text = "Contraseña erronea"
                        End If
                    Else
                        LBLInfoUsuarios.Text = "Nombre erroneo"
                    End If
                Else
                    LBLInfoUsuarios.Text = "Cedula erronea"
                End If
        End Select
        estadoVisualizar()
    End Sub

    Private Function verificarPasswd()
        If TXTPasswdUsuarios.Text < 7 Then
            Return False
        End If
        Return True
    End Function

    Private Function verificarNombre()
        Dim aux As String = TXTNombreUsuarios.Text

        If TXTNombreUsuarios.Text.Length < 7 Then
            Return False
        End If

        For Each e As Char In aux
            If IsNumeric(e) Then
                Return False
            End If
        Next
        Return True
    End Function

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
        End If
        Return False
    End Function

    Dim estadoUsuario As String = "visualizar"

    Private Sub BotonAgregarUsuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNAgregarUsuarios.Click
        LBLInfoUsuarios.Text = ""
        estadoAgregar()
    End Sub

    Private Sub estadoModificar()

        estadoUsuario = "modificar"

        BTNAceptarUsuarios.Visible = True
        BTNCancelarUsuarios.Visible = True

        BTNBusquedaUsuarios.Enabled = False
        CHBUsuariosInactivos.Enabled = False

        DGVUsuarios.Enabled = False

        CBXBusquedaUsuarios.Enabled = False

        BTNAgregarUsuarios.Visible = False
        BTNEliminarUsuarios.Visible = False
        BTNModificarUsuarios.Visible = False

        TXTCiUsuarios.ReadOnly = False
        TXTNombreUsuarios.ReadOnly = False
        TXTPasswdUsuarios.ReadOnly = False
        TXTRangoUsuarios.ReadOnly = False
        PICUsuarios.Enabled = True

        TXTBusquedaUsuarios.ReadOnly = True

    End Sub

    Private Sub estadoAgregar()

        estadoModificar()

        estadoUsuario = "agregar"

        PICUsuarios.Image = Image.FromFile("../../Res/profile/nueva.bmp")

        TXTCiUsuarios.Text = ""
        TXTNombreUsuarios.Text = ""
        TXTPasswdUsuarios.Text = ""
        TXTRangoUsuarios.Text = ""

        CHBUsuariosInactivos.Checked = False

    End Sub

    Private Sub estadoVisualizar()

        estadoUsuario = "visualizar"

        BTNAceptarUsuarios.Visible = False
        BTNCancelarUsuarios.Visible = False

        BTNBusquedaUsuarios.Enabled = True
        CHBUsuariosInactivos.Enabled = True

        DGVUsuarios.Enabled = True

        CBXBusquedaUsuarios.Enabled = True

        BTNModificarUsuarios.Visible = True
        BTNAgregarUsuarios.Visible = True
        BTNEliminarUsuarios.Visible = True

        TXTCiUsuarios.ReadOnly = True
        TXTNombreUsuarios.ReadOnly = True
        TXTPasswdUsuarios.ReadOnly = True
        TXTRangoUsuarios.ReadOnly = True
        PICUsuarios.Enabled = False

        TXTBusquedaUsuarios.ReadOnly = False

        BTNBusquedaUsuarios.PerformClick()

        StringImagenUsuarios = "default"

    End Sub

    Private Sub CheckBoxUsuarios_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHBUsuariosInactivos.CheckStateChanged
        BTNBusquedaUsuarios.PerformClick()

        If CHBUsuariosInactivos.Checked Then
            LabelEstadoUsuarios.Visible = True
        Else
            LabelEstadoUsuarios.Visible = False
        End If
    End Sub

    Private Sub CheckBoxPasswdUsuarios_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHBPasswdUsuarios.CheckStateChanged
        If CHBPasswdUsuarios.Checked Then
            TXTPasswdUsuarios.PasswordChar = ""
        Else
            TXTPasswdUsuarios.PasswordChar = "+"
        End If
    End Sub

    Dim openFileDialog As New OpenFileDialog()

    Dim StringImagenUsuarios As String = "default"

    Private Sub PictureBoxUsuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PICUsuarios.Click
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
                        PICUsuarios.ImageLocation = ("../../Res/profile/" + aux(0) + ".bmp")
                        'StringImagenUsuarios = aux(0)
                    Else
                        openFileDialog.FileName = ""
                        MsgBox("La imagen seleccionda no debe superar 90 x 90")
                    End If
                Catch Ex As Exception
                    openFileDialog.FileName = ""
                    LBLInfoUsuarios.Text = ("Error: " + Ex.Message)
                End Try
            Else
                openFileDialog.FileName = ""
                MsgBox("Imagenes .BMP unicamente")
                BuscarImagen()
            End If
        End If
    End Sub

    '///FIN SECCION USUARIOS



    Private Sub TabClientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabClientes.Click
        If paneldetextosenventas.Visible = True Then
            btnagregarpanel.Image = Image.FromFile("Resources\flecha-hacia-la-izquierda.png")
        Else
            btnagregarpanel.Image = Image.FromFile("Resources\anadir.png")
        End If
    End Sub
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'panel ventas
        paneldetextosenventas.Visible = False
        'If paneldetextosenventas.Visible = True Then
        '    btnagregarpanel.BackgroundImage = Image.FromFile("C:\Users\Alumno-09\Desktop\Proyecto3BE-master\Proyecto3BE\Resources\flecha-hacia-la-izquierda.png")

        'End If

    
        '///////////////Paneles de agregar compras////////////////
        PNLAgregarcompraganado.Enabled = False
        PNLAgregarcompraganado.Visible = False
        PNLAgregarcompraganado.SendToBack()

        PNLAgregarcompraproducto.Enabled = False
        PNLAgregarcompraproducto.Visible = False
        PNLAgregarcompraproducto.SendToBack()


        'timer en ganado
        TexSelecCodigoG.Visible = False
        Label6deborrarganado.Visible = False



        '/////// CONSULTA VENTA
        Consulta = "select * from venta"
        consultar()
        'actualiza la dgvw
        DataGridViewVENTAS.DataSource = Tabla
        labelceduladeclienteventa.Visible = False
        'label's hide
        txbcedulaclienteventa.Visible = False
        labelidv.Visible = False




        '////////////USUARIOS
        CBXBusquedaUsuarios.SelectedIndex = 0

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
        DTGCompras.DataSource = Tabla
        DTGCompras.Columns(0).HeaderText = "Id"
        DTGCompras.Columns(1).HeaderText = "Fecha de Compra"
        DTGCompras.Columns(2).HeaderText = "Comentario"
        DTGCompras.Columns(3).HeaderText = "Total"

        'Nose que es esto
        CBXBusquedaUsuarios.SelectedIndex = 0

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
    Private Sub BTNVolverdeagregarcompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNVolverdeagregarcompra.Click
        'Muestra panel pricipal de compras
        Panelprincipalcompras.Enabled = True
        Panelprincipalcompras.Visible = True
        Panelprincipalcompras.BringToFront()


        'Oculta panel de agregar compras
        Panelagregarcompras.SendToBack()
        Panelagregarcompras.Visible = False
        Panelagregarcompras.Enabled = False

        CBXAgregarcompra.Text = ""

        PNLAgregarcompraproducto.Visible = False
        PNLAgregarcompraproducto.Enabled = False
        PNLAgregarcompraproducto.SendToBack()

        PNLAgregarcompraganado.Visible = False
        PNLAgregarcompraganado.Enabled = False
        PNLAgregarcompraganado.SendToBack()
    End Sub
    '/////////////////////////Boton de agregar compras////////////
    Private Sub BTNpanelmodicompras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNpanelagregarcompras.Click
        'Muestra el panel de agregar compras
        Panelagregarcompras.BringToFront()
        Panelagregarcompras.Visible = True
        Panelagregarcompras.Enabled = True

        'Oculta el panel principal de compras
        Panelprincipalcompras.SendToBack()
        Panelprincipalcompras.Enabled = False
        Panelprincipalcompras.Visible = False
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNAgregarganadocompra.Click

    End Sub
    Private Sub BTNAgregarcompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNAgregarcompraproducto.Click
        Dim fechacompra As String = DTPFechacompraproducto.Value.ToString("yyyy-MM-dd")
        If fechacompra <> "" And RTXComentariocompraproducto.Text <> "" And TXTTotalpagadocomprasproducto.Text <> "" Then
            If IsNumeric(TXTTotalpagadocomprasproducto.Text) Then
                'Agrega los valores de los campos a cada tabla correspondiente
                Consulta = "insert into compra values (0,'" & fechacompra & "','" & RTXComentariocompraproducto.Text & "','" & TXTTotalpagadocomprasproducto.Text & "')"
                consultar()
                Consulta = "select * from compra"
                consultar()
                'Actualiza la BD
                DTGCompras.DataSource = Tabla
                'Deja a los textbox vacios para ingresar nuevos datos
                RTXComentariocompraproducto.Text = ""
                TXTTotalpagadocomprasproducto.Text = ""
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
    Private Sub BTNclearagregarcompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNclearagregarcompraproducto.Click
        'Deja los textbox vacios
        RTXComentariocompraproducto.Clear()
        TXTTotalpagadocomprasproducto.Clear()
        DTPFechacompraproducto.Value = Today
    End Sub
    '////////////////////Boton muestra panel de modificar compras///////////////////
    Private Sub BTNPanelmodicompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNPanelmodicompra.Click
        'Muestra el panel de modificar compras
        Panelmodificarcompras.BringToFront()
        Panelmodificarcompras.Visible = True
        Panelmodificarcompras.Enabled = True

        'Actualiza datagrid de panel modificar compras
        Consulta = "select * from compra"
        consultar()
        DTGModificarcompra.DataSource = Tabla
        'Cambia los headers
        DTGModificarcompra.Columns(0).HeaderText = "Id"
        DTGModificarcompra.Columns(1).HeaderText = "Fecha de Compra"
        DTGModificarcompra.Columns(2).HeaderText = "Comentario"
        DTGModificarcompra.Columns(3).HeaderText = "Total Pagado"

        'Oculta panel principal compras
        Panelprincipalcompras.SendToBack()
        Panelprincipalcompras.Visible = False
        Panelprincipalcompras.Enabled = False
    End Sub
    
    Private Sub BTNEliminarmodicompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNEliminarmodicompra.Click
        'Elimina el id de una compra juntos con todos los datos de ese id
        Consulta = "delete from compra where idc='" & TXTIdmodicompra.Text & "'"
        consultar()

        Consulta = "select * from compra"
        consultar()
        'Actualiza la BD
        DTGModificarcompra.DataSource = Tabla
        'Deja vacios los campos
        RTXModicomentariocompra.Clear()
        TXTModitotalapagarcompra.Clear()
        TXTIdmodicompra.Clear()
        MsgBox("Datos eliminados correctamente")
    End Sub
    Private Sub Clearagregarclientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Clearagregarclientes.Click
        Texcedula.Clear()
        Texdireccion.Clear()
        Texnombreapellido.Clear()
        Texttelefono.Clear()

    End Sub
    Private Sub BTNAgregarcomraganado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNAgregarcomraganado.Click
        Dim fechacompra As String = DTPFechacompraganado.Value.ToString("yyyy-MM-dd")
        Dim fechanac As String = DTPFechanacimientocompra.Value.ToString("yyyy-MM-dd")
        If fechacompra <> "" And RTXComentariocompraganado.Text <> "" And TXTTotalapagarcompraganado.Text Then
            If IsNumeric(TXTTotalapagarcompraganado.Text) Then
                'Agrega los valores de los campos a cada tabla correspondiente
                Consulta = "insert into compra values (0,'" & fechacompra & "','" & RTXComentariocompraganado.Text & "','" & TXTTotalapagarcompraganado.Text & "')"
                consultar()
                Consulta = "select * from compra"
                consultar()
                'Actualiza la BD
                DTGCompras.DataSource = Tabla
                'Deja a los textbox vacios para ingresar nuevos datos
                DTPFechacompraganado.Value = Today
                RTXComentariocompraganado.Text = ""
                TXTTotalapagarcompraganado.Text = ""

                TXTCodigoganadocompra.Text = ""
                TXTRazacompra.Text = ""
                TXTSexocompra.Text = ""
                DTPFechanacimientocompra.Value = Today
                TXTEstadocompra.Text = ""
            Else
                'Muestra mensaje diciendo que no se ingresaron valores numericos o que solo acepta valores numericos
                MsgBox("Ingrese solo valor numerico en total")
            End If
        Else
            'Muestra mensaje que todos los campos no estan completos
            MsgBox("Complete todos los campos vacios")
        End If
    End Sub
    Private Sub BTNLimpiarcompraganado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNLimpiarcompraganado.Click
        RTXComentariocompraganado.Clear()
        TXTTotalapagarcompraganado.Clear()
        DTPFechacompraganado.Value = Today

        TXTCodigoganadocompra.Clear()
        TXTRazacompra.Clear()
        TXTSexocompra.Clear()
        DTPFechanacimientocompra.Value = Today
        TXTEstadocompra.Clear()
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
            If verificarCedula(Texcedula.Text) Then

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
                MsgBox("Cedula erronea")
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
        'dsfvsdddsadasdsad
        If verificarCedula(Cedulamodificarcliente.Text) Then
            Consulta = "update cliente set id='" + Cedulamodificarcliente.Text + "', nombre='" + Nombreyapellidomodificarcliente.Text + "', direccion='" + Direccionmodificarcliente.Text + "', telefono='" + Telefonomodificarcliente.Text + "' where id='" + Cedulamodificarcliente.Text + "'"
            consultar()
            Consulta = "select * from cliente"
            consultar()
            Cedulamodificarcliente.Text = ""
            Nombreyapellidomodificarcliente.Text = ""
            Direccionmodificarcliente.Text = ""
            Cedulamodificarcliente.Text = ""
            DataGridViewModificarclientes.DataSource = Tabla
            'DataGridViewModificarclientes.Columns(0).HeaderText = "Cédula"
            'DataGridViewModificarclientes.Columns(1).HeaderText = "Nombre y apellido"
            'DataGridViewModificarclientes.Columns(2).HeaderText = "Dirección"
            'DataGridViewModificarclientes.Columns(3).HeaderText = "Teléfono"
            MsgBox("Editado con exito")
        Else
            MsgBox("Cédula errónea")
        End If
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
        Dim fechacompra As String = DTPModifechacompra.Value.ToString("yyyy-MM-dd")

        Consulta = "update compra set idc ='" + TXTIdmodicompra.Text + "', fechacompra='" + fechacompra + "', comentarioc='" + RTXModicomentariocompra.Text + "', totalc='" + TXTModitotalapagarcompra.Text + "' where idc='" + TXTIdmodicompra.Text + "'"
        consultar()
        Consulta = "select * from compra"
        consultar()


        DTGModificarcompra.DataSource = Tabla
        DTGModificarcompra.Columns(0).HeaderText = "Id"
        DTGModificarcompra.Columns(1).HeaderText = "Fecha de compra"
        DTGModificarcompra.Columns(2).HeaderText = "Comentario"
        DTGModificarcompra.Columns(3).HeaderText = "Total a pagado"
        MsgBox("La compra se modifico con exito")
    End Sub



    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Texbuscarcliente.TextChanged

    End Sub

    '////////////////////agregar en  ventas///////////////////

    Private Sub agregarventa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnagregarventa.Click
        If lblparamostrarsisemodifico.Visible = True Then
            lblparamostrarsisemodifico.Visible = False
        End If
        If lblmostrarqueseborro.Visible = True Then
            lblmostrarqueseborro.Visible = False
        End If
        Dim fecha As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        Dim comentario As String = txbcomentarioventa.Text
        Dim totalv As String = txbtotalventa.Text
        Dim id As String = txbcedulaclienteventa.Text


        If txbcedulaclienteventa.Text = "" Then
            MsgBox("Complete el campo Cédula")
        Else

            Try

                'consulta
                Consulta = "insert into venta (fechaventa,comentariov,totalv,id) values('" & fecha & "','" & comentario & "','" & totalv & "','" & id & "');"
                consultar()
                'select hacia venta
                Consulta = "select * from venta"
                consultar()
                'actualiza la dgvw
                DataGridViewVENTAS.DataSource = Tabla
                Labelparamostraragregado.Show()
            Catch ex As Exception
                MsgBox(ex)


            End Try

        End If
        
    End Sub
    'BORRAR EN VENTA//////////////////////////////////////////



    Private Sub Buttonborrarventas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnborrarventa.Click
        If Labelparamostraragregado.Visible = True Then
            Labelparamostraragregado.Visible = False
        End If
        If lblparamostrarsisemodifico.Visible = True Then
            lblparamostrarsisemodifico.Visible = False
        End If

        If txbcedulaclienteventa.Text = "" Then
            MsgBox("Complete campo idv")
        Else

            Try
                Consulta = "delete from venta where idv= '" & txbcedulaclienteventa.Text & "'"
                consultar()

                Consulta = "select * from venta"
                consultar()

                DataGridViewVENTAS.DataSource = Tabla
                lblmostrarqueseborro.Show()

            Catch ex As Exception
                MsgBox(ex)
            End Try
        End If

    End Sub
    '////////////////////////////////////////////////////////////////////////////////////////////////
    'esto hace que el label cambie al pasar el boton por el boton de borrar
    Private Sub Buttonborrarventas_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnborrarventa.MouseMove
        labelceduladeclienteventa.Visible = False
        labelidv.Visible = True
        txbcedulaclienteventa.Visible = True
    End Sub




    Private Sub agregarventa_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnagregarventa.MouseMove
        labelceduladeclienteventa.Visible = True
        txbcedulaclienteventa.Visible = True
        labelidv.Visible = False
        
    End Sub

    Private Sub btnclearventa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclearventa.Click
        If Labelparamostraragregado.Visible = True Then
            Labelparamostraragregado.Visible = False
        End If
        If lblparamostrarsisemodifico.Visible = True Then
            lblparamostrarsisemodifico.Visible = False
        End If
        If lblmostrarqueseborro.Visible = True Then
            lblmostrarqueseborro.Visible = False
        End If

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
    Private Sub DataGridViewVENTAS_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewVENTAS.SelectionChanged

        txbcedulaclienteventa.Clear()
        txbcomentarioventa.Clear()
        txbtotalventa.Clear()


        txbcomentarioventa.Text = DataGridViewVENTAS.Item(2, DataGridViewVENTAS.CurrentRow.Index).Value
        txbtotalventa.Text = DataGridViewVENTAS.Item(3, DataGridViewVENTAS.CurrentRow.Index).Value

    End Sub


    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    '''//////////////TABLA GANADO(CODIGO PARA INGRESAR DATOS)
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim CodG As Integer = Texcodigoganado.Text
        Dim sexo As String = Texsexoganado.Text
        Dim raza As String = Texrazaganado.Text
        Dim fechaN As String = DateTimePickerGanado.Value.ToString("yyyy-MM-dd")
        Dim estadoG As String = Texestadoganado.Text

        Try






            Consulta = "INSERT INTO ganado (idg,sexo,raza,nacimiento,estado) values('" & CodG & "','" & sexo & "','" & raza & "','" & fechaN & "','" & estadoG & "' )"
            consultar()


            Consulta = " select * from ganado"
            consultar()

            DataGridViewganado.DataSource = Tabla

        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub



    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Panelagregarganando.Visible = False
    End Sub

    Private Sub DataGridViewganado_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        TexSelecCodigoG.Clear()

        TexSelecCodigoG.Text = DataGridViewganado.Item(0, DataGridViewganado.CurrentRow.Index).Value

        'Label6.Text = DataGridViewganado.Item(3, DataGridViewganado.CurrentRow.Index).Value
    End Sub





    'MODIFICAR VENTAS 
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmodificarventa.Click
        If Labelparamostraragregado.Visible = True Then
            Labelparamostraragregado.Visible = False
        End If
        If lblmostrarqueseborro.Visible = True Then
            lblmostrarqueseborro.Visible = False
        End If
        Dim fecha As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        Dim comentario As String = txbcomentarioventa.Text
        Dim totalv As String = txbtotalventa.Text
        Dim id As String = txbcedulaclienteventa.Text


        If txbcedulaclienteventa.Text = "" Then
            MsgBox("Complete el campo ID ")
        ElseIf txbcomentarioventa.Text = "" And txbtotalventa.Text = "" Then
            MsgBox("Complete los campos restantes ")
        Else


            Try
                Consulta = ("update venta set idv='" + txbcedulaclienteventa.Text + "', fechaventa='" + fecha + "', comentariov='" + txbcomentarioventa.Text + "', totalv='" + txbtotalventa.Text + "' where idv='" + txbcedulaclienteventa.Text + "'")
                consultar()
                Consulta = "select * from venta"
                consultar()
                DataGridViewVENTAS.DataSource = Tabla
                lblparamostrarsisemodifico.Show()

            Catch ex As Exception
                MsgBox(ex)

            End Try

        End If
    End Sub

  


    Private Sub Button4_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnmodificarventa.MouseMove
        labelceduladeclienteventa.Visible = False
        labelidv.Visible = True
        txbcedulaclienteventa.Visible = True
    End Sub

    Private Sub btnagregarganado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnagregarganado.Click
        Panelagregarganando.Visible = True
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminarganado.Click

        Consulta = " delete from ganado where idg='" & TexSelecCodigoG.Text & "'"
        consultar()

        Consulta = " select * from ganado"
        consultar()
        DataGridViewganado.DataSource = Tabla
        TexSelecCodigoG.Text = ""

    End Sub
    ' timer 
    Private Sub btneliminarganado_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btneliminarganado.MouseMove
        Dim timer As Integer
        Label6deborrarganado.Visible = True
        TexSelecCodigoG.Visible = True
        timer = 0
       
    End Sub






    Private Sub Timer1_Tick_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Label6deborrarganado.Visible = False
        TexSelecCodigoG.Visible = False
    End Sub

    Private Sub Timerventaseliminaryagregar_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        labelidv.Visible = False
        labelceduladeclienteventa.Visible = False
        txbcedulaclienteventa.Visible = False
    End Sub
    ' ////////////////////////////////////////////////////////////
    Private Sub BTNsalirmodicompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNsalirmodicompra.Click
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
        DTGCompras.DataSource = Tabla
        'Cambia los headers de las tablas
        DTGCompras.Columns(0).HeaderText = "Id"
        DTGCompras.Columns(1).HeaderText = "Fecha de Compra"
        DTGCompras.Columns(2).HeaderText = "Comentario"
        DTGCompras.Columns(3).HeaderText = "Total Pagado"
    End Sub
    Private Sub DTGmodificarcompra_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTGModificarcompra.SelectionChanged
        'Cuando se selecciona otra fila del data grid deja los textbox, richtextbox vacios para mostrar los nuevos datos
        RTXModicomentariocompra.Clear()
        TXTModitotalapagarcompra.Clear()
        TXTIdmodicompra.Clear()


        'Cada vez que se selecciona un item del datagrid, muestra los datos en los textbox,datatimerpick,richtextbox
        TXTIdmodicompra.Text = DTGModificarcompra.Item(0, DTGModificarcompra.CurrentRow.Index).Value
        DTPModifechacompra.Value = DTGModificarcompra.Item(1, DTGModificarcompra.CurrentRow.Index).Value
        RTXModicomentariocompra.Text = DTGModificarcompra.Item(2, DTGModificarcompra.CurrentRow.Index).Value
        TXTModitotalapagarcompra.Text = DTGModificarcompra.Item(3, DTGModificarcompra.CurrentRow.Index).Value
    End Sub

    Private Sub BTNlimpiarmodicompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNlimpiarmodicompra.Click
        'Deja vacio el campo de comentario
        RTXModicomentariocompra.Clear()
        'Deja vacio el campo de Total a pagar
        TXTModitotalapagarcompra.Clear()
        DTPModifechacompra.Value = Today
    End Sub

    Private Sub CBXAgregarcompra_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBXAgregarcompra.SelectedIndexChanged
        If CBXAgregarcompra.Text = "Ganado" Then
            PNLAgregarcompraganado.Visible = True
            PNLAgregarcompraganado.Enabled = True
            PNLAgregarcompraganado.BringToFront()

            PNLAgregarcompraproducto.Visible = False
            PNLAgregarcompraproducto.Enabled = False
            PNLAgregarcompraproducto.SendToBack()
        ElseIf CBXAgregarcompra.Text = "Productos" Then
            PNLAgregarcompraproducto.Visible = True
            PNLAgregarcompraproducto.Enabled = True
            PNLAgregarcompraproducto.BringToFront()

            PNLAgregarcompraganado.Visible = False
            PNLAgregarcompraganado.Enabled = False
            PNLAgregarcompraganado.SendToBack()
        Else
            PNLAgregarcompraproducto.Visible = False
            PNLAgregarcompraproducto.Enabled = False
            PNLAgregarcompraproducto.SendToBack()

            PNLAgregarcompraganado.Visible = False
            PNLAgregarcompraganado.Enabled = False
            PNLAgregarcompraganado.SendToBack()
        End If
    End Sub
    ' cosas de paneles

    Private Sub btnagregarpanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnagregarpanel.Click
        paneldetextosenventas.Visible = True
        If paneldetextosenventas.Height = 71 Then
            paneldetextosenventas.Height = 376
        Else
            paneldetextosenventas.Height = 71
        End If
        If paneldetextosenventas.Visible = True Then
            btnagregarpanel.Image = Image.FromFile("..\..\Resources\flecha-hacia-la-izquierda.png")


        End If
        If paneldetextosenventas.Height = 71 Then
            btnagregarpanel.Image = Image.FromFile("..\..\Resources\anadir.png")
        End If



    End Sub

    
End Class