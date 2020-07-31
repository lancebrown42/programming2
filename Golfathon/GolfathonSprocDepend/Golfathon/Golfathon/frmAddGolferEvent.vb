Public Class frmAddGolferEvent
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub cboEvents_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEvents.SelectedIndexChanged
        Try
            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim dt As DataTable = New DataTable



            If OpenDatabaseConnectionSQLServer() = False Then


                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)


                Me.Close()

            End If
            lstInEvent.BeginUpdate()
            strSelect = "SELECT intGolferID, strLastName FROM vEventGolfers WHERE intEventYearID = " & cboEvents.SelectedValue
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader


            dt.Load(drSourceTable)
            lstInEvent.ValueMember = "intGolferID"
            lstInEvent.DisplayMember = "strLastName"
            lstInEvent.DataSource = dt
            If lstInEvent.Items.Count > 0 Then lstInEvent.SelectedIndex = 0

            lstInEvent.EndUpdate()
            drSourceTable.Close()
            CloseDatabaseConnection()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnAddGolfer_Click(sender As Object, e As EventArgs) Handles btnAddGolfer.Click
        Try
            Dim strInsert As String = ""
            Dim cmdInsert As OleDb.OleDbCommand
            Dim dt As DataTable = New DataTable
            Dim intRowsAffected As Integer


            If OpenDatabaseConnectionSQLServer() = False Then


                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)


                Me.Close()

            End If



            strInsert = "INSERT INTO TGolferEventYears ( intGolferID, intEventYearID )" & "VALUES ( " & cboEvents.SelectedValue & ", " & lstAvailable.SelectedValue & ")"
            cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)
            intRowsAffected = cmdInsert.ExecuteNonQuery()
            CloseDatabaseConnection()
            frmAddGolferEvent_Load(sender, e)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmAddGolferEvent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'Load events into cbo
            '*****************************************
            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim dt As DataTable = New DataTable


            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)


                Me.Close()

            End If


            cboEvents.BeginUpdate()
            strSelect = "SELECT intEventYearID, intEventYear FROM TEventYears"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            dt.Load(drSourceTable)


            cboEvents.ValueMember = "intEventYearID"
            cboEvents.DisplayMember = "intEventYear"
            cboEvents.DataSource = dt

            If cboEvents.Items.Count > 0 Then cboEvents.SelectedIndex = 0


            cboEvents.EndUpdate()


            drSourceTable.Close()

            CloseDatabaseConnection()

            ' load golfers into list
            '******************************
            Dim dt1 As DataTable = New DataTable


            If OpenDatabaseConnectionSQLServer() = False Then


                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)


                Me.Close()

            End If


            lstAvailable.BeginUpdate()

            '*****************************
            'TODO: change this so golfers can be in more than one event, but not the same one twice
            '******************************
            strSelect = "SELECT intGolferID, strLastName FROM vAvailableGolfers"
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader


            dt1.Load(drSourceTable)


            lstAvailable.ValueMember = "intGolferID"
            lstAvailable.DisplayMember = "strLastName"
            lstAvailable.DataSource = dt1



            If lstAvailable.Items.Count > 0 Then lstAvailable.SelectedIndex = 0

            lstAvailable.EndUpdate()


            drSourceTable.Close()

            CloseDatabaseConnection()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnDropGolfer_Click(sender As Object, e As EventArgs) Handles btnDropGolfer.Click
        Dim strDelete As String = ""
        Dim strSelect As String = String.Empty
        Dim strName As String = ""
        Dim intRowsAffected As Integer
        Dim cmdDelete As OleDb.OleDbCommand
        Dim dt As DataTable = New DataTable
        Dim result As DialogResult

        Try




            If OpenDatabaseConnectionSQLServer() = False Then


                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                "The application will now close.",
                                Me.Text + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)

                Me.Close()

            End If


            result = MessageBox.Show("Are you sure you want to Delete Golfer: Last Name-" & lstInEvent.Text & " from " & cboEvents.Text & " ?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)


            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Canceled")
                Case DialogResult.No
                    MessageBox.Show("Action Canceled")
                Case DialogResult.Yes



                    strDelete = "Delete FROM TGolferEventYears Where intGolferID = " & lstInEvent.SelectedValue.ToString


                    cmdDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
                    intRowsAffected = cmdDelete.ExecuteNonQuery()


            End Select



            CloseDatabaseConnection()


            frmAddGolferEvent_Load(sender, e)

        Catch excError As Exception

            MessageBox.Show(excError.Message)

        End Try
    End Sub
End Class