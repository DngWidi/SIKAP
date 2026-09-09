Imports Guna.UI2.WinForms

Public Class Menu_Utama
    Private bDashboard, bRecruitment, bEmployee, bAttendance, bOvertime, bLeave, bPerformance, bPayroll, bResign, bMaster, bReport, bSetting, bSelfService As Guna2Button
    Private lblHeader As Label


    ' FlowLayoutPanel untuk Sub Menu
    ' Private flpSubMenu As FlowLayoutPanel

    ' Panel Submenu
    Private pnlSubRecruitment As New FlowLayoutPanel With {
    .AutoSize = True,
    .AutoSizeMode = AutoSizeMode.GrowAndShrink,
    .FlowDirection = FlowDirection.TopDown,
    .WrapContents = False,
    .Visible = False,
    .Dock = DockStyle.Top,
    .Padding = New Padding(20, 2, 5, 2)
}

    Private Sub bMax_Click(sender As Object, e As EventArgs) Handles bMax.Click
        If Me.WindowState = FormWindowState.Normal Then

            Me.WindowState = FormWindowState.Maximized

        Else

            Me.WindowState = FormWindowState.Normal

        End If
    End Sub

    Private Sub bMin_Click(sender As Object, e As EventArgs) Handles bMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private pnlSubMaster As New FlowLayoutPanel With {
    .AutoSize = True,
    .AutoSizeMode = AutoSizeMode.GrowAndShrink,
    .FlowDirection = FlowDirection.TopDown,
    .WrapContents = False,
    .Visible = False,
    .Dock = DockStyle.Top,
    .Padding = New Padding(20, 2, 5, 2)
}
#Region "FUNCTION"
    '========== BUTTON UTAMA ==========
    Private Function BuatButtonUtama(ByVal text As String, ByVal name As String, ByVal iconNormal As Image) As Guna.UI2.WinForms.Guna2Button
        ' HITUNG LEBAR TOMBOL - KURANGI 20px untuk margin
        Dim btnWidth As Integer = flpMenu.Width - 45
        Dim btn As New Guna.UI2.WinForms.Guna2Button With {
            .Text = "  " & text,
            .Name = name,
            .Dock = DockStyle.None,
            .FillColor = Color.Transparent,
            .ForeColor = Color.White,
            .Font = New Font("Segoe UI", 9, FontStyle.Regular),
            .Size = New Size(btnWidth, 35),
            .TextAlign = HorizontalAlignment.Left,
            .Cursor = Cursors.Hand,
            .Margin = New Padding(0, 2, 0, 2),
            .BorderRadius = 5,
            .Image = iconNormal,
            .Tag = New Object() {iconNormal},
            .ImageAlign = HorizontalAlignment.Left,
            .ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton
            }
        ' 2. Atur State di luar blok With agar tidak error
        btn.HoverState.FillColor = Color.CornflowerBlue
        btn.HoverState.ForeColor = Color.White

        btn.CheckedState.FillColor = Color.CornflowerBlue
        btn.CheckedState.ForeColor = Color.White

        Return btn
    End Function
    '========== BUTTON SUB MENU ==========
    Private Function BuatSubButton(ByVal text As String, ByVal name As String, ByVal icon As Image, ByVal enable As Boolean) As Guna.UI2.WinForms.Guna2Button
        Dim btn As New Guna.UI2.WinForms.Guna2Button With {
            .Text = text,
            .Name = name,
            .Size = New Size(flpMenu.Width - 45, 35),
            .Font = New Font("Segoe UI", 9, FontStyle.Regular),
            .Image = icon,
            .ImageAlign = HorizontalAlignment.Left,
            .TextAlign = HorizontalAlignment.Left,
            .TextOffset = New Point(5, 0),
            .FillColor = Color.Transparent,
            .ForeColor = Color.White,
            .Cursor = Cursors.Hand,
            .Margin = New Padding(5, 2, 5, 2),
            .BorderRadius = 5,
            .Enabled = enable,
            .BackColor = Color.Transparent
        }
        '  .FillColor = Color.FromArgb(240, 240, 240),
        ' .ForeColor = Color.FromArgb(50, 50, 50),
        ' Hover State untuk sub button
        btn.HoverState.FillColor = Color.LightSteelBlue
        btn.HoverState.ForeColor = Color.Black
        btn.CheckedState.FillColor = Color.CornflowerBlue
        btn.CheckedState.ForeColor = Color.White

        ' Tambahkan handler berdasarkan nama (sesuai dengan kebutuhan Anda)
        Select Case name
            ' Untuk Menu Recruitment
            Case "bPermintaanKaryawan"
                AddHandler btn.Click, AddressOf bPermintaanKaryawan_Click
            Case "bKandidat"
                AddHandler btn.Click, AddressOf bKandidat_Click
            Case "bInterview"
              '  AddHandler btn.Click, AddressOf bInterview_Click

            ' Untuk Menu Employee
            Case "bEmployeeData"
            '    AddHandler btn.Click, AddressOf bEmployeeData_Click
            Case "bEmployeeProfile"
             '   AddHandler btn.Click, AddressOf bEmployeeProfile_Click
            Case "bOrganization"
             '   AddHandler btn.Click, AddressOf bOrganization_Click
          '  Case "bDepartment"
              '  AddHandler btn.Click, AddressOf bDepartment_Click
            Case "bPosition"
              '  AddHandler btn.Click, AddressOf bPosition_Click

            ' Untuk Menu Attendance
            Case "bAttendanceList"
              '  AddHandler btn.Click, AddressOf bAttendanceList_Click
            Case "bAttendanceReport"
               ' AddHandler btn.Click, AddressOf bAttendanceReport_Click

            ' Untuk Menu Overtime
            Case "bOvertimeRequest"
               ' AddHandler btn.Click, AddressOf bOvertimeRequest_Click
            Case "bOvertimeApproval"
               ' AddHandler btn.Click, AddressOf bOvertimeApproval_Click
            Case "bOvertimeReport"
                'AddHandler btn.Click, AddressOf bOvertimeReport_Click

            ' Untuk Menu Leave Management
            Case "bLeaveRequest"
               ' AddHandler btn.Click, AddressOf bLeaveRequest_Click
            Case "bLeaveApproval"
              '  AddHandler btn.Click, AddressOf bLeaveApproval_Click
            Case "bLeaveBalance"
               ' AddHandler btn.Click, AddressOf bLeaveBalance_Click
            Case "bLeaveCalendar"
               ' AddHandler btn.Click, AddressOf bLeaveCalendar_Click

            ' Untuk Menu Performance Appraisal
            Case "bPerformanceForm"
               ' AddHandler btn.Click, AddressOf bPerformanceForm_Click
            Case "bPerformanceReview"
               ' AddHandler btn.Click, AddressOf bPerformanceReview_Click
            Case "bGoalSetting"
               ' AddHandler btn.Click, AddressOf bGoalSetting_Click
            Case "bTraining"
               ' AddHandler btn.Click, AddressOf bTraining_Click

            ' Untuk Menu Payroll
            Case "bPayrollSetting"
               ' AddHandler btn.Click, AddressOf bPayrollSetting_Click
            Case "bProcessPayroll"
               ' AddHandler btn.Click, AddressOf bProcessPayroll_Click
            Case "bPayslip"
               ' AddHandler btn.Click, AddressOf bPayslip_Click
            Case "bPayrollReport"
               ' AddHandler btn.Click, AddressOf bPayrollReport_Click
            Case "bBPJS"
               ' AddHandler btn.Click, AddressOf bBPJS_Click
            Case "bPPh21"
               ' AddHandler btn.Click, AddressOf bPPh21_Click

            ' Untuk Menu Resign
            Case "bResignRequest"
               ' AddHandler btn.Click, AddressOf bResignRequest_Click
            Case "bResignApproval"
               ' AddHandler btn.Click, AddressOf bResignApproval_Click
            Case "bExitInterview"
               ' AddHandler btn.Click, AddressOf bExitInterview_Click

            ' Untuk Menu Master Data
            Case "bDepartment"
                AddHandler btn.Click, AddressOf bDepartment_Click
            Case "bBagian"
                AddHandler btn.Click, AddressOf bBagian_Click
            Case "bJabatan"
                AddHandler btn.Click, AddressOf bJabatan_Click
            Case "bBiaya"
                AddHandler btn.Click, AddressOf bBiaya_Click
            Case "bKodeAbsen"
                AddHandler btn.Click, AddressOf bKodeAbsen_Click
            Case "bKalender"
                AddHandler btn.Click, AddressOf bKalender_Click

            ' Untuk Menu Report
            Case "bReportEmployee"
               ' AddHandler btn.Click, AddressOf bReportEmployee_Click
            Case "bReportAttendance"
               ' AddHandler btn.Click, AddressOf bReportAttendance_Click
            Case "bReportPayroll"
              '  AddHandler btn.Click, AddressOf bReportPayroll_Click
            Case "bReportCustom"
              '  AddHandler btn.Click, AddressOf bReportCustom_Click

            ' Untuk Menu Setting
            Case "bUserManagement"
               ' AddHandler btn.Click, AddressOf bUserManagement_Click
            Case "bRoleAccess"
              '  AddHandler btn.Click, AddressOf bRoleAccess_Click
            Case "bSystemConfig"
               ' AddHandler btn.Click, AddressOf bSystemConfig_Click
            Case "bBackupDB"
               ' AddHandler btn.Click, AddressOf bBackupDB_Click
            Case "bRestoreDB"
               ' AddHandler btn.Click, AddressOf bRestoreDB_Click

            ' Untuk Menu Employee Self-Service
            Case "bMyProfile"
               ' AddHandler btn.Click, AddressOf bMyProfile_Click
            Case "bMyLeave"
               ' AddHandler btn.Click, AddressOf bMyLeave_Click
            Case "bMyPayslip"
                'AddHandler btn.Click, AddressOf bMyPayslip_Click
            Case "bMyAttendance"
                'AddHandler btn.Click, AddressOf bMyAttendance_Click
        End Select

        Return btn
    End Function
    '================ BUAT LABEL MAIN MENU ==============
    Private Function BuatLabelHeader(ByVal text As String) As Label
        Dim lblWidth As Integer = flpMenu.Width - 25
        Dim lbl As New Label With {
            .Text = text,
            .Font = New Font("Segoe UI", 8, FontStyle.Bold),
            .ForeColor = Color.White,
            .AutoSize = False,
            .Height = 20,
            .Width = lblWidth,
            .TextAlign = ContentAlignment.MiddleLeft,
            .Margin = New Padding(0, 20, 0, 5),
            .BackColor = Color.Transparent
        }
        Return lbl
    End Function
    ' .ForeColor = Color.FromArgb(105, 105, 105),
