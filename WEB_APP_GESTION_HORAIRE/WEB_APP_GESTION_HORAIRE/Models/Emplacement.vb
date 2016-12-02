Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports WEB_APP_GESTION_HORAIRE

Public Class Emplacement

    Public Overridable Property id As Integer

    Public Property nom_Emplacement As String
    Public Property adresse As String
    Public Property telephone As String

    Public Overridable Property entreprise As Entreprise

End Class
