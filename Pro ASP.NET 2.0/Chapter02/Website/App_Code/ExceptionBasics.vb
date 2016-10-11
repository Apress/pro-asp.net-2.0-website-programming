Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class ExceptionBasics

    '***************************************************************************
    Public Shared Function IntegerDivide(ByVal N As Long, ByVal D As Long) As Long
        Try
            Dim ReturnValue As Long
            ReturnValue = (N \ D)
            Return ReturnValue
        Catch ex As Exception
            '-------------------------------------------------------------------
            ' Return 0 if an error occurs.
            '-------------------------------------------------------------------
            Return 0
        End Try
    End Function


    '***************************************************************************
    Public Shared Function AddTwoNumbers(ByVal x As Long, ByVal y As Long) As Long
        Try
            Return x + y
        Catch ex As Exception
            Return 0
        End Try
    End Function


    '***************************************************************************
    Public Shared Function ReadFile(ByVal FileAndPath As String, _
                                    ByRef ErrorInfo As String) As String

        Try
            Dim SR As New System.IO.StreamReader(FileAndPath)
            Dim FileContent As String = SR.ReadToEnd()
            SR.Close()
            Return FileContent

        Catch dirEx As System.IO.DirectoryNotFoundException
            ErrorInfo = "The directory was not found"
            Return String.Empty

        Catch fileEx As System.IO.FileNotFoundException
            ErrorInfo = "The file was not found"
            Return String.Empty

        Catch ioEx As System.IO.IOException
            ErrorInfo = "There was an IO Exception: " & ioEx.Message
            Return String.Empty

        Catch ex As Exception
            ErrorInfo = "There was an Exception: " & ex.Message
            Return String.Empty

        End Try

    End Function


    '***************************************************************************
    Public Shared Sub BadCatchExample()
        Try
            Throw New System.IO.IOException()
        Catch ex As Exception
            'Run Exception Handling
        Catch ioEx As System.IO.IOException
            'Run IOException Handling
        End Try
    End Sub


    '***************************************************************************
    Public Shared Sub WhenExample(ByRef ErrorMsg As String)
        Try
            Dim dbConn As New SqlConnection(Config.MyConnectionString)
            Dim SQL As String = "SELECT asdf FROM [settings]"
            Dim dbCmd As New System.Data.SqlClient.SqlCommand(SQL, dbConn)
            Dim dbDr As SqlDataReader

            dbConn.Open()
            dbDr = dbCmd.ExecuteReader()
            dbConn.Close()

        Catch ex As SqlException When InStr(ex.Message, "The ConnectionString ") > 0
            ErrorMsg = "You did not initialize the connection string."

        Catch ex As SqlException When InStr(ex.Message, "Login failed") > 0
            ErrorMsg = "Your login information was invalid."

        Catch ex As SqlException When InStr(ex.Message, "Invalid object") > 0
            ErrorMsg = "You referenced a non-existant table, view,  etc."

        Catch ex As SqlException When InStr(ex.Message, "Invalid column") > 0
            ErrorMsg = "You referenced a non-existant column."

        Catch ex As Exception
            ErrorMsg = "An exception occurred: " & ex.Message

        End Try

    End Sub


    '***************************************************************************
    Public Shared Function FinallyExample() As Object

        Dim dbConn As SqlConnection = Nothing
        Dim SQL As String = "SELECT Count(*) FROM [settings];"
        Dim dbCmd As SqlCommand = Nothing

        Try
            dbConn = New SqlConnection(Config.MyConnectionString)
            dbCmd = New System.Data.SqlClient.SqlCommand(SQL, dbConn)
            dbConn.Open()
            Return dbCmd.ExecuteScalar()
        Catch ex As Exception
            Return 0
        Finally
            'The following line will ALWAYS be executed.
            If Not dbConn Is Nothing Then dbConn.Close()
        End Try

    End Function


    '***************************************************************************
    Public Shared Function GetObjectName(ByVal obj As Object) As String
        If obj Is Nothing Then _
            Throw New ArgumentNullException("The obj parameter cannot be nothing")
        Return obj.GetType.ToString()
    End Function

    '***************************************************************************
    Public Shared Sub ThrowLogAndReThrow()
        Try
            Throw New Exception("Force an exception")
        Catch ex As Exception
            'Place logging code here...
            Throw
        End Try
    End Sub


#Region "Custom Exception Class Example"

    '***************************************************************************
    Public Class NegativeNumberSimple
        Inherits Exception

        Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub

        Sub New(ByVal message As String, ByVal innerException As Exception)
            MyBase.New(message, innerException)
        End Sub

    End Class


    '***************************************************************************
    Public Class NegativeNumberException
        Inherits System.Exception

        Public NegativeNumber As Double
        Public Parameter As String

        Public Sub New(ByVal Parameter As String, ByVal NegativeNumber As Double)
            Me.NegativeNumber = NegativeNumber
            Me.Parameter = Parameter
        End Sub

        Public Overrides ReadOnly Property Message() As String
            Get
                Return String.Format("Negative Number {0} specified for {1}", _
                                      NegativeNumber, Parameter)
            End Get
        End Property

    End Class



    '***************************************************************************
    Public Shared Function CalculateSalary(ByVal Rate As Double, _
                                           ByVal Hours As Double) As Double

        If Rate < 0 Then Throw New NegativeNumberException("Rate", Rate)
        If Hours < 0 Then Throw New NegativeNumberException("Hours", Hours)
        Return Rate * Hours        

    End Function

    '***************************************************************************
    Public Function GetSalary() As String
        Try
            Return "Your salary is " & CalculateSalary(-100, 10).ToString()
        Catch ex As NegativeNumberException
            Select Case ex.Parameter
                Case "Rate"
                    Return "You may want to check your rates!"
                Case "Hours"
                    Return "You may want to check your hours!"
                Case Else
                    Return "Your salary could not be calculated!"
            End Select
        End Try
    End Function




#End Region


#Region "Error Propogation Example"

    '***************************************************************************
    Public Function A() As String
        Try
            Return "Diamonds" & B()
        Catch ex As Exception
            Return ex.Message & " (and handled in the A Function)"
        End Try
    End Function

    '***************************************************************************
    Public Function B() As String
        Return "are " & C()
    End Function

    '***************************************************************************
    Public Function C() As String
        Throw New Exception("Exception Thrown from the C Function")
        Return "forever."
    End Function

#End Region


End Class