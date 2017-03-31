using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataProjec3CShaRp
{
    class Hasher
    {
        public Hasher() { }
        public void hasher(string[] str, Dictionary<string, List<Urun>> dt, Urun urun)
        {
            List<string> lst = new List<string>();
            int i = 7;
            string gecici;
            try
            {
                while ((gecici = str[i]) != null)
                {
                    lst.Add(gecici);

                    if (!dt.ContainsKey(gecici))
                    {
                        List<Urun> hList = new List<Urun>();
                        hList.Add(urun);
                        dt.Add(gecici, hList);
                    }
                    else
                        dt[gecici].Add(urun);

                    i++;
                }
            }
            catch (IndexOutOfRangeException) { }
        }
        public void dehasher(Dictionary<string, List<Urun>> dt, Urun urun)
        {
            foreach (string str in urun.getAciklama())
            {
                dt[str].Remove(urun);
                if (dt[str].Count == 0) //eğer ürünün silindiği liste boş ise
                    dt.Remove(str); //bu girdiyi hash tablosunda siliyoruz
            }
        }
    }
}
