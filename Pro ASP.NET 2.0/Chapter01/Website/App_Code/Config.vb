'*******************************************************************************
' Make sure you import the following line when creating your configuration 
' files to avoid hideously long calls to the AppSetting object.
'*******************************************************************************
Imports IconConfiguration
Imports System.Configuration.ConfigurationManager


Public Class Config

    '***************************************************************************
    'Private Shared Variables used for Caching Settings
    Private Shared _MyString As String
    Private Shared _MyInteger As Integer
    Private Shared _MyDateTime As DateTime
    Private Shared _MyBoolean As Boolean
    Private Shared _MyPrimeList As ArrayList
    Private Shared _MyConnectionString As String
    Private Shared _IconData As IconConfigurationCollection
    Private Shared _MyGuid As Guid

    '***************************************************************************
    Public Shared ReadOnly Property MyString() As String
        Get            
            If _MyString = Nothing Then _MyString = AppSettings("MyString")
            Return _MyString
        End Get
    End Property

    '***************************************************************************
    Public Shared ReadOnly Property MyInteger() As Integer
        Get
            If _MyInteger = Nothing Then _
                _MyInteger = CInt(AppSettings("MyInteger"))
            Return _MyInteger
        End Get
    End Property

    '***************************************************************************
    Public Shared ReadOnly Property MyDateTime() As Date
        Get
            If _MyDateTime = Nothing Then _
                _MyDateTime = CDate(AppSettings("MyDateTime"))
            Return _MyDateTime
        End Get
    End Property

    '***************************************************************************
    Public Shared ReadOnly Property MyBoolean() As Boolean
        Get
            If _MyBoolean = Nothing Then _
             _MyBoolean = CBool(AppSettings("MyBoolean"))
            Return _MyBoolean
        End Get
    End Property

    '***************************************************************************
    Public Shared ReadOnly Property MyPrimeList() As ArrayList
        Get
            If _MyPrimeList Is Nothing Then
                _MyPrimeList = New ArrayList
                Dim TempPrimeList As String() = _
                  Split(AppSettings("MyPrimeList"), ";")

                For index As Integer = 0 To TempPrimeList.Length - 1
                    _MyPrimeList.Add(CInt(TempPrimeList(index)))
                Next

            End If

            Return _MyPrimeList
        End Get
    End Property

    '***************************************************************************
    Public Shared ReadOnly Property MyConnectionString() As String
        Get
            If _MyConnectionString = Nothing Then _MyConnectionString = _
                ConnectionStrings("MyConnectionString").ConnectionString
            Return _MyConnectionString
        End Get
    End Property


    '***************************************************************************
    Public Shared ReadOnly Property MyIntegerWithErrorChecking() As Integer
        Get
            If IsNumeric(AppSettings("MyInteger")) Then
                _MyInteger = CInt(AppSettings("MyInteger"))                
            Else
                _MyInteger = 5
            End If
            Return _MyInteger
        End Get
    End Property


    '***************************************************************************
    Public Shared ReadOnly Property MyIntegerWithErrorHandling() As Integer
        Get
            Try
                If _MyInteger = Nothing Then _
                    _MyInteger = CInt(AppSettings("MyInteger"))                
            Catch ex As Exception
                _MyInteger = 5
            End Try
            Return _MyInteger
        End Get
    End Property

    '***************************************************************************
    Public Shared ReadOnly Property MyIntegerWithNoCaching() As Integer
        Get
            Return CInt(AppSettings("MyInteger"))
        End Get
    End Property

    '***************************************************************************
    Public Shared ReadOnly Property IconData() As IconConfigurationCollection
        Get
            If _IconData Is Nothing Then _IconData = _
              DirectCast(ConfigurationManager.GetSection("iconConfig"), _
                 IconConfigurationCollection)
            Return _IconData
        End Get
    End Property

    '***************************************************************************
    Public Shared ReadOnly Property MyGuidWithErrorHandling() As Guid
        Get
            Try
                If _MyGuid = Nothing Then _MyGuid = _
                    New Guid(AppSettings("MyGuid"))
            Catch ex As Exception
                'Error occured so set a default value
                _MyGuid = New Guid("{05F8B079-5367-42a8-B97F-6C72BAC4915C}")
            End Try
            Return _MyGuid
        End Get
    End Property


End Class
