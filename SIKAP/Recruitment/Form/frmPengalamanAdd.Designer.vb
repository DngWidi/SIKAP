<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPengalamanAdd
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.pnlMain = New Guna.UI2.WinForms.Guna2Panel()
        Me.pnlBody = New Guna.UI2.WinForms.Guna2Panel()
        Me.dtglselesai = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.dtglmulai = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.tperusahaan = New Guna.UI2.WinForms.Guna2TextBox()
        Me.tketerangan = New Guna.UI2.WinForms.Guna2TextBox()
        Me.talasanberhenti = New Guna.UI2.WinForms.Guna2TextBox()
        Me.tgajiterakhir = New Guna.UI2.WinForms.Guna2TextBox()
        Me.tjabatan = New Guna.UI2.WinForms.Guna2TextBox()
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
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.ShadowDecoration.Parent = Me.pnlMain
        Me.pnlMain.Size = New System.Drawing.Size(446, 534)
        Me.pnlMain.TabIndex = 2
        '
        'pnlBody
        '
        Me.pnlBody.Controls.Add(Me.dtglselesai)
        Me.pnlBody.Controls.Add(Me.dtglmulai)
        Me.pnlBody.Controls.Add(Me.tperusahaan)
        Me.pnlBody.Controls.Add(Me.tketerangan)
        Me.pnlBody.Controls.Add(Me.talasanberhenti)
        Me.pnlBody.Controls.Add(Me.tgajiterakhir)
        Me.pnlBody.Controls.Add(Me.tjabatan)
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
        'dtglselesai
        '
        Me.dtglselesai.BorderColor = System.Drawing.Color.DarkGray
        Me.dtglselesai.BorderRadius = 6
        Me.dtglselesai.BorderThickness = 1
        Me.dtglselesai.CheckedState.Parent = Me.dtglselesai
        Me.dtglselesai.FillColor = System.Drawing.Color.White
        Me.dtglselesai.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtglselesai.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtglselesai.HoverState.Parent = Me.dtglselesai
        Me.dtglselesai.Location = New System.Drawing.Point(166, 155)
        Me.dtglselesai.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtglselesai.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtglselesai.Name = "dtglselesai"
        Me.dtglselesai.ShadowDecoration.Parent = Me.dtglselesai
        Me.dtglselesai.Size = New System.Drawing.Size(127, 36)
        Me.dtglselesai.TabIndex = 15
        Me.dtglselesai.Value = New Date(2026, 9, 8, 9, 11, 44, 845)
        '
        'dtglmulai
        '
        Me.dtglmulai.BorderColor = System.Drawing.Color.DarkGray
        Me.dtglmulai.BorderRadius = 6
        Me.dtglmulai.BorderThickness = 1
        Me.dtglmulai.CheckedState.Parent = Me.dtglmulai
        Me.dtglmulai.FillColor = System.Drawing.Color.White
        Me.dtglmulai.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtglmulai.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtglmulai.HoverState.Parent = Me.dtglmulai
        Me.dtglmulai.Location = New System.Drawing.Point(15, 155)
        Me.dtglmulai.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtglmulai.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtglmulai.Name = "dtglmulai"
        Me.dtglmulai.ShadowDecoration.Parent = Me.dtglmulai
        Me.dtglmulai.Size = New System.Drawing.Size(127, 36)
        Me.dtglmulai.TabIndex = 14
        Me.dtglmulai.Value = New Date(2026, 9, 8, 9, 12, 42, 310)
        '
        'tperusahaan
        '
        Me.tperusahaan.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.tperusahaan.BorderRadius = 6
        Me.tperusahaan.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tperusahaan.DefaultText = ""
        Me.tperusahaan.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.tperusahaan.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.tperusahaan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.tperusahaan.DisabledState.Parent = Me.tperusahaan
        Me.tperusahaan.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.tperusahaan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tperusahaan.FocusedState.Parent = Me.tperusahaan
        Me.tperusahaan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.tperusahaan.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tperusahaan.HoverState.Parent = Me.tperusahaan
        Me.tperusahaan.Location = New System.Drawing.Point(15, 32)
        Me.tperusahaan.Name = "tperusahaan"
        Me.tperusahaan.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.tperusahaan.PlaceholderText = ""
        Me.tperusahaan.SelectedText = ""
        Me.tperusahaan.ShadowDecoration.Parent = Me.tperusahaan
        Me.tperusahaan.Size = New System.Drawing.Size(418, 38)
        Me.tperusahaan.TabIndex = 8
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
        Me.tketerangan.Location = New System.Drawing.Point(15, 335)
        Me.tketerangan.Name = "tketerangan"
        Me.tketerangan.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.tketerangan.PlaceholderText = ""
        Me.tketerangan.SelectedText = ""
        Me.tketerangan.ShadowDecoration.Parent = Me.tketerangan
        Me.tketerangan.Size = New System.Drawing.Size(418, 38)
        Me.tketerangan.TabIndex = 13
        '
        'talasanberhenti
        '
        Me.talasanberhenti.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.talasanberhenti.BorderRadius = 6
        Me.talasanberhenti.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.talasanberhenti.DefaultText = ""
        Me.talasanberhenti.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.talasanberhenti.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.talasanberhenti.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.talasanberhenti.DisabledState.Parent = Me.talasanberhenti
        Me.talasanberhenti.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.talasanberhenti.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.talasanberhenti.FocusedState.Parent = Me.talasanberhenti
        Me.talasanberhenti.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.talasanberhenti.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.talasanberhenti.HoverState.Parent = Me.talasanberhenti
        Me.talasanberhenti.Location = New System.Drawing.Point(15, 274)
        Me.talasanberhenti.Name = "talasanberhenti"
        Me.talasanberhenti.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.talasanberhenti.PlaceholderText = ""
        Me.talasanberhenti.SelectedText = ""
        Me.talasanberhenti.ShadowDecoration.Parent = Me.talasanberhenti
        Me.talasanberhenti.Size = New System.Drawing.Size(418, 38)
        Me.talasanberhenti.TabIndex = 12
        '
        'tgajiterakhir
        '
        Me.tgajiterakhir.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.tgajiterakhir.BorderRadius = 6
        Me.tgajiterakhir.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tgajiterakhir.DefaultText = ""
        Me.tgajiterakhir.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.tgajiterakhir.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.tgajiterakhir.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.tgajiterakhir.DisabledState.Parent = Me.tgajiterakhir
        Me.tgajiterakhir.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.tgajiterakhir.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tgajiterakhir.FocusedState.Parent = Me.tgajiterakhir
        Me.tgajiterakhir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.tgajiterakhir.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tgajiterakhir.HoverState.Parent = Me.tgajiterakhir
        Me.tgajiterakhir.Location = New System.Drawing.Point(15, 213)
        Me.tgajiterakhir.Name = "tgajiterakhir"
        Me.tgajiterakhir.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.tgajiterakhir.PlaceholderText = ""
        Me.tgajiterakhir.SelectedText = ""
        Me.tgajiterakhir.ShadowDecoration.Parent = Me.tgajiterakhir
        Me.tgajiterakhir.Size = New System.Drawing.Size(418, 38)
        Me.tgajiterakhir.TabIndex = 9
        '
        'tjabatan
        '
        Me.tjabatan.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.tjabatan.BorderRadius = 6
        Me.tjabatan.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tjabatan.DefaultText = ""
        Me.tjabatan.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.tjabatan.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.tjabatan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.tjabatan.DisabledState.Parent = Me.tjabatan
        Me.tjabatan.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.tjabatan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tjabatan.FocusedState.Parent = Me.tjabatan
        Me.tjabatan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.tjabatan.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tjabatan.HoverState.Parent = Me.tjabatan
        Me.tjabatan.Location = New System.Drawing.Point(15, 93)
        Me.tjabatan.Name = "tjabatan"
        Me.tjabatan.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.tjabatan.PlaceholderText = ""
        Me.tjabatan.SelectedText = ""
        Me.tjabatan.ShadowDecoration.Parent = Me.tjabatan
        Me.tjabatan.Size = New System.Drawing.Size(418, 38)
        Me.tjabatan.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(15, 316)
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
        Me.Label5.Location = New System.Drawing.Point(15, 255)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 15)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Alasan Berhenti"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(163, 134)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 15)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Tahun Selesai"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(15, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 15)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Tahun Mulai"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(15, 194)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Gaji Terakhir"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(15, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Jabatan *"
        '
        'lblKode
        '
        Me.lblKode.AutoSize = True
        Me.lblKode.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.lblKode.Location = New System.Drawing.Point(15, 13)
        Me.lblKode.Name = "lblKode"
        Me.lblKode.Size = New System.Drawing.Size(111, 15)
        Me.lblKode.TabIndex = 0
        Me.lblKode.Text = "Nama Perusahaan *"
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
        'frmPengalamanAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(446, 534)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPengalamanAdd"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmPengalamanAdd"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlBody.ResumeLayout(False)
        Me.pnlBody.PerformLayout()
        Me.pnlFooter.ResumeLayout(False)
        Me.flpFooterButton.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlMain As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pnlBody As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents tketerangan As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents talasanberhenti As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents tgajiterakhir As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents tjabatan As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
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
    Friend WithEvents dtglselesai As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents dtglmulai As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents tperusahaan As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2Elipse1 As Guna.UI2.WinForms.Guna2Elipse
End Class
