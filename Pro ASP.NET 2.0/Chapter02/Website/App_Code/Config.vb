'*******************************************************************************
' Make sure you import the following line when creating your configuration 
' files to avoid hideously long calls to the AppSetting object.
'*******************************************************************************

Imports System.Configuration.ConfigurationManager

Public Class Config

    '***************************************************************************
    'Private Shared Variables used for Caching Settings
    Private Shared _MyConnectionString As String

    '***************************************************************************
    Public Shared ReadOnly Property MyConnectionString() As String
        Get
            If _MyConnectionString = Nothing Then _MyConnectionString = _
                ConnectionStrings("MyConnectionString").ConnectionString
            Return _MyConnectionString            
        End Get
    End Property

End Class