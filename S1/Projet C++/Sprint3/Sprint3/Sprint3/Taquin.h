#ifndef _TAQUIN_
#define _TAQUIN_
/*
* @file Taquin.h
* @brief Projet SDA
* @author SOK Alexis - VIGNARAJAH Daran
* @version 2 19/12/18
*/
#include "Item.h"
#include "Tableau2D.h"
#include "Etat.h"
#include "Liste.h"

struct Taquin {
	Tab2D initial;
	int nbL;
	int nbC;
	Liste LEE;
	Liste LEAE;
};

/* @brief Cr�er ke jeu du taquin avec l'�tat initial
*  @param[out] t : Taquin
*/
void initialiser(Taquin& t);

/*
*@brief It�ration de l'algorithme de recherche
* @param[out] t : Taquin
*/
void jouer(Taquin& t);

/*
*@brief Recherche les diff�rents mouvements possibles
*@param [in] ligneX : ligne ou se trouve la case vide
*@param [in] ligneY : colonne ou se trouve la case vide
*@param [out] maxX : nombre de ligne du tableau
*@param [out] maxY : nombre de colonne du tableau
*@return mvmts : retourne les mouvements possibles
*/
Mouvement *mouvements_possible(int lignex, int ligney, int maxX, int maxY);

/*
*@brief Cr�e les taquins fils
*@param [in] tab_mouvement : diff�rent mouvements possibles
*@param [in] e : �tat actuel du taquin
*@param [in] lignex : ligne ou se trouve la case vide
*@param [in] ligney : colonne ou se trouve la case vide
*@param [out] t : taquin
*/
void creer_fils(Mouvement *tab_mouvement, Etat& e, int lignex, int ligney, Taquin& t);

/*
*@brief Affichage du taquin
*@param [in] t : taquin
*/
void afficher(const Taquin& t);

#endif // !_TAQUIN_

