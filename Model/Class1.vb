Namespace Modelo
    Public Class Archivo
        Protected lclRuta As String
        Protected lclTamReg As Integer
        Protected lclNombre As String
        Protected lclFullNombre As String
        Protected lclStatus As Integer
        Protected lclNomStatus As String

        Public Property Ruta() As String
            Get
                Return lclRuta
            End Get
            Set(ByVal value As String)
                lclRuta = value
            End Set
        End Property

        Public Property LongitudRegistro() As Integer
            Get
                Return lclTamReg
            End Get
            Set(ByVal value As Integer)
                lclTamReg = value
            End Set
        End Property

        Public Property Nombre() As String
            Get
                Return lclNombre
            End Get
            Set(ByVal value As String)
                lclNombre = value
            End Set
        End Property

        Public ReadOnly Property NombreCompleto() As String
            Get
                Return lclRuta & "\" & lclNombre
            End Get
        End Property

        ''' <summary>
        ''' Este método inicializa la clase sin argumentos
        ''' </summary>
        ''' <remarks>Inicializa la clase</remarks>
        Public Sub New()
            lclStatus = 1
            lclNomStatus = "Inicializado sin valores"
        End Sub

        ''' <summary>
        ''' Este método Obtiene el registro indicado por el valor Indice desde el archivo, devuelve los datos en una estructura
        ''' </summary>
        ''' <param name="Indice">Indice de egistro a leer</param>
        ''' <remarks>Devuelve una cadena con el contenido del registro indice del archivo</remarks>
        Public Function Leer(Indice As Integer) As datos
            Dim cadDatos As String
            Dim NroArch As Integer
            NroArch = FreeFile()
            cadDatos = ""
            FileOpen(NroArch, Me.NombreCompleto, OpenMode.Random,,, lclTamReg)
            FileGet(NroArch, cadDatos, Indice)
            FileClose(NroArch)
            Return Decodificar(cadDatos)
        End Function

        ''' <summary>
        ''' Este método Escribe el contenido de estructura en el archivo, anexandolo al final
        ''' </summary>
        ''' <param name="estructura">Datos a escribir</param>
        ''' <remarks>agrega el contenido de estructura al archivo</remarks>
        Public Sub Escribir(estructura As datos)
            Dim cadDatos As String
            Dim NroArch As Integer
            NroArch = FreeFile()
            cadDatos = Codificar(estructura)
            FileOpen(NroArch, Me.NombreCompleto, OpenMode.Append,,, lclTamReg)
            FilePut(NroArch, cadDatos)
            FileClose(NroArch)

        End Sub

        ''' <summary>
        ''' Este método obtiene el tamaño en bytes del archivo
        ''' </summary>
        ''' <remarks>obtiene el tamaño en bytes del archivo</remarks>
        Public Function SizeBytes() As Integer
            Dim infoReader As System.IO.FileInfo
            infoReader = My.Computer.FileSystem.GetFileInfo("C:\testfile.txt")
            Return infoReader.Length
        End Function

        ''' <summary>
        ''' Este método obtiene el tamaño en registros del archivo
        ''' </summary>
        ''' <remarks>obtiene el tamaño en registros del archivo</remarks>
        Public Function SizeReg() As Integer
            Return Int(Me.SizeBytes() / lclTamReg)
        End Function

        Public Sub Escribir(estructura As datos, posicion As Integer)
            Dim cadDatos As String
            Dim NroArch As Integer
            NroArch = FreeFile()
            cadDatos = Codificar(estructura)
            FileOpen(NroArch, Me.NombreCompleto, OpenMode.Append,,, lclTamReg)
            FilePut(NroArch, cadDatos, posicion)
            FileClose(NroArch)
        End Sub

        Public Function Codificar(estructura As datos) As String
            Return ""
        End Function

        Public Function Decodificar(cadena As String) As datos
            Dim lclData As datos
            Return lclData
        End Function

        Public Structure datos

        End Structure
    End Class

    ' Clase para Archivo Municipio, hereda de archivo
    Public Class Municipio
        Inherits Archivo

        Public Sub New(Path As String, NombreArchivo As String)
            lclRuta = Path
            lclNombre = NombreArchivo
            lclTamReg = 33
            lclStatus = 0
            lclNomStatus = "OK"
        End Sub

        Public Shadows Structure Datos
            Public Id As Integer
            Public Nombre As String
        End Structure

        Public Shadows Function Codificar(estructura As Datos) As String
            Dim lclCadena As String
            Dim lclcadtemp As String
            lclCadena = estructura.Id.ToString.PadLeft(3, "0")
            lclcadtemp = Left(estructura.Nombre, 30)
            lclcadtemp = lclcadtemp.PadRight(30, " ")
            lclCadena = lclCadena & lclcadtemp
            Return lclCadena
        End Function

        Public Shadows Function decodificar(cadena As String) As Datos
            Dim estru As Datos
            estru.Id = Val(Mid(cadena, 0, 3))
            estru.Nombre = Trim(Mid(cadena, 3, 30))
            Return estru
        End Function


    End Class
End Namespace