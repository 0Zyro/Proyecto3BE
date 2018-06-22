Public Class Form1

    Private Sub ButtonAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAceptar.Click

        If TextBoxUser.Text = "user" And TextBoxPasswd.Text = "passwd" Then
            Form2.Show()
            Me.Close()
        Else
            TextBoxUser.Text = ""
            TextBoxPasswd.Text = ""
            LabelInfo.Text = "Datos Incorrectos"
            TextBoxUser.Focus()
        End If
    End Sub

    Private Sub TextBoxUser_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxUser.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBoxPasswd.Focus()
        End If
    End Sub

    Private Sub TextBoxUser_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxUser.TextChanged
        LabelInfo.Text = ""
    End Sub

    Private Sub TextBoxPasswd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxPasswd.KeyDown
        If e.KeyCode = Keys.Enter Then
            ButtonAceptar.PerformClick()
        End If
    End Sub

    Private Sub TextBoxPasswd_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxPasswd.TextChanged
        LabelInfo.Text = ""
    End Sub
End Class
