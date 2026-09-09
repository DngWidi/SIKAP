<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKeahlianAdd
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
        Me.ctingkat = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.tkeahlian = New Guna.UI2.WinForms.Guna2TextBox()
        Me.tketerangan = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
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
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.ShadowDecoration.Parent = Me.pnlMain
        Me.pnlMain.Size = New System.Drawing.Size(430, 376)
        Me.pnlMain.TabIndex = 3
        '
        'pnlBody
        '
        Me.pnlBody.Controls.Add(Me.ctingkat)
        Me.pnlBody.Controls.Add(Me.tkeahlian)
        Me.pnlBody.Controls.Add(Me.tketerangan)
        Me.pnlBody.Controls.Add(Me.Label3)
        Me.pnlBody.Controls.Add(Me.Label1)
        Me.pnlBody.Controls.Add(Me.lblKode)
        Me.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBody.Location = New System.Drawing.Point(0, 70)
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.Padding = New System.Windows.Forms.Padding(24, 18, 24, 10)
        Me.pnlBody.ShadowDecoration.Parent = Me.pnlBody
        Me.pnlBody.Size = New System.Drawing.Size(430, 241)
        Me.pnlBody.TabIndex = 4
        '
        'ctingkat
        '
        Me.ctingkat.BackColor = System.Drawing.Color.Transparent
        Me.ctingkat.BorderRadius = 6
        Me.ctingkat.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ctingkat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ctingkat.FocusedColor = System.Drawing.Color.Empty
        Me.ctingkat.FocusedState.Parent = Me.ctingkat
        Me.ctingkat.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ctingkat.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.ctingkat.FormattingEnabled = True
        Me.ctingkat.HoverState.Parent = Me.ctingkat
        Me.ctingkat.ItemHeight = 30
        Me.ctingkat.ItemsAppearance.Parent = Me.ctingkat
        Me.ctingkat.Location = New System.Drawing.Point(15, 92)
        Me.ctingkat.Name = "ctingkat"
        Me.ctingkat.ShadowDecoration.Parent = Me.ctingkat
        Me.ctingkat.Size = New System.Drawing.Size(403, 36)
        Me.ctingkat.TabIndex = 5
        '
        'tkeahlian
        '
        Me.tkeahlian.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.tkeahlian.BorderRadius = 6
        Me.tkeahlian.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tkeahlian.DefaultText = ""
        Me.tkeahlian.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.tkeahlian.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.tkeahlian.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.tkeahlian.DisabledState.Parent = Me.tkeahlian
        Me.tkeahlian.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.tkeahlian.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tkeahlian.FocusedState.Parent = Me.tkeahlian
        Me.tkeahlian.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.tkeahlian.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tkeahlian.HoverState.Parent = Me.tkeahlian
        Me.tkeahlian.Location = New System.Drawing.Point(15, 32)
        Me.tkeahlian.Name = "tkeahlian"
        Me.tkeahlian.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.tkeahlian.PlaceholderText = ""
        Me.tkeahlian.SelectedText = ""
        Me.tkeahlian.ShadowDecoration.Parent = Me.tkeahlian
        Me.tkeahlian.Size = New System.Drawing.Size(404, 38)
        Me.tkeahlian.TabIndex = 4
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
        Me.tketerangan.Location = New System.Drawing.Point(15, 153)
        Me.tketerangan.Multiline = True
        Me.tketerangan.Name = "tketerangan"
        Me.tketerangan.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.tketerangan.PlaceholderText = ""
        Me.tketerangan.SelectedText = ""
        Me.tketerangan.ShadowDecoration.Parent = Me.tketerangan
        Me.tketerangan.Size = New System.Drawing.Size(404, 82)
        Me.tketerangan.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(15, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 15)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Keterangan"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(15, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Tingkat *"
        '
        'lblKode
        '
        Me.lblKode.AutoSize = True
        Me.lblKode.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.lblKode.Location = New System.Drawing.Point(15, 13)
        Me.lblKode.Name = "lblKode"
        Me.lblKode.Size = New System.Drawing.Size(60, 15)
        Me.lblKode.TabIndex = 0
        Me.lblKode.Text = "Keahlian *"
        '
        'pnlFooter
        '
        Me.pnlFooter.BorderColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.pnlFooter.Controls.Add(Me.flpFooterButton)
        Me.pnlFooter.Controls.Add(Me.pnlFooterLine)
        Me.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlFooter.Location = New System.Drawing.Point(0, 311)
        Me.pnlFooter.Name = "pnlFooter"
        Me.pnlFooter.ShadowDecoration.Parent = Me.pnlFooter
        Me.pnlFooter.Size = New System.Drawing.Size(430, 65)
        Me.pnlFooter.TabIndex = 3
        '
        'flpFooterButton
        '
        Me.flpFooterButton.Controls.Add(Me.bBatal)
        Me.flpFooterButton.Controls.Add(Me.bSimpan)
        Me.flpFooterButton.Dock = System.Windows.Forms.DockStyle.Right
        Me.flpFooterButton.Location = New System.Drawing.Point(220, 1)
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
        Me.pnlFooterLine.Size = New System.Drawing.Size(430, 1)
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
        Me.pnlHeader.Size = New System.Drawing.Size(430, 70)
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
        Me.bClose.Location = New System.Drawing.Point(396, 12)
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
        Me.pnlHeaderLine.Size = New System.Drawing.Size(430, 1)
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
        'frmKeahlianAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(430, 376)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmKeahlianAdd"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmKeahlianAdd"
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
    Friend WithEvents tkeahlian As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents tketerangan As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label3 As Label
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
    Friend WithEvents ctingkat As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Guna2Elipse1 As Guna.UI2.WinForms.Guna2Elipse
End Class
