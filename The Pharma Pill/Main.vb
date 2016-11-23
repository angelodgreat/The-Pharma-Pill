Imports MySql.Data.MySqlClient
Imports Telerik.WinControls
Imports Telerik.WinControls.UI

Public Class Main

    Dim MysqlConn As MySqlConnection
    Dim query As String


    Dim adddrug As DialogResult

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_drugnamein_du()
    End Sub
    Private Sub dm_btn_save_Click(sender As Object, e As EventArgs) Handles dm_btn_save.Click
        Try
            adddrug = RadMessageBox.Show("Are you sure you want to add this drug?", "The Pharma Pill", MessageBoxButtons.YesNo, RadMessageIcon.Question)

            If adddrug = MsgBoxResult.Yes Then

                MysqlConn = New MySqlConnection
                MysqlConn.ConnectionString = connstring
                Dim reader As MySqlDataReader

                If dm_drugname.Text = "" Then
                    RadMessageBox.Show("Please input a drug name", "The Pharma Pill", MessageBoxButtons.YesNo, RadMessageIcon.Exclamation)

                Else
                    MysqlConn.Close()
                    MysqlConn.Open()

                    query = "INSERT INTO drugs VALUES (@drugname,@indication,@contraindication,@specialprecautions,@sideeffects,@druginteraction,@drugtype);
                             INSERT INTO dosinginformationtable VALUES (@drugname,@adult,@adultdose,@children,@childrendose) "
                    comm = New MySqlCommand(query, MysqlConn)
                    comm.Parameters.AddWithValue("@drugname", dm_drugname.Text)
                    comm.Parameters.AddWithValue("@indication", dm_indication.Text)
                    comm.Parameters.AddWithValue("@contraindication", dm_contraindication.Text)
                    comm.Parameters.AddWithValue("@specialprecautions", dm_specialprecaution.Text)
                    comm.Parameters.AddWithValue("@sideeffects", dm_sideeffects.Text)
                    comm.Parameters.AddWithValue("@druginteraction", dm_druginteractions.Text)
                    comm.Parameters.AddWithValue("@drugtype", dm_drugtype.Text)
                    comm.Parameters.AddWithValue("@adult", dm_adult.Text)
                    comm.Parameters.AddWithValue("@adultdose", dm_adultdose.Text)
                    comm.Parameters.AddWithValue("@children", dm_children.Text)
                    comm.Parameters.AddWithValue("@childrendose", dm_childrendose.Text)

                    reader = comm.ExecuteReader
                    MysqlConn.Close()

                    RadMessageBox.Show(Me, "Succesfully saved!", "The Pharma Pill", MessageBoxButtons.OK, RadMessageIcon.Info)


                End If

            End If

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, "The Pharma Pill", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()


        End Try
    End Sub

    Public Sub load_drugnamein_du()
        Try
            MysqlConn = New MySqlConnection
            MysqlConn.ConnectionString = connstring

            du_drugname_collection.Items.Clear()
            If MysqlConn.State = ConnectionState.Open Then
                MysqlConn.Close()
            End If


            MysqlConn.Open()
            query = "SELECT drugname FROM drugs ORDER BY drugname ASC"
            comm = New MySqlCommand(query, MysqlConn)
            reader = comm.ExecuteReader

            du_drugname_collection.Items.Clear()

            While reader.Read
                du_drugname_collection.Items.Add(reader.GetString("drugname"))
            End While
            MysqlConn.Close()

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, "The Pharma Pill", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()

        End Try


    End Sub

    Private Sub du_drugname_collection_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs) Handles du_drugname_collection.SelectedIndexChanged
        'TO BE CONTINUED
        'Try
        '    MysqlConn = New MySqlConnection
        '    MysqlConn.ConnectionString = connstring

        '    If MysqlConn.State = ConnectionState.Open Then
        '        MysqlConn.Close()
        '    End If


        '    MysqlConn.Open()
        '    query = "SELECT drugname FROM drugs ORDER BY drugname ASC"
        '    comm = New MySqlCommand(query, MysqlConn)
        '    reader = comm.ExecuteReader

        '    du_drugname_collection.Items.Clear()

        '    While reader.Read
        '        du_drugname_collection.Items.Add(reader.GetString("drugname"))
        '    End While
        '    MysqlConn.Close()

        'Catch ex As Exception
        '    RadMessageBox.Show(ex.Message, "The Pharma Pill", MessageBoxButtons.OK, RadMessageIcon.Error)
        'Finally
        '    MysqlConn.Dispose()

        'End Try
    End Sub





    'Private Sub RadButton1_Click(sender As Object, e As EventArgs)
    '	WebBrowser1.Navigate("file:///" & IO.Path.GetFullPath(".\test.html"))
    'End Sub

End Class
