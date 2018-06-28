Imports System.Data
Imports System.Data.OleDb
Imports MySql.Data.MySqlClient

Public Class Form2
    'Dim data As String = ("Server=localhost;Database=dbproyecto;User id=root;Password=;Port=3306;")
    Dim data As String = ("Server=www.db4free.net;Database=database_vacas;User id=zero22394;Password=zero22394;Port=3306;")

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

    'Dim conexion As New MySqlConnection(data)

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
End Class