'''''
'''Lance Brown
'''7/1/20
'''Assignment 7
''''''
Option Strict On
Public Class frmMain
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnVerify_Click(sender As Object, e As EventArgs) Handles btnVerify.Click
        Reset()
        Dim intPin(7) As Integer
        Dim intMinimum() As Integer = {7, 0, 5, 0, 4, 3, 0}
        Dim intMaximum() As Integer = {9, 5, 9, 4, 8, 6, 3}
        For Each txtBox As TextBox In grpPin.Controls
            If String.IsNullOrEmpty(txtBox.Text) Or String.IsNullOrWhiteSpace(txtBox.Text) Then
                MessageBox.Show("Field cannot be empty", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Err(txtBox)
                Exit For
            End If
            Dim i As Integer = txtBox.TabIndex
            intPin(i) = CInt(txtBox.Text)
            If intPin(i) >= intMinimum(i) And intPin(i) <= intMaximum(i) Then
                Continue For
            Else
                MessageBox.Show("Value " & (i + 1).ToString & " does not fall between " & (intMinimum(i)).ToString & " and " & (intMaximum(i)).ToString, "Invalid Pin number", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Err(txtBox)
                Exit For
            End If

        Next

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        For Each ctrl As Control In grpPin.Controls
            ctrl.ResetText()
            ctrl.BackColor = Color.Empty
        Next

    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each ctrl As TextBox In grpPin.Controls
            ctrl.MaxLength = 1
            AddHandler(ctrl.KeyPress), AddressOf Text_Keyed
            AddHandler(ctrl.TextChanged), AddressOf Text_Changed
        Next
    End Sub
    Private Sub Text_Keyed(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim ctrl As TextBox = TryCast(sender, TextBox)
        If Not Char.IsNumber(e.KeyChar) And e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub
    Private Sub Text_Changed(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ctrl As TextBox = TryCast(sender, TextBox)
        If ctrl.TextLength = ctrl.MaxLength Then
            If TypeOf GetNextControl(ctrl, True) Is TextBox Then
                SelectNextControl(ctrl, True, True, True, False)
            End If

        End If
    End Sub
    Private Sub Err(ByRef ctrl As TextBox)
        ctrl.BackColor = Color.Yellow
        ctrl.Select()
    End Sub
    Private Sub Reset()
        For Each ctrl As TextBox In grpPin.Controls
            ctrl.BackColor = Color.Empty
        Next
    End Sub

End Class
