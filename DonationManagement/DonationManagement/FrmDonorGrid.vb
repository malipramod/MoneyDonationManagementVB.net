Imports System.Data.SqlClient
Public Class frmDonorDetails
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim ds As DataSet
    Dim da As SqlDataAdapter
    Dim str As String

  
    Private Sub frmDonorDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        con = New SqlConnection(testModule.ConStr)
        con.Open()
        cmbSearchBy.Text = "First Name"
        BindGrid()
    End Sub


    Private Sub DGDonorMaster_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGDonorMaster.CellMouseClick
        str = ""
        str = "SELECT *from DonorMaster where DonorID =" + DGDonorMaster.SelectedRows(0).Cells("DonorID").Value.ToString()
        da = New SqlDataAdapter(str, con)
        ds = New DataSet()
        da.Fill(ds)
        If (ds.Tables(0).Rows.Count > 0) Then
            testModule.var = ds.Tables(0).Rows(0)("DonorID").ToString()
        End If
    End Sub

    Sub BindGrid()
        str = ""
        str = "select *from DonorMaster"
        da = New SqlDataAdapter(str, con)
        ds = New DataSet()
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            DGDonorMaster.DataSource = ds.Tables(0)
        Else
            DGDonorMaster.DataSource = System.DBNull.Value.ToString()
        End If
    End Sub


    Private Sub btnMiniMize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMiniMize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()

    End Sub

    
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        testModule.DonorFlag = True
        testModule.DonorID = var
        Dim frm As New FrmDonorRegistration
        frm.ShowDialog()
    End Sub

    Private Sub btnEdit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If var <> "" Then
            testModule.DonorFlag = True
            testModule.DonorID = var
            Dim frm As New FrmEditDonorRegistration
            frm.ShowDialog()
        Else
            MsgBox("Please Select any Record to Perform this operation")
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If var <> "" Then
            Dim m = MessageBox.Show("Are You Sure ? ", "Donor Master", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If m = Windows.Forms.DialogResult.Yes Then
                str = ""
                str = "Delete From DonorMaster where DonorID = '" + var + "'"
                cmd = New SqlCommand(str, con)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Your Record is Deleted", "Donor Master", MessageBoxButtons.OK, MessageBoxIcon.Information)
                BindGrid()
            End If
            If m = Windows.Forms.DialogResult.No Then
                MessageBox.Show("Operation is cancelled by user", "Donor Master", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Refresh()
            End If
        Else

            MessageBox.Show("Please select any row to delete.", "Donor Master", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        FrmDonationManagement.Show()
        Me.Close()

    End Sub

   
    Private Sub txtsearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.TextChanged
        If cmbSearchBy.Text.Equals("First Name") Then
            If txtsearch.Text <> "" Then
                str = ""
                str = "Select *from DonorMaster Where FirstName like '%" + txtsearch.Text + "%'"
                da = New SqlDataAdapter(str, con)
                ds = New DataSet()
                da.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    DGDonorMaster.DataSource = ds.Tables(0)
                    DGDonorMaster.Columns(0).Visible = False
                Else
                    DGDonorMaster.DataSource = System.DBNull.Value.ToString()
                End If
            Else
                BindGrid()
            End If
        ElseIf cmbSearchBy.Text.Equals("Middle Name") Then
            If txtsearch.Text <> "" Then
                str = ""
                str = "Select *from DonorMaster Where MiddleName like '%" + txtsearch.Text + "%'"
                da = New SqlDataAdapter(str, con)
                ds = New DataSet()
                da.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    DGDonorMaster.DataSource = ds.Tables(0)
                    DGDonorMaster.Columns(0).Visible = False
                Else
                    DGDonorMaster.DataSource = System.DBNull.Value.ToString()
                End If
            Else
                BindGrid()
            End If
        ElseIf cmbSearchBy.Text.Equals("Last Name") Then
            If txtsearch.Text <> "" Then
                str = ""
                str = "Select *from DonorMaster Where LastName like '%" + txtsearch.Text + "%'"
                da = New SqlDataAdapter(str, con)
                ds = New DataSet()
                da.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    DGDonorMaster.DataSource = ds.Tables(0)
                    DGDonorMaster.Columns(0).Visible = False
                Else
                    DGDonorMaster.DataSource = System.DBNull.Value.ToString()
                End If
            Else
                BindGrid()
            End If
        ElseIf cmbSearchBy.Text.Equals("Country") Then
            If txtsearch.Text <> "" Then
                str = ""
                str = "Select *from DonorMaster Where CountryID like '%" + txtsearch.Text + "%'"
                da = New SqlDataAdapter(str, con)
                ds = New DataSet()
                da.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    DGDonorMaster.DataSource = ds.Tables(0)
                    DGDonorMaster.Columns(0).Visible = False
                Else
                    DGDonorMaster.DataSource = System.DBNull.Value.ToString()
                End If
            Else
                BindGrid()
            End If
        ElseIf cmbSearchBy.Text.Equals("State") Then
            If txtsearch.Text <> "" Then
                str = ""
                str = "Select *from DonorMaster Where StateID like '%" + txtsearch.Text + "%'"
                da = New SqlDataAdapter(str, con)
                ds = New DataSet()
                da.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    DGDonorMaster.DataSource = ds.Tables(0)
                    DGDonorMaster.Columns(0).Visible = False
                Else
                    DGDonorMaster.DataSource = System.DBNull.Value.ToString()
                End If
            Else
                BindGrid()
            End If
        ElseIf cmbSearchBy.Text.Equals("City") Then
            If txtsearch.Text <> "" Then
                str = ""
                str = "Select *from DonorMaster Where CityID like '%" + txtsearch.Text + "%'"
                da = New SqlDataAdapter(str, con)
                ds = New DataSet()
                da.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    DGDonorMaster.DataSource = ds.Tables(0)
                    DGDonorMaster.Columns(0).Visible = False
                Else
                    DGDonorMaster.DataSource = System.DBNull.Value.ToString()
                End If
            Else
                BindGrid()
            End If
        ElseIf cmbSearchBy.Text.Equals("MobileNo") Then
            If txtsearch.Text <> "" Then
                str = ""
                str = "Select *from DonorMaster Where MobileNo like '%" + txtsearch.Text + "%'"
                da = New SqlDataAdapter(str, con)
                ds = New DataSet()
                da.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    DGDonorMaster.DataSource = ds.Tables(0)
                    DGDonorMaster.Columns(0).Visible = False
                Else
                    DGDonorMaster.DataSource = System.DBNull.Value.ToString()
                End If
            Else
                BindGrid()
            End If
        End If
    End Sub
    Private Sub btnAddSubDonor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddSubDonor.Click
        If var <> "" Then
            Dim frm As New FrmSubDonorRegistration()
            frm.ShowDialog()
        Else
            MsgBox("Please Select any Record to Perform this operation")
        End If
    End Sub
End Class
