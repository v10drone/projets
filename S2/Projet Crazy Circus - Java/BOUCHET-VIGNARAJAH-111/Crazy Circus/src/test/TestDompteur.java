package test;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.Test;

import entités.Dompteur;

class TestDompteur {

	@Test
	void test() {
		Dompteur d1 = new Dompteur("test");
		assertTrue(d1.getNomDeScene().equals("test"));
		assertTrue(d1.getScore() == 0);
		assertTrue(d1.hasDroit());
		
		d1.setScore(42);
		assertTrue(d1.getScore() == 42);
		assertFalse(d1.getScore() == 0);
		
		d1.setDroit(false);
		assertTrue(!d1.hasDroit());
		assertFalse(d1.hasDroit());
		
		Dompteur d2 = new Dompteur("test");
		assertTrue(d1.getNomDeScene().equals(d2.getNomDeScene()));
		assertFalse(d1.equals(d2));
	}

}
