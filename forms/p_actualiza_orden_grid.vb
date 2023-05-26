Public Class p_actualiza_orden_grid
    Private estaCargando = True
    Private dt As New DataTable
    Private dsevento As New DataSet
    Private dv, dv2 As New DataView
    Private columName As String = "id_factura"
    Private Sub p_actualiza_orden_grid_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        muestrareservas1()
        creagrid2()
        muestrareservas2()
        estaCargando = False
    End Sub
    Sub muestrareservas1()
        datagv_idr1.DataSource = ""

        Dim dsevento As DataSet = consultas.recupera_idfactura()
        dv.Table = dsevento.Tables("eventos")
        datagv_idr1.DataSource = dv

        With datagv_idr1.DefaultCellStyle
            .Font = New Font("Arial", 8)
            .ForeColor = Color.Black
            .BackColor = Color.Beige
            .SelectionForeColor = Color.Yellow
            .SelectionBackColor = Color.Black
            .Alignment = DataGridViewContentAlignment.MiddleLeft
        End With

        With datagv_idr1
            '.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("id_factura").HeaderText = "id_factura"
            .Columns("id_factura").Width = 60
            .Columns("id_factura").ReadOnly = True
            .Columns("id_factura").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("fecha").HeaderText = "fecha"
            .Columns("fecha").Width = 100
            .Columns("fecha").ReadOnly = True
            .Columns("fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("fecha").DefaultCellStyle.Format = "d"
            .Columns("importe").HeaderText = "importe"
            .Columns("importe").Width = 100
            .Columns("importe").ReadOnly = True
            .Columns("importe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("importe").DefaultCellStyle.Format = "c"
            .Columns("operacion").Visible = False
        End With
        muestraTotales()

    End Sub
    Sub creagrid2()

        Dim ds As New DataSet
        dt.Columns.Add(New DataColumn("id_factura", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        dt.Columns.Add(New DataColumn("importe", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("operacion", GetType(Integer)))
        dt.Columns.Add(New DataColumn("num_factura", GetType(String)))
        ds.Tables.Add(dt)
        datagv_idr2.DataSource = dt
    End Sub

    Sub muestrareservas2()

        With datagv_idr2
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("id_factura").Visible = True
            .Columns("id_factura").HeaderText = "id_factura"
            .Columns("id_factura").Width = 60
            .Columns("id_factura").ReadOnly = True
            .Columns("id_factura").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("fecha").Visible = True
            .Columns("fecha").HeaderText = "fecha"
            .Columns("fecha").Width = 100
            .Columns("fecha").ReadOnly = True
            .Columns("fecha").DefaultCellStyle.Format = "d"
            .Columns("fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("importe").Visible = True
            .Columns("importe").HeaderText = "importe"
            .Columns("importe").Width = 100
            .Columns("importe").ReadOnly = True
            .Columns("importe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("importe").DefaultCellStyle.Format = "c"
            .Columns("operacion").Visible = False
            .Columns("num_factura").Visible = False
        End With
        LblFactura.Text = ""
        muestraTotales()



    End Sub

    Sub muestraTotales()
        'Totaliza grilla 1
        Dim cMonto1 As Decimal = 0
        Dim I As Integer = 0
        For I = 0 To datagv_idr1.RowCount - 1
            cMonto1 = cMonto1 + datagv_idr1.Item("importe", I).Value
        Next
        lblMonto1.Text = "Monto..." & Format(cMonto1, "####,###.##")

        'Totaliza grilla 2
        Dim cMonto2 As Decimal = 0
        Dim X As Integer = 0
        For X = 0 To datagv_idr2.RowCount - 1
            cMonto2 = cMonto2 + datagv_idr2.Item("importe", X).Value
        Next

        lblmonto2.Text = "Monto..." & Format(cMonto2, "####,###.##")

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Len(LblFactura.Text) = 0 Then

            Dim coleccion As DataGridViewSelectedRowCollection = datagv_idr1.SelectedRows
            For Each fila As DataGridViewRow In coleccion
                Dim operacion As Integer
                Dim id_factura As String
                Dim fecha As Date
                Dim importe As Decimal
                operacion = datagv_idr1(0, fila.Index).Value
                id_factura = datagv_idr1(1, fila.Index).Value
                fecha = datagv_idr1(2, fila.Index).Value
                importe = datagv_idr1(3, fila.Index).Value

                dt.Rows.Add(id_factura, fecha, importe, operacion)
                'datagv_idr2.Rows.Add(id_factura, fecha, importe, operacion)
                datagv_idr1.Rows.RemoveAt(fila.Index)
            Next
            muestraTotales()
        End If
    End Sub


    Private Sub datagv_idr1_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles datagv_idr1.ColumnHeaderMouseClick
        ' Obtenemos el índice de la columna
        '
        Dim columnIndex As Integer = e.ColumnIndex
        columName = datagv_idr1.Columns.Item(columnIndex).Name
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        If Not estaCargando Then
            If columName = "fila" Or columName = "id_factura" Or columName = "cant" Or columName = "precio" Or columName = "imp_total" Then
                dv.RowFilter = String.Format("Convert({0}, 'System.String') Like '%{1}%'", columName, TextBox1.Text)
            Else
                dv.RowFilter = String.Format("{0} like '%{1}%'", columName, TextBox1.Text)
            End If
            muestraTotales()
        End If
    End Sub

    Private Sub buscar2_Click(sender As Object, e As EventArgs) Handles buscar2.Click
        datagv_idr2.DataSource = ""
        Dim dsevento As DataSet = consultas.recupera_ordencompra(txtNumOrden.Text)
        dt = dsevento.Tables("dt")
        datagv_idr2.DataSource = dt
        muestrareservas2()
        If datagv_idr2.RowCount() > 0 Then
            LblFactura.Text = dt.Rows(0).Item("num_factura").ToString
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        inicializagrid()
    End Sub
    Sub inicializagrid()
        muestrareservas1()
        dt.Clear()
        datagv_idr2.Refresh()
        muestrareservas2()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        If Len(txtNumOrden.Text) > 0 Then
            If datagv_idr2.RowCount > 0 Then
                Dim numfactura As String = consultas.devuelve_numfactura(txtNumOrden.Text)

                If numfactura <> "" Then
                    Dim Respuesta As DialogResult
                    Respuesta = MessageBox.Show(" Orden fue facturada con Nro Factura:" & numfactura & "..esta Seguro Liberarla ", "SGA", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
                    If (Respuesta = DialogResult.Yes) Then
                        actualizar.actualizar_eliminanumorden(txtNumOrden.Text)
                    Else
                        MessageBox.Show(" Nro Orden:" & txtNumOrden.Text & "..No Se Actualizo!! ")
                    End If


                Else
                    actualizar.actualizar_eliminanumorden(txtNumOrden.Text)
                    MessageBox.Show(" Nro Orden:" & txtNumOrden.Text & "..Se Actualizo Correctamente ")

                End If

                inicializagrid()
            Else
                MessageBox.Show("Saleccione id factura ")
            End If
        Else
            MessageBox.Show("Ingrese Numero de Orden ")
        End If
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Dim frm As New rptForm
        Dim cTitulo As String = ""
        Dim nroOrden As String = txtNumOrden.Text
        Dim dsevento As DataSet = consultas.recuperaevento_BEO_orden(nroOrden, False)
        frm.cargarBEOevento_sunat(dsevento, cTitulo)
        frm.MdiParent = principal
        frm.Show()

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If Len(txtNumOrden.Text) > 0 Then
            If datagv_idr2.RowCount > 0 Then
                For X = 0 To datagv_idr2.RowCount - 1
                    actualizar.actualizarnumorden(datagv_idr2("id_factura", X).Value, datagv_idr2("fecha", X).Value, txtNumOrden.Text)
                Next
                MessageBox.Show(" Nro Orden:" & txtNumOrden.Text & "..Se Actualizo Correctamente ")
                inicializagrid()
            Else
                MessageBox.Show("Saleccione id factura ")
            End If
        Else
            MessageBox.Show("Ingrese Numero de Orden ")
        End If
    End Sub


End Class
