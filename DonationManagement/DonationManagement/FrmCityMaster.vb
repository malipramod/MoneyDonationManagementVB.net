Imports System.Data.SqlClient
Public Class FrmCityMaster
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

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        'If txtCityName.Text = "" Then
        '    MsgBox("Please First Insert Country Name", MsgBoxStyle.Critical, "Country Name Missing")
        'Else
        '    str = ""
        '    str = "Insert into CityMaster(StateID,CityName) values('" + FrmDonorRegistration.cmbState.SelectedValue.ToString() + "','" + txtCityName.Text + "')"
        '    cmd = New SqlCommand(str, con)
        '    cmd.ExecuteNonQuery()
        '    ' MsgBox("Inserted Sucussesfully", MsgBoxStyle.MsgBoxRight, "City Master")
        '    txtCityName.Text = ""
        '    FrmDonorRegistration.BindCity()
        '    Me.Close()
        'End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtCityName.Text = ""
        txtCityName.Focus()

    End Sub
End Class