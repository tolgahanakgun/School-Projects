package LanguageIdentifier;

import java.util.ArrayList;
import java.util.Arrays;

public class German extends AbstractLanguages {

	private static ArrayList<String> mostCommonGermanWord = new ArrayList<String>(
			Arrays.asList(new String[]{"der", "die", "das", "und", "sein", "in",
					"ein", "zu", "haben", "ich", "werden", "sie", "von",
					"nicht", "mit", "es", "sich", "auch", "auf", "für", "an",
					"er", "so", "dass", "können", "dies", "als", "ihr", "ja",
					"wie", "bei", "oder", "wir", "aber", "dann", "man", "da",
					"noch", "nach", "was", "also", "aus", "all", "wenn", "nur",
					"müssen", "sagen", "um", "über", "machen", "kein", "jahr",
					"du", "mein", "schon", "vor", "durch", "geben", "mehr",
					"andere", "viel", "kommen", "jetzt", "sollen", "ganz",
					"mich", "immer", "gehen", "sehr", "hier", "doch", "bis",
					"wieder", "mal", "zwei", "gut", "wissen", "neu", "sehen",
					"lassen", "uns", "weil", "unter", "denn", "stehen", "jede",
					"beispiel", "zeit", "erste", "ihm", "wo", "lang",
					"eigentlich", "damit", "selbst", "unser", "oben", "selber",
					"dag", "geven"}));
	private static ArrayList<String> mostCommonGermanWord3Gram;

	public German() {
		mostCommonGermanWord3Gram = nGramGenerator
				.Generate(mostCommonGermanWord);
	}

	public double howSimilar(ArrayList<String> words) {
		if (words == null || words.size() == 0)
			throw new IllegalArgumentException(
					"The argument must be not null!");
		else
			return stringSimilarityCalculator.similarityRatio(words,
					mostCommonGermanWord3Gram);
	}

}
