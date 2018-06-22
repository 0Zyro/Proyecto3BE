Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAceptar.Click

        If TextBoxUser.Text = "user" And TextBoxPasswd.Text = "passwd" Then

            Form2.Show()
            Me.Close()

        Else

            LabelInfo.Text = "Datos Incorrectos"

        End If

    End Sub

    Private Sub TextBoxUser_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxUser.TextChanged
        LabelInfo.Text = ""
    End Sub

    Private Sub TextBoxPasswd_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxPasswd.TextChanged
        LabelInfo.Text = ""
    End Sub
End Class
