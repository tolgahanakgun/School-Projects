using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataProjec3CShaRp
{
    public class BSTUrun
    {
        private Urun root;

        public Urun getRoot()
        {
            return root;
        }

        // ağaç boş mu ?
        public bool isEmpty()
        {
            return size() == 0;
        }

        // ağaçtaki düğüm sayısını döndürür
        public int size()
        {
            if (root == null) return 0; //ağaç boşsa yani root==null ise 0
            return size(root) + 1;        //eğer eleman varsa da bütün elemanların sayısını döndürür(root!=null ise root da bir elemandır)
        }

        // x düğümünün altındaki düğüm sayısını döndürür
        public int size(Urun x)
        {
            if (x == null) return 0;
            else return x.getN();
        }

        // bu isme sahip ürün var mı?
        public bool contains(String urunAdi)
        {
            return get(urunAdi) != null;
        }

        // ismi verilen ürünü döndürür yoksa null döndürür
        public Urun get(String urunAdi)
        {
            return get(root, urunAdi);
        }

        private Urun get(Urun x, String urunAdi)
        {
            if (x == null) return null;
            int cmp = String.Compare(urunAdi, x.getUrunAdi());
            if (cmp < 0) return get(x.getLeft(), urunAdi);
            else if (cmp > 0) return get(x.getRight(), urunAdi);
            else return x;
        }

         //Ağaca yeni düğüm ekleme
         //Eğer eklenecek düğüm zaten ağaçta mevcut ise bilgileri güncellenir
         
        public void put(Urun eklenecekUrun)
        {
            root = put(root, eklenecekUrun);
        }

        private Urun put(Urun root, Urun eklenecekUrun)
        {
            if (root == null) return eklenecekUrun;
            int cmp = string.Compare(eklenecekUrun.getUrunAdi(), root.getUrunAdi());
            if (cmp < 0) root.setLeft(put(root.getLeft(), eklenecekUrun));
            else if (cmp > 0) root.setRight(put(root.getRight(), eklenecekUrun));
            else root = eklenecekUrun;
            if (root.getLeft() != null && root.getRight() != null)                        //eğer bir dalın sağında ve solunda yaprak
                root.setN(1 + size(root.getLeft()) + size(root.getRight()) + 1);   //varsa bu dalın N sayısı +2 artmalı
            else root.setN(1 + size(root.getLeft()) + size(root.getRight()));   //tek bir yaprak varsa buna gerek yoktur
            return root;
        }

        public void deleteMin()
        {
            if (isEmpty()) throw new ArgumentNullException("Böyle bir düğüm bulunmamaktadır !");
            root = deleteMin(root);
        }

        private Urun deleteMin(Urun silinecekUrun)
        {
            if (silinecekUrun.getLeft() == null) return silinecekUrun.getRight();
            silinecekUrun.setLeft(deleteMin(silinecekUrun.getLeft()));
            silinecekUrun.setN(size(silinecekUrun.getLeft()) + size(silinecekUrun.getRight()) + 1);
            return silinecekUrun;
        }

        public void deleteMax()
        {
            if (isEmpty()) throw new ArgumentNullException("Böyle bir düğüm bulunmamaktadır !");
            root = deleteMax(root);
        }

        private Urun deleteMax(Urun silinecekUrun)
        {
            if (silinecekUrun.getRight() == null) return silinecekUrun.getLeft();
            silinecekUrun.setRight(deleteMax(silinecekUrun.getRight()));
            silinecekUrun.setN(size(silinecekUrun.getLeft()) + size(silinecekUrun.getRight()) + 1);
            return silinecekUrun;
        }

        public void delete(String urunAdi)
        {
            root = delete(root, urunAdi);
        }

        private Urun delete(Urun root, String urunAdi)
        {
            if (root == null) return null;
            int cmp = string.Compare(urunAdi, root.getUrunAdi());
            if (cmp < 0) root.setLeft(delete(root.getLeft(), urunAdi));
            else if (cmp > 0) root.setRight(delete(root.getRight(), urunAdi));
            else
            {
                if (root.getRight() == null) return root.getLeft();
                if (root.getLeft() == null) return root.getRight();
                Urun t = root;
                root = min(root.getRight());
                root.setRight(deleteMin(t.getRight()));
                root.setLeft(t.getLeft());
            }
            root.setN(size(root.getLeft()) + size(root.getRight()) + 1);
            return root;
        }

        public String min()
        {
            if (isEmpty()) return null;
            return min(root).getUrunAdi();
        }

        private Urun min(Urun x)
        {
            if (x.getLeft() == null) return x;
            else return min(x.getLeft());
        }

        public String max()
        {
            if (isEmpty()) return null;
            return max(root).getUrunAdi();
        }

        private Urun max(Urun x)
        {
            if (x.getRight() == null) return x;
            else return max(x.getRight());
        }

        public LinkedList<Urun> inOrder(Urun localRoot, float aralik1, float aralik2, LinkedList<Urun> aralikUrun)
        {
            if (localRoot != null)
            {
                inOrder(localRoot.getLeft(), aralik1, aralik2, aralikUrun);
                if (localRoot.getSatisFiyatı() > aralik1 && localRoot.getSatisFiyatı() < aralik2)
                    aralikUrun.AddFirst(localRoot);
                inOrder(localRoot.getRight(), aralik1, aralik2, aralikUrun);

                return aralikUrun;
            }

            return null;
        }

        public int height() { return height(root); }
        private int height(Urun x)
        {
            if (x == null) return -1;
            return 1 + Math.Max(height(x.getLeft()), height(x.getRight()));
        }

        public void duzeyListele(Urun etkin, int d)
        {
            if (etkin != null)
            {
                d = d + 1;
                duzeyListele(etkin.getLeft(), d);
                //Console.WriteLine(" " + etkin.data + " " + d + ". düzeyde");
                duzeyListele(etkin.getRight(), d);
            }
        }

        public LinkedList<Urun> inOrder(Urun localRoot, string kategori, LinkedList<Urun> kategoriUrun, int duzey)
        {
            if (localRoot != null)
            {
                duzey++;

                if (string.Compare(localRoot.getUrunKategori(), kategori) == 0)
                {
                    localRoot.setDuzey(duzey);
                    kategoriUrun.AddFirst(localRoot);
                    if(localRoot.getDigerleri() != null)
                    {
                        Urun urun = new Urun();
                        urun.setUrunAdi(localRoot.getUrunAdi());
                        urun.setUrunKategori(localRoot.getUrunKategori());
                        urun.setDuzey(duzey);
                        foreach(TheOthers to in localRoot.getDigerleri())
                        {
                            urun.setMarka(to.getMarka());
                            urun.setModel(to.getModel());
                            urun.setMiktar(to.getMiktar());
                            urun.setMaliyet(to.getMaliyet());
                            urun.setSatisFiyatı(to.getSatisFiyatı());
                            urun.setAciklama(to.getAciklama());

                            kategoriUrun.AddFirst(urun);
                        }
                    }
                }
                    
                inOrder(localRoot.getLeft(), kategori, kategoriUrun,duzey);
                inOrder(localRoot.getRight(), kategori, kategoriUrun,duzey);

                return kategoriUrun;
            }

            return null;
        }

        public void getCheaper(string kategori, Heap hp)
        {
            LinkedList<Urun> lst = new LinkedList<Urun>();
            foreach (Urun urun in inOrder(root, kategori, lst, -1))
                hp.insert(urun);
        } 
    }

}

