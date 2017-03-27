package Test;

import static org.junit.Assert.*;

import java.io.IOException;
import java.net.URISyntaxException;
import java.net.URL;
import java.nio.file.Paths;
import org.junit.Test;

import LanguageIdentifier.LanguageIdentifier;
import TextSources.TextFileReader;

public class EnglishLanguageIdentifierTest {

	@Test
	public void test() {

		LanguageIdentifier idenfier = new LanguageIdentifier();
		TextFileReader reader = new TextFileReader();
		try {
			URL resource = EnglishLanguageIdentifierTest.class.getResource("/englishExampleText.txt");
			String string = Paths.get(resource.toURI()).toFile().getAbsolutePath();
			String actual = idenfier.whichLanguage(reader.getText(string));
			String expected = "English";
			assertEquals(expected, actual);
		} catch (URISyntaxException | IOException e) {
			fail(e.getMessage());
		}
	}

}
