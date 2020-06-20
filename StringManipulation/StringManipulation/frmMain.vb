#Disable Warning BC42312 ' XML documentation comments must precede member or type declarations
''' <summary>
''' Lance Brown
''' String Manipulation
''' 6/15/20
''' </summary>
''' 
''' Options
Option Strict On
#Enable Warning BC42312 ' XML documentation comments must precede member or type declarations

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
        Dim arrSplit As String() = SplitRecord(txtRecord.Text)
        txtRecord.ResetText()
        txtF1.Text = arrSplit(0).ToString
        txtF2.Text = arrSplit(1).ToString
        txtF3.Text = arrSplit(2).ToString
        txtF4.Text = arrSplit(3).ToString
        txtF5.Text = arrSplit(4).ToString
        txtF6.Text = arrSplit(5).ToString
    End Sub
    Private Function SplitRecord(ByVal strRecord As String) As String()
        Dim arrSub(5) As String
        arrSub = strRecord.Split(New Char() {","c}, 6)

        'weed out additional entries
        If arrSub(arrSub.Length - 1).IndexOf(",") <> -1 Then
            arrSub(5) = arrSub(5).Substring(0, arrSub(5).IndexOf(","))
        End If
        'trim whitespace
        For i = 0 To arrSub.Length - 1

            arrSub(i) = arrSub(i).Trim()

        Next
        If arrSub.Length < 6 Then
            Array.Resize(Of String)(arrSub, 6)
            For i = 0 To arrSub.Length - 1
                If IsNothing(arrSub(i)) Then
                    arrSub(i) = ""
                End If
            Next
        End If

        Return arrSub

    End Function

    Private Sub btnFormat_Click(sender As Object, e As EventArgs) Handles btnFormat.Click
        Dim strPhone As String = txtEnterPhone.Text
        txtFormatPhone.Text = FormatPhoneNumber(strPhone)
    End Sub
    Private Function FormatPhoneNumber(ByVal strPhone As String) As String
        Dim strFormatted As String
        If strPhone.Length <> 10 Then
            MessageBox.Show("Invalid entry")
            Return ""
        End If
        Try
            strFormatted = String.Format("({0}){1}-{2}", strPhone.Substring(0, 3), strPhone.Substring(3, 3), strPhone.Substring(6, 4))
        Catch ex As Exception
            strFormatted = "Invalid entry"
        End Try

        Return strFormatted

    End Function
    Private Sub txtEnterPhone_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEnterPhone.KeyPress

        'only accept number keystrokes and backspace keystroke
        If Not Char.IsNumber(e.KeyChar) And e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If

    End Sub

End Class
