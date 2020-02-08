#include <iostream>
#include <string>
using namespace std;
/**
* @file Tableau2D.cpp
* @brief Projet SDA
* @author SOK Alexis - VIGNARAJAH Daran
* @version 2 19/12/18
*/

#include "Tableau2D.h"

void initialiser(Tab2D& m, unsigned int nbL, unsigned int nbC) {

	Item** tab = new Item*[nbL]; //Création du tableau dynamique principal
	for (unsigned int i = 0; i < nbL; i++){ //Tableau ligne
		tab[i] = new Item[nbC]; //Tableau colonne
	}

	m.nbL = nbL; //conserve nbL dans struct de Tab2D
	m.nbC = nbC; //conserve nbC dans struct de Tab2D
	m.tab = tab; //conserve le tableau crée dans Tab2D

}

void detruire(Tab2D& m) {
	delete[] m.tab;
	m.nbL = NULL;
	m.nbC = NULL;
	m.tab = NULL;
}

void lire(Tab2D& m) {
	char v[10]; // v comme valeur  

	for (unsigned int i = 0; i < m.nbL; i++){
		for (unsigned int j = 0; j < m.nbC; j++){
			cin >> v;

			if (v == "#"){
				cout << "#";
			}
			else{
				m.tab[i][j] = atoi(v);
			}
		}
	}
}

void afficher(const Tab2D& m) {

	for (unsigned int i = 0; i < m.nbL; i++) {
		cout << "  ";
		for (unsigned int j = 0; j < m.nbC; j++) {
			if (m.tab[i][j] == 0) {
				cout << "#" << "  ";
			}
			else {
				cout << m.tab[i][j] << "  ";
			}
		}
		cout << endl;
	}
}

bool comparer(Tab2D &ref, Tab2D &comp) {
	for (unsigned int x = 0; x < ref.nbL; x++) {
		for (unsigned int y = 0; y < ref.nbC; y++) {
			if (ref.tab[x][y] != comp.tab[x][y]) {
				return false;
			}
		}
	}

	return true;
}

/*
void localiser (Tab2D& t, unsigned int*x, unsigned int*y){
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
}
*/