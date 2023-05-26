<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class rpt_reservas
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rpt_reservas))
        Me.mcHasta = New DevComponents.Editors.DateTimeAdv.MonthCalendarAdv()
        Me.mcDesde = New DevComponents.Editors.DateTimeAdv.MonthCalendarAdv()
        Me.cmdProcesar = New DevComponents.DotNetBar.ButtonX()
        Me.cmdCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.cmdImprimir = New DevComponents.DotNetBar.ButtonX()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.opt_etiquetas = New System.Windows.Forms.RadioButton()
        Me.optProgEventos = New System.Windows.Forms.RadioButton()
        Me.optReservas = New System.Windows.Forms.RadioButton()
        Me.TabControl2 = New DevComponents.DotNetBar.TabControl()
        Me.TabControlPanel4 = New DevComponents.DotNetBar.TabControlPanel()
        Me.Datadetalle = New System.Windows.Forms.DataGridView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.chkIMP = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.lblMontoDS = New DevComponents.DotNetBar.LabelX()
        Me.lblMonedaDS = New DevComponents.DotNetBar.LabelX()
        Me.lblRegistros = New DevComponents.DotNetBar.LabelX()
        Me.tabSaldos = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.tabResumen = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabItem1 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.buscar = New System.Windows.Forms.PictureBox()
        Me.chkestado = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.ChkAdicional = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.chkCopia = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.lblMonto = New DevComponents.DotNetBar.LabelX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.GroupBox2.SuspendLayout()
        CType(Me.TabControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl2.SuspendLayout()
        Me.TabControlPanel4.SuspendLayout()
        CType(Me.Datadetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.buscar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mcHasta
        '
        Me.mcHasta.AnnuallyMarkedDates = New Date(-1) {}
        Me.mcHasta.AutoSize = True
        '
        '
        '
        Me.mcHasta.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.mcHasta.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.mcHasta.BackgroundStyle.BorderBottomWidth = 1
        Me.mcHasta.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.mcHasta.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.mcHasta.BackgroundStyle.BorderLeftWidth = 1
        Me.mcHasta.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.mcHasta.BackgroundStyle.BorderRightWidth = 1
        Me.mcHasta.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.mcHasta.BackgroundStyle.BorderTopWidth = 1
        Me.mcHasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.mcHasta.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mcHasta.ContainerControlProcessDialogKey = True
        Me.mcHasta.DisplayMonth = New Date(2010, 10, 1, 0, 0, 0, 0)
        Me.mcHasta.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.mcHasta.Location = New System.Drawing.Point(203, 12)
        Me.mcHasta.MarkedDates = New Date(-1) {}
        Me.mcHasta.MaxDate = New Date(2030, 12, 31, 0, 0, 0, 0)
        Me.mcHasta.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.mcHasta.MonthlyMarkedDates = New Date(-1) {}
        Me.mcHasta.Name = "mcHasta"
        '
        '
        '
        Me.mcHasta.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.mcHasta.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.mcHasta.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.mcHasta.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mcHasta.Size = New System.Drawing.Size(170, 131)
        Me.mcHasta.TabIndex = 174
        Me.mcHasta.Text = "MonthCalendarAdv1"
        Me.mcHasta.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        '
        'mcDesde
        '
        Me.mcDesde.AnnuallyMarkedDates = New Date(-1) {}
        Me.mcDesde.AutoSize = True
        '
        '
        '
        Me.mcDesde.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.mcDesde.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.mcDesde.BackgroundStyle.BorderBottomWidth = 1
        Me.mcDesde.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.mcDesde.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.mcDesde.BackgroundStyle.BorderLeftWidth = 1
        Me.mcDesde.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.mcDesde.BackgroundStyle.BorderRightWidth = 1
        Me.mcDesde.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.mcDesde.BackgroundStyle.BorderTopWidth = 1
        Me.mcDesde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.mcDesde.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mcDesde.ContainerControlProcessDialogKey = True
        Me.mcDesde.DisplayMonth = New Date(2010, 10, 1, 0, 0, 0, 0)
        Me.mcDesde.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.mcDesde.Location = New System.Drawing.Point(3, 12)
        Me.mcDesde.MarkedDates = New Date(-1) {}
        Me.mcDesde.MaxDate = New Date(2030, 12, 31, 0, 0, 0, 0)
        Me.mcDesde.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.mcDesde.MonthlyMarkedDates = New Date(-1) {}
        Me.mcDesde.Name = "mcDesde"
        '
        '
        '
        Me.mcDesde.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.mcDesde.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.mcDesde.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.mcDesde.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mcDesde.Size = New System.Drawing.Size(170, 131)
        Me.mcDesde.TabIndex = 173
        Me.mcDesde.Text = "MonthCalendarAdv1"
        Me.mcDesde.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        '
        'cmdProcesar
        '
        Me.cmdProcesar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdProcesar.BackColor = System.Drawing.SystemColors.Control
        Me.cmdProcesar.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.cmdProcesar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdProcesar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.cmdProcesar.Location = New System.Drawing.Point(800, 65)
        Me.cmdProcesar.Name = "cmdProcesar"
        Me.cmdProcesar.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(5)
        Me.cmdProcesar.Size = New System.Drawing.Size(101, 37)
        Me.cmdProcesar.TabIndex = 180
        Me.cmdProcesar.Text = "Procesar Datos"
        Me.cmdProcesar.TextColor = System.Drawing.Color.Navy
        '
        'cmdCerrar
        '
        Me.cmdCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCerrar.Location = New System.Drawing.Point(801, 108)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(5)
        Me.cmdCerrar.Size = New System.Drawing.Size(100, 36)
        Me.cmdCerrar.TabIndex = 179
        Me.cmdCerrar.Text = "Cerrar"
        '
        'cmdImprimir
        '
        Me.cmdImprimir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdImprimir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdImprimir.Location = New System.Drawing.Point(800, 26)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(5)
        Me.cmdImprimir.Size = New System.Drawing.Size(101, 36)
        Me.cmdImprimir.TabIndex = 178
        Me.cmdImprimir.Text = "Imprimir"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.opt_etiquetas)
        Me.GroupBox2.Controls.Add(Me.optProgEventos)
        Me.GroupBox2.Controls.Add(Me.optReservas)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(402, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(218, 159)
        Me.GroupBox2.TabIndex = 181
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo de Reporte"
        '
        'opt_etiquetas
        '
        Me.opt_etiquetas.AutoSize = True
        Me.opt_etiquetas.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opt_etiquetas.ForeColor = System.Drawing.Color.Black
        Me.opt_etiquetas.Location = New System.Drawing.Point(8, 64)
        Me.opt_etiquetas.Name = "opt_etiquetas"
        Me.opt_etiquetas.Size = New System.Drawing.Size(192, 20)
        Me.opt_etiquetas.TabIndex = 2
        Me.opt_etiquetas.Text = "Etiquetas Orden Trabajo"
        Me.opt_etiquetas.UseVisualStyleBackColor = True
        '
        'optProgEventos
        '
        Me.optProgEventos.AutoSize = True
        Me.optProgEventos.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optProgEventos.ForeColor = System.Drawing.Color.Black
        Me.optProgEventos.Location = New System.Drawing.Point(8, 39)
        Me.optProgEventos.Name = "optProgEventos"
        Me.optProgEventos.Size = New System.Drawing.Size(161, 20)
        Me.optProgEventos.TabIndex = 1
        Me.optProgEventos.Text = "Ordenes de Trabajo"
        Me.optProgEventos.UseVisualStyleBackColor = True
        '
        'optReservas
        '
        Me.optReservas.AutoSize = True
        Me.optReservas.Checked = True
        Me.optReservas.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optReservas.ForeColor = System.Drawing.Color.Black
        Me.optReservas.Location = New System.Drawing.Point(8, 15)
        Me.optReservas.Name = "optReservas"
        Me.optReservas.Size = New System.Drawing.Size(156, 20)
        Me.optReservas.TabIndex = 0
        Me.optReservas.TabStop = True
        Me.optReservas.Text = "Programacion Final"
        Me.optReservas.UseVisualStyleBackColor = True
        '
        'TabControl2
        '
        Me.TabControl2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControl2.CanReorderTabs = False
        Me.TabControl2.ColorScheme.TabBackground = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControl2.ColorScheme.TabBackground2 = System.Drawing.Color.White
        Me.TabControl2.ColorScheme.TabItemBackground = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.TabControl2.ColorScheme.TabItemBackground2 = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControl2.Controls.Add(Me.TabControlPanel4)
        Me.TabControl2.Location = New System.Drawing.Point(-48, 172)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControl2.SelectedTabIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(949, 292)
        Me.TabControl2.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005Document
        Me.TabControl2.TabIndex = 182
        Me.TabControl2.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl2.Tabs.Add(Me.tabSaldos)
        Me.TabControl2.Text = "Precio de Costo Vs. Precio de Venta"
        '
        'TabControlPanel4
        '
        Me.TabControlPanel4.Controls.Add(Me.Datadetalle)
        Me.TabControlPanel4.Controls.Add(Me.PictureBox1)
        Me.TabControlPanel4.Controls.Add(Me.chkIMP)
        Me.TabControlPanel4.Controls.Add(Me.lblMontoDS)
        Me.TabControlPanel4.Controls.Add(Me.lblMonedaDS)
        Me.TabControlPanel4.Controls.Add(Me.lblRegistros)
        Me.TabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel4.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel4.Name = "TabControlPanel4"
        Me.TabControlPanel4.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel4.Size = New System.Drawing.Size(949, 266)
        Me.TabControlPanel4.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanel4.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel4.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.TabControlPanel4.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel4.Style.GradientAngle = 90
        Me.TabControlPanel4.TabIndex = 1
        Me.TabControlPanel4.TabItem = Me.tabSaldos
        '
        'Datadetalle
        '
        Me.Datadetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Desktop
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datadetalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Datadetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Datadetalle.EnableHeadersVisualStyles = False
        Me.Datadetalle.Location = New System.Drawing.Point(51, 0)
        Me.Datadetalle.Name = "Datadetalle"
        Me.Datadetalle.Size = New System.Drawing.Size(898, 262)
        Me.Datadetalle.TabIndex = 161
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = CType(resources.GetObject("PictureBox1.InitialImage"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(251, 372)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 136
        Me.PictureBox1.TabStop = False
        '
        'chkIMP
        '
        Me.chkIMP.AutoSize = True
        '
        '
        '
        Me.chkIMP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkIMP.Checked = True
        Me.chkIMP.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIMP.CheckValue = "Y"
        Me.chkIMP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIMP.Location = New System.Drawing.Point(4, 369)
        Me.chkIMP.Name = "chkIMP"
        Me.chkIMP.Size = New System.Drawing.Size(135, 15)
        Me.chkIMP.TabIndex = 135
        Me.chkIMP.Text = "Precios CON Impuesto"
        Me.chkIMP.TextColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(128, Byte), Integer))
        '
        'lblMontoDS
        '
        Me.lblMontoDS.AutoSize = True
        Me.lblMontoDS.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.lblMontoDS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMontoDS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoDS.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblMontoDS.Location = New System.Drawing.Point(271, 372)
        Me.lblMontoDS.Name = "lblMontoDS"
        Me.lblMontoDS.Size = New System.Drawing.Size(42, 15)
        Me.lblMontoDS.TabIndex = 133
        Me.lblMontoDS.Text = "Monto..."
        Me.lblMontoDS.WordWrap = True
        '
        'lblMonedaDS
        '
        Me.lblMonedaDS.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.lblMonedaDS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMonedaDS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonedaDS.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblMonedaDS.Location = New System.Drawing.Point(145, 372)
        Me.lblMonedaDS.Name = "lblMonedaDS"
        Me.lblMonedaDS.Size = New System.Drawing.Size(96, 15)
        Me.lblMonedaDS.TabIndex = 132
        Me.lblMonedaDS.Text = "Moneda"
        Me.lblMonedaDS.TextAlignment = System.Drawing.StringAlignment.Far
        Me.lblMonedaDS.WordWrap = True
        '
        'lblRegistros
        '
        '
        '
        '
        Me.lblRegistros.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.ForeColor = System.Drawing.Color.Green
        Me.lblRegistros.Location = New System.Drawing.Point(789, 372)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(181, 19)
        Me.lblRegistros.TabIndex = 160
        Me.lblRegistros.Text = "Nº de Registros... "
        Me.lblRegistros.TextAlignment = System.Drawing.StringAlignment.Center
        Me.lblRegistros.WordWrap = True
        '
        'tabSaldos
        '
        Me.tabSaldos.AttachedControl = Me.TabControlPanel4
        Me.tabSaldos.Icon = CType(resources.GetObject("tabSaldos.Icon"), System.Drawing.Icon)
        Me.tabSaldos.Name = "tabSaldos"
        Me.tabSaldos.Text = "Reservas"
        '
        'tabResumen
        '
        Me.tabResumen.Icon = CType(resources.GetObject("tabResumen.Icon"), System.Drawing.Icon)
        Me.tabResumen.Name = "tabResumen"
        Me.tabResumen.Text = "Resumen Anual de Ventas"
        '
        'TabItem1
        '
        Me.TabItem1.Name = "TabItem1"
        Me.TabItem1.Text = "TabItem1"
        Me.TabItem1.Visible = False
        '
        'txtFiltro
        '
        Me.txtFiltro.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtFiltro.Location = New System.Drawing.Point(3, 149)
        Me.txtFiltro.MaxLength = 50
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(342, 20)
        Me.txtFiltro.TabIndex = 183
        '
        'buscar
        '
        Me.buscar.Image = Global.SGE_Eventos.My.Resources.Resources.buscar22
        Me.buscar.Location = New System.Drawing.Point(351, 149)
        Me.buscar.Name = "buscar"
        Me.buscar.Size = New System.Drawing.Size(22, 22)
        Me.buscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.buscar.TabIndex = 184
        Me.buscar.TabStop = False
        '
        'chkestado
        '
        Me.chkestado.AutoSize = True
        '
        '
        '
        Me.chkestado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkestado.Checked = True
        Me.chkestado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkestado.CheckValue = "Y"
        Me.chkestado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkestado.Location = New System.Drawing.Point(643, 98)
        Me.chkestado.Name = "chkestado"
        Me.chkestado.Size = New System.Drawing.Size(126, 17)
        Me.chkestado.TabIndex = 185
        Me.chkestado.Text = "Solo Confirmadas"
        '
        'ChkAdicional
        '
        Me.ChkAdicional.AutoSize = True
        '
        '
        '
        Me.ChkAdicional.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ChkAdicional.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkAdicional.Location = New System.Drawing.Point(643, 120)
        Me.ChkAdicional.Name = "ChkAdicional"
        Me.ChkAdicional.Size = New System.Drawing.Size(119, 17)
        Me.ChkAdicional.TabIndex = 186
        Me.ChkAdicional.Text = "Solo Adicionales"
        '
        'chkCopia
        '
        Me.chkCopia.AutoSize = True
        '
        '
        '
        Me.chkCopia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkCopia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCopia.Location = New System.Drawing.Point(643, 144)
        Me.chkCopia.Name = "chkCopia"
        Me.chkCopia.Size = New System.Drawing.Size(108, 17)
        Me.chkCopia.TabIndex = 187
        Me.chkCopia.Text = "Realizar Copia"
        '
        'lblMonto
        '
        Me.lblMonto.AutoSize = True
        Me.lblMonto.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.lblMonto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblMonto.Location = New System.Drawing.Point(676, 466)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(93, 32)
        Me.lblMonto.TabIndex = 188
        Me.lblMonto.Text = "Monto..."
        Me.lblMonto.WordWrap = True
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonX2.Location = New System.Drawing.Point(549, 466)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(5)
        Me.ButtonX2.Size = New System.Drawing.Size(108, 32)
        Me.ButtonX2.TabIndex = 190
        Me.ButtonX2.Text = "Actualiza OC"
        '
        'rpt_reservas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(915, 506)
        Me.Controls.Add(Me.ButtonX2)
        Me.Controls.Add(Me.lblMonto)
        Me.Controls.Add(Me.chkCopia)
        Me.Controls.Add(Me.ChkAdicional)
        Me.Controls.Add(Me.chkestado)
        Me.Controls.Add(Me.buscar)
        Me.Controls.Add(Me.txtFiltro)
        Me.Controls.Add(Me.TabControl2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdProcesar)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.mcHasta)
        Me.Controls.Add(Me.mcDesde)
        Me.Name = "rpt_reservas"
        Me.Text = "Consulta Reservas"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.TabControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl2.ResumeLayout(False)
        Me.TabControlPanel4.ResumeLayout(False)
        Me.TabControlPanel4.PerformLayout()
        CType(Me.Datadetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.buscar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents mcHasta As DevComponents.Editors.DateTimeAdv.MonthCalendarAdv
    Friend WithEvents mcDesde As DevComponents.Editors.DateTimeAdv.MonthCalendarAdv
    Friend WithEvents cmdProcesar As ButtonX
    Friend WithEvents cmdCerrar As ButtonX
    Friend WithEvents cmdImprimir As ButtonX
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents optReservas As RadioButton
    Friend WithEvents TabControl2 As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel4 As TabControlPanel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents chkIMP As Controls.CheckBoxX
    Friend WithEvents lblMontoDS As LabelX
    Friend WithEvents lblMonedaDS As LabelX
    Friend WithEvents lblRegistros As LabelX
    Friend WithEvents tabSaldos As TabItem
    Friend WithEvents tabResumen As TabItem
    Friend WithEvents TabItem1 As TabItem
    Friend WithEvents txtFiltro As TextBox
    Friend WithEvents buscar As PictureBox
    Friend WithEvents Datadetalle As DataGridView
    Friend WithEvents optProgEventos As RadioButton
    Friend WithEvents chkestado As Controls.CheckBoxX
    Friend WithEvents ChkAdicional As Controls.CheckBoxX
    Friend WithEvents chkCopia As Controls.CheckBoxX
    Friend WithEvents lblMonto As LabelX
    Friend WithEvents ButtonX2 As ButtonX
    Friend WithEvents opt_etiquetas As RadioButton
End Class
