Imports Reporting
Imports System.Web.UI.WebControls

Partial Class CustomerSearch
    Inherits ReportFramework

    '***************************************************************************
    ' Search Form Toggling Functionality
    '***************************************************************************
    Protected Sub ToggleSearchForm_Click(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles ToggleSearchForm.Click
        If SearchFormIndex = 1 Then SearchFormIndex = 0 Else SearchFormIndex = 1
        LoadSearchForm()
    End Sub

    '***************************************************************************
    Protected Sub Page_PreRender(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles Me.PreRender
        Select Case SearchFormIndex
            Case 0
                Me.ToggleSearchForm.Text = "Advanced Search"
            Case Else
                Me.ToggleSearchForm.Text = "Simple Search"
        End Select
    End Sub

    '***************************************************************************
    ' ReportFramework Virtual Member Overrides
    '***************************************************************************
    Protected Overrides Function SearchFormFileName() As String
        Select Case Me.SearchFormIndex
            Case 0
                Return "~/SearchForms/CustomerSimple.ascx"
            Case Else
                Return "~/SearchForms/CustomerAdvanced.ascx"
        End Select
    End Function

    '***************************************************************************
    Protected Overrides Function PaginationFormFileName() As String
        Return "~/PaginationForms/PagingControl.ascx"
    End Function

    '***************************************************************************
    Protected Overrides Function ConnectionStringKey() As String
        Return "Northwind"
    End Function

    '***************************************************************************
    Protected Overrides Function ItemsPerPage() As Integer
        Return 10
    End Function

    '***************************************************************************
    Protected Overrides Function ReportGrid() As GridView
        Return MyReportGrid
    End Function

    '***************************************************************************
    Protected Overrides Function SearchFormPH() As PlaceHolder
        Return MyReportPlaceHolder
    End Function

    '***************************************************************************
    Protected Overrides Function PaginationFormPH() As PlaceHolder
        Return MyPagingControls
    End Function

    '***************************************************************************
    Protected Overrides Sub SetSortOrder(ByVal queryObj As SqlQuery, ByVal sortExpression As String)
        Select Case sortExpression
            Case "CompanyName"
                queryObj.OrderBy.Add("CompanyName")
                queryObj.OrderBy.Add("ContactName")
            Case "ContactName"
                queryObj.OrderBy.Add("ContactName")                
            Case "ContactTitle"
                queryObj.OrderBy.Add("ContactTitle")
                queryObj.OrderBy.Add("ContactName")
            Case "Phone"
                queryObj.OrderBy.Add("Phone")
            Case Else
                queryObj.OrderBy.Add("CustomerID")
        End Select
    End Sub

End Class