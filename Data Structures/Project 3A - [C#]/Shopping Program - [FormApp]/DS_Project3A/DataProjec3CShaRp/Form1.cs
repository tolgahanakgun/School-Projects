using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace DataProjec3CShaRp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        BSTUrun bst = Global.BST;
        Dictionary<string, List<Urun>> dt = Global.DT;
        int satilanTop = Global.ST;

        //int satilanTop;
        //int satilanMaliyet;

        private void btn_YeniEkle_Click(object sender, EventArgs e)
        {
            if (txt_Dosya.Text != "")
            {
                //Dictionary<string, List<Urun>> dt = new Dictionary<string, List<Urun>>();

                UrunTXTReader reader = new UrunTXTReader();
                try
                {
                    reader.fromTxtToTree(txt_Dosya.Text, bst, dt);
                    MessageBox.Show("Ürünler başarıyla eklendi.");
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine("[Data File Missing] {0}", ex);
                    throw new FileNotFoundException(@"[urunler.txt not in c:\temp directory]", ex);
                }
            }
            else
            {
                Dictionary<string, List<Urun>> dt = new Dictionary<string, List<Urun>>();
                char[] delimiterChars = {'\'', ','};

                if(!bst.contains(txt_UrunAdi.Text))
                {
                    Urun urun = new Urun();

                    urun.setUrunAdi(txt_UrunAdi.Text);
                    urun.setUrunKategori(txt_UrunKategori.Text);
                    urun.setMarka(txt_UrunMarka.Text);
                    urun.setModel(txt_UrunModel.Text);
                    urun.setMiktar(Convert.ToInt32(txt_UrunMiktar.Text));
                    urun.setMaliyet(Convert.ToInt32(txt_UrunMaliyet.Text));
                    urun.setSatisFiyatı(Convert.ToInt32(txt_UrunSatisFiyati.Text));

                    string[] words = txt_UrunAciklama.Text.Split(delimiterChars);
                    List<string> lst = new List<string>();
                    foreach (string str in words)
                    {
                        if (str == null) break;

                        lst.Add(str);

                        if (!dt.ContainsKey(str))
                        {
                            List<Urun> hList = new List<Urun>();
                            hList.Add(urun);
                            dt.Add(str, hList);
                        }
                        else
                            dt[str].Add(urun);
                    }
                    urun.setAciklama(lst);
                    bst.put(urun);
                    MessageBox.Show(txt_UrunAdi.Text + " ürünü başarıyla eklendi.");
                    temizle();
                }
                else
                {
                    Urun urun = new Urun();
                    urun = bst.get(txt_UrunAdi.Text);

                    List<TheOthers> digerleri = new List<TheOthers>();
                    TheOthers to = new TheOthers();
                    to.setMarka(txt_UrunMarka.Text);
                    to.setModel(txt_UrunModel.Text);
                    to.setMiktar(Convert.ToInt32(txt_UrunMiktar.Text));
                    to.setMaliyet(Convert.ToInt32(txt_UrunMaliyet.Text));
                    to.setSatisFiyatı(Convert.ToInt32(txt_UrunSatisFiyati.Text));

                    string[] words = txt_UrunAciklama.Text.Split(delimiterChars);
                    List<string> lst = new List<string>();
                    foreach (string str in words)
                    {
                        if (str == null) break;

                        lst.Add(str);

                        if (!dt.ContainsKey(str))
                        {
                            List<Urun> hList = new List<Urun>();
                            hList.Add(urun);
                            dt.Add(str, hList);
                        }
                        else
                            dt[str].Add(urun);
                    }
                    to.setAciklama(lst);

                    digerleri.Add(to);
                    urun.setDigerleri(digerleri);
                    MessageBox.Show(txt_UrunAdi.Text + " ürünü başarıyla eklendi.");
                    temizle();
                }
            }
        }

        OpenFileDialog ofd = new OpenFileDialog();

        private void btn_DosyaSec_Click(object sender, EventArgs e)
        {
            ofd.Filter = "Text Files (*.txt)|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //System.IO.FileInfo File = new System.IO.FileInfo(ofd.FileName);
                UrunTXTReader reader = new UrunTXTReader();
                //reader.fromTxtToTree(ofd.FileName,bst,dt);
                txt_Dosya.Text = ofd.FileName;
            }
        }

        private void txt_Dosya_TextChanged(object sender, EventArgs e)
        {
            if (txt_Dosya.Text != "")
            {
                grpBox_UrunEkle.Enabled = false;
            }
            else
                grpBox_UrunEkle.Enabled = true;
        }

        public void temizle()
        {
            txt_UrunAdi.Clear();
            txt_UrunAciklama.Clear();
            txt_UrunKategori.Clear();
            txt_UrunMaliyet.Clear();
            txt_UrunMarka.Clear();
            txt_UrunMiktar.Clear();
            txt_UrunModel.Clear();
            txt_UrunSatisFiyati.Clear();
        }

        private void btn_UrunAra_Click(object sender, EventArgs e)
        {
            lstView_UrunSil.Items.Clear();

            if (txt_UrunAdiAra.Text != "")
            {
                if (bst.contains(txt_UrunAdiAra.Text))
                {
                    Urun urun = new Urun();

                    urun = bst.get(txt_UrunAdiAra.Text);
                    
                    ListViewItem lvi = new ListViewItem(urun.getUrunAdi());

                    lvi.SubItems.Add(urun.getUrunKategori());
                    lvi.SubItems.Add(urun.getMarka());
                    lvi.SubItems.Add(urun.getModel());
                    lvi.SubItems.Add(urun.getMiktar().ToString());
                    lvi.SubItems.Add(urun.getMaliyet().ToString());
                    lvi.SubItems.Add(urun.getSatisFiyatı().ToString());

                    string[] aciklamaDizi = urun.getAciklama().ToArray();

                    lvi.SubItems.Add(string.Join(",", aciklamaDizi));

                    lstView_UrunSil.Items.Add(lvi);

                    ListViewItem lvi2 = new ListViewItem(urun.getUrunAdi());

                    if(urun.getDigerleri() != null)
                        foreach(TheOthers to in urun.getDigerleri())
                        {
                            lvi2.SubItems.Add(urun.getUrunKategori());
                            lvi2.SubItems.Add(to.getMarka());
                            lvi2.SubItems.Add(to.getModel());
                            lvi2.SubItems.Add(to.getMiktar().ToString());
                            lvi2.SubItems.Add(to.getMaliyet().ToString());
                            lvi2.SubItems.Add(to.getSatisFiyatı().ToString());

                            aciklamaDizi = to.getAciklama().ToArray();

                            lvi2.SubItems.Add(string.Join(",",aciklamaDizi));

                            lstView_UrunSil.Items.Add(lvi2);
                        }
                }
                else
                    MessageBox.Show("Aranan ürün bulunamadı.");
            }
            else
                MessageBox.Show("Lütfen aranacak ürünün adını giriniz!");
        }

        private void txt_UrunMiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txt_UrunMaliyet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txt_UrunSatisFiyati_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void btn_UrunSil_Click(object sender, EventArgs e)
        {
            try
            {
                Urun urun = new Urun();
                string silinen = lstView_UrunSil.SelectedItems[0].SubItems[0].Text;
                urun = bst.get(silinen);

                foreach(TheOthers to in urun.getDigerleri())
                {
                    if(to.getMarka() == lstView_UrunSil.SelectedItems[0].SubItems[2].Text)
                    {
                        urun.getDigerleri().Remove(to);
                        MessageBox.Show(silinen + " ürünü silindi.");
                        return;
                    }
                }

                bst.delete(silinen);
                MessageBox.Show(silinen + " ürünü silindi.");
                lstView_UrunSil.Items.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Beklenmeyen bir sorunla karşılaşıldı ve ürün silinemedi","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }            
        }

        private void btn_UrunGuncelle_Click(object sender, EventArgs e)
        {           
            Urun urun = new Urun();
            string urunAdi = lstView_Guncelle.SelectedItems[0].SubItems[0].Text;
            urun = bst.get(urunAdi);

            if(urun.getDigerleri() == null)
            {
                Dictionary<string, List<Urun>> dt = new Dictionary<string, List<Urun>>();
                char[] delimiterChars = { '~', ',' };

                urun.setUrunKategori(txt_GuncelUrunKategori.Text);
                urun.setMarka(txt_GuncelUrunMarka.Text);
                urun.setModel(txt_GuncelUrunModel.Text);
                urun.setMiktar(Convert.ToInt32(txt_GuncelUrunMiktar.Text));
                urun.setMaliyet(Convert.ToInt32(txt_GuncelUrunMaliyet.Text));
                urun.setSatisFiyatı(Convert.ToInt32(txt_GuncelUrunSatisFiyati.Text));

                MessageBox.Show(urunAdi + " ürünü başarıyla güncellendi.");
            }
            else
            {
                foreach(TheOthers to in urun.getDigerleri())
                {
                    if(to.getMarka() == lstView_Guncelle.SelectedItems[0].SubItems[2].Text)
                    {
                        urun.setUrunKategori(txt_GuncelUrunKategori.Text);
                        to.setMarka(txt_GuncelUrunMarka.Text);
                        to.setModel(txt_GuncelUrunModel.Text);
                        to.setMiktar(Convert.ToInt32(txt_GuncelUrunMiktar.Text));
                        to.setMaliyet(Convert.ToInt32(txt_GuncelUrunMaliyet.Text));
                        to.setSatisFiyatı(Convert.ToInt32(txt_GuncelUrunSatisFiyati.Text));

                        MessageBox.Show(urunAdi + " ürünü başarıyla güncellendi.");
                    }
                }
            }            
        }

        /*private void Form1_Load(object sender, EventArgs e)
        {
            txt_Gelir.Text = satilanTop.ToString();
            txt_Gider.Text = satilanMaliyet.ToString();
            txt_Kar.Text = (satilanTop - satilanMaliyet).ToString();
        }

        private void btn_Guncelle_Click(object sender, EventArgs e)
        {
            txt_Gelir.Text = Global.ST.ToString();
            txt_Gider.Text = Global.ST.ToString();
            txt_Kar.Text = (satilanTop - satilanMaliyet).ToString();
        }*/

        private void btn_GuncelleAra_Click(object sender, EventArgs e)
        {
            lstView_Guncelle.Items.Clear();

            if (txt_GuncelleUrunAdi.Text != "")
            {
                if (bst.contains(txt_GuncelleUrunAdi.Text))
                {
                    Urun urun = new Urun();

                    urun = bst.get(txt_GuncelleUrunAdi.Text);

                    ListViewItem lvi = new ListViewItem(urun.getUrunAdi());

                    lvi.SubItems.Add(urun.getUrunKategori());
                    lvi.SubItems.Add(urun.getMarka());
                    lvi.SubItems.Add(urun.getModel());
                    lvi.SubItems.Add(urun.getMiktar().ToString());
                    lvi.SubItems.Add(urun.getMaliyet().ToString());
                    lvi.SubItems.Add(urun.getSatisFiyatı().ToString());

                    string[] aciklamaDizi = urun.getAciklama().ToArray();

                    lvi.SubItems.Add(string.Join(",", aciklamaDizi));

                    lstView_Guncelle.Items.Add(lvi);

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

                            lstView_Guncelle.Items.Add(lvi2);
                        }
                }
                else
                    MessageBox.Show("Aranan ürün bulunamadı.");
            }
            else
                MessageBox.Show("Lütfen aranacak ürünün adını giriniz!");
        }
    }
}
