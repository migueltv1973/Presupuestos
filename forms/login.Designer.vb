<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
    Inherits SGE_Eventos.base

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.txtClave = New System.Windows.Forms.TextBox()
        Me.LblPeriodo = New System.Windows.Forms.Label()
        Me.Lbltipcambio = New System.Windows.Forms.Label()
        Me.cmdContinuar = New DevComponents.DotNetBar.ButtonX()
        Me.SuspendLayout()
        '
        'txtUsuario
        '
        Me.txtUsuario.BackColor = System.Drawing.Color.LightGray
        Me.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuario.ForeColor = System.Drawing.Color.Black
        Me.txtUsuario.Location = New System.Drawing.Point(86, 219)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(182, 22)
        Me.txtUsuario.TabIndex = 1
        '
        'txtClave
        '
        Me.txtClave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtClave.BackColor = System.Drawing.Color.LightGray
        Me.txtClave.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtClave.Font = New System.Drawing.Font("Wingdings", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.txtClave.ForeColor = System.Drawing.Color.White
        Me.txtClave.Location = New System.Drawing.Point(85, 276)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(108)
        Me.txtClave.Size = New System.Drawing.Size(153, 18)
        Me.txtClave.TabIndex = 2
        '
        'LblPeriodo
        '
        Me.LblPeriodo.AutoSize = True
        Me.LblPeriodo.BackColor = System.Drawing.Color.Transparent
        Me.LblPeriodo.Font = New System.Drawing.Font("Agency FB", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPeriodo.ForeColor = System.Drawing.Color.DimGray
        Me.LblPeriodo.Location = New System.Drawing.Point(23, 319)
        Me.LblPeriodo.Name = "LblPeriodo"
        Me.LblPeriodo.Size = New System.Drawing.Size(12, 17)
        Me.LblPeriodo.TabIndex = 153
        Me.LblPeriodo.Text = "-"
        Me.LblPeriodo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lbltipcambio
        '
        Me.Lbltipcambio.AutoSize = True
        Me.Lbltipcambio.BackColor = System.Drawing.Color.Transparent
        Me.Lbltipcambio.Font = New System.Drawing.Font("Agency FB", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbltipcambio.ForeColor = System.Drawing.Color.DimGray
        Me.Lbltipcambio.Location = New System.Drawing.Point(175, 319)
        Me.Lbltipcambio.Name = "Lbltipcambio"
        Me.Lbltipcambio.Size = New System.Drawing.Size(12, 17)
        Me.Lbltipcambio.TabIndex = 157
        Me.Lbltipcambio.Text = "-"
        Me.Lbltipcambio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdContinuar
        '
        Me.cmdContinuar.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.cmdContinuar.BackColor = System.Drawing.Color.Transparent
        Me.cmdContinuar.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue
        Me.cmdContinuar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdContinuar.Image = Global.SGE_Eventos.My.Resources.Resources.boton
        Me.cmdContinuar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.cmdContinuar.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cmdContinuar.Location = New System.Drawing.Point(248, 270)
        Me.cmdContinuar.Name = "cmdContinuar"
        Me.cmdContinuar.Size = New System.Drawing.Size(41, 40)
        Me.cmdContinuar.Style = DevComponents.DotNetBar.eDotNetBarStyle.Windows7
        Me.cmdContinuar.TabIndex = 3
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(300, 351)
        Me.Controls.Add(Me.txtClave)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.Lbltipcambio)
        Me.Controls.Add(Me.LblPeriodo)
        Me.Controls.Add(Me.cmdContinuar)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Login"
        Me.Text = "Login"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents cmdContinuar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LblPeriodo As System.Windows.Forms.Label
    Friend WithEvents Lbltipcambio As System.Windows.Forms.Label

End Class
