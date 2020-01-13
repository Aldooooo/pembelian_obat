Imports System.Threading.Tasks
Public Class FDistributor
    Dim lst As ListViewItem
    Dim tempID As Integer

    Private Sub Distributor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call loadGrid(Nothing)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql As String

        If tempID = 0 Then
            sql = "insert into distributor (nama_industri, alamat, telepon) " &
            "values ('" & tb_nama.Text.Trim & "', '" & tb_alamat.Text.Trim & "' , '" & tb_telepon.Text.Trim & "')"
        Else
            sql = "update distributor set nama_industri = '" & tb_nama.Text.Trim & "', " &
                "alamat = '" & tb_alamat.Text.Trim & "', telepon = '" & tb_telepon.Text.Trim & "' " &
                "where kode_distributor = " & tempID
        End If

        MProgress.showProgress(ProgressBar1)
        Dim myTask = Task.Factory.StartNew(Sub() MKoneksi.exec(sql))
        Task.WaitAll(myTask) 'menunggu hingga selesai
        MProgress.hideProgress(ProgressBar1)

        kosong()
        Call loadGrid(Nothing)
    End Sub

    Private Sub kosong()
        tempID = 0
        tb_nama.Text = Nothing
        tb_alamat.Text = Nothing
        tb_telepon.Text = Nothing
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sql As String = "delete from distributor where kode_distributor = " & tempID
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

    Async Function loadGrid(ByVal cari As String) As Task
        MProgress.showProgress(ProgressBar1)

        Dim sql As String

        If cari = Nothing Then
            sql = "select * from distributor"
        Else
            sql = "select * from distributor where nama_industri like '%" & cari & "%' " &
                    "or alamat like '%" & cari & "%' or telepon like '%" & cari & "%'"
        End If

        Dim dt As DataTable = Await Task(Of DataTable).Factory.StartNew(Function() MKoneksi.getList(sql))

        ListView1.Items.Clear()

        For Each dr As DataRow In dt.Rows
            lst = ListView1.Items.Add(dr(0))
            lst.SubItems.Add(dr(1))
            lst.SubItems.Add(dr(2))
            lst.SubItems.Add(dr(3))
        Next

        tempID = 0
        MProgress.hideProgress(ProgressBar1)
    End Function

    Private Sub ListView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseDoubleClick
        With ListView1
            tempID = .SelectedItems.Item(0).Text
            tb_nama.Text = .SelectedItems.Item(0).SubItems(1).Text
            tb_alamat.Text = .SelectedItems.Item(0).SubItems(2).Text
            tb_telepon.Text = .SelectedItems.Item(0).SubItems(3).Text
        End With
    End Sub
End Class