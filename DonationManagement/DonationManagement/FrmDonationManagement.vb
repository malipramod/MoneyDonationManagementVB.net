Imports System.Data.SqlClient
Public Class FrmDonationManagement
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim ds As DataSet
    Dim da As SqlDataAdapter
    Dim str As String

    Private Sub btnMiniMize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMiniMize.Click
        Me.WindowState = FormWindowState.Minimized

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        str = ""
        str = "Update LoginMaster set LoggedOutTime = '" + lblouttimer.Text + "' where UserID= " + testModule.uid.ToString()
        cmd = New SqlCommand(str, con)
        cmd.ExecuteNonQuery()
        MessageBox.Show("You are LoggedOut Successfully", "Log Out ")
        End
    End Sub

    Private Sub BtnReg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReg.Click
        PnlReg.Visible = True
        If PnlTrans.Visible = True Then
            PnlTrans.Visible = False
        End If
        If PnlReport.Visible = True Then
            PnlReport.Visible = False
        End If
    End Sub

    Private Sub btnTransaction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransaction.Click
        PnlTrans.Visible = True
        If PnlReg.Visible = True Then
            PnlReg.Visible = False

        End If
        If PnlReport.Visible = True Then
            PnlReport.Visible = False
        End If

    End Sub

    Private Sub BtnInst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInst.Click
        PnlReg.Visible = False
        Dim frm As New FrmInstituteMaster
        frm.ShowDialog()
    End Sub

    Private Sub BtnDept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDept.Click        
        PnlReg.Visible = False
        Dim frm As New FrmDepartmentMaster
        frm.ShowDialog()
    End Sub

    Private Sub BtnUserReg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUserReg.Click
        PnlReg.Visible = False
        Dim frm As New FrmUserReg
        frm.ShowDialog()
    End Sub

    Private Sub BtnDonorReg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDonorReg.Click
        PnlReg.Visible = False
        Dim frm As New FrmDonorRegistration
        frm.ShowDialog()
    End Sub


    Private Sub BtnLogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLogout.Click
        str = ""
        str = "Update LoginMaster set LoggedOutTime = '" + lblouttimer.Text + "' where UserID= " + testModule.uid.ToString()
        cmd = New SqlCommand(str, con)
        cmd.ExecuteNonQuery()
        MessageBox.Show("You are LoggedOut Successfully", "Log Out ")
        End
    End Sub


    Private Sub BtnDonorTrans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDonorTrans.Click
        PnlTrans.Visible = False
        Dim frm As New frmDonorDetails
        frm.ShowDialog()

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lblouttimer.Text = System.DateTime.Now.ToLongTimeString
    End Sub

    Private Sub BtnEditUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditUser.Click
        PnlTrans.Visible = False
        Dim frm As New frmEditUserReg
        frm.ShowDialog()
    End Sub

    Private Sub FrmDonationManagement_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        If PnlTrans.Visible = True Then
            PnlTrans.Visible = False
        End If
        If PnlReg.Visible = True Then
            PnlReg.Visible = False

        End If
        If PnlReport.Visible = True Then
            PnlReport.Visible = False
        End If

    End Sub

    Private Sub FrmDonationManagement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'MessageBox.Show("time " + testModule.rid.ToString())
        Timer1.Start()
        lblTimer.Text = System.DateTime.Now.ToLongTimeString
        lblUserName.Text = FrmLoginForm.txtUserName.Text

        con = New SqlConnection(testModule.ConStr)
        con.Open()

        If FrmLoginForm.cmbUserType.Text = "Admin" Then
            BtnInst.Enabled = True
            BtnDept.Enabled = True
            BtnUserReg.Enabled = True
            BtnEditDept.Enabled = True
            BtnEditInst.Enabled = True
            frmEditUserReg.btnDelete.Enabled = True
            frmEditUserReg.cmbUserType.Enabled = True
            btnLogInHistory.Enabled = True
            btnUserList.Enabled = True
        End If
    End Sub

    Private Sub BtnSubDonorTrans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSubDonorTrans.Click
        PnlTrans.Visible = False
        Dim frm As New FrmSubDonorgrid
        frm.ShowDialog()
    End Sub

    Private Sub BtnEditInst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditInst.Click
        PnlTrans.Visible = False
        Dim frm As New FrmEditInstituteMaster
        frm.ShowDialog()
    End Sub

    Private Sub BtnEditDept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditDept.Click
        PnlTrans.Visible = False
        Dim frm As New FrmEditDepartmentMaster
        frm.ShowDialog()
    End Sub

    Private Sub BtnChangePass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChangePass.Click
        PnlTrans.Visible = False
        Dim frm As New FrmChangePassword
        frm.ShowDialog()
    End Sub

    Private Sub btnReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReports.Click
        PnlReport.Visible = True
        If PnlReg.Visible = True Then
            PnlReg.Visible = False
        End If
        If PnlTrans.Visible = True Then
            PnlTrans.Visible = False
        End If
    End Sub

    Private Sub btnNameWise_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNameWise.Click
        Dim frm As New RptName
        frm.ShowDialog()
    End Sub

  
    Private Sub btnAmountWise_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAmountWise.Click
        Dim frm As New RptAmount
        frm.ShowDialog()
    End Sub

    
    Private Sub btnSpecialInvite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSpecialInvite.Click
        testModule.rptID = 9
        Me.Hide()
        frmRPTViewer.Show()
    End Sub

    Private Sub btnMemebership_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMemebership.Click
        testModule.rptID = 10
        Me.Hide()
        frmRPTViewer.Show()
    End Sub

    Private Sub btmInst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btmInst.Click
        Dim frm As New rptInstitute
        frm.ShowDialog()
    End Sub

    
    Private Sub btnDepartment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDepartment.Click
        Dim frm As New RptDepartment
        frm.ShowDialog()
    End Sub

    Private Sub btnDateWise_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDateWise.Click
        Dim frm As New RptDate
        frm.ShowDialog()
    End Sub
End Class
