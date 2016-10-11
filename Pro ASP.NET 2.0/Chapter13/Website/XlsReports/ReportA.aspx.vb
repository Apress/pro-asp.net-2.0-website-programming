
Partial Class ReportA
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
      Handles Me.Load
        Response.ContentType = "application/vnd.ms-excel"
        Me.lblReportDate.Text = Format(ReportDate, "MM/dd/yyyy")

    End Sub

End Class
