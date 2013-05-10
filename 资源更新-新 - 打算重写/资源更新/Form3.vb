
Imports MySql.Data.MySqlClient

Public Class Form3
    Dim mycon
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Form3_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        ' Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim Constr As String = "Data Source=" & Form1.TextBox3.Text & ";Initial Catalog=test;User ID=" & Form1.TextBox4.Text & ";Password=" & Form1.TextBox5.Text & ""
        Dim Constr As String = "server=" & Form1.TextBox3.Text & ";User Id=" & Form1.TextBox4.Text & ";password=" & Form1.TextBox5.Text & ";Persist Security Info=True;database=" & Form1.TextBox7.Text & ";"
        mycon = New MySqlConnection(Constr)
        mycon.open()
        Dim myDate As MySqlDataReader
        Dim sql As String = "select * from resource_version"
        Dim cmd As New MySqlCommand(sql, mycon)
        Dim Shuz = Updata()
        myDate = cmd.ExecuteReader()
        Dim Ku(Shuz - 1) As String
        Dim i As Integer = 0
        Try
            Do While myDate.Read()
                Ku(i) = myDate(0).ToString
                i += 1
            Loop
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        mycon.Close()
        Me.TextBox1.AutoCompleteCustomSource.AddRange(Ku)
        Me.TextBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TextBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        TextBox1.Text = ""
        TextBox1.TabIndex = 0
    End Sub


    '刷新数据函数
    Function Updata()
        ' Dim dataAdapter As New SqlDataAdapter
        Dim dataAdapter As New MySqlDataAdapter
        Dim dst As New DataSet
        Dim dt As New DataTable
        Dim sql As String = "select * from resource_version"
        Dim cmd As MySqlCommand = New MySqlCommand(sql, mycon)
        dataAdapter.SelectCommand = cmd
        Dim aaaa = dataAdapter.Fill(dst, "info")
        Return aaaa
    End Function
End Class