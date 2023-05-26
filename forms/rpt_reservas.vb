Imports MySql.Data.MySqlClient



Public Class rpt_reservas
    Inherits System.Windows.Forms.Form
    Private estaCargando = True
    Private dsevento As New DataSet
    Private dv As New DataView
    Private columName As String = "id_factura"

    Private Sub rpt_reservas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        estableceFechas()
    End Sub

    Sub estableceFechas()
        mcDesde.DisplayMonth = pFechaSystem
        mcDesde.SelectedDate = pFechaSystem
        mcHasta.DisplayMonth = pFechaSystem
        mcHasta.SelectedDate = pFechaSystem
    End Sub

    Private Sub txtFiltro_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro.TextChanged

        If Not estaCargando Then
            If columName = "fila" Or columName = "id_factura" Or columName = "cant" Or columName = "precio" Or columName = "imp_total" Then
                dv.RowFilter = String.Format("Convert({0}, 'System.String') Like '%{1}%'", columName, txtFiltro.Text)
            Else
                dv.RowFilter = String.Format("{0} like '%{1}%'", columName, txtFiltro.Text)
            End If
            muestraTotales()
        End If
    End Sub

    Private Sub Datadetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles Datadetalle.KeyDown
        If (e.Control And e.KeyCode = Keys.E) Then
            If Datadetalle.RowCount > 0 Then
                EnviaraExcel(Datadetalle)
            End If
        End If
    End Sub



    Private Sub Datadetalle_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Datadetalle.ColumnHeaderMouseClick
        ' Obtenemos el índice de la columna
        '
        Dim columnIndex As Integer = e.ColumnIndex
        columName = Datadetalle.Columns.Item(columnIndex).Name
    End Sub



    Private Sub Datadetalle_DoubleClick(sender As Object, e As EventArgs) Handles Datadetalle.DoubleClick
        Dim escopia As Boolean
        Dim IsFormCargado As Boolean = False
        Dim mForm As Form
        For Each mForm In principal.MdiChildren
            If mForm.Name = "p_eventos" Then
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

            p_eventos.MdiParent = principal

            Dim ifila As Integer = Datadetalle.CurrentRow.Index

            Dim cod_salon As String

            If IsDBNull(Datadetalle("nom_salon", ifila).Value) Then
                cod_salon = ""
            Else
                cod_salon = Datadetalle("nom_salon", ifila).Value
            End If
            p_eventos.Show()

            If chkCopia.Checked Then
                Dim msgRslt As MsgBoxResult = MsgBox("Esta Seguro de realizar una Copia!!.", MsgBoxStyle.YesNo)
                If msgRslt = MsgBoxResult.Yes Then
                    escopia = True
                Else
                    escopia = False
                End If
            End If
            p_eventos.cargaeventos(Datadetalle("operacion", ifila).Value, Datadetalle("fecha_atencion", ifila).Value, Datadetalle("fecha_atencion", ifila).Value, cod_salon, escopia)
        End If
    End Sub
    Sub Actualiza_numorden(ByVal nro_orden As String, ByVal numfactura As String, ByVal esfactura As Boolean)
        Dim ifila As Integer = Datadetalle.CurrentRow.Index
        If esfactura Then
            actualizar.actualizarnumFactura(nro_orden, numfactura)
        Else
            actualizar.actualizarnumorden(Datadetalle("id_factura", ifila).Value, "", nro_orden)
        End If

        muestrareservas()
    End Sub

    Private Sub cmdProcesar_Click(sender As Object, e As EventArgs) Handles cmdProcesar.Click
        muestrareservas()
    End Sub

    Sub cargaEstructuraReservas()


        With Datadetalle.DefaultCellStyle
            .Font = New Font("Arial", 8)
            .ForeColor = Color.Black
            .BackColor = Color.Beige
            .SelectionForeColor = Color.Yellow
            .SelectionBackColor = Color.Black
            .Alignment = DataGridViewContentAlignment.MiddleLeft
        End With

        With Datadetalle
            .ReadOnly = True
            .Columns("fila").HeaderText = "FILA"
            .Columns("fila").DisplayIndex = 1
            .Columns("fila").Width = 3
            .Columns("fecha_atencion").HeaderText = "FECHA DE ATENCION"
            .Columns("fecha_atencion").DisplayIndex = 2
            .Columns("fecha_atencion").Width = 6
            .Columns("nom_evento").HeaderText = "ASUNTO"
            .Columns("nom_evento").DisplayIndex = 3
            .Columns("nom_evento").Width = 20
            .Columns("id_factura").HeaderText = "ID SOLICITUD"
            .Columns("id_factura").DisplayIndex = 4
            .Columns("id_factura").Width = 6


            .Columns("tip_evento").HeaderText = "TIPO DE EVENTO"
            .Columns("tip_evento").DisplayIndex = 7
            .Columns("tip_evento").Width = 20
            .Columns("nom_unidad").HeaderText = "UNIDAD"
            .Columns("nom_unidad").DisplayIndex = 8
            .Columns("nom_unidad").Width = 20
            .Columns("nom_contacto").HeaderText = "CONTACTO"
            .Columns("nom_contacto").DisplayIndex = 9
            .Columns("nom_contacto").Width = 20
            .Columns("fono_contacto").HeaderText = "ANEXO"
            .Columns("fono_contacto").DisplayIndex = 10
            .Columns("fono_contacto").Width = 8
            .Columns("email_contacto").HeaderText = "EMAIL"
            .Columns("email_contacto").DisplayIndex = 11
            .Columns("email_contacto").Width = 10
            .Columns("nom_salon").HeaderText = "LUGAR"
            .Columns("nom_salon").DisplayIndex = 12
            .Columns("nom_salon").Width = 30
            .Columns("dsc_recurso").HeaderText = "DESCRIPCION"
            .Columns("dsc_recurso").DisplayIndex = 13
            .Columns("dsc_recurso").Width = 50
            .Columns("cant").HeaderText = "CANTIDAD"
            .Columns("cant").DisplayIndex = 14
            .Columns("cant").Width = 5
            .Columns("cant").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("cant_prod").HeaderText = "CANTIDAD PROD"
            .Columns("cant_prod").DisplayIndex = 14
            .Columns("cant_prod").Width = 5
            .Columns("cant_prod").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("precio").HeaderText = "PRECIO"
            .Columns("precio").DisplayIndex = 15
            .Columns("precio").Width = 5
            .Columns("precio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("imp_total").HeaderText = "IMPORTE TOTAL"
            .Columns("imp_total").DisplayIndex = 16
            .Columns("imp_total").Width = 5
            .Columns("imp_total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("postventa").HeaderText = "POSTVENTA"
            .Columns("postventa").DisplayIndex = 17
            .Columns("postventa").Width = 10
            .Columns("postventa").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight



            .Columns("hor_prod").HeaderText = "HORA PRODUCCION"
            .Columns("hor_prod").DisplayIndex = 18
            .Columns("hor_prod").Width = 10
            .Columns("hor_prod").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("hor_ini").HeaderText = "HORA INICIO EVENTO"
            .Columns("hor_ini").DisplayIndex = 19
            .Columns("hor_ini").Width = 10
            .Columns("hor_ini").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("notas").HeaderText = "ATENCION"
            .Columns("notas").DisplayIndex = 20
            .Columns("notas").Width = 10
            .Columns("notas_det").HeaderText = "OBSERVACIONES"
            .Columns("notas_det").DisplayIndex = 21
            .Columns("notas_det").Width = 10
            .Columns("tip_recurso").HeaderText = "TIPO"
            .Columns("tip_recurso").DisplayIndex = 22
            .Columns("tip_recurso").Width = 11
            .Columns("estado").HeaderText = "ESTADO"
            .Columns("estado").DisplayIndex = 23
            .Columns("estado").Width = 10
            .Columns("num_orden").HeaderText = "NUM ORDEN"
            .Columns("num_orden").DisplayIndex = 24
            .Columns("num_orden").Width = 10
            .Columns("num_factura").HeaderText = "NUM FACTURA"
            .Columns("num_factura").DisplayIndex = 24
            .Columns("num_factura").Width = 10


            .Columns("operacion").Visible = False
            .Columns("num_contrato").Visible = False
            .Columns("vendedor").Visible = False
            .Columns("nom_cliente").Visible = False
            .Columns("num_pax").Visible = False
            .Columns("dsc_grupo").Visible = False
            .Columns("cod_reserva").Visible = False
            .Columns("ingreso").Visible = False

        End With
    End Sub
    Sub cargaEstructuraPeventos()

        With Datadetalle.DefaultCellStyle
            .Font = New Font("Arial", 8)
            .ForeColor = Color.Black
            .BackColor = Color.Beige
            .SelectionForeColor = Color.Yellow
            .SelectionBackColor = Color.Black
            .Alignment = DataGridViewContentAlignment.MiddleLeft
        End With

        With Datadetalle
            .ReadOnly = True
            .Columns("fila").HeaderText = "FILA"
            .Columns("fila").DisplayIndex = 1

            .Columns("tip_evento").HeaderText = "TIPO DE EVENTO"
            .Columns("tip_evento").DisplayIndex = 7
            .Columns("tip_evento").Width = 20
            .Columns("nom_unidad").HeaderText = "UNIDAD"
            .Columns("nom_unidad").DisplayIndex = 8
            .Columns("nom_unidad").Width = 20
            .Columns("nom_contacto").HeaderText = "CONTACTO"
            .Columns("nom_contacto").DisplayIndex = 9
            .Columns("nom_contacto").Width = 20
            .Columns("fono_contacto").HeaderText = "ANEXO"
            .Columns("fono_contacto").DisplayIndex = 10
            .Columns("fono_contacto").Width = 8
            .Columns("email_contacto").HeaderText = "EMAIL"
            .Columns("email_contacto").DisplayIndex = 11
            .Columns("email_contacto").Width = 10
            .Columns("nom_salon").HeaderText = "LUGAR"
            .Columns("nom_salon").DisplayIndex = 12
            .Columns("nom_salon").Width = 30
            .Columns("dsc_recurso").HeaderText = "DESCRIPCION"
            .Columns("dsc_recurso").DisplayIndex = 13
            .Columns("dsc_recurso").Width = 50
            .Columns("cant").HeaderText = "CANTIDAD"
            .Columns("cant").DisplayIndex = 14
            .Columns("cant").Width = 5
            .Columns("cant").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("hor_prod").HeaderText = "HORA PRODUCCION"
            .Columns("hor_prod").DisplayIndex = 15
            .Columns("hor_prod").Width = 10
            .Columns("hor_prod").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("hor_ini").HeaderText = "HORA INICIO EVENTO"
            .Columns("hor_ini").DisplayIndex = 16
            .Columns("hor_ini").Width = 10
            .Columns("hor_ini").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("notas").HeaderText = "ATENCION"
            .Columns("notas").DisplayIndex = 17
            .Columns("notas").Width = 10
            .Columns("notas_det").HeaderText = "OBSERVACIONES"
            .Columns("notas_det").DisplayIndex = 18
            .Columns("notas_det").Width = 10

            .Columns("operacion").Visible = False
            .Columns("fecha_Atencion").Visible = False
            .Columns("num_contrato").Visible = False
            .Columns("ESTADO").Visible = False
            .Columns("nom_evento").Visible = False
            .Columns("vendedor").Visible = False
            .Columns("nom_cliente").Visible = False
            .Columns("num_pax").Visible = False
            .Columns("dsc_grupo").Visible = False
            .Columns("precio").Visible = False
            .Columns("cod_reserva").Visible = False
            .Columns("imp_total").Visible = False
            .Columns("id_factura").Visible = False
        End With
    End Sub

    Private Sub optReservas_CheckedChanged(sender As Object, e As EventArgs) Handles optReservas.CheckedChanged
        If Not estaCargando Then
            muestrareservas()

        End If
    End Sub
    Sub muestrareservas()
        Datadetalle.DataSource = ""
        estaCargando = False
        Dim dsevento As DataSet = consultas.recuperaevento_xfecha(mcDesde.SelectedDate, mcHasta.SelectedDate, chkestado.Checked, ChkAdicional.Checked)
        dv.Table = dsevento.Tables("eventos")
        Datadetalle.DataSource = dv
        If optReservas.Checked Then
            cargaEstructuraReservas()
        End If
        If optProgEventos.Checked Then
            cargaEstructuraPeventos()
        End If
        muestraTotales()
    End Sub

    Private Sub cmdImprimir_Click(sender As Object, e As EventArgs) Handles cmdImprimir.Click
        Dim frm As New rptForm
        Dim cTitulo As String = ""

        Dim dsevento As DataSet = consultas.recuperaevento_xfecha(mcDesde.SelectedDate, mcHasta.SelectedDate, chkestado.Checked, ChkAdicional.Checked)

        If optReservas.Checked Then
            frm.cargarListaOT(dsevento, cTitulo)

        End If
        If optProgEventos.Checked Then
            frm.cargarOrdenTrabajo(dsevento, cTitulo)
        End If

        If opt_etiquetas.Checked Then
            frm.cargarEtiquetas(dsevento)
        End If

        frm.MdiParent = principal
        frm.Show()

    End Sub
    Sub muestraTotales()
        Dim cMonto As Decimal = 0
        Dim I As Integer = 0
        For I = 0 To Datadetalle.RowCount - 1
            cMonto = cMonto + Datadetalle.Item("imp_total", I).Value
        Next
        lblMonto.Text = "Monto..." & Format(cMonto, "####,###.##")
    End Sub


    'Private Sub ButtonX1_Click(sender As Object, e As EventArgs)

    '    Dim ifila As Integer = 0
    '    If Datadetalle.RowCount() > 0 Then
    '        ifila = Datadetalle.CurrentRow.Index

    '        Dim num_idfactura As String = Datadetalle("id_factura", ifila).Value
    '        Dim num_orden As String = Datadetalle("num_orden", ifila).Value

    '        Dim isformcargado As Boolean = False
    '        Dim mForm As Form
    '        For Each mForm In principal.MdiChildren
    '            If mForm.Name = "p_actualiza_orden" Then
    '                If mForm.WindowState = FormWindowState.Minimized Then
    '                    mForm.WindowState = FormWindowState.Normal
    '                Else
    '                    mForm.BringToFront()
    '                End If
    '                isformcargado = True
    '                Exit For
    '            End If
    '        Next
    '        mForm = Nothing

    '        If isformcargado = False Then
    '            p_actualiza_orden.MdiParent = principal
    '        Else
    '            p_actualiza_orden.Activate()
    '        End If
    '        p_actualiza_orden.numidfactura(num_idfactura, num_orden)
    '        p_actualiza_orden.Show()
    '    End If
    'End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        Dim isformcargado As Boolean = False
        Dim mForm As Form
        For Each mForm In principal.MdiChildren
            If mForm.Name = "p_actualiza_orden_grid" Then
                If mForm.WindowState = FormWindowState.Minimized Then
                    mForm.WindowState = FormWindowState.Normal
                Else
                    mForm.BringToFront()
                End If
                isformcargado = True
                Exit For
            End If
        Next
        mForm = Nothing

        If isformcargado = False Then
            p_actualiza_orden_grid.MdiParent = principal
        Else
            p_actualiza_orden_grid.Activate()
        End If

        p_actualiza_orden_grid.Show()
    End Sub



    'Private Sub mostrarForm(ByVal nombreform As String)
    '    'Creamos una variable tipo Form
    '    Dim frmdinamico As Form
    '    'Extraemos toda la información necesaria para poder pasar
    '    'con el solo nombre del formulario a la variable "frmdinamico", el objeto
    '    Dim proyecto As String
    '    proyecto = Application.ProductName
    '    frmdinamico = DirectCast(Activator.CreateInstance(Type.GetType(proyecto + "." + nombreform)), Form)
    '    'Llamamos la rutina que no permitira abrir 2 veces el formulario
    '    Abrirformulario(frmdinamico, Me)
    'End Sub
    'Public Sub Abrirformulario(ByVal formulario As Form, ByVal mdi As Form)
    '    Dim frmllamado As Form
    '    Dim escargado As Boolean = False
    '    Try
    '        'chequemos si el formulario ha sido cargado
    '        For Each frmllamado In mdi.MdiChildren
    '            'Compara si es igual y retorna verdadero si lo es.
    '            If frmllamado.Text = formulario.Text Then
    '                'Marca la bandera
    '                escargado = True
    '                'Sale del loop si es verdadero
    '                Exit For
    '            End If
    '        Next

    '        If Not escargado Then
    '            'Carga el formulario si no esta llamado
    '            formulario.MdiParent = mdi
    '            formulario.Show()
    '        ElseIf escargado Then
    '            'Enfoca el objeto
    '            frmllamado.Focus()
    '        End If

    '        'Nada que hacer, toca colocar la exception
    '    Catch ex As Exception
    '        'Mostrar mensaje
    '        MsgBox(ex.Message & vbCrLf & ex.Source & vbCrLf &
    '               ex.StackTrace, MsgBoxStyle.Critical, "Error")
    '    End Try
    '    'Limpiar todo
    '    formulario = Nothing
    '    frmllamado = Nothing
    'End Sub


End Class