
Namespace Controlador



    Public Class clsCtrlTipoProducto
        Private lclRuta As String
        Private lclModel As Model.Modelo.TipoProducto
        Private lclDatos As Model.Modelo.TipoProducto.Datos

        Public Sub New()
            lclRuta = My.Application.Info.DirectoryPath & "\datos\"
            lclModel = New Model.Modelo.TipoProducto(lclRuta, "TipoProducto")

        End Sub

        Public Structure Datos
            Public Contenido As Model.Modelo.TipoProducto.Datos
        End Structure

        Public Function Grabar(argDatos As Datos) As Boolean
            If Me.validar(argDatos) = True Then
                Dim lclmdlDatos As Model.Modelo.TipoProducto.Datos
                lclmdlDatos.Id = argDatos.Contenido.Id
                lclmdlDatos.Id = argDatos.Contenido.Id
                lclModel.Escribir(lclmdlDatos)
                Return True
            Else
                Return False
            End If


        End Function

        Public Function validar(argDatos As Datos) As Boolean

            Return True
        End Function

        Public Function traer() As Datos
            Dim posactual As Integer
            Dim tempdatos As Datos

            posactual = lclModel.posActual
            If posactual = 0 Then
                tempdatos.Contenido.Id = 0
                tempdatos.Contenido.Nombre = ""
            Else
                lclDatos = lclModel.Leer(posactual)
                tempdatos.Contenido.Id = lclDatos.Id
                tempdatos.Contenido.Nombre = lclDatos.Nombre
            End If
            Return tempdatos
        End Function
    End Class

End Namespace