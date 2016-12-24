Imports System.Web.Mvc

Namespace Controllers
    Public Class EntreprisesController
        Inherits Controller

        ' GET: Entreprises
        Function ListeEntreprises() As ActionResult
            If Not Session("AdminRights") Then
                Return Nothing
            End If

            Using accessLayer As New Dal
                Dim liste As List(Of Entreprise) = accessLayer.obtenirEntreprises()

                Return View("ListeEntreprises", liste)
            End Using

        End Function

        Function CreerEntreprise() As ActionResult
            If Not Session("AdminRights") Then
                Return Nothing
            End If
            Return View("CreerEntreprise")
        End Function

        Function entreprises()
            If Not Session("AdminRights") Then
                Return Nothing
            End If
            Using accessLayer As New Dal
                Dim liste As List(Of Entreprise) = accessLayer.obtenirEntreprises()

                Return View("ListeEntreprises", liste)
            End Using
        End Function

        <HttpPost>
        Function enregistrerEntreprise() As ActionResult
            If Not Session("AdminRights") Then
                Return Nothing
            End If

            Dim nomEntreprise = Request("nom_Entreprise")



            Using accessLayer As New Dal
                accessLayer.ajouterEntreprise(nomEntreprise)
                Dim liste As List(Of Entreprise) = accessLayer.obtenirEntreprises()

                Return View("ListeEntreprises", liste)
            End Using

        End Function

        <HttpPost>
        Function supprimerEntreprise() As ActionResult
            If Session("AdminRights") Then


                Using accessLayer As New Dal()
                    accessLayer.supprimerEntreprise(Request("id_entreprise"))
                    Dim users As List(Of Utilisateur) = accessLayer.obtenirTousLesUtilisateurs()
                    ViewBag.users = users
                    Return RedirectToAction("entreprises")
                End Using


            End If
            Return Nothing

        End Function





    End Class
End Namespace