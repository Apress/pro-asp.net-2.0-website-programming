Imports SqlExceptionLogging
Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationManager

Partial Class ShowException
    Inherits System.Web.UI.Page

    '***************************************************************************
    Private ExLog As ExceptionLog

    '***************************************************************************
    Private ReadOnly Property ExceptionID() As Integer
        Get
            If IsNumeric(Request.QueryString("ExceptionID")) Then
                Return CInt(Request.QueryString("ExceptionID"))
            Else
                Return 0
            End If
        End Get
    End Property

    '***************************************************************************
    Protected Sub Page_Load(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles Me.Load

        Dim ExChain As ExceptionLogCollection
        Dim dbConn As New SqlConnection( _
          ConnectionStrings("Chapter02").ConnectionString)

        dbConn.Open()

        'Acquire Exception
        ExLog = New ExceptionLog
        ExLog.LoadByID(ExceptionID, dbConn)

        'Acquire Exception Chain
        ExChain = New ExceptionLogCollection
        ExChain.LoadChain(ExLog.ChainID, dbConn)

        dbConn.Close()

        'Populate Form Data
        Me.lblExceptionDate.Text = Format(ExLog.ExceptionDate, "MM/dd/yyyy")
        Me.lblExceptionID.Text = ExLog.ExceptionID.ToString
        Me.lblExceptionType.Text = ExLog.ExceptionType
        Me.lblFormData.Text = ExLog.FormData.Replace(ControlChars.CrLf, "<BR>")
        Me.lblMachineName.Text = ExLog.MachineName
        Me.lblMessage.Text = ExLog.ExceptionMessage
        Me.lblPage.Text = ExLog.Page
        Me.lblQueryStringData.Text = ExLog.QueryStringData.Replace(ControlChars.CrLf, "<BR>")
        Me.lblStackTrace.Text = ExLog.StackTrace.Replace(ControlChars.CrLf, "<BR>")
        Me.lblUserAgent.Text = ExLog.UserAgent
        Me.lblUserID.Text = ExLog.UserID

        'Bind Chain Information
        Me.gridExceptionChain.DataSource = ExChain
        Me.gridExceptionChain.DataBind()

    End Sub

    '***************************************************************************
    Protected Sub gridExceptionChain_RowDataBound(ByVal sender As Object, _
      ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) _
      Handles gridExceptionChain.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim rowData As ExceptionLog = DirectCast(e.Row.DataItem, ExceptionLog)
            If rowData.ExceptionID = ExLog.ExceptionID Then
                e.Row.Style.Add("background-color", "#FFFF99")
            End If
        End If

    End Sub

    '***************************************************************************
    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim dbConn As New SqlConnection( _
          ConnectionStrings("Chapter02").ConnectionString)

        dbConn.Open()
        ExLog.DeleteChain(dbConn)
        dbConn.Close()
        Response.Redirect("ShowExceptionList.aspx")

    End Sub

End Class