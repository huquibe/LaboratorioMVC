Namespace Modelo
    Public Class Tipos
        Public Structure tpMunicipio
            Public Id As Integer
            Public Nombre As String
        End Structure
        Public Structure tpAlmacen
            Public Id As Integer '3 espacios
            Public Nombre As String  '30 espacios
            Public Municipio As Integer  '3 espacios
            Public Direccion As String  '100 espacios
            Public Horario As String  '100 espacios
        End Structure
        Public Structure tpCajero
            Public Id As Integer        '10 espacios
            Public Nombres As String    '30 espacios
            Public Apellidos As String  '30 espacios
            Public Email As String      '50 espacios
            Public Celular As Integer   '10 espacios
            Public Genero As String     '1 espacios
            Public FechaIng As Date     '10 espacios
            Public Password As String   '20 espacios
            Public Estado As Byte       '1 espacio
        End Structure
        Public Structure tpCliente
            Public Id As Integer        '10 espacios
            Public Nombres As String    '30 espacios
            Public Apellidos As String  '30 espacios
            Public Email As String      '50 espacios
            Public Celular As Integer   '10 espacios
            Public FechaNmto As Date    '10 espacios
            Public Direccion As String  '100 espacios
        End Structure
        Public Structure tpMedioPago
            Public Id As Integer
            Public Nombre As String
        End Structure
        Public Structure tpTipoProducto
            Public Id As Integer
            Public Nombre As String
        End Structure
        Public Structure tpColeccion
            Public Id As Integer '3 espacios
            Public Nombre As String  '30 espacios
            Public Trimestre As Integer  '5 espacios
        End Structure
        Public Structure tpProducto
            Public Id As Integer                '10 espacios
            Public Nombre As String             '30 espacios
            Public TipoProducto As Integer      '3 espacios
            Public coleccion As Integer         '3 espacios
            Public Imagen As String             '50 espacios
            Public Precio As Integer            '8 espacios
        End Structure
        Public Structure tpInventario
            Public Almacen As Integer   '3 espacios
            Public Producto As Integer  '3 espacios
            Public Cantidad As Integer  '6 espacios
        End Structure
        Public Structure tpVentaEnc
            Public Id As Integer            '10 espacios
            Public Almacen As Integer       '3 espacios
            Public IdCliente As Integer     '10 espacios
            Public IdCajero As Integer      '10 espacios
            Public FechaHora As DateTime    '16 espacios
            Public MedioPago As Integer     '3 espacios
            Public VrBruto As Integer       '10 espacios
            Public VrDescuento As Integer   '10 espacios
            Public VrNeto As Integer        '10 espacios
        End Structure
        Public Structure tpVentaDet
            Public IdVenta As Integer       '10 espacios
            Public IdProducto As Integer    '10 espacios
            Public Precio As Integer        '8 espacios
            Public Cantidad As Integer      '6 espacios
        End Structure
    End Class
End Namespace