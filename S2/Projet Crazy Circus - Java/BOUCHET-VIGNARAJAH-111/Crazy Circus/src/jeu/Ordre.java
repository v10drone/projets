package jeu;

import composants.Carte;
import entités.Animal;

/**
 * Classe Ordre qui permet d'exécuter et de valider des ordres
 * 
 * @author BOUCHET Ulysse & VIGNARAJAH Daran
 * @version 1.6 17/02/2019
 *
 */
public class Ordre {

	/**
	 * Simule l'ordre à effectuer
	 * 
	 * @param carte à partir de laquelle on veut simuler l'ordre
	 * @param ordre que l'on veut simuler
	 * @see Ordre#ki(Carte)
	 * @see Ordre#lo(Carte)
	 * @see Ordre#so(Carte)
	 * @see Ordre#ni(Carte)
	 * @see Ordre#ma(Carte)
	 */
	public static void simulerOrdre(Carte carte, String ordre) {

		for (int i = 0; i < ordre.length(); i = i + 2)
			switch (ordre.substring(i, i + 2)) {
			case "KI":
				Ordre.ki(carte);
				break;
			case "LO":
				Ordre.lo(carte);
				break;
			case "SO":
				Ordre.so(carte);
				break;
			case "NI":
				Ordre.ni(carte);
				break;
			case "MA":
				Ordre.ma(carte);
				break;
			default:
			}
	}

	/**
	 * Simule l'ordre ki
	 * 
	 * @param tmp la carte pour laquelle on simule l'ordre
	 */
	private static void ki(Carte tmp) {
		if (tmp.getBleu().getTop() >= 0) {
			tmp.getRouge().getAnimaux().set(tmp.getRouge().getTop() + 1,
					tmp.getBleu().getAnimaux().get(tmp.getBleu().getTop()));
			tmp.getBleu().getAnimaux().set(tmp.getBleu().getTop(), Animal.NULL);
		} else {
			tmp.getBleu().setNull();
			tmp.getRouge().setNull();
		}
	}

	/**
	 * Simule l'ordre lo
	 * 
	 * @param tmp la carte pour laquelle on simule l'ordre
	 */
	private static void lo(Carte tmp) {
		if (tmp.getRouge().getTop() >= 0) {
			tmp.getBleu().getAnimaux().set(tmp.getBleu().getTop() + 1,
					tmp.getRouge().getAnimaux().get(tmp.getRouge().getTop()));
			tmp.getRouge().getAnimaux().set(tmp.getRouge().getTop(), Animal.NULL);
		} else {
			tmp.getBleu().setNull();
			tmp.getRouge().setNull();
		}

	}

	/**
	 * Simule l'ordre so
	 * 
	 * @param tmp la carte pour laquelle on simule l'ordre
	 */
	private static void so(Carte tmp) {
		Animal tmpA;
		if (tmp.getRouge().getTop() >= 0 && tmp.getBleu().getTop() >= 0) {
			tmpA = tmp.getBleu().getAnimaux().get(tmp.getBleu().getTop());
			tmp.getBleu().getAnimaux().set(tmp.getBleu().getTop(),
					tmp.getRouge().getAnimaux().get(tmp.getRouge().getTop()));
			tmp.getRouge().getAnimaux().set(tmp.getRouge().getTop(), tmpA);
		} else {
			tmp.getBleu().setNull();
			tmp.getRouge().setNull();
		}

	}

	/**
	 * Simule l'ordre ni
	 * 
	 * @param tmp la carte pour laquelle on simule l'ordre
	 */
	private static void ni(Carte tmp) {
		Animal tmpA = Animal.NULL;
		tmpA = tmp.getBleu().getAnimaux().get(0);
		tmp.getBleu().getAnimaux().remove(0);
		tmp.getBleu().getAnimaux().add(Animal.NULL);
		tmp.getBleu().getAnimaux().set(tmp.getBleu().getTop() + 1, tmpA);
	}

	/**
	 * Simule l'ordre ma
	 * 
	 * @param tmp la carte pour laquelle on simule l'ordre
	 */
	private static void ma(Carte tmp) {
		Animal tmpA = Animal.NULL;
		tmpA = tmp.getRouge().getAnimaux().get(0);
		tmp.getRouge().getAnimaux().remove(0);
		tmp.getRouge().getAnimaux().add(Animal.NULL);
		tmp.getRouge().getAnimaux().set(tmp.getRouge().getTop() + 1, tmpA);
	}

	/**
	 * Vérifie si l'ordre est valide
	 * 
	 * @param ordre à vérifier
	 * @return une boolean true si l'ordre est valide, false sinon
	 */
	public static boolean ordreValide(String ordre) {
		if (ordre.length() % 2 != 0)
			return false;

		for (int i = 0; i < ordre.length(); i = i + 2)
			if (!ordre.substring(i, i + 2).equals("KI") && !ordre.substring(i, i + 2).equals("LO")
					&& !ordre.substring(i, i + 2).equals("SO") && !ordre.substring(i, i + 2).equals("NI")
					&& !ordre.substring(i, i + 2).equals("MA"))
				return false;

		return true;
	}
}
