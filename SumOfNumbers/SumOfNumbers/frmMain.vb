
'''Lance Brown
'''5/25/20
'''Program to take a single input and calculate the sum from 1 to the input/

Public Class frmMain


    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub btnNumbers_Click(sender As Object, e As EventArgs) Handles btnNumbers.Click
        frmInput.ShowDialog()
    End Sub
End Class
