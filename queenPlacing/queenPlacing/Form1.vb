Public Class Form1
    Dim flag As Boolean = False
    Dim b() As Integer = {-1, -1, -1, -1}
    Dim counter As Integer = 0


    Private Sub setcolor(ByVal sender As System.Object)
        If Val(sender.tag.ToString.Substring(0, 1)) Mod 2 = 0 And Val(sender.tag.ToString.Substring(2, 1)) Mod 2 = 0 Or Val(sender.tag.ToString.Substring(0, 1)) Mod 2 = 1 And Val(sender.tag.ToString.Substring(2, 1)) Mod 2 = 1 Then
            sender.backcolor = Color.Black
        Else
            sender.backcolor = Color.White
        End If
    End Sub
    Private Sub getsolution()
        Dim s As String = ""
        For i As Integer = 0 To 3
            If b(i) = -1 Or flag = False Then Exit Sub
            s += b(i).ToString
        Next
        If MsgBox("Do you want to get other solution", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            b(0) = -1
            b(1) = -1
            b(2) = -1
            b(3) = -1
            counter = 0
            lbl00.Text = ""
            lbl01.Text = ""
            lbl02.Text = ""
            lbl03.Text = ""
            lbl10.Text = ""
            lbl11.Text = ""
            lbl12.Text = ""
            lbl13.Text = ""
            lbl20.Text = ""
            lbl21.Text = ""
            lbl22.Text = ""
            lbl23.Text = ""
            lbl30.Text = ""
            lbl31.Text = ""
            lbl32.Text = ""
            lbl33.Text = ""
            display.Text += s + vbNewLine
        End If
    End Sub
    Private Sub lbl00_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl00.Click, lbl10.Click, lbl20.Click, lbl30.Click, lbl01.Click, lbl02.Click, lbl03.Click, lbl11.Click, lbl12.Click, lbl13.Click, lbl21.Click, lbl22.Click, lbl23.Click, lbl31.Click, lbl32.Click, lbl33.Click, Label2.Click, Label1.Click
        If sender.text = "Q" Then
            sender.text = ""
            b(sender.tag.ToString.Substring(0, 1)) = -1
            counter -= 1
            flag = True
            If sender.BackColor = Color.Red Then
                setcolor(sender)
            End If
        Else
            If b(sender.tag.ToString.Substring(0, 1)) = -1 Then
                sender.text = "Q"
                b(sender.tag.ToString.Substring(0, 1)) = sender.tag.ToString.Substring(2, 1)
                If counter > 0 Then issafe(counter, sender)
                counter += 1
                getsolution()
            End If
        End If
    End Sub
    Private Sub issafe(ByVal c As Integer, ByVal s As System.Object)
        Dim x As Integer = b(c)
        For i As Integer = 1 To c
            Dim t As Integer = b(c - i)
            If t = x Or t = x + i Or t = x - i Then
                s.BackColor = Color.Red
                flag = False
                ' If MsgBox("Do you want replace", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then setcolor(s)
            End If
        Next
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
