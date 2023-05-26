Imports MySql.Data.MySqlClient
Imports System.Configuration
'Imports libreriaseguridad
Public Class Conexion
    Public Shared Function obtenerConexion() As MySqlConnection
        'Const BaseDatos As String = "rosanautica"
        'Const Servidor As String = "12.100.10.12"
        Try
            Dim servidor As String = ConfigurationManager.AppSettings("Servidor").ToString
            Dim basedatos As String = ConfigurationManager.AppSettings("BaseDatos").ToString
            ' Dim licencia As String = ConfigurationManager.AppSettings("licencia").ToString

            Dim conex As String = "User Id=custom;password=P4nt3r4--;server=" & servidor & ";database=" & basedatos &
              ";Convert Zero Datetime=True;persist security info=True;use procedure bodies=False;Connection Timeout=300 ; pooling=true; Max Pool Size=300"

            ' Dim cifrado As String = seguridad.Cifrado(1, 4, licencia, "password12345678", "password12345678")

            Dim ConexBD As New MySqlConnection(conex)
            If ConexBD.State = ConnectionState.Open Then
                ConexBD.Close()
            End If
            ConexBD.Open()
            'If (seguridad.Cifrado(2, 4, licencia, "password12345678", "password12345678") <> servidor & basedatos) Then
            '    ConexBD.Close()
            'End If
            Return ConexBD
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Shared Function obtenerConexionODBC() As Odbc.OdbcConnection
        Const conex As String = "Dsn=micros;uid=dba;pwd=micros3700;"
        Dim conexBD As New Odbc.OdbcConnection(conex)
        Try
            conexBD.Open()
            Return conexBD
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
End Class

''Dim Encontro As Boolean = False
'Dim DireccionRelativa, DireccionCompleta As String
'' obtiene el path relativo de la aplicación. 
'DireccionRelativa = System.IO.Directory.GetCurrentDirectory()
'DireccionCompleta = DireccionRelativa + "\configuracion.ini"
'Dim objReader As New IO.StreamReader(DireccionCompleta)
'Dim sLine As String = ""
'Dim arrText As New ArrayList()
'Do
'    sLine = objReader.ReadLine()
'    If Not sLine Is Nothing Then
'        arrText.Add(sLine)
'    End If
'Loop Until sLine Is Nothing
'objReader.Close()
'Servidor = arrText(1)
'BaseDatos = arrText(2)