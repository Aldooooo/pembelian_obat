Imports System.Threading.Tasks
Module MKoneksi
    Public conn As New OleDb.OleDbConnection
    Public cmd As New OleDb.OleDbCommand
    Public adp As OleDb.OleDbDataAdapter
    Public sql, str As String

    Sub open()
        str = "Provider=Microsoft.Jet.OLEDB.4.0;"
        str += "Data Source=" & Application.StartupPath() & "\DB_pembelianobat.mdb"

        conn = New OleDb.OleDbConnection(str)
        Try
            conn.Open()
            If conn.State = ConnectionState.Closed Then
                MsgBox("Data gagal terhubung")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub exec(ByVal query As String) 'untuk insert, update, delete
        Try
            open()
            cmd = New OleDb.OleDbCommand(query, conn)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            close()
        End Try
    End Sub

    'untuk ambil data 
    Function getList(ByVal query As String) As DataTable
        Dim dt As New DataTable

        Try
            open()
            adp = New OleDb.OleDbDataAdapter(query, conn)
            adp.Fill(dt)

            Return dt
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            close()
        End Try

        Return Nothing
    End Function

    Function getListID(ByVal table As String, ByVal column As String) As DataTable
        Dim dt As New DataTable

        Try
            open()
            sql = "select * from " & table & " order by " & column & " desc"
            adp = New OleDb.OleDbDataAdapter(sql, conn)
            adp.Fill(dt)

            Return dt
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            close()
        End Try

        Return Nothing
    End Function

    Sub close()
        conn.Close()
    End Sub
End Module
