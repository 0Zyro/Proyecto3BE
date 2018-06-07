Public Class FormPrincipal
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Consulta = "select * from ganado"
        consultar()
        Muestra.DataSource = Tabla
        'Muestra.Columns(0).Visible = False
        'actTabla()
        'Dim consulta As String = "Select * from ganado"
        'DataGridView1.DataSource = SQLSEL(consulta).Tables("DATOS")
        'conexion.Close()

        Muestra.Columns(8).Width = 140
        Muestra.Columns(0).HeaderText = "hola"



    End Sub

   


  

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

    End Sub




    Private Sub ClientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClientesToolStripMenuItem.Click
        FormCliente.Show()
        Me.Close()
    End Sub

    Private Sub VentasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VentasToolStripMenuItem.Click
        FormVenta.Show()
        Me.Close()

    End Sub

    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Texb8.TextChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'If Texb2.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" Then
        '    If IsNumeric(TextBox3.Text) Then
        Dim idc As Integer = Texb2.Text
        Dim idv As Integer = Texb3.Text
        Dim raza As String = Texb4.Text
        Dim sexo As String = Texb5.Text
        Dim edad As String = Texb6.Text
        Dim estado As String = Texb9.Text
        Dim PrecioCompra As Integer = Texb7.Text
        Dim PrecioVenta As Integer = Texb8.Text


        Consulta = "INSERT INTO ganado (idC, idV, raza,sexo,edad,estado,Precio_Compra,Precio_Venta) VALUES ('" + Str(idc) + "','" + Str(idv) + "','" + raza + "','" + edad + "','" + estado + "','" + Str(PrecioCompra) + "','" + Str(PrecioVenta) + "');"
        consultar()
        MsgBox("Ingresado con Éxito")

        Me.Dispose()
        'FormPrincipal.Show()
        'FormPrincipal.actTabla()
        '    Else
        'MsgBox("La cantidad es un Número :v " + vbNewLine + "Ingréselo de nuevo", MsgBoxStyle.Exclamation)
        'TextBox3.Text = ""
        '    End If

        'Else
        'MsgBox("Complete los cuadros", MsgBoxStyle.Exclamation)
        'End If
    End Sub

    Private Sub Muestra_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Muestra.CellContentClick
     


        Texb1.Text = Muestra.Item(0, Muestra.CurrentRow.Index).Value


    End Sub
End Class
