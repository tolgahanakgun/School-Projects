package Test;
import static org.junit.Assert.*;

import java.util.ArrayList;

import org.junit.Test;

import SimilarityCalculator.JaccardCalculator;

public class JaccardSimilarityTest {

	@Test
	public void test() {
		
		ArrayList<String> arrayList = new ArrayList<>();
		arrayList.add("Tuðba");
		arrayList.add("süt");
		arrayList.add("iç");
		
		ArrayList<String> arrayList2 = new ArrayList<>();
		arrayList2.add("Tuðba");
		arrayList2.add("su");
		arrayList2.add("iç");
		
		JaccardCalculator jcCalculator = new JaccardCalculator();
		double expected = 0.5;
		double actual = jcCalculator.similarityRatio(arrayList,arrayList2);
		
		assertEquals(expected, actual, 0.001);
	}

}
