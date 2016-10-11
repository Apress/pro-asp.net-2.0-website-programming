Imports System.Drawing

Partial Class ColorEntryWebPart
    Inherits WebPartUserControl
    Implements IColorInfo

#Region "WebPartUserControl Overrides"

    '***************************************************************************
    Public Overrides Function DefaultCatalogIconImageUrl() As String
        Return ""
    End Function

    '***************************************************************************
    Public Overrides Function DefaultDescription() As String
        Return "Acts as a connection provider.  Allows you to choose a " & _
               "color, and then sends that color to all consumer web parts"
    End Function

    '***************************************************************************
    Public Overrides Function DefaultSubTitle() As String
        Return String.Empty
    End Function

    '***************************************************************************
    Public Overrides Function DefaultTitle() As String
        Return "Color Definer"
    End Function

    '***************************************************************************
    Public Overrides Function DefaultTitleIconImageUrl() As String
        Return ""
    End Function

    '***************************************************************************
    Public Overrides Function DefaultTitleUrl() As String
        Return ""
    End Function

#End Region

#Region "Custom Web Part Functionality"

    '***************************************************************************
    Sub SetFromRGB(ByVal R As Byte, ByVal G As Byte, ByVal B As Byte)
        Me.R = R
        Me.G = G
        Me.B = B
        Me.HexValue = "#" & Right(Hex(R).PadLeft(2, "0"c), 2) & _
                            Right(Hex(G).PadLeft(2, "0"c), 2) & _
                            Right(Hex(B).PadLeft(2, "0"c), 2)
    End Sub

    '***************************************************************************
    Sub SetFromHex(ByVal Hex As String)
        Try
            Dim startIndex As Integer = CInt(IIf(Me.txtHex.Text.Length = 6, 0, 1))
            Dim RHex As String = Me.txtHex.Text.Substring(startIndex, 2)
            Dim GHex As String = Me.txtHex.Text.Substring(startIndex + 2, 2)
            Dim BHex As String = Me.txtHex.Text.Substring(startIndex + 4, 2)
            SetFromRGB(CByte("&H" & RHex), CByte("&H" & GHex), CByte("&H" & BHex))
        Catch
            SetFromRGB(0, 0, 0)
        End Try
    End Sub

    '***************************************************************************
    Sub SetFromColorName(ByVal Name As String)
        Try
            Dim ColorForName As Color = Color.FromName(Name)
            SetFromRGB(ColorForName.R, ColorForName.G, ColorForName.B)
        Catch ex As Exception
            SetFromRGB(0, 0, 0)
        End Try
    End Sub

    '***************************************************************************    
    Protected Sub btnRGB_Click(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles btnRGB.Click
        SetFromRGB(R, G, B)
    End Sub

    '***************************************************************************
    Protected Sub btnHex_Click(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles btnHex.Click
        SetFromHex(Me.txtHex.Text)
    End Sub

    '***************************************************************************
    Protected Sub btnNamed_Click(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles btnNamed.Click
        SetFromColorName(Me.txtName.Text)
    End Sub

#End Region

    '***************************************************************************
    <ConnectionProvider("Color Information Provider")> _
    Public Function GetColorInfo() As IColorInfo
        Return Me
    End Function

#Region "IColorInfo Implementation"


    '***************************************************************************
    Public Property R() As Byte Implements IColorInfo.R
        Get
            If Not IsNumeric(Me.txtR.Text) Then txtR.Text = "0"
            Return CByte(Me.txtR.Text)
        End Get
        Set(ByVal value As Byte)
            Me.txtR.Text = value.ToString()
        End Set
    End Property

    '***************************************************************************
    Public Property G() As Byte Implements IColorInfo.G
        Get
            If Not IsNumeric(Me.txtG.Text) Then txtG.Text = "0"
            Return CByte(Me.txtG.Text)
        End Get
        Set(ByVal value As Byte)
            Me.txtG.Text = value.ToString()
        End Set
    End Property

    '***************************************************************************
    Public Property B() As Byte Implements IColorInfo.B
        Get
            If Not IsNumeric(Me.txtB.Text) Then txtB.Text = "0"
            Return CByte(Me.txtB.Text)
        End Get
        Set(ByVal value As Byte)
            Me.txtB.Text = value.ToString()
        End Set
    End Property

    '***************************************************************************
    Public Property HexValue() As String Implements IColorInfo.HexValue
        Get
            Return Me.txtHex.Text
        End Get
        Set(ByVal value As String)
            Me.txtHex.Text = value
        End Set
    End Property

#End Region

    '***************************************************************************
    Public Sub RegisterDataAcquired(ByVal ConsumerName As String) _
      Implements IColorInfo.RegisterConsumerName

        If lblConsumers.Text = String.Empty Then _
            lblConsumers.Text &= "<br/><b><u>Consumers</u></b>"

        lblConsumers.Text &= "<br/>&nbsp;&nbsp;" & ConsumerName

    End Sub

End Class
