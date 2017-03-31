package dataProject2;

import java.util.Comparator;
public class ArabaComparator implements Comparator<Araba>{

	@Override
	public int compare(Araba arg0, Araba arg1) {
		if(arg0.getBeklemeSuresi()>arg1.getBeklemeSuresi())
			return 1;
		if(arg0.getBeklemeSuresi()<arg1.getBeklemeSuresi())
			return -1;
		return 0;
	}
}