Imports MySql.Data.MySqlClient

Public Class Form7
    Dim mycon
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    '刷新数据函数
    Function Updata()
        ' Dim dataAdapter As New SqlDataAdapter
        Dim dataAdapter As New MySqlDataAdapter
        Dim dst As New DataSet
        Dim dt As New DataTable
        mycon.Open()
        Dim sql As String = "select * from operational_records"
        Dim cmd As MySqlCommand = New MySqlCommand(sql, mycon)
        dataAdapter.SelectCommand = cmd
        Dim aaaa = dataAdapter.Fill(dst, "info")
        dt = dst.Tables("info")
        mycon.Close()   '关闭数据库  
        DataGridView1.AutoGenerateColumns = True '自动创建列  
        DataGridView1.DataSource = dt
        Return aaaa
    End Function

    Private Sub Form7_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Constr As String = "server=" & Form1.TextBox3.Text & ";User Id=" & Form1.TextBox4.Text & ";password=" & Form1.TextBox5.Text & ";Persist Security Info=True;database=" & Form1.TextBox7.Text & ";"
        'Dim Constr As String = "Data Source=" & TextBox3.Text & ";Initial Catalog=test;User ID=" & TextBox4.Text & ";Password=" & TextBox5.Text & ""
        'Dim Constr As String = "Data Source=192.168.0.52;Initial Catalog=test;User ID=sa;Password=cb5494"
        mycon = New MySqlConnection(Constr)
        Updata()
        Dim a() As String = Now().ToString.Split(" ")
        DateTimePicker1.Value = a(0)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim dataAdapter As New MySqlDataAdapter
        Dim dst As New DataSet
        Dim dt As New DataTable
        Dim time As String = DateTimePicker1.Value
        ' Dim times() As String = time.Split("/")
        Dim timeK As String = time & " 00:00"
        Dim timeJ As String = time & " 23:59"
        'select * from table where data >='2011-03-03 00:00' and data<='2011-03-03 23:59'
        Dim sql As String = "select * from operational_records where Time >='" & timeK & "' " & "and Time<='" & timeJ & "'"
        mycon.Open()
        Dim cmd As MySqlCommand = New MySqlCommand(sql, mycon)
        dataAdapter.SelectCommand = cmd
        dataAdapter.Fill(dst, "info")
        dt = dst.Tables("info")
        mycon.Close()   '关闭数据库  
        DataGridView1.AutoGenerateColumns = True '自动创建列  
        DataGridView1.DataSource = dt
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Updata()
    End Sub
End Class