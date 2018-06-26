Public Class Form1

    'Cuando el usuario presiona "Aceptar" se evaluaran los datos y se hara login en caso de ser correctosuyguyguyguyguygiujhn
    'en caso de no serlo, se informara el error
    Private Sub ButtonAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAceptar.Click
        If TextBoxUser.Text = "user" And TextBoxPasswd.Text = "passwd" Then
            Form2.Show()
            Me.Close()
        Else
            TextBoxPasswd.Text = ""
            LabelInfo.Text = "Datos Incorrectos"
            TextBoxUser.Focus()
        End If
    End Sub

    'Si usuario presiona "Enter" en el TextBox "Usuario" se cambia el focus al TextBox "Passwd" para continuar escribiendo alli
    Private Sub TextBoxUser_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxUser.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBoxPasswd.Focus()
        End If
    End Sub

    'Si usuario presiona "Enter" en el TextBox "Contraseña" se evaluan los datos para hacer el login
    Private Sub TextBoxPasswd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxPasswd.KeyDown
        If e.KeyCode = Keys.Enter Then
            ButtonAceptar.PerformClick()
        End If
    End Sub

    'Si usuario cambia el texto escrito en el TextBox "Contraseña" se deja de indicar que los datos son erroneos
    Private Sub TextBoxPasswd_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxPasswd.TextChanged
        LabelInfo.Text = ""
    End Sub

    'Si usuario cambia el texto escrito en el TextBox "Usuario" se deja de indicar que los datos son erroneos
    Private Sub TextBoxUser_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxUser.TextChanged
        LabelInfo.Text = ""
    End Sub
End Class
