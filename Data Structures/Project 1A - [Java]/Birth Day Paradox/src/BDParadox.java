import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Random;
import java.util.Scanner;

public class BDParadox {

	public static void main(String[] Args){
		
		Scanner scan = new Scanner(System.in);
		int devam = 0;
		boolean hata;
		int yil1,yil2;
		
		do{
			do{
				hata = false;
				System.out.print("Birinci y�l� giriniz: ");
				yil1 = scan.nextInt();
				System.out.print("�kinci y�l� giriniz: ");
				yil2 = scan.nextInt();
				if(yil1==yil2){
					hata = true;
					System.out.println("Girilen y�llar ayn� olamaz!");
				}
			}while(hata);
			
			int secim = anaMenu();
						
			switch (secim) {
			case 1:
				istatistikYaz(yil1,yil2);
				break;
			case 2:
				for(int x=0;x<3;x++){
					System.out.print((x+1) + ". deney i�in ki�i(n) say�s�n� giriniz: ");
					int n = scan.nextInt();
					int secim2 = kizErkekDeney();
					switch (secim2) {
					case 1:
						deneyTekrarla(yil1, yil2, n);
						break;
					case 2:
						for(int g=0;g<2;g++){
							if(g==0){
								n=n/4;//K�z ��rencilerin tahmini say�s�na g�re n say�s� de�i�iyor.
								System.out.println("Bu deney k�zlar i�in ger�ekle�tiriliyor...");
							}
							else{
								n=(3*n)/4;//Erkek ��rencilerin tahmini say�s�na g�re n say�s� de�i�iyor.
								System.out.println("Bu deney erkekler i�in ger�ekle�tiriliyor...");
							}
							deneyTekrarla(yil1, yil2, n);
						}	
						break;
					default:
						break;
					}
				}
					break;
			default://varsay�lan giri�i..
				break;
			}
			System.out.print("\nDevam etmek i�in 1, ��kmak i�in 0 girin: ");
			devam = scan.nextInt();
			System.out.println();
		}while(devam==1);
		scan.close();
	}
	
	public static int anaMenu(){
		
		Scanner scan = new Scanner(System.in);

		System.out.println("1 - �statistikleri g�r");
		System.out.println("2 - Tek tek deneyleri g�r");
		System.out.print("Se�iminizi yap�n�z: ");
		int secim = scan.nextInt();

		return secim;
	}
	
	public static int kizErkekDeney(){
		
		Scanner scan = new Scanner(System.in);
		
		System.out.println("1 - Deneyi t�m herkes i�in ger�ekle�tir");
		System.out.println("2 - K�z ve erkek ��renciler i�in ayr� ayr� ger�ekle�tir");
		System.out.print("Se�iminizi yap�n�z: ");
		int secim = scan.nextInt();
		
		return secim;
	}
	
	public static void istatistikYaz(int yil1,int yil2){
		
		double[][] cakismaDizisi = new double[3][11];

		cakismaDizisi = nCakisma(yil1, yil2);
		
		System.out.println("\n     	   1.n      2.n     3.n");
		System.out.println("     	   ----    ------  ------");
		for(int i=0;i<11;i++){
			if(i!=10)
				System.out.printf("%s%-5d","Deney ",(i+1));
			else
				System.out.printf("%-5s","Ortalama:  ");
			for(int k=0;k<3;k++){
				System.out.printf("%-8.2f",cakismaDizisi[k][i]);
			}
			System.out.println();
		}
	}

	public static double[][] nCakisma(int yil1,int yil2){

		Scanner scan = new Scanner(System.in);
		double[][] cakismaDizisi = new double[3][11];
		int toplamCakisma;

		for(int j=0;j<3;j++){
			toplamCakisma=0;
			System.out.print((j+1) + ". deney i�in ki�i(n) say�s�n� giriniz: ");
			int n = scan.nextInt();
			for(int i=0;i<10;i++){
				cakismaDizisi[j][i] = herDeneydekiCakisma(yil1, yil2, n);
				toplamCakisma += cakismaDizisi[j][i];
			}
			cakismaDizisi[j][10] = ((double)toplamCakisma/10);
		}
		return cakismaDizisi;
	}

	public static int herDeneydekiCakisma(int yil1,int yil2,int n){

		int sayac[][][] = generateRandomBD(yil1, yil2, n);

		int toplamYil = toplamYil(yil1, yil2);
		int kucukYil = kucukYilHesapla(yil1, yil2);
		int yildakiCakisma = 0;
		int toplamCakisma = 0;

		for(int i=0;i<toplamYil;i++){
			yildakiCakisma = 0;
			for(int j=0;j<12;j++){
				switch(j){
				case 0:case 2:case 4:
				case 6:case 7:case 9:case 11:
					for(int k=0;k<31;k++){
						if(sayac[i][j][k]!=0){
							yildakiCakisma+=sayac[i][j][k]-1;
						}
					}
					break;
				case 3:case 5:case 8:case 10:
					for(int k=0;k<30;k++){
						if(sayac[i][j][k]!=0){
							yildakiCakisma+=sayac[i][j][k]-1;
						}
					}
					break;
				case 1:
					if((i+kucukYil)%4==0)
						for(int k=0;k<29;k++){
							if(sayac[i][j][k]!=0){
								yildakiCakisma+=sayac[i][j][k]-1;
							}
						}
					else
						for(int k=0;k<28;k++){
							if(sayac[i][j][k]!=0){
								yildakiCakisma+=sayac[i][j][k]-1;
							}
						}
					break;
				}
			}
			toplamCakisma += yildakiCakisma;
		}
		return toplamCakisma;
	}
	
