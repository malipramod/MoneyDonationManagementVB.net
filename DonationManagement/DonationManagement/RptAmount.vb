Public Class RptAmount

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        If txtAmount.Text = "" Then
            MsgBox("Please Insert Amount to Generate Report", MsgBoxStyle.Critical, "Ammount is missing")
            txtAmount.Focus()
        ElseIf cmbSelect.Text = "GreaterThen" Then
            testModule.rptID = 6
            testModule.item = txtAmount.Text
            Me.Hide()
            frmRPTViewer.Show()
        ElseIf cmbSelect.Text = "LessThen" Then
            testModule.rptID = 7
            testModule.item = txtAmount.Text
            Me.Hide()
            frmRPTViewer.Show()
        ElseIf cmbSelect.Text = "Perticular" Then
            testModule.rptID = 8
            testModule.item = txtAmount.Text
            Me.Hide()            
            frmRPTViewer.Show()
        End If
    End Sub

    Private Sub txtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
            Beep()
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False

        End If
    End Sub

   
End Class