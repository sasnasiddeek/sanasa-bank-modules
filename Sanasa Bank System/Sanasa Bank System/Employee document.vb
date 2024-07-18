Imports MySql.Data.MySqlClient
Imports System.IO
Public Class Employee_document
    Dim con As New MySqlConnection
    Dim Connection As String = "Server=localhost; username=root;password=sasna1234;database=sanasabank"
    ' Dim conn As New MySqlConnection("server=localhost;user id=root;password=sasna1234;database=employee")
    Dim cmd As New MySqlCommand
    Dim da As New MySqlDataAdapter
    Dim result As Integer
    Dim imgpath As String
    Dim arrimage() As Byte
    Dim sql As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles SaveDocument.Click
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

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Employee_document_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbldate.Text = Date.Now.ToString("dd-MM-yyy")
        lbltime.Text = Date.Now.ToString("hh-mm-ss")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
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

                            cmd.CommandText = "Insert into employeedocument(EmployeeNic,DocumentId,EmployeeName,Catogaries,EntryDate,UpdateDate,Comment,SaveDocument)VALUES(@EmployeeNic,@DocumentId,@EmployeeName,@Catogaries,@EntryDate,@UpdateDate,@Comment,@SaveDocument)"
                            cmd.Parameters.AddWithValue("@EmployeeNic", txtnic.Text)
                            cmd.Parameters.AddWithValue("@DocumentId", txtdid.Text)
                            cmd.Parameters.AddWithValue("@EmployeeName", txtname.Text)
                            cmd.Parameters.AddWithValue("@Catogaries", ComboBox1.Text)
                            cmd.Parameters.AddWithValue("@EntryDate", DateTimePicker1.Text)
                            cmd.Parameters.AddWithValue("@UpdateDate", DateTimePicker2.Text)
                            cmd.Parameters.AddWithValue("@Comment", txtcomment.Text)
                            cmd.Parameters.AddWithValue("@SaveDocument", arrimage)
                            '' cmd.ExecuteNonQuery()

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

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = True

    End Sub
End Class