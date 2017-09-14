Namespace Modelo
    Public Class Archivo
        Protected lclRuta As String
        Protected lclTamReg As Integer
        Protected lclNombre As String
        Protected lclFullNombre As String
        Protected lclStatus As Integer
        Protected lclNomStatus As String
        Protected lclposActual As Integer
        Protected lclposFinal As Integer

        Public Property Ruta() As String
            Get
                Return lclRuta
            End Get
            Set(ByVal value As String)
                lclRuta = value
            End Set
        End Property

        Public ReadOnly Property posActual() As String
            Get
                Return lclposActual
            End Get
        End Property
        Public ReadOnly Property posFinal() As String
            Get
                Return Me.SizeReg
            End Get
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
                Return lclRuta & lclNombre
            End Get
        End Property

        ''' <summary>
        ''' Este método inicializa la clase sin argumentos
        ''' </summary>
        ''' <remarks>Inicializa la clase</remarks>
        Public Sub New(Path As String, NombreArchivo As String, size As Integer)
            Dim NroArch As Integer
            NroArch = FreeFile()
            lclRuta = Path
            lclNombre = NombreArchivo
            lclTamReg = size
            lclStatus = 0
            lclNomStatus = "OK"
            lclposActual = 0
            lclposFinal = Me.SizeReg

            FileOpen(NroArch, Me.NombreCompleto, OpenMode.Random,,, lclTamReg)
            FileClose(NroArch)
        End Sub

        Public Sub New()

        End Sub

        Public Function Siguiente() As Integer
            If lclposActual >= lclposFinal Then
                Return lclposActual
            Else
                lclposActual = lclposActual + 1
                Return posActual
            End If
        End Function

        Public Function Anterior() As Integer
            If lclposActual <= 1 Then
                Return lclposActual
            Else
                lclposActual = lclposActual - 1
                Return posActual
            End If
        End Function
        Public Function Primero() As Integer
            If Me.SizeReg > 0 Then
                lclposActual = 1
                Return lclposActual
            Else
                lclposActual = 0
                Return lclposActual
            End If

        End Function
        Public Function ultimo() As Integer
            lclposActual = Me.SizeReg
            Return lclposActual
        End Function

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
            Dim NroArch As Integer
            NroArch = FreeFile()
            FileOpen(NroArch, Me.NombreCompleto, OpenMode.Append,,, lclTamReg)
            FilePut(NroArch, estructura)
            FileClose(NroArch)
            lclposFinal = Me.SizeReg
        End Sub

        Public Sub Escribir(estructura As Object, posicion As Integer)
            Dim NroArch As Integer
            NroArch = FreeFile()
            FileOpen(NroArch, Me.NombreCompleto, OpenMode.Random,,, lclTamReg)
            FilePut(NroArch, estructura, posicion)
            FileClose(NroArch)
        End Sub

        ''' <summary>
        ''' Esta función devuelve la posición en que se encuentra el id pasado como argumento, devuelve un entero con la posición del registro, o 0 si no se encuentra
        ''' </summary>
        ''' <param name="id">Identificador a Buscar</param>
        ''' <remarks>Busca un identificador en el archivo</remarks>
        Public Overridable Function Buscar(id As Object) As Integer
            ' se deja sin codificar porque se sobreescribirá por las clases que hereden de esta
            Return 0
        End Function


        ''' <summary>
        ''' Este método elimina el id pasado como argumento
        ''' </summary>
        ''' <param name="id">Identificador a Buscar</param>
        ''' <remarks>Busca un identificador en el archivo</remarks>
        Public Function Eliminar(id As Object) As Boolean
            Dim lclPosicion As Integer
            Dim lclCadTemp As datos
            Dim i As Integer

            Dim NroArch As Integer
            Dim nroarchnuevo As Integer
            lclPosicion = Me.Buscar(id)
            If lclPosicion <> 0 Then
                NroArch = FreeFile()
                FileOpen(NroArch, Me.NombreCompleto, OpenMode.Random,,, lclTamReg)
                nroarchnuevo = FreeFile()
                FileOpen(nroarchnuevo, Me.lclRuta & "Temporal.txt", OpenMode.Random,,, lclTamReg)
                For i = 1 To lclPosicion - 1
                    FileGet(NroArch, lclCadTemp, i)
                    FilePut(nroarchnuevo, lclCadTemp, i)
                Next i
                For i = lclPosicion To Me.SizeReg - 1
                    FileGet(NroArch, lclCadTemp, i + 1)
                    FilePut(nroarchnuevo, lclCadTemp, i)
                Next i
                FileClose(NroArch)
                FileClose(nroarchnuevo)
                Return True
            Else
                Return False
            End If
        End Function

        ''' <summary>
        ''' Este método obtiene el tamaño en bytes del archivo
        ''' </summary>
        ''' <remarks>obtiene el tamaño en bytes del archivo</remarks>
        Public Function SizeBytes() As Integer
            Dim infoReader As System.IO.FileInfo
            infoReader = My.Computer.FileSystem.GetFileInfo(Me.NombreCompleto)
            Return infoReader.Length
        End Function

        ''' <summary>
        ''' Este método obtiene el tamaño en registros del archivo
        ''' </summary>
        ''' <remarks>obtiene el tamaño en registros del archivo</remarks>
        Public Function SizeReg() As Integer
            Return Int(Me.SizeBytes() / lclTamReg)
        End Function



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
            lclposActual = 0
            lclposFinal = Me.SizeReg
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

        ''' <summary>
        ''' Esta función devuelve la posición en que se encuentra el id pasado como argumento, devuelve un entero con la posición del registro, o 0 si no se encuentra
        ''' </summary>
        ''' <param name="id">Identificador a Buscar</param>
        ''' <remarks>Busca un identificador en el archivo</remarks>
        Public Shadows Function Buscar(id As Object) As Integer
            Dim cadDatos As String
            Dim NroArch As Integer
            Dim rta As Integer
            Dim i As Integer
            Dim rtadatos As Datos
            i = 0
            rta = 0
            NroArch = FreeFile()
            cadDatos = ""
            FileOpen(NroArch, Me.NombreCompleto, OpenMode.Random,,, lclTamReg)
            For i = 1 To Me.SizeReg
                FileGet(NroArch, cadDatos, i)
                rtadatos = Me.decodificar(cadDatos)
                If rtadatos.Id = Val(id) Then
                    rta = i
                End If

            Next
            FileClose(NroArch)
            Return rta

        End Function

    End Class

    Public Class Almacen
        Inherits Archivo

        Public Sub New(Path As String, NombreArchivo As String)
            lclRuta = Path
            lclNombre = NombreArchivo
            lclTamReg = 236
            lclStatus = 0
            lclNomStatus = "OK"
            lclposActual = 0
            lclposFinal = Me.lclTamReg
        End Sub

        Public Shadows Structure Datos
            Public Id As Integer '3 espacios
            Public Nombre As String  '30 espacios
            Public Municipio As Integer  '3 espacios
            Public Direccion As String  '100 espacios
            Public Horario As String  '100 espacios
        End Structure

        Public Shadows Function Codificar(estructura As Datos) As String
            Dim lclCadena As String
            Dim lclcadtemp As String
            lclCadena = estructura.Id.ToString.PadLeft(3, "0")
            ' agregamos Nombre
            lclcadtemp = Left(estructura.Nombre, 30)
            lclcadtemp = lclcadtemp.PadRight(30, " ")
            lclCadena = lclCadena & lclcadtemp
            ' agregamos Municipio
            lclcadtemp = estructura.Municipio.ToString.PadLeft(3, "0")
            lclCadena = lclCadena & lclcadtemp
            ' agregamos direccion
            lclcadtemp = Left(estructura.Direccion, 100)
            lclcadtemp = lclcadtemp.PadRight(100, " ")
            lclCadena = lclCadena & lclcadtemp
            ' agregamos Horario
            lclcadtemp = Left(estructura.Horario, 100)
            lclcadtemp = lclcadtemp.PadRight(100, " ")
            lclCadena = lclCadena & lclcadtemp
            Return lclCadena
        End Function

        Public Shadows Function decodificar(cadena As String) As Datos
            Dim estru As Datos
            estru.Id = Val(Mid(cadena, 0, 3))
            estru.Nombre = Trim(Mid(cadena, 3, 30))
            estru.Municipio = Val(Mid(cadena, 33, 3))
            estru.Direccion = Trim(Mid(cadena, 36, 100))
            estru.Horario = Trim(Mid(cadena, 136, 100))
            Return estru
        End Function

        ''' <summary>
        ''' Esta función devuelve la posición en que se encuentra el id pasado como argumento, devuelve un entero con la posición del registro, o 0 si no se encuentra
        ''' </summary>
        ''' <param name="id">Identificador a Buscar</param>
        ''' <remarks>Busca un identificador en el archivo</remarks>
        Public Shadows Function Buscar(id As Integer) As Integer
            Dim cadDatos As String
            Dim NroArch As Integer
            Dim rta As Integer
            Dim i As Integer
            Dim rtadatos As Datos
            i = 0
            rta = 0
            NroArch = FreeFile()
            cadDatos = ""
            FileOpen(NroArch, Me.NombreCompleto, OpenMode.Random,,, lclTamReg)
            For i = 1 To Me.SizeReg
                FileGet(NroArch, cadDatos, i)
                rtadatos = Me.decodificar(cadDatos)
                If rtadatos.Id = Val(id) Then
                    rta = i
                End If
            Next
            FileClose(NroArch)
            Return rta
        End Function

    End Class

    Public Class Cajero
        Inherits Archivo

        Public Sub New(Path As String, NombreArchivo As String)
            lclRuta = Path
            lclNombre = NombreArchivo
            lclTamReg = 162
            lclStatus = 0
            lclNomStatus = "OK"
            lclposActual = 0
            lclposFinal = Me.lclTamReg
        End Sub

        Public Shadows Structure Datos
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

        Public Shadows Function Codificar(estructura As Datos) As String
            Dim lclCadena As String
            Dim lclcadtemp As String
            lclCadena = estructura.Id.ToString.PadLeft(10, "0")
            ' agregamos Nombres
            lclcadtemp = Left(estructura.Nombres, 30)
            lclcadtemp = lclcadtemp.PadRight(30, " ")
            lclCadena = lclCadena & lclcadtemp
            ' agregamos Apellidos
            lclcadtemp = Left(estructura.Apellidos, 30)
            lclcadtemp = lclcadtemp.PadRight(30, " ")
            lclCadena = lclCadena & lclcadtemp
            ' agregamos Email
            lclcadtemp = Left(estructura.Email, 50)
            lclcadtemp = lclcadtemp.PadRight(50, " ")
            lclCadena = lclCadena & lclcadtemp
            ' agregamos Celular
            lclcadtemp = estructura.Celular.ToString.PadLeft(10, "0")
            lclCadena = lclCadena & lclcadtemp
            ' agregamos Genero
            lclcadtemp = Left(estructura.Genero, 1)
            lclCadena = lclCadena & lclcadtemp
            ' agregamos Fecha Ingreso
            lclcadtemp = Year(estructura.FechaIng) & "/" & Format(Month(estructura.FechaIng), "00") & "/" & Format(Month(estructura.FechaIng), "00")
            lclCadena = lclCadena & lclcadtemp
            ' agregamos Contraseña
            lclcadtemp = Left(estructura.Password, 20)
            lclcadtemp = lclcadtemp.PadRight(20, " ")
            lclCadena = lclCadena & lclcadtemp
            ' agregamos Estado
            lclcadtemp = Left(estructura.Estado.ToString, 1)
            lclCadena = lclCadena & lclcadtemp
            Return lclCadena
        End Function

        Public Shadows Function decodificar(cadena As String) As Datos
            Dim estru As Datos
            estru.Id = Val(Mid(cadena, 0, 10))
            estru.Nombres = Trim(Mid(cadena, 10, 30))
            estru.Apellidos = Trim(Mid(cadena, 40, 30))
            estru.Email = Trim(Mid(cadena, 70, 50))
            estru.Celular = Val(Trim(Mid(cadena, 120, 10)))
            estru.Genero = Trim(Mid(cadena, 130, 1))
            estru.FechaIng = DateSerial(Trim(Mid(cadena, 131, 4)), Trim(Mid(cadena, 136, 2)), Trim(Mid(cadena, 139, 2)))
            estru.Password = Trim(Mid(cadena, 141, 20))
            estru.Estado = Trim(Mid(cadena, 161, 1))
            Return estru
        End Function

        ''' <summary>
        ''' Esta función devuelve la posición en que se encuentra el id pasado como argumento, devuelve un entero con la posición del registro, o 0 si no se encuentra
        ''' </summary>
        ''' <param name="id">Identificador a Buscar</param>
        ''' <remarks>Busca un identificador en el archivo</remarks>
        Public Shadows Function Buscar(id As Integer) As Integer
            Dim cadDatos As String
            Dim NroArch As Integer
            Dim rta As Integer
            Dim i As Integer
            Dim rtadatos As Datos
            i = 0
            rta = 0
            NroArch = FreeFile()
            cadDatos = ""
            FileOpen(NroArch, Me.NombreCompleto, OpenMode.Random,,, lclTamReg)
            For i = 1 To Me.SizeReg
                FileGet(NroArch, cadDatos, i)
                rtadatos = Me.decodificar(cadDatos)
                If rtadatos.Id = Val(id) Then
                    rta = i
                End If
            Next
            FileClose(NroArch)
            Return rta
        End Function

    End Class
    Public Class Cliente
        Inherits Archivo

        Public Sub New(Path As String, NombreArchivo As String)
            Dim datTemp As Datos
            lclTamReg = Len(datTemp)
            lclRuta = Path
            lclNombre = NombreArchivo
            lclStatus = 0
            lclNomStatus = "OK"
            lclposActual = 0
            lclposFinal = Me.SizeReg
        End Sub

        Public Shadows Structure Datos
            ' 230 bytes
            Public Id As Integer        '4 espacios
            <VBFixedString(30)> Public Nombres As String    '30 espacios
            <VBFixedString(30)> Public Apellidos As String  '30 espacios
            <VBFixedString(50)> Public Email As String      '50 espacios
            Public Celular As Double   '8 espacios
            Public FechaNmto As Date    '8 espacios
            <VBFixedString(100)> Public Direccion As String  '100 espacios
        End Structure



        ''' <summary>
        ''' Esta función devuelve la posición en que se encuentra el id pasado como argumento, devuelve un entero con la posición del registro, o 0 si no se encuentra
        ''' </summary>
        ''' <param name="id">Identificador a Buscar</param>
        ''' <remarks>Busca un identificador en el archivo</remarks>
        Public Shadows Function Buscar(id As Integer) As Integer
            Dim cadDatos As Datos
            Dim NroArch As Integer
            Dim rta As Integer
            Dim i As Integer

            i = 0
            rta = 0
            NroArch = FreeFile()

            FileOpen(NroArch, Me.NombreCompleto, OpenMode.Random,,, lclTamReg)
            For i = 1 To Me.SizeReg
                FileGet(NroArch, cadDatos, i)

                If cadDatos.Id = Val(id) Then
                    rta = i
                End If
            Next
            FileClose(NroArch)
            Return rta
        End Function
        Public Shadows Function Leer(Indice As Integer) As Datos
            Dim cadDatos As Datos
            Dim NroArch As Integer
            NroArch = FreeFile()
            FileOpen(NroArch, Me.NombreCompleto, OpenMode.Random,,, lclTamReg)
            FileGet(NroArch, cadDatos, Indice)
            FileClose(NroArch)
            Return cadDatos
        End Function


        ''' <summary>
        ''' Este método Escribe el contenido de estructura en el archivo, anexandolo al final
        ''' </summary>
        ''' <param name="estructura">Datos a escribir</param>
        ''' <remarks>agrega el contenido de estructura al archivo</remarks>
        Public Shadows Sub Escribir(estructura As Datos)
            Dim NroArch As Integer
            Dim posicion = Me.Buscar(estructura.Id)
            If posicion = 0 Then
                NroArch = FreeFile()
                FileOpen(NroArch, Me.NombreCompleto, OpenMode.Random,,, Len(estructura))
                FilePut(NroArch, estructura, lclposFinal + 1)
                FileClose(NroArch)
                lclposFinal = Me.SizeReg
                lclposActual = lclposFinal
            Else
                Me.Escribir(estructura, posicion)
            End If

        End Sub

        Public Shadows Sub Escribir(estructura As Datos, posicion As Integer)

            Dim NroArch As Integer
            NroArch = FreeFile()

            FileOpen(NroArch, Me.NombreCompleto, OpenMode.Random,,, Len(estructura))
            FilePut(NroArch, estructura, posicion)
            FileClose(NroArch)
            lclposActual = posicion

        End Sub
    End Class
    Public Class MedioPago
        Inherits Archivo

        Public Sub New(Path As String, NombreArchivo As String)
            lclRuta = Path
            lclNombre = NombreArchivo
            lclTamReg = 33
            lclStatus = 0
            lclNomStatus = "OK"
            lclposActual = 0
            lclposFinal = Me.lclTamReg
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

        ''' <summary>
        ''' Esta función devuelve la posición en que se encuentra el id pasado como argumento, devuelve un entero con la posición del registro, o 0 si no se encuentra
        ''' </summary>
        ''' <param name="id">Identificador a Buscar</param>
        ''' <remarks>Busca un identificador en el archivo</remarks>
        Public Shadows Function Buscar(id As Object) As Integer
            Dim cadDatos As String
            Dim NroArch As Integer
            Dim rta As Integer
            Dim i As Integer
            Dim rtadatos As Datos
            i = 0
            rta = 0
            NroArch = FreeFile()
            cadDatos = ""
            FileOpen(NroArch, Me.NombreCompleto, OpenMode.Random,,, lclTamReg)
            For i = 1 To Me.SizeReg
                FileGet(NroArch, cadDatos, i)
                rtadatos = Me.decodificar(cadDatos)
                If rtadatos.Id = Val(id) Then
                    rta = i
                End If

            Next
            FileClose(NroArch)
            Return rta

        End Function

    End Class
    Public Class TipoProducto
        Inherits Archivo
        Public Sub New(Path As String, NombreArchivo As String)
            Dim datTemp As Datos
            lclTamReg = Len(datTemp)
            lclRuta = Path
            lclNombre = NombreArchivo
            lclStatus = 0
            lclNomStatus = "OK"
            lclposActual = 0
            lclposFinal = Me.SizeReg
        End Sub

        Public Shadows Structure Datos
            ' Tamaño 34 bytes
            Public Id As Integer
            <VBFixedString(30)> Public Nombre As String
        End Structure



        ''' <summary>
        ''' Esta función devuelve la posición en que se encuentra el id pasado como argumento, devuelve un entero con la posición del registro, o 0 si no se encuentra
        ''' </summary>
        ''' <param name="id">Identificador a Buscar</param>
        ''' <remarks>Busca un identificador en el archivo</remarks>
        Public Overrides Function Buscar(id As Object) As Integer
            Dim cadDatos As Datos
            Dim NroArch As Integer
            Dim rta As Integer
            Dim i As Integer
            i = 0
            rta = 0
            NroArch = FreeFile()
            FileOpen(NroArch, Me.NombreCompleto, OpenMode.Random,,, Len(cadDatos))
            For i = 1 To Me.SizeReg
                FileGet(NroArch, cadDatos, i)

                If cadDatos.Id = Val(id) Then
                    rta = i
                End If

            Next
            FileClose(NroArch)
            Return rta

        End Function

        Public Shadows Function Leer(Indice As Integer) As Datos
            Dim cadDatos As Datos
            Dim NroArch As Integer
            NroArch = FreeFile()
            FileOpen(NroArch, Me.NombreCompleto, OpenMode.Random,,, lclTamReg)
            FileGet(NroArch, cadDatos, Indice)
            FileClose(NroArch)
            Return cadDatos
        End Function


        ''' <summary>
        ''' Este método Escribe el contenido de estructura en el archivo, anexandolo al final
        ''' </summary>
        ''' <param name="estructura">Datos a escribir</param>
        ''' <remarks>agrega el contenido de estructura al archivo</remarks>
        Public Shadows Sub Escribir(estructura As Datos)
            Dim NroArch As Integer
            Dim posicion = Me.Buscar(estructura.Id)
            If posicion = 0 Then
                NroArch = FreeFile()
                FileOpen(NroArch, Me.NombreCompleto, OpenMode.Random,,, Len(estructura))
                FilePut(NroArch, estructura, lclposFinal + 1)
                FileClose(NroArch)
                lclposFinal = Me.SizeReg
                lclposActual = lclposFinal
            Else
                Me.Escribir(estructura, posicion)
            End If

        End Sub

        Public Shadows Sub Escribir(estructura As Datos, posicion As Integer)

            Dim NroArch As Integer
            NroArch = FreeFile()

            FileOpen(NroArch, Me.NombreCompleto, OpenMode.Random,,, Len(estructura))
            FilePut(NroArch, estructura, posicion)
            FileClose(NroArch)
            lclposActual = posicion

        End Sub

    End Class
    Public Class Coleccion
        Inherits Archivo

        Public Sub New(Path As String, NombreArchivo As String)
            lclRuta = Path
            lclNombre = NombreArchivo
            lclTamReg = 38
            lclStatus = 0
            lclNomStatus = "OK"
            lclposActual = 0
            lclposFinal = Me.lclTamReg
        End Sub

        Public Shadows Structure Datos
            Public Id As Integer '3 espacios
            Public Nombre As String  '30 espacios
            Public Trimestre As Integer  '5 espacios
        End Structure

        Public Shadows Function Codificar(estructura As Datos) As String
            Dim lclCadena As String
            Dim lclcadtemp As String
            lclCadena = estructura.Id.ToString.PadLeft(3, "0")
            ' agregamos Nombre
            lclcadtemp = Left(estructura.Nombre, 30)
            lclcadtemp = lclcadtemp.PadRight(30, " ")
            lclCadena = lclCadena & lclcadtemp
            ' agregamos Poducto
            lclcadtemp = estructura.Trimestre.ToString.PadLeft(5, "0")
            lclCadena = lclCadena & lclcadtemp

            Return lclCadena
        End Function

        Public Shadows Function decodificar(cadena As String) As Datos
            Dim estru As Datos
            estru.Id = Val(Mid(cadena, 0, 3))
            estru.Nombre = Trim(Mid(cadena, 3, 30))
            estru.Trimestre = Val(Mid(cadena, 33, 5))
            Return estru
        End Function

        ''' <summary>
        ''' Esta función devuelve la posición en que se encuentra el id pasado como argumento, devuelve un entero con la posición del registro, o 0 si no se encuentra
        ''' </summary>
        ''' <param name="id">Identificador a Buscar</param>
        ''' <remarks>Busca un identificador en el archivo</remarks>
        Public Overrides Function Buscar(id As Object) As Integer
            Dim cadDatos As String
            Dim NroArch As Integer
            Dim rta As Integer
            Dim i As Integer
            Dim rtadatos As Datos
            i = 0
            rta = 0
            NroArch = FreeFile()
            cadDatos = ""
            FileOpen(NroArch, Me.NombreCompleto, OpenMode.Random,,, lclTamReg)
            For i = 1 To Me.SizeReg
                FileGet(NroArch, cadDatos, i)
                rtadatos = Me.decodificar(cadDatos)
                If rtadatos.Id = Val(id) Then
                    rta = i
                End If
            Next
            FileClose(NroArch)
            Return rta
        End Function

    End Class
    Public Class Producto
        Inherits Archivo

        Public Sub New(Path As String, NombreArchivo As String)
            lclRuta = Path
            lclNombre = NombreArchivo
            lclTamReg = 104
            lclStatus = 0
            lclNomStatus = "OK"
            lclposActual = 0
            lclposFinal = Me.lclTamReg
        End Sub

        Public Shadows Structure Datos
            Public Id As Integer                '10 espacios
            Public Nombre As String             '30 espacios
            Public TipoProducto As Integer      '3 espacios
            Public coleccion As Integer         '3 espacios
            Public Imagen As String             '50 espacios
            Public Precio As Integer            '8 espacios
        End Structure

        Public Shadows Function Codificar(estructura As Datos) As String
            Dim lclCadena As String
            Dim lclcadtemp As String
            lclCadena = estructura.Id.ToString.PadLeft(10, "0")
            ' agregamos Nombres
            lclcadtemp = Left(estructura.Nombre, 30)
            lclcadtemp = lclcadtemp.PadRight(30, " ")
            lclCadena = lclCadena & lclcadtemp
            ' agregamos Tipo de Producto
            lclcadtemp = estructura.TipoProducto.ToString.PadLeft(3, "0")
            lclCadena = lclCadena & lclcadtemp
            ' agregamos Coleccion
            lclcadtemp = estructura.coleccion.ToString.PadLeft(3, "0")
            lclCadena = lclCadena & lclcadtemp
            ' agregamos Imagen
            lclcadtemp = Left(estructura.Imagen, 50)
            lclcadtemp = lclcadtemp.PadRight(50, " ")
            lclCadena = lclCadena & lclcadtemp
            ' agregamos Precio
            lclcadtemp = estructura.Precio.ToString.PadLeft(8, "0")
            lclCadena = lclCadena & lclcadtemp
            Return lclCadena
        End Function

        Public Shadows Function decodificar(cadena As String) As Datos
            Dim estru As Datos
            estru.Id = Val(Mid(cadena, 0, 10))
            estru.Nombre = Trim(Mid(cadena, 10, 30))
            estru.TipoProducto = Val(Trim(Mid(cadena, 40, 3)))
            estru.coleccion = Val(Trim(Mid(cadena, 43, 3)))
            estru.Imagen = Trim(Mid(cadena, 46, 50))
            estru.Precio = Val(Trim(Mid(cadena, 96, 8)))
            Return estru
        End Function

        ''' <summary>
        ''' Esta función devuelve la posición en que se encuentra el id pasado como argumento, devuelve un entero con la posición del registro, o 0 si no se encuentra
        ''' </summary>
        ''' <param name="id">Identificador a Buscar</param>
        ''' <remarks>Busca un identificador en el archivo</remarks>
        Public Shadows Function Buscar(id As Integer) As Integer
            Dim cadDatos As String
            Dim NroArch As Integer
            Dim rta As Integer
            Dim i As Integer
            Dim rtadatos As Datos
            i = 0
            rta = 0
            NroArch = FreeFile()
            cadDatos = ""
            FileOpen(NroArch, Me.NombreCompleto, OpenMode.Random,,, lclTamReg)
            For i = 1 To Me.SizeReg
                FileGet(NroArch, cadDatos, i)
                rtadatos = Me.decodificar(cadDatos)
                If rtadatos.Id = Val(id) Then
                    rta = i
                End If
            Next
            FileClose(NroArch)
            Return rta
        End Function

    End Class
    Public Class Inventario
        Inherits Archivo

        Public Sub New(Path As String, NombreArchivo As String)
            lclRuta = Path
            lclNombre = NombreArchivo
            lclTamReg = 12
            lclStatus = 0
            lclNomStatus = "OK"
            lclposActual = 0
            lclposFinal = Me.lclTamReg
        End Sub

        Public Shadows Structure Datos
            Public Almacen As Integer   '3 espacios
            Public Producto As Integer  '3 espacios
            Public Cantidad As Integer  '6 espacios
        End Structure

        Public Shadows Function Codificar(estructura As Datos) As String
            Dim lclCadena As String
            Dim lclcadtemp As String
            lclCadena = estructura.Almacen.ToString.PadLeft(3, "0")
            ' agregamos Producto
            lclcadtemp = estructura.Producto.ToString.PadLeft(3, "0")
            lclCadena = lclCadena & lclcadtemp
            ' agregamos cantidad
            lclcadtemp = estructura.Cantidad.ToString.PadLeft(6, "0")
            lclCadena = lclCadena & lclcadtemp
            Return lclCadena
        End Function

        Public Shadows Function decodificar(cadena As String) As Datos
            Dim estru As Datos
            estru.Almacen = Val(Mid(cadena, 0, 3))
            estru.Producto = Val(Mid(cadena, 3, 3))
            estru.Cantidad = Val(Mid(cadena, 6, 6))
            Return estru
        End Function

        ''' <summary>
        ''' Esta función devuelve la posición en que se encuentra el id pasado como argumento, devuelve un entero con la posición del registro, o 0 si no se encuentra
        ''' </summary>
        ''' <param name="idalm">almacen a Buscar</param>
        ''' ''' <param name="idProd">Producto a Buscar</param>
        ''' <remarks>Busca un identificador en el archivo</remarks>
        Public Shadows Function Buscar(idalm As Integer, idProd As Integer) As Integer
            Dim cadDatos As String
            Dim NroArch As Integer
            Dim rta As Integer
            Dim i As Integer
            Dim rtadatos As Datos
            i = 0
            rta = 0
            NroArch = FreeFile()
            cadDatos = ""
            FileOpen(NroArch, Me.NombreCompleto, OpenMode.Random,,, lclTamReg)
            For i = 1 To Me.SizeReg
                FileGet(NroArch, cadDatos, i)
                rtadatos = Me.decodificar(cadDatos)
                If rtadatos.Almacen = Val(idalm) And rtadatos.Producto = Val(idProd) Then
                    rta = i
                End If
            Next
            FileClose(NroArch)
            Return rta
        End Function

    End Class
    Public Class VentaEnc
        Inherits Archivo

        Public Sub New(Path As String, NombreArchivo As String)
            lclRuta = Path
            lclNombre = NombreArchivo
            lclTamReg = 82
            lclStatus = 0
            lclNomStatus = "OK"
            lclposActual = 0
            lclposFinal = Me.lclTamReg
        End Sub

        Public Shadows Structure Datos
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

        Public Shadows Function Codificar(estructura As Datos) As String
            Dim lclCadena As String
            Dim lclcadtemp As String
            lclCadena = estructura.Id.ToString.PadLeft(10, "0")
            ' agregamos Almacen
            lclcadtemp = estructura.Almacen.ToString.PadLeft(3, "0")
            lclCadena = lclCadena & lclcadtemp
            ' agregamos Cliente
            lclcadtemp = estructura.IdCliente.ToString.PadLeft(10, "0")
            lclCadena = lclCadena & lclcadtemp
            ' agregamos Cajero
            lclcadtemp = estructura.IdCajero.ToString.PadLeft(10, "0")
            lclCadena = lclCadena & lclcadtemp
            ' agregamos Fecha y Hora
            lclcadtemp = Year(estructura.FechaHora) & "/" & Format(Month(estructura.FechaHora), "00") & "/" & Format(Month(estructura.FechaHora), "00")
            lclcadtemp = lclcadtemp & " " & Hour(estructura.FechaHora) & ":" & Minute(estructura.FechaHora)
            lclCadena = lclCadena & lclcadtemp
            ' agregamos medio de Pago
            lclcadtemp = estructura.MedioPago.ToString.PadLeft(3, "0")
            lclCadena = lclCadena & lclcadtemp
            ' agregamos Valor Bruto
            lclcadtemp = estructura.VrBruto.ToString.PadLeft(10, "0")
            lclCadena = lclCadena & lclcadtemp
            ' agregamos Valor descuento
            lclcadtemp = estructura.VrDescuento.ToString.PadLeft(10, "0")
            lclCadena = lclCadena & lclcadtemp
            ' agregamos Valor Neto
            lclcadtemp = estructura.VrNeto.ToString.PadLeft(10, "0")
            lclCadena = lclCadena & lclcadtemp
            Return lclCadena
        End Function

        Public Shadows Function decodificar(cadena As String) As Datos
            Dim estru As Datos
            estru.Id = Val(Mid(cadena, 0, 10))
            estru.Almacen = Val(Mid(cadena, 10, 3))
            estru.IdCliente = Val(Mid(cadena, 13, 10))
            estru.IdCajero = Val(Mid(cadena, 23, 10))
            estru.FechaHora = DateSerial(Trim(Mid(cadena, 33, 4)), Trim(Mid(cadena, 38, 2)), Trim(Mid(cadena, 41, 2)))
            estru.FechaHora.AddHours(Val(Mid(cadena, 44, 2)))
            estru.FechaHora.AddMinutes(Val(Mid(cadena, 47, 2)))
            estru.MedioPago = Val(Mid(cadena, 49, 3))
            estru.VrBruto = Val(Mid(cadena, 52, 10))
            estru.VrDescuento = Val(Mid(cadena, 62, 10))
            estru.VrNeto = Val(Mid(cadena, 72, 10))
            Return estru
        End Function

        ''' <summary>
        ''' Esta función devuelve la posición en que se encuentra el id pasado como argumento, devuelve un entero con la posición del registro, o 0 si no se encuentra
        ''' </summary>
        ''' <param name="id">Id a Buscar</param>
        ''' <remarks>Busca un identificador en el archivo</remarks>
        Public Shadows Function Buscar(id As Integer) As Integer
            Dim cadDatos As String
            Dim NroArch As Integer
            Dim rta As Integer
            Dim i As Integer
            Dim rtadatos As Datos
            i = 0
            rta = 0
            NroArch = FreeFile()
            cadDatos = ""
            FileOpen(NroArch, Me.NombreCompleto, OpenMode.Random,,, lclTamReg)
            For i = 1 To Me.SizeReg
                FileGet(NroArch, cadDatos, i)
                rtadatos = Me.decodificar(cadDatos)
                If rtadatos.Id = Val(id) Then
                    rta = i
                End If
            Next
            FileClose(NroArch)
            Return rta
        End Function

    End Class
    Public Class ventaDet
        Inherits Archivo

        Public Sub New(Path As String, NombreArchivo As String)
            lclRuta = Path
            lclNombre = NombreArchivo
            lclTamReg = 34
            lclStatus = 0
            lclNomStatus = "OK"
            lclposActual = 0
            lclposFinal = Me.lclTamReg
        End Sub

        Public Shadows Structure Datos
            Public IdVenta As Integer       '10 espacios
            Public IdProducto As Integer    '10 espacios
            Public Precio As Integer        '8 espacios
            Public Cantidad As Integer      '6 espacios
        End Structure

        Public Shadows Function Codificar(estructura As Datos) As String
            Dim lclCadena As String
            Dim lclcadtemp As String
            lclCadena = estructura.IdVenta.ToString.PadLeft(10, "0")
            ' agregamos Producto
            lclcadtemp = estructura.IdProducto.ToString.PadLeft(10, "0")
            lclCadena = lclCadena & lclcadtemp
            ' agregamos Precio
            lclcadtemp = estructura.Precio.ToString.PadLeft(8, "0")
            lclCadena = lclCadena & lclcadtemp
            ' agregamos cantidad
            lclcadtemp = estructura.Cantidad.ToString.PadLeft(6, "0")
            lclCadena = lclCadena & lclcadtemp
            Return lclCadena
        End Function

        Public Shadows Function decodificar(cadena As String) As Datos
            Dim estru As Datos
            estru.IdVenta = Val(Mid(cadena, 0, 10))
            estru.IdProducto = Val(Mid(cadena, 10, 10))
            estru.Precio = Val(Mid(cadena, 20, 8))
            estru.Cantidad = Val(Mid(cadena, 28, 6))
            Return estru
        End Function

        ''' <summary>
        ''' Esta función devuelve la posición en que se encuentra el id pasado como argumento, devuelve un entero con la posición del registro, o 0 si no se encuentra
        ''' </summary>
        ''' <param name="idVenta">Venta a Buscar</param>
        ''' ''' <param name="idProd">Producto a Buscar</param>
        ''' <remarks>Busca un identificador en el archivo</remarks>
        Public Shadows Function Buscar(idVenta As Integer, idProd As Integer) As Integer
            Dim cadDatos As String
            Dim NroArch As Integer
            Dim rta As Integer
            Dim i As Integer
            Dim rtadatos As Datos
            i = 0
            rta = 0
            NroArch = FreeFile()
            cadDatos = ""
            FileOpen(NroArch, Me.NombreCompleto, OpenMode.Random,,, lclTamReg)
            For i = 1 To Me.SizeReg
                FileGet(NroArch, cadDatos, i)
                rtadatos = Me.decodificar(cadDatos)
                If rtadatos.IdVenta = Val(idVenta) And rtadatos.IdProducto = Val(idProd) Then
                    rta = i
                End If
            Next
            FileClose(NroArch)
            Return rta
        End Function

    End Class
End Namespace