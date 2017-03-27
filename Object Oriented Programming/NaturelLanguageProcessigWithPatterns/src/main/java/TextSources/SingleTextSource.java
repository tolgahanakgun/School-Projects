package TextSources;

import java.io.File;
import java.io.IOException;
import java.net.URL;
import java.util.ArrayList;

public class SingleTextSource implements SingleTextSourceInterface{

	private SingleTextSourcesStrategyInterface singleTextSourcesStrategyInterface;

	@SuppressWarnings("unused")
	public ArrayList<String> getText(String source) {

		try {
			URL url;
			if ((url = new URL(source)) != null) {
				//here we assume that the source is a Wikipedia URL
				singleTextSourcesStrategyInterface = new WikipediaAdapter();
				return singleTextSourcesStrategyInterface.getText(source);
			} else {
				File file;
				if ((file = new File(source)) != null && file.exists()) {
					singleTextSourcesStrategyInterface = new TextFileReader();
					return singleTextSourcesStrategyInterface.getText(source);
				} else
					return null;
			}
		} catch (IOException e) {
			e.printStackTrace();
		}
		return null;
	}

}
