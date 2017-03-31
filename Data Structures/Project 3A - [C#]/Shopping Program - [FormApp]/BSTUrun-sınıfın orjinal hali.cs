using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{

public class BSTUrun {
    private Urun root;
    
    // ağaç boş mu ?
    public bool isEmpty() {
        return size() == 0;
    }

    // ağaçtaki kök hariç düğüm sayısını döndürür
    public int size() {
        return size(root);
    }

    // x düğümünün altındaki düğüm sayısını döndürür
    private int size(Urun x) {
        if (x == null) return 0;
        else return x.getN();
    }
    
    /***********************************************************************
     *  Search BST for given key, and return associated value if found,
     *  return null if not found
     ***********************************************************************/
    
     // bu isme sahip ürün var mı?
     public bool contains(String urunAdi) {
         return get(urunAdi) != null;
     }

     // ismi verilen ürünü döndürür yoksa null döndürür
     public Urun get(String urunAdi) {
         return get(root, urunAdi);
     }
     
     private Urun get(Urun x, String urunAdi) {
         if (x == null) return null;
         //int cmp = urunAdi.compareTo(x.getUrunAdi());
         int cmp = String.Compare(urunAdi, x.getUrunAdi());
         if      (cmp < 0) return get(x.getLeft(), urunAdi);
         else if (cmp > 0) return get(x.getRight(), urunAdi);
         else              return x;
     }
     
     /***********************************************************************
      *  Ağaca yeni düğüm ekleme
      *  Eğer eklenecek düğüm zaten ağaçta mevcut ise bilgileri güncellenir
      ***********************************************************************/
     
     public void put(Urun eklenecekUrun) {
        // if (val == null) { delete(key); return; }
         root = put(root, eklenecekUrun);
         //assert check();
     }

     private Urun put(Urun root, Urun eklenecekUrun) {
         if (root == null) return eklenecekUrun;
         //int cmp = eklenecekUrun.getUrunAdi().compareTo(root.getUrunAdi());
         int cmp = string.Compare(eklenecekUrun.getUrunAdi(), root.getUrunAdi());
         if      (cmp < 0) root.setLeft(put(root.getLeft(),eklenecekUrun));
         else if (cmp > 0) root.setRight(put(root.getRight(),eklenecekUrun));
         else              root   = eklenecekUrun;
         root.setN(1 + size(root.getLeft()) + size(root.getRight()));
         return root;
     }
     
     /***********************************************************************
      *  Silme
      ***********************************************************************/
     public void deleteMin() {
         if (isEmpty()) throw new NullReferenceException("Symbol table underflow");
         root = deleteMin(root);
         //assert check();
     }
     
     private Urun deleteMin(Urun silinecekUrun) {
         if (silinecekUrun.getLeft() == null) return silinecekUrun.getRight();
         silinecekUrun.setLeft(deleteMin(silinecekUrun.getLeft()));
         silinecekUrun.setN(size(silinecekUrun.getLeft()) + size(silinecekUrun.getRight()) + 1);
         return silinecekUrun;
     }
     
     public void deleteMax() {
         if (isEmpty()) throw new NullReferenceException("Symbol table underflow");
         root = deleteMax(root);
         //assert check();
     }
     
     private Urun deleteMax(Urun silinecekUrun) {
         if (silinecekUrun.getRight() == null) return silinecekUrun.getLeft();
         silinecekUrun.setRight(deleteMax(silinecekUrun.getRight()));
         silinecekUrun.setN(size(silinecekUrun.getLeft()) + size(silinecekUrun.getRight()) + 1);
         return silinecekUrun;
     }
     
     public void delete(String urunAdi) {
         root = delete(root, urunAdi);
         //assert check();
     }
     
     private Urun delete(Urun root, String urunAdi) {
         if (root == null) return null;
         //int cmp = urunAdi.compareTo(root.getUrunAdi());
         int cmp = string.Compare(urunAdi, root.getUrunAdi());
         if      (cmp < 0) root.setLeft(delete(root.getLeft(),  urunAdi));
         else if (cmp > 0) root.setRight(delete(root.getRight(), urunAdi));
         else { 
             if (root.getRight() == null) return root.getLeft();
             if (root.getLeft()  == null) return root.getRight();
             Urun t = root;
             root = min(root.getRight());
             root.setRight(deleteMin(t.getRight()));
             root.setLeft(t.getLeft());
         } 
         root.setN(size(root.getLeft()) + size(root.getRight()) + 1);
         return root;
     }
     
     /***********************************************************************
      *  Min, max
      ***********************************************************************/
      public String min() {
          if (isEmpty()) return null;
          return min(root).getUrunAdi();
      } 

      private Urun min(Urun x) { 
          if (x.getLeft() == null) return x; 
          else                return min(x.getLeft()); 
      } 

      public String max() {
          if (isEmpty()) return null;
          return max(root).getUrunAdi();
      } 

      private Urun max(Urun x) { 
          if (x.getRight() == null) return x; 
          else                 return max(x.getRight()); 
      } 
    }
}
