using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVLTree {
    class Program {
        static void Main(string[] args) {
            //int[] nums = { 64, 28, 26, 80, 50, 77, 82, 3, 65, 16, 9, 87, 38, 67, 69, 49, 10, 79, 15, 62, 30, 48, 52, 31, 19, 35, 59, 41, 97, 92, 22, 37, 7, 70, 78, 21, 72, 96, 91, 73, 4, 54, 27, 75, 46, 44, 51, 84, 57, 2, 42, 93, 33, 13, 88, 94, 55, 43, 5, 40, 18, 36, 76, 60, 86, 45, 25, 99, 39, 95, 71, 66, 81, 90, 6, 53, 24, 11, 56, 98, 14, 20, 83, 61, 23, 74, 68, 12, 17, 29, 34, 32, 8, 0, 63, 85, 89, 47, 58, 1 };
            int[] nums = { 15, 10, 24, 25, 9, 13, 14, 23, 0, 5, 4, 8, 11, 17, 2, 12, 21, 16, 22, 6, 3, 18, 7, 20, 1, 19 };
            //int[] nums = { 1, 0, 6, 3, 9, 2, 7, 8, 5, 4 };
            //int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11,12};
            //int[] nums = { 7, 6, 5, 4, 3, 2, 1 };
            //int[] nums = {1,5,7,6,8,9};

            
            var tree = new AVLTree<int>();
            
            Console.Write("AVL tree\n\nWild list:\n  ");
            foreach (var i in nums) {
                Console.Write(i + " ");
                tree.Add(i);
            }

            Console.Write("\n\nSorted list:\n  ");
            foreach (var i in tree)
                Console.Write(i + " ");
            
            Console.Write("\n\nTree count:\n  {0}", tree.Count);
            
            Console.Write("\n\nVertical tree draw:\n  ");
            Console.Write(tree.ToString());

            Console.Write("\n\nTree root's historical balances:\n  ");
            foreach (int i in tree.HistoricalBalances)
                Console.Write("{0} ", i);

            Console.Write("\n\nHistorical roots:\n  ");
            foreach (var i in tree.HistoricalRoots)
                Console.Write("{0} ", i);
            

            Console.ReadKey();
        }
    }
}
