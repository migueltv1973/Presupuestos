

Imports MySql.Data.MySqlClient
Imports Microsoft.Office.Interop
Imports System.ComponentModel
Imports DevComponents.AdvTree

Public Class p_eventos
    Private dsDetalle As New DataSet
    Private dtDetalle As New DataTable
    Private dsDetalleAyb As New DataSet
    Private dtdetalleAyb As New DataTable
    Private dsCliente As New DataSet
    Private dtCliente As New DataTable("cliente")
    Private dsSucursal As New DataSet
    Private dtSucursal As New DataTable("sucursal")
    Private dsEjventas As New DataSet


    Private dtejventas As New DataTable("ejventas")
    Private dstipSalon As New DataSet
    Private dttipSalon As New DataTable("tipsalon")
    Private dstipevento As New DataSet
    Private dttipevento As New DataTable("tipevento")
    Private dstipestado As New DataSet
    Private dttippostventa As New DataTable("tippostventa")
    Private dstippostventa As New DataSet
    Private dttipestado As New DataTable("tipestado")
    Private dstiptabla As New DataSet
    Private dttiptabla As New DataTable("tiptabla")
    Private dsRecurso As New DataSet
    Private cadena As String
    Private codigo As String
    Private cod_tabla As String
    Private nom_grp As String
    Private cod_grp As String
    Private nroOperacion As Integer
    Private estacargando As Boolean = True


    Public Sub cargaeventos(ByVal operacion As Integer, ByVal fec_desde As DateTime, ByVal fec_hasta As DateTime, ByVal salon As String, ByVal escopia As Boolean)
        Dim ds As DataSet
        nroOperacion = IIf(escopia, 0, operacion)
        dt_desde.Value = fec_desde
        dt_hasta.Value = fec_hasta
        dt_horadesde.Value = fec_desde
        dt_horahasta.Value = fec_hasta
        dt_horproduccion.Value = fec_desde.AddMinutes(-90)
        txtnro_evento.Text = IIf(escopia, 0, operacion)
        cbotip_salon.Text = salon

        ds = consultas.recuperaEvento(operacion)
        If ds.Tables("cabecera").Rows.Count > 0 Then
            Dim mfila As DataRow = ds.Tables("cabecera").Rows(0)
            txt_reserva.Text = IIf(escopia, 0, mfila.Item("cod_reserva"))
            dt_horadesde.Value = mfila.Item("fec_ini")
            dt_horproduccion.Value = mfila.Item("fec_produccion")
            txtid_factura.Text = mfila.Item("id_factura")
            txtid_numfactura.Text = mfila.Item("num_factura")
            txtid_cotizacion.Text = mfila.Item("num_orden")
            txtnom_evento.Text = mfila.Item("nom_evento")
            txtnro_adultos.Text = mfila.Item("num_adultos")
            lblFacturado.Text = IIf(Len(mfila.Item("num_factura")) > 0, "FACTURADO : " + mfila.Item("num_factura"), "")

            cboCliente.SelectedValue = mfila.Item("cod_cliente")
            cboUnidad.SelectedValue = mfila.Item("cod_sucursal")
            cboContacto.SelectedValue = mfila.Item("cod_contacto")
            cbotip_salon.SelectedValue = mfila.Item("cod_salon")
            cboejventas.SelectedValue = mfila.Item("cod_vend")
            cbotip_evento.SelectedValue = mfila.Item("cod_evento")
            cbotip_estado.Text = consultas.devuelve_nomrecurso(mfila.Item("cod_estado"))
            cbotip_conforme.Text = consultas.devuelve_nomrecurso(mfila.Item("cod_postventa"))
            txtObservacion.Text = mfila.Item("obs")

        End If
        If cboCliente.SelectedValue <> "" Then
            Dim fcod_clie As String = cboCliente.SelectedValue.ToString
            UbicarCliente(fcod_clie)
            If cboContacto.SelectedValue <> "" Then
                Dim fcod_contacto As String = cboContacto.SelectedValue.ToString
                UbicarContacto(fcod_contacto)
            End If

        End If

        'Datos Recursos
        dsDetalle = consultas.recuperaEvento_det(operacion)
        dtDetalle = dsDetalle.Tables("detalle")
        dataDetalle.DataSource = dsDetalle.Tables("detalle").DefaultView
        cargaEstructuraDetalle()
        With tvRecursos
            .DataSource = dsDetalle.Tables("detalle").DefaultView
            .DisplayMembers = "cant,cant_prod,dsc_recurso,precio,imp_venta,obs"
            .ValueMember = dsDetalle.Tables("detalle").Columns("cod_recurso").ToString
            .GroupingMembers = dsDetalle.Tables("detalle").Columns("dsc_grupo").ToString
        End With
        cargaestructuratvrecursos()


        'Datos Alimentos y bebidas
        dsDetalleAyb = consultas.recuperaEvento_detAyB(operacion)
        dtdetalleAyb = dsDetalleAyb.Tables("detalleAyB")
        dataAyB.DataSource = dsDetalleAyb.Tables("detalleAyB").DefaultView
        cargaEstructuraDetalleAyB()
        With tvAyB
            .DataSource = dsDetalleAyb.Tables("detalleAyB").DefaultView
            .DisplayMembers = "cant,cant_prod,dsc_recurso,precio,imp_venta,obs"
            .ValueMember = dsDetalleAyb.Tables("detalleAyB").Columns("cod_recurso").ToString
            .GroupingMembers = dsDetalleAyb.Tables("detalleAyB").Columns("dsc_grupo").ToString
        End With
        cargaestructuratvAyB()
        With tvPack
            .DataSource = dsDetalleAyb.Tables("detalleAyB").DefaultView
            .DisplayMembers = "cant,cant_prod,dsc_recurso,precio,imp_venta,obs"
            .ValueMember = dsDetalleAyb.Tables("detalleAyB").Columns("cod_recurso").ToString
            .GroupingMembers = dsDetalleAyb.Tables("detalleAyB").Columns("dsc_grupo").ToString
        End With
        cargaestructuraPack()

        calculadetalle()
        calculaTotal()
    End Sub

    Private Sub p_eventos_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        cargaForm_c_eventos()
    End Sub
    Sub cargaForm_c_eventos()

        Dim IsFormCargado As Boolean = False
        Dim mForm As Form
        For Each mForm In principal.MdiChildren
            If mForm.Name = "c_eventos" Then
                If mForm.WindowState = FormWindowState.Minimized Then
                    mForm.WindowState = FormWindowState.Normal
                Else
                    mForm.BringToFront()
                End If
                IsFormCargado = True
                Exit For
            End If
        Next
        mForm = Nothing
        If IsFormCargado = False Then
            Dim mformIngresos As New c_eventos
            mformIngresos.MdiParent = principal
            mformIngresos.Show()
            mformIngresos.Refresh()
        End If


    End Sub

    Private Sub p_eventos_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.Control And e.KeyCode = Keys.A) Then
            agregaitems()
        End If
    End Sub

    Private Sub p_eventos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'dataset cliente
        dsCliente.Tables.Add(dtCliente)
        Dim daCliente As New MySqlDataAdapter
        cadena = "Select * from cliente where activo=1 order by raz_soc"
        Dim comClie As New MySqlCommand(cadena, dbConex)
        daCliente.SelectCommand = comClie
        daCliente.Fill(dsCliente, "cliente")
        With cboCliente
            .DataSource = dsCliente.Tables("cliente")
            .DisplayMember = dsCliente.Tables("cliente").Columns("raz_soc").ToString
            .ValueMember = dsCliente.Tables("cliente").Columns("cod_clie").ToString
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With

        'dataset sucursal
        dsSucursal.Tables.Add(dtSucursal)
        Dim daSucursal As New MySqlDataAdapter
        cadena = "Select * from cliente_sucursal where activo=1 order by dir_sucursal"
        Dim comSuc As New MySqlCommand(cadena, dbConex)
        daSucursal.SelectCommand = comSuc
        daSucursal.Fill(dsSucursal, "sucursal")
        With cboUnidad
            .DataSource = dsSucursal.Tables("sucursal")
            .DisplayMember = dsSucursal.Tables("sucursal").Columns("dir_sucursal").ToString
            .ValueMember = dsSucursal.Tables("sucursal").Columns("cod_sucursal").ToString
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
        ''dataset ejventas
        dsEjventas.Tables.Add(dtejventas)
        Dim daejventas As New MySqlDataAdapter
        cadena = "Select c_aux,dsc_recurso from tipo_recurso where activo and cod_tabla='tip_ejventa'"
        Dim comejventas As New MySqlCommand(cadena, dbConex)
        daejventas.SelectCommand = comejventas
        daejventas.Fill(dsEjventas, "ejventas")
        With cboejventas
            .DataSource = dsEjventas.Tables("ejventas")
            .DisplayMember = dsEjventas.Tables("ejventas").Columns("dsc_recurso").ToString
            .ValueMember = dsEjventas.Tables("ejventas").Columns("c_aux").ToString
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With

        'dataset tipEstado
        dstipestado.Tables.Add(dttipestado)
        Dim datipestado As New MySqlDataAdapter
        cadena = "Select cod_recurso,dsc_recurso from tipo_recurso where activo and cod_tabla='tip_estado'"
        Dim comTipestado As New MySqlCommand(cadena, dbConex)
        datipestado.SelectCommand = comTipestado
        datipestado.Fill(dstipestado, "tipestado")
        With cbotip_estado
            .DataSource = dstipestado.Tables("tipestado")
            .DisplayMember = dstipestado.Tables("tipestado").Columns("dsc_recurso").ToString
            .ValueMember = dstipestado.Tables("tipestado").Columns("cod_recurso").ToString
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
        'dataset tipSalon
        dstipSalon.Tables.Add(dttipSalon)
        Dim datipsalon As New MySqlDataAdapter
        cadena = "Select cod_recurso,dsc_recurso from tipo_recurso where activo and cod_tabla='tip_salon'"
        Dim comTipsalon As New MySqlCommand(cadena, dbConex)
        datipsalon.SelectCommand = comTipsalon
        datipsalon.Fill(dstipSalon, "tipsalon")
        With cbotip_salon
            .DataSource = dstipSalon.Tables("tipsalon")
            .DisplayMember = dstipSalon.Tables("tipsalon").Columns("dsc_recurso").ToString
            .ValueMember = dstipSalon.Tables("tipsalon").Columns("cod_recurso").ToString
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
        'dataset tipPostventa
        dstippostventa.Tables.Add(dttippostventa)
        Dim datippostventa As New MySqlDataAdapter
        cadena = "Select cod_recurso,dsc_recurso from tipo_recurso where activo and cod_tabla='tip_postvent'"
        Dim comTippostventa As New MySqlCommand(cadena, dbConex)
        datippostventa.SelectCommand = comTippostventa
        datippostventa.Fill(dstippostventa, "tippostventa")
        With cbotip_conforme
            .DataSource = dstippostventa.Tables("tippostventa")
            .DisplayMember = dstippostventa.Tables("tippostventa").Columns("dsc_recurso").ToString
            .ValueMember = dstippostventa.Tables("tippostventa").Columns("cod_recurso").ToString
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
        'dataset tipEvento
        dstipevento.Tables.Add(dttipevento)
        Dim datipevento As New MySqlDataAdapter
        cadena = "Select cod_recurso,dsc_recurso from tipo_recurso where activo and cod_tabla='tip_evento'"
        Dim comTipevento As New MySqlCommand(cadena, dbConex)
        datipevento.SelectCommand = comTipevento
        datipevento.Fill(dstipevento, "tipevento")
        With cbotip_evento
            .DataSource = dstipevento.Tables("tipevento")
            .DisplayMember = dstipevento.Tables("tipevento").Columns("dsc_recurso").ToString
            .ValueMember = dstipevento.Tables("tipevento").Columns("cod_recurso").ToString
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
        'dataset tiptabla
        dstiptabla.Tables.Add(dttiptabla)
        Dim datiptabla As New MySqlDataAdapter
        'cadena = "Select cod_tabla,dsc_tabla from tipo_tabla where activo and tip_tabla='2'"
        cadena = "Select CONCAT('*',cod_tabla) cod_tabla,dsc_tabla from tipo_tabla where activo and tip_tabla='2' " _
                & " union  select cod_sgrupo,nom_sgrupo from subgrupo where esVenta order by 2"
        Dim comTiptabla As New MySqlCommand(cadena, dbConex)
        datiptabla.SelectCommand = comTiptabla
        datiptabla.Fill(dstiptabla, "tiptabla")
        With cbotip_tabla
            .DataSource = dstiptabla.Tables("tiptabla")
            .DisplayMember = dstiptabla.Tables("tiptabla").Columns("dsc_tabla").ToString
            .ValueMember = dstiptabla.Tables("tiptabla").Columns("cod_tabla").ToString
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
        estacargando = False

    End Sub
    Sub cargarunidad(ByVal cod_cliente As String)

        'dataset contacto
        Dim dtcontacto As New DataTable("contacto")
        Dim dscontacto As New DataSet
        dscontacto.Tables.Add(dtcontacto)
        Dim daContacto As New MySqlDataAdapter
        cadena = "Select * from cliente_sucursal where activo=1 and cod_clie ='" & cod_cliente & "' order by dir_sucursal"
        Dim comCont As New MySqlCommand(cadena, dbConex)
        daContacto.SelectCommand = comCont

        daContacto.Fill(dscontacto, "contacto")
        With cboUnidad
            .DataSource = dscontacto.Tables("contacto")
            .DisplayMember = dscontacto.Tables("contacto").Columns("dir_sucursal").ToString
            .ValueMember = dscontacto.Tables("contacto").Columns("cod_sucursal").ToString
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With

    End Sub

    Sub cargarcontacto(ByVal cod_sucursal As String)

        'dataset contacto
        Dim dtcontacto As New DataTable("contacto")
        Dim dscontacto As New DataSet
        dscontacto.Tables.Add(dtcontacto)
        Dim daContacto As New MySqlDataAdapter
        cadena = "Select * from cliente_contacto where activo=1 and cod_sucursal ='" & cod_sucursal & "' order by nom_contacto"
        Dim comCont As New MySqlCommand(cadena, dbConex)
        daContacto.SelectCommand = comCont

        daContacto.Fill(dscontacto, "contacto")
        With cboContacto
            .DataSource = dscontacto.Tables("contacto")
            .DisplayMember = dscontacto.Tables("contacto").Columns("nom_contacto").ToString
            .ValueMember = dscontacto.Tables("contacto").Columns("cod_contacto").ToString
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With

    End Sub
    Sub cargaEstructuraDetalle()
        With dataDetalle
            ' .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("cant").HeaderText = "Cantidad"
            .Columns("cant").DisplayIndex = 1
            .Columns("cant").Width = 50
            .Columns("cant").ReadOnly = False
            .Columns("cant").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("cant").DefaultCellStyle.BackColor = Color.AliceBlue
            .Columns("cant").DefaultCellStyle.Format = "##,###"

            .Columns("cant_prod").HeaderText = "Produccion"
            .Columns("cant_prod").DisplayIndex = 2
            .Columns("cant_prod").Width = 35
            .Columns("cant_prod").ReadOnly = False
            .Columns("cant_prod").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("cant_prod").DefaultCellStyle.BackColor = Color.AliceBlue
            .Columns("cant_prod").DefaultCellStyle.Format = "##,###.##"

            .Columns("dsc_recurso").HeaderText = "Descripcion"
            .Columns("dsc_recurso").DisplayIndex = 3
            .Columns("dsc_recurso").Width = 260
            .Columns("dsc_recurso").ReadOnly = True


            .Columns("precio").HeaderText = "Precio"
            .Columns("precio").DisplayIndex = 4
            .Columns("precio").Width = 30
            .Columns("precio").ReadOnly = False
            .Columns("precio").DefaultCellStyle.Format = "##,###.##"

            .Columns("imp_venta").HeaderText = "Importe"
            .Columns("imp_venta").DisplayIndex = 5
            .Columns("imp_venta").Width = 50
            .Columns("imp_venta").ReadOnly = False
            .Columns("imp_venta").DefaultCellStyle.Format = "##,##0.##"

            .Columns("obs").HeaderText = "Observacion"
            .Columns("obs").DisplayIndex = 6
            .Columns("obs").Width = 150
            .Columns("obs").DefaultCellStyle.ForeColor = Color.CornflowerBlue
            .Columns("obs").ReadOnly = False

            .Columns("dsc_grupo").HeaderText = "Grupo"
            .Columns("dsc_grupo").DisplayIndex = 7
            .Columns("dsc_grupo").Width = 170
            .Columns("dsc_grupo").ReadOnly = True
            .Columns("dsc_grupo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("operacion").Visible = False
            .Columns("cod_recurso").Visible = False
            .Columns("ingreso").Visible = False
            .Columns("c_aux1").Visible = False
            .Columns("n_aux1").Visible = False
        End With
    End Sub
    Sub cargaEstructuraDetalleAyB()
        With dataAyB
            '.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("cant").HeaderText = "Cantidad"
            .Columns("cant").Width = 50
            .Columns("cant").ReadOnly = False
            .Columns("cant").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("cant").DefaultCellStyle.BackColor = Color.AliceBlue
            .Columns("cant").DefaultCellStyle.Format = "##,###"
            .Columns("cant").DisplayIndex = 1

            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("cant_prod").HeaderText = "Produccion"
            .Columns("cant_prod").Width = 35
            .Columns("cant_prod").ReadOnly = False
            .Columns("cant_prod").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("cant_prod").DefaultCellStyle.BackColor = Color.AliceBlue
            .Columns("cant_prod").DefaultCellStyle.Format = "##,###.##"
            .Columns("cant_prod").DisplayIndex = 2


            .Columns("dsc_recurso").HeaderText = "Descripcion"
            .Columns("dsc_recurso").Width = 320
            .Columns("dsc_recurso").ReadOnly = True
            .Columns("dsc_recurso").DisplayIndex = 3

            .Columns("precio").HeaderText = "Precio"
            .Columns("precio").DisplayIndex = 4
            .Columns("precio").Width = 30
            .Columns("precio").ReadOnly = False
            .Columns("precio").DefaultCellStyle.Format = "##,###.##"

            .Columns("imp_venta").HeaderText = "Importe"
            .Columns("imp_venta").DisplayIndex = 5
            .Columns("imp_venta").Width = 50
            .Columns("imp_venta").ReadOnly = False
            .Columns("imp_venta").DefaultCellStyle.Format = "###,###.##"

            .Columns("obs").HeaderText = "Observacion"
            .Columns("obs").Width = 150
            .Columns("obs").DefaultCellStyle.ForeColor = Color.CornflowerBlue
            .Columns("obs").ReadOnly = False
            .Columns("obs").DisplayIndex = 6

            .Columns("dsc_grupo").HeaderText = "Grupo"
            .Columns("dsc_grupo").Width = 120
            .Columns("dsc_grupo").ReadOnly = True
            .Columns("dsc_grupo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("dsc_grupo").DisplayIndex = 7
            .Columns("operacion").Visible = False
            .Columns("cod_recurso").Visible = False
            .Columns("ingreso").Visible = False
            .Columns("c_aux1").Visible = False
            .Columns("n_aux1").Visible = False
        End With


    End Sub
    Private Sub cmdgrabar_Click(sender As System.Object, e As System.EventArgs) Handles cmdGrabar.Click
        Dim cod_recurso, cod_aux1 As String
        Dim cant, cant_prod, precio As Decimal
        Dim ingreso, nroOperacionxfecha, num_aux1 As Integer
        Dim cod_cliente As String = txtRuc.Text
        Dim id_factura As String = txtid_factura.Text
        Dim cod_sucursal As String = cboUnidad.SelectedValue
        Dim cod_contacto As String = cboContacto.SelectedValue
        'Dim cod_vendedor As String = cboejventas.SelectedValue
        Dim cod_vendedor As String = pCuentaUser
        Dim cod_evento As String = cbotip_evento.SelectedValue
        Dim cod_salon As String = cbotip_salon.SelectedValue
        Dim cod_estado As String = cbotip_estado.SelectedValue
        Dim cod_postventa As String = cbotip_conforme.SelectedValue
        Dim nom_evento As String = txtnom_evento.Text
        Dim num_adultos As Integer = CInt(txtnro_adultos.Text)
        Dim num_ninos As Integer = 0 'CInt(txtnro_ninos.Text)
        Dim obs As String = txtObservacion.Text
        Dim cod_reserva As String
        Dim esAdicional As Boolean = chkAdicional.Checked
        Dim fec_reserva As String = dt_desde.Value.ToString("yyyy-MM-dd")
        Dim fec_desde As String = dt_desde.Value.ToString("yyyy-MM-dd") & " " & dt_horadesde.Value.ToString("HH:mm:ss")
        Dim fec_hasta As String = dt_hasta.Value.ToString("yyyy-MM-dd") & " " & dt_horahasta.Value.ToString("HH:mm:ss")
        Dim fec_produccion As String = dt_horproduccion.Value.ToString("yyyy-MM-dd") & " " & dt_horproduccion.Value.ToString("HH:mm:ss")


        If validaGrabacion() Then
            Try


                'If Not consultas.existeCliente(txtRuc.Text) Then
                '    insertar.insertarCliente(txtRuc.Text, cboCliente.Text, cboCliente.Text, txtDirEntrega.Text, txtDirEntrega.Text, cboContacto.Text, txtTelefono.Text, txtEmail.Text, "00", 1)
                'Else
                '    actualizar.actualizarCliente(txtRuc.Text, cboCliente.Text, cboCliente.Text, txtDirEntrega.Text, txtDirEntrega.Text, cboContacto.Text, txtTelefono.Text, txtEmail.Text, "00", 1)
                'End If

                If nroOperacion = 0 Then
                    nroOperacion = General.maxOperacion()
                    nroOperacionxfecha = General.maxOperacionxfecha(fec_reserva)
                    cod_reserva = fec_reserva & "-" & nroOperacionxfecha.ToString


                    insertar.insertarEvento(nroOperacion, cod_reserva, id_factura, fec_desde, fec_hasta, fec_produccion, cod_cliente, cod_sucursal, cod_contacto,
                                            cod_postventa, cod_evento, cod_salon, cod_vendedor, cod_estado, nom_evento, num_adultos, num_ninos, obs, pCuentaUser, esAdicional)
                Else
                    actualizar.actualizarEvento(nroOperacion, id_factura, fec_desde, fec_hasta, fec_produccion, cod_cliente, cod_sucursal, cod_contacto,
                                               cod_postventa, cod_evento, cod_salon, cod_estado, nom_evento, num_adultos, num_ninos, obs, esAdicional)
                End If


                actualizar.actualizar_Contacto(cod_contacto, txtobs_contacto.Text)

                For I = 0 To dataDetalle.RowCount - 1
                    Dim obs_det As String = dataDetalle("obs", I).Value.ToString
                    ingreso = dataDetalle("ingreso", I).Value
                    cod_recurso = dataDetalle("cod_recurso", I).Value.ToString
                    cod_aux1 = dataDetalle("c_aux1", I).Value.ToString
                    num_aux1 = dataDetalle("n_aux1", I).Value
                    cant = dataDetalle("cant", I).Value
                    cant_prod = dataDetalle("cant_prod", I).Value
                    precio = dataDetalle("precio", I).Value
                    If consultas.existeEvento_det(nroOperacion, ingreso) Then
                        actualizar.actualizarEvento_det(nroOperacion, ingreso, cant, cant_prod, precio, obs_det)
                    Else
                        ingreso = consultas.maxReserva_det(nroOperacion)
                        insertar.insertarEvento_det(nroOperacion, ingreso, cod_recurso, cant, cant_prod, precio, obs_det, cod_aux1, num_aux1)
                    End If
                Next

                For I = 0 To dataAyB.RowCount - 1
                    Dim obs_det As String = dataAyB("obs", I).Value.ToString
                    ingreso = dataAyB("ingreso", I).Value
                    cod_recurso = dataAyB("cod_recurso", I).Value.ToString
                    cod_aux1 = dataAyB("c_aux1", I).Value.ToString
                    num_aux1 = dataAyB("n_aux1", I).Value
                    cant = dataAyB("cant", I).Value
                    cant_prod = dataAyB("cant_prod", I).Value
                    precio = dataAyB("precio", I).Value
                    If consultas.existeEvento_det(nroOperacion, ingreso) Then
                        actualizar.actualizarEvento_det(nroOperacion, ingreso, cant, cant_prod, precio, obs_det)
                    Else
                        ingreso = consultas.maxReserva_det(nroOperacion)
                        insertar.insertarEvento_det(nroOperacion, ingreso, cod_recurso, cant, cant_prod, precio, obs_det, cod_aux1, num_aux1)
                    End If

                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

            modoDesabilitado()
        End If
        actualizar.actualizar_codpostventa(nroOperacion, cod_postventa)
    End Sub
    Sub modoDesabilitado()
        cmdGrabar.Enabled = False
    End Sub

    Sub modoHabilitado()
        cmdGrabar.Enabled = True
    End Sub


    Private Sub cmdborrar_Click(sender As System.Object, e As System.EventArgs) Handles cmdborrar.Click
        'Dim rpta As Integer = MessageBox.Show("Esta Seguro de Eliminar el Evento" + Chr(13) + "Este Proceso es Irreversible...", "EVENTOS", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2)
        'If rpta = 6 Then
        '    eliminar.eliminaEvento(nroOperacion)
        'End If

    End Sub

    Private Sub cbotip_tabla_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbotip_tabla.SelectedIndexChanged
        If Not estacargando Then
            cod_tabla = cbotip_tabla.SelectedValue
            If cod_tabla.Substring(0, 1) = "*" Then

                cadena = "select cod_recurso ,dsc_recurso ,b_ancho,b_alto,'' as cod_aux1,0 as num_aux1,1.00 as cant,imp_venta as pre_venta,dsc_tabla as dsc_grupo from tipo_recurso tr" _
                    & " inner join tipo_tabla tt on tt.cod_tabla=tr.cod_tabla " _
                    & " where tr.activo and tr.cod_tabla='" & cod_tabla.Substring(1, 4) & "' order by 2"

            Else

                cadena = " Select cod_art As cod_recurso,nom_art As dsc_recurso,t.b_ancho,t.b_alto,0 as num_aux1,g.cod_grupo As cod_aux1," & txtnro_adultos.Text & " as cant,a.pre_venta,g.nom_grupo As dsc_grupo " _
                     & " From articulo a inner Join subgrupo t on a.cod_grupov=t.cod_sgrupo " _
                     & " left join grupo g on g.cod_grupo=t.cod_grupo  inner join almacen al on a.cod_alma=al.cod_alma" _
                     & " where  a.activo And (t.esVenta) and al.esEvento  And a.cod_grupov = '" & cod_tabla & "' order by 2"

            End If
            mostrararticulos(cadena)
        End If
    End Sub
    Private Sub mostrararticulos(ByVal strSQL As String)
        Dim objconexion As MySqlConnection
        Dim da As New MySqlDataAdapter
        objconexion = Conexion.obtenerConexion()
        Dim mycomand As New MySqlCommand(strSQL, dbConex)
        da.SelectCommand = mycomand
        dsRecurso.Clear()
        da.Fill(dsRecurso, "recurso")

        Dim myreader As MySqlDataReader
        panelarticulos.Controls.Clear()
        Try
            myreader = mycomand.ExecuteReader()
            While myreader.Read
                Dim botona As New Button
                With botona
                    .Width = myreader("b_ancho")
                    .Height = myreader("b_alto")
                    .Visible = True
                    .TextAlign = ContentAlignment.MiddleCenter
                    .BackColor = Color.LightCoral
                    .ForeColor = Color.GhostWhite
                    .Text = myreader("dsc_recurso")
                    .Name = myreader("cod_recurso")
                End With
                panelarticulos.Controls.Add(botona)
                AddHandler botona.Click, AddressOf Me.botona_Click
                AddHandler botona.GotFocus, AddressOf Me.botona_GotFocus
                AddHandler botona.LostFocus, AddressOf Me.botona_LostFocus
                AddHandler botona.MouseMove, AddressOf Me.botona_MouseMove
                AddHandler botona.MouseLeave, AddressOf Me.botona_MouseLeave
                'ListBox1.Items.Add(myreader(0).ToString + Space(5) + myreader(1).ToString)
            End While
            myreader.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            objconexion.Close()
        End Try
    End Sub
    Private Sub botona_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        btn.BackColor = Color.CadetBlue
    End Sub

    Private Sub botona_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        'Volviendo al color inicial
        btn.BackColor = Color.LightCoral
    End Sub

    Private Sub botona_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        btn.BackColor = Color.CadetBlue
    End Sub
    Private Sub botona_MouseLeave(sender As Object, e As System.EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        btn.BackColor = Color.LightCoral
    End Sub

    Private Sub botona_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Obtenemos el botón pulsado
        Dim btn As Button = DirectCast(sender, Button)
        codigo = btn.Name
        agregaitem(codigo)

    End Sub
    Private Sub agregaitem(ByVal codigo As String)

        'Dim cod_tabla As String = cbotip_tabla.SelectedValue
        ' Dim fila As DataRow = IIf(cod_tabla = "0000", dtdetalleAyb.NewRow, dtDetalle.NewRow)
        Dim cadena As String
        Dim fila As DataRow
        If tabRecurso.IsSelected Then
            fila = dtDetalle.NewRow
        ElseIf tabayb.IsSelected Then
            fila = dtdetalleAyb.NewRow
        ElseIf tabPack.IsSelected Then
            fila = dtdetalleAyb.NewRow
        End If
        Dim buscafila() As DataRow
        buscafila = dsRecurso.Tables("recurso").Select("cod_recurso='" & codigo & "'")
        fila.Item("cod_recurso") = buscafila(0).Item("cod_recurso").ToString
        fila.Item("dsc_recurso") = buscafila(0).Item("dsc_recurso").ToString
        fila.Item("dsc_grupo") = buscafila(0).Item("dsc_grupo").ToString
        fila.Item("c_aux1") = buscafila(0).Item("cod_aux1").ToString
        fila.Item("n_aux1") = buscafila(0).Item("num_aux1").ToString
        fila.Item("cant") = buscafila(0).Item("cant")
        fila.Item("cant_prod") = buscafila(0).Item("cant")
        fila.Item("precio") = buscafila(0).Item("pre_venta")
        fila.Item("imp_venta") = fila.Item("precio") * fila.Item("cant")

        fila.Item("ingreso") = 0

        If consultas.esCombo(codigo) Then
            nom_grp = buscafila(0).Item("dsc_recurso").ToString
            cod_grp = buscafila(0).Item("cod_aux1").ToString
            fila.Item("n_aux1") = 1

            agregadetallegrid(fila)

            cadena = "select acd.cod_art as cod_recurso,b.nom_art as dsc_recurso,t.b_ancho,t.b_alto,precio as pre_venta,1 as num_aux1," _
                    & txtnro_adultos.Text & " as cant ,'" & cod_grp & "' as cod_aux1, '" & nom_grp & "' as dsc_grupo" _
                    & " from articulo a inner Join subgrupo t on a.cod_sgrupo=t.cod_sgrupo " _
                    & " inner Join grupo g on g.cod_grupo=t.cod_grupo " _
                    & " inner Join art_combo ac on ac.cod_art=a.cod_art  " _
                    & " inner Join art_combodet acd on acd.cod_combo=ac.cod_combo  " _
                    & " inner Join articulo b on b.cod_art=acd.cod_art " _
                    & " where a.activo And ac.cod_art='" & codigo & "' order by 1"
            mostrararticulos(cadena)
        ElseIf consultas.esComboEsp(codigo) Then
            nom_grp = buscafila(0).Item("dsc_recurso").ToString
            cod_grp = buscafila(0).Item("cod_aux1").ToString
            fila.Item("n_aux1") = 1

            agregadetallegrid(fila)

            cadena = " Select cod_art As cod_recurso,nom_art As dsc_recurso,t.b_ancho,t.b_alto,1 as num_aux1,0 as pre_venta," _
                     & txtnro_adultos.Text & " as cant ,'" & cod_grp & "' as cod_aux1, '" & nom_grp & "' as dsc_grupo" _
                     & " From articulo a inner Join subgrupo t on a.cod_sgrupo=t.cod_sgrupo " _
                     & " inner join grupo g on g.cod_grupo=t.cod_grupo " _
                     & " inner join tipo_articulo ta on ta.cod_tart=a.cod_tart " _
                     & "  Where a.activo And (t.esEvento) And (ta.esProductoTerminado) order by 2"
            mostrararticulos(cadena)
        ElseIf True Then

            agregadetallegrid(fila)
        End If

        calculaTotal()

    End Sub
    Sub agregadetallegrid(ByVal fila As DataRow)
        If tabRecurso.IsSelected Then
            dtDetalle.Rows.Add(fila)

        Else
            dtdetalleAyb.Rows.Add(fila)
        End If
    End Sub

    Sub agregaitems()
        For I = 0 To dsRecurso.Tables("recurso").Rows.Count - 1
            codigo = dsRecurso.Tables("recurso").Rows(I).Item("cod_recurso").ToString
            agregaitem(codigo)
        Next
    End Sub



    Sub cargaestructuratvrecursos()
        With tvRecursos
            .Columns.Item(0).Width.Absolute = 80
            .Columns.Item(1).Width.Absolute = 40
            .Columns.Item(2).Width.Absolute = 310
            .Columns.Item(3).Width.Absolute = 40
            .Columns.Item(4).Width.Absolute = 50
            .Columns.Item(5).Width.Absolute = 320
        End With
    End Sub
    Sub cargaestructuratvAyB()
        With tvAyB
            .Columns.Item(0).Width.Absolute = 80
            .Columns.Item(1).Width.Absolute = 40
            .Columns.Item(2).Width.Absolute = 310
            .Columns.Item(3).Width.Absolute = 40
            .Columns.Item(4).Width.Absolute = 50
            .Columns.Item(5).Width.Absolute = 320
        End With
    End Sub
    Sub cargaestructuraPack()
        With tvPack
            .Columns.Item(0).Width.Absolute = 80
            .Columns.Item(1).Width.Absolute = 40
            .Columns.Item(2).Width.Absolute = 310
            .Columns.Item(3).Width.Absolute = 40
            .Columns.Item(4).Width.Absolute = 50
            .Columns.Item(5).Width.Absolute = 320
        End With
    End Sub
    Sub nombreevento()
        txtnom_evento.Text = ""
        Dim nom_evento As String = cbotip_evento.Text
        Dim nom_cliente As String = cboCliente.Text
        txtnom_evento.Text = nom_evento & " " & nom_cliente
    End Sub

    Private Sub cbotip_evento_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        'nombreevento()
    End Sub


    Sub AgregadtItem(ByVal cant As Decimal, ByVal cant_prod As Decimal, ByVal precio As Decimal, ByVal obs As String)
        If validaGrabacion() Then

            If tabRecurso.IsSelected Then
                If dataDetalle.RowCount > 0 Then
                    Dim fila As Integer = dataDetalle.CurrentRow.Index
                    dataDetalle("obs", fila).Value = obs
                    dataDetalle("cant", fila).Value = cant
                    dataDetalle("cant_prod", fila).Value = cant_prod
                    dataDetalle("precio", fila).Value = precio
                    dataDetalle("imp_venta", fila).Value = cant * dataDetalle("precio", fila).Value
                End If
            Else
                If dataAyB.RowCount > 0 Then
                    Dim fila As Integer = dataAyB.CurrentRow.Index
                    dataAyB("obs", fila).Value = obs
                    dataAyB("cant", fila).Value = cant
                    dataAyB("cant_prod", fila).Value = cant_prod
                    dataAyB("precio", fila).Value = precio
                    dataAyB("imp_venta", fila).Value = cant * dataAyB("precio", fila).Value
                End If
            End If
            calculaTotal()
        End If
    End Sub

    Sub eliminadtitem()
        If validaGrabacion() Then
            Dim ifila, ingreso As Integer
            Dim mfila As DataRow
            Dim rpta As Integer
            rpta = MessageBox.Show("Esta Seguro de Eliminar el ITEM Seleccionado" + Chr(13) + "Este Proceso es Irreversible...", "EVENTOS", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2)
            If rpta = 6 Then
                If tabRecurso.IsSelected Then
                    ifila = dataDetalle.CurrentRow.Index
                    mfila = dtDetalle.Rows(ifila)
                    ingreso = dataDetalle("ingreso", ifila).Value
                    dtDetalle.Rows.Remove(mfila)
                Else
                    ifila = dataAyB.CurrentRow.Index
                    mfila = dtdetalleAyb.Rows(ifila)
                    ingreso = dataAyB("ingreso", ifila).Value
                    dtdetalleAyb.Rows.Remove(mfila)
                End If
                eliminar.eliminaEvento_det(nroOperacion, ingreso)
                calculaTotal()
            End If
            cargaestructuratvrecursos()
            cargaestructuratvAyB()
        End If
    End Sub

    Private Sub UbicarCliente(ByVal cod_cliente As String)
        Try
            'Dim fila As DataRow = dsCliente.Tables("cliente").Rows.Find(lcod)
            Dim fila() As DataRow
            fila = dsCliente.Tables("cliente").Select("cod_clie ='" & cod_cliente & "'")
            txtRuc.Text = fila(0).Item("cod_clie").ToString
            txtDirEntrega.Text = fila(0).Item("dir_ent").ToString
            'txtTelefono.Text = fila(0).Item("fono_clie").ToString
            ' txtEmail.Text = fila(0).Item("email_clie").ToString
            'cboContacto.Text = fila(0).Item("nom_cont").ToString
            cboCliente.SelectedValue = cod_cliente

        Catch err As Exception
            MessageBox.Show("Seleccione un Cliente Registrado...", "Eventos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            reiniciaCliente()
            'dsArticulo.Clear()
        End Try
    End Sub
    Private Sub UbicarContacto(ByVal cod_contacto As String)
        Dim clConex As New MySqlConnection
        Dim da As New MySqlDataAdapter
        Dim ds As New DataSet
        clConex = Conexion.obtenerConexion
        Dim cad As String
        cad = "Select * from cliente_contacto where activo=1 and cod_contacto ='" & cod_contacto & "' order by nom_contacto"
        Dim com As New MySqlCommand(cad)
        com.Connection = clConex
        da.SelectCommand = com
        da.Fill(ds, "contacto")
        Dim fila() As DataRow
        fila = ds.Tables("contacto").Select("cod_contacto ='" & cod_contacto & "'")
        txtEmail.Text = fila(0).Item("email_contacto").ToString
        txtTelefono.Text = fila(0).Item("fono_contacto").ToString
        txtobs_contacto.Text = fila(0).Item("obs_contacto").ToString



        clConex.Close()
    End Sub


    Sub reiniciaCliente()
        cboCliente.SelectedIndex = -1
        txtDirEntrega.Text = ""
        txtTelefono.Text = ""
        cboContacto.Text = ""
    End Sub



    Private Sub cmdimprimir_Click(sender As System.Object, e As System.EventArgs) Handles cmdimprimir.Click
        Dim frm As New rptForm
        Dim cTitulo As String = ""
        Dim dsevento As DataSet = consultas.recuperaevento_BEO(nroOperacion, False)
        frm.cargarBEOevento(dsevento, cTitulo)
        frm.MdiParent = principal
        frm.Show()


    End Sub



    Private Sub txtObservacion_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            'SendKeys.Send("{TAB}")
            txtObservacion.Focus()
        End If
    End Sub


    Private Sub cmdActualizar_Click(sender As System.Object, e As System.EventArgs) Handles cmdActualizar.Click
        cargaeventos(nroOperacion, dt_desde.Value, dt_hasta.Value, cbotip_salon.Text, False)
        modoHabilitado()
    End Sub
    Private Sub tvRecursos_DoubleClick(sender As Object, e As System.EventArgs) Handles tvRecursos.DoubleClick

        Dim IsFormCargado As Boolean = False
        Dim obs As String
        Dim cant, cant_prod, precio As Decimal
        Dim mForm As Form
        For Each mForm In principal.MdiChildren
            If mForm.Name = "p_notas" Then
                If mForm.WindowState = FormWindowState.Minimized Then
                    mForm.WindowState = FormWindowState.Normal
                Else
                    mForm.BringToFront()
                End If
                IsFormCargado = True
                Exit For
            End If
        Next
        mForm = Nothing
        Dim ifila As Integer = dataDetalle.CurrentRow.Index
        If IsFormCargado = False Then
            p_notas.MdiParent = principal
            p_notas.lblnotas.Text = p_notas.lblnotas.Text + " a :" + dataDetalle("dsc_recurso", ifila).Value
            If IsDBNull(dataDetalle("cant", ifila).Value) And IsDBNull(dataDetalle("obs", ifila).Value) Then
                obs = ""
                cant = 0
                cant_prod = 0
                precio = 0
            Else
                obs = dataDetalle("obs", ifila).Value.ToString
                cant = dataDetalle("cant", ifila).Value
                cant_prod = dataDetalle("cant_prod", ifila).Value
                precio = dataDetalle("precio", ifila).Value
            End If
            p_notas.datosNotas(cant, cant_prod, precio, obs)
            p_notas.txtcant.Focus()
        Else
            p_notas.lblnotas.Text = p_notas.lblnotas.Text + " a :" + dataDetalle("dsc_recurso", ifila).Value
            p_notas.Activate()
        End If
        dataDetalle.ClearSelection()
        p_notas.txtcant.Focus()
        p_notas.Show()
    End Sub



    Private Sub tvAyB_DoubleClick(sender As Object, e As System.EventArgs) Handles tvAyB.DoubleClick



        Dim IsFormCargado As Boolean = False
        Dim obs As String
        Dim cant, cant_prod, precio As Decimal
        Dim mForm As Form
        For Each mForm In principal.MdiChildren
            If mForm.Name = "p_notas" Then
                If mForm.WindowState = FormWindowState.Minimized Then
                    mForm.WindowState = FormWindowState.Normal
                Else
                    mForm.BringToFront()
                End If
                IsFormCargado = True
                Exit For
            End If
        Next
        mForm = Nothing
        Dim ifila As Integer = dataAyB.CurrentRow.Index
        If IsFormCargado = False Then
            p_notas.MdiParent = principal

            p_notas.lblnotas.Text = p_notas.lblnotas.Text + " a :" + dataAyB("dsc_recurso", ifila).Value
            If IsDBNull(dataAyB("cant", ifila).Value) And IsDBNull(dataAyB("obs", ifila).Value) Then
                obs = ""
                cant = 0
                cant_prod = 0
                precio = 0
            Else
                obs = dataAyB("obs", ifila).Value.ToString
                cant = dataAyB("cant", ifila).Value
                cant_prod = dataAyB("cant_prod", ifila).Value
                precio = dataAyB("precio", ifila).Value

            End If
            p_notas.datosNotas(cant, cant_prod, precio, obs)
        Else
            p_notas.lblnotas.Text = p_notas.lblnotas.Text + " a :" + dataAyB("dsc_recurso", ifila).Value
            p_notas.Activate()
        End If
        dataAyB.ClearSelection()
        p_notas.txtcant.Focus()
        p_notas.Show()
    End Sub



    Private Sub buscar_Click(sender As System.Object, e As System.EventArgs) Handles buscar.Click


        If tabRecurso.IsSelected Then

            cadena = "select cod_recurso ,dsc_recurso ,b_ancho,b_alto,'' as cod_aux1,0 as num_aux1,1.00 as cant,imp_venta as pre_venta,dsc_tabla as dsc_grupo from tipo_recurso tr" _
                    & " inner join tipo_tabla tt on tt.cod_tabla=tr.cod_tabla " _
                    & " where tr.activo and dsc_recurso like '%" & cbotip_tabla.Text & "%' order by 2"

        ElseIf tabayb.IsSelected Then

            cadena = " Select cod_art As cod_recurso,nom_art As dsc_recurso,t.b_ancho,t.b_alto,0 as num_aux1,g.cod_grupo As cod_aux1," & txtnro_adultos.Text & " as cant ,a.pre_venta,g.nom_grupo As dsc_grupo " _
                     & " From articulo a inner Join subgrupo t on a.cod_sgrupo=t.cod_sgrupo " _
                     & " left Join grupo g on g.cod_grupo=t.cod_grupo inner join almacen al on a.cod_alma=al.cod_alma " _
                     & "  Where a.activo And (t.esEvento) and al.esEvento and nom_art like '%" & cbotip_tabla.Text & "%' order by 2"

        ElseIf TabPack.IsSelected Then
            cadena = " Select cod_art As cod_recurso,nom_art As dsc_recurso,t.b_ancho,t.b_alto,1 as num_aux1,0 as pre_venta," _
                  & txtnro_adultos.Text & " as cant ,'" & cod_grp & "' as cod_aux1, '" & nom_grp & "' as dsc_grupo" _
                  & " From articulo a inner Join subgrupo t on a.cod_sgrupo=t.cod_sgrupo " _
                  & " left Join grupo g on g.cod_grupo=t.cod_grupo " _
                  & " inner join tipo_articulo ta on ta.cod_tart=a.cod_tart " _
                  & "  Where a.activo And (t.esEvento) And (ta.esProductoTerminado) and nom_art like '%" & cbotip_tabla.Text & "%' order by 2"
        End If


        mostrararticulos(cadena)
    End Sub

    Function validaGrabacion() As Boolean
        Dim valorRetorno As Boolean = True
        If Microsoft.VisualBasic.Len(txtid_numfactura.Text) > 0 Then
            MessageBox.Show("EVENTO FACTURADO...", "EVENTOS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            valorRetorno = False
        End If


        If Microsoft.VisualBasic.Len(txtRuc.Text) = 0 Then
            MessageBox.Show("Ingrese Ruc de Cliente...", "EVENTOS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ep.SetError(txtRuc, "Ingrese Ruc de Cliente...")
            txtRuc.Focus()
            valorRetorno = False
        End If


        Return valorRetorno
    End Function



    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        enviaCorreu()
    End Sub

    Private Sub enviaCorreu()
        'Dim m_OutLook As Outlook.Application
        'Try

        '    '* Creamos un Objeto tipo Mail  

        '    Dim objMail As Outlook.MailItem

        '    '* Inicializamos nuestra apliación OutLook  

        '    m_OutLook = New Outlook.Application



        '    '* Creamos una instancia de un objeto tipo MailItem 

        '    objMail = m_OutLook.CreateItem(Outlook.OlItemType.olMailItem)



        '    '* Asignamos las propiedades a nuestra Instancial del objeto 

        '    '* MailItem 

        '    objMail.To = txtEmail.Text

        '    objMail.Subject = txtnom_evento.Text

        '    objMail.Body = txtObservacion.Text

        '    'Si queremos enviar un archivo adjunto usamos este codigo… 
        '    'Dim sSource As String = "d:\ejemplo.txt"
        '    'Dim sDisplayName As String = "ejemplo.txt"
        '    'Dim sBodyLen As String = objMail.Body.Length
        '    'Dim oAttachs As Outlook.Attachments = objMail.Attachments
        '    'Dim oAttach As Outlook.Attachment
        '    'oAttach = oAttachs.Add(sSource, , sBodyLen + 1, sDisplayName)


        '    objMail.Display()

        '    'objMail.Send()



        '    '* Desplegamos un mensaje indicando que todo fue exitoso  

        '    'MessageBox.Show("Mail Enviado", "Integración con OutLook", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        'Catch ex As Exception

        '    '* Si se produce algun Error Notificar al usuario  

        '    MessageBox.Show("Error enviando mail")



        'Finally

        '    m_OutLook = Nothing



        'End Try
    End Sub



    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Close()
    End Sub

    Private Sub cboCliente_Validating(sender As Object, e As CancelEventArgs) Handles cboCliente.Validating
        If cboCliente.SelectedValue <> "" Then
            Dim fcod_clie As String = cboCliente.SelectedValue.ToString
            UbicarCliente(fcod_clie)
        End If
    End Sub

    Private Sub cboUnidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboUnidad.SelectedIndexChanged
        If Not estacargando Then
            If cboUnidad.SelectedValue <> "" Then
                Dim fcod_unidad As String = cboUnidad.SelectedValue.ToString
                cargarcontacto(fcod_unidad)
            End If
        End If
    End Sub



    Private Sub cboContacto_Validating(sender As Object, e As CancelEventArgs) Handles cboContacto.Validating
        If cboContacto.SelectedValue <> "" Then
            Dim fcod_contacto As String = cboContacto.SelectedValue.ToString
            UbicarContacto(fcod_contacto)
        End If
    End Sub

    Sub calculaTotal()
        Dim nroReg As Integer = 0, I As Integer = 0
        Dim lTotal As Decimal = 0
        Dim GTotal As Decimal = 0

        nroReg = dataDetalle.RowCount
        For I = 0 To nroReg - 1
            lTotal = lTotal + dataDetalle("imp_venta", I).Value
        Next
        txttotal_otros.Text = CDbl(lTotal).ToString("N2")
        GTotal = lTotal
        lTotal = 0
        nroReg = dataAyB.RowCount
        For I = 0 To nroReg - 1
            lTotal = lTotal + dataAyB("imp_venta", I).Value
        Next
        GTotal = GTotal + lTotal
        txttotal_ayb.Text = CDbl(lTotal).ToString("N2")
        lbltotal.Text = CDbl(GTotal).ToString("N2")

    End Sub


    Private Sub calculadetalle()

        Dim lcantidad, lprecio, lneto As Decimal
        'validamos el ingreso de cantidades no nulas
        Dim fila As Integer
        If dataAyB.SelectedRows.Count > 0 Then
            fila = dataAyB.CurrentRow.Index
            dataAyB("imp_venta", fila).Value = dataAyB("cant", fila).Value * dataAyB("precio", fila).Value
        End If
        If dataDetalle.SelectedRows.Count > 0 Then
            fila = dataDetalle.CurrentRow.Index
            dataDetalle("imp_venta", fila).Value = dataDetalle("cant", fila).Value * dataDetalle("precio", fila).Value
        End If


        'If IsDBNull(dataAyB("cant", dataAyB.CurrentRow.Index).Value) Or IsDBNull(dataAyB("precio", dataAyB.CurrentRow.Index).Value) Or IsDBNull(dataAyB("imp_venta", dataAyB.CurrentRow.Index).Value) Then
        '    dataAyB("precio", fila).Value = 0
        '    lprecio = 0
        '    dataAyB("imp_venta", fila).Value = 0
        '    lneto = 0
        'End If
        'If dataDetalle.CurrentCell.ColumnIndex = dataDetalle.Columns("cantidad").Index Then
        '    If IsDBNull(dataDetalle("cantidad", dataDetalle.CurrentRow.Index).Value) Or dataDetalle("cantidad", dataDetalle.CurrentRow.Index).Value = 0 Then
        '        lcantidad = 1
        '        dataDetalle("cantidad", dataDetalle.CurrentRow.Index).Value = 1
        '    Else
        '        lcantidad = dataDetalle("cantidad", dataDetalle.CurrentRow.Index).Value
        '        lprecio = dataDetalle("precio", dataDetalle.CurrentRow.Index).Value
        '        lneto = Round(lcantidad * lprecio, pDecimales)
        '        dataDetalle("neto", dataDetalle.CurrentRow.Index).Value = lneto
        '    End If
        '    'txtBuscar.Focus()
        '    'dataDetalle.ClearSelection()
        'End If
        'If dataDetalle.CurrentCell.ColumnIndex = dataDetalle.Columns("precio").Index Then
        '    If IsDBNull(dataDetalle("precio", dataDetalle.CurrentRow.Index).Value) Then
        '        lprecio = 0
        '        dataDetalle("precio", dataDetalle.CurrentRow.Index).Value = 0
        '    Else
        '        lprecio = dataDetalle("precio", dataDetalle.CurrentRow.Index).Value
        '        lcantidad = dataDetalle("cantidad", dataDetalle.CurrentRow.Index).Value
        '        lneto = Round(lcantidad * lprecio, pDecimales)
        '        dataDetalle("neto", dataDetalle.CurrentRow.Index).Value = lneto
        '    End If
        '    'txtBuscar.Focus()
        '    'dataDetalle.ClearSelection()
        'End If
        'If dataDetalle.CurrentCell.ColumnIndex = dataDetalle.Columns("neto").Index Then
        '    If IsDBNull(dataDetalle("neto", dataDetalle.CurrentRow.Index).Value) Then
        '        lneto = 0
        '        dataDetalle("neto", dataDetalle.CurrentRow.Index).Value = 0
        '    Else
        '        lneto = dataDetalle("neto", dataDetalle.CurrentRow.Index).Value
        '        lcantidad = dataDetalle("cantidad", dataDetalle.CurrentRow.Index).Value
        '        lprecio = Round(lneto / lcantidad, 10)
        '        dataDetalle("precio", dataDetalle.CurrentRow.Index).Value = lprecio
        '    End If
        'End If



    End Sub


    Private Sub tvAyB_CellEditEnding(sender As Object, e As CellEditEventArgs) Handles tvAyB.CellEditEnding
        calculadetalle()
    End Sub



    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click



        Dim frm As New rptForm
        Dim cTitulo As String = ""
        Dim dsevento As DataSet = consultas.recuperaevento_BEO(nroOperacion, True)
        frm.cargarOrdenTrabajo(dsevento, cTitulo)
        frm.MdiParent = principal
        frm.Show()


    End Sub


    Private Sub dt_horadesde_ValueChanged(sender As Object, e As EventArgs) Handles dt_horadesde.ValueChanged
        dt_horproduccion.Value = dt_horadesde.Value.AddMinutes(-90)
    End Sub

    Private Sub tvRecursos_Click(sender As Object, e As EventArgs) Handles tvRecursos.Click

    End Sub

    Private Sub tvAyB_Click(sender As Object, e As EventArgs) Handles tvAyB.Click

    End Sub

    Private Sub cboCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCliente.SelectedIndexChanged
        If Not estacargando Then
            If cboCliente.SelectedValue <> "" Then
                Dim fcod_cliente As String = cboCliente.SelectedValue.ToString
                cargarunidad(fcod_cliente)
            End If
        End If
    End Sub

    Private Sub tvPack_DoubleClick(sender As Object, e As EventArgs) Handles tvPack.DoubleClick


        Dim IsFormCargado As Boolean = False
        Dim obs As String
        Dim cant, cant_prod, precio As Decimal
        Dim mForm As Form
        For Each mForm In principal.MdiChildren
            If mForm.Name = "p_notas" Then
                If mForm.WindowState = FormWindowState.Minimized Then
                    mForm.WindowState = FormWindowState.Normal
                Else
                    mForm.BringToFront()
                End If
                IsFormCargado = True
                Exit For
            End If
        Next
        mForm = Nothing
        Dim ifila As Integer = dataAyB.CurrentRow.Index
        If IsFormCargado = False Then
            p_notas.MdiParent = principal

            p_notas.lblnotas.Text = p_notas.lblnotas.Text + " a :" + dataAyB("dsc_recurso", ifila).Value
            If IsDBNull(dataAyB("cant", ifila).Value) And IsDBNull(dataAyB("obs", ifila).Value) Then
                obs = ""
                cant = 0
                cant_prod = 0
                precio = 0
            Else
                obs = dataAyB("obs", ifila).Value.ToString
                cant = dataAyB("cant", ifila).Value
                cant_prod = dataAyB("cant_prod", ifila).Value
                precio = dataAyB("precio", ifila).Value

            End If
            p_notas.datosNotas(cant, cant_prod, precio, obs)
        Else
            p_notas.lblnotas.Text = p_notas.lblnotas.Text + " a :" + dataAyB("dsc_recurso", ifila).Value
            p_notas.Activate()
        End If
        dataAyB.ClearSelection()
        p_notas.txtcant.Focus()
        p_notas.Show()
    End Sub
End Class
