Public Class frmInput
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim intInput As Integer
        Dim intOutput As Integer
        If Integer.TryParse(txtInput.Text, intInput) Then
            If intInput > 0 Then
                For i As Integer = 0 To intInput
                    intOutput += i
                Next


                MessageBox.Show("The sum of 1 to " & intInput & " is " & intOutput)
            Else
                MessageBox.Show("Please enter a positive value")
            End If
        Else
            MessageBox.Show("Please enter an integer value")
        End If
    End Sub
End Class