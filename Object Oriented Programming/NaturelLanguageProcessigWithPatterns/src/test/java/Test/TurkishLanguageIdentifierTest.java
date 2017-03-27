package Test;

import static org.junit.Assert.*;

import java.io.IOException;
import java.net.URISyntaxException;
import java.net.URL;
import java.nio.file.Paths;

import org.junit.Test;

import LanguageIdentifier.LanguageIdentifier;
import TextSources.TextFileReader;

public class TurkishLanguageIdentifierTest {

	@Test
	public void test() {

		LanguageIdentifier idenfier = new LanguageIdentifier();
		TextFileReader reader = new TextFileReader();
		try {
			URL resource = TurkishLanguageIdentifierTest.class.getResource("/turkishExampleText.txt");
			String string = Paths.get(resource.toURI()).toFile().getAbsolutePath();
			String actual = idenfier.whichLanguage(reader.getText(string));
			String expected = "Turkish";
			assertEquals(expected, actual);
		} catch (URISyntaxException | IOException e) {
			fail(e.getMessage());
		}
	}

}

