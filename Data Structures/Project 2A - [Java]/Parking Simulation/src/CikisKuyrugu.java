package dataProject2;

import java.util.Iterator;

public class CikisKuyrugu {

	private int boyut;
	private Araba[] kuyrukDizi;
	private int bas,son;
	private int elemanSayisi;
	
	public CikisKuyrugu(int s){
		boyut = s;
		kuyrukDizi = new Araba[boyut];
		bas = 0; son = -1; elemanSayisi = 0;
	}
	
	public void enque(Araba j){//Kuyruk sonuna eleman ekler
		if(son == boyut-1)//basa donme durumu
			son = -1;
		kuyrukDizi[++son] = j;//sonu arttýr ve ekle
		elemanSayisi++;
	}
	
	public Araba deque(){
		Araba temp = kuyrukDizi[bas++];
		if(bas == boyut)
			bas = 0;
		elemanSayisi--;
		return temp;
	}
	
	public boolean bosMu(){//kuyruk bos ise, true
		return elemanSayisi==0;
	}
}
