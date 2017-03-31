package dataProjectPart_II;
import java.util.ArrayList;

import org.eclipse.swt.widgets.Label;
import org.eclipse.swt.widgets.ProgressBar;
import org.eclipse.swt.widgets.Text;

public class masa{
	String[] kisiler;
	int masadakiKisiSayisi;
	
	public masa(int masadaOturacakKisiSayisi){  
		kisiler = new String[masadaOturacakKisiSayisi];
		masadakiKisiSayisi = masadaOturacakKisiSayisi;
	}
	
	public masa(){ } //parametresiz constructor main de fonksiyonlarý kullanabilmek için yazýldý
	
	public void masayaOturt(String kisi){ //parametre olarak gönderilen kiþi sayýsý kadar yere sahip masa oluþturur
		this.kisiler[this.kacKisiVar()]=kisi;
	}
	
	public String[] masadaKimlerVar(){ //masadaki kiþilerin listesini döndürür
		return kisiler;
	}
	
	public int kacKisiVar(){ //masadaki kiþi sayýsýný döndürür
		int i = 0;
		while(kisiler[i]!=null){
			i++;
			if(i==kisiler.length)
				return i;
		}
		return i;
	}
	
	public int masaDolulukYuzdesi(){ //masanýn doluluk yüzdesini döndürür
		return (int)(100/((double)masadakiKisiSayisi/this.kacKisiVar()));
	}
	
	public masa[] masaDizisiOlustur(){ //önceden belirlenmiþ sayýda masa nesnelerinden oluþmuþ dizi döndürür
		masa[] masalar = new masa[10];
		int i=0,j=0,k=0;
		for(;i<2;i++) masalar[i] = new masa(10);
		for(;j<3;j++) masalar[i+j] = new masa(8);
		for(;k<5;k++) masalar[i+j+k] = new masa(4);
		return masalar;
	}
	
	public void masalaraYerlestir(String[] kisiler,masa[] masalar) {
		int[][] yerlestirmeSirasi = new int[][] {{1, 1,	1,	1,	1,	1,	1,	1,	1,	1,},	//masalara kiþiler daðýtýlýrken
												{1,  1,	1,	1,	1,	1,	1,	1,	1,	1,},	//buradaki öncelik sýralarýna göre
												{1,  1,	1,	1,	0,	1,	1,	0,	1,	1,},	//daðýtýlýr
												{1,  1,	1,	1,	0,	1,	1,	0,	1,	1,},
												{1,	 1,	1,	1,	0,	1,	1,	0,	1,	1,},
												{1,	 0,	0,	1,	0,	0,	1,	0,	1,	0,},
												{1,	 0,	0,	1,	0,	0,	1,	0,	1,	0,},
												{1,	 0,	0,	1,	0,	0,	1,	0,	1,	0,},
												{1,	 0,	0,	1,	0,	0,	1,	0,	1,	0,},
												{1,	 0,	0,	1,	0,	0,	1,	0,	1,	0}};
		int i=0,j=0,k=0;
		for(i=0;i<10;i++){
			for(j=0;j<10;j++){
				if(yerlestirmeSirasi[j][i]==1){
					masalar[j].masayaOturt(kisiler[k]);
					k++;
				}
				if(kisiler.length==k) break;
			}
			if(kisiler.length==k) break;
		}
	}
	
	public void masalariYazdir(ArrayList<ProgressBar> pbarList,ArrayList<Label> lblList, ArrayList<Text> txtKisler2, int kisiSayisi){
		randomName rndmName = new randomName(); //masaya oturacaklarýn isimleri için random isimler oluþturuluyor
		masa[] masalar = masaDizisiOlustur();
		String[] kisilerStrings = rndmName.isimleriOku(kisiSayisi);
		masalaraYerlestir(kisilerStrings, masalar);
		String geciciString = new String();
		int j=0, i;
		for(i=0;i<10;i++){
			for(String str: masalar[i].masadaKimlerVar()){ //masadaki kiþi sayýsý kadar yazdýrma iþlemi
				if(str==null)
					break;
				j++;
				geciciString+=(j+"."+str+" ");
			}
			j=0;
			if(geciciString!=null)
			txtKisler2.get(i).setText(geciciString);
			geciciString="";
			pbarList.get(i).setSelection(masalar[i].masaDolulukYuzdesi()); //ilerleme çubuklarýna yüzdeleri iþleniyor
			lblList.get(i).setText(masalar[i].kacKisiVar()+" kisi,  "+"%"+String.valueOf(masalar[i].masaDolulukYuzdesi()));
			
		}
		pbarList.get(i).setSelection((int)(100/((double)64/kisiSayisi)));
		if(kisiSayisi>=64){ //restoran geneli doluluk yüzdesi bulunuyor
			lblList.get(i).setText(kisiSayisi+" kisi,  "+"%"+"100");
		}else{
			lblList.get(i).setText(kisiSayisi+" kisi,  "+"%"+(int)(100/((double)64/kisiSayisi)));
		}
		if(kisiSayisi>64){ //ayakta kalan müþteri sayýsý ve gereken boþ masa sayýsý hesaplanýyor
			lblList.get(11).setText("!!! " + String.valueOf(kisiSayisi-64) +" müþteri ayakta kalmýþtýr"+"\n"+
					String.valueOf((int)Math.ceil((double)(kisiSayisi-64)/4)) + " tane daha 4 kiþilik masa gerekmektedir");
		}else {
			lblList.get(11).setText("");
		}
		if(kisilerStrings.length>64){
			ayaktaKalanlarForm frmAyaktaKalanlar = new ayaktaKalanlarForm(kisilerStrings);
			frmAyaktaKalanlar.open();
		}
			
	}	
}