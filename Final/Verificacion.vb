Module Verificacion
    Public Function fn_enteros(txt_box As TextBox, cant As Integer) As String
        Dim parte2 As String
        Dim parte1 As String


        parte1 = ""
        parte2 = ""

        If Len(txt_box.Text) > 1 Then
            parte1 = Mid(txt_box.Text, 1, Len(txt_box.Text) - 1)
            parte2 = Mid(txt_box.Text, Len(txt_box.Text), 1)
        Else
            parte2 = txt_box.Text
        End If

        If (parte2 < "0" Or parte2 > "9" Or Len(txt_box.Text) > cant) And Len(txt_box.Text) > 0 Then
            txt_box.Text = Mid(txt_box.Text, 1, Len(txt_box.Text) - 1)
        End If

        If parte1.IndexOf("0") = 0 And Len(txt_box.Text) > 1 Then
            txt_box.Text = parte2
        End If
        txt_box.SelectionStart = txt_box.Text.Length
        Return txt_box.Text
    End Function

    Public Function fn_numeroDecimal(txt_box As TextBox, cantE As Integer, cantD As Integer) As String


        Dim parte2 As String
        Dim parte1 As String

        parte1 = ""
        parte2 = ""

        If Len(txt_box.Text) > 1 Then
            parte1 = Mid(txt_box.Text, 1, Len(txt_box.Text) - 1)
            parte2 = Mid(txt_box.Text, Len(txt_box.Text), 1)
        Else
            parte2 = txt_box.Text
        End If

        Select Case parte2
            Case "0"
                If parte1.IndexOf("0") = 0 Then

                    If parte1.IndexOf(".") <> 1 Then
                        txt_box.Text = parte1
                    End If

                End If
                'MsgBox("f")
                If (txt_box.Text.Length > cantE And txt_box.Text.IndexOf(".") = -1) Then
                    txt_box.Text = parte1
                End If

                If txt_box.Text.IndexOf(".") <> -1 And txt_box.Text.Length - txt_box.Text.IndexOf(".") - 1 > cantD Then
                    txt_box.Text = parte1
                End If
            Case "1" To "9"
                If parte1.IndexOf("0") = 0 And parte1.IndexOf(".") <> 1 Then 'Indica que el primer digito es un 0 y el segundo no es un punto, por ende se intenta poner 01 asi que el cero es inecesario y se elimina
                    txt_box.Text = parte2
                End If

                If (txt_box.Text.Length > cantE And txt_box.Text.IndexOf(".") = -1) Then
                    txt_box.Text = parte1
                End If

                If txt_box.Text.IndexOf(".") <> -1 And txt_box.Text.Length - txt_box.Text.IndexOf(".") - 1 > cantD Then
                    txt_box.Text = parte1
                End If
            Case ",", "."
                If parte1.IndexOf(".") = -1 Then
                    txt_box.Text = parte1 & "."
                Else
                    txt_box.Text = parte1
                End If
            Case Else
                txt_box.Text = parte1
        End Select

        txt_box.SelectionStart = txt_box.Text.Length
        Return txt_box.Text
    End Function

    Public Function fn_alfabetico(txt_box As TextBox, cant As Integer) As String
        Dim parte2 As String
        Dim parte1 As String

        parte1 = ""
        parte2 = ""

        If Len(txt_box.Text) > 1 Then
            parte1 = Mid(txt_box.Text, 1, Len(txt_box.Text) - 1)
            parte2 = Mid(txt_box.Text, Len(txt_box.Text), 1)
        Else
            parte2 = txt_box.Text
        End If

        Select Case parte2
            Case "a" To "z", "A" To "Z", "é", "á" To "ú", " ", "ü", "Ñ"
                If Len(txt_box.Text) <= cant Then
                    txt_box.SelectionStart = txt_box.Text.Length
                    Return txt_box.Text
                End If

                Return parte1

            Case Else
                Return parte1
        End Select
    End Function

    Public Function fn_alfabeticoConNumero(txt_box As TextBox, cant As Integer) As String
        Dim parte2 As String
        Dim parte1 As String

        parte1 = ""
        parte2 = ""

        If Len(txt_box.Text) > 1 Then
            parte1 = Mid(txt_box.Text, 1, Len(txt_box.Text) - 1)
            parte2 = Mid(txt_box.Text, Len(txt_box.Text), 1)
        Else
            parte2 = txt_box.Text
        End If

        Select Case parte2
            Case "a" To "z", "A" To "Z", "é", "á" To "ú", " ", "ü", "Ñ"
                If Len(txt_box.Text) <= cant Then
                    txt_box.SelectionStart = txt_box.Text.Length
                    Return txt_box.Text
                End If

                Return parte1
            Case "0" To "9", "/", "-"

                If Len(txt_box.Text) <= cant Then
                    txt_box.SelectionStart = txt_box.Text.Length
                    Return txt_box.Text
                End If

                Return parte1

            Case Else
                Return parte1
        End Select
    End Function

    Public Function fn_cambiarComaPorPunto(lbl_dato As Label) As String
        Dim parte2 As String
        Dim parte1 As String

        parte1 = ""
        parte2 = ""

        If lbl_dato.Text.IndexOf(",") = -1 Then
            Return lbl_dato.Text
        Else
            parte1 = Mid(lbl_dato.Text, 1, lbl_dato.Text.IndexOf(","))
            parte2 = Mid(lbl_dato.Text, lbl_dato.Text.IndexOf(",") + 2, lbl_dato.Text.Length - lbl_dato.Text.IndexOf(",") + 1)
            Return parte1 & "." & parte2
        End If
    End Function

    Public Function fn_cambiarComaPorPunto(dato As String) As String
        Dim parte2 As String
        Dim parte1 As String

        parte1 = ""
        parte2 = ""

        If dato.IndexOf(",") = -1 Then
            Return dato
        Else
            parte1 = Mid(dato, 1, dato.IndexOf(","))
            parte2 = Mid(dato, dato.IndexOf(",") + 2, dato.Length - dato.IndexOf(",") + 1)
            Return parte1 & "." & parte2
        End If
    End Function
End Module
