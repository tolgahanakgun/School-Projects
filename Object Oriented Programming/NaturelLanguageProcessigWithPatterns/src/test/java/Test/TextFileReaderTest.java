package Test;

import static org.junit.Assert.*;

import java.io.IOException;
import java.net.URISyntaxException;
import java.net.URL;
import java.nio.file.Paths;
import java.util.ArrayList;

import org.junit.Test;

import TextSources.TextFileReader;

public class TextFileReaderTest {

	@Test
	public void test() throws IOException {
		
		try {
			TextFileReader reader = new TextFileReader();
			URL resource = TextFileReaderTest.class.getResource("/exampleText.txt");
			String string = Paths.get(resource.toURI()).toFile().getAbsolutePath();
			ArrayList<String> actual = reader.getText(string);
			ArrayList<String> expected = new ArrayList<>();
			expected.add("Tuðba");
			expected.add("java");
			expected.add("kodla");
			assertEquals(expected,actual);
		} catch (URISyntaxException e) {
			fail(e.getMessage());
		}

	}

}
