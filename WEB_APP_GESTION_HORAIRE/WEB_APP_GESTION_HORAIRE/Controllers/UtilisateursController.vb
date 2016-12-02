Imports System.Web.Mvc

Namespace Controllers
    Public Class UtilisateursController
        Inherits Controller

        Function Utilisateurs()
            If Session("AdminRights") Then
                Using accessLayer As New Dal

                    Return View("CreerUtilisateur")
                End Using

            Else Return View("~/Views/Shared/PermissionDenied.vbhtml")
            End If
        End Function




        Function ListeUtilisateurs()
            If Session("AdminRights") Then
                Using accessLayer As New Dal
                    Dim users As List(Of Utilisateur) = accessLayer.obtenirTousLesUtilisateurs()
                    ViewBag.users = users
                    Return View(users)
                End Using

            Else Return View("~/Views/Shared/PermissionDenied.vbhtml")
            End If
        End Function

        <HttpPost>
        Function creerUtilisateur() As ActionResult
            If Session("AdminRights") Then
                Debug.WriteLine("Création " + Request("username") + " P: " + Request("password"))

                Dim username As String = Request("username")
                Dim password As String = Request("password")
                Dim email As String = Request("email")
                Dim admin As Boolean
                Dim nom As String = Request("nom")
                Dim prenom As String = Request("prenom")
                Dim telephone As String = Request("telephone")
                Try
                    admin = Request("admin")
                Catch exc As Exception
                    admin = True
                End Try


                Using accessLayer As New Dal()
                    accessLayer.ajouterUtilisateur(username, password, email, admin, nom, prenom, telephone)


                End Using
                Return RedirectToAction("Index", "Home")

            Else Return View("~/Views/Shared/PermissionDenied.vbhtml")
            End If

        End Function
        <HttpPost>
        Function supprimerUtilisateur() As ActionResult
            If Session("AdminRights") Then


                Using accessLayer As New Dal()
                    accessLayer.supprimerUtilisateur(Request("id_utilisateur"))
                    Dim users As List(Of Utilisateur) = accessLayer.obtenirTousLesUtilisateurs()
                    ViewBag.users = users
                    Return View("ListeUtilisateurs", users)
                End Using


            End If
            Return Nothing

        End Function


        <HttpPost>
        Function DeconnecterUtilisateur() As ActionResult
            Session.Clear()

            Return View("~/Views/Home/Index.vbhtml")
        End Function

        <HttpPost>
        Function ConnecterUtilisateur() As ActionResult
            Dim _username As String = Request("_username")
            Dim password As String = Request("password")
            Session.Timeout = 10000

            Debug.WriteLine(Request("_username") + " P: " + Request("password"))

            Using accessLayer As New Dal
                Dim users As List(Of Utilisateur) = accessLayer.obtenirTousLesUtilisateurs()
                Dim requestedUser = From u In users
                                    Where u.username = _username And u.password = Utilisateur.Hash512(password, u.salt)
                                    Select u
                Try

                    Debug.WriteLine("Connexion" + requestedUser(0).username)
                    Session("UID") = requestedUser(0).id
                    Session("AdminRights") = requestedUser(0).admin
                    Session("UserLogged") = True
                    Return RedirectToAction("Index", "Home")

                Catch exc As Exception
                    Debug.WriteLine("utilisateur invalide")
                    Return RedirectToAction("Index", "Home")
                End Try

            End Using


        End Function

    End Class
End Namespace