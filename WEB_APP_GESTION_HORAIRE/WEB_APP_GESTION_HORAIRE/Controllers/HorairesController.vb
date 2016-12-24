
Imports System.Web.Mvc

Namespace Controllers
    Public Class HorairesController
        Inherits Controller

        Public Sub New()

        End Sub

        ' GET: Horaires

        Function Horaires() As ActionResult
            If Not Session("AdminRights") Then
                Return Nothing
            End If

            ViewBag.date = Date.Today.ToString("yyyy/MM/dd")
            ViewBag.debutSemaine = GetPreviousSunday(Date.Today).ToString("dd MMMM yyyy")
            ViewBag.finSemaine = GetNextSaturday(Date.Today).ToString("dd MMMM yyyy")





            Using accessLayer As New Dal
                Dim entreprises As List(Of Entreprise) = accessLayer.obtenirEntreprises()
                Dim emplacement As List(Of Emplacement) = accessLayer.obtenirEmplacements()
                Dim employes As List(Of Utilisateur) = accessLayer.obtenirTousLesUtilisateurs()
                ViewBag.employes = employes
                ViewBag.emplacements = emplacement
                ViewBag.entreprises = entreprises
                ViewBag.shifts = New List(Of Shift)
            End Using




            Return View("Horaires")
        End Function

        <HttpPost>
        Function AfficherHoraires() As ActionResult
            If Not Session("AdminRights") Then
                Return Nothing
            End If


            Dim debutSemaine As Date = GetPreviousSunday(Request("date")).AddDays(-1)
            Dim finSemaine As Date = GetNextSaturday(Request("date")).AddDays(1)
            ViewBag.debutSemaine = debutSemaine.AddDays(1).ToString("dd MMMM yyyy")
            ViewBag.finSemaine = finSemaine.AddDays(-1).ToString("dd MMMM yyyy")
            ViewBag.date = debutSemaine.AddDays(1).ToString("yyyy/MM/dd")

            Dim arrayEntreprises(-1) As String
            Dim arrayEmployes(-1) As String
            Dim arrayEmplacements(-1) As String

            Try
                arrayEntreprises = Split(Request("entreprises"), ",")
            Catch exc As Exception : End Try

            Try
                arrayEmplacements = Split(Request("emplacements"), ",")
            Catch exc As Exception : End Try

            Try
                arrayEmployes = Split(Request("employes"), ",")
            Catch exc As Exception : End Try




            Dim listeQuart As List(Of Shift)


            Using accessLayer As New Dal


                Dim employes As List(Of Utilisateur) = accessLayer.obtenirTousLesUtilisateurs()
                Dim emplacement As List(Of Emplacement) = accessLayer.obtenirEmplacements()
                ViewBag.employes = employes
                ViewBag.emplacements = emplacement

                listeQuart =
                (From sh In accessLayer.obtenirTousLesQuarts()
                 Where
                    (arrayEntreprises.Contains(sh.emplacement.entreprise.id) Or arrayEntreprises(0) = String.Empty) And
                    (arrayEmplacements.Contains(sh.emplacement.id) Or arrayEmplacements(0) = String.Empty) And
                    (arrayEmployes.Contains(sh.utilisateur.id) Or arrayEmployes(0) = String.Empty) And
                    ((sh.fin < finSemaine And sh.fin > debutSemaine) Or (sh.debut > debutSemaine And sh.debut < finSemaine))
                 Select New Shift With {.id = sh.id, .emplacement = sh.emplacement, .utilisateur = sh.utilisateur, .debut = sh.debut, .fin = sh.fin}).ToList()
            End Using
            Using accessLayer As New Dal()
                Dim entreprises As List(Of Entreprise) = accessLayer.obtenirEntreprises()
                Dim emplacement As List(Of Emplacement) = accessLayer.obtenirEmplacements()
                Dim employes As List(Of Utilisateur) = accessLayer.obtenirTousLesUtilisateurs()
                ViewBag.employes = employes
                ViewBag.emplacements = emplacement
                ViewBag.entreprises = entreprises
                ViewBag.shifts = listeQuart
            End Using




            Return View("Horaires")
        End Function





        '<HttpPost>
        'Function MonHorairePeriode() As ActionResult

        '    If Session("uid") = 0 Then
        '        Return RedirectToAction("Index", "Home")
        '    End If

        '    Dim debutSemaine As Date = GetPreviousSunday(Request("date")).AddDays(-1)
        '    Dim finSemaine As Date = GetNextSaturday(Request("date")).AddDays(1)
        '    ViewBag.debutSemaine = debutSemaine.AddDays(1).ToString("dd MMMM yyyy")
        '    ViewBag.finSemaine = finSemaine.AddDays(-1).ToString("dd MMMM yyyy")
        '    ViewBag.date = debutSemaine.AddDays(1).ToString("yyyy/MM/dd")







        '    Dim listeQuart As List(Of Shift)


        '    Using accessLayer As New Dal


        '        Dim employes As List(Of Utilisateur) = accessLayer.obtenirTousLesUtilisateurs()
        '        Dim emplacement As List(Of Emplacement) = accessLayer.obtenirEmplacements()
        '        ViewBag.employes = employes
        '        ViewBag.emplacements = emplacement

        '        listeQuart =
        '        (From sh In accessLayer.obtenirTousLesQuarts()
        '         Where
        '         (sh.utilisateur.id = Session("UID")) And
        '            ((sh.fin < finSemaine And sh.fin > debutSemaine) Or (sh.debut > debutSemaine And sh.debut < finSemaine))
        '         Select New Shift With {.id = sh.id, .emplacement = sh.emplacement, .utilisateur = sh.utilisateur, .debut = sh.debut, .fin = sh.fin}).ToList()
        '    End Using
        '    Using accessLayer As New Dal()
        '        Dim entreprises As List(Of Entreprise) = accessLayer.obtenirEntreprises()
        '        Dim emplacement As List(Of Emplacement) = accessLayer.obtenirEmplacements()
        '        Dim employes As List(Of Utilisateur) = accessLayer.obtenirTousLesUtilisateurs()
        '        ViewBag.employes = employes
        '        ViewBag.emplacements = emplacement
        '        ViewBag.entreprises = entreprises
        '        ViewBag.shifts = listeQuart
        '    End Using

        '    Return View("MonHoraire")

        'End Function




        Function MonHoraire() As ActionResult

            If Session("uid") = 0 Then
                Return RedirectToAction("Index", "Home")
            End If

            Dim debutSemaine As Date
            Dim finSemaine As Date
            Try

                debutSemaine = Request("date")
                finSemaine = Request("date")
                Debug.WriteLine(debutSemaine + " SET BY POST ")
            Catch ex As Exception
                debutSemaine = Date.Today
                finSemaine = Date.Today
            End Try

            debutSemaine = GetPreviousSunday(debutSemaine).AddDays(-1)
            finSemaine = GetNextSaturday(finSemaine).AddDays(1)
            ViewBag.debutSemaine = debutSemaine.AddDays(1).ToString("dd MMMM yyyy")
            ViewBag.finSemaine = finSemaine.AddDays(-1).ToString("dd MMMM yyyy")
            ViewBag.date = debutSemaine.AddDays(1).ToString("yyyy/MM/dd")

            Dim listeQuart As List(Of Shift)

            Using accessLayer As New Dal


                Dim employes As List(Of Utilisateur) = accessLayer.obtenirTousLesUtilisateurs()
                Dim emplacement As List(Of Emplacement) = accessLayer.obtenirEmplacements()
                ViewBag.employes = employes
                ViewBag.emplacements = emplacement


                Dim listeEmplacement As List(Of Integer) = (From sh In accessLayer.obtenirTousLesQuarts()
                                                            Where
                                        (sh.utilisateur.id = Session("UID")) And
                                        ((sh.fin < finSemaine And sh.fin > debutSemaine) Or (sh.debut > debutSemaine And sh.debut < finSemaine))
                                                            Select sh.emplacement.id).ToList()

                listeQuart =
                (From sh In accessLayer.obtenirTousLesQuarts()
                 Where
                 ((sh.utilisateur.id = Session("UID")) Or listeEmplacement.Contains(sh.emplacement.id)) And
                    ((sh.fin < finSemaine And sh.fin > debutSemaine) Or (sh.debut > debutSemaine And sh.debut < finSemaine))
                 Select New Shift With {.id = sh.id, .emplacement = sh.emplacement, .utilisateur = sh.utilisateur, .debut = sh.debut, .fin = sh.fin}).ToList()
            End Using
            Using accessLayer As New Dal()
                Dim entreprises As List(Of Entreprise) = accessLayer.obtenirEntreprises()
                Dim emplacement As List(Of Emplacement) = accessLayer.obtenirEmplacements()
                Dim employes As List(Of Utilisateur) = accessLayer.obtenirTousLesUtilisateurs()
                ViewBag.employes = employes
                ViewBag.emplacements = emplacement
                ViewBag.entreprises = entreprises
                ViewBag.shifts = listeQuart
            End Using

            Return View("MonHoraire")

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


        <HttpPost>
        Function enregistrerQuart() As ActionResult
            If Not Session("AdminRights") Then
                Return Nothing
            End If

            Dim employe As Integer = Request("employe")
            Dim emplacement As Integer = Request("emplacement")
            Dim debut As String = Request("debut")
            Dim fin As String = Request("fin")


            Using accessLayer As New Dal
                accessLayer.ajouterQuart(emplacement, employe, debut, fin)


                Return RedirectToAction("Horaires", "Horaires")
            End Using

        End Function

        Function GetPreviousSunday(fromDate As Date) As Date
            Return fromDate.AddDays(0 - fromDate.DayOfWeek)
        End Function

        Function GetNextSaturday(fromDate As Date) As Date
            Return fromDate.AddDays(6 - fromDate.DayOfWeek)
        End Function


    End Class
End Namespace