Imports System.Text.RegularExpressions

Public Class SqlConditionGroup
    Inherits CollectionBase
    Implements ISqlCondition

    '***************************************************************************
    Private _Not As Boolean
    Private _NextOperation As SqlOperation = SqlOperation.And

    '***************************************************************************
    Public Property [Not]() As Boolean
        Get
            Return _Not
        End Get
        Set(ByVal value As Boolean)
            _Not = value
        End Set
    End Property

    '***************************************************************************
    Public Sub New(ByVal operation As SqlOperation, ByVal [not] As Boolean)
        _ConditionOp = operation
        _Not = [not]
    End Sub

    '***************************************************************************
    Public Sub New(ByVal operation As SqlOperation, ByVal [not] As Boolean, _
      ByVal name As String)
        _ConditionOp = operation
        _Not = [not]
        _Name = name
    End Sub

    '***************************************************************************
    Public Sub [And]()
        _NextOperation = SqlOperation.And
    End Sub

    '***************************************************************************
    Public Sub [Or]()
        _NextOperation = SqlOperation.Or
    End Sub

    '***************************************************************************
    Public Function AddCondition(ByVal condition As String) As SqlCondition
        Return AddCondition(condition, String.Empty)
    End Function

    '***************************************************************************
    Public Function AddCondition(ByVal condition As String, _
                                  ByVal name As String) As SqlCondition
        Dim item As New SqlCondition(condition, _NextOperation)
        item.Name = name
        List.Add(item)
        Return item
    End Function

    '***************************************************************************
    Public Function AddGroup() As SqlConditionGroup
        Return AddGroup(String.Empty)
    End Function

    '***************************************************************************
    Public Function AddGroup(ByVal name As String) As SqlConditionGroup
        Dim item As New SqlConditionGroup(_NextOperation, False)
        item.Name = name
        List.Add(item)
        Return item
    End Function

    '***************************************************************************
    Public Function AddNotGroup() As SqlConditionGroup
        Return AddNotGroup(String.Empty)
    End Function

    '***************************************************************************
    Public Function AddNotGroup(ByVal name As String) As SqlConditionGroup
        Dim item As New SqlConditionGroup(_NextOperation, True)
        item.Name = name
        List.Add(item)
        Return item
    End Function

    '***************************************************************************
    Private Function GetNamedItem(ByVal name As String, _
      ByVal requestType As SqlConditionType) As ISqlCondition

        Dim item As ISqlCondition
        Dim tempItem As ISqlCondition

        'Ensure there are items before setting item to the first one in the list
        If Me.Count = 0 Then Return Nothing
        item = List.Item(0)

        'Only UCase the name once
        name = UCase(name)

        'Iterate through all items in the list looking for a match
        For Each item In List
            If UCase(item.Name) = name And item.Type = requestType Then
                Return item
            End If
        Next

        'If no match is found, then search sub-groups
        For Each item In List

            'If the current item is a group, search through it recusively
            If item.Type = SqlConditionType.Group Then
                tempItem = DirectCast(item, _
                            SqlConditionGroup).GetNamedItem(name, requestType)
                If Not tempItem Is Nothing Then Return tempItem
            End If

        Next

        Return Nothing

    End Function

    '***************************************************************************
    Public Function GetNamedGroup(ByVal name As String) As SqlConditionGroup
        Return GetNamedItem(name, SqlConditionType.Group)
    End Function

    '***************************************************************************
    Public Function GetNamedCondition(ByVal name As String) As SqlCondition
        Return GetNamedItem(name, SqlConditionType.Condition)
    End Function

    '***************************************************************************
    Public Sub Remove(ByVal item As ISqlCondition)        
        Me.List.Remove(item)
    End Sub

    '***************************************************************************
    Public Sub RemoveNamedCondition(ByVal name As String)
        Dim item As SqlCondition = GetNamedCondition(name)
        If Not item Is Nothing Then Me.List.Remove(item)
    End Sub

    '***************************************************************************
    Public Sub RemoveNamedGroup(ByVal name As String)
        Dim item As SqlConditionGroup = GetNamedGroup(name)
        If Not item Is Nothing Then Me.List.Remove(item)
    End Sub

    '***************************************************************************
    Public Function WriteStatement() As String

        Dim group As SqlConditionGroup
        Dim firstItemFlag As Boolean = True
        Dim statement As String = String.Empty
        Dim tempStatement As String = String.Empty

        'Run through each item (may be condition or condition group) in list 
        For Each item As ISqlCondition In List

            'Determine the condition type
            Select Case item.Type

                Case SqlConditionType.Condition
                    'Acquire the statement from the condition property                    
                    tempStatement = DirectCast(item, SqlCondition).Condition

                Case SqlConditionType.Group
                    'Recursively call the WriteStatement function
                    group = DirectCast(item, SqlConditionGroup)
                    tempStatement = group.WriteStatement

                    'Ensure statement returned text before adding parenthesis
                    If Not tempStatement = String.Empty Then _
                      tempStatement = "(" & tempStatement & ")"

                    'If this is a "NOT" group, add the NOT keyword
                    If group.Not Then tempStatement = "NOT" & tempStatement

            End Select

            'Ensure statement contains text before appending condition operation
            If Not tempStatement = String.Empty Then

                If firstItemFlag Then
                    'Do not add condition operation for first item in group
                    firstItemFlag = False
                Else
                    'Determine condition operation and add appropriate SQL
                    Select Case item.ConditionOp
                        Case SqlOperation.And
                            tempStatement = " AND " & tempStatement
                        Case SqlOperation.Or
                            tempStatement = " OR " & tempStatement
                    End Select
                End If

                statement &= tempStatement

            End If

        Next

        Return statement

    End Function

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
    Public Property ConditionOp() As SqlOperation _
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
            Return SqlConditionType.Group
        End Get
    End Property

