Imports MySql.Data.MySqlClient
Module insertar
    Public Function insertarEvento(ByVal operacion As Integer, ByVal cod_reserva As String, ByVal id_factura As String, ByVal fec_desde As Date, ByVal fec_hasta As Date, ByVal fec_produccion As Date _
                                          , ByVal cod_cliente As String, ByVal cod_sucursal As String, ByVal cod_contacto As String, ByVal cod_postventa As String _
                                          , ByVal cod_evento As String, ByVal cod_salon As String, ByVal cod_vendedor As String, ByVal cod_estado As String, ByVal nom_evento As String _
                                          , ByVal num_adultos As Integer, ByVal num_ninos As Integer, ByVal obs As String, ByVal usuario As String, ByVal adicional As Boolean) As Boolean
        Dim clConex As MySqlConnection = Conexion.obtenerConexion
        Dim com As New MySqlCommand
        com.Connection = clConex
        Dim sql As String, result As Integer
        Dim mfecha1 As String = fec_desde.ToString("yy-MM-dd HH:mm:ss")
        Dim mfecha2 As String = fec_hasta.ToString("yy-MM-dd HH:mm:ss")
        Dim mfecha3 As String = fec_produccion.ToString("yy-MM-dd HH:mm:ss")
        sql = "Insert Into reservas(operacion,cod_reserva,id_factura,fec_ini, fec_fin, fec_produccion,cod_cliente,cod_sucursal,cod_contacto,cod_postventa,cod_evento,cod_salon,cod_vend,cod_estado,nom_evento,num_adultos,num_ninos,obs,usuario,esAdicional)" &
                "values(" & operacion & ",'" & cod_reserva & "','" & id_factura & "','" &
        mfecha1 & "','" & mfecha2 & "','" & mfecha3 & "','" & cod_cliente & "','" & cod_sucursal & "','" & cod_contacto & "','" & cod_postventa & "','" & cod_evento & "','" & cod_salon & "','" & cod_vendedor & "','" & cod_estado & "','" & nom_evento & "'," & num_adultos & "," & num_ninos & ",'" & obs & "','" & usuario & "'," & adicional & ")"
        com.CommandText = sql
        result = com.ExecuteNonQuery
        clConex.Close()
        Return result
    End Function

    Public Function insertarEvento_det(ByVal operacion As Integer, ByVal ingreso As Integer, ByVal cod_recurso As String _
                                      , ByVal cant As Decimal, ByVal cant_prod As Decimal, ByVal precio As Decimal _
                                      , ByVal obs As String, ByVal c_aux1 As String, ByVal n_aux1 As Integer) As Boolean
        Dim clConex As MySqlConnection = Conexion.obtenerConexion
        Dim com As New MySqlCommand
        com.Connection = clConex
        Dim sql As String, result As Integer
        sql = "Insert Into reservas_det(operacion, ingreso,cod_recurso,cant,cant_prod,precio,obs,c_aux1,n_aux1)" &
                "values(" & operacion & "," & ingreso & ",'" &
                cod_recurso & "'," & cant & "," & cant_prod & "," & precio & ",'" & obs & "','" & c_aux1 & "'," & n_aux1 & ")"
        com.CommandText = sql
        result = com.ExecuteNonQuery
        clConex.Close()
        Return result
    End Function
    Public Function insertarCliente(ByVal cod_clie As String, _
                            ByVal nom_clie As String, _
                            ByVal raz_soc As String, _
                            ByVal dir_clie As String, _
                            ByVal dir_ent As String, _
                            ByVal nom_cont As String, _
                            ByVal fono_clie As String, _
                            ByVal email As String, _
                            ByVal cod_tipo As String, _
                            ByVal activo As Integer) As Boolean
        Dim clConex As MySqlConnection = Conexion.obtenerConexion
        Dim com As New MySqlCommand
        com.Connection = clConex
        Dim sql As String, result As Integer
        sql = "Insert Into cliente(cod_clie,nom_clie,raz_soc,dir_clie,dir_ent,nom_cont,fono_clie,email_clie,cod_tipo,activo)" & _
            "values('" & _
            cod_clie & "','" & nom_clie & "','" & raz_soc & "','" & dir_clie & "','" & dir_ent & "','" & nom_cont & "','" & fono_clie & "','" & email & "','" & cod_tipo & "'," & activo & ")"
        com.CommandText = sql
        result = com.ExecuteNonQuery
        clConex.Close()
        Return result
    End Function

End Module
