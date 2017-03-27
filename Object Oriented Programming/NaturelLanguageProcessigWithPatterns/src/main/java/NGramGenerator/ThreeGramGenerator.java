package NGramGenerator;
import java.util.ArrayList;
import java.util.Arrays;

public class ThreeGramGenerator implements NGramGeneratorInterface {

	public ArrayList<String> Generate(ArrayList<String> strings) {
		 int nSize = 3;
		ArrayList<String> lst = new ArrayList<>();
		StringBuilder sb;
		for (String str : strings) {
			sb = new StringBuilder(str);
			//Adding underscore beginning and end of the word
			sb.insert(0, "_");
			sb.append("_");
			//all strings convert to lowercase
			lst.addAll(Arrays.asList(ngrams(sb.toString().toLowerCase(), nSize)));
		}
		return lst;
	}

	public static String[] ngrams(String str, int length) {
		char[] chars = str.toCharArray();
		if (chars.length < length + 1)
			return new String[]{str};
		final int resultCount = chars.length - length + 1;
		String[] result = new String[resultCount];
		for (int i = 0; i < resultCount; i++) {
			result[i] = new String(chars, i, length);
		}
		return result;
	}
}
