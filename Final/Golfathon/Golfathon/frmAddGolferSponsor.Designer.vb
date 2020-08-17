<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddGolferSponsor
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
        Me.btnDropSponsor = New System.Windows.Forms.Button()
        Me.btnAddSponsor = New System.Windows.Forms.Button()
        Me.lstAvailable = New System.Windows.Forms.ListBox()
        Me.lstInEvent = New System.Windows.Forms.ListBox()
        Me.cboEvents = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboGolfers = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(230, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 13)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Available Sponsors:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Event Sponsors:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Event:"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(145, 269)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(66, 32)
        Me.btnExit.TabIndex = 24
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnDropSponsor
        '
        Me.btnDropSponsor.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.btnDropSponsor.Location = New System.Drawing.Point(158, 194)
        Me.btnDropSponsor.Name = "btnDropSponsor"
        Me.btnDropSponsor.Size = New System.Drawing.Size(46, 38)
        Me.btnDropSponsor.TabIndex = 23
        Me.btnDropSponsor.Text = "→"
        Me.btnDropSponsor.UseVisualStyleBackColor = True
        '
        'btnAddSponsor
        '
        Me.btnAddSponsor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddSponsor.Location = New System.Drawing.Point(158, 138)
        Me.btnAddSponsor.Name = "btnAddSponsor"
        Me.btnAddSponsor.Size = New System.Drawing.Size(46, 35)
        Me.btnAddSponsor.TabIndex = 22
        Me.btnAddSponsor.Text = "←"
        Me.btnAddSponsor.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAddSponsor.UseVisualStyleBackColor = True
        '
        'lstAvailable
        '
        Me.lstAvailable.FormattingEnabled = True
        Me.lstAvailable.Location = New System.Drawing.Point(233, 123)
        Me.lstAvailable.Name = "lstAvailable"
        Me.lstAvailable.Size = New System.Drawing.Size(106, 121)
        Me.lstAvailable.TabIndex = 21
        '
        'lstInEvent
        '
        Me.lstInEvent.FormattingEnabled = True
        Me.lstInEvent.Location = New System.Drawing.Point(19, 123)
        Me.lstInEvent.Name = "lstInEvent"
        Me.lstInEvent.Size = New System.Drawing.Size(106, 121)
        Me.lstInEvent.TabIndex = 20
        '
        'cboEvents
        '
        Me.cboEvents.FormattingEnabled = True
        Me.cboEvents.Location = New System.Drawing.Point(19, 48)
        Me.cboEvents.Name = "cboEvents"
        Me.cboEvents.Size = New System.Drawing.Size(106, 21)
        Me.cboEvents.TabIndex = 19
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(251, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "Golfer:"
        '
        'cboGolfers
        '
        Me.cboGolfers.FormattingEnabled = True
        Me.cboGolfers.Location = New System.Drawing.Point(233, 48)
        Me.cboGolfers.Name = "cboGolfers"
        Me.cboGolfers.Size = New System.Drawing.Size(106, 21)
        Me.cboGolfers.TabIndex = 28
        '
        'frmAddGolferSponsor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(385, 353)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboGolfers)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnDropSponsor)
        Me.Controls.Add(Me.btnAddSponsor)
        Me.Controls.Add(Me.lstAvailable)
        Me.Controls.Add(Me.lstInEvent)
        Me.Controls.Add(Me.cboEvents)
        Me.Name = "frmAddGolferSponsor"
        Me.Text = "frmAddGolferSponsor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnExit As Button
    Friend WithEvents btnDropSponsor As Button
    Friend WithEvents btnAddSponsor As Button
    Friend WithEvents lstAvailable As ListBox
    Friend WithEvents lstInEvent As ListBox
    Friend WithEvents cboEvents As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cboGolfers As ComboBox
End Class
