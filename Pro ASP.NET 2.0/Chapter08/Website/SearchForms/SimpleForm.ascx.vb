Imports Reporting

Partial Class SimpleForm
    Inherits System.Web.UI.UserControl
    Implements ISearchControl

    '***************************************************************************
    Public Function GetSqlQuery() As Reporting.SqlQuery _
      Implements Reporting.ISearchControl.GetSqlQuery
        Dim SqlQueryObj As New SqlQuery
        SqlQueryObj.From = "Employees"
        SqlQueryObj.Where.CreateKeywords(Me.txtEmployeeInfo.Text, _
          "FirstName + ' ' + LastName + ' ' + Title", SqlOperation.And)
        Return SqlQueryObj
    End Function

End Class
