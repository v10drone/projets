
package jeu;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;

import composants.Carte;
import composants.Podium;
import entités.Animal;
import entités.Dompteur;
import entités.Border;

/**
 * Classe contenant toutes les fonctions et attributs relatifs au jeu. La
 * plupart des fonctions de cette classe return des String, pour optimiser
 * l'affichage
 * 
 * @author BOUCHET Ulysse & VIGNARAJAH Daran
 * @version 2.1 27/02/2019
 */
public class Jeu {

	/**
	 * Liste représentant le paquet de cartes: il contient toutes les cartes
	 * possibles
	 * 
	 * @see Carte
	 * @see Carte#generateCartes()
	 */
	private ArrayList<Carte> paquet;

	/**
	 * Contient la liste des dompteurs
	 * 
	 * @see Dompteur
	 */
	private ArrayList<Dompteur> dompteurs;

	/**
	 * Carte contenant la position initiale des animaux à chaque tour
	 * 
	 * @see Carte
	 */
	private Carte carteInitiale;

	/**
	 * Carte contenant la position à atteindre par les animaux à chaque tour
	 * 
	 * @see Carte
	 */
	private Carte carteObjectif;

	/**
	 * Boolean déterminant la difficulté de la partie
	 */
	private boolean difficile;

	/**
	 * Constructeur de la classe Jeu
	 * 
	 * @see Jeu
	 * @see Jeu#initialiser()
	 */
	public Jeu() {
		dompteurs = new ArrayList<>();
		carteInitiale = new Carte();
		carteObjectif = new Carte();
		difficile = false;
		this.initialiser();
	}

	/**
	 * Initialise le jeu
	 * 
	 * @see Carte#generateCartes()
	 */
	private void initialiser() {
		paquet = Carte.generateCartes();
		this.carteInitiale = tirerCarteFromPaquet();

		do
			this.carteObjectif = tirerCarteFromPaquet();
		while (this.carteObjectif.equals(this.carteInitiale));
	}

	/**
	 * Génère un nouveau tour
	 * 
	 * @return une String pour afficher à l'écran ce que la méthode a fait
	 * @see Jeu#tirerCarteFromPaquet()
	 */
	private String generateRound() {
		for (Dompteur d : this.dompteurs)
			d.setDroit(true);

		this.carteInitiale = this.carteObjectif;
		this.carteObjectif = tirerCarteFromPaquet();

		return "Tirage d'une nouvelle carte objectif...";
	}

	/**
	 * Tire aléatoirement une carte du paquet
	 * 
	 * @return la carte tirée
	 * @see Carte
	 * @see Jeu#paquet
	 */
	private Carte tirerCarteFromPaquet() {
		int r = (int) (paquet.size() * Math.random());

		r = (int) (paquet.size() * Math.random());

		Carte tmp = paquet.get(r);
		return tmp;
	}

