Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class FrmEditDonorRegistration
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim ds As DataSet
    Dim da As SqlDataAdapter
    Dim str As String
    Dim nationality As String
    Dim membership As String
    Dim SpecialEnvite As String

    Private Sub FrmDonorRegistration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        con = New SqlConnection(testModule.ConStr)
        con.Open()
        CmbTypeOfDonation.Text = "Check"
        If testModule.var.ToString() <> "" Then

            str = ""
            str = "Select *from DonorMaster where DonorID=" + testModule.var.ToString()
            da = New SqlDataAdapter(str, con)
            ds = New DataSet()
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                CmbTypeOfDonation.Text = ds.Tables(0).Rows(0)("TypeOfDonation").ToString()
                txtFirstName.Text = ds.Tables(0).Rows(0)("FirstName").ToString()
                txtMiddleName.Text = ds.Tables(0).Rows(0)("MiddleName").ToString()
                txtLastName.Text = ds.Tables(0).Rows(0)("LastName").ToString()
                txtAdd1.Text = ds.Tables(0).Rows(0)("Address1").ToString()
                txtAdd2.Text = ds.Tables(0).Rows(0)("Address2").ToString()
                txtAdd3.Text = ds.Tables(0).Rows(0)("Address3").ToString()
                txtCountry.Text = ds.Tables(0).Rows(0)("CountryID").ToString()
                txtState.Text = ds.Tables(0).Rows(0)("StateID").ToString()
                txtCity.Text = ds.Tables(0).Rows(0)("CityID").ToString()
                cmbPaymentMode.SelectedItem = ds.Tables(0).Rows(0)("PaymentMode").ToString()
                txtNationality.Text = ds.Tables(0).Rows(0)("Nationality").ToString()
                If ds.Tables(0).Rows(0)("NRI_Local").ToString().Equals("NRI") Then
                    rbtnNRI.Checked = True
                Else
                    rbtnLocal.Checked = True
                End If
                txtMobileNo.Text = ds.Tables(0).Rows(0)("MobileNo").ToString()
                txtLandlineNo.Text = ds.Tables(0).Rows(0)("LandlineNo").ToString()
                txtEmail.Text = ds.Tables(0).Rows(0)("EmailID").ToString()
                If ds.Tables(0).Rows(0)("SpecialInvite").ToString().Equals("Yes") Then
                    chkSpecialInvite.Checked = True
                End If
                If ds.Tables(0).Rows(0)("LifeTimeMember").ToString().Equals("Yes") Then
                    chkLifeMember.Checked = True
                End If

                CmbTypeOfDonation.SelectedItem = ds.Tables(0).Rows(0)("TypeOfDonation").ToString()
                If ds.Tables(0).Rows(0)("PaymentMode").ToString().Equals("Cash") Then
                    txtAmount.Text = ds.Tables(0).Rows(0)("Amount").ToString()
                    lblCheckNumber.Visible = False
                    txtCheckNo.Visible = False
                    lblDraftNumber.Visible = False
                    txtDraftNo.Visible = False

                ElseIf ds.Tables(0).Rows(0)("PaymentMode").ToString().Equals("Check") Then
                    txtAmount.Text = ds.Tables(0).Rows(0)("Amount").ToString()
                    txtCheckNo.Text = ds.Tables(0).Rows(0)("CheckNo").ToString()
                    lblCheckNumber.Visible = True
                    txtCheckNo.Visible = True
                    lblDraftNumber.Visible = False
                    txtDraftNo.Visible = False

                ElseIf ds.Tables(0).Rows(0)("PaymentMode").ToString().Equals("Draft") Then
                    txtAmount.Text = ds.Tables(0).Rows(0)("Amount").ToString()
                    txtDraftNo.Text = ds.Tables(0).Rows(0)("DraftNo").ToString()
                    lblDraftNumber.Visible = True
                    txtDraftNo.Visible = True
                    lblCheckNumber.Visible = False
                    txtCheckNo.Visible = False
                End If
                DTPDate.Value = ds.Tables(0).Rows(0)("Date").ToString()
                cmbGender.SelectedItem = ds.Tables(0).Rows(0)("Gender").ToString()
            End If
        End If


    End Sub




    

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()

    End Sub


    Private Sub txtFirstName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFirstName.KeyPress
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

    Private Sub txtMiddleName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMiddleName.KeyPress
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

    Private Sub txtLastName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLastName.KeyPress
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

    Private Sub txtNation_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNationality.KeyPress
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

    Private Sub txtMobileNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMobileNo.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
            Beep()
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False

        End If
    End Sub

    Private Sub txtLandlineNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLandlineNo.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
            Beep()
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False

        End If
    End Sub

    Private Sub txtEmail_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtEmail.Validating
        Dim pattern As String = "^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$"


        Dim match As System.Text.RegularExpressions.Match = Regex.Match(txtEmail.Text.Trim(), pattern, RegexOptions.IgnoreCase)
        If (match.Success) Then
        Else
            MessageBox.Show("Please enter a valid email id", "Checking")
            txtEmail.Clear()
        End If
    End Sub

    Private Sub txtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
            Beep()
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False

        End If
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        'Life time member or not?
        membership = chkLifeMember.Checked
        If membership = True Then
            membership = "Yes"
        Else
            membership = "No"
        End If

        'Special Invitation or not?
        SpecialEnvite = chkSpecialInvite.Checked
        If SpecialEnvite = True Then
            SpecialEnvite = "Yes"
        Else
            SpecialEnvite = "No"
        End If

        'NRI or Local?
        If rbtnNRI.Checked Then
            nationality = "NRI"
        Else
            nationality = "Local"
        End If


        If txtFirstName.Text.Equals("") Then
            MsgBox("Please Insert First Name", MsgBoxStyle.Critical, "First Name is Missing")
            txtFirstName.Focus()
        ElseIf txtMiddleName.Text.Equals("") Then
            MsgBox("Please Insert Middle Name", MsgBoxStyle.Critical, "Middle Name is Missing")
            txtMiddleName.Focus()
        ElseIf txtLastName.Text.Equals("") Then
            MsgBox("Please Insert Last Name", MsgBoxStyle.Critical, "Last Name is Missing")
            txtLastName.Focus()
        ElseIf cmbGender.SelectedIndex.Equals(-1) Then
            MsgBox("Please Select the Gender", MsgBoxStyle.Critical, "Gender is not Selected")
            cmbGender.Focus()
        ElseIf txtAdd1.Text.Equals("") Then
            MsgBox("Please Insert Address", MsgBoxStyle.Critical, "Address is Missing")
            txtAdd1.Focus()
        ElseIf txtCountry.Text = "" Then
            MsgBox("Please Select the Country", MsgBoxStyle.Critical, "Country is Missing")
            txtCountry.Focus()
        ElseIf txtState.Text = "" Then
            MsgBox("Please Insert the State", MsgBoxStyle.Critical, "State is Missing")
            txtState.Focus()
        ElseIf txtCity.Text.Equals(-1) Then
            MsgBox("Please Select the City", MsgBoxStyle.Critical, "City is Missing")
            txtCity.Focus()
        ElseIf txtNationality.Text.Equals("") Then
            MsgBox("Please Add Nationality", MsgBoxStyle.Critical, "Nationality is Missing")
            txtNationality.Focus()
        ElseIf rbtnLocal.Checked.Equals(False) And rbtnNRI.Checked.Equals(False) Then
            MsgBox("Please Select Local Or NRI", MsgBoxStyle.Critical, "Local Or NRI is Not Selected")

        ElseIf txtMobileNo.Text.Equals("") Then
            MsgBox("Please Insert Mobile Number", MsgBoxStyle.Critical, "Mobile Number is Missing")
            txtMobileNo.Focus()
        ElseIf txtLandlineNo.Text.Equals("") Then
            MsgBox("Please Insert LandLine Number", MsgBoxStyle.Critical, "LandLine Number is Missing")
            txtLandlineNo.Focus()
        ElseIf CmbTypeOfDonation.SelectedIndex.Equals(-1) Then
            MsgBox("Please Select the Type of Donation", MsgBoxStyle.Critical, "Donation Type is not Selected")
            CmbTypeOfDonation.Focus()
        ElseIf cmbPaymentMode.SelectedIndex.Equals(-1) Then
            MsgBox("Please Select the Payment Mode", MsgBoxStyle.Critical, "Payment Mode is not Selected")
            cmbPaymentMode.Focus()
        ElseIf txtAmount.Text.Equals("") Then
            MsgBox("Please Insert Ammount", MsgBoxStyle.Critical, "Ammount is Missing")
            txtAmount.Focus()
        ElseIf cmbPaymentMode.Text.Equals("Check") And txtCheckNo.Text.Equals("") Then
            MsgBox("Please Insert Check Number", MsgBoxStyle.Critical, "Check Number is Missing")
            txtCheckNo.Focus()
        ElseIf cmbPaymentMode.Text.Equals("Draft") And txtDraftNo.Text.Equals("") Then
            MsgBox("Please Insert Draft Number", MsgBoxStyle.Critical, "Draft Number is Missing")
            txtDraftNo.Focus()

        Else
            str = ""
            str = "Update DonorMaster set FirstName='" + txtFirstName.Text + "',MiddleName='" + txtMiddleName.Text + "',LastName='" + txtFirstName.Text + "',Gender='" + cmbGender.SelectedItem + "',Address1='" + txtAdd1.Text + "',Address2='" + txtAdd2.Text + "',Address3='" + txtAdd3.Text + "',CountryID='" + txtCountry.Text + "',StateID='" + txtState.Text + "',CityID='" + txtCity.Text + "',LandLineNo='" + txtLandlineNo.Text + "',MobileNo='" + txtMobileNo.Text + "',NRI_Local='" + nationality + "',Nationality='" + txtNationality.Text + "',EmailID='" + txtEmail.Text + "',SpecialInvite='" + SpecialEnvite + "',LifeTimeMember='" + membership + "',TypeOfDonation='" + CmbTypeOfDonation.SelectedItem + "',PaymentMode='" + cmbPaymentMode.SelectedItem + "',CheckNo='" + txtCheckNo.Text + "',DraftNo='" + txtDraftNo.Text + "',Date='" + DTPDate.Value + "',Amount='" + txtAmount.Text + "'where DonorID=" + testModule.var.ToString()
            cmd = New SqlCommand(str, con)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Updated Successfully", "Sub Donor Master")
            FrmSubDonorRegistration.ClearDonorDetails()
            frmDonorDetails.BindGrid()
            testModule.var = ""
            Me.Close()

        End If
    End Sub

   
    Private Sub BtnCountryAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmCOuntryMaster.Show()

    End Sub

    Private Sub BtnStateAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmStateMaster.Show()

    End Sub

    Private Sub BtnCityAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmCityMaster.Show()

    End Sub

    Private Sub cmbPaymentMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPaymentMode.SelectedIndexChanged
        If cmbPaymentMode.SelectedItem = "Check" Then
            lblCheckNumber.Visible = True
            txtCheckNo.Visible = True
            lblDraftNumber.Visible = False
            txtDraftNo.Visible = False
        ElseIf cmbPaymentMode.SelectedItem = "Cash" Then
            lblCheckNumber.Visible = False
            txtCheckNo.Visible = False
            lblDraftNumber.Visible = False
            txtDraftNo.Visible = False
        ElseIf cmbPaymentMode.SelectedItem = "Draft" Then
            lblDraftNumber.Visible = True
            txtDraftNo.Visible = True
            lblCheckNumber.Visible = False
            txtCheckNo.Visible = False
        End If
    End Sub

    Private Sub txtAmount_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
            Beep()
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False

        End If
    End Sub

    Private Sub txtDraftNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDraftNo.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
            Beep()
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False

        End If
    End Sub

    Private Sub txtCheckNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCheckNo.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
            Beep()
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False

        End If
    End Sub

    
   
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If testModule.var.ToString() <> "" Then
            Dim m = MessageBox.Show("Are You Sure ? ", "Donor Master", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If m = Windows.Forms.DialogResult.Yes Then
                str = ""
                str = "Delete From DonorMaster where DonorID = '" + testModule.var.ToString() + "'"
                cmd = New SqlCommand(str, con)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Your Record is Deleted", "Donor Master", MessageBoxButtons.OK, MessageBoxIcon.Information)
                frmDonorDetails.BindGrid()
                testModule.var = ""
                Me.Close()
                frmDonorDetails.Show()
            End If
            If m = Windows.Forms.DialogResult.No Then
                MessageBox.Show("Operation is cancelled by user", "Donor Master", MessageBoxButtons.OK, MessageBoxIcon.Information)
                testModule.var = ""
            End If
        Else

            MessageBox.Show("Please select any row to delete.", "Donor Master", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Refresh()
        End If
    End Sub

    Private Sub txtCountry_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCountry.KeyPress
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

    Private Sub txtState_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtState.KeyPress
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

    Private Sub txtCity_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCity.KeyPress
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