Imports Microsoft.VisualBasic

Public Class MasterDemoProvider
    Inherits MasterPersonalizationProviderBase

    '***************************************************************************
    Protected Overrides ReadOnly Property PageGroupName() As String
        Get
            Return "MasterDemo"
        End Get
    End Property

End Class
