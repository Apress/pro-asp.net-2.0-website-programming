
Partial Class SimpleHashingAlgorithm
    Inherits System.Web.UI.Page

    '***************************************************************************
    Private Function MyHashAlgorithm(ByVal input As String) As Integer
        'Add up the character value of each character in the string
        'and return the summation as the "hash value"

        Dim charArray() As Char = input.ToCharArray()
        Dim hashValue As Integer = 0
        For Each c As Char In charArray
            hashValue += Asc(UCase(c))
        Next
        Return hashValue

    End Function

    '***************************************************************************
    Protected Sub btnHashValue_Click(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles btnHashValue.Click
        Me.lblHashedValue.Text = CStr(MyHashAlgorithm(Me.txtValueToHash.Text))
    End Sub
End Class
