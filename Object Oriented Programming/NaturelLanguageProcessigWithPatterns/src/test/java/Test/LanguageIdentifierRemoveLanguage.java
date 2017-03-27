package Test;

import static org.junit.Assert.*;

import java.util.ArrayList;

import org.junit.Test;

import LanguageIdentifier.LanguageIdentifier;

public class LanguageIdentifierRemoveLanguage {

	@Test
	public void test() {
		LanguageIdentifier languageIdentifier = new LanguageIdentifier();
		ArrayList<String> expected = new ArrayList<>();
		expected.add("English");
		expected.add("German");
		languageIdentifier.removeLanguage("Turkish");
		ArrayList<String> result = languageIdentifier.listAllAvailableLanguage();
		assertEquals(expected,result);
	}

}
