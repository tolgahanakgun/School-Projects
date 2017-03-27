package LanguageIdentifier;

import java.util.ArrayList;
import java.util.Arrays;

public class Turkish extends AbstractLanguages {

	private static ArrayList<String> mostCommonTurkishWord = new ArrayList<String>(
			Arrays.asList(new String[]{"bir", "bu", "ve", "ne", "mi", "için",
					"çok", "ben", "o", "evet", "de", "var", "ama", "mı",
					"değil", "hayır", "sen", "şey", "da", "daha", "bana",
					"kadar", "seni", "beni", "iyi", "onu", "tamam", "bunu",
					"gibi", "yok", "benim", "her", "sana", "ki", "sadece",
					"neden", "senin", "burada", "zaman", "hiç", "şimdi",
					"nasıl", "us", "sonra", "olduğunu", "en", "mu", "hadi",
					"misin", "şu", "öyle", "ya", "güzel", "biraz", "musun",
					"önce", "lütfen", "ıyi", "bak", "ona", "böyle", "oldu",
					"hey", "istiyorum", "onun", "geri", "bile", "eğer", "artık",
					"gerçekten", "kim", "bay", "yani", "çünkü", "büyük",
					"doğru", "peki", "buraya", "biliyorum", "başka", "belki",
					"olarak", "tanrım", "tek", "efendim", "biri", "olur",
					"olacak", "adam", "haydi", "olan", "ışte", "et", "sanırım",
					"merhaba", "biz", "orada", "demek", "teşekkürler", "hiçbir",
					"nerede", "most"}));
	private static ArrayList<String> mostCommonTurkishWord3Gram;

	public Turkish() {
		mostCommonTurkishWord3Gram = nGramGenerator
				.Generate(mostCommonTurkishWord);
	}

	public double howSimilar(ArrayList<String> words) {
		if (words == null || words.size() == 0)
			throw new IllegalArgumentException(
					"The argument must be not null!");
		else
			return stringSimilarityCalculator.similarityRatio(words,
					mostCommonTurkishWord3Gram);
	}
}
