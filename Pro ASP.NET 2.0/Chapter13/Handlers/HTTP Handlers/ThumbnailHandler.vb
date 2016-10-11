Imports System.Drawing
Imports System.IO
Imports System.Web

Public Class ThumbnailHandler
    Implements IHttpHandler

    '******************************************************************************
    Public ReadOnly Property IsReusable() As Boolean _
      Implements IHttpHandler.IsReusable
        Get
            Return True
        End Get
    End Property

    '******************************************************************************
    Public Sub ProcessRequest(ByVal context As HttpContext) _
      Implements IHttpHandler.ProcessRequest

        'File info objects used to determine file existence and modified dates
        Dim Thumbnail As New FileInfo(context.Server.MapPath(context.Request.Path))
        Dim FullSized As New FileInfo(context.Server.MapPath( _
          context.Request.Path.Replace("/Thumbnails", "/Pictures")))

        'Full-sized version of thumbnail should exit for thumbnail to be returned
        If Not FullSized.Exists Then
            If Thumbnail.Exists Then Thumbnail.Delete()
            Throw New Exception("Full sized image does not exist")
        End If

        'Determine whether or not to create or retrieve the thumbnail
        If Thumbnail.Exists Then
            If FullSized.LastWriteTime > Thumbnail.LastWriteTime Then
                Thumbnail.Delete()
                CreateThumbnail(context, Thumbnail, FullSized)
            Else
                RetrieveThumbnail(Thumbnail, context)
            End If
        Else
            CreateThumbnail(context, Thumbnail, FullSized)
        End If

    End Sub

    '******************************************************************************
    Private Function GetContentType(ByVal FI As FileInfo) As String
        'Returns appropriate content type based on file extension

        Select Case UCase(FI.Extension)            
            Case ".GIF"
                Return "image/gif"
            Case ".JPG", ".JPEG"
                Return "image/jpeg"
            Case Else
                Throw New Exception("Invalid image type")
        End Select

    End Function

    '******************************************************************************
    Private Function GetImageFormat(ByVal FI As FileInfo) As Imaging.ImageFormat
        'Returns appropriate image format based on file extension

        Select Case UCase(FI.Extension)
            Case ".GIF"
                Return Imaging.ImageFormat.Gif
            Case ".JPG", ".JPEG"
                Return Imaging.ImageFormat.Jpeg
            Case Else
                Throw New Exception("Invalid image type")
        End Select

    End Function

    '******************************************************************************
    Private Sub RetrieveThumbnail(ByVal Thumbnail As FileInfo, _
                                 ByVal context As HttpContext)

        Dim img As Image = Image.FromFile(Thumbnail.FullName)
        context.Response.ContentType = GetContentType(Thumbnail)
        img.Save(context.Response.OutputStream, img.RawFormat)
        img.Dispose()

    End Sub

    '******************************************************************************
    Public Function GetSizeMultiplier(ByVal img As Image) As Single
        'Gets size multiplier used to maintain image aspect ratio

        Const MaxWidth As Integer = 150
        Const MaxHeight As Integer = 150

        Dim HeightMultiplier As Single = MaxWidth / img.Width
        Dim WidthMultiplier As Single = MaxHeight / img.Height


        If HeightMultiplier > 1 Then HeightMultiplier = 1
        If WidthMultiplier > 1 Then WidthMultiplier = 1

        If HeightMultiplier < WidthMultiplier Then
            Return HeightMultiplier
        Else
            Return WidthMultiplier
        End If

    End Function

    '******************************************************************************
    Private Sub CreateThumbnail(ByVal context As HttpContext, _
                                ByVal Thumbnail As FileInfo, _
                                ByVal FullSized As FileInfo)

        Dim img As Image = Image.FromFile(FullSized.FullName)
        Dim imgFormat As Imaging.ImageFormat = GetImageFormat(FullSized)
        Dim SizeMultiplier = GetSizeMultiplier(img)

        img = img.GetThumbnailImage(CInt(img.Width * SizeMultiplier), _
                    CInt(img.Height * SizeMultiplier), Nothing, Nothing)
        context.Response.ContentType = GetContentType(Thumbnail)
        img.Save(context.Response.OutputStream, imgFormat)
        If Not Thumbnail.Directory.Exists Then Thumbnail.Directory.Create()
        img.Save(Thumbnail.FullName, imgFormat)
        img.Dispose()

    End Sub

End Class
