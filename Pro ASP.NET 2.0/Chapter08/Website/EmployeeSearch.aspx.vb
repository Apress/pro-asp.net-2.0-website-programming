Imports Reporting
Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationManager

Partial Class EmployeeSearch
    Inherits System.Web.UI.Page

    '***************************************************************************
    Private SearchControl As ISearchControl

    '***************************************************************************
    Private Property FormName() As String
        Get
            'You could also use the profile here if you wanted 
            If Session("SearchForm") Is Nothing Then
                Return "SimpleForm.ascx"
            Else
                Return CStr(Session("SearchForm"))
            End If
        End Get
        Set(ByVal value As String)
            Session("SearchForm") = value
        End Set
    End Property

    '***************************************************************************
    Private Sub SetupForm()

        Dim SearchForm As Control = LoadControl("~/SearchForms/" & FormName)
        SearchControl = CType(SearchForm, ISearchControl)
        SearchForm.ID = "ucSearchForm"
        phForm.Controls.Clear()
        phForm.Controls.Add(SearchForm)

        If FormName = "SimpleForm.ascx" Then
            Me.lnkToggleForm.Text = "Advanced Search"
        Else
            Me.lnkToggleForm.Text = "Simple Search"
        End If

    End Sub

    '***************************************************************************
    Protected Sub lnkToggleForm_Click(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles lnkToggleForm.Click
        If FormName = "SimpleForm.ascx" Then
            FormName = "AdvancedForm.ascx"
        Else
            FormName = "SimpleForm.ascx"
        End If
        SetupForm()
    End Sub

    '***************************************************************************
    Protected Sub Page_PreLoad(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles Me.PreLoad
        SetupForm()
    End Sub

    '***************************************************************************
    Protected Sub btnDisplayQuery_Click(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles btnDisplayQuery.Click

        Dim SQL As String = SearchControl.GetSqlQuery.GetQuery()
        Me.lblQueryOutput.Text = SQL

        Dim SqlQueryObj As New Reporting.SqlQuery
        Dim dbConn As New SqlConnection( _
          ConnectionStrings("Northwind").ConnectionString)
        dbConn.Open()

        Dim dbCmd As New SqlCommand(SQL, dbConn)
        Dim dr As SqlDataReader = dbCmd.ExecuteReader()

        MyGrid.DataSource = dr
        MyGrid.DataBind()

        dr.Close()
        dbConn.Close()

    End Sub

End Class