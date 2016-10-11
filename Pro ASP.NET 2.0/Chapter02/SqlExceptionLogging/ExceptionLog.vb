Imports System.Data.SqlClient

Public Class ExceptionLog

#Region "Fields"

    '***************************************************************************
    Private _ExceptionID As Integer = 0
    Private _ParentID As Integer = 0
    Private _MachineName As String = String.Empty
    Private _UserID As String = String.Empty
    Private _UserAgent As String = String.Empty
    Private _ExceptionDate As Date = Now
    Private _ExceptionType As String = String.Empty
    Private _ExceptionMessage As String = String.Empty
    Private _Page As String = String.Empty
    Private _StackTrace As String = String.Empty
    Private _QueryStringData As String = String.Empty
    Private _FormData As String = String.Empty
    Private _ChainID As Guid = Guid.Empty

#End Region

#Region "Properties"

    '***************************************************************************
    Public Property ExceptionID() As Integer
        Get
            Return _ExceptionID
        End Get
        Set(ByVal value As Integer)
            _ExceptionID = value
        End Set
    End Property

    '***************************************************************************
    Public Property ParentID() As Integer
        Get
            Return _ParentID
        End Get
        Set(ByVal value As Integer)
            _ParentID = value
        End Set
    End Property

    '***************************************************************************
    Public Property MachineName() As String
        Get
            Return _MachineName
        End Get
        Set(ByVal value As String)
            _MachineName = value
        End Set
    End Property

    '***************************************************************************
    Public Property UserID() As String
        Get
            Return _UserID
        End Get
        Set(ByVal value As String)
            _UserID = value
        End Set
    End Property

    '***************************************************************************
    Public Property UserAgent() As String
        Get
            Return _UserAgent
        End Get
        Set(ByVal value As String)
            _UserAgent = value
        End Set
    End Property

    '***************************************************************************
    Public Property ExceptionDate() As Date
        Get
            Return _ExceptionDate
        End Get
        Set(ByVal value As Date)
            _ExceptionDate = value
        End Set
    End Property

    '***************************************************************************
    Public Property ExceptionType() As String
        Get
            Return _ExceptionType
        End Get
        Set(ByVal value As String)
            _ExceptionType = value
        End Set
    End Property

    '***************************************************************************
    Public Property ExceptionMessage() As String
        Get
            Return _ExceptionMessage
        End Get
        Set(ByVal value As String)
            _ExceptionMessage = value
        End Set
    End Property

    '***************************************************************************
    Public Property Page() As String
        Get
            Return _Page
        End Get
        Set(ByVal value As String)
            _Page = value
        End Set
    End Property

    '***************************************************************************
    Public Property StackTrace() As String
        Get
            Return _StackTrace
        End Get
        Set(ByVal value As String)
            _StackTrace = value
        End Set
    End Property

    '***************************************************************************
    Public Property QueryStringData() As String
        Get
            Return _QueryStringData
        End Get
        Set(ByVal value As String)
            _QueryStringData = value
        End Set
    End Property

    '***************************************************************************
    Public Property FormData() As String
        Get
            Return _FormData
        End Get
        Set(ByVal value As String)
            _FormData = value
        End Set
    End Property

    '***************************************************************************
    Public Property ChainID() As Guid
        Get
            Return _ChainID
        End Get
        Set(ByVal value As Guid)
            _ChainID = value
        End Set
    End Property

