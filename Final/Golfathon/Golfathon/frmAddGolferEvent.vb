'''Lance Brown
'''Assignment 8
'''08/01/20
Option Strict On
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
            Dim dt1 As DataTable = New DataTable



            If OpenDatabaseConnectionSQLServer() = False Then


                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)


                Me.Close()

            End If
            lstInEvent.BeginUpdate()
            strSelect = "SELECT intGolferID, strLastName FROM vEventGolfers WHERE intEventYearID = " & cboEvents.SelectedValue.ToString
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader


            dt.Load(drSourceTable)
            lstInEvent.ValueMember = "intGolferID"
            lstInEvent.DisplayMember = "strLastName"
            lstInEvent.DataSource = dt
            If lstInEvent.Items.Count > 0 Then lstInEvent.SelectedIndex = 0

            lstInEvent.EndUpdate()
            lstAvailable.BeginUpdate()


            strSelect = "SELECT intGolferID, strLastName FROM TGolfers WHERE intGolferID NOT IN (SELECT intGolferID FROM TGolferEventYears WHERE TGolferEventYears.intEventYearID = " & cboEvents.SelectedValue.ToString & ")"
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



            strInsert = "INSERT INTO TGolferEventYears ( intGolferID, intEventYearID )" & "VALUES ( " & lstAvailable.SelectedValue.ToString & ", " & cboEvents.SelectedValue.ToString & ")"
            cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)
            intRowsAffected = cmdInsert.ExecuteNonQuery()
            CloseDatabaseConnection()
            frmAddGolferEvent_Load(sender, e)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
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
            Dim dt1 As DataTable = New DataTable
            Dim dt2 As DataTable = New DataTable
            Dim dt3 As DataTable = New DataTable
            Dim dt4 As DataTable = New DataTable


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
            Dim dt5 As DataTable = New DataTable
            Dim dt6 As DataTable = New DataTable


            If OpenDatabaseConnectionSQLServer() = False Then


                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)


                Me.Close()

            End If
            lstInEvent.BeginUpdate()
            strSelect = "SELECT intGolferID, strLastName FROM vEventGolfers WHERE intEventYearID = " & cboEvents.SelectedValue.ToString
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader


            dt5.Load(drSourceTable)
            lstInEvent.ValueMember = "intGolferID"
            lstInEvent.DisplayMember = "strLastName"
            lstInEvent.DataSource = dt5
            If lstInEvent.Items.Count > 0 Then lstInEvent.SelectedIndex = 0

            lstInEvent.EndUpdate()

            lstAvailable.BeginUpdate()

            '*****************************
            'TODO: change this so golfers can be in more than one event, but not the same one twice
            '******************************
            strSelect = "SELECT intGolferID, strLastName FROM TGolfers WHERE intGolferID NOT IN (SELECT intGolferID FROM TGolferEventYears WHERE TGolferEventYears.intEventYearID = " & cboEvents.SelectedValue.ToString & ")"
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader


            dt6.Load(drSourceTable)


            lstAvailable.ValueMember = "intGolferID"
            lstAvailable.DisplayMember = "strLastName"
            lstAvailable.DataSource = dt6



            If lstAvailable.Items.Count > 0 Then lstAvailable.SelectedIndex = 0

            lstAvailable.EndUpdate()



            drSourceTable.Close()

            CloseDatabaseConnection()
            If OpenDatabaseConnectionSQLServer() = False Then


                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)


                Me.Close()
            End If
            cboSponsors.BeginUpdate()
                'strSelect = "SELECT intGolferID, intSponsorID, intEventYearID, SponsorName FROM vGolferSponsors WHERE intGolferID = " & lstInEvent.SelectedValue.ToString & " AND intEventYearID = " & cboEvents.SelectedValue.ToString
                'cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                'drSourceTable = cmdSelect.ExecuteReader


                'dt.Load(drSourceTable)
                strSelect = "SELECT intSponsorID, strLastName FROM TSponsors"


                cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                drSourceTable = cmdSelect.ExecuteReader
                dt1.Load(drSourceTable)

                cboSponsors.ValueMember = "intSponsorID"
                cboSponsors.DisplayMember = "strLastName"
                cboSponsors.DataSource = dt1
                If cboSponsors.Items.Count > 0 Then cboSponsors.SelectedIndex = 0

            cboSponsors.EndUpdate()


            cboSponsorType.BeginUpdate()
                strSelect = "SELECT intSponsorTypeID, strSponsorTypeDesc from TSponsorTypes"
                cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                drSourceTable = cmdSelect.ExecuteReader
                dt2.Load(drSourceTable)
                cboSponsorType.ValueMember = "intSponsorID"
                cboSponsorType.DisplayMember = "strSponsorTypeDesc"
                cboSponsorType.DataSource = dt2
                If cboSponsorType.Items.Count > 0 Then cboSponsorType.SelectedIndex = 0
            cboSponsorType.EndUpdate()


            cboPaymentType.BeginUpdate()
                strSelect = "SELECT intPaymentTypeID, strPaymentTypeDesc from TPaymentTypes"
                cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                drSourceTable = cmdSelect.ExecuteReader
                dt3.Load(drSourceTable)
            cboPaymentType.ValueMember = "intPaymentTypeID"
            cboPaymentType.DisplayMember = "strPaymentTypeDesc"
            cboPaymentType.DataSource = dt3
            If cboPaymentType.Items.Count > 0 Then cboPaymentType.SelectedIndex = 0
            cboPaymentType.EndUpdate()



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

    Private Sub btnAddSponsor_Click(sender As Object, e As EventArgs) Handles btnAddSponsor.Click
        Try
            Dim strInsert As String = ""
            Dim cmdInsert As New OleDb.OleDbCommand
            Dim cmdSelect As New OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim dt As DataTable = New DataTable
            Dim dt1 As DataTable = New DataTable
            Dim intRowsAffected As Integer
            Dim cmdAddGolferSponsor As New OleDb.OleDbCommand
            Dim result As DialogResult
            Dim strSelect As String = ""
            Dim strGolferID As String = ""



            If OpenDatabaseConnectionSQLServer() = False Then


                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)


                Me.Close()

            End If

            strSelect = "SELECT intGolferID from TGolferEventYears WHERE intGolferEventYearID = " & lstInEvent.SelectedValue.ToString


            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dt1.Load(drSourceTable)
            result = MessageBox.Show("Add Sponsor " & cboSponsors.SelectedText & " to Golfer- " & lstInEvent.Text & " in " & cboEvents.Text & " ?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)


            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Canceled")
                Case DialogResult.No
                    MessageBox.Show("Action Canceled")
                Case DialogResult.Yes


                    cmdAddGolferSponsor.CommandText = "EXECUTE uspAddGolferSponsor " & dt1.Select().ToString & ", " & cboEvents.SelectedValue.ToString & ", " & cboSponsors.SelectedValue.ToString & ", " & txtPledge.Text & ", " & cboSponsorType.SelectedValue.ToString & ", " & cboPaymentType.SelectedValue.ToString & ", " & cboPayment.SelectedValue.ToString
                    cmdAddGolferSponsor.CommandType = CommandType.StoredProcedure

                    cmdAddGolferSponsor = New OleDb.OleDbCommand(cmdAddGolferSponsor.CommandText, m_conAdministrator)



            End Select



            CloseDatabaseConnection()
            frmAddGolferEvent_Load(sender, e)

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub lstInEvent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstInEvent.SelectedIndexChanged

    End Sub
End Class