using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CipherSuiteGUI
{
    class ShiftCipher
    {
        //by changing the alphabet you can encrypt different languages text
        //public static char[] alphabet;
        
        public ShiftCipher() 
        {

        }

        public string encrypt(char[] alphabet, string plainText, int shiftCount)
        {   
            
            char[] textArray = plainText.ToArray();
            for (int i = 0; i < textArray.Length; i++)
                textArray[i] = alphabet[Modulo.mod((Array.IndexOf(alphabet, textArray[i]) + (shiftCount)), alphabet.Length)];
            return new string(textArray);
        }

        public string decrypt(char[] alphabet, string cipherText, int shiftCount) 
        {
            char[] textArray = cipherText.ToArray();
            for (int i = 0; i < textArray.Length; i++)
                textArray[i] = alphabet[Modulo.mod((Array.IndexOf(alphabet, textArray[i]) - (shiftCount)), alphabet.Length)];
            return new string(textArray);
        }
        //public char[] getAlphabet() { return alphabet; }
    }
}
