Imports System.IO
Imports MySql.Data.MySqlClient
Imports System.Windows.Forms

Public Class Form5
    Dim WenM() As String
    Dim BF As String
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim FileNema As New OpenFileDialog()
        FileNema.FileName = ""
        FileNema.Filter = "(*.*)|*.*"
        FileNema.Multiselect = True
        FileNema.ShowDialog()
        WenM = FileNema.FileNames
        Dim a As String = ""
        For i = 0 To WenM.Length - 1
            a += WenM(i) & ";"
        Next
        TextBox1.Text = a
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Dim a() As String = TextBox1.Text.Split(";")
        Dim bbb() As String
        Label4.Text = "选择文件数量：" & (a.Length - 1)
        Label4.Visible = True
        If a.Length >= 3 Then
            TextBox3.Text = "直接点击提交！" '
            Exit Sub
        End If
        For i = 0 To a.Length - 2
            Dim Fname = Mid(a(i), InStrRev(a(i), "\") + 1)
            Dim b() As String = Directory.GetFiles("\\172.16.32.100\pic", Fname, SearchOption.AllDirectories)
            If b.Length = 0 Then
                b = Directory.GetFiles("\\172.16.32.100\data", Fname, SearchOption.AllDirectories)
            End If
            If b.Length <> 0 Then
                bbb = b(0).Split("\")
                Dim str As String = ""
                For z = 3 To bbb.Length - 2
                    If z = bbb.Length - 2 Then
                        str += bbb(z)
                    Else
                        str += bbb(z) & "\"
                    End If
                Next
                TextBox3.Text = str
            End If
        Next
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim a() As String = TextBox1.Text.Split(";")
        Dim name As String = ""
        Dim num As Integer = 0
        Dim names As String = ""
        Button3.Enabled = False
        ProgressBar1.Maximum = a.Length - 1
        ProgressBar1.Visible = True
        ProgressBar1.Value = 0
        Label3.Visible = True
        For xx = 0 To a.Length - 2
            name = a(xx)
            Dim Fname As String
            Fname = Mid(a(xx), InStrRev(a(xx), "\") + 1)
            If IO.File.Exists(name) = False Then
                MsgBox("错误，源文件不存在")
                Exit Sub
            End If
            Dim MuBiao_d As String = DedaoMUbiao(Fname)
            If IO.Directory.Exists(TextBox2.Text & "\" & MuBiao_d) = False Then
                If TextBox3.Text = "直接点击提交！" Or TextBox3.Text = "" Then
                    MsgBox("错误，文件" & Fname & "不存在，请单独上传！")
                    Exit Sub
                End If
                MuBiao_d = TextBox3.Text
                If IO.Directory.Exists(TextBox2.Text & "\" & MuBiao_d) = False Then
                    MsgBox("错误，目标不存在")
                    Exit Sub
                End If
            End If
            'TextBox2.Text 这里的内容由form1_load加载
            If IO.Directory.Exists(TextBox2.Text & "\" & MuBiao_d) = False Then
                Directory.CreateDirectory(TextBox2.Text & "\" & MuBiao_d)
            End If
            Dim Mubiao As String = TextBox2.Text & "\" & MuBiao_d & "\" & Fname
            ' Shell("c:\windows\system32\cmd.exe /c net use \\172.16.32.110 ""  /user:""")
            If IO.File.Exists(Mubiao) Then
                If Not IO.Directory.Exists(BF & MuBiao_d) Then
                    Directory.CreateDirectory(BF & MuBiao_d)
                End If
                Dim FnameF() As String = Fname.Split(".")
                If Not Chaxun(Fname) Then
                    ver = "100001"
                End If
                Dim Fnamesss As String = FnameF(0) & "_" & ver & "." & FnameF(1)
                System.IO.File.Copy(Mubiao, BF & MuBiao_d & "\" & Fnamesss, True)
            End If
            Try
                System.IO.File.Copy(name, Mubiao, True)
                num += 1
                names += Mubiao & vbNewLine
                ProgressBar1.Value += 1
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Next
        Dim msg As String = "以成功上传文件个数:" & num & vbNewLine
        msg += names
        MsgBox(msg)
        Form1.TextBox1.Text = TextBox1.Text
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = ""
        TextBox3.Text = ""
        Button3.Enabled = True
        ProgressBar1.Visible = False
        Label3.Visible = False
        Label4.Visible = False
        'XML_duqu()
        My.Computer.FileSystem.CurrentDirectory = Application.StartupPath
        Dim files() As String = System.IO.Directory.GetDirectories("\\172.16.32.100\pic", "*", SearchOption.AllDirectories)
        '\\172.16.32.100\pic  \\172.16.32.100\data
        Dim files_d() As String = System.IO.Directory.GetDirectories("\\172.16.32.100\data", "*", SearchOption.AllDirectories)
        Dim str((files.Length - 1) + files_d.Length) As String
        For i = 0 To files.Length - 1
            Dim zstr() As String = files(i).Split("pic\")
            str(i) = "pic\" & zstr(1).Substring(3)
        Next
        For i = files.Length To (files.Length - 1) + files_d.Length
            Dim zzstr() As String = files_d(i - files.Length).Split("data\")
            str(i) = "data\" & zzstr(1).Substring(4)
        Next
        Me.TextBox3.AutoCompleteCustomSource.AddRange(str)
        Me.TextBox3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TextBox3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Try
            If Not IO.Directory.Exists("config.txt") Then
                'MsgBox("错误，目标不存在")
                Dim sr() As String = File.ReadAllLines("config.txt")
                BF = sr(6)
            Else
                BF = "D:\"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Dim mycon
    Dim ver
    '查询的东西是否存在
    Function Chaxun(ByVal name_add As String)
        Dim myDate As MySqlDataReader
        Dim Constr As String = "server=" & Form1.TextBox3.Text & ";User Id=" & Form1.TextBox4.Text & ";password=" & Form1.TextBox5.Text & ";Persist Security Info=True;database=" & Form1.TextBox7.Text & ";"
        mycon = New MySqlConnection(Constr)
        Dim sql As String = "select * from resource_version where resource_name='" & name_add & "'"
        'MsgBox(sql)
        Dim cmd As New MySqlCommand(sql, mycon)
        mycon.open()
        myDate = cmd.ExecuteReader()
        Try
            Do While myDate.Read()
                ver = myDate(1)
                mycon.Close()
                Return True
            Loop
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        mycon.Close()
        Return False
    End Function


    Public Function XML_duqu()
        My.Computer.FileSystem.CurrentDirectory = Application.StartupPath
        Dim st(99) As String
        Dim sr() As String = File.ReadAllLines("config.txt")
        Try
            If sr(7) = "Checked" Then
                CheckBox1.CheckState = CheckState.Checked
                TextBox3.Text = sr(8)
            ElseIf sr(7) = "Unchecked" Then
                CheckBox1.CheckState = CheckState.Unchecked
            End If
        Catch ex As Exception
        End Try
        Return ""
    End Function

    Private Sub Form5_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        My.Computer.FileSystem.CurrentDirectory = Application.StartupPath
        Dim strr As String = ""
        Dim sr() As String = File.ReadAllLines("config.txt")
        If sr.Length = 9 Then
            If CheckBox1.CheckState = CheckState.Checked Then
                sr(7) = "Checked"
                sr(8) = TextBox3.Text
            Else
                sr(7) = "Unchecked"
            End If
        End If
        If sr.Length = 9 Then
            For i = 0 To 8
                strr += sr(i) & vbNewLine
            Next
            Dim addones As String = "config.txt"
            System.IO.File.WriteAllText(addones, strr)
        End If
    End Sub

    Function GetAllFiles()
        Dim Files_pic() As String = Directory.GetFiles("\\172.16.32.100\pic", "*", SearchOption.AllDirectories)
        Dim Files_data() As String = Directory.GetFiles("\\172.16.32.100\data", "*", SearchOption.AllDirectories)
        Dim AllFiles(Files_pic.Length - 1 + Files_data.Length) As String
        Dim zhong1() As String
        Dim zhong2() As String
        For i = 0 To Files_pic.Length - 1
            zhong1 = Files_pic(i).Split("\")
            Dim str As String = ""
            For z = 3 To zhong1.Length - 1
                If z = zhong1.Length - 1 Then
                    str += zhong1(z)
                Else
                    str += zhong1(z) & "\"
                End If
            Next
            AllFiles(i) = Files_pic(i)
        Next
        For i = Files_pic.Length To Files_pic.Length - 1 + Files_data.Length
            zhong2 = Files_pic(i - Files_pic.Length).Split("\")

            AllFiles(i) = Files_pic(i - Files_pic.Length)
        Next
        Return AllFiles
    End Function

    Function DedaoMUbiao(ByVal filenames As String)
        Dim str As String = ""
        Dim b() As String = Directory.GetFiles("\\172.16.32.100\pic", filenames, SearchOption.AllDirectories)
        If b.Length = 0 Then
            b = Directory.GetFiles("\\172.16.32.100\data", filenames, SearchOption.AllDirectories)
        End If
        Dim bbb() As String
        If b.Length <> 0 Then
            bbb = b(0).Split("\")
            For z = 3 To bbb.Length - 2
                If z = bbb.Length - 2 Then
                    str += bbb(z)
                Else
                    str += bbb(z) & "\"
                End If
            Next
        End If
        Return str
    End Function
End Class