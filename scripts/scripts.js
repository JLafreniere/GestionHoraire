	var WeekDays = [
	"Dimanche",
	"Lundi",
	"Mardi",
	"Mercredi",
	"Jeudi",
	"Vendredi",
	"Samedi"
	];


function renderApp(){

	let container = document.getElementById("app-container");
	

	let HeaderRow = document.createElement("div");
	HeaderRow.className="row";
	container.appendChild(HeaderRow);

	let HeaderTopLeftCell = document.createElement("div");
	HeaderTopLeftCell.className="col-xs-12";
	HeaderTopLeftCell.innerHTML="Heure";


	let HourColumn = document.createElement("div");
	HourColumn.className="col-xs-5"
	HourColumn.style.width="16%";
	let HourRowHeaderContainer = document.createElement("div");
	HourRowHeaderContainer.className="row";
	HourRowHeaderContainer.appendChild(HeaderTopLeftCell);




	for (let i = 0; i <= 23 ; i++) {
		
		
		
		let HourRowHeader = document.createElement("div");
		HourRowHeader.className="col-xs-12 nopadding";
		
		
		let rectangle = document.createElement("div");
		rectangle.innerHTML=i + ":00"
		rectangle.style="width:100%;height:40px;border:1px solid #000; margin-top: 20px;"

		HourRowHeader.appendChild(rectangle);

		HourRowHeaderContainer.appendChild(HourRowHeader);
		
	}
	HourColumn.appendChild(HourRowHeaderContainer);
	container.appendChild(HourColumn)







	for (let i = 0; i <= 6; i++) {
	let DayColumn = document.createElement("div");
	DayColumn.className="col-xs-1"
	DayColumn.style.width="12%";
	let ColumnHeader = document.createElement("div");
	ColumnHeader.className="col-xs-12";
	ColumnHeader.innerHTML=WeekDays[i];

		let CellRowHeaderContainer = document.createElement("div");
	CellRowHeaderContainer.className="row";
	CellRowHeaderContainer.appendChild(ColumnHeader);
	
	

	for (let i = 0; i <= 23 ; i++) {
		
		console.log("bonjour");
		
		let EmptyCell = document.createElement("div");
		EmptyCell.className="col-xs-12 nopadding";
		EmptyCell.innerHTML = ".";
		EmptyCell.style.color = "transparent";
		let rectangle = document.createElement("div");
		rectangle.style="width:100%;height:40px;border:1px solid #C8C8C8;"
		EmptyCell.appendChild(rectangle);

		EmptyCell.style="width:100%"
		CellRowHeaderContainer.appendChild(EmptyCell);
		DayColumn.appendChild(CellRowHeaderContainer);
	}
		container.appendChild(DayColumn);
	}
}



