package dataProject2;

public class Araba {
	private String renk;
	private Araba sonrakiAraba;
	public int beklemeSuresi;
	private int siraNo;
	
	public Araba(String renk){
		this.renk = renk;
	}
	public Araba(int beklemeSuresi){
		this.beklemeSuresi=beklemeSuresi;
	}
	
	public Araba(String renk, int beklemeSuresi, int siraNo){
		this.beklemeSuresi=beklemeSuresi;
		this.renk=renk;
		this.siraNo=siraNo;
	}
	
	
	public Araba getSonrakiAraba() {
		return sonrakiAraba;
	}
	public void setSonrakiAraba(Araba sonrakiAraba) {
		this.sonrakiAraba = sonrakiAraba;
	}
	public String getRenk() {
		return renk;
	}
	public void setRenk(String renk) {
		this.renk = renk;
	}
	public int getBeklemeSuresi() {
		return beklemeSuresi;
	}
	public void setBeklemeSuresi(int beklemeSuresi) {
		this.beklemeSuresi = beklemeSuresi;
	}
	public int getSiraNo() {
		return siraNo;
	}
	public void setSiraNo(int siraNo) {
		this.siraNo = siraNo;
	}
}
