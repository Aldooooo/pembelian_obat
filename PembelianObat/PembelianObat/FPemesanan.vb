Imports System.Threading.Tasks

Public Class FPemesanan
    Dim dtpemesanan As DataTable

    Private Sub FPemesanan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call loadSupplier()
        initPemesanan()
    End Sub

    Async Function loadSupplier() As Threading.Tasks.Task
     
        MProgress.showProgress(ProgressBar1)

        Dim sql As String = "select id_distributor, nama_industri, alamat, telepon from distributor"

        'ambil data table
        dtpemesanan = Await Task(Of DataTable).Factory.StartNew(Function() MKoneksi.getList(sql))

        cb_nosp.DataSource = dtpemesanan
        cb_nosp.DisplayMember = "nama_industri"
        cb_kodedistributor.ValueMember = "id_distributor"

        cb_kodedistributor(Nothing, Nothing)

        MProgress.hideProgress(ProgressBar1)
    End Function

    Sub initPemesanan()
        With ListView1
            .View = View.Details
            .GridLines = True
            .FullRowSelect = True
            .Columns.Clear()
            .Columns.Add("IDBarang", 120, HorizontalAlignment.Left)
            .Columns.Add("Nama", 200, HorizontalAlignment.Left)
            .Columns.Add("Qty", 70, HorizontalAlignment.Right)
            .Columns.Add("Harga", 120, HorizontalAlignment.Right)
            .Columns.Add("Jumlah", 120, HorizontalAlignment.Right)
        End With
    End Sub
End Class