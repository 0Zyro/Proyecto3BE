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
        'asdasdasdasd
        'asdasdasdasdasdasd
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

        Consulta = ("insert into ventas (FECHA,TOTALDEVENTA,COMENTARIO)values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "')")

        consultar()
        MessageBox.Show("Conexión exitosa")
        TXTID.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub
    'boton modificar con sus respectivos checkbox's con la opcion de poner la id

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        If CheckBoxTODO.Checked = True Then
            Consulta = ("update ventas set IDVENTA='" & TXTID.Text & "',FECHA='" & TextBox1.Text & "',TOTALDEVENTA='" & TextBox2.Text & "',COMENTARIO='" & TextBox3.Text & "'where IDVENTA='" & TXTID.Text & "'")
            consultar()
            TXTID.Text = ""
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""

        End If

        If CheckBox1.Checked = True Then
            Consulta = ("update ventas set IDVENTA='" & TXTID.Text & "',FECHA='" & TextBox1.Text & "'where IDVENTA='" & TXTID.Text & "'")
            consultar()
            TextBox1.Text = ""
        End If
        If CheckBox2.Checked = True Then
            Consulta = ("update ventas set IDVENTA='" & TXTID.Text & "',TOTALDEVENTA='" & TextBox2.Text & "'where IDVENTA='" & TXTID.Text & "'")
            consultar()
            TextBox2.Text = ""
        End If
        If CheckBox3.Checked = True Then
            Consulta = ("update ventas set IDVENTA='" & TXTID.Text & "',COMENTARIO='" & TextBox3.Text & "'where IDVENTA='" & TXTID.Text & "'")
            consultar()
            TextBox3.Text = ""
        End If
    End Sub

    'boton borrar con opcion de poner la id para borrar
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttonborrarventas.Click
        Consulta = ("delete from ventas where IDVENTA= '" & TXTID.Text & "'")
        consultar()
        MsgBox("Borrado" + TXTID.Text)
        TXTID.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

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
End Class