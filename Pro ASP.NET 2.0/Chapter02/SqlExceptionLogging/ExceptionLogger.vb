Imports Microsoft.VisualBasic.ControlChars
Imports System.Collections.Specialized
Imports System.Configuration.ConfigurationManager
Imports System.Data.SqlClient
Imports System.Web.HttpContext

Public Class ExceptionLogger

    '***************************************************************************
    Private Shared _connectionString As String = ""

    '***************************************************************************
    Public Shared Property ConnectionString() As String
        Get
            Return _connectionString
        End Get
        Set(ByVal value As String)
            _connectionString = value
        End Set
    End Property

    '***************************************************************************
    Public Shared Sub Log(ByVal ex As Exception)

        Dim exLog As New ExceptionLog
        Dim parentID As Integer = 0
        Dim chainID As Guid = Guid.NewGuid()
        Dim dbConn As SqlConnection = New SqlConnection(ConnectionString)

        dbConn.Open()

        'Iterate through all of the exceptions in the exception chain
        While Not ex Is Nothing

            'Create a new Exception Log object for the exception
            exLog = New ExceptionLog()

            'Acquire the user name
            If Current.User.Identity.IsAuthenticated Then
                exLog.UserID = Current.User.Identity.Name
            Else
                exLog.UserID = "<Anonymous User>"
            End If

            exLog.ParentID = parentID
            exLog.MachineName = Current.Server.MachineName
            exLog.UserAgent = Current.Request.UserAgent
            exLog.ExceptionDate = Now
            exLog.ExceptionType = ex.GetType.ToString
            exLog.ExceptionMessage = ex.Message
            exLog.Page = Current.Request.AppRelativeCurrentExecutionFilePath()
            exLog.StackTrace = ex.StackTrace
            exLog.QueryStringData = GetQuerystringData()
            exLog.FormData = GetFormData()
            exLog.ChainID = chainID

            'Save Exception Log, Get New ParentID, Get Next Inner Exception
            If exLog.Save(dbConn) Then
                parentID = exLog.ExceptionID
                ex = ex.InnerException
            Else
                ex = Nothing
            End If

        End While

        dbConn.Close()

    End Sub


    '***************************************************************************
    Private Shared Function GetQuerystringData() As String
        Dim Data As New System.Text.StringBuilder(256)
        For Each key As String In Current.Request.QueryString.Keys
            Data.Append(key)
            Data.Append("=")
            Data.Append(Current.Request.QueryString(key))
            Data.Append(CrLf)
        Next
        Return Data.ToString
    End Function

    '***************************************************************************
    Private Shared Function GetFormData() As String
        Dim Data As New System.Text.StringBuilder(256)
        For Each key As String In Current.Request.Form.Keys
            Data.Append(key)
            Data.Append("=")
            Data.Append(Current.Request.Form(key))
            Data.Append(CrLf)
        Next
        Return Data.ToString
    End Function

End Class
