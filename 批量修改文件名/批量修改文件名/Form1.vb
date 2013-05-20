Imports System.IO

Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim splstr As String = TextBox2.Text '保存文件分割符号
        Dim mulv As String = TextBox1.Text   '保存目录
        Dim YJieGou As String = TextBox3.Text '保存文件名结构
        Dim MJieGou As String = TextBox6.Text '保存目标文件名结构
        Dim YID As String = TextBox4.Text     '保存源文件名起始
        Dim MID As String = TextBox5.Text     '保存目标文件名起始
        If IO.Directory.Exists(mulv) = False Then
            Debug("目标文件夹不存在")
            Exit Sub
        End If
        Dim WenJIan() As String = Directory.GetFiles(mulv)

    End Sub
    Function Debug(ByVal str As String)
        MsgBox(str)
    End Function
End Class
