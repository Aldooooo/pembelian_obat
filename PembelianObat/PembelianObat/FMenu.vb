Public Class FMenu

    Private Sub KeluarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KeluarToolStripMenuItem.Click
        End
    End Sub

    Private Sub PenggunaToolStripMenuItem_Click(sender As Object, e As EventArgs)
        FPengguna.Show()
        FPengguna.MdiParent = Me
    End Sub

    Private Sub SupplierToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupplierToolStripMenuItem.Click
        FDistributor.Show()
        FDistributor.MdiParent = Me
    End Sub

    Private Sub PembelianToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PembelianToolStripMenuItem.Click
        FPemesanan.Show()
        FPemesanan.MdiParent = Me
    End Sub

    Private Sub PembayaranToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PembayaranToolStripMenuItem.Click
        FPembayaran.Show()
        FPembayaran.MdiParent = Me
    End Sub

    Private Sub BarangToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BarangToolStripMenuItem.Click
        FObat.Show()
        FObat.MdiParent = Me
    End Sub

    Private Sub BarangToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles BarangToolStripMenuItem2.Click
        FCObat.Show()
        FCObat.MdiParent = Me
    End Sub

    Private Sub PembeliToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PembeliToolStripMenuItem.Click
        FCPemesanan.Show()
        FCPemesanan.MdiParent = Me
    End Sub

    Private Sub SupplierToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles SupplierToolStripMenuItem2.Click
        FCPembayaran.Show()
        FCPembayaran.MdiParent = Me
    End Sub

    Private Sub PenggunaToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles PenggunaToolStripMenuItem2.Click
        FCDistributor.Show()
        FCDistributor.MdiParent = Me
    End Sub

    Private Sub PenggunaToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles PenggunaToolStripMenuItem.Click
        FPengguna.Show()
        FPengguna.MdiParent = Me
    End Sub
End Class
