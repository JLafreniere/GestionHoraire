Imports System.ComponentModel.DataAnnotations
Imports System.Security.Cryptography

Public Class Utilisateur

    Public Property id As Integer
    <MinLength(5)>
    Public Property username As String
    <MinLength(5)>
    Public Property password As String
    <MinLength(2)>
    Public Property nom As String
    <MinLength(2)>
    Public Property prenom As String
    Public Property telephone As String
    Public Property email As String
    Public Property admin As Boolean
    Public Property salt As String


    Public Shared Function CreateRandomSalt() As String
        'the following is the string that will hold the salt charachters
        Dim mix As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+=][}{<>"
        Dim salt As String = ""
        Dim rnd As New Random
        Dim sb As New StringBuilder
        For i As Integer = 1 To 100 'Length of the salt
            Dim x As Integer = rnd.Next(0, mix.Length - 1)
            salt &= (mix.Substring(x, 1))
        Next
        Return salt
    End Function

    Public Shared Function Hash512(password As String, salt As String) As String
        Dim convertedToBytes As Byte() = Encoding.UTF8.GetBytes(password & salt)
        Dim hashType As HashAlgorithm = New SHA512Managed()
        Dim hashBytes As Byte() = hashType.ComputeHash(convertedToBytes)
        Dim hashedResult As String = Convert.ToBase64String(hashBytes)
        Return hashedResult
    End Function


End Class
