Imports System.Web.Mvc

Namespace Controllers
    Public Class UtilisateursController
        Inherits Controller

        Function Utilisateurs()
            If Session("AdminRights") Then
                Using accessLayer As New Dal
                    ViewBag.fail = False
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
                    Dim success As Boolean = accessLayer.ajouterUtilisateur(username, password, email, admin, nom, prenom, telephone)
                    If success Then
                        Return RedirectToAction("Index", "Home")
                    Else
                        ViewBag.fail = True
                        Return View("CreerUtilisateur")
                    End If

                End Using


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

            Try

                Dim _username As String = Request("_username")
                Dim password As String = Request("password")




                Using accessLayer As New Dal
                    Dim users As List(Of Utilisateur) = accessLayer.obtenirTousLesUtilisateurs()
                    Dim requestedUser As Utilisateur = (From u In users
                                                        Where u.username = _username And u.password = Utilisateur.Hash512(password, u.salt)
                                                        Select u).ToList()(0)

                    System.Diagnostics.Debug.WriteLine(requestedUser.username + " EST CONNECTÉ (UID: " & requestedUser.id & ")")
                Session("UID") = requestedUser.id
                Session("UserName") = requestedUser.username
                Session("AdminRights") = requestedUser.admin
                Session("UserLogged") = True
                Return RedirectToAction("Index", "Home")

                End Using
            Catch exc As Exception

                Debug.WriteLine("utilisateur invalide " + exc.Message)
                    Return RedirectToAction("Index", "Home")
                End Try



        End Function

    End Class
End Namespace