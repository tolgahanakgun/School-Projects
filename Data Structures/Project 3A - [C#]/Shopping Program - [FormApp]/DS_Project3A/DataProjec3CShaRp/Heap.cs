using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataProjec3CShaRp
{
    public class Heap
    {
        private Urun[] A;
        private int last;
        private int capacity;

        public Heap()
        {
            A = new Urun[51];
            last = 0;
            capacity = 50;
        }

        public Heap(int cap)
        {
            A = new Urun[cap + 1];
            last = 0;
            capacity = cap;
        }

        //heapteki eleman sayısını döndürür
        public int size()
        {
            return last;
        }

        //heap boş mu ?
        public bool isEmpty()
        {
            return size() == 0;
        }

        //heapteki minimum elemanı döndürür
        public Urun min()
        {
            if (isEmpty())
                throw new ArgumentException();
            else
                return A[1];
        }

        //karşılaştırıcı fonksiyon
        private int compare(Urun x, Urun y)
        {
            if (x.getSatisFiyatı() > y.getSatisFiyatı())
                return 1;
            if (x.getSatisFiyatı() < y.getSatisFiyatı())
                return -1;
            return 0;
        }

        //heap e eleman ekler
        public void insert(Urun e)
        {
            if (size() == capacity)
                throw new StackOverflowException();
            else
            {
                last++;
                A[last] = e;
                upHeapBubble();
            }
        }

        //heapteki en küçük elemanı siler ve referansını döndürür
        public Urun removeMin()
        {
            if (isEmpty())
                throw new ArgumentNullException("Heap boş !");
            else
            {
                Urun minimum = min();
                A[1] = A[last];
                last--;
                downHeapBubble();
                return minimum;
            }
        }

        /**
         * downHeapBubble() method is used after the removeMin() method to reorder the elements
         * in order to preserve the Heap properties
         */
        private void downHeapBubble()
        {
            int index = 1;
            while (true)
            {
                int child = index * 2;
                if (child > size())
                    break;
                if (child + 1 <= size())
                {
                    //if there are two children -> take the smalles or
                    //if they are equal take the left one
                    child = findMin(child, child + 1);
                }
                if (compare(A[index], A[child]) <= 0)
                    break;
                swap(index, child);
                index = child;
            }
        }

        /**
         * upHeapBubble() method is used after the insert(E e) method to reorder the elements
         * in order to preserve the Heap properties 
         */
        private void upHeapBubble()
        {
            int index = size();
            while (index > 1)
            {
                int parent = index / 2;
                if (compare(A[index], A[parent]) >= 0)
                    //break if the parent is greater or equal to the current element
                    break;
                swap(index, parent);
                index = parent;
            }
        }

        private void swap(int i, int j)
        {
            Urun temp = A[i];
            A[i] = A[j];
            A[j] = temp;
        }

        private int findMin(int leftChild, int rightChild)
        {
            if (compare(A[leftChild], A[rightChild]) <= 0)
                return leftChild;
            else
                return rightChild;
        }
    }
}

