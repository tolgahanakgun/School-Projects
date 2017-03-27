using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra;

/* Math.NET Numerics License (MIT/X11)
 * ===================================
 * 
 * Copyright (c) 2002-2015 Math.NET
 * 
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 * 
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 */ 

namespace CipherSuiteGUI
{
    public partial class Form1 : Form
    {
        ShiftCipher shiftCipher = new ShiftCipher();
        HillCipher hillCipher = new HillCipher();
        Steganography steganography = new Steganography();
        VigenéreCipher vigenéreCipher = new VigenéreCipher();

        char[] alphabet = Alphabet.English;
        Bitmap bitmap = null;
        string oldPicPath = "";
        string newPicPath = "";
        string picPath = "";
        int shiftCount = 3;

        public Form1()
        {
            InitializeComponent();
            for(int i = 0; i<10;i++)
                dataGridView1.Rows.Add("0","0","0","0","0","0","0","0","0","0");
            comboBox1.SelectedIndex = 0;
            HillCipher hc = new HillCipher();
            readMatrixFromDGV(dataGridView1);
            comboBox3.Items.Clear();
            for (int i = 1; i < alphabet.Length; i++)
                comboBox3.Items.Add(i);
            comboBox3.MaxDropDownItems = 5;
            radioButton1.Checked = true;

        }

        private void btn_encrypt_Click(object sender, EventArgs e)
        {
            //convert the text to lower case in order not to cause ambiguity
            txtbox_plain.Text = txtbox_plain.Text.ToLower();
            if (txtbox_plain.Text == "")
                MessageBox.Show("Please enter plain text !");
            else if (ControlText.suitsAlphabet(alphabet, txtbox_plain.Text.ToCharArray()))
                txtbox_cipher.Text = shiftCipher.encrypt(alphabet, txtbox_plain.Text, shiftCount);
            else MessageBox.Show("Please check the text you entered !");
        }

        private void btn_decrypt_Click(object sender, EventArgs e)
        {
            //convert the text to lower case in order not to cause ambiguity
            txtbox_cipher.Text = txtbox_cipher.Text.ToLower();

            if (txtbox_cipher.Text == "")
                MessageBox.Show("Please enter plain text !");
            else if (ControlText.suitsAlphabet(alphabet, txtbox_cipher.Text.ToCharArray()))
                txtbox_plain.Text = shiftCipher.decrypt(alphabet, txtbox_cipher.Text, shiftCount);
            else MessageBox.Show("Please check the text you entered !");
        }


        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            
                dlg.Title = "Open Image";
                dlg.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png, *.bmp) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.bmp";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    picPath = dlg.FileName;
                    bitmap = new Bitmap(picPath);
                    pictureBox1.Image = bitmap;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.ToLower();
            steganography.embedText(textBox1.Text, bitmap);
            if (checkBox1.Checked)
            {
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = picPath.Substring(0, picPath.LastIndexOf('/') + 1);
                savefile.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png, *.bmp) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.bmp";
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    bitmap.Save(savefile.FileName);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text.ToLower();
            textBox2.Text = steganography.extractText(bitmap);
        }

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        private Matrix<double> readMatrixFromDGV(DataGridView dgv)
        {
            int n = Convert.ToInt16(comboBox1.SelectedItem.ToString());
            Matrix<double> values = new DenseMatrix(n, n);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    values[i,j] = Convert.ToDouble(dgv.Rows[i].Cells[j].Value.ToString());
            return values;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text.ToLower();
            if(textBox3.Text != "")
                textBox4.Text = hillCipher.Encrypt(readMatrixFromDGV(dataGridView1),
                                alphabet, textBox3.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox4.Text = textBox4.Text.ToLower();
            if (textBox4.Text != "")
                textBox3.Text = hillCipher.Decrypt(readMatrixFromDGV(dataGridView1),
                                alphabet, textBox4.Text);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            txt_box_NewAlphabet.Text = txt_box_NewAlphabet.Text.ToLower();
            alphabet = txt_box_NewAlphabet.Text.ToCharArray();
            textBox5.Text = new string(alphabet);
            comboBox3.Items.Clear();
            for (int i = 1; i < alphabet.Length; i++)
                comboBox3.Items.Add(i);
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            txt_box_NewAlphabet.Text = "";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0: alphabet = Alphabet.Turkish; break;
                case 1: alphabet = Alphabet.English; break;
                case 2: alphabet = Alphabet.French; break;
                case 3: alphabet = Alphabet.German; break;
            }
            textBox5.Text = new string(alphabet);
            txt_box_NewAlphabet.Text = "";
            comboBox3.Items.Clear();
            for (int i = 1; i < alphabet.Length; i++)
                comboBox3.Items.Add(i);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox6.Text = textBox6.Text.ToLower();
            if (textBox6.Text != "")
                textBox7.Text = vigenéreCipher.Encrypt(alphabet, textBox8.Text, textBox6.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox7.Text = textBox7.Text.ToLower();
            if (textBox7.Text != "")
                textBox6.Text = vigenéreCipher.Decrypt(alphabet, textBox8.Text, textBox7.Text);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                comboBox3.Enabled = false;
                label11.Enabled = false;
                shiftCount = 3;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                comboBox3.Enabled = true;
                label11.Enabled = true;
            }
            
        }

        private class Item
        {
            public string Name;
            public int Value;
            public Item(string name, int value)
            {
                Name = name; Value = value;
            }
            public override string ToString()
            {
                // Generates the text shown in the combo box
                return Name;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            shiftCount = Convert.ToInt16(comboBox3.SelectedIndex+1);
        }
    }
}
