@ModelType IEnumerable(Of WEB_APP_GESTION_HORAIRE.Entreprise)
@Code
ViewData("Title") = "ListeEntreprises"
End Code

<h2>Entreprises</h2>

<p>
    @Html.ActionLink("Ajouter une entreprise", "CreerEntreprise")
</p>
<table class="table">
    <tr>
        <th>
            Nom de l'entreprise
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.nom_Entreprise)
        </td>
        <td>


            <form action="/entreprises/supprimerEntreprise" method="post">
                <button type="submit" name="id_entreprise" value="@item.id" class="btn btn-danger" id="@item.id">Supprimer</button>
            </form>
        </td>
    </tr>
Next

</table>

<script>                    $("tr:odd").css("background-color", "#F3F3F3");
    $("tr:even").css("background-color", "#E0E0E0");</script>
