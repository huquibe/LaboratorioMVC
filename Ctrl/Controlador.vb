
Namespace Controlador



    Public Class clsCtrlTipoProducto
        Private lclRuta As String
        Private lclModel As Model.Modelo.TipoProducto
        Private lclDatos As Model.Modelo.TipoProducto.Datos

        Public Sub New()
            lclRuta = My.Application.Info.DirectoryPath & "\datos\"
            lclModel = New Model.Modelo.TipoProducto(lclRuta, "TipoProducto.txt")

        End Sub

        Public Structure Datos
            Public Contenido As Model.Modelo.TipoProducto.Datos
        End Structure

        Public Function Grabar(argDatos As Datos) As Boolean
            If Me.validar(argDatos) = True Then
                Dim lclmdlDatos As Model.Modelo.TipoProducto.Datos
                lclmdlDatos.Id = argDatos.Contenido.Id
                lclmdlDatos.Nombre = argDatos.Contenido.Nombre
                lclModel.Escribir(lclmdlDatos)
                Return True
            Else
                Return False
            End If


        End Function

        Public Function validar(argDatos As Datos) As Boolean
            Dim rta As Boolean
            rta = False
            If argDatos.Contenido.Id > 0 And Len(argDatos.Contenido.Nombre.ToString) > 0 Then rta = True
            Return rta
        End Function

        Public Function traer(pos As Integer) As Datos
            Dim posactual As Integer
            Dim tempdatos As Datos
            Select Case pos
                Case 0  ' Inicial
                    posactual = lclModel.Siguiente
                Case -1 'Primero
                    posactual = lclModel.Primero
                Case -2 ' Anterior
                    posactual = lclModel.Anterior
                Case -3  'Siguiente
                    posactual = lclModel.Siguiente
                Case -4 ' ultimo
                    posactual = lclModel.ultimo
                Case Else
                    posactual = pos
            End Select


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
        Public Function buscar(id As Integer) As Integer
            Dim rta As Integer
            rta = 0
            rta = lclModel.Buscar(id)
            Return rta
        End Function
        Public Function borrar(id As Integer) As Boolean
            Return lclModel.Eliminar(id)
        End Function
    End Class

    Public Class clsCtrlClientes
        Private lclRuta As String
        Private lclModel As Model.Modelo.Cliente
        Private lclDatos As Model.Modelo.Cliente.Datos

        Public Sub New()
            lclRuta = My.Application.Info.DirectoryPath & "\datos\"
            lclModel = New Model.Modelo.Cliente(lclRuta, "Cliente.txt")

        End Sub

        Public Structure Datos
            Public Contenido As Model.Modelo.Cliente.Datos
        End Structure

        Public Function Grabar(argDatos As Datos) As Boolean
            If Me.validar(argDatos) = True Then
                Dim lclmdlDatos As Model.Modelo.Cliente.Datos
                lclmdlDatos.Id = argDatos.Contenido.Id
                lclmdlDatos.Nombres = argDatos.Contenido.Nombres
                lclmdlDatos.Apellidos = argDatos.Contenido.Apellidos
                lclmdlDatos.Email = argDatos.Contenido.Email
                lclmdlDatos.Celular = argDatos.Contenido.Celular
                lclmdlDatos.FechaNmto = argDatos.Contenido.FechaNmto
                lclmdlDatos.Direccion = argDatos.Contenido.Direccion
                lclModel.Escribir(lclmdlDatos)
                Return True
            Else
                Return False
            End If


        End Function

        Public Function validar(argDatos As Datos) As Boolean
            Dim rta As Boolean
            rta = True
            If argDatos.Contenido.Id < 1 Then rta = False
            If Len(argDatos.Contenido.Nombres.ToString) = 0 Then rta = False
            If Len(argDatos.Contenido.Apellidos.ToString) = 0 Then rta = False
            If Len(argDatos.Contenido.Email.ToString) = 0 Then rta = False
            If Len(argDatos.Contenido.Direccion.ToString) = 0 Then rta = False
            If IsDate(argDatos.Contenido.FechaNmto) = False Then rta = False
            Return rta
        End Function

        Public Function traer(pos As Integer) As Datos
            Dim posactual As Integer
            Dim tempdatos As Datos
            Select Case pos
                Case 0  ' Inicial
                    posactual = lclModel.Siguiente
                Case -1 'Primero
                    posactual = lclModel.Primero
                Case -2 ' Anterior
                    posactual = lclModel.Anterior
                Case -3  'Siguiente
                    posactual = lclModel.Siguiente
                Case -4 ' ultimo
                    posactual = lclModel.ultimo
                Case Else
                    posactual = pos
            End Select


            If posactual = 0 Then
                tempdatos.Contenido.Id = 0
                tempdatos.Contenido.Nombres = ""
            Else
                lclDatos = lclModel.Leer(posactual)
                tempdatos.Contenido.Id = lclDatos.Id
                tempdatos.Contenido.Nombres = lclDatos.Nombres
                tempdatos.Contenido = lclDatos
            End If
            Return tempdatos
        End Function
        Public Function buscar(id As Integer) As Integer
            Dim rta As Integer
            rta = 0
            rta = lclModel.Buscar(id)
            Return rta
        End Function
        Public Function borrar(id As Integer) As Boolean
            Return lclModel.Eliminar(id)
        End Function
    End Class
End Namespace