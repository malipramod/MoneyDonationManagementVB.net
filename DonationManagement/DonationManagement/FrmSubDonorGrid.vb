Imports System.Data.SqlClient
Public Class FrmSubDonorgrid
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim ds As DataSet
    Dim da As SqlDataAdapter
    Dim str As String

    Sub BindGrid()
        str = ""
        str = "select *from SubDonorMaster"
        ds = New DataSet()
        da = New SqlDataAdapter(str, con)
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            DGSubDonorMaster.DataSource = ds.Tables(0)
        Else
            DGSubDonorMaster.DataSource = System.DBNull.Value.ToString()
        End If
    End Sub


    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        testModule.DonorFlag = True
        testModule.DonorID = var
        Dim frm As New FrmSubDonorRegistration
        frm.ShowDialog()

    End Sub



    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If var <> "" Then
            Dim m = MessageBox.Show("Are You Sure ? ", "Outward Register delete Form", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If m = Windows.Forms.DialogResult.Yes Then
                str = ""
                str = "Delete From SubDonorMaster where SubDonorID = '" + var + "'"
                cmd = New SqlCommand(str, con)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Your Record is Deleted", "Sub Donor Master", MessageBoxButtons.OK, MessageBoxIcon.Information)
                BindGrid()
            End If
            If m = Windows.Forms.DialogResult.No Then
                MessageBox.Show("Operation is cancelled by user", "Sub Donor Master", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Refresh()
            End If
        Else

            MessageBox.Show("Please select any row to delete.", "Sub Donor Master", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub FrmSubDonorgrid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        con = New SqlConnection(testModule.ConStr)
        con.Open()
        BindGrid()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If var <> "" Then
            testModule.DonorID = var
            Dim frm As New FrmEditSubDonorRegistration
            frm.ShowDialog()
        Else
            MsgBox("Please Select any Record to Perform this operation")
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()

    End Sub

    Private Sub txtsearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.TextChanged
        If cmbSearchBy.Text.Equals("First Name") Then
            If txtsearch.Text <> "" Then
                str = ""
                str = "Select *from SubDonorMaster Where FirstName like '%" + txtsearch.Text + "%'"
                da = New SqlDataAdapter(str, con)
                ds = New DataSet()
                da.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    DGSubDonorMaster.DataSource = ds.Tables(0)
                    DGSubDonorMaster.Columns(0).Visible = False
                Else
                    DGSubDonorMaster.DataSource = System.DBNull.Value.ToString()
                End If
            Else
                BindGrid()
            End If
        ElseIf cmbSearchBy.Text.Equals("Middle Name") Then
            If txtsearch.Text <> "" Then
                str = ""
                str = "Select *from SubDonorMaster Where MiddleName like '%" + txtsearch.Text + "%'"
                da = New SqlDataAdapter(str, con)
                ds = New DataSet()
                da.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    DGSubDonorMaster.DataSource = ds.Tables(0)
                    DGSubDonorMaster.Columns(0).Visible = False
                Else
                    DGSubDonorMaster.DataSource = System.DBNull.Value.ToString()
                End If
            Else
                BindGrid()
            End If
        ElseIf cmbSearchBy.Text.Equals("Last Name") Then
            If txtsearch.Text <> "" Then
                str = ""
                str = "Select *from SubDonorMaster Where LastName like '%" + txtsearch.Text + "%'"
                da = New SqlDataAdapter(str, con)
                ds = New DataSet()
                da.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    DGSubDonorMaster.DataSource = ds.Tables(0)
                    DGSubDonorMaster.Columns(0).Visible = False
                Else
                    DGSubDonorMaster.DataSource = System.DBNull.Value.ToString()
                End If
            Else
                BindGrid()
            End If
        ElseIf cmbSearchBy.Text.Equals("Country") Then
            If txtsearch.Text <> "" Then
                str = ""
                str = "Select *from SubDonorMaster Where CountryID like '%" + txtsearch.Text + "%'"
                da = New SqlDataAdapter(str, con)
                ds = New DataSet()
                da.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    DGSubDonorMaster.DataSource = ds.Tables(0)
                    DGSubDonorMaster.Columns(0).Visible = False
                Else
                    DGSubDonorMaster.DataSource = System.DBNull.Value.ToString()
                End If
            Else
                BindGrid()
            End If
        ElseIf cmbSearchBy.Text.Equals("State") Then
            If txtsearch.Text <> "" Then
                str = ""
                str = "Select *from SubDonorMaster Where StateID like '%" + txtsearch.Text + "%'"
                da = New SqlDataAdapter(str, con)
                ds = New DataSet()
                da.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    DGSubDonorMaster.DataSource = ds.Tables(0)
                    DGSubDonorMaster.Columns(0).Visible = False
                Else
                    DGSubDonorMaster.DataSource = System.DBNull.Value.ToString()
                End If
            Else
                BindGrid()
            End If
        ElseIf cmbSearchBy.Text.Equals("City") Then
            If txtsearch.Text <> "" Then
                str = ""
                str = "Select *from SubDonorMaster Where CityID like '%" + txtsearch.Text + "%'"
                da = New SqlDataAdapter(str, con)
                ds = New DataSet()
                da.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    DGSubDonorMaster.DataSource = ds.Tables(0)
                    DGSubDonorMaster.Columns(0).Visible = False
                Else
                    DGSubDonorMaster.DataSource = System.DBNull.Value.ToString()
                End If
            Else
                BindGrid()
            End If
        ElseIf cmbSearchBy.Text.Equals("MobileNo") Then
            If txtsearch.Text <> "" Then
                str = ""
                str = "Select *from SubDonorMaster Where MobileNo like '%" + txtsearch.Text + "%'"
                da = New SqlDataAdapter(str, con)
                ds = New DataSet()
                da.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    DGSubDonorMaster.DataSource = ds.Tables(0)
                    DGSubDonorMaster.Columns(0).Visible = False
                Else
                    DGSubDonorMaster.DataSource = System.DBNull.Value.ToString()
                End If
            Else
                BindGrid()
            End If
        End If
    End Sub

    Private Sub DGSubDonorMaster_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGSubDonorMaster.CellMouseClick
        str = ""
        str = "SELECT *from SubDonorMaster where SubDonorID =" + DGSubDonorMaster.SelectedRows(0).Cells("SubDonorID").Value.ToString()
        da = New SqlDataAdapter(str, con)
        ds = New DataSet()
        da.Fill(ds)
        If (ds.Tables(0).Rows.Count > 0) Then
            testModule.var = ds.Tables(0).Rows(0)("SubDonorID").ToString()
        End If
    End Sub
End Class