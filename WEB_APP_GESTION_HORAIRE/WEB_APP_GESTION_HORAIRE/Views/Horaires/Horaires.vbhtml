@Code
    ViewData("Title") = "Horaires"
End Code

<h2>Horaires</h2>

<div class="row">
    <div class="col-md-3">

        <div class="row">
            <div class="col-md-12">
                <h6>datetimepicker1</h6>

                <div class="form-group">
                    <div class="input-group date " id="datetimepicker1">
                        <input style="height: 40px" type="text" class="form-control" id="txtDate" />	<span class="input-group-addon"><span class="glyphicon-calendar glyphicon"></span></span>
                    </div>
                </div>

            </div>
        </div></div>
    <div class="col-md-9" id="colonneHoraire" style="background-color: red">asdasd</div>
    </div>







	

<script type="text/javascript" src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.1/js/bootstrap.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/moment.js/2.9.0/moment-with-locales.js"></script>
<script src="//cdn.rawgit.com/Eonasdan/bootstrap-datetimepicker/e8bddc60e73c1ec2475f827be36e1957af72e2ea/src/js/bootstrap-datetimepicker.js"></script>












<script type="text/javascript"
        src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.9.0/moment-with-locales.js">
</script>
<script type="text/javascript"
        src="https://cdn.rawgit.com/Eonasdan/bootstrap-datetimepicker/a549aa8780dbda16f6cff545aeabc3d71073911e/src/js/bootstrap-datetimepicker.js">
</script>


<script>

    $('#datetimepicker1').datetimepicker();


</script>