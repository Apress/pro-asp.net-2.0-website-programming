Imports Reporting

Partial Class CustomerSimple
    Inherits UserControl
    Implements ISearchControl

    '***************************************************************************
    Public Event SearchExecuted() Implements ISearchControl.SearchButtonClicked

    '***************************************************************************
    Public Function GetSqlQuery() As SqlQuery Implements ISearchControl.GetSqlQuery
        Dim SqlQueryObj As New SqlQuery
        SqlQueryObj.From = "Customers"
        SqlQueryObj.Where.CreateKeywords(Me.txtCustomerInfo.Text, _
          "CustomerID + ' ' + CompanyName + ' ' + ContactName + ' ' + " & _
          "ContactTitle", SqlOperation.And)
        Return SqlQueryObj
    End Function

    '***************************************************************************
    Protected Sub btnSearch_Click(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles btnSearch.Click
        RaiseEvent SearchExecuted()
    End Sub

End Class