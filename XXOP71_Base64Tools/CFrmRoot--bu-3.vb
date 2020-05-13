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
            Dim tx = Me
            Debug.WriteLine(String.Format(">>> {0}", Me.ContainsFocus))

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

    Public Enum EKeyModfs As Integer
        None = 0
        Alt = 1
        Control = 2
        Shift = 4
        Windows = 8
    End Enum

    'Public Enum EWms As Integer
    '    HotKey = &H312
    'End Enum

    Private Const WM_HOTKEY As Integer = &H312

    Private Enum _Ehkids As Integer
        CtrlV = 695201
        CtrlC = 695202
        CtrlE = 695203
        CtrlD = 695204
        CtrlQ = 695205
    End Enum


    <DllImport(_pllpath_User32, EntryPoint:="RegisterHotKey", CharSet:=CharSet.Auto)> _
    Private Shared Function ppRegisterHotKey( _
        hWnd As IntPtr, id As Integer, fsModifiers As EKeyModfs, vk As Keys) As Integer
    End Function

    Protected Overrides Sub WndProc(ByRef tmsg As Message)
        'If (tmsg.Msg = WM_HOTKEY) Then
        '    'ppGetChange(tmsg)
        'End If
        MyBase.WndProc(tmsg)
    End Sub

    Private Sub ppGetChange(ByRef tmsg As Message)
        If (Me.WindowState = FormWindowState.Normal) AndAlso Me.ContainsFocus Then
            Dim twpv As Integer = tmsg.WParam.ToInt32()

            Select Case twpv
                Case _Ehkids.CtrlV
                    MsgBox("_Ehkids.CtrlV")

                    'pp_btn1_Click(Nothing, Nothing)

            End Select

            'If twp = _Ehkids.CtrlC Then
            '    MsgBox(">>> ")
            '    'Dim tx As Integer = tmsg.Msg Or Keys.A
            '    'MsgBox(String.Format("Hotkey가 눌려짐 {0}", tmsg.WParam.ToInt32()))
            '    'MsgBox(String.Format(">>> {0}, {1}", tmsg.Msg, CType(EWms.HotKey, Integer)))
            '    'MsgBox(String.Format(">>> {0}", tx))
            'End If
        End If
    End Sub

    Private Sub ppSubSetting()
        'ppRegisterHotKey(Me.Handle, _Ehkids.CtrlV, EKeyModfs.Control, Keys.V)
        'ppRegisterHotKey(Me.Handle, _Ehkids.CtrlC, EKeyModfs.Control, Keys.C)
        'ppRegisterHotKey(Me.Handle, _Ehkids.CtrlE, EKeyModfs.Control, Keys.E)
        'ppRegisterHotKey(Me.Handle, _Ehkids.CtrlD, EKeyModfs.Control, Keys.D)
        'ppRegisterHotKey(Me.Handle, _Ehkids.CtrlQ, EKeyModfs.Control, Keys.Q)
    End Sub

End Class
