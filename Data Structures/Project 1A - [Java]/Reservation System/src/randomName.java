package dataProjectPart_II;
import java.util.Arrays;
import java.util.Collections;

public class randomName {
	
	String[] isimler = new String[] {"Mehmet", "Yunus","Aybars","Nagihan", 
			"Merve", "Gülcan", "Cemal", "Serkan", "Güldehan", 
			"Tunahan", "Barbaros", "Bilal", "Enes", "Selçuk", 
			"Þule", "Tuðçe","Hadise", "Gözde", "Esra", "Tuðba"};
	
	String[] soyIsimler = new String[] {"Sartekin", "Emircan", "Ýpekçi","Bursalý",
			"Kaya", "Altýntop", "Kalaycý", "Düzyatan", "Ersoy", "Yerlikaya",
			"Sarý","Þansal","Ulusay","Türker","Üstün","Yüksel","Uður",
			"Ateþ","Düzoba","Kýlýç"};
	
	String[] karistirilmisIsimleString = new String[400];
	
	public randomName() {
		Collections.shuffle(Arrays.asList(isimler)); //isimlerin sýralamasý deðiþtiriliyor
		Collections.shuffle(Arrays.asList(soyIsimler)); //soyisimlerin sýralamasý deðiþtiriliyor
		isimleriBirlestir();
	}
	
	private void isimleriBirlestir() { //isimlerin kartezyen kümesi oluþturuluyor
		for(int i = 0; i<20; i++){
			for(int j=0; j<20; j++)
			karistirilmisIsimleString[20*i+j] = isimler[j] + " " + soyIsimler[i];
		}
	}
	
	public String[] isimleriOku(int n){ //oluþturulan isimleri string dizisi olarak döndürür
		String[] isimler = new String[n];
		Collections.shuffle(Arrays.asList(karistirilmisIsimleString)); //isim soyisim kombinasyonlarý karýþtýrýlýyor
		for(int i=0; i<n;i++){
			isimler[i]=karistirilmisIsimleString[i];
		}
		return isimler;
	}
}
