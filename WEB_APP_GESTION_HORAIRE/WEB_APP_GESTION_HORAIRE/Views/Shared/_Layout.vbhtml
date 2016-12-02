<!DOCTYPE html>
<html>
<head>

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - My ASP.NET Application</title>
    <script src="https://code.jquery.com/jquery-2.2.4.js"
            integrity="sha256-iT6Q9iMJYuQiMWNd9lDyBUStIq/8PuOW33aOqmvFpqI="
            crossorigin="anonymous"></script>


    
    
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />

    <link href="~/Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" media="screen" href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.1/css/bootstrap.min.css">
    
    
    <script src="~/Scripts/bootstrap.js"></script>
    <script src="~/Scripts/bootstrap.min.js"></script>
    <script src="~/Scripts/modernizr-2.6.2.js"></script>


</head>
<body>
    
    <div class="navbar navbar-inverse navbar-fixed-top" style="font-size: 12px">
        <div class="container">
            <div class="navbar-header accueil">
                <button class="navbar-toggle" type="button" data-toggle="collapse" data-target="#navbar-main">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                @Html.ActionLink("Gestion d'horaire", "Index", "Home", New With {.area = ""}, New With {.class = "navbar-brand"})
            </div>
            <center>
                
                <div class="navbar-collapse collapse" id="navbar-main">
                    <ul id="tabs" class="nav navbar-nav">
                        <li class="Horaire">
                            @Html.ActionLink("Mon horaire", "MonHoraire")
                        </li>
                        <li class="VoirHoraires adminTab">
                            @Html.ActionLink("Voir les horaires", "Horaires")
                        </li>
                        <li class="GererHoraires adminTab">
                           @Html.ActionLink("Gérer les horaires", "Horaires", "Horaires", New With {.area = ""}, New With {.class = ""})
                        </li>

                        <li class="Entreprises adminTab">
                           @Html.ActionLink("Entreprises", "ListeEntreprises", "Entreprises", New With {.area = ""}, New With {.class = ""})
                        </li>
                        <li class="Emplacements adminTab">
                            @Html.ActionLink("Emplacements", "ListeEmplacements", "Emplacements", New With {.area = ""}, New With {.class = ""})
                        </li>
                        <li class="Utilisateurs adminTab">
                           @Html.ActionLink("Utilisateurs", "ListeUtilisateurs", "Utilisateurs", New With {.area = ""}, New With {.class = ""})
                        </li>

           

 
                    </ul>
                  
                        @Code
                            If Not (Session("AdminRights")) Then
                                End Code
                    <script>
                        
                        $(".adminTab").remove();


                    </script>
                        @Code
                            End If
                                 End Code

                    @Code
                        If Not (Session("UserLogged")) Then
                    End Code
                    <script>
                      
                        $("#tabs").remove();


                    </script>
                    @Code
                        End If
                    End Code            

                  

                    @Code
                        If Session("uid") = 0 Then
                    End Code
                        <form Class="navbar-form navbar-right" role="search" style="font-size: 12px" action="/Utilisateurs/ConnecterUtilisateur" method="post">
                        <div Class="input-group-sm">
                            <div Class="form-group">
                                <input type = "text" Class="form-control input-sm" name="_username" id="username" placeholder="Utilisateur">
                            </div>
                            <div Class="form-group">
                                <input type = "password" Class="form-control input-sm" name="password" id="password" placeholder="Mot de passe">
                            </div>
                            <Button Class="btn btn-info btn-sm" type="submit"><span>Connexion</span></button>
                        </div>

                    </form>
@Code
    Else
End Code
                    <form action="/Utilisateurs/DeconnecterUtilisateur" method="post" Class="navbar-form navbar-right">
                    <button class="btn btn-default" type="submit">Déconnexion</button>
                        </form>
                    @code

                        End If
End Code
                </div>

            </center>
        </div>
    </div>



    <div Class="container body-content">
        @RenderBody()
        <script>

            let idActif = $("#pageName").val();
            $("." + idActif).addClass("active");


        </script>
        <hr />
        <footer>
                            <p> @DateTime.Now.Year - Jonathan Lafrenière</p>
        </footer>
    </div>

    
    <script src="~/Scripts/bootstrap.min.js"></script>
</body>
</html>
