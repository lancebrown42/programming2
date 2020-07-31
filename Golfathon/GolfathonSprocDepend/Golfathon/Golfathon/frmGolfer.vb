''''
'''Lance Brown
'''Assignment 3
'''6/5/20
'''Program that pulls data from DB and allows user to update golfer info
'''
Option Strict On
Public Class frmGolfer
    Private Sub frmGolfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
            strSelect = "SELECT intGolferID, strLastName FROM TGolfers"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)

            ' Add the item to the combo box. We need the Golfer ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the rest of the Golfers data.
            ' We are binding the column name to the combo box display and value members. 
            cboNames.ValueMember = "intGolferID"
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

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        '''''
        '''*************************************************************************************************************
        '''TODO
        '''Handle "Submit" with nothing selected, because this form is not intuitive
        '''**************************************************************************************************************
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
        strSelect = "SELECT strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail, strShirtSizeDesc, strGenderDesc FROM TGolfers JOIN TShirtSizes on TGolfers.intShirtSizeID = TShirtSizes.intShirtSizeID JOIN TGenders on TGolfers.intGenderID = TGenders.intGenderID Where intGolferID = " & cboNames.SelectedValue.ToString

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
        cboShirt.SelectedItem = dt.Rows(0).Item(8)
        cboGender.SelectedItem = dt.Rows(0).Item(9)

        ' close the database connection
        CloseDatabaseConnection()
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
                strShirt = cboShirt.Text
                strGender = cboGender.Text



                ' Build the select statement using PK from name selected
                strSelect = "Update TGolfers Set strFirstName = '" & strFirstName & "', " & "strLastName = '" & strLastName &
                "', " & "strStreetAddress = '" & strAddress & "', " & "strCity = '" & strCity & "', " &
                 "strState = '" & strState & "', " & "strZip = '" & strZip & "', " & "strPhoneNumber = '" & strPhone & "', " & "strEmail = '" & strEmail & "', " & "intShirtSizeID = " & cboShirt.SelectedIndex + 1 & ", intGenderID = " & cboGender.SelectedIndex + 1 &
                 "Where intGolferID = " & cboNames.SelectedValue.ToString

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
                frmGolfer_Load(sender, e)
            End If
        End If
    End Sub
    Public Function Validation() As Boolean
        For Each ctrl As Control In Controls
            If TypeOf ctrl Is TextBox Then
                ctrl.BackColor = Color.White
                If ctrl.Text = String.Empty Then
                    ctrl.BackColor = Color.HotPink
                    ctrl.Focus()
                    Return False
                End If
            End If
        Next
        Return True

    End Function

    Private Sub btnAddGolfer_Click(sender As Object, e As EventArgs) Handles btnAddGolfer.Click
        Dim AddGolfer As New frmAddGolfer
        AddGolfer.ShowDialog()
        frmGolfer_Load(sender, e)
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim strDelete As String = ""
        Dim strSelect As String = String.Empty
        Dim strName As String = ""
        Dim intRowsAffected As Integer
        Dim cmdDelete As OleDb.OleDbCommand ' this will be used for our Delete statement
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader
        Dim result As DialogResult  ' this is the result of which button the user selects
        If OpenDatabaseConnectionSQLServer() = False Then
            MessageBox.Show("Database connection error." & vbNewLine &
                                "The application will now close.",
                                Text + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()

        End If

        result = MessageBox.Show("Are you sure you want to Delete Golfer: Last Name-" & cboNames.Text & "?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

        Select Case result
            Case DialogResult.Cancel
                MessageBox.Show("Action Canceled")
            Case DialogResult.No
                MessageBox.Show("Action Canceled")
            Case DialogResult.Yes


                ' Build the delete statement using PK from name selected
                ' must delete any child revords first
                strDelete = "Delete FROM TGolferEventYears Where intGolferID = " & cboNames.SelectedValue.ToString

                ' Delete the record(s) 
                cmdDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
                intRowsAffected = cmdDelete.ExecuteNonQuery()

                ' now we can delete the parent record
                strDelete = "Delete FROM TGolfers Where intGolferID = " & cboNames.SelectedValue.ToString

                ' Delete the record(s) 
                cmdDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
                intRowsAffected = cmdDelete.ExecuteNonQuery()

                ' Did it work?
                If intRowsAffected > 0 Then

                    ' Yes, success
                    MessageBox.Show("Delete successful")

                End If

        End Select


        ' close the database connection
        CloseDatabaseConnection()

        ' call the Form Load sub to refresh the combo box data after a delete
        frmGolfer_Load(sender, e)
    End Sub
End Class