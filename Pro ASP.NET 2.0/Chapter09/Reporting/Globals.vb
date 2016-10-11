'***********************************************************************************
Public Enum SqlSortDirection
    Ascending
    Descending
End Enum

'***********************************************************************************
Public Enum SqlOperation
    [And]
    [Or]
End Enum

'***********************************************************************************
Public Enum SqlConditionType
    Condition
    Group
End Enum

'***********************************************************************************
Public Enum SqlEvaluationType
    Exclusive
    Inclusive
End Enum

Public Module Globals

    '*******************************************************************************
    Public Function SqlString(ByVal text As String) As String
        Return text.Replace("'", "''")
    End Function

End Module