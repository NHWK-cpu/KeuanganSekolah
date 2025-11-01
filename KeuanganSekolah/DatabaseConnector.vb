Imports MySql.Data.MySqlClient
Imports System.Configuration

Public Module DatabaseConnector
    Public ReadOnly Property ConnectionString As String
        Get
            Return ConfigurationManager.ConnectionStrings("MySqlConn").ConnectionString
        End Get
    End Property

    Public Function GetConnection() As MySqlConnection
        Return New MySqlConnection(ConnectionString)
    End Function

    ' Returns a DataTable for a SELECT (or any query that returns rows).
    Public Function GetDataTable(query As String, Optional parameters As Dictionary(Of String, Object) = Nothing) As DataTable
        Dim dt As New DataTable()
        Using conn = DatabaseConnector.GetConnection()
            Using cmd = New MySqlCommand(query, conn)
                If parameters IsNot Nothing Then
                    For Each kvp In parameters
                        cmd.Parameters.AddWithValue(kvp.Key, If(kvp.Value, DBNull.Value))
                    Next
                End If
                Using adapter = New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    ' Executes a scalar query (e.g. COUNT(*), MAX(...)) and returns the raw object result.
    Public Function ExecuteScalar(query As String, Optional parameters As Dictionary(Of String, Object) = Nothing) As Object
        Using conn = DatabaseConnector.GetConnection()
            Using cmd = New MySqlCommand(query, conn)
                If parameters IsNot Nothing Then
                    For Each kvp In parameters
                        cmd.Parameters.AddWithValue(kvp.Key, If(kvp.Value, DBNull.Value))
                    Next
                End If
                conn.Open()
                Return cmd.ExecuteScalar()
            End Using
        End Using
    End Function

End Module
