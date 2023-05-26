Imports MySql.Data.MySqlClient

Public Class m_recursos
    Private darecurso As New MySqlDataAdapter
    Private cbRecurso As MySqlCommandBuilder = New MySqlCommandBuilder(darecurso)
    Private dsfamilia As New DataSet
    Private dsRecurso As New DataSet
    Private dtRecurso As DataTable
    Private bsRecurso As New BindingSource
    Private estacargando As Boolean = True
    Private sepDecimal As Char

    Private Sub cmdCerrar_Click(sender As System.Object, e As System.EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub m_recursos_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        principal.mp_recursos.Enabled = True
    End Sub

    Private Sub m_recursos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'dataset tablas
        sepDecimal = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
        Dim daFamilia As New MySqlDataAdapter
        Dim comFamilia As New MySqlCommand("select cod_tabla,dsc_tabla from tipo_tabla where activo=1 order by dsc_tabla", dbConex)
        daFamilia.SelectCommand = comFamilia
        daFamilia.Fill(dsfamilia, "familia")
        With cboFamilia
            .DataSource = dsfamilia.Tables("familia")
            .DisplayMember = dsfamilia.Tables("familia").Columns("dsc_tabla").ToString
            .ValueMember = dsfamilia.Tables("familia").Columns("cod_tabla").ToString
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.ListItems
            '.SelectedIndex = -1
        End With
        Dim cod_tabla As String = cboFamilia.SelectedValue
        'cargamos el dataset
        cargardataset(cod_tabla)

        'relacionamos los cuadros de texto con el bindingSource
        txtCodigo.DataBindings.Add("text", bsRecurso, "cod_recurso")
        txtDescripcion.DataBindings.Add("text", bsRecurso, "dsc_recurso")
        txtPreCosto.DataBindings.Add("text", bsRecurso, "imp_costo")
        txtPreVenta.DataBindings.Add("text", bsRecurso, "imp_venta")
        chkActivo.DataBindings.Add("checked", bsRecurso, "activo")
        estacargando = False
    End Sub
    Sub cargardataset(ByVal cod_tabla As String)
        dsRecurso.Clear()
        Dim com As New MySqlCommand("Select cod_recurso,dsc_recurso,cod_tabla,imp_costo,imp_venta,activo from tipo_recurso where activo and cod_tabla = '" & cod_tabla & "' order by cod_recurso", dbConex)
        darecurso.SelectCommand = com
        darecurso.Fill(dsRecurso, "recurso")
        bsRecurso.DataSource = dsRecurso
        bsRecurso.DataMember = "recurso"
        datos.AutoGenerateColumns = True
        With datos
            .DataSource = bsRecurso
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("cod_recurso").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns.Item("cod_recurso").HeaderText = "Código"
            .Columns.Item("cod_recurso").Resizable = DataGridViewTriState.False
            .Columns.Item("cod_recurso").Width = "60"
            .Columns.Item("cod_recurso").DefaultCellStyle.BackColor = Color.CadetBlue
            .Columns.Item("cod_recurso").DefaultHeaderCellType = AcceptButton
            .Columns.Item("dsc_recurso").HeaderText = "Descripcion"
            .Columns.Item("dsc_recurso").Resizable = DataGridViewTriState.False
            .Columns.Item("dsc_recurso").Width = "350"
            .Columns.Item("activo").HeaderText = "Activo"
            .Columns.Item("activo").Resizable = DataGridViewTriState.False
            .Columns.Item("activo").Width = "50"
            .Columns.Item("cod_tabla").Visible = False
            .Columns.Item("imp_costo").Visible = False
            .Columns.Item("imp_venta").Visible = False

        End With

    End Sub
    Private Sub AddButtonColumn()
        Dim buttons As New DataGridViewButtonColumn()
        With buttons
            .HeaderText = "Sales"
            .Text = "Sales"
            .UseColumnTextForButtonValue = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .FlatStyle = FlatStyle.Standard
            .CellTemplate.Style.BackColor = Color.Honeydew
            .DisplayIndex = 0
        End With

        datos.Columns.Add(buttons)

    End Sub
    Sub habilitaDetalle()
        txtCodigo.BackColor = Color.White
        txtCodigo.ReadOnly = False
        txtDescripcion.BackColor = Color.White
        txtDescripcion.ReadOnly = False
        txtPreCosto.BackColor = Color.White
        txtPreCosto.ReadOnly = False
        txtPreVenta.BackColor = Color.White
        txtPreVenta.ReadOnly = False
        chkActivo.Enabled = True
        cboFamilia.Enabled = False
    End Sub
    Sub deshabilitaDetalle()
        txtCodigo.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(255, Byte), Integer))
        txtCodigo.ReadOnly = True
        txtDescripcion.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(255, Byte), Integer))
        txtDescripcion.ReadOnly = True
        txtPreCosto.BackColor = Color.White
        txtPreCosto.ReadOnly = True
        txtPreVenta.BackColor = Color.White
        txtPreVenta.ReadOnly = True
        cboFamilia.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(255, Byte), Integer))
        cboFamilia.Enabled = True
        chkActivo.Enabled = False
    End Sub
    Sub habilitaCabecera()
        datos.Enabled = True
    End Sub
    Sub deshabilitaCabecera()
        datos.Enabled = False
    End Sub
    Sub modoAñadir()
        cmdAñadir.Enabled = True
        cmdGrabar.Enabled = False
        cmdCancelar.Enabled = False
        cmdEditar.Enabled = True
        cmdEliminar.Enabled = True
    End Sub
    Sub modoGrabar()
        cmdAñadir.Enabled = False
        cmdGrabar.Enabled = True
        cmdCancelar.Enabled = True
        cmdEditar.Enabled = False
        cmdEliminar.Enabled = False
    End Sub
    Function validaIngreso()
        Dim validado As Boolean = False
        If Len(txtCodigo.Text) > 0 Then
            If Len(txtDescripcion.Text) > 0 Then
                validado = True
            Else
                MessageBox.Show("Ingrese la Descripcion...", "SGE", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtDescripcion.Focus()
            End If
        Else
            MessageBox.Show("Ingrese el Código...", "SGE", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCodigo.Focus()
        End If
        Return validado
    End Function


    Private Sub cboFamilia_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboFamilia.SelectedIndexChanged
        If Not (estacargando) Then
            Dim cod_tabla As String = cboFamilia.SelectedValue
            cargardataset(cod_tabla)
        End If
    End Sub

    Private Sub cmdAñadir_Click(sender As System.Object, e As System.EventArgs) Handles cmdAñadir.Click
        Dim cod_recurso As String = consultas.maxCodRecurso(cboFamilia.SelectedValue)
        habilitaDetalle()
        deshabilitaCabecera()
        dsRecurso.Tables("recurso").Columns("cod_recurso").DefaultValue = cod_recurso
        dsRecurso.Tables("recurso").Columns("cod_tabla").DefaultValue = cboFamilia.SelectedValue
        dsRecurso.Tables("recurso").Columns("activo").DefaultValue = True
        
        bsRecurso.AddNew()
        datos.DataSource = bsRecurso
        modoGrabar()
        txtCodigo.Refresh()
        txtDescripcion.Refresh()
        chkActivo.Refresh()
        txtDescripcion.Focus()
    End Sub

    Private Sub cmdGrabar_Click(sender As System.Object, e As System.EventArgs) Handles cmdGrabar.Click
        Try
            If validaIngreso() = True Then
                bsRecurso.EndEdit()
                darecurso.Update(dsRecurso, "recurso")
                datos.Refresh()
                deshabilitaDetalle()
                habilitaCabecera()
                modoAñadir()
                datos.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            bsRecurso.CancelEdit()
            datos.Refresh()
            deshabilitaDetalle()
            habilitaCabecera()
            modoAñadir()
            datos.Focus()
        End Try
    End Sub

    Private Sub cmdCancelar_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancelar.Click
        bsRecurso.CancelEdit()
        datos.Refresh()
        deshabilitaDetalle()
        habilitaCabecera()
        modoAñadir()
        datos.Focus()
        If datos.Rows.Count > 0 Then
            datos.CurrentCell = datos(1, 0)
        End If
    End Sub

    Private Sub cmdEliminar_Click(sender As System.Object, e As System.EventArgs) Handles cmdEliminar.Click
        If bsRecurso.Count > 0 Then
            Dim rpta As Integer
            'Dim mSGrupo As New SubGrupo, exist, rpta As Integer
            'exist = mSGrupo.existeEnCatalogo(Trim(txtCodigo.Text))
            'If exist = 0 Then
            rpta = MessageBox.Show("¿Esta seguro de Eliminar el ITEM Seleccionado...", "SGE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If rpta = 6 Then
                bsRecurso.RemoveCurrent()
                darecurso.Update(dsRecurso, "recurso")
                datos.Refresh()
            End If
            'Else
            '   MessageBox.Show("El Registro Tiene Datos Relacionados..." + Chr(13) + "!NO Es posible eliminarlo¡", "SGE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2)
            'End If
        End If
    End Sub

    Private Sub cmdEditar_Click(sender As System.Object, e As System.EventArgs) Handles cmdEditar.Click
        If bsRecurso.Count > 0 Then
            habilitaDetalle()
            deshabilitaCabecera()
            modoGrabar()
            txtCodigo.Focus()
        End If
    End Sub

    Private Sub txtPreCosto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPreCosto.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not (e.KeyChar = ChrW(Keys.Back)) And Not (e.KeyChar.Equals(sepDecimal)) Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txtPreVenta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPreVenta.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not (e.KeyChar = ChrW(Keys.Back)) And Not (e.KeyChar.Equals(sepDecimal)) Then
            e.KeyChar = ""
        End If
    End Sub


End Class
