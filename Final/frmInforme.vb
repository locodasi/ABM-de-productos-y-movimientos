Imports System.Data.SqlClient

Public Class frmInforme
    Dim g_idArticulo As String
    Dim g_string As String
    Dim g_total As Integer
    Private Sub frmInforme_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarArticulos()
        Me.ListBox1.Items.Clear()
        g_total = 0
    End Sub

    Private Sub cargarArticulos()
        'MsgBox("arti")
        Me.cmbArticulo.Items.Clear()
        On Error GoTo errores
        Dim Rs As SqlDataReader
        Dim Rs2 As SqlDataReader
        Dim consulta As String = ""
        sql = "select a.[nom articulo] from articulo a inner join agrupacion ag on a.[ID agrupacion] = ag.[ID agrupacion] ORDER BY [ID articulo]"
        instruccion = New SqlCommand(sql, daoCon)
        Rs = instruccion.ExecuteReader()
        While Rs.Read
            'MsgBox(Rs(0))
            'ContarAgrupacion(Rs(1))

            'If Rs2(0) <> 0 Then
            Me.cmbArticulo.Items.Add(Rs(0))
            'End If

            'Rs2.Close()
        End While
        Rs.Close()
        Exit Sub
errores:
        Select Case Err.Number
            Case 5
                MsgBox(Err.Description & " " & Err.Number)
                Exit Sub
        End Select

    End Sub

    Private Sub cmbArticulo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbArticulo.SelectedIndexChanged
        ObtenerIdArticulo()
        cargarMovimiento()
    End Sub
    Private Sub ObtenerIdArticulo()
        On Error GoTo errores
        Dim Rs As SqlDataReader
        sql = "SELECT [ID articulo] from articulo WHERE [nom articulo] = '" & Me.cmbArticulo.Text & "'"
        instruccion = New SqlCommand(sql, daoCon)

        Rs = instruccion.ExecuteReader()
        Rs.Read()

        g_idArticulo = Rs(0)

        Rs.Close()
        Exit Sub
errores:
        MsgBox(Err.Description)
        Exit Sub
    End Sub
    Private Sub cargarMovimiento()
        Me.ListBox1.Items.Clear()
        g_total = 0
        On Error GoTo errores
        Dim Rs As SqlDataReader
        Dim consulta As String = ""
        sql = "select [fec movimiento], [obs movimiento], [tip tipomovi], [can movimiento]  from movimiento m inner join tipomovi t on m.[ID tipomovi] = t.[ID tipomovi] WHERE m.[ID articulo] = " & g_idArticulo & "  ORDER BY [ID movimiento]"
        instruccion = New SqlCommand(sql, daoCon)
        Rs = instruccion.ExecuteReader()
        While Rs.Read
            armarString(Rs(0), Rs(1), Rs(2), Rs(3))
            Me.ListBox1.Items.Add(g_string)
        End While
        Rs.Close()
        Exit Sub
errores:
        MsgBox(Err.Description)
        Exit Sub
    End Sub

    Private Sub armarString(fecha As String, obs As String, tipo As Char, cant As Integer)
        g_string = ""
        Dim d As Integer
        Dim m As Integer
        g_string = fecha
        d = Len(Mid(fecha, 1, fecha.IndexOf("/")))
        fecha = Mid(g_string, d + 2, g_string.Length)
        m = Len(Mid(fecha, 1, fecha.IndexOf("/")))
        obs = Mid(obs, 1, 50)

        If Len(g_string) > 10 Then
            If d = 2 And m = 2 Then
                g_string = g_string & Space(1) & obs & Space(51 - Len(obs))
            ElseIf d = 2 Or m = 2 Then
                g_string = g_string & Space(2) & obs & Space(51 - Len(obs))
            Else
                g_string = g_string & Space(3) & obs & Space(51 - Len(obs))
            End If
        Else
            If d = 2 And m = 2 Then
                g_string = g_string & Space(10) & obs & Space(51 - Len(obs))
            ElseIf d = 2 Or m = 2 Then
                g_string = g_string & Space(11) & obs & Space(51 - Len(obs))
            Else
                g_string = g_string & Space(12) & obs & Space(51 - Len(obs))
            End If
        End If

        Dim auxS As String = cant
        'MsgBox(Len(auxS))

        If tipo = "E" Then
            g_string = g_string & cant & Space(18 - Len(auxS) - 1)
            g_total = g_total + cant
        Else
            g_string = g_string & Space(9) & cant & Space(9 - Len(auxS) - 1)
            g_total = g_total - cant
        End If

        g_string = g_string & g_total

    End Sub
End Class