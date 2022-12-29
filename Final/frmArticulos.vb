Imports System.Data.SqlClient

Public Class frmArticulos
    Dim g_valido As Boolean
    Dim g_cambio As Boolean
    Dim g_idAgrupacion As String

    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs)
        Me.txtNombre.Text = fn_alfabeticoConNumero(Me.txtNombre, 50)
        g_cambio = True
    End Sub

    Private Sub frmArticulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        limpiar()
        g_valido = False
        g_cambio = False
        sumarAgrupacion()
        Me.cmbAgrupacion.SelectedIndex = 0
        g_idAgrupacion = 0
    End Sub

    Private Sub limpiar()
        Me.txtNombre.Text = ""
        Me.txtCodigo.Text = ""
        Me.txtPrecio.Text = ""
        Me.tsmModificar.Enabled = False
        Me.tsmEliminar.Enabled = False
        Me.tsmAgregar.Enabled = True
        g_idAgrupacion = 0
        Me.cmbAgrupacion.SelectedIndex = 0
        g_cambio = False
        Me.ListBox1.Items.Clear()
        Me.txtNombre.Focus()
    End Sub

    Private Sub txtPrecio_TextChanged(sender As Object, e As EventArgs)
        Me.txtPrecio.Text = fn_numeroDecimal(Me.txtPrecio, 12, 2)
        g_cambio = True
    End Sub
    Private Sub sumarAgrupacion()
        Me.cmbAgrupacion.Items.Clear()
        On Error GoTo errores
        Dim Rs As SqlDataReader
        Dim consulta As String = ""
        sql = "select [nom agrupacion]  from agrupacion ORDER BY [ID agrupacion]"
        instruccion = New SqlCommand(sql, daoCon)
        Rs = instruccion.ExecuteReader()
        While Rs.Read

            Me.cmbAgrupacion.Items.Add(Rs(0))
        End While
        Rs.Close()
        Exit Sub
errores:
        MsgBox(Err.Description)
        Exit Sub
    End Sub

    Private Sub LimpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LimpToolStripMenuItem.Click
        If g_cambio Then

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

    Private Sub tsmAgregar_Click(sender As Object, e As EventArgs) Handles tsmAgregar.Click
        validar()
        If g_valido Then
            agregar()
        End If
    End Sub

    Private Sub validar()
        If Me.txtNombre.Text <> "" And Me.cmbAgrupacion.Text <> "" And Val(Me.txtPrecio.Text) > 0 Then
            g_valido = True
        Else
            g_valido = False

        End If

    End Sub

    Sub agregar()

        On Error GoTo errores

        obtenerIdAgrupacion()
        ' MsgBox(g_idAgrupacion)
        sql = "INSERT INTO articulo ([nom articulo], [ID agrupacion], [pco articulo]) VALUES ('" & Me.txtNombre.Text & "'," & g_idAgrupacion & "," & Me.txtPrecio.Text & ")"
        instruccion = New SqlCommand(sql, daoCon)
        instruccion.ExecuteNonQuery()
        Me.limpiar()
        Exit Sub
errores:
        MsgBox(Err.Description)
        Exit Sub

    End Sub

    Private Sub obtenerIdAgrupacion()
        On Error GoTo errores
        Dim Rs As SqlDataReader
        sql = "SELECT [ID agrupacion] from agrupacion WHERE [nom agrupacion] = '" & Me.cmbAgrupacion.Text & "'"
        instruccion = New SqlCommand(sql, daoCon)

        Rs = instruccion.ExecuteReader()
        Rs.Read()

        g_idAgrupacion = Rs(0)

        Rs.Close()
        Exit Sub
errores:
        MsgBox(Err.Description)
        Exit Sub
    End Sub

    Private Sub tsmBuscar_Click(sender As Object, e As EventArgs) Handles tsmBuscar.Click
        g_cambio = False
        frmBuscarArticulo.ShowDialog()
    End Sub

    Private Sub tsmEliminar_Click(sender As Object, e As EventArgs) Handles tsmEliminar.Click
        eliminar()
    End Sub

    Private Sub eliminar()
        On Error GoTo errores
        sql = "DELETE FROM articulo WHERE [ID articulo] =" & Me.txtCodigo.Text
        instruccion = New SqlCommand(sql, daoCon)
        instruccion.ExecuteNonQuery()
        limpiar()
        Exit Sub
errores:
        MsgBox(Err.Description)
        Exit Sub
    End Sub

    Private Sub tsmModificar_Click(sender As Object, e As EventArgs) Handles tsmModificar.Click
        modificar()
    End Sub

    Private Sub modificar()
        On Error GoTo errores
        obtenerIdAgrupacion()
        sql = "UPDATE articulo SET [nom articulo] ='" & Me.txtNombre.Text & "', [pco articulo] = " & Me.txtPrecio.Text & ", [ID agrupacion] = " & g_idAgrupacion & " WHERE [ID articulo] =" & Me.txtCodigo.Text
        instruccion = New SqlCommand(sql, daoCon)
        instruccion.ExecuteNonQuery()
        g_cambio = False
        Exit Sub
errores:
        MsgBox(Err.Description)
        Exit Sub
    End Sub

    Private Sub cmbAgrupacion_SelectedIndexChanged(sender As Object, e As EventArgs)
        g_cambio = True
    End Sub

    Private Sub txtNombre_TextChanged_1(sender As Object, e As EventArgs) Handles txtNombre.TextChanged
        Me.txtNombre.Text = fn_alfabeticoConNumero(Me.txtNombre, 50)
        g_cambio = True
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub txtPrecio_TextChanged_1(sender As Object, e As EventArgs) Handles txtPrecio.TextChanged
        Me.txtPrecio.Text = fn_numeroDecimal(Me.txtPrecio, 12, 2)
        g_cambio = True
    End Sub
End Class