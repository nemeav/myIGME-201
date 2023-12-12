﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BinaryTreeVisualizer;

namespace BTree
{
    public partial class BTreeForm : Form
    {
        public BTreeForm()
        {
            try
            {
                // Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.2; WOW64; Trident / 7.0; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.30729; .NET CLR 3.5.30729; wbx 1.0.0)
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\\WOW6432Node\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION",
                    true);
                key.SetValue(Application.ExecutablePath.Replace(Application.StartupPath + "\\", ""), 11001, Microsoft.Win32.RegistryValueKind.DWord);
                key.Close();
            }
            catch
            {
            }

            InitializeComponent();

            this.randomButton.Click += new EventHandler(RandomButton__Click);
            this.unbalancedButton.Click += new EventHandler(UnbalancedButton__Click);
            this.primedButton.Click += new EventHandler(PrimedButton__Click);
            this.button1.Click += new EventHandler(Exercise1__Click);
            this.button2.Click += new EventHandler(Exercise2__Click);
            this.button3.Click += new EventHandler(Exercise3__Click);
            this.button4.Click += new EventHandler(Exercise4__Click);
            this.button5.Click += new EventHandler(Exercise5__Click);
            this.button6.Click += new EventHandler(Exercise6__Click);
            this.button7.Click += new EventHandler(Exercise7__Click);
            this.exitButton.Click += new EventHandler(ExitButton__Click);

            // give the BTree class objects access to Form1
            BTree.bTreeForm = this;
        }

        private void ExitButton__Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RandomButton__Click(object sender, EventArgs e)
        {
            // load a tree with random numbers
            BTree root = null;
            BTree node;
            Random random = new Random();

            this.richTextBox.Clear();

            for (int i = 0; i < 10; ++i)
            {
                node = new BTree(random.Next(100), root);

                if (i == 0)
                {
                    root = node;
                }
            }

            this.richTextBox.Text += "\nAscending order:";
            BTree.TraverseAscending(root);

            this.richTextBox.Text += "\nDescending order:";
            BTree.TraverseDescending(root);


            VisualizeBinaryTree visualizeBinaryTree = new VisualizeBinaryTree(root);
        }

        private void UnbalancedButton__Click(object sender, EventArgs e)
        {
            // load a tree in data-ascending order, 
            // which will cause it to be unbalanced and poor-performing
            BTree root = null;
            BTree node;

            this.richTextBox.Clear();

            for (int i = 0; i < 10; ++i)
            {
                node = new BTree(i, root);

                if (i == 0)
                {
                    root = node;
                }
            }

            this.richTextBox.Text += "\n";
            BTree.TraverseAscending(root);

            VisualizeBinaryTree visualizeBinaryTree = new VisualizeBinaryTree(root);
        }

        private void PrimedButton__Click(object sender, EventArgs e)
        {
            // Prime a tree to hold alphabetical information

            this.richTextBox.Clear();

            BTree node = null;
            BTree root = null;

            node = new BTree("M", null);
            root = node;

            node = new BTree("F", root);
            node = new BTree("C", root);
            node = new BTree("B", root);
            node = new BTree("A", root);
            node = new BTree("E", root);
            node = new BTree("D", root);

            node = new BTree("J", root);
            node = new BTree("I", root);
            node = new BTree("H", root);
            node = new BTree("G", root);
            node = new BTree("L", root);
            node = new BTree("K", root);

            node = new BTree("P", root);
            node = new BTree("O", root);
            node = new BTree("N", root);
            node = new BTree("T", root);
            node = new BTree("S", root);
            node = new BTree("R", root);
            node = new BTree("Q", root);

            node = new BTree("W", root);
            node = new BTree("V", root);
            node = new BTree("U", root);
            node = new BTree("X", root);
            node = new BTree("Y", root);
            node = new BTree("Z", root);

            this.richTextBox.Text += "\n";
            BTree.TraverseAscending(root);

            this.richTextBox.Text += "\n";
            BTree.TraverseDescending(root);

            VisualizeBinaryTree visualizeBinaryTree = new VisualizeBinaryTree(root);
        }

        private void Exercise1__Click(object sender, EventArgs e)
        {
            // Exercise #1
            // insert 30 random numbers between 1 and 51

            BTree root = null;
            BTree node;
            Random random = new Random();

            this.richTextBox.Clear();

            // Your code here
            for (int i = 0; i < 30; i++)
            {
                int randomNumber = random.Next(1, 52);

                node = new BTree(randomNumber, root);

                if (root == null)
                {
                    root = node;
                }
            }

            this.richTextBox.Text += "\n";

            BTree.TraverseAscending(root);

            VisualizeBinaryTree visualizeBinaryTree = new VisualizeBinaryTree(root);
        }

