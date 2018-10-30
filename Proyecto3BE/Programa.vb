Imports System.Data
Imports System.Data.OleDb
Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports System.Math

Public Class Programa
    Dim error1 As Integer
    Dim data As String = ("Server=localhost;Database=vacas;User id=root;Password=;Port=3306;")
    'Dim data As String = ("Server=www.db4free.net;Database=database_vacas;User id=zero22394;Password=zero22394;Port=3306;")

    Public Conexion As MySqlDataAdapter
    Public Tabla As DataTable
    Public Consulta As String
    Public MysqlConexion As MySqlConnection = New MySqlConnection(data)

    Private PasswdUsuario As String
    Private ImagenUsuario As String


    Structure vacas
        Dim codigoganado As Integer
        Dim strraza As String
        Dim strsexo As String
        Dim fechanacimiento As Date
        Dim estado As String
    End Structure



    Public Sub consultar()
        Try
            Conexion = New MySqlDataAdapter(Consulta, data)
            Tabla = New DataTable
            Conexion.Fill(Tabla)
            error1 = 0
        Catch ex As Exception
            MsgBox(ex.Message)
            error1 = 1
        End Try
    End Sub

    Public Sub actualizarCliente()
        'CARGA DATAGRIDCLIENTES
        Consulta = "select * from cliente where estado = 1"
        consultar()

        DataGridViewClientes.DataSource = Tabla

        DataGridViewClientes.Columns(0).HeaderText = "Cédula"
        DataGridViewClientes.Columns(1).HeaderText = "Nombre"
        DataGridViewClientes.Columns(2).HeaderText = "Apellido"
        DataGridViewClientes.Columns(3).HeaderText = "Dirección"
        DataGridViewClientes.Columns(4).HeaderText = "Teléfono"
        DataGridViewClientes.Columns(5).Visible = False


    End Sub


    '//////// ACTIVA Y VUELVE VISIBLE LOS BOTONES Y EL DATAGRID PRINCIPAL QUE FUERON DESACTIVADOS POR EL EVENTO DesactivarBotones() ////////////////////////////
    Public Sub ACtivarBotonesGanado()
        GroupBox3.Enabled = True
        BOTONguardarAgregar.Enabled = True
        BOTONcancelarAgregar.Enabled = True
        BOTONguardarModificar.Enabled = True
        BOTONcancelarModificar.Enabled = True
        DataGridGanadoEconomico.Visible = False
        DataGridViewganado.Visible = True
    End Sub
    '/////////////////////////// DESACTIVA Y OCULTA VARIOS BOTONES Y EL DATAGRID PRINCIPAL ///////////////////////////////////////////
    Public Sub DesactivarBotonesGanado()
        GroupBox3.Enabled = False
        BOTONguardarAgregar.Enabled = False
        BOTONcancelarAgregar.Enabled = False
        BOTONguardarModificar.Enabled = False
        BOTONcancelarModificar.Enabled = False
        DataGridViewganado.Visible = False
        CBXsexoGanado.Text = ""
        CBXRazaGanado.Text = ""

        DTPAgregarGanado.Value = Today
        CBXagregarEstadoGanado.Text = ""
    End Sub

    Public Sub ActualizarGanadoSinConsulta()

        consultar()
        DataGridViewganado.DataSource = Tabla
        DataGridViewganado.Focus()

        'Cambiamos los headers

        DataGridViewganado.Columns(0).HeaderText = "Codigo"
        DataGridViewganado.Columns(1).HeaderText = "Sexo"
        DataGridViewganado.Columns(2).HeaderText = "Raza"

        DataGridViewganado.Columns(4).HeaderText = "Fecha Nacimiento"
        DataGridViewganado.Columns(3).HeaderText = "Estado"
        DataGridViewganado.Columns(5).HeaderText = "Años"
        DataGridViewganado.Columns(6).HeaderText = "Meses"

    End Sub

    'CONSULTA DE TABLA GANADO

    Public Sub actualizarGanado()

        Try
            Consulta = "select idg,sexo,raza,estado,nacimiento, TIMESTAMPDIFF(YEAR,ganado.nacimiento,CURDATE()) AS 'Anios', TIMESTAMPDIFF(month, ganado.nacimiento,NOW())%12 AS 'Meses' from ganado where estado <> 'Muerto/a' "
            consultar()
            DataGridViewganado.DataSource = Tabla

            DataGridViewganado.Focus()

            'Cambiamos los headers
            DataGridViewganado.Columns(0).HeaderText = "Codigo"
            DataGridViewganado.Columns(1).HeaderText = "Sexo"
            DataGridViewganado.Columns(2).HeaderText = "Raza"

            DataGridViewganado.Columns(4).HeaderText = "Fecha Nacimiento"
            DataGridViewganado.Columns(3).HeaderText = "Estado"
            DataGridViewganado.Columns(5).HeaderText = "Años"
            DataGridViewganado.Columns(6).HeaderText = "Meses"

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    '///SECCION USUARIOS

    Private Sub BTNModificarContraseña_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNModificarContraseña.Click

        Dim aux As String = ""

        aux = InputBox("¿Seguro que desea cambiar la contraseña?", "Confirmacion")

        comando.CommandType = CommandType.Text
        comando.Connection = connection
        comando.CommandText = ("update usuario set contrasena='" + encriptar(aux) + "' where ci='" + CiSeleccionado + "'")

        If aux <> "" Then

            If aux = InputBox("Repita la contraseña, por favor", "Confirmacion") Then

                If verificarPasswd(aux) Then

                    Try

                        connection.Open()

                        comando.ExecuteNonQuery()

                        connection.Close()

                    Catch ex As Exception
                        MsgBox(ex.Message)
                        If connection.State = ConnectionState.Open Then
                            connection.Close()
                        End If
                    End Try

                    LBLInfoUsuarios.Text = "Contraseña cambiada con exito"

                End If

            Else

                MsgBox("La contraseñas no coinciden")

            End If

            'BTNModificarContraseña.PerformClick()

        End If

    End Sub

    Public Function encriptar(ByVal pass As String)

        Dim sham As New SHA256Managed()

        Dim tmp() As Byte = ASCIIEncoding.ASCII.GetBytes(pass)
        Dim hash() As Byte = sham.ComputeHash(tmp)

        Dim asdf As String = ""

        For Each ele As Byte In hash
            asdf = asdf + (ele.ToString)
        Next

        Return asdf

    End Function

    Private Sub BTNCerrarSesion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCerrarSesion.Click
        Me.Close()
    End Sub

    Private Sub LBLCambioContraseña_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBLCambioContraseña.Click

        Dim asd As String = InputBox("¿Seguro que desea cambiar su contraseña?", "Confirmacion")

        If verificarPasswd(asd) Then

            comando.CommandType = CommandType.Text
            comando.Connection = connection
            comando.CommandText = ("update usuario set contrasena='" + encriptar(asd) + "' where ci='" + PasswdUsuario + "'")

            Try

                connection.Open()

                comando.ExecuteNonQuery()

                BTNBusquedaUsuarios.PerformClick()

                connection.Close()

            Catch ex As Exception
                LBLInfoUsuarios.Text = ex.Message
                If connection.State = ConnectionState.Open Then
                    connection.Close()
                End If
            End Try

        End If


    End Sub

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

        PICUsuarioLogueado.ImageLocation = imagen
    End Sub

    'Boton de busqueda de usuarios
    Private Sub BotonBusquedaUsuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBusquedaUsuarios.Click

        'Se borra el contenido anterior del datagrid
        DGVUsuarios.DataSource = Nothing

        'Si el panel de busqueda esta vacio se buscaran todos, en caso contrario se busca lo especificado
        If TXTBusquedaUsuarios.Text = "" Then
            If CHBUsuariosInactivos.Checked Then
                Consulta = ("select ci, nombre, rango, estado from usuario")
            Else
                Consulta = ("select ci, nombre, rango, estado from usuario where estado='activo'")
            End If
        Else
            If CHBUsuariosInactivos.Checked Then
                Consulta = ("select ci, nombre, rango, estado from usuario where " + CBXBusquedaUsuarios.SelectedItem + "='" + TXTBusquedaUsuarios.Text + "'")
            Else
                Consulta = ("select ci, nombre, rango, estado from usuario where estado='activo' and " + CBXBusquedaUsuarios.SelectedItem + "='" + TXTBusquedaUsuarios.Text + "'")
            End If
        End If

        If CBXBusquedaRangoUsuarios.Visible = True Then

            If CHBUsuariosInactivos.Checked Then
                Consulta = ("select ci, nombre, rango, estado from usuario where rango='" + CBXBusquedaRangoUsuarios.SelectedItem + "'")
            Else
                Consulta = ("select ci, nombre, rango, estado from usuario where rango='" + CBXBusquedaRangoUsuarios.SelectedItem + "' and estado='activo'")
            End If

        End If

        consultar()

        DGVUsuarios.DataSource = Tabla

        If CHBUsuariosInactivos.Checked = True Then
        Else
            DGVUsuarios.Columns(3).Visible = False
        End If

    End Sub

    Private Sub CBXBusquedaUsuarios_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBXBusquedaUsuarios.SelectedIndexChanged
        If CBXBusquedaUsuarios.SelectedItem.ToString = "Rango" Then
            TXTBusquedaUsuarios.Visible = False
            CBXBusquedaRangoUsuarios.Visible = True
            CBXBusquedaRangoUsuarios.SelectedIndex = 0
        Else
            TXTBusquedaUsuarios.Visible = True
            CBXBusquedaRangoUsuarios.Visible = False
            TXTBusquedaUsuarios.Text = ""
        End If
    End Sub

    Private Sub CBXBusquedaRangoUsuarios_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBXBusquedaRangoUsuarios.SelectedIndexChanged
        TXTBusquedaUsuarios.Text = CBXBusquedaRangoUsuarios.SelectedItem.ToString
    End Sub

    'Ci del usuario seleccionado actualmente
    Dim CiSeleccionado As String = ""

    'Cuando se cambia el item seleccionado en "DGVUsuarios"
    Private Sub DGVUsuarios_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGVUsuarios.SelectionChanged

        LBLInfoUsuarios.Text = ""

        'Limpieza de busquedas anteriores
        TXTCiUsuarios.Text = ""
        TXTNombreUsuarios.Text = ""
        TXTPasswdUsuarios.Text = ""
        CBXRangoUsuarios.SelectedIndex = 0

        'Informacion necesaria para el comando
        comando.CommandType = CommandType.Text
        comando.Connection = connection
        'Se hace la consulta segun que ha seleccionado el usuario en "ListBoxUsuarios"

        Try
            CiSeleccionado = DGVUsuarios.Item(0, DGVUsuarios.CurrentRow.Index).Value
            comando.CommandText = ("select * from usuario where ci='" + CiSeleccionado + "'")

            'Se abre la conexion, se ejecuta el comando y se guarda el resultado en "reader"
            connection.Open()
            reader = comando.ExecuteReader()

            'Se leen los datos otenidos
            reader.Read()

            'Se mueven los datos desde "reader" a los textbox para ser mostrados
            TXTCiUsuarios.Text = reader.GetInt32(0).ToString
            TXTNombreUsuarios.Text = reader.GetString(1)
            TXTPasswdUsuarios.Text = reader.GetString(2)

            Select Case reader.GetString(3)
                Case "Admin"
                    CBXRangoUsuarios.SelectedIndex = 1
                    Exit Select
                Case "User"
                    CBXRangoUsuarios.SelectedIndex = 0
                    Exit Select
                Case Else
                    CBXRangoUsuarios.SelectedIndex = 2
            End Select

            'If Dir$("../../Res/profile/" + reader.GetString(5) + ".bmp") <> "" Then
            'PICUsuarios.ImageLocation = ("../../Res/profile/" + reader.GetString(5) + ".bmp")
            'Else
            'PICUsuarios.ImageLocation = ("../../Res/profile/default.bmp")
            'End If

            'PICUsuarios.ImageLocation = reader.GetString(5) + ".bmp"

            'MsgBox(reader.GetString(5))

            PICUsuarios.ImageLocation = reader.GetString(5)

            'Se cierra la conexion
            connection.Close()

        Catch ex As Exception
            'Se reportan errores
            LBLInfoUsuarios.Text = ("No se encontraron resultados")
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    'Boton de eliminacion de Usuarios
    Private Sub BotonEliminarUsuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNEliminarUsuarios.Click

        Try
            'Se pide una confirmacion antes de proceder
            If MessageBox.Show("¿Seguro que desea eliminar a este usuario?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

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
        If Not DGVUsuarios.CurrentRow Is Nothing Then
            LBLInfoUsuarios.Text = ""
            estadoModificar()
        End If
    End Sub

    'Boton de cancelacion de edicion de tab "Usuarios"
    Private Sub BotonCancelarUsuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCancelarUsuarios.Click
        LBLInfoUsuarios.Text = ""
        estadoVisualizar()
    End Sub

    'Boton 'Aceptar' de edicion de datos de tab "Usuarios"
    Private Sub BotonAceptarUsuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNAceptarUsuarios.Click

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        'Dim stringaux As String = imagenSeleccionada()
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        'Info necesaria para el comando
        comando.CommandType = CommandType.Text
        comando.Connection = connection

        Select Case estadoUsuario
            Case "modificar"
                If verificarNombre() Then

                    Try
                        My.Computer.FileSystem.CopyFile(PICUsuarios.ImageLocation, ("../../Resources/profile/" + getFileName()), Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs)
                    Catch ex As Exception
                    End Try

                    PICUsuarios.ImageLocation = ("../../Resources/profile/" + getFileName())

                    comando.CommandText = ("update usuario set nombre='" + TXTNombreUsuarios.Text +
                   "', rango='" + CBXRangoUsuarios.SelectedItem.ToString +
                   "', perfil='" + getAbsoluteRoute() +
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
                        estadoVisualizar()
                    Catch ex As Exception
                        'Se informan errores
                        MsgBox("Error: " + ex.Message)
                    End Try
                    estadoVisualizar()

                Else
                    LBLInfoUsuarios.Text = "Nombre incorrecto"
                End If

                Exit Select
            Case "agregar"
                If verificarCedula(TXTCiUsuarios.Text) Then
                    Select Case checarUsuario(TXTCiUsuarios.Text)
                        Case "inactivo"
                            If MessageBox.Show("Un usuario con esta ci ya existe pero se encuentra inactivo ¿Desea darlo de alta?", "Usuario existente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                altaUsuario(TXTCiUsuarios.Text)
                            Else
                                Exit Sub
                            End If
                        Case "activo"
                            MessageBox.Show("Un usuario con esta ci ya existe y esta activo", "Usuario existente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        Case "noexiste"
                            If verificarNombre() Then
                                If verificarPasswd(TXTPasswdUsuarios.Text) Then

                                    Try
                                        My.Computer.FileSystem.CopyFile(getAbsoluteRoute(), ("../../Resources/profile/" + getFileName()), Microsoft.VisualBasic.FileIO.UIOption.AllDialogs)
                                    Catch ex As Exception
                                    End Try


                                    PICUsuarios.ImageLocation = ("../../Resources/profile/" + getFileName())

                                    comando.CommandText = ("insert into usuario values ('" +
                                                           TXTCiUsuarios.Text + "','" +
                                                           TXTNombreUsuarios.Text + "','" +
                                                           encriptar(TXTPasswdUsuarios.Text) + "','" +
                                                           CBXRangoUsuarios.SelectedItem.ToString +
                                                           "','activo','" +
                                                           getAbsoluteRoute() +
                                                           "')")

                                    Try
                                        connection.Open()
                                        comando.ExecuteNonQuery()
                                        connection.Close()

                                        estadoVisualizar()
                                    Catch ex As Exception
                                        LBLInfoUsuarios.Text = ("Error:" + ex.Message)
                                    End Try
                                Else
                                    LBLInfoUsuarios.Text = "Contraseña erronea"
                                End If
                            Else
                                LBLInfoUsuarios.Text = "Nombre erroneo"
                            End If
                    End Select
                Else
                    LBLInfoUsuarios.Text = "Cedula erronea"
                End If
        End Select
    End Sub

    Private Function getAbsoluteRoute()

        Dim aux As String() = PICUsuarios.ImageLocation.Split("/")

        Dim fileName As String = aux(aux.Length - 1)
        Dim fileRoute As String = ""

        ReDim Preserve aux(aux.Length - 2)

        For Each e As String In aux
            fileRoute = (fileRoute + e + "/")
        Next

        Dim absoluteRoute As String = My.Computer.FileSystem.CombinePath(fileRoute, fileName)

        absoluteRoute = absoluteRoute.Replace("\", "/")

        Return absoluteRoute

    End Function

    Private Function getFileName()

        Dim aux As String() = PICUsuarios.ImageLocation.Split("/")

        Return aux(aux.Length - 1)

    End Function

    Private Sub altaUsuario(ByVal ci As String)

        comando.CommandType = CommandType.Text
        comando.Connection = connection
        comando.CommandText = ("update usuario set estado='activo' where ci='" + ci + "'")

        Try
            connection.Open()

            comando.ExecuteNonQuery()

            connection.Close()
        Catch ex As Exception

        End Try

    End Sub

    Private Function checarUsuario(ByVal ci As String)

        comando.CommandType = CommandType.Text
        comando.Connection = connection
        comando.CommandText = "select ci, estado from usuario"

        Try
            connection.Open()
            reader = comando.ExecuteReader()

            While reader.Read()

                If reader.GetInt32(0).ToString = ci Then
                    If reader.GetString(1) = "inactivo" Then
                        connection.Close()
                        Return "inactivo"
                    Else
                        connection.Close()
                        Return "activo"
                    End If
                End If

            End While

            connection.Close()

        Catch ex As Exception

        End Try

        Return "noexiste"

    End Function

    'Private Function imagenSeleccionada()

    'Dim nombre() As String

    '   If PICUsuarios.ImageLocation <> "../../Res/profile/default.bmp" And PICUsuarios.ImageLocation <> "../../Res/profile/nueva.bmp" Then
    '      nombre = PICUsuarios.ImageLocation.Split("/")
    '     nombre = nombre(nombre.Length - 1).Split(".")

    '        Return nombre(0)

    '   End If

    '    Return "default"
    'End Function

    Private Function verificarPasswd(ByVal passwd As String)
        If passwd.Length < 7 Then
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

        BTNBusquedaUsuarios.Visible = False
        CHBUsuariosInactivos.Visible = False

        DGVUsuarios.Visible = False

        CBXBusquedaUsuarios.Visible = False

        BTNAgregarUsuarios.Visible = False
        BTNEliminarUsuarios.Visible = False
        BTNModificarUsuarios.Visible = False

        BTNModificarContraseña.Visible = True

        PICUsuarios.Enabled = True
        'PICUsuarios.ImageLocation = "../../Res/profile/nueva.bmp"

        TXTBusquedaUsuarios.Visible = False

        TXTCiUsuarios.Visible = False
        LBLCiUsuarios.Visible = False

        TXTPasswdUsuarios.Visible = False
        LBLPasswdUsuarios.Visible = False

        PNLUsuarios.Visible = True
    End Sub

    Private Sub estadoAgregar()
        estadoModificar()

        estadoUsuario = "agregar"

        TXTCiUsuarios.Visible = True
        LBLCiUsuarios.Visible = True

        TXTPasswdUsuarios.Visible = True
        LBLPasswdUsuarios.Visible = True

        BTNModificarContraseña.Visible = False

        PICUsuarios.ImageLocation = ("../../Resources/profile/nueva.bmp")

        TXTCiUsuarios.Text = ""
        TXTNombreUsuarios.Text = ""
        TXTPasswdUsuarios.Text = ""
        CBXRangoUsuarios.SelectedIndex = 0
    End Sub

    Private Sub estadoVisualizar()

        estadoUsuario = "visualizar"

        BTNAceptarUsuarios.Visible = False
        BTNCancelarUsuarios.Visible = False

        BTNBusquedaUsuarios.Visible = True
        CHBUsuariosInactivos.Visible = True

        DGVUsuarios.Visible = True

        CBXBusquedaUsuarios.Visible = True

        BTNModificarUsuarios.Visible = True
        BTNAgregarUsuarios.Visible = True
        BTNEliminarUsuarios.Visible = True

        PICUsuarios.Enabled = False

        TXTBusquedaUsuarios.Visible = True

        PNLUsuarios.Visible = False

        BTNBusquedaUsuarios.PerformClick()

        StringImagenUsuarios = "default"

    End Sub

    Private Sub CheckBoxUsuarios_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHBUsuariosInactivos.CheckStateChanged

        BTNBusquedaUsuarios.PerformClick()

        If CHBUsuariosInactivos.Checked Then
            DGVUsuarios.Columns(3).Visible = True
        Else
            DGVUsuarios.Columns(3).Visible = False
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
        openFileDialog.FileName = ""



        Dim ImagenUsuarios As Image

        If openFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            If openFileDialog.FileName.Split(".")(1) = "bmp" Then
                Try
                    ImagenUsuarios = Image.FromFile(openFileDialog.FileName)
                    If ImagenUsuarios.Height <= 90 And ImagenUsuarios.Width <= 90 Then
                        'aux = openFileDialog.FileName.Split("\")
                        'aux = aux(aux.Length - 1).Split(".")
                        'PICUsuarios.ImageLocation = ("../../Res/profile/" + aux(0) + ".bmp")

                        PICUsuarios.ImageLocation = openFileDialog.FileName.Replace("\", "/")

                        openFileDialog.FileName = ""
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




    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        comando.CommandType = CommandType.Text

        comando.Connection = connection

        comando.CommandText = ("select razitas from razas")

        Try

            connection.Open()

            reader = comando.ExecuteReader()

            If reader.HasRows() Then

                While reader.Read()

                    CBXeliminarRazaCBX.Items.Add(reader.GetString(0))
                    CBXRazaGanado.Items.Add(reader.GetString(0))
                    CBXseleccionarRaza.Items.Add(reader.GetString(0))
                    CBXrazaCompradoVendido.Items.Add(reader.GetString(0))
                    CBXRazacompra.Items.Add(reader.GetString(0))
                    CBXModificarCBX.Items.Add(reader.GetString(0))


                End While

            End If

            connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If

        End Try


        actualizarGanado()
        TMRHoraFecha.Start()

        Me.Text = ("Gestión y Control Ganadero || " + Date.Today.Day.ToString + "/" + Date.Today.Month.ToString + "/" + Date.Today.Year.ToString)

        '-------------------------------------------------------------------------------------------------------------------

        '////////////VENTAS

        Consulta = "select * from venta"
        consultar()
        'actualiza la dgvw
        DataGridViewVENTAS.DataSource = Tabla
        DataGridViewVENTAS.Columns(0).HeaderText = "Id venta"
        DataGridViewVENTAS.Columns(1).HeaderText = "Fecha de venta"
        DataGridViewVENTAS.Columns(2).HeaderText = "Comentario"
        DataGridViewVENTAS.Columns(3).HeaderText = "Total"
        DataGridViewVENTAS.Columns(4).HeaderText = "Cédula de cliente"
        'panel ventas
        paneldetextosenventas.Visible = False

        '////////////FIN VENTAS

        '-------------------------------------------------------------------------------------------------------------------

        '////////////CLIENTES

        PanelPrincipalclientes.Enabled = True
        PanelPrincipalclientes.Visible = True
        PanelPrincipalclientes.BringToFront()

        PanelAgregarcliente.Enabled = False
        PanelAgregarcliente.Visible = False

        '////////////FIN CLIENTES

        '-------------------------------------------------------------------------------------------------------------------

        '////////////COMPRAS

        'Consulta = "select sum(totalc) from compra where year(fechacompra) = year(now())"

        CBXBuscarcompra.Text = "Id"

        'Paneles de agregar compras
        PNLAgregarcompraganado.Enabled = False
        PNLAgregarcompraganado.Visible = False
        PNLAgregarcompraganado.SendToBack()

        PNLAgregarcompraproducto.Enabled = False
        PNLAgregarcompraproducto.Visible = False
        PNLAgregarcompraproducto.SendToBack()

        'Muestra el panel principal de Compras y oculta los otros
        PNLPrincipalcompra.BringToFront()
        PNLModificarcompras.Visible = False
        PNLAgregarcompras.Visible = False

        '////////////FIN COMPRAS
    End Sub

    '////////////////////////////////////////INICIO DE GANADO///////////////////////////////////////////////////////////////////

    '/////////////////////// MUESTRA EN EL DRATAGRID LA RAZA  Y EL SEXO SELECCIONAD0 EN EL COMBOBOX/////////////////////////////////////
    ' ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    Private Sub BOTONseleccionarRaza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONseleccionarRaza.Click

        DataGridGanadoEconomico.Visible = False
        ACtivarBotonesGanado()

        If CBXseleccionarRaza.Text <> "" And CBXseleccionarSexo.Text <> "" Then
            If CBXseleccionarSexo.Text = "Ambos" Then
                Try
                    Consulta = " SELECT idg,sexo,raza,estado,nacimiento, TIMESTAMPDIFF(YEAR,nacimiento,CURDATE()) AS 'Edad', TIMESTAMPDIFF(month, ganado.nacimiento,NOW())%12 AS 'Meses' from ganado  where estado <> 'Muerto/a' and raza= '" + CBXseleccionarRaza.SelectedItem + "'"
                    ActualizarGanadoSinConsulta()


                    If DataGridViewganado.Rows.Count = 0 Then
                        MessageBox.Show("NO hay ganado registrado con los datos ingresado en la busqueda", "Busqueda de ganado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        CBXseleccionarRaza.Text = ""
                        CBXseleccionarSexo.Text = ""
                        actualizarGanado()
                    End If
                Catch ex As Exception
                    MsgBox(ex.ToString)

                End Try

            ElseIf CBXseleccionarSexo.Text = "Macho" Then

                Try
                    Consulta = " SELECT idg,sexo,raza,estado,nacimiento, TIMESTAMPDIFF(YEAR,nacimiento,CURDATE()) AS 'Edad', TIMESTAMPDIFF(month, ganado.nacimiento,NOW())%12 AS 'Meses' from ganado  where estado <> 'Muerto/a' and raza= '" + CBXseleccionarRaza.SelectedItem + "' And sexo = 'Macho' "
                    ActualizarGanadoSinConsulta()

                    'CBXseleccionarRaza.Text = ""
                    'CBXseleccionarSexo.Text = ""

                    If DataGridViewganado.Rows.Count = 0 Then
                        MessageBox.Show("NO hay ganado registrado con los datos ingresado en la busqueda", "Busqueda de ganado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        CBXseleccionarRaza.Text = ""
                        CBXseleccionarSexo.Text = ""
                        actualizarGanado()

                    End If
                Catch ex As Exception
                    MsgBox(ex.ToString)

                End Try

            ElseIf CBXseleccionarSexo.Text = "Hembra" Then
                Try
                    Consulta = " SELECT idg,sexo,raza,estado,nacimiento, TIMESTAMPDIFF(YEAR,nacimiento,CURDATE()) AS 'Edad', TIMESTAMPDIFF(month, ganado.nacimiento,NOW())%12 AS 'Meses' from ganado where raza= '" + CBXseleccionarRaza.SelectedItem + "' And sexo = 'Hembra'"
                    ActualizarGanadoSinConsulta()

                    'CBXseleccionarRaza.Text = ""
                    'CBXseleccionarSexo.Text = ""
                    If DataGridViewganado.Rows.Count = 0 Then
                        MessageBox.Show("NO hay ganado registrado con los datos ingresado en la busqueda", "Busqueda de ganado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        CBXseleccionarRaza.Text = ""
                        CBXseleccionarSexo.Text = ""
                        actualizarGanado()

                    End If
                Catch ex As Exception
                    MsgBox(ex.ToString)

                End Try

            End If
        Else
            MsgBox(" Debe seleccionar sexo y raza ", MsgBoxStyle.Critical, Title:=" Error ")

        End If
    End Sub


    '''/////////////////////// ABRI PANEL BUSCAR CODIGO GANADO ////////////////////////////
    ''' ////////////////////////////////////////////////////////////////////////////////////
    Private Sub BOTONpanelCodigo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONpanelCodigo.Click
        GroupBox3.Enabled = True
        BOTONguardarAgregar.Enabled = True
        BOTONcancelarAgregar.Enabled = True
        BOTONguardarModificar.Enabled = True
        BOTONcancelarModificar.Enabled = True

        CBXcompradoVendido.Text = ""
        CBXrazaCompradoVendido.Text = ""
        DateTimeBuscarFechaGanado.Text = ""
        CBXbuscarEstadoGanado.Text = ""
        CBXseleccionarRaza.Text = ""
        CBXseleccionarSexo.Text = ""

        PanelDatosGanado.Visible = False
        PanelBuscarEstadoGanado.Visible = False
        PanelBuscarSexoRaza.Visible = False
        PanelBuscarFechaNacimiento.Visible = False
        PanelBuscarCodGanado.Visible = True
        PanelCompradoVenedido.Visible = False
        txtBuscarCodGanado.Focus()

    End Sub



    '''///////////////////////////////////////// ABRE PANEL DE BUSQUEDA POR NACIEMIENTO
    Private Sub BOTONpanelBuscarNacimiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONpanelBuscarNacimiento.Click
        GroupBox3.Enabled = True
        BOTONguardarAgregar.Enabled = True
        BOTONcancelarAgregar.Enabled = True
        BOTONguardarModificar.Enabled = True
        BOTONcancelarModificar.Enabled = True

        txtBuscarCodGanado.Text = ""
        CBXcompradoVendido.Text = ""
        CBXrazaCompradoVendido.Text = ""
        DateTimeBuscarFechaGanado.Text = ""
        CBXbuscarEstadoGanado.Text = ""
        CBXseleccionarRaza.Text = ""
        CBXseleccionarSexo.Text = ""

        PanelDatosGanado.Visible = False
        PanelBuscarEstadoGanado.Visible = False
        PanelBuscarCodGanado.Visible = False
        PanelBuscarSexoRaza.Visible = False
        PanelCompradoVenedido.Visible = False
        PanelBuscarFechaNacimiento.Visible = True
    End Sub


    '/////////////////////////////// ABRE PANEL DE BUSQUEDA DE SEXO Y RAZA //////////////////////////////////////////////////////
    ' ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    Private Sub BOTONpanelSexoRaza_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONpanelSexoRaza.Click

        GroupBox3.Enabled = True
        BOTONguardarAgregar.Enabled = True
        BOTONcancelarAgregar.Enabled = True
        BOTONguardarModificar.Enabled = True
        BOTONcancelarModificar.Enabled = True

        txtBuscarCodGanado.Text = ""
        CBXcompradoVendido.Text = ""
        CBXrazaCompradoVendido.Text = ""
        DateTimeBuscarFechaGanado.Text = ""
        CBXbuscarEstadoGanado.Text = ""
        CBXseleccionarRaza.Text = ""
        CBXseleccionarSexo.Text = ""

        PanelDatosGanado.Visible = False
        PanelBuscarEstadoGanado.Visible = False
        PanelBuscarCodGanado.Visible = False
        PanelBuscarFechaNacimiento.Visible = False
        PanelCompradoVenedido.Visible = False
        PanelBuscarSexoRaza.Visible = True
    End Sub


    '''///////////////////////////////////// VUELVE INVISIBLE EL PANEL DE BUSQUEQUE DE SEXO  Y RAZA//////////////////////////////
    ''' //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    Private Sub BOTONocultarSexoRaza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONocultarSexoRaza.Click
        CBXseleccionarRaza.Text = ""
        CBXseleccionarSexo.Text = ""

        'actualizarGanado()

        PanelBuscarSexoRaza.Visible = False

    End Sub

    '//////////////////BUSCA GANADO POR SU FECHA DE NACIMIENTO ///////////////////////////////////////
    Private Sub BuscarFechaGanado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONBuscarFechaGanado.Click
        DataGridGanadoEconomico.Visible = False
        ACtivarBotonesGanado()
        Dim FechaN As String = DateTimeBuscarFechaGanado.Value.ToString("yyyy-MM-dd")

        Consulta = "SELECT idg,sexo,raza,estado,nacimiento, TIMESTAMPDIFF(YEAR,ganado.nacimiento,CURDATE()) AS'Anios', TIMESTAMPDIFF(month, ganado.nacimiento,NOW())%12 AS 'Meses' from ganado  where estado <> 'Muerto/a' and nacimiento ='" & FechaN & "'"
        ActualizarGanadoSinConsulta()
        If DataGridViewganado.Rows.Count = 0 Then
            MessageBox.Show("No se encontraron datos de la fecha que usted ingreso", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            actualizarGanado()
        End If


    End Sub
    '''//////////////////// OCULTA PANEL DE BUSQUE DE FACHA DE NACIMIENTO/////////////////////////////
    ''' /////////////////////////////////////////////////////////////////////////////////////////////
    Private Sub BOTONocultarPanelFechaG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONocultarPanelFechaG.Click
        DateTimeBuscarFechaGanado.Text = ""

        'actualizarGanado()

        PanelBuscarFechaNacimiento.Visible = False
    End Sub


    '''//////////// CERRAR PANEL BUSCAR CODIGO DE GANADO /////////////////////////////////////////////////////////
    ''' /////////////////////////////////////////////////////////////////////////////////////////////////////////
    ''' 
    Private Sub BOTONcancelarBuscarCodigo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONcancelarBuscarCodigo.Click
        txtBuscarCodGanado.Text = ""
        'actualizarGanado()

        PanelBuscarCodGanado.Visible = False
    End Sub




    '''/////////////////BOTON QUE ACTIVA LA OPCION GUARDAR GANADO PARA AGREGAR////////////////////////////////////////
    ''' ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ''' 
    Private Sub BOTONabrirAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONabrirAgregar.Click


        GroupBox1.Enabled = True
        If DataGridViewganado.Rows.Count = 0 Then
            Consulta = " alter table ganado auto_increment = 1001 "
            consultar()


        End If




        CBXmodificarEstadoGanado.Visible = False
        'GroupBox1.Enabled = True

        DataGridViewganado.Enabled = False

        BOTONguardarAgregar.Visible = True
        BOTONcancelarAgregar.Visible = True

        CBXagregarEstadoGanado.Visible = True
        CBXagregarEstadoGanado.Enabled = True
        CBXsexoGanado.Enabled = True
        CBXRazaGanado.Enabled = True

        DTPAgregarGanado.Enabled = True



        'CBXagregarEstadoGanado.Enabled = True

        'CBXsexoGanado.Text = ""
        'CBXRazaGanado.Text = ""

        'DTPAgregarGanado.Text = ""


        CBXagregarEstadoGanado.Text = ""

        BOTONabrirAgregar.Enabled = False
        BOTONabrirModificar.Enabled = False


    End Sub
    '''/////////////////////////////////////////BOTON PARA CANCELAR EL GUARDADO DEL AGREGADO DE GANADO////////////////////////////////
    ''' ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    Private Sub BOTONcancelarAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONcancelarAgregar.Click

        GroupBox1.Enabled = False

        DataGridViewganado.Enabled = True

        BOTONabrirAgregar.Enabled = True

        BOTONabrirModificar.Enabled = True
        CBXsexoGanado.Enabled = False
        CBXRazaGanado.Enabled = False
        DTPAgregarGanado.Enabled = False

        CBXagregarEstadoGanado.Enabled = False
        CBXsexoGanado.Text = ""
        CBXRazaGanado.Text = ""
        DTPAgregarGanado.Text = ""

        CBXagregarEstadoGanado.Text = ""
        CBXmodificarEstadoGanado.Text = ""
        If DataGridViewganado.Rows.Count = 0 Then
            BOTONabrirAgregar.Focus()

        Else

            DataGridViewganado.Focus()

            CBXsexoGanado.Text = DataGridViewganado.Item(1, DataGridViewganado.CurrentRow.Index).Value
            CBXRazaGanado.Text = DataGridViewganado.Item(2, DataGridViewganado.CurrentRow.Index).Value
            DTPAgregarGanado.Text = DataGridViewganado.Item(4, DataGridViewganado.CurrentRow.Index).Value
            CBXagregarEstadoGanado.Text = DataGridViewganado.Item(3, DataGridViewganado.CurrentRow.Index).Value
            CBXmodificarEstadoGanado.Text = DataGridViewganado.Item(3, DataGridViewganado.CurrentRow.Index).Value
            BOTONguardarAgregar.Visible = False
            BOTONcancelarAgregar.Visible = False

        End If
       
    End Sub

    '''/////////////////////////////////////BOTON PARA INGRESAR NUEVO GANADO//////////////////////////////////////
    ''' //////////////////////////////////////////////////////////////////////////////////////////////////////////
    Private Sub BOTONguardarAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONguardarAgregar.Click
        If MessageBox.Show("¿Seguro desea guardar datos ?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            'Dim CodG As Integer = Val(Texcodigoganado.Text)

            Dim estado As String = CBXagregarEstadoGanado.SelectedItem
            Dim sexo As String = CBXsexoGanado.SelectedItem
            Dim raza As String = CBXRazaGanado.SelectedItem
            Dim fechaN As String = DTPAgregarGanado.Value.ToString("yyyy-MM-dd")





            If estado <> "" Then



                Try

                    Consulta = "insert into ganado (sexo, raza, estado, nacimiento) values('" & sexo & "','" & raza & "','" & estado & "','" & fechaN & "' )"
                    consultar()

                    actualizarGanado()


                    CBXsexoGanado.Text = ""
                    CBXRazaGanado.Text = ""

                    DTPAgregarGanado.Value = Today
                    CBXagregarEstadoGanado.Text = ""

                    CBXsexoGanado.Enabled = True
                    CBXRazaGanado.Enabled = True

                    DTPAgregarGanado.Enabled = True


                    MsgBox("Datos guardados", MsgBoxStyle.Information)


                Catch ex As Exception
                    MsgBox(ex.Message)

                End Try


            Else
                MsgBox("El campo estado no puede ser vacio", MsgBoxStyle.Exclamation, Title:="No se guardaron datos")
            End If
        End If


    End Sub

   

    '///////////////////////////////BOTON PARA MODIFICAR DATOS EN LOS CAMPOS////////////////////////////////////////
    ' //////////////////////////////////////////////////////////////////////////////////////////////////////////////

    Private Sub BOTONguardarModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONguardarModificar.Click




        If MessageBox.Show("¿Seguro que desea modificar ?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Dim codigo As String = DataGridViewganado.Item(0, DataGridViewganado.CurrentRow.Index).Value
            Dim sexo As String = CBXsexoGanado.SelectedItem
            Dim raza As String = CBXRazaGanado.SelectedItem
            Dim estado As String = CBXmodificarEstadoGanado.SelectedItem
            Dim fechaN As String = DTPAgregarGanado.Value.ToString("yyyy-MM-dd")


            If CBXsexoGanado.Text <> "" And CBXRazaGanado.Text <> "" And CBXmodificarEstadoGanado.Text <> "" Then




                Try

                    Consulta = "update ganado set sexo= '" + sexo +
                                              "',raza= '" + raza +
                                              "',estado = '" + estado +
                                              "',nacimiento= '" + fechaN +
                                              "' where idg= '" + codigo + "'"
                    consultar()
                    actualizarGanado()


                    CBXRazaGanado.Text = ""
                    CBXsexoGanado.Text = ""

                    DTPAgregarGanado.Value = Today
                    CBXagregarEstadoGanado.Text = ""
                    MsgBox("Datos editados", MsgBoxStyle.Information)



                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
           
        Else
            MsgBox("Los campos no pueden estar vacios", MsgBoxStyle.Exclamation, Title:="No se realizaron cambios")
        End If

            If CBXmodificarEstadoGanado.Text = "Muerto/a" Then
                MsgBox("fdjvj")
            End If
        End If
    End Sub

    Private Sub BOTONabrirModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONabrirModificar.Click

        GroupBox1.Enabled = True

        If CBXmodificarEstadoGanado.SelectedItem = "vendido" Then
            CBXmodificarEstadoGanado.Enabled = False
            CBXRazaGanado.Enabled = False
            CBXsexoGanado.Enabled = False
            DTPAgregarGanado.Enabled = False

        Else
            CBXmodificarEstadoGanado.Enabled = True
            CBXRazaGanado.Enabled = True
            CBXsexoGanado.Enabled = True
            DTPAgregarGanado.Enabled = True
        End If


        BOTONguardarModificar.Visible = True
        BOTONcancelarModificar.Visible = True
        'BOTONabrirAgregar.Enabled = True
        CBXsexoGanado.Enabled = True
        CBXRazaGanado.Enabled = True
        DTPAgregarGanado.Enabled = True


        CBXagregarEstadoGanado.Visible = False
        CBXmodificarEstadoGanado.Visible = True
        CBXmodificarEstadoGanado.Enabled = True

        DataGridViewganado.Focus()

        CBXsexoGanado.Text = DataGridViewganado.Item(1, DataGridViewganado.CurrentRow.Index).Value
        CBXRazaGanado.Text = DataGridViewganado.Item(2, DataGridViewganado.CurrentRow.Index).Value
        DTPAgregarGanado.Text = DataGridViewganado.Item(4, DataGridViewganado.CurrentRow.Index).Value
        CBXagregarEstadoGanado.Text = DataGridViewganado.Item(3, DataGridViewganado.CurrentRow.Index).Value
        CBXmodificarEstadoGanado.Text = DataGridViewganado.Item(3, DataGridViewganado.CurrentRow.Index).Value

  
            If CBXmodificarEstadoGanado.SelectedItem = "vendido" Then
                CBXmodificarEstadoGanado.Enabled = False
                CBXRazaGanado.Enabled = False
                CBXsexoGanado.Enabled = False
            DTPAgregarGanado.Enabled = False
            BOTONguardarModificar.Enabled = False

            Else
                CBXmodificarEstadoGanado.Enabled = True
                CBXRazaGanado.Enabled = True
                CBXsexoGanado.Enabled = True
            DTPAgregarGanado.Enabled = True
            BOTONguardarModificar.Enabled = True
            End If


        BOTONabrirModificar.Enabled = False
        BOTONabrirAgregar.Enabled = False

    End Sub
    '''(((((((/////////////////////CANCELA Y CIERRA EL BOTON MODIFICAR//////////////////////////////
    ''' //////////////////////////////////////////////////////////////////////////////////////
    Private Sub BOTONcancelarModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONcancelarModificar.Click
        GroupBox1.Enabled = False

        CBXmodificarEstadoGanado.Visible = False
        CBXagregarEstadoGanado.Visible = True

        BOTONabrirModificar.Enabled = True

        BOTONabrirAgregar.Enabled = True

        CBXsexoGanado.Enabled = False
        CBXRazaGanado.Enabled = False
        DTPAgregarGanado.Enabled = False
        CBXagregarEstadoGanado.Enabled = False

        CBXRazaGanado.Text = ""
        CBXsexoGanado.Text = ""
        DTPAgregarGanado.Text = ""
        CBXagregarEstadoGanado.Text = ""
        'Texestadoganado.Clear()
        DataGridViewganado.Focus()

        CBXsexoGanado.Text = DataGridViewganado.Item(1, DataGridViewganado.CurrentRow.Index).Value
        CBXRazaGanado.Text = DataGridViewganado.Item(2, DataGridViewganado.CurrentRow.Index).Value
        DTPAgregarGanado.Text = DataGridViewganado.Item(4, DataGridViewganado.CurrentRow.Index).Value
        CBXagregarEstadoGanado.Text = DataGridViewganado.Item(3, DataGridViewganado.CurrentRow.Index).Value

        BOTONguardarModificar.Visible = False
        BOTONcancelarModificar.Visible = False
    End Sub

    '''//////////////////////////// DENTRO DEL DATAGRID ESTA EL CODIGO PARA PASAR DATOS A LOS CAMPOS//////////////////
    ''' ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
    Private Sub DataGridViewganado_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewganado.SelectionChanged


        Try

            CBXsexoGanado.Text = ""
            CBXRazaGanado.Text = ""
            DTPAgregarGanado.Text = ""
            CBXagregarEstadoGanado.Text = ""
            CBXmodificarEstadoGanado.Text = ""
            CBXmodificarEstadoGanado.Enabled = True
            CBXsexoGanado.Text = DataGridViewganado.Item(1, DataGridViewganado.CurrentRow.Index).Value
            CBXRazaGanado.Text = DataGridViewganado.Item(2, DataGridViewganado.CurrentRow.Index).Value
            DTPAgregarGanado.Text = DataGridViewganado.Item(4, DataGridViewganado.CurrentRow.Index).Value
            CBXagregarEstadoGanado.Text = DataGridViewganado.Item(3, DataGridViewganado.CurrentRow.Index).Value
            CBXmodificarEstadoGanado.Text = DataGridViewganado.Item(3, DataGridViewganado.CurrentRow.Index).Value

            If GroupBox1.Enabled = False Then
                CBXmodificarEstadoGanado.Enabled = False
                CBXRazaGanado.Enabled = False
                CBXsexoGanado.Enabled = False
                DTPAgregarGanado.Enabled = False
                CBXagregarEstadoGanado.Enabled = False
            Else
                If CBXmodificarEstadoGanado.SelectedItem = "vendido" Then
                    CBXmodificarEstadoGanado.Enabled = False
                    CBXRazaGanado.Enabled = False
                    CBXsexoGanado.Enabled = False
                    DTPAgregarGanado.Enabled = False
                    BOTONguardarModificar.Enabled = False

                Else
                    CBXmodificarEstadoGanado.Enabled = True
                    CBXRazaGanado.Enabled = True
                    CBXsexoGanado.Enabled = True
                    DTPAgregarGanado.Enabled = True
                    BOTONguardarModificar.Enabled = True
                End If
            End If
        Catch ex As Exception
            'MsgBox(" NO SELECCIONO DATO HA MODIFICAR" & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical, Title:=" ERROR ")
        End Try


    End Sub




    '////////////////////////// BOTON PARA ELIMINAR GANADO/////////////////////////////
    '/////////////////////////////////////////////////////////////////////////////////


    'Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminarganado.Click
    '    Dim MsgStyle As MsgBoxStyle = MsgBoxStyle.Critical + MsgBoxStyle.OkOnly
    '    Dim MsgStyle1 As MsgBoxStyle = MsgBoxStyle.Information + MsgBoxStyle.OkOnly
    '    If MessageBox.Show("¿Seguro que desea eliminar ?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '        Try
    '            Consulta = " delete from ganado where idg='" & DataGridViewganado.Item(0, DataGridViewganado.CurrentRow.Index).Value & "'"
    '            consultar()

    '            actualizarGanado()

    '            DataGridViewganado.Focus()

    '            MsgBox("Datos borrados", MsgStyle1, Title:="Eliminado")
    '        Catch ex As Exception
    '            MsgBox("NO HAY DATOS PARA ELIMINAR" & vbCrLf & vbCrLf, MsgStyle, Title:="ERROR")
    '        End Try
    '        '& vbCrLf & vbCrLf & ex.Message, MsgStyle, Title:="ERROR

    '    End If
    'End Sub
    '''////////////////////////////PARA VOLVER A MOSTRAR DATOS COMPLETOS DE GANADO EN EL DATAGRID///////////////////
    ''' ///////////////////////////////////////////////////////////////////////////////////////////////////////////
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        DataGridGanadoEconomico.Visible = False
        ACtivarBotonesGanado()

        actualizarGanado()
    End Sub

    Private Sub txtBuscarCodGanado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscarCodGanado.KeyPress
        DataGridGanadoEconomico.Visible = False
        ACtivarBotonesGanado()

        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then


            'If IsNumeric(txtBuscarCodGanado.Text) Then


        Else
            e.Handled = True
        End If
        'DataGridViewganado.Columns(0).HeaderText = "Codigo"
        'DataGridViewganado.Columns(1).HeaderText = "Sexo"
        'DataGridViewganado.Columns(2).HeaderText = "Raza"

        'DataGridViewganado.Columns(4).HeaderText = "Fecha Nacimiento"
        'DataGridViewganado.Columns(3).HeaderText = "Estado"
        'DataGridViewganado.Columns(5).HeaderText = "Años"
        'DataGridViewganado.Columns(6).HeaderText = "Meses"


        'Else
        'txtBuscarCodGanado.Clear()

        'Consulta = "SELECT idg,sexo,raza,estado,nacimiento, TIMESTAMPDIFF(YEAR,ganado.nacimiento,CURDATE()) AS'Anios', TIMESTAMPDIFF(month, ganado.nacimiento,NOW())%12 AS 'Meses' from ganado " '"
        'consultar()
        'DataGridViewganado.DataSource = Tabla

        'DataGridViewganado.Columns(0).HeaderText = "Codigo"
        'DataGridViewganado.Columns(1).HeaderText = "Sexo"
        'DataGridViewganado.Columns(2).HeaderText = "Raza"

        'DataGridViewganado.Columns(4).HeaderText = "Fecha Nacimiento"
        'DataGridViewganado.Columns(3).HeaderText = "Estado"
        'DataGridViewganado.Columns(5).HeaderText = "Años"
        'DataGridViewganado.Columns(6).HeaderText = "Meses"


        'End If
    End Sub
    Private Sub txtBuscarCodGanado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscarCodGanado.TextChanged
        DataGridGanadoEconomico.Visible = False
        DataGridViewganado.Visible = True
        Consulta = "SELECT idg,sexo,raza,estado,nacimiento, TIMESTAMPDIFF(YEAR,ganado.nacimiento,CURDATE()) AS'Anios', TIMESTAMPDIFF(month, ganado.nacimiento,NOW())%12 AS 'Meses' from ganado  where estado <> 'Muerto/a' and idg like '" & txtBuscarCodGanado.Text & "%'"

        consultar()
        DataGridViewganado.DataSource = Tabla

    End Sub








    Private Sub BOTONbuscarPanelestado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONbuscarPanelestado.Click
        GroupBox3.Enabled = True
        BOTONguardarAgregar.Enabled = True
        BOTONcancelarAgregar.Enabled = True
        BOTONguardarModificar.Enabled = True
        BOTONcancelarModificar.Enabled = True


        txtBuscarCodGanado.Text = ""
        CBXcompradoVendido.Text = ""
        CBXrazaCompradoVendido.Text = ""
        DateTimeBuscarFechaGanado.Text = ""
        CBXbuscarEstadoGanado.Text = ""
        CBXseleccionarRaza.Text = ""
        CBXseleccionarSexo.Text = ""

        PanelDatosGanado.Visible = False
        PanelBuscarSexoRaza.Visible = False
        PanelBuscarFechaNacimiento.Visible = False
        PanelBuscarCodGanado.Visible = False
        PanelCompradoVenedido.Visible = False
        PanelBuscarEstadoGanado.Visible = True
    End Sub

    Private Sub BOTONcerrarPanelEstado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONcerrarPanelEstado.Click

        CBXbuscarEstadoGanado.Text = ""

        PanelBuscarEstadoGanado.Visible = False
        actualizarGanado()

    End Sub

    Private Sub BOTONbuscarEstadoGanado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONbuscarEstadoGanado.Click

        DataGridGanadoEconomico.Visible = False
        ACtivarBotonesGanado()

        If CBXbuscarEstadoGanado.Text <> "" Then


            If CBXbuscarEstadoGanado.Text = "activo" Then

                Try
                    Consulta = "select idg, sexo, raza, estado, nacimiento, TIMESTAMPDIFF(YEAR,ganado.nacimiento,CURDATE()) AS 'Anios', TIMESTAMPDIFF(month, ganado.nacimiento,NOW())%12 AS 'Meses' from ganado where estado = '" & CBXbuscarEstadoGanado.SelectedItem & "'"
                    ActualizarGanadoSinConsulta()

                    If DataGridViewganado.Rows.Count = 0 Then
                        MessageBox.Show("No se encontraron datos de ganado activo", "Busqueda por Estado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        actualizarGanado()

                    End If

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try


            ElseIf CBXbuscarEstadoGanado.Text = "vendido" Then

                Try

                    Consulta = "select idg, sexo, raza, estado, nacimiento, TIMESTAMPDIFF(YEAR,ganado.nacimiento,CURDATE()) AS 'Anios', TIMESTAMPDIFF(month, ganado.nacimiento,NOW())%12 AS 'Meses' from ganado where estado = '" & CBXbuscarEstadoGanado.SelectedItem & "'"
                    ActualizarGanadoSinConsulta()

                    If DataGridViewganado.Rows.Count = 0 Then
                        MessageBox.Show("No se encontraron datos de ganado vendido", "Busqueda por Estado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        actualizarGanado()

                    End If

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try



            ElseIf CBXbuscarEstadoGanado.Text = "enfermo/a" Then

                Try

                    Consulta = "select idg, sexo, raza, estado, nacimiento, TIMESTAMPDIFF(YEAR,ganado.nacimiento,CURDATE()) AS 'Anios', TIMESTAMPDIFF(month, ganado.nacimiento,NOW())%12 AS 'Meses' from ganado where estado = '" & CBXbuscarEstadoGanado.SelectedItem & "'"
                    ActualizarGanadoSinConsulta()

                    If DataGridViewganado.Rows.Count = 0 Then
                        MessageBox.Show("No se encontraron datos de ganado Enfermo/a", "Busqueda por Estado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        actualizarGanado()


                    End If



                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            ElseIf CBXbuscarEstadoGanado.Text = "Muerto/a" Then

                Try

                    Consulta = "select idg, sexo, raza, estado, nacimiento, TIMESTAMPDIFF(YEAR,ganado.nacimiento,CURDATE()) AS 'Anios', TIMESTAMPDIFF(month, ganado.nacimiento,NOW())%12 AS 'Meses' from ganado where estado = '" & CBXbuscarEstadoGanado.SelectedItem & "'"
                    ActualizarGanadoSinConsulta()

                    If DataGridViewganado.Rows.Count = 0 Then
                        MessageBox.Show("No se encontraron datos de ganado Muerto/a", "Busqueda por Estado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        actualizarGanado()


                    End If



                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If
        Else

            MessageBox.Show("debe seleccionar una opcion para relizar busqueda", "Busqueda por Estado", MessageBoxButtons.OK, MessageBoxIcon.Information)



        End If
    End Sub

    Private Sub BOTONpanelActividadEconomica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONpanelActividadEconomica.Click

       

        GroupBox3.Enabled = True
        BOTONguardarAgregar.Enabled = True
        BOTONcancelarAgregar.Enabled = True
        BOTONguardarModificar.Enabled = True
        BOTONcancelarModificar.Enabled = True

        txtBuscarCodGanado.Text = ""
        CBXcompradoVendido.Text = ""
        CBXrazaCompradoVendido.Text = ""
        DateTimeBuscarFechaGanado.Text = ""
        CBXbuscarEstadoGanado.Text = ""
        CBXseleccionarRaza.Text = ""
        CBXseleccionarSexo.Text = ""

        PanelDatosGanado.Visible = False
        PanelBuscarEstadoGanado.Visible = False
        PanelBuscarSexoRaza.Visible = False
        PanelBuscarFechaNacimiento.Visible = False
        PanelBuscarCodGanado.Visible = False
        PanelCompradoVenedido.Visible = True
        txtBuscarCodGanado.Focus()


    End Sub

    Private Sub BOTONbuscarCompradoVenedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONbuscarCompradoVenedido.Click
        Dim raza As String = CBXrazaCompradoVendido.SelectedItem.ToString

        If CBXcompradoVendido.Text <> "" And CBXrazaCompradoVendido.Text <> "" Then

            If CBXcompradoVendido.Text = "Vendido" And CBXrazaCompradoVendido.Text = "Todas las razas" Then


                DesactivarBotonesGanado()
                DataGridGanadoEconomico.Visible = True
                Consulta = " SELECT idg AS 'Cod Ganado', sexo AS 'Sexo', raza AS 'Raza', estado AS 'Estado', nacimiento As'Fecha Nacimiento', venta.idv AS 'Num Venta', fechaventa As 'Fecha de Venta', totalv AS 'Total US$' from ganado inner join venta on ganado.idv = venta.idv"
                consultar()
                DataGridGanadoEconomico.DataSource = Tabla

                'DataGridGanadoEconomico.Columns(4).Visible = False
                DataGridGanadoEconomico.Focus()



                BOTONpanelActividadEconomica.Visible = True

                If DataGridGanadoEconomico.Rows.Count = 0 Then

                    MsgBox("No se encontraron datos de ganados vendidos", MsgBoxStyle.Information, Title:="Venta de ganado")
                    ACtivarBotonesGanado()
                    actualizarGanado()

                End If

            ElseIf CBXcompradoVendido.Text = "Comprado" And CBXrazaCompradoVendido.Text = "Todas las razas" Then

                DesactivarBotonesGanado()
                DataGridGanadoEconomico.Visible = True
                Consulta = " SELECT idg AS 'Cod Ganado', sexo AS 'Sexo', raza AS 'Raza', estado AS 'Estado', nacimiento As'Fecha Nacimiento', compra.idc AS 'Id Compra', fechacompra As 'Fecha de compra', precioc AS 'Total US$' from ganado  inner join compra on ganado.idc = compra.idc  where estado <> 'Muerto/a' "
                consultar()
                DataGridGanadoEconomico.DataSource = Tabla
                DataGridGanadoEconomico.Columns(4).Visible = False
                DataGridGanadoEconomico.Focus()



                BOTONpanelActividadEconomica.Visible = True

                If DataGridGanadoEconomico.Rows.Count = 0 Then

                    MsgBox("No se encontraron datos de ganado comprado", MsgBoxStyle.Information, Title:="Compra de ganado")
                    ACtivarBotonesGanado()
                    actualizarGanado()

                End If

            ElseIf CBXcompradoVendido.Text = "Vendido" Then


                DesactivarBotonesGanado()
                DataGridGanadoEconomico.Visible = True
                Consulta = " SELECT idg AS 'Cod Ganado', sexo AS 'Sexo', raza AS 'Raza', estado AS 'Estado' nacimiento As'Fecha Nacimiento', venta.idv AS 'Num Compra', fechaventa As 'Fecha de venta', totalv AS 'Total US$' from ganado,venta where ganado.idv = venta.idv   estado <> 'Muerto/a' and raza='" + CBXrazaCompradoVendido.SelectedItem + "'"
                consultar()
                DataGridGanadoEconomico.DataSource = Tabla

                'DataGridGanadoEconomico.Columns(4).Visible = False
                DataGridGanadoEconomico.Focus()



                BOTONpanelActividadEconomica.Visible = True

                If DataGridGanadoEconomico.Rows.Count = 0 Then

                    MsgBox("No se encontraron datos de ganados vendidos en la raza seleccionada", MsgBoxStyle.Information, Title:="Venta de ganado")
                    ACtivarBotonesGanado()
                    actualizarGanado()

                End If

            ElseIf CBXcompradoVendido.Text = "Comprado" Then

                DesactivarBotonesGanado()
                DataGridGanadoEconomico.Visible = True
                Consulta = " SELECT idg AS 'Cod Ganado', sexo AS 'Sexo', raza AS 'Raza', estado AS 'Estado', nacimiento As'Fecha Nacimiento', compra.idc AS 'Num Compra', fechacompra As 'Fecha de compra', precioc AS 'Total US$' from ganado inner join compra on ganado.idc= compra.idc  where estado <> 'Muerto/a' and raza='" + CBXrazaCompradoVendido.SelectedItem + "'"
                consultar()
                DataGridGanadoEconomico.DataSource = Tabla
                'DataGridGanadoEconomico.Columns(4).Visible = False
                DataGridGanadoEconomico.Focus()



                BOTONpanelActividadEconomica.Visible = True

                If DataGridGanadoEconomico.Rows.Count = 0 Then

                    MsgBox("No se encontraron datos de ganado comprado de la raza seleccionada", MsgBoxStyle.Information, Title:="Compra de ganado")
                    ACtivarBotonesGanado()
                    actualizarGanado()

                End If
            End If


        Else
            MsgBox("Debe seleccionar dato en ambos campos")

        End If
    End Sub



    Private Sub BOTONabriPanelDatosGanado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONabriPanelDatosGanado.Click
        PanelDatosGanado.Visible = True
    End Sub


    '//////////////////EVENTO MouseENTER//////////////////////////////////////

    Private Sub PanelCompradoVenedido_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelCompradoVenedido.MouseEnter
        PanelDatosGanado.Visible = False
    End Sub

    Private Sub PanelBuscarSexoRaza_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelBuscarSexoRaza.MouseEnter
        PanelDatosGanado.Visible = False
    End Sub


    Private Sub PanelBuscarCodGanado_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelBuscarCodGanado.MouseEnter
        PanelDatosGanado.Visible = False
    End Sub

    Private Sub PanelBuscarEstadoGanado_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelBuscarEstadoGanado.MouseEnter
        PanelDatosGanado.Visible = False
    End Sub

    Private Sub PanelBuscarFechaNacimiento_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelBuscarFechaNacimiento.MouseEnter
        PanelDatosGanado.Visible = False
    End Sub

    Private Sub DataGridViewganado_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridViewganado.MouseEnter
        PanelDatosGanado.Visible = False
    End Sub

    Private Sub Panel1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel1.MouseEnter
        PanelDatosGanado.Visible = False
    End Sub

    Private Sub DataGridGanadoEconomico_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridGanadoEconomico.MouseEnter
        PanelDatosGanado.Visible = False
    End Sub

    Private Sub TabGanado_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabGanado.MouseEnter
        PanelDatosGanado.Visible = False
    End Sub

    Private Sub BOTONcerrarPanelCompradoVendido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONcerrarPanelCompradoVendido.Click

        CBXcompradoVendido.Text = ""
        CBXrazaCompradoVendido.Text = ""

        PanelCompradoVenedido.Visible = False
    End Sub

    '////////////                                      FIN GANADO
    '/////////////////////////////////////////////////////////////////////////////////////////////


    '////////////////////////////////////////INICIO DE CCLIENTE//////////////////////////////////////////////////
    '//////////////////////////////////////////////////////////////////////////////////////////////////////////



    '////////////////////BOTON QUE ABRE PANEL DE AGREGAR CLIENTE  OCULTA PANEL PRINCIPAL/////////////////////////
    Private Sub BOTONagregarcliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONagregarcliente.Click
        DataGridViewClientes.Enabled = False

        BOTONguardarAgregarCliente.Visible = True
        BOTONcancelarGuardarCliente.Visible = True
        BOTONvaciarCamposCliente.Visible = True

        'BOTONguardarModificarCliente.Visible = False
        'BOTONcancelarModificarCliente.Visible = False

        BOTONagregarcliente.Enabled = False
        BOTONmodificarCliente.Enabled = False

        txtnombreCliente.Text = ""
        txtapellidoCliente.Text = ""
        txtcedulaCliente.Text = ""
        txttelefonoCliente.Text = ""
        txtdireccionCliente.Text = ""



        txtnombreCliente.Enabled = True
        txtnombreCliente.Focus()
        txtapellidoCliente.Enabled = True
        txtcedulaCliente.Enabled = True
        txttelefonoCliente.Enabled = True
        txtdireccionCliente.Enabled = True







    End Sub

    '//////////////////BOTON PARA ACTIVAR BOTONES MODIFICAR CLIENT//////////////////////////////////////////////////////////////////
    Private Sub BTNPanelmodificarcliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONmodificarCliente.Click
        DataGridViewMostraDatosClientes.Visible = False

        'BOTONguardarAgregarCliente.Visible = True
        'BOTONcancelarGuardarCliente.Visible = True
        'BOTONvaciarCamposCliente.Visible = True

        BOTONguardarModificarCliente.Visible = True
        BOTONcancelarModificarCliente.Visible = True

        BOTONagregarcliente.Enabled = False
        BOTONmodificarCliente.Enabled = False

        txtnombreCliente.Enabled = True
        txtnombreCliente.Focus()
        txtapellidoCliente.Enabled = True
        txtcedulaCliente.Enabled = False
        txttelefonoCliente.Enabled = True
        txtdireccionCliente.Enabled = True

    End Sub



    '////////////////////////////////////////////////////BOTON PARA ELIMINAR CLIENTE
    Private Sub BTNEliminarcliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONEliminarcliente.Click

        Dim MsgStyle As MsgBoxStyle = MsgBoxStyle.Critical + MsgBoxStyle.OkOnly
        Dim MsgStyle1 As MsgBoxStyle = MsgBoxStyle.Information + MsgBoxStyle.OkOnly
        Dim estado As String = DataGridViewClientes.Item(0, DataGridViewClientes.CurrentRow.Index).Value
        If MessageBox.Show("¿Seguro que desea eliminar a este cliente?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Try
                Consulta = " update cliente set estado = 0 where id='" & estado & "'"
                consultar()
                actualizarCliente()




                'Elimina el id de una compra juntos con todos los datos de ese id
                'Consulta = "delete from cliente where id='" & DataGridViewClientes.Item(0, DataGridViewClientes.CurrentRow.Index).Value & "'"
                'consultar()

                'Select Case error1

                '    Case 1
                '        MsgBox("no se pudo borrar", MsgStyle, Title:="Error")
                '    Case 0
                '        Consulta = "select * from cliente"
                '        consultar()
                '        'Actualiza la BD

                '        DataGridViewClientes.DataSource = Tabla

                '        MsgBox(" cliente eliminado", MsgStyle1, Title:="Eliminado")

                'End Select



            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub


    '///////////////////BOTON PARA SALIR DEL PANEL MODIFICAR Y REGRESAR AL PANEL PRINCIPAL////////////////////////////////////////
    Private Sub BOTONregrasarPrincipalCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONregrasarPrincipalCliente.Click
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


    '//////////////////////////////////////////// BOTON PARA VOLVER A CARGAR LOS DATOS DE CLIENTE/////////////////////////////////////////////////
    Private Sub BOTONcargarDatosclientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONcargarDatosclientes.Click
        GroupBoxcliente.Enabled = True
        actualizarCliente()
        DataGridViewMostraDatosClientes.Visible = False
        DataGridViewClientes.Visible = True

        txtBUSCARcedula.Clear()

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONclienteInactivo.Click
        DataGridViewMostraDatosClientes.Visible = False
        GroupBoxcliente.Enabled = False
        DataGridViewClientes.Visible = False
        DataGridclienteInactivos.Visible = True
        BOTONcancelarHabilitado.Visible = True
        BOTONaceptarHabilitado.Visible = True

        BOTONclienteInactivo.Enabled = False
        Try
            Consulta = " select * from cliente where estado = 0 "
            consultar()

            DataGridclienteInactivos.DataSource = Tabla

            DataGridclienteInactivos.Columns(0).HeaderText = "Cédula"
            DataGridclienteInactivos.Columns(1).HeaderText = "Nombre"
            DataGridclienteInactivos.Columns(2).HeaderText = "Apellido"
            DataGridclienteInactivos.Columns(3).HeaderText = "Dirección"
            DataGridclienteInactivos.Columns(4).HeaderText = "Teléfono"
            DataGridclienteInactivos.Columns(5).Visible = False

            If DataGridclienteInactivos.Rows.Count = 0 Then
                BOTONaceptarHabilitado.Enabled = False

            Else
                BOTONaceptarHabilitado.Enabled = True

            End If

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

    Private Sub BOTONaceptarHabilitado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONaceptarHabilitado.Click
        Dim MsgStyle As MsgBoxStyle = MsgBoxStyle.Critical + MsgBoxStyle.OkOnly
        Dim MsgStyle1 As MsgBoxStyle = MsgBoxStyle.Information + MsgBoxStyle.OkOnly
        Dim estado As String = DataGridclienteInactivos.Item(0, DataGridclienteInactivos.CurrentRow.Index).Value
        If MessageBox.Show("¿Seguro que desea al cliente seleccionado?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Try
                Consulta = " update cliente set estado = 1 where id='" & estado & "'"
                consultar()
                Consulta = " select * from cliente where estado = 0 "
                consultar()

                DataGridclienteInactivos.DataSource = Tabla

                DataGridclienteInactivos.Columns(0).HeaderText = "Cédula"
                DataGridclienteInactivos.Columns(1).HeaderText = "Nombre"
                DataGridclienteInactivos.Columns(2).HeaderText = "Apellido"
                DataGridclienteInactivos.Columns(3).HeaderText = "Dirección"
                DataGridclienteInactivos.Columns(4).HeaderText = "Teléfono"
                DataGridclienteInactivos.Columns(5).Visible = False

                actualizarCliente()

                If DataGridclienteInactivos.Rows.Count = 0 Then
                    BOTONaceptarHabilitado.Enabled = False

                Else
                    BOTONaceptarHabilitado.Enabled = True
                End If


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub BOTONcancelarHabilitado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONcancelarHabilitado.Click
        GroupBoxcliente.Enabled = True

        DataGridclienteInactivos.Visible = False
        DataGridViewClientes.Visible = True

        BOTONcancelarHabilitado.Visible = False
        BOTONaceptarHabilitado.Visible = False
        BOTONcargarDatosclientes.Enabled = True
        BOTONclienteInactivo.Enabled = True
    End Sub

    '/////////////////////////// ARREGLOS EN CLIENTE///////////////////////////////////////////////////////////////////////////////////////////
    Private Sub txtBUSCARcedula_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBUSCARcedula.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then


            'If IsNumeric(txtBuscarCodGanado.Text) Then


        Else
            e.Handled = True
        End If
    End Sub


    Private Sub txtBUSCARcedula_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBUSCARcedula.TextChanged
        BOTONguardarAgregarCliente.Visible = False
        BOTONcancelarGuardarCliente.Visible = False
        BOTONagregarcliente.Enabled = True
        BOTONmodificarCliente.Enabled = True


            Consulta = " SELECT * from cliente where id like '" & txtBUSCARcedula.Text & "%'"
            consultar()

            DataGridViewClientes.DataSource = Tabla

            '    Consulta = " SELECT * from cliente where id like '" & txtBUSCARcedula.Text & "%'"
       
    End Sub








    '' ''///////////////////////////////////BOTON PARA AGREGAR CLIENTE//////////////////////////////////////////////////
    ' ''Private Sub BTNAgregarclientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNAgregarclientes.Click
    ' ''    If Texcedula.Text <> "" And Texnombreapellido.Text <> "" And Texdireccion.Text <> "" And Texttelefono.Text <> "" Then
    ' ''        If verificarCedula(Texcedula.Text) Then

    ' ''            Consulta = "INSERT INTO cliente values('" & Texcedula.Text & "','" & Texnombreapellido.Text & "','" & Texdireccion.Text & "','" & Texttelefono.Text & "' )"
    ' ''            consultar()
    ' ''            Consulta = "select * from cliente"
    ' ''            consultar()
    ' ''            DataGridViewClientes.DataSource = Tabla
    ' ''            Texcedula.Text = ""
    ' ''            Texnombreapellido.Text = ""
    ' ''            Texdireccion.Text = ""
    ' ''            Texttelefono.Text = ""
    ' ''            MsgBox("Registro exitoso")
    ' ''        Else
    ' ''            MsgBox("Cedula erronea")
    ' ''        End If
    ' ''    Else
    ' ''        MsgBox("Complete todos los campos vacios")
    ' ''    End If
    ' ''End Sub
    ' ''/////////// BONTON DENTRO DEL PANEL DE AGREGAR CLIENTES(LIMPIA LOS TEXTBOX)//////////////////////
    ''Private Sub BTNClearclientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNClearclientes.Click
    ''    Texcedula.Clear()
    ''    Texdireccion.Clear()
    ''    Texnombreapellido.Clear()
    ''    Texttelefono.Clear()
    ''End Sub

    ''////////////////////////////BOTON QUE VUELVE AL PANEL PRINCIPAL///////////////////////////////////
    'Private Sub BTNVolveragregarcliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNVolveragregarcliente.Click
    '    PanelPrincipalclientes.BringToFront()
    '    PanelPrincipalclientes.Visible = True
    '    PanelPrincipalclientes.Enabled = True

    '    Consulta = "select * from cliente"
    '    consultar()
    '    DataGridViewClientes.DataSource = Tabla


    '    PanelAgregarcliente.Enabled = False
    '    PanelAgregarcliente.Visible = False
    '    PanelAgregarcliente.SendToBack()
    'End Sub


    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        PanelAgregarcliente.BringToFront()
        PanelAgregarcliente.Visible = True
        PanelAgregarcliente.Enabled = True

        PanelPrincipalclientes.SendToBack()
        PanelPrincipalclientes.Visible = False
        PanelPrincipalclientes.Enabled = False
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        PanelModificarclientes.BringToFront()
        PanelModificarclientes.Visible = True
        PanelModificarclientes.Enabled = True
        PanelPrincipalclientes.SendToBack()
        PanelPrincipalclientes.Visible = False
        PanelPrincipalclientes.Enabled = False
    End Sub

    Private Sub BOTONcancelarGuardarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONcancelarGuardarCliente.Click
        DataGridViewClientes.Enabled = True


        BOTONguardarAgregarCliente.Visible = False
        BOTONcancelarGuardarCliente.Visible = False
        BOTONvaciarCamposCliente.Visible = False

        BOTONguardarModificarCliente.Visible = False
        BOTONcancelarModificarCliente.Visible = False

        BOTONagregarcliente.Enabled = True
        BOTONmodificarCliente.Enabled = True


        txtnombreCliente.Text = ""
        txtapellidoCliente.Text = ""
        txtcedulaCliente.Text = ""
        txttelefonoCliente.Text = ""
        txtdireccionCliente.Text = ""


        DataGridViewClientes.Focus()

        txtcedulaCliente.Text = DataGridViewClientes.Item(0, DataGridViewClientes.CurrentRow.Index).Value
        txtnombreCliente.Text = DataGridViewClientes.Item(1, DataGridViewClientes.CurrentRow.Index).Value
        txtapellidoCliente.Text = DataGridViewClientes.Item(2, DataGridViewClientes.CurrentRow.Index).Value
        txtdireccionCliente.Text = DataGridViewClientes.Item(3, DataGridViewClientes.CurrentRow.Index).Value
        txttelefonoCliente.Text = DataGridViewClientes.Item(4, DataGridViewClientes.CurrentRow.Index).Value

        txtnombreCliente.Enabled = False
        txtapellidoCliente.Enabled = False
        txtcedulaCliente.Enabled = False
        txttelefonoCliente.Enabled = False
        txtdireccionCliente.Enabled = False

    End Sub
    ''//////////////// CODIGO QUE SOLO PERMITE INGRESO DE LETRAR EN TEXTBOX/////////////////////////
    Private Sub txtnombreCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnombreCliente.KeyPress

        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then


            'If IsNumeric(txtBuscarCodGanado.Text) Then


        Else
            e.Handled = True

        End If

    End Sub

    '////////////////// CODIGO QUE SOLO ADMITE LETRAS EN TEXTBOX DE APELLIDO///////////////
    Private Sub txtapellidoCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtapellidoCliente.KeyPress

        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then


            'If IsNumeric(txtBuscarCodGanado.Text) Then


        Else

            e.Handled = True

        End If

    End Sub
    Private Sub txttelefonoCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttelefonoCliente.KeyPress

        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
            'ElseIf Char.IsSeparator(e.KeyChar) Then
            '    e.Handled = True

            'If IsNumeric(txtBuscarCodGanado.Text) Then


        Else

            e.Handled = True

        End If
    End Sub
    Private Sub txtcedulaCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcedulaCliente.KeyPress


        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
            'ElseIf Char.IsSeparator(e.KeyChar) Then
            '    e.Handled = True

            'If IsNumeric(txtBuscarCodGanado.Text) Then


        Else

            e.Handled = True

        End If

    End Sub

    Private Sub BOTONguardarAgregarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONguardarAgregarCliente.Click
        Dim strid As String
        'Select Case error1
        '    Case 0

        'Consulta = " Sslect * from 
        If txtnombreCliente.Text <> "" And txtapellidoCliente.Text <> "" And txtcedulaCliente.Text <> "" And txtdireccionCliente.Text <> "" And txttelefonoCliente.Text <> "" Then
            If IsNumeric(txtcedulaCliente.Text) And IsNumeric(txttelefonoCliente.Text) Then
                'If Not IsNumeric(txtnombreCliente.Text) And Not IsNumeric(txtapellidoCliente.Text) Then


                strid = txtcedulaCliente.ToString

                Consulta = "select * from cliente where id='" + txtcedulaCliente.Text + "'"
                consultar()

                If Tabla.Rows.Count > 0 Then
                    For Each row As DataRow In Tabla.Rows
                        strid = row("id").ToString
                        MsgBox("LA cedula existe")
                    Next

                Else

                    If verificarCedula(txtcedulaCliente.Text) Then
                        Try

                            Consulta = "INSERT INTO cliente(id,nombre,apellido,direccion,telefono) values('" & txtcedulaCliente.Text & "','" & txtnombreCliente.Text & "','" & txtapellidoCliente.Text & "','" & txtdireccionCliente.Text & "','" & txttelefonoCliente.Text & "')"
                            consultar()




                            Consulta = "select * from cliente"
                            consultar()
                            DataGridViewClientes.DataSource = Tabla




                            txtnombreCliente.Text = ""
                            txtapellidoCliente.Text = ""
                            txtcedulaCliente.Text = ""
                            txtdireccionCliente.Text = ""
                            txttelefonoCliente.Text = ""
                            DataGridViewMostraDatosClientes.Visible = False
                            DataGridViewClientes.Visible = True

                            MsgBox("Registro exitoso")

                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    Else
                        MsgBox("Cedula erronea")
                    End If

                End If




                'Else
                '    MsgBox("Nombre y Apellido no pueden contener datos numericos")

                'End If
            Else

                MsgBox("Cedula y telefono son numericos")

            End If
        Else
            MsgBox("Complete todos los campos vacios")
        End If

        '    Case 1
        'MsgBox("esa cedula,ya existe")
        'End Select
    End Sub


    '///////////////////////////BOTON QUE VUELVE AL PANEL PRINCIPAL///////////////////////////////////
    Private Sub BTNVolveragregarcliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNVolveragregarcliente.Click
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

    Private Sub BOTONcancelarModificarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONcancelarModificarCliente.Click


        'BOTONguardarAgregarCliente.Visible = True
        'BOTONcancelarGuardarCliente.Visible = True
        'BOTONvaciarCamposCliente.Visible = True

        BOTONguardarModificarCliente.Visible = False
        BOTONcancelarModificarCliente.Visible = False

        BOTONagregarcliente.Enabled = True
        BOTONmodificarCliente.Enabled = True

        txtnombreCliente.Text = ""
        txtapellidoCliente.Text = ""
        txtcedulaCliente.Text = ""
        txttelefonoCliente.Text = ""
        txtdireccionCliente.Text = ""

        DataGridViewClientes.Focus()

        txtcedulaCliente.Text = DataGridViewClientes.Item(0, DataGridViewClientes.CurrentRow.Index).Value
        txtnombreCliente.Text = DataGridViewClientes.Item(1, DataGridViewClientes.CurrentRow.Index).Value
        txtapellidoCliente.Text = DataGridViewClientes.Item(2, DataGridViewClientes.CurrentRow.Index).Value
        txtdireccionCliente.Text = DataGridViewClientes.Item(3, DataGridViewClientes.CurrentRow.Index).Value
        txttelefonoCliente.Text = DataGridViewClientes.Item(4, DataGridViewClientes.CurrentRow.Index).Value

        txtnombreCliente.Enabled = False
        txtnombreCliente.Focus()
        txtapellidoCliente.Enabled = False
        txtcedulaCliente.Enabled = False
        txttelefonoCliente.Enabled = False
        txtdireccionCliente.Enabled = False

    End Sub

    Private Sub BOTONguardarModificarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONguardarModificarCliente.Click

        Dim cedula As String = DataGridViewClientes.Item(0, DataGridViewClientes.CurrentRow.Index).Value
        If txtnombreCliente.Text <> "" And txtapellidoCliente.Text <> "" And txtdireccionCliente.Text <> "" And txttelefonoCliente.Text <> "" Then


            'If IsNumeric(txttelefonoCliente.Text) Then
            '    If Not IsNumeric(txtnombreCliente.Text) Then
            '        If Not IsNumeric(txtapellidoCliente.Text) Then


            Consulta = "update cliente set nombre='" + txtnombreCliente.Text +
                "', apellido='" + txtapellidoCliente.Text +
                "', direccion='" + txtdireccionCliente.Text +
                "', telefono = '" + txttelefonoCliente.Text +
                "' where id='" + cedula + "'"
            consultar()
            actualizarCliente()
            MsgBox(" Se editaron datos")

        Else
            '    MsgBox("El apellido no puede contener datos numericos")
            'End If
            '        Else

            'MsgBox("El nombre no puede conter datos numericos")

            '        End If

            'MsgBox("Telefono es un datos de tipo numerico")
            '    End If

            'Else

            MsgBox("Todos los campos deben tener un contenido")

        End If
    End Sub



    Private Sub DataGridViewClientes_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewClientes.SelectionChanged
        Try

            txtcedulaCliente.Text = ""
            txtnombreCliente.Text = ""
            txtapellidoCliente.Text = ""
            txtdireccionCliente.Text = ""
            txttelefonoCliente.Text = ""

            txtcedulaCliente.Text = DataGridViewClientes.Item(0, DataGridViewClientes.CurrentRow.Index).Value
            txtnombreCliente.Text = DataGridViewClientes.Item(1, DataGridViewClientes.CurrentRow.Index).Value
            txtapellidoCliente.Text = DataGridViewClientes.Item(2, DataGridViewClientes.CurrentRow.Index).Value
            txtdireccionCliente.Text = DataGridViewClientes.Item(3, DataGridViewClientes.CurrentRow.Index).Value
            txttelefonoCliente.Text = DataGridViewClientes.Item(4, DataGridViewClientes.CurrentRow.Index).Value

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub




    Private Sub BOTONvaciarCamposCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONvaciarCamposCliente.Click
        txtcedulaCliente.Text = ""
        txtnombreCliente.Text = ""
        txtapellidoCliente.Text = ""
        txtdireccionCliente.Text = ""
        txttelefonoCliente.Text = ""

    End Sub

    Private Sub DataGridclienteInactivos_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridclienteInactivos.MouseEnter
        'If DataGridclienteInactivos.Rows.Count = 0 Then
        '    BOTONaceptarHabilitado.Enabled = False

        'Else

        '    BOTONaceptarHabilitado.Enabled = True

        'End If
    End Sub

    Private Sub BOTONaceptarHabilitado_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONaceptarHabilitado.MouseEnter
        'If DataGridclienteInactivos.Rows.Count = 0 Then
        '    BOTONaceptarHabilitado.Enabled = False

        'Else

        '    BOTONaceptarHabilitado.Enabled = True

        'End If
    End Sub
    '////////////////////////////////FIN DE ARREGLOS CLIENTES///////////////////////////////////////////////
    '///////////////////////////////////////////////  FIN DE CLIENTEEEEEE ////////////////////////////////////////////////////////////////////


    '///////////////////////////////////////COMPRAS//////////////////////////////////////////////
    '////////////////////////////////////////////////////////////////////////////////////////////
    '/////////////////////////////////////////////////////////////////////////////////////////////
    '/////////////////////////////////////////////////////////////////////////////////////////////
    'boton que sale del panel de agregar compras y muestra panel principal
    Private Sub BTNVolverdeagregarcompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNVolverdeagregarcompra.Click
        'Muestra panel pricipal de compras
        PNLPrincipalcompra.Enabled = True
        PNLPrincipalcompra.Visible = True
        PNLPrincipalcompra.BringToFront()


        'Oculta panel de agregar compras
        PNLAgregarcompras.SendToBack()
        PNLAgregarcompras.Visible = False
        PNLAgregarcompras.Enabled = False



        PNLAgregarcompraproducto.Visible = False
        PNLAgregarcompraproducto.Enabled = False
        PNLAgregarcompraproducto.SendToBack()

        PNLAgregarcompraganado.Visible = False
        PNLAgregarcompraganado.Enabled = False
        PNLAgregarcompraganado.SendToBack()

        Consulta = "select * from compra"
        consultar()
        DGVCompras.DataSource = Tabla
    End Sub
    Private Sub BTNCancelarcompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCancelarcompra.Click
        CBXAgregarcompra.Enabled = True
        BTNVolverdeagregarcompra.Enabled = True
        DGVGanadocompra.Rows.Clear()
        DataGridView2.Rows.Clear()
        PNLGanadocompra.Visible = True
        PNLGanadocompra.BringToFront()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox4.Clear()
        TextBox3.Clear()
        TXTTotalapagarcompraganado.Clear()
        CBXAgregarcompra.Text = ""
        acumulador = 0
        DTPFechanacimientocompra.Value = Today
    End Sub
    '/////////////////////////Boton de para entrar al panel de agregar compras
    Private Sub BTNpanelmodicompras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNPanelagregarcompra.Click
        'Muestra el panel de agregar compras
        PNLAgregarcompras.BringToFront()
        PNLAgregarcompras.Visible = True
        PNLAgregarcompras.Enabled = True
        CBXAgregarcompra.Text = "Elige una opción"
        'Oculta el panel principal de compras
        PNLPrincipalcompra.SendToBack()
        PNLPrincipalcompra.Enabled = False
        PNLPrincipalcompra.Visible = False

        'Deja los textbox richtbox vacios, y los dtp con la fecha actual
        RTXComentariocompraganado.Clear()
        TXTTotalapagarcompraganado.Clear()
        DTPFechacompraganado.Value = Today


        DTPFechanacimientocompra.Value = Today

        RTXComentariocompraproducto.Clear()
        TXTTotalpagadocomprasproducto.Clear()
        DTPFechacompraproducto.Value = Today
    End Sub
    Private Sub BTNEstadisticascompras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNEstadisticascompras.Click
        PNLEstadisticascompras.Visible = True
    End Sub
    Private Sub DGVCompras_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGVCompras.MouseEnter
        PNLEstadisticascompras.Visible = False
    End Sub
    Private Sub PNLPrincipalcompra_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PNLPrincipalcompra.MouseEnter
        PNLEstadisticascompras.Visible = False
    End Sub
    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNUltimafechacompra.Click
        Consulta = "select * from compra where fechacompra = (select max(fechacompra) from compra)"
        consultar()
        DGVCompras.DataSource = Tabla
        DGVCompras.Columns(0).HeaderText = "Id"
        DGVCompras.Columns(1).HeaderText = "Fecha de Compra"
        DGVCompras.Columns(2).HeaderText = "Comentario"
        DGVCompras.Columns(3).HeaderText = "Total"
    End Sub
    Private Sub Button1_Click_3(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Consulta = ("select sum(totalc) from compra where year(fechacompra) = year(now())")
        consultar()
        DGVCompras.DataSource = Tabla
        DGVCompras.Columns(0).HeaderText = "Total que se gastó en el año"

    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Consulta = "select * from compra where idc = any (select idc from ganado)"
        consultar()
        DGVCompras.DataSource = Tabla
    End Sub
    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Consulta = "select * from compra where idc not in (select idc from ganado)"
        consultar()
        DGVCompras.DataSource = Tabla
    End Sub

    Private Sub BTNActualizarcompras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNActualizarcompras.Click
        Consulta = ("select * from compra")
        consultar()
        DGVCompras.DataSource = Tabla
        DGVCompras.Columns(0).HeaderText = "Id"
        DGVCompras.Columns(1).HeaderText = "Fecha de Compra"
        DGVCompras.Columns(2).HeaderText = "Comentario"
        DGVCompras.Columns(3).HeaderText = "Total"
    End Sub

    Dim acumulador As Double
    Private Sub BTNAgregarganadocompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNAgregarganadocompra.Click
        Dim sexo As String = CBXSexocompra.SelectedItem
        Dim raza As String = CBXRazacompra.SelectedItem
        Dim fecha As String = DTPFechanacimientocompra.Value.ToString("yyyy-MM-dd")

        

            If fecha <> "" And sexo <> "" And raza <> "" Then
            If IsNumeric(TextBox1.Text) And IsNumeric(TextBox2.Text) And TextBox1.Text <> "" And TextBox2.Text <> "" Then

                TextBox3.Text = Convert.ToDouble(TextBox1.Text.ToString.Replace(".", ",")) * Convert.ToDouble(TextBox2.Text.ToString.Replace(".", ","))
                acumulador = (acumulador + (Convert.ToDouble(TextBox1.Text.ToString.Replace(".", ",")) * Convert.ToDouble(TextBox2.Text.ToString.Replace(".", ","))))
                TextBox4.Text = acumulador
                If DTPFechanacimientocompra.Value > Today Then
                    MsgBox("La fecha de nacimiento no puede ser mayor a la fecha actual")
                Else


                    DGVGanadocompra.Rows.Add(raza, sexo, fecha, TextBox3.Text)

                    DTPFechanacimientocompra.Value = Today
                    CBXRazacompra.Text = ""
                    CBXSexocompra.Text = ""
                    TextBox1.Clear()
                    TextBox3.Clear()
                    CBXAgregarcompra.Enabled = False
                    BTNVolverdeagregarcompra.Enabled = False
                    BTNavanzarcompra.Enabled = True
                    BTNCancelarcompra.Visible = True

                End If
            Else
                MsgBox("Ingrese solo valor numérico en Kg y en U$S")

            End If


        Else
            MsgBox("Complete todos los campos vacios")
        End If

    End Sub
    'Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
    '    If Char.IsNumber(e.KeyChar) Then
    '        e.Handled = False
    '    ElseIf Char.IsControl(e.KeyChar) Then
    '        e.Handled = False
    '    Else

    '        e.Handled = True

    '    End If
    'End Sub

    'Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
    '    If Char.IsNumber(e.KeyChar) Then
    '        e.Handled = False
    '    ElseIf Char.IsControl(e.KeyChar) Then
    '        e.Handled = False
    '    Else

    '        e.Handled = True

    '    End If
    'End Sub
    Private Sub BTNEliminarganadocompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNEliminarganadocompra.Click

        If DGVGanadocompra.Rows.Count > 0 Then
            acumulador = (acumulador - (Convert.ToDouble(DGVGanadocompra.CurrentRow.Cells(3).Value).ToString.Replace(".", ",")))
            DGVGanadocompra.Rows.Remove(DGVGanadocompra.CurrentRow)
            TextBox4.Text = acumulador
            If DGVGanadocompra.Rows.Count < 1 Then
                acumulador = 0
                TextBox4.Text = acumulador
            End If
        Else
            MsgBox("No hay ganado para eliminar")
        End If

    End Sub
    Private Sub BTNavanzarcompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNavanzarcompra.Click
        If DGVGanadocompra.Rows.Count < 1 Then
            MsgBox("Por favor, ingrese ganado para continuar")
        Else

            PNLGanadocompra.Visible = False
            TXTTotalapagarcompraganado.Text = acumulador
        End If
    End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            TextBox6.Visible = True
            TextBox5.Visible = True
            Label22.Visible = True
            Label23.Visible = True
            TXTTotalpagadocomprasproducto.Enabled = False
        Else
            TextBox6.Visible = False
            TextBox5.Visible = False
            Label22.Visible = False
            Label23.Visible = False
            TXTTotalpagadocomprasproducto.Enabled = True
        End If
    End Sub

    Private Sub BTNAgregarcompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNAgregarcompraproducto.Click

        Dim fechacompra As String = DTPFechacompraproducto.Value.ToString("yyyy-MM-dd")
        Dim totalcompra As String = TXTTotalpagadocomprasproducto.Text
        If fechacompra <> "" And RTXComentariocompraproducto.Text <> "" Then

            If CheckBox1.Checked Then
                If DTPFechacompraproducto.Value > Today Then
                    MsgBox("La fecha de compra no puede ser mayor a la fecha actual")
                    'Sino, guarda los datos mientras se cumplan los demas requisitos
                Else
                    If TextBox5.Text <> "" And TextBox6.Text <> "" Then
                        TXTTotalpagadocomprasproducto.Text = Convert.ToDouble(TextBox6.Text.ToString.Replace(".", ",")) * Convert.ToDouble(TextBox5.Text.ToString.Replace(".", ","))
                        Consulta = "insert into compra values (0,'" & fechacompra & "','" & RTXComentariocompraproducto.Text & "','" & Round(Convert.ToDouble(totalcompra), 2).ToString.Replace(",", ".") & "')"
                        consultar()

                        Consulta = ("update compra set comentarioc = concat(upper(left(comentarioc,1)), right(comentarioc,length(comentarioc)-1))")
                        consultar()

                        Consulta = "select * from compra"
                        consultar()

                        'Actualiza la BD
                        DGVCompras.DataSource = Tabla

                        'Deja a los textbox vacios para ingresar nuevos datos
                        RTXComentariocompraproducto.Text = ""
                        TXTTotalpagadocomprasproducto.Text = ""
                        TextBox5.Text = ""
                        TextBox6.Text = ""

                        MsgBox("Se han agregado los datos correctamente")
                    Else
                        MsgBox("Ingrese valores numericos en Pesos Uruguayos y en Dólar")
                    End If
                End If

            ElseIf fechacompra <> "" And RTXComentariocompraproducto.Text <> "" And TXTTotalpagadocomprasproducto.Text <> "" Then

                'Si la fecha de compra es mayor que la fecha actual salta el msgbox
                If DTPFechacompraproducto.Value > Today Then
                    MsgBox("La fecha de compra no puede ser mayor a la fecha actual")
                    'Sino, guarda los datos mientras se cumplan los demas requisitos
                Else

                    If IsNumeric(TXTTotalpagadocomprasproducto.Text) Then
                        'Agrega los valores de los campos a cada tabla correspondiente
                        Consulta = "insert into compra values (0,'" & fechacompra & "','" & RTXComentariocompraproducto.Text & "','" & Round(Convert.ToDouble(totalcompra), 2).ToString.Replace(",", ".") & "')"
                        consultar()

                        Consulta = ("update compra set comentarioc = concat(upper(left(comentarioc,1)), right(comentarioc,length(comentarioc)-1))")
                        consultar()
                        Consulta = "select * from compra"
                        consultar()

                        'Actualiza la BD
                        DGVCompras.DataSource = Tabla

                        'Deja a los textbox vacios para ingresar nuevos datos
                        RTXComentariocompraproducto.Text = ""
                        TXTTotalpagadocomprasproducto.Text = ""
                        TextBox5.Text = ""
                        TextBox6.Text = ""

                        MsgBox("Se han agregado los datos correctamente")
                    Else
                        'Muestra mensaje diciendo que no se ingresaron valores numericos o que solo acepta valores numericos
                        MsgBox("Igrese solo valor numerico en total")
                    End If
                End If
            End If
        Else
            MsgBox("Complete los campos vacios")
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
        PNLModificarcompras.BringToFront()
        PNLModificarcompras.Visible = True
        PNLModificarcompras.Enabled = True

        'Actualiza datagrid de panel modificar compras
        Consulta = "select * from compra"
        consultar()
        DTGModificarcompra.DataSource = Tabla
        'Cambia los headers
        DTGModificarcompra.Columns(0).HeaderText = "Id"
        DTGModificarcompra.Columns(1).HeaderText = "Fecha de Compra"
        DTGModificarcompra.Columns(2).HeaderText = "Comentario"
        DTGModificarcompra.Columns(3).HeaderText = "Total Pagado"
        CBXModificarcompra.Text = "Id"
        'Oculta panel principal compras
        PNLPrincipalcompra.SendToBack()
        PNLPrincipalcompra.Visible = False
        PNLPrincipalcompra.Enabled = False

        'deja los richtbox y los textbox vacios, y los datatimerpick con la fecha actual
        RTXModicomentariocompra.Clear()
        TXTModitotalapagarcompra.Clear()
        DTPModifechacompra.Value = Today
    End Sub
    Private Sub BTNBuscarcompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBuscarcompra.Click
        DGVUsuarios.DataSource = Nothing
        Dim fecha As String = DTPBuscarcompra.Value.ToString("yyyy-MM-dd")
        Try
            If CBXBuscarcompra.Text = "Id" And TXTBuscarcompra.Text = "" Then
                Consulta = ("select * from compra")
                consultar()
                DGVCompras.DataSource = Tabla
            ElseIf CBXBuscarcompra.Text = "Elige una opción" Then
                Consulta = ("select * from compra")
                consultar()
                DGVCompras.DataSource = Tabla
            Else

                If CBXBuscarcompra.Text = "Id" Then
                    If IsNumeric(TXTBuscarcompra.Text) Then
                        Consulta = ("select idc,fechacompra,comentarioc,totalc from compra where idc ='" + TXTBuscarcompra.Text + "'")
                        consultar()
                        DGVCompras.DataSource = Tabla

                        DGVCompras.Focus()
                    Else
                        MsgBox("El id tiene que ser valor númerico")
                    End If

                Else : CBXBuscarcompra.Text = "Fecha de Compra"
                    Consulta = ("select idc,fechacompra,comentarioc,totalc from compra where fechacompra ='" + fecha + "'")
                    consultar()
                    DGVCompras.DataSource = Tabla
                    DGVCompras.Focus()


                End If
            End If
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub
    Private Sub BTNRetrocederGanadocompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNRetrocederGanadocompra.Click
        PNLGanadocompra.BringToFront()
        PNLGanadocompra.Visible = True
    End Sub
    Private Sub BTNAgregarcomraganado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNAgregarcomraganado.Click
        If DataGridViewganado.Rows.Count = 0 Then
            Consulta = " alter table ganado auto_increment = 1001 "
            consultar()
        End If
        If DGVCompras.Rows.Count = 0 Then
            Consulta = " alter table compra auto_increment = 2001 "
            consultar()
        End If

        Dim fechacompra As String = DTPFechacompraganado.Value.ToString("yyyy-MM-dd")
        Dim fechanac As String = DTPFechanacimientocompra.Value.ToString("yyyy-MM-dd")
        Dim totalcompra As String = TXTTotalapagarcompraganado.Text



        If fechacompra <> "" And RTXComentariocompraganado.Text <> "" And TXTTotalapagarcompraganado.Text Then

            'Si la fecha de compra es mayor a la actual salta el msgbox
            If DTPFechacompraganado.Value > Today Then
                MsgBox("La fecha de compra no puede ser mayor a la fecha actual")
            Else

                If IsNumeric(TXTTotalapagarcompraganado.Text) Then
                    'Agrega los valores de los campos a cada tabla correspondiente
                    Consulta = "insert into compra values (0,'" & fechacompra & "','" & RTXComentariocompraganado.Text & "','" & Round(Convert.ToDouble(totalcompra), 2).ToString.Replace(",", ".") & "')"
                    consultar()

                    Consulta = "select idc from compra where idc = (select max(idc) from compra)"
                    consultar()
                    DataGridView2.DataSource = Tabla

                    'Pone la primera letra de comentario en mayuscula
                    Consulta = ("update compra set comentarioc = concat(upper(left(comentarioc,1)), right(comentarioc,length(comentarioc)-1))")
                    consultar()

                    For row As Integer = 0 To DGVGanadocompra.Rows.Count - 1
                        Consulta = "insert into ganado(sexo, raza, nacimiento, estado, precioc, idc) values ('" & DGVGanadocompra.Rows(row).Cells(1).Value & "','" & DGVGanadocompra.Rows(row).Cells(0).Value & "','" & DGVGanadocompra.Rows(row).Cells(2).Value & "','Activo','" & Round(Convert.ToDouble(DGVGanadocompra.Rows(row).Cells(3).Value), 2).ToString.Replace(",", ".") & "','" & (DataGridView2.CurrentRow.Cells(0).Value) & "')"
                        consultar()
                    Next

                    'Actualiza la BD
                    Consulta = "select * from compra"
                    consultar()
                    DGVCompras.DataSource = Tabla

                    'Deja a los textbox vacios para ingresar nuevos datos
                    DTPFechacompraganado.Value = Today
                    RTXComentariocompraganado.Text = ""
                    TXTTotalapagarcompraganado.Text = ""


                    DTPFechanacimientocompra.Value = Today
                    MsgBox("Los datos se ingresaron correctamente")
                    CBXAgregarcompra.Enabled = True
                    BTNVolverdeagregarcompra.Enabled = True
                    DGVGanadocompra.Rows.Clear()
                    PNLGanadocompra.Visible = True
                    PNLGanadocompra.BringToFront()
                    TextBox1.Clear()
                    TextBox2.Clear()
                    TextBox4.Clear()
                    TextBox3.Clear()
                    TXTTotalapagarcompraganado.Clear()
                    CBXAgregarcompra.Text = ""
                    acumulador = 0
                    DataGridView2.Rows.Remove(DataGridView2.CurrentRow)
                Else
                    'Muestra mensaje diciendo que no se ingresaron valores numericos o que solo acepta valores numericos
                    MsgBox("Ingrese solo valor numerico en total")
                End If
            End If
        Else
            'Muestra mensaje que todos los campos no estan completos
            MsgBox("Complete todos los campos vacios")

        End If
    End Sub
    Private Sub BTNLimpiarcompraganado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNLimpiarcompraganado.Click
        RTXComentariocompraganado.Clear()
        DTPFechacompraganado.Value = Today
    End Sub




    Private Sub Agregarmodificarcompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNAgregarmodificacion.Click
        Dim fechacompra As String = DTPModifechacompra.Value.ToString("yyyy-MM-dd")

        If MessageBox.Show("¿Seguro que desea modificar ?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then



            If IsNumeric(TXTModitotalapagarcompra.Text) Then

                Consulta = ("update compra set idc ='" & DTGModificarcompra.Item(0, DTGModificarcompra.CurrentRow.Index).Value & "', fechacompra='" & fechacompra & "', comentarioc='" & RTXModicomentariocompra.Text & "', totalc='" & TXTModitotalapagarcompra.Text & "' where idc= '" & DTGModificarcompra.Item(0, DTGModificarcompra.CurrentRow.Index).Value & "'")
                consultar()

                Consulta = ("update compra set comentarioc = concat(upper(left(comentarioc,1)), right(comentarioc,length(comentarioc)-1))")
                consultar()

                Consulta = ("select * from compra")
                consultar()

                DTGModificarcompra.DataSource = Tabla
                DTGModificarcompra.Columns(0).HeaderText = "Id"
                DTGModificarcompra.Columns(1).HeaderText = "Fecha de Compra"
                DTGModificarcompra.Columns(2).HeaderText = "Comentario"
                DTGModificarcompra.Columns(3).HeaderText = "Total"
                MsgBox("La compra se modificó con exito")

            Else
                MsgBox("Ingrese solo valor numerico en total")
            End If

        End If



    End Sub

    Private Sub TXTBuscarmodificarcompra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBuscarmodificarcompra.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
            'ElseIf Char.IsSeparator(e.KeyChar) Then
            '    e.Handled = True

            'If IsNumeric(txtBuscarCodGanado.Text) Then


        Else

            e.Handled = True

        End If
    End Sub
    '//////////////textbox para buscar id en modificar compra
    Private Sub TXTBuscarmodificarcompra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTBuscarmodificarcompra.TextChanged
        'Actualiza en vivo buscando en el datagrid lo que se escribe en el textbox
        Consulta = ("select * from compra where idc like '" & TXTBuscarmodificarcompra.Text & "%'")
        consultar()
        'Actualiza el datagrid
        DTGModificarcompra.DataSource = Tabla
    End Sub
    Private Sub BTNsalirmodicompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNsalirmodicompra.Click
        'Oculta el panel de modificar compra
        PNLModificarcompras.Enabled = False
        PNLModificarcompras.Visible = False
        PNLModificarcompras.SendToBack()

        'Muestra el panel principal de compra
        PNLPrincipalcompra.Enabled = True
        PNLPrincipalcompra.Visible = True
        PNLPrincipalcompra.BringToFront()

        'Actualiza el datagrid del panel principal de compras
        Consulta = "select * from compra"
        consultar()
        DGVCompras.DataSource = Tabla
        'Cambia los headers de las tablas
        DGVCompras.Columns(0).HeaderText = "Id"
        DGVCompras.Columns(1).HeaderText = "Fecha de Compra"
        DGVCompras.Columns(2).HeaderText = "Comentario"
        DGVCompras.Columns(3).HeaderText = "Total Pagado"
    End Sub
    '///////////Datagridview del panel de modificarcompra
    Private Sub DTGmodificarcompra_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTGModificarcompra.SelectionChanged
        'Cuando se selecciona otra fila del data grid deja los textbox, richtextbox vacios para mostrar los nuevos datos
        RTXModicomentariocompra.Clear()
        TXTModitotalapagarcompra.Clear()



        'Cada vez que se selecciona un item del datagrid, muestra los datos en los textbox,datatimerpick,richtextbox
        DTPModifechacompra.Value = DTGModificarcompra.Item(1, DTGModificarcompra.CurrentRow.Index).Value
        RTXModicomentariocompra.Text = DTGModificarcompra.Item(2, DTGModificarcompra.CurrentRow.Index).Value
        TXTModitotalapagarcompra.Text = DTGModificarcompra.Item(3, DTGModificarcompra.CurrentRow.Index).Value
    End Sub
    '////boton para limpiar los campos en moidicar compra
    Private Sub BTNlimpiarmodicompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNlimpiarmodicompra.Click
        'Deja vacio el campo de comentario
        RTXModicomentariocompra.Clear()
        'Deja vacio el campo de Total a pagar
        TXTModitotalapagarcompra.Clear()
        DTPModifechacompra.Value = Today
    End Sub
    '/////////////////combobox de agregar compras, para seleccionar producto o ganado
    Private Sub CBXAgregarcompra_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBXAgregarcompra.SelectedIndexChanged
        If CBXAgregarcompra.Text = "Ganado" Then
            PNLAgregarcompraganado.Visible = True
            PNLAgregarcompraganado.Enabled = True
            PNLAgregarcompraganado.BringToFront()

            PNLAgregarcompraproducto.Visible = False
            PNLAgregarcompraproducto.Enabled = False
            PNLAgregarcompraproducto.SendToBack()
            PNLGanadocompra.BringToFront()

        ElseIf CBXAgregarcompra.Text = "Productos" Then
            PNLAgregarcompraproducto.Visible = True
            PNLAgregarcompraproducto.Enabled = True
            PNLAgregarcompraproducto.BringToFront()

            PNLAgregarcompraganado.Visible = False
            PNLAgregarcompraganado.Enabled = False
            PNLAgregarcompraganado.SendToBack()
            BTNCancelarcompra.Visible = False
        Else
            PNLAgregarcompraproducto.Visible = False
            PNLAgregarcompraproducto.Enabled = False
            PNLAgregarcompraproducto.SendToBack()

            PNLAgregarcompraganado.Visible = False
            PNLAgregarcompraganado.Enabled = False
            PNLAgregarcompraganado.SendToBack()
            BTNCancelarcompra.Visible = False
        End If
    End Sub
    'Private Sub TXTModitotalapagarcompra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTModitotalapagarcompra.KeyPress
    '    If Char.IsNumber(e.KeyChar) Then
    '        e.Handled = False
    '    ElseIf Char.IsControl(e.KeyChar) Then
    '        e.Handled = False
    '        'ElseIf Char.IsSeparator(e.KeyChar) Then
    '        '    e.Handled = True

    '        'If IsNumeric(txtBuscarCodGanado.Text) Then


    '    Else

    '        e.Handled = True

    '    End If
    'End Sub

    Private Sub TXTBuscarcompra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBuscarcompra.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
            'ElseIf Char.IsSeparator(e.KeyChar) Then
            '    e.Handled = True

            'If IsNumeric(txtBuscarCodGanado.Text) Then


        Else

            e.Handled = True

        End If
    End Sub
    '//////Boton que elimina el ganado/////////
    'Private Sub BTNEliminarCompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNEliminarCompra.Click
    '    Dim MsgStyle As MsgBoxStyle = MsgBoxStyle.Critical + MsgBoxStyle.OkOnly
    '    Dim MsgStyle1 As MsgBoxStyle = MsgBoxStyle.Information + MsgBoxStyle.OkOnly

    '    If MessageBox.Show("¿Seguro que desea eliminar ésta compra?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '        Try
    '            'Elimina el id de una compra juntos con todos los datos de ese id
    '            Consulta = "delete from compra where idc='" & DGVCompras.Item(0, DGVCompras.CurrentRow.Index).Value & "'"
    '            consultar()

    '            Select Case error1

    '                Case 1
    '                    MsgBox("No se pudo eliminar la compra", MsgStyle, Title:="Error")
    '                Case 0
    '                    Consulta = "select * from compra"
    '                    consultar()
    '                    'Actualiza la BD

    '                    DGVCompras.DataSource = Tabla

    '                    MsgBox("Compra eliminada", MsgStyle1, Title:="Eliminado")

    '            End Select

    '        Catch ex As Exception
    '            MsgBox(ex)
    '        End Try
    '    End If
    'End Sub

    Private Sub TXTBuscarcompra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTBuscarcompra.TextChanged
        Consulta = "select * from compra where idc like '" & TXTBuscarcompra.Text & "%'"
        consultar()
        DGVCompras.DataSource = Tabla
    End Sub
    '///////////////Boton buscar en modificacion de compra
    Private Sub BTNBuscarmodificacioncompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBuscarmodificacioncompra.Click
        Dim fecha As String = DTPBuscarmodificarcompra.Value.ToString("yyyy-MM-dd")
        Try
            If CBXModificarcompra.Text = "Id" And TXTBuscarmodificarcompra.Text = "" Then
                Consulta = ("select * from compra")
                consultar()
                DTGModificarcompra.DataSource = Tabla
            ElseIf CBXModificarcompra.Text = "Elige una opción" Then
                Consulta = ("select * from compra")
                consultar()
                DTGModificarcompra.DataSource = Tabla
            Else

                If CBXModificarcompra.Text = "Id" Then
                    If IsNumeric(TXTBuscarmodificarcompra.Text) Then
                        Consulta = ("select idc,fechacompra,comentarioc,totalc from compra where idc ='" + TXTBuscarmodificarcompra.Text + "'")
                        consultar()
                        DTGModificarcompra.DataSource = Tabla
                        DGVCompras.Focus()
                    Else
                        MsgBox("El id tiene que ser un valor númerico")
                    End If
                Else : CBXBuscarcompra.Text = "Fecha de Compra"
                    Consulta = ("select idc,fechacompra,comentarioc,totalc from compra where fechacompra ='" + fecha + "'")
                    consultar()
                    DTGModificarcompra.DataSource = Tabla
                    DTGModificarcompra.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex)
        End Try

    End Sub
    '/////combobox del panel principal de compras
    Private Sub CBXBuscarcompra_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBXBuscarcompra.SelectedIndexChanged
        'Si el combo box esta en elige una opcion, oculta el datatimerpick y el textbox
        If CBXBuscarcompra.Text = "Elige una opción" Then
            'Cuando se encuentra en elige una opcion actualiza la base de datos
            Consulta = ("select * from compra")
            consultar()
            DGVCompras.DataSource = Tabla
            DTPBuscarcompra.Visible = False
            TXTBuscarcompra.Visible = False
            'Muesta el datatimerpick y oculta el textbox
        ElseIf CBXBuscarcompra.Text = "Fecha de Compra" Then
            DTPBuscarcompra.Visible = True
            TXTBuscarcompra.Visible = False
            'Pone el datatimerpick en la fecha actual
            DTPBuscarcompra.Value = Today
            'Sino muestra el textbox y oculta el datatimerpick
        Else
            Consulta = ("select * from compra")
            consultar()
            DGVCompras.DataSource = Tabla
            DTPBuscarcompra.Visible = False
            TXTBuscarcompra.Visible = True
        End If
    End Sub
    '////combobox de modificar compra////
    Private Sub CBXModificarcompra_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBXModificarcompra.SelectedIndexChanged
        'Si el combo box esta en elige una opcion, oculta el datatimerpick y el textbox
        If CBXModificarcompra.Text = "Elige una opción" Then
            'Cuando se encuentra en elige una opcion actualiza la base de datos
            Consulta = ("select * from compra")
            consultar()
            DTGModificarcompra.DataSource = Tabla
            DTPBuscarmodificarcompra.Visible = False
            TXTBuscarmodificarcompra.Visible = False
            'Si el combobox esta en id, oculta el datatimerpick y muestra el textbox
        ElseIf CBXModificarcompra.Text = "Id" Then
            Consulta = ("select * from compra")
            consultar()
            DTGModificarcompra.DataSource = Tabla
            DTPBuscarmodificarcompra.Visible = False
            TXTBuscarmodificarcompra.Visible = True
            'Sino muestra el datatimerpick y oculta el textbox
        Else
            DTPBuscarmodificarcompra.Visible = True
            TXTBuscarmodificarcompra.Visible = False
        End If
    End Sub

    '//////Datatimerpick para la busqueda de fechas en el panel principal de compras
    Private Sub DTPBuscarcompra_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPBuscarcompra.ValueChanged
        'Convierte datatimerpick en un string
        Dim fecha As String = DTPBuscarcompra.Value.ToString("yyyy-MM-dd")
        'Ve la fecha del datatimerpick y hace la consulta a la base de datos
        Consulta = "select * from compra where fechacompra like '" & fecha & "%'"
        consultar()
        'Actualiza el datagrid
        DGVCompras.DataSource = Tabla
    End Sub
    '/////Datatimerpick para buscar por fecha en modificacion de compra
    Private Sub DTPBuscarmodificarcompra_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPBuscarmodificarcompra.ValueChanged
        Dim fecha As String = DTPModifechacompra.Value.ToString("yyyy-MM-dd")
        'Ve la fecha del datatimerpick y hace la consulta a la base de datos
        Consulta = "select * from compra where fechacompra like '" & fecha & "%'"
        consultar()
        DTGModificarcompra.DataSource = Tabla
    End Sub
    '/////////////////////////////FIN COMPRAS//////////////////////////////////////////////////////////////////
    '//////////////////////////////////////////////////////////////////////////////////////////////////////////
    '//////////////////////////////////////////////////////////////////////////////////////////////////////////

   
    Private Sub btnclearventa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


        rtbventa.Text = ""
        txbtotalventa.Text = ""
        txbceduladeclientedeventas.Clear()
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


        'txbcomentarioventa.Clear()
        'txbtotalventa.Clear()


        'txbcomentarioventa.Text = DataGridViewVENTAS.Item(2, DataGridViewVENTAS.CurrentRow.Index).Value
        'txbtotalventa.Text = DataGridViewVENTAS.Item(3, DataGridViewVENTAS.CurrentRow.Index).Value

    End Sub


    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    'MODIFICAR VENTAS 
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim fecha As String = DTPVentas.Value.ToString("yyyy-MM-dd")
        Dim comentario As String = rtbventa.Text
        Dim totalv As String = txbtotalventa.Text


        Try
            Consulta = ("update venta set idv='" + DataGridViewVENTAS.Item(0, DataGridViewVENTAS.CurrentRow.Index).Value + "', fechaventa='" + fecha + "', comentariov='" + rtbventa.Text + "', totalv='" + txbtotalventa.Text + "' where idv='" + DataGridViewVENTAS.Item(0, DataGridViewVENTAS.CurrentRow.Index).Value + "'")
            consultar()
            Consulta = "select * from venta"
            consultar()
            DataGridViewVENTAS.DataSource = Tabla
            'lblparamostrarsisemodifico.Show()

        Catch ex As Exception
            MsgBox(ex)

        End Try

    End Sub


    Private Sub TabbedPane_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabbedPane.SelectedIndexChanged

        Select Case TabbedPane.SelectedIndex

            Case 0
                'CONSULTA DE TABLA GANADO
                Consulta = "select idg, sexo, raza, estado, nacimiento, TIMESTAMPDIFF(YEAR,ganado.nacimiento,CURDATE()) AS 'Anios', TIMESTAMPDIFF(month, ganado.nacimiento,NOW())%12 AS 'Meses' from ganado Where estado <> 'Muerto/a' "
                consultar()
                DataGridViewganado.DataSource = Tabla

                DataGridViewganado.Focus()

                'Cambiamos los headers

                DataGridViewganado.Columns(0).HeaderText = "Codigo"
                DataGridViewganado.Columns(1).HeaderText = "Sexo"
                DataGridViewganado.Columns(2).HeaderText = "Raza"

                DataGridViewganado.Columns(4).HeaderText = "Fecha Nacimiento"
                DataGridViewganado.Columns(3).HeaderText = "Estado"
                DataGridViewganado.Columns(5).HeaderText = "Años"
                DataGridViewganado.Columns(6).HeaderText = "Meses"
                PanelDatosGanado.Visible = False

                Exit Select
            Case 1

                'CONSULTA DE TABLA(CARGA COMPRA)
                Consulta = "select * from compra"
                consultar()
                DGVCompras.DataSource = Tabla
                DGVCompras.Columns(0).HeaderText = "Id"
                DGVCompras.Columns(1).HeaderText = "Fecha de Compra"
                DGVCompras.Columns(2).HeaderText = "Comentario"
                DGVCompras.Columns(3).HeaderText = "Total"

                Exit Select
            Case 2

                'CONSULTA VENTA
                Consulta = "select * from venta"
                consultar()
                'actualiza la dgvw
                DataGridViewVENTAS.DataSource = Tabla
                PanelDatosGanado.Visible = False

                Exit Select
            Case 3

                'CARGA DATAGRIDCLIENTES
                Consulta = "select * from cliente where estado = 1 "
                consultar()

                DataGridViewClientes.DataSource = Tabla

                DataGridViewClientes.Focus()

                DataGridViewClientes.Columns(0).HeaderText = "Cédula"
                DataGridViewClientes.Columns(1).HeaderText = "Nombre"
                DataGridViewClientes.Columns(2).HeaderText = "Apellido"
                DataGridViewClientes.Columns(3).HeaderText = "Dirección"
                DataGridViewClientes.Columns(4).HeaderText = "Dirección"
                DataGridViewClientes.Columns(5).Visible = False

                PanelDatosGanado.Visible = False

                Exit Select
            Case 4

                PanelDatosGanado.Visible = False
                BTNBusquedaUsuarios.PerformClick()

                CBXBusquedaUsuarios.SelectedIndex = 0

                Exit Select

        End Select
    End Sub


    Private Sub Panelagregarventaaganado_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        Consulta = " select * from ganado"
        consultar()


    End Sub




    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

        Consulta = " select * from venta"
        consultar()


    End Sub
    Private Sub paneldetextosenventas_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles paneldetextosenventas.Paint
        Consulta = "select idg,sexo,raza,nacimiento,estado,preciov,idv from ganado"
        consultar()
        'actualiza la dgvw
        'DataGridViewganadoenventa.DataSource = Tabla


        'DataGridViewganadoenventa.Columns(0).HeaderText = "Id ganado"
        'DataGridViewganadoenventa.Columns(1).HeaderText = "Sexo"
        'DataGridViewganadoenventa.Columns(2).HeaderText = "Raza"
        'DataGridViewganadoenventa.Columns(3).HeaderText = "nacimiento"
        'DataGridViewganadoenventa.Columns(4).HeaderText = "Estado"
        'DataGridViewganadoenventa.Columns(5).HeaderText = "Precio de venta"
        'DataGridViewganadoenventa.Columns(6).HeaderText = "id de venta"



    End Sub



    Private Sub DataGridViewganadoenventa_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'txbcodigodeganadoenventa.Text = DataGridViewganadoenventa.Item(0, DataGridViewganadoenventa.CurrentRow.Index).Value

    End Sub



    Private Sub DataGridViewmodificarventa_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewmodificarventa.SelectionChanged

        DateTimePickermodificarventa.Text = DataGridViewmodificarventa.Item(1, DataGridViewmodificarventa.CurrentRow.Index).Value
        RichTextBoxmodificarventa.Text = DataGridViewmodificarventa.Item(2, DataGridViewmodificarventa.CurrentRow.Index).Value
        txbmodificarventa.Text = DataGridViewmodificarventa.Item(3, DataGridViewmodificarventa.CurrentRow.Index).Value
        'CBXmodificarestadoventa = DataGridViewmodificarventa.Item(5, DataGridViewmodificarventa.CurrentRow.Index).Value

    End Sub

    Private Sub Button6_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNmodificarventas.Click

        Dim fecha As String = DateTimePickermodificarventa.Value.ToString("yyyy-MM-dd")
        Dim comentario As String = RichTextBoxmodificarventa.Text
        Dim totalv As String = txbmodificarventa.Text
        Dim dedo As String = DataGridViewmodificarventa.Item(0, DataGridViewmodificarventa.CurrentRow.Index).Value

        Try
            Consulta = ("update venta set fechaventa='" + fecha + "', comentariov='" + comentario + "', totalv='" + totalv + "' where idv='" & dedo & "'")

            consultar()
            Consulta = "select * from venta"
            consultar()
            DataGridViewmodificarventa.DataSource = Tabla


        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub

    Private Sub btnvolvervm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnvolvervm.Click
        Consulta = "select * from venta"
        consultar()
        DataGridViewVENTAS.DataSource = Tabla
        paneldemodificarventa.Visible = False

    End Sub


    '//////////////PARTE DE VENTA///////////////////////////////////////////////////////////////////////////////
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNAparecerPanelCalculo.Click

        DGVCalculoK.Rows.Clear()

        For i As Integer = 0 To LSTVentas.Items.Count - 1

            DGVCalculoK.Rows.Add()

            DGVCalculoK.Item(0, i).Value = LSTVentas.Items(i).ToString
        Next
        PNLCalculoK.Visible = True

    End Sub

    Private Sub BTNCalculoK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCalculoK.Click

        Dim total As Double = 0

        For i As Integer = 0 To DGVCalculoK.Rows.Count - 1
            If IsNumeric(DGVCalculoK.Item(1, i).Value) And IsNumeric(DGVCalculoK.Item(2, i).Value) Then
                DGVCalculoK.Item(1, i).Value = DGVCalculoK.Item(1, i).Value.ToString.Replace(".", ",")
                DGVCalculoK.Item(2, i).Value = DGVCalculoK.Item(2, i).Value.ToString.Replace(".", ",")
                DGVCalculoK.Item(3, i).Value = (Convert.ToDouble(DGVCalculoK.Item(1, i).Value)) * (Convert.ToDouble(DGVCalculoK.Item(2, i).Value))
                total = (total + (Convert.ToDouble(DGVCalculoK.Item(3, i).Value)))
             Else
                MsgBox("Ingrese caracteres numericos solamente")
                Exit Sub
            End If
        Next
        txbtotalventa.Text = (((total * 22) / 100) + total).ToString
        PNLCalculoK.Visible = False
    End Sub

    Private Sub btnclearventaxd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclearventaxd.Click
        rtbventa.Text = ""
        txbtotalventa.Text = ""
        txbceduladeclientedeventas.Clear()
    End Sub



    Private Sub cbxventa_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbxventa.SelectedIndexChanged
        LSTVentas.Items.Add(cbxventa.SelectedItem.ToString)
        cbxventa.Items.RemoveAt(cbxventa.SelectedIndex)
    End Sub


    Private Sub BTNQuitarLista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNQuitarLista.Click
        Try
            cbxventa.Items.Add(LSTVentas.Items.Item(LSTVentas.SelectedIndex))
            LSTVentas.Items.RemoveAt(LSTVentas.SelectedIndex)
        Catch ex As Exception
        End Try
    End Sub
    'AGREGAR EN VENTA
    Private Sub btnagregarventa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnagregarventa.Click
        Dim fecha As String = DTPVentas.Value.ToString("yyyy-MM-dd")
        Dim comentario As String = rtbventa.Text
        Dim totalv As String = txbtotalventa.Text
        Dim id As String = txbceduladeclientedeventas.Text

        If txbceduladeclientedeventas.Text = "" Then
            MsgBox("Complete el campo Cédula")
        Else
            Try
                'consulta
                comando.CommandType = CommandType.Text
                comando.Connection = connection
                comando.CommandText = "insert into venta (fechaventa,comentariov,totalv,id) values('" & fecha & "','" & comentario & "','" & Round(Convert.ToDouble(totalv), 2).ToString.Replace(",", ".") & "','" & id & "')"
                connection.Open()
                comando.ExecuteNonQuery()
                connection.Close()
                'select hacia venta
                Consulta = "select * from venta"
                consultar()
                'actualiza la dgvw
                DataGridViewVENTAS.DataSource = Tabla
                DataGridViewVENTAS.Columns(0).HeaderText = "Id venta"
                DataGridViewVENTAS.Columns(1).HeaderText = "Fecha de venta"
                DataGridViewVENTAS.Columns(2).HeaderText = "Comentario"
                DataGridViewVENTAS.Columns(3).HeaderText = "Total"
                DataGridViewVENTAS.Columns(4).HeaderText = "Cédula de cliente"
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        comando.CommandType = CommandType.Text
        comando.Connection = connection
        comando.CommandText = ("select max(idv) from venta")
        Try
            connection.Open()
            reader = comando.ExecuteReader()
            reader.Read()
            Dim aux As String = reader.GetString(0)
            connection.Close()
            connection.Open()

            For i As Integer = 0 To LSTVentas.Items.Count - 1
                comando.CommandText = ("update ganado set estado='vendido', idv='" + aux + "', preciov='" + DGVCalculoK.Item(3, i).Value.ToString.Replace(",", ".") + "' where idg='" + LSTVentas.Items(i) + "'")
                comando.ExecuteNonQuery()
            Next
            connection.Close()
            MsgBox("Se agregó la venta con exito")
        Catch ex As Exception
            MsgBox(ex.Message)
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
        'rtbventa.Text = ""
        'txbtotalventa.Text = ""
        'txbceduladeclientedeventas.Clear()

        'btnvolverventa.PerformClick()
        BTNBoleta.Visible = True
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnvolverventa.Click
        paneldetextosenventas.Visible = False
    End Sub
    'AGREGAR VENTA
    Private Sub Button9_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNAGREGARVENTAP.Click
        rtbventa.Text = ""
        txbtotalventa.Text = ""
        txbceduladeclientedeventas.Clear()
        paneldetextosenventas.BringToFront()
        cbxventa.Items.Clear()
        LSTVentas.Items.Clear()
        'El comando va por texto
        comando.CommandType = CommandType.Text
        'el comando se conecta a traves del objeto connection
        comando.Connection = connection
        comando.CommandText = ("select idg from ganado where estado='activo'")
        Try
            connection.Open()
            reader = comando.ExecuteReader()
            If reader.HasRows() Then
                While reader.Read()
                    cbxventa.Items.Add(reader.GetString(0))
                End While
            End If
            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
        paneldetextosenventas.Visible = True
    End Sub

    'MODIFICAR VENTAS 
    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmodificarventa.Click
        paneldemodificarventa.BringToFront()
        paneldemodificarventa.Visible = True
        Consulta = "select * from venta"
        consultar()
        DataGridViewmodificarventa.DataSource = Tabla
        DataGridViewmodificarventa.Columns(0).HeaderText = "Id"
        DataGridViewmodificarventa.Columns(1).HeaderText = "Fecha de venta"
        DataGridViewmodificarventa.Columns(2).HeaderText = "Comentario"
        DataGridViewmodificarventa.Columns(3).HeaderText = "Total Pagado"
        DataGridViewmodificarventa.Columns(4).HeaderText = "Cédula de cliente"
    End Sub
    Private Sub btnbuscarventa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbuscarventa.Click
        If CBXbuscarenventa.Text = "Venta con mayor costo" Then
            Consulta = "SELECT * FROM `venta` WHERE totalv >= ALL (SELECT totalv FROM venta)"
            consultar()
            DataGridViewVENTAS.DataSource = Tabla
        End If
        If CBXbuscarenventa.Text = "Venta con menor costo" Then
            Consulta = "SELECT * FROM `venta` WHERE totalv <= ALL (SELECT totalv FROM venta)"
            consultar()
            DataGridViewVENTAS.DataSource = Tabla
        End If
        If CBXbuscarenventa.Text = "Todas las ventas" Then
            Consulta = "SELECT * FROM `venta`"
            consultar()
            DataGridViewVENTAS.DataSource = Tabla
        End If
        If CBXbuscarenventa.Text = "Última venta realizada en el año actual" Then
            Consulta = "SELECT * FROM `venta` WHERE MONTH(fechaventa) <= ALL (SELECT MONTH(fechaventa) FROM venta)"
            consultar()
            DataGridViewVENTAS.DataSource = Tabla
        End If
        If CBXbuscarenventa.Text = "Primera venta realizada en el año actual" Then
            Consulta = "SELECT * FROM `venta` WHERE MONTH(fechaventa) >= ALL (SELECT MONTH(fechaventa) FROM venta)"
            consultar()
            DataGridViewVENTAS.DataSource = Tabla
        End If
    End Sub
    Dim separador As Boolean = False
    Private Sub TMRHoraFecha_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TMRHoraFecha.Tick
        If separador = False Then
            LBLHora.Text = (Date.Now.Hour.ToString("00") + " " + Date.Now.Minute.ToString("00"))
            separador = True
        Else
            LBLHora.Text = (Date.Now.Hour.ToString("00") + ":" + Date.Now.Minute.ToString("00"))
            separador = False
        End If
    End Sub
    Dim index As Integer = 99999
    '//////boleta//////////////////////////////////






    Private Sub BTNBoleta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBoleta.Click
        

        Dim idventaenboleta As Integer
        Dim nombreclienteve As String
        Dim apellidoclienteve As String
        comando.CommandType = CommandType.Text

        comando.Connection = connection
        comando.CommandText = ("SELECT nombre,apellido from cliente WHERE id ='" + txbceduladeclientedeventas.Text + "'")

        connection.Open()
        reader = comando.ExecuteReader()
        reader.Read()
        nombreclienteve = reader.GetString(0)
        connection.Close()


        comando.Connection = connection
        comando.CommandText = ("SELECT apellido from cliente WHERE id ='" + txbceduladeclientedeventas.Text + "'")

        connection.Open()
        reader = comando.ExecuteReader()
        reader.Read()
        apellidoclienteve = reader.GetString(0)
        connection.Close()



        comando.Connection = connection
        comando.CommandText = ("select max(idv) from venta")
        connection.Open()
        reader = comando.ExecuteReader()
        reader.Read()

        idventaenboleta = reader.GetString(0)
        connection.Close()




        Boleta.clear()
       
        For i As Integer = 0 To DGVCalculoK.Rows.Count - 1 And DataGridViewganado.Rows.Count - 1
            Boleta.cargardatos(DGVCalculoK.Item(1, i).Value, DGVCalculoK.Item(2, i).Value, DGVCalculoK.Item(3, i).Value, DGVCalculoK.Item(0, i).Value, DTPVentas.Value.ToString("yy/MM/dd"), Convert.ToDouble(txbtotalventa.Text), nombreclientev:=nombreclienteve.ToString, apellidoclientev:=apellidoclienteve.ToString, idventaboleta:=idventaenboleta.ToString, raza:=DataGridViewganado.Item(2, i).Value, sexo:=DataGridViewganado.Item(1, i).Value)
        Next
        Boleta.Show()
        BTNBoleta.Visible = False
    End Sub
    ' ////////////////////////////////////////////////////

    Private Sub BOTONAgregarModificarRaza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONAgregarModificarRaza.Click
        PanelAgregarModificarRaza.Visible = True

        BOTONAgregarModificarRaza.Visible = False
        BOTONcerrarAgregarModificarRaza.Visible = True
    End Sub

    Private Sub CBXModificarCBX_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBXModificarCBX.SelectedIndexChanged
        TXTModificarRazaCBX.Text = CBXModificarCBX.Text
    End Sub

    Private Sub BOTONagregarRazaCBX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONagregarRazaCBX.Click

        Dim verificar As String

        If MessageBox.Show("¿Seguro desea guardar datos ?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then


            'If Not IsNumeric(txtnombreCliente.Text) And Not IsNumeric(txtapellidoCliente.Text) Then


            verificar = txtAgregarRazaCBX.ToString

            Consulta = "select * from razas where razitas='" + txtAgregarRazaCBX.Text + "'"
            consultar()

            If Tabla.Rows.Count > 0 Then
                For Each row As DataRow In Tabla.Rows
                    verificar = row("razitas").ToString
                    txtAgregarRazaCBX.Clear()
                    MsgBox("LA raza existe")
                Next

            Else
                If txtAgregarRazaCBX.Text <> "" Then
                    Consulta = "INSERT INTO razas(razitas) VALUES('" + txtAgregarRazaCBX.Text + "')"
                    consultar()
                    txtAgregarRazaCBX.Clear()
                    MsgBox("Se agrego raza con exito", MsgBoxStyle.Information, Title:="Agregado")
                    comando.CommandType = CommandType.Text
                    comando.Connection = connection
                    comando.CommandText = ("select razitas from razas")
                    Try
                        connection.Open()
                        reader = comando.ExecuteReader()
                        If reader.HasRows() Then
                            While reader.Read()
                                CBXeliminarRazaCBX.Items.Remove(reader.GetString(0))
                                CBXRazaGanado.Items.Remove(reader.GetString(0))
                                CBXseleccionarRaza.Items.Remove(reader.GetString(0))
                                CBXrazaCompradoVendido.Items.Remove(reader.GetString(0))
                                CBXRazacompra.Items.Remove(reader.GetString(0))
                                CBXModificarCBX.Items.Remove(reader.GetString(0))
                            End While
                        End If
                        connection.Close()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                        If connection.State = ConnectionState.Open Then
                            connection.Close()
                        End If
                    End Try

                    comando.CommandType = CommandType.Text

                    comando.Connection = connection

                    comando.CommandText = ("select razitas from razas")

                    Try

                        connection.Open()

                        reader = comando.ExecuteReader()

                        If reader.HasRows() Then

                            While reader.Read()
                                CBXeliminarRazaCBX.Items.Add(reader.GetString(0))
                                CBXRazaGanado.Items.Add(reader.GetString(0))
                                CBXseleccionarRaza.Items.Add(reader.GetString(0))
                                CBXrazaCompradoVendido.Items.Add(reader.GetString(0))
                                CBXRazacompra.Items.Add(reader.GetString(0))
                                CBXModificarCBX.Items.Add(reader.GetString(0))


                            End While

                        End If

                        connection.Close()

                    Catch ex As Exception
                        MsgBox(ex.Message)
                        If connection.State = ConnectionState.Open Then
                            connection.Close()
                        End If

                    End Try
                Else
                    MsgBox("No puede agregar una raza con datos vacios", MsgBoxStyle.Critical, Title:=" No se pudo agregar raza")
                End If
            End If


        End If

    End Sub




    Private Sub BOTONmodificarRazaCBX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONmodificarRazaCBX.Click

        comando.CommandType = CommandType.Text
        comando.Connection = connection

        If CBXModificarCBX.Text <> "" Then

            comando.CommandText = ("update razas set razitas='" + TXTModificarRazaCBX.Text + "' where razitas='" + CBXModificarCBX.SelectedItem.ToString + "'")

            TXTModificarRazaCBX.Clear()
            CBXModificarCBX.Text = ""

            CBXeliminarRazaCBX.Items.Clear()
            CBXModificarCBX.Items.Clear()
            CBXRazaGanado.Items.Clear()
            CBXseleccionarRaza.Items.Clear()
            CBXrazaCompradoVendido.Items.Clear()
            CBXRazacompra.Items.Clear()



            Try

                connection.Open()

                comando.ExecuteNonQuery()

                connection.Close()

            Catch ex As Exception
                MsgBox(ex.Message)
                If connection.State = ConnectionState.Open Then
                    connection.Close()
                End If

            End Try

            comando.CommandType = CommandType.Text

            comando.Connection = connection

            comando.CommandText = ("select razitas from razas")

            Try

                connection.Open()

                reader = comando.ExecuteReader()

                If reader.HasRows() Then

                    While reader.Read()

                        CBXeliminarRazaCBX.Items.Add(reader.GetString(0))
                        CBXRazaGanado.Items.Add(reader.GetString(0))
                        CBXseleccionarRaza.Items.Add(reader.GetString(0))
                        CBXrazaCompradoVendido.Items.Add(reader.GetString(0))
                        CBXRazacompra.Items.Add(reader.GetString(0))
                        CBXModificarCBX.Items.Add(reader.GetString(0))


                    End While

                End If

                connection.Close()

            Catch ex As Exception
                MsgBox(ex.Message)
                If connection.State = ConnectionState.Open Then
                    connection.Close()
                End If

            End Try

        Else

            MsgBox("Debe seleccionar la raza a modificar")

        End If

    End Sub


 
    Private Sub CBXMostrarDatosClientes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBXMostrarDatosClientes.SelectedIndexChanged

        If CBXMostrarDatosClientes.SelectedItem = "Importe total por cada cliente activo" Then


            Consulta = "SELECT cliente.id AS 'Cedula', nombre AS 'Nombre', apellido As 'Apellido', direccion As 'Direccion', telefono AS 'Telefono', sum(totalv) As 'Importe total' FROM cliente,venta where venta.id = cliente.id and cliente.id in(SELECT venta.id FROM venta) and estado = 1 GROUP BY 1 "
            consultar()
            DataGridViewMostraDatosClientes.DataSource = Tabla

            GroupBoxcliente.Enabled = False
            DataGridclienteInactivos.Visible = False
            DataGridViewClientes.Visible = False
            DataGridViewMostraDatosClientes.Visible = True

            If DataGridViewMostraDatosClientes.Rows.Count = 0 Then

                MsgBox("No exiten datos solicitados", MsgBoxStyle.Information, Title:="Busqueda")



            End If

        ElseIf CBXMostrarDatosClientes.SelectedItem = "Importe total por cada cliente inactivo" Then


            Consulta = "SELECT cliente.id AS 'Cedula', nombre AS 'Nombre', apellido As 'Apellido', direccion As 'Direccion', telefono AS 'Telefono', sum(totalv) As 'Importe total' FROM cliente,venta where venta.id = cliente.id and cliente.id in(SELECT venta.id FROM venta) and estado = 0 GROUP BY 1 "
            consultar()
            DataGridViewMostraDatosClientes.DataSource = Tabla

            GroupBoxcliente.Enabled = False
            DataGridclienteInactivos.Visible = False
            DataGridViewClientes.Visible = False
            DataGridViewMostraDatosClientes.Visible = True

            If DataGridViewMostraDatosClientes.Rows.Count = 0 Then

                MsgBox("No exiten datos solicitados", MsgBoxStyle.Information, Title:="Busqueda")

            End If



        ElseIf CBXMostrarDatosClientes.SelectedItem = "Cliente activo con mayor importe total" Then


            Consulta = "SELECT cliente.id AS 'Cedula', nombre AS 'Nombre', apellido As 'Apellido', direccion As 'Direccion', telefono AS 'Telefono', sum(totalv) As 'Importe total' FROM cliente,venta where venta.id = cliente.id and cliente.id in(SELECT venta.id FROM venta HAVING max(totalv)) and estado = 1 "
            consultar()
            DataGridViewMostraDatosClientes.DataSource = Tabla

            GroupBoxcliente.Enabled = False
            DataGridclienteInactivos.Visible = False
            DataGridViewClientes.Visible = False
            DataGridViewMostraDatosClientes.Visible = True

            If DataGridViewMostraDatosClientes.Rows.Count = 0 Then

                MsgBox("No se exiten datos solicitados", MsgBoxStyle.Information, Title:="Busqueda")

            End If



        ElseIf CBXMostrarDatosClientes.SelectedItem = "Cliente inactivo con mayor importe total" Then


            Consulta = "SELECT cliente.id AS 'Cedula', nombre AS 'Nombre', apellido As 'Apellido', direccion As 'Direccion', telefono AS 'Telefono', sum(totalv) As 'Importe total' FROM cliente,venta where venta.id = cliente.id and cliente.id in(SELECT venta.id FROM venta HAVING max(totalv)) and estado = 0 "
            consultar()
            DataGridViewMostraDatosClientes.DataSource = Tabla

            GroupBoxcliente.Enabled = False
            DataGridclienteInactivos.Visible = False
            DataGridViewClientes.Visible = False
            DataGridViewMostraDatosClientes.Visible = True

            If DataGridViewMostraDatosClientes.Rows.Count = 0 Then

                MsgBox("No se exiten datos solicitados", MsgBoxStyle.Information, Title:="Busqueda")


        End If

        ElseIf CBXMostrarDatosClientes.SelectedItem = "Cliente activo con mayor compra realizada" Then


            Consulta = "SELECT cliente.id AS 'Cedula', nombre AS 'Nombre', apellido As 'Apellido', direccion As 'Direccion', telefono AS 'Telefono', max(totalv) As 'Mayor Venta(U$$)' FROM cliente,venta where venta.id = cliente.id and estado = 1 "
            consultar()
            DataGridViewMostraDatosClientes.DataSource = Tabla

            GroupBoxcliente.Enabled = False
            DataGridclienteInactivos.Visible = False
            DataGridViewClientes.Visible = False
            DataGridViewMostraDatosClientes.Visible = True

            If DataGridViewMostraDatosClientes.Rows.Count = 0 Then

                MsgBox("No se exiten datos solicitados", MsgBoxStyle.Information, Title:="Busqueda")

            End If



        End If



    End Sub

    'Envento keypress para combobox para ganado//////////////
    Private Sub txtAgregarRazaCBX_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAgregarRazaCBX.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then


            'If IsNumeric(txtBuscarCodGanado.Text) Then


        Else
            e.Handled = True

        End If
    End Sub

    Private Sub TXTModificarRazaCBX_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTModificarRazaCBX.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then


            'If IsNumeric(txtBuscarCodGanado.Text) Then


        Else
            e.Handled = True

        End If
    End Sub
    '/////////////// fin keypress//////////////////////////////////

    Private Sub CBXmodificarEstadoGanado_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBXmodificarEstadoGanado.KeyPress
        e.Handled = True
    End Sub

    Private Sub CBXagregarEstadoGanado_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBXagregarEstadoGanado.KeyPress
        e.Handled = True
    End Sub

    Private Sub CBXsexoGanado_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBXsexoGanado.KeyPress
        e.Handled = True
    End Sub

    Private Sub CBXRazaGanado_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBXRazaGanado.KeyPress
        e.Handled = True
    End Sub

    Private Sub DTPAgregarGanado_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTPAgregarGanado.KeyPress
        e.Handled = True
    End Sub

    Private Sub CBXModificarCBX_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBXModificarCBX.KeyPress
        e.Handled = True
    End Sub

    Private Sub CBXMostrarDatosClientes_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBXMostrarDatosClientes.KeyPress
        e.Handled = True
    End Sub



    Private Sub CBXcompradoVendido_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBXcompradoVendido.KeyPress
        e.Handled = True
    End Sub

    Private Sub CBXrazaCompradoVendido_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBXrazaCompradoVendido.KeyPress
        e.Handled = True
    End Sub

    Private Sub CBXbuscarEstadoGanado_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBXbuscarEstadoGanado.KeyPress
        e.Handled = True
    End Sub

    Private Sub CBXseleccionarRaza_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBXseleccionarRaza.KeyPress
        e.Handled = True
    End Sub

    Private Sub CBXseleccionarSexo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBXseleccionarSexo.KeyPress
        e.Handled = True
    End Sub

    Private Sub DateTimeBuscarFechaGanado_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DateTimeBuscarFechaGanado.KeyPress
        e.Handled = True
    End Sub

    Private Sub BOTONcerrarAgregarModificarRaza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONcerrarAgregarModificarRaza.Click

        PanelAgregarModificarRaza.Visible = False

        BOTONcerrarAgregarModificarRaza.Visible = False
        BOTONAgregarModificarRaza.Visible = True

    End Sub

  
    Private Sub BOTONeliminarRaza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOTONeliminarRaza.Click


        Dim razas As String
        razas = txtEliminarRaza.ToString

        Consulta = "select raza from ganado where raza='" + txtEliminarRaza.Text + "' group by 1 "
        consultar()

        If Tabla.Rows.Count > 0 Then
            For Each row As DataRow In Tabla.Rows
                razas = row("raza").ToString
                txtAgregarRazaCBX.Clear()
                MsgBox("LA raza existe")
            Next

        Else

            Consulta = " DELETE FROM razas WHERE razitas ='" + txtEliminarRaza.Text + "'"
            consultar()
            MsgBox("Se elimino raza")
            CBXeliminarRazaCBX.Text = ""

            CBXeliminarRazaCBX.Items.Clear()
            CBXModificarCBX.Items.Clear()
            CBXRazaGanado.Items.Clear()
            CBXseleccionarRaza.Items.Clear()
            CBXrazaCompradoVendido.Items.Clear()
            CBXRazacompra.Items.Clear()

            comando.CommandType = CommandType.Text

            comando.Connection = connection

            comando.CommandText = ("select razitas from razas")

            Try

                connection.Open()

                reader = comando.ExecuteReader()

                If reader.HasRows() Then

                    While reader.Read()
                        CBXeliminarRazaCBX.Items.Add(reader.GetString(0))
                        CBXRazaGanado.Items.Add(reader.GetString(0))
                        CBXseleccionarRaza.Items.Add(reader.GetString(0))
                        CBXrazaCompradoVendido.Items.Add(reader.GetString(0))
                        CBXRazacompra.Items.Add(reader.GetString(0))
                        CBXModificarCBX.Items.Add(reader.GetString(0))


                    End While

                End If

                connection.Close()

            Catch ex As Exception
                MsgBox(ex.Message)
                If connection.State = ConnectionState.Open Then
                    connection.Close()
                End If

            End Try

        End If

    End Sub

    Private Sub CBXeliminarRazaCBX_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBXeliminarRazaCBX.SelectedIndexChanged
        txtEliminarRaza.Text = CBXeliminarRazaCBX.Text
    End Sub
End Class
