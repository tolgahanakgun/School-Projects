using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Trie
{
    public partial class Form1 : Form
    {
        PrefixTree Ptree = Global.PTREE;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] str = richTextBox1.Text.ToString().Split(',', ' ', '.', ';', '?', '!', ':','(',')','{','}', '[',']','=','*','+','/','\\','%','_','&','\n');
            for(int i=0;i<str.Length;i++)
            {
                if (!Ptree.find(Ptree.getRoot(), str[i].ToLower()))
                    Ptree.insertWord(Ptree.getRoot(), str[i].ToLower());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.ToString() == "")
                MessageBox.Show("Yukarıda kutuya bir metin giriniz !");
            else
            {
                if (textBox1.Text.ToString() == "")
                    MessageBox.Show("Aranacak kelime bülümüne bir kelime giriniz !");
                else
                {
                    if (Ptree.find(Ptree.getRoot(), textBox1.Text.ToString().ToLower()))
                        MessageBox.Show("'" + textBox1.Text.ToString() + "'" + " kelimesi bu metinde bulunmaktadır !");
                    else
                        MessageBox.Show("'"+textBox1.Text.ToString()+"'" + " kelimesi bu metinde bulunmamaktadır !");
                }
            }
        }
    }
}
