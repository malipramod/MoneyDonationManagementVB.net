Public Class RptDepartment

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        If txtDeptName.Text = "" Then
            MsgBox("Please Insert Department Name", MsgBoxStyle.Critical, "Department Name is Missing")
            txtDeptName.Focus()
        Else
            testModule.rptID = 12
            testModule.item = txtDeptName.Text
            Me.Hide()
            frmRPTViewer.Show()
        End If
    End Sub
End Class