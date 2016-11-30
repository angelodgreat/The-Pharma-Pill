Public Class About
    Private Sub About_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        about_wb.Navigate("file:///" & IO.Path.GetFullPath(".\About\About.html"))
    End Sub
End Class
