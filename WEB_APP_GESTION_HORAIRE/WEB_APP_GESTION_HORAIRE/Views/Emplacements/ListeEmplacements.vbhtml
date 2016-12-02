@ModelType IEnumerable(Of WEB_APP_GESTION_HORAIRE.Emplacement)
@Code
    ViewData("Title") = "Emplacements"
End Code

<h2>Emplacements</h2>

<p>
    @Html.ActionLink("Ajouter", "CreerEmplacement")
</p>
<table class="table">
    <tr>
        <th>
            Emplacement
        </th>
        <th>
           Entreprise
        </th>
        <th>
            Adresse
        </th>
        <th>Téléphone</th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.nom_Emplacement)
        </td>
         <td>

             @Html.DisplayFor(Function(modelItem) item.entreprise.nom_Entreprise)

         </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.adresse)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.telephone)
        </td>

        <td>

            <form action="/emplacements/supprimerEmplacement" method="post">
                <button type="submit" name="id_emplacement" value="@item.id" class="btn btn-danger" id="@item.id">Supprimer</button>
            </form>

        </td>
    </tr>
Next



</table>
<script>
                    $("tr:odd").css("background-color", "#F3F3F3");
                    $("tr:even").css("background-color", "#E0E0E0");
                    
</script>
