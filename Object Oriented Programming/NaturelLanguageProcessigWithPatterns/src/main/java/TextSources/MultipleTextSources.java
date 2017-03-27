package TextSources;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Iterator;

public class MultipleTextSources  implements MultipleTextSourceInterface{

	private SingleTextSourcesStrategyInterface singleTextSourcesStrategyInterface;
	
	public ArrayList<ArrayList<String>> getContent(File file) throws IOException{
		if (file != null && file.exists()) {
			/*
			 * We can define the strategy for the operation for the sources but lets
			 * assume that all the strings in the sources are wikipedia links. 
			 * If they are from different sources assigning of the
			 * singleTextSourcesStrategyInterface must be done in while loop
			 * according to the predefined strategy.
			 */
			singleTextSourcesStrategyInterface = new WikipediaAdapter();
			BufferedReader br = new BufferedReader(new FileReader(file)); 
			ArrayList<ArrayList<String>> lists = new ArrayList<>();
			String line = null;
			while ((line = br.readLine()) != null) {
				lists.add(singleTextSourcesStrategyInterface.getText(line));
			}
			br.close();
			return lists;
		}
		else
			throw new IOException();
	}
	@Override
	public ArrayList<ArrayList<String>> getContent(ArrayList<String> sources) throws IOException{
		/*
		 * We can define the strategy for the operation for the sources but lets
		 * assume that all the strings in the sources are wikipedia links. 
		 * If they are from different sources assigning of the
		 * singleTextSourcesStrategyInterface must be done in while loop
		 * according to the predefined strategy.
		 */
		singleTextSourcesStrategyInterface = new WikipediaAdapter();
		Iterator< String> iterator = sources.iterator();
		ArrayList<ArrayList<String>> lists = new ArrayList<>();
		while (iterator.hasNext()) {
			lists.add(singleTextSourcesStrategyInterface.getText(iterator.next()));
		}
		return lists;
	}
}
