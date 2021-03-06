﻿Public Class frmTipoProducto
    Dim Ctrler As Ctrl.Controlador.clsCtrlTipoProducto
    Dim dat As Ctrl.Controlador.clsCtrlTipoProducto.Datos
    Private Sub frmTipoProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMain
        Me.lblNombre.Text = Me.Text
        'Activar(0)
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
                cmdExit.Enabled = True
        End Select
    End Sub

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub rellenar(dt As Ctrl.Controlador.clsCtrlTipoProducto.Datos)
        If dat.Contenido.Id = 0 Then
            txtId.Text = ""
            txtDescripcion.Text = ""
        Else
            txtId.Text = dat.Contenido.Id.ToString
            txtDescripcion.Text = dat.Contenido.Nombre
        End If


    End Sub

    Private Sub Llenar()

        dat = Ctrler.traer(0)
        rellenar(dat)


    End Sub

    Private Sub cmdFirst_Click(sender As Object, e As EventArgs) Handles cmdFirst.Click
        dat = Ctrler.traer(-1)
        rellenar(dat)
    End Sub

    Private Sub cmdPrev_Click(sender As Object, e As EventArgs) Handles cmdPrev.Click
        dat = Ctrler.traer(-2)
        rellenar(dat)
    End Sub

    Private Sub cmdNext_Click(sender As Object, e As EventArgs) Handles cmdNext.Click
        dat = Ctrler.traer(-3)
        rellenar(dat)
    End Sub

    Private Sub cmdLast_Click(sender As Object, e As EventArgs) Handles cmdLast.Click
        dat = Ctrler.traer(-4)
        rellenar(dat)
    End Sub

    Private Sub cmdNew_Click(sender As Object, e As EventArgs) Handles cmdNew.Click
        txtId.Text = ""
        txtDescripcion.Text = ""
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim argum As Ctrl.Controlador.clsCtrlTipoProducto.Datos
        argum.Contenido.Id = Val(txtId.Text)
        argum.Contenido.Nombre = txtDescripcion.Text.ToString.Trim
        If Ctrler.Grabar(argum) Then
            MsgBox("Grabado con exito", vbOKOnly, "Grabación")
        Else
            MsgBox("Error Grabando", vbOKOnly, "Grabación")

        End If
    End Sub

    Private Sub cmdFind_Click(sender As Object, e As EventArgs) Handles cmdFind.Click
        If Val(txtId.Text) > 0 Then
            Dim p As Integer
            p = Ctrler.buscar(Val(txtId.Text))
            If p = 0 Then
                MsgBox("Valor no encontrado", vbOKOnly, "Búsqueda")
            Else
                dat = Ctrler.traer(p)
                rellenar(dat)
            End If
        Else
            MsgBox("Valor no válido", vbOKOnly, "Búsqueda")
        End If
    End Sub

    Private Sub cmdDelete_Click(sender As Object, e As EventArgs) Handles cmdDelete.Click
        If Val(txtId.Text) > 0 Then
            If Ctrler.borrar(Val(txtId.Text)) Then
                MsgBox("Eliminado con exito", vbOKOnly, "Eliminación")
            Else
                MsgBox("Error eliminando", vbOKOnly, "Eliminación")
            End If
        Else
            MsgBox("No hay Id para eliminar", vbOKOnly, "Eliminación")
        End If
    End Sub
End Class