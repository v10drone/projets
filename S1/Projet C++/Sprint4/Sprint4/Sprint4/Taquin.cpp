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

	std::cout << "Entrez le nombre de ligne et colonnes :" << endl;
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
	etat.g = 0;
	etat.h = heuristique(etat);

	inserer(t.LEAE, 0, etat);
}

bool jouer(Taquin& t) {
	bool fin = false;
	unsigned int compteur = 0;

	while (fin == false && compteur < 100) {
		cout << "Iteration " << compteur << endl;

		afficher(t);

		/*if (longueur(t.LEAE) == 0) {
			cout << "A" << endl;
			break;
		}*/
		Etat actuel = algorithmeRecherche(t);

		if (but(actuel)) {
			fin = true;
			std::cout << "Fin iteration " << compteur << endl;
			std::cout << endl;
			break;
		}

		unsigned int ligneX = 0;
		unsigned int ligneY = 0;

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

		creer_fils(actuel, ligneX, ligneY, t);

		/*//if (longueur(t.LEAE) > 0) {
		Etat actuel = lire(t.LEAE, longueur(t.LEAE) - 1);
		supprimer(t.LEAE, longueur(t.LEAE) - 1);

		inserer(t.LEE, longueur(t.LEE), actuel);
		cout << "ccccccccccccc" << endl;
		int ligneX = 0;
		int ligneY = 0;

	//}
	cout << "ANOUPANOUP" << endl;
	for (int x = 0; x < t.nbL; x++) {
		for (int y = 0; y < t.nbC; y++) {

			//on cherche la case contenant un # (c'est une case nulle)
			if (actuel.damierF.tab[x][y] == 0)
				//on l'a trouvé, on peut arreter les deux boucles et retourner sa position
				ligneX = x;
			ligneY = y;
		}
	}

	cout << "ddddddd" << endl;
	Mouvement *mvs = mouvements_possible(ligneX, ligneY, t.nbL - 1, t.nbC - 1);
	creer_fils(mvs, actuel, ligneX, ligneY, t);

	*/

		std::cout << "Fin iteration " << compteur << endl;
		std::cout << endl;
		compteur++;
	}

	if (fin) {
		//solution trouvée
	}
	else {
		cout << "Ce taquin n'a pas de solution" << endl;
	}
	return false;
}

Mouvement *mouvements_possible(int ligneX, int ligneY, Taquin &t) {
	Mouvement *mvmts = new Mouvement[4];

	int maxX = t.nbL - 1;
	int maxY = t.nbL - 1;

	if (ligneX == 0) {
		mvmts[2] = EST;
		mvmts[1] = SUD;
		mvmts[0] = OUEST;
		mvmts[3] = FIXE;
	}
	else if (ligneX == maxX) {
		mvmts[2] = EST;
		mvmts[1] = OUEST;
		mvmts[0] = NORD;
		mvmts[3] = FIXE;
	}
	else {
		mvmts[3] = EST;
		mvmts[2] = SUD;
		mvmts[1] = OUEST;
		mvmts[0] = NORD;
	}

	return mvmts;
}

void creer_fils(Etat& e, int lignex, int ligney, Taquin& t) {
	Mouvement *mvs = mouvements_possible(lignex, ligney, t);

	for (unsigned int i = 0; i < e.damierF.nbC; i++) {
		if (mvs[i] != FIXE) {
			int x2 = lignex, y2 = ligney;
			Mouvement mv = mvs[i];
			
			Tab2D nDamier;
			initialiser(nDamier, e.damierF.nbL, e.damierF.nbC);
			
			Etat nouvelEtat;
			nouvelEtat.parent = &e;
			nouvelEtat.mouvements = mv;
			nouvelEtat.g = e.g + 1;

			for (unsigned int x = 0; x < nDamier.nbL; x++) {
				for (unsigned int y = 0; y < nDamier.nbC; y++) {
					nDamier.tab[x][y] = e.damierF.tab[x][y];
				}
			}

			switch (mv) {
				case NORD:
					x2 = x2 - 1;
					break;
				case EST:
					if (nDamier.nbC - 1 == ligney) {
						y2 = 0;
					}
					else {
						y2 = y2 + 1;
					}
					break;
				case SUD:
					x2 = x2 + 1;
					break;
				case OUEST:
					if (ligney == 0) {
						y2 = nDamier.nbC - 1;
					}
					else {
						y2 = y2 - 1;
					}
					break;
				default:
					break;
			}


			Item tmp = nDamier.tab[lignex][ligney];
			nDamier.tab[lignex][ligney] = nDamier.tab[x2][y2];
			nDamier.tab[x2][y2] = tmp;
			
			nouvelEtat.damierF = nDamier;
			nouvelEtat.h = heuristique(nouvelEtat);

			if (appartient(nouvelEtat, t) == false) {
				inserer(t.LEAE, 0, nouvelEtat);
			}
		}
	}
}

void afficher(Taquin& t) {
	/*std::cout << "*** LEE - long : " << longueur(t.LEE) << endl;
	for (unsigned int i = 0; i < longueur(t.LEE); i++) {
		afficher(lire(t.LEE, i));
	}

	std::cout << endl;*/

	std::cout << "*** LEAE - long : " << longueur(t.LEAE) << endl;
	for (unsigned int i = 0; i < longueur(t.LEAE); i++) {
		afficher(lire(t.LEAE, i));
	}
}

bool appartient(Etat& ef, Taquin& t) {
	for (unsigned int i = 0; i < longueur(t.LEE); i++) {
		Etat e = lire(t.LEE, i);
		if (comparer(ef.damierF, e.damierF) == true) {
			return true;
		}
		
	}

	for (unsigned int i = 0; i < longueur(t.LEAE); i++) {
		Etat e = lire(t.LEAE, i);
		if (comparer(ef.damierF, e.damierF) == true) {
			return true;
		}
	}

	return false;
}

Etat algorithmeRecherche(Taquin & t)
{
	int index = 0;
	Etat e = lire(t.LEAE, 0);

	if (e.h == 0) {
		supprimer(t.LEAE, index);
		inserer(t.LEE, longueur(t.LEE), e);
		return e;
	}
	else {
		for (int y = 0; y < longueur(t.LEAE); y++) {
			Etat e2 = lire(t.LEAE, y);
			if (e2.h < e.h) {
				e = e2;
				index = y;
			}
			else if (e2.h == e.h) {
				if (e2.g < e.g) {
					e = e2;
					index = y;
				}
			}
		}
	}

	supprimer(t.LEAE, index);
	inserer(t.LEE, longueur(t.LEE), e);

	return e;
}



