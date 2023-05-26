Public Class base
    Private Sub base_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.SelectNextControl(ActiveControl, True, True, True, True)
        End If
    End Sub

    Private Sub base_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class