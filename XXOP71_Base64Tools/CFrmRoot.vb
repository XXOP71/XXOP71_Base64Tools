﻿Imports System
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
        'ppSubSetting()
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
            Clipboard.Clear()
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

    <DllImport(_pllpath_User32, EntryPoint:="UnregisterHotKey", CharSet:=CharSet.Auto)> _
    Private Shared Function ppUnregisterHotKey( _
        hWnd As IntPtr, id As Integer) As Integer
    End Function


    Protected Overrides Sub WndProc(ByRef tmsg As Message)
        If (tmsg.Msg = WM_HOTKEY) Then
            ppGetChange(tmsg)
        End If
        MyBase.WndProc(tmsg)
    End Sub

    Private Sub ppGetChange(ByRef tmsg As Message)
        If (Me.WindowState = FormWindowState.Normal) AndAlso Me.ContainsFocus Then
            Dim twpv As Integer = tmsg.WParam.ToInt32()

            Select Case twpv
                Case _Ehkids.CtrlV
                    'MsgBox("CtrlV")
                    pp_btn4_Click(Nothing, Nothing)

                Case _Ehkids.CtrlC
                    'MsgBox("CtrlC")
                    pp_btn5_Click(Nothing, Nothing)

                Case _Ehkids.CtrlE
                    'MsgBox("CtrlE")
                    pp_btn1_Click(Nothing, Nothing)

                Case _Ehkids.CtrlD
                    'MsgBox("CtrlD")
                    pp_btn2_Click(Nothing, Nothing)

                Case _Ehkids.CtrlQ
                    'MsgBox("CtrlQ")
                    pp_btn3_Click(Nothing, Nothing)

            End Select
        End If
    End Sub

    Protected Overrides Sub OnDeactivate(tea As EventArgs)
        ppSubSetting(False)
        MyBase.OnDeactivate(tea)
    End Sub

    Protected Overrides Sub OnActivated(tea As EventArgs)
        ppSubSetting(True)
        MyBase.OnActivated(tea)
    End Sub


    Private Sub ppSubSetting(tbx As Boolean)
        If tbx Then
            ppRegisterHotKey(Me.Handle, _Ehkids.CtrlV, EKeyModfs.Control, Keys.V)
            ppRegisterHotKey(Me.Handle, _Ehkids.CtrlC, EKeyModfs.Control, Keys.C)
            ppRegisterHotKey(Me.Handle, _Ehkids.CtrlE, EKeyModfs.Control, Keys.E)
            ppRegisterHotKey(Me.Handle, _Ehkids.CtrlD, EKeyModfs.Control, Keys.D)
            ppRegisterHotKey(Me.Handle, _Ehkids.CtrlQ, EKeyModfs.Control, Keys.Q)
        Else
            ppUnregisterHotKey(Me.Handle, _Ehkids.CtrlV)
            ppUnregisterHotKey(Me.Handle, _Ehkids.CtrlC)
            ppUnregisterHotKey(Me.Handle, _Ehkids.CtrlE)
            ppUnregisterHotKey(Me.Handle, _Ehkids.CtrlD)
            ppUnregisterHotKey(Me.Handle, _Ehkids.CtrlQ)
        End If
    End Sub

End Class
