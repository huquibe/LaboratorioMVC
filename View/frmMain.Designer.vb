<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MaestrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FormasDePagoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CajerosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColeccionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlmacenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CiudadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TipoDeProductoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MovimientosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VentasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InventarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MaestrosToolStripMenuItem, Me.MovimientosToolStripMenuItem, Me.ConsultasToolStripMenuItem, Me.SalirToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(655, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MaestrosToolStripMenuItem
        '
        Me.MaestrosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClientesToolStripMenuItem, Me.CajerosToolStripMenuItem, Me.ProductosToolStripMenuItem, Me.ColeccionesToolStripMenuItem, Me.AlmacenToolStripMenuItem, Me.FormasDePagoToolStripMenuItem, Me.CiudadToolStripMenuItem, Me.TipoDeProductoToolStripMenuItem})
        Me.MaestrosToolStripMenuItem.Name = "MaestrosToolStripMenuItem"
        Me.MaestrosToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.MaestrosToolStripMenuItem.Text = "Maestros"
        '
        'FormasDePagoToolStripMenuItem
        '
        Me.FormasDePagoToolStripMenuItem.Name = "FormasDePagoToolStripMenuItem"
        Me.FormasDePagoToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.FormasDePagoToolStripMenuItem.Text = "Formas de Pago"
        '
        'ClientesToolStripMenuItem
        '
        Me.ClientesToolStripMenuItem.Name = "ClientesToolStripMenuItem"
        Me.ClientesToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.ClientesToolStripMenuItem.Text = "Clientes"
        '
        'CajerosToolStripMenuItem
        '
        Me.CajerosToolStripMenuItem.Name = "CajerosToolStripMenuItem"
        Me.CajerosToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.CajerosToolStripMenuItem.Text = "Cajeros"
        '
        'ProductosToolStripMenuItem
        '
        Me.ProductosToolStripMenuItem.Name = "ProductosToolStripMenuItem"
        Me.ProductosToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.ProductosToolStripMenuItem.Text = "Productos"
        '
        'ColeccionesToolStripMenuItem
        '
        Me.ColeccionesToolStripMenuItem.Name = "ColeccionesToolStripMenuItem"
        Me.ColeccionesToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.ColeccionesToolStripMenuItem.Text = "Colecciones"
        '
        'AlmacenToolStripMenuItem
        '
        Me.AlmacenToolStripMenuItem.Name = "AlmacenToolStripMenuItem"
        Me.AlmacenToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.AlmacenToolStripMenuItem.Text = "Almacenes"
        '
        'CiudadToolStripMenuItem
        '
        Me.CiudadToolStripMenuItem.Name = "CiudadToolStripMenuItem"
        Me.CiudadToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.CiudadToolStripMenuItem.Text = "Ciudades"
        '
        'TipoDeProductoToolStripMenuItem
        '
        Me.TipoDeProductoToolStripMenuItem.Name = "TipoDeProductoToolStripMenuItem"
        Me.TipoDeProductoToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.TipoDeProductoToolStripMenuItem.Text = "Tipo de Producto"
        '
        'MovimientosToolStripMenuItem
        '
        Me.MovimientosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VentasToolStripMenuItem})
        Me.MovimientosToolStripMenuItem.Name = "MovimientosToolStripMenuItem"
        Me.MovimientosToolStripMenuItem.Size = New System.Drawing.Size(89, 20)
        Me.MovimientosToolStripMenuItem.Text = "Movimientos"
        '
        'VentasToolStripMenuItem
        '
        Me.VentasToolStripMenuItem.Name = "VentasToolStripMenuItem"
        Me.VentasToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.VentasToolStripMenuItem.Text = "Ventas"
        '
        'ConsultasToolStripMenuItem
        '
        Me.ConsultasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InventarioToolStripMenuItem})
        Me.ConsultasToolStripMenuItem.Name = "ConsultasToolStripMenuItem"
        Me.ConsultasToolStripMenuItem.Size = New System.Drawing.Size(71, 20)
        Me.ConsultasToolStripMenuItem.Text = "Consultas"
        '
        'InventarioToolStripMenuItem
        '
        Me.InventarioToolStripMenuItem.Name = "InventarioToolStripMenuItem"
        Me.InventarioToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.InventarioToolStripMenuItem.Text = "Inventario"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(655, 261)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.Text = "Cueros de América"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MaestrosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClientesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CajerosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProductosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ColeccionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AlmacenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FormasDePagoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CiudadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TipoDeProductoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MovimientosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VentasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConsultasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InventarioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As ToolStripMenuItem
End Class
