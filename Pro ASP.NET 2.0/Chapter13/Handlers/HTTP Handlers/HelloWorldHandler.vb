Imports System.Web

Public Class HelloWorldHandler
    Implements IHttpHandler, SessionState.IRequiresSessionState

    '***************************************************************************
    Public Sub ProcessRequest(ByVal context As HttpContext) _
      Implements IHttpHandler.ProcessRequest
        
        context.Response.Write("<HTML><BODY><H1>Hello World!</H1><HR>" & _
                               "This content was output by an HTTP Handler " & _
                               "for the .hello file type.<BODY></HTML>")
    End Sub


    '***************************************************************************
    Public ReadOnly Property IsReusable() As Boolean _
      Implements IHttpHandler.IsReusable
        Get
            Return True
        End Get
    End Property

End Class
