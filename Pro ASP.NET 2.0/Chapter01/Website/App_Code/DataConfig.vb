Imports System.Data.SqlClient
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Soap

Public Class DataConfig

    '***************************************************************************
    Private Shared Function ReadValueFromDatabase(ByVal SettingName As String) As String

        Try
            Dim SQL As String = "SELECT [Value] FROM [Settings] " & _
                                "WHERE [SettingName]=@SettingName;"
            Dim dbConn As New SqlConnection(Config.MyConnectionString)
            Dim dbCmd As New SqlCommand(SQL, dbConn)

            'Setup the SettingName Parameters
            dbCmd.Parameters.Add("@SettingName", _
              Data.SqlDbType.VarChar).Value = SettingName

            dbConn.Open()
            ReadValueFromDatabase = CStr(dbCmd.ExecuteScalar())
            dbConn.Close()

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    '***************************************************************************
    Private Shared Function WriteValueToDatabase(ByVal SettingName As String, _
                                                ByVal Value As String) As Boolean
        Try
            Dim SQL As String = "UPDATE [Settings] SET [Value]=@Value " & _
                                "WHERE [SettingName]=@SettingName;"
            Dim dbConn As New SqlConnection(Config.MyConnectionString)
            Dim dbCmd As New SqlCommand(SQL, dbConn)

            'Setup the Value and SettingName parameters
            dbCmd.Parameters.Add("@Value", Data.SqlDbType.VarChar).Value = Value
            dbCmd.Parameters.Add("@SettingName", _
              Data.SqlDbType.VarChar).Value = SettingName

            dbConn.Open()
            WriteValueToDatabase = (dbCmd.ExecuteNonQuery() > 0)
            dbConn.Close()

        Catch ex As Exception
            Return False
        End Try

    End Function

    '***************************************************************************
    'Private Shared Variables used for Caching Settings
    Private Shared _MyString As String
    Private Shared _MyInteger As Integer
    Private Shared _MyDateTime As DateTime
    Private Shared _MyBoolean As Boolean
    Private Shared _MyPrimeList As ArrayList

    '***************************************************************************
    Public Shared Sub ClearCache()
        _MyString = Nothing
        _MyInteger = Nothing
        _MyDateTime = Nothing
        _MyBoolean = Nothing
        _MyPrimeList = Nothing
    End Sub

    '***************************************************************************
    Public Shared Property MyString() As String
        Get
            If _MyString = Nothing Then _MyString = ReadValueFromDatabase("MyString")
            Return _MyString
        End Get
        Set(ByVal value As String)
            WriteValueToDatabase("MyString", value)
        End Set
    End Property


    '***************************************************************************
    Public Shared Property MyInteger() As Integer
        Get
            If _MyInteger = Nothing Then _
                _MyInteger = _
                  CInt(ReadValueFromDatabase("MyInteger"))
            Return _MyInteger
        End Get
        Set(ByVal value As Integer)
            WriteValueToDatabase("MyString", CStr(value))
        End Set
    End Property


    '***************************************************************************
    Public Shared Property MyDateTime() As Date
        Get
            If _MyDateTime = Nothing Then _
                _MyDateTime = _
                  CDate(ReadValueFromDatabase("MyDateTime"))
            Return _MyDateTime
        End Get
        Set(ByVal value As Date)
            WriteValueToDatabase("MyString", CStr(value))
        End Set
    End Property


    '***************************************************************************
    Public Shared Property MyBoolean() As Boolean
        Get
            If _MyBoolean = Nothing Then _
                _MyBoolean = _
                  CBool(ReadValueFromDatabase("MyBoolean"))
            Return _MyBoolean
        End Get
        Set(ByVal value As Boolean)
            WriteValueToDatabase("MyString", CStr(value))
        End Set
    End Property


    '***************************************************************************
    Private Shared Function SerializeToXML(ByVal Obj As Object) As String
        Try
            Dim sf As New SoapFormatter()
            Dim ms As New MemoryStream
            sf.Serialize(ms, Obj)
            Dim ascEncoding As New System.Text.ASCIIEncoding()
            Return ascEncoding.GetString(ms.GetBuffer)
        Catch
            Return String.Empty
        End Try
    End Function


    '***************************************************************************
    Private Shared Function DeserializeFromXML(ByVal XML As String) As Object
        Try
            Dim ascEncoding As New System.Text.ASCIIEncoding()
            Dim ms As New MemoryStream(ascEncoding.GetBytes(XML))
            Dim sf As New SoapFormatter
            Return sf.Deserialize(ms)
        Catch
            Return Nothing
        End Try
    End Function


    '***************************************************************************
    Public Shared Property MyPrimeList() As ArrayList
        Get
            If _MyPrimeList Is Nothing Then
                Dim XML As String = ReadValueFromDatabase("MyPrimeList")
                If Not XML = String.Empty Then
                    _MyPrimeList = CType(DeserializeFromXML(XML), ArrayList)
                End If
            End If
            If _MyPrimeList Is Nothing Then _MyPrimeList = New ArrayList()
            Return _MyPrimeList
        End Get
        Set(ByVal value As ArrayList)
            _MyPrimeList = value
            SaveMyPrimeList()
        End Set
    End Property


    '***************************************************************************
    Public Shared Sub SaveMyPrimeList()
        WriteValueToDatabase("MyPrimeList", SerializeToXML(_MyPrimeList))
    End Sub

End Class
