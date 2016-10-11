Imports Reporting

Partial Class AdvancedForm
    Inherits System.Web.UI.UserControl
    Implements ISearchControl

    '***************************************************************************
    Public Function GetSqlQuery() As Reporting.SqlQuery _
      Implements Reporting.ISearchControl.GetSqlQuery

        Dim sqlQueryObj As New SqlQuery
        sqlQueryObj.From = "Employees"

        'This query will use AND conditional logic
        sqlQueryObj.Where.And()

        'Setup the employee ID condition if applicable
        If Me.txtEmployeeID.Text <> String.Empty Then _
          sqlQueryObj.Where.AddCondition("EmployeeID='" & _
          SqlString(Me.txtEmployeeID.Text) + "'")

        'Setup the employee name keywords
        sqlQueryObj.Where.CreateKeywords( _
          Me.txtEmployeeName.Text, "FirstName + ' ' + LastName", SqlOperation.And)

        'Setup the title keywords
        sqlQueryObj.Where.CreateKeywords( _
         Me.txtTitle.Text, "Title", SqlOperation.And)

        'Setup the birth date date range
        sqlQueryObj.Where.CreateDateRange( _
          Me.txtBirthDateStart.Text, Me.txtBirthDateEnd.Text, "BirthDate", _
          SqlEvaluationType.Inclusive, "MM/dd/yyyy")

        Return sqlQueryObj

    End Function

End Class