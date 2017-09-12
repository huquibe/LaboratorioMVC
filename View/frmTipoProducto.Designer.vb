<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTipoProducto
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
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmdUndo = New System.Windows.Forms.Button()
        Me.cmdFind = New System.Windows.Forms.Button()
        Me.cmdNew = New System.Windows.Forms.Button()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdFirst = New System.Windows.Forms.Button()
        Me.cmdPrev = New System.Windows.Forms.Button()
        Me.cmdNext = New System.Windows.Forms.Button()
        Me.cmdLast = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.ForeColor = System.Drawing.Color.White
        Me.lblNombre.Location = New System.Drawing.Point(85, 9)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(92, 29)
        Me.lblNombre.TabIndex = 0
        Me.lblNombre.Text = "Label1"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Controls.Add(Me.lblNombre)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(683, 41)
        Me.Panel1.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.Controls.Add(Me.cmdUndo)
        Me.Panel2.Controls.Add(Me.cmdFind)
        Me.Panel2.Controls.Add(Me.cmdNew)
        Me.Panel2.Controls.Add(Me.cmdEdit)
        Me.Panel2.Controls.Add(Me.cmdSave)
        Me.Panel2.Controls.Add(Me.cmdFirst)
        Me.Panel2.Controls.Add(Me.cmdPrev)
        Me.Panel2.Controls.Add(Me.cmdNext)
        Me.Panel2.Controls.Add(Me.cmdLast)
        Me.Panel2.Controls.Add(Me.cmdExit)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 41)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(85, 291)
        Me.Panel2.TabIndex = 2
        '
        'cmdUndo
        '
        Me.cmdUndo.Location = New System.Drawing.Point(12, 163)
        Me.cmdUndo.Name = "cmdUndo"
        Me.cmdUndo.Size = New System.Drawing.Size(65, 23)
        Me.cmdUndo.TabIndex = 19
        Me.cmdUndo.Text = "Deshacer"
        Me.cmdUndo.UseVisualStyleBackColor = True
        '
        'cmdFind
        '
        Me.cmdFind.Location = New System.Drawing.Point(12, 110)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(65, 23)
        Me.cmdFind.TabIndex = 18
        Me.cmdFind.Text = "Buscar"
        Me.cmdFind.UseVisualStyleBackColor = True
        '
        'cmdNew
        '
        Me.cmdNew.Location = New System.Drawing.Point(12, 136)
        Me.cmdNew.Name = "cmdNew"
        Me.cmdNew.Size = New System.Drawing.Size(65, 23)
        Me.cmdNew.TabIndex = 17
        Me.cmdNew.Text = "Nuevo"
        Me.cmdNew.UseVisualStyleBackColor = True
        '
        'cmdEdit
        '
        Me.cmdEdit.Location = New System.Drawing.Point(12, 190)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(65, 23)
        Me.cmdEdit.TabIndex = 16
        Me.cmdEdit.Text = "Modificar"
        Me.cmdEdit.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(12, 216)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(65, 23)
        Me.cmdSave.TabIndex = 15
        Me.cmdSave.Text = "Guardar"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdFirst
        '
        Me.cmdFirst.Location = New System.Drawing.Point(12, 6)
        Me.cmdFirst.Name = "cmdFirst"
        Me.cmdFirst.Size = New System.Drawing.Size(65, 23)
        Me.cmdFirst.TabIndex = 14
        Me.cmdFirst.Text = "Primero"
        Me.cmdFirst.UseVisualStyleBackColor = True
        '
        'cmdPrev
        '
        Me.cmdPrev.Location = New System.Drawing.Point(12, 32)
        Me.cmdPrev.Name = "cmdPrev"
        Me.cmdPrev.Size = New System.Drawing.Size(65, 23)
        Me.cmdPrev.TabIndex = 13
        Me.cmdPrev.Text = "Anterior"
        Me.cmdPrev.UseVisualStyleBackColor = True
        '
        'cmdNext
        '
        Me.cmdNext.Location = New System.Drawing.Point(12, 58)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(65, 23)
        Me.cmdNext.TabIndex = 12
        Me.cmdNext.Text = "Siguiente"
        Me.cmdNext.UseVisualStyleBackColor = True
        '
        'cmdLast
        '
        Me.cmdLast.Location = New System.Drawing.Point(12, 84)
        Me.cmdLast.Name = "cmdLast"
        Me.cmdLast.Size = New System.Drawing.Size(65, 23)
        Me.cmdLast.TabIndex = 11
        Me.cmdLast.Text = "Último"
        Me.cmdLast.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(12, 242)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(65, 23)
        Me.cmdExit.TabIndex = 10
        Me.cmdExit.Text = "Salir"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(204, 61)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(136, 20)
        Me.txtId.TabIndex = 3
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(204, 87)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(410, 20)
        Me.txtDescripcion.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(147, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Código"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(124, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Descripción"
        '
        'frmTipoProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(683, 332)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmTipoProducto"
        Me.Text = "Tipos de Producto"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblNombre As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents cmdFind As Button
    Friend WithEvents cmdNew As Button
    Friend WithEvents cmdEdit As Button
    Friend WithEvents cmdSave As Button
    Friend WithEvents cmdFirst As Button
    Friend WithEvents cmdPrev As Button
    Friend WithEvents cmdNext As Button
    Friend WithEvents cmdLast As Button
    Friend WithEvents cmdExit As Button
    Friend WithEvents cmdUndo As Button
    Friend WithEvents txtId As TextBox
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