	/**
	 * Permet l'affichage à la console de la situation de jeu
	 * 
	 * @return une String contenant tout l'affichage du jeu
	 */
	public String displayJeu() {
		StringBuilder sJeu = new StringBuilder();

		String separator = "  ----  ";
		String arrow = "==>";
		String sBleu = "BLEU";
		String sRouge = "ROUGE";
		String nom = new String();

		for (int i = 2; i >= 0; --i) {
			nom = (this.carteInitiale.getBleu().getAnimaux().get(i) == Animal.ELEPHANT)
					? this.carteInitiale.getBleu().getAnimaux().get(i).getNom()
					: ("  " + this.carteInitiale.getBleu().getAnimaux().get(i).getNom() + "  ");
			sJeu.append(nom);
			sJeu.append(" ");
			nom = (this.carteInitiale.getRouge().getAnimaux().get(i) == Animal.ELEPHANT)
					? this.carteInitiale.getRouge().getAnimaux().get(i).getNom()
					: ("  " + this.carteInitiale.getRouge().getAnimaux().get(i).getNom() + "  ");
			sJeu.append(nom);
			sJeu.append("     ");
			nom = (this.carteObjectif.getBleu().getAnimaux().get(i) == Animal.ELEPHANT)
					? this.carteObjectif.getBleu().getAnimaux().get(i).getNom()
					: ("  " + this.carteObjectif.getBleu().getAnimaux().get(i).getNom() + "  ");
			sJeu.append(nom);
			sJeu.append(" ");
			nom = (this.carteObjectif.getRouge().getAnimaux().get(i) == Animal.ELEPHANT)
					? this.carteObjectif.getRouge().getAnimaux().get(i).getNom()
					: ("  " + this.carteObjectif.getRouge().getAnimaux().get(i).getNom() + "  ");
			sJeu.append(nom);

			sJeu.append(System.lineSeparator());
		}
		sJeu.append(separator);
		sJeu.append(" ");
		sJeu.append(separator);
		sJeu.append(" ");
		sJeu.append(arrow);
		sJeu.append(" ");
		sJeu.append(separator);
		sJeu.append(" ");
		sJeu.append(separator);

		sJeu.append(System.lineSeparator());

		sJeu.append("  ");
		sJeu.append(sBleu);
		sJeu.append("     ");
		sJeu.append(sRouge);
		sJeu.append("        ");
		sJeu.append(sBleu);
		sJeu.append("     ");
		sJeu.append(sRouge);

		sJeu.append(System.lineSeparator());
		sJeu.append(System.lineSeparator());

		for (int i = 0; i < 39; ++i)
			sJeu.append("-");
		sJeu.append(System.lineSeparator());

		sJeu.append("KI : BLEU --> ROUGE    NI : BLEU  ˆ");
		sJeu.append(System.lineSeparator());
		sJeu.append("LO : BLEU <-- ROUGE    MA : ROUGE ˆ");
		sJeu.append(System.lineSeparator());
		sJeu.append("SO : BLEU <-> ROUGE");

		return sJeu.toString();
	}

	/**
	 * Gère un tour de jeu à partir d'un ordre et d'un dompteur
	 * 
	 * @param nomDeScene de la personne ayant donné un ordre
	 * @param ordre      à effectuer
	 * @return une String décrivant ce qu'il s'est passé durant le tour
	 * @see Jeu#dompteurExists(String)
	 * @see Jeu#getDompteurFromJeu(String)
	 * @see Ordre#ordreValide(String)
	 * @see Ordre#simulerOrdre(Jeu, String)
	 * @see Jeu#check(Carte)
	 * @see Jeu#nbDompteursAllowed()
	 * @see Jeu#pointForOnlyDompteur()
	 * @see Jeu#continueJeu()
	 * @see Jeu#generateRound()
	 */
	public String play(String nomDeScene, String ordre) {
		StringBuilder s = new StringBuilder();


		if (this.dompteurExists(nomDeScene)) {
			Dompteur tmp = this.getDompteurFromJeu(nomDeScene);
			if (tmp.hasDroit()) {
				if (Ordre.ordreValide(ordre)) {
					if (this.difficile && ordre.contains("SO"))
						s.append("La commande <SO> est interdite en mode difficile!");
					else {
						Carte simul = copyInitiale();
						Ordre.simulerOrdre(simul, ordre);

						if (simul.isSameAs(this.carteObjectif)) {
							tmp.setScore(tmp.getScore() + 1);

							s.append(tmp.getNomDeScene());
							s.append(" a trouvé une solution!");
							s.append(System.lineSeparator());

						} else {
							s.append("L'ordre que vous avez donné est faux! ");
							s.append(System.lineSeparator());
							s.append(Border.border);

							if (this.dompteurs.size() != 1) {
								s.append(tmp.getNomDeScene());
								s.append(" perd le droit de donner des ordres durant ce tour!");
								s.append(System.lineSeparator());
								tmp.setDroit(false);

								// S'il n'y a plus qu'un dompteur pouvant agir, il gagne
								// (sauf mode 1 joueur)
								if (this.nbDompteursAllowed() == 1) {
									s.append(this.pointForOnlyDompteur());
									s.append(System.lineSeparator());
								}
							}

						}

						if (this.continueJeu()) {
							s.append(Border.border);
							s.append(this.generateRound());
							this.paquet.remove(this.carteObjectif);
						}
					}
				} else
					s.append("Ordre non reconnu.");

			} else
				s.append("Ce dompteur n'a plus le droit de donner d'ordres pendant ce tour.");

		} else
			s.append("Nom de scène non reconnu.");

		return s.toString();
	}

