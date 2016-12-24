@ModelType WEB_APP_GESTION_HORAIRE.Shift
@Code
    ViewData("Title") = "CreerQuart"
End Code


<link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
<link rel="stylesheet" href="https://cdn.rawgit.com/Eonasdan/bootstrap-datetimepicker/a549aa8780dbda16f6cff545aeabc3d71073911e/build/css/bootstrap-datetimepicker.css">
<script src="https://code.jquery.com/jquery-1.12.4.js"></script>
<script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

<h2>Ajouter un quart de travail</h2>



<div class="row">
    <form action="/horaires/enregistrerQuart" method="post" id="frmQuart">
        <div class="form-horizontal col-md-6">
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

            <div class="row">
                <div class="col-md-2" style="text-align: center">
                    <div class="form-group">
                        <label for="debut" class="control-label" >Début</label>
                    </div>
                </div>
                    <div class="col-md-7">
                        <div class="input-group date " id="datetimepicker1">
                            <input style="height: 40px; margin-left: 0px" type="text" onchange="ajusterDuree()" class="form-control" id="txtDebut" name="debut" />	<span class="input-group-addon"><span class="glyphicon-calendar glyphicon"></span></span>
                        </div>
                    </div>
              
            </div>
            <br />

            <div class="row">
              <div class="col-xs-2"></div>  <input type="radio" name="finQ" value="parDuree" id="rbDuree" checked onclick="afficherDuree('rbDuree'); "/> <label class="control-label ">Définir la durée du quart</label> <br />
            </div>
            <br />
            <div id="choixDuree">

                <div class="row">

                    <div class="col-xs-3"></div>
                    <div class="col-xs-9">
                        <input type="radio" name="duree" value="4" onclick="ajusterDuree();"/>   4 Heures<br /><br />
                        <input type="radio" name="duree" value="8" onclick="ajusterDuree()" checked/>   8 Heures<br /><br />
                        <input type="radio" name="duree" value="12" onclick="ajusterDuree()" />   12 Heures<br /><br />




                    </div>
                </div>

            </div>

            <br />

            <div class="row">
                <div class="col-xs-2"></div>  <input type="radio" name="finQ" value="parHeureFin" id="rbfin" onclick="afficherDuree('rbFin'); "/> <label class="control-label ">Définir la fin du quart</label> <br />
            </div>
       


                <br />
                <div class="row">
                    <div class="col-md-2" style="text-align: center">
                        <div class="form-group">
                            
                        </div>
                    </div>
                    <div class="col-md-7" id="dtpFin">
                        <div class="input-group date " id="datetimepicker2">
                            <input style="height: 40px; margin-left: 0px" type="text" class="form-control" id="txtFin" name="fin" />	<span class="input-group-addon"><span class="glyphicon-calendar glyphicon"></span></span>
                        </div>
                    </div>

                </div>

                <br />
                <div Class="form-group">
                    <div Class="col-md-offset-2 col-md-10">
                        <button type="button" onclick="validate()" value="Ajouter" Class="btn btn-success">Ajouter</button>
                    </div>
                </div>



            </div>


    </form>
</div>


<script>
    $("#dtpFin").hide();
    function afficherDuree(idItem) {
        console.log(idItem);
        if (idItem == "rbFin") {
            $("#choixDuree").hide("fast");
            $("#dtpFin").show("fast");
        }
        else {
            $("#choixDuree").show("fast");
            $("#dtpFin").hide("fast");

        }

    }

    function ajusterDuree() {

        let parDuree = $('input[name=finQ]:checked', '#frmQuart').val();
        
        if(parDuree=="parDuree"){
        let tempsHeure = $('input[name=duree]:checked', '#frmQuart').val();
        console.log(tempsHeure + " NB HEURES");
        let d = new Date($("#txtDebut").val());
        let newDate = d.addHours(tempsHeure);
        $("#txtFin").val(moment(newDate).format("YYYY/MM/DD HH:mm"));
        }
    }

    Date.prototype.addHours = function (h) {
        this.setTime(this.getTime() + (h * 60 * 60 * 1000));
        return this;
    }




</script>




















<script src="~/Scripts/bootstrap.min.js"></script>
<script type="text/javascript" src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.1/js/bootstrap.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/moment.js/2.9.0/moment-with-locales.js"></script>
<script src="//cdn.rawgit.com/Eonasdan/bootstrap-datetimepicker/e8bddc60e73c1ec2475f827be36e1957af72e2ea/src/js/bootstrap-datetimepicker.js"></script>
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.9.0/moment-with-locales.js"></script>
<script type="text/javascript" src="https://cdn.rawgit.com/Eonasdan/bootstrap-datetimepicker/a549aa8780dbda16f6cff545aeabc3d71073911e/src/js/bootstrap-datetimepicker.js"></script>



<script>

    $('#datetimepicker1').datetimepicker({
        format: 'YYYY/MM/DD HH:mm'
    }).on('dp.change', function (event) {
        ajusterDuree();
    });

    $('#datetimepicker2').datetimepicker({
        format: 'YYYY/MM/DD HH:mm'
    });
    let dateDeb = "@Date.Today"

    $('#txtDebut').val(moment("@Date.Now").format("YYYY/MM/DD HH:mm"));
    $('#txtFin').val(moment("@Date.Now").format("YYYY/MM/DD HH:mm"));


</script>




<script>


    function validate() {
        let b;
        let debut = new Date($("#txtDebut").val());
        let fin = new Date($("#txtFin").val());
        if (debut < fin)
            b= true;
        else
            b= false;

        if (b) {
            $("#frmQuart").submit();
        } else {
            alert("La période définie pour le quart de travail est invalide");
        }



    }


</script>

<div>
    @Html.ActionLink("Retour à la grille", "Horaires")
</div>







