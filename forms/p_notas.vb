Public Class p_notas

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        p_eventos.eliminadtitem()
        Me.Close()
    End Sub

    Private Sub p_notas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Sub datosNotas(ByVal cant As Decimal, ByVal cant_prod As Decimal, ByVal precio As Decimal, ByVal obs As String)
        txtnotas.Text = obs
        txtcant.Text = cant
        txtcant_prod.Text = cant_prod
        txtprecio.Text = precio
        'If precio = 0 Then
        '    txtprecio.Enabled = True
        'End If
    End Sub

    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        p_eventos.AgregadtItem(txtcant.Text, txtcant_prod.Text, txtprecio.Text, txtnotas.Text)
        Me.Close()
    End Sub

    Private Sub txtnotas_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtnotas.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtnotas.Focus()
        End If
    End Sub

    Private Sub txtnotas_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtnotas.TextChanged

    End Sub
End Class
