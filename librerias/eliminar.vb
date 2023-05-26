Imports MySql.Data.MySqlClient
Module eliminar
    Public Function eliminaEvento(ByVal operacion As Integer) As Boolean
        Dim clConex As MySqlConnection = Conexion.obtenerConexion
        Dim com As New MySqlCommand
        com.Connection = clConex
        Dim sql As String, result As Integer
        sql = "delete from reservas where operacion=" & operacion
        com.CommandText = sql
        result = com.ExecuteNonQuery
        clConex.Close()
        Return result
    End Function
    Public Function eliminaEvento_det(ByVal operacion As Integer, ByVal ingreso As Integer) As Boolean
        Dim clConex As MySqlConnection = Conexion.obtenerConexion
        Dim com As New MySqlCommand
        com.Connection = clConex
        Dim sql As String, result As Integer
        sql = "delete from reservas_det where operacion=" & operacion & " and ingreso= " & ingreso
        com.CommandText = sql
        result = com.ExecuteNonQuery
        clConex.Close()
        Return result
    End Function


End Module
