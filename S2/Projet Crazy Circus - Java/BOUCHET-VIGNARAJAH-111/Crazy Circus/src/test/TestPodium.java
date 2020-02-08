package test;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.Test;

import composants.Podium;
import entités.Animal;

class TestPodium {

	@Test
	void test() {
		Podium p1 = new Podium();
		for(Animal a : p1.getAnimaux()) {
			assertTrue(a.equals(Animal.NULL));
		}
		
		Podium p2 = new Podium();
		assertFalse(p1.equals(p2));
		assertTrue(p1.getAnimaux().equals(p2.getAnimaux()));
		assertTrue(p1.hasSameAnimals(p2));
		
		p1.getAnimaux().set(0, Animal.LION);
		assertTrue(p1.getAnimaux().get(0).equals(Animal.LION));
		assertTrue(p1.getTop() == 0);
		assertFalse(p1.getAnimaux().equals(p2.getAnimaux()));
		assertFalse(p1.hasSameAnimals(p2));

		p1.getAnimaux().set(1, Animal.ELEPHANT);
		assertTrue(p1.getTop() == 1);
		
		p1.setNull();
		assertTrue(p1.getAnimaux().equals(p2.getAnimaux()));
	}

}
