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
        Dim init As Entity.IDatabaseInitializer(Of BddContext) = New CreateDatabaseIfNotExists(Of BddContext)

        Database.SetInitializer(init)
        Dim bdContext As New BddContext("ConnStringDb1")

        init.InitializeDatabase(bdContext)

        Using d As New Dal()
            bdContext.Database.ExecuteSqlCommand("delete from shifts")
            bdContext.Database.ExecuteSqlCommand("delete from utilisateurs")
            bdContext.Database.ExecuteSqlCommand("delete from emplacements")
            bdContext.Database.ExecuteSqlCommand("delete from entreprises")
            bdContext.Database.ExecuteSqlCommand("delete from shifts")

            d.ajouterUtilisateur("Utilisateur", "1234", "j@j.j", False, "Paré", "Mathieu", "819-555-5555")
            d.ajouterUtilisateur("Administrateur", "1234", "j@j.j", True, "Désaulniers", "Alain", "819-555-5555")
            d.ajouterUtilisateur("MarieL", "1234", "j@j.j", False, "Lessard", "Marie", "819-555-5555")

            d.ajouterEntreprise("LocationCanot.com")
            d.ajouterEntreprise("Poêles & Foyers")

            d.ajouterEmplacement("Location Canot Wapi-Nord", "Parc National de la Mauricie", "(819)498-1274", d.obtenirEntreprises(0).id)
            d.ajouterEmplacement("Dépanneur Wapi-Nord", "Parc National de la Mauricie", "(819)438-1425", d.obtenirEntreprises(0).id)
            d.ajouterEmplacement("Location Canot Wapi-Sud", "Parc National de la Mauricie", "(819)498-1274", d.obtenirEntreprises(0).id)
            d.ajouterEmplacement("Dépanneur Wapi-Sud", "Parc National de la Mauricie", "(819)438-1425", d.obtenirEntreprises(0).id)
            d.ajouterEmplacement("Magasin Trois-Rivières", "245 5ème avenue, Trois-Rivières", "(819)834-1221", d.obtenirEntreprises(1).id)
            d.ajouterEmplacement("Magasin Lévis", "10135 rue principale, Lévis", "(819)490-9834", d.obtenirEntreprises(1).id)



            Debug.WriteLine("Crypt: " + d.obtenirTousLesUtilisateurs(0).password)
            Debug.WriteLine("       " + (Utilisateur.Hash512("1234", d.obtenirTousLesUtilisateurs(0).salt)))
            Debug.WriteLine("Nb Utilisateurs:  " & d.obtenirTousLesUtilisateurs.Count)
        End Using



    End Sub

    Protected Sub Session_OnStart()
        Session.Timeout = 30
        Session("UserLogged") = False
        Session("UID") = 0
        Session("AdminRights") = False

    End Sub


    <Conditional("DEBUG")>
    Private Sub DisableApplicationInsightsOnDebug()
        TelemetryConfiguration.Active.DisableTelemetry = True
    End Sub


End Class
