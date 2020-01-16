Imports System.Threading.Tasks
Public Class FObat
    Dim lst As ListViewItem
    Dim tempID As Integer
    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub FObat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call loadGrid(Nothing)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql As String

        If tempID = 0 Then
            sql = "insert into obat (nama_obat, zat_aktif,bentuk_kekuatan, satuan) " &
            "values ( '" & TextBox2.Text.Trim & "' , '" & TextBox4.Text.Trim & "','" & TextBox5.Text.Trim & "','" & TextBox6.Text.Trim & "')"
        Else
            sql = "update obat set nama_obat = '" & TextBox2.Text.Trim & "', " &
                "zat_aktif = '" & TextBox4.Text.Trim & "', bentuk_kekuatan = '" & TextBox5.Text.Trim & "' , satuan = '" & TextBox6.Text.Trim & "'" &
                "where kode_obat = " & tempID
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
        TextBox2.Text = Nothing
        TextBox4.Text = Nothing
        TextBox5.Text = Nothing
        TextBox6.Text = Nothing
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sql As String = "delete from obat where kode_obat = " & tempID
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
            sql = "select * from obat"
        Else
            sql = "select * from obat where nama_obat like '%" & cari & "%' " &
                    "or zat_aktif like '%" & cari & "%' or bentuk_kekuatan like '%" & cari & "%' or satuan like '%" & cari & "%'"
        End If

        Dim dt As DataTable = Await Task(Of DataTable).Factory.StartNew(Function() MKoneksi.getList(sql))

        ListView1.Items.Clear()

        For Each dr As DataRow In dt.Rows
            lst = ListView1.Items.Add(dr(0))
            lst.SubItems.Add(dr(1))
            lst.SubItems.Add(dr(2))
            lst.SubItems.Add(dr(3))
            lst.SubItems.Add(dr(4))
        Next

        tempID = 0
        MProgress.hideProgress(ProgressBar1)
    End Function

    Private Sub ListView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseDoubleClick
        With ListView1
            tempID = .SelectedItems.Item(0).Text
            TextBox2.Text = .SelectedItems.Item(0).SubItems(1).Text
            TextBox4.Text = .SelectedItems.Item(0).SubItems(2).Text
            TextBox5.Text = .SelectedItems.Item(0).SubItems(3).Text
            TextBox6.Text = .SelectedItems.Item(0).SubItems(4).Text
        End With
    End Sub
End Class