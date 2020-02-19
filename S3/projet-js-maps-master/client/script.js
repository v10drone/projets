
//On configure la sidebar
$(document).ready(function () {
    $('.drawer').drawer({
        showOverlay: false
    });
});

//On crée l'évènement pour notre formulaire on va traiter la requête nous même

$("#searchForm").submit(function(e){
    e.preventDefault();

    console.log("Evénement intercepté");

    //Ici on continue on récupère les champs que le gars à saisie et on fait une requête à notre api 
    




})


//Dessin de la map
var map = L.map('map',
    {
        center: [48.858376, 2.294442],
        zoom: 18
    });
var base = L.tileLayer('http://{s}.tile.osm.org/{z}/{x}/{y}.png').addTo(map);



