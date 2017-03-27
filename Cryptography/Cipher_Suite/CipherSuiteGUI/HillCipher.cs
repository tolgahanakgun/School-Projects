using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathNet.Numerics.LinearAlgebra;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra.Double;

namespace CipherSuiteGUI
{
    class HillCipher
    {
        private string plainText = null;
        private Matrix<double> key = null;
        private Dictionary<char, int> alphabet = null;

        public string Encrypt(Matrix<double> matrix, char[] alphabet, String stream)
        {
            plainText = stream;
            this.key = matrix;
            comleteTheStream();
            this.alphabet = convert(alphabet);
            string ciphered = "";
            foreach (string str in Split(key, plainText))
                ciphered += matrixToString((stringToMatrix(str, key.RowCount) * key).Modulus(alphabet.Count()));
            return ciphered;
        }

        public string Decrypt(Matrix<double> matrix, char[] alphabet, String stream)
        {
            plainText = stream;
            int det = (int)matrix.Determinant();
            key = matrix.Determinant() * matrix.Inverse();
            key.CoerceZero(0.0001);
            key = ((int)(modInverse((BigInteger)det, (BigInteger)alphabet.Length)) * key).Modulus(alphabet.Length);
            this.alphabet = convert(alphabet);
            string ciphered = "";
            comleteTheStream();
            foreach (string str in Split(key, plainText))
                ciphered += matrixToString((stringToMatrix(str, key.RowCount) * key).Modulus(alphabet.Count()));
            return ciphered;
        }

        private void comleteTheStream()
        {
            if (plainText.Length % key.RowCount == 0)
                return;
            else
            {
                while (plainText.Length < key.RowCount || plainText.Length % key.RowCount != 0)
                {
                    plainText += 'z';
                }
            }
        }

        private List<string> Split(Matrix<double> key, string stream)
        {
            int chunkSize = key.RowCount;
            List<string> lst = new List<string>();
            for (int i = 0; i < stream.Length; i += chunkSize)
                lst.Add(stream.Substring(i, chunkSize));
            return lst;
        }


        private Matrix stringToMatrix(string plainText, int size)
        {
            double[] values = new double[size];
            int index = 0;
            foreach (char ch in plainText)
                values[index++] = alphabet[ch];
            return new DenseMatrix(1, size, values);
        }

        private string matrixToString(Matrix<double> m)
        {
            int[] values = new int[m.ColumnCount];
            int index = 0;
            foreach (double d in m.Enumerate())
                values[index++] = (int)Math.Round(d, 0, MidpointRounding.AwayFromZero);
            string str = "";
            foreach (int db in values)
                str += alphabet.Keys.ElementAt(db);
            return str;
        }

        private Dictionary<char, int> convert(char[] alphabet)
        {
            Dictionary<char, int> dictionary = new Dictionary<char, int>();
            for (int i = 0; i < alphabet.Length; i++)
            {
                dictionary.Add(alphabet[i], i);
            }
            return dictionary;
        }

        static BigInteger modInverse(BigInteger a, BigInteger n)
        {
            BigInteger i = n, v = 0, d = 1;
            while (a < 0)
                a += n;
            while (a > 0)
            {
                BigInteger t = i / a, x = a;
                a = i % x;
                i = x;
                x = d;
                d = v - t * x;
                v = x;
            }
            v %= n;
            if (v < 0) v = (v + n) % n;
            return v;
        }
    }
}
