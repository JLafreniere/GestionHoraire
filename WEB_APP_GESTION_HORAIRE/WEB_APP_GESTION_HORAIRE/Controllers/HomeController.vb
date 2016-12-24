Imports System.Web.Mvc
Imports System.Linq

Namespace Controllers
    Public Class HomeController
        Inherits Controller

        ' GET: Home
        Function Index() As ActionResult

            Using d As New Dal()
                Dim listeUser = d.obtenirTousLesUtilisateurs()
                Dim utilisateur As Utilisateur
                Try
                    utilisateur = (From u As Utilisateur In listeUser
                                   Where u.id = Integer.Parse(Session("UID"))
                                   Select u).ToList()(0)
                    System.Diagnostics.Debug.WriteLine(Session("UserName") & " --- accueil")
                    ViewBag.user = utilisateur.prenom + " " + utilisateur.nom
                Catch exc As Exception
                    ViewBag.user = exc.Message
                End Try

            End Using
            Return View()

        End Function







        Function GererHoraires()
            If Session("AdminRights") Then
                Return View()
            Else Return View("~/Views/Shared/PermissionDenied.vbhtml")
            End If

        End Function

        Function VoirHoraires()
            If Session("AdminRights") Then
                Return View()
            Else Return View("~/Views/Shared/PermissionDenied.vbhtml")
            End If
        End Function



        Function MonHoraire()
            If Session("UserLogged") Then
                Return View()
            Else Return View("~/Views/Shared/PermissionDenied.vbhtml")
            End If
        End Function



    End Class
End Namespace