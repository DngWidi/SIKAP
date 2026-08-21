<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class f_pesan
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
        Me.pnlFooter = New Guna.UI2.WinForms.Guna2Panel()
        Me.bYes = New Guna.UI2.WinForms.Guna2Button()
        Me.bNo = New Guna.UI2.WinForms.Guna2Button()
        Me.bOk = New Guna.UI2.WinForms.Guna2Button()
        Me.picIcon = New System.Windows.Forms.PictureBox()
        Me.lPesan = New System.Windows.Forms.Label()
        Me.pnlHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lJudul = New System.Windows.Forms.Label()
        Me.Guna2Elipse1 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.pnlMain.SuspendLayout()
        Me.pnlBody.SuspendLayout()
        Me.pnlFooter.SuspendLayout()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHeader.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.BorderRadius = 9
        Me.pnlMain.Controls.Add(Me.pnlBody)
        Me.pnlMain.Controls.Add(Me.pnlHeader)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.FillColor = System.Drawing.Color.White
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.ShadowDecoration.Parent = Me.pnlMain
        Me.pnlMain.Size = New System.Drawing.Size(466, 221)
        Me.pnlMain.TabIndex = 0
        '
        'pnlBody
        '
        Me.pnlBody.Controls.Add(Me.pnlFooter)
        Me.pnlBody.Controls.Add(Me.picIcon)
        Me.pnlBody.Controls.Add(Me.lPesan)
        Me.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBody.FillColor = System.Drawing.Color.White
        Me.pnlBody.Location = New System.Drawing.Point(0, 60)
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.ShadowDecoration.Parent = Me.pnlBody
        Me.pnlBody.Size = New System.Drawing.Size(466, 161)
        Me.pnlBody.TabIndex = 1
        '
        'pnlFooter
        '
        Me.pnlFooter.Controls.Add(Me.bYes)
        Me.pnlFooter.Controls.Add(Me.bNo)
        Me.pnlFooter.Controls.Add(Me.bOk)
        Me.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlFooter.FillColor = System.Drawing.Color.White
        Me.pnlFooter.Location = New System.Drawing.Point(0, 96)
        Me.pnlFooter.Name = "pnlFooter"
        Me.pnlFooter.ShadowDecoration.Parent = Me.pnlFooter
        Me.pnlFooter.Size = New System.Drawing.Size(466, 65)
        Me.pnlFooter.TabIndex = 2
        '
        'bYes
        '
        Me.bYes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bYes.BorderRadius = 8
        Me.bYes.CheckedState.Parent = Me.bYes
        Me.bYes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bYes.CustomImages.Parent = Me.bYes
        Me.bYes.FillColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.bYes.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bYes.ForeColor = System.Drawing.Color.White
        Me.bYes.HoverState.Parent = Me.bYes
        Me.bYes.Location = New System.Drawing.Point(356, 13)
        Me.bYes.Name = "bYes"
        Me.bYes.ShadowDecoration.Parent = Me.bYes
        Me.bYes.Size = New System.Drawing.Size(90, 38)
        Me.bYes.TabIndex = 2
        Me.bYes.Text = "Ya"
        '
        'bNo
        '
        Me.bNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bNo.BorderRadius = 8
        Me.bNo.CheckedState.Parent = Me.bNo
        Me.bNo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bNo.CustomImages.Parent = Me.bNo
        Me.bNo.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.bNo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bNo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.bNo.HoverState.Parent = Me.bNo
        Me.bNo.Location = New System.Drawing.Point(256, 13)
        Me.bNo.Name = "bNo"
        Me.bNo.ShadowDecoration.Parent = Me.bNo
        Me.bNo.Size = New System.Drawing.Size(90, 38)
        Me.bNo.TabIndex = 1
        Me.bNo.Text = "Tidak"
        '
        'bOk
        '
        Me.bOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bOk.BorderRadius = 8
        Me.bOk.CheckedState.Parent = Me.bOk
        Me.bOk.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bOk.CustomImages.Parent = Me.bOk
        Me.bOk.FillColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.bOk.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bOk.ForeColor = System.Drawing.Color.White
        Me.bOk.HoverState.Parent = Me.bOk
        Me.bOk.Location = New System.Drawing.Point(356, 13)
        Me.bOk.Name = "bOk"
        Me.bOk.ShadowDecoration.Parent = Me.bOk
        Me.bOk.Size = New System.Drawing.Size(90, 38)
        Me.bOk.TabIndex = 0
        Me.bOk.Text = "OK"
        '
        'picIcon
        '
        Me.picIcon.Location = New System.Drawing.Point(30, 17)
        Me.picIcon.Name = "picIcon"
        Me.picIcon.Size = New System.Drawing.Size(55, 55)
        Me.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picIcon.TabIndex = 1
        Me.picIcon.TabStop = False
        '
        'lPesan
        '
        Me.lPesan.BackColor = System.Drawing.Color.Transparent
        Me.lPesan.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lPesan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lPesan.Location = New System.Drawing.Point(91, 9)
        Me.lPesan.Name = "lPesan"
        Me.lPesan.Size = New System.Drawing.Size(390, 70)
        Me.lPesan.TabIndex = 0
        Me.lPesan.Text = "Isi pesan akan ditampilakan di sini."
        Me.lPesan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.PictureBox1)
        Me.pnlHeader.Controls.Add(Me.lJudul)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.FillColor = System.Drawing.Color.White
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.ShadowDecoration.Parent = Me.pnlHeader
        Me.pnlHeader.Size = New System.Drawing.Size(466, 60)
        Me.pnlHeader.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(20, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(28, 28)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'lJudul
        '
        Me.lJudul.AutoSize = True
        Me.lJudul.BackColor = System.Drawing.Color.Transparent
        Me.lJudul.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lJudul.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.lJudul.Location = New System.Drawing.Point(60, 18)
        Me.lJudul.Name = "lJudul"
        Me.lJudul.Size = New System.Drawing.Size(85, 20)
        Me.lJudul.TabIndex = 0
        Me.lJudul.Text = "Peringatan"
        '
        'Guna2Elipse1
        '
        Me.Guna2Elipse1.BorderRadius = 12
        Me.Guna2Elipse1.TargetControl = Me
        '
        'f_pesan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(466, 221)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "f_pesan"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Pesan"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlBody.ResumeLayout(False)
        Me.pnlFooter.ResumeLayout(False)
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlMain As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pnlHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pnlBody As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lJudul As Label
    Friend WithEvents pnlFooter As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents picIcon As PictureBox
    Friend WithEvents lPesan As Label
    Friend WithEvents bYes As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents bNo As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents bOk As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Elipse1 As Guna.UI2.WinForms.Guna2Elipse
End Class
