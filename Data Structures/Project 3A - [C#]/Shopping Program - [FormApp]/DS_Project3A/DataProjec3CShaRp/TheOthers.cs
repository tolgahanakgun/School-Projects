using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataProjec3CShaRp
{
    public class TheOthers
    {
        private String marka;
        private String model;
        private int miktar;
        private int maliyet;
        private int satisFiyatı;
        private List<string> aciklama;

        public List<string> getDigerleri()
        {
            return aciklama;
        }
        public void setDigerleri(List<string> list)
        {
            this.aciklama = list;
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
        public void setAciklama(List<string> lst)
        {
            this.aciklama = lst;
        }
        public List<string> getAciklama()
        {
            return aciklama;
        }
    }
}
