Option Strict On
Public Class frmSponsors
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub frmSponsors_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dt As DataTable = New DataTable ' this is the table we will load from our reader

            ' loop through the textboxes and clear them in case they have data in them after a delete
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

            ' open the DB
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            ' Build the select statement
            strSelect = "SELECT intSponsorID, strLastName FROM TSponsors"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)

            ' Add the item to the combo box. We need the Golfer ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the rest of the Golfers data.
            ' We are binding the column name to the combo box display and value members. 
            cboNames.ValueMember = "intSponsorID"
            cboNames.DisplayMember = "strLastName"
            cboNames.DataSource = dt

            ' Select the first item in the list by default
            If cboNames.Items.Count > 0 Then cboNames.SelectedIndex = 0

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            Dim strSelect As String = ""
            Dim strName As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dt As DataTable = New DataTable ' this is the table we will load from our reader

            ' open the database
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                "The application will now close.",
                                Me.Text + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            ' Build the select statement using PK from name selected
            strSelect = "SELECT strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail FROM TSponsors Where intSponsorID = " & cboNames.SelectedValue.ToString

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load the data table from the reader
            dt.Load(drSourceTable)

            ' populate the text boxes with the data
            txtFirstName.Text = dt.Rows(0).Item(0).ToString
            txtLastName.Text = dt.Rows(0).Item(1).ToString
            txtAddress.Text = dt.Rows(0).Item(2).ToString
            txtCity.Text = dt.Rows(0).Item(3).ToString
            txtState.Text = dt.Rows(0).Item(4).ToString
            txtZip.Text = dt.Rows(0).Item(5).ToString
            txtPhone.Text = dt.Rows(0).Item(6).ToString
            txtEmail.Text = dt.Rows(0).Item(7).ToString


            ' close the database connection
            CloseDatabaseConnection()
        Catch ex As Exception
            MessageBox.Show("You probably didn't select a sponsor. Error message: " & ex.Message)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim strSelect As String = ""
        Dim strFirstName As String = ""
        Dim strLastName As String = ""
        Dim strAddress As String = ""
        Dim strCity As String = ""
        Dim strState As String = ""
        Dim strZip As String = ""
        Dim strPhone As String = ""
        Dim strEmail As String = ""
        Dim strShirt As String = ""
        Dim strGender As String = ""
        Dim intRowsAffected As Integer

        ' thie will hold our Update statement
        Dim cmdUpdate As OleDb.OleDbCommand

        ' check to make sure all text boxes have data. No data no update!
        If Validation() = True Then
            ' open database
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            ' after you validate there is data put values into variables
            If Validation() = True Then

                strFirstName = txtFirstName.Text
                strLastName = txtLastName.Text
                strAddress = txtAddress.Text
                strCity = txtCity.Text
                strState = txtState.Text
                strZip = txtZip.Text
                strPhone = txtPhone.Text
                strEmail = txtEmail.Text




                ' Build the select statement using PK from name selected
                strSelect = "Update TSponsors Set strFirstName = '" & strFirstName & "', " & "strLastName = '" & strLastName &
                "', " & "strStreetAddress = '" & strAddress & "', " & "strCity = '" & strCity & "', " &
                 "strState = '" & strState & "', " & "strZip = '" & strZip & "', " & "strPhoneNumber = '" & strPhone & "', " & "strEmail = '" & strEmail &
                 " Where intSponsorID = " & cboNames.SelectedValue.ToString

                ' uncomment out the following message box line to use as a tool to check your sql statement
                ' remember anything not a numeric value going into SQL Server must have single quotes '
                ' around it, including dates.

                MessageBox.Show(strSelect)


                ' make the connection
                cmdUpdate = New OleDb.OleDbCommand(strSelect, m_conAdministrator)

                ' IUpdate the row with execute the statement
                intRowsAffected = cmdUpdate.ExecuteNonQuery()

                ' have to let the user know what happened 
                If intRowsAffected = 1 Then
                    MessageBox.Show("Update successful")
                Else
                    MessageBox.Show("Update failed")
                End If

                ' close the database connection
                CloseDatabaseConnection()

                ' call the Form Load sub to refresh the combo box data after a delete
                frmSponsors_Load(sender, e)
            End If
        End If
    End Sub
End Class