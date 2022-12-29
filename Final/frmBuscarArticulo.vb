Imports System.Data.SqlClient
Public Class frmBuscarArticulo
    Public g_format As String = "00000"
    Dim g_validarDatos As Boolean
    Dim g_elegido As String
    Dim g_StringItem As String
    Dim g_total As Integer
    Dim g_string As String

    Dim g_Rs0 As String
    Dim g_Rs1 As String
    Dim g_Rs2 As String
    Dim g_Rs3 As String
    Private Sub frmBuscarArticulo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        g_validarDatos = False
        g_elegido = ""
        g_StringItem = ""
        g_Rs0 = ""
        g_Rs1 = ""
        g_Rs2 = ""
        g_Rs3 = ""
        Me.txtBuscar.Text = ""
        Me.ListBox1.Items.Clear()
        Me.txtBuscar.Focus()
        buscar()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        buscar()
    End Sub

    Private Sub buscar()
        Me.ListBox1.Items.Clear()
        On Error GoTo errores
        Dim Rs As SqlDataReader
        Dim consulta As String = ""
        sql = "select f.[ID articulo], f.[nom articulo], a.[nom agrupacion], f.[pco articulo]  from articulo f inner join agrupacion a on f.[ID agrupacion] = a.[ID agrupacion] ORDER BY [ID articulo]"
        instruccion = New SqlCommand(sql, daoCon)
        Rs = instruccion.ExecuteReader()
        While Rs.Read
            g_Rs0 = Rs(0)

            g_Rs1 = Rs(1)
            g_Rs2 = Rs(2)
            g_Rs3 = Rs(3)
            consulta = Format(Rs(0), g_format) & Rs(1) & Rs(2) & Rs(3)
            If fn_validarConsulta(consulta) Then
                StringItem(Rs(0))
                Me.ListBox1.Items.Add(g_StringItem)
            End If
        End While
        Rs.Close()
        Exit Sub
errores:
        MsgBox(Err.Description)
        Rs.Close()
        Exit Sub

    End Sub

    Private Function fn_validarConsulta(consulta As String) As Boolean
        consulta = UCase(consulta)
        If consulta.IndexOf(UCase(Me.txtBuscar.Text)) <> -1 Then
            Return True
        End If
        Return False
    End Function

    Private Sub validarItem()
        If ListBox1.SelectedItem = Nothing Then
            g_validarDatos = False
            Exit Sub
        End If

        If ListBox1.SelectedItem.ToString() <> "" Then

            g_validarDatos = True
            Exit Sub
        End If

        g_validarDatos = False
    End Sub

    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles ListBox1.DoubleClick
        validarItem()
        Me.txtBuscar.Focus()
        If g_validarDatos Then
            g_elegido = Me.ListBox1.SelectedItem.ToString
            pasarDatos()
            Me.Close()
        End If
    End Sub

    Private Sub frmBuscarArticulo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If g_validarDatos Then
            frmArticulos.tsmAgregar.Enabled = False
            frmArticulos.tsmEliminar.Enabled = True
            frmArticulos.tsmModificar.Enabled = True
        Else
            frmArticulos.LimpToolStripMenuItem.PerformClick()
        End If
    End Sub

    Private Sub pasarDatos()

        cargarMov(Val(g_elegido))
        frmArticulos.txtCodigo.Text = Val(g_elegido)
        'MsgBox(frmArticulos.txtCodigo.Text)

        g_elegido = Mid(g_elegido, 7, g_elegido.Length)
        'MsgBox(g_elegido)


        'MsgBox(frmArticulos.cmbAgrupacion.Items)
        'MsgBox(frmArticulos.cmbAgrupacion.Items.IndexOf(Trim("PC     ")))
        'MsgBox(Mid(g_elegido, 1, 50))
        'MsgBox(frmArticulos.cmbAgrupacion.Items.IndexOf(Mid(g_elegido, 1, 50)))
        frmArticulos.cmbAgrupacion.SelectedIndex = frmArticulos.cmbAgrupacion.Items.IndexOf(Trim(Mid(g_elegido, 1, 50)))
        'frmArticulos.cmbAgrupacion.Text = Mid(g_elegido, 1, 50)
        'MsgBox(frmArticulos.cmbAgrupacion.Text)

        g_elegido = Mid(g_elegido, 52, g_elegido.Length)
        'MsgBox(g_elegido)

        frmArticulos.txtNombre.Text = Trim(Mid(g_elegido, 1, 50))
        'MsgBox(frmArticulos.txtNombre.Text)

        g_elegido = Mid(g_elegido, 52, g_elegido.Length)
        'MsgBox(g_elegido)

        frmArticulos.txtPrecio.Text = fn_cambiarComaPorPunto(g_elegido)
        'MsgBox(frmArticulos.txtPrecio.Text)



    End Sub
    Private Sub cargarMov(codigo As Integer)
        Me.ListBox1.Items.Clear()
        frmArticulos.ListBox1.Items.Clear()
        g_total = 0
        On Error GoTo errores
        Dim Rs As SqlDataReader
        Dim consulta As String = ""
        sql = "select [fec movimiento], [obs movimiento], [tip tipomovi], [can movimiento]  from movimiento m inner join tipomovi t on m.[ID tipomovi] = t.[ID tipomovi] WHERE m.[ID articulo] = " & codigo & "  ORDER BY [ID movimiento]"
        instruccion = New SqlCommand(sql, daoCon)
        Rs = instruccion.ExecuteReader()

        frmArticulos.ListBox1.Items.Add("Fecha" & Space(15) & "Detalle movimiento" & Space(51 - Len("Detalle movimiento")) & "E" & Space(8) & "S" & Space(7) & "Cantidad en stock")
        While Rs.Read
            armarString(Rs(0), Rs(1), Rs(2), Rs(3))
            frmArticulos.ListBox1.Items.Add(g_string)
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
    Private Sub StringItem(codigo As Long)

        g_StringItem = Format(codigo, g_format) & Space(1)
        'MsgBox(g_StringItem)
        g_StringItem = g_StringItem & g_Rs2 & Space(50 - Len(g_Rs2)) & Space(1)
        'MsgBox(g_StringItem)
        'txtPrecio.Text = fn_cambiarComaPorPuntoString(Format(Val(txtPrecio.Text), g_formato))
        g_StringItem = g_StringItem & g_Rs1 & Space(50 - Len(g_Rs1)) & Space(1)
        'MsgBox(g_StringItem)
        g_StringItem = g_StringItem & Space(15 - Len(g_Rs3)) & g_Rs3
        'MsgBox(g_StringItem)

        'Dim subtotal As String = 0
        'subtotal = Format(Val(txtcantidad.text) * Val(txtprecio.text), g_formato)
        'subtotal = fn_cambiarcomaporpuntostring(subtotal)
        'g_StringItem = g_StringItem & Space(20 - Len(subtotal)) & subtotal

    End Sub
End Class