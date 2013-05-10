Public Class Form6

   
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim aaa As String = "1"
        If TextBox1.Text = "1" Then
            Button2.Enabled = True
            TextBox2.Enabled = True
        Else
            MsgBox("密码错误")
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox2.Text = "" Then
            MsgBox("不能空")
            Exit Sub
        End If
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Form6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Button2.Enabled = False
        TextBox2.Enabled = False
        TextBox2.Text = ""
        TextBox1.Text = ""
    End Sub
End Class