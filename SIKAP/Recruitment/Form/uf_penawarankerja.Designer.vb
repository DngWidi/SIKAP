<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uf_penawarankerja
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlContext = New Guna.UI2.WinForms.Guna2Panel()
        Me.pnlButton = New Guna.UI2.WinForms.Guna2Panel()
        Me.pnlPage = New Guna.UI2.WinForms.Guna2Panel()
        Me.paginationPenawaran = New SIKAP.ucPagination()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.dgvPenawaranKerja = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlToolbar = New Guna.UI2.WinForms.Guna2Panel()
        Me.dtpSampai = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpDari = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cstatus = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.bRefresh = New Guna.UI2.WinForms.Guna2Button()
        Me.bCari = New Guna.UI2.WinForms.Guna2Button()
        Me.tPencarian = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlContext.SuspendLayout()
        Me.pnlButton.SuspendLayout()
        Me.pnlPage.SuspendLayout()
        CType(Me.dgvPenawaranKerja, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlContext.Size = New System.Drawing.Size(901, 527)
        Me.pnlContext.TabIndex = 6
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
        Me.pnlButton.Controls.Add(Me.pnlPage)
        Me.pnlButton.Controls.Add(Me.dgvPenawaranKerja)
        Me.pnlButton.Location = New System.Drawing.Point(11, 162)
        Me.pnlButton.Name = "pnlButton"
        Me.pnlButton.ShadowDecoration.Parent = Me.pnlButton
        Me.pnlButton.Size = New System.Drawing.Size(873, 362)
        Me.pnlButton.TabIndex = 4
        '
        'pnlPage
        '
        Me.pnlPage.BorderColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.pnlPage.BorderThickness = 1
        Me.pnlPage.Controls.Add(Me.paginationPenawaran)
        Me.pnlPage.Controls.Add(Me.lblInfo)
        Me.pnlPage.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPage.Location = New System.Drawing.Point(0, 316)
        Me.pnlPage.Name = "pnlPage"
        Me.pnlPage.ShadowDecoration.Parent = Me.pnlPage
        Me.pnlPage.Size = New System.Drawing.Size(873, 46)
        Me.pnlPage.TabIndex = 4
        '
        'paginationPenawaran
        '
        Me.paginationPenawaran.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.paginationPenawaran.CurrentPage = 1
        Me.paginationPenawaran.Dock = System.Windows.Forms.DockStyle.Right
        Me.paginationPenawaran.Location = New System.Drawing.Point(523, 0)
        Me.paginationPenawaran.Name = "paginationPenawaran"
        Me.paginationPenawaran.PageSize = 10
        Me.paginationPenawaran.Size = New System.Drawing.Size(350, 46)
        Me.paginationPenawaran.TabIndex = 1
        Me.paginationPenawaran.TotalRecord = 0
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
        'dgvPenawaranKerja
        '
        Me.dgvPenawaranKerja.AllowUserToAddRows = False
        Me.dgvPenawaranKerja.AllowUserToDeleteRows = False
        Me.dgvPenawaranKerja.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        Me.dgvPenawaranKerja.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvPenawaranKerja.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPenawaranKerja.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPenawaranKerja.BackgroundColor = System.Drawing.Color.White
        Me.dgvPenawaranKerja.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvPenawaranKerja.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvPenawaranKerja.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(254, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPenawaranKerja.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvPenawaranKerja.ColumnHeadersHeight = 24
        Me.dgvPenawaranKerja.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPenawaranKerja.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvPenawaranKerja.EnableHeadersVisualStyles = False
        Me.dgvPenawaranKerja.GridColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.dgvPenawaranKerja.Location = New System.Drawing.Point(3, 18)
        Me.dgvPenawaranKerja.MultiSelect = False
        Me.dgvPenawaranKerja.Name = "dgvPenawaranKerja"
        Me.dgvPenawaranKerja.ReadOnly = True
        Me.dgvPenawaranKerja.RowHeadersVisible = False
        Me.dgvPenawaranKerja.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPenawaranKerja.Size = New System.Drawing.Size(867, 283)
        Me.dgvPenawaranKerja.TabIndex = 3
        Me.dgvPenawaranKerja.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.[Default]
        Me.dgvPenawaranKerja.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvPenawaranKerja.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.dgvPenawaranKerja.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.dgvPenawaranKerja.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.dgvPenawaranKerja.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.dgvPenawaranKerja.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.dgvPenawaranKerja.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.dgvPenawaranKerja.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvPenawaranKerja.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvPenawaranKerja.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.dgvPenawaranKerja.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.dgvPenawaranKerja.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.dgvPenawaranKerja.ThemeStyle.HeaderStyle.Height = 24
        Me.dgvPenawaranKerja.ThemeStyle.ReadOnly = True
        Me.dgvPenawaranKerja.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvPenawaranKerja.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvPenawaranKerja.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.dgvPenawaranKerja.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.dgvPenawaranKerja.ThemeStyle.RowsStyle.Height = 22
        Me.dgvPenawaranKerja.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvPenawaranKerja.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(8, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(215, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Home   >    Recruitment >  Penawaran Kerja"
        '
        'pnlToolbar
        '
        Me.pnlToolbar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.pnlToolbar.BorderColor = System.Drawing.Color.Gainsboro
        Me.pnlToolbar.BorderRadius = 6
        Me.pnlToolbar.BorderThickness = 1
        Me.pnlToolbar.Controls.Add(Me.dtpSampai)
        Me.pnlToolbar.Controls.Add(Me.Label7)
        Me.pnlToolbar.Controls.Add(Me.dtpDari)
        Me.pnlToolbar.Controls.Add(Me.Label6)
        Me.pnlToolbar.Controls.Add(Me.Label5)
        Me.pnlToolbar.Controls.Add(Me.cstatus)
        Me.pnlToolbar.Controls.Add(Me.bRefresh)
        Me.pnlToolbar.Controls.Add(Me.bCari)
        Me.pnlToolbar.Controls.Add(Me.tPencarian)
        Me.pnlToolbar.Controls.Add(Me.Label4)
        Me.pnlToolbar.Location = New System.Drawing.Point(11, 82)
        Me.pnlToolbar.Name = "pnlToolbar"
        Me.pnlToolbar.ShadowDecoration.Parent = Me.pnlToolbar
        Me.pnlToolbar.Size = New System.Drawing.Size(873, 74)
        Me.pnlToolbar.TabIndex = 3
        '
        'dtpSampai
        '
        Me.dtpSampai.BorderColor = System.Drawing.Color.LightGray
        Me.dtpSampai.BorderRadius = 6
        Me.dtpSampai.BorderThickness = 1
        Me.dtpSampai.CheckedState.Parent = Me.dtpSampai
        Me.dtpSampai.FillColor = System.Drawing.Color.White
        Me.dtpSampai.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpSampai.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpSampai.HoverState.Parent = Me.dtpSampai
        Me.dtpSampai.Location = New System.Drawing.Point(561, 31)
        Me.dtpSampai.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpSampai.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpSampai.Name = "dtpSampai"
        Me.dtpSampai.ShadowDecoration.Parent = Me.dtpSampai
        Me.dtpSampai.Size = New System.Drawing.Size(125, 34)
        Me.dtpSampai.TabIndex = 9
        Me.dtpSampai.Value = New Date(2026, 9, 28, 18, 16, 45, 675)
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Yu Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(549, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(12, 16)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "-"
        '
        'dtpDari
        '
        Me.dtpDari.BorderColor = System.Drawing.Color.LightGray
        Me.dtpDari.BorderRadius = 6
        Me.dtpDari.BorderThickness = 1
        Me.dtpDari.CheckedState.Parent = Me.dtpDari
        Me.dtpDari.FillColor = System.Drawing.Color.White
        Me.dtpDari.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDari.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDari.HoverState.Parent = Me.dtpDari
        Me.dtpDari.Location = New System.Drawing.Point(418, 31)
        Me.dtpDari.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpDari.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpDari.Name = "dtpDari"
        Me.dtpDari.ShadowDecoration.Parent = Me.dtpDari
        Me.dtpDari.Size = New System.Drawing.Size(125, 34)
        Me.dtpDari.TabIndex = 7
        Me.dtpDari.Value = New Date(2026, 9, 28, 18, 16, 45, 675)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Yu Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(421, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 16)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Periode Offering"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Yu Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(288, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 16)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Status Offering"
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
        Me.cstatus.Location = New System.Drawing.Point(288, 30)
        Me.cstatus.Name = "cstatus"
        Me.cstatus.ShadowDecoration.Parent = Me.cstatus
        Me.cstatus.Size = New System.Drawing.Size(124, 36)
        Me.cstatus.TabIndex = 4
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
        Me.bRefresh.Location = New System.Drawing.Point(784, 31)
        Me.bRefresh.Name = "bRefresh"
        Me.bRefresh.ShadowDecoration.Parent = Me.bRefresh
        Me.bRefresh.Size = New System.Drawing.Size(86, 34)
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
        Me.bCari.Location = New System.Drawing.Point(692, 31)
        Me.bCari.Name = "bCari"
        Me.bCari.ShadowDecoration.Parent = Me.bCari
        Me.bCari.Size = New System.Drawing.Size(86, 34)
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
        Me.tPencarian.Location = New System.Drawing.Point(14, 30)
        Me.tPencarian.Name = "tPencarian"
        Me.tPencarian.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.tPencarian.PlaceholderText = "Cari no kandidat, nama, no permintaan atau jabatan"
        Me.tPencarian.SelectedText = ""
        Me.tPencarian.ShadowDecoration.Parent = Me.tPencarian
        Me.tPencarian.Size = New System.Drawing.Size(268, 34)
        Me.tPencarian.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Yu Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Pencarian"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(14, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(227, 30)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Data Penawaran Kerja"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(106, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(119, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(16, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(278, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Kelola seluruh data penawaran kerja karyawan"
        '
        'uf_penawarankerja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Controls.Add(Me.pnlContext)
        Me.Name = "uf_penawarankerja"
        Me.Size = New System.Drawing.Size(901, 527)
        Me.pnlContext.ResumeLayout(False)
        Me.pnlContext.PerformLayout()
        Me.pnlButton.ResumeLayout(False)
        Me.pnlPage.ResumeLayout(False)
        Me.pnlPage.PerformLayout()
        CType(Me.dgvPenawaranKerja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlToolbar.ResumeLayout(False)
        Me.pnlToolbar.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlContext As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pnlButton As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pnlPage As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents paginationPenawaran As ucPagination
    Friend WithEvents lblInfo As Label
    Friend WithEvents dgvPenawaranKerja As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlToolbar As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents cstatus As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents bRefresh As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents bCari As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents tPencarian As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents dtpDari As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents dtpSampai As Guna.UI2.WinForms.Guna2DateTimePicker
End Class
