Imports System.Data.SqlClient
Module Module1
    Public daoCon As SqlConnection
    Public sql As String
    Public instruccion As SqlCommand

    Sub conectarBase()
        On Error GoTo errores
        Dim servidor As String = "Ingrese el dns"
        Dim base As String = "Ingrese contraseña de la BD"
        daoCon = New SqlConnection("server=" & servidor & ";database=" & base & ";User ID=sa;Password=Ingrese contraseña del usuario")
        daoCon.Open()
        Exit Sub
errores:
        MsgBox("No se pudo conectar a la base de datos")
        'MsgBox(Err.Description)
        End
        Exit Sub
    End Sub
    Sub ContarAgrupacion(codigo As Long)
        Dim RS2 As SqlDataReader
        Dim Instruccion2 As SqlCommand
        sql = "SELECT COUNT(*) FROM agrupacion WHERE [ID agrupacion] = " & codigo
        Instruccion2 = New SqlCommand(sql, daoCon)
        RS2 = Instruccion2.ExecuteReader()
        RS2.Read()
        If RS2(0) <> 0 Then

        End If

        RS2.Close()

    End Sub
End Module
