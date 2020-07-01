<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.grpPin = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.btnVerify = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.grpPin.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpPin
        '
        Me.grpPin.Controls.Add(Me.TextBox7)
        Me.grpPin.Controls.Add(Me.TextBox6)
        Me.grpPin.Controls.Add(Me.TextBox5)
        Me.grpPin.Controls.Add(Me.TextBox4)
        Me.grpPin.Controls.Add(Me.TextBox3)
        Me.grpPin.Controls.Add(Me.TextBox2)
        Me.grpPin.Controls.Add(Me.TextBox1)
        Me.grpPin.Location = New System.Drawing.Point(31, 44)
        Me.grpPin.Name = "grpPin"
        Me.grpPin.Size = New System.Drawing.Size(290, 63)
        Me.grpPin.TabIndex = 0
        Me.grpPin.TabStop = False
        Me.grpPin.Text = "Enter The Pin"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(7, 20)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(33, 20)
        Me.TextBox1.TabIndex = 0
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(46, 20)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(33, 20)
        Me.TextBox2.TabIndex = 1
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(85, 20)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(33, 20)
        Me.TextBox3.TabIndex = 2
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(124, 20)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(33, 20)
        Me.TextBox4.TabIndex = 3
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(163, 20)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(33, 20)
        Me.TextBox5.TabIndex = 4
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(202, 20)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(33, 20)
        Me.TextBox6.TabIndex = 5
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(241, 20)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(33, 20)
        Me.TextBox7.TabIndex = 6
        '
        'btnVerify
        '
        Me.btnVerify.Location = New System.Drawing.Point(57, 132)
        Me.btnVerify.Name = "btnVerify"
        Me.btnVerify.Size = New System.Drawing.Size(75, 23)
        Me.btnVerify.TabIndex = 1
        Me.btnVerify.Text = "Verify"
        Me.btnVerify.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(139, 132)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 2
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(220, 132)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(363, 198)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnVerify)
        Me.Controls.Add(Me.grpPin)
        Me.Name = "frmMain"
        Me.Text = "Pin Verifier"
        Me.grpPin.ResumeLayout(False)
        Me.grpPin.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grpPin As GroupBox
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents btnVerify As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnClose As Button
End Class
