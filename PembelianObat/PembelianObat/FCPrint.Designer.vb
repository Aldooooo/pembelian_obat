<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FCPrint
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cb_sampai = New System.Windows.Forms.ComboBox()
        Me.cb_dari = New System.Windows.Forms.ComboBox()
        Me.cb_pilih = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.cb_sampai)
        Me.Panel1.Controls.Add(Me.cb_dari)
        Me.Panel1.Controls.Add(Me.cb_pilih)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(4, 4)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1032, 146)
        Me.Panel1.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(471, 107)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 28)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Submit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cb_sampai
        '
        Me.cb_sampai.FormattingEnabled = True
        Me.cb_sampai.Location = New System.Drawing.Point(104, 103)
        Me.cb_sampai.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cb_sampai.Name = "cb_sampai"
        Me.cb_sampai.Size = New System.Drawing.Size(291, 24)
        Me.cb_sampai.TabIndex = 5
        '
        'cb_dari
        '
        Me.cb_dari.FormattingEnabled = True
        Me.cb_dari.Location = New System.Drawing.Point(104, 60)
        Me.cb_dari.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cb_dari.Name = "cb_dari"
        Me.cb_dari.Size = New System.Drawing.Size(291, 24)
        Me.cb_dari.TabIndex = 4
        '
        'cb_pilih
        '
        Me.cb_pilih.FormattingEnabled = True
        Me.cb_pilih.Items.AddRange(New Object() {"Barang", "Supplier", "Pengguna", "Pembelian"})
        Me.cb_pilih.Location = New System.Drawing.Point(104, 12)
        Me.cb_pilih.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cb_pilih.Name = "cb_pilih"
        Me.cb_pilih.Size = New System.Drawing.Size(160, 24)
        Me.cb_pilih.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 106)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Sampai"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 60)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Dari"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 16)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Pilih"
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(4, 146)
        Me.CrystalReportViewer1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1031, 509)
        Me.CrystalReportViewer1.TabIndex = 4
        Me.CrystalReportViewer1.ToolPanelWidth = 267
        '
        'FCPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1039, 654)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FCPrint"
        Me.Text = "FCPrint"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cb_sampai As System.Windows.Forms.ComboBox
    Friend WithEvents cb_dari As System.Windows.Forms.ComboBox
    Friend WithEvents cb_pilih As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
