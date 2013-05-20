Imports System.IO
Imports MySql.Data.MySqlClient

Public Class Form4
    Dim mycon
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim FileNema As New OpenFileDialog()
        FileNema.FileName = ""
        FileNema.Filter = "(*.txt)|*.txt"
        FileNema.ShowDialog()
        TextBox1.Text = FileNema.FileName
        'Opentxt()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Then
            Return
        End If
        If IO.File.Exists(TextBox1.Text) = False Then
            MsgBox("目标文件不存在")
            Return
        End If
        Dim sr() As String = File.ReadAllLines(TextBox1.Text) '这里面需要添加或者新的表单
        Dim Constr As String = "server=" & Form1.TextBox3.Text & ";User Id=" & Form1.TextBox4.Text & ";password=" & Form1.TextBox5.Text & ";Persist Security Info=True;database=" & Form1.TextBox7.Text & ";"
        mycon = New MySqlConnection(Constr)
        ' Dim Queq As String = "insert into resource_version (resource_name,version,Description) values ('" & Fname & "','1','1')"
        Dim i As Integer = 0
        Dim str() As String
        Dim sqlstr As String = ""
        For i = 0 To sr.Length - 1
            str = sr(i).Split("	") '分割下，0为名称，1为版本号
            If Chaxun(str(0)) = "True" Then
                sqlstr += "update resource_version set version='" & str(1) & "' " & "where  resource_name='" & str(0) & "'" & ";" & vbNewLine
            Else
                sqlstr += "insert into resource_version (resource_name,version,Description) values ('" & str(0) & "'," & str(1) & ",'" & "批量添加的" & "')" & ";" & vbNewLine
            End If
        Next
        Dim cmd As New MySqlCommand(sqlstr, mycon)
        mycon.Open()
        cmd.ExecuteNonQuery()
        mycon.close()
        MsgBox("导入成功")
    End Sub


    Function Chaxun(ByVal name_add As String)
        Dim myDate As MySqlDataReader
        Dim sql As String = "select * from resource_version where resource_name='" & name_add & "'"
        'MsgBox(sql)
        Dim cmd As New MySqlCommand(sql, mycon)
        mycon.open()
        myDate = cmd.ExecuteReader()
        Try
            Do While myDate.Read()
                mycon.Close()
                Return "True"
            Loop
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        mycon.Close()
        Return ""
    End Function
End Class