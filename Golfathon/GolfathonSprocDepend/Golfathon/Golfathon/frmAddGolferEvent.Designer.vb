<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddGolferEvent
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnDropGolfer = New System.Windows.Forms.Button()
        Me.btnAddGolfer = New System.Windows.Forms.Button()
        Me.lstAvailable = New System.Windows.Forms.ListBox()
        Me.lstInEvent = New System.Windows.Forms.ListBox()
        Me.cboEvents = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(255, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Available Golfers:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(41, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Event Golfers:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(62, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Event:"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(170, 263)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(66, 32)
        Me.btnExit.TabIndex = 15
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnDropGolfer
        '
        Me.btnDropGolfer.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.btnDropGolfer.Location = New System.Drawing.Point(183, 188)
        Me.btnDropGolfer.Name = "btnDropGolfer"
        Me.btnDropGolfer.Size = New System.Drawing.Size(46, 38)
        Me.btnDropGolfer.TabIndex = 14
        Me.btnDropGolfer.Text = "→"
        Me.btnDropGolfer.UseVisualStyleBackColor = True
        '
        'btnAddGolfer
        '
        Me.btnAddGolfer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddGolfer.Location = New System.Drawing.Point(183, 132)
        Me.btnAddGolfer.Name = "btnAddGolfer"
        Me.btnAddGolfer.Size = New System.Drawing.Size(46, 35)
        Me.btnAddGolfer.TabIndex = 13
        Me.btnAddGolfer.Text = "←"
        Me.btnAddGolfer.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAddGolfer.UseVisualStyleBackColor = True
        '
        'lstAvailable
        '
        Me.lstAvailable.FormattingEnabled = True
        Me.lstAvailable.Location = New System.Drawing.Point(258, 117)
        Me.lstAvailable.Name = "lstAvailable"
        Me.lstAvailable.Size = New System.Drawing.Size(106, 121)
        Me.lstAvailable.TabIndex = 12
        '
        'lstInEvent
        '
        Me.lstInEvent.FormattingEnabled = True
        Me.lstInEvent.Location = New System.Drawing.Point(44, 117)
        Me.lstInEvent.Name = "lstInEvent"
        Me.lstInEvent.Size = New System.Drawing.Size(106, 121)
        Me.lstInEvent.TabIndex = 11
        '
        'cboEvents
        '
        Me.cboEvents.FormattingEnabled = True
        Me.cboEvents.Location = New System.Drawing.Point(44, 42)
        Me.cboEvents.Name = "cboEvents"
        Me.cboEvents.Size = New System.Drawing.Size(106, 21)
        Me.cboEvents.TabIndex = 10
        '
        'frmAddGolferEvent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(419, 318)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnDropGolfer)
        Me.Controls.Add(Me.btnAddGolfer)
        Me.Controls.Add(Me.lstAvailable)
        Me.Controls.Add(Me.lstInEvent)
        Me.Controls.Add(Me.cboEvents)
        Me.Name = "frmAddGolferEvent"
        Me.Text = "frmAddGolferEvent"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnExit As Button
    Friend WithEvents btnDropGolfer As Button
    Friend WithEvents btnAddGolfer As Button
    Friend WithEvents lstAvailable As ListBox
    Friend WithEvents lstInEvent As ListBox
    Friend WithEvents cboEvents As ComboBox
End Class
