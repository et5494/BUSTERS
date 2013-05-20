Imports System.IO
Imports System.Reflection

Public Class Form1
    Dim verip = "\\172.16.0.114\read\策划\CB\Release\资源更新.exe"
    Dim verip_d = "\\172.16.0.114\public\策划\CB\Release\资源更新.exe"
    'Dim verip = "\\172.16.0.114\read\策划\CB\Release\资源更新.exe"
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Button1.Text = "开始更新" Then

            Try
                System.IO.File.Copy(verip, "资源更新.exe", True)
            Catch ex As Exception
                System.IO.File.Copy(verip_d, "资源更新.exe", True)
            End Try

            ProgressBar1.Value = 100
        ElseIf Button1.Text = "确定" Then
            Process.Start("资源更新.exe")
            Me.Close()
        End If
        reload()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim verstr As String = "\\172.16.0.114\read\策划\CB\VER\ver.txt"
        Dim verstr_W As String = "\\172.16.0.114\public\策划\CB\VER\ver.txt"
        Dim sr() As String
        Try
            sr = File.ReadAllLines(verstr)
        Catch ex As Exception
            sr = File.ReadAllLines(verstr_W)
        End Try
        Dim myAssemblyName As AssemblyName = AssemblyName.GetAssemblyName("资源更新.exe")
        Dim myAssemblyName_F As AssemblyName
        Try
            myAssemblyName_F = AssemblyName.GetAssemblyName("\\172.16.0.114\public\策划\CB\Release\资源更新.exe")
        Catch ex As Exception
            myAssemblyName_F = AssemblyName.GetAssemblyName("\\172.16.0.114\read\策划\CB\Release\资源更新.exe")
        End Try
        Dim Version_Major_F = myAssemblyName_F.Version.Major
        Dim Version_MajorRevision_F = myAssemblyName_F.Version.MajorRevision
        Dim Version_Minor_F = myAssemblyName_F.Version.Minor
        Dim Version_MinorRevision_F = myAssemblyName_F.Version.MinorRevision
        Dim Version_F = Version_Major_F & "." & Version_MajorRevision_F & "." & Version_Minor_F & "." & Version_MinorRevision_F
        Dim Version_Major = myAssemblyName.Version.Major
        Dim Version_MajorRevision = myAssemblyName.Version.MajorRevision
        Dim Version_Minor = myAssemblyName.Version.Minor
        Dim Version_MinorRevision = myAssemblyName.Version.MinorRevision
        Dim Version = Version_Major & "." & Version_MajorRevision & "." & Version_Minor & "." & Version_MinorRevision
        Label1.Text = "当前版本：" & Version
        Label2.Text = "服务器版本：" & Version_F
        If sr(0) > Version_MinorRevision Then
            Button1.Enabled = True
        End If
    End Sub

    Function reload()
        Button1.Enabled = False
        Dim verstr As String = "\\172.16.0.114\read\策划\CB\VER\ver.txt"
        Dim verstr_W As String = "\\172.16.0.114\public\策划\CB\VER\ver.txt"
        Dim sr() As String
        Try
            sr = File.ReadAllLines(verstr)
        Catch ex As Exception
            sr = File.ReadAllLines(verstr_W)
        End Try
        Dim myAssemblyName As AssemblyName = AssemblyName.GetAssemblyName("资源更新.exe")
        Dim myAssemblyName_F As AssemblyName
        Try
            myAssemblyName_F = AssemblyName.GetAssemblyName("\\172.16.0.114\public\策划\CB\Release\资源更新.exe")
        Catch ex As Exception
            myAssemblyName_F = AssemblyName.GetAssemblyName("\\172.16.0.114\read\策划\CB\Release\资源更新.exe")
        End Try
        Dim Version_Major_F = myAssemblyName_F.Version.Major
        Dim Version_MajorRevision_F = myAssemblyName_F.Version.MajorRevision
        Dim Version_Minor_F = myAssemblyName_F.Version.Minor
        Dim Version_MinorRevision_F = myAssemblyName_F.Version.MinorRevision
        Dim Version_F = Version_Major_F & "." & Version_MajorRevision_F & "." & Version_Minor_F & "." & Version_MinorRevision_F
        Dim Version_Major = myAssemblyName.Version.Major
        Dim Version_MajorRevision = myAssemblyName.Version.MajorRevision
        Dim Version_Minor = myAssemblyName.Version.Minor
        Dim Version_MinorRevision = myAssemblyName.Version.MinorRevision
        Dim Version = Version_Major & "." & Version_MajorRevision & "." & Version_Minor & "." & Version_MinorRevision
        Label1.Text = "当前版本：" & Version
        Label2.Text = "服务器版本：" & Version_F
        If sr(0) > Version_MinorRevision Then
            Button1.Enabled = True
        End If
        Button1.Text = "确定"
        Button1.Enabled = True
    End Function
End Class
