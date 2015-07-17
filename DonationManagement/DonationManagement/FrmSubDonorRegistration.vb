Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class FrmSubDonorRegistration
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim ds As DataSet
    Dim da As SqlDataAdapter
    Dim str As String
    Dim nationality As String
    Dim membership As String
    Dim SpecialInvite As String
    Private Sub FrmSubDonorRegistration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        con = New SqlConnection(testModule.ConStr)
        con.Open()

        BindMainDonoCmb()
        Timer1.Start()
    End Sub




    Sub BindMainDonoCmb()
        str = ""
        str = "Select * from DonorMaster where DonorID=" + testModule.var.ToString()
        ds = New DataSet
        da = New SqlDataAdapter(str, con)
        da.Fill(ds)
        If (ds.Tables(0).Rows.Count > 0) Then
            cmbMainDonor.DataSource = ds.Tables(0)
            cmbMainDonor.DisplayMember = "FirstName"
            cmbMainDonor.ValueMember = "DonorID"
        Else
            cmbMainDonor.DataSource = System.DBNull.Value.ToString()
        End If

    End Sub

   


    Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click
   
        'Life time member or not?
        membership = chkLifeMember.Checked
        If membership = True Then
            membership = "Yes"
        Else
            membership = "No"
        End If

        'Special Invitation or not?
        SpecialInvite = chkSpecialInvite.Checked
        If SpecialInvite = True Then
            SpecialInvite = "Yes"
        Else
            SpecialInvite = "No"
        End If

        'NRI or Local?
        If rbtnNRI.Checked = True Then
            nationality = "NRI"
        Else
            nationality = "Local"
        End If

        If cmbMainDonor.SelectedIndex.Equals(-1) Then
            MsgBox("Please Select Main Donor", MsgBoxStyle.Critical, "Main Donor Is not Selected")
            txtFirstName.Focus()
        ElseIf txtFirstName.Text.Equals("") Then
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
            MsgBox("Please Insert Country", MsgBoxStyle.Critical, "Country is Missing")
            txtCountry.Focus()
        ElseIf txtState.Text = "" Then
            MsgBox("Please Insert State", MsgBoxStyle.Critical, "State is Missing")
            txtState.Focus()
        ElseIf txtCity.Text = "" Then
            MsgBox("Please Insert City", MsgBoxStyle.Critical, "City is Missing")
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

        ElseIf cmbTypeOfDonation.SelectedIndex.Equals(-1) Then
            MsgBox("Please Select the Type of Donation", MsgBoxStyle.Critical, "Donation Type is not Selected")
            cmbTypeOfDonation.Focus()
        ElseIf cmbPaymentMode.SelectedIndex.Equals(-1) Then
            MsgBox("Please Select the Payment Mode", MsgBoxStyle.Critical, "Payment Mode is not Selected")
            cmbPaymentMode.Focus()
        ElseIf txtSubDonorAmount.Text.Equals("") Then
            MsgBox("Please Insert Ammount", MsgBoxStyle.Critical, "Ammount is Missing")
            txtSubDonorAmount.Focus()
        ElseIf cmbPaymentMode.Text.Equals("Check") And txtCheckNo.Text.Equals("") Then
            MsgBox("Please Insert Check Number", MsgBoxStyle.Critical, "Check Number is Missing")
            txtCheckNo.Focus()
        ElseIf cmbPaymentMode.Text.Equals("Draft") And txtDraftNo.Text.Equals("") Then
            MsgBox("Please Insert Draft Number", MsgBoxStyle.Critical, "Draft Number is Missing")
            txtDraftNo.Focus()

        Else
            str = ""
            str = "Insert into SubDonorMaster(DonorID,FirstName,MiddleName,LastName,Gender,Address1,Address2,Address3,CountryID,StateID,CityID,LandlineNo,MobileNo,NRI_Local,Nationality,EmailID,SpecialInvite,LifeTimeMember,TypeOfDonation,PaymentMode,CheckNo,DraftNo,Date,Amount) values('" + cmbMainDonor.Text + "','" + txtFirstName.Text + "','" + txtMiddleName.Text + "','" + txtLastName.Text + "','" + cmbGender.Text + "','" + txtAdd1.Text + "','" + txtAdd2.Text + "','" + txtAdd3.Text + "','" + txtCountry.Text + "','" + txtState.Text + "','" + txtCity.Text + "','" + txtLandlineNo.Text + "','" + txtMobileNo.Text + "','" + nationality + "','" + txtNationality.Text + "','" + txtEmail.Text + "','" + SpecialInvite + "','" + membership + "','" + cmbTypeOfDonation.Text + "','" + cmbPaymentMode.Text + "','" + txtCheckNo.Text + "','" + txtDraftNo.Text + "','" + DTPDate.Value + "','" + txtSubDonorAmount.Text + "')"
            cmd = New SqlCommand(str, con)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Inserted Successfully", "Sub Donor Master")
            ClearDonorDetails()
        End If

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()

    End Sub

    Sub ClearDonorDetails()
        txtFirstName.Text = ""
        txtMiddleName.Text = ""
        txtLastName.Text = ""
        cmbGender.SelectedIndex = -1
        txtAdd1.Text = ""
        txtAdd2.Text = ""
        txtAdd3.Text = ""
        txtCountry.Text = ""
        txtCity.Text = ""
        txtState.Text = ""
        txtNationality.Text = ""
        txtMobileNo.Text = ""
        txtLandlineNo.Text = ""
        txtEmail.Text = ""
        rbtnLocal.Checked = False
        rbtnNRI.Checked = False
        chkSpecialInvite.Checked = False
        chkLifeMember.Checked = False
        cmbTypeOfDonation.SelectedIndex = -1
        txtCheckNo.Text = ""
        txtDraftNo.Text = ""
        txtSubDonorAmount.Text = ""
        txtFirstName.Focus()
    End Sub
    Private Sub btnMiniMize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMiniMize.Click
        Me.WindowState = FormWindowState.Minimized
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


    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmCOuntryMaster.Show()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmStateMaster.Show()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmCityMaster.Show()

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lblTimer.Text = System.DateTime.Now.ToLongTimeString
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

   

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ClearDonorDetails()
    End Sub

    Private Sub txtSubDonorAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSubDonorAmount.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
            Beep()
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False

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