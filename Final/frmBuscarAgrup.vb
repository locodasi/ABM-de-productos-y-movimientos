Imports System.Data.SqlClient
Public Class frmBuscarAgrup

    Dim g_format As String
    Dim g_validarDatos As Boolean
    Private Sub frmBuscarAgrup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        g_format = "00000-"
        g_validarDatos = False
        Me.txtBuscar.Text = ""
        Me.ListBox1.Items.Clear()
        Me.txtBuscar.Focus()
        buscar()
    End Sub

    Private Sub buscar()
        Me.ListBox1.Items.Clear()
        On Error GoTo errores
        Dim Rs As SqlDataReader
        Dim consulta As String = ""
        sql = "select *  from agrupacion ORDER BY [ID agrupacion]"
        instruccion = New SqlCommand(sql, daoCon)
        Rs = instruccion.ExecuteReader()
        While Rs.Read
            consulta = Format(Rs(0), g_format) & Rs(1)
            If fn_validarConsulta(consulta) Then
                Me.ListBox1.Items.Add(Format(Rs(0), g_format) & Rs(1))
            End If
        End While
        Rs.Close()
        Exit Sub
errores:
        MsgBox(Err.Description)
        Exit Sub

    End Sub

    Private Function fn_validarConsulta(consulta As String) As Boolean
        consulta = UCase(consulta)
        If consulta.IndexOf(UCase(Me.txtBuscar.Text)) <> -1 Then
            Return True
        End If
        Return False
    End Function

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        buscar()
    End Sub

    Private Sub pasarDatos()
        frmAgrupaciones.txtCodigo.Text = Val(Me.ListBox1.SelectedItem.ToString)
        frmAgrupaciones.txtNombre.Text = Trim(Mid(Me.ListBox1.SelectedItem.ToString, 7, Len(Me.ListBox1.SelectedItem.ToString)))

    End Sub

    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles ListBox1.DoubleClick
        validarItem()
        Me.txtBuscar.Focus()

        If g_validarDatos Then
            pasarDatos()
            Me.Close()
        End If

    End Sub

    Private Sub frmBuscarAgrup_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If g_validarDatos Then
            frmAgrupaciones.tsmAgregar.Enabled = False
            frmAgrupaciones.tsmEliminar.Enabled = True
            frmAgrupaciones.tsmModificar.Enabled = True
        Else
            frmAgrupaciones.LimpToolStripMenuItem.PerformClick()
        End If
    End Sub

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
End Class