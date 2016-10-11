
Partial Class ExceptionWrappingDemo_aspx
    Inherits System.Web.UI.Page

    '***************************************************************************
    Public Function AddNumbersInStringArray(ByVal Numbers() As String) As Long
        Try

            Dim Total As Long = 0
            For Each s As String In Numbers
                Dim l As Long = CLng(s)
                Total += l
            Next
        Catch ex As Exception
            Dim Message As String = "There was an invliad number in the " & _
                                    "Numbers array.  All of the values " & _
                                    "in the Numbers array must be string " & _
                                    "representations of numerical values."

            'Wrap orig. message in a new exception with a detailed message
            'ex (the original exception) will become the inner exception of
            'the ArgumentException.
            Throw New ArgumentException(Message, ex)

        End Try
    End Function

    '***************************************************************************
    Sub btnCreateWrappedException_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Dim NumberArray As String() = Split(Me.txtNumbers.Text, ",")
            Me.lblInfo.Text = "The total value is " & AddNumbersInStringArray(NumberArray)

        Catch ex As Exception

            Dim UseSep As Boolean = False

            While Not ex Is Nothing
                If Not UseSep Then
                    Me.lblInfo.Text = "<span style='text-decoration:underline; font-weight:bold'>Exception Info</span><br />"
                    UseSep = True
                Else
                    Me.lblInfo.Text &= "<br /><br />"
                    Me.lblInfo.Text &= "<span style='text-decoration:underline; font-weight:bold'>Inner Exception Info</span><br />"
                End If

                Me.lblInfo.Text &= "<strong>Exception Type:</strong>"
                Me.lblInfo.Text &= ex.GetType.ToString & "<BR>"
                Me.lblInfo.Text &= "<strong>Message:</strong>"
                Me.lblInfo.Text &= ex.Message

                ex = ex.InnerException

            End While

        End Try

    End Sub

End Class
