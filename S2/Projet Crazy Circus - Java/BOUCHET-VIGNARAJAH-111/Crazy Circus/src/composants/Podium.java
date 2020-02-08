package composants;

import java.util.ArrayList;

import entités.Animal;

/**
 * Classe définissant un podium
 * 
 * @author BOUCHET Ulysse & VIGNARAJAH Daran
 * @version 1.7 21/02/2019
 *
 */
public class Podium {
	
	/**
	 * Liste des animaux qui composent un podium
	 * @see Animal
	 */
	private ArrayList<Animal> animaux = new ArrayList<>();
	
	/**
	 * Constructeur du Podium.
	 * @see Podium#setNull()
	 */
	public Podium() {
		this.setNull();
	}

	/**
	 * Permet de déterminer si ce podium est égal au podium p
	 * @param p l'autre podium
	 * @return true s'ils sont égaux, false sinon
	 */
	public boolean hasSameAnimals(Podium p) {
		for (int i = 0; i < 3; ++i)
			if (!(this.animaux.get(i).equals(p.animaux.get(i))))
				return false;

		return true;
	}
	
	//Getters & Setters

	/**
	 * Remplit d'animaux NULL le podium
	 * @see Podium#animaux
	 */
	public void setNull() {
		animaux.clear();
		for (int i = 0; i < 3; ++i)
			this.animaux.add(Animal.NULL);
	}

	/**
	 * Permet d'obtenir l'indice de l'Animal situé en haut du Podium
	 * @return l'indice de l'Animal situé en haut du Podium
	 */
	public int getTop() {
		for (int i = 0; i < this.animaux.size(); ++i)
			if (this.animaux.get(i).equals(Animal.NULL))
				return (i - 1);

		return 2;
	}
	
	/**
	 * Permet d'obtenir la liste des animaux du Podium
	 * @return la liste des animaux du Podium
	 */
	public ArrayList<Animal> getAnimaux() {
		return animaux;
	}
}
