Public Class frmMain
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnVowels_Click(sender As Object, e As EventArgs) Handles btnVowels.Click
        Dim intVowels As Integer = CountVowels(txtSentence.Text)
        MessageBox.Show(intVowels.ToString & " vowels in the sentence")

    End Sub

    Private Function CountVowels(ByVal strSentence As String) As Integer
        Dim intVowels As Integer
        Dim strCurrentLetter As String
        strSentence = strSentence.ToLower()
        For i = 0 To strSentence.Length - 1
            strCurrentLetter = strSentence.Substring(i, 1)
            If strCurrentLetter = "a" Or strCurrentLetter = "e" Or strCurrentLetter = "i" Or strCurrentLetter = "o" Or strCurrentLetter = "u" Then
                intVowels += 1

            End If
        Next
        Return intVowels
    End Function
    Private Function CountWords(ByVal strSentence As String) As Integer
        Dim intWords As Integer = 1 'need to buffer for either first or last word
        Dim strCurrentCharacter As String
        For i = 0 To strSentence.Length - 1
            strCurrentCharacter = strSentence.Substring(i, 1)
            If strCurrentCharacter = " " Then
                intWords += 1
            End If
        Next
        Return intWords

    End Function

    Private Sub btnWords_Click(sender As Object, e As EventArgs) Handles btnWords.Click
        Dim intWords As Integer = CountWords(txtSentence.Text)
        MessageBox.Show(intWords.ToString & " words in the sentence")
    End Sub

    Private Sub btnSplit_Click(sender As Object, e As EventArgs) Handles btnSplit.Click
        Dim arrSplit = SplitRecord(txtRecord.Text)
        txtF1.Text = arrSplit(0).ToString
        txtF2.Text = arrSplit(1).ToString
        txtF3.Text = arrSplit(2).ToString
        txtF4.Text = arrSplit(3).ToString
        txtF5.Text = arrSplit(4).ToString
        txtF6.Text = arrSplit(5).ToString
    End Sub
    Private Function SplitRecord(ByVal strRecord As String) As Array
        Dim arrSub(5) As String
        Dim arrIndices(7) As Integer
        Dim strCurrentCharacter As String
        Dim strCurrentRecord As String
        arrIndices.SetValue(0, 0) 'start at beginning
        arrIndices.SetValue(strRecord.Length - 1, 6) 'end at end
        Dim j As Integer = 1
        For i As Integer = 0 To strRecord.Length - 1
            strCurrentCharacter = strRecord.Substring(i, 1)
            If strCurrentCharacter = "," Then
                arrIndices.SetValue(i, j)
                j += 1
            End If
        Next
        For i As Integer = 0 To 5
            strCurrentRecord = strRecord.Substring(arrIndices.GetValue(i) + 1, arrIndices.GetValue(i + 1) - arrIndices.GetValue(i) - 1)
            arrSub.SetValue(strCurrentRecord, i)
        Next
        Return arrSub

    End Function
End Class
