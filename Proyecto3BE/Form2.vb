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
    
End Class