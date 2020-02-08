#include <iostream>
using namespace std;
/**
* @file Etat.cpp
* @brief Projet SDA
* @author SOK Alexis - VIGNARAJAH Daran
* @version 2 19/12/18
*/
#include "Etat.h"
#include "Tableau2D.h"

void afficher(const Etat& e) {
	if (e.parent != NULL) {
		switch (e.mouvements) {
		case NORD:
			cout << "NORD" << endl;
			break;
		case SUD:
			cout << "SUD" << endl;
			break;
		case EST:
			cout << "EST" << endl;
			break;
		case OUEST:
			cout << "OUEST" << endl;
			break;
		default:
			break;
		}
	}

	afficher(e.damierF);
	cout << "f=g+h=" << e.g << "+" << e.h << "=" << e.g + e.h << endl;
}

bool but(Etat& e) {
	Tab2D sol1;
	unsigned int cpt = 1;
	initialiser(sol1, e.damierF.nbL, e.damierF.nbC);
	for (unsigned int x = 0; x < e.damierF.nbL; x++) {
		for (unsigned int y = 0; y < e.damierF.nbC; y++) {
			sol1.tab[x][y] = cpt;
			cpt++;
		}
	}
	sol1.tab[(e.damierF.nbL) - 1][(e.damierF.nbC) - 1] = 0;

	if (comparer(sol1, e.damierF) == true) {
		return true;
	}

	cpt = 0;

	Tab2D tmp;
	initialiser(tmp, e.damierF.nbL, e.damierF.nbC);

	for (unsigned int x = 0; x < tmp.nbL; x++) {//copier
		for (unsigned int y = 0; y < tmp.nbC; y++) {
			tmp.tab[x][y] = sol1.tab[x][y];
		}
	}

	while (cpt < e.damierF.nbC - 1) {
		Tab2D tmp2;
		initialiser(tmp2, e.damierF.nbL, e.damierF.nbC);

		for (unsigned int x = 0; x < tmp2.nbL; x++) {//copier
			for (unsigned int y = 0; y < tmp2.nbC; y++) {
				tmp2.tab[x][y] = tmp.tab[x][y];
			}
		}

		for (unsigned int i = 0; i < e.damierF.nbL; i++) {//décalage de colonne
			for (unsigned int j = 0; j < e.damierF.nbC - 1; j++) {
				tmp2.tab[i][j + 1] = tmp.tab[i][j];
			}

			tmp2.tab[i][0] = tmp.tab[i][tmp.nbC - 1];
		}

		for (unsigned int x = 0; x < tmp.nbL; x++) {//copier
			for (unsigned int y = 0; y < tmp.nbC; y++) {
				tmp.tab[x][y] = tmp2.tab[x][y];
			}
		}

		if (comparer(tmp, e.damierF) == true) {
			return true;
		}

		cpt++;
	}

	return false;
}

unsigned int heuristique(Etat &e) {
	int heuristiqueMin = e.damierF.nbC * e.damierF.nbL;

	Tab2D sol1;
	unsigned int cpt = 1;
	initialiser(sol1, e.damierF.nbL, e.damierF.nbC);
	for (unsigned int x = 0; x < e.damierF.nbL; x++) {
		for (unsigned int y = 0; y < e.damierF.nbC; y++) {
			sol1.tab[x][y] = cpt;
			cpt++;
		}
	}
	sol1.tab[(e.damierF.nbL) - 1][(e.damierF.nbC) - 1] = 0;

	for (int x = 0; x < e.damierF.nbL; x++) {
		for (unsigned int y = 0; y < e.damierF.nbC; y++) {
			if ((e.damierF.tab[x][y] != sol1.tab[x][y]) && sol1.tab[x][y] != 0) {
				cpt++;
			}
		}
	}

	if (cpt < heuristiqueMin) {
		heuristiqueMin = cpt;
	}

	cpt = 0;

	Tab2D tmp;
	initialiser(tmp, e.damierF.nbL, e.damierF.nbC);

	for (unsigned int x = 0; x < tmp.nbL; x++) {//copier
		for (unsigned int y = 0; y < tmp.nbC; y++) {
			tmp.tab[x][y] = sol1.tab[x][y];
		}
	}

	while (cpt < e.damierF.nbC - 1) {
		Tab2D tmp2;
		initialiser(tmp2, e.damierF.nbL, e.damierF.nbC);

		for (unsigned int x = 0; x < tmp2.nbL; x++) {//copier
			for (unsigned int y = 0; y < tmp2.nbC; y++) {
				tmp2.tab[x][y] = tmp.tab[x][y];
			}
		}

		for (unsigned int i = 0; i < e.damierF.nbL; i++) {//décalage de colonne
			for (unsigned int j = 0; j < e.damierF.nbC - 1; j++) {
				tmp2.tab[i][j + 1] = tmp.tab[i][j];
			}

			tmp2.tab[i][0] = tmp.tab[i][tmp.nbC - 1];
		}

		for (unsigned int x = 0; x < tmp.nbL; x++) {//copier
			for (unsigned int y = 0; y < tmp.nbC; y++) {
				tmp.tab[x][y] = tmp2.tab[x][y];
			}
		}

		int h = 0;

		for (int x = 0; x < e.damierF.nbL; x++) {
			for (unsigned int y = 0; y < e.damierF.nbC; y++) {
				if ((e.damierF.tab[x][y] != tmp.tab[x][y]) && tmp.tab[x][y] != 0) {
					h++;
				}
			}
		}

		if (h < heuristiqueMin) {
			heuristiqueMin = h;
		}

		cpt++;
	}

	return heuristiqueMin;
}