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

    Dim campos() As String = {"ci", "nombre", "permisos"}
    Dim rows(0) As String
    Dim tipo As String

    Dim connection As New MySqlConnection(data)
    Dim comando As New MySqlCommand
    Dim reader As MySqlDataReader

    Private Sub BotonBusquedaUsuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BotonBusquedaUsuarios.Click

        If TextBoxBusquedaUsuarios.Text = "" Then
            comando.CommandText = "select ci from usuarios"
        Else
            comando.CommandText = ("select nombre from usuario where " + campos(ComboBoxUsuarios.SelectedIndex) + "='" + TextBoxBusquedaUsuarios.Text + "'")
        End If
        comando.CommandType = CommandType.Text
        comando.Connection = connection

        Try
            connection.Open()
            reader = comando.ExecuteReader()
            If reader.HasRows Then
                ListBoxUsuarios.Items.Clear()
                ReDim rows(0)

                While (reader.Read())
                    rows(rows.Length - 1) = reader.GetString("nombre")
                    ReDim Preserve rows(rows.Length)
                End While
                'ReDim Preserve rows(rows.Length - 2)

                For Each ele As String In rows
                    MsgBox(ele + ".")
                Next

                'ListBoxUsuarios.Items.AddRange(rows)
            Else
                LabelInfoUsuarios.Text = "No se encontraron resultados"
            End If
            connection.Close()
        Catch ex As Exception

        End Try

    End Sub
End Class