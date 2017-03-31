using System;
using System.Collections;
using System.Collections.Generic;
namespace DataProject4_Graphs
{
    internal class Algorithms
    {
        private int minDistance(int[] dist, bool[] sptSet,int MAX)
        {
           int min = Int16.MaxValue, min_index=0;
           for (int v = 0; v < MAX; v++)
               if (sptSet[v] == false && dist[v] <= min)
               {
                   min = dist[v];
                   min_index = v;
                }
           return min_index;
        }

        public int dijkstra(int[,] graph, int MAX, int src, int dest)
        {
            int[] dist = new int[MAX];
            bool[] sptSet = new bool[MAX];
             for (int i = 0; i < MAX; i++)
             {
                 dist[i] = Int16.MaxValue;
                 sptSet[i] = false;
             }
             dist[src] = 0;
             for (int count = 0; count < MAX-1; count++)
             {
               int u = minDistance(dist, sptSet,MAX);
               sptSet[u] = true;
               for (int v = 0; v < MAX; v++)
                   if (!sptSet[v] && (graph[u, v] != null) && dist[u] != Int16.MaxValue
                                               && dist[u]+graph[u,v] < dist[v])
                    dist[v] = dist[u] + graph[u,v];
             }
             return dist[dest];
        }

        public void DFS(int[,] graph, int MAX, int src)
        {
            bool[] visited = new bool[MAX];
            DFS(graph, visited, MAX, src);
        }

        private void DFS(int[,] graph, bool[] visited, int MAX, int src)
        {
            Console.WriteLine("Şuan " + src + "nci tepeyi dolaştık.");
            visited[src] = true;
            for (int i = 0; i < MAX; i++)
                if (graph[src, i] < Int16.MaxValue && !visited[i])//aradaki mesafe sonsuz değilse ve o köşe daha önce dolaşılmadıysa
                    DFS(graph, visited, MAX, i);                            //recursive olarak kökü o anki değer olarak fonksiyon tekrar çağırılır

        }

        public int[,] floydWarshell (int[,] graph, int MAX)
        {
            int[,] dist = new int[MAX,MAX];
            int   i, j, k;
 
            for (i = 0; i < MAX; i++)
                for (j = 0; j < MAX; j++)
                    dist[i,j] = graph[i,j];

            for (k = 0; k < MAX; k++)
                for (i = 0; i < MAX; i++)
                    for (j = 0; j < MAX; j++)
                        if (dist[i,k] + dist[k,j] < dist[i,j])
                            dist[i,j] = dist[i,k] + dist[k,j];
            return dist;
        }

        public Queue<int> BFS(int[,] graph, int MAX, int src)//dolaşılacak elemanların sırasını kuyruk şeklinde döndürür
        {                                                                                   //src dolaşmaya başlanacak nokta
            bool[] visited = new bool[MAX];
            Queue<int> queue = new Queue<int>();
            Queue<int> dolasmaSirasi = new Queue<int>();
            queue.Enqueue(src);
            visited[src] = true;
            dolasmaSirasi.Enqueue(src);
            while (queue.Count != 0)
            {
               int gecici=queue.Dequeue();
               for (int i = 0; i < MAX; i++)
               {
                   if (graph[gecici, i] < Int16.MaxValue && !visited[i])
                   {
                       dolasmaSirasi.Enqueue(i);
                       visited[i] = true;
                       queue.Enqueue(i);
                    }
                }
            }
            return dolasmaSirasi;
        }
    }
}