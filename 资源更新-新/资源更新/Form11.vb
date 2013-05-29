Public Class Form11

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim FileNema As New OpenFileDialog()
        FileNema.FileName = ""
        FileNema.Filter = "jpg|*.jpg|png|*.png"
        FileNema.ShowDialog()
        TextBox1.Text = FileNema.FileName
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Dim imageList1 As ImageList = 
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Form11_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = ""
    End Sub
End Class