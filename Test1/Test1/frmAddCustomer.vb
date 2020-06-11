﻿''''
'''Lance Brown
'''Test1
'''6/8/20
'''
' --------------------------------------------------------------------------------
' Options
' --------------------------------------------------------------------------------
Option Strict On
Public Class frmAddCustomer
    Private Sub frmAddCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Try

        '    Dim strSelect As String = ""
        '    Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        '    Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to

        '    Dim dt As DataTable = New DataTable ' this is the table we will load from our reader


        '    ' loop through the textboxes and clear them in case they have data in them after a delete
        '    For Each cntrl As Control In Controls
        '        If TypeOf cntrl Is TextBox Then
        '            cntrl.Text = String.Empty
        '        End If
        '        If TypeOf cntrl Is ComboBox Then
        '            Dim box As ComboBox = CType(cntrl, ComboBox)
        '            If box.Tag Is "input" Then
        '                box.SelectedIndex = -1
        '            End If
        '        End If
        '    Next

        '    ' open the DB
        '    If OpenDatabaseConnectionSQLServer() = False Then

        '        ' No, warn the user ...
        '        MessageBox.Show(Me, "Database connection error." & vbNewLine &
        '                            "The application will now close.",
        '                            Me.Text + " Error",
        '                            MessageBoxButtons.OK, MessageBoxIcon.Error)

        '        ' and close the form/application
        '        Me.Close()

        '    End If

        '    ' Build the select statement
        '    strSelect = "SELECT intShirtSizeID, strShirtSizeDesc FROM TShirtSizes"

        '    ' Retrieve all the records 
        '    cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
        '    drSourceTable = cmdSelect.ExecuteReader

        '    ' load table from data reader
        '    dt.Load(drSourceTable)

        '    ' Add the item to the combo box. We need the Customer ID associated with the name so 
        '    ' when we click on the name we can then use the ID to pull the rest of the Customers data.
        '    ' We are binding the column name to the combo box display and value members. 
        '    cboShirt.ValueMember = "intShirtSizeID"
        '    cboShirt.DisplayMember = "strShirtSizeDesc"
        '    cboShirt.DataSource = dtShirt
        '    ' Select the first item in the list by default
        '    If cboShirt.Items.Count > 0 Then cboShirt.SelectedIndex = 0

        '    strSelect = "SELECT intGenderID, strGenderDesc FROM TGenders"
        '    cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
        '    drGSourceTable = cmdSelect.ExecuteReader
        '    dtGender.Load(drGSourceTable)
        '    cboGender.ValueMember = "intGenderID"
        '    cboGender.DisplayMember = "strGenderDesc"
        '    cboGender.DataSource = dtGender
        '    ' Select the first item in the list by default
        '    If cboGender.Items.Count > 0 Then cboGender.SelectedIndex = 0

        '    ' Clean up
        '    drSSourceTable.Close()
        '    drGSourceTable.Close()
        '    ' close the database connection
        '    CloseDatabaseConnection()

        'Catch excError As Exception

        '    ' Log and display error message
        '    MessageBox.Show(excError.Message)

        'End Try
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strSelect As String
        Dim strInsert As String
        Dim strFirstName As String = ""
        Dim strLastName As String = ""
        Dim strAddress As String = ""
        Dim strCity As String = ""
        Dim strState As String = ""
        Dim strZip As String = ""
        Dim strLoyalty As String = ""
        Dim cmdSelect As OleDb.OleDbCommand
        Dim cmdInsert As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim intNextHighestRecordID As Integer
        Dim intRowsAffected As Integer

        strFirstName = txtFirst.Text
        strLastName = txtLast.Text
        strAddress = txtAddress.Text
        strCity = txtCity.Text
        strState = txtState.Text
        strZip = txtZip.Text
        strLoyalty = txtLoyalty.Text


        If Validation() = True Then



            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            strSelect = "SELECT MAX(intCustomerID) + 1 AS intNextHighestRecordID " &
                        " FROM TCustomers"

            ' Execute command
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' Read result( highest ID )
            drSourceTable.Read()

            ' Null? (empty table)
            If drSourceTable.IsDBNull(0) = True Then

                ' Yes, start numbering at 1
                intNextHighestRecordID = 1

            Else

                ' No, get the next highest ID
                intNextHighestRecordID = CInt(drSourceTable.Item(0))

            End If
            strInsert = "Insert into TCustomers (intCustomerID, strFirstName, strLastName, strAddress, strCity, strState, strZip, strLoyaltyCard)" &
                " Values (" & intNextHighestRecordID & ",'" & strFirstName & "'," & "'" & strLastName & "'," & "'" & strAddress & "'," & "'" & strCity & "'," & "'" & strState & "'," & "'" & strZip & "'," & "'" & strLoyalty & "')"

            cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)


            intRowsAffected = cmdInsert.ExecuteNonQuery()
            If intRowsAffected > 0 Then
                MessageBox.Show("Customer has been added")
                Close()
            End If
        End If
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


End Class