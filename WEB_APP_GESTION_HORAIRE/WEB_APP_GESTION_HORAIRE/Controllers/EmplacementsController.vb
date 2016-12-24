Imports System.Web.Mvc

Namespace Controllers
    Public Class EmplacementsController
        Inherits Controller

        ' GET: Emplacements
        Function ListeEmplacements() As ActionResult
            If Not Session("AdminRights") Then
                Return Nothing
            End If

            Using accessLayer As New Dal
                Dim liste As List(Of Emplacement) = accessLayer.obtenirEmplacements()
                Dim entrepr As List(Of Entreprise) = accessLayer.obtenirEntreprises()
                ViewBag.entrepr = entrepr

                Return View("ListeEmplacements", liste)
            End Using

        End Function

        Function CreerEmplacement() As ActionResult
            If Not Session("AdminRights") Then
                Return Nothing
            End If


            Using accessLayer As New Dal
                Dim liste As List(Of Entreprise) = accessLayer.obtenirEntreprises()
                ViewBag.entreprises = liste
            End Using


            Return View("CreerEmplacement")


        End Function


        <HttpPost>
        Function enregistrerEmplacement() As ActionResult
            If Not Session("AdminRights") Then
                Return Nothing
            End If

            Dim nomEmplacement As String = Request("nom_emplacement")

            Dim adresse As String = Request("adresse")
            Dim telephone As String = Request("telephone")
            Dim id_entreprise As Integer = Request("entreprise")



            Using accessLayer As New Dal
                accessLayer.ajouterEmplacement(nomEmplacement, adresse, telephone, id_entreprise)

                Return RedirectToAction("ListeEmplacements")

            End Using

        End Function


        <HttpPost>
        Function supprimerEmplacement() As ActionResult
            If Session("AdminRights") Then


                Using accessLayer As New Dal()
                    accessLayer.supprimerEmplacement(Request("id_emplacement"))

                    Return RedirectToAction("ListeEmplacements")
                End Using


            End If
            Return Nothing

        End Function

    End Class
End Namespace