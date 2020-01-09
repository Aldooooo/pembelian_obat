Public Class FMenu

    Private Sub KeluarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KeluarToolStripMenuItem.Click
        End
    End Sub

    Private Sub PenggunaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PenggunaToolStripMenuItem.Click
        FPengguna.Show()
        FPengguna.MdiParent = Me
    End Sub
End Class
