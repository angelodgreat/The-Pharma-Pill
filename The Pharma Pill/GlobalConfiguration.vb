Imports MySql.Data.MySqlClient

Module GlobalConfiguration
    Public MySQLConn As New MySqlConnection
    Public connstring As String = "server=localhost;database=thepharmapill;port=3306;uid=root;password=root;"
    Public comm As MySqlCommand
    Public reader As MySqlDataReader
    Public adapter As New MySqlDataAdapter
End Module
