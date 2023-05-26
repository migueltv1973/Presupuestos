<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class p_notas
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtprecio = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtcant_prod = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtcant = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblnotas = New DevComponents.DotNetBar.LabelX()
        Me.cmdCancelar = New DevExpress.DXCore.Controls.XtraEditors.SimpleButton()
        Me.cmdAceptar = New DevExpress.DXCore.Controls.XtraEditors.SimpleButton()
        Me.txtnotas = New System.Windows.Forms.RichTextBox()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(240, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 18)
        Me.Label2.TabIndex = 180
        Me.Label2.Text = "Precio"
        '
        'txtprecio
        '
        Me.txtprecio.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtprecio.Border.Class = "TextBoxBorder"
        Me.txtprecio.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtprecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtprecio.ForeColor = System.Drawing.Color.Black
        Me.txtprecio.Location = New System.Drawing.Point(302, 38)
        Me.txtprecio.Name = "txtprecio"
        Me.txtprecio.Size = New System.Drawing.Size(83, 21)
        Me.txtprecio.TabIndex = 179
        Me.txtprecio.TabStop = False
        Me.txtprecio.Text = "0.00"
        Me.txtprecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 18)
        Me.Label1.TabIndex = 178
        Me.Label1.Text = "Produccion"
        '
        'txtcant_prod
        '
        Me.txtcant_prod.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtcant_prod.Border.Class = "TextBoxBorder"
        Me.txtcant_prod.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtcant_prod.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcant_prod.ForeColor = System.Drawing.Color.Black
        Me.txtcant_prod.Location = New System.Drawing.Point(122, 63)
        Me.txtcant_prod.Name = "txtcant_prod"
        Me.txtcant_prod.Size = New System.Drawing.Size(68, 21)
        Me.txtcant_prod.TabIndex = 177
        Me.txtcant_prod.TabStop = False
        Me.txtcant_prod.Text = "0"
        Me.txtcant_prod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(15, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 18)
        Me.Label6.TabIndex = 176
        Me.Label6.Text = "Cantidad"
        '
        'txtcant
        '
        Me.txtcant.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtcant.Border.Class = "TextBoxBorder"
        Me.txtcant.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtcant.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcant.ForeColor = System.Drawing.Color.Black
        Me.txtcant.Location = New System.Drawing.Point(122, 38)
        Me.txtcant.Name = "txtcant"
        Me.txtcant.Size = New System.Drawing.Size(68, 21)
        Me.txtcant.TabIndex = 0
        Me.txtcant.TabStop = False
        Me.txtcant.Text = "0"
        Me.txtcant.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblnotas)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox3.Location = New System.Drawing.Point(12, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(381, 35)
        Me.GroupBox3.TabIndex = 175
        Me.GroupBox3.TabStop = False
        '
        'lblnotas
        '
        '
        '
        '
        Me.lblnotas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblnotas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnotas.ForeColor = System.Drawing.Color.Maroon
        Me.lblnotas.Location = New System.Drawing.Point(6, 12)
        Me.lblnotas.Name = "lblnotas"
        Me.lblnotas.Size = New System.Drawing.Size(367, 17)
        Me.lblnotas.TabIndex = 0
        Me.lblnotas.Text = "Ingrese Observacion"
        Me.lblnotas.TextAlignment = System.Drawing.StringAlignment.Center
        Me.lblnotas.WordWrap = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancelar.Appearance.Options.UseFont = True
        Me.cmdCancelar.Image = Global.SGE_Eventos.My.Resources.Resources.Error_22
        Me.cmdCancelar.ImageLocation = DevExpress.DXCore.Controls.XtraEditors.ImageLocation.TopCenter
        Me.cmdCancelar.Location = New System.Drawing.Point(98, 164)
        Me.cmdCancelar.LookAndFeel.SkinName = "iMaginary"
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(64, 50)
        Me.cmdCancelar.TabIndex = 173
        Me.cmdCancelar.Text = "Eliminar"
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAceptar.Appearance.Options.UseFont = True
        Me.cmdAceptar.Image = Global.SGE_Eventos.My.Resources.Resources.ejecutar22
        Me.cmdAceptar.ImageLocation = DevExpress.DXCore.Controls.XtraEditors.ImageLocation.TopCenter
        Me.cmdAceptar.Location = New System.Drawing.Point(234, 164)
        Me.cmdAceptar.LookAndFeel.SkinName = "iMaginary"
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(64, 50)
        Me.cmdAceptar.TabIndex = 172
        Me.cmdAceptar.Text = "Aceptar"
        '
        'txtnotas
        '
        Me.txtnotas.Location = New System.Drawing.Point(12, 89)
        Me.txtnotas.Name = "txtnotas"
        Me.txtnotas.Size = New System.Drawing.Size(373, 69)
        Me.txtnotas.TabIndex = 100
        Me.txtnotas.Text = ""
        '
        'p_notas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(408, 253)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtprecio)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtcant_prod)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtcant)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.txtnotas)
        Me.DoubleBuffered = True
        Me.Name = "p_notas"
        Me.Text = "Ingreso Detalle"
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtnotas As System.Windows.Forms.RichTextBox
    Friend WithEvents cmdCancelar As DevExpress.DXCore.Controls.XtraEditors.SimpleButton
    Friend WithEvents cmdAceptar As DevExpress.DXCore.Controls.XtraEditors.SimpleButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblnotas As DevComponents.DotNetBar.LabelX
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtcant As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label1 As Label
    Friend WithEvents txtcant_prod As Controls.TextBoxX
    Friend WithEvents Label2 As Label
    Friend WithEvents txtprecio As Controls.TextBoxX
End Class
