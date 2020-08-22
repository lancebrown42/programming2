''''
'''Lance Brown
'''Assignment 8
'''08/01/20
'''Program that pulls data from DB and allows user to update golfer info
'''
Option Strict On
Public Class frmMain
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnGolfer_Click(sender As Object, e As EventArgs) Handles btnGolfer.Click
        frmGolfer.ShowDialog()
    End Sub

    Private Sub btnEvent_Click(sender As Object, e As EventArgs) Handles btnEvent.Click
        frmEvents.ShowDialog()
    End Sub

    Private Sub btnGolferEvent_Click(sender As Object, e As EventArgs) Handles btnGolferEvent.Click
        frmAddGolferEvent.ShowDialog()
    End Sub

    Private Sub btnSponsors_Click(sender As Object, e As EventArgs) Handles btnSponsors.Click
        frmSponsors.ShowDialog()

    End Sub

    Private Sub btnGolferSponsor_Click(sender As Object, e As EventArgs) Handles btnGolferSponsor.Click
        frmAddGolferSponsor.ShowDialog()
    End Sub
End Class
