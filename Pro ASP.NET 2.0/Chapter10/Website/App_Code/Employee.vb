Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports Data

Public Class Employee

    '***************************************************************************
    Private _employeeID As Integer
    Private _lastName As String
    Private _firstName As String
    Private _title As String
    Private _titleOfCourtesy As String
    Private _birthDate As Date
    Private _hireDate As Date
    Private _address As String
    Private _city As String
    Private _region As String
    Private _postalCode As String
    Private _country As String
    Private _homePhone As String
    Private _extension As String
    Private _notes As String

#Region "Fields"

    '***************************************************************************
    Public Property EmployeeID() As Integer
        Get
            Return _employeeID
        End Get
        Set(ByVal value As Integer)
            _employeeID = value
        End Set
    End Property

    '***************************************************************************
    Public Property LastName() As String
        Get
            Return _lastName
        End Get
        Set(ByVal value As String)
            _lastName = value
        End Set
    End Property

    '***************************************************************************
    Public Property FirstName() As String
        Get
            Return _firstName
        End Get
        Set(ByVal value As String)
            _firstName = value
        End Set
    End Property

    '***************************************************************************
    Public Property Title() As String
        Get
            Return _title
        End Get
        Set(ByVal value As String)
            _title = value
        End Set
    End Property

    '***************************************************************************
    Public Property TitleOfCourtesy() As String
        Get
            Return _titleOfCourtesy
        End Get
        Set(ByVal value As String)
            _titleOfCourtesy = value
        End Set
    End Property

    '***************************************************************************
    Public Property BirthDate() As Date
        Get
            Return _birthDate
        End Get
        Set(ByVal value As Date)
            _birthDate = value
        End Set
    End Property

    '***************************************************************************
    Public Property HireDate() As Date
        Get
            Return _hireDate
        End Get
        Set(ByVal value As Date)
            _hireDate = value
        End Set
    End Property

    '***************************************************************************
    Public Property Address() As String
        Get
            Return _address
        End Get
        Set(ByVal value As String)
            _address = value
        End Set
    End Property

    '***************************************************************************
    Public Property City() As String
        Get
            Return _city
        End Get
        Set(ByVal value As String)
            _city = value
        End Set
    End Property

    '***************************************************************************
    Public Property Region() As String
        Get
            Return _region
        End Get
        Set(ByVal value As String)
            _region = value
        End Set
    End Property

    '***************************************************************************
    Public Property PostalCode() As String
        Get
            Return _postalCode
        End Get
        Set(ByVal value As String)
            _postalCode = value
        End Set
    End Property

    '***************************************************************************
    Public Property Country() As String
        Get
            Return _country
        End Get
        Set(ByVal value As String)
            _country = value
        End Set
    End Property

    '***************************************************************************
    Public Property HomePhone() As String
        Get
            Return _homePhone
        End Get
        Set(ByVal value As String)
            _homePhone = value
        End Set
    End Property

    '***************************************************************************
    Public Property Extension() As String
        Get
            Return _extension
        End Get
        Set(ByVal value As String)
            _extension = value
        End Set
    End Property

    '***************************************************************************
    Public Property Notes() As String
        Get
            Return _notes
        End Get
        Set(ByVal value As String)
            _notes = value
        End Set
    End Property

#End Region

    '***************************************************************************
    Public Sub PopulateObject(ByVal DR As SqlDataReader)
        EmployeeID = GetInteger(DR("EmployeeID"))
        LastName = GetString(DR("LastName"))
        FirstName = GetString(DR("FirstName"))
        Title = GetString(DR("Title"))
        TitleOfCourtesy = GetString(DR("TitleOfCourtesy"))
        BirthDate = GetDate(DR("BirthDate"))
        HireDate = GetDate(DR("HireDate"))
        Address = GetString(DR("Address"))
        City = GetString(DR("City"))
        Region = GetString(DR("Region"))
        PostalCode = GetString(DR("PostalCode"))
        Country = GetString(DR("Country"))
        HomePhone = GetString(DR("HomePhone"))
        Extension = GetString(DR("Extension"))
        Notes = GetString(DR("Notes"))
    End Sub

    '***************************************************************************
    Public Function Add() As Boolean

        Dim SQL As String

        SQL = "INSERT INTO [Employees] (" & _
              "   LastName, FirstName, Title, " & _
              "   TitleOfCourtesy, BirthDate, HireDate, Address, " & _
              "   City, Region, PostalCode, Country, HomePhone, " & _
              "   Extension, Notes) " & _
              " VALUES (" & _
              "   @LastName, @FirstName, @Title, " & _
              "   @TitleOfCourtesy, @BirthDate, @HireDate, @Address, " & _
              "   @City, @Region, @PostalCode, @Country, @HomePhone, " & _
              "   @Extension, @Notes)"

        Dim conn As SqlConnection = GetOpenConnection()

        Dim cmd As New SqlCommand(SQL, conn)
        cmd.Parameters.Add("@LastName", VarChar).Value = LastName
        cmd.Parameters.Add("@FirstName", VarChar).Value = FirstName
        cmd.Parameters.Add("@Title", VarChar).Value = Title
        cmd.Parameters.Add("@TitleOfCourtesy", VarChar).Value = TitleOfCourtesy
        cmd.Parameters.Add("@BirthDate", DateTime).Value = CheckNullDate(BirthDate)
        cmd.Parameters.Add("@HireDate", DateTime).Value = CheckNullDate(HireDate)
        cmd.Parameters.Add("@Address", VarChar).Value = Address
        cmd.Parameters.Add("@City", VarChar).Value = City
        cmd.Parameters.Add("@Region", VarChar).Value = Region
        cmd.Parameters.Add("@PostalCode", VarChar).Value = PostalCode
        cmd.Parameters.Add("@Country", VarChar).Value = Country
        cmd.Parameters.Add("@HomePhone", VarChar).Value = HomePhone
        cmd.Parameters.Add("@Extension", VarChar).Value = Extension
        cmd.Parameters.Add("@Notes", VarChar).Value = Notes

        cmd.ExecuteNonQuery()
        cmd.CommandText = "SELECT @@IDENTITY;"
        Me.EmployeeID = CInt(cmd.ExecuteScalar())
        conn.Close()

    End Function

    '***************************************************************************
    Private Function CheckNullDate(ByVal checkDate As Date) As Object
        If checkDate = Nothing Then
            Return DBNull.Value
        Else
            Return checkDate
        End If
    End Function

    '***************************************************************************
    Private Shared Function GetEmployeeBySQL(ByVal SQL As String) _
      As Employee

        Dim conn As SqlConnection = GetOpenConnection()
        Dim cmd As New SqlCommand(SQL, conn)
        Dim dr As SqlDataReader = cmd.ExecuteReader()
        Dim EmployeeObj As Employee = Nothing

        If dr.Read Then
            EmployeeObj = New Employee
            EmployeeObj.PopulateObject(dr)
        End If

        conn.Close()

        Return EmployeeObj

    End Function

    '***************************************************************************
    Public Shared Function GetEmployeeById(ByVal EmployeeID As Integer) _
        As Employee

        Dim SQL As String = "SELECT * FROM [Employees] WHERE " & _
                            "[EmployeeID]=" & EmployeeID & ";"
        Return GetEmployeeBySQL(SQL)

    End Function

End Class
