''''
'''Lance Brown
'''Assignment 8
'''08/01/20
'''Program that pulls data from DB and allows user to update golfer info
'''
Option Strict On

Public Class frmEvents
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub frmEvents_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            strSelect = "SELECT intEventYearID, intEventYear FROM TEventYears"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)

            ' Add the item to the combo box. We need the Golfer ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the rest of the Golfers data.
            ' We are binding the column name to the combo box display and value members. 
            cboYear.ValueMember = "intEventYearID"
            cboYear.DisplayMember = "intEventYear"
            cboYear.DataSource = dt

            ' Select the first item in the list by default
            If cboYear.Items.Count > 0 Then cboYear.SelectedIndex = 0

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try
    End Sub

    Private Sub btnAddEvent_Click(sender As Object, e As EventArgs) Handles btnAddEvent.Click
        Dim AddEvent As New frmAddEvent
        AddEvent.ShowDialog()
        frmEvents_Load(sender, e)
    End Sub
End Class