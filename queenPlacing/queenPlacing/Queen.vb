Module Queen

    Dim maxi As Integer
    Dim b() As Integer = {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1}
    Dim s As Integer

    Public Sub solution(ByVal m As Integer)
        s = 0
        Dim y As Integer = 0
        maxi = m
        b(y) = -1

        While (y >= 0)
            Do
                b(y) += 1
            Loop While ((b(y) < maxi) And unsafe(y))
            If (b(y) < maxi) Then
                If (y < maxi - 1) Then
                    y += 1
                    b(y) = -1
                Else
                    Dim a As String = s.ToString + " --> "
                    For i As Integer = 0 To maxi - 1
                        a += b(i).ToString
                    Next
                    Form2.listbox1.Items.Add(a)
                    s += 1
                End If
            Else
                y -= 1
            End If
        End While
    End Sub
    Public Function unsafe(ByVal c As Integer) As Boolean
        Dim x As Integer = b(c)
        For i As Integer = 1 To c
            Dim t As Integer = b(c - i)
            If t = x Or t = x + i Or t = x - i Then
                Return True
            End If
        Next
        Return False
    End Function
End Module
