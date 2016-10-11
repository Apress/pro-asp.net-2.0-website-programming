Imports System.Security.Cryptography
Imports System.Text

'*******************************************************************************
Public Class Hashing

    'Algorithm Enermations
    Public Enum HashAlgorithmType
        MD5
        SHA1
        SHA256
        SHA384
        SHA512
    End Enum

    '***************************************************************************
    Public Shared Function CreateHash(ByVal valueToHash As String, _
      ByVal algorithmType As HashAlgorithmType) As String

        'Setup variables
        Dim algorithm As System.Security.Cryptography.HashAlgorithm
        Dim encoder As ASCIIEncoding = New ASCIIEncoding()
        Dim valueByteArray As Byte() = encoder.GetBytes(valueToHash)
        Dim hashValue As String = ""
        Dim hashValueByteArray As Byte()


        'Acquire algorithm object
        Select Case algorithmType
            Case HashAlgorithmType.SHA1
                algorithm = New SHA1Managed()
            Case HashAlgorithmType.SHA256
                algorithm = New SHA256Managed()
            Case HashAlgorithmType.SHA384
                algorithm = New SHA384Managed()
            Case HashAlgorithmType.SHA512
                algorithm = New SHA512Managed()
            Case Else 'use MD5
                algorithm = New MD5CryptoServiceProvider
        End Select

        'Create binary hash
        hashValueByteArray = algorithm.ComputeHash(valueByteArray)

        'Convert binary hash to hex
        For Each b As Byte In hashValueByteArray
            hashValue &= String.Format("{0:x2}", b)
        Next

        Return hashValue

    End Function

End Class
