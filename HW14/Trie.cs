/*
 *Name: Hasnain Mazhar
 * CPTS 321
 * HW14 - Trie data structure
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW14
{
    //Node class
    class Node
    {
        public List<Node> m_children;
        public char c;
        public bool IsDone;
        //constructor
        public Node(char c)
        {
            m_children = new List<Node>();
            this.c = c;
        }
        //function that returns the character
        public Node GetChild(char c)
        {
            if(m_children.Count != 0)
            {
                foreach(var ch in m_children)
                {
                    if(ch.c == c)
                    {
                        return ch;
                    }
                }
            }
            return null;
        }
    }
    //Trie data structure class
    class Trie
    {
        private List<string> branches;
        private Node root;

        public Trie()
        {
            branches = new List<string>();
            root = new Node(' ');
        }

        private void makeBranches(Node node, string s)
        {
            if (node == null)
            {
                return;
            }

            s += node.c;

            if (node.IsDone)
            {
                branches.Add(s);
            }

            foreach(var n in node.m_children)
            {
                makeBranches(n, s);
            }
        }

        public List<string> GetWord(string s)
        {
            StringBuilder s_Builder = new StringBuilder();
            Node current = root;
            Node child = null;
            char[] char_Arr = s.ToCharArray();

            for(int i = 0; i < char_Arr.Length; i++)
            {
                if(i < char_Arr.Length -1)
                {
                    s_Builder.Append(char_Arr[i]);
                }

                child = current.GetChild(char_Arr[i]);

                if(child == null)
                {
                    break;
                }
                current = child;
            }

            branches.Clear();
            makeBranches(current, s_Builder.ToString());
            return branches;
        }

        public bool search(string s)
        {
            Node current = root;
            Node child = null;

            char[] char_Arr = s.ToCharArray();
            for(int i = 0; i < char_Arr.Length; i++)
            {
                child = current.GetChild(char_Arr[i]);
                if(child == null)
                {
                    return false;
                }
                current = child;
            }
            return true;
        }

        public void add_characters(string word)
        {
            Node current = root;
            Node child = null;

            char[] char_Arr = word.ToCharArray();
            for(int i = 0; i < char_Arr.Length; i++)
            {
                child = current.GetChild(word[i]);
                if(child == null)
                {
                    var newNode = new Node(word[i]);
                    current.m_children.Add(newNode);
                    current = newNode;
                }
                else
                {
                    current = child;
                }
                if(i == char_Arr.Length - 1)
                {
                    current.IsDone = true;
                }
            }

        }
    }
}
