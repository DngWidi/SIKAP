<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPendidikanAdd
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
        Me.components = New System.ComponentModel.Container()
        Me.pnlMain = New Guna.UI2.WinForms.Guna2Panel()
        Me.pnlBody = New Guna.UI2.WinForms.Guna2Panel()
        Me.ttahunlulus = New Guna.UI2.WinForms.Guna2NumericUpDown()
        Me.ttahunmasuk = New Guna.UI2.WinForms.Guna2NumericUpDown()
        Me.tketerangan = New Guna.UI2.WinForms.Guna2TextBox()
        Me.tnilai = New Guna.UI2.WinForms.Guna2TextBox()
        Me.tjurusan = New Guna.UI2.WinForms.Guna2TextBox()
        Me.tinstitusi = New Guna.UI2.WinForms.Guna2TextBox()
        Me.ctingkat = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblKode = New System.Windows.Forms.Label()
        Me.pnlFooter = New Guna.UI2.WinForms.Guna2Panel()
        Me.flpFooterButton = New System.Windows.Forms.FlowLayoutPanel()
        Me.bBatal = New Guna.UI2.WinForms.Guna2Button()
        Me.bSimpan = New Guna.UI2.WinForms.Guna2Button()
        Me.pnlFooterLine = New Guna.UI2.WinForms.Guna2Panel()
        Me.pnlHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.bClose = New Guna.UI2.WinForms.Guna2Button()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.pnlHeaderLine = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Guna2Elipse1 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.pnlMain.SuspendLayout()
        Me.pnlBody.SuspendLayout()
        CType(Me.ttahunlulus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ttahunmasuk, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFooter.SuspendLayout()
        Me.flpFooterButton.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.Controls.Add(Me.pnlBody)
        Me.pnlMain.Controls.Add(Me.pnlFooter)
        Me.pnlMain.Controls.Add(Me.pnlHeader)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.ShadowDecoration.Parent = Me.pnlMain
        Me.pnlMain.Size = New System.Drawing.Size(446, 534)
        Me.pnlMain.TabIndex = 1
        '
        'pnlBody
        '
        Me.pnlBody.Controls.Add(Me.ttahunlulus)
        Me.pnlBody.Controls.Add(Me.ttahunmasuk)
        Me.pnlBody.Controls.Add(Me.tketerangan)
        Me.pnlBody.Controls.Add(Me.tnilai)
        Me.pnlBody.Controls.Add(Me.tjurusan)
        Me.pnlBody.Controls.Add(Me.tinstitusi)
        Me.pnlBody.Controls.Add(Me.ctingkat)
        Me.pnlBody.Controls.Add(Me.Label6)
        Me.pnlBody.Controls.Add(Me.Label5)
        Me.pnlBody.Controls.Add(Me.Label4)
        Me.pnlBody.Controls.Add(Me.Label3)
        Me.pnlBody.Controls.Add(Me.Label2)
        Me.pnlBody.Controls.Add(Me.Label1)
        Me.pnlBody.Controls.Add(Me.lblKode)
        Me.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBody.Location = New System.Drawing.Point(0, 70)
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.Padding = New System.Windows.Forms.Padding(24, 18, 24, 10)
        Me.pnlBody.ShadowDecoration.Parent = Me.pnlBody
        Me.pnlBody.Size = New System.Drawing.Size(446, 399)
        Me.pnlBody.TabIndex = 4
        '
        'ttahunlulus
        '
        Me.ttahunlulus.BackColor = System.Drawing.Color.Transparent
        Me.ttahunlulus.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ttahunlulus.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.ttahunlulus.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.ttahunlulus.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.ttahunlulus.DisabledState.Parent = Me.ttahunlulus
        Me.ttahunlulus.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(CType(CType(177, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(177, Byte), Integer))
        Me.ttahunlulus.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.ttahunlulus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ttahunlulus.FocusedState.Parent = Me.ttahunlulus
        Me.ttahunlulus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ttahunlulus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.ttahunlulus.Location = New System.Drawing.Point(221, 217)
        Me.ttahunlulus.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.ttahunlulus.Name = "ttahunlulus"
        Me.ttahunlulus.ShadowDecoration.Parent = Me.ttahunlulus
        Me.ttahunlulus.Size = New System.Drawing.Size(100, 36)
        Me.ttahunlulus.TabIndex = 11
        '
        'ttahunmasuk
        '
        Me.ttahunmasuk.BackColor = System.Drawing.Color.Transparent
        Me.ttahunmasuk.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ttahunmasuk.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.ttahunmasuk.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.ttahunmasuk.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.ttahunmasuk.DisabledState.Parent = Me.ttahunmasuk
        Me.ttahunmasuk.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(CType(CType(177, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(177, Byte), Integer))
        Me.ttahunmasuk.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.ttahunmasuk.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ttahunmasuk.FocusedState.Parent = Me.ttahunmasuk
        Me.ttahunmasuk.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ttahunmasuk.ForeColor = System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.ttahunmasuk.Location = New System.Drawing.Point(12, 212)
        Me.ttahunmasuk.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.ttahunmasuk.Name = "ttahunmasuk"
        Me.ttahunmasuk.ShadowDecoration.Parent = Me.ttahunmasuk
        Me.ttahunmasuk.Size = New System.Drawing.Size(100, 36)
        Me.ttahunmasuk.TabIndex = 10
        '
        'tketerangan
        '
        Me.tketerangan.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.tketerangan.BorderRadius = 6
        Me.tketerangan.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tketerangan.DefaultText = ""
        Me.tketerangan.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.tketerangan.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.tketerangan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.tketerangan.DisabledState.Parent = Me.tketerangan
        Me.tketerangan.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.tketerangan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tketerangan.FocusedState.Parent = Me.tketerangan
        Me.tketerangan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.tketerangan.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tketerangan.HoverState.Parent = Me.tketerangan
        Me.tketerangan.Location = New System.Drawing.Point(12, 335)
        Me.tketerangan.Name = "tketerangan"
        Me.tketerangan.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.tketerangan.PlaceholderText = ""
        Me.tketerangan.SelectedText = ""
        Me.tketerangan.ShadowDecoration.Parent = Me.tketerangan
        Me.tketerangan.Size = New System.Drawing.Size(418, 38)
        Me.tketerangan.TabIndex = 13
        '
        'tnilai
        '
        Me.tnilai.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.tnilai.BorderRadius = 6
        Me.tnilai.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tnilai.DefaultText = ""
        Me.tnilai.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.tnilai.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.tnilai.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.tnilai.DisabledState.Parent = Me.tnilai
        Me.tnilai.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.tnilai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tnilai.FocusedState.Parent = Me.tnilai
        Me.tnilai.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.tnilai.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tnilai.HoverState.Parent = Me.tnilai
        Me.tnilai.Location = New System.Drawing.Point(12, 274)
        Me.tnilai.Name = "tnilai"
        Me.tnilai.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.tnilai.PlaceholderText = ""
        Me.tnilai.SelectedText = ""
        Me.tnilai.ShadowDecoration.Parent = Me.tnilai
        Me.tnilai.Size = New System.Drawing.Size(418, 38)
        Me.tnilai.TabIndex = 12
        '
        'tjurusan
        '
        Me.tjurusan.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.tjurusan.BorderRadius = 6
        Me.tjurusan.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tjurusan.DefaultText = ""
        Me.tjurusan.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.tjurusan.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.tjurusan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.tjurusan.DisabledState.Parent = Me.tjurusan
        Me.tjurusan.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.tjurusan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tjurusan.FocusedState.Parent = Me.tjurusan
        Me.tjurusan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.tjurusan.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tjurusan.HoverState.Parent = Me.tjurusan
        Me.tjurusan.Location = New System.Drawing.Point(12, 152)
        Me.tjurusan.Name = "tjurusan"
        Me.tjurusan.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.tjurusan.PlaceholderText = ""
        Me.tjurusan.SelectedText = ""
        Me.tjurusan.ShadowDecoration.Parent = Me.tjurusan
        Me.tjurusan.Size = New System.Drawing.Size(418, 38)
        Me.tjurusan.TabIndex = 9
        '
        'tinstitusi
        '
        Me.tinstitusi.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.tinstitusi.BorderRadius = 6
        Me.tinstitusi.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tinstitusi.DefaultText = ""
        Me.tinstitusi.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.tinstitusi.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.tinstitusi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.tinstitusi.DisabledState.Parent = Me.tinstitusi
        Me.tinstitusi.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.tinstitusi.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tinstitusi.FocusedState.Parent = Me.tinstitusi
        Me.tinstitusi.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.tinstitusi.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tinstitusi.HoverState.Parent = Me.tinstitusi
        Me.tinstitusi.Location = New System.Drawing.Point(12, 91)
        Me.tinstitusi.Name = "tinstitusi"
        Me.tinstitusi.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.tinstitusi.PlaceholderText = ""
        Me.tinstitusi.SelectedText = ""
        Me.tinstitusi.ShadowDecoration.Parent = Me.tinstitusi
        Me.tinstitusi.Size = New System.Drawing.Size(418, 38)
        Me.tinstitusi.TabIndex = 8
        '
        'ctingkat
        '
        Me.ctingkat.BackColor = System.Drawing.Color.Transparent
        Me.ctingkat.BorderRadius = 6
        Me.ctingkat.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ctingkat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ctingkat.FocusedColor = System.Drawing.Color.Empty
        Me.ctingkat.FocusedState.Parent = Me.ctingkat
        Me.ctingkat.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ctingkat.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.ctingkat.FormattingEnabled = True
        Me.ctingkat.HoverState.Parent = Me.ctingkat
        Me.ctingkat.ItemHeight = 30
        Me.ctingkat.ItemsAppearance.Parent = Me.ctingkat
        Me.ctingkat.Location = New System.Drawing.Point(12, 32)
        Me.ctingkat.Name = "ctingkat"
        Me.ctingkat.ShadowDecoration.Parent = Me.ctingkat
        Me.ctingkat.Size = New System.Drawing.Size(421, 36)
        Me.ctingkat.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(12, 316)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 15)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Keterangan"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(12, 255)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 15)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Nilai / IPK"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(218, 199)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 15)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Tahun Lulus"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(12, 194)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 15)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Tahun Masuk"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(12, 133)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Jurusan"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(12, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nama Institusi *"
        '
        'lblKode
        '
        Me.lblKode.AutoSize = True
        Me.lblKode.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.lblKode.Location = New System.Drawing.Point(12, 13)
        Me.lblKode.Name = "lblKode"
        Me.lblKode.Size = New System.Drawing.Size(117, 15)
        Me.lblKode.TabIndex = 0
        Me.lblKode.Text = "Tingkat Pendidikan *"
        '
        'pnlFooter
        '
        Me.pnlFooter.BorderColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.pnlFooter.Controls.Add(Me.flpFooterButton)
        Me.pnlFooter.Controls.Add(Me.pnlFooterLine)
        Me.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlFooter.Location = New System.Drawing.Point(0, 469)
        Me.pnlFooter.Name = "pnlFooter"
        Me.pnlFooter.ShadowDecoration.Parent = Me.pnlFooter
        Me.pnlFooter.Size = New System.Drawing.Size(446, 65)
        Me.pnlFooter.TabIndex = 3
        '
        'flpFooterButton
        '
        Me.flpFooterButton.Controls.Add(Me.bBatal)
        Me.flpFooterButton.Controls.Add(Me.bSimpan)
        Me.flpFooterButton.Dock = System.Windows.Forms.DockStyle.Right
        Me.flpFooterButton.Location = New System.Drawing.Point(236, 1)
        Me.flpFooterButton.Name = "flpFooterButton"
        Me.flpFooterButton.Padding = New System.Windows.Forms.Padding(0, 14, 14, 0)
        Me.flpFooterButton.Size = New System.Drawing.Size(210, 64)
        Me.flpFooterButton.TabIndex = 3
        Me.flpFooterButton.WrapContents = False
        '
        'bBatal
        '
        Me.bBatal.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.bBatal.BorderRadius = 6
        Me.bBatal.BorderThickness = 1
        Me.bBatal.CheckedState.Parent = Me.bBatal
        Me.bBatal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bBatal.CustomImages.Parent = Me.bBatal
        Me.bBatal.FillColor = System.Drawing.Color.White
        Me.bBatal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.bBatal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.bBatal.HoverState.Parent = Me.bBatal
        Me.bBatal.Location = New System.Drawing.Point(3, 17)
        Me.bBatal.Name = "bBatal"
        Me.bBatal.ShadowDecoration.Parent = Me.bBatal
        Me.bBatal.Size = New System.Drawing.Size(90, 36)
        Me.bBatal.TabIndex = 1
        Me.bBatal.Text = "Batal"
        '
        'bSimpan
        '
        Me.bSimpan.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.bSimpan.BorderRadius = 6
        Me.bSimpan.CheckedState.Parent = Me.bSimpan
        Me.bSimpan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bSimpan.CustomImages.Parent = Me.bSimpan
        Me.bSimpan.FillColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.bSimpan.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSimpan.ForeColor = System.Drawing.Color.White
        Me.bSimpan.HoverState.Parent = Me.bSimpan
        Me.bSimpan.Location = New System.Drawing.Point(99, 17)
        Me.bSimpan.Name = "bSimpan"
        Me.bSimpan.ShadowDecoration.Parent = Me.bSimpan
        Me.bSimpan.Size = New System.Drawing.Size(100, 36)
        Me.bSimpan.TabIndex = 2
        Me.bSimpan.Text = "Simpan"
        '
        'pnlFooterLine
        '
        Me.pnlFooterLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.pnlFooterLine.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFooterLine.Location = New System.Drawing.Point(0, 0)
        Me.pnlFooterLine.Name = "pnlFooterLine"
        Me.pnlFooterLine.ShadowDecoration.Parent = Me.pnlFooterLine
        Me.pnlFooterLine.Size = New System.Drawing.Size(446, 1)
        Me.pnlFooterLine.TabIndex = 0
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.pnlHeader.Controls.Add(Me.bClose)
        Me.pnlHeader.Controls.Add(Me.lblDescription)
        Me.pnlHeader.Controls.Add(Me.pnlHeaderLine)
        Me.pnlHeader.Controls.Add(Me.lblTitle)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.ShadowDecoration.Parent = Me.pnlHeader
        Me.pnlHeader.Size = New System.Drawing.Size(446, 70)
        Me.pnlHeader.TabIndex = 1
        '
        'bClose
        '
        Me.bClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bClose.CheckedState.Parent = Me.bClose
        Me.bClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bClose.CustomImages.Parent = Me.bClose
        Me.bClose.FillColor = System.Drawing.Color.Transparent
        Me.bClose.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.bClose.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.bClose.HoverState.Parent = Me.bClose
        Me.bClose.ImageSize = New System.Drawing.Size(16, 16)
        Me.bClose.Location = New System.Drawing.Point(412, 12)
        Me.bClose.Name = "bClose"
        Me.bClose.ShadowDecoration.Parent = Me.bClose
        Me.bClose.Size = New System.Drawing.Size(36, 36)
        Me.bClose.TabIndex = 2
        Me.bClose.Text = "X"
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.BackColor = System.Drawing.Color.Transparent
        Me.lblDescription.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.ForeColor = System.Drawing.Color.White
        Me.lblDescription.Location = New System.Drawing.Point(36, 40)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(222, 15)
        Me.lblDescription.TabIndex = 1
        Me.lblDescription.Text = "Tambahkan bagian baru ke dalam sistem"
        '
        'pnlHeaderLine
        '
        Me.pnlHeaderLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.pnlHeaderLine.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlHeaderLine.Location = New System.Drawing.Point(0, 69)
        Me.pnlHeaderLine.Name = "pnlHeaderLine"
        Me.pnlHeaderLine.ShadowDecoration.Parent = Me.pnlHeaderLine
        Me.pnlHeaderLine.Size = New System.Drawing.Size(446, 1)
        Me.pnlHeaderLine.TabIndex = 1
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(37, 12)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(142, 25)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Tambah Bagian"
        '
        'Guna2Elipse1
        '
        Me.Guna2Elipse1.BorderRadius = 8
        Me.Guna2Elipse1.TargetControl = Me
        '
        'frmPendidikanAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(446, 534)
        Me.Controls.Add(Me.pnlMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPendidikanAdd"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmPendidikanAdd"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlBody.ResumeLayout(False)
        Me.pnlBody.PerformLayout()
        CType(Me.ttahunlulus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ttahunmasuk, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFooter.ResumeLayout(False)
        Me.flpFooterButton.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlMain As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pnlBody As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblKode As Label
    Friend WithEvents pnlFooter As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents flpFooterButton As FlowLayoutPanel
    Friend WithEvents bBatal As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents bSimpan As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents pnlFooterLine As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pnlHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents bClose As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblDescription As Label
    Friend WithEvents pnlHeaderLine As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ctingkat As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents tjurusan As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents tinstitusi As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents tketerangan As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents tnilai As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents ttahunlulus As Guna.UI2.WinForms.Guna2NumericUpDown
    Friend WithEvents ttahunmasuk As Guna.UI2.WinForms.Guna2NumericUpDown
    Friend WithEvents Guna2Elipse1 As Guna.UI2.WinForms.Guna2Elipse
End Class
