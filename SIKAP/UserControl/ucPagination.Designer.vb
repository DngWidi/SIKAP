<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucPagination
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
        Me.flpPagination = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblRows = New System.Windows.Forms.Label()
        Me.cmbPageSize = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.bFirst = New Guna.UI2.WinForms.Guna2Button()
        Me.bPrev = New Guna.UI2.WinForms.Guna2Button()
        Me.bNext = New Guna.UI2.WinForms.Guna2Button()
        Me.bLast = New Guna.UI2.WinForms.Guna2Button()
        Me.flpPagination.SuspendLayout()
        Me.SuspendLayout()
        '
        'flpPagination
        '
        Me.flpPagination.BackColor = System.Drawing.Color.Transparent
        Me.flpPagination.Controls.Add(Me.lblRows)
        Me.flpPagination.Controls.Add(Me.cmbPageSize)
        Me.flpPagination.Controls.Add(Me.bFirst)
        Me.flpPagination.Controls.Add(Me.bPrev)
        Me.flpPagination.Controls.Add(Me.bNext)
        Me.flpPagination.Controls.Add(Me.bLast)
        Me.flpPagination.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpPagination.Location = New System.Drawing.Point(0, 0)
        Me.flpPagination.Margin = New System.Windows.Forms.Padding(0)
        Me.flpPagination.Name = "flpPagination"
        Me.flpPagination.Size = New System.Drawing.Size(291, 44)
        Me.flpPagination.TabIndex = 0
        Me.flpPagination.WrapContents = False
        '
        'lblRows
        '
        Me.lblRows.AutoSize = True
        Me.lblRows.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRows.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblRows.Location = New System.Drawing.Point(3, 13)
        Me.lblRows.Margin = New System.Windows.Forms.Padding(3, 13, 3, 0)
        Me.lblRows.Name = "lblRows"
        Me.lblRows.Size = New System.Drawing.Size(35, 15)
        Me.lblRows.TabIndex = 1
        Me.lblRows.Text = "Rows"
        '
        'cmbPageSize
        '
        Me.cmbPageSize.BackColor = System.Drawing.Color.Transparent
        Me.cmbPageSize.BorderRadius = 6
        Me.cmbPageSize.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbPageSize.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbPageSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPageSize.FocusedColor = System.Drawing.Color.Empty
        Me.cmbPageSize.FocusedState.Parent = Me.cmbPageSize
        Me.cmbPageSize.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbPageSize.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cmbPageSize.FormattingEnabled = True
        Me.cmbPageSize.HoverState.Parent = Me.cmbPageSize
        Me.cmbPageSize.ItemHeight = 30
        Me.cmbPageSize.Items.AddRange(New Object() {"10", "25", "50", "100"})
        Me.cmbPageSize.ItemsAppearance.Parent = Me.cmbPageSize
        Me.cmbPageSize.Location = New System.Drawing.Point(44, 3)
        Me.cmbPageSize.Name = "cmbPageSize"
        Me.cmbPageSize.ShadowDecoration.Parent = Me.cmbPageSize
        Me.cmbPageSize.Size = New System.Drawing.Size(70, 36)
        Me.cmbPageSize.StartIndex = 0
        Me.cmbPageSize.TabIndex = 2
        '
        'bFirst
        '
        Me.bFirst.BorderRadius = 6
        Me.bFirst.CheckedState.Parent = Me.bFirst
        Me.bFirst.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bFirst.CustomImages.Parent = Me.bFirst
        Me.bFirst.FillColor = System.Drawing.Color.Transparent
        Me.bFirst.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.bFirst.ForeColor = System.Drawing.Color.Black
        Me.bFirst.HoverState.Parent = Me.bFirst
        Me.bFirst.Location = New System.Drawing.Point(120, 3)
        Me.bFirst.Name = "bFirst"
        Me.bFirst.ShadowDecoration.Parent = Me.bFirst
        Me.bFirst.Size = New System.Drawing.Size(32, 32)
        Me.bFirst.TabIndex = 9
        Me.bFirst.Text = "<<"
        '
        'bPrev
        '
        Me.bPrev.BorderRadius = 6
        Me.bPrev.CheckedState.Parent = Me.bPrev
        Me.bPrev.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bPrev.CustomImages.Parent = Me.bPrev
        Me.bPrev.FillColor = System.Drawing.Color.Transparent
        Me.bPrev.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.bPrev.ForeColor = System.Drawing.Color.Black
        Me.bPrev.HoverState.Parent = Me.bPrev
        Me.bPrev.Location = New System.Drawing.Point(158, 3)
        Me.bPrev.Name = "bPrev"
        Me.bPrev.ShadowDecoration.Parent = Me.bPrev
        Me.bPrev.Size = New System.Drawing.Size(32, 32)
        Me.bPrev.TabIndex = 10
        Me.bPrev.Text = "<"
        '
        'bNext
        '
        Me.bNext.BorderRadius = 6
        Me.bNext.CheckedState.Parent = Me.bNext
        Me.bNext.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bNext.CustomImages.Parent = Me.bNext
        Me.bNext.FillColor = System.Drawing.Color.Transparent
        Me.bNext.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.bNext.ForeColor = System.Drawing.Color.Black
        Me.bNext.HoverState.Parent = Me.bNext
        Me.bNext.Location = New System.Drawing.Point(196, 3)
        Me.bNext.Name = "bNext"
        Me.bNext.ShadowDecoration.Parent = Me.bNext
        Me.bNext.Size = New System.Drawing.Size(32, 32)
        Me.bNext.TabIndex = 14
        Me.bNext.Text = ">"
        '
        'bLast
        '
        Me.bLast.BorderRadius = 6
        Me.bLast.CheckedState.Parent = Me.bLast
        Me.bLast.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bLast.CustomImages.Parent = Me.bLast
        Me.bLast.FillColor = System.Drawing.Color.Transparent
        Me.bLast.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.bLast.ForeColor = System.Drawing.Color.Black
        Me.bLast.HoverState.Parent = Me.bLast
        Me.bLast.Location = New System.Drawing.Point(234, 3)
        Me.bLast.Name = "bLast"
        Me.bLast.ShadowDecoration.Parent = Me.bLast
        Me.bLast.Size = New System.Drawing.Size(32, 32)
        Me.bLast.TabIndex = 15
        Me.bLast.Text = ">>"
        '
        'ucPagination
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Controls.Add(Me.flpPagination)
        Me.Name = "ucPagination"
        Me.Size = New System.Drawing.Size(291, 44)
        Me.flpPagination.ResumeLayout(False)
        Me.flpPagination.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents flpPagination As FlowLayoutPanel
    Friend WithEvents lblRows As Label
    Friend WithEvents cmbPageSize As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents bFirst As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents bPrev As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents bNext As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents bLast As Guna.UI2.WinForms.Guna2Button
End Class
