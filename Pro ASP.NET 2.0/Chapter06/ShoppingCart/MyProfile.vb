Imports System.Web.Profile

Public Class MyProfile
    Inherits ProfileBase

    '*****************************************************************
    Private _FirstName As String
    Private _LastName As String

    '*****************************************************************
    Public Property FirstName() As String
        Get
            Return _FirstName
        End Get
        Set(ByVal value As String)
            _FirstName = value
        End Set
    End Property

    '*****************************************************************
    Public Property LastName() As String
        Get
            Return _LastName
        End Get
        Set(ByVal value As String)
            _LastName = value
        End Set
    End Property

End Class

