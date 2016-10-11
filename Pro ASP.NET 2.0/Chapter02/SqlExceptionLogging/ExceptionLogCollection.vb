Imports System.Data.SqlClient

Public Class ExceptionLogCollection
    Inherits CollectionBase

    '***************************************************************************
    Default Public Property Items(ByVal index As Integer) As ExceptionLog
        Get
            Return InnerList.Item(index)
        End Get
        Set(ByVal value As ExceptionLog)
            InnerList.Item(index) = value
        End Set
    End Property

    '***************************************************************************
    Public Function Add(ByVal obj As ExceptionLog) As Integer
        Return InnerList.Add(obj)        
    End Function

    '***************************************************************************
    Public Sub LoadChain(ByVal ChainID As Guid, _
      ByVal DBConn As SqlConnection)

        Dim SQL As String = "SELECT * FROM [ExceptionLog] " & _
          "WHERE [ChainID]=@ChainID ORDER BY [ExceptionID];"

        Dim cmd As New SqlCommand(SQL, DBConn)
        cmd.Parameters.Add("@ChainID", SqlDbType.UniqueIdentifier).Value = ChainID

        Dim dr As SqlDataReader = cmd.ExecuteReader()
        Dim obj As ExceptionLog

        Me.Clear()
        While dr.Read
            obj = New ExceptionLog
            obj.MapData(dr)
            Add(obj)
        End While

    End Sub

    '***************************************************************************
    Public Sub LoadAll(ByVal DBConn As SqlConnection)

        Dim SQL As String = "SELECT * FROM [ExceptionLog] " & _
          "WHERE [ParentID]=0 ORDER BY [ExceptionDate] DESC;"

        Dim cmd As New SqlCommand(SQL, DBConn)
        Dim dr As SqlDataReader = cmd.ExecuteReader()
        Dim obj As ExceptionLog

        Me.Clear()
        While dr.Read
            obj = New ExceptionLog
            obj.MapData(dr)
            Add(obj)
        End While

    End Sub


End Class
