
Partial Class ViewEmployee
    Inherits System.Web.UI.Page

    '***************************************************************************
    Public ReadOnly Property EmployeeID() As Integer
        Get
            If IsNumeric(Request.QueryString("EmployeeID")) Then
                Return Integer.Parse(Request.QueryString("EmployeeID"))
            Else
                Return 0
            End If
        End Get
    End Property

    '***************************************************************************
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
      Handles Me.Load

        Dim EmployeeObj As Employee = Employee.GetEmployeeById(EmployeeID)

        If Not EmployeeObj Is Nothing Then
            With EmployeeObj
                lblHeading.Text = .FirstName & " " & .LastName
                lblTitleOfCourtesy.Text = .TitleOfCourtesy
                lblFirstName.Text = .FirstName
                lblLastName.Text = .LastName
                lblAddress.Text = .Address
                lblCity.Text = .City
                lblPostalCode.Text = .PostalCode
                lblCountry.Text = .Country
                lblHomePhone.Text = .HomePhone
                lblJobTitle.Text = .Title
                lblExtension.Text = .Extension
                lblNotes.Text = .Notes

                If Not .BirthDate = Nothing Then _
                  lblBirthDate.Text = Format(.BirthDate, "MM/dd/yyyy")

                If Not .HireDate = Nothing Then _
                  lblHireDate.Text = Format(.HireDate, "MM/dd/yyyy")

            End With
        End If

    End Sub

End Class
