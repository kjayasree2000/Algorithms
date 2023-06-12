using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKPractise
{
    class Program
    {
        static void Main(string[] args)
        {

            StringsPractise obj = new StringsPractise();

            TreeProblems ts = new TreeProblems();
            BinaryTreeNode root = new BinaryTreeNode(0);
            root.left = new BinaryTreeNode(1);          
            root.left.left = new BinaryTreeNode(2);
            root.left.right = new BinaryTreeNode(3);
            root.left.left.left = new BinaryTreeNode(4);
            root.left.right.right = new BinaryTreeNode(5);
            List<List<int>> result = new List<List<int>>();
            result = ts.BinaryTreePath(root);
            foreach(List<int> li in result)
            {
                foreach(int t in li)
                {
                    Console.Write(t + " ");
                }
                Console.WriteLine("");
            }
            //List<List<int>> res = new List<List<int>>();
            //ts.All_Paths_Sum_K(root, 14);
            //StringsPractise s = new StringsPractise();
            //int len=s.get_longest_substring_length_with_exactly_two_distinct_chars("ecebaaaaca");
            //Console.WriteLine(len);
            Console.ReadLine();

        }
    }
}
