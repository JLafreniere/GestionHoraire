@ModelType IEnumerable(Of WEB_APP_GESTION_HORAIRE.Utilisateur)
@Code
    ViewData("Title") = "Utilisateurs"
End Code
<input type="hidden" id="pageName" value="@ViewData("Title")" />
<h2>Utilisateurs</h2>


    <form action="/utilisateurs/utilisateurs" method="post">
       <button type="submit" value="Go to Google" class="btn btn-success" >Ajouter</button>
    </form>
    
<br />
<table class="table">
    <tr>
        <th>
            Nom d'utilisateur
        </th>
        <th>
            Nom complet
        </th>
        <th>
            Téléphone
        </th>
        <th>
            Email
        </th>
        <th>
            Administrateur
        </th>

        <th></th>
    </tr>


@For Each item In Model
    @code
        Try
    End Code
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.username)
        </td>
         <td>
             @code
                 Write(item.nom & ",  " & item.prenom)
              End code
         </td>
         <td>
             @item.telephone
         </td>


        <td>
            @Html.DisplayFor(Function(modelItem) item.email)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.admin)
        </td>

        <td>
            <form action="/utilisateurs/supprimerUtilisateur" method="post">
                <button type="submit" name="id_utilisateur" value="@item.id" class="btn btn-danger" id="@item.id">Supprimer</button>
             </form>
</td>
    </tr>
    @code
    Catch exc As Exception : End Try
    End Code
        Next
</table>
<script>
    //Empêcher l'utilisateur de supprimer son propre compte
    $("#@Session("UID")").remove();
                 $("tr:odd").css("background-color", "#F3F3F3");
    $("tr:even").css("background-color", "#E0E0E0");
</script>
