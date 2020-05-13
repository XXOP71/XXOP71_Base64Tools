Imports System
Imports System.Windows.Forms

Public NotInheritable Class CTxbA : Inherits TextBox
    Protected Overrides Function ProcessCmdKey(ByRef tmsg As Message, tkd As Keys) As Boolean
        Return MyBase.ProcessCmdKey(tmsg, tkd)
    End Function

    Protected Overrides Sub OnPreviewKeyDown(tpkdea As PreviewKeyDownEventArgs)
        MyBase.OnPreviewKeyDown(tpkdea)
    End Sub
End Class
