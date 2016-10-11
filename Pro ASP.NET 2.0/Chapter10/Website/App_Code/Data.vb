Imports System.Data.SqlClient
Imports system.Web.Configuration.WebConfigurationManager

Public Class Data

    '***************************************************************************
    Public Shared Function GetConnectionString() As String
        Return ConnectionStrings("Northwind").ConnectionString
    End Function

    '***************************************************************************
    Public Shared Function GetOpenConnection() As SqlConnection
        Dim conn As New SqlConnection(GetConnectionString)
        conn.Open()
        Return conn
    End Function

    '***************************************************************************
    Public Shared Function SQLEncode(ByVal sqlString As String) As String
        Return sqlString.Replace("'", "''")
    End Function

    '***************************************************************************
    Public Shared Function GetInteger(ByVal obj As Object) As Integer
        If IsDBNull(obj) Then Return 0 Else Return CInt(obj)
    End Function

    '***************************************************************************
    Public Shared Function GetDate(ByVal obj As Object) As Date
        If IsDBNull(obj) Then Return Nothing Else Return CDate(obj)
    End Function

    '***************************************************************************
    Public Shared Function GetString(ByVal obj As Object) As String
        If IsDBNull(obj) Then Return String.Empty Else Return CStr(obj)
    End Function

    '***************************************************************************
    Public Shared Function StringToDate(ByVal dateString As String) As Date
        If IsDate(dateString) Then Return CDate(dateString)
        Return Nothing
    End Function

    ''***************************************************************************
    'Public Shared Function NullableInt(ByVal intIn As Integer) As String
    '    If intIn = Nothing Then Return "null" Else Return intIn.ToString()
    'End Function

    '***************************************************************************
    Public Shared Function NullableDate(ByVal dateIn As Date) As String
        If dateIn = Nothing Then Return "null" Else _
          Return "'" & Format(dateIn, "MM/dd/yyyy") & "'"
    End Function

End Class
