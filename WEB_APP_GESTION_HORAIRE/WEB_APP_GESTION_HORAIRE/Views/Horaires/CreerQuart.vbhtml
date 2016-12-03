@ModelType WEB_APP_GESTION_HORAIRE.Shift
@Code
    ViewData("Title") = "CreerQuart"
End Code


<link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
<link rel="stylesheet" href="https://cdn.rawgit.com/Eonasdan/bootstrap-datetimepicker/a549aa8780dbda16f6cff545aeabc3d71073911e/build/css/bootstrap-datetimepicker.css">
<script src="https://code.jquery.com/jquery-1.12.4.js"></script>
<script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

<h2>Ajouter un quart de travail</h2>



<form>
    <div class="form-horizontal">
        @Html.AntiForgeryToken()

        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})


        <div class="form-group">
            <label for="employe" class="control-label col-md-2">Employé</label>
            <div class="col-md-10">
                <select name="employe" class="form-control">
                    @code
                        For Each e As Utilisateur In ViewBag.employes
                    End Code

                    <option value="@e.id">@e.prenom @e.nom</option>

                    @code

                        Next

                    End Code



                </select>
            </div>
        </div>

        <div class="form-group">
            <label for="emplacement" class="control-label col-md-2">Emplacement</label>
            <div class="col-md-10">
                <select name="emplacement" class="form-control">
                    @code
                        For Each e As Emplacement In ViewBag.emplacements
                    End Code
                    <option value="@e.id">@e.nom_Emplacement</option>
                    @code
                        Next
                    End Code

                </select>
            </div>
        </div>
    </div>


</form>



<script>


</script>















<div Class="form-group">
    <div Class="col-md-offset-2 col-md-10">
        <input type="submit" value="Ajouter" Class="btn btn-success" />
    </div>
</div>



<div>
    @Html.ActionLink("Retour à la grille", "Horaires")
</div>







