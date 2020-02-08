#include <iostream>
using namespace std;
/**
* @file main.cpp
* @brief Projet SDA
* @author SOK Alexis - VIGNARAJAH Daran
* @version 2 19/12/18
*/
#include "Tableau2D.h"
#include "Etat.h"
#include "Taquin.h"

int main() {

	Taquin taquin;

	initialiser(taquin);
	jouer(taquin);

	detruire(taquin.LEAE);
	detruire(taquin.LEE);

	system("pause");

	return 0;
}