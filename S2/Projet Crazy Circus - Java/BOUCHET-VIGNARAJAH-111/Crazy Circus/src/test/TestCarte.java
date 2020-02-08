package test;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.Test;

import composants.Carte;
import composants.Podium;
import entités.Animal;

class TestCarte {

	@Test
	void test() {
		Carte c1 = new Carte();
		Carte c2 = new Carte();
		assertFalse(c1.equals(c2));
		assertTrue(c1.isSameAs(c2));

		Podium tmp = new Podium();
		assertTrue(c1.getBleu().hasSameAnimals(tmp));
		assertTrue(c1.getRouge().hasSameAnimals(tmp));
		
		assertTrue(Carte.generateCartes().size() == 24);
		
		c2 = Carte.generateCartes().get(0);
		assertFalse(c2.isSameAs(c1));
		
		c2.getBleu().setNull();
		c2.getRouge().setNull();
		assertTrue(c1.isSameAs(c2));
		
		tmp.getAnimaux().set(0, Animal.LION);
		assertFalse(c1.getBleu().hasSameAnimals(tmp));
		assertFalse(c1.getRouge().hasSameAnimals(tmp));
		
		c1.setBleu(tmp);
		c1.setRouge(tmp);
		assertTrue(c1.getBleu().hasSameAnimals(tmp));
		assertTrue(c1.getRouge().hasSameAnimals(tmp));
		
	}

}
