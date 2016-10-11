Imports Microsoft.VisualBasic

Public Class SqlQueryScenarios


    '***************************************************************************
    Public Shared Function Scenario1() As String

        'SELECT   CustomerID, CompanyName, Phone AS PhoneNumber, Fax as FaxNumber
        'FROM     Customers
        'ORDER BY CompanyName

        Dim SqlQueryObj As New Reporting.SqlQuery

        SqlQueryObj.SelectFields.Add("CustomerID")
        SqlQueryObj.SelectFields.Add("CompanyName")
        SqlQueryObj.SelectFields.Add("Phone", "PhoneNumber")
        SqlQueryObj.SelectFields.Add("Fax", "FaxNumber")
        SqlQueryObj.From = "Customers"
        SqlQueryObj.OrderBy.Add("CompanyName")
        Return SqlQueryObj.GetQuery()

    End Function

    '***************************************************************************
    Public Shared Function Scenario2(ByVal cityName As String) As String

        'SELECT   CustomerID, CompanyName, Phone AS PhoneNumber, Fax as FaxNumber
        'FROM     Customers
        'WHERE    City = 'cityName'
        'ORDER BY CompanyName

        Dim SqlQueryObj As New Reporting.SqlQuery

        SqlQueryObj.SelectFields.Add("CustomerID")
        SqlQueryObj.SelectFields.Add("CompanyName")
        SqlQueryObj.SelectFields.Add("Phone", "PhoneNumber")
        SqlQueryObj.SelectFields.Add("Fax", "FaxNumber")
        SqlQueryObj.From = "Customers"

        If Not cityName = String.Empty Then
            SqlQueryObj.Where.AddCondition("City='" & cityName & "'")
        End If

        SqlQueryObj.OrderBy.Add("CompanyName")
        Return SqlQueryObj.GetQuery()

    End Function


    '***************************************************************************
    Public Shared Function Scenario3(ByVal cityName As String, _
      ByVal showTotalSpent As Boolean, ByVal sortColumn As String, _
      ByVal sortDir As Reporting.SqlSortDirection) As String

        '-----------------------------------------------------------------------
        ' Option 1:
        '-----------------------------------------------------------------------
        '  SELECT   CustomerID, CompanyName, City, Phone AS PhoneNumber, Fax as FaxNumber
        '  FROM     Customers
        '  WHERE    City='[City Name]'    -- Line should not appear if city is not specified
        '  ORDER BY CompanyName
        '
        '-----------------------------------------------------------------------
        ' Option 2
        '-----------------------------------------------------------------------
        '  SELECT     Customers.CustomerID, Customers.CompanyName,          
        '             Customers.Phone AS PhoneNumber, Customers.Fax AS FaxNumber, 
        '             Customers.City,
        '             SUM([Order Details].UnitPrice * [Order Details].Quantity) AS TotalSpent
        '  FROM       Customers INNER JOIN Orders ON 
        '               Customers.CustomerID = Orders.CustomerID INNER JOIN [Order Details] ON 
        '                 Orders.OrderID = [Order Details].OrderID
        '  WHERE     (Customers.City = 'London') AND (Orders.OrderDate > '[Six Months Ago]')
        '  GROUP BY  Customers.CustomerID, Customers.CompanyName, Customers.Phone, 
        '            Customers.Fax, Customers.City, Customers.City
        '  ORDER BY  Customers.CustomerID
        '-----------------------------------------------------------------------

        Dim SqlQueryObj As New Reporting.SqlQuery

        SqlQueryObj.SelectFields.Add("Customers.CustomerID")
        SqlQueryObj.SelectFields.Add("Customers.CompanyName")
        SqlQueryObj.SelectFields.Add("Customers.Phone", "PhoneNumber")
        SqlQueryObj.SelectFields.Add("Customers.Fax", "FaxNumber")

        If Not cityName = String.Empty Then
            SqlQueryObj.Where.AddCondition("Customers.City='" & cityName & "'")
        End If

        If showTotalSpent Then

            'Setup the additional Select Field
            SqlQueryObj.SelectFields.Add( _
                "SUM([Order Details].UnitPrice * [Order Details].Quantity)", _
                "TotalSpent")

            'Setup the FROM clause with the Joined tables
            SqlQueryObj.From = "Customers INNER JOIN Orders ON " & _
                "Customers.CustomerID = Orders.CustomerID INNER JOIN " & _
                "[Order Details] ON Orders.OrderID = [Order Details].OrderID"

            'Add WHERE clause to limit orders to the last 6 months
            SqlQueryObj.Where.And()
            SqlQueryObj.Where.AddCondition("Orders.OrderDate > '" & _
                Format(CDate(Now.AddMonths(-6)), "MM/dd/yyyy") & "'")

            'Setup the GROUP BY clause
            SqlQueryObj.GroupBy.Add("Customers.CustomerID")
            SqlQueryObj.GroupBy.Add("Customers.CompanyName")
            SqlQueryObj.GroupBy.Add("Customers.Phone")
            SqlQueryObj.GroupBy.Add("Customers.Fax")
            SqlQueryObj.GroupBy.Add("Customers.City")
            SqlQueryObj.GroupBy.Add("Customers.City")

        Else
            'Setup the single table FROM clause
            SqlQueryObj.From = "Customers"
        End If

        'Build out ORDER BY based on sortColumn value
        Select Case UCase(sortColumn)
            Case "CUSTOMERID"
                SqlQueryObj.OrderBy.Add("CustomerID", sortDir)
            Case "TOTALSPENT"
                SqlQueryObj.OrderBy.Add("TotalSpent", sortDir)
                SqlQueryObj.OrderBy.Add("CompanyName", sortDir)
            Case Else
                SqlQueryObj.OrderBy.Add("CompanyName", sortDir)
        End Select

        Return SqlQueryObj.GetQuery()

    End Function


End Class
