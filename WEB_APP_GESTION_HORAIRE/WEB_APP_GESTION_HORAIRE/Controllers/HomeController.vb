Imports System.Web.Mvc
Imports System.Linq

Namespace Controllers
    Public Class HomeController
        Inherits Controller

        ' GET: Home
        Function Index() As ActionResult
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