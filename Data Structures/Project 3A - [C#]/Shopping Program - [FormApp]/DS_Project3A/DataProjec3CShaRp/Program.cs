using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Collections;

namespace DataProjec3CShaRp
{
    static class Global
    {
        private static BSTUrun bst = new BSTUrun();
        //private static Heap heap = new Heap();
        private static Dictionary<string, List<Urun>> dt = new Dictionary<string, List<Urun>>();
        private static Hasher hs = new Hasher();
        private static int satilanTop = new int();
        //private static int maliyetTop = new int();

        public static BSTUrun BST
        {
            get { return bst; }
        }

        

        public static int ST
        {
            get { return satilanTop; }
        }

        public static Dictionary<string, List<Urun>> DT
        {
            get { return dt; }
        }

        public static Hasher HS
        {
            get
            {
                return hs;
            }
        }
    }

    static class Program
    {
        [STAThread]
        static void Main()
        {          
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form3()); 
        }
    }
}
