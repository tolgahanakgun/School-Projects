package TextSources;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;

public class TextFileReader implements SingleTextSourcesStrategyInterface {

	public ArrayList<String> getText(String source) throws IOException {
		File f = new File(source);
		try {
			if (f.exists() && !f.isDirectory()) {
				BufferedReader br = new BufferedReader(new FileReader(f));
				ArrayList<String> lists = new ArrayList<>();
				String line = null;
				String delimiters = " |\\.|\\,|\\'|\\-|\\*|\\/|\\?|\\!"
						+ "|\\+|\\%|\\(|\\)|\\{|\\[|\\}|\\]|\\\\|\\||\\<|\\>"
						+ "0123456789";
				while ((line = br.readLine()) != null) {
					lists.addAll(Arrays.asList(line.split(delimiters)));
				}
				br.close();
				return lists;
			} 
		} catch (Exception e) {
			throw new IOException();
		}
		return null;

	}

}
