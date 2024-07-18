Imports MySql.Data.MySqlClient
Public Class viewcustomer
    Dim conn As New MySqlConnection("server=localhost;user id=root;password=sasna1234;database=sanasabank")
    Dim cmd As New MySqlCommand
    Private Sub viewcustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        displaydate()
        Timer1.Enabled = True

    End Sub
    Public Sub displaydate()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()

        cmd = conn.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "Select * From document"
        cmd.ExecuteNonQuery()
        Dim dt As New DataTable()
        Dim da As New MySqlDataAdapter(cmd)
        da.Fill(dt)
        DataGridView1.DataSource = dt


    End Sub
    Public Sub FilterData(valueToSearch As String)
        Dim searchQuery As String = "SELECT * From document WHERE CustomerId like '%" & valueToSearch & "%' "
        Dim cmd As New MySqlCommand(searchQuery, conn)
        Dim da As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable()

        da.Fill(dt)
        DataGridView1.DataSource = dt

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lbldate.Text = Date.Now.ToString("dd-MM-yyy")
        lbltime.Text = Date.Now.ToString("hh-mm-ss")


    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick, DataGridView1.CellClick


    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FilterData(txtsearch.Text)
    End Sub

    Private Sub txtsearsh_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        FilterData(txtsearch.Text)
    End Sub


End Class