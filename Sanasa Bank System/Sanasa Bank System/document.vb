Imports MySql.Data.MySqlClient
Imports System.IO

Public Class document
    Dim con As New MySqlConnection
    Dim Connection As String = "Server=localhost; username=root;password=sasna1234;database=sanasabank"
    ' Dim conn As New MySqlConnection("server=localhost;user id=root;password=sasna1234;database=employee")
    Dim cmd As New MySqlCommand
    Dim da As New MySqlDataAdapter
    Dim result As Integer
    Dim imgpath As String
    Dim arrimage() As Byte
    Dim sql As String
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try

            'Dim msstream As New System.IO.MemoryStream
            'PictureBox1.Image.Save(msstream, System.Drawing.Imaging.ImageFormat.Jpeg)
            'arrimage = msstream.GetBuffer()
            'Dim filesize As UInt32
            'filesize = msstream.Length
            'msstream.Close()

            Try
                OpenConnection()
                Using cmd As MySqlCommand = conn.CreateCommand
                    Using trans As MySqlTransaction = conn.BeginTransaction
                        Try
                            cmd.Connection = conn
                            cmd.Transaction = trans

                            cmd.CommandText = "Insert into document(CustomerId,AccountNumber,CustomerName,Catogaries,EntryDate,UpdateDate,Comment,SaveDocument)VALUES(@CustomerId,@AccountNumber,@CustomerName,@Catogaries,@EntryDate,@UpdateDate,@Comment,@SaveDocument)"
                            cmd.Parameters.AddWithValue("@CustomerId", txtid.Text)
                            cmd.Parameters.AddWithValue("@AccountNumber", txtnumber.Text)
                            cmd.Parameters.AddWithValue("@CustomerName", txtname.Text)
                            cmd.Parameters.AddWithValue("@Catogaries", ComboBox1.Text)
                            cmd.Parameters.AddWithValue("@EntryDate", DateTimePicker1.Text)
                            cmd.Parameters.AddWithValue("@UpdateDate", DateTimePicker2.Text)
                            cmd.Parameters.AddWithValue("@Comment", txtcomment.Text)
                            cmd.Parameters.AddWithValue("@SaveDocument", arrimage)
                            cmd.ExecuteNonQuery()

                            trans.Commit()


                        Catch ex As Exception
                            trans.Rollback()
                            MsgBox("Error" & ex.ToString)
                        End Try
                    End Using
                End Using
            Catch ex As Exception
                MsgBox("Error" & ex.ToString)
            Finally : CloseConnection()
            End Try

            'sql = "Insert into document(AccountNumber,Catogaries,EntryDate,UpadateDate,Comment,SaveDocument)VALES(@AccountNumber,@Catogaries,@EntryDate,@UpdateDate,@Comment,@SaveDocument)"
            ''cmd.Connection = con
            ''cmd.CommandText = sql
            'cmd.Parameters.AddWithValue("@AccountNumber", txtnumber.Text)
            'cmd.Parameters.AddWithValue("@Catogaries", ComboBox1.Text)
            'cmd.Parameters.AddWithValue("@EntryDate", DateTimePicker1.Text)
            'cmd.Parameters.AddWithValue("@UpdateDate", DateTimePicker2.Text)
            'cmd.Parameters.AddWithValue("@Comment", txtcomment.Text)
            'cmd.Parameters.AddWithValue("@SaveDocument", arrimage)


            'Dim x As Integer

            'X = cmd.ExecuteNonQuery()

            ' If X > 0 Then
            'MessageBox.Show("Document record has been added")
            'Else
            'MessageBox.Show("Record not saved")

            'End If
            'cmd.Parameters.Clear()
            'conn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)

        Finally : CloseConnection()
        End Try
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
        'DataGridView1.DataSource = dt


    End Sub

    Private Sub document_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
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

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    'Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs)
    '    Try
    '        If con.State = ConnectionState.Open Then
    '            con.Close()
    '        End If
    '        con.Open()
    '        Dim i As Integer
    '        i = Convert.ToInt32(DataGridView1.SelectedCells.Item(0).Value.ToString())

    '        cmd = con.CreateCommand()
    '        cmd.CommandType = CommandType.Text
    '        cmd.CommandText = "select  AccountNumber from document where AccountNumber=" & i & ""
    '        cmd.ExecuteNonQuery()

    '        Dim dt As New DataTable()
    '        Dim da As New MySqlDataAdapter(cmd)
    '        da.Fill(dt)
    '        Dim dr As MySqlDataReader
    '        dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
    '        While dr.Read

    '            txtnumber.Text = dr.GetValue(0).ToString()



    '        End While

    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Dim ask As MsgBoxResult
        ask = MsgBox("Are you sure want to change the Document details?", MsgBoxStyle.YesNo, "Message")

        Try
            If con.State = ConnectionState.Open Then
                con.Close()
            End If

            conn.Open()

            cmd = con.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText =
            cmd.ExecuteNonQuery()
            displaydate()
            MessageBox.Show("Person details changed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)



        Catch ex As Exception
            MessageBox.Show("Data Not Update", "Messsage", MessageBoxButtons.OK, MessageBoxIcon.Question)


        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim command As New MySqlCommand("select * from document where CustomerId = @CustomerId", conn)
        command.Parameters.Add("@CustomerId", MySqlDbType.VarChar).Value = txtid.Text
        ''If c.State = ConnectionState.Open Then
        ''    conn.Close()
        ''End If
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()



        cmd = conn.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select * from document where AccountNumber='" & txtnumber.Text & "'"
        cmd.ExecuteNonQuery()


        Dim table As New DataTable()
        Dim adapter As New MySqlDataAdapter(command)

        adapter.Fill(table)
        If table.Rows.Count() <= 0 Then
            MessageBox.Show("No Image For This Number")
        Else

            txtid.Text = table.Rows(0)(1).ToString()
            txtnumber.Text = table.Rows(0)(2).ToString()
            txtname.Text = table.Rows(0)(3).ToString()
            ComboBox1.Text = table.Rows(0)(4).ToString()
            DateTimePicker1.Text = table.Rows(0)(5).ToString()
            DateTimePicker2.Text = table.Rows(0)(6).ToString()
            txtcomment.Text = table.Rows(0)(7).ToString()

            Dim arrimage() As Byte
            arrimage = table.Rows(0)(8)
            Dim ms As New MemoryStream(arrimage)

            PictureBox1.Image = Image.FromStream(ms)




        End If

































    End Sub



    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub txtnumber_TextChanged(sender As Object, e As EventArgs) Handles txtname.TextChanged



    End Sub

    Private Sub txtnumber_Leave(sender As Object, e As EventArgs) Handles txtname.Leave
        Try


            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()



            cmd = con.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "select * from document where AccountNumber = '" & txtname.Text & "'"
            cmd.ExecuteNonQuery()


            Dim table As New DataTable()
            Dim adapter As New MySqlDataAdapter(cmd)

            adapter.Fill(table)
            If table.Rows.Count() <= 0 Then
                MessageBox.Show("No Image For This Number")
            Else


                txtname.Text = table.Rows(0)(0).ToString()
                ComboBox1.Text = table.Rows(0)(1).ToString()
                DateTimePicker1.Text = table.Rows(0)(3).ToString()
                DateTimePicker2.Text = table.Rows(0)(4).ToString()
                txtcomment.Text = table.Rows(0)(5).ToString()

                Dim arrimage() As Byte
                arrimage = table.Rows(0)(6)
                Dim ms As New MemoryStream(arrimage)

                PictureBox1.Image = Image.FromStream(ms)




            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txtname.Clear()
        ComboBox1.Text = ""
        DateTimePicker1.Text = ""
        DateTimePicker1.Text = ""
        txtcomment.Clear()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lbldate.Text = Date.Now.ToString("dd-MM-yyy")
        lbltime.Text = Date.Now.ToString("hh-mm-ss")
    End Sub

    Private Sub lbldate_Click(sender As Object, e As EventArgs) Handles lbldate.Click

    End Sub
End Class
