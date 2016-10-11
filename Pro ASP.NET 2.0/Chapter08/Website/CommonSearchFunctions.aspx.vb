
Partial Class CommonSearchFunctions
    Inherits System.Web.UI.Page

    '***************************************************************************
    Protected Sub btnDateRangeQuery_Click(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles btnDateRangeQuery.Click

        Dim sqlQueryObj As New Reporting.SqlQuery

        sqlQueryObj.From = "Order"

        If Not Me.txtCustomerID.Text = String.Empty Then
            sqlQueryObj.Where.AddCondition( _
              String.Format("CustomerID='{0}'", txtCustomerID.Text))
        End If

        sqlQueryObj.Where.And()
        sqlQueryObj.Where.CreateDateRange(Me.txtStartDate.Text, _
          Me.txtEndDate.Text, "OrderDate", _
          Reporting.SqlEvaluationType.Inclusive, "MM/dd/yyyy")

        Me.lblDateRangeQuery.Text = sqlQueryObj.GetQuery()

    End Sub

    '***************************************************************************
    Protected Sub btnKeywords_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnKeywords.Click
        Dim sqlQueryObj As New Reporting.SqlQuery

        sqlQueryObj.From = "Employees"
        sqlQueryObj.Where.CreateKeywords(Me.txtKeywords.Text, "LastName + ' ' + FirstName + ' ' + Title", Reporting.SqlOperation.And)
        Me.lblKeywordQuery.Text = sqlQueryObj.GetQuery()

    End Sub

End Class
