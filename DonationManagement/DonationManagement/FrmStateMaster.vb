Imports System.Data.SqlClient
Public Class FrmStateMaster
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim str As String
    Private Sub FrmInstituteMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        con = New SqlConnection(testModule.ConStr)
        con.Open()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtStateName.Text = ""
        txtStateName.Focus()

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        'If txtStateName.Text = "" Then
        '    MsgBox("Please First Insert Country Name", MsgBoxStyle.Critical, "Country Name Missing")
        'Else
        '    str = ""
        '    str = "Insert into StateMaster(CountryID,StateName) values('" + FrmDonorRegistration.txCountry.SelectedValue.ToString() + "','" + txtStateName.Text + "')"
        '    cmd = New SqlCommand(str, con)
        '    cmd.ExecuteNonQuery()
        '    'MsgBox("Inserted Sucussesfully", MsgBoxStyle.MsgBoxRight, "State Master")
        '    txtStateName.Text = ""
        '    FrmDonorRegistration.BindState()
        '    Me.Close()
        'End If
    End Sub
End Class