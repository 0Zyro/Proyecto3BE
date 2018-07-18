﻿Imports System.Data
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
'jdjdjfje
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Try
        '    conexion.Open()
        '    MsgBox("Conectado")
        'Catch ex As Exception
        '    MsgBox("Error:" And ex.Message)
        'End Try

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

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

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

        'Se borra el contenido anterior del label de informes
        LabelInfoUsuarios.Text = ""

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
            Else
                'Si no se encontraron resultados se informa
                LabelInfoUsuarios.Text = "No se encontraron resultados"
            End If

            'Se Cierra la conexion
            connection.Close()
        Catch ex As Exception
            'Se reportan errores
            MsgBox(ex.Message)
        End Try
    End Sub

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

            'Se mueven los datos desde "reader" a sus TextBox correspondientes
            TextBoxCiUsuarios.Text = reader.GetInt32(0).ToString
            TextBoxNombreUsuarios.Text = reader.GetString(1)
            TextBoxPasswdUsuarios.Text = reader.GetString(2)
            TextBoxRangoUsuarios.Text = reader.GetString(3)

            'Se cierra la conexion
            connection.Close()

        Catch ex As Exception
            'Se reportan errores
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
