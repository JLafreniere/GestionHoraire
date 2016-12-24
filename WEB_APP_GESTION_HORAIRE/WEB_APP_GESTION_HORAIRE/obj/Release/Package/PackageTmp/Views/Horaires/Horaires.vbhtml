@Code
    ViewData("Title") = "Horaires"
End Code

<h2>Gérer les Horaires</h2>



<script src="~/Scripts/Horaire/global_vars.js"></script>
<div class="row">
    <div class="col-md-3">

        <div class="row">
            <div class="col-md-12">
  
                <form action="/horaires/AfficherHoraires" method="post">
                    <h3 style="margin-top: 13px">Semaine</h3>

                    <div class="form-group">
                        <div class="input-group date " id="datetimepicker1">
                            <input style="height: 40px" name="date" type="text" class="form-control" id="txtDate" />	<span class="input-group-addon"><span class="glyphicon-calendar glyphicon"></span></span>
                        </div>
                    </div>
                    <br />

                    <div class="form-group">
                        <div class="input-group">
                            <div style="margin-top: -10px; margin-left: 1px"><b> Inclure les entreprises</b></div>
                            <div style="margin-top:-24px; margin-left: 240px "><input id="triEntreprise" name="triEntreprise" style="width: 20px; height: 20px; " type="checkbox" onclick="hideShowEntreprises()"/>	</div>
                        </div>
                        <div id="divEntrep"></div>
                    </div>
                    <hr />
                    <div class="form-group">
                        <div class="input-group">
                            <div style="margin-top: -10px; margin-left: 1px"> <b>Inclure les emplacements</b></div>
                            <div style="margin-top:-24px; margin-left: 240px "><input id="triEmplacements" name="triEmplacements" style="width: 20px; height: 20px; " type="checkbox" onclick="hideShowEmplacements()"/>	</div>
                        </div>
                        <div id="divEmplacement"></div>
                    </div>
                    <hr />
                    <div class="form-group">
                        <div class="input-group">
                            <div style="margin-top: -10px; margin-left: 1px"><b>Inclure les employés</b></div>
                            <div style="margin-top:-24px; margin-left: 240px "><input id="triEmployes" name="triEmployes" style="width: 20px; height: 20px; " type="checkbox" onclick="hideShowEmployes()"/>	</div>
                        </div>
                        <div id="divEmployes"></div>
                    </div>

                    <button type="submit" class="btn btn-info pull-right" style="">Rechercher</button>
                </form>         
                <br /><br />
                <br /><br />























            </div>
        </div></div>
    <div class="col-md-9" id="colonneHoraire" style="padding-left: 0px; margin-top: -29px ">
        <div class="row">
            <div class="div-col-xs-2 col-xs-offset-5">
                <!--      <div id="datetimepicker" class="input-append date" onchange="console.log('test')">
                 <input type="text" id="date_sem" ></input>
                 <script>
                 let field = document.getElementById("date_sem");
                 let now = new Date(Date.now());
                 console.log(now);
                 field.value = now.getFullYear()+"-"+String("00" + (now.getMonth()+1)).slice(-2)+"-"+String("00" + now.getDate()).slice(-2);


                 </script>
                 <span class="add-on">
                    <i data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
                 </span>
              </div>-->


              

            </div>
            <!-- <input type="button" value="Go!" onclick="refreshApp()" id="btnGo"><br><br> -->
           
               <div class="row" style="margin-left: 0px; padding-bottom:15px">
                   <div class="col-md-10" style="text-align: center"><h3>Semaine du @ViewBag.debutSemaine au @ViewBag.finSemaine</h3></div>
                   <div class="col-md-2"><form action="/horaires/creerQuart" method="post">
    <button type="submit" class="btn btn-success pull-right" style="margin-right: 14px; margin-top: 18px">Ajouter un quart</button>
</form></div>
               </div>
                  
           
                
           
       
        </div>

        <div id="container">
            <canvas id="app_cvs" width="863" height="600"></canvas>
        </div>


</div>
    </div>







	


