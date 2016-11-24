Public Class FAQ
    Private Sub FAQ_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        wb_faq.Navigate("file:///" & IO.Path.GetFullPath(".\FAQ.html"))
    End Sub
End Class
