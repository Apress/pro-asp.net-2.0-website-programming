Imports System.Configuration
Imports System.Xml

Public Class IconConfigurationHandler
    Implements IConfigurationSectionHandler

    '***************************************************************************
    Public Function Create(ByVal parent As Object, _
                           ByVal configContext As Object, _
                           ByVal section As System.Xml.XmlNode) As Object _
                           Implements IConfigurationSectionHandler.Create

        Dim ReturnObj As New IconConfigurationCollection
        Dim IconItem As IconConfigurationItem

        Dim IconNodes As XmlNodeList = section.SelectNodes("icon")
        Dim IconNode As XmlNode
        Dim ExtensionNodes As XmlNodeList
        Dim ExtensionNode As XmlNode

        'Acquire and Process the Icon Nodes
        For Each IconNode In IconNodes
            ExtensionNodes = IconNode.SelectNodes("ext")
            For Each ExtensionNode In ExtensionNodes

                IconItem = New IconConfigurationItem( _
                  IconNode.Attributes.GetNamedItem("imageUrl").Value, _
                  IconNode.Attributes.GetNamedItem("description").Value, _
                  ExtensionNode.InnerText)
                ReturnObj.Add(IconItem)

            Next
        Next
        
        'Acquire and Process the Unknown Icon Node
        IconNode = section.SelectSingleNode("unknownIcon")
        If Not IconNode Is Nothing Then
            ReturnObj.UnknownIconInfo = New IconConfigurationItem( _
            IconNode.Attributes.GetNamedItem("imageUrl").Value, _
            IconNode.Attributes.GetNamedItem("description").Value, _
            String.Empty)
        End If

        Return ReturnObj

    End Function

End Class