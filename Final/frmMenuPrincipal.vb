Imports System.Data.SqlClient
Imports System.Net.NetworkInformation

Public Class frmMenuPrincipal

    Dim g_stock As Long
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conectarBase()
        g_stock = 0
        calcularStock()
        verificarInternet()
    End Sub

    Private Sub frmMenuPrincipal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        daoCon.Close()
    End Sub

    Private Sub btnAgrupacion_Click(sender As Object, e As EventArgs) Handles btnAgrupacion.Click
        frmAgrupaciones.Show()
    End Sub

    Private Sub AgrupacionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgrupacionToolStripMenuItem.Click
        frmAgrupaciones.Show()
    End Sub

    Private Sub btnTipoMov_Click(sender As Object, e As EventArgs) Handles btnTipoMov.Click
        frmTipoMov.Show()
    End Sub

    Private Sub TipoDeMovimientoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TipoDeMovimientoToolStripMenuItem.Click
        frmTipoMov.Show()
    End Sub

    Private Sub ArticuloToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArticuloToolStripMenuItem.Click
        frmArticulos.Show()
    End Sub

    Private Sub btnArticulos_Click(sender As Object, e As EventArgs) Handles btnArticulos.Click
        frmArticulos.Show()
    End Sub

    Private Sub btnMovCant_Click(sender As Object, e As EventArgs) Handles btnMovCant.Click
        frmMovimientos.Show()
    End Sub

    Private Sub MovimientosDeCantidadesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MovimientosDeCantidadesToolStripMenuItem.Click
        frmMovimientos.Show()
    End Sub

    Private Sub calcularStock()
        On Error GoTo errores
        g_stock = 0
        Dim Rs As SqlDataReader
        Dim consulta As String = ""
        sql = "select t.[tip tipomovi], m.[pre movimiento] from movimiento m inner join tipomovi t on t.[ID tipomovi] = m.[ID tipomovi] ORDER BY [ID movimiento]"
        instruccion = New SqlCommand(sql, daoCon)
        Rs = instruccion.ExecuteReader()
        While Rs.Read


            If Rs(0) = "E" Then
                g_stock = g_stock + Rs(1)
            Else
                g_stock = g_stock - Rs(1)
            End If
        End While
        Rs.Close()
        lblValorStock.Text = g_stock
        Exit Sub
errores:
        MsgBox(Err.Description)
        Rs.Close()
        Exit Sub
    End Sub

    Private Sub InformesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InformesToolStripMenuItem.Click
        frmInforme.Show()
    End Sub

    Private Sub verificarInternet()

        If My.Computer.Network.IsAvailable() Then
            Try

                If My.Computer.Network.Ping("www.google.es", 1000) Then
                    Me.tlsInternet.Text = "Tenes internet"
                Else
                    Me.tlsInternet.Text = "Error al conectarse a internet"
                End If

            Catch ex As PingException
                Me.tlsInternet.Text = "Error al conectarse a internet"
            End Try

        Else
            Me.tlsInternet.Text = "No tenes internet"
        End If
    End Sub
End Class
