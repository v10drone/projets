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
	for (unsigned int i = 0; i < nbL; i++) { //Tableau ligne
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

	for (int i = 0; i < m.nbL; i++) {
		for (int j = 0; j < m.nbC; j++) {
			cin >> v;

			if (v == "#") {
				cout << "#";
			}
			else {
				m.tab[i][j] = atoi(v);
			}
		}
	}
}

void afficher(const Tab2D& m) {

	for (int i = 0; i < m.nbL; i++) {
		cout << "  ";
		for (int j = 0; j < m.nbC; j++) {
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