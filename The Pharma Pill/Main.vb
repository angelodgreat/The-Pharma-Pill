Imports MySql.Data.MySqlClient
Imports Telerik.WinControls
Imports Telerik.WinControls.UI

Public Class Main

    Dim MysqlConn As MySqlConnection
    Dim query As String

    Dim adddrug As DialogResult

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_drugnamein_du()
        load_drugs_in_ph()
        load_listofdrugs()
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

    Public Sub load_drugs_in_ph()
        Try
            MysqlConn = New MySqlConnection
            MysqlConn.ConnectionString = connstring

            dm_daiph_drugname.Items.Clear()
            If MysqlConn.State = ConnectionState.Open Then
                MysqlConn.Close()
            End If

            MysqlConn.Open()
            query = "SELECT drugname FROM drugs ORDER BY drugname ASC"
            comm = New MySqlCommand(query, MysqlConn)
            reader = comm.ExecuteReader

            dm_daiph_drugname.Items.Clear()

            While reader.Read
                dm_daiph_drugname.Items.Add(reader.GetString("drugname"))
            End While
            MysqlConn.Close()

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, "The Pharma Pill", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()

        End Try
    End Sub

    'loading of drugname and available in ph
    Public Sub load_listofdrugs()
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = connstring
        Try
            Dim sda As New MySqlDataAdapter
            Dim bsource As New BindingSource
            Dim dbdataset As New DataTable

            MysqlConn.Open()
            query = "SELECT drugname as 'Drug Name' FROM drugs"
            comm = New MySqlCommand(query, MysqlConn)
            sda.SelectCommand = comm
            sda.Fill(dbdataset)
            bsource.DataSource = dbdataset
            dm_druglist.DataSource = bsource
            sda.Update(dbdataset)

            MysqlConn.Close()

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, "The Pharmacy Pill", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()
        End Try
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

                    query = "INSERT INTO drugs VALUES (@drugname,@indication,@contraindication,@specialprecautions,@sideeffects,@druginteraction,@drugtype,@adult,@adultdose,@children,@childrendose)"

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

    Private Sub du_drugname_collection_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs) Handles du_drugname_collection.SelectedIndexChanged
        Try
            MysqlConn = New MySqlConnection
            MysqlConn.ConnectionString = connstring

            If MysqlConn.State = ConnectionState.Open Then
                MysqlConn.Close()
            End If

            MysqlConn.Open()
            query = "SELECT * FROM drugs WHERE drugname=@drugname"
            comm = New MySqlCommand(query, MysqlConn)
            comm.Parameters.AddWithValue("@drugname", du_drugname_collection.Text)
            reader = comm.ExecuteReader


            While reader.Read
                du_drugfor.Text = reader.GetString("drugtype")
                du_indication.Text = reader.GetString("indication")
                du_adultdose.Text = reader.GetString("adultdose")
                du_childrendose.Text = reader.GetString("childrendose")
                du_contraindication.Text = reader.GetString("contraindication")
                du_specialprecautions.Text = reader.GetString("specialprecautions")
                du_sideeffects.Text = reader.GetString("sideeffects")
                du_druginteractions.Text = reader.GetString("druginteraction")
            End While
            MysqlConn.Close()


        Catch ex As Exception
            RadMessageBox.Show(ex.Message, "The Pharma Pill", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()
        End Try

    End Sub

    'Control Buttons in checking DrugList
    Private Sub dm_showdefault_Click(sender As Object, e As EventArgs) Handles dm_showdefault.Click
        load_listofdrugs()
    End Sub

    Private Sub dm_btn_showdrugsinph_Click(sender As Object, e As EventArgs) Handles dm_btn_showdrugsinph.Click
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = connstring
        Try
            Dim sda As New MySqlDataAdapter
            Dim bsource As New BindingSource
            Dim dbdataset As New DataTable

            MysqlConn.Open()
            query = "SELECT drugname as 'Drug Name' , brandnameintheph as 'Available in Philippines' FROM brandnameinphtable"
            comm = New MySqlCommand(query, MysqlConn)
            sda.SelectCommand = comm
            sda.Fill(dbdataset)
            bsource.DataSource = dbdataset
            dm_druglist.DataSource = bsource
            sda.Update(dbdataset)

            MysqlConn.Close()

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, "The Pharmacy Pill", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()

            Dim columndrugname = dm_druglist.Columns(0)
            columndrugname.Width = 50

            Dim columnbrandnameinph = dm_druglist.Columns(1)
            columnbrandnameinph.Width = 50
        End Try
    End Sub

    Private Sub dm_daiph_btn_save_Click(sender As Object, e As EventArgs) Handles dm_daiph_btn_save.Click
        Try
            adddrug = RadMessageBox.Show("Are you sure you want to add this drug?", "The Pharma Pill", MessageBoxButtons.YesNo, RadMessageIcon.Question)

            If adddrug = MsgBoxResult.Yes Then

                MysqlConn = New MySqlConnection
                MysqlConn.ConnectionString = connstring
                Dim reader As MySqlDataReader

                If dm_daiph_drugname.Text = "" Then
                    RadMessageBox.Show("Please choose a drug name", "The Pharma Pill", MessageBoxButtons.YesNo, RadMessageIcon.Exclamation)

                Else
                    MysqlConn.Close()
                    MysqlConn.Open()

                    query = "INSERT INTO brandnameinphtable VALUES (@drugname,@brandnameintheph)"

                    comm = New MySqlCommand(query, MysqlConn)
                    comm.Parameters.AddWithValue("@drugname", dm_daiph_drugname.Text)
                    comm.Parameters.AddWithValue("@brandnameintheph", dm_daiph_tb_brandinph.Text)


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




    'Private Sub RadButton1_Click(sender As Object, e As EventArgs)
    '	WebBrowser1.Navigate("file:///" & IO.Path.GetFullPath(".\test.html"))
    'End Sub

End Class
