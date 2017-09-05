
Namespace Controlador

    Public Class ctrlConfiguracion
        Private RutaDatos As String
        Public Sub New()
            RutaDatos = My.Application.Info.DirectoryPath & "\datos\"
            Debug.Print(RutaDatos)
        End Sub
    End Class
    Public Class ctrlMunicipio
        Private lclDatos As Model.Modelo.Municipio.Datos
    End Class
End Namespace