#End Region
#Region "PRIVATE"
    Private Sub ResetSubMenuMaster()
        ' Matikan semua tombol submenu Master Data
        For Each ctrl As Control In pnlSubMaster.Controls

            If TypeOf ctrl Is Guna2Button Then
                DirectCast(ctrl, Guna2Button).Checked = False
            End If

        Next
    End Sub
    Private Sub LoadUserControl(uc As UserControl)
        pnlForm.BringToFront()
        pnlForm.SuspendLayout()

        For Each ctrl As Control In pnlForm.Controls
            ctrl.Dispose()
        Next
        pnlForm.Controls.Clear()

        uc.Dock = DockStyle.Fill
        pnlForm.Controls.Add(uc)

        pnlForm.ResumeLayout()

    End Sub
    '================ BUAT LABEL MAIN MENU ==============
    Private Sub HideAllSubMenu()
        pnlSubRecruitment.Visible = False
        pnlSubMaster.Visible = False


    End Sub

    '========= Recruitment ========
    Private Sub bRecruitment_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn = DirectCast(sender, Guna.UI2.WinForms.Guna2Button)
        Dim icons = DirectCast(btn.Tag, Object())

        'Jika submenu Master sedang terbuka maka cukup ditutup
        If pnlSubRecruitment.Visible Then

            pnlSubRecruitment.Visible = False
            btn.Image = DirectCast(icons(0), Image)

            Exit Sub

        End If

        'Tutup semua submenu
        HideAllSubMenu()

        'Reset semua icon menu utama
        '  ResetMenuIcon()

        pnlSubRecruitment.SuspendLayout()

        pnlSubRecruitment.Controls.Clear()

        pnlSubRecruitment.Controls.Add(BuatSubButton("   Permintaan Karyawan", "bPermintaanKaryawan", My.Resources.Lowongan, True))
        pnlSubRecruitment.Controls.Add(BuatSubButton("   Kandidat", "bKandidat", My.Resources.Kandidat, True))
        pnlSubRecruitment.Controls.Add(BuatSubButton("   Seleksi", "bKirim", My.Resources.Seleksi, True))
        pnlSubRecruitment.Controls.Add(BuatSubButton("   Penilaian Interview", "bGroup", My.Resources.Interview, True))
        pnlSubRecruitment.Controls.Add(BuatSubButton("   Penawaran Kerja", "bUsaha", My.Resources.Kontrak, True))
        pnlSubRecruitment.Controls.Add(BuatSubButton("   Calon Pegawai", "bSegmen", My.Resources.Calonpegawai, True))

        pnlSubRecruitment.Visible = True

        '  btn.Image = DirectCast(icons(1), Image)

        pnlSubRecruitment.ResumeLayout()

        pnlSubRecruitment.PerformLayout()

    End Sub
    Private Sub bPermintaanKaryawan_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Matikan semua submenu Master Data
        ResetSubMenuMaster()

        ' Aktifkan tombol yang sedang dipilih
        Dim btn = DirectCast(sender, Guna2Button)
        btn.Checked = True

        ' Aktifkan menu utama Master Data
        bMaster.Checked = True

        ' Tampilkan UserControl Department
        LoadUserControl(New uf_permintaankaryawan())
    End Sub
    Private Sub bKandidat_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Matikan semua submenu Master Data
        ResetSubMenuMaster()

        ' Aktifkan tombol yang sedang dipilih
        Dim btn = DirectCast(sender, Guna2Button)
        btn.Checked = True

        ' Aktifkan menu utama Master Data
        bMaster.Checked = True

        ' Tampilkan UserControl Department
        LoadUserControl(New uf_kandidat())
    End Sub
    '============== Employee ==========
    '=========== Master Data =========
    Private Sub bMaster_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn = DirectCast(sender, Guna.UI2.WinForms.Guna2Button)
        Dim icons = DirectCast(btn.Tag, Object())

        'Jika submenu Master sedang terbuka maka cukup ditutup
        If pnlSubMaster.Visible Then

            pnlSubMaster.Visible = False
            btn.Image = DirectCast(icons(0), Image)

            Exit Sub

        End If

        'Tutup semua submenu
        HideAllSubMenu()

        'Reset semua icon menu utama
        '  ResetMenuIcon()

        pnlSubMaster.SuspendLayout()

        pnlSubMaster.Controls.Clear()

        pnlSubMaster.Controls.Add(BuatSubButton("   Department", "bDepartment", My.Resources.Department, True))
        pnlSubMaster.Controls.Add(BuatSubButton("   Bagian", "bBagian", My.Resources.Bagian, True))
        pnlSubMaster.Controls.Add(BuatSubButton("   Jabatan", "bJabatan", My.Resources.Jabatan, True))
        pnlSubMaster.Controls.Add(BuatSubButton("   Kode Biaya", "bBiaya", My.Resources.Kodebiaya, True))
        pnlSubMaster.Controls.Add(BuatSubButton("   Kode Absensi", "bKodeAbsen", My.Resources.Kodeabsen, True))
        pnlSubMaster.Controls.Add(BuatSubButton("   Kalender Libur", "bKalender", My.Resources.Kalender, True))

        pnlSubMaster.Visible = True

        '  btn.Image = DirectCast(icons(1), Image)

        pnlSubMaster.ResumeLayout()

        pnlSubMaster.PerformLayout()

    End Sub
    Private Sub bDepartment_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Matikan semua submenu Master Data
        ResetSubMenuMaster()

        ' Aktifkan tombol yang sedang dipilih
        Dim btn = DirectCast(sender, Guna2Button)
        btn.Checked = True

        ' Aktifkan menu utama Master Data
        bMaster.Checked = True

        ' Tampilkan UserControl Department
        LoadUserControl(New uf_department())


    End Sub
    Private Sub bBagian_Click(ByVal sender As Object, ByVal e As EventArgs)

        ' Matikan semua submenu Master Data
        ResetSubMenuMaster()

        ' Aktifkan tombol yang sedang dipilih
        Dim btn = DirectCast(sender, Guna2Button)
        btn.Checked = True

        ' Aktifkan menu utama Master Data
        bMaster.Checked = True

        ' Tampilkan UserControl Department
        LoadUserControl(New uf_bagian())
    End Sub
    Private Sub bJabatan_Click(ByVal sender As Object, ByVal e As EventArgs)

        ' Matikan semua submenu Master Data
        ResetSubMenuMaster()

        ' Aktifkan tombol yang sedang dipilih
        Dim btn = DirectCast(sender, Guna2Button)
        btn.Checked = True

        ' Aktifkan menu utama Master Data
        bMaster.Checked = True

        ' Tampilkan UserControl Department
        LoadUserControl(New uf_jabatan())
    End Sub
    Private Sub bBiaya_Click(ByVal sender As Object, ByVal e As EventArgs)

        ' Matikan semua submenu Master Data
        ResetSubMenuMaster()

        ' Aktifkan tombol yang sedang dipilih
        Dim btn = DirectCast(sender, Guna2Button)
        btn.Checked = True

        ' Aktifkan menu utama Master Data
        bMaster.Checked = True

        ' Tampilkan UserControl Department
        LoadUserControl(New uf_Biaya())
    End Sub
    Private Sub bKodeAbsen_Click(ByVal sender As Object, ByVal e As EventArgs)

        ' Matikan semua submenu Master Data
        ResetSubMenuMaster()

        ' Aktifkan tombol yang sedang dipilih
        Dim btn = DirectCast(sender, Guna2Button)
        btn.Checked = True

        ' Aktifkan menu utama Master Data
        bMaster.Checked = True

        ' Tampilkan UserControl Department
        LoadUserControl(New uf_kodeabsen())
    End Sub
    Private Sub bKalender_Click(ByVal sender As Object, ByVal e As EventArgs)

        ' Matikan semua submenu Master Data
        ResetSubMenuMaster()

        ' Aktifkan tombol yang sedang dipilih
        Dim btn = DirectCast(sender, Guna2Button)
        btn.Checked = True

        ' Aktifkan menu utama Master Data
        bMaster.Checked = True

        ' Tampilkan UserControl Department
        LoadUserControl(New uf_kalenderlibur())
    End Sub
