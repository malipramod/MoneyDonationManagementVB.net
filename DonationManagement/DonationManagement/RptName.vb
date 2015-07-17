Public Class RptName

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    
    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        If txtName.Text.Equals("") Then
            MsgBox("Please Provide Text in the TextBox", MsgBoxStyle.Critical, "Text is Missing")
            txtName.Focus()
        ElseIf cmbSelect.Text = "FirstName" And cmbDonorType.Text = "MainDonor" Then
            testModule.rptID = 1
            testModule.item = txtName.Text
            Me.Hide()
            frmRPTViewer.Show()
        ElseIf cmbSelect.Text = "MiddleName" And cmbDonorType.Text = "MainDonor" Then
            testModule.rptID = 2
            testModule.item = txtName.Text
            Me.Hide()
            frmRPTViewer.Show()
        ElseIf cmbSelect.Text = "LastName" And cmbDonorType.Text = "MainDonor" Then
            testModule.rptID = 3
            testModule.item = txtName.Text
            Me.Hide()
            frmRPTViewer.Show()
        ElseIf cmbSelect.Text = "FirstName" And cmbDonorType.Text = "SubDonor" Then
            testModule.rptID = 4
            testModule.item = txtName.Text
            Me.Hide()
            frmRPTViewer.Show()
        ElseIf cmbSelect.Text = "LastName" And cmbDonorType.Text = "SubDonor" Then
            testModule.rptID = 5
            testModule.item = txtName.Text
            Me.Hide()
            frmRPTViewer.Show()
        ElseIf cmbSelect.Text = "MiddleName" And cmbDonorType.Text = "SubDonor" Then
            testModule.rptID = 6
            testModule.item = txtName.Text
            Me.Hide()
            frmRPTViewer.Show()
        
        End If
    End Sub

    Private Sub RptName_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbSelect.Text = "FirstName"
        cmbDonorType.Text = "MainDonor"
    End Sub

    Private Sub txtName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtName.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 65) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 90) And (Microsoft.VisualBasic.Asc(e.KeyChar) < 97) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 122) Then
            'Allowed space
            If (Microsoft.VisualBasic.Asc(e.KeyChar) <> 32) Then
                e.Handled = True
            End If
        End If
        ' Allowed backspace 
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
    End Sub

End Class