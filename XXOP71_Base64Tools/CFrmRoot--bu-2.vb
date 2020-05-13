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
Imports System.Runtime.InteropServices





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
        ppSubSetting()
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




    Private Const _pllpath_User32 As String = "User32.dll"

    Public Enum EKeyModfs
        None = 0
        Alt = 1
        Control = 2
        Shift = 4
        Windows = 8
    End Enum


    <DllImport(_pllpath_User32, EntryPoint:="RegisterHotKey", CharSet:=CharSet.Auto)> _
    Private Shared Function ppRegisterHotKey( _
        hWnd As IntPtr, id As Integer, fsModifiers As EKeyModfs, vk As Keys) As Integer
    End Function

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If (m.Msg = CInt(&H312)) Then
            MsgBox("Hotkey가 눌려짐")
        End If
        MyBase.WndProc(m)
    End Sub


    Private Sub ppSubSetting()
        Const _HOTKEY_ID As Integer = 1122
        'ppRegisterHotKey(Me.Handle, _HOTKEY_ID, EKeyModifiers.Control Or EKeyModifiers.Shift, Keys.N)
        ppRegisterHotKey(Me.Handle, _HOTKEY_ID, EKeyModfs.Control, Keys.A)
    End Sub







    'Public Overrides Function PreProcessMessage(ByRef msg As System.Windows.Forms.Message) As Boolean
    '    Debug.WriteLine("~~~~")
    '    Return MyBase.PreProcessMessage(msg)
    'End Function


    'Private Const _WM_KEYDOWN As Integer = &H100
    'Private Const _WM_KEYUP As Integer = &H101
    'Private Const _WM_SYSKEYDOWN As Integer = &H104
    'Protected Overrides Sub WndProc(ByRef tmsg As Message)
    '    'Debug.WriteLine(">>> 1")
    '    'If (tmsg.Msg = _WM_SYSKEYDOWN) OrElse (tmsg.Msg = _WM_KEYDOWN) Then
    '    '    Debug.WriteLine(">>> ")
    '    'Else
    '    '    MyBase.WndProc(tmsg)
    '    'End If

    '    'Trace.WriteLine(String.Format(">>> {0}", tmsg.Msg))
    '    'If tmsg.Msg = _WM_KEYDOWN Then
    '    '    Trace.WriteLine(String.Format(">>> {0}", tmsg.Msg))
    '    'End If
    '    MyBase.WndProc(tmsg)
    'End Sub

    'Protected Overrides Sub OnKeyDown(tkea As System.Windows.Forms.KeyEventArgs)
    '    MyBase.OnKeyDown(tkea)
    'End Sub

    'Protected Overrides Sub OnPreviewKeyDown(tpkdea As PreviewKeyDownEventArgs)
    '    MyBase.OnPreviewKeyDown(tpkdea)
    'End Sub

    'Protected Overrides Function ProcessCmdKey(ByRef tmsg As Message, tkd As Keys) As Boolean
    '    'Trace.WriteLine(String.Format(">>> {0}", tmsg.Msg))

    '    'If (tkd = (Keys.Control Or Keys.V)) Then
    '    '    pp_btn4_Click(Nothing, Nothing)
    '    '    Return True
    '    'ElseIf (tkd = (Keys.Control Or Keys.C)) Then
    '    '    pp_btn5_Click(Nothing, Nothing)
    '    '    Return True
    '    'ElseIf (tkd = (Keys.Control Or Keys.E)) Then
    '    '    pp_btn1_Click(Nothing, Nothing)
    '    '    Return True
    '    'ElseIf (tkd = (Keys.Control Or Keys.D)) Then
    '    '    pp_btn2_Click(Nothing, Nothing)
    '    '    Return True
    '    'ElseIf (tkd = (Keys.Control Or Keys.Q)) Then
    '    '    pp_btn3_Click(Nothing, Nothing)
    '    '    Return True
    '    'End If
    '    'Return MyBase.ProcessCmdKey(tmsg, tkd)


    '    'Const _WM_KEYDOWN As Integer = &H100
    '    'Const _WM_KEYUP As Integer = &H101
    '    'Const _WM_SYSKEYDOWN As Integer = &H104
    '    'If (tmsg.Msg = _WM_KEYDOWN) OrElse (tmsg.Msg = _WM_SYSKEYDOWN) Then
    '    '    Trace.WriteLine(String.Format(">>>, {0}", tkd))
    '    'End If

    '    Return MyBase.ProcessCmdKey(tmsg, tkd)
    'End Function

End Class
