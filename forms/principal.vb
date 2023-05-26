Imports System.Windows.Forms
Imports System.Data

Public Class principal

    Private Sub principal_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        End
    End Sub

    Private Sub principal_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim tit As String = General.tituloVentanaPrincipal()
        Me.Text = tit
        lblusuario1.Text = "Usuario Activo: " & pDatosUser
        c_eventos.MdiParent = Me
        c_eventos.Show()
    End Sub

    Private Sub mp_salir_Click(sender As System.Object, e As DevComponents.DotNetBar.ClickEventArgs) Handles mp_salir.Click
        Me.Close()
        End
    End Sub

    Private Sub mp_eventos_Click(sender As System.Object, e As DevComponents.DotNetBar.ClickEventArgs) Handles mp_eventos.Click
        mp_eventos.Enabled = False
        c_eventos.MdiParent = Me
        c_eventos.Show()
    End Sub

    Private Sub mp_recursos_Click(sender As System.Object, e As DevComponents.DotNetBar.ClickEventArgs) Handles mp_recursos.Click
        mp_recursos.Enabled = False
        m_recursos.MdiParent = Me
        m_recursos.Show()
    End Sub

    Private Sub btn_nuevo_Click(sender As Object, e As ClickEventArgs) Handles btn_nuevo.Click
        Dim IsFormCargado As Boolean = False
        Dim mForm As Form
        For Each mForm In Me.MdiChildren
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
            p_eventos.MdiParent = Me
            Dim cod_salon As String = ""
            p_eventos.Show()
            p_eventos.cargaeventos(0, DateTime.Now, DateTime.Now, cod_salon, False)
        End If
    End Sub

    Private Sub mp_contactos_Click(sender As Object, e As ClickEventArgs) Handles mp_contactos.Click
        mp_contactos.Enabled = False
        m_contactos.MdiParent = Me
        m_contactos.Show()
    End Sub

    Private Sub mp_sucursal_Click(sender As Object, e As ClickEventArgs) Handles mp_sucursal.Click
        mp_sucursal.Enabled = False
        m_sucursales.MdiParent = Me
        m_sucursales.Show()
    End Sub
End Class
