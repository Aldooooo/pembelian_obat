
Imports System.Threading.Tasks
Imports System.Security.Cryptography
Imports System.Text

Public Class FPengguna

    Dim tempEmail As String
    Dim lst As ListViewItem

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql, pass As String

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

        If (tempEmail <> Nothing) Then 'lagi edit
            If pass = Nothing Then 'kalo ga masukin password baru
                sql = "update pengguna set tipe = '" & ComboBox1.Text() & "',  " & _
                        "aktif = '" & CheckBox1.CheckState & "' " & _
                        "where email = '" & tempEmail & "'"
            Else
                sql = "update pengguna set tipe = '" & ComboBox1.Text() & "',  " & _
                         "pwd = '" & pass & "', " & _
                         "aktif = '" & CheckBox1.CheckState & "' " & _
                         "where email = '" & tempEmail & "'"
            End If
        Else
            sql = "insert into pengguna (email, pwd, tipe, aktif) " & _
                "values ('" & TextBox1.Text().Trim & "' , '" & pass & "', " & _
                "'" & ComboBox1.Text() & "', '" & CheckBox1.CheckState & "')"
        End If

        MProgress.showProgress(ProgressBar1)
        Dim myTask = Task.Factory.StartNew(Sub() MKoneksi.exec(sql))
        Task.WaitAll(myTask) 'menunggu hingga selesai
        MProgress.hideProgress(ProgressBar1)

        kosong()
        Call loadGrid(Nothing)
    End Sub

    Private Sub kosong()
        tempEmail = Nothing
        TextBox1.Text = Nothing
        TextBox2.Text = Nothing
        ComboBox1.SelectedIndex = 0
        CheckBox1.Checked = False
    End Sub


    Private Sub FPengguna_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call loadGrid(Nothing)
    End Sub

    Async Function loadGrid(ByVal cari As String) As Task
        MProgress.showProgress(ProgressBar1)

        Dim sql As String

        If cari = Nothing Then
            sql = "select email, tipe, aktif from pengguna"
        Else
            sql = "select email, tipe, aktif from pengguna " & _
                    "where email like '%" & cari & "%'"
        End If

        Dim dt As DataTable = Await Task(Of DataTable).Factory.StartNew(Function() MKoneksi.getList(sql))

        ListView1.Items.Clear()
        For Each dr As DataRow In dt.Rows
            lst = ListView1.Items.Add(dr(0))
            lst.SubItems.Add(dr(1))
            lst.SubItems.Add(dr(2))
        Next

        tempEmail = Nothing
        MProgress.hideProgress(ProgressBar1)
    End Function

    Private Sub ListView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseDoubleClick
        With ListView1
            tempEmail = .SelectedItems.Item(0).Text
            TextBox1.Text = tempEmail : TextBox1.Enabled = False
            TextBox2.Text = Nothing
            ComboBox1.Text = .SelectedItems.Item(0).SubItems(1).Text
            CheckBox1.Checked = .SelectedItems.Item(0).SubItems(2).Text
        End With

        MsgBox("Passwordmu telah terenkripsi dengan baik",
               vbOKOnly + vbInformation,
               "Jangan mengisi text password, jika tak ingin mengubah")

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MsgBox("Hapus data " & tempEmail & "?", vbYesNo, "Perhatian") = MsgBoxResult.No Then Exit Sub

        If (tempEmail = Nothing) Then
            MsgBox("Tak ada data yang akan dihapus", vbOKOnly, "Perhatian")
            Exit Sub
        End If

        sql = "delete from pengguna where email = '" & TextBox1.Text().Trim & "'"

        MProgress.showProgress(ProgressBar1)
        Dim myTask = Task.Factory.StartNew(Sub() MKoneksi.exec(sql))
        Task.WaitAll(myTask) 'menunggu hingga selesai
        MProgress.hideProgress(ProgressBar1)

        kosong()
        Call loadGrid(Nothing)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Call loadGrid(TextBox3.Text.Trim)
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub ListView2_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
End Class