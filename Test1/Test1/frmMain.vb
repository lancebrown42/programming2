''''
'''Lance Brown
'''Test1
'''6/8/20
'''
' --------------------------------------------------------------------------------
' Options
' --------------------------------------------------------------------------------
Option Strict On

Public Class frmMain


    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim dt As DataTable = New DataTable

            For Each ctrl As Control In Controls
                If TypeOf ctrl Is TextBox Then
                    ctrl.Text = String.Empty
                End If
                If TypeOf ctrl Is ComboBox Then
                    Dim box As ComboBox = CType(ctrl, ComboBox)
                    If box.Tag Is "input" Then
                        box.SelectedIndex = -1
                    End If
                End If
            Next
            If OpenDatabaseConnectionSQLServer() = False Then


                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)


                Me.Close()
            End If

            strSelect = "SELECT intCustomerID, strLastName FROM TCustomers"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            dt.Load(drSourceTable)

            cboCustomers.ValueMember = "intCustomerID"
            cboCustomers.DisplayMember = "strLastName"
            cboCustomers.DataSource = dt


            If cboCustomers.Items.Count > 0 Then cboCustomers.SelectedIndex = 0
            drSourceTable.Close()
            CloseDatabaseConnection()

        Catch excError As Exception
            MessageBox.Show(excError.Message)

        End Try
    End Sub


    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Dim strSelect As String = ""
        Dim strName As String = ""
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
        strSelect = "SELECT strFirstName, strLastName, strAddress, strCity, strState, strZip, strLoyaltyCard FROM TCustomers Where intCustomerID = " & cboCustomers.SelectedValue.ToString
        cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
        drSourceTable = cmdSelect.ExecuteReader

        dt.Load(drSourceTable)

        txtFirst.Text = dt.Rows(0).Item(0).ToString
        txtLast.Text = dt.Rows(0).Item(1).ToString
        txtAddress.Text = dt.Rows(0).Item(2).ToString
        txtCity.Text = dt.Rows(0).Item(3).ToString
        txtState.Text = dt.Rows(0).Item(4).ToString
        txtZip.Text = dt.Rows(0).Item(5).ToString
        txtLoyalty.Text = dt.Rows(0).Item(6).ToString

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
        Dim strLoyalty As String = ""
        Dim intRowsAffected As Integer

        Dim cmdUpdate As OleDb.OleDbCommand

        If Validation() = True Then
            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                Me.Close()
            End If

            If Validation() = True Then

                strFirstName = txtFirst.Text
                strLastName = txtLast.Text
                strAddress = txtAddress.Text
                strCity = txtCity.Text
                strState = txtState.Text
                strZip = txtZip.Text
                strLoyalty = txtLoyalty.Text




                strSelect = "Update TCustomers Set strFirstName = '" & strFirstName & "', " & "strLastName = '" & strLastName &
                "', " & "strStreetAddress = '" & strAddress & "', " & "strCity = '" & strCity & "', " &
                 "strState = '" & strState & "', " & "strZip = '" & strZip & "', " & "strLoyaltyNumber = '" & strLoyalty & "' " & "Where intCustomerID = " & cboCustomers.SelectedValue.ToString

                MessageBox.Show(strSelect)

                cmdUpdate = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                intRowsAffected = cmdUpdate.ExecuteNonQuery()

                If intRowsAffected = 1 Then
                    MessageBox.Show("Update successful")
                Else
                    MessageBox.Show("Update failed")
                End If

                CloseDatabaseConnection()
                frmMain_Load(sender, e)
            End If
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim strDelete As String = ""
        Dim strSelect As String = String.Empty
        Dim strName As String = ""
        Dim intRowsAffected As Integer
        Dim cmdDelete As OleDb.OleDbCommand
        Dim dt As DataTable = New DataTable
        Dim result As DialogResult
        If OpenDatabaseConnectionSQLServer() = False Then
            MessageBox.Show("Database connection error." & vbNewLine &
                                "The application will now close.",
                                Text + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()

        End If

        result = MessageBox.Show("Are you sure you want to Delete Customer: Last Name-" & cboCustomers.Text & "?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

        Select Case result
            Case DialogResult.Cancel
                MessageBox.Show("Action Canceled")
            Case DialogResult.No
                MessageBox.Show("Action Canceled")
            Case DialogResult.Yes

                strDelete = "Delete FROM TCustomers Where intCustomerID = " & cboCustomers.SelectedValue.ToString

                cmdDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
                intRowsAffected = cmdDelete.ExecuteNonQuery()
                If intRowsAffected > 0 Then
                    MessageBox.Show("Delete successful")
                End If

        End Select



        CloseDatabaseConnection()
        frmMain_Load(sender, e)
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim AddCustomer As New frmAddCustomer
        AddCustomer.ShowDialog()
        frmMain_Load(sender, e)
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


End Class
