Imports MySql.Data.MySqlClient
Public Class viewcustomerregistraion
    Dim conn As New MySqlConnection("server=localhost;user id=root;password=sasna1234;database=sanasabank")
    Dim cmd As New MySqlCommand
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
    Public Sub displaydate()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()

        cmd = conn.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "Select * From registration"
        cmd.ExecuteNonQuery()
        Dim dt As New DataTable()
        Dim da As New MySqlDataAdapter(cmd)
        da.Fill(dt)
        DataGridView1.DataSource = dt


    End Sub

    Private Sub viewcustomerregistraion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        displaydate()
    End Sub
End Class


