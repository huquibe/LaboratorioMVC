Public Class frmMain
    Private Sub AlmacenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AlmacenToolStripMenuItem.Click

    End Sub

    Private Sub TipoDeProductoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TipoDeProductoToolStripMenuItem.Click
        frmTipoProducto.Show()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        End
    End Sub

    Private Sub ClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesToolStripMenuItem.Click
        frmClientes.Show()
    End Sub

    Private Sub CréditosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CréditosToolStripMenuItem.Click
        Creditos.Show()
    End Sub
End Class