#End Region

    Private Sub Form_Utama_Load(sender As Object, e As EventArgs) Handles Me.Load


        ' === ATUR FLOWLAYOUTPANEL ===
        flpMenu.FlowDirection = FlowDirection.TopDown
        flpMenu.WrapContents = False
        flpMenu.AutoScroll = True

        ' PENTING: Nonaktifkan horizontal scroll
        flpMenu.HorizontalScroll.Enabled = False
        flpMenu.HorizontalScroll.Visible = False

        ' Atur padding panel
        flpMenu.Padding = New Padding(10, 5, 10, 5)  ' Padding kiri-kanan 10

        ' Inisialisasi tombol
        bDashboard = BuatButtonUtama("Dashboard", "bDashboard", My.Resources.Dashboard)
        bRecruitment = BuatButtonUtama("Recruitment", "bRecruitment", My.Resources.Recruitment)
        bEmployee = BuatButtonUtama("Employee", "bEmployee", My.Resources.Employee)
        bAttendance = BuatButtonUtama("Attendance", "bAttendance", My.Resources.Attendance)
        bOvertime = BuatButtonUtama("Overtime", "bOvertime", My.Resources.Overtime)
        bLeave = BuatButtonUtama("Leave Management", "bLeave", My.Resources.Leave)
        bPerformance = BuatButtonUtama("Performance Appraisal", "bPerformance", My.Resources.Performance)
        bPayroll = BuatButtonUtama("Payrol", "bPayrol", My.Resources.Payrol)
        bResign = BuatButtonUtama("Resign", "bResign", My.Resources.Resign)
        bMaster = BuatButtonUtama("Master Data", "bMaster", My.Resources.Employeedata)
        bReport = BuatButtonUtama("Report", "bReport", My.Resources.Report)
        bSetting = BuatButtonUtama("Setting", "bSetting", My.Resources.Setting)
        bSelfService = BuatButtonUtama("Employee Self-Service", "bSelfService", My.Resources.Selfservice)


        ' *** TAMBAHKAN INI: Hubungkan event click ke ButtonUtama_Click ***
        'AddHandler bDashboard.Click, AddressOf ButtonUtama_Click
        AddHandler bRecruitment.Click, AddressOf bRecruitment_Click
        AddHandler bMaster.Click, AddressOf bMaster_Click
        '

        ' Buat Label Header
        lblHeader = BuatLabelHeader("MAIN MENU")
        flpMenu.Controls.Add(lblHeader)


        ' Tambahkan tombol ke FlowLayoutPanel
        flpMenu.Controls.Add(bDashboard)
        flpMenu.Controls.Add(bRecruitment)
        flpMenu.Controls.Add(pnlSubRecruitment)
        flpMenu.Controls.Add(bEmployee)
        flpMenu.Controls.Add(bAttendance)
        flpMenu.Controls.Add(bOvertime)
        flpMenu.Controls.Add(bLeave)
        flpMenu.Controls.Add(bPerformance)
        flpMenu.Controls.Add(bPayroll)
        flpMenu.Controls.Add(bResign)
        flpMenu.Controls.Add(bMaster)
        flpMenu.Controls.Add(pnlSubMaster)
        flpMenu.Controls.Add(bReport)
        flpMenu.Controls.Add(bSetting)
        flpMenu.Controls.Add(bSelfService)


    End Sub
    Private Sub bClose_Click(sender As Object, e As EventArgs) Handles bClose.Click
        End
    End Sub
End Class