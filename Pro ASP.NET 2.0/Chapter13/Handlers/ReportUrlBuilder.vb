Imports System.Web
Imports System.Web.UI

Public Class ReportUrlBuilder

    '******************************************************************************
    Public Shared Function GetReportAPath(ByVal ReportDate As Date) As String

        Return String.Format("XlsReports/ReportA/{0}/WebStats.{1}.xls", _
            Format(ReportDate, "yyyy-MM-dd"), _
            Format(ReportDate, "yyyy.MM.dd"))
    End Function

    '******************************************************************************
    Public Shared Function GetReportBPath(ByVal Room As String, _
                                    ByVal ReportDate As Date) As String

        Return String.Format("XlsReports/ReportB/{0}/{1}/{0}.{2}.xls", _
            Room, _
            Format(ReportDate, "yyyy-MM-dd"), _
            Format(ReportDate, "yyyy.MM.dd"))
    End Function

    '******************************************************************************
    Public Shared Function GetReportCPath(ByVal Employee As String, _
                                    ByVal ReportDate As Date) As String

        Return String.Format("XlsReports/ReportB/{0}/{1}/{0}.{2}.xls", _
            Employee, _
            Format(ReportDate, "yyyy-MM-dd"), _
            Format(ReportDate, "yyyy.MM.dd"))
    End Function


End Class
