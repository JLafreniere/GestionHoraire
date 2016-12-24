
<br /><br />
@ModelType WEB_APP_GESTION_HORAIRE.Utilisateur
@Code
    ViewData("Title") = "Ajouter un utilisateur"
End Code
<input type="hidden" id="pageName" value="@ViewData("Title")" />


@code
    If ViewBag.fail Then
       End code

    <h2 style="color: red">Erreur lors de l'ajout de l'utilisateur</h2>

@code

    End If
End Code
 <form action="/Utilisateurs/creerUtilisateur" method="post">
    @Html.AntiForgeryToken()

    <div class="form-horizontal">
        <h4>Ajouter un utilisateur</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        <div class="form-group">
            <label for="username" class="control-label col-md-2">Nom d'utilisateur</label>
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.username, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.username, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            <label for="password" class="control-label col-md-2">Mot de passe</label>
            <div class="col-md-10">
                <input type="password" class="form-control" name="password" />
                @Html.ValidationMessageFor(Function(model) model.password, "", New With {.class = "text-danger"})
            </div>
        </div>


        <div class="form-group">
            <label for="Nom" class="control-label col-md-2">Nom</label>
            <div class="col-md-10">
         
                    @Html.EditorFor(Function(model) model.nom, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.nom, "", New With {.class = "text-danger"})
               
            </div>
        </div>


        <div class="form-group">
            <label for="prenom" class="control-label col-md-2">Prénom</label>
            <div class="col-md-10">
              
                    @Html.EditorFor(Function(model) model.prenom, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.prenom, "", New With {.class = "text-danger"})
               
            </div>
        </div>

        <div class="form-group">
            <label for="telephone" class="control-label col-md-2">Téléphone</label>
            <div class="col-md-10">
               
                    @Html.EditorFor(Function(model) model.telephone, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.telephone, "", New With {.class = "text-danger"})
          
            </div>
        </div>




        <div class="form-group">
            <label for="email" class="control-label col-md-2">Adresse Email</label>
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.email, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.email, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            <label for="Admin" class="control-label col-md-2">Administrateur</label>
            <div class="col-md-10">
                <div class="checkbox">
                    @Html.EditorFor(Function(model) model.admin)
                    @Html.ValidationMessageFor(Function(model) model.admin, "", New With {.class = "text-danger"})
                </div>
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
    @Html.ActionLink("Retour à la liste", "ListeUtilisateurs")
</div>
