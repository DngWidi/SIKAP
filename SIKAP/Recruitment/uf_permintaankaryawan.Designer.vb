<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uf_permintaankaryawan
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uf_permintaankaryawan))
        Me.pnlContext = New Guna.UI2.WinForms.Guna2Panel()
        Me.pnlButton = New Guna.UI2.WinForms.Guna2Panel()
        Me.pnlPage = New Guna.UI2.WinForms.Guna2Panel()
        Me.paginationPermintaan = New SIKAP.ucPagination()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.dgvPermintaan = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlToolbar = New Guna.UI2.WinForms.Guna2Panel()
        Me.cstatus = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.bSubmit = New Guna.UI2.WinForms.Guna2Button()
        Me.bDetail = New Guna.UI2.WinForms.Guna2Button()
        Me.bHapus = New Guna.UI2.WinForms.Guna2Button()
        Me.bEdit = New Guna.UI2.WinForms.Guna2Button()
        Me.bTambah = New Guna.UI2.WinForms.Guna2Button()
        Me.bRefresh = New Guna.UI2.WinForms.Guna2Button()
        Me.bCari = New Guna.UI2.WinForms.Guna2Button()
        Me.tPencarian = New Guna.UI2.WinForms.Guna2TextBox()
        Me.pnlContext.SuspendLayout()
        Me.pnlButton.SuspendLayout()
        Me.pnlPage.SuspendLayout()
        CType(Me.dgvPermintaan, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlContext.Size = New System.Drawing.Size(696, 527)
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
        Me.pnlButton.Controls.Add(Me.bSubmit)
        Me.pnlButton.Controls.Add(Me.bDetail)
        Me.pnlButton.Controls.Add(Me.bHapus)
        Me.pnlButton.Controls.Add(Me.bEdit)
        Me.pnlButton.Controls.Add(Me.pnlPage)
        Me.pnlButton.Controls.Add(Me.dgvPermintaan)
        Me.pnlButton.Controls.Add(Me.bTambah)
        Me.pnlButton.Location = New System.Drawing.Point(11, 162)
        Me.pnlButton.Name = "pnlButton"
        Me.pnlButton.ShadowDecoration.Parent = Me.pnlButton
        Me.pnlButton.Size = New System.Drawing.Size(668, 362)
        Me.pnlButton.TabIndex = 4
        '
        'pnlPage
        '
        Me.pnlPage.BorderColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.pnlPage.BorderThickness = 1
        Me.pnlPage.Controls.Add(Me.paginationPermintaan)
        Me.pnlPage.Controls.Add(Me.lblInfo)
        Me.pnlPage.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPage.Location = New System.Drawing.Point(0, 316)
        Me.pnlPage.Name = "pnlPage"
        Me.pnlPage.ShadowDecoration.Parent = Me.pnlPage
        Me.pnlPage.Size = New System.Drawing.Size(668, 46)
        Me.pnlPage.TabIndex = 4
        '
        'paginationPermintaan
        '
        Me.paginationPermintaan.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.paginationPermintaan.CurrentPage = 1
        Me.paginationPermintaan.Dock = System.Windows.Forms.DockStyle.Right
        Me.paginationPermintaan.Location = New System.Drawing.Point(318, 0)
        Me.paginationPermintaan.Name = "paginationPermintaan"
        Me.paginationPermintaan.PageSize = 10
        Me.paginationPermintaan.Size = New System.Drawing.Size(350, 46)
        Me.paginationPermintaan.TabIndex = 1
        Me.paginationPermintaan.TotalRecord = 0
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
        'dgvPermintaan
        '
        Me.dgvPermintaan.AllowUserToAddRows = False
        Me.dgvPermintaan.AllowUserToDeleteRows = False
        Me.dgvPermintaan.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dgvPermintaan.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPermintaan.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPermintaan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPermintaan.BackgroundColor = System.Drawing.Color.White
        Me.dgvPermintaan.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvPermintaan.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvPermintaan.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(254, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPermintaan.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPermintaan.ColumnHeadersHeight = 24
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPermintaan.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvPermintaan.EnableHeadersVisualStyles = False
        Me.dgvPermintaan.GridColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.dgvPermintaan.Location = New System.Drawing.Point(3, 63)
        Me.dgvPermintaan.MultiSelect = False
        Me.dgvPermintaan.Name = "dgvPermintaan"
        Me.dgvPermintaan.ReadOnly = True
        Me.dgvPermintaan.RowHeadersVisible = False
        Me.dgvPermintaan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPermintaan.Size = New System.Drawing.Size(662, 228)
        Me.dgvPermintaan.TabIndex = 3
        Me.dgvPermintaan.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.[Default]
        Me.dgvPermintaan.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvPermintaan.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.dgvPermintaan.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.dgvPermintaan.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.dgvPermintaan.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.dgvPermintaan.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.dgvPermintaan.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.dgvPermintaan.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvPermintaan.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvPermintaan.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.dgvPermintaan.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.dgvPermintaan.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.dgvPermintaan.ThemeStyle.HeaderStyle.Height = 24
        Me.dgvPermintaan.ThemeStyle.ReadOnly = True
        Me.dgvPermintaan.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvPermintaan.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvPermintaan.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.dgvPermintaan.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.dgvPermintaan.ThemeStyle.RowsStyle.Height = 22
        Me.dgvPermintaan.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvPermintaan.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(8, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(237, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Home   >    Recruitment >  Permintaan Karyawan"
        '
        'pnlToolbar
        '
        Me.pnlToolbar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.pnlToolbar.BorderColor = System.Drawing.Color.Gainsboro
        Me.pnlToolbar.BorderRadius = 6
        Me.pnlToolbar.BorderThickness = 1
        Me.pnlToolbar.Controls.Add(Me.cstatus)
        Me.pnlToolbar.Controls.Add(Me.bRefresh)
        Me.pnlToolbar.Controls.Add(Me.bCari)
        Me.pnlToolbar.Controls.Add(Me.tPencarian)
        Me.pnlToolbar.Controls.Add(Me.Label4)
        Me.pnlToolbar.Location = New System.Drawing.Point(11, 82)
        Me.pnlToolbar.Name = "pnlToolbar"
        Me.pnlToolbar.ShadowDecoration.Parent = Me.pnlToolbar
        Me.pnlToolbar.Size = New System.Drawing.Size(668, 74)
        Me.pnlToolbar.TabIndex = 3
        '
        'cstatus
        '
        Me.cstatus.BackColor = System.Drawing.Color.Transparent
        Me.cstatus.BorderRadius = 6
        Me.cstatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cstatus.FocusedColor = System.Drawing.Color.Empty
        Me.cstatus.FocusedState.Parent = Me.cstatus
        Me.cstatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cstatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cstatus.FormattingEnabled = True
        Me.cstatus.HoverState.Parent = Me.cstatus
        Me.cstatus.ItemHeight = 30
        Me.cstatus.ItemsAppearance.Parent = Me.cstatus
        Me.cstatus.Location = New System.Drawing.Point(288, 27)
        Me.cstatus.Name = "cstatus"
        Me.cstatus.ShadowDecoration.Parent = Me.cstatus
        Me.cstatus.Size = New System.Drawing.Size(183, 36)
        Me.cstatus.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Yu Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Cari Permintaan"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(14, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(279, 30)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Data Permintaan Karyawan"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(106, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(119, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(16, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(320, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Kelola seluruh data permintaan karyawan perusahaan"
        '
        'bSubmit
        '
        Me.bSubmit.BorderColor = System.Drawing.Color.Gainsboro
        Me.bSubmit.BorderRadius = 5
        Me.bSubmit.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.bSubmit.BorderThickness = 2
        Me.bSubmit.CheckedState.Parent = Me.bSubmit
        Me.bSubmit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bSubmit.CustomImages.Parent = Me.bSubmit
        Me.bSubmit.FillColor = System.Drawing.Color.Transparent
        Me.bSubmit.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSubmit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.bSubmit.HoverState.Parent = Me.bSubmit
        Me.bSubmit.Image = CType(resources.GetObject("bSubmit.Image"), System.Drawing.Image)
        Me.bSubmit.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.bSubmit.ImageSize = New System.Drawing.Size(18, 18)
        Me.bSubmit.Location = New System.Drawing.Point(377, 14)
        Me.bSubmit.Name = "bSubmit"
        Me.bSubmit.ShadowDecoration.Parent = Me.bSubmit
        Me.bSubmit.Size = New System.Drawing.Size(94, 32)
        Me.bSubmit.TabIndex = 8
        Me.bSubmit.Text = "Submit"
        Me.bSubmit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bDetail
        '
        Me.bDetail.BorderColor = System.Drawing.Color.Gainsboro
        Me.bDetail.BorderRadius = 5
        Me.bDetail.BorderThickness = 1
        Me.bDetail.CheckedState.Parent = Me.bDetail
        Me.bDetail.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bDetail.CustomImages.Parent = Me.bDetail
        Me.bDetail.FillColor = System.Drawing.Color.Transparent
        Me.bDetail.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bDetail.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.bDetail.HoverState.Parent = Me.bDetail
        Me.bDetail.Image = CType(resources.GetObject("bDetail.Image"), System.Drawing.Image)
        Me.bDetail.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.bDetail.ImageSize = New System.Drawing.Size(18, 18)
        Me.bDetail.Location = New System.Drawing.Point(288, 14)
        Me.bDetail.Name = "bDetail"
        Me.bDetail.ShadowDecoration.Parent = Me.bDetail
        Me.bDetail.Size = New System.Drawing.Size(83, 32)
        Me.bDetail.TabIndex = 7
        Me.bDetail.Text = "Detail"
        Me.bDetail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.bHapus.Location = New System.Drawing.Point(199, 14)
        Me.bHapus.Name = "bHapus"
        Me.bHapus.ShadowDecoration.Parent = Me.bHapus
        Me.bHapus.Size = New System.Drawing.Size(83, 32)
        Me.bHapus.TabIndex = 6
        Me.bHapus.Text = "Hapus"
        Me.bHapus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.bEdit.TabIndex = 5
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
        Me.bRefresh.Location = New System.Drawing.Point(569, 27)
        Me.bRefresh.Name = "bRefresh"
        Me.bRefresh.ShadowDecoration.Parent = Me.bRefresh
        Me.bRefresh.Size = New System.Drawing.Size(86, 36)
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
        Me.bCari.Location = New System.Drawing.Point(477, 27)
        Me.bCari.Name = "bCari"
        Me.bCari.ShadowDecoration.Parent = Me.bCari
        Me.bCari.Size = New System.Drawing.Size(86, 36)
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
        Me.tPencarian.PlaceholderText = "Ketik No. Request / Jabatan / Department"
        Me.tPencarian.SelectedText = ""
        Me.tPencarian.ShadowDecoration.Parent = Me.tPencarian
        Me.tPencarian.Size = New System.Drawing.Size(268, 36)
        Me.tPencarian.TabIndex = 1
        '
        'uf_permintaankaryawan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Controls.Add(Me.pnlContext)
        Me.Name = "uf_permintaankaryawan"
        Me.Size = New System.Drawing.Size(696, 527)
        Me.pnlContext.ResumeLayout(False)
        Me.pnlContext.PerformLayout()
        Me.pnlButton.ResumeLayout(False)
        Me.pnlPage.ResumeLayout(False)
        Me.pnlPage.PerformLayout()
        CType(Me.dgvPermintaan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlToolbar.ResumeLayout(False)
        Me.pnlToolbar.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlContext As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pnlButton As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pnlPage As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents paginationPermintaan As ucPagination
    Friend WithEvents lblInfo As Label
    Friend WithEvents dgvPermintaan As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents bTambah As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlToolbar As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents bRefresh As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents bCari As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents tPencarian As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cstatus As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents bDetail As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents bHapus As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents bEdit As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents bSubmit As Guna.UI2.WinForms.Guna2Button
End Class
