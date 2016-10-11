Imports EncryptionLibrary
Imports EncryptionLibrary.Encryption.EncryptionAlgorithmType

Partial Class EncryptionPage
    Inherits System.Web.UI.Page


    Private ReadOnly Property SelectedAlgorithm() As Encryption.EncryptionAlgorithmType
        Get
            Select Case Me.ddlAlgorithm.SelectedValue
                Case "DES" : Return DES
                Case "RC2" : Return RC2
                Case "Rijndael" : Return Rijndael
                Case "TripleDES" : Return TripleDES
                Case Else : Throw New ArgumentException()
            End Select
        End Get
    End Property

    Protected Sub btnExecute_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExecute.Click

        Dim algorithm As Encryption.EncryptionAlgorithmType = SelectedAlgorithm
        Dim key As Byte() = Nothing
        Dim IV As Byte() = Nothing

        'Make sure there is a value with which to work
        If Me.txtValue.Text = String.Empty Then
            Me.lblOutput.Text = "You must specify a value to encryp or decrypt"
            Exit Sub
        End If

        'Acquire Key and IV if applicable
        If Not Me.txtKey.Text = String.Empty Then
            key = Convert.FromBase64String(Me.txtKey.Text)
        End If

        If Not Me.txtIV.Text = String.Empty Then
            IV = Convert.FromBase64String(Me.txtIV.Text)
        End If

        Try

            Select Case Me.ddlDirection.SelectedValue
                Case "Encrypt"
                    Me.txtValue.Text = Encryption.EncryptString(Me.txtValue.Text, algorithm, key, IV)
                    Me.txtKey.Text = Convert.ToBase64String(key)
                    Me.txtIV.Text = Convert.ToBase64String(IV)
                    Me.lblOutput.Text = "Value Encrypted"

                Case "Decrypt"
                    If key Is Nothing Or IV Is Nothing Then
                        Me.lblOutput.Text = "You must specify a key and an init vector to decrypt data"
                    Else
                        Me.txtValue.Text = Encryption.DecryptString(Me.txtValue.Text, algorithm, key, IV)
                        Me.lblOutput.Text = "Value Decrypted"
                    End If

            End Select

        Catch ex As Exception
            lblOutput.Text = "Error Executing Encryption / Decryption: " & ex.Message
        End Try


    End Sub

    Protected Sub btnGenKey_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenKey.Click
        Dim key As Byte() = Encryption.GenerateKey(SelectedAlgorithm)
        Me.txtKey.Text = Convert.ToBase64String(key)
        Me.lblOutput.Text = "Generated " & key.Length * 8 & " bit key"
    End Sub

    Protected Sub btnGenIV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenIV.Click
        Dim IV As Byte() = Encryption.GenerateIV(SelectedAlgorithm)
        Me.txtIV.Text = Convert.ToBase64String(IV)
        Me.lblOutput.Text = "Generated " & IV.Length * 8 & " bit IV"
    End Sub

End Class
