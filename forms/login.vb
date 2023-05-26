Imports MySql.Data.MySqlClient


Public Class Login
    'para validar el separador decimal
    Private sepDecimal As Char
    Dim Arrastre As Boolean


    Private Sub Login_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            End
        End If
    End Sub
    Private Sub login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ''Formulario Elipse
        'Dim gp As New System.Drawing.Drawing2D.GraphicsPath
        'gp.AddEllipse(0, 0, Me.Width, Me.Height)
        'gp.GetHashCode()
        'Me.Region = New Region(gp)
        'capturamos el separador decimal
        'Aca tiene que cargar su imagen de fondo...
        'Dim imagen As Image = Bitmap.FromFile("C:\loginsga.BMP")

        Dim imagen As Image = Me.BackgroundImage
        Me.BackgroundImage = imagen
        Me.Height = imagen.Height
        Me.Width = imagen.Width
        Dim mibitmap As Bitmap = CType(imagen, Bitmap)
        'Le paso a la funcion la imagen el bitmap de fondo y el color transparente ( En este caso tomo el color del pixel 0,0 del bitmap)
        'Dicha función me retorna la región de la imagen para poder asignarla a la región del formulario
        Me.Region = ObtenerRegionDelBitmap(mibitmap, mibitmap.GetPixel(0, 0))

        'Dim mes, anno As Integer
        'Dim NomMes As String
        'mes = Month(pFechaActivaMax)
        'NomMes = UCase(MonthName(mes, True))
        'anno = Year(pFechaActivaMax)
        'LblPeriodo.Text = "Periodo Activo :" & NomMes & "-" & CType(anno, String)
        sepDecimal = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
        'txtTC.Text = mTC.recupera(pFechaSystem)
        pTC = consultas.recuperaTC(pFechaSystem)
        Lbltipcambio.Text = "Tipo de Cambio :" & consultas.recuperaTC(pFechaSystem)

    End Sub
    Private Sub cmdContinuar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdContinuar.Click
        ingresaSystem()
    End Sub
    Sub ingresaSystem()
        If consultas.ingresoSistema(txtUsuario.Text, txtClave.Text) = True Then
            pNombreUser = txtUsuario.Text
            pCuentaUser = txtUsuario.Text
            pNivelUser = consultas.recuperaNivelUsuario(txtUsuario.Text)
            'pAlmaUser = usuario.recuperaAlmacenUsuario(txtUsuario.Text)
            pDatosUser = consultas.recuperaDatosUsuario(txtUsuario.Text)
            Dim com As New MySqlCommand("select * from configuracion where activo='1'", dbConex)
            Dim dr As MySqlDataReader
            dr = com.ExecuteReader
            If dr.HasRows = True Then
                While dr.Read
                    pIGV = dr("igv")
                    pEmpresa = dr("cod_emp")
                    pNempresa = dr("nom_emp")
                    pDirEmpresa = dr("dir_emp")
                    pDecimales = dr("nros_decimales")
                    pDiasModificarIngreso = dr("dias_modificar_ingreso")
                    pDiasModificarPedido = dr("dias_modificar_pedido")
                    pDiasModificarSalida = dr("dias_modificar_salida")
                    pPreciosIncIGV = dr("precios_inc_igv")
                    pDespachoXprecioVenta = dr("despacho_x_pre_venta")
                    pDespachoXtipoCliente = dr("despacho_x_tipo_cliente")
                    pModoPedidos = dr("modo_pedidos")
                    pDiasModificarInventario = dr("dias_modificar_inventario")
                    pMoneda = dr("moneda")
                    pMonedaAbr = dr("monedaAbr")
                    pCatalogoXalmacen = dr("catalogo_x_almacen")
                    pLogo = dr("Logo")
                    pImpuestoXarticulo = dr("impuesto_x_articulo")
                    pDiasModificarTrans = dr("dias_modificar_trans")
                    pDespachoStock0 = dr("despacho_stock0")

                    pDiasModificarBaja = dr("dias_modificar_baja")



                End While


                'establecemos permisos de usuario
                Dim ds As New DataSet, I As Integer, cod_smenu As String
                Dim activo As Boolean
                ds = consultas.permisos(pCuentaUser)
                If ds.Tables("permisos").Rows.Count > 0 Then
                    For I = 0 To ds.Tables("permisos").Rows.Count - 1
                        cod_smenu = ds.Tables("permisos").Rows(I).Item("cod_smenu").ToString()
                        activo = ds.Tables("permisos").Rows(I).Item("activo").ToString()
                        asignaPermisos(cod_smenu, activo)
                    Next
                End If
            Else
                MessageBox.Show("NO es Posible Cargar la Configuración del Sistema...")
                End
            End If
            dr.Close()
            principal.Show()
            Me.Hide()
        Else
            pNombreUser = ""
            pCuentaUser = ""
            MessageBox.Show("Acceso Denegado...", "Cefe", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub txtTC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not Char.IsNumber(e.KeyChar) And Not (e.KeyChar = ChrW(Keys.Back)) And Not (e.KeyChar.Equals(sepDecimal)) Then
            e.KeyChar = ""
        End If
    End Sub
    Private Sub txtUsuario_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsuario.GotFocus
        general.ingresaTexto(txtUsuario)
    End Sub
    Private Sub txtUsuario_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsuario.LostFocus
        general.saleTexto(txtUsuario)
    End Sub
    Private Sub txtClave_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtClave.GotFocus
        general.ingresaTexto(txtClave)
    End Sub
    Private Sub txtClave_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtClave.LostFocus
        general.saleTexto(txtClave)
    End Sub
    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        End
    End Sub
    Private Function ObtenerRegionDelBitmap(ByVal MiImagen As Bitmap, ByVal ColorTransparente As Color) As Region

        Dim RegionLocal As Region = Nothing

        If MiImagen Is Nothing Then Return RegionLocal

        Dim ColorDeFondo As Color = ColorTransparente

        Dim Largo As Integer = MiImagen.Height - 1

        Dim Ancho As Integer = MiImagen.Width

        Dim Fila As Integer

        Dim Columna As Integer

        RegionLocal = New Region(New Rectangle(0, 0, 0, 0))

        For Fila = 0 To Largo

            Dim ColumnaComienzo As Integer = -1

            Dim ColumnaFin As Integer = -1


            For Columna = 0 To Ancho

                If Columna = Ancho Then

                    If ColumnaComienzo <> -1 Then

                        ColumnaFin = Columna

                        Dim regUnion As New Region(New Rectangle(ColumnaComienzo, Fila, ColumnaFin - ColumnaComienzo, 1))

                        RegionLocal.Union(regUnion)

                        regUnion = Nothing

                    End If

                Else

                    If Not MiImagen.GetPixel(Columna, Fila).Equals(ColorDeFondo) Then

                        If ColumnaComienzo = -1 Then ColumnaComienzo = Columna

                    ElseIf MiImagen.GetPixel(Columna, Fila).Equals(ColorDeFondo) Then

                        If ColumnaComienzo <> -1 Then

                            ColumnaFin = Columna

                            Dim regUnion As New Region(New Rectangle(ColumnaComienzo, Fila, ColumnaFin - ColumnaComienzo, 1))

                            RegionLocal.Union(regUnion)

                            regUnion = Nothing

                            ColumnaComienzo = -1

                            ColumnaFin = -1

                        End If

                    End If

                End If

            Next

        Next

        Return RegionLocal

    End Function

    Private Sub Login_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        Arrastre = True

    End Sub

    Private Sub Login_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If Arrastre Then Me.Location = Me.PointToScreen(New Point(e.X, e.Y))
    End Sub

    Private Sub Login_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        Arrastre = False
    End Sub

    Private Sub cmdContinuar_Click_1(sender As Object, e As EventArgs) Handles cmdContinuar.Click

    End Sub
End Class

