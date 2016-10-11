Imports Reporting

Partial Class PagingControl
    Inherits System.Web.UI.UserControl
    Implements IPaginationControl

    'IPaginationForm Events
    '***************************************************************************
    Public Event NewPageRequested(ByVal page As Integer) _
      Implements IPaginationControl.NewPageRequested

    Public Event NextPageRequested() _
      Implements IPaginationControl.NextPageRequested

    Public Event PrevPageRequested() _
      Implements IPaginationControl.PrevPageRequested

    '***************************************************************************
    Public Sub SetInfo(ByVal currentPage As Integer, ByVal totalPages As Integer, _
      ByVal totalRecords As Integer, ByVal itemsPerPage As Integer, _
      ByVal recordStart As Integer, ByVal recordEnd As Integer) _
      Implements IPaginationControl.SetInfo

        'Setup current page, total page, and record display labels
        Me.lblPageTotal.Text = totalPages.ToString
        Me.txtCurrentPage.Text = currentPage.ToString
        Me.lblRecordInfo.Text = String.Format( _
          "Displaying {0}-{1} of {2} Total Items", _
          recordStart, recordEnd, totalRecords)

        'Setup validation for jumping to another page
        rngPageNumber.MinimumValue = "1"
        rngPageNumber.MaximumValue = totalPages.ToString

        'Disable 
        If currentPage = totalPages Then Me.lnkNext.Enabled = False
        If currentPage = 1 Then Me.lnkPrev.Enabled = False
        If totalPages = 1 Then Me.lnkGotoPage.Enabled = False

    End Sub

    '***************************************************************************
    Protected Sub lnkPrev_Click(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles lnkPrev.Click
        RaiseEvent PrevPageRequested()
    End Sub

    '***************************************************************************
    Protected Sub lnkNext_Click(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles lnkNext.Click
        RaiseEvent NextPageRequested()
    End Sub

    '***************************************************************************
    Protected Sub lnkGotoPage_Click(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles lnkGotoPage.Click
        If Not IsNumeric(Me.txtCurrentPage.Text) Then Exit Sub
        RaiseEvent NewPageRequested(CInt(Me.txtCurrentPage.Text))
    End Sub

End Class