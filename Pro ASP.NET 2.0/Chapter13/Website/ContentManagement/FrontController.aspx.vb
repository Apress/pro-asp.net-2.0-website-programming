Imports System
Imports System.Configuration.ConfigurationManager
Imports System.Data.SqlClient

Partial Class FrontController
    Inherits Web.UI.Page

    '******************************************************************************
    Private _PageID As Long
    Private _Title As String
    Private _MasterPage As String

    '******************************************************************************
    Private Function SqlString(ByVal text As String) As String
        Return text.Replace("'", "''")
    End Function

    '******************************************************************************
    Private Function AcquirePageInfo() As Boolean

        Dim DbConn As SqlConnection
        Dim SQL As String
        Dim DbCmd As SqlCommand
        Dim Dr As SqlDataReader

        DbConn = New SqlConnection(ConnectionStrings("Database").ConnectionString)

        'Create SQL command and setup parameters
        SQL = "SELECT * FROM [Pages] WHERE [Location]=@Location;"
        DbCmd = New SqlCommand(SQL, DbConn)
        DbCmd.Parameters.Add("@Location", Data.SqlDbType.VarChar).Value = _
          Context.Items("VirtualPage")

        DbConn.Open()
        Dr = DbCmd.ExecuteReader()
        If Dr.Read Then
            _PageID = CLng(Dr("PageID"))
            _Title = CStr(Dr("Title"))
            _MasterPage = CStr(Dr("MasterPage"))
            AcquirePageInfo = True
        Else
            AcquirePageInfo = False
        End If        
        DbConn.Close()

    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
        
    '******************************************************************************
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs) _
      Handles Me.PreInit

        'Acquire the page info and setup the master page
        If AcquirePageInfo() Then
            Me.MasterPageFile = "~/ContentManagement/Master Pages/" & _MasterPage
            Me.Title = _Title
        Else
            'If the page is not found in the database, send a 404 error
            Response.StatusCode = 404
            Response.End()
        End If

    End Sub

    '******************************************************************************
    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As EventArgs) _
      Handles Me.PreLoad        
        LoadPageContent()
    End Sub

    '******************************************************************************
    Private Sub SetupBreakLiteral(ByVal lit As Literal, ByVal Count As Integer)        
        For index As Integer = 1 To Count
            lit.Text &= "<br />"
        Next
    End Sub

    '******************************************************************************
    Public Sub LoadPageContent()

        Dim CPH As ContentPlaceHolder
        Dim DbConn As SqlConnection
        Dim SQL As String
        Dim DbCmd As SqlCommand
        Dim Dr As SqlDataReader

        'Create database connection
        DbConn = New SqlConnection(ConnectionStrings("Database").ConnectionString)

        'Create SQL command and setup parameters
        SQL = "SELECT * FROM [Content] WHERE [PageID]=@PageID " & _
              "ORDER BY [Area],[Position];"
        DbCmd = New SqlCommand(SQL, DbConn)
        DbCmd.Parameters.Add("@PageID", Data.SqlDbType.Int).Value = _PageID

        'Open database and execute command
        DbConn.Open()
        Dr = DbCmd.ExecuteReader()

        While Dr.Read

            'Store data reader values in strongly typed variables
            Dim ContentType As String = CStr(Dr("Type"))
            Dim ContentArea As Integer = CInt(Dr("Area"))
            Dim ContentParams As String = CStr(Dr("Parameters"))
            Dim ContentBreaksAfter As Integer = CInt(Dr("BreaksAfter"))
            Dim Params As String() = Split(ContentParams, "|")

            'Locate the ContentPlaceHolder into which the content should be loaded
            CPH = CType(Master.FindControl("Area" & ContentArea), _
                 ContentPlaceHolder)

            'Only load the content if the ContentPlaceHolder control is located
            If Not CPH Is Nothing Then

                Select Case UCase(ContentType)

                    Case "TITLE"
                        Dim lbl As New Label
                        lbl.Font.Bold = True
                        lbl.Font.Underline = True
                        lbl.Font.Size = WebControls.FontUnit.Point(12)
                        If Params.Length > 0 Then lbl.Text = Params(0)
                        CPH.Controls.Add(lbl)
                        If ContentBreaksAfter > 0 Then
                            Dim lit As New Literal
                            SetupBreakLiteral(lit, ContentBreaksAfter)
                            CPH.Controls.Add(lit)
                        End If

                    Case "PARAGRAPH"
                        Dim lbl As New Label()
                        If Params.Length > 0 Then lbl.Text = Params(0)
                        CPH.Controls.Add(lbl)
                        Dim lit As New Literal
                        SetupBreakLiteral(lit, ContentBreaksAfter)
                        CPH.Controls.Add(lit)

                    Case "HYPERLINK"
                        Dim hlnk As New HyperLink()
                        If Params.Length > 0 Then hlnk.Text = Params(0)
                        If Params.Length > 1 Then hlnk.NavigateUrl = Params(1)
                        CPH.Controls.Add(hlnk)
                        If ContentBreaksAfter > 0 Then
                            Dim lit As New Literal
                            SetupBreakLiteral(lit, ContentBreaksAfter)
                            CPH.Controls.Add(lit)
                        End If

                    Case "IMAGE"
                        Dim img As New Image()
                        If Params.Length > 0 Then img.ImageUrl = Params(0)
                        CPH.Controls.Add(img)
                        If ContentBreaksAfter > 0 Then
                            Dim lit As New Literal
                            SetupBreakLiteral(lit, ContentBreaksAfter)
                            CPH.Controls.Add(lit)
                        End If

                    Case "LINKIMAGE"
                        Dim hlnk As New HyperLink()
                        If Params.Length > 0 Then hlnk.ImageUrl = Params(0)
                        If Params.Length > 1 Then hlnk.NavigateUrl = Params(1)
                        CPH.Controls.Add(hlnk)
                        If ContentBreaksAfter > 0 Then
                            Dim lit As New Literal
                            SetupBreakLiteral(lit, ContentBreaksAfter)
                            CPH.Controls.Add(lit)
                        End If

                    Case "USERCONTROL"
                        If Params.Length > 0 Then
                            Dim ctrl As UserControl = CType(LoadControl( _
                              "~/ContentManagement/UserControls/" & Params(0)), _
                              UserControl)
                            CPH.Controls.Add(ctrl)
                            If ContentBreaksAfter > 0 Then
                                Dim lit As New Literal
                                SetupBreakLiteral(lit, ContentBreaksAfter)
                                CPH.Controls.Add(lit)
                            End If
                        End If

                End Select

            End If

        End While

        Dr.Close()
        DbConn.Close()        

    End Sub

End Class
