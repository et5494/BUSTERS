Imports System.IO

Public Class Form1

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim splstr As String = TextBox2.Text '保存文件分割符号
        Dim mulv As String = TextBox1.Text   '保存目录
        Dim YJieGou As String = TextBox3.Text '保存文件名结构
        Dim MJieGou As String = TextBox6.Text '保存目标文件名结构
        Dim YID As String = TextBox4.Text     '保存源文件名起始
        Dim MID As String = TextBox5.Text     '保存目标文件名起始
        Dim oldname As String
        Dim newname As String
        If IO.Directory.Exists(mulv) = False Then
            Debug("目标文件夹不存在")
            Exit Sub
        End If
        If TextBox7.Text = "" Then
            Debug("后缀名为空")
            Exit Sub
        End If
        If TextBox2.Text = "" Then
            Debug("分割符号为空")
            Exit Sub
        End If
        If TextBox4.Text = "" Or TextBox5.Text = "" Then
            Debug("有空")
            Exit Sub
        End If
        Dim WenJIan() As String = Directory.GetFiles(mulv)
        Dim WenYNum() As String = YID.Split("-")
        If WenYNum(0) = YID Then
            Debug("错误")
            Exit Sub
        End If
        Dim WenMNum() As String = MID.Split("-")
        If WenMNum(0) = MID Then
            Debug("错误")
            Exit Sub
        End If
        If (WenYNum(1) - WenYNum(0)) <> (WenMNum(1) - WenMNum(0)) Then
            Debug("文件名范围出错")
            Exit Sub
        End If
        Dim WenYJianJg() As String = YJieGou.Split(splstr)  'item_xxx
        If WenYJianJg(0) = YJieGou Then
            Debug("错误")
            Exit Sub
        End If
        Dim WenMJianJg() As String = MJieGou.Split(splstr)  'item_xxx
        If WenYJianJg(0) = "" Then
            Debug("源文件名为空")
            Exit Sub
        End If
        If WenYJianJg(0) = "" Then
            WenMJianJg(0) = WenYJianJg(0)
            WenMJianJg(1) = WenYJianJg(1)
        End If

        For i = CUInt(WenYNum(0)) To CUInt(WenYNum(1))
            If IO.File.Exists(TextBox1.Text & "\" & WenYJianJg(0) & splstr & i & "." & TextBox7.Text) = False Then
                Debug("错误，文件" & WenYJianJg(0) & splstr & i & "." & TextBox7.Text & "不存在")
                Exit Sub
            End If
            oldname = TextBox1.Text & "\" & WenYJianJg(0) & splstr & i & "." & TextBox7.Text
            newname = TextBox1.Text & "\" & WenMJianJg(0) & splstr & i + (WenMNum(0) - WenYNum(0)) & "." & TextBox7.Text
            Try
                Rename(oldname, newname)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        Next
        Debug("修改完成")
    End Sub
    Function Debug(ByVal str As String)
        MsgBox(str)
    End Function

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TextBox6.Text = TextBox3.Text
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = My.Computer.FileSystem.CurrentDirectory
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TextBox1.Text = TextBox1.Text
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim str() As String = Directory.GetFiles(TextBox1.Text, "*", SearchOption.AllDirectories)




    End Sub



    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim FileNema As New FolderBrowserDialog()
        FileNema.ShowNewFolderButton = True
        FileNema.SelectedPath = ""
        FileNema.ShowDialog()
        TextBox8.Text = FileNema.SelectedPath
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim mulv As String = TextBox8.Text
        If mulv = "" Then
            MsgBox("空")
            Exit Sub
        End If
        If TextBox9.Text = "" Then
            MsgBox("空")
            Exit Sub
        End If

        If IO.Directory.Exists(mulv) = False Then
            Debug("目标文件夹不存在")
            Exit Sub
        End If
        Dim WenJIan() As String = Directory.GetFiles(mulv, "*", SearchOption.AllDirectories)
        Dim FileNames As String
        Dim oldname As String
        Dim newname As String
        For i = 0 To WenJIan.Length - 1
            Dim Wenn() As String = WenJIan(i).Split("\")
            FileNames = Wenn(Wenn.Length - 1)
            Dim FileName = FileNames.Split(".")    '0为名字 1 为后缀
            oldname = WenJIan(i)
            newname = mulv & "\" & FileName(0) & TextBox9.Text & "." & FileName(1)
            Try
                Rename(oldname, newname)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Next
        MsgBox("完成")
    End Sub
    Dim fs As Process
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        fs = Process.Start("c:\1.txt")
        'Dim fs As New FileStream("c:\1.txt", FileMode.Append, FileAccess.Write, FileShare.Write)

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        fs.CloseMainWindow()
        fs.Close()
    End Sub
End Class
