
const express = require('express');
const volleyball = require('volleyball');
const cors = require('cors');
const ical = require('ical');
const fetch = require("node-fetch");



//On démarre notre application express
app = express();

//Permet à n'importe quelle client d'envoyer des requêtes à ce serveur (cors = Cross origin )
app.use(cors());

//Cela permet à notre serveur de comprendre le JSON
app.use(express.json());

//Permet l'affichage sur l'invite de commande node des requêtes entrante et response sortant (pour le débugage)
app.use(volleyball);



const months = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sept', 'Oct', 'Nov', 'Dec'];
var days = ['Dimanche', 'Lundi', 'Mardi', 'Mercredi', 'Jeudi', 'Vendredi', 'Samedi'];



app.get("/", (request, response) => {


    response.json({
        message: "clear /"
    })
})
app.post("/dowloadParse", (request, response) => {

    const requestURL = request.body.calendarURL;

    ical.fromURL(requestURL, {}, function (err, data) {

        if (err) {
            console.log(err);
        }
        const calendar = [];
        for (let k in data) {
            if (data.hasOwnProperty(k)) {
                var ev = data[k];
                if (data[k].type == 'VEVENT') {

                    //Si le jour de la matière est inférieur à la date du jour on le considère pas
                    if (ev.start.getTime() - (new Date).getTime() < 0) {
                        continue;
                    }


                    //Le jour ou on à le cours servira de clé dans le tableau
                    //La clé sera le timestamp du jour ou le cour a lieu à 00h00
                    //On met les mois et les jours sur 2 chiffre (01,02,03 ect)
                    const dateStart = `${("0" + ev.start.getDate()).slice(-2)}/${months[ev.start.getMonth()]}/${ev.start.getFullYear()}`;
                    console.log(dateStart);
                    //En france on est en UTC + 1 donc on rajoute 1h 
                    // ev.start.setTime(ev.start.getTime() + (1*60*60*1000));
                    const dateStartKey = (new Date(dateStart)).getTime() + "-" + dateStart;


                    const dayOfWeek = days[ev.start.getDay()];

                    // console.log(dateStart);
                    // console.log(dayOfWeek);

                    if (!calendar[dayOfWeek]) {
                        calendar[dayOfWeek] = {}
                    }

                    //Si on à pas de tableau pour cette date on le crée
                    if (!calendar[dayOfWeek][dateStartKey]) {
                        calendar[dayOfWeek][dateStartKey] = [];
                    }

                    ev.startMilis = new Date(ev.start).getTime();
                    calendar[dayOfWeek][dateStartKey].push(ev);
                }
            }
        }


        //Maintenant qu'on à un tableau associatif à 2 dimension 
        // avec
        // 1 ere dimension : clé (jour de la semaine) et valeur(tableau pour chaque journée de cours tombant le jour qui sert de clé)
        //2eme dimension : clé (jour/mois/année) et valeur (liste des cours) 
        //On trie aussi le tableau des cours pour chaque jour pour avoir un vrai calendrier
        for (let day in calendar) {

            // calendar[day].sort((a, b) => {
            //     return b.localeCompare(a);
            // })

            //On trie le JSON
            const ordered = {};
            Object.keys(calendar[day]).sort().forEach(function (key) {
                ordered[key] = calendar[day][key];
            });
            calendar[day] = ordered;



            for (let date in calendar[day])
                calendar[day][date].sort((a, b) => {
                    return a.start.getTime() - b.start.getTime();

                });
            // console.log(calendar[day]);


            // console.log("=========");

        }

        // console.log(calendar);

        console.log(calendar);
        console.log(calendar["Lundi"]);
        response.json({
            "Lundi": calendar["Lundi"],
            "Mardi": calendar["Mardi"],
            "Mercredi": calendar["Mercredi"],
            "Jeudi": calendar["Jeudi"],
            "Vendredi": calendar["Vendredi"],
            "Samedi": calendar["Samedi"],
            "Dimanche": calendar["Dimanche"],

        });

    });

});



/*------ http://localhost:3000/itineraire?departure=247%20rue+de+crimee&arrival=127%20avenue%20de%20Versailles----------*/
app.get('/itineraire', (request, response) => {
    var departure = request.query.departure; // on reçoit l'adresse de départ
    var arrival = request.query.arrival; // on reçoit l'adresse d'arrivée

    console.log(departure);
    console.log(arrival);

    /* En vrai je crois que ça sert à rien Google doit sûrement le faire soi-même*/
    var depart = departure.replace(" ", "+");
    var arrive = arrival.replace(" ", "+");

    /* ----- Utilisation de l'API Google Direction : belek la clé d'API de Daran ne pas trop l'utiliser*/
    var url = 'https://maps.googleapis.com/maps/api/directions/json?origin=' + depart + '&destination=' + arrive + '&key=AIzaSyCI9-tYg6bp8pB7iQ_wIEB750lCQYONlZI';

    /*récupérer les données qu'on a demandé*/
    fetch(url)
        .then((resp) => resp.json())
        .then((data) => {


            response.json({ duration: parseInt(data.routes[0].legs[0].duration.text.split(" ")[0]) });

        })

});





const server = app.listen(3000, () => {
    console.log("Serveur is running");
})

