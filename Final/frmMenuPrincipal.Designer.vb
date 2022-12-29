<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMenuPrincipal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMenuPrincipal))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.AltasYActualizacionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AgrupacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArticuloToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TipoDeMovimientoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MovimientosDeCantidadesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InformesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnMovCant = New System.Windows.Forms.Button()
        Me.btnTipoMov = New System.Windows.Forms.Button()
        Me.btnArticulos = New System.Windows.Forms.Button()
        Me.btnAgrupacion = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblValorStock = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tlsInternet = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AltasYActualizacionesToolStripMenuItem, Me.MovimientosDeCantidadesToolStripMenuItem, Me.InformesToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(789, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AltasYActualizacionesToolStripMenuItem
        '
        Me.AltasYActualizacionesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AgrupacionToolStripMenuItem, Me.ArticuloToolStripMenuItem, Me.TipoDeMovimientoToolStripMenuItem})
        Me.AltasYActualizacionesToolStripMenuItem.Name = "AltasYActualizacionesToolStripMenuItem"
        Me.AltasYActualizacionesToolStripMenuItem.Size = New System.Drawing.Size(139, 20)
        Me.AltasYActualizacionesToolStripMenuItem.Text = "Altas y Actualizaciones"
        '
        'AgrupacionToolStripMenuItem
        '
        Me.AgrupacionToolStripMenuItem.Image = Global.Final.My.Resources.Resources.agrupacion
        Me.AgrupacionToolStripMenuItem.Name = "AgrupacionToolStripMenuItem"
        Me.AgrupacionToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.AgrupacionToolStripMenuItem.Text = "Agrupacion"
        '
        'ArticuloToolStripMenuItem
        '
        Me.ArticuloToolStripMenuItem.Image = Global.Final.My.Resources.Resources.tornillo
        Me.ArticuloToolStripMenuItem.Name = "ArticuloToolStripMenuItem"
        Me.ArticuloToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.ArticuloToolStripMenuItem.Text = "Articulo"
        '
        'TipoDeMovimientoToolStripMenuItem
        '
        Me.TipoDeMovimientoToolStripMenuItem.Image = Global.Final.My.Resources.Resources.es
        Me.TipoDeMovimientoToolStripMenuItem.Name = "TipoDeMovimientoToolStripMenuItem"
        Me.TipoDeMovimientoToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.TipoDeMovimientoToolStripMenuItem.Text = "Tipo de movimiento"
        '
        'MovimientosDeCantidadesToolStripMenuItem
        '
        Me.MovimientosDeCantidadesToolStripMenuItem.Image = Global.Final.My.Resources.Resources.transaccion
        Me.MovimientosDeCantidadesToolStripMenuItem.Name = "MovimientosDeCantidadesToolStripMenuItem"
        Me.MovimientosDeCantidadesToolStripMenuItem.Size = New System.Drawing.Size(181, 20)
        Me.MovimientosDeCantidadesToolStripMenuItem.Text = "Movimientos de cantidades"
        '
        'InformesToolStripMenuItem
        '
        Me.InformesToolStripMenuItem.Image = Global.Final.My.Resources.Resources.informe3
        Me.InformesToolStripMenuItem.Name = "InformesToolStripMenuItem"
        Me.InformesToolStripMenuItem.Size = New System.Drawing.Size(82, 20)
        Me.InformesToolStripMenuItem.Text = "Informes"
        '
        'btnMovCant
        '
        Me.btnMovCant.BackgroundImage = Global.Final.My.Resources.Resources.transaccion
        Me.btnMovCant.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnMovCant.Location = New System.Drawing.Point(156, 27)
        Me.btnMovCant.Name = "btnMovCant"
        Me.btnMovCant.Size = New System.Drawing.Size(42, 39)
        Me.btnMovCant.TabIndex = 4
        Me.btnMovCant.UseVisualStyleBackColor = True
        '
        'btnTipoMov
        '
        Me.btnTipoMov.BackColor = System.Drawing.Color.White
        Me.btnTipoMov.Image = Global.Final.My.Resources.Resources.es
        Me.btnTipoMov.Location = New System.Drawing.Point(108, 27)
        Me.btnTipoMov.Name = "btnTipoMov"
        Me.btnTipoMov.Size = New System.Drawing.Size(42, 39)
        Me.btnTipoMov.TabIndex = 3
        Me.btnTipoMov.UseVisualStyleBackColor = False
        '
        'btnArticulos
        '
        Me.btnArticulos.BackgroundImage = Global.Final.My.Resources.Resources.tornillo
        Me.btnArticulos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnArticulos.Location = New System.Drawing.Point(60, 27)
        Me.btnArticulos.Name = "btnArticulos"
        Me.btnArticulos.Size = New System.Drawing.Size(42, 39)
        Me.btnArticulos.TabIndex = 2
        Me.btnArticulos.UseVisualStyleBackColor = True
        '
        'btnAgrupacion
        '
        Me.btnAgrupacion.BackgroundImage = Global.Final.My.Resources.Resources.agrupacion
        Me.btnAgrupacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAgrupacion.Location = New System.Drawing.Point(12, 27)
        Me.btnAgrupacion.Name = "btnAgrupacion"
        Me.btnAgrupacion.Size = New System.Drawing.Size(42, 39)
        Me.btnAgrupacion.TabIndex = 1
        Me.btnAgrupacion.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(436, 265)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 18)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "®"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 144)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Valor de stock:"
        '
        'lblValorStock
        '
        Me.lblValorStock.AutoSize = True
        Me.lblValorStock.Location = New System.Drawing.Point(86, 144)
        Me.lblValorStock.Name = "lblValorStock"
        Me.lblValorStock.Size = New System.Drawing.Size(0, 13)
        Me.lblValorStock.TabIndex = 7
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.White
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.tlsInternet})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 404)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(789, 24)
        Me.StatusStrip1.TabIndex = 10
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripStatusLabel1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(166, 19)
        Me.ToolStripStatusLabel1.Text = "Conectado a la Base de Datos"
        '
        'tlsInternet
        '
        Me.tlsInternet.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.tlsInternet.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tlsInternet.Name = "tlsInternet"
        Me.tlsInternet.Size = New System.Drawing.Size(4, 19)
        '
        'frmMenuPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BackgroundImage = Global.Final.My.Resources.Resources.Captura_de_pantalla__96_
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(789, 428)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.lblValorStock)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnMovCant)
        Me.Controls.Add(Me.btnTipoMov)
        Me.Controls.Add(Me.btnArticulos)
        Me.Controls.Add(Me.btnAgrupacion)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "frmMenuPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu Principal"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents AltasYActualizacionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AgrupacionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ArticuloToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TipoDeMovimientoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MovimientosDeCantidadesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InformesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnAgrupacion As Button
    Friend WithEvents btnArticulos As Button
    Friend WithEvents btnTipoMov As Button
    Friend WithEvents btnMovCant As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblValorStock As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents tlsInternet As ToolStripStatusLabel
End Class
