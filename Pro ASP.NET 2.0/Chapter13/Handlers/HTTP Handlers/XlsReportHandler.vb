Imports System.Web
Imports System.Web.UI

Public Class XlsReportHandler
    Implements IHttpHandler

    '******************************************************************************
    Private ReadOnly Property IsReusable() As Boolean _
      Implements System.Web.IHttpHandler.IsReusable
        Get
            Return True
        End Get
    End Property

    '******************************************************************************
    Private Function GetReportName(ByVal UrlParts As String()) As String
        For index As Integer = 0 To UrlParts.Length - 1
            If UCase(UrlParts(index)) = "XLSREPORTS" Then
                If index < UrlParts.Length - 1 Then
                    Return UrlParts(index + 1)
                End If
            End If
        Next
        Return ""
    End Function

    '******************************************************************************
    Private Sub ProcessRequest(ByVal context As System.Web.HttpContext) _
      Implements System.Web.IHttpHandler.ProcessRequest

        Dim ReportHandler As IHttpHandler = Nothing
        Dim UrlParts As String() = Split(context.Request.Path, "/")

        Select Case GetReportName(UrlParts)
            Case "ReportA"
                '===============================================================
                Try
                    context.Items("Date") = CDate(UrlParts(UrlParts.Length - 2))
                    context.RewritePath("~/XlsReports/ReportA.aspx")
                    ReportHandler = PageParser.GetCompiledPageInstance( _
                      "~/XlsReports/ReportA.aspx", Nothing, context)

                Catch ex As Exception
                    ReportHandler = PageParser.GetCompiledPageInstance( _
                      "~/XlsReports/Invalid.aspx", Nothing, context)
                End Try

            Case "ReportB"
                '===============================================================
                Try
                    Dim Room As String = UrlParts(UrlParts.Length - 3)
                    Dim ReportDate As Date = CDate(UrlParts(UrlParts.Length-2))

                    context.Items("Room") = UrlParts(UrlParts.Length - 3)
                    context.Items("Date") = CDate(UrlParts(UrlParts.Length - 2))
                    context.RewritePath("~/XlsReports/ReportB.aspx")
                    ReportHandler = PageParser.GetCompiledPageInstance( _
                      "~/XlsReports/ReportB.aspx", Nothing, context)

                Catch ex As Exception
                    ReportHandler = PageParser.GetCompiledPageInstance( _
                      "~/XlsReports/Invalid.aspx", Nothing, context)
                End Try

            Case "ReportC"
                '===============================================================
                Try
                    context.Items("Employee") = UrlParts(UrlParts.Length - 3)
                    context.Items("Date") = CDate(UrlParts(UrlParts.Length - 2))
                    context.RewritePath("~/XlsReports/ReportC.aspx")
                    ReportHandler = PageParser.GetCompiledPageInstance( _
                      "~/XlsReports/ReportC.aspx", Nothing, context)

                Catch ex As Exception
                    ReportHandler = PageParser.GetCompiledPageInstance( _
                      "~/XlsReports/Invalid.aspx", Nothing, context)
                End Try

            Case Else 'Invalid report requested
                '===============================================================                
                ReportHandler = PageParser.GetCompiledPageInstance( _
                  "~/XlsReports/Invalid.aspx", Nothing, context)

        End Select

        ReportHandler.ProcessRequest(context)

    End Sub

End Class
