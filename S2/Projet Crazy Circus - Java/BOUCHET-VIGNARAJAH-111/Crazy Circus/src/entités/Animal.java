package entités;

/**
 * Enumère les différents animaux existant
 * @author BOUCHET Ulysse & VIGNARAJAH Daran
 * @version 2.2 18/02/2019
 */
public enum Animal {
	OURS("OURS"), LION("LION"), ELEPHANT("ELEPHANT"), NULL("    ");
	
	/**
	 * Nom de l'animal
	 */
	private String nom;

	/**
	 * Constructeur d'Animal
	 * @param nom
	 */
	Animal(String nom) {
		this.nom = nom;
	}

	/**
	 * Getter du nom de l'Animal
	 * @return le nom de l'animal
	 * @see Animal#nom
	 */
	public String getNom() {
		return nom;
	}
}
