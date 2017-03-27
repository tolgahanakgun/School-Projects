package Test;

import static org.junit.Assert.fail;

import java.io.IOException;
import java.net.MalformedURLException;

import org.junit.Test;
import TextSources.WikipediaAdapter;

public class WikipediaAdapterTest {

	@Test
	public void test() throws IOException {
		WikipediaAdapter wikipediaAdapter = new WikipediaAdapter();
		try {
			System.out.println(wikipediaAdapter.getText("https://tr.wikipedia.org/wiki/Ege_Bölgesi"));
		}catch(MalformedURLException e) {
			fail("The entered URL is not in the correct form !");
		}
		catch (org.jsoup.HttpStatusException e) {
			fail("Please check the URL you entered !");
		}
		catch (java.net.SocketTimeoutException e) {
			fail("Check your internet connection !");
		}
		catch (Exception e) {
			fail("Something went wrong !");
		}
	}
}
