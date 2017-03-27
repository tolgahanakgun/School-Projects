using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CipherSuiteGUI
{
    class VigenéreCipher
    {
        private static string key = "";
        public string Encrypt(char[] alphabet, string password, string text)
        {
            extendKey(password, text.Length);
            string res = "";
            int index = 0;
            foreach (char ch in text)
                res += alphabet[ Modulo.mod(Array.IndexOf(alphabet, ch) + Array.IndexOf(alphabet, key[index++]),alphabet.Length)];
            return res;
        }

        public string Decrypt(char[] alphabet, string password, string text)
        {
            extendKey(password, text.Length);
            string res = "";
            int index = 0;
            foreach (char ch in text)
                res += alphabet[Modulo.mod(Array.IndexOf(alphabet, ch) - Array.IndexOf(alphabet, key[index++]), alphabet.Length)];
            return res;
        }

        private void extendKey(string password, int length)
        {
            key = "";
            for (int i = 0; i < length; i++)
                key += password[i % password.Length];
            
        }
    }
}
