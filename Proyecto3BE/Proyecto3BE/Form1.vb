﻿Imports MySql.Data.MySqlClient

Public Class Form1
    'Objetos necesarios para realizar la conexion a la DB
    Dim data As String = ("Server=localhost;Database=vacas;User id=root;Password=;Port=3306;")
    Dim conexion As New MySqlConnection(data)

    'Se crea el objeto que contiene la consulta a realizar
    Dim consulta As New MySqlCommand
    'Se crea el objeto reader que leera los resultados devueltos por la consulta
    Dim reader As MySqlDataReader

    'Usuario que actualmente intenta loguearse
    Dim usuario As Integer = 0
    'Contraseña del usuario que intenta loguearse actualmente
    Dim passwd As String = ""

    'Control de estado del logueo
    Dim estado As Integer = 1

    'Cuando el usuario presiona "Aceptar" se evaluaran los datos y se hara login en caso de ser correctos
    'en caso de no serlo, se informara el error
    Private Sub BotonAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BotonAceptar.Click
        If estado = 1 Then
            estado1()
        Else
            estado2()
        End If
    End Sub

    'El estado 1 se encarga de recoger que usuario esta ingresando actualmente
    Private Sub estado1()
        'Array que contiene todos los usuarios de la DB cuando "estado" = 1
        Dim cis(0) As Integer

        'Se le asigna a consulta los valores necesarios, texto del comando, conexion a utilizar y tipo de comando
        consulta.CommandText = "select ci from usuario where estado='activo'"
        consulta.Connection = conexion
        consulta.CommandType = CommandType.Text

        Try
            'Se abre la conexion con la DB, se ejecuta la consulta y se envian los resultados al objeto reader
            conexion.Open()
            reader = consulta.ExecuteReader()
            'Si "reader" tiene algun resultado, se lee cada resultado y se guarda en el array "cis"
            If reader.HasRows Then
                While reader.Read()
                    cis(cis.Length - 1) = reader.GetInt32(0)
                    ReDim Preserve cis(cis.Length)
                End While
                ReDim Preserve cis(cis.Length - 2)
            Else
                MsgBox("Usuario no Encontrado")
            End If
            conexion.Close()
        Catch ex As Exception
            MsgBox("Error: " + ex.Message)
        End Try

        'Se compara el usuario ingresado con todos los usuarios encontrados en la DB
        'Si se encuentra coincidencia se iguala la variable "usuario" a este
        For Each ele As Integer In cis
            If TextBoxUser.Text = ele.ToString Then
                usuario = ele
                Exit For
            End If
        Next

        'Si ninguno coincide se informa de la excepcion
        If usuario = 0 Then
            LabelInfo.Text = "Usuario no encontrado o incorrecto"
            TextBoxUser.Focus()
        Else
            avanzar()
        End If
    End Sub

    'El estado 2 se encarga de recoger la contraseña del usuario en cuestion, validar y dar ingreso al programa
    Private Sub estado2()

        'Se le asigna a consulta los valores necesarios, texto del comando, conexion a utilizar y tipo de comando
        consulta.CommandText = ("select contrasena from usuario where ci='" + Str(usuario) + "'")
        consulta.Connection = conexion
        consulta.CommandType = CommandType.Text

        Try
            'Se abre la conexion, se ejecuta la consulta y se guarda el resultado en "reader"
            conexion.Open()
            reader = consulta.ExecuteReader()

            'Se pasa la contraseña obtenida al la variable "passwd"
            reader.Read()
            passwd = reader.GetString(0)

            'Se cierra la conexion
            conexion.Close()
        Catch ex As Exception
            MsgBox("Error: " + ex.Message)
        End Try

        'Si coincide la contraseña ingresada con la obtenida de la DB, se ingresa
        'sino se informa del error
        If TextBoxUser.Text = passwd Then
            Form2.Show()
            Me.Close()
        Else
            TextBoxUser.Text = ""
            TextBoxUser.Focus()
            LabelInfo.Text = "Contraseña Incorrecta"
        End If
    End Sub

    'Los metodos de avanzar y volver se encargan de controlar los cambios de estado del logueo y cambiar la interfaz segun sea necesario
    'Este metodo se usa para cambiar de la interfaz de ingresar usuario a ingresar contraseña
    Private Sub avanzar()
        BotonAceptar.Text = "Ingresar"
        LabelUser.Text = "Contraseña:"
        BotonVolver.Visible = True
        TextBoxUser.Text = ""
        TextBoxUser.Focus()
        TextBoxUser.PasswordChar = "+"
        Me.Text = ("Ingresar: " + Str(usuario))
        estado = 2
    End Sub
    'Este metodo se usa para cambiar de la intefaz de ingresar contraseña a la de ingresar usuario
    Private Sub volver()
        usuario = 0
        passwd = ""
        BotonAceptar.Text = ">>"
        LabelUser.Text = "Usuario (CI):"
        BotonVolver.Visible = False
        TextBoxUser.Text = ""
        TextBoxUser.Focus()
        TextBoxUser.PasswordChar = ""
        Me.Text = "Ingresar"
        estado = 1
    End Sub

    'Si se presiona "Enter" estando en el textbox, se interpeta igual a presionar el boton de avance
    Private Sub TextBoxUser_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxUser.KeyDown
        If e.KeyCode = Keys.Enter Then
            BotonAceptar.PerformClick()
        End If
    End Sub

    'Si usuario cambia el texto escrito en el TextBox "Usuario" se deja de indicar que los datos son erroneos
    Private Sub TextBoxUser_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxUser.TextChanged
        LabelInfo.Text = ""
    End Sub

    'El boton volver cvuelve a la interfaz anterior
    Private Sub BotonVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BotonVolver.Click
        volver()
    End Sub
End Class
