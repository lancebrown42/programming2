﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnGolfer = New System.Windows.Forms.Button()
        Me.btnEvent = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnGolferEvent = New System.Windows.Forms.Button()
        Me.btnSponsors = New System.Windows.Forms.Button()
        Me.btnGolferSponsor = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnGolfer
        '
        Me.btnGolfer.Location = New System.Drawing.Point(23, 13)
        Me.btnGolfer.Name = "btnGolfer"
        Me.btnGolfer.Size = New System.Drawing.Size(244, 145)
        Me.btnGolfer.TabIndex = 0
        Me.btnGolfer.Text = "Manage Golfers"
        Me.btnGolfer.UseVisualStyleBackColor = True
        '
        'btnEvent
        '
        Me.btnEvent.Location = New System.Drawing.Point(273, 13)
        Me.btnEvent.Name = "btnEvent"
        Me.btnEvent.Size = New System.Drawing.Size(244, 145)
        Me.btnEvent.TabIndex = 1
        Me.btnEvent.Text = "Manage Events"
        Me.btnEvent.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(346, 353)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnGolferEvent
        '
        Me.btnGolferEvent.Location = New System.Drawing.Point(523, 13)
        Me.btnGolferEvent.Name = "btnGolferEvent"
        Me.btnGolferEvent.Size = New System.Drawing.Size(244, 145)
        Me.btnGolferEvent.TabIndex = 3
        Me.btnGolferEvent.Text = "Manage Golfers/Events"
        Me.btnGolferEvent.UseVisualStyleBackColor = True
        '
        'btnSponsors
        '
        Me.btnSponsors.Location = New System.Drawing.Point(23, 168)
        Me.btnSponsors.Name = "btnSponsors"
        Me.btnSponsors.Size = New System.Drawing.Size(244, 145)
        Me.btnSponsors.TabIndex = 4
        Me.btnSponsors.Text = "Manage Sponsors"
        Me.btnSponsors.UseVisualStyleBackColor = True
        '
        'btnGolferSponsor
        '
        Me.btnGolferSponsor.Location = New System.Drawing.Point(523, 168)
        Me.btnGolferSponsor.Name = "btnGolferSponsor"
        Me.btnGolferSponsor.Size = New System.Drawing.Size(244, 145)
        Me.btnGolferSponsor.TabIndex = 5
        Me.btnGolferSponsor.Text = "Manage Golfers/Sponsors"
        Me.btnGolferSponsor.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnGolferSponsor)
        Me.Controls.Add(Me.btnSponsors)
        Me.Controls.Add(Me.btnGolferEvent)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnEvent)
        Me.Controls.Add(Me.btnGolfer)
        Me.Name = "frmMain"
        Me.Text = "Golfathon"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnGolfer As Button
    Friend WithEvents btnEvent As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents btnGolferEvent As Button
    Friend WithEvents btnSponsors As Button
    Friend WithEvents btnGolferSponsor As Button
End Class
