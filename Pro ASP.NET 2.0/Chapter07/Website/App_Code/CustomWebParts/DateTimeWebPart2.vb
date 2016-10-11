Imports System.Web.UI.WebControls.WebParts

Namespace CustomWebParts

    Public Class DateTimeWebPart2
        Inherits WebPart

        '***************************************************************************
        Private lblDate As Label
        Private lblTime As Label

#Region "Personalizable Properties"

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

#End Region

        '***************************************************************************
        Sub New()
            CatalogIconImageUrl = "~/images/ClockIcon.gif"
            Description = "Example web part that displays the date and time"
            Title = "Date and Time (Web Part)"
            TitleIconImageUrl = "~/images/ClockIcon.gif"
            HelpUrl = "~/Help/DateDisplayWebPart.htm"
            ExportMode = WebPartExportMode.All
        End Sub

        '***************************************************************************
        Public Overrides Property ExportMode() _
          As System.Web.UI.WebControls.WebParts.WebPartExportMode
            Get
                Return WebPartExportMode.NonSensitiveData
            End Get
            Set(ByVal value As WebPartExportMode)
                'Do nothing here
            End Set
        End Property


        '***************************************************************************
        Public Overrides ReadOnly Property Verbs() _
          As System.Web.UI.WebControls.WebParts.WebPartVerbCollection
            Get

                'Instantiate two new verb objects
                Dim MoveNextZone As New WebPartVerb("v1", _
                  New WebPartEventHandler(AddressOf MoveNextZoneClick))

                Dim MovePrevZone As New WebPartVerb("v2", _
                  New WebPartEventHandler(AddressOf MovePrevZoneClick))

                'Setup Verb Properties
                MoveNextZone.Text = "Next Zone"
                MoveNextZone.Description = "Moves web part to the next zone"
                MoveNextZone.ImageUrl = "~/Images/NextIcon.gif"

                MovePrevZone.Text = "Previous Zone"
                MovePrevZone.Description = "Moves web part to the previous zone"
                MovePrevZone.ImageUrl = "~/Images/PrevIcon.gif"

                'Create and return a WebPartVerbCollection
                Dim PartVerbs As WebPartVerb() = {MoveNextZone, MovePrevZone}                
                Return New WebPartVerbCollection(PartVerbs)

            End Get
        End Property

        '***************************************************************************
        Private Sub MoveNextZoneClick(ByVal sender As Object, _
          ByVal e As WebPartEventArgs)

            Dim CurrentZoneIndex As Integer = WebPartManager.Zones.IndexOf(Zone)
            Dim MaxZoneIndex As Integer = WebPartManager.Zones.Count - 1

            If CurrentZoneIndex < MaxZoneIndex Then
                WebPartManager.MoveWebPart(Me, _
                  WebPartManager.Zones(CurrentZoneIndex + 1), 0)
            Else
                WebPartManager.MoveWebPart(Me, _
                  WebPartManager.Zones(0), 0)
            End If

        End Sub

        '***************************************************************************
        Private Sub MovePrevZoneClick(ByVal sender As Object, _
          ByVal e As WebPartEventArgs)

            Dim CurrentZoneIndex As Integer = WebPartManager.Zones.IndexOf(Zone)
            Dim MaxZoneIndex As Integer = WebPartManager.Zones.Count - 1

            If CurrentZoneIndex > 0 Then
                WebPartManager.MoveWebPart(Me, _
                  WebPartManager.Zones(CurrentZoneIndex - 1), 0)
            Else
                WebPartManager.MoveWebPart(Me, _
                  WebPartManager.Zones(MaxZoneIndex), 0)
            End If

        End Sub

        '***************************************************************************
        Protected Overrides Sub CreateChildControls()
            MyBase.CreateChildControls()
            lblDate = New Label
            lblTime = New Label
            lblDate.ID = "lblDate"
            lblTime.ID = "lblTime"
            Controls.Add(lblDate)
            Controls.Add(lblTime)
        End Sub

        '***************************************************************************
        ' Example of Overriding the Render Method
        '***************************************************************************
        'Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
        '    'Example showing RenderBeginTag / RenderEndTag
        '    writer.AddAttribute("id", "Div1")
        '    writer.AddAttribute("class", "MyDivClass")            
        '    writer.AddStyleAttribute("border", "1px solid black")
        '    writer.AddStyleAttribute("font-weight", "bold")
        '    writer.RenderBeginTag(HtmlTextWriterTag.Div) 'Renders attributes also
        '    writer.Write("This appears in the 1st div")            
        '    writer.RenderEndTag() 'Closes off the DIV tag started earlier
        '    writer.WriteBreak()

        '    'Example showing WriteFullBeginTag / WriteEndTag
        '    writer.WriteBeginTag("div ")
        '    writer.WriteAttribute("id", "Div2")
        '    writer.WriteAttribute("class", "MyDivClass")            
        '    writer.WriteAttribute("style", "border: 1px solid black")
        '    writer.Write(">")
        '    writer.Write("This appears in the 2nd div")
        '    writer.WriteEndTag("div")

        '    'Example showing straight output
        '    writer.Write("<br><div id=Div3 class=MyDivClass style=" & _
        '      "'border: 1px solid black'>This appears in the 3rd div</div>")

        'End Sub

        '***************************************************************************
        Protected Overrides Sub OnPreRender(ByVal e As System.EventArgs)
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

            MyBase.OnPreRender(e)

        End Sub

    End Class

End Namespace