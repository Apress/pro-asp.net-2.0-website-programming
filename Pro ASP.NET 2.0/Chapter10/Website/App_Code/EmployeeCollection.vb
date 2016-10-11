Imports System.Data.SqlClient
Imports Data

Public Class EmployeeCollection
    Inherits CollectionBase

    '***************************************************************************
    Default Public Property Item(ByVal index As Integer) As Employee
        Get
            Return DirectCast(List.Item(index), Employee)
        End Get
        Set(ByVal value As Employee)
            List.Item(index) = value
        End Set
    End Property

    '***************************************************************************
    Public Function Add(ByVal item As Employee) As Integer
        Return List.Add(item)
    End Function

    '***************************************************************************
    Private Shared Function PopulateCollection(ByVal SQL As String) _
      As EmployeeCollection

        Dim EmployeeCol As New EmployeeCollection
        Dim EmployeeObj As Employee
        Dim conn As SqlConnection = GetOpenConnection()
        Dim cmd As New SqlCommand(SQL, conn)
        Dim dr As SqlDataReader = cmd.ExecuteReader()

        While dr.Read
            EmployeeObj = New Employee
            EmployeeObj.PopulateObject(dr)
            EmployeeCol.Add(EmployeeObj)
        End While

        conn.Close()

        Return EmployeeCol

    End Function

    '***************************************************************************
    Public Shared Function GetEmployeeMatches(ByVal LastName As String, _
      ByVal FirstName As String) As EmployeeCollection

        Dim SQL As String = String.Format( _
                "SELECT * FROM [Employees] " & _
                " WHERE   (DIFFERENCE(LastName, '{0}') >= 3 " & _
                "          OR LastName like '%{0}%' " & _
                "          OR '{0}' LIKE '%' + LastName + '%')" & _
                "     AND (DIFFERENCE(FirstName,'{1}') >= 3 " & _
                "          OR FirstName like '%{1}%' " & _
                "          OR '{1}' LIKE '%' + FirstName + '%')" & _
                " ORDER BY DIFFERENCE(LastName, '{0}'),  " & _
                "         DIFFERENCE(FirstName,'{1}')", _
                SQLEncode(LastName), SQLEncode(FirstName))

        Return PopulateCollection(SQL)

    End Function

End Class
