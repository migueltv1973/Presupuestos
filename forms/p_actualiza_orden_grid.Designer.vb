<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class p_actualiza_orden_grid
    Inherits SGE_Eventos.base

    'Form invalida a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.txtNumOrden = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.buscar = New System.Windows.Forms.PictureBox()
        Me.lblmonto2 = New DevComponents.DotNetBar.LabelX()
        Me.lblMonto1 = New DevComponents.DotNetBar.LabelX()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.datagv_idr2 = New System.Windows.Forms.DataGridView()
        Me.datagv_idr1 = New System.Windows.Forms.DataGridView()
        Me.buscar2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.LblFactura = New DevComponents.DotNetBar.LabelX()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.buscar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datagv_idr2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datagv_idr1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.buscar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelX2
        '
        Me.LabelX2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelX2.AutoSize = True
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.LabelX2.Location = New System.Drawing.Point(379, 7)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(80, 15)
        Me.LabelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003
        Me.LabelX2.TabIndex = 197
        Me.LabelX2.Text = "OC...FACTURA"
        Me.LabelX2.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX2.WordWrap = True
        '
        'LabelX1
        '
        Me.LabelX1.AutoSize = True
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.LabelX1.Location = New System.Drawing.Point(12, 7)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 15)
        Me.LabelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003
        Me.LabelX1.TabIndex = 196
        Me.LabelX1.Text = "ID...FACTURA"
        Me.LabelX1.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX1.WordWrap = True
        '
        'txtNumOrden
        '
        Me.txtNumOrden.BackColor = System.Drawing.SystemColors.Info
        Me.txtNumOrden.Location = New System.Drawing.Point(465, 5)
        Me.txtNumOrden.Name = "txtNumOrden"
        Me.txtNumOrden.Size = New System.Drawing.Size(229, 20)
        Me.txtNumOrden.TabIndex = 195
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.SGE_Eventos.My.Resources.Resources.ejecutar22
        Me.PictureBox1.Location = New System.Drawing.Point(700, 35)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(22, 22)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 194
        Me.PictureBox1.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Info
        Me.TextBox1.Location = New System.Drawing.Point(93, 4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(206, 20)
        Me.TextBox1.TabIndex = 193
        '
        'buscar
        '
        Me.buscar.Image = Global.SGE_Eventos.My.Resources.Resources.buscar22
        Me.buscar.Location = New System.Drawing.Point(305, 4)
        Me.buscar.Name = "buscar"
        Me.buscar.Size = New System.Drawing.Size(22, 22)
        Me.buscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.buscar.TabIndex = 192
        Me.buscar.TabStop = False
        '
        'lblmonto2
        '
        Me.lblmonto2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblmonto2.AutoSize = True
        Me.lblmonto2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lblmonto2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblmonto2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmonto2.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.lblmonto2.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.lblmonto2.Location = New System.Drawing.Point(566, 324)
        Me.lblmonto2.Name = "lblmonto2"
        Me.lblmonto2.Size = New System.Drawing.Size(17, 21)
        Me.lblmonto2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.lblmonto2.TabIndex = 190
        Me.lblmonto2.Text = "..."
        Me.lblmonto2.TextAlignment = System.Drawing.StringAlignment.Center
        Me.lblmonto2.WordWrap = True
        '
        'lblMonto1
        '
        Me.lblMonto1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMonto1.AutoSize = True
        Me.lblMonto1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lblMonto1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMonto1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonto1.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.lblMonto1.Location = New System.Drawing.Point(161, 324)
        Me.lblMonto1.Name = "lblMonto1"
        Me.lblMonto1.Size = New System.Drawing.Size(17, 21)
        Me.lblMonto1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003
        Me.lblMonto1.TabIndex = 189
        Me.lblMonto1.Text = "..."
        Me.lblMonto1.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.lblMonto1.WordWrap = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(336, 59)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(34, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = ">>"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'datagv_idr2
        '
        Me.datagv_idr2.AllowUserToAddRows = False
        Me.datagv_idr2.BackgroundColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.datagv_idr2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.datagv_idr2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagv_idr2.GridColor = System.Drawing.SystemColors.Control
        Me.datagv_idr2.Location = New System.Drawing.Point(379, 31)
        Me.datagv_idr2.Name = "datagv_idr2"
        Me.datagv_idr2.ReadOnly = True
        Me.datagv_idr2.Size = New System.Drawing.Size(315, 287)
        Me.datagv_idr2.TabIndex = 1
        '
        'datagv_idr1
        '
        Me.datagv_idr1.AllowUserToAddRows = False
        Me.datagv_idr1.BackgroundColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Desktop
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.datagv_idr1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.datagv_idr1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.InactiveBorder
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.datagv_idr1.DefaultCellStyle = DataGridViewCellStyle3
        Me.datagv_idr1.GridColor = System.Drawing.SystemColors.Control
        Me.datagv_idr1.Location = New System.Drawing.Point(12, 31)
        Me.datagv_idr1.Name = "datagv_idr1"
        Me.datagv_idr1.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.datagv_idr1.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.datagv_idr1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datagv_idr1.Size = New System.Drawing.Size(317, 287)
        Me.datagv_idr1.TabIndex = 0
        '
        'buscar2
        '
        Me.buscar2.Image = Global.SGE_Eventos.My.Resources.Resources.buscar22
        Me.buscar2.Location = New System.Drawing.Point(700, 7)
        Me.buscar2.Name = "buscar2"
        Me.buscar2.Size = New System.Drawing.Size(22, 22)
        Me.buscar2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.buscar2.TabIndex = 198
        Me.buscar2.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.SGE_Eventos.My.Resources.Resources.tr_024
        Me.PictureBox2.Location = New System.Drawing.Point(342, 167)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 199
        Me.PictureBox2.TabStop = False
        '
        'LblFactura
        '
        Me.LblFactura.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblFactura.AutoSize = True
        Me.LblFactura.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LblFactura.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFactura.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.LblFactura.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.LblFactura.Location = New System.Drawing.Point(379, 324)
        Me.LblFactura.Name = "LblFactura"
        Me.LblFactura.Size = New System.Drawing.Size(0, 0)
        Me.LblFactura.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LblFactura.TabIndex = 200
        Me.LblFactura.TextAlignment = System.Drawing.StringAlignment.Center
        Me.LblFactura.WordWrap = True
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.SGE_Eventos.My.Resources.Resources.cancel22
        Me.PictureBox3.Location = New System.Drawing.Point(700, 63)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(22, 22)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox3.TabIndex = 201
        Me.PictureBox3.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.SGE_Eventos.My.Resources.Resources._print
        Me.PictureBox4.Location = New System.Drawing.Point(700, 276)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox4.TabIndex = 202
        Me.PictureBox4.TabStop = False
        '
        'p_actualiza_orden_grid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(737, 356)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.LblFactura)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.buscar2)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.txtNumOrden)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.buscar)
        Me.Controls.Add(Me.lblmonto2)
        Me.Controls.Add(Me.lblMonto1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.datagv_idr2)
        Me.Controls.Add(Me.datagv_idr1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "p_actualiza_orden_grid"
        Me.Text = "Actualiza"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.buscar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datagv_idr2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datagv_idr1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.buscar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents datagv_idr1 As DataGridView
    Friend WithEvents datagv_idr2 As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents lblMonto1 As LabelX
    Friend WithEvents lblmonto2 As LabelX
    Friend WithEvents buscar As PictureBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents txtNumOrden As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents LabelX1 As LabelX
    Friend WithEvents LabelX2 As LabelX
    Friend WithEvents buscar2 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents LblFactura As LabelX
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
End Class
