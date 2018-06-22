Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If Label1.Text = "usuario" And Label2.Text = "contraseña" Then

            Form2.Show()

        Else

            Label3.Text = "Datos Incorrectos"

        End If

    End Sub
End Class
