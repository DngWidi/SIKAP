<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uf_kalenderlibur
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.pnlContext = New Guna.UI2.WinForms.Guna2Panel()
        Me.pnlButton = New Guna.UI2.WinForms.Guna2Panel()
        Me.pnlPage = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlToolbar = New Guna.UI2.WinForms.Guna2Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.flpKalender = New System.Windows.Forms.FlowLayoutPanel()
        Me.bHapus = New Guna.UI2.WinForms.Guna2Button()
        Me.bNext = New Guna.UI2.WinForms.Guna2Button()
        Me.bPrev = New Guna.UI2.WinForms.Guna2Button()
        Me.bSyncApi = New Guna.UI2.WinForms.Guna2Button()
        Me.bEdit = New Guna.UI2.WinForms.Guna2Button()
        Me.bTambah = New Guna.UI2.WinForms.Guna2Button()
        Me.bRefresh = New Guna.UI2.WinForms.Guna2Button()
        Me.bCari = New Guna.UI2.WinForms.Guna2Button()
        Me.tPencarian = New Guna.UI2.WinForms.Guna2TextBox()
        Me.pnlContext.SuspendLayout()
        Me.pnlButton.SuspendLayout()
        Me.pnlPage.SuspendLayout()
        Me.pnlToolbar.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlContext
        '
        Me.pnlContext.AutoScroll = True
        Me.pnlContext.Controls.Add(Me.pnlButton)
        Me.pnlContext.Controls.Add(Me.Label1)
        Me.pnlContext.Controls.Add(Me.pnlToolbar)
        Me.pnlContext.Controls.Add(Me.Label2)
        Me.pnlContext.Controls.Add(Me.Label3)
        Me.pnlContext.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContext.Location = New System.Drawing.Point(0, 0)
        Me.pnlContext.Name = "pnlContext"
        Me.pnlContext.ShadowDecoration.Parent = Me.pnlContext
        Me.pnlContext.Size = New System.Drawing.Size(636, 527)
        Me.pnlContext.TabIndex = 5
        '
        'pnlButton
        '
        Me.pnlButton.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.pnlButton.BorderColor = System.Drawing.Color.Silver
        Me.pnlButton.BorderRadius = 6
        Me.pnlButton.BorderThickness = 1
        Me.pnlButton.Controls.Add(Me.bHapus)
        Me.pnlButton.Controls.Add(Me.flpKalender)
        Me.pnlButton.Controls.Add(Me.pnlPage)
        Me.pnlButton.Controls.Add(Me.bSyncApi)
        Me.pnlButton.Controls.Add(Me.bEdit)
        Me.pnlButton.Controls.Add(Me.bTambah)
        Me.pnlButton.Location = New System.Drawing.Point(11, 162)
        Me.pnlButton.Name = "pnlButton"
        Me.pnlButton.ShadowDecoration.Parent = Me.pnlButton
        Me.pnlButton.Size = New System.Drawing.Size(608, 362)
        Me.pnlButton.TabIndex = 4
        '
        'pnlPage
        '
        Me.pnlPage.BorderColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.pnlPage.BorderThickness = 1
        Me.pnlPage.Controls.Add(Me.bNext)
        Me.pnlPage.Controls.Add(Me.bPrev)
        Me.pnlPage.Controls.Add(Me.lblInfo)
        Me.pnlPage.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPage.Location = New System.Drawing.Point(0, 316)
        Me.pnlPage.Name = "pnlPage"
        Me.pnlPage.ShadowDecoration.Parent = Me.pnlPage
        Me.pnlPage.Size = New System.Drawing.Size(608, 46)
        Me.pnlPage.TabIndex = 4
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblInfo.Location = New System.Drawing.Point(11, 18)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(177, 15)
        Me.lblInfo.TabIndex = 0
        Me.lblInfo.Text = "Menampilkan 1-10 dari 245 Data"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(8, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(209, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Home   >    Master Data   >  Kalender Libur"
        '
        'pnlToolbar
        '
        Me.pnlToolbar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.pnlToolbar.BorderColor = System.Drawing.Color.Gainsboro
        Me.pnlToolbar.BorderRadius = 6
        Me.pnlToolbar.BorderThickness = 1
        Me.pnlToolbar.Controls.Add(Me.bRefresh)
        Me.pnlToolbar.Controls.Add(Me.bCari)
        Me.pnlToolbar.Controls.Add(Me.tPencarian)
        Me.pnlToolbar.Controls.Add(Me.Label4)
        Me.pnlToolbar.Location = New System.Drawing.Point(11, 82)
        Me.pnlToolbar.Name = "pnlToolbar"
        Me.pnlToolbar.ShadowDecoration.Parent = Me.pnlToolbar
        Me.pnlToolbar.Size = New System.Drawing.Size(608, 74)
        Me.pnlToolbar.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Yu Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Cari Kalender Libur"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(14, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(208, 30)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Data Kalender Libur"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(106, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(119, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(16, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(276, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Kelola seluruh data kalender libur perusahaan"
        '
        'flpKalender
        '
        Me.flpKalender.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flpKalender.BackColor = System.Drawing.Color.White
        Me.flpKalender.Location = New System.Drawing.Point(14, 52)
        Me.flpKalender.Name = "flpKalender"
        Me.flpKalender.Size = New System.Drawing.Size(577, 258)
        Me.flpKalender.TabIndex = 5
        '
        'bHapus
        '
        Me.bHapus.BorderColor = System.Drawing.Color.Gainsboro
        Me.bHapus.BorderRadius = 5
        Me.bHapus.BorderThickness = 1
        Me.bHapus.CheckedState.Parent = Me.bHapus
        Me.bHapus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bHapus.CustomImages.Parent = Me.bHapus
        Me.bHapus.FillColor = System.Drawing.Color.Transparent
        Me.bHapus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bHapus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.bHapus.HoverState.Parent = Me.bHapus
        Me.bHapus.Image = Global.SIKAP.My.Resources.Resources.Delete
        Me.bHapus.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.bHapus.ImageSize = New System.Drawing.Size(18, 18)
        Me.bHapus.Location = New System.Drawing.Point(198, 14)
        Me.bHapus.Name = "bHapus"
        Me.bHapus.ShadowDecoration.Parent = Me.bHapus
        Me.bHapus.Size = New System.Drawing.Size(83, 32)
        Me.bHapus.TabIndex = 6
        Me.bHapus.Text = "Hapus"
        Me.bHapus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bNext
        '
        Me.bNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bNext.BorderColor = System.Drawing.Color.Gray
        Me.bNext.BorderRadius = 6
        Me.bNext.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.bNext.BorderThickness = 1
        Me.bNext.CheckedState.Parent = Me.bNext
        Me.bNext.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bNext.CustomImages.Parent = Me.bNext
        Me.bNext.FillColor = System.Drawing.Color.Transparent
        Me.bNext.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bNext.ForeColor = System.Drawing.Color.Black
        Me.bNext.HoverState.Parent = Me.bNext
        Me.bNext.Image = Global.SIKAP.My.Resources.Resources._Next
        Me.bNext.ImageSize = New System.Drawing.Size(18, 18)
        Me.bNext.Location = New System.Drawing.Point(526, 13)
        Me.bNext.Name = "bNext"
        Me.bNext.ShadowDecoration.Parent = Me.bNext
        Me.bNext.Size = New System.Drawing.Size(79, 30)
        Me.bNext.TabIndex = 5
        '
        'bPrev
        '
        Me.bPrev.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bPrev.BorderColor = System.Drawing.Color.Gray
        Me.bPrev.BorderRadius = 6
        Me.bPrev.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.bPrev.BorderThickness = 1
        Me.bPrev.CheckedState.Parent = Me.bPrev
        Me.bPrev.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bPrev.CustomImages.Parent = Me.bPrev
        Me.bPrev.FillColor = System.Drawing.Color.Transparent
        Me.bPrev.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bPrev.ForeColor = System.Drawing.Color.Black
        Me.bPrev.HoverState.Parent = Me.bPrev
        Me.bPrev.Image = Global.SIKAP.My.Resources.Resources.Prev
        Me.bPrev.ImageSize = New System.Drawing.Size(18, 18)
        Me.bPrev.Location = New System.Drawing.Point(441, 13)
        Me.bPrev.Name = "bPrev"
        Me.bPrev.ShadowDecoration.Parent = Me.bPrev
        Me.bPrev.Size = New System.Drawing.Size(79, 30)
        Me.bPrev.TabIndex = 4
        '
        'bSyncApi
        '
        Me.bSyncApi.BorderColor = System.Drawing.Color.Gainsboro
        Me.bSyncApi.BorderRadius = 5
        Me.bSyncApi.BorderThickness = 1
        Me.bSyncApi.CheckedState.Parent = Me.bSyncApi
        Me.bSyncApi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bSyncApi.CustomImages.Parent = Me.bSyncApi
        Me.bSyncApi.FillColor = System.Drawing.Color.White
        Me.bSyncApi.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSyncApi.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.bSyncApi.HoverState.Parent = Me.bSyncApi
        Me.bSyncApi.Image = Global.SIKAP.My.Resources.Resources.Sinkronisasi
        Me.bSyncApi.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.bSyncApi.ImageSize = New System.Drawing.Size(18, 18)
        Me.bSyncApi.Location = New System.Drawing.Point(426, 14)
        Me.bSyncApi.Name = "bSyncApi"
        Me.bSyncApi.ShadowDecoration.Parent = Me.bSyncApi
        Me.bSyncApi.Size = New System.Drawing.Size(165, 32)
        Me.bSyncApi.TabIndex = 2
        Me.bSyncApi.Text = "Sinkronisasi Hari Libur"
        Me.bSyncApi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bEdit
        '
        Me.bEdit.BorderColor = System.Drawing.Color.Gainsboro
        Me.bEdit.BorderRadius = 5
        Me.bEdit.BorderThickness = 1
        Me.bEdit.CheckedState.Parent = Me.bEdit
        Me.bEdit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bEdit.CustomImages.Parent = Me.bEdit
        Me.bEdit.FillColor = System.Drawing.Color.Transparent
        Me.bEdit.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bEdit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.bEdit.HoverState.Parent = Me.bEdit
        Me.bEdit.Image = Global.SIKAP.My.Resources.Resources.Edit
        Me.bEdit.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.bEdit.ImageSize = New System.Drawing.Size(18, 18)
        Me.bEdit.Location = New System.Drawing.Point(118, 14)
        Me.bEdit.Name = "bEdit"
        Me.bEdit.ShadowDecoration.Parent = Me.bEdit
        Me.bEdit.Size = New System.Drawing.Size(75, 32)
        Me.bEdit.TabIndex = 1
        Me.bEdit.Text = "Edit"
        Me.bEdit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bTambah
        '
        Me.bTambah.BorderColor = System.Drawing.Color.Gainsboro
        Me.bTambah.BorderRadius = 5
        Me.bTambah.BorderThickness = 1
        Me.bTambah.CheckedState.Parent = Me.bTambah
        Me.bTambah.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bTambah.CustomImages.Parent = Me.bTambah
        Me.bTambah.FillColor = System.Drawing.Color.Transparent
        Me.bTambah.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bTambah.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.bTambah.HoverState.Parent = Me.bTambah
        Me.bTambah.Image = Global.SIKAP.My.Resources.Resources.Add
        Me.bTambah.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.bTambah.ImageSize = New System.Drawing.Size(18, 18)
        Me.bTambah.Location = New System.Drawing.Point(14, 14)
        Me.bTambah.Name = "bTambah"
        Me.bTambah.ShadowDecoration.Parent = Me.bTambah
        Me.bTambah.Size = New System.Drawing.Size(98, 32)
        Me.bTambah.TabIndex = 0
        Me.bTambah.Text = "Tambah"
        Me.bTambah.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bRefresh
        '
        Me.bRefresh.BorderColor = System.Drawing.Color.Gray
        Me.bRefresh.BorderRadius = 6
        Me.bRefresh.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.bRefresh.BorderThickness = 1
        Me.bRefresh.CheckedState.Parent = Me.bRefresh
        Me.bRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bRefresh.CustomImages.Parent = Me.bRefresh
        Me.bRefresh.FillColor = System.Drawing.Color.Transparent
        Me.bRefresh.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bRefresh.ForeColor = System.Drawing.Color.Black
        Me.bRefresh.HoverState.Parent = Me.bRefresh
        Me.bRefresh.Image = Global.SIKAP.My.Resources.Resources.Reset
        Me.bRefresh.ImageSize = New System.Drawing.Size(18, 18)
        Me.bRefresh.Location = New System.Drawing.Point(505, 27)
        Me.bRefresh.Name = "bRefresh"
        Me.bRefresh.ShadowDecoration.Parent = Me.bRefresh
        Me.bRefresh.Size = New System.Drawing.Size(86, 30)
        Me.bRefresh.TabIndex = 3
        Me.bRefresh.Text = "Reset"
        '
        'bCari
        '
        Me.bCari.BorderRadius = 6
        Me.bCari.CheckedState.Parent = Me.bCari
        Me.bCari.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bCari.CustomImages.Parent = Me.bCari
        Me.bCari.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.bCari.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bCari.ForeColor = System.Drawing.Color.White
        Me.bCari.HoverState.Parent = Me.bCari
        Me.bCari.Image = Global.SIKAP.My.Resources.Resources.SearchW
        Me.bCari.ImageSize = New System.Drawing.Size(18, 18)
        Me.bCari.Location = New System.Drawing.Point(413, 27)
        Me.bCari.Name = "bCari"
        Me.bCari.ShadowDecoration.Parent = Me.bCari
        Me.bCari.Size = New System.Drawing.Size(86, 30)
        Me.bCari.TabIndex = 2
        Me.bCari.Text = "Cari"
        '
        'tPencarian
        '
        Me.tPencarian.BorderRadius = 6
        Me.tPencarian.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tPencarian.DefaultText = ""
        Me.tPencarian.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.tPencarian.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.tPencarian.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.tPencarian.DisabledState.Parent = Me.tPencarian
        Me.tPencarian.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.tPencarian.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tPencarian.FocusedState.Parent = Me.tPencarian
        Me.tPencarian.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tPencarian.HoverState.Parent = Me.tPencarian
        Me.tPencarian.IconRight = Global.SIKAP.My.Resources.Resources.Search
        Me.tPencarian.IconRightSize = New System.Drawing.Size(18, 18)
        Me.tPencarian.Location = New System.Drawing.Point(14, 27)
        Me.tPencarian.Name = "tPencarian"
        Me.tPencarian.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.tPencarian.PlaceholderText = "Ketik tanggal "
        Me.tPencarian.SelectedText = ""
        Me.tPencarian.ShadowDecoration.Parent = Me.tPencarian
        Me.tPencarian.Size = New System.Drawing.Size(229, 30)
        Me.tPencarian.TabIndex = 1
        '
        'uf_kalenderlibur
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlContext)
        Me.Name = "uf_kalenderlibur"
        Me.Size = New System.Drawing.Size(636, 527)
        Me.pnlContext.ResumeLayout(False)
        Me.pnlContext.PerformLayout()
        Me.pnlButton.ResumeLayout(False)
        Me.pnlPage.ResumeLayout(False)
        Me.pnlPage.PerformLayout()
        Me.pnlToolbar.ResumeLayout(False)
        Me.pnlToolbar.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlContext As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pnlButton As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pnlPage As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblInfo As Label
    Friend WithEvents bSyncApi As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents bEdit As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents bTambah As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlToolbar As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents bRefresh As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents bCari As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents tPencarian As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents flpKalender As FlowLayoutPanel
    Friend WithEvents bNext As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents bPrev As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents bHapus As Guna.UI2.WinForms.Guna2Button
End Class