#End Region

#Region "Common Queries"

    '***************************************************************************
    Public Function CreateKeywords(ByVal keywords As String, _
      ByVal column As String, ByVal defaultOp As SqlOperation) As SqlConditionGroup

        Dim group As New SqlConditionGroup(_NextOperation, False)        
        Dim groupStack As New Stack
        Dim keywordList As String()
        Dim [not] As Boolean
        Dim hasCondition As Boolean

        If Trim(keywords) = String.Empty Then Return Nothing
        keywords = Regex.Replace(keywords, "\(|\)", " $0 ")
        keywords = Regex.Replace(keywords, "\s{2,}", " ")
        keywordList = Split(UCase(Trim(keywords)))

        For Each keyword As String In keywordList
            Select Case keyword
                Case "AND"
                    group.And()
                Case "OR"
                    group.Or()
                Case "NOT"
                    [not] = True
                Case "("
                    groupStack.Push(group)
                    group = group.AddGroup()
                    group.Not = [not]
                    [not] = False
                Case ")"
                    If groupStack.Count > 0 Then group = groupStack.Pop
                Case ""
                    'Do nothing
                Case Else
                    group.AddCondition(String.Format( _
                      "{0}{1} like '%{2}%'", IIf([not], "NOT ", ""), _
                      column, SqlString(keyword)))
                    [not] = False
                    hasCondition = True
            End Select
        Next

        If hasCondition Then
            'Make sure you end up with the top level group
            While groupStack.Count > 0
                group = groupStack.Pop()
            End While
            List.Add(group)
            Return group
        Else
            Return Nothing
        End If

    End Function

    '***************************************************************************
    Public Function CreateDateRange(ByVal startDateStr As String, _
      ByVal endDateStr As String, ByVal column As String, _
      ByVal evalType As SqlEvaluationType, ByVal dateFormat As String) _
      As SqlConditionGroup

        Return CreateDateRange(startDateStr, endDateStr, column, evalType, _
          dateFormat, String.Empty)

    End Function

    '***************************************************************************
    Public Function CreateDateRange(ByVal startDateStr As String, _
      ByVal endDateStr As String, ByVal column As String, _
      ByVal evalType As SqlEvaluationType, ByVal dateFormat As String, _
      ByVal name As String) As SqlConditionGroup


        Dim group As SqlConditionGroup
        Dim startDate As Date
        Dim endDate As Date

        'Make sure that there is at least one date specified before continuing
        If IsDate(startDateStr) Then startDate = CDate(startDateStr)
        If IsDate(endDateStr) Then endDate = CDate(endDateStr)
        If startDate = Nothing And endDate = Nothing Then Return Nothing

        'Specify a date format string if none was supplied
        If dateFormat = String.Empty Then dateFormat = "MM/dd/yyyy"

        'Create new group.  Specify that all conditions in group must be met
        group = New SqlConditionGroup(_NextOperation, False, name)
        group.And()

        'Append the start date criteria, if applicable
        If Not startDate = Nothing Then

            Select Case evalType

                Case SqlEvaluationType.Exclusive
                    group.AddCondition(String.Format("{0}>'{1}'", column, _
                                             Format(startDate, dateFormat)))

                Case SqlEvaluationType.Inclusive
                    group.AddCondition(String.Format("{0}>='{1}'", column, _
                                             Format(startDate, dateFormat)))

            End Select
        End If

        'Append the end date criteria, if applicable
        If Not endDate = Nothing Then
            Select Case evalType

                Case SqlEvaluationType.Exclusive
                    group.AddCondition(String.Format("{0}<'{1}'", column, _
                    Format(endDate, dateFormat)))

                Case SqlEvaluationType.Inclusive
                    group.AddCondition(String.Format("{0}<='{1}'", column, _
                    Format(endDate, dateFormat)))

            End Select
        End If

        List.Add(group)
        Return group

    End Function

#End Region

End Class
