<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CFrmRoot
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기를 사용하여 수정하지 마십시오.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me._btn2 = New System.Windows.Forms.Button()
        Me._txb1 = New System.Windows.Forms.TextBox()
        Me._btn1 = New System.Windows.Forms.Button()
        Me._txb2 = New System.Windows.Forms.TextBox()
        Me._btn3 = New System.Windows.Forms.Button()
        Me._btn4 = New System.Windows.Forms.Button()
        Me._btn5 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        '_btn2
        '
        Me._btn2.Location = New System.Drawing.Point(559, 168)
        Me._btn2.Name = "_btn2"
        Me._btn2.Size = New System.Drawing.Size(189, 23)
        Me._btn2.TabIndex = 0
        Me._btn2.Text = "▼▼▼ Decoding (CTRL+D)"
        Me._btn2.UseVisualStyleBackColor = True
        '
        '_txb1
        '
        Me._txb1.Location = New System.Drawing.Point(12, 12)
        Me._txb1.Multiline = True
        Me._txb1.Name = "_txb1"
        Me._txb1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me._txb1.Size = New System.Drawing.Size(736, 150)
        Me._txb1.TabIndex = 1
        Me._txb1.WordWrap = False
        '
        '_btn1
        '
        Me._btn1.Location = New System.Drawing.Point(364, 168)
        Me._btn1.Name = "_btn1"
        Me._btn1.Size = New System.Drawing.Size(189, 23)
        Me._btn1.TabIndex = 2
        Me._btn1.Text = "▼▼▼ Encoding (CTRL+E)"
        Me._btn1.UseVisualStyleBackColor = True
        '
        '_txb2
        '
        Me._txb2.Location = New System.Drawing.Point(12, 197)
        Me._txb2.Multiline = True
        Me._txb2.Name = "_txb2"
        Me._txb2.ReadOnly = True
        Me._txb2.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me._txb2.Size = New System.Drawing.Size(736, 150)
        Me._txb2.TabIndex = 3
        Me._txb2.WordWrap = False
        '
        '_btn3
        '
        Me._btn3.Location = New System.Drawing.Point(628, 353)
        Me._btn3.Name = "_btn3"
        Me._btn3.Size = New System.Drawing.Size(120, 23)
        Me._btn3.TabIndex = 4
        Me._btn3.Text = "Clear (CTRL+Q)"
        Me._btn3.UseVisualStyleBackColor = True
        '
        '_btn4
        '
        Me._btn4.Location = New System.Drawing.Point(12, 168)
        Me._btn4.Name = "_btn4"
        Me._btn4.Size = New System.Drawing.Size(120, 23)
        Me._btn4.TabIndex = 5
        Me._btn4.Text = "Paste (CTRL+V)"
        Me._btn4.UseVisualStyleBackColor = True
        '
        '_btn5
        '
        Me._btn5.Location = New System.Drawing.Point(12, 353)
        Me._btn5.Name = "_btn5"
        Me._btn5.Size = New System.Drawing.Size(120, 23)
        Me._btn5.TabIndex = 6
        Me._btn5.Text = "Copy (CTRL+C)"
        Me._btn5.UseVisualStyleBackColor = True
        '
        'CFrmRoot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(760, 397)
        Me.Controls.Add(Me._btn5)
        Me.Controls.Add(Me._btn4)
        Me.Controls.Add(Me._btn3)
        Me.Controls.Add(Me._txb2)
        Me.Controls.Add(Me._btn1)
        Me.Controls.Add(Me._txb1)
        Me.Controls.Add(Me._btn2)
        Me.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "CFrmRoot"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents _btn2 As System.Windows.Forms.Button
    Friend WithEvents _txb1 As System.Windows.Forms.TextBox
    Friend WithEvents _btn1 As System.Windows.Forms.Button
    Friend WithEvents _txb2 As System.Windows.Forms.TextBox
    Friend WithEvents _btn3 As System.Windows.Forms.Button
    Friend WithEvents _btn4 As System.Windows.Forms.Button
    Friend WithEvents _btn5 As System.Windows.Forms.Button

End Class
