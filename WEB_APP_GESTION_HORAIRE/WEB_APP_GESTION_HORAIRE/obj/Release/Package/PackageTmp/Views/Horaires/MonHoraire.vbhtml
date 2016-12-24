@Code
    ViewData("Title") = "Horaires"
End Code

<h2>Mon horaire</h2>



<script src="~/Scripts/Horaire/global_vars.js"></script>
<div class="row">
    <div class="col-md-3">

        <div class="row">
            <div class="col-md-12">

                <form action="/horaires/MonHoraire" method="post">
                    <h3 style="margin-top: 13px">Semaine</h3>

                    <div class="form-group">
                        <div class="input-group date " id="datetimepicker1">
                            <input style="height: 40px" name="date" type="text" class="form-control" id="txtDate" />	<span class="input-group-addon"><span class="glyphicon-calendar glyphicon"></span></span>
                        </div>
                    </div>

                    <button type="submit" class="btn btn-info pull-right" style="">Rechercher</button>
                </form>
                <br /><br />
                <br /><br />
                
            </div>
        </div>
    </div>
    <div class="col-md-9" id="colonneHoraire" style="padding-left: 0px; margin-top: -29px ">
        <div class="row">
            <div class="div-col-xs-2 col-xs-offset-5">
            </div>

            <div class="row" style="margin-left: 0px; padding-bottom:15px">
                <div class="col-md-12" style="text-align: center"><h3>Semaine du @ViewBag.debutSemaine au @ViewBag.finSemaine</h3></div>
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