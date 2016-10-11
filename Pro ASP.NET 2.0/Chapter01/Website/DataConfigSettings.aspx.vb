
Partial Class DataConfigSettings_aspx
    Inherits Page

    '***************************************************************************
    Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles Me.Load

        Me.lblMyString.Text = DataConfig.MyString
        Me.lblMyInteger.Text = DataConfig.MyInteger.ToString()
        Me.lblMyDateTime.Text = DataConfig.MyDateTime.ToString()
        Me.lblMyBoolean.Text = DataConfig.MyBoolean.ToString()

        For Each PrimeNumber As Integer In DataConfig.MyPrimeList
            Me.lblMyPrimeList.Text &= PrimeNumber.ToString & "<BR>"
        Next

        If DataConfig.MyPrimeList.Count = 0 Then
            DataConfig.MyPrimeList.Add(1)
            DataConfig.MyPrimeList.Add(2)
            DataConfig.MyPrimeList.Add(3)
            DataConfig.MyPrimeList.Add(5)
            DataConfig.MyPrimeList.Add(7)
            DataConfig.MyPrimeList.Add(9)
            DataConfig.SaveMyPrimeList()
        End If
    End Sub

    '***************************************************************************
    Sub btnClearCache_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        DataConfig.ClearCache()
    End Sub

End Class
