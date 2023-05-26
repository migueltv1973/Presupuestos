Imports MySql.Data.MySqlClient
Module consultas
    Public Function recuperaconsulta(ByVal h As Boolean, ByVal pr As String, ByVal op As Integer) As DataSet
        Dim clConex As New MySqlConnection
        Dim da As New MySqlDataAdapter
        Dim ds As New DataSet
        clConex = Conexion.obtenerConexion
        Dim cad As String
        cad = "select * from reservas"
        Dim com As New MySqlCommand(cad)
        com.Connection = clConex
        da.SelectCommand = com
        da.Fill(ds, "cabecera")
        clConex.Close()
        Return ds
    End Function
    Public Function recupera_ordencompra(ByVal orden As String) As DataSet
        Dim clConex As New MySqlConnection
        Dim da As New MySqlDataAdapter
        Dim ds As New DataSet
        clConex = Conexion.obtenerConexion
        Dim cad1, cad2, cad3, cad As String

        cad1 = " select id_factura,date(fec_ini) fecha,sum(precio*cant) as importe,r.operacion,num_factura from reservas r " _
             & " inner join reservas_det rd on r.operacion=rd.operacion "
        cad2 = " where num_factura like  '%" & orden & "%' and cod_estado='9102' group by id_factura, date(fec_ini)"
        cad3 = " order by Date(fec_ini), id_factura"
        cad = cad1 + cad2 + cad3
        Dim com As New MySqlCommand(cad)
        com.Connection = clConex
        da.SelectCommand = com
        da.Fill(ds, "dt")
        clConex.Close()
        Return ds
    End Function
    Public Function recupera_idfactura() As DataSet
        Dim clConex As New MySqlConnection
        Dim da As New MySqlDataAdapter
        Dim ds As New DataSet
        clConex = Conexion.obtenerConexion
        Dim cad1, cad2, cad3, cad As String

        cad1 = " select r.operacion,id_factura,date(fec_ini) fecha,sum(precio*cant) as importe from reservas r " _
             & " inner join reservas_det rd on r.operacion=rd.operacion "
        cad2 = " where LENGTH(num_orden)=0 and cod_estado='9102' group by id_factura, date(fec_ini) "
        cad3 = " order by Date(fec_ini), id_factura"
        cad = cad1 + cad2 + cad3
        Dim com As New MySqlCommand(cad)
        com.Connection = clConex
        da.SelectCommand = com
        da.Fill(ds, "eventos")
        clConex.Close()
        Return ds
    End Function

    Public Function recupera_idfactura2() As DataSet
        Dim clConex As New MySqlConnection
        Dim da As New MySqlDataAdapter
        Dim ds As New DataSet
        clConex = Conexion.obtenerConexion
        Dim cad1, cad2, cad3, cad As String

        cad1 = " select id_factura,date(fec_ini) fecha,sum(precio*cant) as importe from reservas r " _
             & " inner join reservas_det rd on r.operacion=rd.operacion "
        cad2 = " where id_factura=9999999 and cod_estado='9102' group by id_factura, date(fec_ini)"
        cad3 = " order by Date(fec_ini), id_factura"
        cad = cad1 + cad2 + cad3
        Dim com As New MySqlCommand(cad)
        com.Connection = clConex
        da.SelectCommand = com
        da.Fill(ds, "eventos")
        clConex.Close()
        Return ds
    End Function
    Public Function recuperaevento_BEO(ByVal operacion As Integer, ByVal estado As Boolean) As DataSet
        Dim clConex As New MySqlConnection
        Dim da As New MySqlDataAdapter
        Dim ds As New DataSet
        clConex = Conexion.obtenerConexion
        Dim cad1, cad2, cad3, cad As String
        cad1 = "Select r.operacion,SUBSTRING(cod_reserva,12,2) As fila,Date(r.fec_ini) fecha_atencion,num_contrato,r5.dsc_recurso As ESTADO," _
             & " nom_evento,r1.dsc_recurso As nom_salon,r2.dsc_recurso As tip_evento,r3.dsc_recurso As vendedor,time(fec_ini) As hor_ini,time(fec_produccion) As hor_prod, " _
             & " c.nom_clie As nom_cliente,cs.dir_sucursal As nom_unidad,cc.nom_contacto,cc.fono_contacto,cc.email_contacto,r.num_adultos As num_pax,cant,r4.dsc_recurso,dsc_tabla As dsc_grupo,r.obs As notas,rd.obs As notas_det, " _
             & " rd.precio,r.cod_reserva,r.id_factura,cant*precio As imp_total" _
             & " from reservas r inner join reservas_det rd On r.operacion=rd.operacion " _
             & " left join tipo_recurso r1 On r.cod_salon=r1.cod_recurso" _
             & " left join tipo_recurso r2 On r.cod_evento=r2.cod_recurso" _
             & " left join tipo_recurso r3 On r.cod_vend=r3.c_aux" _
             & " left join tipo_recurso r5 On r.cod_estado=r5.cod_recurso" _
             & " inner join tipo_recurso r4 On rd.cod_recurso=r4.cod_recurso" _
             & " inner join tipo_tabla t On r4.cod_tabla=t.cod_tabla" _
             & " left join cliente c On r.cod_cliente=c.cod_clie" _
             & " left join cliente_contacto cc On r.cod_contacto=cc.cod_contacto" _
             & " left join cliente_sucursal cs On r.cod_sucursal=cs.cod_sucursal" _
             & " where  r.operacion= " & operacion _
             & IIf(estado, " And r5.n_aux=1 ", "")
        cad2 = " union Select r.operacion,SUBSTRING(cod_reserva,12,2) As fila,Date(r.fec_ini) fecha_atencion,num_contrato,r5.dsc_recurso As ESTADO," _
             & " nom_evento,r1.dsc_recurso As nom_salon,r2.dsc_recurso As tip_evento,r3.dsc_recurso As vendedor,time(fec_ini) As hor_ini,time(fec_produccion) As hor_prod, " _
             & " c.nom_clie As nom_cliente,cs.dir_sucursal As nom_unidad,cc.nom_contacto,cc.fono_contacto,cc.email_contacto,r.num_adultos As num_pax,cant,a.nom_Art As dsc_recurso,'ALIMENTOS' as dsc_grupo,r.obs as notas,rd.obs as notas_det, " _
             & " rd.precio,r.cod_reserva,r.id_factura,cant*precio as imp_total" _
             & " from reservas r inner join reservas_det rd on r.operacion=rd.operacion " _
             & " left join tipo_recurso r1 on r.cod_salon=r1.cod_recurso" _
             & " left join tipo_recurso r2 on r.cod_evento=r2.cod_recurso" _
             & " left join tipo_recurso r3 on r.cod_vend=r3.c_aux" _
             & " left join tipo_recurso r5 on r.cod_estado=r5.cod_recurso" _
             & " inner join articulo a on rd.cod_recurso=a.cod_art" _
             & " inner join subgrupo s on s.cod_sgrupo=a.cod_sgrupo" _
             & " inner join grupo g on g.cod_grupo=s.cod_grupo" _
             & " left join cliente c on r.cod_cliente=c.cod_clie left join art_combo ac on ac.cod_art=a.cod_art" _
             & " left join cliente_contacto cc on r.cod_contacto=cc.cod_contacto" _
             & " left join cliente_sucursal cs on r.cod_sucursal=cs.cod_sucursal" _
              & " where rd.n_aux1=0 and r.operacion= " & operacion _
             & IIf(estado, " and r5.n_aux=1 ", "")
        cad3 = " union select r.operacion,SUBSTRING(cod_reserva,12,2) as fila,date(r.fec_ini) fecha_Atencion,num_contrato,r5.dsc_recurso as ESTADO," _
             & " nom_evento,r1.dsc_recurso as nom_salon,r2.dsc_recurso as tip_evento,r3.dsc_recurso as vendedor,time(fec_ini) as hor_ini,time(fec_produccion) as hor_prod, " _
             & " c.nom_clie as nom_cliente,cs.dir_sucursal as nom_unidad,cc.nom_contacto,cc.fono_contacto,cc.email_contacto,r.num_adultos as num_pax,cant,a.nom_Art as dsc_recurso,'PAQUETES' as dsc_grupo,r.obs as notas,rd.obs as notas_det, " _
             & " rd.precio,r.cod_reserva,r.id_factura,cant*precio as imp_total" _
             & " from reservas r inner join reservas_det rd on r.operacion=rd.operacion " _
             & " left join tipo_recurso r1 on r.cod_salon=r1.cod_recurso" _
             & " left join tipo_recurso r2 on r.cod_evento=r2.cod_recurso" _
             & " left join tipo_recurso r3 on r.cod_vend=r3.c_aux" _
             & " left join tipo_recurso r5 on r.cod_estado=r5.cod_recurso" _
             & " inner join articulo a on rd.cod_recurso=a.cod_art" _
             & " inner join subgrupo s on s.cod_sgrupo=a.cod_sgrupo" _
             & " inner join grupo g on g.cod_grupo=s.cod_grupo" _
             & " left join cliente c on r.cod_cliente=c.cod_clie left join art_combo ac on ac.cod_art=a.cod_art" _
             & " left join cliente_contacto cc on r.cod_contacto=cc.cod_contacto" _
             & " left join cliente_sucursal cs on r.cod_sucursal=cs.cod_sucursal" _
             & " where rd.n_aux1=1 and r.operacion= " & operacion _
             & IIf(estado, " and r5.n_aux=1 ", "") _
             & " order by operacion,fecha_Atencion,hor_prod"

        cad = cad1 + cad2 + cad3
        Dim com As New MySqlCommand(cad)
        com.Connection = clConex
        da.SelectCommand = com
        da.Fill(ds, "eventos")
        clConex.Close()
        Return ds
    End Function

    Public Function recuperaevento_BEO_orden(ByVal orden As String, ByVal estado As Boolean) As DataSet
        Dim clConex As New MySqlConnection
        Dim da As New MySqlDataAdapter
        Dim ds As New DataSet
        clConex = Conexion.obtenerConexion
        Dim cad1, cad2, cad3, cad As String
        cad1 = "Select r.operacion,r.num_orden,r.id_factura,convert(SUBSTRING(cod_reserva,12,2),Integer) As fila,Date(r.fec_ini) fecha_atencion,num_contrato,r5.dsc_recurso As ESTADO," _
             & " nom_evento,r1.dsc_recurso As nom_salon,r2.dsc_recurso As tip_evento,r3.dsc_recurso As vendedor,time(fec_ini) As hor_ini,time(fec_produccion) As hor_prod, " _
             & " c.cod_clie,c.nom_clie As nom_cliente,cs.dir_sucursal As nom_unidad,cc.nom_contacto,cc.fono_contacto,cc.email_contacto,r.num_adultos As num_pax,cant,r4.dsc_recurso,dsc_tabla As dsc_grupo,r.obs As notas,rd.obs As notas_det, " _
             & " rd.precio,r.cod_reserva,r.id_factura,cant*precio As imp_total" _
             & " from reservas r inner join reservas_det rd On r.operacion=rd.operacion " _
             & " left join tipo_recurso r1 On r.cod_salon=r1.cod_recurso" _
             & " left join tipo_recurso r2 On r.cod_evento=r2.cod_recurso" _
             & " left join tipo_recurso r3 On r.cod_vend=r3.c_aux" _
             & " left join tipo_recurso r5 On r.cod_estado=r5.cod_recurso" _
             & " inner join tipo_recurso r4 On rd.cod_recurso=r4.cod_recurso" _
             & " inner join tipo_tabla t On r4.cod_tabla=t.cod_tabla" _
             & " left join cliente c On r.cod_cliente=c.cod_clie" _
             & " left join cliente_contacto cc On r.cod_contacto=cc.cod_contacto" _
             & " left join cliente_sucursal cs On r.cod_sucursal=cs.cod_sucursal" _
             & " where  r.num_factura= '" & orden & "'" _
             & IIf(estado, " And r5.n_aux=1 ", "")
        cad2 = " union Select r.operacion,r.num_orden,r.id_factura,convert(SUBSTRING(cod_reserva,12,2),Integer) As fila,Date(r.fec_ini) fecha_atencion,num_contrato,r5.dsc_recurso As ESTADO," _
             & " nom_evento,r1.dsc_recurso As nom_salon,r2.dsc_recurso As tip_evento,r3.dsc_recurso As vendedor,time(fec_ini) As hor_ini,time(fec_produccion) As hor_prod, " _
             & " c.cod_clie,c.nom_clie As nom_cliente,cs.dir_sucursal As nom_unidad,cc.nom_contacto,cc.fono_contacto,cc.email_contacto,r.num_adultos As num_pax,cant,a.nom_Art As dsc_recurso,'ALIMENTOS' as dsc_grupo,r.obs as notas,rd.obs as notas_det, " _
             & " rd.precio,r.cod_reserva,r.id_factura,cant*precio as imp_total" _
             & " from reservas r inner join reservas_det rd on r.operacion=rd.operacion " _
             & " left join tipo_recurso r1 on r.cod_salon=r1.cod_recurso" _
             & " left join tipo_recurso r2 on r.cod_evento=r2.cod_recurso" _
             & " left join tipo_recurso r3 on r.cod_vend=r3.c_aux" _
             & " left join tipo_recurso r5 on r.cod_estado=r5.cod_recurso" _
             & " inner join articulo a on rd.cod_recurso=a.cod_art" _
             & " inner join subgrupo s on s.cod_sgrupo=a.cod_sgrupo" _
             & " inner join grupo g on g.cod_grupo=s.cod_grupo" _
             & " left join cliente c on r.cod_cliente=c.cod_clie left join art_combo ac on ac.cod_art=a.cod_art" _
             & " left join cliente_contacto cc on r.cod_contacto=cc.cod_contacto" _
             & " left join cliente_sucursal cs on r.cod_sucursal=cs.cod_sucursal" _
              & " where rd.n_aux1=0 and r.num_factura= '" & orden & "'" _
             & IIf(estado, " and r5.n_aux=1 ", "")
        cad3 = " union select r.operacion,r.num_orden,r.id_factura,convert(SUBSTRING(cod_reserva,12,2),integer) as fila,date(r.fec_ini) fecha_Atencion,num_contrato,r5.dsc_recurso as ESTADO," _
             & " nom_evento,r1.dsc_recurso as nom_salon,r2.dsc_recurso as tip_evento,r3.dsc_recurso as vendedor,time(fec_ini) as hor_ini,time(fec_produccion) as hor_prod, " _
             & " c.cod_clie,c.nom_clie as nom_cliente,cs.dir_sucursal as nom_unidad,cc.nom_contacto,cc.fono_contacto,cc.email_contacto,r.num_adultos as num_pax,cant,a.nom_Art as dsc_recurso,'PAQUETES' as dsc_grupo,r.obs as notas,rd.obs as notas_det, " _
             & " rd.precio,r.cod_reserva,r.id_factura,cant*precio as imp_total" _
             & " from reservas r inner join reservas_det rd on r.operacion=rd.operacion " _
             & " left join tipo_recurso r1 on r.cod_salon=r1.cod_recurso" _
             & " left join tipo_recurso r2 on r.cod_evento=r2.cod_recurso" _
             & " left join tipo_recurso r3 on r.cod_vend=r3.c_aux" _
             & " left join tipo_recurso r5 on r.cod_estado=r5.cod_recurso" _
             & " inner join articulo a on rd.cod_recurso=a.cod_art" _
             & " inner join subgrupo s on s.cod_sgrupo=a.cod_sgrupo" _
             & " inner join grupo g on g.cod_grupo=s.cod_grupo" _
             & " left join cliente c on r.cod_cliente=c.cod_clie left join art_combo ac on ac.cod_art=a.cod_art" _
             & " left join cliente_contacto cc on r.cod_contacto=cc.cod_contacto" _
             & " left join cliente_sucursal cs on r.cod_sucursal=cs.cod_sucursal" _
             & " where rd.n_aux1=1 and r.num_factura= '" & orden & "'" _
             & IIf(estado, " and r5.n_aux=1 ", "") _
             & " order by operacion,fecha_Atencion,hor_prod"

        cad = cad1 + cad2 + cad3
        Dim com As New MySqlCommand(cad)
        com.Connection = clConex
        da.SelectCommand = com
        da.Fill(ds, "eventos")
        clConex.Close()
        Return ds
    End Function

    Public Function recuperaevento_xfecha(ByVal fechaInicio As Date, ByVal fechaFinal As Date, ByVal estado As Boolean, ByVal esadicional As Boolean) As DataSet
        Dim clConex As New MySqlConnection
        Dim da As New MySqlDataAdapter
        Dim ds As New DataSet
        clConex = Conexion.obtenerConexion
        Dim cad1, cad2, cad3, cad As String
        Dim mfechaI As String = fechaInicio.ToString("yyyy-MM-dd")
        Dim mfechaF As String = fechaFinal.ToString("yyyy-MM-dd")
        cad1 = "select r.operacion,ingreso,SUBSTRING(cod_reserva,12,2) as fila,date(r.fec_ini) fecha_atencion,num_contrato,r5.dsc_recurso as ESTADO,r6.dsc_recurso as POSTVENTA," _
             & " nom_evento,r1.dsc_recurso As nom_salon,r2.dsc_recurso As tip_evento,r3.dsc_recurso As vendedor,time(fec_ini) as hor_ini,time(fec_produccion) as hor_prod, " _
             & " c.nom_clie As nom_cliente,cs.dir_sucursal as nom_unidad,cc.nom_contacto,cc.fono_contacto,cc.email_contacto,r.num_adultos As num_pax,cant,cant_prod,r4.dsc_recurso,dsc_tabla As dsc_grupo,r.obs As notas,rd.obs As notas_det, " _
             & " rd.precio,r.cod_reserva,r.id_factura,cant*precio as imp_total,t.tip_recurso,num_orden,num_factura" _
             & " from reservas r inner join reservas_det rd on r.operacion=rd.operacion " _
             & " left join tipo_recurso r1 on r.cod_salon=r1.cod_recurso" _
             & " left join tipo_recurso r2 on r.cod_evento=r2.cod_recurso" _
             & " left join tipo_recurso r6 on r.cod_postventa=r6.cod_recurso" _
             & " left join tipo_recurso r3 on r.cod_vend=r3.c_aux" _
             & " left join tipo_recurso r5 on r.cod_estado=r5.cod_recurso" _
             & " left join tipo_recurso r4 on rd.cod_recurso=r4.cod_recurso" _
             & " inner join tipo_tabla t on r4.cod_tabla=t.cod_tabla" _
             & " left join cliente c on r.cod_cliente=c.cod_clie" _
             & " left join cliente_contacto cc on r.cod_contacto=cc.cod_contacto" _
             & " left join cliente_sucursal cs on r.cod_sucursal=cs.cod_sucursal" _
             & " where date(fec_ini)>='" & mfechaI & "'" & " and date(fec_ini)<='" & mfechaF & "'" _
             & IIf(estado, " and r5.n_aux=1 ", "") _
             & IIf(esadicional, " and r.esAdicional=1 ", "")
        cad2 = " union select r.operacion,ingreso,SUBSTRING(cod_reserva,12,2) as fila,date(r.fec_ini) fecha_atencion,num_contrato,r5.dsc_recurso as ESTADO,r6.dsc_recurso as POSTVENTA," _
             & " nom_evento,r1.dsc_recurso as nom_salon,r2.dsc_recurso as tip_evento,r3.dsc_recurso as vendedor,time(fec_ini) as hor_ini,time(fec_produccion) as hor_prod, " _
             & " c.nom_clie as nom_cliente,cs.dir_sucursal as nom_unidad,cc.nom_contacto,cc.fono_contacto,cc.email_contacto,r.num_adultos as num_pax,cant,cant_prod,a.nom_Art as dsc_recurso,'ALIMENTOS' as dsc_grupo,r.obs as notas,rd.obs as notas_det, " _
             & " rd.precio,r.cod_reserva,r.id_factura,cant*precio as imp_total,s.tip_recurso,num_orden,num_factura" _
             & " from reservas r inner join reservas_det rd on r.operacion=rd.operacion " _
             & " left join tipo_recurso r1 on r.cod_salon=r1.cod_recurso" _
             & " left join tipo_recurso r2 on r.cod_evento=r2.cod_recurso" _
             & " left join tipo_recurso r6 on r.cod_postventa=r6.cod_recurso" _
             & " left join tipo_recurso r3 on r.cod_vend=r3.c_aux" _
             & " left join tipo_recurso r5 on r.cod_estado=r5.cod_recurso" _
             & " inner join articulo a on rd.cod_recurso=a.cod_art" _
             & " inner join subgrupo s on s.cod_sgrupo=a.cod_sgrupo" _
             & " left join grupo g on g.cod_grupo=s.cod_grupo" _
             & " left join cliente c on r.cod_cliente=c.cod_clie left join art_combo ac on ac.cod_art=a.cod_art" _
             & " left join cliente_contacto cc on r.cod_contacto=cc.cod_contacto" _
             & " left join cliente_sucursal cs on r.cod_sucursal=cs.cod_sucursal" _
             & " where rd.n_aux1=0 and date(fec_ini)>='" & mfechaI & "'" & " and date(fec_ini)<='" & mfechaF & "'" _
             & IIf(estado, " and r5.n_aux=1 ", "") _
             & IIf(esadicional, " and r.esAdicional=1 ", "")
        cad3 = " union select r.operacion,ingreso,SUBSTRING(cod_reserva,12,2) as fila,date(r.fec_ini) fecha_Atencion,num_contrato,r5.dsc_recurso as ESTADO,r6.dsc_recurso as POSTVENTA," _
             & " nom_evento,r1.dsc_recurso as nom_salon,r2.dsc_recurso as tip_evento,r3.dsc_recurso as vendedor,time(fec_ini) as hor_ini,time(fec_produccion) as hor_prod, " _
             & " c.nom_clie as nom_cliente,cs.dir_sucursal as nom_unidad,cc.nom_contacto,cc.fono_contacto,cc.email_contacto,r.num_adultos as num_pax,cant,cant_prod,a.nom_Art as dsc_recurso,'PAQUETES' as dsc_grupo,r.obs as notas,rd.obs as notas_det, " _
             & " rd.precio,r.cod_reserva,r.id_factura,cant*precio as imp_total,s.tip_recurso,num_orden,num_factura" _
             & " from reservas r inner join reservas_det rd on r.operacion=rd.operacion " _
             & " left join tipo_recurso r1 on r.cod_salon=r1.cod_recurso" _
             & " left join tipo_recurso r2 on r.cod_evento=r2.cod_recurso" _
             & " left join tipo_recurso r6 on r.cod_postventa=r6.cod_recurso" _
             & " left join tipo_recurso r3 on r.cod_vend=r3.c_aux" _
             & " left join tipo_recurso r5 on r.cod_estado=r5.cod_recurso" _
             & " inner join articulo a on rd.cod_recurso=a.cod_art" _
             & " inner join subgrupo s on s.cod_sgrupo=a.cod_sgrupo" _
             & " left join grupo g on g.cod_grupo=s.cod_grupo" _
             & " left join cliente c on r.cod_cliente=c.cod_clie left join art_combo ac on ac.cod_art=a.cod_art" _
             & " left join cliente_contacto cc on r.cod_contacto=cc.cod_contacto" _
             & " left join cliente_sucursal cs on r.cod_sucursal=cs.cod_sucursal" _
             & " where rd.n_aux1=1 and date(fec_ini)>='" & mfechaI & "'" & " and date(fec_ini)<='" & mfechaF & "'" _
             & IIf(estado, " and r5.n_aux=1 ", "") _
             & IIf(esadicional, " and r.esAdicional=1 ", "") _
             & " order by fecha_Atencion,hor_prod"
        cad = cad1 + cad2 + cad3
        Dim com As New MySqlCommand(cad)
        com.Connection = clConex
        da.SelectCommand = com
        da.Fill(ds, "eventos")
        clConex.Close()
        Return ds
    End Function

    Public Function recuperaevento_test(ByVal fechaInicio As Date, ByVal fechaFinal As Date) As DataSet
        Dim clConex As New MySqlConnection
        Dim da As New MySqlDataAdapter
        Dim ds As New DataSet
        clConex = Conexion.obtenerConexion
        Dim cad1, cad2, cad3, cad As String
        Dim mfechaI As String = fechaInicio.ToString("yyyy-MM-dd")
        Dim mfechaF As String = fechaFinal.ToString("yyyy-MM-dd")
        cad1 = " select r.operacion,convert(SUBSTRING(cod_reserva,12,2),integer) as fila,r.nom_evento As tip_evento" _
             & " from reservas r where date(fec_ini)>='" & mfechaI & "'" & " and date(fec_ini)<='" & mfechaF & "'"
        cad2 = ""
        cad3 = " order by 1"
        cad = cad1 + cad2 + cad3
        Dim com As New MySqlCommand(cad)
        com.Connection = clConex
        da.SelectCommand = com
        da.Fill(ds, "eventos")
        clConex.Close()
        Return ds
    End Function
    Public Function recuperaevento_consolidar(ByVal fechaInicio As Date, ByVal fechaFinal As Date, ByVal estado As Boolean, ByVal xcontacto As Boolean, ByVal cod_contacto As String) As DataSet
        Dim clConex As New MySqlConnection
        Dim da As New MySqlDataAdapter
        Dim ds As New DataSet
        clConex = Conexion.obtenerConexion
        Dim cad1, cad As String
        Dim mfechaI As String = fechaInicio.ToString("yyyy-MM-dd")
        Dim mfechaF As String = fechaFinal.ToString("yyyy-MM-dd")
        cad1 = "select r.cod_reserva,nom_clie as nom_cliente,nom_evento,dir_sucursal,nom_contacto,id_factura," _
             & " date(fec_ini) as fecha_atencion,r.num_adultos as num_pax,r2.dsc_recurso As tip_evento,sum(cant*precio) as imp_total from reservas r " _
             & " inner join reservas_det rd on r.operacion=rd.operacion " _
             & " left join cliente c on c.cod_clie=r.cod_cliente" _
             & " left join cliente_contacto cc on r.cod_contacto=cc.cod_contacto " _
             & " left join cliente_sucursal cs on r.cod_sucursal=cs.cod_sucursal" _
             & " left join tipo_recurso r2 on r.cod_evento=r2.cod_recurso" _
             & " left join tipo_recurso r5 on r.cod_estado=r5.cod_recurso" _
             & " where r.cod_estado='9102' and date(fec_ini)>='" & mfechaI & "'" & " and date(fec_ini)<='" & mfechaF & "'" _
             & IIf(xcontacto, " and r.cod_contacto='" & cod_contacto & "'", "") _
             & IIf(estado, " and r5.n_aux=1 ", "") _
             & " group by r.cod_reserva,nom_clie,nom_evento,dir_sucursal,nom_contacto,date(fec_ini),r.num_adultos,r.cod_evento" _
             & " order by nom_clie,nom_evento,dir_sucursal,nom_contacto,date(fec_ini),r.cod_evento"


        cad = cad1
        Dim com As New MySqlCommand(cad)
        com.Connection = clConex
        da.SelectCommand = com
        da.Fill(ds, "eventos_consolidado")
        clConex.Close()
        Return ds
    End Function

    Public Function recuperaevento_consolidarxid(ByVal fechaInicio As Date, ByVal fechaFinal As Date, ByVal estado As Boolean, ByVal xCliente As Boolean, ByVal cod_cliente As String) As DataSet
        Dim clConex As New MySqlConnection
        Dim da As New MySqlDataAdapter
        Dim ds As New DataSet
        clConex = Conexion.obtenerConexion
        Dim cad1, cad As String
        Dim mfechaI As String = fechaInicio.ToString("yyyy-MM-dd")
        Dim mfechaF As String = fechaFinal.ToString("yyyy-MM-dd")
        cad1 = "select nom_clie as nom_cliente,dir_sucursal,nom_contacto,id_factura, " _
            & " num_orden, num_factura, sum(cant * precio) as imp_total " _
            & " From reservas r inner Join reservas_det rd on r.operacion=rd.operacion " _
            & " Left Join cliente c on c.cod_clie=r.cod_cliente " _
            & " Left Join cliente_contacto cc on r.cod_contacto=cc.cod_contacto " _
            & " Left Join cliente_sucursal cs on r.cod_sucursal=cs.cod_sucursal " _
            & " Left Join tipo_recurso r2 on r.cod_evento=r2.cod_recurso " _
            & " Left Join tipo_recurso r5 on r.cod_estado=r5.cod_recurso " _
            & " where r.cod_estado='9102' and date(fec_ini)>='" & mfechaI & "'" & " and date(fec_ini)<='" & mfechaF & "'" _
            & IIf(xCliente, " and r.cod_cliente='" & cod_cliente & "'", "") _
            & IIf(estado, " and r5.n_aux=1 ", "") _
            & " group by id_factura, num_orden, num_factura, nom_clie, dir_sucursal, nom_contacto" _
            & " order by id_factura, nom_clie, dir_sucursal, nom_contacto, r.cod_evento"
        cad = cad1
        Dim com As New MySqlCommand(cad)
        com.Connection = clConex
        da.SelectCommand = com
        da.Fill(ds, "eventos_consolidado")
        clConex.Close()
        Return ds
    End Function
    Public Function recuperaevento_consolidarxfactura(ByVal fechaInicio As Date, ByVal fechaFinal As Date, ByVal estado As Boolean, ByVal xCliente As Boolean, ByVal cod_cliente As String) As DataSet
        Dim clConex As New MySqlConnection
        Dim da As New MySqlDataAdapter
        Dim ds As New DataSet
        clConex = Conexion.obtenerConexion
        Dim cad1, cad As String
        Dim mfechaI As String = fechaInicio.ToString("yyyy-MM-dd")
        Dim mfechaF As String = fechaFinal.ToString("yyyy-MM-dd")
        cad1 = "select nom_clie as nom_cliente,dir_sucursal,nom_contacto,id_factura, " _
            & " num_orden, num_factura, sum(cant * precio) as imp_total " _
            & " From reservas r inner Join reservas_det rd on r.operacion=rd.operacion " _
            & " Left Join cliente c on c.cod_clie=r.cod_cliente " _
            & " Left Join cliente_contacto cc on r.cod_contacto=cc.cod_contacto " _
            & " Left Join cliente_sucursal cs on r.cod_sucursal=cs.cod_sucursal " _
            & " Left Join tipo_recurso r2 on r.cod_evento=r2.cod_recurso " _
            & " Left Join tipo_recurso r5 on r.cod_estado=r5.cod_recurso " _
            & " where r.cod_estado='9102' and date(fec_ini)>='" & mfechaI & "'" & " and date(fec_ini)<='" & mfechaF & "'" _
            & IIf(xCliente, " and r.cod_cliente='" & cod_cliente & "'", "") _
            & IIf(estado, " and r5.n_aux=1 and LENGTH(num_factura)>0 ", "") _
            & " group by id_factura, num_orden, num_factura, nom_clie, dir_sucursal, nom_contacto" _
            & " order by num_factura, nom_clie, dir_sucursal, nom_contacto, r.cod_evento"
        cad = cad1
        Dim com As New MySqlCommand(cad)
        com.Connection = clConex
        da.SelectCommand = com
        da.Fill(ds, "eventos_consolidado")
        clConex.Close()
        Return ds
    End Function

    Public Function recuperaEvento(ByVal operacion As Integer) As DataSet
        Dim clConex As New MySqlConnection
        Dim da As New MySqlDataAdapter
        Dim ds As New DataSet
        clConex = Conexion.obtenerConexion
        Dim cad As String
        cad = "select * from reservas where operacion= " & operacion
        Dim com As New MySqlCommand(cad)
        com.Connection = clConex
        da.SelectCommand = com
        da.Fill(ds, "cabecera")
        clConex.Close()
        Return ds
    End Function
    Public Function recuperaEvento_det(ByVal operacion As Integer) As DataSet
        Dim clConex As New MySqlConnection
        Dim da As New MySqlDataAdapter
        Dim ds As New DataSet
        clConex = Conexion.obtenerConexion
        Dim cad As String
        cad = "select operacion,ingreso,rd.cod_recurso,dsc_recurso,cant,cant_prod,rd.precio," _
            & " round(cant*rd.precio,3) as imp_venta,obs,tt.dsc_tabla As dsc_grupo,c_aux1,n_aux1 " _
            & " from reservas_det rd " _
            & " inner join tipo_recurso tr On rd.cod_recurso=tr.cod_recurso " _
            & " inner join tipo_tabla tt On tr.cod_tabla=tt.cod_tabla" _
            & " where operacion= " & operacion & " order by dsc_grupo"
        Dim com As New MySqlCommand(cad)
        com.Connection = clConex
        da.SelectCommand = com
        da.Fill(ds, "detalle")
        clConex.Close()
        Return ds
    End Function
    Public Function recuperaEvento_detAyB(ByVal operacion As Integer) As DataSet
        Dim clConex As New MySqlConnection
        Dim da As New MySqlDataAdapter
        Dim ds As New DataSet
        clConex = Conexion.obtenerConexion
        Dim cad, cad1, cad2 As String
        cad1 = " Select operacion,ingreso,rd.cod_recurso,a.nom_art As dsc_recurso,cant,cant_prod,rd.precio," _
            & " round(cant*rd.precio,3) As imp_venta,obs ,g.nom_grupo As dsc_grupo,c_aux1,n_aux1 " _
            & " from reservas_det rd inner join articulo a On rd.cod_recurso=a.cod_art " _
            & " left join articulo a1 On rd.c_Aux1=a1.cod_art " _
            & " left join subgrupo s On s.cod_sgrupo=a.cod_sgrupo " _
            & " left join grupo g On g.cod_grupo=s.cod_grupo " _
            & " where n_aux1=0 and operacion= " & operacion

        cad2 = " UNION Select operacion,ingreso,rd.cod_recurso,a.nom_art As dsc_recurso,cant,cant_prod,rd.precio," _
            & " round(cant*rd.precio,3) As imp_venta,obs ,'PAQUETES' As dsc_grupo,c_aux1,n_aux1 " _
            & " from reservas_det rd inner join articulo a On rd.cod_recurso=a.cod_art " _
            & " left join articulo a1 On rd.c_Aux1=a1.cod_art " _
            & " left join subgrupo s On s.cod_sgrupo=a.cod_sgrupo " _
            & " left join grupo g On g.cod_grupo=s.cod_grupo " _
            & " where n_aux1=1 and operacion= " & operacion & " order by dsc_grupo "
        cad = cad1 + cad2
        Dim com As New MySqlCommand(cad)
        com.Connection = clConex
        da.SelectCommand = com
        da.Fill(ds, "detalleAyB")
        clConex.Close()
        Return ds
    End Function

    Public Function devuelve_caux(ByVal codigo As String) As String
        Dim clConex As New MySqlConnection
        Dim com As New MySqlCommand
        clConex = Conexion.obtenerConexion
        Dim cad, result As String
        com.Connection = clConex
        cad = "Select c_aux  from tipo_recurso " _
               & " where cod_recurso= '" & codigo & "'"
        com.CommandText = cad
        Dim obj As Object = com.ExecuteScalar
        result = CType(IIf(IsDBNull(obj), "", obj), String)
        clConex.Close()
        Return result
    End Function
    Public Function devuelve_codcliente(ByVal codigo As String) As String
        Dim clConex As New MySqlConnection
        Dim com As New MySqlCommand
        clConex = Conexion.obtenerConexion
        Dim cad, result As String
        com.Connection = clConex
        cad = "Select cod_clie  from cliente_sucursal" _
               & " where cod_sucursal= '" & codigo & "'"
        com.CommandText = cad
        Dim obj As Object = com.ExecuteScalar
        result = CType(IIf(IsDBNull(obj), "", obj), String)
        clConex.Close()
        Return result
    End Function

    Public Function devuelve_numfactura(ByVal num_orden As String) As String
        Dim clConex As New MySqlConnection
        Dim com As New MySqlCommand
        clConex = Conexion.obtenerConexion
        Dim cad, result As String
        com.Connection = clConex
        cad = "Select num_factura  from reservas" _
               & " where num_orden= '" & num_orden & "' group by num_orden,num_factura" _
               & " order by num_orden,num_factura"
        com.CommandText = cad
        Dim obj As Object = com.ExecuteScalar
        result = CType(IIf(IsDBNull(obj), "", obj), String)
        clConex.Close()
        Return result
    End Function

    Public Function devuelve_nomrecurso(ByVal codigo As String) As String
        Dim clConex As New MySqlConnection
        Dim com As New MySqlCommand
        clConex = Conexion.obtenerConexion
        Dim cad, result As String
        com.Connection = clConex
        cad = "select dsc_recurso  from tipo_recurso " _
               & " where cod_recurso= '" & codigo & "'"
        com.CommandText = cad
        Dim obj As Object = com.ExecuteScalar
        result = CType(IIf(IsDBNull(obj), "", obj), String)
        clConex.Close()
        Return result
    End Function

    Public Function existeEvento_det(ByVal operacion As Integer, ByVal ingreso As Integer) As Boolean
        Dim clConex As MySqlConnection = Conexion.obtenerConexion
        Dim com As New MySqlCommand, result As Integer, cad As String
        com.Connection = clConex
        cad = "Select count(ingreso) from reservas_det where operacion=" & operacion & " and ingreso=" & ingreso
        com.CommandText = cad
        Dim obj As Object = com.ExecuteScalar
        result = CType(IIf(IsDBNull(obj), False, obj), Integer)
        clConex.Close()
        If result = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function maxCodRecurso(ByVal cod_tabla As String) As String
        Dim clConex As MySqlConnection = Conexion.obtenerConexion
        Dim com As New MySqlCommand, result As Integer
        com.Connection = clConex
        com.CommandText = "select max(cod_recurso) from tipo_recurso where cod_tabla='" & cod_tabla & "'"
        Dim obj As Object = com.ExecuteScalar
        result = CType(IIf(IsDBNull(obj), "0000", obj), String)
        Dim resp As String = Right("0000" & Trim(Str(Microsoft.VisualBasic.Val(result) + 1)), 4)
        clConex.Close()
        Return resp
    End Function
    Public Function maxCodsucursal(ByVal cod_cliente As String) As String
        Dim clConex As MySqlConnection = Conexion.obtenerConexion
        Dim com As New MySqlCommand, result As Integer
        com.Connection = clConex
        com.CommandText = "select max(cod_sucursal) from cliente_sucursal "
        'com.CommandText = "select max(cod_sucursal) from cliente_sucursal where cod_clie='" & cod_cliente & "'"
        Dim obj As Object = com.ExecuteScalar
        result = CType(IIf(IsDBNull(obj), "0000", obj), String)
        Dim resp As String = Right("000000" & Trim(Str(Microsoft.VisualBasic.Val(result) + 1)), 4)
        clConex.Close()
        Return resp
    End Function
    Public Function maxCodContacto(ByVal cod_cliente As String) As String
        Dim clConex As MySqlConnection = Conexion.obtenerConexion
        Dim com As New MySqlCommand, result As Integer
        com.Connection = clConex
        com.CommandText = "select max(cod_contacto) from cliente_contacto "
        Dim obj As Object = com.ExecuteScalar
        result = CType(IIf(IsDBNull(obj), "0000", obj), String)
        Dim resp As String = Right("000000" & Trim(Str(Microsoft.VisualBasic.Val(result) + 1)), 4)
        clConex.Close()
        Return resp
    End Function
    Public Function maxReserva_det(ByVal operacion As Integer) As Integer
        Dim clConex As MySqlConnection = Conexion.obtenerConexion
        Dim com As New MySqlCommand, result As Integer
        com.Connection = clConex
        com.CommandText = "select max(ingreso) from reservas_det where operacion='" & operacion & "'"
        Dim obj As Object = com.ExecuteScalar
        result = CType(IIf(IsDBNull(obj), 0, obj), Integer)
        Dim resp As String = result + 1
        clConex.Close()
        Return resp
    End Function

    Public Function existeCliente(ByVal cod_clie As String) As Boolean
        Dim clConex As MySqlConnection = Conexion.obtenerConexion
        Dim com As New MySqlCommand, result As Integer, cad As String
        com.Connection = clConex
        cad = "Select count(cod_clie) from cliente where cod_clie='" & cod_clie & "'"
        com.CommandText = cad
        Dim obj As Object = com.ExecuteScalar
        result = CType(IIf(IsDBNull(obj), False, obj), Integer)
        clConex.Close()
        If result = 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function existeReceta(ByVal cod_art As String) As Boolean
        Dim clConex As MySqlConnection = Conexion.obtenerConexion
        Dim com As New MySqlCommand, result As Integer, cad As String
        com.Connection = clConex
        cad = "select count(r.cod_rec) from receta r inner join articulo a on a.cod_Art=r.cod_art inner join " _
             & "tipo_articulo t on a.cod_tart=t.cod_tart where (esProductoterminado) and cod_rec='" & cod_art & "'"
        com.CommandText = cad
        Dim obj As Object = com.ExecuteScalar
        result = CType(IIf(IsDBNull(obj), False, obj), Integer)
        clConex.Close()
        If result = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function esCombo(ByVal cod_art As String) As Boolean
        Dim clConex As MySqlConnection = Conexion.obtenerConexion
        Dim com As New MySqlCommand, result As Integer, cad As String
        com.Connection = clConex
        cad = "select count(a.cod_art) from  articulo a inner join " _
             & "tipo_articulo t on a.cod_tart=t.cod_tart where (esCombo) and a.cod_art='" & cod_art & "'"
        com.CommandText = cad
        Dim obj As Object = com.ExecuteScalar
        result = CType(IIf(IsDBNull(obj), False, obj), Integer)
        clConex.Close()
        If result = 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function esComboEsp(ByVal cod_art As String) As Boolean
        Dim clConex As MySqlConnection = Conexion.obtenerConexion
        Dim com As New MySqlCommand, result As Integer, cad As String
        com.Connection = clConex
        cad = "select count(a.cod_art) from  articulo a inner join " _
             & "tipo_articulo t on a.cod_tart=t.cod_tart where (esComboEsp) and a.cod_art='" & cod_art & "'"
        com.CommandText = cad
        Dim obj As Object = com.ExecuteScalar
        result = CType(IIf(IsDBNull(obj), False, obj), Integer)
        clConex.Close()
        If result = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function recuperaTC(ByVal fechaProceso As Date) As Decimal
        Dim mfecha = fechaProceso.ToString("yyyy-MM-dd")
        Dim clConex As MySqlConnection = Conexion.obtenerConexion
        Dim com As New MySqlCommand, result As Decimal, cad, cad1, cad2 As String
        com.Connection = clConex
        cad1 = "Select tc from tipo_cambio where"
        cad2 = " fecha='" & mfecha & "'"
        cad = cad1 + cad2
        com.CommandText = cad
        Dim obj As Object = com.ExecuteScalar
        result = CType(IIf(IsDBNull(obj), 0, obj), Decimal)
        clConex.Close()
        Return result
    End Function

    Public Function ingresoSistema(ByVal usuario As String, ByVal clave As String) As Boolean
        Dim resp As Integer
        Dim cmd As New MySqlCommand

        Dim clConex As MySqlConnection = Conexion.obtenerConexion()
        cmd.Connection = clConex
        cmd.CommandText = "select count(*) from usuario where cuenta='" + usuario + "'" + " and clave='" + clave + "'"
        If Not clConex Is Nothing Then
            resp = cmd.ExecuteScalar()
            clConex.Close()
            If resp > 0 Then
                Return True
            Else
                Return False
            End If
        Else
            clConex.Close()
            Return False
        End If
        
    End Function

    Public Function recuperaNivelUsuario(ByVal cuenta As String) As String
        Dim resp As String = ""
        Dim cmd As New MySqlCommand
        Try
            Dim clConex As MySqlConnection = Conexion.obtenerConexion()
            cmd.Connection = clConex
            cmd.CommandText = "select nivel from usuario where cuenta='" & cuenta & "'"
            If Not clConex Is Nothing Then
                resp = cmd.ExecuteScalar()
                clConex.Close()
            Else
                clConex.Close()
                resp = ""
            End If
        Catch ex As Exception
        Finally
        End Try
        Return resp
    End Function

    Public Function recuperaDatosUsuario(ByVal cuenta As String) As String
        Dim resp As String = ""
        Dim cmd As New MySqlCommand
        Try
            Dim clConex As MySqlConnection = Conexion.obtenerConexion()
            cmd.Connection = clConex
            cmd.CommandText = "select user from usuario where cuenta='" & cuenta & "'"
            If Not clConex Is Nothing Then
                resp = cmd.ExecuteScalar()
                clConex.Close()
                Return resp
            Else
                clConex.Close()
                Return resp
            End If
        Catch ex As Exception
        Finally
        End Try
        Return resp
    End Function

    Public Function permisos(ByVal cuenta As String) As DataSet
        Dim clConex As MySqlConnection = Conexion.obtenerConexion
        Dim da As New MySqlDataAdapter
        Dim dsPermisos As New DataSet
        Dim cad, cad1, cad2 As String
        cad1 = "select cod_smenu,activo"
        cad2 = " from usuario_smenu where cuenta='" & cuenta & "'"
        cad = cad1 + cad2
        Dim com As New MySqlCommand(cad)
        com.Connection = clConex
        da.SelectCommand = com
        da.Fill(dsPermisos, "permisos")
        Return dsPermisos
    End Function
End Module
