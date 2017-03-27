package LanguageIdentifier;

import java.util.ArrayList;

import NGramGenerator.ThreeGramGenerator;

public class LanguageIdentifier {

	private ArrayList<AbstractLanguages> langs;
	private LanguageFactory languageFactory = new LanguageFactory(langs);

	public LanguageIdentifier() {
		// creating a language arraylist from all available languages
		langs = languageFactory.allLanguages();
	}

	public String whichLanguage(ArrayList<String> words) {
		if (words == null || words.size() == 0)
			throw new IllegalArgumentException("The arguments must not be null!");
		else {
			double max = 0, temp;
			String string = null;
			ThreeGramGenerator threeGramGenerator = new ThreeGramGenerator();
			ArrayList<String> lStrings = threeGramGenerator.Generate(words);
			for (AbstractLanguages abstractLanguages : langs) {
				temp = abstractLanguages.howSimilar(lStrings);
				if (temp > max) {
					max = temp;
					string = abstractLanguages.getClass().getSimpleName();
				}
			}
			return string;
		}
	}

	public ArrayList<String> listAllAvailableLanguage() {
		return languageFactory.listAllAvailableLanguage();
	}

	public boolean addLanguage(String languageName) {
		return languageFactory.addLanguage(languageName);
	}

	public boolean removeLanguage(String language) {
		return languageFactory.removeLanguage(language);
	}
}