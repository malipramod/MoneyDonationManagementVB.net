Public Class rptInstitute

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        If txtInstName.Text = "" Then
            MsgBox("Please Insert Institute Name", MsgBoxStyle.Critical, "Institute Name is Missing")
            txtInstName.Focus()
        Else
            testModule.rptID = 11
            testModule.item = txtInstName.Text
            Me.Hide()
            frmRPTViewer.Show()
        End If
    End Sub
End Class