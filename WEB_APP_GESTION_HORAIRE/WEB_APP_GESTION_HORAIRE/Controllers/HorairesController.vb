
Imports System.Web.Mvc

Namespace Controllers
    Public Class HorairesController
        Inherits Controller

        ' GET: Horaires
        Function Horaires() As ActionResult
            If Not Session("AdminRights") Then
                Return Nothing
            End If


            Using accessLayer As New Dal
                Dim entreprises As List(Of Entreprise) = accessLayer.obtenirEntreprises()
                Dim emplacement As List(Of Emplacement) = accessLayer.obtenirEmplacements()
                Dim employes As List(Of Utilisateur) = accessLayer.obtenirTousLesUtilisateurs()
                ViewBag.employes = employes
                ViewBag.emplacements = emplacement
                ViewBag.entreprises = entreprises
            End Using




            Return View("Horaires")
        End Function

        Function CreerQuart()
            If Not Session("AdminRights") Then
                Return Nothing
            End If


            Using accessLayer As New Dal
                Dim employes As List(Of Utilisateur) = accessLayer.obtenirTousLesUtilisateurs()
                Dim emplacement As List(Of Emplacement) = accessLayer.obtenirEmplacements()
                ViewBag.employes = employes
                ViewBag.emplacements = emplacement
            End Using




            Return View("CreerQuart")
        End Function
    End Class
End Namespace