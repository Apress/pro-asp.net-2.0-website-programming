Imports System
Imports System.Security.Cryptography
Imports System.Text
Imports EncryptionLibrary

Partial Class StrongHashingAlgorithm
    Inherits System.Web.UI.Page

    Protected Sub btnHashValue_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHashValue.Click

        Dim algorithm As Hashing.HashAlgorithmType

        Select Case ddlAlgorithm.SelectedValue
            Case "MD5"
                algorithm = Hashing.HashAlgorithmType.MD5
            Case "SHA1"
                algorithm = Hashing.HashAlgorithmType.SHA1
            Case "SHA256"
                algorithm = Hashing.HashAlgorithmType.SHA256
            Case "SHA384"
                algorithm = Hashing.HashAlgorithmType.SHA384
            Case "SHA512"
                algorithm = Hashing.HashAlgorithmType.SHA512
        End Select

        Me.lblHashedValue.Text = Hashing.CreateHash(Me.txtValueToHash.Text, algorithm)

    End Sub


End Class
