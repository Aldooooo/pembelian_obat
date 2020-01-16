Imports System.Threading.Tasks
Public Class FPembayaran
    Dim dtSP As DataTable
    Async Function loadSP() As Threading.Tasks.Task

        MProgress.showProgress(ProgressBar1)

        Dim sql As String = "select no_sp, tanggal, nama, jabatan, nama_apotek, alamat,kode_distributor from pemesanan_header"

        'ambil data table
        dtSP = Await Task(Of DataTable).Factory.StartNew(Function() MKoneksi.getList(sql))

        ComboBox2.DataSource = dtSP
        ComboBox2.DisplayMember = "nama"
        ComboBox2.ValueMember = "no_sp"

        ComboBox2_SelectedIndexChanged(Nothing, Nothing)

        MProgress.hideProgress(ProgressBar1)
    End Function
    Private Sub FPembayaran_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call loadSP()
        initPembayaran()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim sid As String = ComboBox2.SelectedValue.ToString

        'ambil alamat yang tertapung pada datatable 
        Try
            Dim row As DataRow() = dtSP.Select("no_sp = " & sid)

            TextBox13.Text = row(0)(6)
        Catch ex As Exception
            Console.Write(ex.ToString)
        End Try
    End Sub
    Sub initPembayaran()
        With ListView1
            .View = View.Details
            .GridLines = True
            .FullRowSelect = True
            .Columns.Clear()
            .Columns.Add("ID Obat", 120, HorizontalAlignment.Left)
            .Columns.Add("Nama", 200, HorizontalAlignment.Left)
            .Columns.Add("Qty", 70, HorizontalAlignment.Right)
            .Columns.Add("Harga", 120, HorizontalAlignment.Right)
            .Columns.Add("Jumlah", 120, HorizontalAlignment.Right)
        End With
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        hitungtotal()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FPembayaranObat.ShowDialog()
    End Sub
    Private Sub ListView1_MouseDown(sender As Object, e As MouseEventArgs) Handles ListView1.MouseDown
        If ListView1.Items.Count = 0 Then Exit Sub

        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenuStrip1.Show(MousePosition.X, MousePosition.Y)
        End If
    End Sub
    Sub hitungtotal()
        Dim subtotal, total1, total2, dp, ppn, biayakirim As Long
        For i As Integer = 0 To ListView1.Items.Count - 1
            subtotal += Val(ListView1.Items(i).SubItems(4).Text)
        Next

        dp = Val(TextBox1.Text.Trim)
        total1 = subtotal - dp
        ppn = Val(TextBox4.Text.Trim)
        biayakirim = Val(TextBox8.Text.Trim)
        total2 = total1 + ppn + biayakirim

        TextBox5.Text = subtotal : TextBox9.Text = total2 : TextBox3.Text = total1


    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        hitungtotal()
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        hitungtotal()
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged
        hitungtotal()
    End Sub

    Private Sub HapusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HapusToolStripMenuItem.Click
        ListView1.Items.Remove(ListView1.SelectedItems(0))
        hitungtotal()
    End Sub

    Private Sub UbahToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UbahToolStripMenuItem.Click
        With FPembayaranObat
            .ComboBox1.SelectedValue = ListView1.SelectedItems(0).Text
            .TextBox1.Text = ListView1.SelectedItems(0).SubItems(3).Text
            .TextBox2.Text = ListView1.SelectedItems(0).SubItems(2).Text
            .Label4.Text = ListView1.SelectedItems(0).SubItems(4).Text
            .Show()
        End With

        ListView1.Items.Remove(ListView1.SelectedItems(0))
        hitungtotal()
    End Sub

    Private Async Sub bt_simpan_Click(sender As Object, e As EventArgs) Handles bt_simpan.Click
        If bt_simpan.Text = "Simpan" Then
            sql = "insert into pembayaran_header (tanggal, surat_jalan, cara_bayar, jatuh_tempo, total_1, potongan, total_2, ppn, biaya_kirim, jumlah_tagihan, penerima, ket, no_sp, kode_distributor) values ( " &
            "'" & DateTimePicker1.Value & "'," & TextBox2.Text & ",'" & TextBox6.Text & "','" & DateTimePicker2.Value & "'," &
            "" & TextBox5.Text & "," & TextBox1.Text & "," & TextBox3.Text & "," & TextBox4.Text & "," & TextBox8.Text & "," & TextBox9.Text & ",'" & TextBox10.Text & "','" & TextBox11.Text & "'," &
            "'" & ComboBox2.SelectedValue.ToString & "'," & TextBox13.Text & ")"
            MProgress.showProgress(ProgressBar1)
            Dim myTask = Task.Factory.StartNew(Sub() MKoneksi.exec(sql))
            Task.WaitAll(myTask)

            Dim dt As DataTable = Await Task(Of DataTable).Factory.StartNew(
                Function() MKoneksi.getListID("pembayaran_header", "nomor"))
            Dim id_beli As String = dt.Rows(0).Item(0).ToString

            For i As Integer = 0 To ListView1.Items.Count - 1
                sql = "insert into detail_pembayaran values (" & id_beli & "," &
                    "" & ListView1.Items(i).SubItems(2).Text & ", " &
                    "" & ListView1.Items(i).SubItems(3).Text & ", " &
                    "" & ListView1.Items(i).SubItems(4).Text & ", " &
                     "" & ListView1.Items(i).Text & ");"

                myTask = Task.Factory.StartNew(Sub() MKoneksi.exec(sql))
                Task.WaitAll(myTask)

            Next

            MProgress.hideProgress(ProgressBar1)

            MsgBox("Data berhasil disimpan", , "Pesan")

        ElseIf bt_simpan.Text = "Perbarui" Then
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        hitungtotal()
    End Sub

End Class