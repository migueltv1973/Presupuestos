Imports MySql.Data.MySqlClient
Module actualizar
    Public Function actualizarEvento(ByVal operacion As Integer, ByVal id_factura As String, ByVal fec_desde As Date, ByVal fec_hasta As Date, ByVal fec_produccion As Date _
                                          , ByVal cod_cliente As String, ByVal cod_sucursal As String, ByVal cod_contacto As String, ByVal cod_postventa As String _
                                          , ByVal cod_evento As String, ByVal cod_salon As String, ByVal cod_estado As String, ByVal nom_evento As String _
                                          , ByVal num_adultos As Integer, ByVal num_ninos As Integer, ByVal obs As String, ByVal adicional As Boolean) As Boolean
        Dim clConex As MySqlConnection = Conexion.obtenerConexion
        Dim com As New MySqlCommand
        com.Connection = clConex
        Dim mfecha1 As String = fec_desde.ToString("yy-MM-dd HH:mm:ss")
        Dim mfecha2 As String = fec_hasta.ToString("yy-MM-dd HH:mm:ss")
        Dim mfecha3 As String = fec_produccion.ToString("yy-MM-dd HH:mm:ss")
        Dim cad, cad1, cad2 As String, result As Integer
        cad1 = "update reservas set id_factura = '" & id_factura & "', fec_ini='" & mfecha1 & "',fec_fin='" & mfecha2 & "',fec_produccion='" & mfecha3 & "',esAdicional=" & adicional & "," _
                   & " cod_cliente='" & cod_cliente & "', cod_sucursal ='" & cod_sucursal & "', cod_contacto='" & cod_contacto & "', cod_postventa='" & cod_postventa & "',cod_evento='" & cod_evento & "'," _
                   & " cod_salon='" & cod_salon & "',cod_estado='" & cod_estado & "',nom_evento= '" & nom_evento & "',num_adultos= " & num_adultos & ",num_ninos= " & num_ninos & ",obs='" & obs & "'"
        cad2 = " where operacion=" & operacion
        cad = cad1 + cad2
        com.CommandText = cad
        result = com.ExecuteNonQuery
        clConex.Close()
        Return result
    End Function

    Public Function actualizarnumFactura(ByVal num_orden As String, ByVal num_factura As String) As Boolean
        Dim clConex As MySqlConnection = Conexion.obtenerConexion
        Dim com As New MySqlCommand
        com.Connection = clConex
        Dim cad, cad1, cad2 As String, result As Integer
        cad1 = "update reservas set num_factura = '" & num_factura & "'"
        cad2 = " where cod_estado='9102' and num_orden='" & num_orden & "'"

        cad = cad1 + cad2
        com.CommandText = cad
        result = com.ExecuteNonQuery
        clConex.Close()
        Return result
    End Function

    Public Function actualizarnumorden(ByVal id_factura As String, ByVal fecha As Date, ByVal num_orden As String) As Boolean
        Dim clConex As MySqlConnection = Conexion.obtenerConexion
        Dim com As New MySqlCommand
        com.Connection = clConex
        Dim cad, cad1, cad2 As String, result As Integer
        Dim mfecha1 As String = fecha.ToString("yyyy-MM-dd")
        cad1 = "update reservas set num_orden = '" & num_orden & "'"
        cad2 = " where cod_estado='9102' and id_factura='" & id_factura & "' and date(fec_ini)='" & mfecha1 & "'"

        cad = cad1 + cad2
        com.CommandText = cad
        result = com.ExecuteNonQuery
        clConex.Close()
        Return result
    End Function

    Public Function actualizar_eliminanumorden(ByVal num_orden As String) As Boolean
        Dim clConex As MySqlConnection = Conexion.obtenerConexion
        Dim com As New MySqlCommand
        com.Connection = clConex
        Dim cad, cad1, cad2 As String, result As Integer

        cad1 = "update reservas set num_orden = '',num_factura='',usu_mod='" & pCuentaUser & "'"
        cad2 = " where num_orden='" & num_orden & "'"

        cad = cad1 + cad2
        com.CommandText = cad
        result = com.ExecuteNonQuery
        clConex.Close()
        Return result
    End Function
    Public Function actualizarCliente(ByVal cod_clie As String, ByVal nom_clie As String, ByVal raz_soc As String, ByVal dir_clie As String, _
                        ByVal dir_ent As String, ByVal nom_cont As String, ByVal fono_clie As String, ByVal email As String, ByVal cod_tipo As String, ByVal activo As Integer) As Boolean
        Dim clConex As MySqlConnection = Conexion.obtenerConexion
        Dim com As New MySqlCommand
        com.Connection = clConex
        Dim cad, cad1, cad2 As String, result As Integer
        cad1 = "update cliente set nom_clie='" & nom_clie & "',raz_soc='" & raz_soc & "',dir_clie='" & dir_clie & "',dir_ent='" & dir_ent & "'," _
                   & " nom_cont='" & nom_cont & "',fono_clie='" & fono_clie & "',email_clie='" & email & "',cod_tipo= '" & cod_tipo & "',activo= '" & activo & "'"
        cad2 = " where cod_clie='" & cod_clie & "'"
        cad = cad1 + cad2
        com.CommandText = cad
        result = com.ExecuteNonQuery
        clConex.Close()
        Return result
    End Function


    Public Function actualizarEvento_det(ByVal operacion As Integer, ByVal ingreso As Integer, ByVal cant As Decimal, ByVal cant_prod As Decimal,
                                         ByVal precio As Decimal, ByVal obs As String) As Boolean
        Dim clConex As MySqlConnection = Conexion.obtenerConexion
        Dim com As New MySqlCommand
        com.Connection = clConex
        Dim cad, cad1, cad2 As String, result As Integer
        cad1 = "update reservas_det set cant=" & cant & ",cant_prod= " & cant_prod & ",precio= " & precio & ",obs='" & obs & "'"
        cad2 = " where operacion=" & operacion & " and ingreso=" & ingreso
        cad = cad1 + cad2
        com.CommandText = cad
        result = com.ExecuteNonQuery
        clConex.Close()
        Return result
    End Function

    Public Function actualizar_Contacto(ByVal cod_contacto As String, ByVal obs As String) As Boolean
        Dim clConex As MySqlConnection = Conexion.obtenerConexion
        Dim com As New MySqlCommand
        com.Connection = clConex
        Dim cad, cad1, cad2 As String, result As Integer
        cad1 = " update cliente_contacto set obs_contacto='" & obs & "'"
        cad2 = " where cod_contacto='" & cod_contacto & "'"
        cad = cad1 + cad2
        com.CommandText = cad
        result = com.ExecuteNonQuery
        clConex.Close()
        Return result
    End Function

    Public Function actualizar_codpostventa(ByVal operacion As Integer, ByVal cod_postventa As String) As Boolean
        Dim clConex As MySqlConnection = Conexion.obtenerConexion
        Dim com As New MySqlCommand
        com.Connection = clConex
        Dim cad, cad1, cad2 As String, result As Integer
        cad1 = " update reservas set cod_postventa='" & cod_postventa & "'"
        cad2 = " where operacion=" & operacion
        cad = cad1 + cad2
        com.CommandText = cad
        result = com.ExecuteNonQuery
        clConex.Close()
        Return result
    End Function

End Module
