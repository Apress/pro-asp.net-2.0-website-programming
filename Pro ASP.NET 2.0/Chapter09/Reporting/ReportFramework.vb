Imports System.Configuration.ConfigurationManager
Imports System.Data.SqlClient
Imports System.Web.UI
Imports System.Web.UI.WebControls

Public MustInherit Class ReportFramework
    Inherits System.Web.UI.Page

    '***************************************************************************
    'View State Name (VSN) Constants
    '***************************************************************************
    Const CurrentPageVSN As String = "1"
    Const LastSqlVSN As String = "2"
    Const SearchFormIndexVSN As String = "3"

    '***************************************************************************
    'Private Class Variables
    '***************************************************************************
    Private WithEvents _SearchForm As ISearchControl
    Private WithEvents _PaginationForm As IPaginationControl
    Private _TotalRecords As Long
    Private _SortClicked As Boolean
    Private _SortExpression As String
    Private _SortDirection As SqlSortDirection

    '***************************************************************************
    'MustOverride Methods and Properties
    '***************************************************************************
    Protected MustOverride Function ConnectionStringKey() As String
    Protected MustOverride Function ReportGrid() As GridView
    Protected MustOverride Function ItemsPerPage() As Integer
    Protected MustOverride Function SearchFormFileName() As String
    Protected MustOverride Function SearchFormPH() As PlaceHolder
    Protected MustOverride Function PaginationFormFileName() As String
    Protected MustOverride Function PaginationFormPH() As PlaceHolder
    Protected MustOverride Sub SetSortOrder(ByVal query As SqlQuery, _
      ByVal sortExpression As String)

    '***************************************************************************
    'Overridable Methods
    '***************************************************************************
    Protected Overridable Function GetSqlQuery() As SqlQuery
        If _SearchForm Is Nothing Then
            Return Nothing
        Else
            Return _SearchForm.GetSqlQuery
        End If
    End Function

    '***************************************************************************
    Protected Overridable Sub OnReportError(ByVal ex As Exception)
        Throw ex        
    End Sub

    '***************************************************************************
    Protected Overridable ReadOnly Property BindInPreLoad() As Boolean
        Get
            Return False
        End Get
    End Property

    '***************************************************************************
    'Class Properties
    '***************************************************************************
    Protected Property LastSql() As String
        Get
            If ViewState(LastSqlVSN) Is Nothing Then
                Return String.Empty
            Else
                Return ViewState(LastSqlVSN)
            End If            
        End Get
        Set(ByVal value As String)
            If value = String.Empty Then
                ViewState.Remove(LastSqlVSN)
            Else
                ViewState(LastSqlVSN) = value
            End If            
        End Set
    End Property

    '***************************************************************************
    Protected Property SearchFormIndex() As Short
        Get
            If ViewState(SearchFormIndexVSN) Is Nothing Then
                Return 0
            Else
                Return ViewState(SearchFormIndexVSN)
            End If            
        End Get
        Set(ByVal value As Short)
            If value = 0 Then
                ViewState.Remove(SearchFormIndexVSN)
            Else
                ViewState(SearchFormIndexVSN) = value
            End If
        End Set
    End Property

    '***************************************************************************
    Protected Property CurrentPage() As Long
        Get
            If ViewState(CurrentPageVSN) Is Nothing Then
                Return 1
            Else
                Return ViewState(CurrentPageVSN)
            End If            
        End Get
        Set(ByVal value As Long)
            If value <= 1 Then
                ViewState.Remove(CurrentPageVSN)
            Else
                ViewState(CurrentPageVSN) = value
            End If
        End Set
    End Property

    '***************************************************************************
    Protected ReadOnly Property TotalPages() As Long
        Get
            If ItemsPerPage() = 0 Then
                Return 1
            Else
                Return (_TotalRecords \ ItemsPerPage()) + _
                         CInt(IIf(_TotalRecords Mod ItemsPerPage() = 0, 0, 1))
            End If
        End Get
    End Property

    '***************************************************************************
    'Page Event and Related Methods
    '***************************************************************************
    Private Sub Page_PreLoad(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles Me.PreLoad

        If ReportGrid() Is Nothing Then
            OnReportError(New Exception("ReportGrid cannot be Nothing"))
            Exit Sub
        End If

        If Page.IsPostBack Then AcquireHiddenFieldValues()
        LoadSearchForm()
        LoadPaginationForm()

        If _SortClicked Then
            CurrentPage = 1
            SetupSearchSql()
        End If

        If BindInPreLoad() Then BindReport()

    End Sub

    '***************************************************************************
    Private Sub AcquireHiddenFieldValues()

        _SortClicked = CBool(Request.Form("sortClicked") = "1")
        _SortExpression = Request.Form("sortExp")

        If CBool(Request.Form("sortDir") = "1") Then
            _SortDirection = SqlSortDirection.Descending
        Else
            _SortDirection = SqlSortDirection.Ascending
        End If

    End Sub

    '***************************************************************************
    Protected Sub LoadSearchForm()
        If SearchFormPH() Is Nothing Then Exit Sub
        Try
            _SearchForm = LoadControl(SearchFormFileName())
            DirectCast(_SearchForm, UserControl).ID = "SearchFormControl"
            SearchFormPH.Controls.Clear()
            SearchFormPH.Controls.Add(_SearchForm)
        Catch ex As Exception
            OnReportError(New Exception("Error loading search form", ex))
        End Try
    End Sub

    '***************************************************************************
    Protected Sub LoadPaginationForm()
        If PaginationFormPH() Is Nothing Then Exit Sub
        Try
            _PaginationForm = LoadControl(PaginationFormFileName())
            DirectCast(_PaginationForm, UserControl).ID = "PaginationFormControl"
            PaginationFormPH.Controls.Clear()
            PaginationFormPH.Controls.Add(_PaginationForm)
        Catch ex As Exception
            OnReportError(New Exception("Error loading pagination form", ex))
        End Try
    End Sub

    '***************************************************************************
    Private Sub SearchButtonClicked() Handles _SearchForm.SearchButtonClicked
        CurrentPage = 1
        _SortExpression = String.Empty
        _SortDirection = SqlSortDirection.Ascending
        SetupSearchSql()
        If BindInPreLoad() Then BindReport()
    End Sub

    '***************************************************************************
    Private Sub SetupSearchSql()

        Dim SqlQueryObj As SqlQuery = GetSqlQuery()
        If SqlQueryObj Is Nothing Then ClearSearch() : Exit Sub

        SetSortOrder(SqlQueryObj, _SortExpression)

        If _SortDirection = SqlSortDirection.Descending Then _
          ReverseOrderBy(SqlQueryObj)

        If _PaginationForm Is Nothing Then
            LastSql = SqlQueryObj.GetQuery()
        Else
            LastSql = SqlQueryObj.GetPagedQuery( _
                        CurrentPage, ItemsPerPage) & ";" & _
                        _SearchForm.GetSqlQuery.GetCountQuery()
        End If

    End Sub

    '***************************************************************************
    Private Sub ReverseOrderBy(ByVal Query As SqlQuery)
        For Each field As SqlField In Query.OrderBy
            If field.SortDirection = SqlSortDirection.Ascending Then
                field.SortDirection = SqlSortDirection.Descending
            Else
                field.SortDirection = SqlSortDirection.Ascending
            End If
        Next
    End Sub

    '***************************************************************************
    Protected Sub ClearSearch()
        LastSql = String.Empty
    End Sub

    '***************************************************************************
    Private Sub BindReport()

        If LastSql = String.Empty Then Exit Sub

        Dim dbConn As SqlConnection
        Dim dbCmd As SqlCommand
        Dim dbDr As SqlDataReader
        Dim RecordStart As Integer
        Dim RecordEnd As Integer

        Try
            dbConn = New SqlConnection( _
               ConnectionStrings(ConnectionStringKey).ConnectionString)
            dbCmd = New SqlCommand(LastSql, dbConn)
            dbConn.Open()
            dbDr = dbCmd.ExecuteReader()
            ReportGrid.DataSource = dbDr
            ReportGrid.DataBind()
            If Not _PaginationForm Is Nothing _
              AndAlso dbDr.NextResult AndAlso dbDr.Read Then
                _TotalRecords = dbDr.Item(0)

                'Ensure page bounds are correct
                If CurrentPage < 1 Then CurrentPage = 1
                If CurrentPage > TotalPages Then CurrentPage = TotalPages

                'Calculate the Starting and Ending Records
                RecordStart = ((CurrentPage - 1) * ItemsPerPage()) + 1
                If CurrentPage = TotalPages Then
                    RecordEnd = _TotalRecords
                Else
                    RecordEnd = RecordStart + ItemsPerPage() - 1
                End If

                'Initialize the Paging Component
                _PaginationForm.SetInfo(CurrentPage, TotalPages, _
                  _TotalRecords, ItemsPerPage, RecordStart, RecordEnd)

            End If
            dbConn.Close()

        Catch ex As Exception
            OnReportError(ex)
        End Try

    End Sub

    '***************************************************************************
    Private Sub Page_PreRender(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles Me.PreRender

        If Not BindInPreLoad() Then BindReport()
        SetupHiddenFields()
        SetupJavaScript()
        If Not _PaginationForm Is Nothing Then _
          If ReportGrid.Rows.Count = 0 Then Me.PaginationFormPH.Controls.Clear() _
            Else SetupSortableColumns()

    End Sub

    '***************************************************************************
    Private Sub SetupHiddenFields()
        ClientScript.RegisterHiddenField("sortClicked", "0")
        ClientScript.RegisterHiddenField("sortExp", _SortExpression)
        ClientScript.RegisterHiddenField("sortDir", _
          IIf(_SortDirection = SqlSortDirection.Ascending, 0, 1))
    End Sub

    '***************************************************************************
    Private Sub SetupJavaScript()
        Dim script As String = _
              "   function setSortExp(sortExp){" & _
              "     var sortExpField = document.getElementById('sortExp');" & _
              "     var sortDirField = document.getElementById('sortDir');" & _
              "     if(sortExpField.value==sortExp){" & _
              "       if(sortDirField.value==0){" & _
              "         sortDirField.value=1;" & _
              "       }else{" & _
              "         sortDirField.value=0;" & _
              "       }" & _
              "     }else{" & _
              "       sortExpField.value=sortExp;" & _
              "       sortDirField.value=0;" & _
              "     }" & _
              "     document.getElementById('sortClicked').value = '1';" & _
              "  }"
        ClientScript.RegisterClientScriptBlock(Me.GetType, "sortExp", script, True)
    End Sub

    '***************************************************************************
    Private Sub SetupSortableColumns()

        Dim sortButton As LinkButton
        Dim columnHeading As Label

        For index As Integer = 0 To ReportGrid.Columns.Count - 1
            'If neither the header text, nor the sort expression are defined
            'then do not place anything in the header
            If ReportGrid.Columns.Item(index).SortExpression = String.Empty _
              And ReportGrid.Columns.Item(index).HeaderText <> String.Empty Then
                'Do not allow sorting on the column
                columnHeading = New Label
                columnHeading.Text = ReportGrid.Columns.Item(index).HeaderText
                ReportGrid.HeaderRow.Cells.Item(index).Controls.Add(columnHeading)
            Else
                'Allow sorting on the column
                sortButton = New LinkButton
                sortButton.Text = ReportGrid.Columns.Item(index).HeaderText

                sortButton.Attributes.Add("onclick", String.Format( _
                    "setSortExp('{0}');", _
                    ReportGrid.Columns.Item(index).SortExpression))

                ReportGrid.HeaderRow.Cells.Item(index).Controls.Add(sortButton)
            End If
        Next

    End Sub

    '***************************************************************************
    'Pagination Methods
    '***************************************************************************
    Protected Sub RequestNextPage() _
      Handles _PaginationForm.NextPageRequested
        CurrentPage += 1
        SetupSearchSql()
        If BindInPreLoad() Then BindReport()
    End Sub

    '***************************************************************************
    Protected Sub RequestPrevPage() _
      Handles _PaginationForm.PrevPageRequested
        CurrentPage -= 1
        SetupSearchSql()
        If BindInPreLoad() Then BindReport()
    End Sub

    '***************************************************************************
    Protected Sub RequestNewPage(ByVal page As Integer) _
      Handles _PaginationForm.NewPageRequested
        CurrentPage = page
        SetupSearchSql()
        If BindInPreLoad() Then BindReport()
    End Sub

End Class