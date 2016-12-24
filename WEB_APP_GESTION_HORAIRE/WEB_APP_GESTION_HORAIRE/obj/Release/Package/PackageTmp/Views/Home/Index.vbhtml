@Code
    ViewData("Title") = "Accueil"
End Code

<input type="hidden" id="pageName" value="@ViewData("Title")" />
<h2>Accueil</h2>
@code
    If Not (Session("UID") = 0) Then
End code    
        <h3> Utilisateur connecté: @ViewBag.user</h3>
<br /><br />
<h4>Programmeur: Jonathan Lafrenière</h4>
<h4>Téléphone: (819) 701-7047</h4>
<h4>Courriel: jonathan.lafrenière@hotmail.com</h4>
<h4>Version: 1.0.1</h4>
<h4>17 décembre 2016</h4>


        

@code
    End If

End Code
