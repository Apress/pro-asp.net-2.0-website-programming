
Partial Class ReportC
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
    Private ReadOnly Property Employee() As String
        Get
            If CStr(Context.Items("Employee")) = String.Empty Then
                Return "Unknown Employee"
            Else
                Return CStr(Context.Items("Employee"))
            End If
        End Get
    End Property

    '******************************************************************************
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.ContentType = "application/vnd.ms-excel"        
        Me.lblReportDate.Text = Format(ReportDate, "MM/dd/yyyy")
        Me.lblEmployeeName.Text = Employee
    End Sub

End Class
