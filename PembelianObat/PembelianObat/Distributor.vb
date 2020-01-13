Imports System.Threading.Tasks
Public Class Distributor
    Dim lst As ListViewItem
    Dim tempID As Integer

    Private Sub Distributor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call loadGrid(Nothing)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql As String

        If tempID = 0 Then
            sql = "insert into distributor (kode_distributor, nama_industri, alamat, telepon) " & _
            "values ('" & cb_kodedistributor.Text & "' , '" & tb_nama.Text.Trim & "', " & _
            "'" & tb_alamat.Text.Trim & "' , '" & tb_telepon.Text.Trim & "')"
        Else
            sql = "update distributor set nama_industri = '" & tb_nama.Text.Trim & "', " & _
                "alamat = '" & tb_alamat.Text.Trim & "', telepon = '" & tb_telepon.Text.Trim & "' " & _
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
        cb_kodedistributor.Text = Nothing
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
            sql = "select * from distributor where nama_industri like '%" & cari & "%' " & _
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
End Class