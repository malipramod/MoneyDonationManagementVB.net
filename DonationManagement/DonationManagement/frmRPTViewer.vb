Imports System.Data.SqlClient
Public Class frmRPTViewer
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim str As String
    Dim se As String

    Private Sub frmRPTViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        con = New SqlConnection(testModule.ConStr)
        con.Open()
        If testModule.rptID = 1 Then
            str = ""
            str = "SELECT FirstName,MiddleName, LastName, Address1, Address2, Address3, CountryID,Date, Amount FROM DonorMaster where FirstName like'%" + testModule.item.ToString + "%'"
            ds = New DataSet
            da = New SqlDataAdapter(str, con)
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                Dim rpt As New CRDonorName
                rpt.SetDataSource(ds.Tables(0))
                CRV.ReportSource = rpt
            End If
        ElseIf testModule.rptID = 2 Then
            str = ""
            str = "SELECT FirstName, LastName,MiddleName, Address1, Address2, Address3, CountryID,Date, Amount FROM DonorMaster where MiddleName like'%" + testModule.item.ToString + "%'"
            ds = New DataSet
            da = New SqlDataAdapter(str, con)
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                Dim rpt As New CRDonorName
                rpt.SetDataSource(ds.Tables(0))
                CRV.ReportSource = rpt
            End If
        ElseIf testModule.rptID = 3 Then
            str = ""
            str = "SELECT FirstName, LastName,MiddleName, Address1, Address2, Address3, CountryID,Date, Amount FROM DonorMaster where LastName like'%" + testModule.item.ToString + "%'"
            ds = New DataSet
            da = New SqlDataAdapter(str, con)
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                Dim rpt As New CRDonorName
                rpt.SetDataSource(ds.Tables(0))
                CRV.ReportSource = rpt
            End If
        ElseIf testModule.rptID = 4 Then
            str = ""
            str = "SELECT DonorMaster.DonorID, SubDonorMaster.FirstName, SubDonorMaster.LastName, SubDonorMaster.Address1, SubDonorMaster.Address2, SubDonorMaster.Address3,  SubDonorMaster.CountryID, SubDonorMaster.Amount, SubDonorMaster.TotalAmount FROM DonorMaster INNER JOIN SubDonorMaster ON DonorMaster.DonorID = SubDonorMaster.DonorID where SubDonorMaster.FirstName like '%" + testModule.item.ToString + "%'"
            ds = New DataSet
            da = New SqlDataAdapter(str, con)
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                Dim rpt As New CRDonorName
                rpt.SetDataSource(ds.Tables(0))
                CRV.ReportSource = rpt
            End If
        ElseIf testModule.rptID = 5 Then
            str = ""
            str = "SELECT DonorMaster.DonorID, SubDonorMaster.FirstName, SubDonorMaster.LastName, SubDonorMaster.Address1, SubDonorMaster.Address2, SubDonorMaster.Address3,  SubDonorMaster.CountryID, SubDonorMaster.TotalAmount FROM DonorMaster INNER JOIN SubDonorMaster ON DonorMaster.DonorID = SubDonorMaster.DonorID where SubDonorMaster.LastName like '%" + testModule.item.ToString + "%'"
            ds = New DataSet
            da = New SqlDataAdapter(str, con)
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                Dim rpt As New CRDonorName
                rpt.SetDataSource(ds.Tables(0))
                CRV.ReportSource = rpt
            End If
        ElseIf testModule.rptID = 5 Then
            str = ""
            str = "SELECT DonorMaster.DonorID, SubDonorMaster.FirstName, SubDonorMaster.LastName, SubDonorMaster.Address1, SubDonorMaster.Address2, SubDonorMaster.Address3,  SubDonorMaster.CountryID, SubDonorMaster.TotalAmount FROM DonorMaster INNER JOIN SubDonorMaster ON DonorMaster.DonorID = SubDonorMaster.DonorID where SubDonorMaster.MiddleName like '%" + testModule.item.ToString + "%'"
            ds = New DataSet
            da = New SqlDataAdapter(str, con)
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                Dim rpt As New CRDonorName
                rpt.SetDataSource(ds.Tables(0))
                CRV.ReportSource = rpt
            End If
        ElseIf testModule.rptID = 6 Then
            str = ""
            str = "SELECT FirstName, LastName, CountryID, MobileNo, Amount FROM DonorMaster where Amount >" + testModule.item.ToString()
            ds = New DataSet
            da = New SqlDataAdapter(str, con)
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                Dim rpt As New CRAmount
                rpt.SetDataSource(ds.Tables(0))
                CRV.ReportSource = rpt
            End If
        ElseIf testModule.rptID = 7 Then
            str = ""
            str = "SELECT FirstName, LastName, CountryID, MobileNo, Amount FROM DonorMaster where Amount <" + testModule.item.ToString()
            ds = New DataSet
            da = New SqlDataAdapter(str, con)
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                Dim rpt As New CRAmount
                rpt.SetDataSource(ds.Tables(0))
                CRV.ReportSource = rpt
            End If
        ElseIf testModule.rptID = 8 Then
            str = ""
            str = "SELECT FirstName, LastName, CountryID, MobileNo, Amount FROM DonorMaster where Amount like'%" + testModule.item.ToString() + "%'"
            ds = New DataSet
            da = New SqlDataAdapter(str, con)
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                Dim rpt As New CRAmount
                rpt.SetDataSource(ds.Tables(0))
                CRV.ReportSource = rpt
            End If
        ElseIf testModule.rptID = 9 Then
            se = "Yes"
            str = ""
            str = "SELECT     FirstName, LastName, SpecialInvite,LifeTimeMember, Amount FROM DonorMaster where SpecialInvite like'%" + se + "%'"
            ds = New DataSet
            da = New SqlDataAdapter(str, con)
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                Dim rpt As New CRSpecialMebership
                rpt.SetDataSource(ds.Tables(0))
                CRV.ReportSource = rpt
            End If
        ElseIf testModule.rptID = 10 Then
            se = "Yes"
            str = ""
            str = "SELECT     FirstName, LastName, SpecialInvite,LifeTimeMember, Amount FROM DonorMaster where LifeTimeMember like'%" + se + "%'"
            ds = New DataSet
            da = New SqlDataAdapter(str, con)
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                Dim rpt As New CRSpecialMebership
                rpt.SetDataSource(ds.Tables(0))
                CRV.ReportSource = rpt
            End If
        ElseIf testModule.rptID = 11 Then
            str = ""
            str = "SELECT InstituteMaster.InstName, DepartmentMaster.DeptName FROM InstituteMaster INNER JOIN DepartmentMaster ON InstituteMaster.InstID = DepartmentMaster.InstID where InstName like'%" + testModule.item.ToString + "%'"
            ds = New DataSet
            da = New SqlDataAdapter(str, con)
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                Dim rpt As New CRInstDept
                rpt.SetDataSource(ds.Tables(0))
                CRV.ReportSource = rpt
            End If
        ElseIf testModule.rptID = 12 Then
            se = "Yes"
            str = ""
            str = "SELECT InstituteMaster.InstName, DepartmentMaster.DeptName FROM InstituteMaster INNER JOIN DepartmentMaster ON InstituteMaster.InstID = DepartmentMaster.InstID where DeptName like'%" + testModule.item.ToString + "%'"
            ds = New DataSet
            da = New SqlDataAdapter(str, con)
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                Dim rpt As New CRInstDept
                rpt.SetDataSource(ds.Tables(0))
                CRV.ReportSource = rpt
            End If
        ElseIf testModule.rptID = 13 Then
            se = "Yes"
            str = ""
            str = "SELECT  UserName, UserTypeID, LoggedInTime, LoggedOutTime FROM LoginMaster where LoggedInTime like '%" + item.ToString + "%' "
            ds = New DataSet
            da = New SqlDataAdapter(str, con)
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                Dim rpt As New CRUserMaster
                rpt.SetDataSource(ds.Tables(0))
                CRV.ReportSource = rpt
            End If
        End If
    End Sub
End Class