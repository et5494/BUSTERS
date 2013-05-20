Imports System.IO
Public Class Form1
    Dim mv As String
    Dim AllFile() As String
    Dim AllNum As Integer = 0
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim FileNema As New FolderBrowserDialog()
        FileNema.ShowNewFolderButton = True
        FileNema.SelectedPath = ""
        FileNema.ShowDialog()
        TextBox1.Text = FileNema.SelectedPath
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If IO.Directory.Exists(TextBox1.Text) = False Then
            MsgBox("错误，目标不存在")
            Exit Sub
        End If
        AllFile = Directory.GetFiles(TextBox1.Text, "*.*", SearchOption.AllDirectories)
        mv = TextBox1.Text
        Label3.Text = AllFile.Length
        Button2.Enabled = False
        Button3.Enabled = True
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Button3.Text = "开始监控" Then
            AllFile = Directory.GetFiles(mv, "*.*", SearchOption.AllDirectories)
            Timer1.Start()
            Button3.Text = "停止监控"
        ElseIf Button3.Text = "停止监控" Then
            Timer1.Stop()
            Button3.Text = "开始监控"
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim file() As String = Directory.GetFiles(mv, "*.*", SearchOption.AllDirectories)
        Label4.Text = file.Length
        For i = 0 To file.Length - 1
            If Array.IndexOf(AllFile, file(i)) = -1 Then
                'Timer1.Stop()
                GaiName(file(i))
            End If
        Next
        AllFile = Directory.GetFiles(mv, "*.*", SearchOption.AllDirectories)
        Label3.Text = AllFile.Length
    End Sub


    Function GaiName(ByVal filename As String)
        Dim oldname As String
        Dim newname As String
        oldname = filename
        Dim fil() As String = filename.Split(".")
        newname = fil(0) & "_ver_00001" & ".dat"
        Try
            If IO.File.Exists(newname) Then
                My.Computer.FileSystem.DeleteFile(newname)
            End If
            Rename(oldname, newname)
            AllNum += 1
            Label7.Text = AllNum
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return True
    End Function
End Class
