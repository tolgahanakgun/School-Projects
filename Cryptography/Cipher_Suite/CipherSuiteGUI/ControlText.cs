using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CipherSuiteGUI
{
    class ControlText
    {
        //This method is for controlling whether the text suit the alphabet or not 
        public static bool suitsAlphabet(char[] alphabet, char[] text)
        {   
            int i;
            for (i = 0; i < text.Length && alphabet.Contains(text[i]); i++) { }
            if (i == text.Length)
                return true;
            return false;
        }
    }
}
