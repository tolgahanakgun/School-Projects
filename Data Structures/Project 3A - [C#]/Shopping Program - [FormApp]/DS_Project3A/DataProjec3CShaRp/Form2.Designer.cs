namespace DataProjec3CShaRp
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.lstView_KullaniciArama = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txt_urunAdiAra = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_fiyatAraligi2 = new System.Windows.Forms.TextBox();
            this.txt_FiyatAraligi1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Ara = new System.Windows.Forms.Button();
            this.lbl_Derinlik = new System.Windows.Forms.Label();
            this.txt_Derinlik = new System.Windows.Forms.TextBox();
            this.lbl_ElemanSayisi = new System.Windows.Forms.Label();
            this.txt_ElemanSayisi = new System.Windows.Forms.TextBox();
            this.btn_SatinAl = new System.Windows.Forms.Button();
            this.txt_Kategori = new System.Windows.Forms.TextBox();
            this.txt_AnahtarKelime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_UrunSayisi = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lstView_KullaniciArama
            // 
            this.lstView_KullaniciArama.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader2,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.lstView_KullaniciArama.FullRowSelect = true;
            this.lstView_KullaniciArama.GridLines = true;
            this.lstView_KullaniciArama.Location = new System.Drawing.Point(12, 165);
            this.lstView_KullaniciArama.Name = "lstView_KullaniciArama";
            this.lstView_KullaniciArama.Size = new System.Drawing.Size(805, 236);
            this.lstView_KullaniciArama.TabIndex = 7;
            this.lstView_KullaniciArama.UseCompatibleStateImageBehavior = false;
            this.lstView_KullaniciArama.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Adı";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Kategori";
            this.columnHeader3.Width = 99;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Marka";
            this.columnHeader4.Width = 84;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Model";
            this.columnHeader5.Width = 79;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Miktar";
            this.columnHeader6.Width = 81;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Maliyet";
            this.columnHeader2.Width = 85;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Satış Fiyatı";
            this.columnHeader7.Width = 102;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Açıklama";
            this.columnHeader8.Width = 113;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Düzey";
            this.columnHeader9.Width = 77;
            // 
            // txt_urunAdiAra
            // 
            this.txt_urunAdiAra.Location = new System.Drawing.Point(123, 18);
            this.txt_urunAdiAra.Name = "txt_urunAdiAra";
            this.txt_urunAdiAra.Size = new System.Drawing.Size(232, 22);
            this.txt_urunAdiAra.TabIndex = 1;
            this.txt_urunAdiAra.TextChanged += new System.EventHandler(this.txt_UrunAdiAra_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "Ürün Adı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 14);
            this.label2.TabIndex = 9;
            this.label2.Text = "Fiyat Aralığı";
            // 
            // txt_fiyatAraligi2
            // 
            this.txt_fiyatAraligi2.Location = new System.Drawing.Point(252, 46);
            this.txt_fiyatAraligi2.Name = "txt_fiyatAraligi2";
            this.txt_fiyatAraligi2.Size = new System.Drawing.Size(103, 22);
            this.txt_fiyatAraligi2.TabIndex = 3;
            this.txt_fiyatAraligi2.TextChanged += new System.EventHandler(this.txt_fiyatAraligi2_TextChanged);
            this.txt_fiyatAraligi2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_fiyatAraligi2_KeyPress);
            // 
            // txt_FiyatAraligi1
            // 
            this.txt_FiyatAraligi1.Location = new System.Drawing.Point(123, 46);
            this.txt_FiyatAraligi1.Name = "txt_FiyatAraligi1";
            this.txt_FiyatAraligi1.Size = new System.Drawing.Size(103, 22);
            this.txt_FiyatAraligi1.TabIndex = 2;
            this.txt_FiyatAraligi1.TextChanged += new System.EventHandler(this.txt_FiyatAraligi1_TextChanged);
            this.txt_FiyatAraligi1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_FiyatAraligi1_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "Kategori";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "Anahtar Kelime";
            // 
            // btn_Ara
            // 
            this.btn_Ara.Location = new System.Drawing.Point(252, 130);
            this.btn_Ara.Name = "btn_Ara";
            this.btn_Ara.Size = new System.Drawing.Size(103, 23);
            this.btn_Ara.TabIndex = 7;
            this.btn_Ara.Text = "Ara";
            this.btn_Ara.UseVisualStyleBackColor = true;
            this.btn_Ara.Click += new System.EventHandler(this.btn_Ara_Click);
            // 
            // lbl_Derinlik
            // 
            this.lbl_Derinlik.AutoSize = true;
            this.lbl_Derinlik.Location = new System.Drawing.Point(9, 418);
            this.lbl_Derinlik.Name = "lbl_Derinlik";
            this.lbl_Derinlik.Size = new System.Drawing.Size(63, 14);
            this.lbl_Derinlik.TabIndex = 9;
            this.lbl_Derinlik.Text = "Derinlik";
            this.lbl_Derinlik.Visible = false;
            // 
            // txt_Derinlik
            // 
            this.txt_Derinlik.Location = new System.Drawing.Point(78, 415);
            this.txt_Derinlik.Name = "txt_Derinlik";
            this.txt_Derinlik.ReadOnly = true;
            this.txt_Derinlik.Size = new System.Drawing.Size(103, 22);
            this.txt_Derinlik.TabIndex = 9;
            this.txt_Derinlik.Visible = false;
            // 
            // lbl_ElemanSayisi
            // 
            this.lbl_ElemanSayisi.AutoSize = true;
            this.lbl_ElemanSayisi.Location = new System.Drawing.Point(213, 418);
            this.lbl_ElemanSayisi.Name = "lbl_ElemanSayisi";
            this.lbl_ElemanSayisi.Size = new System.Drawing.Size(98, 14);
            this.lbl_ElemanSayisi.TabIndex = 9;
            this.lbl_ElemanSayisi.Text = "Eleman Sayısı";
            this.lbl_ElemanSayisi.Visible = false;
            // 
            // txt_ElemanSayisi
            // 
            this.txt_ElemanSayisi.Location = new System.Drawing.Point(317, 415);
            this.txt_ElemanSayisi.Name = "txt_ElemanSayisi";
            this.txt_ElemanSayisi.ReadOnly = true;
            this.txt_ElemanSayisi.Size = new System.Drawing.Size(103, 22);
            this.txt_ElemanSayisi.TabIndex = 10;
            this.txt_ElemanSayisi.Visible = false;
            // 
            // btn_SatinAl
            // 
            this.btn_SatinAl.Location = new System.Drawing.Point(714, 414);
            this.btn_SatinAl.Name = "btn_SatinAl";
            this.btn_SatinAl.Size = new System.Drawing.Size(103, 23);
            this.btn_SatinAl.TabIndex = 8;
            this.btn_SatinAl.Text = "Satın Al";
            this.btn_SatinAl.UseVisualStyleBackColor = true;
            this.btn_SatinAl.Click += new System.EventHandler(this.btn_SatinAl_Click);
            // 
            // txt_Kategori
            // 
            this.txt_Kategori.Location = new System.Drawing.Point(124, 102);
            this.txt_Kategori.Name = "txt_Kategori";
            this.txt_Kategori.Size = new System.Drawing.Size(231, 22);
            this.txt_Kategori.TabIndex = 5;
            this.txt_Kategori.TextChanged += new System.EventHandler(this.txt_Kategori_TextChanged);
            // 
            // txt_AnahtarKelime
            // 
            this.txt_AnahtarKelime.Location = new System.Drawing.Point(124, 74);
            this.txt_AnahtarKelime.Name = "txt_AnahtarKelime";
            this.txt_AnahtarKelime.Size = new System.Drawing.Size(231, 22);
            this.txt_AnahtarKelime.TabIndex = 4;
            this.txt_AnahtarKelime.TextChanged += new System.EventHandler(this.txt_AnahtarKelime_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 14);
            this.label6.TabIndex = 9;
            this.label6.Text = "Adet";
            // 
            // txt_UrunSayisi
            // 
            this.txt_UrunSayisi.Location = new System.Drawing.Point(123, 130);
            this.txt_UrunSayisi.Name = "txt_UrunSayisi";
            this.txt_UrunSayisi.Size = new System.Drawing.Size(55, 22);
            this.txt_UrunSayisi.TabIndex = 6;
            this.txt_UrunSayisi.TextChanged += new System.EventHandler(this.txt_UrunSayisi_TextChanged);
            this.txt_UrunSayisi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_UrunSayisi_KeyPress);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 451);
            this.Controls.Add(this.txt_UrunSayisi);
            this.Controls.Add(this.txt_AnahtarKelime);
            this.Controls.Add(this.txt_Kategori);
            this.Controls.Add(this.btn_SatinAl);
            this.Controls.Add(this.btn_Ara);
            this.Controls.Add(this.txt_ElemanSayisi);
            this.Controls.Add(this.txt_Derinlik);
            this.Controls.Add(this.txt_FiyatAraligi1);
            this.Controls.Add(this.txt_fiyatAraligi2);
            this.Controls.Add(this.lbl_ElemanSayisi);
            this.Controls.Add(this.lbl_Derinlik);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_urunAdiAra);
            this.Controls.Add(this.lstView_KullaniciArama);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alış - Veriş";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstView_KullaniciArama;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.TextBox txt_urunAdiAra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_fiyatAraligi2;
        private System.Windows.Forms.TextBox txt_FiyatAraligi1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Ara;
        private System.Windows.Forms.Label lbl_Derinlik;
        private System.Windows.Forms.TextBox txt_Derinlik;
        private System.Windows.Forms.Label lbl_ElemanSayisi;
        private System.Windows.Forms.TextBox txt_ElemanSayisi;
        private System.Windows.Forms.Button btn_SatinAl;
        private System.Windows.Forms.TextBox txt_Kategori;
        private System.Windows.Forms.TextBox txt_AnahtarKelime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_UrunSayisi;
    }
}