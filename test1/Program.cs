using System;
using System.Collections;
using System.Collections.Generic;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            BtnTree<int> tree1 = new BtnTree<int>();
            tree1.Add(16);
            tree1.Add(4);
            tree1.Add(12);
            tree1.Add(15);
            tree1.Add(11);                        
            tree1.Add(10);
            tree1.Add(3);
            tree1.Add(2);
            tree1.Add(18);            

            BtnTree<int> tree2 = new BtnTree<int>();            
            tree2.Add(10);
            tree2.Add(3);
            tree2.Add(2);
            tree2.Add(4);
            tree2.Add(12);
            tree2.Add(15);
            tree2.Add(11);            
            tree2.Add(16);
            tree2.Add(18);

            if (TreesEqual<int>(tree1, tree2))
                Console.WriteLine("Trees are equal.");
            else
                Console.WriteLine("Trees are not equal.");
        }

        static bool TreesEqual<T>(BtnTree<T> tree1, BtnTree<T> tree2) where T : IComparable
        {
            if (tree1.Count != tree2.Count)
                return false;

            IEnumerator<T> enum1 = tree1.GetEnumerator();
            IEnumerator<T> enum2 = tree2.GetEnumerator();            

            while (enum1.MoveNext() && enum2.MoveNext())
            {
                if (enum1.Current.CompareTo(enum2.Current) != 0)
                    return false;
            }

            return true;
        }
    }
}
