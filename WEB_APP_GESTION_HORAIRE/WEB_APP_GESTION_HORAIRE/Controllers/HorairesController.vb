Imports System.Web.Mvc

Namespace Controllers
    Public Class HorairesController
        Inherits Controller

        ' GET: Horaires
        Function Horaires() As ActionResult
            Return View("Horaires")
        End Function
    End Class
End Namespace