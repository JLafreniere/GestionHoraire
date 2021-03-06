﻿Imports System.Data.Entity
Imports System.Globalization
Imports WEB_APP_GESTION_HORAIRE

Public Class BddContext
    Inherits DbContext

    Public Property Shifts As DbSet(Of Shift)

    Public Property Emplacements As DbSet(Of Emplacement)
    Public Property Entreprises As DbSet(Of Entreprise)
    Public Property Utilisateurs As DbSet(Of Utilisateur)

    Public Sub New(connectionString As String)
        MyBase.New(connectionString)
    End Sub




End Class

Public Interface IDal
    Inherits IDisposable

    Function ajouterUtilisateur(_username As String, _plainTextPassword As String, _email As String, _admin As Boolean, _nom As String, _prenom As String, _telephone As String) As Boolean
    Function obtenirTousLesUtilisateurs() As List(Of Utilisateur)
    Function obtenirEntreprises() As List(Of Entreprise)
    Function obtenirEmplacements() As List(Of Emplacement)
End Interface

Public Class Dal
    Implements IDal

    Private bdd As New BddContext("ConnStringDb1")

    Public Sub Dal()

    End Sub

    Public Function ajouterUtilisateur(_username As String, _plainTextPassword As String, _email As String, _admin As Boolean, _nom As String, _prenom As String, _telephone As String) As Boolean Implements IDal.ajouterUtilisateur

        Dim salt As String = Utilisateur.CreateRandomSalt()

        Dim userWithSameName = (From u As Utilisateur In bdd.Utilisateurs.ToList()
                                Where u.username = _username
                                Select u).ToList().Count

        If userWithSameName = 0 Then
            bdd.Utilisateurs.Add(New Utilisateur With {.username = _username, .email = _email, .password =
                     Utilisateur.Hash512(_plainTextPassword, salt), .salt = salt, .admin = _admin, .nom = _nom, .prenom = _prenom, .telephone = _telephone})
            bdd.SaveChanges()
            Return True
        Else
            Debug.WriteLine("Existing username")
            Return False
        End If




    End Function

    Public Sub ajouterQuart(_emplacement As Integer, _employe As Integer, _debut As String, _fin As String)



        Dim debutShift As DateTime = DateTime.ParseExact(_debut, "yyyy/MM/dd HH:mm", CultureInfo.CurrentCulture)
        Dim finShift As DateTime = DateTime.ParseExact(_fin, "yyyy/MM/dd HH:mm", CultureInfo.CurrentCulture)

        Dim quart = New Shift With {.emplacement = bdd.Emplacements.Find(_emplacement), .utilisateur = bdd.Utilisateurs.Find(_employe), .debut = debutShift, .fin = finShift}
        bdd.Shifts.Add(quart)
        bdd.SaveChanges()

    End Sub

    Public Sub ajouterEmplacement(_nomEmplacement As String, _adresse As String, _telephone As String, entreprise As Integer)



        Dim newEmpl = New Emplacement With {.adresse = _adresse, .telephone = _telephone, .nom_Emplacement = _nomEmplacement, .entreprise = bdd.Entreprises.Find(entreprise)}

        bdd.Emplacements.Add(newEmpl)
        bdd.SaveChanges()
    End Sub

    Public Function obtenirTousLesUtilisateurs() As List(Of Utilisateur) Implements IDal.obtenirTousLesUtilisateurs
        Return bdd.Utilisateurs.ToList()
    End Function

    Public Function obtenirTousLesQuarts() As List(Of Shift)
        Return bdd.Shifts.ToList()
    End Function

    Friend Sub supprimerEmplacement(id As Integer)
        bdd.Database.ExecuteSqlCommand("delete from emplacements where id = " & id)
    End Sub

    Public Function obtenirEntreprises() As List(Of Entreprise) Implements IDal.obtenirEntreprises
        Return bdd.Entreprises.ToList()
    End Function

    Public Function obtenirEmplacements() As List(Of Emplacement) Implements IDal.obtenirEmplacements
        Return bdd.Emplacements.ToList()
    End Function

    Public Sub ajouterEntreprise(nomEntreprise As String)
        bdd.Entreprises.Add(New Entreprise With {.nom_Entreprise = nomEntreprise})
        bdd.SaveChanges()
    End Sub

    Public Sub supprimerUtilisateur(id As Integer)
        bdd.Database.ExecuteSqlCommand("delete from utilisateurs where id = " & id)
    End Sub

    Public Sub supprimerEntreprise(id As Integer)
        bdd.Database.ExecuteSqlCommand("delete from entreprises where id = " & id)
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        ' TODO: uncomment the following line if Finalize() is overridden above.
        ' GC.SuppressFinalize(Me)
    End Sub


#End Region


End Class