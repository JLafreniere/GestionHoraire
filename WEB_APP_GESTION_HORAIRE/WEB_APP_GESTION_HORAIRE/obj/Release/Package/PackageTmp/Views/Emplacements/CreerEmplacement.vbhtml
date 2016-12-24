@ModelType WEB_APP_GESTION_HORAIRE.Emplacement
@Code
    ViewData("Title") = "Créer un emplacement"
End Code

<h2>Créer un emplacement</h2>

<form action="/Emplacements/EnregistrerEmplacement" method="post">
    @Html.AntiForgeryToken()

    <div class="form-horizontal">
        <h4>Emplacement</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        <div class="form-group">
         <label class = "control-label col-md-2">Nom de l'emplacement</label>
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.nom_Emplacement, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.nom_Emplacement, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            <label class="control-label col-md-2">Adresse</label>
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.adresse, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.adresse, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            <label class="control-label col-md-2">Téléphone</label>
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.telephone, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.telephone, "", New With {.class = "text-danger"})
            </div>
        </div>





        <div class="form-group">
            <label for="entreprise" class="control-label col-md-2">Entreprise</label>
            <div class="col-md-10">
                <select name="entreprise" class="form-control">
                    @code
                        For Each e As Entreprise In ViewBag.entreprises
                    End Code

                    <option value="@e.id">@e.nom_Entreprise</option>

                    @code

                        Next

                    End Code



                </select>
            </div>
        </div>



        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Enregistrer" class="btn btn-default btn-success" />
            </div>
        </div>
    </div>
   </form>

    <div>
        @Html.ActionLink("Retour à la liste", "ListeEmplacements")
    </div>
