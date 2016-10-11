Partial Class ProductDisplayer
    Inherits UserControl

    '***************************************************************************
    Private _ProductId As String
    Public Property ProductID() As String
        Get
            Return _ProductId
        End Get
        Set(ByVal value As String)
            _ProductId = value
        End Set
    End Property

    '***************************************************************************
    Public Property ProductName() As String
        Get
            EnsureChildControls()
            Return Me.lblProductName.Text
        End Get
        Set(ByVal value As String)
            EnsureChildControls()
            Me.lblProductName.Text = value
        End Set
    End Property

    '***************************************************************************
    Public Property UnitPrice() As Decimal
        Get
            Return CDec(Me.lblPrice.Text)
        End Get
        Set(ByVal value As Decimal)
            EnsureChildControls()
            Me.lblPrice.Text = FormatCurrency(value, 2)
        End Set
    End Property


    '***************************************************************************
    Public Property ImageUrl() As String
        Get
            EnsureChildControls()
            Return Me.imgProduct.ImageUrl
        End Get
        Set(ByVal value As String)
            EnsureChildControls()
            Me.imgProduct.ImageUrl = value
        End Set
    End Property

    '***************************************************************************
    Private ReadOnly Property Quantity() As Integer
        Get
            EnsureChildControls()
            If IsNumeric(Me.txtQuantity.Text) Then _
                Return CInt(Me.txtQuantity.Text)
            Return 0
        End Get
    End Property


    '***************************************************************************
    Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        If Profile.ShoppingCart Is Nothing Then _
            Profile.ShoppingCart = New ShoppingCart.Cart

        Profile.ShoppingCart.AddProduct(ProductID, ProductName, UnitPrice, Quantity)

    End Sub

    '***************************************************************************
    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Me.txtQuantity.Text = "1"
    End Sub

End Class
