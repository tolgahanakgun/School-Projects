package LanguageIdentifier;

import java.util.ArrayList;

import NGramGenerator.NGramGeneratorInterface;
import NGramGenerator.ThreeGramGenerator;
import SimilarityCalculator.JaccardCalculator;
import SimilarityCalculator.StringSimilarityInterface;

public abstract class AbstractLanguages {

	public abstract double howSimilar(ArrayList<String> words);
	// Works with only classes implements StringSimilarityInterface
	// Inherited class must use the same similarity calculator
	// no need for new instances
	protected static StringSimilarityInterface stringSimilarityCalculator = new JaccardCalculator();
	// works with only classes implements NGramGeneratorInterface
	// Inherited class must use the same NGramGenerator
	// no need for new instances
	protected static NGramGeneratorInterface nGramGenerator = new ThreeGramGenerator();

}