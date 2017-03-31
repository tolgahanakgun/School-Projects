using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataProjec3CShaRp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        BSTUrun bst = Global.BST;
        //Heap heap = Global.HEAP;
        Dictionary<string, List<Urun>> dt = Global.DT;

        int satilanTop = Global.ST;
        int maliyetTop = new int();
        int satisTop = new int();
        

        private void txt_UrunAdiAra_TextChanged(object sender, EventArgs e)
        {
            if(txt_urunAdiAra.Text != "")
            {
                txt_AnahtarKelime.Enabled = false;
                txt_FiyatAraligi1.Enabled = false;
                txt_fiyatAraligi2.Enabled = false;
                txt_Kategori.Enabled = false;
            }
            else
            {
                txt_AnahtarKelime.Enabled = true;
                txt_FiyatAraligi1.Enabled = true;
                txt_fiyatAraligi2.Enabled = true;
                txt_Kategori.Enabled = true;
            }
        }

        private void txt_FiyatAraligi1_TextChanged(object sender, EventArgs e)
        {
            if(txt_FiyatAraligi1.Text != "" || txt_fiyatAraligi2.Text !="")
            {
                txt_AnahtarKelime.Enabled = false;
                txt_UrunSayisi.Enabled = false;
                txt_Kategori.Enabled = false;
                txt_urunAdiAra.Enabled = false;
            }
            else
            {
                txt_AnahtarKelime.Enabled = true;
                txt_UrunSayisi.Enabled = true;
                txt_Kategori.Enabled = true;
                txt_urunAdiAra.Enabled = true;
            }
        }

        private void btn_Ara_Click(object sender, EventArgs e)
        {
            if(txt_urunAdiAra.Enabled && txt_Kategori.Enabled)
            {
                MessageBox.Show("En az bir kutuyu doldurmalısınız.");
            }
            else if(txt_urunAdiAra.Enabled)
            {
                lstView_KullaniciArama.Items.Clear();

                if (bst.contains(txt_urunAdiAra.Text))
                {
                    Urun urun = new Urun();

                    urun = bst.get(txt_urunAdiAra.Text);

                    ListViewItem lvi = new ListViewItem(urun.getUrunAdi());

                    lvi.SubItems.Add(urun.getUrunKategori());
                    lvi.SubItems.Add(urun.getMarka());
                    lvi.SubItems.Add(urun.getModel());
                    lvi.SubItems.Add(urun.getMiktar().ToString());
                    lvi.SubItems.Add(urun.getMaliyet().ToString());
                    lvi.SubItems.Add(urun.getSatisFiyatı().ToString());

                    string[] aciklamaDizi = urun.getAciklama().ToArray();

                    lvi.SubItems.Add(string.Join(",", aciklamaDizi));
                    lvi.SubItems.Add("-".ToString());
                    lstView_KullaniciArama.Items.Add(lvi);

                    ListViewItem lvi2 = new ListViewItem(urun.getUrunAdi());

                    if (urun.getDigerleri() != null)
                        foreach (TheOthers to in urun.getDigerleri())
                        {
                            lvi2.SubItems.Add(urun.getUrunKategori());
                            lvi2.SubItems.Add(to.getMarka());
                            lvi2.SubItems.Add(to.getModel());
                            lvi2.SubItems.Add(to.getMiktar().ToString());
                            lvi2.SubItems.Add(to.getMaliyet().ToString());
                            lvi2.SubItems.Add(to.getSatisFiyatı().ToString());

                            aciklamaDizi = to.getAciklama().ToArray();

                            lvi2.SubItems.Add(string.Join(",", aciklamaDizi));

                            lstView_KullaniciArama.Items.Add(lvi2);
                        }
                }
                else
                    MessageBox.Show("Aranan ürün bulunamadı.");
            }
            else if (txt_AnahtarKelime.Enabled)
            {
                try
                {
                    if (dt[txt_AnahtarKelime.Text] == null)
                        MessageBox.Show("bu ürün bulunamadı !");
                    else
                    {
                        lstView_KullaniciArama.Items.Clear();
                        string gecici = "";
                        foreach (Urun urun in dt[txt_AnahtarKelime.Text])
                        {
                            ListViewItem lv = new ListViewItem(urun.getUrunAdi());
                            lv.SubItems.Add(urun.getUrunKategori());
                            lv.SubItems.Add(urun.getMarka());
                            lv.SubItems.Add(urun.getModel());
                            lv.SubItems.Add(urun.getMiktar().ToString());
                            lv.SubItems.Add(urun.getMaliyet().ToString());
                            lv.SubItems.Add(urun.getSatisFiyatı().ToString());
                            foreach (string str in urun.getAciklama())
                                gecici += (str + ", ");
                            lv.SubItems.Add(gecici);
                            lv.SubItems.Add("-".ToString());
                            lstView_KullaniciArama.Items.Add(lv);
                        }
                    }
                }
                catch (NullReferenceException) { MessageBox.Show("bu ürün bulunamadı !"); }
                catch (KeyNotFoundException) { MessageBox.Show("bu ürün bulunamadı !"); }
            }
            else if(txt_Kategori.Enabled && txt_UrunSayisi.Text == "")
            {
                lstView_KullaniciArama.Items.Clear();

                Urun urun = new Urun();
                LinkedList<Urun> kategoriUrun = new LinkedList<Urun>();
                urun = bst.getRoot();

                kategoriUrun = bst.inOrder(urun,txt_Kategori.Text,kategoriUrun,-1);

                ListViewItem lvi;

                foreach (Urun orn in kategoriUrun)
                {
                    lvi = new ListViewItem(orn.getUrunAdi());
                    lvi.SubItems.Add(orn.getUrunKategori());
                    lvi.SubItems.Add(orn.getMarka());
                    lvi.SubItems.Add(orn.getModel());
                    lvi.SubItems.Add(orn.getMiktar().ToString());
                    lvi.SubItems.Add(orn.getMaliyet().ToString());
                    lvi.SubItems.Add(orn.getSatisFiyatı().ToString());

                    string[] aciklamaDizi = urun.getAciklama().ToArray();
                    lvi.SubItems.Add(string.Join(",", aciklamaDizi));
                    lvi.SubItems.Add(orn.getDuzey().ToString());

                    lstView_KullaniciArama.Items.Add(lvi);
                }

                lbl_Derinlik.Visible = true;
                txt_Derinlik.Visible = true;
                txt_Derinlik.Text = Convert.ToInt32(bst.height()).ToString();
                lbl_ElemanSayisi.Visible = true;
                txt_ElemanSayisi.Visible = true;
                txt_ElemanSayisi.Text = Convert.ToInt32(bst.size()).ToString();
            }
            else if (txt_FiyatAraligi1.Enabled && txt_fiyatAraligi2.Enabled)
            {
                lstView_KullaniciArama.Items.Clear();

                Urun urun = new Urun();
                LinkedList<Urun> aralikUrun = new LinkedList<Urun>();
                urun = bst.getRoot();

                int ara1 = Convert.ToInt32(txt_FiyatAraligi1.Text);
                int ara2 = Convert.ToInt32(txt_fiyatAraligi2.Text);

                aralikUrun = bst.inOrder(urun, ara1, ara2, aralikUrun);

                ListViewItem lvi;
                foreach (Urun orn in aralikUrun)
                {
                    lvi = new ListViewItem(orn.getUrunAdi());
                    lvi.SubItems.Add(orn.getUrunKategori());
                    lvi.SubItems.Add(orn.getMarka());
                    lvi.SubItems.Add(orn.getModel());
                    lvi.SubItems.Add(orn.getMiktar().ToString());
                    lvi.SubItems.Add(orn.getMaliyet().ToString());
                    lvi.SubItems.Add(orn.getSatisFiyatı().ToString());

                    lstView_KullaniciArama.Items.Add(lvi);
                }

            }
            else
            {
                MessageBox.Show("Fiyat aralığı kısımları boş geçilemez.");
            }
        }

        private void txt_fiyatAraligi2_TextChanged(object sender, EventArgs e)
        {
            if (txt_FiyatAraligi1.Text != "" || txt_fiyatAraligi2.Text != "")
            {
                txt_AnahtarKelime.Enabled = false;
                txt_UrunSayisi.Enabled = false;
                txt_Kategori.Enabled = false;
                txt_urunAdiAra.Enabled = false;
            }
            else
            {
                txt_AnahtarKelime.Enabled = true;
                txt_UrunSayisi.Enabled = true;
                txt_Kategori.Enabled = true;
                txt_urunAdiAra.Enabled = true;
            }

        }

        private void txt_Kategori_TextChanged(object sender, EventArgs e)
        {
            if (txt_Kategori.Text != "" || txt_UrunSayisi.Text != "")
            {
                txt_AnahtarKelime.Enabled = false;
                txt_urunAdiAra.Enabled = false;
                txt_FiyatAraligi1.Enabled = false;
                txt_fiyatAraligi2.Enabled = false;
            }
            else
            {
                txt_AnahtarKelime.Enabled = true;
                txt_urunAdiAra.Enabled = true;
                txt_FiyatAraligi1.Enabled = true;
                txt_fiyatAraligi2.Enabled = true;
            }
        }

        private void txt_UrunSayisi_TextChanged(object sender, EventArgs e)
        {
            if (txt_UrunSayisi.Text != "" || txt_Kategori.Text != "")
            {
                txt_AnahtarKelime.Enabled = false;
                txt_FiyatAraligi1.Enabled = false;
                txt_fiyatAraligi2.Enabled = false;
            }
            else
            {
                txt_AnahtarKelime.Enabled = true;
                txt_FiyatAraligi1.Enabled = true;
                txt_fiyatAraligi2.Enabled = true;
            }
        }

        private void txt_UrunSayisi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void btn_SatinAl_Click(object sender, EventArgs e)
        {
            if (txt_Kategori.Enabled && txt_UrunSayisi.Text != "")
            {   
                Heap heap = new Heap();
                lstView_KullaniciArama.Items.Clear();
                bst.getCheaper(txt_Kategori.Text.ToString(), heap);
                List<Urun> lst = new List<Urun>();
                
                Urun urun = heap.removeMin();
                ListViewItem lvi = new ListViewItem(urun.getUrunAdi());

                lvi.SubItems.Add(urun.getUrunKategori());
                lvi.SubItems.Add(urun.getMarka());
                lvi.SubItems.Add(urun.getModel());
                lvi.SubItems.Add(urun.getMiktar().ToString());
                lvi.SubItems.Add(urun.getMaliyet().ToString());
                lvi.SubItems.Add(urun.getSatisFiyatı().ToString());

                string[] aciklamaDizi = urun.getAciklama().ToArray();

                lvi.SubItems.Add(string.Join(",", aciklamaDizi));
                lstView_KullaniciArama.Items.Add(lvi);
                bool bulundu = false;

                if (urun.getDigerleri() != null)
                {
                    foreach (TheOthers to in urun.getDigerleri())
                    {
                        if (to.getMarka() == urun.getMarka())
                        {
                            bulundu = true;
                            if ((to.getMiktar() - Convert.ToInt32(txt_UrunSayisi.Text)) <= 0)
                            {
                                urun.getDigerleri().Remove(to);
                            }
                            else
                            {
                                to.setMiktar((to.getMiktar() - Convert.ToInt32(txt_UrunSayisi.Text)));
                            }
                        }
                    }
                    if (!bulundu)
                    {
                        Urun ur = bst.get(urun.getUrunAdi());
                        ur.setMarka(urun.getMarka());
                        ur.setModel(urun.getModel());
                        ur.setMiktar(urun.getMiktar()-Convert.ToInt32(txt_UrunSayisi.Text));
                        ur.setSatisFiyatı(ur.getSatisFiyatı());
                        ur.setMaliyet(ur.getMaliyet());
                        urun.getDigerleri().RemoveAt(0);
                    }
                }
                else
                {
                    if ((urun.getMiktar() - Convert.ToInt32(txt_UrunSayisi.Text)) <= 0)
                    {
                        bst.delete(urun.getUrunAdi());
                    }
                    else
                    {
                        urun.setMiktar((urun.getMiktar() - Convert.ToInt32(txt_UrunSayisi.Text)));
                    }
                }
            }
            else if(txt_urunAdiAra.Text != "" && txt_urunAdiAra.Enabled)
            {
                Urun urun = new Urun();
                string satilan = lstView_KullaniciArama.SelectedItems[0].SubItems[0].Text;
                urun = bst.get(satilan);
                bool bulundu = false;

                if (urun.getDigerleri() != null)
                {
                    int i = 0;
                    foreach (TheOthers to in urun.getDigerleri())
                    {
                        i++;
                        //gecici = to;
                        if (to.getMarka() == lstView_KullaniciArama.SelectedItems[0].SubItems[2].Text)
                        {
                            bulundu = true;

                            if (Convert.ToInt32(lstView_KullaniciArama.SelectedItems[0].SubItems[4].ToString()) < Convert.ToInt32(txt_UrunSayisi.Text))
                            {
                                MessageBox.Show("Girilen miktar kadar ürün stoklarda bulunmamaktadır.");
                                return;
                            }

                            to.setMiktar(to.getMiktar() - Convert.ToInt32(txt_UrunSayisi.Text));
                            maliyetTop += Convert.ToInt32(txt_UrunSayisi.Text)*to.getMaliyet();
                            satilanTop += Convert.ToInt32(txt_UrunSayisi.Text)*(to.getSatisFiyatı()-to.getMaliyet());
                            satisTop += Convert.ToInt32(txt_UrunSayisi.Text) * to.getSatisFiyatı();
                            MessageBox.Show("Toplam Kar: " + satilanTop + "\n Toplam Maliyet: " + maliyetTop + "\n Toplam Satis Fiyati: " + satisTop);
                            if (to.getMiktar() <= 0)
                            {
                                urun.getDigerleri().Remove(to);
                            }
                        }
                        if ( i==urun.getDigerleri().Count && !bulundu)
                        {
                            if((urun.getMiktar() - Convert.ToInt32(txt_UrunSayisi.Text)>=0)){
                                urun.setMarka(urun.getMarka());
                                urun.setModel(urun.getModel());
                                urun.setMiktar(urun.getMiktar() - Convert.ToInt32(txt_UrunSayisi.Text));
                                urun.setSatisFiyatı(urun.getSatisFiyatı());
                                urun.setMaliyet(urun.getMaliyet());
                                maliyetTop += Convert.ToInt32(txt_UrunSayisi.Text) * urun.getMaliyet();
                                satilanTop += Convert.ToInt32(txt_UrunSayisi.Text) * (urun.getSatisFiyatı() - urun.getMaliyet());
                                satisTop += Convert.ToInt32(txt_UrunSayisi.Text) * urun.getSatisFiyatı();
                                MessageBox.Show("Toplam Kar: " + satilanTop + "\n Toplam Maliyet: " + maliyetTop + "\n Toplam Satis Fiyati: " + satisTop);
                            if((urun.getMiktar() - Convert.ToInt32(txt_UrunSayisi.Text)==0))
                                urun.getDigerleri().RemoveAt(0);
                            return;
                            }
                            else
                            {
                                MessageBox.Show("Stok yetersiz.");
                            }

                        }
                    }
                    
                }
                else
                {
                    urun.setMiktar(urun.getMiktar() - Convert.ToInt32(txt_UrunSayisi.Text));
                    if (urun.getMiktar() <= 0)
                    {
                        bst.delete(urun.getUrunAdi());
                    }
                }


            }
        }

        private void txt_AnahtarKelime_TextChanged(object sender, EventArgs e)
        {
            if(txt_AnahtarKelime.Text != "")
            {
                txt_Kategori.Enabled = false;
                txt_UrunSayisi.Enabled = false;
                txt_urunAdiAra.Enabled = false;
                txt_FiyatAraligi1.Enabled = false;
                txt_fiyatAraligi2.Enabled = false;
            }
            else
            {
                txt_Kategori.Enabled = true;
                txt_UrunSayisi.Enabled = true;
                txt_urunAdiAra.Enabled = true;
                txt_FiyatAraligi1.Enabled = true;
                txt_fiyatAraligi2.Enabled = true;
            }
        }

        private void txt_FiyatAraligi1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txt_fiyatAraligi2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
