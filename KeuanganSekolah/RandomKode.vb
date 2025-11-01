Imports System
Imports System.Text

Module RandomKode
    Function GenerateRandomString(Optional length As Integer = 8) As String
        Dim chars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"
        Dim result As New StringBuilder()
        Dim rand As New Random()

        For i As Integer = 1 To length
            Dim index As Integer = rand.Next(0, chars.Length)
            result.Append(chars(index))
        Next

        Return result.ToString()
    End Function

    Sub Main()
        Dim randomStr As String = GenerateRandomString()
        Console.WriteLine(randomStr)
    End Sub
End Module
