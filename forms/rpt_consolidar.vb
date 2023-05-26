
Imports MySql.Data.MySqlClient

Public Class rpt_consolidar
    Private dsCliente As New DataSet
    Private dtCliente As New DataTable("cliente")
    Private dsSucursal As New DataSet
    Private dtSucursal As New DataTable("sucursal")
    Private cadena As String
    Private estacargando As Boolean = True

    Private Sub cmdImprimir_Click(sender As Object, e As EventArgs) Handles cmdImprimir.Click
        Dim frm As New rptForm
        If optReservas.Checked Then

            Dim cTitulo As String = "CONSOLIDADO POR UNIDAD"
            Dim cFecha As String = "Desde: " + dtiDesde.Value.ToString("yyyy-MM-dd") + "  Hasta: " + dtiHasta.Value.ToString("yyyy-MM-dd")
            Dim es_xContacto As Boolean = IIf(ChkContacto.Checked, True, False)

            Dim dsevento As DataSet = consultas.recuperaevento_consolidar(dtiDesde.Value, dtiHasta.Value, True, es_xContacto, cboContacto.SelectedValue)
            frm.cargarconsolidar(dsevento, cTitulo, cFecha, 1)
        End If
        If opt_reservasxid.Checked Then
            Dim cTitulo As String = "CONSOLIDADO POR ID"
            Dim cFecha As String = "Desde: " + dtiDesde.Value.ToString("yyyy-MM-dd") + "  Hasta: " + dtiHasta.Value.ToString("yyyy-MM-dd")
            Dim es_xCliente As Boolean = IIf(ChkCliente.Checked, True, False)

            Dim dsevento As DataSet = consultas.recuperaevento_consolidarxid(dtiDesde.Value, dtiHasta.Value, True, es_xCliente, cboCliente.SelectedValue)
            frm.cargarconsolidar(dsevento, cTitulo, cFecha, 2)
        End If
        If opt_reservasfac.Checked Then
            Dim cTitulo As String = "CONSOLIDADO POR FACTRURAS"
            Dim cFecha As String = "Desde: " + dtiDesde.Value.ToString("yyyy-MM-dd") + "  Hasta: " + dtiHasta.Value.ToString("yyyy-MM-dd")
            Dim es_xCliente As Boolean = IIf(ChkCliente.Checked, True, False)

            Dim dsevento As DataSet = consultas.recuperaevento_consolidarxfactura(dtiDesde.Value, dtiHasta.Value, True, es_xCliente, cboCliente.SelectedValue)
            frm.cargarconsolidar(dsevento, cTitulo, cFecha, 3)
        End If

        frm.MdiParent = principal
        frm.Show()
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub rpt_consolidar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtiDesde.Value = pFechaSystem
        dtiHasta.Value = pFechaSystem


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

    Private Sub cboCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCliente.SelectedIndexChanged
        If Not estacargando Then
            If cboCliente.SelectedValue <> "" Then
                Dim fcod_cliente As String = cboCliente.SelectedValue.ToString
                cargarunidad(fcod_cliente)
            End If
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

    Private Sub ChkContacto_CheckedChanged(sender As Object, e As EventArgs) Handles ChkContacto.CheckedChanged

    End Sub
End Class
