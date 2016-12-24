Imports System.ComponentModel.DataAnnotations
Imports WEB_APP_GESTION_HORAIRE

Public Class Entreprise

    Public Property id As Integer
    <MinLength(2)>
    Public Property nom_Entreprise As String



    Public Shared Widening Operator CType(v As Integer) As Entreprise
        Dim bdd As New BddContext("ConnStringDb1")
        Return bdd.Entreprises.FirstOrDefault(Function(entr) entr.id = v)
    End Operator




End Class
