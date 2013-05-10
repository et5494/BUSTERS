Public Class Form1
    Dim M_x(11) As Integer, M_y(11) As Integer, M_i As Integer, FFF As Graphics, Bi As New Pen(Color.Red, 3)


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        M_i = 1
        BianLi()
        'PictureBox6.BorderStyle = BorderStyle.FixedSingle
        FFF = PictureBox1.CreateGraphics
        FFF.DrawRectangle(Bi, 0, 0, 45, 45)
        Timer1.Start()


        'M_i = 1
        'While True
        '    If M_x(M_i) Then
        '        MsgBox("全部遍历完成")
        '        Exit While
        '    End If
        '    MsgBox(M_x(M_i))
        '    M_i = 1 + M_i
        'End While
    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'MsgBox("11111")
        ' FFF.Clear()
    End Sub

    Private Sub BianLi()
        For Each ct As Control In Me.Controls
            If TypeOf ct Is PictureBox Then
                M_x(M_i) = ct.Location.X
                M_y(M_i) = ct.Location.Y
                M_i = M_i + 1
            End If
        Next
    End Sub
End Class
