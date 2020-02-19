const express = require('express');
const cors = require('cors');
const fetch = require('node-fetch');
var polyline = require('google-polyline');

const app = express(); // création de l'application
app.use(express.json());
app.use(cors());

app.get('/itineraire', (request, response) => {
  var departure = request.query.departure;
  var arrival = request.query.arrival;

  console.log(departure);
  console.log(arrival);

  var depart = departure.replace(" ", "+");
  var arrive= arrival.replace(" ", "+");

  var url = 'https://maps.googleapis.com/maps/api/directions/json?origin='+depart+'&destination='+arrive+'&key=AIzaSyCI9-tYg6bp8pB7iQ_wIEB750lCQYONlZI';

  fetch(url)
  .then((resp) => resp.text())
  .then((text) => JSON.parse(text))
  .then((data) => {
    var donnee = data;
    console.log(donnee);

    var tab = donnee.routes[0].legs[0].steps;

    var tab3 = [];

    for (var i = 0; i < tab.length; i++) {
      tab3.push(tab[i].polyline);
}

console.log("DONC-----------------------------------------------------------");
      console.log(tab3);

console.log("EUUUUH-----------------------------------------------------------");

      var oui = [];
      for (var i = 0; i < tab3.length; i++) {
        oui.push(polyline.decode(tab3[i]));
        console.log(oui[i]);
      }


    response.json(tab3);


  })
});

app.listen(3000, () => {
  console.log("le serveur tourne ");
})