        private void Exercise2__Click(object sender, EventArgs e)
        {
            // Exercise #2
            // prime the tree for numbers between 1 and 51
            // with 7 optimally distributed data points (setting isData = false) 
            // then insert 30 random numbers between 1 and 51

            BTree root = null;
            BTree node;
            Random random = new Random();

            this.richTextBox.Clear();


            // Your code here
            int[] optimalPoints = { 7, 14, 21, 28, 35, 42, 49 };
            foreach (int point in optimalPoints)
            {
                node = new BTree(point, root, false);
                root = node;
            }


            for (int i = 0; i < 30; ++i)
            {
                node = new BTree(random.Next(1, 52), root);
            }

            this.richTextBox.Text += "\n";

            BTree.TraverseAscending(root);

            VisualizeBinaryTree visualizeBinaryTree = new VisualizeBinaryTree(root);
        }

        private void Exercise3__Click(object sender, EventArgs e)
        {
            // Exercise #3
            // insert 15 random uppercase strings

            BTree root = null;
            BTree node;
            Random random = new Random();

            this.richTextBox.Clear();

            // Your code here
            string[] words = { "LION", "TIGER", "CAT", "DOG", "FISH", "BIRD", "RAT", "PANDA", "MOUSE", "SQUID", "FROG", "TOAD", "NEWT", "SNAKE", "BAT" };

            foreach (string word in words)
            {
                node = new BTree(word, root);

                if (root == null)
                {
                    root = node;
                }
            }

            this.richTextBox.Text += "\n";

            BTree.TraverseAscending(root);

            VisualizeBinaryTree visualizeBinaryTree = new VisualizeBinaryTree(root);
        }

        private void Exercise4__Click(object sender, EventArgs e)
        {
            // Exercise #4
            // prime the tree using the code in Button3_Click()
            // then insert the 15 random uppercase strings from Exercise #3

            this.richTextBox.Clear();

            BTree node = null;
            BTree root = null;

            string[] primeLetters = { "M", "F", "T", "C", "J", "S", "X", "B", "E", "I", "L", "R", "V", "Z", "A", "D", "H", "K", "Q", "U", "Y", "P", "O", "W" };

            string[] words = { "LION", "TIGER", "CAT", "DOG", "FISH", "BIRD", "RAT", "PANDA", "MOUSE", "SQUID", "FROG", "TOAD", "NEWT", "SNAKE", "BAT" };

            foreach (string word in words)
            {
                if (!primeLetters.Contains(word))
                {
                    if (root == null)
                    {
                        root = new BTree(word, null, true);
                        node = root;
                    }
                    else if (word != "LION")
                    {
                        node = new BTree(word, root, true);
                    }
                }
            }

            this.richTextBox.Text += "\n";
            BTree.TraverseAscending(root);

            this.richTextBox.Text += "\n";
            BTree.TraverseDescending(root);

            VisualizeBinaryTree visualizeBinaryTree = new VisualizeBinaryTree(root);
        }

        private void Exercise5__Click(object sender, EventArgs e)
        {
            // Exercise #5
            // use the code in Button3_Click to add the 26 letters to the tree
            // then remove nodes "C", "I" and "A" 
            // using this code to remove each node:
            //     // create new freestanding node for "C"
            //     nodeToDelete = new BTree("C", null);
            //     BTree.DeleteNode(nodeToDelete, root);
            // add the newline and call BTree.TraverseAscending() after each delete

            this.richTextBox.Clear();

            BTree node = null;
            BTree nodeToDelete = null;
            BTree root = null;

            // Your code here
            string[] letters = { "M", "F", "T", "C", "J", "S", "X", "B", "E", "I", "L", "R", "V", "Z", "A", "D", "H", "K", "Q", "U", "Y", "P", "O", "W", "G", "N" };

            foreach (string letter in letters)
            {
                if (node == null)
                {
                    node = new BTree(letter, null, false);
                    root = node;
                }
                else
                {
                    node = new BTree(letter, root, false);
                }
            }

            this.richTextBox.Text += "\n";
            BTree.TraverseAscending(root);

            nodeToDelete = new BTree("C", null);
            BTree.DeleteNode(nodeToDelete, root);

            this.richTextBox.Text += "\n";
            BTree.TraverseAscending(root);

            nodeToDelete = new BTree("I", null);
            BTree.DeleteNode(nodeToDelete, root);

            this.richTextBox.Text += "\n";
            BTree.TraverseAscending(root);

            nodeToDelete = new BTree("A", null);
            BTree.DeleteNode(nodeToDelete, root);

            this.richTextBox.Text += "\n";
            BTree.TraverseAscending(root);

            VisualizeBinaryTree visualizeBinaryTree = new VisualizeBinaryTree(root);
        }

