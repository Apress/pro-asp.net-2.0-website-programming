Public Interface IPaginationControl

    Sub SetInfo(ByVal currentPage As Integer, ByVal totalPages As Integer, _
      ByVal totalRecords As Integer, ByVal itemsPerPage As Integer, _
      ByVal recordStart As Integer, ByVal recordEnd As Integer)
    Event NextPageRequested()
    Event PrevPageRequested()
    Event NewPageRequested(ByVal page As Integer)

End Interface
