Option Strict On
Public Class frmAddSponsor
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnAddSponsor_Click(sender As Object, e As EventArgs) Handles btnAddSponsor.Click
        Dim strFirstName As String = ""
        Dim strLastName As String = ""
        Dim strAddress As String = ""
        Dim strCity As String = ""
        Dim strState As String = ""
        Dim strZip As String = ""
        Dim strPhone As String = ""
        Dim strEmail As String = ""



        strFirstName = txtFirstName.Text
        strLastName = txtLastName.Text
        strAddress = txtAddress.Text
        strCity = txtCity.Text
        strState = txtState.Text
        strZip = txtZip.Text
        strPhone = txtPhone.Text
        strEmail = txtEmail.Text



        If Validation() = True Then

            AddSponsor(strFirstName, strLastName, strAddress, strCity, strState, strZip, strPhone, strEmail)
        End If
    End Sub

    Private Sub frmAddSponsor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each cntrl As Control In Controls
            If TypeOf cntrl Is TextBox Then
                cntrl.Text = String.Empty
            End If
            If TypeOf cntrl Is ComboBox Then
                Dim box As ComboBox = CType(cntrl, ComboBox)
                If box.Tag Is "input" Then
                    box.SelectedIndex = -1
                End If
            End If
        Next
    End Sub
    Public Function Validation() As Boolean

        ' loop through the textboxes and clear them in case they have data in them after a delete
        For Each cntrl As Control In Controls
            If TypeOf cntrl Is TextBox Then
                cntrl.BackColor = Color.White
                If cntrl.Text = String.Empty Then
                    cntrl.BackColor = Color.Yellow
                    cntrl.Focus()
                    Return False
                End If
            End If
        Next

        'every this is good so return true
        Return True

    End Function
    Private Sub AddSponsor(ByVal strFirstName As String, ByVal strLastName As String, ByVal strAddress As String, ByVal strCity As String, ByVal strState As String, ByVal strZip As String, ByVal strPhone As String, ByVal strEmail As String)
        Dim cmdAddSponsor As New OleDb.OleDbCommand()
        Dim intRowsAffected As Integer
        Dim intPKID As Integer
        Try
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If
            cmdAddSponsor.CommandText = "EXECUTE uspAddSponsor '" & intPKID & "', '" & strFirstName & "'," & "'" & strLastName & "'," & "'" & strAddress & "'," & "'" & strCity & "'," & "'" & strState & "'," & "'" & strZip & "'," & "'" & strPhone & "'," & "'" & strEmail
            cmdAddSponsor.CommandType = CommandType.StoredProcedure

            cmdAddSponsor = New OleDb.OleDbCommand(cmdAddSponsor.CommandText, m_conAdministrator)

            intRowsAffected = cmdAddSponsor.ExecuteNonQuery()

            CloseDatabaseConnection()

            If intRowsAffected > 0 Then
                MessageBox.Show("Sponsor has been added")
                Close()

            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.ToString)
        End Try
    End Sub
End Class