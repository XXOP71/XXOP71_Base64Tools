Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.Diagnostics
Imports System.Windows.Forms
Imports System.Linq
Imports System.Xml.Linq
Imports System.Text



Public NotInheritable Class CFrmRoot
    Public Sub New()
        InitializeComponent()
    End Sub


    Private Shared Sub ppResetWindowPosition(tfrm As Form)
        Dim tcs As Screen = Screen.FromPoint(Cursor.Position)
        Dim tsb As Rectangle = tcs.Bounds
        Dim tlp As Point = New Point(tsb.Right, tsb.Bottom)
        Dim tws As Size = tfrm.Size
        tlp.Offset(-(tws.Width + 40), -(tws.Height + 40))
        tfrm.Location = tlp
    End Sub


    Private Const _strVer As String = "v1.00"

    Protected Overrides Sub OnLoad(tea As EventArgs)
        MyBase.OnLoad(tea)

        Me.Text = String.Format("{0}  {1}", Me.GetType().Namespace, _strVer)
        ppResetWindowPosition(Me)
    End Sub




    ''' <summary>
    ''' Texts to encoding
    ''' </summary>
    ''' <param name="tsd"></param>
    ''' <param name="tea"></param>
    ''' <remarks></remarks>
    Private Sub pp_btn1_Click(tsd As Object, tea As EventArgs) Handles _btn1.Click
        Try
            Dim tstr As String = _txb1.Text
            If Not String.IsNullOrEmpty(tstr) Then
                'Dim tbts() As Byte = Encoding.Default.GetBytes(tstr)
                'Dim tbts() As Byte = Encoding.Unicode.GetBytes(tstr)
                Dim tbts() As Byte = Encoding.UTF8.GetBytes(tstr)
                Dim tos As String = Convert.ToBase64String(tbts, Base64FormattingOptions.None)
                _txb2.Text = tos

                'Dim txa = Encoding.Default
                'Dim txb = Encoding.Unicode
                'Dim txc = Encoding.UTF8
            End If
        Catch
        End Try
    End Sub


    ''' <summary>
    ''' Texts to decoding
    ''' </summary>
    ''' <param name="tsd"></param>
    ''' <param name="tea"></param>
    ''' <remarks></remarks>
    Private Sub pp_btn2_Click(tsd As Object, tea As EventArgs) Handles _btn2.Click
        Try
            Dim tstr As String = _txb1.Text
            If Not String.IsNullOrEmpty(tstr) Then
                Dim tbts() As Byte = Convert.FromBase64String(tstr)
                'Dim tos As String = Encoding.Default.GetString(tbts)
                'Dim tos As String = Encoding.Unicode.GetString(tbts)
                Dim tos As String = Encoding.UTF8.GetString(tbts)
                _txb2.Text = tos
            End If
        Catch
        End Try
    End Sub


    ''' <summary>
    ''' Forms Clear
    ''' </summary>
    ''' <param name="tsd"></param>
    ''' <param name="tea"></param>
    ''' <remarks></remarks>
    Private Sub pp_btn3_Click(tsd As Object, tea As EventArgs) Handles _btn3.Click
        Try
            _txb1.Clear()
            _txb2.Clear()
        Catch
        End Try
    End Sub


    ''' <summary>
    ''' Texts Paste
    ''' </summary>
    ''' <param name="tsd"></param>
    ''' <param name="tea"></param>
    ''' <remarks></remarks>
    Private Sub pp_btn4_Click(tsd As Object, tea As EventArgs) Handles _btn4.Click
        Try
            _txb1.Text = Clipboard.GetText()
        Catch
        End Try
    End Sub


    ''' <summary>
    ''' Texts Copy
    ''' </summary>
    ''' <param name="tsd"></param>
    ''' <param name="tea"></param>
    ''' <remarks></remarks>
    Private Sub pp_btn5_Click(tsd As Object, tea As EventArgs) Handles _btn5.Click
        Try
            Clipboard.SetText(_txb2.Text)
        Catch
        End Try
    End Sub



    Private Sub ppKeyDown(tsd As Object, tkea As KeyEventArgs) Handles MyBase.KeyDown
        If tkea.Control Then
            If tkea.KeyCode = Keys.V Then
                pp_btn4_Click(Nothing, Nothing)
            ElseIf tkea.KeyCode = Keys.C Then
                pp_btn5_Click(Nothing, Nothing)
            ElseIf tkea.KeyCode = Keys.E Then
                pp_btn1_Click(Nothing, Nothing)
            ElseIf tkea.KeyCode = Keys.D Then
                pp_btn2_Click(Nothing, Nothing)
            ElseIf tkea.KeyCode = Keys.Q Then
                pp_btn3_Click(Nothing, Nothing)
            End If
        End If
    End Sub

End Class
