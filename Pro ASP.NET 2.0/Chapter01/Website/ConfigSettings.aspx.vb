
Partial Class ConfigSettings_aspx
    Inherits Page

    '***************************************************************************
    Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles Me.Load

        Me.lblMyString.Text = Config.MyString
        Me.lblMyInteger.Text = Config.MyInteger.ToString()
        Me.lblMyDateTime.Text = Config.MyDateTime.ToString()
        Me.lblMyBoolean.Text = Config.MyBoolean.ToString()
        Me.lblMyConnectionString.Text = Config.MyConnectionString

        For Each PrimeNumber As Integer In Config.MyPrimeList
            Me.lblMyPrimeList.Text &= PrimeNumber.ToString & "<BR>"
        Next

    End Sub

End Class
