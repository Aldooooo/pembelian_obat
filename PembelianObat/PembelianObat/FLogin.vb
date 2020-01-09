Imports System.Threading.Tasks
Imports System.Security.Cryptography
Imports System.Text
Public Class FLogin

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = Nothing
        TextBox2.Text = Nothing
    End Sub
    Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text.Length = 0 Or TextBox2.Text.Length = 0 Then Exit Sub

        Dim pass As String
        If TextBox2.Text.Trim.Length > 0 Then
            Using md5Hash As MD5 = MD5.Create()
                pass = MHash.GetMd5Hash(md5Hash, TextBox2.Text.Trim)

                If MHash.VerifyMd5Hash(md5Hash, TextBox2.Text.Trim, pass) Then
                    Console.WriteLine("Hash sama")
                Else
                    Console.WriteLine("Hash berbeda")
                End If
            End Using
        Else
            pass = Nothing
        End If

        sql = "select * from pengguna where email = '" & TextBox1.Text.Trim & "' and " & _
                "pwd = '" & pass & "' and aktif = true"

        MProgress.showProgress(ProgressBar1)
        Dim dt As DataTable = Await Task(Of DataTable).Factory.StartNew(Function() MKoneksi.getList(sql))
        MProgress.hideProgress(ProgressBar1)

        If dt.Rows.Count > 0 Then
            FMenu.Show()
            Me.Hide()
        Else
            MsgBox("Data tak ditemukan", vbOKOnly + vbExclamation, "Pesan")
        End If
    End Sub
End Class