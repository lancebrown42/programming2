''''
'''Lance Brown
'''Assignment 3
'''6/5/20
Option Strict On
Public Class frmAddEvent
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim strSelect As String
        Dim strInsert As String
        Dim strYear As String = ""
        Dim cmdSelect As OleDb.OleDbCommand
        Dim cmdInsert As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim intNextHighestRecordID As Integer
        Dim intRowsAffected As Integer
        strYear = txtYear.Text
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

            strSelect = "SELECT MAX(intEventYearID) + 1 AS intNextHighestRecordID " &
                        " FROM TEventYears"

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
            strInsert = "Insert into TEventYears (intEventYearID, intEventYear)" &
                " Values (" & intNextHighestRecordID & "," & strYear & ")"

            cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)


            intRowsAffected = cmdInsert.ExecuteNonQuery()
            If intRowsAffected > 0 Then
                MessageBox.Show("Event has been added")
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