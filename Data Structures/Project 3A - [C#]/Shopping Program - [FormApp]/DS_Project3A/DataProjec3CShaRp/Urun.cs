using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace DataProjec3CShaRp
{
    public class Urun
    {
        private String urunAdi;
        private String urunKategori;
        private String marka;
        private String model;
        private int miktar;
        private int maliyet;
        private int satisFiyatı;
        private List<string> aciklama;
        private List<TheOthers> digerleri;
        private Urun left, right;
        private int N;
        private int duzey;

        public List<TheOthers> getDigerleri()
        {
            return digerleri;
        }

        public void setDigerleri(List<TheOthers> list)
        {
            this.digerleri = list;
        }

        public String getMarka()
        {
            return marka;
        }
        public void setMarka(String marka)
        {
            this.marka = marka;
        }
        public String getModel()
        {
            return model;
        }
        public void setModel(String model)
        {
            this.model = model;
        }
        public int getMiktar()
        {
            return miktar;
        }
        public void setMiktar(int miktar)
        {
            this.miktar = miktar;
        }
        public int getMaliyet()
        {
            return maliyet;
        }
        public void setMaliyet(int maliyet)
        {
            this.maliyet = maliyet;
        }
        public int getSatisFiyatı()
        {
            return satisFiyatı;
        }
        public void setSatisFiyatı(int satisFiyatı)
        {
            this.satisFiyatı = satisFiyatı;
        }
        public String getUrunAdi()
        {
            return urunAdi;
        }
        public void setUrunAdi(String urunAdi)
        {
            this.urunAdi = urunAdi;
        }
        public String getUrunKategori()
        {
            return urunKategori;
        }
        public void setUrunKategori(String urunKategori)
        {
            this.urunKategori = urunKategori;
        }
        public Urun getLeft()
        {
            return left;
        }
        public void setLeft(Urun left)
        {
            this.left = left;
        }
        public Urun getRight()
        {
            return right;
        }
        public void setRight(Urun right)
        {
            this.right = right;
        }
        public int getN()
        {
            return N;
        }
        public void setN(int n)
        {
            N = n;
        }
        public void setAciklama(List<string> lst)
        {
            this.aciklama = lst;
        }
        public List<string> getAciklama()
        {
            return aciklama;
        }
        public void setDuzey(int n)
        {
            duzey = n;
        }
        public int getDuzey()
        {
            return duzey;
        }

    }
}
