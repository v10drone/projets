///**
//* @file Tableau2D.h
//* @brief Projet SDA
//* @author SOK Alexis - VIGNARAJAH Daran
//* @version 2 19/12/18
//*/
//
//#include <iostream>
//#include <iomanip>
//using namespace std;
//#include "Tableau2D.h"
//#include <cassert>
//
//void initialiser(Tab2D& m, unsigned int nbL, unsigned int nbC)
//{
//
//	Item **Tab  = new Item*[nbL]; // Création du tableau principal - Je peux le nommer comme je veux
//	for (int i = 0; i < nbL; i++) // Tableau ligne
//	{ 
//	Tab[i] = new Item[nbC];	// Tableau colonne
//	}
//
//	m.nbL = nbL; // Création ligne
//	m.nbC = nbC; // Création colonne
//
//	m.tab = Tab;  // Tab = Tab2D - voir ligne 16
//}
//
//void detruire(Tab2D& m)
//{
//	delete[] m.tab;
//	m.nbL = NULL;
//	m.nbC = NULL;
//	m.tab = NULL;
//}
//
//void lire(Tab2D& m)
//{
//	char v[10]; // v comme valeur  
//
//	for (int i = 0; i < m.nbL; i++)
//	{
//		for (int j = 0; j < m.nbC; j++)
//		{
//			cin >> v;
//			
//
//			if (v == "#")
//			{
//				cout << "#";
//			}
//
//			else
//			{
//				m.tab[i][j] = atoi(v);
//			}
//		}
//	}
//}
//
//
//void afficher(const Tab2D& m)
//{
//	
//	for (int i = 0; i < m.nbL; i++) 
//	{
//	cout << "  ";
//		for (int j = 0; j < m.nbC; j++)
//		{
//			if (m.tab[i][j] == 0)
//			{
//				cout << "#" << "  ";
//			}
//			else
//			{
//				cout << m.tab[i][j] << "  ";
//			}
//		}
//		cout << endl;
//	}
//}
//
