@ModelType WEB_APP_GESTION_HORAIRE.Entreprise
@Code
    ViewData("Title") = "Créer une entreprise"
End Code

<h2>Créer une entreprise</h2>

<form action="/Entreprises/enregistrerEntreprise" method="post">
    @Html.AntiForgeryToken()

    <div class="form-horizontal">
        
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        <div class="form-group">
           <label class = "control-label col-md-2">Nom de l'entreprise</label>
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.nom_Entreprise, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.nom_Entreprise, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Enregistrer" class="btn btn-success" />
            </div>
        </div>
    </div>
</form>

    <div>
        @Html.ActionLink("Retour à la liste", "Entreprises")
    </div>
