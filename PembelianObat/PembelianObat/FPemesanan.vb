Imports System.Threading.Tasks
Public Class FPemesanan
    Dim dtDistrib As DataTable
    Dim tempID As Integer



    Private Sub FPemesanan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call loadDistri()
        initPemesanan()
    End Sub

    Async Function loadDistri() As Threading.Tasks.Task
        'ambil data supplier dan tampilkan dalam bentuk key - value 
        'seperti <option value="xxx">yyy</option> pada HTML
        MProgress.showProgress(ProgressBar1)

        Dim sql As String = "select kode_distributor, nama_industri, alamat, telepon from distributor"

        'ambil data table
        dtDistrib = Await Task(Of DataTable).Factory.StartNew(Function() MKoneksi.getList(sql))

        ComboBox2.DataSource = dtDistrib
        ComboBox2.DisplayMember = "nama_industri,"
        ComboBox2.ValueMember = "kode_distributor"

        ComboBox2_SelectedIndexChanged(Nothing, Nothing)

        MProgress.hideProgress(ProgressBar1)
    End Function
    Sub initPemesanan()
        With ListView1
            .View = View.Details
            .GridLines = True
            .FullRowSelect = True
            .Columns.Clear()
            .Columns.Add("ID Obat", 120, HorizontalAlignment.Left)
            .Columns.Add("Nama", 200, HorizontalAlignment.Left)
            .Columns.Add("Qty", 70, HorizontalAlignment.Right)
        End With
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim sid As String = ComboBox2.SelectedValue.ToString

        'ambil alamat yang tertapung pada datatable 
        Try
            Dim row As DataRow() = dtDistrib.Select("kode_distributor = " & sid)

            TextBox1.Text = row(0)(2) & vbCrLf & row(0)(3) 'vbcrlf itu buat enter
        Catch ex As Exception
            Console.Write(ex.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FPemesananObat.ShowDialog()
    End Sub

    Private Sub ListView1_MouseDown(sender As Object, e As MouseEventArgs) Handles ListView1.MouseDown
        If ListView1.Items.Count = 0 Then Exit Sub

        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenuStrip1.Show(MousePosition.X, MousePosition.Y)
        End If
    End Sub

    Private Sub HapusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HapusToolStripMenuItem.Click
        ListView1.Items.Remove(ListView1.SelectedItems(0))

    End Sub

    Private Sub UbahToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UbahToolStripMenuItem.Click
        With FPemesananObat
            .ComboBox1.SelectedValue = ListView1.SelectedItems(0).Text
            .TextBox1.Text = ListView1.SelectedItems(0).SubItems(2).Text
            .Show()
        End With

        ListView1.Items.Remove(ListView1.SelectedItems(0))

    End Sub

    Private Async Sub bt_simpan_Click(sender As Object, e As EventArgs) Handles bt_simpan.Click
        If bt_simpan.Text = "Simpan" Then
            sql = "insert into pemesanan_header (tanggal, nama, jabatan, nama_apotek, alamat, kode_distributor) values ( " &
            "'" & DateTimePicker1.Value & "','" & TextBox2.Text & "'," &
            "'" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox5.Text & "'," &
            "'" & ComboBox2.SelectedValue.ToString & "')"
            MProgress.showProgress(ProgressBar1)
            Dim myTask = Task.Factory.StartNew(Sub() MKoneksi.exec(sql))
            Task.WaitAll(myTask)

            Dim dt As DataTable = Await Task(Of DataTable).Factory.StartNew(
                Function() MKoneksi.getListID("pemesanan_header", "no_sp"))
            Dim id_beli As String = dt.Rows(0).Item(0).ToString

            For i As Integer = 0 To ListView1.Items.Count - 1
                sql = "insert into detail_pemesanan values (" & id_beli & "," &
                    "" & ListView1.Items(i).Text & ", " &
                    "" & ListView1.Items(i).SubItems(2).Text & ");"
                myTask = Task.Factory.StartNew(Sub() MKoneksi.exec(sql))
                Task.WaitAll(myTask)

            Next

            MProgress.hideProgress(ProgressBar1)

            MsgBox("Data berhasil disimpan", , "Pesan")

        ElseIf bt_simpan.Text = "Perbarui" Then
        End If
        iniform()
    End Sub
    Sub iniform()
        ListView1.Items.Clear()
        ComboBox2.SelectedIndex = 0
        TextBox1.Text = "0"
        TextBox2.Text = "0"
        TextBox6.Text = "0"
        TextBox7.Text = "0"
        TextBox5.Text = Nothing
        DateTimePicker1.Value = Date.Now
    End Sub

    Private Async Sub bt_hapus_Click(sender As Object, e As EventArgs) Handles bt_hapus.Click
        Dim sql As String = "delete from pemesanan_header where no_sp = "
        MProgress.showProgress(ProgressBar1)
        Dim myTask = Task.Factory.StartNew(Sub() MKoneksi.exec(sql))
        Task.WaitAll(myTask) 'menunggu hingga selesai
        Dim dt As DataTable = Await Task(Of DataTable).Factory.StartNew(
                Function() MKoneksi.getListID("pemesanan_header", "no_sp"))
        Dim no_sp As String = dt.Rows(0).Item(0).ToString

        For i As Integer = 0 To ListView1.Items.Count - 1
            sql = "delete from detail_pemesanan where no_sp = " & no_sp & ""
            myTask = Task.Factory.StartNew(Sub() MKoneksi.exec(sql))
            Task.WaitAll(myTask) 'menunggu hingga selesai

        Next
        MProgress.hideProgress(ProgressBar1)
        iniform()


    End Sub
End Class