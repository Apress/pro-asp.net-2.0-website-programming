
Partial Class ReportB
    Inherits System.Web.UI.Page

    '******************************************************************************
    Private ReadOnly Property ReportDate() As Date
        Get
            If IsDate(Context.Items("Date")) Then
                Return CDate(Context.Items("Date"))
            Else
                Return Now()
            End If
        End Get
    End Property

    '******************************************************************************
    Private ReadOnly Property Room() As String
        Get
            If CStr(Context.Items("Room")) = String.Empty Then
                Return "Unknown Room"
            Else
                Return CStr(Context.Items("Room"))
            End If
        End Get
    End Property

    '******************************************************************************
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.ContentType = "application/vnd.ms-excel"        
        Me.lblReportDate.Text = Format(ReportDate, "MM/dd/yyyy")
        Me.lblRoomName.Text = Room
    End Sub

End Class
