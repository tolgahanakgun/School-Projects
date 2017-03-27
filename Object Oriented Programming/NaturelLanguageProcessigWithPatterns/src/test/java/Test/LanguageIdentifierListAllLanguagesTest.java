package Test;

import static org.junit.Assert.*;

import java.util.ArrayList;

import org.junit.Test;

import LanguageIdentifier.LanguageIdentifier;

public class LanguageIdentifierListAllLanguagesTest {

	@Test
	public void test() {
		LanguageIdentifier languageIdentifier = new LanguageIdentifier();
		ArrayList<String> expected = new ArrayList<>();
		expected.add("Turkish");
		expected.add("English");
		expected.add("German");
		ArrayList<String> actual = languageIdentifier.listAllAvailableLanguage();
		assertEquals(expected,actual);
	}
}
