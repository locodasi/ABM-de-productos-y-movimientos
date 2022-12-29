Imports System.Data.SqlClient

Public Class frmMovimientos
    Dim g_valido As Boolean
    Dim g_cambio As Boolean
    Dim g_idArticulo As String
    Dim g_idTipoMovi As String
    Dim g_formatFecha As String
    Dim g_formatPrecio As String
    Dim g_precioArt As String


    Private Sub frmMovimientos_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load

        g_valido = False
        g_cambio = False
        sumarArticulo()
        sumarTipoMov()
        limpiar()
        g_idTipoMovi = 0
        g_idArticulo = 0
        g_formatFecha = "dd/MM/yyyy HH:mm:ss"
        g_formatPrecio = "##0.00"
    End Sub

    Private Sub limpiar()
        Me.txtObservaciones.Text = ""
        Me.txtCantidad.Text = ""
        Me.cmbArticulo.SelectedIndex = 0
        Me.cmbTipoMovi.SelectedIndex = 0
        g_idTipoMovi = 0
        g_idArticulo = 0
        g_precioArt = ""
        g_cambio = False
        Me.tsmAgregar.Enabled = True
        Me.txtCodigo.Text = ""
        Me.txtCantidad.Focus()
    End Sub

    Private Sub txtCantidad_TextChanged(sender As Object, e As EventArgs) Handles txtCantidad.TextChanged
        Me.txtCantidad.Text = fn_enteros(Me.txtCantidad, 8)
        g_cambio = True
    End Sub

    Private Sub txtExtra_TextChanged(sender As Object, e As EventArgs) Handles txtObservaciones.TextChanged
        g_cambio = True
    End Sub

    Private Sub sumarArticulo()
        'MsgBox("arti")
        Me.cmbArticulo.Items.Clear()
        On Error GoTo errores
        Dim Rs As SqlDataReader
        Dim Rs2 As SqlDataReader
        Dim consulta As String = ""
        sql = "select a.[nom articulo] from articulo a inner join agrupacion ag on ag.[ID agrupacion] = a.[ID agrupacion] ORDER BY a.[ID articulo]"
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

    Private Sub sumarTipoMov()
        'MsgBox("movi")
        Me.cmbTipoMovi.Items.Clear()
        On Error GoTo errores
        Dim Rs As SqlDataReader
        Dim consulta As String = ""
        sql = "select [nom tipomovi]  from tipomovi ORDER BY [ID tipomovi]"
        instruccion = New SqlCommand(sql, daoCon)
        Rs = instruccion.ExecuteReader()
        While Rs.Read

            Me.cmbTipoMovi.Items.Add(Rs(0))
        End While
        Rs.Close()
        Exit Sub
errores:
        MsgBox(Err.Description)
        Exit Sub
    End Sub

    Private Sub LimpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LimpToolStripMenuItem.Click
        If g_cambio Then
            Me.tsmAgregar.Enabled = True
            avisarCambio()
            Exit Sub
        End If
        limpiar()
    End Sub

    Private Sub avisarCambio()
        Dim op As Integer
        op = MsgBox("Se han realizado cambios. ¿Desea continuar?", vbYesNo, "Atencion")
        If op = vbYes Then
            limpiar()
        End If
    End Sub

    Private Sub cmbTipoMovi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoMovi.SelectedIndexChanged
        g_cambio = True
    End Sub

    Private Sub cmbArticulo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbArticulo.SelectedIndexChanged
        g_cambio = True
    End Sub

    Private Sub tsmAgregar_Click(sender As Object, e As EventArgs) Handles tsmAgregar.Click
        validar()
        If g_valido Then
            agregar()
        End If
    End Sub

    Private Sub validar()
        If Me.txtObservaciones.Text <> "" And Val(Me.txtCantidad.Text) > 0 And Me.cmbArticulo.Text <> "" And Me.cmbTipoMovi.Text <> "" Then
            g_valido = True
        Else
            g_valido = False

        End If

    End Sub

    Sub agregar()

        On Error GoTo errores

        obtenerIdTipoMovi()
        obtenerIdArticulo()
        ' MsgBox("tipo " & g_idTipoMovi)
        ' MsgBox("art " & g_idArticulo)
        obtenerPrecio()
        g_precioArt = Format(Val(g_precioArt) * Val(Me.txtCantidad.Text), g_formatPrecio)
        'MsgBox("pre " & g_precioArt)
        '& "," & g_idArticulo & ",'" & Format(Now, g_formatFecha) & "'," & Me.txtCantidad.Text & "," & Val(g_precioArt) & ",'" & Me.txtObservaciones
        sql = "INSERT INTO movimiento ([ID tipomovi], [ID articulo], [fec movimiento], [can movimiento], [pre movimiento], [obs movimiento]) VALUES (" & g_idTipoMovi & "," & g_idArticulo & ",'" & Format(Now, g_formatFecha) & "'," & Me.txtCantidad.Text & "," & Val(g_precioArt) & ",'" & Me.txtObservaciones.Text & "')"
        instruccion = New SqlCommand(sql, daoCon)
        instruccion.ExecuteNonQuery()
        Me.limpiar()
        Exit Sub
errores:
        MsgBox(Err.Description)
        Exit Sub

    End Sub

    Private Sub obtenerPrecio()
        On Error GoTo errores
        Dim Rs As SqlDataReader
        sql = "SELECT [pco articulo] from articulo WHERE [ID articulo] = " & g_idArticulo
        instruccion = New SqlCommand(sql, daoCon)

        Rs = instruccion.ExecuteReader()
        Rs.Read()

        'MsgBox("d")
        g_precioArt = Rs(0)
        ' MsgBox(g_precioArt)
        Rs.Close()
        Exit Sub
errores:
        MsgBox(Err.Description)
        Exit Sub
    End Sub
    Private Sub obtenerIdTipoMovi()
        On Error GoTo errores
        Dim Rs As SqlDataReader
        sql = "SELECT [ID tipomovi] from tipomovi WHERE [nom tipomovi] = '" & Me.cmbTipoMovi.Text & "'"
        instruccion = New SqlCommand(sql, daoCon)

        Rs = instruccion.ExecuteReader()
        Rs.Read()

        g_idTipoMovi = Rs(0)

        Rs.Close()
        Exit Sub
errores:
        MsgBox(Err.Description)
        Exit Sub
    End Sub

    Private Sub obtenerIdArticulo()
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

    Private Sub tsmBuscar_Click(sender As Object, e As EventArgs) Handles tsmBuscar.Click
        g_cambio = False
        frmBuscarMovimiento.ShowDialog()
    End Sub
End Class