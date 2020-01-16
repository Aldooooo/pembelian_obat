Imports System.Threading.Tasks
Public Class FPembayaranObat
    Dim dtObat As DataTable
    Private Sub FPembayaranObat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call loadObat()
    End Sub
    Sub hitung()
        Label4.Text = Val(TextBox1.Text.Trim) * Val(TextBox2.Text.Trim)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        hitung()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        hitung()
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
        With FPembayaran.ListView1
            lst = .Items.Add(ComboBox1.SelectedValue.ToString)
            lst.SubItems.Add(ComboBox1.Text)
            lst.SubItems.Add(TextBox1.Text)
            lst.SubItems.Add(TextBox2.Text)
            lst.SubItems.Add(Label4.Text)
        End With

        FPembayaran.hitungtotal()
    End Sub
End Class