Imports System.Security.Cryptography
Imports System.Text
Imports System.IO

Public Class Encryption

    '***************************************************************************
    Public Enum EncryptionAlgorithmType
        DES
        RC2
        Rijndael
        TripleDES
    End Enum

    '***************************************************************************
    Public Enum CryptoDirection
        Encrypt
        Decrypt
    End Enum

    '***************************************************************************
    Public Shared Function GetAlgorithm( _
     ByVal type As EncryptionAlgorithmType) As SymmetricAlgorithm

        'Determine the type and return the approrpiate Symmetric Algorithm Class
        Select Case type
            Case EncryptionAlgorithmType.DES
                Return New DESCryptoServiceProvider
            Case EncryptionAlgorithmType.RC2
                Return New RC2CryptoServiceProvider
            Case EncryptionAlgorithmType.Rijndael
                Return New RijndaelManaged
            Case EncryptionAlgorithmType.TripleDES
                Return New TripleDESCryptoServiceProvider
            Case Else
                Throw New ArgumentException("Invalid Algorithm Type")
        End Select

    End Function

    '***************************************************************************
    Public Shared Function GenerateKey( _
      ByVal type As EncryptionAlgorithmType) As Byte()

        Dim algorithm As SymmetricAlgorithm = GetAlgorithm(type)
        algorithm.GenerateKey()
        Return algorithm.Key()

    End Function

    '***************************************************************************
    Public Shared Function GenerateIV( _
      ByVal type As EncryptionAlgorithmType) As Byte()

        Dim algorithm As SymmetricAlgorithm = GetAlgorithm(type)
        algorithm.GenerateIV()
        Return algorithm.IV()

    End Function

    '***************************************************************************
    Private Shared Function GetCrytoTransfomer( _
      ByVal type As EncryptionAlgorithmType, _
      ByVal direction As CryptoDirection, ByRef key As Byte(), _
      ByRef IV As Byte()) As ICryptoTransform

        Dim algorithm As SymmetricAlgorithm = GetAlgorithm(type)
        algorithm.Mode = CipherMode.CBC

        'Give key to algorithm, or get auto-generated key from algorithm
        If key Is Nothing Then
            key = algorithm.Key     'Get generated key
        Else
            algorithm.Key = key     'Set key
        End If

        'Give IV to algorithm, or get auto-generated IV from algorithm
        If IV Is Nothing Then
            IV = algorithm.IV       'Get generated IV
        Else
            algorithm.IV = IV       'Set IV
        End If

        'Return the appropriate ICryptoTransformer for the Direction
        Select Case direction
            Case CryptoDirection.Decrypt
                Return algorithm.CreateDecryptor()
            Case CryptoDirection.Encrypt
                Return algorithm.CreateEncryptor
            Case Else
                Throw New ArgumentException("Invalid Crypto Direction")
        End Select

    End Function

    '***************************************************************************
    Public Shared Function EncryptString(ByVal valueToEncrypt As String, _
      ByVal type As EncryptionAlgorithmType, ByRef key As Byte(), _
      ByRef IV As Byte()) As String

        Dim encoder As New ASCIIEncoding
        Dim value As Byte() = encoder.GetBytes(valueToEncrypt)
        Dim encrypted As Byte() = EncryptByteArray(value, type, key, IV)
        Return Convert.ToBase64String(encrypted)

    End Function

    '***************************************************************************
    Public Shared Function EncryptByteArray(ByVal byteArrayToEncrypt As Byte(), _
      ByVal type As EncryptionAlgorithmType, ByRef key As Byte(), _
      ByRef IV As Byte()) As Byte()

        Dim transformer As ICryptoTransform = GetCrytoTransfomer(type, _
                                               CryptoDirection.Encrypt, key, IV)
        Dim buffer As New MemoryStream
        Dim encStream As New CryptoStream(buffer, transformer, _
                                           CryptoStreamMode.Write)

        'Write data to encryption stream which stores it in the buffer
        Try
            encStream.Write(byteArrayToEncrypt, 0, byteArrayToEncrypt.Length)
            encStream.FlushFinalBlock()
        Catch ex As Exception
            Throw New IOException("Could not encrypt data", ex)
        Finally
            encStream.Close()
        End Try

        Return buffer.ToArray()

    End Function

    '***************************************************************************
    Public Shared Function DecryptString(ByVal valueToDecrypt As String, _
      ByVal type As EncryptionAlgorithmType, ByRef key As Byte(), _
      ByRef IV As Byte()) As String

        Dim encoder As New ASCIIEncoding
        Dim value = Convert.FromBase64String(valueToDecrypt)
        Dim decrypted = DecryptByteArray(value, type, key, IV)
        Return encoder.GetString(decrypted)

    End Function

    '***************************************************************************
    Public Shared Function DecryptByteArray(ByVal byteArrayToEncrypt As Byte(), _
      ByVal type As EncryptionAlgorithmType, ByRef key As Byte(), _
      ByRef IV As Byte()) As Byte()

        Dim transformer As ICryptoTransform = GetCrytoTransfomer(type, _
                                               CryptoDirection.Decrypt, key, IV)
        Dim buffer As New MemoryStream
        Dim encStream As New CryptoStream(buffer, transformer, _
                                           CryptoStreamMode.Write)

        'Write data to encryption stream which stores it in the buffer
        Try
            encStream.Write(byteArrayToEncrypt, 0, byteArrayToEncrypt.Length)
            encStream.FlushFinalBlock()
        Catch ex As Exception
            Throw New IOException("Could not decrypt data", ex)
        Finally
            encStream.Close()
        End Try

        Return buffer.ToArray()

    End Function

End Class
