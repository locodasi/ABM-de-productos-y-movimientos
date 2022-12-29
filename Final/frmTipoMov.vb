Imports System.Data.SqlClient

Public Class frmTipoMov
    Dim g_valido As Boolean
    Dim g_cambio As Boolean

    Private Sub frmTipoMov_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        limpiar()
        g_valido = False
        g_cambio = False
        Me.cmbTipo.SelectedIndex = 0
    End Sub

    Private Sub limpiar()
        Me.txtNombre.Text = ""
        Me.txtCodigo.Text = ""
        Me.tsmModificar.Enabled = False
        Me.tsmEliminar.Enabled = False
        Me.tsmAgregar.Enabled = True
        g_cambio = False
        Me.txtNombre.Focus()
    End Sub

    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged
        Me.txtNombre.Text = fn_alfabetico(Me.txtNombre, 50)
        g_cambio = True
    End Sub

    Private Sub tsmAgregar_Click(sender As Object, e As EventArgs) Handles tsmAgregar.Click
        validar()
        If g_valido Then
            agregar()
        End If
    End Sub

    Private Sub validar()
        If Me.txtNombre.Text <> "" And Me.cmbTipo.Text <> "" Then
            g_valido = True
        Else
            g_valido = False

        End If

    End Sub

    Sub agregar()
        On Error GoTo errores
        sql = "INSERT INTO tipomovi ([nom tipomovi], [tip tipomovi]) VALUES ('" & Me.txtNombre.Text & "', '" & Me.cmbTipo.Text & "')"
        instruccion = New SqlCommand(sql, daoCon)
        instruccion.ExecuteNonQuery()
        Me.limpiar()
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

    Private Sub cmbTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipo.SelectedIndexChanged
        g_cambio = True
    End Sub

    Private Sub tsmBuscar_Click(sender As Object, e As EventArgs) Handles tsmBuscar.Click
        g_cambio = False
        frmBuscarTipoMov.ShowDialog()
    End Sub

    Private Sub tsmEliminar_Click(sender As Object, e As EventArgs) Handles tsmEliminar.Click
        eliminar()
    End Sub

    Private Sub eliminar()
        On Error GoTo errores
        Dim Rs As SqlDataReader
        sql = "SELECT COUNT(*) FROM movimiento WHERE [ID tipomovi]=" & Me.txtCodigo.Text
        instruccion = New SqlCommand(sql, daoCon)
        Rs = instruccion.ExecuteReader()
        Rs.Read()

        If Rs(0) > 0 Then
            MsgBox("Imposible borrar, existe un movimiento con este tipo", vbCritical, "Atencion")
            Rs.Close()
            Exit Sub
        End If
        Rs.Close()

        sql = "DELETE FROM tipomovi WHERE [ID tipomovi] =" & Me.txtCodigo.Text
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
        sql = "UPDATE tipomovi SET [nom tipomovi] ='" & Me.txtNombre.Text & "', [tip tipomovi] = '" & Me.cmbTipo.Text & "' WHERE [ID tipomovi] =" & Me.txtCodigo.Text
        instruccion = New SqlCommand(sql, daoCon)
        instruccion.ExecuteNonQuery()
        g_cambio = False
        Exit Sub
errores:
        MsgBox(Err.Description)
        Exit Sub
    End Sub
End Class