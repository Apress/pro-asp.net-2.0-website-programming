Imports Microsoft.VisualBasic
Imports System.Web.UI.WebControls.WebParts

Public MustInherit Class MasterPersonalizationProviderBase
    Inherits SqlPersonalizationProvider

    '***************************************************************************
    Protected MustOverride ReadOnly Property PageGroupName() As String

    '***************************************************************************
    Public Overrides Function FindState(ByVal scope As PersonalizationScope, _
      ByVal query As PersonalizationStateQuery, ByVal pageIndex As Integer, _
      ByVal pageSize As Integer, ByRef totalRecords As Integer) _
      As PersonalizationStateInfoCollection

        Return MyBase.FindState(scope, query, pageIndex, pageSize, totalRecords)

    End Function

    '***************************************************************************
    Public Overrides Function GetCountOfState( _
      ByVal scope As PersonalizationScope, _
      ByVal query As PersonalizationStateQuery) As Integer

        If Not query.PathToMatch = String.Empty Then _
          query.PathToMatch = PageGroupName
        Return MyBase.GetCountOfState(scope, query)

    End Function

    '***************************************************************************
    Protected Overrides Sub LoadPersonalizationBlobs( _
      ByVal webPartManager As WebPartManager, ByVal path As String, _
      ByVal userName As String, ByRef sharedDataBlob() As Byte, _
      ByRef userDataBlob() As Byte)

        path = PageGroupName
        MyBase.LoadPersonalizationBlobs(webPartManager, path, userName, sharedDataBlob, userDataBlob)

    End Sub

    '***************************************************************************
    Protected Overrides Sub ResetPersonalizationBlob( _
      ByVal webPartManager As WebPartManager, _
      ByVal path As String, ByVal userName As String)

        path = PageGroupName
        MyBase.ResetPersonalizationBlob(webPartManager, path, userName)

    End Sub

    '***************************************************************************
    Public Overrides Function ResetState(ByVal scope As PersonalizationScope, _
      ByVal paths() As String, ByVal usernames() As String) As Integer

        paths = New String() {PageGroupName}
        Return MyBase.ResetState(scope, paths, usernames)

    End Function

    '***************************************************************************
    Public Overrides Function ResetUserState(ByVal path As String, _
      ByVal userInactiveSinceDate As Date) As Integer

        path = PageGroupName
        Return MyBase.ResetUserState(path, userInactiveSinceDate)

    End Function

    '***************************************************************************
    Protected Overrides Sub SavePersonalizationBlob( _
      ByVal webPartManager As WebPartManager, ByVal path As String, _
      ByVal userName As String, ByVal dataBlob() As Byte)

        path = PageGroupName
        MyBase.SavePersonalizationBlob(webPartManager, path, userName, dataBlob)

    End Sub

End Class


