package entités;

/**
 * Définit un dompteur.
 * 
 * @author BOUCHET Ulysse & VIGNARAJAH Daran
 * @version 1.3 27/02/2019
 *
 */
public class Dompteur {

	/**
	 * Le nom de scène du dompteur.
	 */
	private String nomDeScene;

	/**
	 * Le score du dompteur.
	 */
	private int score;

	/**
	 * Définit si le dompteur a le droit ou non de jouer pendant ce tour.
	 */
	private boolean droit;

	/**
	 * Construit un dompteur
	 * @param nomDeScene que l'on veut donner au dompteur
	 */
	public Dompteur(String nomDeScene) {
		this.nomDeScene = nomDeScene;
		setScore(0);
		setDroit(true);
	}

	// Getters & Setters

	/**
	 * Getter du nom de scène du dompteur
	 * @return le nom de scène du dompteur
	 * @see Dompteur#nomDeScene
	 */
	public String getNomDeScene() {
		return nomDeScene;
	}

	/**
	 * Getter du score du dompteur
	 * @return le score du dompteur
	 * @see Dompteur#score
	 */
	public int getScore() {
		return score;
	}

	/**
	 * Setter du score du dompteur
	 * @param score que l'on veut donner au dompteur
	 * @see Dompteur#score
	 */
	public void setScore(int score) {
		this.score = score;
	}

	/**
	 * Getter du droit du dompteur
	 * @return le droit du dompteur
	 * @see Dompteur#droit
	 */
	public boolean hasDroit() {
		return droit;
	}

	/**
	 * Setter du droit du dompteur
	 * @param droit que l'on veut accorder au dompteur
	 * @see Dompteur#droit
	 */
	public void setDroit(boolean droit) {
		this.droit = droit;
	}
}
