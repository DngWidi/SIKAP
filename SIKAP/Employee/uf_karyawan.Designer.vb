<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uf_karyawan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uf_karyawan))
        Me.pnlContext = New Guna.UI2.WinForms.Guna2Panel()
        Me.pnlButton = New Guna.UI2.WinForms.Guna2Panel()
        Me.pnlPage = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.dgvDataKaryawan = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlToolbar = New Guna.UI2.WinForms.Guna2Panel()
        Me.cFilter = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.paginationKaryawan = New SIKAP.ucPagination()
        Me.bDetail = New Guna.UI2.WinForms.Guna2Button()
        Me.bEdit = New Guna.UI2.WinForms.Guna2Button()
        Me.bTambah = New Guna.UI2.WinForms.Guna2Button()
        Me.bRefresh = New Guna.UI2.WinForms.Guna2Button()
        Me.bCari = New Guna.UI2.WinForms.Guna2Button()
        Me.tPencarian = New Guna.UI2.WinForms.Guna2TextBox()
        Me.pnlContext.SuspendLayout()
        Me.pnlButton.SuspendLayout()
        Me.pnlPage.SuspendLayout()
        CType(Me.dgvDataKaryawan, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlContext.Size = New System.Drawing.Size(1006, 746)
        Me.pnlContext.TabIndex = 9
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
        Me.pnlButton.Controls.Add(Me.bDetail)
        Me.pnlButton.Controls.Add(Me.bEdit)
        Me.pnlButton.Controls.Add(Me.bTambah)
        Me.pnlButton.Controls.Add(Me.pnlPage)
        Me.pnlButton.Controls.Add(Me.dgvDataKaryawan)
        Me.pnlButton.Location = New System.Drawing.Point(11, 162)
        Me.pnlButton.Name = "pnlButton"
        Me.pnlButton.ShadowDecoration.Parent = Me.pnlButton
        Me.pnlButton.Size = New System.Drawing.Size(978, 581)
        Me.pnlButton.TabIndex = 4
        '
        'pnlPage
        '
        Me.pnlPage.BorderColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.pnlPage.BorderThickness = 1
        Me.pnlPage.Controls.Add(Me.paginationKaryawan)
        Me.pnlPage.Controls.Add(Me.lblInfo)
        Me.pnlPage.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPage.Location = New System.Drawing.Point(0, 535)
        Me.pnlPage.Name = "pnlPage"
        Me.pnlPage.ShadowDecoration.Parent = Me.pnlPage
        Me.pnlPage.Size = New System.Drawing.Size(978, 46)
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
        'dgvDataKaryawan
        '
        Me.dgvDataKaryawan.AllowUserToAddRows = False
        Me.dgvDataKaryawan.AllowUserToDeleteRows = False
        Me.dgvDataKaryawan.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dgvDataKaryawan.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDataKaryawan.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDataKaryawan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDataKaryawan.BackgroundColor = System.Drawing.Color.White
        Me.dgvDataKaryawan.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvDataKaryawan.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvDataKaryawan.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(254, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDataKaryawan.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDataKaryawan.ColumnHeadersHeight = 24
        Me.dgvDataKaryawan.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDataKaryawan.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvDataKaryawan.EnableHeadersVisualStyles = False
        Me.dgvDataKaryawan.GridColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.dgvDataKaryawan.Location = New System.Drawing.Point(3, 47)
        Me.dgvDataKaryawan.MultiSelect = False
        Me.dgvDataKaryawan.Name = "dgvDataKaryawan"
        Me.dgvDataKaryawan.ReadOnly = True
        Me.dgvDataKaryawan.RowHeadersVisible = False
        Me.dgvDataKaryawan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDataKaryawan.Size = New System.Drawing.Size(972, 463)
        Me.dgvDataKaryawan.TabIndex = 3
        Me.dgvDataKaryawan.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.[Default]
        Me.dgvDataKaryawan.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvDataKaryawan.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.dgvDataKaryawan.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.dgvDataKaryawan.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.dgvDataKaryawan.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.dgvDataKaryawan.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.dgvDataKaryawan.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.dgvDataKaryawan.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvDataKaryawan.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvDataKaryawan.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.dgvDataKaryawan.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.dgvDataKaryawan.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.dgvDataKaryawan.ThemeStyle.HeaderStyle.Height = 24
        Me.dgvDataKaryawan.ThemeStyle.ReadOnly = True
        Me.dgvDataKaryawan.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvDataKaryawan.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvDataKaryawan.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.dgvDataKaryawan.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.dgvDataKaryawan.ThemeStyle.RowsStyle.Height = 22
        Me.dgvDataKaryawan.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvDataKaryawan.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(8, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(196, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Home   >    Employee >  Data Karyawan" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
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
        Me.pnlToolbar.Controls.Add(Me.cFilter)
        Me.pnlToolbar.Controls.Add(Me.tPencarian)
        Me.pnlToolbar.Controls.Add(Me.Label4)
        Me.pnlToolbar.Location = New System.Drawing.Point(11, 82)
        Me.pnlToolbar.Name = "pnlToolbar"
        Me.pnlToolbar.ShadowDecoration.Parent = Me.pnlToolbar
        Me.pnlToolbar.Size = New System.Drawing.Size(978, 74)
        Me.pnlToolbar.TabIndex = 3
        '
        'cFilter
        '
        Me.cFilter.BackColor = System.Drawing.Color.Transparent
        Me.cFilter.BorderRadius = 6
        Me.cFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cFilter.FocusedColor = System.Drawing.Color.Empty
        Me.cFilter.FocusedState.Parent = Me.cFilter
        Me.cFilter.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cFilter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cFilter.FormattingEnabled = True
        Me.cFilter.HoverState.Parent = Me.cFilter
        Me.cFilter.ItemHeight = 30
        Me.cFilter.ItemsAppearance.Parent = Me.cFilter
        Me.cFilter.Location = New System.Drawing.Point(319, 27)
        Me.cFilter.Name = "cFilter"
        Me.cFilter.ShadowDecoration.Parent = Me.cFilter
        Me.cFilter.Size = New System.Drawing.Size(183, 36)
        Me.cFilter.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Yu Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Cari Data Karyawan"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(14, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(161, 30)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Data Karyawan"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(106, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(119, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(16, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(132, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Daftar data karyawan"
        '
        'paginationKaryawan
        '
        Me.paginationKaryawan.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.paginationKaryawan.CurrentPage = 1
        Me.paginationKaryawan.Dock = System.Windows.Forms.DockStyle.Right
        Me.paginationKaryawan.Location = New System.Drawing.Point(628, 0)
        Me.paginationKaryawan.Name = "paginationKaryawan"
        Me.paginationKaryawan.PageSize = 10
        Me.paginationKaryawan.Size = New System.Drawing.Size(350, 46)
        Me.paginationKaryawan.TabIndex = 1
        Me.paginationKaryawan.TotalRecord = 0
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
        Me.bDetail.Location = New System.Drawing.Point(199, 9)
        Me.bDetail.Name = "bDetail"
        Me.bDetail.ShadowDecoration.Parent = Me.bDetail
        Me.bDetail.Size = New System.Drawing.Size(83, 32)
        Me.bDetail.TabIndex = 11
        Me.bDetail.Text = "Detail"
        Me.bDetail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.bEdit.Location = New System.Drawing.Point(118, 9)
        Me.bEdit.Name = "bEdit"
        Me.bEdit.ShadowDecoration.Parent = Me.bEdit
        Me.bEdit.Size = New System.Drawing.Size(75, 32)
        Me.bEdit.TabIndex = 9
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
        Me.bTambah.Location = New System.Drawing.Point(14, 9)
        Me.bTambah.Name = "bTambah"
        Me.bTambah.ShadowDecoration.Parent = Me.bTambah
        Me.bTambah.Size = New System.Drawing.Size(98, 32)
        Me.bTambah.TabIndex = 8
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
        Me.bRefresh.Location = New System.Drawing.Point(758, 27)
        Me.bRefresh.Name = "bRefresh"
        Me.bRefresh.ShadowDecoration.Parent = Me.bRefresh
        Me.bRefresh.Size = New System.Drawing.Size(86, 36)
        Me.bRefresh.TabIndex = 7
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
        Me.bCari.Location = New System.Drawing.Point(666, 27)
        Me.bCari.Name = "bCari"
        Me.bCari.ShadowDecoration.Parent = Me.bCari
        Me.bCari.Size = New System.Drawing.Size(86, 36)
        Me.bCari.TabIndex = 6
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
        Me.tPencarian.PlaceholderText = "Cari Nik / Nama Karyawan"
        Me.tPencarian.SelectedText = ""
        Me.tPencarian.ShadowDecoration.Parent = Me.tPencarian
        Me.tPencarian.Size = New System.Drawing.Size(299, 36)
        Me.tPencarian.TabIndex = 1
        '
        'uf_karyawan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.pnlContext)
        Me.Name = "uf_karyawan"
        Me.Size = New System.Drawing.Size(1006, 746)
        Me.pnlContext.ResumeLayout(False)
        Me.pnlContext.PerformLayout()
        Me.pnlButton.ResumeLayout(False)
        Me.pnlPage.ResumeLayout(False)
        Me.pnlPage.PerformLayout()
        CType(Me.dgvDataKaryawan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlToolbar.ResumeLayout(False)
        Me.pnlToolbar.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlContext As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pnlButton As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pnlPage As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents paginationKaryawan As ucPagination
    Friend WithEvents lblInfo As Label
    Friend WithEvents dgvDataKaryawan As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlToolbar As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents bRefresh As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents bCari As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents cFilter As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents tPencarian As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents bDetail As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents bEdit As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents bTambah As Guna.UI2.WinForms.Guna2Button
End Class
