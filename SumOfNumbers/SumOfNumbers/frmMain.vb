
'''Lance Brown
'''5/25/20
'''Program to take a single input and calculate the sum from 1 to the input/

Public Class frmMain


    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub btnNumbers_Click(sender As Object, e As EventArgs) Handles btnNumbers.Click
        Dim intInput As Integer
        Dim intOutput As Integer
        If Integer.TryParse(InputBox("Enter a Positive Value", "Input", "10"), intInput) Then
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