<script src="~/Scripts/bootstrap.min.js"></script>
<script src="~/Scripts/Horaire/creationTableau.js"></script>
<script src="~/Scripts/Horaire/tests.js"></script>
<script type="text/javascript" src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.1/js/bootstrap.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/moment.js/2.9.0/moment-with-locales.js"></script>
<script src="//cdn.rawgit.com/Eonasdan/bootstrap-datetimepicker/e8bddc60e73c1ec2475f827be36e1957af72e2ea/src/js/bootstrap-datetimepicker.js"></script>
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.9.0/moment-with-locales.js"></script>
<script type="text/javascript" src="https://cdn.rawgit.com/Eonasdan/bootstrap-datetimepicker/a549aa8780dbda16f6cff545aeabc3d71073911e/src/js/bootstrap-datetimepicker.js"></script>
<script>




    var d = new Date();

    var month = d.getMonth() + 1;
    var day = d.getDate();

    var output = +  +
    d.getFullYear() + "/"+(month < 10 ? '0' : '') + month + '/' + (day < 10 ? '0' : '') + day;


    $('#datetimepicker1').datetimepicker({
        format: 'YYYY/MM/DD'
    });
    $('#txtDate').val("@ViewBag.date")


    function hideShowEntreprises() {


        if(document.getElementById("triEntreprise").checked){


        let entreprises = document.createElement("div");
        entreprises.id = "listeEntrep";

        let emplacements = document.getElementsByTagName("listeEmplacements");


        let x = 0;

        @code
            For Each e As Entreprise In ViewBag.Entreprises
        End Code

            x = document.createElement("div");
            x.style = "margin-right: 30px; padding-bottom: 5px";
            x.innerHTML = "@e.nom_Entreprise <input value=\"@e.id\" id=\"@e.id\" type=\"checkbox\" name=\"entreprises\" onchange=\"ajusterEmplacements()\" class=\"chkEntreprise chkSubContent\">";
            entreprises.appendChild(x);


        @code

            Next
        End Code

            document.getElementById("divEntrep").appendChild(entreprises);
            $(".chkEmplacement").each(function () { this.disabled = true; });
            $(".chkEmplacement").each(function () { this.checked = false; });

        } else {
            document.getElementById("divEntrep").innerHTML = "";
           $(".chkEmplacement").each(function () { this.disabled = false; });
        }

    }



    function hideShowEmplacements() {


        if(document.getElementById("triEmplacements").checked){


            let emplacements = document.createElement("div");
            emplacements.id = "listeEmplacements";

            let x = 0;

        @code
            For Each e As Emplacement In ViewBag.emplacements
            End Code

            x = document.createElement("div");
            x.style = "margin-right: 30px; padding-bottom: 5px";
            x.innerHTML = "@e.nom_Emplacement <input type=\"checkbox\" name=\"emplacements\"  value=\"@e.id\" class=\"@e.entreprise.id chkEmplacement chkSubContent\">";
            emplacements.appendChild(x);


        @code

            Next
            End Code

            document.getElementById("divEmplacement").appendChild(emplacements);
            ajusterEmplacements();
        } else {
            document.getElementById("divEmplacement").innerHTML = "";

        }

    }


    function hideShowEmployes() {


        if(document.getElementById("triEmployes").checked){


            let employes = document.createElement("div");
            employes.id = "listeEmployes";

            let x = 0;

        @code
            For Each u As Utilisateur In ViewBag.employes
            End Code

            x = document.createElement("div");
            x.style = "margin-right: 30px; padding-bottom: 5px";
            x.innerHTML = "@u.prenom @u.nom  <input type=\"checkbox\" name=\"employes\"  value=\"@u.id\"  class=\"chkSubContent\">";
            employes.appendChild(x);


        @code

            Next
            End Code

            document.getElementById("divEmployes").appendChild(employes);

        } else {
            document.getElementById("divEmployes").innerHTML = "";

        }

    }



    function ajusterEmplacements(){

        let emplacements = document.getElementsByClassName("chkEmplacement");
        let entreprises = document.getElementsByClassName("chkEntreprise");

        $(".chkEntreprise").each(function () {

            let i = this.id;
            if (!this.checked) {

                $(".chkEmplacement." + i).each(function () { this.disabled = true; });
                $(".chkEmplacement." + i).each(function () { this.checked = false; });
            }
            else { $(".chkEmplacement." + i).each(function () { this.disabled = false; }); }
        });




    }


    let quartTravail;
    let arrayQuarts =[];

    @code
    For Each s As Shift In ViewBag.shifts
    End Code
    quartTravail = new workshift("@Html.Raw(s.utilisateur.prenom) @Html.Raw(s.utilisateur.nom)",
        new Date(@s.debut.Year, @(s.debut.Month - 1), @s.debut.Day, @(s.debut.Hour - 0), @s.debut.Minute, @s.debut.Second),
        new Date(@s.fin.Year, @(s.fin.Month - 1), @s.fin.Day, @(s.fin.Hour - 0), @s.fin.Minute, @s.fin.Second));
    arrayQuarts.push(quartTravail);
    @code
            System.Diagnostics.Debug.WriteLine("Shift de :" + s.utilisateur.nom)
        Next
    End Code





    refreshApp()

    window.setTimeout(test, 300);


    function test(){
        afficherShifts(arrayQuarts);
    }




</script>