<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uf_penilaianinterview
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uf_penilaianinterview))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlContext = New Guna.UI2.WinForms.Guna2Panel()
        Me.pnlButton = New Guna.UI2.WinForms.Guna2Panel()
        Me.bHapus = New Guna.UI2.WinForms.Guna2Button()
        Me.bSubmit = New Guna.UI2.WinForms.Guna2Button()
        Me.bDetail = New Guna.UI2.WinForms.Guna2Button()
        Me.bEdit = New Guna.UI2.WinForms.Guna2Button()
        Me.pnlPage = New Guna.UI2.WinForms.Guna2Panel()
        Me.paginationSeleksi = New SIKAP.ucPagination()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.dgvPenilaian = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlToolbar = New Guna.UI2.WinForms.Guna2Panel()
        Me.cTahap = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.cstatus = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.tPencarian = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlContext.SuspendLayout()
        Me.pnlButton.SuspendLayout()
        Me.pnlPage.SuspendLayout()
        CType(Me.dgvPenilaian, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlContext.Size = New System.Drawing.Size(889, 652)
        Me.pnlContext.TabIndex = 7
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
        Me.pnlButton.Controls.Add(Me.bSubmit)
        Me.pnlButton.Controls.Add(Me.bDetail)
        Me.pnlButton.Controls.Add(Me.bEdit)
        Me.pnlButton.Controls.Add(Me.pnlPage)
        Me.pnlButton.Controls.Add(Me.dgvPenilaian)
        Me.pnlButton.Location = New System.Drawing.Point(11, 162)
        Me.pnlButton.Name = "pnlButton"
        Me.pnlButton.ShadowDecoration.Parent = Me.pnlButton
        Me.pnlButton.Size = New System.Drawing.Size(861, 487)
        Me.pnlButton.TabIndex = 4
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
        Me.bHapus.Location = New System.Drawing.Point(287, 14)
        Me.bHapus.Name = "bHapus"
        Me.bHapus.ShadowDecoration.Parent = Me.bHapus
        Me.bHapus.Size = New System.Drawing.Size(83, 32)
        Me.bHapus.TabIndex = 13
        Me.bHapus.Text = "Hapus"
        Me.bHapus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.bSubmit.Location = New System.Drawing.Point(187, 14)
        Me.bSubmit.Name = "bSubmit"
        Me.bSubmit.ShadowDecoration.Parent = Me.bSubmit
        Me.bSubmit.Size = New System.Drawing.Size(94, 32)
        Me.bSubmit.TabIndex = 12
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
        Me.bDetail.Location = New System.Drawing.Point(98, 14)
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
        Me.bEdit.Location = New System.Drawing.Point(17, 14)
        Me.bEdit.Name = "bEdit"
        Me.bEdit.ShadowDecoration.Parent = Me.bEdit
        Me.bEdit.Size = New System.Drawing.Size(75, 32)
        Me.bEdit.TabIndex = 9
        Me.bEdit.Text = "Edit"
        Me.bEdit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pnlPage
        '
        Me.pnlPage.BorderColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.pnlPage.BorderThickness = 1
        Me.pnlPage.Controls.Add(Me.paginationSeleksi)
        Me.pnlPage.Controls.Add(Me.lblInfo)
        Me.pnlPage.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPage.Location = New System.Drawing.Point(0, 441)
        Me.pnlPage.Name = "pnlPage"
        Me.pnlPage.ShadowDecoration.Parent = Me.pnlPage
        Me.pnlPage.Size = New System.Drawing.Size(861, 46)
        Me.pnlPage.TabIndex = 4
        '
        'paginationSeleksi
        '
        Me.paginationSeleksi.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.paginationSeleksi.CurrentPage = 1
        Me.paginationSeleksi.Dock = System.Windows.Forms.DockStyle.Right
        Me.paginationSeleksi.Location = New System.Drawing.Point(511, 0)
        Me.paginationSeleksi.Name = "paginationSeleksi"
        Me.paginationSeleksi.PageSize = 10
        Me.paginationSeleksi.Size = New System.Drawing.Size(350, 46)
        Me.paginationSeleksi.TabIndex = 1
        Me.paginationSeleksi.TotalRecord = 0
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
        'dgvPenilaian
        '
        Me.dgvPenilaian.AllowUserToAddRows = False
        Me.dgvPenilaian.AllowUserToDeleteRows = False
        Me.dgvPenilaian.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dgvPenilaian.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPenilaian.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPenilaian.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPenilaian.BackgroundColor = System.Drawing.Color.White
        Me.dgvPenilaian.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvPenilaian.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvPenilaian.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(254, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPenilaian.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPenilaian.ColumnHeadersHeight = 24
        Me.dgvPenilaian.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPenilaian.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvPenilaian.EnableHeadersVisualStyles = False
        Me.dgvPenilaian.GridColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.dgvPenilaian.Location = New System.Drawing.Point(3, 63)
        Me.dgvPenilaian.MultiSelect = False
        Me.dgvPenilaian.Name = "dgvPenilaian"
        Me.dgvPenilaian.ReadOnly = True
        Me.dgvPenilaian.RowHeadersVisible = False
        Me.dgvPenilaian.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPenilaian.Size = New System.Drawing.Size(855, 353)
        Me.dgvPenilaian.TabIndex = 3
        Me.dgvPenilaian.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.[Default]
        Me.dgvPenilaian.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvPenilaian.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.dgvPenilaian.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.dgvPenilaian.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.dgvPenilaian.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.dgvPenilaian.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.dgvPenilaian.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.dgvPenilaian.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvPenilaian.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvPenilaian.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.dgvPenilaian.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.dgvPenilaian.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.dgvPenilaian.ThemeStyle.HeaderStyle.Height = 24
        Me.dgvPenilaian.ThemeStyle.ReadOnly = True
        Me.dgvPenilaian.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvPenilaian.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvPenilaian.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.dgvPenilaian.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.dgvPenilaian.ThemeStyle.RowsStyle.Height = 22
        Me.dgvPenilaian.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvPenilaian.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(8, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(223, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Home   >    Recruitment >  Penilaian Interview" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'pnlToolbar
        '
        Me.pnlToolbar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.pnlToolbar.BorderColor = System.Drawing.Color.Gainsboro
        Me.pnlToolbar.BorderRadius = 6
        Me.pnlToolbar.BorderThickness = 1
        Me.pnlToolbar.Controls.Add(Me.cTahap)
        Me.pnlToolbar.Controls.Add(Me.cstatus)
        Me.pnlToolbar.Controls.Add(Me.tPencarian)
        Me.pnlToolbar.Controls.Add(Me.Label4)
        Me.pnlToolbar.Location = New System.Drawing.Point(11, 82)
        Me.pnlToolbar.Name = "pnlToolbar"
        Me.pnlToolbar.ShadowDecoration.Parent = Me.pnlToolbar
        Me.pnlToolbar.Size = New System.Drawing.Size(861, 74)
        Me.pnlToolbar.TabIndex = 3
        '
        'cTahap
        '
        Me.cTahap.BackColor = System.Drawing.Color.Transparent
        Me.cTahap.BorderRadius = 6
        Me.cTahap.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cTahap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cTahap.FocusedColor = System.Drawing.Color.Empty
        Me.cTahap.FocusedState.Parent = Me.cTahap
        Me.cTahap.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cTahap.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cTahap.FormattingEnabled = True
        Me.cTahap.HoverState.Parent = Me.cTahap
        Me.cTahap.ItemHeight = 30
        Me.cTahap.ItemsAppearance.Parent = Me.cTahap
        Me.cTahap.Location = New System.Drawing.Point(288, 27)
        Me.cTahap.Name = "cTahap"
        Me.cTahap.ShadowDecoration.Parent = Me.cTahap
        Me.cTahap.Size = New System.Drawing.Size(183, 36)
        Me.cTahap.TabIndex = 5
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
        Me.cstatus.Location = New System.Drawing.Point(477, 27)
        Me.cstatus.Name = "cstatus"
        Me.cstatus.ShadowDecoration.Parent = Me.cstatus
        Me.cstatus.Size = New System.Drawing.Size(183, 36)
        Me.cstatus.TabIndex = 4
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
        Me.tPencarian.PlaceholderText = "No Kandidat / Nama"
        Me.tPencarian.SelectedText = ""
        Me.tPencarian.ShadowDecoration.Parent = Me.tPencarian
        Me.tPencarian.Size = New System.Drawing.Size(268, 36)
        Me.tPencarian.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Yu Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Cari Kandidat"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(14, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(201, 30)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Penilaian Interview"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(106, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(119, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(16, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(431, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Kelola dan lakukan penilaian terhadap kandidat yang mengikuti interview"
        '
        'uf_penilaianinterview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.pnlContext)
        Me.Name = "uf_penilaianinterview"
        Me.Size = New System.Drawing.Size(889, 652)
        Me.pnlContext.ResumeLayout(False)
        Me.pnlContext.PerformLayout()
        Me.pnlButton.ResumeLayout(False)
        Me.pnlPage.ResumeLayout(False)
        Me.pnlPage.PerformLayout()
        CType(Me.dgvPenilaian, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlToolbar.ResumeLayout(False)
        Me.pnlToolbar.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlContext As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pnlButton As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pnlPage As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents paginationSeleksi As ucPagination
    Friend WithEvents lblInfo As Label
    Friend WithEvents dgvPenilaian As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlToolbar As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents cstatus As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents tPencarian As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cTahap As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents bDetail As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents bEdit As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents bSubmit As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents bHapus As Guna.UI2.WinForms.Guna2Button
End Class
