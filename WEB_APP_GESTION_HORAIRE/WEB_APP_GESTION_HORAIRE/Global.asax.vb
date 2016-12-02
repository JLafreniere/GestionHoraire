Imports System.Data.Entity
Imports System.Web.Mvc
Imports System.Web.Routing
Imports Microsoft.ApplicationInsights.Extensibility

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Protected Sub Application_Start()

        DisableApplicationInsightsOnDebug()
        AreaRegistration.RegisterAllAreas()
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        Dim init As Entity.IDatabaseInitializer(Of BddContext) = New DropCreateDatabaseAlways(Of BddContext)

        Database.SetInitializer(init)
        init.InitializeDatabase(New BddContext())

        Using bob As New Dal()
            bob.ajouterUtilisateur("Utilisateur", "1234", "j@j.j", False, "Nom", "Prenom", "819-555-5555")
            bob.ajouterUtilisateur("Administrateur", "1234", "j@j.j", True, "Nom", "Prenom", "819-555-5555")
            Debug.WriteLine("Crypt: " + bob.obtenirTousLesUtilisateurs(0).password)
            Debug.WriteLine("       " + (Utilisateur.Hash512("1234", bob.obtenirTousLesUtilisateurs(0).salt)))
            Debug.WriteLine("Nb Utilisateurs:  " & bob.obtenirTousLesUtilisateurs.Count)
        End Using



    End Sub

    Protected Sub Session_OnStart()

        Session("UserLogged") = False
        Session("UID") = 0
        Session("AdminRights") = False

    End Sub


    <Conditional("DEBUG")>
    Private Sub DisableApplicationInsightsOnDebug()
        TelemetryConfiguration.Active.DisableTelemetry = True
    End Sub


End Class
