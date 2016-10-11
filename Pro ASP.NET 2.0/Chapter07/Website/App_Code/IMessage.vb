Public Interface IMessage
    ReadOnly Property Message() As String
    Sub PassBackConsumerData(ByVal ConsumerName As String)
End Interface