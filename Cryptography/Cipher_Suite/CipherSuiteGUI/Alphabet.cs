using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CipherSuiteGUI
{
    class Alphabet
    {
        public static char[] Turkish = "abcçdefgğhıijklmnoöprsştuüvyz".ToCharArray();
        public static char[] English = "abcdefghijklmnopqrstuvwxyz".ToArray();
        public static char[] French = "abcdefghijklmnopqrstuvwxyzéèàùçâêîôûëï".ToCharArray();
        public static char[] German = "abcdefghijklmnopqrstuvwxyzäöüß".ToCharArray();
    }
}