	/**
	 * Vérifie s'il reste des cartes dans le paquet
	 * 
	 * @return un boolean true si c'est le cas, false sinon
	 * @see Jeu#paquet
	 */
	public boolean continueJeu() {
		if (paquet.size() == 0)
			return false;
		else
			return true;
	}

	/**
	 * donne un point au seul dompteur ayant encore le droit de jouer
	 * 
	 * @return une String décrivant ce qu'a fait la méthode
	 * @see Jeu#nbDompteursAllowed()
	 */
	private String pointForOnlyDompteur() {
		StringBuilder s = new StringBuilder();

		Dompteur tmp;
		for (Dompteur d : this.dompteurs)
			if (d.hasDroit()) {
				s.append("Tous les autres joueurs s'étant trompés, ");
				s.append(d.getNomDeScene());
				s.append(" gagne ce tour!");

				tmp = d;
				tmp.setScore(tmp.getScore() + 1);
			}

		return s.toString();
	}

	/**
	 * Permet l'affichage du classement des Dompteurs
	 * 
	 * @return une String contenant l'affichage
	 * @see Jeu#orderDompteurs()
	 */
	public String displayLeaderboard() {
		StringBuilder sLeaderboard = new StringBuilder();
		if (this.dompteurs.size() != 1) {
			int nb = 1;
			orderDompteurs();
			for (Dompteur d : this.dompteurs) {
				sLeaderboard.append(nb);
				sLeaderboard.append(": ");
				sLeaderboard.append(d.getNomDeScene());
				sLeaderboard.append(" ");
				sLeaderboard.append(d.getScore());
				sLeaderboard.append(" points.");
				sLeaderboard.append(System.lineSeparator());
				nb++;
			}

			sLeaderboard.append(Border.border);
			sLeaderboard.append(System.lineSeparator());

			sLeaderboard.append("Félicitations à ");
			sLeaderboard.append(this.dompteurs.get(0).getNomDeScene());
			sLeaderboard.append(" qui a gagné cette partie!");
		} else
			sLeaderboard.append("Fin de l'entraînement !");

		return sLeaderboard.toString();
	}

	/**
	 * Permet le tri des dompteurs en fonction de leur score puis de leur nom de
	 * scène
	 * 
	 * @see Collections#sort(java.util.List, Comparator)
	 * @see Jeu#comparePseudos(Dompteur, Dompteur)
	 * @see Jeu#compareScores(Dompteur, Dompteur)
	 */
	private void orderDompteurs() {
		Collections.sort(this.dompteurs, new Comparator<Dompteur>() {
			@Override
			public int compare(Dompteur d1, Dompteur d2) {
				if (compareScores(d1, d2) != 0)
					return compareScores(d1, d2);
				else
					return comparePseudos(d1, d2);
			}
		});

	}

	/**
	 * Compare le score de deux dompteurs
	 * 
	 * @param d1 le premier dompteur
	 * @param d2 le second dompteur
	 * @return 1 si le second a un meilleur score, 0 s'ils ont le même score, -1 si
	 *         le premier a un meilleur score
	 */
	private static int compareScores(Dompteur d1, Dompteur d2) {
		if (d1.getScore() < d2.getScore())
			return 1;
		else if (d1.getScore() == d2.getScore())
			return 0;
		else
			return -1;
	}

