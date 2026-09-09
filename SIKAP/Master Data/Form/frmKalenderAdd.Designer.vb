<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKalenderAdd
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
        Me.pnlMain = New Guna.UI2.WinForms.Guna2Panel()
        Me.pnlBody = New Guna.UI2.WinForms.Guna2Panel()
        Me.dTanggal = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.tKeterangan = New Guna.UI2.WinForms.Guna2TextBox()
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
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.ShadowDecoration.Parent = Me.pnlMain
        Me.pnlMain.Size = New System.Drawing.Size(484, 301)
        Me.pnlMain.TabIndex = 1
        '
        'pnlBody
        '
        Me.pnlBody.Controls.Add(Me.dTanggal)
        Me.pnlBody.Controls.Add(Me.tKeterangan)
        Me.pnlBody.Controls.Add(Me.Label1)
        Me.pnlBody.Controls.Add(Me.lblKode)
        Me.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBody.Location = New System.Drawing.Point(0, 70)
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.Padding = New System.Windows.Forms.Padding(24, 18, 24, 10)
        Me.pnlBody.ShadowDecoration.Parent = Me.pnlBody
        Me.pnlBody.Size = New System.Drawing.Size(484, 166)
        Me.pnlBody.TabIndex = 4
        '
        'dTanggal
        '
        Me.dTanggal.BorderRadius = 6
        Me.dTanggal.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDot
        Me.dTanggal.BorderThickness = 1
        Me.dTanggal.CheckedState.Parent = Me.dTanggal
        Me.dTanggal.FillColor = System.Drawing.Color.White
        Me.dTanggal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dTanggal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dTanggal.HoverState.Parent = Me.dTanggal
        Me.dTanggal.Location = New System.Drawing.Point(15, 36)
        Me.dTanggal.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dTanggal.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dTanggal.Name = "dTanggal"
        Me.dTanggal.ShadowDecoration.Parent = Me.dTanggal
        Me.dTanggal.Size = New System.Drawing.Size(181, 36)
        Me.dTanggal.TabIndex = 4
        Me.dTanggal.Value = New Date(2026, 8, 26, 15, 32, 2, 46)
        '
        'tKeterangan
        '
        Me.tKeterangan.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.tKeterangan.BorderRadius = 6
        Me.tKeterangan.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tKeterangan.DefaultText = ""
        Me.tKeterangan.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.tKeterangan.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.tKeterangan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.tKeterangan.DisabledState.Parent = Me.tKeterangan
        Me.tKeterangan.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.tKeterangan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tKeterangan.FocusedState.Parent = Me.tKeterangan
        Me.tKeterangan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.tKeterangan.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tKeterangan.HoverState.Parent = Me.tKeterangan
        Me.tKeterangan.Location = New System.Drawing.Point(15, 102)
        Me.tKeterangan.Name = "tKeterangan"
        Me.tKeterangan.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.tKeterangan.PlaceholderText = "Libur Natal"
        Me.tKeterangan.SelectedText = ""
        Me.tKeterangan.ShadowDecoration.Parent = Me.tKeterangan
        Me.tKeterangan.Size = New System.Drawing.Size(452, 38)
        Me.tKeterangan.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(26, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Keterangan"
        '
        'lblKode
        '
        Me.lblKode.AutoSize = True
        Me.lblKode.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.lblKode.Location = New System.Drawing.Point(26, 18)
        Me.lblKode.Name = "lblKode"
        Me.lblKode.Size = New System.Drawing.Size(49, 15)
        Me.lblKode.TabIndex = 0
        Me.lblKode.Text = "Tanggal"
        '
        'pnlFooter
        '
        Me.pnlFooter.BorderColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.pnlFooter.Controls.Add(Me.flpFooterButton)
        Me.pnlFooter.Controls.Add(Me.pnlFooterLine)
        Me.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlFooter.Location = New System.Drawing.Point(0, 236)
        Me.pnlFooter.Name = "pnlFooter"
        Me.pnlFooter.ShadowDecoration.Parent = Me.pnlFooter
        Me.pnlFooter.Size = New System.Drawing.Size(484, 65)
        Me.pnlFooter.TabIndex = 3
        '
        'flpFooterButton
        '
        Me.flpFooterButton.Controls.Add(Me.bBatal)
        Me.flpFooterButton.Controls.Add(Me.bSimpan)
        Me.flpFooterButton.Dock = System.Windows.Forms.DockStyle.Right
        Me.flpFooterButton.Location = New System.Drawing.Point(274, 1)
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
        Me.pnlFooterLine.Size = New System.Drawing.Size(484, 1)
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
        Me.pnlHeader.Size = New System.Drawing.Size(484, 70)
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
        Me.bClose.Location = New System.Drawing.Point(450, 12)
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
        Me.lblDescription.Location = New System.Drawing.Point(23, 40)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(258, 15)
        Me.lblDescription.TabIndex = 1
        Me.lblDescription.Text = "Tambahkan kalender libur baru ke dalam sistem"
        '
        'pnlHeaderLine
        '
        Me.pnlHeaderLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.pnlHeaderLine.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlHeaderLine.Location = New System.Drawing.Point(0, 69)
        Me.pnlHeaderLine.Name = "pnlHeaderLine"
        Me.pnlHeaderLine.ShadowDecoration.Parent = Me.pnlHeaderLine
        Me.pnlHeaderLine.Size = New System.Drawing.Size(484, 1)
        Me.pnlHeaderLine.TabIndex = 1
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(24, 12)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(208, 25)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Tambah Kalender Libur"
        '
        'frmKalenderAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(484, 301)
        Me.Controls.Add(Me.pnlMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmKalenderAdd"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmKalenderAdd"
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
    Friend WithEvents dTanggal As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents tKeterangan As Guna.UI2.WinForms.Guna2TextBox
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
End Class
