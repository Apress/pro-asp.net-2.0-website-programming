Imports System.Web
Imports System.Web.UI

Public Class ContentManagementHandler
    Implements IHttpHandler

    '******************************************************************************
    Public ReadOnly Property IsReusable() As Boolean _
      Implements System.Web.IHttpHandler.IsReusable
        Get
            Return True
        End Get
    End Property

    '******************************************************************************
    Private Function GetVirtualPage(ByVal context As HttpContext) As String
        Return context.Request.Path.Replace( _
                context.Request.ApplicationPath & "/ContentManagement/", "")
    End Function

    '******************************************************************************
    Public Sub ProcessRequest(ByVal context As System.Web.HttpContext) _
      Implements System.Web.IHttpHandler.ProcessRequest

        'Store the virtual page value in context
        context.Items("VirtualPage") = GetVirtualPage(context)

        'Acquire the Front Controller HTTP Handler
        Dim FrontController As IHttpHandler = _
          PageParser.GetCompiledPageInstance( _
          "~/ContentManagement/FrontController.aspx", Nothing, context)

        'Rewrite the path and allow the Front Controller to Process the Request
        context.RewritePath("ContentManagement/FrontController.aspx")
        FrontController.ProcessRequest(context)

    End Sub

End Class
