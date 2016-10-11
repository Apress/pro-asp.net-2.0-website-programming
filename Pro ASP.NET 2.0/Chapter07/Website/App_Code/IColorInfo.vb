Public Interface IColorInfo
    Property R() As Byte
    Property G() As Byte
    Property B() As Byte
    Property HexValue() As String
    Sub RegisterConsumerName(ByVal ConsumerName As String)
End Interface

