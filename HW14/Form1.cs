/*
 *Name: Hasnain Mazhar
 * CPTS 321
 * HW14 - Trie data structure
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HW14
{
    public partial class Form1 : Form
    {
        Trie Trie = new Trie();
        public Form1()
        {
            InitializeComponent();
            readFile();
        }
        //function that reads the file
        public void readFile()
        {
            string fileName = "wordsEn.txt";
            var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            try
            {
                //stream reader to open and read file
                using (var streamReader = new StreamReader(fileStream))
                {
                    string s = "";
                    while ((s = streamReader.ReadLine()) != null)
                    {
                        Trie.add_characters(s);
                    }
                }
                fileStream.Dispose();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Cannot open file: " + fileName + "\nMake sure the file is in Debug folder!");

            }
        }
        //function that search for the wordsand returns a list of it
        public void search(string prefix, List<string> words)
        {
            if(Trie.search(prefix) && !(string.IsNullOrEmpty(prefix)))
            {
                var matches = Trie.GetWord(prefix);
                if(matches.Count > 0)
                {
                    foreach(var m in matches)
                    {
                        words.Add(m);
                    }
                }
            }
            else
            {
                return;
            }
        }
        //when the text in textbox changed it updates the list box with potential words
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if(string.IsNullOrEmpty(textBox1.ToString()))
            {
                return;
            }

            List<string> words = new List<string>();
            search(textBox1.Text, words);                // take input and search

            listBox1.Items.AddRange(words.ToArray());
        }
    }
}
