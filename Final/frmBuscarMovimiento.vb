Imports System.Data.SqlClient

Public Class frmBuscarMovimiento
    Public g_format As String = "00000"
    Dim g_validarDatos As Boolean
    Dim g_elegido As String
    Dim g_StringItem As String
    Dim g_obs As String
    Dim g_idElegido As String
    Private Sub frmBuscarMovimiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        g_validarDatos = False
        g_elegido = ""
        g_StringItem = ""
        g_obs = ""
        g_idElegido = ""
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
        sql = "select m.[ID movimiento], t.[nom tipomovi], a.[nom articulo],  m.[fec movimiento], m.[can movimiento], m.[pre movimiento], m.[obs movimiento]   from movimiento m inner join articulo a on m.[ID articulo] = a.[ID articulo] inner join tipomovi t on m.[ID tipomovi] = t.[ID tipomovi] inner join agrupacion ag on ag.[ID agrupacion] = a.[ID agrupacion] ORDER BY [fec movimiento]"
        instruccion = New SqlCommand(sql, daoCon)
        Rs = instruccion.ExecuteReader()
        While Rs.Read
            consulta = Format(Rs(0), g_format) & Rs(1) & Rs(2) & Rs(3) & Rs(4) & Rs(5)
            If fn_validarConsulta(consulta) Then
                StringItem(Rs(0), Rs(1), Rs(2), Rs(3), Rs(4), Rs(5))
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

    Private Sub frmBuscarMovimiento_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If g_validarDatos Then
            frmMovimientos.tsmAgregar.Enabled = False
        Else
            frmMovimientos.LimpToolStripMenuItem.PerformClick()
        End If
    End Sub

    Private Sub StringItem(codigo As Long, tipo As String, nombre As String, fecha As String, can As Integer, precio As Double)
        Dim d As Integer
        Dim m As Integer
        Dim aux As String
        aux = fecha
        d = Len(Mid(fecha, 1, fecha.IndexOf("/")))
        fecha = Mid(fecha, d + 2, fecha.Length)
        m = Len(Mid(fecha, 1, fecha.IndexOf("/")))




        g_StringItem = Format(codigo, g_format) & Space(1)
        'MsgBox(g_StringItem)
        g_StringItem = g_StringItem & tipo & Space(51 - Len(tipo))

        g_StringItem = g_StringItem & nombre & Space(51 - Len(nombre))

        If Len(aux) > 10 Then
            If d = 2 And m = 2 Then
                g_StringItem = g_StringItem & aux & Space(1)
            ElseIf d = 2 Or m = 2 Then
                g_StringItem = g_StringItem & aux & Space(2)
            Else
                g_StringItem = g_StringItem & aux & Space(3)
            End If
        Else
            If d = 2 And m = 2 Then
                g_StringItem = g_StringItem & aux & Space(10)
            ElseIf d = 2 Or m = 2 Then
                g_StringItem = g_StringItem & aux & Space(11)
            Else
                g_StringItem = g_StringItem & aux & Space(12)
            End If
        End If


        Dim cantAux As String = can
        g_StringItem = g_StringItem & Space(12 - Len(cantAux)) & can & Space(1)

        Dim preAux As String = precio
        g_StringItem = g_StringItem & Space(18 - Len(preAux)) & precio

    End Sub


    Private Sub pasarDatos()
        g_idElegido = Val(g_elegido)
        frmMovimientos.txtCodigo.Text = Val(g_elegido)
        'MsgBox(frmArticulos.txtCodigo.Text)

        g_elegido = Mid(g_elegido, 7, g_elegido.Length)
        'MsgBox(g_elegido)

        'MsgBox(Mid(g_elegido, 1, 50))





        frmMovimientos.cmbTipoMovi.SelectedIndex = frmMovimientos.cmbTipoMovi.Items.IndexOf(Trim(Mid(g_elegido, 1, 50)))

        'MsgBox("ds " & frmMovimientos.cmbTipoMovi.Text)

        g_elegido = Mid(g_elegido, 52, g_elegido.Length)
        'MsgBox(g_elegido)
        'MsgBox(g_elegido)
        'MsgBox(Mid(g_elegido, 1, 50))
        'MsgBox(Trim(Mid(g_elegido, 1, 50)))

        frmMovimientos.cmbArticulo.SelectedIndex = frmMovimientos.cmbArticulo.Items.IndexOf(Trim(Mid(g_elegido, 1, 50)))
        'MsgBox("s " + frmMovimientos.cmbArticulo.Text)

        g_elegido = Mid(g_elegido, 52, g_elegido.Length)
        'MsgBox(g_elegido)

        g_elegido = Mid(g_elegido, g_elegido.LastIndexOf(":") + 14, g_elegido.Length)
        'MsgBox(g_elegido)

        'MsgBox(Val(Mid(g_elegido, 1, g_elegido.IndexOf(" ") + 1)))
        'MsgBox(g_elegido)
        'MsgBox(Mid(g_elegido, 1, g_elegido.LastIndexOf(" ") + 1))
        frmMovimientos.txtCantidad.Text = Val(Mid(g_elegido, 1, g_elegido.LastIndexOf(" ") + 1))

        obtenerObs()
        frmMovimientos.txtObservaciones.Text = g_obs
        'MsgBox(g_obs)
        'MsgBox(frmArticulos.txtPrecio.Text)


    End Sub

    Private Sub obtenerObs()
        On Error GoTo errores
        Dim Rs As SqlDataReader
        Dim consulta As String = ""
        sql = "select [obs movimiento] from movimiento WHERE [ID movimiento] = " & g_idElegido
        instruccion = New SqlCommand(sql, daoCon)
        Rs = instruccion.ExecuteReader()
        While Rs.Read
            g_obs = Rs(0)
        End While
        Rs.Close()
        Exit Sub
errores:
        MsgBox(Err.Description)
        Rs.Close()
        Exit Sub
    End Sub
End Class