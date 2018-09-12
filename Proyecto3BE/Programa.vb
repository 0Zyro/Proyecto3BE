Imports System.Data
Imports System.Data.OleDb
Imports MySql.Data.MySqlClient
Imports System.IO

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

    '///SECCION USUARIOS

    Private Sub LBLCambioContraseña_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBLCambioContraseña.Click
        If MessageBox.Show("¿Seguro que desea cambiar su contraseña?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then

            Dim asd As String = InputBox("mensaje", "titulo")

            If verificarPasswd(asd) Then

                '///////////////////////////
                'Cambiar contraseña usuaio logueado
                '///////////////////////////

            End If

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

        PICUsuarioLogueado.ImageLocation = ("../../Res/profile/" + imagen + ".bmp")
    End Sub

    'Boton de busqueda de usuarios
    Private Sub BotonBusquedaUsuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBusquedaUsuarios.Click

        'Se borra el contenido anterior del listbox
        DGVUsuarios.DataSource = Nothing

        'Si el panel de busqueda esta vacio se buscaran todos, en caso contrario se busca lo especificado
        If TXTBusquedaUsuarios.Text = "" Then
            If CHBUsuariosInactivos.Checked Then
                Consulta = ("select ci, nombre, contrasena, rango, estado from usuario")
            Else
                Consulta = ("select ci, nombre, contrasena, rango, estado from usuario where estado='activo'")
            End If
        Else
            If CHBUsuariosInactivos.Checked Then
                Consulta = ("select ci, nombre, contrasena, rango, estado from usuario where " + CBXBusquedaUsuarios.SelectedItem + "='" + TXTBusquedaUsuarios.Text + "'")
            Else
                Consulta = ("select ci, nombre, contrasena, rango, estado from usuario where estado='activo' and " + CBXBusquedaUsuarios.SelectedItem + "='" + TXTBusquedaUsuarios.Text + "'")
            End If
        End If

        consultar()

        DGVUsuarios.DataSource = Tabla

        If CHBUsuariosInactivos.Checked = True Then
        Else
            DGVUsuarios.Columns(4).Visible = False
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

            If Dir$("../../Res/profile/" + reader.GetString(5) + ".bmp") <> "" Then
                PICUsuarios.ImageLocation = ("../../Res/profile/" + reader.GetString(5) + ".bmp")
            Else
                PICUsuarios.ImageLocation = ("../../Res/profile/default.bmp")
            End If

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
        Dim stringaux As String = imagenSeleccionada()
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        'Info necesaria para el comando
        comando.CommandType = CommandType.Text
        comando.Connection = connection

        Select Case estadoUsuario
            Case "modificar"
                If verificarNombre() Then
                    If verificarPasswd() Then
                        comando.CommandText = ("update usuario set contrasena='" + TXTPasswdUsuarios.Text +
                       "', nombre='" + TXTNombreUsuarios.Text +
                       "', rango='" + CBXRangoUsuarios.SelectedItem.ToString +
                       "', perfil='" + stringaux +
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
                        LBLInfoUsuarios.Text = "Contraseña muy corta"
                    End If
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
                                If verificarPasswd() Then
                                    comando.CommandText = ("insert into usuario values ('" +
                                                           TXTCiUsuarios.Text + "','" +
                                                           TXTNombreUsuarios.Text + "','" +
                                                           TXTPasswdUsuarios.Text + "','" +
                                                           CBXRangoUsuarios.SelectedItem.ToString +
                                                           "','activo','" +
                                                           stringaux +
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

    Private Function imagenSeleccionada()

        Dim nombre() As String

        If PICUsuarios.ImageLocation <> "../../Res/profile/default.bmp" And PICUsuarios.ImageLocation <> "../../Res/profile/nueva.bmp" Then
            nombre = PICUsuarios.ImageLocation.Split("/")
            nombre = nombre(nombre.Length - 1).Split(".")

            Return nombre(0)

        End If

        Return "default"
    End Function

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

        BTNBusquedaUsuarios.Visible = False
        CHBUsuariosInactivos.Visible = False

        DGVUsuarios.Visible = False

        CBXBusquedaUsuarios.Visible = False

        BTNAgregarUsuarios.Visible = False
        BTNEliminarUsuarios.Visible = False
        BTNModificarUsuarios.Visible = False

        PICUsuarios.Enabled = True
        'PICUsuarios.ImageLocation = "../../Res/profile/nueva.bmp"

        TXTBusquedaUsuarios.Visible = False

        PNLUsuarios.Visible = True
    End Sub

    Private Sub estadoAgregar()
        estadoModificar()

        estadoUsuario = "agregar"

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

        TXTBusquedaUsuarios.Visible = False

        PNLUsuarios.Visible = False

        BTNBusquedaUsuarios.PerformClick()

        StringImagenUsuarios = "default"

    End Sub

    Private Sub CheckBoxUsuarios_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHBUsuariosInactivos.CheckStateChanged

        BTNBusquedaUsuarios.PerformClick()

        If CHBUsuariosInactivos.Checked Then
            DGVUsuarios.Columns(4).Visible = True
        Else
            DGVUsuarios.Columns(4).Visible = False
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



    Private Sub TabClientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabClientes.Click
        If paneldetextosenventas.Visible = True Then
            btnagregarpanel.Image = Image.FromFile("Resources\flecha-hacia-la-izquierda.png")
        Else
            btnagregarpanel.Image = Image.FromFile("Resources\anadir.png")
        End If
    End Sub
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load





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


        'Paneles de agregar compras
        PNLAgregarcompraganado.Enabled = False
        PNLAgregarcompraganado.Visible = False
        PNLAgregarcompraganado.SendToBack()

        PNLAgregarcompraproducto.Enabled = False
        PNLAgregarcompraproducto.Visible = False
        PNLAgregarcompraproducto.SendToBack()

        'Muestra el panel principal de Compras y oculta los otros
        PNLPrincipalcompra.BringToFront()
        Panelmodificarcompras.Visible = False
        Panelagregarcompras.Visible = False

        '////////////FIN COMPRAS
    End Sub
    '////////////GANADO




    ''''''''//////////////////////// ///// BOTON PARA INGRESAR AL PANEL AGRAGAR GANADO///////////////
    '''//////////////////////////////////////////////////////////////////////////////////////////////////////////
    ''' 
    Private Sub btnagregarganado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnagregarganado.Click

        Texcodigoganado.Clear()
        Texsexoganado.Clear()
        Texrazaganado.Clear()
        DTPAgregarGanado.Value = Today
        Texestadoganado.Clear()

        Panelagregarganando.Visible = True

        Consulta = " select idg from ganado"
        consultar()
        DataGridganadoguardado.DataSource = Tabla
        DataGridganadoguardado.Columns(0).HeaderText = "Codigo de ganado"
    End Sub

    '''//////////////TABLA GANADO(CODIGO PARA INGRESAR DATOS)
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If MessageBox.Show("¿Seguro desea guardar datos ?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            If Texcodigoganado.Text <> "" And Texsexoganado.Text <> "" And Texrazaganado.Text <> "" And Texestadoganado.Text <> "" Then
                If IsNumeric(Texcodigoganado.Text) Then
                    Dim CodG As Integer = Texcodigoganado.Text
                    Dim sexo As String = Texsexoganado.Text
                    Dim raza As String = Texrazaganado.Text
                    Dim fechaN As String = DTPAgregarGanado.Value.ToString("yyyy-MM-dd")
                    Dim estadoG As String = Texestadoganado.Text
                    Try

                        Consulta = "INSERT INTO ganado (idg,sexo,raza,nacimiento,estado) values('" & CodG & "','" & sexo & "','" & raza & "','" & fechaN & "','" & estadoG & "' )"
                        consultar()


                        Consulta = " select idg,sexo,raza,nacimiento,estado from ganado"
                        consultar()

                        DataGridViewganado.DataSource = Tabla
                        Consulta = " select idg from ganado"
                        consultar()
                        DataGridganadoguardado.DataSource = Tabla
                        Texcodigoganado.Clear()
                        Texsexoganado.Clear()
                        Texrazaganado.Clear()
                        DTPAgregarGanado.Value = Today
                        Texestadoganado.Clear()
                        MsgBox("Datos guardados", MsgBoxStyle.Information)


                    Catch ex As Exception
                        MsgBox(ex)
                    End Try
                End If

            Else
                MsgBox("El codigo del ganado es numerico")
            End If
        Else
            MsgBox("Debe completar todo los datos")
        End If
    End Sub




    ''' ////////BOTON PARA REGREGAR AL PANEL PRINCIPAL/////////////////////////
    ''' '///////////////////////////////////////////////////////////////////////
    ''' 
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Panelagregarganando.Visible = False
    End Sub

    '''////////////////////////// BOTON PARA ELIMINAR GANADO/////////////////////////////
    '''/////////////////////////////////////////////////////////////////////////////////
    '''  

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminarganado.Click
        Dim MsgStyle As MsgBoxStyle = MsgBoxStyle.Critical + MsgBoxStyle.OkOnly
        Dim MsgStyle1 As MsgBoxStyle = MsgBoxStyle.Information + MsgBoxStyle.OkOnly
        If MessageBox.Show("¿Seguro que desea eliminar ?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Try
                Consulta = " delete from ganado where idg='" & DataGridViewganado.Item(0, DataGridViewganado.CurrentRow.Index).Value & "'"
                consultar()


                Consulta = " select idg,sexo,raza,nacimiento,estado from ganado"
                consultar()
                DataGridViewganado.DataSource = Tabla

                MsgBox("Datos borrados", MsgStyle1, Title:="Eliminado")
            Catch ex As Exception
                MsgBox("NO HAY DATOS PARA ELIMINAR" & vbCrLf & vbCrLf & ex.Message, MsgStyle, Title:="ERROR")
            End Try

        End If
    End Sub
    '''///////////////////// BOTON PARA INGRESAR DATOS AL PANEL MODIFICAR GANADO////////////////////////
    ''' //////////////////////////////////////////////////////////////////////////////////////////////
    ''' 
    Private Sub ButPanelModificarGanado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButPanelModificarGanado.Click
        Try

            txtMraza.Text = DataGridViewganado.Item(2, DataGridViewganado.CurrentRow.Index).Value
            DTPModificarGanado.Text = DataGridViewganado.Item(3, DataGridViewganado.CurrentRow.Index).Value
            txtMestado.Text = DataGridViewganado.Item(4, DataGridViewganado.CurrentRow.Index).Value
            txtMcodigo.Text = DataGridViewganado.Item(0, DataGridViewganado.CurrentRow.Index).Value
            txtMsexo.Text = DataGridViewganado.Item(1, DataGridViewganado.CurrentRow.Index).Value
            PanelMGanado.Visible = True

        Catch ex As Exception
            MsgBox(" NO SELECCIONO DATO HA MODIFICAR" & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical, Title:=" ERROR ")
        End Try
    End Sub

    ''//////////////////// CONSULTA MODIFICAR GANADO///////////////
    ''////////////////////////////////////////////////////////////////
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click

        Dim idg As String = txtMcodigo.Text
        Dim sexo As String = txtMsexo.Text
        Dim raza As String = txtMraza.Text
        Dim fechaN As String = DTPModificarGanado.Value.ToString("yyyy-MM-dd")
        Dim estado As String = txtMestado.Text
        If MessageBox.Show("¿Seguro que desea modificar ?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Consulta = "update ganado set idg = '" + idg +
                                      "',sexo='" + sexo +
                                      "',raza='" + raza +
                                      "',nacimiento='" + fechaN +
                                      "',estado='" + estado +
                                      "' where idg= '" + idg + "'"
            consultar()
            Consulta = "select idg,sexo,raza,nacimiento,estado from ganado"
            consultar()
            DataGridViewganado.DataSource = Tabla
            txtMcodigo.Clear()
            txtMsexo.Clear()
            txtMraza.Clear()
            DTPModificarGanado.Value = Today
            txtMestado.Clear()
            MsgBox("Datos editados", MsgBoxStyle.Information)
            PanelMGanado.Visible = False
        End If
    End Sub

    '''//////////////// BOTON PARA CANCELAR MODIFICACION DE GANADO, LIMPIA CAmPOS Y VUELVE AL PANEL PRINCIPAL////////////
    ''' ////////////////////////////////////////////////////////////////////////////////////////////////////

    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        txtMcodigo.Clear()
        txtMsexo.Clear()
        txtMraza.Clear()
        DTPModificarGanado.Value = Today
        txtMestado.Clear()
        PanelMGanado.Visible = False
    End Sub
    '//////////// FIN GANADO
    '/////////////////////////////////////////////////////////////////////////////////////////////


    '///////////////////////////////////////COMPRAS//////////////////////////////////////////////
    '////////////////////////////////////////////////////////////////////////////////////////////
    '/////////////////////////////////////////////////////////////////////////////////////////////
    '/////////////////////////////////////////////////////////////////////////////////////////////
    Private Sub BTNVolverdeagregarcompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNVolverdeagregarcompra.Click
        'Muestra panel pricipal de compras
        PNLPrincipalcompra.Enabled = True
        PNLPrincipalcompra.Visible = True
        PNLPrincipalcompra.BringToFront()


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
    Private Sub BTNpanelmodicompras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNPanelagregarcompra.Click
        'Muestra el panel de agregar compras
        Panelagregarcompras.BringToFront()
        Panelagregarcompras.Visible = True
        Panelagregarcompras.Enabled = True
        CBXAgregarcompra.Text = "Elige una opción"
        'Oculta el panel principal de compras
        PNLPrincipalcompra.SendToBack()
        PNLPrincipalcompra.Enabled = False
        PNLPrincipalcompra.Visible = False
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
                DGVCompras.DataSource = Tabla
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
        PNLPrincipalcompra.SendToBack()
        PNLPrincipalcompra.Visible = False
        PNLPrincipalcompra.Enabled = False
    End Sub
    Private Sub BTNBuscarcompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBuscarcompra.Click
        

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
                DGVCompras.DataSource = Tabla
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
    Private Sub DataGridViewModificarclientes_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewModificarclientes.SelectionChanged
        Nombreyapellidomodificarcliente.Clear()
        Cedulamodificarcliente.Clear()
        Direccionmodificarcliente.Clear()
        Telefonomodificarcliente.Clear()

        Nombreyapellidomodificarcliente.Text = DataGridViewModificarclientes.Item(1, DataGridViewModificarclientes.CurrentRow.Index).Value
        Cedulamodificarcliente.Text = DataGridViewModificarclientes.Item(0, DataGridViewModificarclientes.CurrentRow.Index).Value
        Direccionmodificarcliente.Text = DataGridViewModificarclientes.Item(2, DataGridViewModificarclientes.CurrentRow.Index).Value
        Telefonomodificarcliente.Text = DataGridViewModificarclientes.Item(3, DataGridViewModificarclientes.CurrentRow.Index).Value

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



    Private Sub Agregarmodificarcompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNAgregarmodificacion.Click
        Dim fechacompra As String = DTPModifechacompra.Value.ToString("yyyy-MM-dd")
        Try
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
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub
    Private Sub BTNsalirmodicompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNsalirmodicompra.Click
        'Oculta el panel de modificar compra
        Panelmodificarcompras.Enabled = False
        Panelmodificarcompras.Visible = False
        Panelmodificarcompras.SendToBack()

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
    '//////Boton que elimina el ganado/////////
    Private Sub BTNEliminarCompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNEliminarCompra.Click
        Dim MsgStyle As MsgBoxStyle = MsgBoxStyle.Critical + MsgBoxStyle.OkOnly
        Dim MsgStyle1 As MsgBoxStyle = MsgBoxStyle.Information + MsgBoxStyle.OkOnly

        If MessageBox.Show("¿Seguro que desea eliminar ésta compra?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Try
                'Elimina el id de una compra juntos con todos los datos de ese id
                Consulta = "delete from compra where idc='" & DGVCompras.Item(0, DGVCompras.CurrentRow.Index).Value & "'"
                consultar()

                Select Case error1

                    Case 1
                        MsgBox("No se pudo eliminar la compra", MsgStyle, Title:="Error")
                    Case 0
                        Consulta = "select * from compra"
                        consultar()
                        'Actualiza la BD

                        DGVCompras.DataSource = Tabla

                        MsgBox("Compra eliminada", MsgStyle1, Title:="Eliminado")

                End Select



            Catch ex As Exception
                MsgBox(ex)
            End Try
        End If
    End Sub

    Private Sub TXTBuscarcompra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTBuscarcompra.TextChanged

    End Sub
    '/////////////////////////////FIN COMPRAS//////////////////////////////////////////////////////////////////
    '//////////////////////////////////////////////////////////////////////////////////////////////////////////
    '//////////////////////////////////////////////////////////////////////////////////////////////////////////



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
        Dim id As String = txbceduladeclientedeventas.Text


        If txbceduladeclientedeventas.Text = "" Then
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
                DataGridViewVENTAS.Columns(0).HeaderText = "Id venta"
                DataGridViewVENTAS.Columns(1).HeaderText = "Fecha de venta"
                DataGridViewVENTAS.Columns(2).HeaderText = "Comentario"
                DataGridViewVENTAS.Columns(3).HeaderText = "Total"
                DataGridViewVENTAS.Columns(4).HeaderText = "Cédula de cliente"


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

        If txbiddeventa.Text = "" Then
            MsgBox("Complete campo idv")
        Else

            Try
                Consulta = "delete from venta where idv= '" & txbiddeventa.Text & "'"
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
        txbcodigodeganadoenventa.Clear()
        txbiddeventa.Text = ""
        txbcomentarioventa.Text = ""
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

        txbiddeventa.Clear()
        txbcomentarioventa.Clear()
        txbtotalventa.Clear()

        txbiddeventa.Text = DataGridViewVENTAS.Item(0, DataGridViewVENTAS.CurrentRow.Index).Value
        txbcomentarioventa.Text = DataGridViewVENTAS.Item(2, DataGridViewVENTAS.CurrentRow.Index).Value
        txbtotalventa.Text = DataGridViewVENTAS.Item(3, DataGridViewVENTAS.CurrentRow.Index).Value

    End Sub


    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

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
        Dim id As String = txbiddeventa.Text


        If txbiddeventa.Text = "" Then
            MsgBox("Complete el campo ID ")
        ElseIf txbcomentarioventa.Text = "" And txbtotalventa.Text = "" Then
            MsgBox("Complete los campos restantes ")
        Else


            Try
                Consulta = ("update venta set idv='" + txbiddeventa.Text + "', fechaventa='" + fecha + "', comentariov='" + txbcomentarioventa.Text + "', totalv='" + txbtotalventa.Text + "' where idv='" + txbiddeventa.Text + "'")
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

















    ' ////////////////////////////////////////////////////////////
    
    ' cosas de paneles

    Private Sub btnagregarpanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnagregarpanel.Click

     


        

        DataGridViewganadoenventa.Visible = True
        paneldetextosenventas.Visible = True
        ' cambiamos de tamaño el panel 
        If paneldetextosenventas.Width = 10 Then
            paneldetextosenventas.Width = 1014
        Else
            paneldetextosenventas.Width = 10
        End If

        ' si el panel tiene... de ancho se cambia la imagen del boton 
        If paneldetextosenventas.Width = 1014 Then
            btnagregarpanel.Image = Image.FromFile("..\..\Resources\flecha-hacia-la-izquierda.png")
            Panelparaocultar.Visible = False

        End If

        If paneldetextosenventas.Width = 10 Then
            btnagregarpanel.Image = Image.FromFile("..\..\Resources\anadir.png")
            Panelparaocultar.Visible = True
        End If



    End Sub


    Private Sub TabbedPane_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabbedPane.SelectedIndexChanged

        Select Case TabbedPane.SelectedIndex
            Case 0
                'CONSULTA DE TABLA GANADO
                Consulta = "select idg,sexo,raza,nacimiento,estado from ganado"
                consultar()
                DataGridViewganado.DataSource = Tabla

                'Cambiamos los headers
                DataGridViewganado.Columns(0).HeaderText = "Codigo de ganado"
                DataGridViewganado.Columns(1).HeaderText = "Raza"
                DataGridViewganado.Columns(2).HeaderText = "Sexo"
                DataGridViewganado.Columns(3).HeaderText = "Fecha nacimiento"
                DataGridViewganado.Columns(4).HeaderText = "Estado"




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

                Exit Select
            Case 3

                'CARGA DATAGRIDCLIENTES
                Consulta = "select * from cliente"
                consultar()
                DataGridViewClientes.DataSource = Tabla
                DataGridViewClientes.Columns(0).HeaderText = "Cedúla"
                DataGridViewClientes.Columns(1).HeaderText = "Nombre y apellido"
                DataGridViewClientes.Columns(2).HeaderText = "Dirección"
                DataGridViewClientes.Columns(3).HeaderText = "Teléfono"

                Exit Select
            Case 4

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


    Private Sub Button4_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnañadiraganadounaventa.Click

        paneldetextosenventas.Visible = False


        btnagregarpanel.Image = Image.FromFile("..\..\Resources\anadir.png")




        Try

            'consulta
            Consulta = "update ganado  set idv='" + txbiddeventa.Text + "', preciov='" + txbtotalventa.Text + "' where idg='" + txbcodigodeganadoenventa.Text + "' "
            consultar()
            'select hacia ganado
            Consulta = "select idg,sexo,raza,nacimiento,estado,preciov,idv from ganado"
            consultar()
            'actualiza la dgvw
            DataGridViewganadoenventa.DataSource = Tabla
            MsgBox("se agregó con éxito")
        Catch ex As Exception
            MsgBox(ex)


        End Try

    End Sub

    Private Sub paneldetextosenventas_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles paneldetextosenventas.Paint
        Consulta = "select idg,sexo,raza,nacimiento,estado,preciov,idv from ganado"
        consultar()
        'actualiza la dgvw
        DataGridViewganadoenventa.DataSource = Tabla

      
        DataGridViewganadoenventa.Columns(0).HeaderText = "Id ganado"
        DataGridViewganadoenventa.Columns(1).HeaderText = "Sexo"
        DataGridViewganadoenventa.Columns(2).HeaderText = "Raza"
        DataGridViewganadoenventa.Columns(3).HeaderText = "nacimiento"
        DataGridViewganadoenventa.Columns(4).HeaderText = "Estado"
        DataGridViewganadoenventa.Columns(5).HeaderText = "Precio de venta"
        DataGridViewganadoenventa.Columns(6).HeaderText = "id de venta"



    End Sub



    Private Sub DataGridViewganadoenventa_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewganadoenventa.SelectionChanged
        txbcodigodeganadoenventa.Text = DataGridViewganadoenventa.Item(0, DataGridViewganadoenventa.CurrentRow.Index).Value

    End Sub

    Private Sub BTNAgregarclientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNAgregarclientes.Click
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

    Private Sub BTNClearclientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNClearclientes.Click
        Texcedula.Clear()
        Texdireccion.Clear()
        Texnombreapellido.Clear()
        Texttelefono.Clear()
    End Sub

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

    Private Sub BTNPanelagregarcliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNPanelagregarcliente.Click
        PanelAgregarcliente.BringToFront()
        PanelAgregarcliente.Visible = True
        PanelAgregarcliente.Enabled = True

        PanelPrincipalclientes.SendToBack()
        PanelPrincipalclientes.Visible = False
        PanelPrincipalclientes.Enabled = False
    End Sub

    Private Sub BTNPanelmodificarcliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNPanelmodificarcliente.Click
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

    Private Sub BTNEliminarcliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNEliminarcliente.Click

        Dim MsgStyle As MsgBoxStyle = MsgBoxStyle.Critical + MsgBoxStyle.OkOnly
        Dim MsgStyle1 As MsgBoxStyle = MsgBoxStyle.Information + MsgBoxStyle.OkOnly

        If MessageBox.Show("¿Seguro que desea eliminar a este cliente?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Try
                'Elimina el id de una compra juntos con todos los datos de ese id
                Consulta = "delete from cliente where id='" & DataGridViewClientes.Item(0, DataGridViewClientes.CurrentRow.Index).Value & "'"
                consultar()

                Select Case error1

                    Case 1
                        MsgBox("no se pudo borrar", MsgStyle, Title:="Error")
                    Case 0
                        Consulta = "select * from cliente"
                        consultar()
                        'Actualiza la BD

                        DataGridViewClientes.DataSource = Tabla

                        MsgBox(" cliente eliminado", MsgStyle1, Title:="Eliminado")

                End Select



            Catch ex As Exception
                MsgBox(ex)
            End Try
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
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

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If verificarCedula(Cedulamodificarcliente.Text) Then
            Try
                Consulta = "update cliente set nombre='" + Nombreyapellidomodificarcliente.Text + "', direccion='" + Direccionmodificarcliente.Text + "', telefono='" + Telefonomodificarcliente.Text + "' where id='" + Cedulamodificarcliente.Text + "'"
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
            Catch ex As Exception
                MsgBox(ex)
            End Try
        Else
            MsgBox("Cédula errónea")
        End If
    End Sub

    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Nombreyapellidomodificarcliente.Clear()
        Cedulamodificarcliente.Clear()
        Direccionmodificarcliente.Clear()
        Telefonomodificarcliente.Clear()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
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

   
   
End Class
