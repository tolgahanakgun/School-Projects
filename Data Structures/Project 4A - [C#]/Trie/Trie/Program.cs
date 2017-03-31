using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Trie
{
    static class Global
    {
        private static PrefixTree Ptree = new PrefixTree();

        public static PrefixTree PTREE
        {
            get { return Ptree; }
        }
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
