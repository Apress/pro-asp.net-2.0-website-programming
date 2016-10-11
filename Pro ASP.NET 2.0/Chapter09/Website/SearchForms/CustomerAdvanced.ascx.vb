Imports Reporting

Partial Class CustomerAdvanced
    Inherits UserControl
    Implements ISearchControl

    '***************************************************************************
    Public Event SearchExecuted() Implements ISearchControl.SearchButtonClicked

    '***************************************************************************
    Public Function GetSqlQuery() As SqlQuery Implements ISearchControl.GetSqlQuery
        Dim SqlQueryObj As New SqlQuery
        SqlQueryObj.From = "Customers"
        SqlQueryObj.Where.And()
        SqlQueryObj.Where.CreateKeywords(Me.txtCustomerID.Text, _
          "CustomerID", SqlOperation.And)
        SqlQueryObj.Where.CreateKeywords(Me.txtCompanyName.Text, _
          "CompanyName", SqlOperation.And)
        SqlQueryObj.Where.CreateKeywords(Me.txtContactName.Text, _
          "ContactName", SqlOperation.And)
        SqlQueryObj.Where.CreateKeywords(Me.txtContactTitle.Text, _
          "ContactTitle", SqlOperation.And)
        Return SqlQueryObj
    End Function

    '***************************************************************************
    Protected Sub btnSearch_Click(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles btnSearch.Click
        RaiseEvent SearchExecuted()
    End Sub

End Class