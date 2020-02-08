#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <string.h>
#include <assert.h>

#pragma warning(disable:4996)

#define lgMot 30
#define maxSkieurs 50
#define minPorte 2
#define maxPorte 20



/*PARTIE STRUCTURE*/

typedef struct Skieur {  //Déclaration tableau pour l'inscription du skieur;
	char nom[lgMot + 1];   // Le +1 pour le \0;
	char pays[lgMot + 1];
	unsigned int dossard;
}Skieur;

Skieur s;

typedef struct Inscrit {
	Skieur data[maxSkieurs];
	unsigned int nbInscrits;	// Contient le nombre d'inscrits dans la course
}Inscrit;

Inscrit skieurInscrit;

typedef struct Mesure {
	float temps;
	int porte, dossard;
}Mesure;

Mesure mes;

typedef struct Course {
	unsigned int nbportes;
	unsigned int nbMesures;
	Mesure data[maxSkieurs*maxPorte];
}Course;

Course crs;



/*PROTOTYPAGE DES FONCTIONS QUE L'ON VA UTILISER*/

void inscrire_skieur(Inscrit *ins);

void afficher_skieur(Inscrit *ins);

void definition_course(Course *crs);

void enregistrement_temps(Course *crs);

void affichage_temps(Course *crs);

void disqualification(Course *crs);

void affichage_classement(const Inscrit *ins, const Course *crs);



/*FONCTION PRINCIPALE*/

int main() {

	while (1 == 1) {

		char tab1[lgMot + 1];	//déclaration du tableau où l'on va inscrire chacune des 8 commandes;

		scanf("%s", tab1);      // une des 8 commandes;

		if (strcmp(tab1, "exit") == 0) {
			exit(1);			// ferme le CMD;
		}

		if (strcmp(tab1, "inscrire_skieur") == 0) {

			inscrire_skieur(&skieurInscrit);		// Appel de la fonction... ;

		}

		if (strcmp(tab1, "afficher_skieurs") == 0) {// Appel de la fonction... ;

			afficher_skieur(&skieurInscrit);

		}

		if (strcmp(tab1, "definir_course") == 0) { // Appel de la fonction... ;
			definition_course(&crs);
		}

		if (strcmp(tab1, "enregistrer_temps") == 0) {// Appel de la fonction... ;
			enregistrement_temps(&crs);
		}

		if (strcmp(tab1, "afficher_temps") == 0) {// Appel de la fonction... ;
			affichage_temps(&crs);
		}

		if (strcmp(tab1, "disqualification") == 0) {// Appel de la fonction... ;
			disqualification(&crs);
		}

		if (strcmp(tab1, "afficher_classement") == 0) {// Appel de la fonction... ;
			affichage_classement(&skieurInscrit, &crs);
		}
	}

	system("pause");
	return 0;
}


void inscrire_skieur(Inscrit *ins) {

	char mot[lgMot + 1];

	int dossard = 101;

	assert(ins->nbInscrits < 50);	// Au bout de 50 inscriptions, un message d'erreur sera affiché;

	scanf("%s", mot);
	strcpy(ins->data[ins->nbInscrits].nom, mot);	// on remplace ce qui est dans le char data (pointant vers le nom) dans le char mot;

	scanf("%s", mot);
	strcpy(ins->data[ins->nbInscrits].pays, mot);	// on remplace ce qui est dans le char data (pointant vers le pays) dans le char mot;

	ins->data[ins->nbInscrits].dossard = 101 + ins->nbInscrits; // A chaque skieur lui sera affecté un dossard;
	ins->nbInscrits++;		// on incrémente;

	Skieur s;
	s.dossard = (100 + ins->nbInscrits);
	printf("inscription dossard %d \n", s.dossard); //affiche le dossard du skieur qu'on a inscrit;
}

void afficher_skieur(Inscrit *ins) {

	for (int i = 0; i < ins->nbInscrits; ++i)
		printf("%s %s %d \n", ins->data[i].nom, ins->data[i].pays, ins->data[i].dossard);  // va afficher tout les skieurs avec leur dossard;

}

void definition_course(Course *crs) { // défini le nombre de portes;

	char portes[lgMot + 1];

	scanf("%s", portes);

	crs->nbportes = atoi(portes);		// converti la chaine de caractère en "valeur numérique";
	assert(minPorte <= crs->nbportes <= maxPorte);

}

void enregistrement_temps(Course *crs) {

	//Définition des variables temporaires
	float temps;
	int porte;
	int dossard;

	scanf("%f", &temps);
	scanf("%d", &porte);
	scanf("%d", &dossard);

	//Création de l'object Mesure
	Mesure mes;

	mes.temps = temps;		// la variable temporaire temps vaut maintenant la valeur temps situé dans la structure Mesure;
	mes.porte = porte;
	mes.dossard = dossard;

	//On ajoute dans le tableau de mesure à la position nbMesures la nouvelle mesure
	crs->data[crs->nbMesures] = mes;
	crs->nbMesures++;
}


void affichage_temps(Course *crs) {

	unsigned int dossard;

	Mesure mesure;

	scanf("%u", &dossard);

	for (int i = 0; i < crs->nbMesures; i++) {

		if (dossard == crs->data[i].dossard) { //on vérifie si c'est bien égal;

			if (crs->data[i].temps == -1) { // une valeur est affecté pour le skieur défaillant: ici -1;

				printf(" %u %u disqualification \n", crs->data[i].porte, crs->data[i].dossard);

			}
			else
			{
				printf("%u %u %.2f \n", crs->data[i].porte, crs->data[i].dossard, crs->data[i].temps);
			}
		}
	}
}


void disqualification(Course *crs) {
	// Variables temporaires
	unsigned int porte;
	unsigned int dossard2;

	Mesure mesure;

	scanf("%u", &porte);
	mesure.porte = porte;

	scanf("%u", &dossard2);
	mesure.dossard = dossard2;

	mesure.temps = -1.; // le skieur disqualifié aura la valeur -1 pour son temps;

	crs->data[crs->nbMesures] = mesure;
	crs->nbMesures++;

}

void affichage_classement(const Inscrit *ins, const Course *crs) {

	// Variables temporaires;
	int i = 0, j, dossard, porte, v = 0;
	int tDos[maxSkieurs], nb_mesure = 0;
	float tTps[maxSkieurs];

	scanf("%d", &porte);

	while (i < crs->nbMesures) {
		i++;
		if ((crs->data[i].porte == porte) && (crs->data[i].temps != -1)) {
			dossard = crs->data[i].dossard;
			for (j = 0; j < crs->nbMesures; ++j) {
				if ((crs->data[j].dossard == dossard) && (crs->data[j].porte == 0))
					break;
			}
			tDos[nb_mesure] = dossard;
			tTps[nb_mesure] = crs->data[i].temps - crs->data[j].temps;
			nb_mesure++;
		}
	}

	// Tri par sélection;
	for (int n = 0; n < nb_mesure; ++n) {
		v = tTps[n];
		j = n;
		int tmp = tDos[n];

		while ((j > 0) && (tTps[j - 1] > v))
		{
			tTps[j] = tTps[j - 1];
			tDos[j] = tDos[j - 1];
			j = j - 1;
		}

		tTps[j] = v;
		tDos[j] = tmp;
	}

	for (int n = 0; n < nb_mesure; ++n) {
		for (i = 0; i < ins->nbInscrits; ++i) {
			if (tDos[n] == ins->data[i].dossard)

				printf("%d %d %s %s %.2f \n", porte, tDos[n], ins->data[i].nom, ins->data[i].pays, tTps[n]);
		}
	}
}