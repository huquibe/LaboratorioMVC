Public Class frmTipoProducto
    Dim Ctrler As Ctrl.Controlador.clsCtrlTipoProducto
    Dim dat As Ctrl.Controlador.clsCtrlTipoProducto.Datos
    Private Sub frmTipoProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMain
        Me.lblNombre.Text = Me.Text
        Activar(0)
        Ctrler = New Ctrl.Controlador.clsCtrlTipoProducto()
        Llenar()
    End Sub

    Private Sub Activar(opcion As Integer)
        Select Case opcion
            Case 0 ' inicialización de formulario
                cmdFirst.Enabled = False
                cmdPrev.Enabled = False
                cmdNext.Enabled = False
                cmdLast.Enabled = False
                cmdNew.Enabled = True
                cmdFind.Enabled = False
                cmdSave.Enabled = False
                cmdEdit.Enabled = False
                cmdExit.Enabled = True
        End Select
    End Sub

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub



    Private Sub Llenar()
        dat = Ctrler.traer
        If dat.Contenido.id = 0 Then
            txtId.Text = ""
            txtDescripcion.Text = ""
        Else
            txtId.Text = dat.Contenido.Id.ToString
            txtDescripcion.Text = dat.Contenido.Nombre
        End If
    End Sub
End Class