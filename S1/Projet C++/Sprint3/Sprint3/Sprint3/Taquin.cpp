#include <iostream>
using namespace std;
/*
* @file Taquin.cpp
* @brief Projet SDA
* @author SOK Alexis - VIGNARAJAH Daran
* @version 2 19/12/18
*/
#include "Etat.h"
#include "Tableau2D.h"
#include "Taquin.h"
#include "Item.h"
#include "Liste.h"

void initialiser(Taquin& t) {

	Tab2D tableau;
	Etat etat;

	int nbC = 0, nbL = 0;

	cout << "Entrez le nombre de ligne et colonnes :" << endl;
	cin >> nbL >> nbC;


	initialiser(tableau, nbL, nbC);
	lire(tableau);

	t.initial = tableau;
	t.nbC = nbC;
	t.nbL = nbL;

	initialiser(t.LEAE);
	initialiser(t.LEE);

	etat.damierF = t.initial;
	etat.parent = NULL;

	inserer(t.LEAE, 0, etat);
}


void jouer(Taquin& t) {
	for (int compteur = 0; compteur < 2; compteur++) {
		cout << "Iteration " << compteur << endl;

		afficher(t);

		if (longueur(t.LEAE) > 0) {
			Etat actuel = lire(t.LEAE, longueur(t.LEAE) - 1);
			supprimer(t.LEAE, longueur(t.LEAE) - 1);

			inserer(t.LEE, longueur(t.LEE), actuel);

			int ligneX = 0;
			int ligneY = 0;

			for (int x = 0; x < t.nbL; x++) {
				for (int y = 0; y < t.nbC; y++) {
					//on cherche la case contenant un # (c'est une case nulle)
					if (actuel.damierF.tab[x][y] == 0) {
						//on l'a trouvé, on peut arreter les deux boucles et retourner sa position
						ligneX = x;
						ligneY = y;
						break;
					}
				}
			}

			Mouvement *mvs = mouvements_possible(ligneX, ligneY, t.nbL - 1, t.nbC - 1);
			creer_fils(mvs, actuel, ligneX, ligneY, t);
		}

		cout << "Fin iteration " << compteur << endl;
		cout << endl;
	}
}

Mouvement *mouvements_possible(int ligneX, int ligneY, int maxX, int maxY) {
	Mouvement *mvmts = new Mouvement[4];

	if (ligneX == 0) {
		mvmts[0] = EST;
		mvmts[1] = SUD;
		mvmts[2] = OUEST;
		mvmts[3] = FIXE;
	}
	else if (ligneX == maxX) {
		mvmts[0] = EST;
		mvmts[1] = OUEST;
		mvmts[2] = NORD;
		mvmts[3] = FIXE;
	}
	else {
		mvmts[0] = EST;
		mvmts[1] = SUD;
		mvmts[2] = OUEST;
		mvmts[3] = NORD;
	}

	return mvmts;
}

void creer_fils(Mouvement *tab_mouvement, Etat& e, int lignex, int ligney, Taquin& t) {
	for (int i = 0; i < 4; i++) {
		if (tab_mouvement[i] != FIXE) {
			Etat nouvelEtat;
			Tab2D nDamier;
			int nX = lignex, nY = ligney;

			nouvelEtat.parent = &e;
			nouvelEtat.mouvements = tab_mouvement[i];

			initialiser(nDamier, e.damierF.nbL, e.damierF.nbC);

			for (int x = 0; x < nDamier.nbL; x++) {
				for (int y = 0; y < nDamier.nbC; y++) {
					nDamier.tab[x][y] = e.damierF.tab[x][y];
				}
			}

			switch (tab_mouvement[i]) {
			case NORD:
				nX--;
				break;
			case EST:
				nY++;
				break;
			case SUD:
				nX++;
				break;
			case OUEST:
				nY--;
				break;
			default:
				break;
			}


			Item tmp = nDamier.tab[lignex][ligney];
			nDamier.tab[lignex][ligney] = nDamier.tab[nX][nY];
			nDamier.tab[nX][nY] = tmp;

			nouvelEtat.damierF = nDamier;

			inserer(t.LEAE, longueur(t.LEAE), nouvelEtat);
		}
	}
}

void afficher(const Taquin& t) {
	cout << "*** LEE - long : " << longueur(t.LEE) << endl;
	for (int i = 0; i < longueur(t.LEE); i++) {
		afficher(lire(t.LEE, i));
	}

	cout << endl;

	cout << "*** LEAE - long : " << longueur(t.LEAE) << endl;
	for (int i = 0; i < longueur(t.LEAE); i++) {
		afficher(lire(t.LEAE, i));
	}
}