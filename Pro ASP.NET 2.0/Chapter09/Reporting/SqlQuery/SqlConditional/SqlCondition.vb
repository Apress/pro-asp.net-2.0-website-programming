Public Class SqlCondition
    Implements ISqlCondition

    '***************************************************************************
    Private _Condition As String

    '***************************************************************************
    Public Sub New(ByVal condition As String, ByVal operation As String)
        _Condition = condition
        _ConditionOp = Operation
    End Sub

    '***************************************************************************
    Public Sub New(ByVal condition As String, ByVal operation As String, _
      ByVal name As String)
        _Condition = condition
        _ConditionOp = operation
        _Name = name
    End Sub

    '***************************************************************************
    Public Property Condition() As String
        Get
            Return _Condition
        End Get
        Set(ByVal value As String)
            _Condition = value
        End Set
    End Property

#Region "ISqlConditional Implementation"

    '***************************************************************************
    Private _Name As String
    Private _ConditionOp As SqlOperation

    '***************************************************************************
    Public Property Name() As String Implements ISqlCondition.Name
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
        End Set
    End Property

    '***************************************************************************
    Public Property Operation() As SqlOperation _
      Implements ISqlCondition.ConditionOp
        Get
            Return _ConditionOp
        End Get
        Set(ByVal value As SqlOperation)
            _ConditionOp = value
        End Set
    End Property

    '***************************************************************************
    Public ReadOnly Property Type() As SqlConditionType _
      Implements ISqlCondition.Type
        Get
            Return SqlConditionType.Condition
        End Get
    End Property

#End Region

End Class