#End Region

    '***************************************************************************
    Public Shared Function DeleteAll(ByVal DBConn As SqlConnection) As Boolean

        Dim SQL As String = "DELETE FROM [ExceptionLog];"
        Dim cmd As New SqlCommand(SQL, DBConn)
        cmd.ExecuteNonQuery()
        Return True

    End Function

    '***************************************************************************
    Public Function DeleteChain(ByVal DBConn As SqlConnection) As Boolean

        Dim SQL As String = "DELETE FROM [ExceptionLog] WHERE [ChainID]=@ChainID;"
        Dim cmd As New SqlCommand(SQL, DBConn)
        cmd.Parameters.Add("@ChainID", SqlDbType.UniqueIdentifier).Value = ChainID
        cmd.ExecuteNonQuery()
        Return True

    End Function

    '*******************************************************************************
    Public Function Save(ByVal dbConn As SqlConnection) As Boolean

        Dim SQL As String = _
          "INSERT INTO [ExceptionLog] (ParentID, MachineName, UserID, " & _
            "UserAgent, ExceptionDate, ExceptionType, ExceptionMessage, " & _
            "Page, StackTrace, QueryStringData, FormData, ChainID)" & _
          "VALUES (@ParentID, @MachineName, @UserID, @UserAgent, " & _
            "@ExceptionDate, @ExceptionType, @ExceptionMessage, @Page, " & _
            "@StackTrace, @QueryStringData, @FormData, @ChainID);"

        Dim cmd As New SqlCommand(SQL, dbConn)
        cmd.Parameters.Add("@ParentID", SqlDbType.Int).Value = ParentID
        cmd.Parameters.Add("@MachineName", SqlDbType.VarChar).Value = CheckEmpty(MachineName)
        cmd.Parameters.Add("@UserID", SqlDbType.VarChar).Value = CheckEmpty(UserID)
        cmd.Parameters.Add("@UserAgent", SqlDbType.VarChar).Value = CheckEmpty(UserAgent)
        cmd.Parameters.Add("@ExceptionDate", SqlDbType.VarChar).Value = CheckEmpty(ExceptionDate)
        cmd.Parameters.Add("@ExceptionType", SqlDbType.VarChar).Value = CheckEmpty(ExceptionType)
        cmd.Parameters.Add("@ExceptionMessage", SqlDbType.VarChar).Value = CheckEmpty(ExceptionMessage)
        cmd.Parameters.Add("@Page", SqlDbType.VarChar).Value = CheckEmpty(Page)
        cmd.Parameters.Add("@StackTrace", SqlDbType.NText).Value = CheckEmpty(StackTrace)
        cmd.Parameters.Add("@QueryStringData", SqlDbType.Text).Value = CheckEmpty(QueryStringData)
        cmd.Parameters.Add("@FormData", SqlDbType.Text).Value = CheckEmpty(FormData)
        cmd.Parameters.Add("@ChainID", SqlDbType.UniqueIdentifier).Value = ChainID

        If cmd.ExecuteNonQuery() > 0 Then
            cmd.CommandText = "SELECT @@IDENTITY;"
            ExceptionID = CInt(cmd.ExecuteScalar())
            Return True
        Else
            Return False
        End If

    End Function

    '*******************************************************************************
    Private Function CheckEmpty(ByVal s As String) As String
        If s = Nothing Then Return "" Else Return s
    End Function

    '*******************************************************************************
    Public Function LoadByID(ByVal ExceptionID As Integer, _
      ByVal DBConn As SqlConnection) As Boolean

        Dim ReturnVal As Boolean = False
        Dim SQL As String = _
          "SELECT * FROM [ExceptionLog] WHERE [ExceptionID]=@ExceptionID"

        Dim cmd As New SqlCommand(SQL, DBConn)
        cmd.Parameters.Add("@ExceptionID", SqlDbType.Int).Value = ExceptionID

        Dim dr As SqlDataReader = cmd.ExecuteReader()
        If dr.Read Then
            MapData(dr)
            ReturnVal = True
        End If

        dr.Close()
        Return ReturnVal

    End Function

    '*******************************************************************************
    Public Sub MapData(ByVal dr As SqlDataReader)
        ExceptionID = CInt(dr("ExceptionID"))
        ParentID = CInt(dr("ParentID"))
        MachineName = CStr(dr("MachineName"))
        UserID = CStr(dr("UserID"))
        UserAgent = CStr(dr("UserAgent"))
        ExceptionDate = CStr(dr("ExceptionDate"))
        ExceptionType = CStr(dr("ExceptionType"))
        ExceptionMessage = CStr(dr("ExceptionMessage"))
        Page = CStr(dr("Page"))
        StackTrace = CStr(dr("StackTrace"))
        QueryStringData = CStr(dr("QueryStringData"))
        FormData = CStr(dr("FormData"))
        ChainID = DirectCast(dr("ChainID"), Guid)
    End Sub

End Class
