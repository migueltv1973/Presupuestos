Option Strict On

Imports Microsoft.VisualBasic
Imports System
Imports System.Text
Imports System.Security.Cryptography
Imports System.IO

Public Class cifradoRSA
    Private Shared dirPruebas As String = "d:\"
    Private Shared ficPruebas As String = Path.Combine(dirPruebas, "MisClaves.xml")

    Public Shared Sub Main()
        ' Cifrar y descifrar con RSA
        Console.Title = "Cifrar y descifrar con RSA"

        ' Si no existe el fichero de claves,
        ' crearlo y guardarlo en el fichero indicado
        If File.Exists(ficPruebas) = False Then
            crearXMLclaves(ficPruebas)
        End If

        ' Leer las claves del fichero
        Dim xmlKeys As String = clavesXML(ficPruebas)

        ' Cifrar la cadena indicada
        Dim datos As Byte() = cifrar("Hola RSA", xmlKeys)

        ' Descifrar el array de bytes con la cadena cifrada
        Dim res As String = descifrar(datos, xmlKeys)

        ' Mostrar el texto descifrado
        Console.WriteLine(res)

        Console.ReadLine()
    End Sub

    ''' <summary>
    ''' Guarda las claves en el fichero indicado
    ''' </summary>
    Private Shared Sub crearXMLclaves(ByVal ficPruebas As String)
        Dim rsa As New RSACryptoServiceProvider()

        Dim xmlKey As String = rsa.ToXmlString(True)

        ' Si no existe el directorio, crearlo
        Dim dirPruebas As String = Path.GetDirectoryName(ficPruebas)

        If Directory.Exists(dirPruebas) = False Then
            Directory.CreateDirectory(dirPruebas)
        End If

        Using sw As New StreamWriter(ficPruebas, False, Encoding.UTF8)
            sw.WriteLine(xmlKey)
            sw.Close()
        End Using

    End Sub

    ''' <summary>
    ''' Lee las claves del fichero y las devuelve como una cadena
    ''' que se puede usar con FromXmlString de RSACryptoServiceProvider
    ''' </summary>
    Private Shared Function clavesXML(ByVal fichero As String) As String
        Dim s As String

        Using sr As New StreamReader(fichero, Encoding.UTF8)
            s = sr.ReadToEnd
            sr.Close()
        End Using

        Return s
    End Function

    ''' <summary>
    ''' Cifra el texto indicado usando las claves en formato XML
    ''' </summary>
    Private Shared Function cifrar(ByVal texto As String, ByVal xmlKeys As String) As Byte()
        Dim rsa As New RSACryptoServiceProvider()

        rsa.FromXmlString(xmlKeys)

        Dim datosEnc As Byte() = rsa.Encrypt(Encoding.Default.GetBytes(texto), False)

        Return datosEnc
    End Function

    ''' <summary>
    ''' Descifra el array de bytes usando las claves en formato XML
    ''' </summary>
    Private Shared Function descifrar(ByVal datosEnc As Byte(), ByVal xmlKeys As String) As String
        Dim rsa As New RSACryptoServiceProvider()

        rsa.FromXmlString(xmlKeys)

        Dim datos As Byte() = rsa.Decrypt(datosEnc, False)

        Dim res As String = Encoding.Default.GetString(datos)

        Return res
    End Function

End Class
