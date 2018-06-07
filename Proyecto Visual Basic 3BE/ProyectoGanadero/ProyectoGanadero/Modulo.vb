
Imports System.Data
Imports System.Data.OleDb
Imports MySql.Data.MySqlClient
Module Modulo
    Dim ubicacion As String = "server=localhost; user id=root ; password='';database = vacuno"
    Public Conexion As MySqlDataAdapter
    Public Tabla As DataTable
    Public Consulta As String
    Public MysqlConexion As MySqlConnection = New MySqlConnection(ubicacion)


    Public Sub consultar()

        Try

            Conexion = New MySqlDataAdapter(Consulta, ubicacion)
            Tabla = New DataTable
            Conexion.Fill(Tabla)


        Catch ex As Exception

            MsgBox(ex.Message)

        End Try


    End Sub

End Module

'    'Public conexion As New MySqlConnection
'    'Public Sub Conectar()

'    '    Try
'    '        conexion.Close()
'    '        conexion.ConnectionString = "server=localhost; user=root; password=; database=vacuno"
'    '        conexion.Open()

'    '    Catch ex As Exception
'    '        MsgBox(ex.Message)

'    '    End Try

'    'End Sub
'    'Public Function SQLSEL(ByRef SQL As String) As DataSet
'    '    Conectar()
'    '    Dim adaptador As New MySqlDataAdapter(SQL, conexion)
'    '    Dim RsDatos As New DataSet
'    '    adaptador.Fill(RsDatos, "DATOS")
'    '    Return RsDatos
'    '    conexion.Close()




'    End Function
'End Module
