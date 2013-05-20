Public Class Form8

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
        For i = 0 To a.Length - 2

        Next
    End Sub
End Class