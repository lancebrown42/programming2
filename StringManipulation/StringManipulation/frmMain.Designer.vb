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
        Me.grp1 = New System.Windows.Forms.GroupBox()
        Me.txtSentence = New System.Windows.Forms.TextBox()
        Me.btnVowels = New System.Windows.Forms.Button()
        Me.btnWords = New System.Windows.Forms.Button()
        Me.grp2 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRecord = New System.Windows.Forms.TextBox()
        Me.btnSplit = New System.Windows.Forms.Button()
        Me.txtF1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtF3 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtF5 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtF2 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtF4 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtF6 = New System.Windows.Forms.TextBox()
        Me.grp3 = New System.Windows.Forms.GroupBox()
        Me.txtEnterPhone = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtFormatPhone = New System.Windows.Forms.TextBox()
        Me.btnFormat = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.grp1.SuspendLayout()
        Me.grp2.SuspendLayout()
        Me.grp3.SuspendLayout()
        Me.SuspendLayout()
        '
        'grp1
        '
        Me.grp1.Controls.Add(Me.Label1)
        Me.grp1.Controls.Add(Me.btnWords)
        Me.grp1.Controls.Add(Me.btnVowels)
        Me.grp1.Controls.Add(Me.txtSentence)
        Me.grp1.Location = New System.Drawing.Point(67, 34)
        Me.grp1.Name = "grp1"
        Me.grp1.Size = New System.Drawing.Size(482, 103)
        Me.grp1.TabIndex = 0
        Me.grp1.TabStop = False
        Me.grp1.Text = "Step 1"
        '
        'txtSentence
        '
        Me.txtSentence.Location = New System.Drawing.Point(74, 19)
        Me.txtSentence.Name = "txtSentence"
        Me.txtSentence.Size = New System.Drawing.Size(402, 20)
        Me.txtSentence.TabIndex = 0
        '
        'btnVowels
        '
        Me.btnVowels.Location = New System.Drawing.Point(167, 67)
        Me.btnVowels.Name = "btnVowels"
        Me.btnVowels.Size = New System.Drawing.Size(89, 23)
        Me.btnVowels.TabIndex = 1
        Me.btnVowels.Text = "Count Vowels"
        Me.btnVowels.UseVisualStyleBackColor = True
        '
        'btnWords
        '
        Me.btnWords.Location = New System.Drawing.Point(308, 67)
        Me.btnWords.Name = "btnWords"
        Me.btnWords.Size = New System.Drawing.Size(87, 23)
        Me.btnWords.TabIndex = 2
        Me.btnWords.Text = "Count Words"
        Me.btnWords.UseVisualStyleBackColor = True
        '
        'grp2
        '
        Me.grp2.Controls.Add(Me.Label8)
        Me.grp2.Controls.Add(Me.txtF6)
        Me.grp2.Controls.Add(Me.Label7)
        Me.grp2.Controls.Add(Me.txtF4)
        Me.grp2.Controls.Add(Me.Label6)
        Me.grp2.Controls.Add(Me.txtF2)
        Me.grp2.Controls.Add(Me.Label5)
        Me.grp2.Controls.Add(Me.txtF5)
        Me.grp2.Controls.Add(Me.Label4)
        Me.grp2.Controls.Add(Me.txtF3)
        Me.grp2.Controls.Add(Me.Label3)
        Me.grp2.Controls.Add(Me.txtF1)
        Me.grp2.Controls.Add(Me.btnSplit)
        Me.grp2.Controls.Add(Me.Label2)
        Me.grp2.Controls.Add(Me.txtRecord)
        Me.grp2.Location = New System.Drawing.Point(67, 144)
        Me.grp2.Name = "grp2"
        Me.grp2.Size = New System.Drawing.Size(482, 208)
        Me.grp2.TabIndex = 1
        Me.grp2.TabStop = False
        Me.grp2.Text = "Step 2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Sentence: "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Record: "
        '
        'txtRecord
        '
        Me.txtRecord.Location = New System.Drawing.Point(74, 19)
        Me.txtRecord.Name = "txtRecord"
        Me.txtRecord.Size = New System.Drawing.Size(402, 20)
        Me.txtRecord.TabIndex = 4
        '
        'btnSplit
        '
        Me.btnSplit.Location = New System.Drawing.Point(167, 46)
        Me.btnSplit.Name = "btnSplit"
        Me.btnSplit.Size = New System.Drawing.Size(89, 23)
        Me.btnSplit.TabIndex = 6
        Me.btnSplit.Text = "Break Apart"
        Me.btnSplit.UseVisualStyleBackColor = True
        '
        'txtF1
        '
        Me.txtF1.Location = New System.Drawing.Point(74, 87)
        Me.txtF1.Name = "txtF1"
        Me.txtF1.Size = New System.Drawing.Size(100, 20)
        Me.txtF1.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(29, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Field 1"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(29, 116)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Field 3"
        '
        'txtF3
        '
        Me.txtF3.Location = New System.Drawing.Point(74, 113)
        Me.txtF3.Name = "txtF3"
        Me.txtF3.Size = New System.Drawing.Size(100, 20)
        Me.txtF3.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(29, 142)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Field 5"
        '
        'txtF5
        '
        Me.txtF5.Location = New System.Drawing.Point(74, 139)
        Me.txtF5.Name = "txtF5"
        Me.txtF5.Size = New System.Drawing.Size(100, 20)
        Me.txtF5.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(238, 90)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Field 2"
        '
        'txtF2
        '
        Me.txtF2.Location = New System.Drawing.Point(283, 87)
        Me.txtF2.Name = "txtF2"
        Me.txtF2.Size = New System.Drawing.Size(100, 20)
        Me.txtF2.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(238, 116)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Field 4"
        '
        'txtF4
        '
        Me.txtF4.Location = New System.Drawing.Point(283, 113)
        Me.txtF4.Name = "txtF4"
        Me.txtF4.Size = New System.Drawing.Size(100, 20)
        Me.txtF4.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(238, 142)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Field 6"
        '
        'txtF6
        '
        Me.txtF6.Location = New System.Drawing.Point(283, 139)
        Me.txtF6.Name = "txtF6"
        Me.txtF6.Size = New System.Drawing.Size(100, 20)
        Me.txtF6.TabIndex = 17
        '
        'grp3
        '
        Me.grp3.Controls.Add(Me.btnFormat)
        Me.grp3.Controls.Add(Me.Label10)
        Me.grp3.Controls.Add(Me.txtFormatPhone)
        Me.grp3.Controls.Add(Me.Label9)
        Me.grp3.Controls.Add(Me.txtEnterPhone)
        Me.grp3.Location = New System.Drawing.Point(67, 358)
        Me.grp3.Name = "grp3"
        Me.grp3.Size = New System.Drawing.Size(481, 163)
        Me.grp3.TabIndex = 2
        Me.grp3.TabStop = False
        Me.grp3.Text = "Step 3"
        '
        'txtEnterPhone
        '
        Me.txtEnterPhone.Location = New System.Drawing.Point(149, 41)
        Me.txtEnterPhone.Name = "txtEnterPhone"
        Me.txtEnterPhone.Size = New System.Drawing.Size(145, 20)
        Me.txtEnterPhone.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(37, 44)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(106, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Enter Phone Number"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(15, 70)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(128, 13)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Formatted Phone Number"
        '
        'txtFormatPhone
        '
        Me.txtFormatPhone.Location = New System.Drawing.Point(149, 67)
        Me.txtFormatPhone.Name = "txtFormatPhone"
        Me.txtFormatPhone.ReadOnly = True
        Me.txtFormatPhone.Size = New System.Drawing.Size(145, 20)
        Me.txtFormatPhone.TabIndex = 2
        '
        'btnFormat
        '
        Me.btnFormat.Location = New System.Drawing.Point(149, 108)
        Me.btnFormat.Name = "btnFormat"
        Me.btnFormat.Size = New System.Drawing.Size(145, 23)
        Me.btnFormat.TabIndex = 4
        Me.btnFormat.Text = "Format Phone Number"
        Me.btnFormat.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(166, 544)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 41)
        Me.btnClear.TabIndex = 3
        Me.btnClear.Text = "Clear Form"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(350, 544)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 41)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 611)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.grp3)
        Me.Controls.Add(Me.grp2)
        Me.Controls.Add(Me.grp1)
        Me.Name = "frmMain"
        Me.Text = "String Manipulation"
        Me.grp1.ResumeLayout(False)
        Me.grp1.PerformLayout()
        Me.grp2.ResumeLayout(False)
        Me.grp2.PerformLayout()
        Me.grp3.ResumeLayout(False)
        Me.grp3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grp1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnWords As Button
    Friend WithEvents btnVowels As Button
    Friend WithEvents txtSentence As TextBox
    Friend WithEvents grp2 As GroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtF6 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtF4 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtF2 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtF5 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtF3 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtF1 As TextBox
    Friend WithEvents btnSplit As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtRecord As TextBox
    Friend WithEvents btnFormat As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents txtFormatPhone As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtEnterPhone As TextBox
    Friend WithEvents btnClear As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents grp3 As GroupBox
End Class
