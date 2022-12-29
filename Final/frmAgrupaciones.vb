Imports System.Data.SqlClient
Public Class frmAgrupaciones

    Dim g_valido As Boolean
    Dim g_cambio As Boolean
    Dim g_validoEliminar As Boolean
    Private Sub AgToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsmAgregar.Click
        validar()
        If g_valido Then
            agregar()
        End If

    End Sub

    Private Sub Agrupaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        limpiar()
        g_valido = False
        g_cambio = False
        g_validoEliminar = False
    End Sub

    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged
        Me.txtNombre.Text = fn_alfabeticoConNumero(Me.txtNombre, 50)
        g_cambio = True
    End Sub

    Private Sub LimpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LimpToolStripMenuItem.Click
        If g_cambio Then

            avisarCambio()
            Exit Sub
        End If
        limpiar()
    End Sub
    Private Sub tsmEliminar_Click(sender As Object, e As EventArgs) Handles tsmEliminar.Click

        validarEliminar()

        If g_validoEliminar Then
            eliminar()
        Else
            MsgBox("No se puede eliminar ya que existen articulos con esta agrupacion", vbInformation, "Atencion")
        End If

    End Sub

    Private Sub modificar()
        On Error GoTo errores
        sql = "UPDATE agrupacion SET [nom agrupacion] ='" & Me.txtNombre.Text & "' WHERE [ID agrupacion] =" & Me.txtCodigo.Text
        instruccion = New SqlCommand(sql, daoCon)
        instruccion.ExecuteNonQuery()
        g_cambio = False
        Exit Sub
errores:
        MsgBox(Err.Description)
        Exit Sub
    End Sub
    Private Sub eliminar()
        On Error GoTo errores
        sql = "DELETE FROM agrupacion WHERE [ID agrupacion] =" & Me.txtCodigo.Text
        instruccion = New SqlCommand(sql, daoCon)
        instruccion.ExecuteNonQuery()
        limpiar()
        Exit Sub
errores:
        MsgBox(Err.Description)
        Exit Sub
    End Sub
    Sub agregar()
        On Error GoTo errores
        sql = "INSERT INTO agrupacion ([nom agrupacion]) VALUES ('" & Me.txtNombre.Text & "')"
        instruccion = New SqlCommand(sql, daoCon)
        instruccion.ExecuteNonQuery()
        Me.limpiar()
        Exit Sub
errores:
        MsgBox(Err.Description)
        Exit Sub

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

    Private Sub validar()
        If Me.txtNombre.Text <> "" Then
            g_valido = True
        Else
            g_valido = False
        End If

    End Sub

    Private Sub tsmBuscar_Click(sender As Object, e As EventArgs) Handles tsmBuscar.Click
        g_cambio = False
        frmBuscarAgrup.ShowDialog()
    End Sub

    Private Sub tsmModificar_Click(sender As Object, e As EventArgs) Handles tsmModificar.Click
        modificar()
    End Sub

    Private Sub avisarCambio()
        Dim op As Integer
        op = MsgBox("Se han realizado cambios. ¿Desea continuar?", vbYesNo, "Atencion")
        If op = vbYes Then
            limpiar()
        End If
    End Sub

    Private Sub validarEliminar()
        On Error GoTo errores
        Dim Rs As SqlDataReader
        Dim consulta As String = ""
        sql = "select [ID agrupacion] from articulo where [ID agrupacion] = " & Me.txtCodigo.Text
        instruccion = New SqlCommand(sql, daoCon)
        Rs = instruccion.ExecuteReader()
        Rs.Read()

        If Rs(0) <> 0 Then
            g_validoEliminar = False
        End If
        Rs.Close()
        Exit Sub
errores:

        Select Case Err.Number
            Case 5
                g_validoEliminar = True
                Rs.Close()
            Case Else
                MsgBox(Err.Description)

        End Select
        Exit Sub
    End Sub
End Class