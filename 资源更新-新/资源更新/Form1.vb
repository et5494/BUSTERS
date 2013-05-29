Imports System.Data
'Imports System.Data.SqlClient
'Imports System.Net.Mime.MediaTypeNames
Imports System.IO
Imports System.Xml
Imports System.Text.RegularExpressions
Imports System.Text
Imports MySql.Data.MySqlClient
Imports System.Reflection
Imports System.Security.Cryptography
Imports System.Drawing

Public Class Form1
    Dim mycon
    Dim QuanJu As String
    Private rname, miaos As Form2
    Dim SkinList As Array = {CB.My.Resources._4, CB.My.Resources.f95cbc45622848b2cefca3ca,
                             CB.My.Resources._4383834_203327048453_2, CB.My.Resources._20130528182727,
                             CB.My.Resources._1231}
    '连接
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'MsgBox(CheckBox1.CheckState.
        If TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Then
            MsgBox("请输入完整信息")
            Exit Sub
        End If
        If Button1.Text = "链接数据库" Then
            Dim Constr As String = "server=" & TextBox3.Text & ";User Id=" & TextBox4.Text & ";password=" & TextBox5.Text & ";Persist Security Info=True;database=" & TextBox7.Text & ";"
            'Dim Constr As String = "Data Source=" & TextBox3.Text & ";Initial Catalog=test;User ID=" & TextBox4.Text & ";Password=" & TextBox5.Text & ""
            'Dim Constr As String = "Data Source=192.168.0.52;Initial Catalog=test;User ID=sa;Password=cb5494"
            mycon = New MySqlConnection(Constr)
            Try
                mycon.Open()
                Button2.Enabled = True
                Button3.Enabled = True
                Button4.Enabled = True
                Button5.Enabled = True
                Button6.Enabled = True
                Button7.Enabled = True
                Button8.Enabled = True
                初始化ToolStripMenuItem.Enabled = True
                查看更新历史ToolStripMenuItem.Enabled = True
                更新所有项目ToolStripMenuItem.Enabled = True
                刷新数据ToolStripMenuItem.Enabled = True
                删除本条ToolStripMenuItem.Enabled = True
                'Button1.Enabled = False
                Label1.Text = "链接成功"
                Button1.Text = "断开链接"
                Label1.ForeColor = Color.Green
                TextBox3.Enabled = False
                TextBox4.Enabled = False
                TextBox5.Enabled = False
                导入数据ToolStripMenuItem.Enabled = True
                mycon.Close()
                Dim aaaa = "config.txt"
                If Not IO.File.Exists(aaaa) Then
                    If CheckBox1.CheckState.ToString = "Checked" Then
                        XML_Jianli()
                    End If
                End If
                Dim aaaaaa = Updata()
                MessageBox.Show("连接成功,总读取行数" & aaaaaa & "。")
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        ElseIf Button1.Text = "断开链接" Then
            Try
                mycon.Close()
            Catch ex As Exception
                MessageBox.Show("错误! ")
            End Try
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Enabled = False
            Button5.Enabled = False
            Button6.Enabled = False
            Button7.Enabled = False
            TextBox3.Enabled = True
            TextBox4.Enabled = True
            TextBox5.Enabled = True
            Button8.Enabled = False
            初始化ToolStripMenuItem.Enabled = False
            查看更新历史ToolStripMenuItem.Enabled = False
            更新所有项目ToolStripMenuItem.Enabled = False
            刷新数据ToolStripMenuItem.Enabled = False
            删除本条ToolStripMenuItem.Enabled = False
            Button1.Text = "链接数据库"
            Label1.Text = "请先链接数据库"
            Label1.ForeColor = Color.Red
        End If
    End Sub
    '查询
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim myDate As MySqlDataReader
        Dim Form2FH As DialogResult = Form3.ShowDialog()
        If Form2FH = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        Dim ChaXun As String = Form3.TextBox1.Text
        If ChaXun = "" Then
            MsgBox("错误，输入信息不完整")
            Exit Sub
        End If
        If ChaXun = TextBox1.Text Then
            MsgBox("错误，请不要查询已经查询的内容")
            Exit Sub
        End If
        Dim sql As String = "select * from resource_version where resource_name='" & ChaXun & "'"
        'MsgBox(sql)
        Dim cmd As New MySqlCommand(sql, mycon)
        mycon.Open()
        myDate = cmd.ExecuteReader()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox6.Text = ""
        Try
            Do While myDate.Read()
                TextBox1.Text = myDate(0)
                TextBox2.Text = myDate(1)
                If IsNothing(myDate(2)) Then
                    TextBox6.Text = ""
                Else
                    TextBox6.Text = myDate(2)
                End If
            Loop
            If TextBox1.Text = "" Then
                MsgBox("错误,配置表不存在！请添加！")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        mycon.Close()

    End Sub
    '添加新条目
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Form2.kankan(Me)
        Dim Form2FH As DialogResult = Form2.ShowDialog()
        If Form2FH = Windows.Forms.DialogResult.Cancel Then
            Return
        End If
        'MsgBox(Form2.TextBox1.Text)
        Dim Name As String = Form2.TextBox1.Text
        If Name = "" Then
            MsgBox("错误，输入信息不完整")
            Exit Sub
        End If
        Dim Errormsg As String = Chaxun(Name)
        If Errormsg = "True" Then
            MsgBox("所添加内容在数据库中已存在！")
            Exit Sub
        End If
        Dim Queq As String = "insert into resource_version (resource_name,version,Description) values ('" & Name & "'," & Form2.TextBox3.Text & ",'" & Form2.TextBox2.Text & "');" & vbNewLine
        Queq += "insert into operational_records (IP,Operating,Version,Directory,Time) values ('" & System.Net.Dns.GetHostName & "','" & "insert into" & "','" & "100001" & "','" & Name & "','" & Now().ToString & "')"
        'MsgBox(Queq)
        mycon.open()
        Dim OK = New MySqlCommand(Queq, mycon)
        OK.ExecuteNonQuery()
        TextBox1.Text = Name
        TextBox2.Text = "100001"
        TextBox6.Text = Form2.TextBox2.Text
        mycon.Close()
        Updata()
    End Sub
    '更新
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim myDate As MySqlDataReader
        Dim Fh As DialogResult = Form5.ShowDialog()
        If Fh <> Windows.Forms.DialogResult.OK Then
            Return
        End If
        If TextBox1.Text = "" Then
            MsgBox("错误，请先查询。")
            Exit Sub
        End If
        Dim a() As String = TextBox1.Text.Split(";")
        Dim name As String = ""
        For xx = 0 To a.Length - 2
            Dim ChaXun As String = Mid(a(xx), InStrRev(a(xx), "\") + 1)
            If ChaXun = "" Then
                MsgBox("错误，输入信息不完整")
                Exit Sub
            End If
            Dim sql As String = "select * from resource_version where resource_name='" & ChaXun & "'"
            'MsgBox(sql)
            Dim cmd As New MySqlCommand(sql, mycon)
            mycon.Open()
            myDate = cmd.ExecuteReader()
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox6.Text = ""
            Try
                Do While myDate.Read()
                    TextBox1.Text = myDate(0)
                    TextBox2.Text = myDate(1)
                    If IsNothing(myDate(2)) Then
                        TextBox6.Text = ""
                    Else
                        TextBox6.Text = myDate(2)
                    End If
                Loop
                mycon.Close()
                If TextBox1.Text = "" Then
                    Dim Queding = MsgBox("错误,配置表不存在！是否添加?", 1)
                    If Queding = 1 Then
                        Dim Fname As String
                        mycon.Open()
                        Fname = Mid(a(xx), InStrRev(a(xx), "\") + 1)
                        Dim Queq As String = ""
                        Queq = "insert into resource_version (resource_name,version,Description) values ('" & Fname & "','100001','1')" & ";" & vbNewLine
                        Queq += "insert into operational_records (IP,Operating,Version,Directory,Time) values ('" & System.Net.Dns.GetHostName & "','" & "insert into" & "','" & "100001" & "','" & Fname & "','" & Now().ToString & "')"
                        Dim OK = New MySqlCommand(Queq, mycon)
                        OK.ExecuteNonQuery()
                        mycon.Close()
                        TextBox1.Text = Fname
                        TextBox2.Text = "100001"
                        TextBox6.Text = "空！"
                        'mycon.Close()
                        'Updata()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                mycon.Close()
                Return
            End Try
            'Dim sqll As String = "select * from resource_version where resource_name='" & TextBox1.Text & "'"
            ' Dim cmd As New SqlCommand(sqll, mycon)
            'sql="update 数据表 set 字段1=值1,字段2=值2 …… 字段n=值n where 条件表达式"
            'Dim cmd As SqlCommand = New SqlClient.SqlCommand("update 表A set 部门='14' where 单据='1234567'")
            Dim msg As String = "是否确定更新" & TextBox1.Text & "!"
            Dim QueRen = MsgBox(msg, 1)
            If QueRen = 1 Then
                Dim Queq = CInt(TextBox2.Text) + 1
                mycon.open()
                Dim Sqlup As String = ""
                Sqlup = "update resource_version set version='" & Queq & "' " & "where  resource_name='" & TextBox1.Text & "'" & ";" & vbNewLine
                Sqlup += "insert into operational_records (IP,Operating,Version,Directory,Time) values ('" & System.Net.Dns.GetHostName & "','" & "update" & "','" & Queq & "','" & TextBox1.Text & "','" & Now().ToString & "')"
                Dim OK = New MySqlCommand(Sqlup, mycon)
                OK.ExecuteNonQuery()
                TextBox2.Text = Queq
                mycon.Close()
            End If
        Next
        Updata()
    End Sub
    '查询的东西是否存在
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
    '导出
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Updata()
        dataGridViewToExcel(DataGridView1)
        ' DcExcel(DataGridView1)
        Dim addones As String = "res_version.txt"
        If IO.File.Exists(addones) = False Then
            MsgBox("错误，源文件不存在")
            Exit Sub
        End If
        Shell("c:\windows\system32\cmd.exe /c net use \\172.16.32.100 ""  /user:""")
        Dim Mubiao As String = "\\172.16.32.100\pic\res_version.txt"
        System.IO.File.Copy(addones, Mubiao, True)
        File.Delete("res_version.txt")
        MsgBox("文件以上传至" & Mubiao)
    End Sub
    '刷新数据函数
    Function Updata()
        ' Dim dataAdapter As New SqlDataAdapter
        Dim dataAdapter As New MySqlDataAdapter
        Dim dst As New DataSet
        Dim dt As New DataTable
        mycon.Open()
        Dim sql As String = "select * from resource_version"
        Dim cmd As MySqlCommand = New MySqlCommand(sql, mycon)
        dataAdapter.SelectCommand = cmd
        Dim aaaa = dataAdapter.Fill(dst, "info")
        dt = dst.Tables("info")
        mycon.Close()   '关闭数据库  
        DataGridView1.AutoGenerateColumns = True '自动创建列  
        DataGridView1.DataSource = dt
        Return aaaa
    End Function
    '刷新数据
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Updata()
    End Sub
    '删除数据
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        ' sql="delete from 数据表 where 条件表达式
        If TextBox1.Text = "" Then
            MsgBox("错误，没有找到任何数据。")
            Exit Sub
        End If
        Dim msg As String = "是否确定删除" & TextBox1.Text & "!!!!!!!!!!!"
        Dim QueRen = MsgBox(msg, 1)
        If QueRen <> 1 Then
            MsgBox("结束过程")
            Exit Sub
        End If
        Try
            mycon.open()
            Dim Sqldel = "delete from resource_version where resource_name='" & TextBox1.Text & "'" & ";" & vbNewLine
            Sqldel += "insert into operational_records (IP,Operating,Version,Directory,Time) values ('" & System.Net.Dns.GetHostName & "','" & "delete" & "','" & TextBox2.Text & "','" & TextBox1.Text & "','" & Now().ToString & "')"
            Dim cmd As MySqlCommand = New MySqlCommand(Sqldel, mycon)
            cmd.ExecuteNonQuery()
            MsgBox("删除完成")
            mycon.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox6.Text = ""
        Updata()
    End Sub
    '导出函数
    Public Sub dataGridViewToExcel(ByVal dgv As DataGridView)
        'Dim saveFileDialog As New SaveFileDialog()
        'saveFileDialog.Filter = "Execl files (*.txt)|*.txt"
        'saveFileDialog.FilterIndex = 0
        'saveFileDialog.RestoreDirectory = True
        'saveFileDialog.CreatePrompt = True
        'saveFileDialog.Title = "导出 TXT 文件到"
        'saveFileDialog.ShowDialog()
        'If saveFileDialog.ShowDialog() = DialogResult.Cancel Then
        '    '如果选择提醒导出
        '    Return
        'End If
        'Dim myStream As Stream
        'myStream = saveFileDialog.OpenFile()
        'StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding("gb2312"));
        Dim addones As String = "res_version.txt"
        Dim sw As New StreamWriter(addones, False)
        Dim str As String = ""
        Try
            ''写标题 dgv.ColumnCount - 2为导出的标题数
            'For i As Integer = 0 To dgv.ColumnCount - 2
            '    If i > 0 Then
            '        str += vbTab
            '    End If
            '    str += dgv.Columns(i).HeaderText
            'Next
            'sw.WriteLine(str)
            '写内容 dgv.Rows.Count - 1 为导出的行数
            For j As Integer = 0 To dgv.Rows.Count - 1
                Dim tempStr As String = ""
                'dgv.Columns.Count - 2为导出的列数
                For k As Integer = 0 To dgv.Columns.Count - 2
                    If k > 0 Then
                        tempStr += vbTab
                    End If
                    tempStr += dgv.Rows(j).Cells(k).Value.ToString()
                Next
                sw.WriteLine(tempStr)
            Next
            sw.Close()
            'myStream.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        Finally
            sw.Close()
            'myStream.Close()
        End Try
    End Sub

    'CheckBox1.CheckState
    Public Function XML_Jianli()
        Dim s As String = TextBox3.Text & vbNewLine
        s += "test" & vbNewLine
        s += TextBox4.Text & vbNewLine
        s += TextBox5.Text & vbNewLine
        s += CheckBox1.CheckState.ToString & vbNewLine
        s += "\\172.16.32.100" & vbNewLine
        s += "D:\" & vbNewLine
        s += Form5.CheckBox1.CheckState.ToString & vbNewLine
        s += "   " & vbNewLine

        '& "</config>"
        Dim addones As String = "config.txt"
        System.IO.File.WriteAllText(addones, s)
        Return ""
    End Function

    Public Function XML_duqu()
        Dim st(99) As String
        Dim sr() As String = File.ReadAllLines("config.txt")
        TextBox3.Text = sr(0)
        TextBox4.Text = sr(2)
        TextBox5.Text = sr(3)
        Form5.TextBox2.Text = sr(5)

        If sr(4) = "Checked" Then
            CheckBox1.CheckState = CheckState.Checked
        ElseIf sr(4) = "Unchecked" Then
            CheckBox1.CheckState = CheckState.Unchecked
        End If
        Return ""
    End Function

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim str() As String = Genx()
        If str(0) = "False" Then
            Dim a As String = ""
            a += "检测到有新版本" & vbNewLine
            a += "更新内容：" & str(1) & vbNewLine
            MsgBox(a)
            System.IO.File.AppendAllText("patch.txt", a)
            Process.Start("更新.exe")
            Me.Close()
            Exit Sub
        End If
        verN()
        If My.Computer.FileSystem.FileExists("config.txt") = False Then
            Exit Sub
        End If
        XML_duqu()
        SkinLoad()
    End Sub

    Private Sub Form1_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        If CheckBox1.CheckState.ToString <> "Checked" Then
            'File.Delete("config.txt")
        End If
    End Sub

    Public NotInheritable Class Simple3Des
        Private TripleDes As New TripleDESCryptoServiceProvider
    End Class


    Private Function TruncateHash( _
    ByVal key As String, _
    ByVal length As Integer) _
    As Byte()
        Dim sha1 As New SHA1CryptoServiceProvider
        ' Hash the key.
        Dim keyBytes() As Byte = _
            System.Text.Encoding.Unicode.GetBytes(key)
        Dim hash() As Byte = sha1.ComputeHash(keyBytes)

        ' Truncate or pad the hash.
        ReDim Preserve hash(length - 1)
        Return hash
    End Function

    'Sub New(ByVal key As String)
    '     Initialize the crypto provider.
    '    TripleDES.Key = TruncateHash(key, TripleDES.KeySize \ 8)
    '    TripleDES.IV = TruncateHash("", TripleDES.BlockSize \ 8)
    'End Sub


    'Public Function EncryptData( _
    'ByVal plaintext As String) _
    'As String

    '     Convert the plaintext string to a byte array.
    '    Dim plaintextBytes() As Byte = _
    '        System.Text.Encoding.Unicode.GetBytes(plaintext)

    '     Create the stream.
    '    Dim ms As New System.IO.MemoryStream
    '     Create the encoder to write to the stream.
    '    Dim encStream As New CryptoStream(ms, _
    '        TripleDES.CreateEncryptor(), _
    '        System.Security.Cryptography.CryptoStreamMode.Write)

    '     Use the crypto stream to write the byte array to the stream.
    '    encStream.Write(plaintextBytes, 0, plaintextBytes.Length)
    '    encStream.FlushFinalBlock()

    '     Convert the encrypted stream to a printable string.
    '    Return Convert.ToBase64String(ms.ToArray)
    'End Function

    Private Sub 连接ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 连接ToolStripMenuItem.Click
        'MsgBox(CheckBox1.CheckState.
        If TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Then
            MsgBox("请输入完整信息")
            Exit Sub
        End If
        If Button1.Text = "链接数据库" Then
            Dim Constr As String = "server=" & TextBox3.Text & ";User Id=" & TextBox4.Text & ";password=" & TextBox5.Text & ";Persist Security Info=True;database=" & TextBox7.Text & ";"
            ' Dim Constr As String = "Data Source=" & TextBox3.Text & ";Initial Catalog=test;User ID=" & TextBox4.Text & ";Password=" & TextBox5.Text & ""
            'Dim Constr As String = "Data Source=192.168.0.52;Initial Catalog=test;User ID=sa;Password=cb5494"
            mycon = New MySqlConnection(Constr)
            Try
                mycon.Open()
                Button2.Enabled = True
                Button3.Enabled = True
                Button4.Enabled = True
                Button5.Enabled = True
                Button6.Enabled = True
                Button7.Enabled = True
                'Button1.Enabled = False
                Label1.Text = "链接成功"
                Button1.Text = "断开链接"
                Label1.ForeColor = Color.Green
                TextBox3.Enabled = False
                TextBox4.Enabled = False
                导入数据ToolStripMenuItem.Enabled = True
                TextBox5.Enabled = False
                mycon.Close()

                If CheckBox1.CheckState.ToString = "Checked" Then
                    XML_Jianli()
                End If

                Dim aaaaaa = Updata()
                MessageBox.Show("连接成功,总读取行数" & aaaaaa & "。")
            Catch ex As Exception
                MessageBox.Show("连接错误! ")
            End Try
        ElseIf Button1.Text = "断开链接" Then
            Try
                mycon.Close()
            Catch ex As Exception
                MessageBox.Show("错误! ")
            End Try
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Enabled = False
            Button5.Enabled = False
            Button6.Enabled = False
            Button7.Enabled = False
            TextBox3.Enabled = True
            TextBox4.Enabled = True
            TextBox5.Enabled = True
            Button1.Text = "链接数据库"
            Label1.Text = "请先链接数据库"
            Label1.ForeColor = Color.Red
        End If
    End Sub

    Private Sub 导入数据ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 导入数据ToolStripMenuItem.Click
        Form4.ShowDialog()

    End Sub

    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk

    End Sub


    Function Chaxun_1()
        Dim myDate As MySqlDataReader
        Dim Form2FH As DialogResult = Form3.ShowDialog()
        If Form2FH = Windows.Forms.DialogResult.Cancel Then
            Return ""
        End If
        Dim ChaXun As String = Form3.TextBox1.Text
        If ChaXun = "" Then
            MsgBox("错误，输入信息不完整")
            Return ""
        End If
        If ChaXun = TextBox1.Text Then
            MsgBox("错误，请不要查询已经查询的内容")
            Return ""
        End If
        Dim sql As String = "select * from resource_version where resource_name='" & ChaXun & "'"
        'MsgBox(sql)
        Dim cmd As New MySqlCommand(sql, mycon)
        mycon.Open()
        myDate = cmd.ExecuteReader()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox6.Text = ""
        Try
            Do While myDate.Read()
                TextBox1.Text = myDate(0)
                TextBox2.Text = myDate(1)
                If IsNothing(myDate(2)) Then
                    TextBox6.Text = ""
                Else
                    TextBox6.Text = myDate(2)
                End If
            Loop
            If TextBox1.Text = "" Then
                MsgBox("错误,配置表不存在！请添加！")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        mycon.Close()
        Return ""
    End Function


    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim myDate As MySqlDataReader
        If TextBox1.Text = "" Then
            MsgBox("错误，请先查询。")
            Exit Sub
        End If
        Dim ChaXun As String = TextBox1.Text
        If ChaXun = "" Then
            MsgBox("错误，输入信息不完整")
            Exit Sub
        End If
        Dim sql As String = "select * from resource_version where resource_name='" & ChaXun & "'"
        'MsgBox(sql)
        Dim cmd As New MySqlCommand(sql, mycon)
        mycon.Open()
        myDate = cmd.ExecuteReader()

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox6.Text = ""
        Try
            Do While myDate.Read()
                TextBox1.Text = myDate(0)
                TextBox2.Text = myDate(1)
                If IsNothing(myDate(2)) Then
                    TextBox6.Text = ""
                Else
                    TextBox6.Text = myDate(2)
                End If
            Loop
            mycon.Close()
            If TextBox1.Text = "" Then
                Dim Queding = MsgBox("错误,配置表不存在！是否添加?", 1)
                If Queding = 1 Then
                    Dim Fname As String
                    mycon.Open()
                    Fname = Mid(Form5.TextBox1.Text, InStrRev(Form5.TextBox1.Text, "\") + 1)
                    Dim Queq As String = "insert into resource_version (resource_name,version,Description) values ('" & Fname & "','1','1')"
                    Dim OK = New MySqlCommand(Queq, mycon)
                    OK.ExecuteNonQuery()
                    mycon.Close()
                    TextBox1.Text = Fname
                    TextBox2.Text = Form2.TextBox3.Text
                    TextBox6.Text = Form2.TextBox2.Text
                    'mycon.Close()
                    Updata()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            mycon.Close()
            Return
        End Try
        'Dim sqll As String = "select * from resource_version where resource_name='" & TextBox1.Text & "'"
        ' Dim cmd As New SqlCommand(sqll, mycon)
        'sql="update 数据表 set 字段1=值1,字段2=值2 …… 字段n=值n where 条件表达式"
        'Dim cmd As SqlCommand = New SqlClient.SqlCommand("update 表A set 部门='14' where 单据='1234567'")
        Dim msg As String = "是否确定更新" & TextBox1.Text & "!"
        Dim QueRen = MsgBox(msg, 1)
        If QueRen = 1 Then
            Dim Queq = CInt(TextBox2.Text) + 1
            mycon.open()
            '机器：IP ,操作：Operating,版本：Version,文件目录：Directory
            Dim Sqlup = "update resource_version set version='" & Queq & "' " & "where  resource_name='" & TextBox1.Text & "'" & ";" & vbNewLine
            Sqlup += "insert into operational_records (IP,Operating,Version,Directory,Time) values ('" & System.Net.Dns.GetHostName & "','" & "update" & "','" & Queq & "','" & TextBox1.Text & "','" & Now().ToString & "')"
            Dim OK = New MySqlCommand(Sqlup, mycon)
            OK.ExecuteNonQuery()
            TextBox2.Text = Queq
            mycon.Close()
            Updata()
        End If
    End Sub


    Private Sub TextBox7_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox7.MouseDown
        Dim Form2FH As DialogResult = Form6.ShowDialog()
        If Form2FH = Windows.Forms.DialogResult.Cancel Then
            TextBox7.Text = "cehua"
            TextBox3.TabIndex = 0
        ElseIf Form2FH = Windows.Forms.DialogResult.OK Then
            TextBox7.Text = Form6.TextBox2.Text
        End If
    End Sub
    '机器：IP ,操作：Operating,版本：Version,文件目录：Directory
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'MsgBox(System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName).AddressList(1).ToString)
        'Dim IPAdress = System.Net.Dns.GetHostName
        MsgBox(System.Net.Dns.GetHostName)
    End Sub

    Private Sub 查看更新历史ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查看更新历史ToolStripMenuItem.Click
        Form7.ShowDialog()
    End Sub


    Private Sub 更新所有项目ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 更新所有项目ToolStripMenuItem.Click
        Dim dataAdapter As New MySqlDataAdapter
        Dim dst As New DataSet
        Dim dt As New DataTable
        Dim myDate As MySqlDataReader
        mycon.Open()
        Dim sql As String = "select * from resource_version"
        Dim cmd As New MySqlCommand(sql, mycon)
        myDate = cmd.ExecuteReader()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox6.Text = ""
        Dim Sqlup As String = ""
        Do While myDate.Read()
            Dim a = myDate(0)
            Dim b = myDate(1)
            Dim c = myDate(2)
            Sqlup += "update resource_version set version='" & b + 1 & "' " & "where  resource_name='" & a & "'" & ";" & vbNewLine
        Loop
        Sqlup += "insert into operational_records (IP,Operating,Version,Directory,Time) values ('" & System.Net.Dns.GetHostName & "','" & "ALLupdate" & "','" & "all +1" & "','" & "all" & "','" & Now().ToString & "')" & vbNewLine
        mycon.Close()
        mycon.Open()
        Dim OK = New MySqlCommand(Sqlup, mycon)
        OK.ExecuteNonQuery()
        mycon.Close()
        Updata()
        MsgBox("所有版本号已经+1")
    End Sub

    Function Genx()
        Dim myAssemblyName As AssemblyName = AssemblyName.GetAssemblyName("资源更新.exe")
        Dim Version_Major = myAssemblyName.Version.Major
        Dim Version_MajorRevision = myAssemblyName.Version.MajorRevision
        Dim Version_Minor = myAssemblyName.Version.Minor
        Dim Version_MinorRevision = myAssemblyName.Version.MinorRevision
        Dim Version = Version_Major & "." & Version_MajorRevision & "." & Version_Minor & "." & Version_MinorRevision
        Dim aa() As String = {True, ""}
        Dim sr() As String
        Try
            sr = File.ReadAllLines("\\172.16.0.114\public\策划\CB\VER\VER.txt")
        Catch ex As Exception
            sr = File.ReadAllLines("\\172.16.0.114\read\策划\CB\VER\VER.txt")
        End Try
        aa(0) = sr(0) <= Version_MinorRevision
        aa(1) = sr(1)
        Return aa
    End Function

    Function verN()
        Dim myAssemblyName As AssemblyName = AssemblyName.GetAssemblyName("资源更新.exe")
        Dim Version_Major = myAssemblyName.Version.Major
        Dim Version_MajorRevision = myAssemblyName.Version.MajorRevision
        Dim Version_Minor = myAssemblyName.Version.Minor
        Dim Version_MinorRevision = myAssemblyName.Version.MinorRevision
        Dim Version = Version_Major & "." & Version_MajorRevision & "." & Version_Minor & "." & Version_MinorRevision
        Label9.Text = "ver:" & Version.ToString
        Return ""
    End Function

    Private Sub 删除本条ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 删除本条ToolStripMenuItem.Click
        ' sql="delete from 数据表 where 条件表达式
        If TextBox1.Text = "" Then
            MsgBox("错误，没有找到任何数据。")
            Exit Sub
        End If
        Dim msg As String = "是否确定删除" & TextBox1.Text & "!!!!!!!!!!!"
        Dim QueRen = MsgBox(msg, 1)
        If QueRen <> 1 Then
            MsgBox("结束过程")
            Exit Sub
        End If
        Try
            mycon.open()
            Dim Sqldel = "delete from resource_version where resource_name='" & TextBox1.Text & "'" & ";" & vbNewLine
            Sqldel += "insert into operational_records (IP,Operating,Version,Directory,Time) values ('" & System.Net.Dns.GetHostName & "','" & "delete" & "','" & TextBox2.Text & "','" & TextBox1.Text & "','" & Now().ToString & "')"
            Dim cmd As MySqlCommand = New MySqlCommand(Sqldel, mycon)
            cmd.ExecuteNonQuery()
            MsgBox("删除完成")
            mycon.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox6.Text = ""
        Updata()
    End Sub

    Private Sub 刷新数据ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 刷新数据ToolStripMenuItem.Click
        Updata()
    End Sub

    Private Sub 更换数据库ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 更换数据库ToolStripMenuItem.Click
        Dim Form2FH As DialogResult = Form6.ShowDialog()
        If Form2FH = Windows.Forms.DialogResult.Cancel Then
            TextBox7.Text = "cehua"
            TextBox3.TabIndex = 0
        ElseIf Form2FH = Windows.Forms.DialogResult.OK Then
            TextBox7.Text = Form6.TextBox2.Text
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        MenuStrip1.BackgroundImage = CB.My.Resources._4
        Panel1.BackgroundImage = CB.My.Resources._4
        SaveSkin("1")
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        'f95cbc45622848b2cefca3ca.jpg
        MenuStrip1.BackgroundImage = CB.My.Resources.f95cbc45622848b2cefca3ca
        Panel1.BackgroundImage = CB.My.Resources.f95cbc45622848b2cefca3ca
        SaveSkin("2")
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        MenuStrip1.BackgroundImage = CB.My.Resources._4383834_203327048453_2
        Panel1.BackgroundImage = CB.My.Resources._4383834_203327048453_2
        SaveSkin("3")
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        MenuStrip1.BackgroundImage = CB.My.Resources._20130528182727
        Panel1.BackgroundImage = CB.My.Resources._20130528182727
        SaveSkin("4")
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        MenuStrip1.BackgroundImage = CB.My.Resources._1231
        Panel1.BackgroundImage = CB.My.Resources._1231
        SaveSkin("5")
    End Sub

    Function SaveSkin(ByVal a As String)
        Dim skin As String = "skin.txt"
        System.IO.File.WriteAllText(skin, a)
        Return ""
    End Function


    Function SkinLoad()
        If Not IO.File.Exists("skin.txt") Then
            Return ""
        End If
        Dim Skin() As String = File.ReadAllLines("skin.txt")
        If Skin.Length > 1 Then
            If Not IO.File.Exists(Skin(0)) Then
                Dim msg As String = "文件" & Skin(0) & "不存在"
                Return ""
            End If
            MenuStrip1.BackgroundImage = Image.FromFile(Skin(0))
            Panel1.BackgroundImage = Image.FromFile(Skin(0))
            Return ""
        End If
        MenuStrip1.BackgroundImage = SkinList(Skin(0) - 1)
        Panel1.BackgroundImage = SkinList(Skin(0) - 1)
        Return ""
    End Function

    Private Sub 自定义ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 自定义ToolStripMenuItem.Click
        Dim Form2FH As DialogResult = Form11.ShowDialog()
        If Form2FH = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        Dim a As String = Form11.TextBox1.Text & vbNewLine
        a += "自定义"
        SaveSkin(a)
        Try
            MenuStrip1.BackgroundImage = Image.FromFile(Form11.TextBox1.Text)
            Panel1.BackgroundImage = Image.FromFile(Form11.TextBox1.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class