	public static void deneyTekrarla(int yil1,int yil2,int n){
		
		BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
		
		//Deneyler 10 kere tekrarlan�yor...
		for(int i=0;i<10;i++){
			System.out.print("\n Deney: " + (i+1) + "\n --------");
			herDeneyiGoster(yil1,yil2,n,i);
			System.out.print("\nDevam etmek i�in bir tu�a bas�n�z...");
			try {
				br.readLine();
			} catch (IOException e) {
				e.printStackTrace();
			}
		}
	}

	public static void herDeneyiGoster(int yil1,int yil2,int n,int deneySayisi){

		int [][][] sayac = generateRandomBD(yil1, yil2, n);

		int toplamYil = toplamYil(yil1, yil2);
		int kucukYil = kucukYilHesapla(yil1, yil2);

		//D�zensiz diziler ekrana bast�r�l�yor...
		for(int i=0;i<toplamYil;i++){
			System.out.println("\n Y�l: " + (i+kucukYil));
			System.out.println("   1 2 3 4 5 6 7 8 9 10111213141516171819202122232425262728293031");
			System.out.println("   --------------------------------------------------------------");
			for(int j=0;j<12;j++){
				switch(j){
				case 0:case 2:case 4:
				case 6:case 7:case 9:case 11:
					System.out.printf("%-3d",(j+1));
					for(int k=0;k<31;k++){
						if(sayac[i][j][k]!=0 && sayac[i][j][k]!=1)
							System.out.print(sayac[i][j][k]-1 + " ");
						else
							System.out.print(0 + " ");
					}
					break;
				case 3:case 5:case 8:case 10:
					System.out.printf("%-3d",(j+1));
					for(int k=0;k<30;k++){
						if(sayac[i][j][k]!=0 && sayac[i][j][k]!=1)
							System.out.print(sayac[i][j][k]-1 + " ");
						else
							System.out.print(0 + " ");
					}
					break;
				case 1:
					System.out.printf("%-3d",(j+1));
					if((i+kucukYil)%4==0)
						for(int k=0;k<29;k++){
							if(sayac[i][j][k]!=0 && sayac[i][j][k]!=1)
								System.out.print(sayac[i][j][k]-1 + " ");
							else
								System.out.print(0 + " ");
						}
					else
						for(int k=0;k<28;k++){
							if(sayac[i][j][k]!=0 && sayac[i][j][k]!=1)
								System.out.print(sayac[i][j][k]-1 + " ");
							else
								System.out.print(0 + " ");
						}
					break;
				}
				System.out.println();
			}
		}
	}

	public static int[][][] generateRandomBD(int yil1,int yil2,int n){

		int toplamYil = toplamYil(yil1, yil2);
		int[][][] sayac = new int[toplamYil][][];
		int kucukYil = kucukYilHesapla(yil1, yil2);

		//D�zensiz dizi olu�turuluyor...
		for(int x=0;x<toplamYil;x++){
			sayac[x] = new int[12][];
			for(int y=0;y<12;y++){
				switch(y){
				case 0:case 2:case 4:
				case 6:case 7:case 9:case 11:
					sayac[x][y] = new int[31];
					break;
				case 3:case 5:case 8:case 10:
					sayac[x][y] = new int[30];
					break;
				case 1:
					if((x+kucukYil)%4==0)
						sayac[x][y] = new int[29];
					else
						sayac[x][y] = new int[28];		
					break;
				}
			}
		}

		for(int i=0;i<n;i++){//n tane do�um g�n� �retiliyor...
			generateRandomBDBetweenTwoDates(yil1,yil2,sayac);
		}
		
		return sayac;
	}

	public static void generateRandomBDBetweenTwoDates(int yil1,int yil2,int sayac[][][]){

		Random rn = new Random();

		int yil=0;
		int kucukYil = kucukYilHesapla(yil1, yil2);

		yil = (rn.nextInt(toplamYil(yil1, yil2)));

		int ay = 0;
		ay = rn.nextInt(12);
		int gun = 0;
		
		//Aylar�n g�n say�lar�na g�re rastgele g�nler olu�turuluyor...
		switch(ay){
		case 0:case 2:case 4:
		case 6:case 7:case 9:case 11:
			gun = rn.nextInt(31);
			break;
		case 3:case 5:case 8:case 10:
			gun = rn.nextInt(30);
			break;
		case 1:
			if((yil+kucukYil)%4==0)
				gun = rn.nextInt(29);
			else
				gun = rn.nextInt(28);
			break;
		}
		
		sayac[yil][ay][gun]++;
	}

	public static int kucukYilHesapla(int yil1,int yil2){

	if(yil1<yil2)
		return yil1;
	else
		return yil2;
	}

	public static int toplamYil(int yil1,int yil2){

		if(yil1<yil2)
			return yil2-yil1+1;
		else
			return yil1-yil2+1;
	}
}