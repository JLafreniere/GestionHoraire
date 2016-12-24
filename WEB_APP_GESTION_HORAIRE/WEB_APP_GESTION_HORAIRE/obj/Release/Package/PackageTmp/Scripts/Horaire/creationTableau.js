let body;
let events = [];
let HeaderHeight = 30;
let HeaderColumnWidth = 100;
let ScheduleColumnWidth = 109; //!!!!!
let ScheduleColumnHeight = 600 - HeaderHeight;
let b = true;
var app = document.getElementById("app_cvs");

function createDiv(classe) {
    let temp = document.createElement("div")
    temp.className = classe;
    return temp;
}


function workshift(emp, dateDebut, dateFin) {
    this.Employe = emp;
    this.debut = dateDebut;
    this.fin = dateFin;
}





function creerCanvas() {

    app = document.getElementById("app_cvs");

    app.addEventListener("mousedown", getPosition, false);

    function getPosition(event) {
        let x = event.x;
        let y = event.y;

        let canvas = document.getElementById("app_cvs");

        x -= canvas.offsetLeft;
        y -= canvas.offsetTop;

        

        executeEvents(x, y);

    }




}



function executeEvents(x, y) {

}




function loadCanvas(date) {


    app = document.getElementById("app_cvs");
    let c = app.getContext("2d");
    c.clearRect(0, 0, app.width, app.height);
    

    c.fillStyle = "black";

    c.strokeRect(0, 0, app.width, HeaderHeight);
    c.strokeRect(0, 0, app.width - 1, app.height - 1);

    c.strokeRect(0, 0, HeaderColumnWidth, app.height);



    ScheduleColumnWidth = (app.width - HeaderColumnWidth) / 7;

    c.font = "14px Segoe UI"


    c.strokeStyle = "#DFDFDF";
    c.lineWidth = 1;
    for (var i = 1; i <= 24; i++) {

        c.beginPath();
        if (i > 1) {
            c.globalCompositeOperation = "source-over";
            c.fillText((i - 1) + ":00", HeaderColumnWidth / 2, ((app.height - HeaderHeight) / 24) * i - 13 + HeaderHeight - 7, HeaderColumnWidth - 10);
        }
        c.globalCompositeOperation = "destination-over";
        c.strokeStyle = "#DFDFDF";
        c.moveTo(1, ((app.height - HeaderHeight) / 24) * i + HeaderHeight)
        c.lineTo(app.width, ((app.height - HeaderHeight) / 24) * i + HeaderHeight)
        c.stroke();
        c.strokeStyle = "black";
        c.textAlign = "center";

        c.closePath();
    }

    c.strokeStyle = "black"
    
    let date_semaine = getLastSunday(date);
    for (var i = 0; i < 7; i++) {


        c.beginPath();

        c.strokeRect(HeaderColumnWidth + (ScheduleColumnWidth * i), 0, ScheduleColumnWidth, app.height);

        c.closePath();

        c.beginPath();

        c.fillText(WeekDays[i] + " " + date_semaine.getDate(), HeaderColumnWidth + (ScheduleColumnWidth * i) + (ScheduleColumnWidth / 2), HeaderHeight - 10, ScheduleColumnWidth);
        c.closePath();
        date_semaine.setDate(date_semaine.getDate() + 1);
    }
    c.save();



    let c1 = app.getContext("2d");
    c1.beginPath();
    c1.strokeStyle = "black"

    c1.moveTo(app.width - 1, 0);
    c1.lineTo(app.width - 1, app.height - 1);
    c1.stroke();
    c1.closePath();

}


function DrawRect(emp, dateDebut, dateFin) {

    
    let app = document.getElementById("app_cvs");
    let c = app.getContext("2d");
    c.globalCompositeOperation = 'destination-over';
    console.log("SHIFT DU" + dateDebut + " au " + dateFin);

    let posX = HeaderColumnWidth + (dateDebut.getDay() * ScheduleColumnWidth);
    let heureDebut = dateDebut.getHours() + (dateDebut.getMinutes() / 60);
    let heureFin = dateFin.getHours() + (dateFin.getMinutes() / 60);

    console.log("Debut: " + heureDebut + " fin: " + heureFin);

    let height =  23.75*(heureFin - (heureDebut));
    let posY = ((heureDebut) *23.75)+32;
    console.log("height: " + height + " posy: " + posY);

    c.beginPath();
    c.globalCompositeOperation = "color-burn";
    c.fillStyle = "rgba(112,194,228, 0.6)";
    c.strokeStyle = "black";



    c.fillRect(posX + 1, posY-2, ScheduleColumnWidth - 1, height-2);
    c.strokeRect(posX + 1, posY-2, ScheduleColumnWidth - 1, height-2);
    c.closePath();

    c.beginPath();



    c.globalCompositeOperation = 'source-over';
    c.fillStyle = "black";
    c.font = "13px Segoe UI";
    c.textAlign = "start";

    let nameYPosMultiplier = getMultiplier(posX, posY);

    c.fillText(emp, posX + 5, posY + (12* nameYPosMultiplier)+ 12);




    /*
    c.fillRect(posX, 0, posX + ScheduleColumnWidth, 100);
    c.fillRect(100, 100, 100, 100);
    c.strokeRect(100, 100, 100, 100);
    c.strokeRect(100, 150, 100, 100);
    c.strokeRect(100, 170, 100, 100);
    c.fillRect(100, 150, 100, 100);
    c.fillRect(100, 170, 100, 100);
    */

    c.closePath();

}

function getMultiplier(posX, posY) {

    let count = 0;

    nameMap.forEach(function (position) {
        if (position == (posX + "," + posY))
            count++;
        console.log("POSITION ARRAY: " + position + " POSITION X Y: " + posX + "," + posY);

    });

    nameMap.push(posX + "," + posY);
    return count;
    
}


function refreshApp() {

    let dateFieldContent = document.getElementById("txtDate").value;
    let selected_date = Date.now();
    let next_saturday = Date.now();

    

    if (!(dateFieldContent == "")) {

        let year, month, day;
        
        year = parseInt(dateFieldContent.split("-")[0]);
        month = parseInt(dateFieldContent.split("-")[1]) - 1;
        day = parseInt(dateFieldContent.split("-")[2]);

        selected_date = new Date(year, month, day);
        selected_date = getLastSunday(selected_date);
        next_saturday = getNextSaturday(selected_date);


        
    }

    let ct = app.getContext("2d");
    ct.clearRect(0, 0, app.width, app.height);
    //TODO: RETRIEVE DATE FROM DATETIMEPICKER
    
    let newDate = new Date(document.getElementById("txtDate").value);
    
    loadCanvas(newDate);

}



function getLastSunday(d) {
    var t = new Date(d);
    t.setDate(t.getDate() - t.getDay());
    return t;
}

function getNextSaturday(d) {
    var t = new Date(d);
    t.setDate(t.getDate() + 6);
    return t;
}



Date.prototype.addDays = function (days) {
    var dat = new Date(this.valueOf());
    dat.setDate(dat.getDate() + days);
    return dat;
}

Date.prototype.format = function () {
    return this.getDate() +
    " " + (monthNames[this.getMonth()]) +
    " " + this.getFullYear();
}

function afficherShifts(shifts) {
    for (var i = shifts.length - 1; i >= 0; i--) {
        
        DrawRect(shifts[i].Employe, shifts[i].debut, shifts[i].fin);
    }
}