	/**
	 * Compare les noms de deux dompteurs
	 * 
	 * @param d1 le premier dompteur
	 * @param d2 le second dompteur
	 * @return 1 si le second se trouve avant alphanumériquement parlant, 0 s'ils
	 *         ont le même nom, -1 si le premier se trouve avant alphanumériquement
	 *         parlant
	 */
	private static int comparePseudos(Dompteur d1, Dompteur d2) {
		for (char c1 : d1.getNomDeScene().toCharArray())
			for (char c2 : d2.getNomDeScene().toCharArray())
				if (c1 > c2)
					return 1;
				else if (c1 < c2)
					return -1;

		return 0;
	}

	/**
	 * Permet de copier la carte initiale pour ensuite simuler une commande
	 * 
	 * @return la copie de la carte initiale
	 * @see Carte
	 * @see Jeu#check
	 * @see Jeu#carteInitiale
	 */
	public Carte copyInitiale() {
		Carte copy = new Carte();
		Podium copyBleu = new Podium();
		Podium copyRouge = new Podium();
		for (int i = 0; i < 3; ++i) {
			copyBleu.getAnimaux().set(i, this.carteInitiale.getBleu().getAnimaux().get(i));
			copyRouge.getAnimaux().set(i, this.carteInitiale.getRouge().getAnimaux().get(i));
		}

		copy.setBleu(copyBleu);
		copy.setRouge(copyRouge);

		return copy;
	}

	/**
	 * Permet d'obtenir le nombre de dompteurs ayant le droit de donner un ordre
	 * 
	 * @return 0 s'il y a un seul joueur (mode entraînement), le nombre de dompteurs
	 *         ayant le droit de donner un ordre sinon
	 */
	public int nbDompteursAllowed() {
		int nb = 0;
		if (this.dompteurs.size() != 1)
			for (Dompteur d : this.dompteurs)
				if (d.hasDroit())
					nb++;

		return nb;
	}

	// Getters & Setters

	/**
	 * Permet d'ajouter un dompteur au jeu
	 * 
	 * @param nomDeScene le nom du dompteur
	 * @return une String décrivant ce qu'a fait la méthode
	 * @see Jeu#dompteurs
	 * @see Jeu#dompteurExists(String)
	 */
	public String addDompteur(String nomDeScene) {
		if (!(dompteurExists(nomDeScene))) {
			dompteurs.add(new Dompteur(nomDeScene));
			return "Dompteur <" + nomDeScene + "> ajouté.";
		} else
			return "Le dompteur <" + nomDeScene + "> existe déjà.";
	}

	/**
	 * Permet de changer la difficulté du jeu
	 * 
	 * @param difficile boolean déterminant la difficulté du jeu
	 * @see Jeu#difficile
	 */
	public void setDifficile(boolean difficile) {
		this.difficile = difficile;
	}

	/**
	 * Permet d'obtenir un dompteur participant au jeu à partir de son nom de scène
	 * 
	 * @param nomDeScene
	 * @return le dompteur s'il participe au jeu, un dompteur "erreur" sinon
	 * @see Jeu#dompteurs
	 * @see Dompteur
	 */
	public Dompteur getDompteurFromJeu(String nomDeScene) {
		if (dompteurExists(nomDeScene)) {
			for (Dompteur d : this.dompteurs)
				if (d.getNomDeScene().equals(nomDeScene))
					return d;
		}

		return new Dompteur("error");

	}

	/**
	 * Permet de vérifier si un dompteur participe au jeu à partir de son nom de
	 * scène
	 * 
	 * @param nomDeScene
	 * @return true s'il existe, false sinon
	 * @see Jeu#dompteurs
	 * @see Dompteur
	 */
	public boolean dompteurExists(String nomDeScene) {
		for (Dompteur d : this.dompteurs)
			if (d.getNomDeScene().equals(nomDeScene))
				return true;

		return false;
	}
}
