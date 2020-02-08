#ifndef _ETAT_
#define _ETAT_
/**
 * @file Etat.h
 * @brief Projet SDA
 * @author Daran VIGNARAJAH Alexis SOK
 * @version 2 29/12/2018
 */

#include "Tableau2D.h"

enum Mouvement { NORD, OUEST, EST, SUD, FIXE };

struct Etat {
	Tab2D damierF; //damier
	Mouvement mouvements; //mouvement
	Etat *parent; //état parent

	unsigned int g; //nombre de coups
	unsigned int h; //heuristique de e à l'état but
};

/*
* @brief Affichage d'un état du taquin
* @param[in] p : l'état à afficher
*/
void afficher(const Etat& e);

/*
*@brief Renvoie vrai s’il s’agir de l’état final, faux sinon
*@param [in] e : Etat
*/
bool but(Etat& e);

unsigned int heuristique(Etat &e);

#endif // !_ETAT_

