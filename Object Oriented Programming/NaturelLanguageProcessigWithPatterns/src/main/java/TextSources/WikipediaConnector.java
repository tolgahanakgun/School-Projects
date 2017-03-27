package TextSources;

import java.io.IOException;

import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;

public class WikipediaConnector implements InternetSiteAdapterStrategyInterface{

	public String getContent(java.net.URL URL) throws IOException{
		Document doc = null;
		doc = Jsoup.connect(URL.toString()).get();
		Element contentDiv = doc.select("div[id=content]").first();
		return contentDiv.text();
	}
}
