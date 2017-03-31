using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trie
{
    class PrefixTree
    {
        TrieNode root;

        public PrefixTree()
        {
            root = new TrieNode('\0');
        }

        public TrieNode getRoot() { return root; }

        public void insertWord(TrieNode root, String word)
        {
            int l = word.Length;
            char[] letters = word.ToCharArray();
            TrieNode curNode = root;

            for (int i = 0; i < l; i++)
            {
                if (curNode.links[letters[i]] == null)
                    curNode.links[letters[i]] = new TrieNode(letters[i]);
                curNode = curNode.links[letters[i]];
            }
            curNode.fullWord = true;
        }

        public bool find(TrieNode root, String word)
        {
            char[] letters = word.ToCharArray();
            int l = letters.Length;
            TrieNode curNode = root;

            int i;
            for (i = 0; i < l; i++)
            {
                if (curNode == null)
                    return false;
                curNode = curNode.links[letters[i]];
            }

            if (i == l && curNode == null)
                return false;

            if (curNode != null && !curNode.fullWord)
                return false;

            return true;
        }

        public void printTree(TrieNode root, int level, char[] branch)
        {
            if (root == null)
                return;

            for (int i = 0; i < root.links.Length; i++)
            {
                branch[level] = root.letter;
                printTree(root.links[i], level + 1, branch);
            }

            if (root.fullWord)
            {
                for (int j = 1; j <= level; j++)
                    Console.Write(branch[j]);
                Console.WriteLine();
            }
        }
    }
}
