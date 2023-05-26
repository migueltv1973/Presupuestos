Public Class p_actualiza_reservas

    Private lnumorden As String
    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
        rpt_reservas.Actualiza_numorden(txtNro_orden.Text, txtnumfactura.Text, chkfacturar.Checked)
        Me.Close()
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.Close()
    End Sub

    Private Sub p_actualiza_reservas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Sub numidfactura(ByVal numidfactura As String, ByVal numOrden As String)
        lnumorden = numOrden
        lblnumidfactura.Text = "Va Actualizar la siguiente ID:" & numidfactura

    End Sub

    Private Sub chkfacturar_CheckedChanged(sender As Object, e As EventArgs) Handles chkfacturar.CheckedChanged
        If chkfacturar.Checked() Then
            txtNro_orden.Text = lnumorden
            lblnumfactura.Visible = True
            txtnumfactura.Visible = True
            lblnumidfactura.Text = "Va Actualizar la siguiente OC:" & lnumorden
        End If
    End Sub
End Class
