<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class principal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(principal))
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EventosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EventosToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblusuario1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.bubbleBar1 = New DevComponents.DotNetBar.BubbleBar()
        Me.bubbleBarTab1 = New DevComponents.DotNetBar.BubbleBarTab(Me.components)
        Me.btn_nuevo = New DevComponents.DotNetBar.BubbleButton()
        Me.bubbleButton3 = New DevComponents.DotNetBar.BubbleButton()
        Me.mp_eventos = New DevComponents.DotNetBar.BubbleButton()
        Me.bubbleButton2 = New DevComponents.DotNetBar.BubbleButton()
        Me.bubbleButton6 = New DevComponents.DotNetBar.BubbleButton()
        Me.mp_sucursal = New DevComponents.DotNetBar.BubbleButton()
        Me.mp_contactos = New DevComponents.DotNetBar.BubbleButton()
        Me.mp_salir = New DevComponents.DotNetBar.BubbleButton()
        Me.bubbleButton9 = New DevComponents.DotNetBar.BubbleButton()
        Me.mp_recursos = New DevComponents.DotNetBar.BubbleButton()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.bubbleBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EventosToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(116, 26)
        '
        'EventosToolStripMenuItem
        '
        Me.EventosToolStripMenuItem.Name = "EventosToolStripMenuItem"
        Me.EventosToolStripMenuItem.Size = New System.Drawing.Size(115, 22)
        Me.EventosToolStripMenuItem.Text = "eventos"
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EventosToolStripMenuItem1})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(116, 26)
        '
        'EventosToolStripMenuItem1
        '
        Me.EventosToolStripMenuItem1.Name = "EventosToolStripMenuItem1"
        Me.EventosToolStripMenuItem1.Size = New System.Drawing.Size(115, 22)
        Me.EventosToolStripMenuItem1.Text = "Eventos"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblusuario1, Me.ToolStripStatusLabel2})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 516)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StatusStrip1.Size = New System.Drawing.Size(1057, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'lblusuario1
        '
        Me.lblusuario1.Name = "lblusuario1"
        Me.lblusuario1.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(10, 17)
        Me.ToolStripStatusLabel2.Text = "."
        Me.ToolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'bubbleBar1
        '
        Me.bubbleBar1.Alignment = DevComponents.DotNetBar.eBubbleButtonAlignment.Bottom
        Me.bubbleBar1.AntiAlias = True
        Me.bubbleBar1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.bubbleBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.bubbleBar1.ButtonBackAreaStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.bubbleBar1.ButtonBackAreaStyle.BackgroundImagePosition = DevComponents.DotNetBar.eStyleBackgroundImage.Tile
        Me.bubbleBar1.ButtonBackAreaStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.bubbleBar1.ButtonBackAreaStyle.BorderBottomWidth = 1
        Me.bubbleBar1.ButtonBackAreaStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.bubbleBar1.ButtonBackAreaStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.bubbleBar1.ButtonBackAreaStyle.BorderLeftWidth = 1
        Me.bubbleBar1.ButtonBackAreaStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.bubbleBar1.ButtonBackAreaStyle.BorderRightWidth = 1
        Me.bubbleBar1.ButtonBackAreaStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.bubbleBar1.ButtonBackAreaStyle.BorderTopWidth = 1
        Me.bubbleBar1.ButtonBackAreaStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.bubbleBar1.ButtonBackAreaStyle.PaddingBottom = 3
        Me.bubbleBar1.ButtonBackAreaStyle.PaddingLeft = 3
        Me.bubbleBar1.ButtonBackAreaStyle.PaddingRight = 3
        Me.bubbleBar1.ButtonBackAreaStyle.PaddingTop = 3
        Me.bubbleBar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bubbleBar1.ImageSizeLarge = New System.Drawing.Size(64, 64)
        Me.bubbleBar1.ImageSizeNormal = New System.Drawing.Size(32, 32)
        Me.bubbleBar1.Location = New System.Drawing.Point(0, 453)
        Me.bubbleBar1.MouseOverTabColors.BorderColor = System.Drawing.SystemColors.Highlight
        Me.bubbleBar1.Name = "bubbleBar1"
        Me.bubbleBar1.SelectedTab = Me.bubbleBarTab1
        Me.bubbleBar1.SelectedTabColors.BorderColor = System.Drawing.Color.Black
        Me.bubbleBar1.Size = New System.Drawing.Size(1057, 63)
        Me.bubbleBar1.TabIndex = 5
        Me.bubbleBar1.Tabs.Add(Me.bubbleBarTab1)
        Me.bubbleBar1.Text = "bubbleBar1"
        Me.bubbleBar1.TooltipFont = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'bubbleBarTab1
        '
        Me.bubbleBarTab1.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.bubbleBarTab1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.bubbleBarTab1.Buttons.AddRange(New DevComponents.DotNetBar.BubbleButton() {Me.btn_nuevo, Me.bubbleButton3, Me.mp_eventos, Me.bubbleButton2, Me.bubbleButton6, Me.mp_sucursal, Me.mp_contactos, Me.mp_salir, Me.bubbleButton9, Me.mp_recursos})
        Me.bubbleBarTab1.DarkBorderColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.bubbleBarTab1.LightBorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.bubbleBarTab1.Name = "bubbleBarTab1"
        Me.bubbleBarTab1.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Blue
        Me.bubbleBarTab1.Text = "Procesos"
        Me.bubbleBarTab1.TextColor = System.Drawing.Color.Black
        '
        'btn_nuevo
        '
        Me.btn_nuevo.Image = CType(resources.GetObject("btn_nuevo.Image"), System.Drawing.Image)
        Me.btn_nuevo.ImageLarge = CType(resources.GetObject("btn_nuevo.ImageLarge"), System.Drawing.Image)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.TooltipText = "Create New File"
        '
        'bubbleButton3
        '
        Me.bubbleButton3.Image = CType(resources.GetObject("bubbleButton3.Image"), System.Drawing.Image)
        Me.bubbleButton3.ImageLarge = CType(resources.GetObject("bubbleButton3.ImageLarge"), System.Drawing.Image)
        Me.bubbleButton3.Name = "bubbleButton3"
        Me.bubbleButton3.TooltipText = "Open File"
        '
        'mp_eventos
        '
        Me.mp_eventos.Image = CType(resources.GetObject("mp_eventos.Image"), System.Drawing.Image)
        Me.mp_eventos.ImageLarge = CType(resources.GetObject("mp_eventos.ImageLarge"), System.Drawing.Image)
        Me.mp_eventos.Name = "mp_eventos"
        Me.mp_eventos.TooltipText = "Account List"
        '
        'bubbleButton2
        '
        Me.bubbleButton2.Image = CType(resources.GetObject("bubbleButton2.Image"), System.Drawing.Image)
        Me.bubbleButton2.ImageLarge = CType(resources.GetObject("bubbleButton2.ImageLarge"), System.Drawing.Image)
        Me.bubbleButton2.Name = "bubbleButton2"
        Me.bubbleButton2.TooltipText = "Search"
        '
        'bubbleButton6
        '
        Me.bubbleButton6.Image = CType(resources.GetObject("bubbleButton6.Image"), System.Drawing.Image)
        Me.bubbleButton6.ImageLarge = CType(resources.GetObject("bubbleButton6.ImageLarge"), System.Drawing.Image)
        Me.bubbleButton6.Name = "bubbleButton6"
        Me.bubbleButton6.TooltipText = "Write CD"
        '
        'mp_sucursal
        '
        Me.mp_sucursal.Image = CType(resources.GetObject("mp_sucursal.Image"), System.Drawing.Image)
        Me.mp_sucursal.ImageLarge = CType(resources.GetObject("mp_sucursal.ImageLarge"), System.Drawing.Image)
        Me.mp_sucursal.Name = "mp_sucursal"
        Me.mp_sucursal.TooltipText = "Take Snapshot"
        '
        'mp_contactos
        '
        Me.mp_contactos.Image = CType(resources.GetObject("mp_contactos.Image"), System.Drawing.Image)
        Me.mp_contactos.ImageLarge = CType(resources.GetObject("mp_contactos.ImageLarge"), System.Drawing.Image)
        Me.mp_contactos.Name = "mp_contactos"
        '
        'mp_salir
        '
        Me.mp_salir.Image = CType(resources.GetObject("mp_salir.Image"), System.Drawing.Image)
        Me.mp_salir.ImageLarge = CType(resources.GetObject("mp_salir.ImageLarge"), System.Drawing.Image)
        Me.mp_salir.Name = "mp_salir"
        Me.mp_salir.TooltipText = "Delete"
        '
        'bubbleButton9
        '
        Me.bubbleButton9.Image = CType(resources.GetObject("bubbleButton9.Image"), System.Drawing.Image)
        Me.bubbleButton9.ImageLarge = CType(resources.GetObject("bubbleButton9.ImageLarge"), System.Drawing.Image)
        Me.bubbleButton9.Name = "bubbleButton9"
        Me.bubbleButton9.TooltipText = "Preferences"
        '
        'mp_recursos
        '
        Me.mp_recursos.Image = CType(resources.GetObject("mp_recursos.Image"), System.Drawing.Image)
        Me.mp_recursos.ImageLarge = CType(resources.GetObject("mp_recursos.ImageLarge"), System.Drawing.Image)
        Me.mp_recursos.Name = "mp_recursos"
        '
        'principal
        '
        Me.ClientSize = New System.Drawing.Size(1057, 538)
        Me.Controls.Add(Me.bubbleBar1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.IsMdiContainer = True
        Me.Name = "principal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.bubbleBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents RibbonControl1 As DevComponents.DotNetBar.RibbonControl
    Friend WithEvents RibbonPanel1 As DevComponents.DotNetBar.RibbonPanel
    Friend WithEvents RibbonTabItem1 As DevComponents.DotNetBar.RibbonTabItem
    Friend WithEvents Office2007StartButton1 As DevComponents.DotNetBar.Office2007StartButton
    Friend WithEvents ItemContainer1 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents ItemContainer2 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents ItemContainer3 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents ButtonItem2 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem4 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem5 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem6 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem7 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GalleryContainer1 As DevComponents.DotNetBar.GalleryContainer
    Friend WithEvents labelItem8 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ButtonItem8 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem9 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem10 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem11 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ItemContainer4 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents ButtonItem12 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents mnu_exit As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonPanel5 As DevComponents.DotNetBar.RibbonPanel
    Friend WithEvents RibbonPanel4 As DevComponents.DotNetBar.RibbonPanel
    Friend WithEvents RibbonPanel3 As DevComponents.DotNetBar.RibbonPanel
    Friend WithEvents RibbonTabItem3 As DevComponents.DotNetBar.RibbonTabItem
    Friend WithEvents RibbonTabItem4 As DevComponents.DotNetBar.RibbonTabItem
    Friend WithEvents RibbonTabItem5 As DevComponents.DotNetBar.RibbonTabItem
    Friend WithEvents rbCatalogo As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents ma_catalogo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ItemContainer5 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents ma_familia As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ma_sgrupo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ma_unidades As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ItemContainer6 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents ma_planCuentas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar5 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents mp_ingreso As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar12 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents RibbonBar10 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents mr_niveles As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ItemContainer13 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents mr_kardex As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents mr_saldos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents mr_recetas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar4 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents ItemContainer9 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents mp_pedidos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ItemContainer10 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents mp_ventas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents rbAlmacen As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents rbVendedor As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents ma_vendedor As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents rbTransporte As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents ma_transporte As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ItemContainer12 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents ma_motivo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ma_conductor As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents rbProveedor As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents ItemContainer8 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents ma_proveedor As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ma_tproveedor As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents rbCliente As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents ItemContainer7 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents ma_cliente As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ma_tcliente As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ma_almacen As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar7 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents mr_comisiones As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar9 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents ButtonItem13 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents mr_cuentaC As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents mr_cuentaP As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar11 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents ButtonItem16 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents mr_transformaciones As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents mr_produccion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar17 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents mp_inventarios As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar8 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents mp_cuentaC As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents mp_cuentaP As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar6 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents mp_recetas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents mp_transformaciones As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents mp_producciones As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ItemContainer16 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents mp_salidas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents mp_transferencia As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ItemContainer15 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents mr_transferencia As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar1 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents mp_mermas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents mp_invDiario As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents mp_invInicial As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents mp_invMensual As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar14 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents mu_configuracion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar16 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents mu_usuarios As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar2 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents ItemContainer19 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents mu_envioCompras As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents mu_envioVentas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ma_precios As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ma_tArticulo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar3 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents ItemContainer18 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents me_precios As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ItemContainer17 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents me_compras As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents me_ventas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents me_gastos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar15 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents mc_mermas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar18 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents mr_inventarios As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ItemContainer14 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents mu_tipoCambio As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ma_maximos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ItemContainer21 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents mr_ingresos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents mr_ventas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ItemContainer22 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents mr_pedidos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents mr_movimientos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ItemContainer11 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents mp_actualizaRecetas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ItemContainer23 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents RibbonBar13 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents mu_pixelPoint As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents mu_micros As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ItemContainer24 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents ItemContainer25 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents mu_codigosExt As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ItemContainer26 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents ItemContainer27 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents ItemContainer28 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents ma_catalogo2 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents lblUsuario As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ItemContainer20 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents ItemContainer29 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents mr_ventaRest As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ma_rendimiento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents mp_notaCredito As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents mp_notaDebito As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents QatCustomizeItem1 As DevComponents.DotNetBar.QatCustomizeItem
    Private WithEvents estiloRN As DevComponents.DotNetBar.StyleManager
    Friend WithEvents RibbonBar19 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents mu_actLotes As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents mu_impventas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents mu_procventas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EventosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EventosToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblusuario1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents bubbleBar1 As DevComponents.DotNetBar.BubbleBar
    Friend WithEvents bubbleBarTab1 As DevComponents.DotNetBar.BubbleBarTab
    Friend WithEvents btn_nuevo As DevComponents.DotNetBar.BubbleButton
    Friend WithEvents bubbleButton3 As DevComponents.DotNetBar.BubbleButton
    Friend WithEvents mp_eventos As DevComponents.DotNetBar.BubbleButton
    Friend WithEvents bubbleButton2 As DevComponents.DotNetBar.BubbleButton
    Friend WithEvents bubbleButton6 As DevComponents.DotNetBar.BubbleButton
    Friend WithEvents mp_sucursal As DevComponents.DotNetBar.BubbleButton
    Friend WithEvents mp_contactos As DevComponents.DotNetBar.BubbleButton
    Friend WithEvents mp_salir As DevComponents.DotNetBar.BubbleButton
    Friend WithEvents bubbleButton9 As DevComponents.DotNetBar.BubbleButton
    Friend WithEvents mp_recursos As DevComponents.DotNetBar.BubbleButton

End Class
