Imports EncryptionLibrary
Imports System.Configuration.ConfigurationManager

Public Class Example

    '***************************************************************************
    Public Function TestEncryption() As Boolean

        'Acquire Base64 strings from web.config
        Dim keyBase64 As String = AppSettings("TripleDESKey")
        Dim IVBase64 As String = AppSettings("TripleDESIV")

        'Convert to byte arrays
        Dim key As Byte() = Convert.FromBase64String(keyBase64)
        Dim IV As Byte() = Convert.FromBase64String(IVBase64)

        Dim TextToEncrypt As String = "Please encrypt this text"

        Dim EncryptedText As String = Encryption.EncryptString(TextToEncrypt, _
                          Encryption.EncryptionAlgorithmType.TripleDES, key, IV)

        Dim DecryptedText As String = Encryption.DecryptString(EncryptedText, _
                          Encryption.EncryptionAlgorithmType.TripleDES, key, IV)

        If DecryptedText = TextToEncrypt Then
            Return True 'Test succeeded
        Else
            Return False 'Test failed
        End If

    End Function

End Class
