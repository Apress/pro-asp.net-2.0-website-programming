
Partial Class DateTimeWebPart
    Inherits WebPartUserControl

    '***************************************************************************
    Public Enum TimeFormatEnum
        StandardTime
        TwentyFourHour
    End Enum

    '***************************************************************************
    Private _ShowDate As Boolean = True
    Private _ShowTime As Boolean = True
    Private _DateFormat As String = "M/dd/yyyy"
    Private _TimeFormat As TimeFormatEnum = TimeFormatEnum.StandardTime
    Private _DatePrefix As String = "Date: "
    Private _TimePrefix As String = "Time: "

#Region "Mustoverride Functions from WebPartUserControl"

    '***************************************************************************
    Public Overrides Function DefaultCatalogIconImageUrl() As String
        Return "~/images/ClockIcon.gif"
    End Function

    '***************************************************************************
    Public Overrides Function DefaultDescription() As String
        Return "Example web part that displays the date and time"
    End Function

    '***************************************************************************
    Public Overrides Function DefaultSubTitle() As String
        Return String.Empty
    End Function

    '***************************************************************************
    Public Overrides Function DefaultTitle() As String
        Return "Date and Time (UserControl)"
    End Function

    '***************************************************************************
    Public Overrides Function DefaultTitleIconImageUrl() As String
        Return "~/images/ClockIcon.gif"
    End Function

    '***************************************************************************
    Public Overrides Function DefaultTitleUrl() As String
        Return String.Empty
    End Function

#End Region

    '***************************************************************************
    <Personalizable(PersonalizationScope.User, False), _
     WebBrowsable(), WebDisplayName("Show the Date"), _
     WebDescription("Determines whether or not to display the current date")> _
    Public Property ShowDate() As Boolean
        Get
            Return _ShowDate
        End Get
        Set(ByVal value As Boolean)
            _ShowDate = value
        End Set
    End Property

    '***************************************************************************
    <Personalizable(PersonalizationScope.User, False), _
     WebBrowsable(), WebDisplayName("Show the Time"), _
     WebDescription("Determines whether or not to display the current time")> _
    Public Property ShowTime() As Boolean
        Get
            Return _ShowTime
        End Get
        Set(ByVal value As Boolean)
            _ShowTime = value
        End Set
    End Property

    '***************************************************************************
    <Personalizable(PersonalizationScope.User, False), _
     WebBrowsable(), WebDisplayName("Date Format String"), _
     WebDescription("Formatting string used to display the current date")> _
    Public Property DateFormat() As String
        Get
            Return _DateFormat
        End Get
        Set(ByVal value As String)
            Try
                Format(Now, value)
            Catch ex As Exception
                Exit Property
            End Try
            _DateFormat = value
        End Set
    End Property

    '***************************************************************************
    <Personalizable(PersonalizationScope.User, False), _
     WebBrowsable(), WebDisplayName("Time Format"), _
     WebDescription("Determines whether to display normal or 24-hour format")> _
    Public Property TimeFormat() As TimeFormatEnum
        Get
            Return _TimeFormat
        End Get
        Set(ByVal value As TimeFormatEnum)
            _TimeFormat = value
        End Set
    End Property

    '***************************************************************************
    <Personalizable(PersonalizationScope.User, False), _
     WebBrowsable(), WebDisplayName("Date Prefix"), _
     WebDescription("Prefix that appears before the date display")> _
    Public Property DatePrefix() As String
        Get
            Return _DatePrefix
        End Get
        Set(ByVal value As String)
            _DatePrefix = value
        End Set
    End Property

    '***************************************************************************
    <Personalizable(PersonalizationScope.User, False), _
     WebBrowsable(), WebDisplayName("Time Prefix"), _
     WebDescription("Prefix that appears before the time display")> _
    Public Property TimePrefix() As String
        Get
            Return _TimePrefix
        End Get
        Set(ByVal value As String)
            _TimePrefix = value
        End Set
    End Property

    '***************************************************************************
    Protected Sub Page_Load(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles Me.Load

        If WebPartData.HelpUrl = String.Empty Then _
            WebPartData.HelpUrl = "~/Help/DateDisplayWebPart.htm"
        WebPartData.ExportMode = WebPartExportMode.NonSensitiveData

    End Sub

    '***************************************************************************
    Protected Sub Page_PreRender(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles Me.PreRender

        If ShowDate Then
            Me.lblDate.Text = DatePrefix & Format(Now, DateFormat)
        Else
            Me.lblDate.Visible = False
        End If

        If ShowTime Then
            Select Case TimeFormat
                Case TimeFormatEnum.TwentyFourHour
                    Me.lblTime.Text = TimePrefix & Format(Now, "HH:mm")
                Case TimeFormatEnum.StandardTime
                    Me.lblTime.Text = TimePrefix & Format(Now, "hh:mm tt")
            End Select
            If ShowDate Then lblTime.Text = "<BR>" & lblTime.Text
        Else
            Me.lblTime.Visible = False
        End If

    End Sub

End Class
