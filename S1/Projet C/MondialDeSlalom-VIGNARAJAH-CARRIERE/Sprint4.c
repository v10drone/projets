#include<stdio.h>
#include<stdlib.h>
#include<string.h>
#define lgMot 30                //30 caractères maximum lors de l'entrée
#define maxSkieurs 50           //50 skieurs au maximum dans la course
#define minPortes 2
#define maxPortes 20
#pragma warning(disable:4996)

//void inscription_skieur(Skieur *ins);
//void affichage_skieurs(const Inscrits *ins);

typedef struct {
	char nom[lgMot + 1];
	char pays[lgMot + 1];
	unsigned int dossard;
}Skieur;

typedef struct {
	Skieur liste[maxSkieurs];
	unsigned int nbInscrits;
}Inscrits;

typedef struct {
	double temps;
	unsigned int portes;
	unsigned int dossard;
}Mesure;

typedef struct {
	unsigned int nb_portes;
	Mesure liste[maxSkieurs*maxPortes];
	int num_mesure;
}Course;

Course crs;

void inscrire_skieur(Inscrits *ins) {
	char mot[lgMot];
	int dossard = 101;


	scanf("%s", mot);
	strcpy(ins->liste[ins->nbInscrits].nom, mot);
	scanf("%s", mot);
	strcpy(ins->liste[ins->nbInscrits].pays, mot);
	ins->liste[ins->nbInscrits].dossard = 101 + ins->nbInscrits;
	ins->nbInscrits++;

	Skieur s;
	s.dossard = (100 + ins->nbInscrits);
	printf("inscription dossard %d \n", s.dossard);
}

void afficher_skieurs(const Inscrits *ins) {

	//for (int i = 0; i < ins->nbInscrits; ++i)
		//printf("inscription dossard %d \n", ins->liste[i].dossard);


	for (int i = 0; i < ins->nbInscrits; ++i)
		printf("%s %s %d \n", ins->liste[i].nom, ins->liste[i].pays, ins->liste[i].dossard);

}

void definition_course(Course *crs) {
	int portes;
	scanf("%d", &portes);

}

void enregistrer_temps(Inscrits *ins, Course *crs) {
	double temps;
	unsigned int portes, dossard;
	Mesure mesure;

	scanf("%f", &temps);
	mesure.temps = temps;

	scanf("%u", &portes);
	mesure.portes = portes;

	scanf("%u", &dossard);
	mesure.dossard = dossard;

	crs->liste[crs->num_mesure] = mesure;

	crs->num_mesure++;

}

void afficher_temps(Course *crs) {
	unsigned int dossard;
	Mesure mesure;

	scanf("%u", &dossard);

	for (int i = 0; i < crs->num_mesure; i++) {

		if (dossard == crs->liste[i].dossard) {

			if (crs->liste[i].temps == -1) {

				printf("%u %u disqualification  \n", crs->liste[i].portes, crs->liste[i].dossard);

			}
			else
			{
				printf("%u %u %.2f \n", crs->liste[i].portes, crs->liste[i].dossard, crs->liste[i].temps);
			}
		}
	}
}


void disqualification_skieur(Course *crs) {
	unsigned int portes;
	unsigned int dossards;
	Mesure mesure;

	scanf("%u", &portes);
	mesure.portes = portes;

	scanf("%u", &dossards);
	mesure.dossard = dossards;

	mesure.temps = -1.;

	crs->liste[crs->num_mesure] = mesure;
	crs->num_mesure++;


}

void affichage_classement(Inscrits *ins, Course *crs) {

	int i = 0, j, dossard, porte;
	int tDos[maxSkieurs], nb_mesure = 0;
	double tTps[maxSkieurs], v = 0;

	scanf("%d", &porte);

	while (i < crs->num_mesure) {
		++i;
		if ((crs->liste[i].portes == porte) && (crs->liste[i].temps != -1)) {
			dossard = crs->liste[i].dossard;
			for (j = 0; j < crs->num_mesure; ++j) {
				if ((crs->liste[j].dossard == dossard) && (crs->liste[j].portes == 0))
					break;
			}
			tDos[nb_mesure] = dossard;
			tTps[nb_mesure] = crs->liste[i].temps - crs->liste[j].temps;
			nb_mesure++;
		}
	}


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
			if (tDos[n] == ins->liste[i].dossard)

				printf("%d %d %s %s %.2f \n", porte, tDos[n], ins->liste[i].nom, ins->liste[i].pays, tTps[n]);
		}
	}

}


int main() {

	char mot[lgMot]; //on stocke ici ce que va remplir l'utilisateur
	Inscrits ins;
	ins.nbInscrits = 0;

	while (1)
	{

		scanf("%s", &mot); //envoie de l'entrée faite par l'utilisateur à mot

		if (strcmp(mot, "inscrire_skieur") == 0)
		{
			inscrire_skieur(&ins);
		}
		else if (strcmp(mot, "afficher_skieurs") == 0)
		{
			afficher_skieurs(&ins);
		}

		else if (strcmp(mot, "definir_course") == 0)
		{
			definition_course(&crs);

		}

		else if (strcmp(mot, "enregistrer_temps") == 0)
		{
			enregistrer_temps(&ins, &crs);
		}

		else if (strcmp(mot, "afficher_temps") == 0)
		{
			afficher_temps(&crs);
		}

		else if (strcmp(mot, "disqualification") == 0)
		{
			disqualification_skieur(&crs);
		}

		else if (strcmp(mot, "afficher_classement") == 0)
		{
			affichage_classement(&ins, &crs);
		}

		else if (strcmp(mot, "exit") == 0)
		{
			exit(1);
		}

	}
	system("pause");
	return 0;
}