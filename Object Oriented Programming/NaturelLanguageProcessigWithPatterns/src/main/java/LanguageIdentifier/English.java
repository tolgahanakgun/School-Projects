package LanguageIdentifier;

import java.util.ArrayList;
import java.util.Arrays;

public class English extends AbstractLanguages {

	private static ArrayList<String> mostCommonEnglishWord = new ArrayList<String>(
			Arrays.asList(new String[]{"the", "be", "to", "of", "and", "a",
					"in", "that", "have", "I", "it", "for", "not", "on", "with",
					"he", "as", "you", "do", "at", "this", "but", "his", "by",
					"from", "they", "we", "say", "her", "she", "or", "an",
					"will", "my", "one", "all", "would", "there", "their",
					"what", "so", "up", "out", "if", "about", "who", "get",
					"which", "go", "me", "when", "make", "can", "like", "time",
					"no", "just", "him", "know", "take", "people", "into",
					"year", "your", "good", "some", "could", "them", "see",
					"other", "than", "then", "now", "look", "only", "come",
					"its", "over", "think", "also", "back", "after", "use",
					"two", "how", "our", "work", "first", "well", "way", "even",
					"new", "want", "because", "any", "these", "give", "day",}));
	private static ArrayList<String> mostCommonEnglishWord3Gram;

	public English() {
		mostCommonEnglishWord3Gram = nGramGenerator
				.Generate(mostCommonEnglishWord);
	}

	public double howSimilar(ArrayList<String> words) {
		if (words == null || words.size() == 0)
			throw new IllegalArgumentException(
					"The argument must be not null!");
		else
			return stringSimilarityCalculator.similarityRatio(words,
					mostCommonEnglishWord3Gram);
	}
}
