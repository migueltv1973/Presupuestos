﻿Imports MySql.Data.MySqlClient

Public Class m_sucursales
    Private darecurso As New MySqlDataAdapter
    Private cbRecurso As MySqlCommandBuilder = New MySqlCommandBuilder(darecurso)
    Private dsCliente As New DataSet
    Private dsRecurso As New DataSet
    Private dtRecurso As DataTable
    Private bsRecurso As New BindingSource
    Private estacargando As Boolean = True
    Private sepDecimal As Char

    Private Sub cmdCerrar_Click(sender As System.Object, e As System.EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub m_recursos_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        principal.mp_sucursal.Enabled = True
    End Sub

    Private Sub m_recursos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'dataset tablas
        sepDecimal = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
        Dim daCliente As New MySqlDataAdapter
        Dim comCliente As New MySqlCommand("select cod_clie,nom_clie from cliente where activo=1 order by nom_clie", dbConex)
        daCliente.SelectCommand = comCliente
        daCliente.Fill(dsCliente, "Cliente")
        With cboCliente
            .DataSource = dsCliente.Tables("Cliente")
            .DisplayMember = dsCliente.Tables("Cliente").Columns("nom_clie").ToString
            .ValueMember = dsCliente.Tables("Cliente").Columns("cod_clie").ToString
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.ListItems
            '.SelectedIndex = -1
        End With
        Dim cod_cliente As String = cboCliente.SelectedValue
        'cargamos el dataset
        cargardataset(cod_cliente)

        'relacionamos los cuadros de texto con el bindingSource
        txtCodigo.DataBindings.Add("text", bsRecurso, "cod_sucursal")
        txtDescripcion.DataBindings.Add("text", bsRecurso, "dir_sucursal")
        chkActivo.DataBindings.Add("checked", bsRecurso, "activo")
        estacargando = False
    End Sub
    Sub cargardataset(ByVal cod_cliente As String)
        dsRecurso.Clear()
        Dim com As New MySqlCommand("Select cod_clie,cod_sucursal,dir_sucursal,activo from cliente_sucursal where activo and cod_clie = '" & cod_cliente & "' order by dir_sucursal", dbConex)
        darecurso.SelectCommand = com
        darecurso.Fill(dsRecurso, "recurso")
        bsRecurso.DataSource = dsRecurso
        bsRecurso.DataMember = "recurso"
        datos.AutoGenerateColumns = True
        With datos
            .DataSource = bsRecurso
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns.Item("cod_sucursal").HeaderText = "Código"
            .Columns.Item("cod_sucursal").Resizable = DataGridViewTriState.False
            .Columns.Item("cod_sucursal").Width = "60"
            .Columns.Item("cod_sucursal").DefaultCellStyle.BackColor = Color.CadetBlue
            .Columns.Item("cod_sucursal").DefaultHeaderCellType = AcceptButton
            .Columns.Item("dir_sucursal").HeaderText = "Descripcion"
            .Columns.Item("dir_sucursal").Resizable = DataGridViewTriState.False
            .Columns.Item("dir_sucursal").Width = "350"
            .Columns.Item("activo").HeaderText = "Activo"
            .Columns.Item("activo").Resizable = DataGridViewTriState.False
            .Columns.Item("activo").Width = "50"
            .Columns.Item("cod_clie").Visible = False


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

        chkActivo.Enabled = True
        cboCliente.Enabled = False
    End Sub
    Sub deshabilitaDetalle()
        txtCodigo.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(255, Byte), Integer))
        txtCodigo.ReadOnly = True
        txtDescripcion.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(255, Byte), Integer))
        txtDescripcion.ReadOnly = True
        cboCliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(255, Byte), Integer))
        cboCliente.Enabled = True
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


    Private Sub cboFamilia_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCliente.SelectedIndexChanged
        If Not (estacargando) Then
            Dim cod_tabla As String = cboCliente.SelectedValue
            cargardataset(cod_tabla)
        End If
    End Sub

    Private Sub cmdAñadir_Click(sender As System.Object, e As System.EventArgs) Handles cmdAñadir.Click
        Dim cod_sucursal As String = consultas.maxCodsucursal(cboCliente.SelectedValue)
        habilitaDetalle()
        deshabilitaCabecera()
        dsRecurso.Tables("recurso").Columns("cod_clie").DefaultValue = cboCliente.SelectedValue
        dsRecurso.Tables("recurso").Columns("cod_sucursal").DefaultValue = cod_sucursal
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

    Private Sub txtPreCosto_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsNumber(e.KeyChar) And Not (e.KeyChar = ChrW(Keys.Back)) And Not (e.KeyChar.Equals(sepDecimal)) Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txtPreVenta_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsNumber(e.KeyChar) And Not (e.KeyChar = ChrW(Keys.Back)) And Not (e.KeyChar.Equals(sepDecimal)) Then
            e.KeyChar = ""
        End If
    End Sub


End Class
