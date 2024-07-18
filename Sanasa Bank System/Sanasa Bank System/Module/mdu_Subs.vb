Module mdu_Subs

    Public Sub OpenConnection()
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Sub CloseConnection()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
    End Sub

End Module
