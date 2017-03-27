package TextSources;

import java.io.IOException;
import java.net.URL;
import java.util.ArrayList;
import java.util.Arrays;

public class WikipediaAdapter implements SingleTextSourcesStrategyInterface, InternetSiteAdapterStrategyInterface{
	
	public ArrayList<String> getText(String source) throws IOException {

		// using java.net class in order to prevent malformedurl's
		// if string is not an URL MalformedURLException throwned
		// class accepts url including utf-8 characters
		java.net.URL url = new URL(source);
		
		//elimate the non alpha characters
		String delimiters = " |\\.|\\,|\\'|\\-|\\*|\\/|\\?|\\!"
				+ "|\\+|\\%|\\(|\\)|\\{|\\[|\\}|\\]|\\\\|\\||\\<|\\>"
				+ "0123456789";
		
		String[] str = getContent(url).split(delimiters);
		return new ArrayList<String>(Arrays.asList(str));
	}

	public String getContent(URL url) throws IOException {
		WikipediaConnector wikipediaConnector = new WikipediaConnector();
		return wikipediaConnector.getContent(url);
	}
}
