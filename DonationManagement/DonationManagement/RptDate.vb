Public Class RptDate

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        testModule.rptID = 12
        testModule.item = DTPDate.Value
        Me.Hide()
        frmRPTViewer.Show()
    End Sub
End Class