        private void Exercise6__Click(object sender, EventArgs e)
        {
            // Exercise #6
            // there are operator overloads to compare 2 BTree objects for BTree.data being string or int
            // enhance the overloads to support the Person object and compare using Person.age using:                
            //     if (a.data.GetType() == typeof(Person))


            // create at least 15 new Person objects which correspond to members of your family
            // insert them into the tree starting with yourself
            this.richTextBox.Clear();

            BTree node = null;
            BTree root = null;

            Person person = null;

            // Your code here
            Person[] familyMembers = new Person[]
            {
                new Person("Neme", 19),
                new Person("Tania", 40),
                new Person("Alex", 41),
                new Person("Gio", 8),
                new Person("Heaven", 13),
                new Person("Aneisha", 18),
                new Person("Cari", 36),
                new Person("Luis", 38),
                new Person("Zully", 36),
                new Person("Zulma", 58),
                new Person("Abby", 73),
                new Person("Jack", 20),
                new Person("Damon", 18),
                new Person("Darriel", 14),
                new Person("Angel", 26),
            };

            for (int i = 0; i < familyMembers.Length; i++)
            {
                if (person == null)
                {
                    node = new BTree(familyMembers[i], null);
                    root = node;
                    person = familyMembers[i];
                }
                else
                {
                    node = root;
                    while (true)
                    {
                        if (familyMembers[i].age < ((Person)node.data).age)
                        {
                            if (node.ltChild == null)
                            {
                                node.ltChild = new BTree(familyMembers[i], root);
                                break;
                            }
                            else
                            {
                                node = node.ltChild;
                            }
                        }
                        else
                        {
                            if (node.gteChild == null)
                            {
                                node.gteChild = new BTree(familyMembers[i], root);
                                break;
                            }
                            else
                            {
                                node = node.gteChild;
                            }
                        }
                    }
                }
            }


            this.richTextBox.Text += "\n";
            BTree.TraverseAscending(root);

            VisualizeBinaryTree visualizeBinaryTree = new VisualizeBinaryTree(root);
        }

        private void Exercise7__Click(object sender, EventArgs e)
        {
            // Exercise #7
            // given the age range of people in Exercise #6, 
            // prime the tree with nodes containing Person objects (set isData = false for the seed nodes)
            // containing the optimal ages to balance the tree
            this.richTextBox.Clear();

            BTree node = null;
            BTree root = null;

            // the Person class is defined below
            Person person = null;

            // Your code here
            Person[] familyMembers = new Person[]
            {
                new Person("Neme", 19),
                new Person("Tania", 40),
                new Person("Alex", 41),
                new Person("Gio", 8),
                new Person("Heaven", 13),
                new Person("Aneisha", 18),
                new Person("Cari", 36),
                new Person("Luis", 38),
                new Person("Zully", 36),
                new Person("Zulma", 58),
                new Person("Abby", 73),
                new Person("Jack", 20),
                new Person("Damon", 18),
                new Person("Darriel", 14),
                new Person("Angel", 26),
            };

            for (int i = 0; i < familyMembers.Length; i++)
            {
                Person currentPerson = familyMembers[i];

                if (root == null)
                {
                    root = new BTree(currentPerson, null, false);
                    person = currentPerson;
                }
                else
                {
                    node = root;

                    while (true)
                    {
                        if (currentPerson.age < person.age)
                        {
                            if (node.ltChild == null)
                            {
                                node.ltChild = new BTree(currentPerson, root, false);
                                break;
                            }
                            else
                            {
                                node = node.ltChild;
                            }
                        }
                        else
                        {
                            if (node.gteChild == null)
                            {
                                node.gteChild = new BTree(currentPerson, root, false);
                                break;
                            }
                            else
                            {
                                node = node.gteChild;
                            }
                        }
                    }
                }
            }

            this.richTextBox.Text += "\n";
            BTree.TraverseAscending(root);

            VisualizeBinaryTree visualizeBinaryTree = new VisualizeBinaryTree(root);
        }
    }
}
