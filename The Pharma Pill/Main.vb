Imports MySql.Data.MySqlClient
Imports Telerik.WinControls
Imports Telerik.WinControls.UI

Public Class Main

    Dim MysqlConn As MySqlConnection
    Dim query As String

    Dim adddrug As DialogResult
    Dim updatedrug As DialogResult
    Dim exityn As DialogResult

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        load_listofdrugs()
        dm_btn_update.Hide()
        load_drug_for_dm()

        ThemeResolutionService.ApplicationThemeName = "TelerikMetroBlue"
    End Sub


    Public Sub load_drug_for_dm()
        Try
            MysqlConn = New MySqlConnection
            MysqlConn.ConnectionString = connstring


            dm_drugfor.Items.Clear()
            du_drugfor_collection.Items.Clear()

            If MysqlConn.State = ConnectionState.Open Then
                MysqlConn.Close()
            End If

            MysqlConn.Open()
            query = "SELECT DISTINCT drugfor FROM drugs ORDER BY drugfor ASC"
            comm = New MySqlCommand(query, MysqlConn)
            reader = comm.ExecuteReader


            dm_drugfor.Items.Clear()
            du_drugfor_collection.Items.Clear()

            While reader.Read
                dm_drugfor.Items.Add(reader.GetString("drugfor"))
                du_drugfor_collection.Items.Add(reader.GetString("drugfor"))
            End While
            MysqlConn.Close()

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, "The Pharma Pill", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()

        End Try
    End Sub


    Private Sub du_drugfor_collection_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs) Handles du_drugfor_collection.SelectedIndexChanged
        Try
            MysqlConn = New MySqlConnection
            MysqlConn.ConnectionString = connstring

            du_drugclassification_collection.Items.Clear()


            If MysqlConn.State = ConnectionState.Open Then
                MysqlConn.Close()
            End If

            MysqlConn.Open()
            query = "SELECT DISTINCT drugclassification FROM drugs WHERE drugfor=@drugfor ORDER BY drugclassification ASC"
            comm = New MySqlCommand(query, MysqlConn)
            comm.Parameters.AddWithValue("@drugfor", du_drugfor_collection.Text)
            reader = comm.ExecuteReader

            du_drugclassification_collection.Items.Clear()

            While reader.Read
                du_drugclassification_collection.Items.Add(reader.GetString("drugclassification"))

            End While
            MysqlConn.Close()

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, "The Pharma Pill", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()

        End Try

    End Sub

    Private Sub du_drugclassification_collection_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs) Handles du_drugclassification_collection.SelectedIndexChanged
        Try
            MysqlConn = New MySqlConnection
            MysqlConn.ConnectionString = connstring

            du_drugname_collection.Items.Clear()


            If MysqlConn.State = ConnectionState.Open Then
                MysqlConn.Close()
            End If

            MysqlConn.Open()
            query = "SELECT drugname FROM drugs WHERE drugclassification=@drugclassfication ORDER BY drugname ASC"
            comm = New MySqlCommand(query, MysqlConn)
            comm.Parameters.AddWithValue("@drugclassfication", du_drugclassification_collection.Text)
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









    'loading of drugname and available in ph
    Public Sub load_listofdrugs()
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = connstring
        Try
            Dim sda As New MySqlDataAdapter
            Dim bsource As New BindingSource
            Dim dbdataset As New DataTable

            MysqlConn.Open()
            query = "SELECT drugname as 'Drug Name',drugfor as 'Drug For' FROM drugs"
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
                du_drugfor.Text = reader.GetString("drugfor")
                du_indication.Text = reader.GetString("indication")
                du_contraindication.Text = reader.GetString("contraindication")
                du_specialprecautions.Text = reader.GetString("specialprecautions")
                du_sideeffects.Text = reader.GetString("sideeffects")
                du_druginteractions.Text = reader.GetString("druginteraction")
                du_dosinginformationtype.Text = reader.GetString("dosinginformationtype")
                du_dosinginformation.Text = reader.GetString("dosinginformation")
                du_lbl_drugavailableinph.Text = reader.GetString("drugsavailableinph")
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

    Private Sub dm_btn_save_Click(sender As Object, e As EventArgs) Handles dm_btn_save.Click
        Try
            If (dm_drugname.Text = "") Or (dm_drugfor.Text = "") Or (dm_drugclassification.Text = "") Then
                RadMessageBox.Show("Please input a Drug For, Drug Classification and Drug Name!", "The Pharma Pill", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Else

                adddrug = RadMessageBox.Show("Are you sure you want to add this drug?", "The Pharma Pill", MessageBoxButtons.YesNo, RadMessageIcon.Question)

            If adddrug = MsgBoxResult.Yes Then

                MysqlConn = New MySqlConnection
                MysqlConn.ConnectionString = connstring
                Dim reader As MySqlDataReader


                    MysqlConn.Close()
                    MysqlConn.Open()

                    query = "INSERT INTO drugs VALUES (@drugfor,@drugclassification,@drugname,@indication,@contraindication,@specialprecautions,@sideeffects,@druginteraction,@dosinginformationtype,@dosinginformation,@brandnameintheph)"

                    comm = New MySqlCommand(query, MysqlConn)
                    comm.Parameters.AddWithValue("@drugfor", dm_drugfor.Text)
                    comm.Parameters.AddWithValue("@drugclassification", dm_drugclassification.Text)
                    comm.Parameters.AddWithValue("@drugname", dm_drugname.Text)
                    comm.Parameters.AddWithValue("@indication", dm_indication.Text)
                    comm.Parameters.AddWithValue("@contraindication", dm_contraindication.Text)
                    comm.Parameters.AddWithValue("@specialprecautions", dm_specialprecautions.Text)
                    comm.Parameters.AddWithValue("@sideeffects", dm_sideeffects.Text)
                    comm.Parameters.AddWithValue("@druginteraction", dm_druginteractions.Text)
                    comm.Parameters.AddWithValue("dosinginformationtype", dm_dosinginformationtype.Text)
                    comm.Parameters.AddWithValue("@dosinginformation", dm_dosinginformation.Text)
                    comm.Parameters.AddWithValue("@brandnameintheph", dm_drugsinph.Text)

                    reader = comm.ExecuteReader
                    MysqlConn.Close()

                    RadMessageBox.Show(Me, "Succesfully Saved!", "The Pharma Pill", MessageBoxButtons.OK, RadMessageIcon.Info)
                End If
            End If

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, "The Pharma Pill", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()

            load_listofdrugs()
            load_drug_for_dm()
        End Try
    End Sub


    Private Sub dm_btn_update_Click(sender As Object, e As EventArgs) Handles dm_btn_update.Click
        Try
            MysqlConn = New MySqlConnection
            MysqlConn.ConnectionString = connstring

            If MysqlConn.State = ConnectionState.Open Then
                MysqlConn.Close()
            End If
            If (dm_drugfor.Text = "") Or (dm_drugname.Text = "") Or (dm_drugclassification.Text = "") Then
                RadMessageBox.Show(Me, "Please double check your fields. The fields Drug For, Drug Classification and Drug Name should have an input.", "The Pharma Pill", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Else

                updatedrug = RadMessageBox.Show(Me, "Are you sure you want to update this record?", "The Pharma Pill", MessageBoxButtons.YesNo, RadMessageIcon.Question)
            If updatedrug = MsgBoxResult.Yes Then


                    MysqlConn.Open()
                    query = "UPDATE drugs SET drugfor=@drugfor,drugclassification=@drugclassification,drugname=@drugname,indication=@indication,contraindication=@contraindication,specialprecautions=@specialprecautions,sideeffects=@sideeffects,druginteraction=@druginteraction,dosinginformationtype=@dosinginformationtype,dosinginformation=@dosinginformation,drugsavailableinph=@brandnameintheph WHERE drugfor=@drugfor AND drugname=@drugname AND drugclassification=@drugclassification"

                    comm = New MySqlCommand(query, MysqlConn)
                    comm.Parameters.AddWithValue("@drugfor", dm_drugfor.Text)
                    comm.Parameters.AddWithValue("@drugclassification", dm_drugclassification.Text)
                    comm.Parameters.AddWithValue("@drugname", dm_drugname.Text)
                    comm.Parameters.AddWithValue("@indication", dm_indication.Text)
                    comm.Parameters.AddWithValue("@contraindication", dm_contraindication.Text)
                    comm.Parameters.AddWithValue("@specialprecautions", dm_specialprecautions.Text)
                    comm.Parameters.AddWithValue("@sideeffects", dm_sideeffects.Text)
                    comm.Parameters.AddWithValue("@druginteraction", dm_druginteractions.Text)
                    comm.Parameters.AddWithValue("dosinginformationtype", dm_dosinginformationtype.Text)
                    comm.Parameters.AddWithValue("@dosinginformation", dm_dosinginformation.Text)
                    comm.Parameters.AddWithValue("@brandnameintheph", dm_drugsinph.Text)

                    reader = comm.ExecuteReader
                    MysqlConn.Close()

                    RadMessageBox.Show(Me, "Succesfully Updated!", "The Pharma Pill", MessageBoxButtons.OK, RadMessageIcon.Info)

                End If
            End If


        Catch ex As Exception
            RadMessageBox.Show(ex.Message, "The Pharma Pill", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()

            load_listofdrugs()
            load_drug_for_dm()

        End Try
    End Sub



    Private Sub rmi_faq_Click(sender As Object, e As EventArgs) Handles rmi_faq.Click
        Dim faq As New FAQ
        faq.Show()
    End Sub

    Private Sub dm_btn_clear_Click(sender As Object, e As EventArgs) Handles dm_btn_clear.Click
        dm_drugfor.Text = ""
        dm_drugclassification.Text = ""
        dm_drugname.Text = ""
        dm_indication.Text = ""
        dm_contraindication.Text = ""
        dm_specialprecautions.Text = ""
        dm_sideeffects.Text = ""
        dm_druginteractions.Text = ""
        dm_dosinginformationtype.Text = ""
        dm_dosinginformation.Text = ""
        dm_drugclassification.Text = ""
        dm_drugsinph.Text = ""
        dm_btn_update.Hide()
    End Sub

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        exityn = RadMessageBox.Show("Are you sure you want to exit?", "The Pharma Pill", MessageBoxButtons.YesNo, RadMessageIcon.Question)

        If exityn = MsgBoxResult.Yes Then
            Me.Dispose()

        ElseIf exityn = MsgBoxResult.No Then
            e.Cancel = True
        End If



    End Sub

    Private Sub dm_druglist_CellClick(sender As Object, e As GridViewCellEventArgs) Handles dm_druglist.CellClick
        dm_btn_update.Show()

        If e.RowIndex >= 0 Then
            Dim row As Telerik.WinControls.UI.GridViewRowInfo

            row = Me.dm_druglist.Rows(e.RowIndex)

            dm_drugname.Text = row.Cells("Drug Name").Value.ToString
        End If

        Try
            MysqlConn = New MySqlConnection
            MysqlConn.ConnectionString = connstring
            Dim reader As MySqlDataReader

            If MysqlConn.State = ConnectionState.Open Then
                MysqlConn.Close()
            End If

            MysqlConn.Open()
            query = "SELECT * FROM drugs WHERE drugname=@drugname"
            comm = New MySqlCommand(query, MysqlConn)
            comm.Parameters.AddWithValue("@drugname", dm_drugname.Text)
            reader = comm.ExecuteReader

            While reader.Read
                dm_drugfor.Text = reader.GetString("drugfor")
                dm_indication.Text = reader.GetString("indication")
                dm_drugclassification.Text = reader.GetString("drugclassification")
                dm_contraindication.Text = reader.GetString("contraindication")
                dm_specialprecautions.Text = reader.GetString("specialprecautions")
                dm_sideeffects.Text = reader.GetString("sideeffects")
                dm_druginteractions.Text = reader.GetString("druginteraction")
                dm_dosinginformationtype.Text = reader.GetString("dosinginformationtype")
                dm_dosinginformation.Text = reader.GetString("dosinginformation")
                dm_drugsinph.Text = reader.GetString("drugsavailableinph")

            End While
            MysqlConn.Close()

            'TO BE FINISHED
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, "The Pharma Pill", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()
        End Try




    End Sub

    Private Sub dm_drugfor_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs) Handles dm_drugfor.SelectedIndexChanged
        Try
            MysqlConn = New MySqlConnection
            MysqlConn.ConnectionString = connstring

            dm_drugclassification.Items.Clear()

            If MysqlConn.State = ConnectionState.Open Then
                MysqlConn.Close()
            End If

            MysqlConn.Open()
            query = "SELECT DISTINCT drugclassification FROM drugs WHERE drugfor=@drugfor ORDER BY drugclassification ASC"
            comm = New MySqlCommand(query, MysqlConn)
            comm.Parameters.AddWithValue("@drugfor", dm_drugfor.Text)
            reader = comm.ExecuteReader

            dm_drugclassification.Items.Clear()


            While reader.Read
                dm_drugclassification.Items.Add(reader.GetString("drugclassification"))

            End While
            MysqlConn.Close()

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, "The Pharma Pill", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()

        End Try
    End Sub

    Private Sub go_toabout_Click(sender As Object, e As EventArgs) Handles go_toabout.Click
        Dim about As New About
        about.Show()
    End Sub






    'Private Sub RadButton1_Click(sender As Object, e As EventArgs)
    '	WebBrowser1.Navigate("file:///" & IO.Path.GetFullPath(".\test.html"))
    'End Sub

End Class
