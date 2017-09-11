﻿Namespace Modelo
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
        ''' Esta función devuelve la posición en que se encuentra el id pasado como argumento, devuelve un entero con la posición del registro, o 0 si no se encuentra
        ''' </summary>
        ''' <param name="id">Identificador a Buscar</param>
        ''' <remarks>Busca un identificador en el archivo</remarks>
        Public Function Buscar(id As Object) As Integer
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
            Dim lclCadTemp As String
            Dim i As Integer

            Dim NroArch As Integer
            lclCadTemp = ""
            lclPosicion = Me.Buscar(id)
            If lclPosicion <> 0 Then
                NroArch = FreeFile()
                FileOpen(NroArch, Me.NombreCompleto, OpenMode.Random,,, lclTamReg)
                For i = lclPosicion To Me.SizeReg - 1
                    FileGet(NroArch, lclCadTemp, i + 1)
                    FilePut(NroArch, lclCadTemp, i)
                Next i
                FilePut(NroArch, "", i)
                FileClose(NroArch)
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
            lclRuta = Path
            lclNombre = NombreArchivo
            lclTamReg = 240
            lclStatus = 0
            lclNomStatus = "OK"
        End Sub

        Public Shadows Structure Datos
            Public Id As Integer        '10 espacios
            Public Nombres As String    '30 espacios
            Public Apellidos As String  '30 espacios
            Public Email As String      '50 espacios
            Public Celular As Integer   '10 espacios
            Public FechaNmto As Date    '10 espacios
            Public Direccion As String  '100 espacios
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
            ' agregamos Fecha Nacimiento
            lclcadtemp = Year(estructura.FechaNmto) & "/" & Format(Month(estructura.FechaNmto), "00") & "/" & Format(Month(estructura.FechaNmto), "00")
            lclCadena = lclCadena & lclcadtemp
            ' agregamos Dirección
            lclcadtemp = Left(estructura.Direccion, 100)
            lclCadena = lclCadena & lclcadtemp
        End Function

        Public Shadows Function decodificar(cadena As String) As Datos
            Dim estru As Datos
            estru.Id = Val(Mid(cadena, 0, 10))
            estru.Nombres = Trim(Mid(cadena, 10, 30))
            estru.Apellidos = Trim(Mid(cadena, 40, 30))
            estru.Email = Trim(Mid(cadena, 70, 50))
            estru.Celular = Val(Trim(Mid(cadena, 120, 10)))
            estru.FechaNmto = DateSerial(Trim(Mid(cadena, 130, 4)), Trim(Mid(cadena, 135, 2)), Trim(Mid(cadena, 138, 2)))
            estru.Direccion = Trim(Mid(cadena, 140, 100))
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
    Public Class MedioPago
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
    Public Class Coleccion
        Inherits Archivo

        Public Sub New(Path As String, NombreArchivo As String)
            lclRuta = Path
            lclNombre = NombreArchivo
            lclTamReg = 38
            lclStatus = 0
            lclNomStatus = "OK"
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
    Public Class Producto
        Inherits Archivo

        Public Sub New(Path As String, NombreArchivo As String)
            lclRuta = Path
            lclNombre = NombreArchivo
            lclTamReg = 104
            lclStatus = 0
            lclNomStatus = "OK"
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

End Namespace