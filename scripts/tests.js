/*
* @Author: JLafreniere
* @Date:   2016-11-01 19:53:00
* @Last Modified by:   JLafreniere
* @Last Modified time: 2016-11-12 16:21:12
*/

function workshift(emp, dateDebut, dateFin){
	this.Employe = emp;
	this.debut = dateDebut;
	this.fin = dateFin;
}


    


let ws1 = new workshift("Jean", new Date(2016, 10, 4, 5, 45, 0), new Date(2016, 10, 4, 16, 15, 0));
let ws2 = new workshift("Pierre", new Date(2016, 10, 5, 10, 30, 0), new Date(2016, 10, 4, 17, 15, 0));
let ws3 = new workshift("Marc", new Date(2016, 10, 3, 15, 25, 0), new Date(2016, 10, 4, 20, 15, 0));
let ws4 = new workshift("Marie", new Date(2016, 10, 4, 9, 45, 0), new Date(2016, 10, 4, 11, 55, 0));
let ws5 = new workshift("Paul", new Date(2016, 10, 4, 4, 45, 0), new Date(2016, 10, 4, 20, 15, 0));
let ws6 = new workshift("Pierre", new Date(2016, 9, 31, 4, 45, 0), new Date(2016, 9, 4, 12, 15, 0));
let ws7 = new workshift("Jean", new Date(2016, 9, 31, 5, 45, 0), new Date(2016, 9, 4, 20, 15, 0));
let ws8 = new workshift("Marie", new Date(2016, 9, 31, 18, 45, 0), new Date(2016, 9, 4, 23, 15, 0));


let shifts = [ws1, ws2, ws3, ws4, ws5, ws6, ws7, ws8];
afficherShifts(shifts);



function kek(){
console.log("DTP VALUE: " + document.getElementById("date_sem").value)
}


DrawRect(ws1.debut, ws1.fin);
