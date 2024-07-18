Imports MySql.Data.MySqlClient


Public Class mail
    Dim con As New MySqlConnection
    Dim Connection As String = "Server=localhost; username=root;password=sasna1234;database=sasnasabank"
    Dim cmd As New MySqlCommand
    Dim da As New MySqlDataAdapter
    Dim result As Integer
    Dim imgpath As String
    Dim arrimage() As Byte
    Dim sql As String




    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles entry.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles mailid.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
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

    Private Sub mail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim msstream As New System.IO.MemoryStream
            PictureBox1.Image.Save(msstream, System.Drawing.Imaging.ImageFormat.Jpeg)
            arrimage = msstream.GetBuffer()
            Dim filesize As UInt32
            filesize = msstream.Length
            msstream.Close()

            con.ConnectionString = Connection
            con.Open()
            sql = "Insert into document(AccountNumber,Catogaries,EntryDate,UpadateDate,Comment,SaveDocument)VALUES(@AccountNumber,@Catogaries,@EntryDate,@UpdateDate,@Comment,@SaveDocument)"
            cmd.Connection = con
            cmd.CommandText = sql
            cmd.Parameters.AddWithValue("@AccountNumber", txtacccount.Text)
            cmd.Parameters.AddWithValue("@Catogaries", ComboBox1.Text)
            cmd.Parameters.AddWithValue("@EntryDate", txtentry.Text)
            cmd.Parameters.AddWithValue("@UpdateDate", txtupdate.Text)
            cmd.Parameters.AddWithValue("@Comment", txtcomment.Text)
            cmd.Parameters.AddWithValue("@SaveDocument", arrimage)

            Dim x As Integer

            x = cmd.ExecuteNonQuery()

            If x > 0 Then
                MessageBox.Show("Document record has been added")
            Else
                MessageBox.Show("Record not saved")

            End If
            cmd.Parameters.Clear()
            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)


        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class