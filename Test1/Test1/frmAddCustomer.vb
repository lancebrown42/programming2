''''
'''Lance Brown
'''Test1
'''6/8/20
'''
' --------------------------------------------------------------------------------
' Options
' --------------------------------------------------------------------------------
Option Strict On
Public Class frmAddCustomer
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


            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            drSourceTable.Read()

            If drSourceTable.IsDBNull(0) = True Then
                intNextHighestRecordID = 1

            Else
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
        Return True

    End Function


End Class