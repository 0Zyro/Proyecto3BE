Public Class FormCliente

    'Sub agregar_formato()

    'End Sub

    'Sub modificar_formato()

    'End Sub

    'Sub eliminar_formato()

    'End Sub

    'Sub buscar_formato()

    'End Sub

    Private Sub Cliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Consulta = "select * from cliente"
        consultar()
        DataGridView1.DataSource = Tabla
        'DataGridView1.Columns(0).Visible = False

        'Dim consulta As String = "Select * from cliente"
        'DataGridView1.DataSource = SQLSEL(consulta).Tables("DATOS")
        'conexion.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        FormPrincipal.Show()
        Me.Close()

    End Sub


   

   
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Consulta = "INSERT INTO cliente(nombre,telefono) values ('" & TextBox1.Text & "','" & TextBox2.Text & "' )"
        consultar()
        Consulta = "select * from cliente"
        consultar()
        DataGridView1.DataSource = Tabla
        'DataGridView1.Columns(0).Visible = False
    End Sub
End Class