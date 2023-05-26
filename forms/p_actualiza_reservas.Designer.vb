<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class p_actualiza_reservas
    Inherits SGE_Eventos.base

    'Form invalida a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkfacturar = New System.Windows.Forms.CheckBox()
        Me.cmdCancelar = New DevExpress.DXCore.Controls.XtraEditors.SimpleButton()
        Me.cmdAceptar = New DevExpress.DXCore.Controls.XtraEditors.SimpleButton()
        Me.lblnumfactura = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtnumfactura = New System.Windows.Forms.TextBox()
        Me.txtNro_orden = New System.Windows.Forms.TextBox()
        Me.lblnumidfactura = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkfacturar)
        Me.GroupBox1.Controls.Add(Me.cmdCancelar)
        Me.GroupBox1.Controls.Add(Me.cmdAceptar)
        Me.GroupBox1.Controls.Add(Me.lblnumfactura)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtnumfactura)
        Me.GroupBox1.Controls.Add(Me.txtNro_orden)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(392, 161)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'chkfacturar
        '
        Me.chkfacturar.AutoSize = True
        Me.chkfacturar.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkfacturar.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.chkfacturar.Location = New System.Drawing.Point(150, 134)
        Me.chkfacturar.Name = "chkfacturar"
        Me.chkfacturar.Size = New System.Drawing.Size(98, 19)
        Me.chkfacturar.TabIndex = 176
        Me.chkfacturar.Text = "FACTURAR"
        Me.chkfacturar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancelar.Appearance.Options.UseFont = True
        Me.cmdCancelar.Image = Global.SGE_Eventos.My.Resources.Resources.transforma1
        Me.cmdCancelar.ImageLocation = DevExpress.DXCore.Controls.XtraEditors.ImageLocation.TopCenter
        Me.cmdCancelar.Location = New System.Drawing.Point(110, 78)
        Me.cmdCancelar.LookAndFeel.SkinName = "iMaginary"
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(64, 50)
        Me.cmdCancelar.TabIndex = 175
        Me.cmdCancelar.Text = "Cancelar"
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAceptar.Appearance.Options.UseFont = True
        Me.cmdAceptar.Image = Global.SGE_Eventos.My.Resources.Resources.ejecutar22
        Me.cmdAceptar.ImageLocation = DevExpress.DXCore.Controls.XtraEditors.ImageLocation.TopCenter
        Me.cmdAceptar.Location = New System.Drawing.Point(226, 78)
        Me.cmdAceptar.LookAndFeel.SkinName = "iMaginary"
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(64, 50)
        Me.cmdAceptar.TabIndex = 174
        Me.cmdAceptar.Text = "Aceptar"
        '
        'lblnumfactura
        '
        Me.lblnumfactura.AutoSize = True
        Me.lblnumfactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnumfactura.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblnumfactura.Location = New System.Drawing.Point(32, 51)
        Me.lblnumfactura.Name = "lblnumfactura"
        Me.lblnumfactura.Size = New System.Drawing.Size(53, 16)
        Me.lblnumfactura.TabIndex = 11
        Me.lblnumfactura.Text = "Factura"
        Me.lblnumfactura.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label1.Location = New System.Drawing.Point(32, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 16)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Orden Compra"
        '
        'txtnumfactura
        '
        Me.txtnumfactura.Location = New System.Drawing.Point(137, 48)
        Me.txtnumfactura.Name = "txtnumfactura"
        Me.txtnumfactura.Size = New System.Drawing.Size(218, 20)
        Me.txtnumfactura.TabIndex = 9
        Me.txtnumfactura.Visible = False
        '
        'txtNro_orden
        '
        Me.txtNro_orden.Location = New System.Drawing.Point(137, 19)
        Me.txtNro_orden.Name = "txtNro_orden"
        Me.txtNro_orden.Size = New System.Drawing.Size(218, 20)
        Me.txtNro_orden.TabIndex = 8
        '
        'lblnumidfactura
        '
        Me.lblnumidfactura.AutoSize = True
        Me.lblnumidfactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnumidfactura.ForeColor = System.Drawing.Color.DarkRed
        Me.lblnumidfactura.Location = New System.Drawing.Point(47, 7)
        Me.lblnumidfactura.Name = "lblnumidfactura"
        Me.lblnumidfactura.Size = New System.Drawing.Size(14, 20)
        Me.lblnumidfactura.TabIndex = 177
        Me.lblnumidfactura.Text = "."
        Me.lblnumidfactura.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'p_actualiza_reservas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(451, 219)
        Me.Controls.Add(Me.lblnumidfactura)
        Me.Controls.Add(Me.GroupBox1)
        Me.DoubleBuffered = True
        Me.Name = "p_actualiza_reservas"
        Me.Text = "Actualiza"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblnumfactura As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtnumfactura As TextBox
    Friend WithEvents txtNro_orden As TextBox
    Friend WithEvents cmdCancelar As DevExpress.DXCore.Controls.XtraEditors.SimpleButton
    Friend WithEvents cmdAceptar As DevExpress.DXCore.Controls.XtraEditors.SimpleButton
    Friend WithEvents lblnumidfactura As Label
    Friend WithEvents chkfacturar As CheckBox
End Class
