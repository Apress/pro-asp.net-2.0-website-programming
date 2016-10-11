Imports System.Data.SqlClient
Imports system.Web.Configuration.WebConfigurationManager

Public Module Data

    '***************************************************************************
    Public Function GetConnectionString() As String
        Return ConnectionStrings("Database").ConnectionString
    End Function

    '***************************************************************************
    Public Function GetConnection() As SqlConnection
        Dim conn As New SqlConnection(GetConnectionString)        
        Return conn
    End Function

    '***************************************************************************
    Public Function SQLEncode(ByVal sqlString As String) As String
        Return sqlString.Replace("'", "''")
    End Function

End Module
