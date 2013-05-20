Public Class Form1
    Dim rand = New System.Random()
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim KU_D() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
        Dim KU_X() As String = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"}
        Dim KU_S() As String = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"}
        Dim Wei As Integer = 21
        Dim QianZui As String = "SSS"
        Dim Num = TextBox1.Text
        Dim zong As String = ""
        Dim zhong As String = ""
        Dim aaa = Now()
        ProgressBar1.Maximum = Num
        ProgressBar1.Value = 0
        For i = 0 To Num - 1
            zong = QianZui
            For z = 0 To Wei - 1
                Dim ret = rand.next(1, 3)
                If ret = 1 Then
                    zong += KU_D(rand.next(1, KU_D.Length - 1))
                ElseIf ret = 2 Then
                    zong += KU_X(rand.next(1, KU_X.Length - 1))
                ElseIf ret = 3 Then
                    zong += KU_S(rand.next(1, KU_S.Length - 1))
                End If
            Next
            System.IO.File.AppendAllText("config.txt", zong)
            ProgressBar1.Value += 1
        Next
        Dim bbb = Now()
        Dim ccc = bbb - aaa
        MsgBox(ccc.ToString)
    End Sub
End Class
