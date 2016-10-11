Imports Microsoft.VisualBasic

<Serializable()> Public Class Cart
    Inherits CollectionBase

    '***************************************************************************
    Function AddProduct(ByVal value As Product) As Integer
        If value.Quantity = 0 Then Return -1
        For Each P As Product In Me.List
            If P.ProductId = value.ProductId Then
                P.Quantity += value.Quantity
                Exit Function
            End If
        Next
        MyBase.List.Add(value)
    End Function

    '***************************************************************************
    Function AddProduct(ByVal ProductID As String, ByVal PRoductName As String, _
                        ByVal UnitPrice As Decimal, _
                        ByVal Quantity As Integer) As Integer
        AddProduct(New Product(ProductID, PRoductName, UnitPrice, Quantity))
    End Function

    '***************************************************************************
    Default Public Property Products(ByVal index As Integer) As Product
        Get
            Return DirectCast(MyBase.List.Item(index), Product)
        End Get
        Set(ByVal value As Product)
            MyBase.List.Item(index) = value
        End Set
    End Property

    '***************************************************************************
    Public Function GetTotal() As Decimal
        Dim total As Decimal = 0
        For Each p As Product In MyBase.List
            total += p.TotalPrice()            
        Next
        Return total
    End Function

End Class
