Public Class Form2
    Private boxsize As Integer
    Dim box(10, 10), lbl1(10) As Label
    Public listbox1 As ListBox
    Dim setqueen() As Integer = {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1}
    Dim counter As Integer
    Dim flag As Boolean = False
    Dim b As Button
    Private Sub setbox()
        For i As Integer = 0 To boxsize - 1
            For j As Integer = 0 To boxsize - 1
                box(i, j).Text = ""
            Next
            setqueen(i) = -1
        Next
        flag = False
        counter = 0
    End Sub
    Private Sub createboard(ByVal size As Integer)
        Me.Controls.Clear()
        flag = False
        boxsize = size
        counter = 0
        Me.BackColor = Color.White
        Dim x, y As Integer
        x = 100
        y = 10
        For k As Integer = 0 To boxsize - 1
            lbl1(k) = New Label
            lbl1(k).Name = "lbl" + k.ToString
            lbl1(k).Text = k.ToString
            lbl1(k).Font = New Font("", 30, FontStyle.Bold)
            lbl1(k).SetBounds(x, y, 50, 50)
            Me.Controls.Add(lbl1(k))
            x += 60
        Next
        x = 100
        y = 60
        For i As Integer = 0 To boxsize - 1
            If boxsize Mod 2 = 0 Then flag = Not flag
            For j As Integer = 0 To boxsize - 1
                box(i, j) = New Label()
                box(i, j).Name = "lbl" + i.ToString + j.ToString
                box(i, j).Text = ""
                box(i, j).SetBounds(x, y, 50, 50)
                box(i, j).Enabled = False
                box(i, j).Visible = True
                box(i, j).Tag = i.ToString + "," + j.ToString
                If flag Then
                    box(i, j).BackColor = Color.Black
                    box(i, j).ForeColor = Color.White
                Else
                    box(i, j).BackColor = Color.White
                    box(i, j).ForeColor = Color.Black
                End If
                flag = Not flag
                box(i, j).BorderStyle = BorderStyle.FixedSingle
                box(i, j).Font = New Font("", 20, FontStyle.Bold)
                Me.Controls.Add(box(i, j))
                AddHandler box(i, j).Click, AddressOf check
                x += 60
            Next
            x = 100
            y += 60
        Next
        listbox1 = New ListBox()
        listbox1.Font = New Font("", 20, FontStyle.Bold)
        listbox1.Items.Add("Total possible combination")
        listbox1.SetBounds(800, 100, 350, 1000)
        listbox1.Dock = DockStyle.Right
        Me.Controls.Add(listbox1)
        b = New Button()
        b.Text = "change board"
        b.SetBounds(800, 100, 200, 80)
        b.Font = listbox1.Font
        Me.Controls.Add(b)
        MethodEnable(0)
        'solution(size)
        AddHandler b.Click, AddressOf setboard
    End Sub
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        createboard(Val(InputBox("Insert size of board")))
        solution(boxsize)
        flag = True
    End Sub
    Private Sub MethodEnable(ByVal row As Integer)
        If row >= boxsize Then Exit Sub
        For i As Integer = 0 To boxsize - 1
            box(row, i).Enabled = True
        Next
    End Sub


    Private Sub setcolor(ByVal sender As System.Object)

        If (Val(sender.tag.ToString.Substring(0, 1)) Mod 2 = 0 And Val(sender.tag.ToString.Substring(2, 1)) Mod 2 = 0 Or Val(sender.tag.ToString.Substring(0, 1)) Mod 2 = 1 And Val(sender.tag.ToString.Substring(2, 1)) Mod 2 = 1) Then
            If boxsize Mod 2 = 1 Then
                sender.backcolor = Color.White
            Else
                sender.backcolor = Color.Black
            End If
        Else
            If boxsize Mod 2 = 1 Then
                sender.backcolor = Color.Black
            Else
                sender.backcolor = Color.White
            End If
        End If


    End Sub
    Private Sub setboard(ByVal sender As System.Object, ByVal e As System.EventArgs)
        createboard(Val(InputBox("Insert size of board")))
        solution(boxsize)
        setbox()
        flag = True
    End Sub

    Private Sub check(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.text = "Q" Then
            sender.text = ""
            setqueen(sender.tag.ToString.Substring(0, 1)) = -1
            counter -= 1
            If sender.BackColor = Color.Red Then setcolor(sender)
        Else
            If setqueen(sender.tag.ToString.Substring(0, 1)) = -1 Then
                sender.text = "Q"
                setqueen(sender.tag.ToString.Substring(0, 1)) = sender.tag.ToString.Substring(2, 1)
                If counter > 0 Then issafe(counter, sender)
                counter += 1
                MethodEnable(sender.tag.ToString.Substring(0, 1) + 1)
                getsolution()
            End If
        End If
        ' MsgBox(setqueen(sender.tag.ToString.Substring(0, 1)))
        ' If MsgBox("Do you want replace", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then setcolor(s)
        flag = True
    End Sub
    Private Sub getsolution()
        Dim s As String = ""
        For i As Integer = 0 To boxsize - 1
            If setqueen(i) = -1 Or flag = False Then Exit Sub
            s += setqueen(i).ToString
        Next
        'If MsgBox("Do you want to get other solution", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
        '    setbox()
        '    display.Text += s + vbNewLine
        'End If
    End Sub
    Private Sub issafe(ByVal c As Integer, ByVal s As System.Object)
        Dim x As Integer = setqueen(c)
        For i As Integer = 1 To c
            Dim t As Integer = setqueen(c - i)
            If t = x Or t = x + i Or t = x - i Then
                s.BackColor = Color.Red
                flag = False
                ' If MsgBox("Do you want replace", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then setcolor(s)
            End If
        Next
    End Sub
End Class