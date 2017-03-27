package SimilarityCalculator;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.Set;

public class JaccardCalculator implements StringSimilarityInterface {

	public double similarityRatio(ArrayList<String> set1,ArrayList<String> set2) {

		double similarity = 0.0d;

		// checks for two array whether compatible or not
		if ((set1 != null && set2 != null)
				&& (set1.size() > 0 || set2.size() > 0)) {
			similarity = intersectionUnionRatio(set1, set2);
		} else {
			throw new IllegalArgumentException(
					"The arguments x and y must be not NULL and either x or y must be non-empty.");
		}
		return similarity;
	}

	private double intersectionUnionRatio(ArrayList<String> lst1,ArrayList<String> lst2) {

		// return 0 if any of the lists is empty
		if (lst1.size() == 0 || lst2.size() == 0)
			return 0.0;

		// union for two string list
		Set<String> unionXY = new HashSet<String>(lst1);
		unionXY.addAll(lst2);

		// intersection for two string list
		Set<String> intersectionXY = new HashSet<String>(lst1);
		intersectionXY.retainAll(lst2);

		return (double) intersectionXY.size() / (double) unionXY.size();
	}
}
