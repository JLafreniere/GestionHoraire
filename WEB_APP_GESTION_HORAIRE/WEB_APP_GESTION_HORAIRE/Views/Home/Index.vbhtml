@Code
    ViewData("Title") = "Accueil"
End Code

<input type="hidden" id="pageName" value="@ViewData("Title")" />
<h2>Index</h2>

@code
    If Not (Session("UID") = 0) Then
        End code    
        <h1> Utilisateur CONNECTÉ: @Session("uid")</h1>
@code
    End If

End Code
