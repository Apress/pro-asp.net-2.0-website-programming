Public Interface ISqlCondition

    '*******************************************************************************
    Property Name() As String
    Property ConditionOp() As SqlOperation    
    ReadOnly Property Type() As SqlConditionType

End Interface
