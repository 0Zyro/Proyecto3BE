Public Class FormVenta

  Private Sub FormVenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Consulta = "select * from v"
        'consultar()
        'DataGridView1.DataSource = Tabla
        'DataGridView1.Columns(0).Visible = False

        'Dim consulta As String = "Select * from venta"
        'DataGridView1.DataSource = SQLSEL(consulta).Tables("DATOS")
        'conexion.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FormPrincipal.Show()
        Me.Close()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        '    Consulta = "INSERT INTO vebta(marca,matricula,puertas) values ('" & TextBox1.Text & "','" & TextBox2.Text & "' )"
        '    consultar()
        '    Consulta = "select * from venta"
        '    consultar()
        '    DataGridView1.DataSource = Tabla
        '    DataGridView1.Columns(0).Visible = False

    End Sub
End Class