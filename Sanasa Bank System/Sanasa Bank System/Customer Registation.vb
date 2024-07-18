Imports MySql.Data.MySqlClient
Imports System.IO

Public Class Customer_Registation
    Dim con As New MySqlConnection
    Dim Connection As String = "Server=localhost; username=root;password=sasna1234;database=sanasabank"
    Dim cmd As New MySqlCommand
    Dim da As New MySqlDataAdapter
    Dim result As Integer
    Dim imgpath As String
    Dim arrimage() As Byte
    Dim sql As String
    Private Sub Customer_Registation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)






    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim msstream As New System.IO.MemoryStream
            PictureBox1.Image.Save(msstream, System.Drawing.Imaging.ImageFormat.Jpeg)
            arrimage = msstream.GetBuffer()
            Dim filesize As UInt32
            filesize = msstream.Length
            msstream.Close()

            con.ConnectionString = Connection
            con.Open()
            sql = "Insert into registration(CustomerId,CustomerName,AccountNumber,DOB,CustomerAge,CustomerAddress,PostalCode,SaveImage)VALUES(@CustomerId,@CustomerName,@AccountNumber,@DOB,@CustomerAge,@CustomerAddress,@PostalCode,@SaveImage)"
            cmd.Connection = con
            cmd.CommandText = sql
            cmd.Parameters.AddWithValue("@CustomerId", txtid.Text)
            cmd.Parameters.AddWithValue("@CustomerName", txtname.Text)
            cmd.Parameters.AddWithValue("@AccountNumber", tstnumber.Text)
            cmd.Parameters.AddWithValue("@DOB", DateTimePicker1.Text)
            cmd.Parameters.AddWithValue("@CustomerAge", txtage.Text)
            cmd.Parameters.AddWithValue("@CustomerAddress", txtaddress)
            cmd.Parameters.AddWithValue("@PostalCode", txtpostal)
            cmd.Parameters.AddWithValue("@SaveImage", arrimage)







            Dim x As Integer

            x = cmd.ExecuteNonQuery()

            If x > 0 Then
                MessageBox.Show("Account has been created")
            Else
                MessageBox.Show("Not created")

            End If
            cmd.Parameters.Clear()
            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)


        End Try
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles txtpostal.TextChanged

    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim ofd As FileDialog = New OpenFileDialog()
            ofd.Filter = "image file (*.jpg;*.png;*.gif;*.jpeg)|*.jpg;*.bmp;*.gif;*.jpeg"

            If ofd.ShowDialog() = DialogResult.OK Then
                imgpath = ofd.FileName
                PictureBox1.ImageLocation = imgpath
            End If
            ofd = Nothing
        Catch ex As Exception
            MsgBox(ex.Message.ToString())





        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim command As New MySqlCommand("select * from document where CustomerId = @CustomerId")
        command.Parameters.Add("@CustomerId", MySqlDbType.VarChar).Value = txtid.Text

        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()



        cmd = conn.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select * from registration where CustomerId='" & txtid.Text & "'"
        cmd.ExecuteNonQuery()


        Dim table As New DataTable()
        Dim adapter As New MySqlDataAdapter(cmd)

        adapter.Fill(table)
        If table.Rows.Count() <= 0 Then
            MessageBox.Show("No Image For This Number")
        Else


            txtid.Text = table.Rows(0)(1).ToString()
            txtname.Text = table.Rows(0)(2).ToString()
            tstnumber.Text = table.Rows(0)(3).ToString()
            DateTimePicker1.Text = table.Rows(0)(4).ToString()
            txtage.Text = table.Rows(0)(5).ToString()
            txtaddress.Text = table.Rows(0)(6).ToString()
            txtpostal.Text = table.Rows(0)(7).ToString()

            Dim arrimage() As Byte
            arrimage = table.Rows(0)(8)
            Dim ms As New MemoryStream(arrimage)

            PictureBox1.Image = Image.FromStream(ms)




        End If


    End Sub

    Private Sub txtnic_TextChanged(sender As Object, e As EventArgs) Handles txtid.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txtid.Clear()
        txtname.Clear()
        tstnumber.Clear()
        DateTimePicker1.Text = ""
        txtage.Clear()
        txtaddress.Clear()
        txtpostal.Clear()




    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub txtaddress_TextChanged(sender As Object, e As EventArgs) Handles txtaddress.TextChanged

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lbldate.Text = Date.Now.ToString("dd-MM-yyy")
        lbltime.Text = Date.Now.ToString("hh-mm-ss")

    End Sub
End Class