package Test;

import static org.junit.Assert.*;

import java.util.ArrayList;

import org.junit.Test;

import LanguageIdentifier.LanguageIdentifier;

public class LanguageIdentifierAddLanguageTest {

	@Test
	public void test() {
		LanguageIdentifier languageIdentifier = new LanguageIdentifier();
		languageIdentifier.removeLanguage("Turkish");
		ArrayList<String> expected = new ArrayList<>();
		ArrayList<String> actual = languageIdentifier.listAllAvailableLanguage();
		expected.add("English");
		expected.add("German");
		assertEquals(expected, actual);
		
	}

}
