package Test;
import static org.junit.Assert.*;

import java.util.ArrayList;

import org.junit.Test;

import NGramGenerator.ThreeGramGenerator;

public class NGramGeneratorTest {

	@Test
	public void test() {
		ThreeGramGenerator threeGramGenerator = new ThreeGramGenerator();
		ArrayList<String> arrayList = new ArrayList<>();
		arrayList.add("Tu�ba");
		ArrayList<String> actual = threeGramGenerator.Generate(arrayList);
		ArrayList<String> expected = new ArrayList<>();
		expected.add("_tu");
		expected.add("tu�");
		expected.add("u�b");
		expected.add("�ba");
		expected.add("ba_");
		assertEquals(expected, actual);
	}

}
