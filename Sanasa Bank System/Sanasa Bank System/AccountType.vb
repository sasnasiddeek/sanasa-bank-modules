Imports MySql.Data.MySqlClient
Public Class AccountType
    Dim conn As New MySqlConnection("server=localhost;user id=root;password=sasna1234;database=sanasabank")
    Dim cmd As New MySqlCommand
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lbldate.Text = Date.Now.ToString("dd-MM-yyy")
        lbltime.Text = Date.Now.ToString("hh-mm-ss")


    End Sub
    Public Sub displaydate()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()

        cmd = conn.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "Select * From account"
        cmd.ExecuteNonQuery()
        Dim dt As New DataTable()
        Dim da As New MySqlDataAdapter(cmd)
        da.Fill(dt)
        DataGridView1.DataSource = dt


    End Sub

    Private Sub AccountType_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        displaydate()
        Timer1.Enabled = True
    End Sub
End Class
