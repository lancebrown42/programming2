''''
'''Lance Brown
'''Assignment 8
'''08/01/20
Option Strict On
Public Class frmAddEvent
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim strYear As String = ""
        strYear = txtYear.Text
        If Validation() = True Then
            AddEvent(strYear)
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
    Private Sub AddEvent(ByVal strEventYear As String)
        Dim cmdAddEvent As New OleDb.OleDbCommand()
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
            cmdAddEvent.CommandText = "EXECUTE uspAddEvent '" & intPKID & "', '" & strEventYear & "'"
            cmdAddEvent.CommandType = CommandType.StoredProcedure

            cmdAddEvent = New OleDb.OleDbCommand(cmdAddEvent.CommandText, m_conAdministrator)

            intRowsAffected = cmdAddEvent.ExecuteNonQuery()

            CloseDatabaseConnection()

            If intRowsAffected > 0 Then
                MessageBox.Show("Event has been added")
                Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.ToString)
        End Try
    End Sub
End Class