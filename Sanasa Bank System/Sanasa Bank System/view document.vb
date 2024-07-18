Imports MySql.Data.MySqlClient
Imports System.IO
Public Class view_document
    Dim con As New MySqlConnection
    Dim Connection As String = "Server=localhost; username=root;password=sasna1234;database=sanasabank"
    ' Dim conn As New MySqlConnection("server=localhost;user id=root;password=sasna1234;database=employee")
    Dim cmd As New MySqlCommand
    Dim da As New MySqlDataAdapter
    Dim result As Integer
    Dim imgpath As String
    Dim arrimage() As Byte
    Dim sql As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim command As New MySqlCommand("select * from document where CustomerId = @CustomerId", conn)
        command.Parameters.Add("@CustomerId", MySqlDbType.VarChar).Value = txtcustomerID.Text



        Dim table As New DataTable()
        Dim adapter As New MySqlDataAdapter(command)

        adapter.Fill(table)
        If table.Rows.Count() <= 0 Then
            MessageBox.Show("No Image For This Number")
        Else


            txtcustomerID.Text = table.Rows(0)(1).ToString()
            cmbAccountNumber.Text = table.Rows(0)(2).ToString()
            txtname.Text = table.Rows(0)(3).ToString()
            ComboBox3.Text = table.Rows(0)(4).ToString()

            Dim arrimage() As Byte
            arrimage = table.Rows(0)(8)
            Dim ms As New MemoryStream(arrimage)

            PictureBox1.Image = Image.FromStream(ms)




        End If














    End Sub

    Private Sub view_document_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
    End Sub

    Sub categury()
        Try
            conn.Open()

            cmd = conn.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT AccountNumber,CustomerName FROM sanasabank.registration where CustomerId='" & txtcustomerID.Text & "'"
            cmd.ExecuteNonQuery()
            Dim dr As MySqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim sname = dr.GetString("AccountNumber")
                cmbAccountNumber.Items.Add(sname)
                txtname.Text = dr.GetString("CustomerName")


            End While
            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtcustomerID_Leave(sender As Object, e As EventArgs) Handles txtcustomerID.Leave
        categury()
    End Sub

    Private Sub txtcustomerID_TextChanged(sender As Object, e As EventArgs) Handles txtcustomerID.TextChanged

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub cmbAccountNumber_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAccountNumber.SelectedIndexChanged

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lbldate.Text = Date.Now.ToString("dd-MM-yyy")
        lbltime.Text = Date.Now.ToString("hh-mm-ss")


    End Sub
End Class