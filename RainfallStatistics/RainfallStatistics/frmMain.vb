'''''
'''Lance Brown
'''6/25/20
'''Assignment 5
'''''
Option Strict On
Public Class frmMain
    Dim arrRainfall(12) As String
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnInput_Click(sender As Object, e As EventArgs) Handles btnInput.Click
        Dim input As String = InputBox("Input monthly rainfall serparated by commas (eg. 3, 8, 6, 6, 4, 7, 5, 6, 3, 8, 2, 4, 3:")
        If Validate(input) Then
            arrRainfall = SplitRecord(input)
        Else
            btnInput_Click(sender, e)
        End If
    End Sub

    Private Sub btnDisplay_Click(sender As Object, e As EventArgs) Handles btnDisplay.Click
        txtInput.Text = "Monthly Rainfall Input" & vbCrLf & "---------------------------"
        Dim dblTotal As Double
        Dim arrNumbers() As Double = {}
        Dim i As Int32 = 0
        For Each entry In arrRainfall
            txtInput.AppendText(vbCrLf & "Rainfall for " & MonthName(i + 1) & "= " & entry)

            dblTotal += CDbl(entry)
            Array.Resize(arrNumbers, arrNumbers.Length + 1)
            arrNumbers(i) = CDbl(entry)
            Debug.WriteLine(arrNumbers(i))
            i += 1
        Next
        txtTotal.Text = "The total annual rainfall was " & dblTotal
        txtAvg.Text = "The average monthly rainfall was " & (dblTotal / 12)
        txtMin.Text = "The minimum monthly rainfall was " & arrNumbers.Min & " (" & MonthName(Array.IndexOf(arrNumbers, arrNumbers.Min) + 1) & ")"
        txtMax.Text = "The maximum monthly rainfall was " & arrNumbers.Max & " (" & MonthName(Array.IndexOf(arrNumbers, arrNumbers.Max) + 1) & ")"

    End Sub


    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        For Each ctrl As Control In Controls
            If TypeOf ctrl Is TextBox Then
                ctrl.ResetText()
            End If
        Next
    End Sub
    Private Function SplitRecord(ByVal strRecord As String) As String()
        Dim arrSub(5) As String
        arrSub = strRecord.Split(New Char() {","c}, 12)

        'weed out additional entries
        If arrSub(arrSub.Length - 1).IndexOf(",") <> -1 Then
            arrSub(5) = arrSub(11).Substring(0, arrSub(11).IndexOf(","))
        End If
        'trim whitespace
        For i = 0 To arrSub.Length - 1

            arrSub(i) = arrSub(i).Trim()

        Next
        If arrSub.Length < 12 Then
            Array.Resize(Of String)(arrSub, 12)
            For i = 0 To arrSub.Length - 1
                If IsNothing(arrSub(i)) Then
                    arrSub(i) = ""
                End If
            Next
        End If

        Return arrSub

    End Function
    Private Function Validate(ByVal input As String) As Boolean
        Dim blnIsValid As Boolean
        If String.IsNullOrEmpty(input) Then
            blnIsValid = False
            MessageBox.Show("Input required")

        End If
        For Each c As Char In input
            If IsNumeric(c) Or c = "," Or c = "." Or c = " " Then
                blnIsValid = True
            Else

                MessageBox.Show("Must be numeric")
                blnIsValid = False
                Exit For
            End If
        Next

        Return blnIsValid



    End Function
End Class
