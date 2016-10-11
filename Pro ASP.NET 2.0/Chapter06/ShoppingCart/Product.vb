Imports Microsoft.VisualBasic

<Serializable()> Public Class Product

    '***************************************************************************
    Private _productId As String
    Private _productName As String
    Private _unitPrice As Decimal
    Private _quantity As Integer    

    '***************************************************************************
    Public Sub New(ByVal ProductID As String, ByVal ProductName As String, _
                   ByVal UnitPrice As Decimal, ByVal Quantity As Integer)
        _productId = ProductID
        _productName = ProductName
        _unitPrice = UnitPrice
        _quantity = Quantity
    End Sub

    '***************************************************************************
    Public Property ProductId() As String
        Get
            Return _productId
        End Get
        Set(ByVal value As String)
            _productId = value
        End Set
    End Property

    '***************************************************************************
    Public Property ProductName() As String
        Get
            Return _productName
        End Get
        Set(ByVal value As String)
            _productName = value
        End Set
    End Property

    '***************************************************************************
    Public Property UnitPrice() As Decimal
        Get
            Return _unitPrice
        End Get
        Set(ByVal value As Decimal)
            _unitPrice = value
        End Set
    End Property

    '***************************************************************************
    Public Property Quantity() As Integer
        Get
            Return _quantity
        End Get
        Set(ByVal value As Integer)
            _quantity = value
        End Set
    End Property

    '***************************************************************************
    Public ReadOnly Property TotalPrice() As Decimal
        Get
            Return _unitPrice * _quantity
        End Get
    End Property

End Class
