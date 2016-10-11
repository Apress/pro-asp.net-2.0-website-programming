
Partial Class RequestReport
    Inherits System.Web.UI.Page

    '******************************************************************************
    Private Function GetReportAPath(ByVal ReportDate As Date) As String

        Return String.Format("XlsReports/ReportA/{0}/WebStats.{1}.xls", _
                             Format(ReportDate, "yyyy-MM-dd"), _
                             Format(ReportDate, "yyyy.MM.dd"))
    End Function

    '******************************************************************************
    Private Function GetReportBPath(ByVal Room As String, _
                                    ByVal ReportDate As Date) As String
        
        Return String.Format("XlsReports/ReportB/{0}/{1}/{0}.{2}.xls", _
                             Room, _
                             Format(ReportDate, "yyyy-MM-dd"), _
                             Format(ReportDate, "yyyy.MM.dd"))
    End Function

    '******************************************************************************
    Private Function GetReportCPath(ByVal Employee As String, _
                                    ByVal ReportDate As Date) As String

        Return String.Format("XlsReports/ReportB/{0}/{1}/{0}.{2}.xls", _
                             Employee, _
                             Format(ReportDate, "yyyy-MM-dd"), _
                             Format(ReportDate, "yyyy.MM.dd"))
    End Function


    '******************************************************************************
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
      Handles Me.Load

        If Not Page.IsPostBack Then
            Me.txtReportADate.Text = Format(Now, "MM/dd/yyyy")
            Me.txtRoom.Text = "Conference Room"
            Me.txtReportBDate.Text = Format(Now, "MM/dd/yyyy")
            Me.txtEmployee.Text = "Nick Reed"
            Me.txtReportCDate.Text = Format(Now, "MM/dd/yyyy")

        End If

        'Setup Hyperlinks
        Me.hlnkReportA.NavigateUrl = GetReportAPath(Now())
        Me.hlnkReportA.Text = Me.hlnkReportA.NavigateUrl
        Me.hlnkReportB.NavigateUrl = GetReportBPath("Conference Room", Now())
        Me.hlnkReportB.Text = Me.hlnkReportB.NavigateUrl
        Me.hlnkReportC.NavigateUrl = GetReportCPath("Nick Reed", Now())
        Me.hlnkReportC.Text = Me.hlnkReportC.NavigateUrl

    End Sub

    '******************************************************************************
    Private ReadOnly Property ReportADate() As Date
        Get
            Return CDate(txtReportADate.Text)
        End Get
    End Property

    '******************************************************************************
    Protected Sub btnGetReportA_Click(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles btnGetReportA.Click

        Response.Redirect(GetReportAPath(CDate(txtReportADate.Text)))

    End Sub

    '******************************************************************************
    Protected Sub btnGetReportB_Click(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles btnGetReportB.Click

        Response.Redirect(GetReportBPath(txtRoom.Text, CDate(txtReportBDate.Text)))

    End Sub

    '******************************************************************************
    Protected Sub btnGetReportC_Click(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles btnGetReportC.Click

        Response.Redirect(GetReportCPath(txtEmployee.Text, _
          CDate(txtReportCDate.Text)))

    End Sub

End Class
