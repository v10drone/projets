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
}