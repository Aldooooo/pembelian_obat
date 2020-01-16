Public Class FPemesananObat
    Dim dtObat As DataTable
    Private Sub FPemesananObat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call loadObat()
    End Sub
    Async Function loadObat() As Threading.Tasks.Task
        Dim sql As String = "select kode_obat, nama_obat from obat"

        MProgress.showProgress(ProgressBar1)

        'ambil data table
        dtObat = Await Task(Of DataTable).Factory.StartNew(Function() MKoneksi.getList(sql))

        ComboBox1.DataSource = dtObat
        ComboBox1.DisplayMember = "nama_obat"
        ComboBox1.ValueMember = "kode_obat"

        ComboBox1_SelectedIndexChanged(Nothing, Nothing)

        MProgress.hideProgress(ProgressBar1)
    End Function

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim lst As ListViewItem
        With FPemesanan.ListView1
            lst = .Items.Add(ComboBox1.SelectedValue.ToString)
            lst.SubItems.Add(ComboBox1.Text)
            lst.SubItems.Add(TextBox1.Text)
        End With


    End Sub

    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs) Handles ProgressBar1.Click

    End Sub
End Class