using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CipherSuiteGUI
{
    class Modulo
    {   
        //This method is for negative integers modulo operation
        public static int mod(int a, int b) {return ((a%b)+b) % b;}
    }
}
