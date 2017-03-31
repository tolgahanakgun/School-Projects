using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DataProject4_Graphs
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            int INFINITE = Int16.MaxValue;

            int[,] cost = new int[6, 6] {{INFINITE,12,9,7,INFINITE,INFINITE},
                                                     {12,INFINITE,INFINITE,8,5,INFINITE},
                                                      {9,INFINITE,INFINITE,4,INFINITE,15},
                                                      {7,8,4,INFINITE,6,16},
                                                      {INFINITE,5,INFINITE,6,INFINITE,10},
                                                      {INFINITE,INFINITE,15,16,10,INFINITE}};
            
            Algorithms algorithms = new Algorithms();
           // Console.WriteLine( algorithms.dijkstra(cost, 6, 2, 4));
            //algorithms.DFS(cost, 6);
            //algorithms.DFS(cost, 6, 0);
           // algorithms.BFS(cost, 0, 6);
           /* int[] gecici=algorithms.BFS(cost, 6, 2);
            for (int i = 0; i < gecici.Length; i++)
                Console.WriteLine(gecici[i]);
                /*int[,] gecici=algorithms.floydWarshell(cost,6);
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                        Console.Write(gecici[i, j] + " ");
                    Console.WriteLine();
                }*/
            Queue<int> gecici = algorithms.BFS(cost, 6, 0);
            int gecicii=0;
            while(gecici.Count!=0)
            {
                try
                {
                    gecicii = gecici.Dequeue();
                }
                catch (IndexOutOfRangeException) { }
                Console.WriteLine(gecicii);
            }
            

                Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}