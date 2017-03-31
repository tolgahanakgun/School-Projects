using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trie
{
    class TrieNode
    {
        public char letter;
        public TrieNode[] links;
        public bool fullWord;

        public TrieNode(char letter)
        {
            this.letter = letter;
            links = new TrieNode[512];//türkçe karakterlerin ascii tablosundaki yerinin sıkıntı çıkarmasından dolayı burası 256 yapıldı
            this.fullWord = false;          //alfabedeki harf sayısı kadar olması yeterliydi
        }
    }
}
