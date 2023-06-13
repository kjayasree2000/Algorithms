using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKPractise
{
    class TreeProblems
    {
        public void printAllNodesofTree(BinaryTreeNode root)
        {
            if (root == null)
                return;
            else
            {
                Console.WriteLine(root.value);
                printAllNodesofTree(root.left);
                printAllNodesofTree(root.right);
            }
        }

        public static int find_single_value_trees(BinaryTreeNode root)
        {
            // Write your code here.
            int count = 0;
         
            recursive_helper(root, count);
            return count;
        }

        public static bool recursive_helper(BinaryTreeNode root, int count)
        {
            if (root == null) return true;
            bool isLefttree = recursive_helper(root.left, count);
            bool isRighttree = recursive_helper(root.right, count);
            if (
                (root.left == null || (isLefttree && root.left.value == root.value)) &&
                (root.right == null || (isRighttree && root.right.value == root.value))

              )
            {
                count++;
                return true;
            }
            else
            {
                return false;
            }

        }

        public static List<int> li = new List<int>();
        public static List<int> preorder(BinaryTreeNode root)
        {
            // Write your code here.
            preorder_helper(root, li);
            return li;
        }
        public static void preorder_helper(BinaryTreeNode root, List<int> li)
        {
            if (root != null) li.Add(root.value);
            preorder_helper(root.left, li);
            preorder_helper(root.right, li);
        }
        List<List<int>> allpaths = new List<List<int>>();
        
        public List<List<int>> All_Paths_Sum_K(BinaryTreeNode root, int k)
        {
            
            DFS_helper(root, new List<int>(), 0);
            List<List<int>> result = new List<List<int>>();
            foreach(List<int> li in allpaths)
            {
                if (li[li.Count - 1] == k)
                {
                    result.Add(li);
                }
            }
            return result;

        }

        public void DFS_helper(BinaryTreeNode root, List<int> path, int pathsum)
        {
            if (root == null) return;
            List<int> li = new List<int>(path);
            li.Add(root.value);
            pathsum = pathsum + root.value;
            if(root.left==null && root.right == null)
            {
                li.Add(pathsum);
                allpaths.Add(li);             
                return;
            }
            else
            {
                DFS_helper(root.left, li, pathsum);
                DFS_helper(root.right, li, pathsum);
            }
            
        }
        
        public int binary_tree_diameter(BinaryTreeNode root)
        {
            if (root == null) return 0;
            return binary_tree_diameter(root.left) + binary_tree_diameter(root.right) + 1; // counting up all nodes
        }

        public List<List<int>> BinaryTreePath(BinaryTreeNode root)
        {
            List<List<int>> result = new List<List<int>>();
            List<int> path = new List<int>();
            result=BinaryTreePathhelper(root, result, path);
            return result;
        }

        public List<List<int>> BinaryTreePathhelper(BinaryTreeNode root, List<List<int>> result, List<int> path)
        {
            if (root==null)
            {
                return result;
               
            }
            path.Add(root.value);
            if (root.left == null && root.right == null)
            {
                List<int> tempPath = path.Select(x => x).ToList();
                result.Add(tempPath);
            }

            if (root.left != null)
            {
                BinaryTreePathhelper(root.left, result, path);
                path.RemoveAt(path.Count - 1);
            }
            if (root.right != null)
            {
                BinaryTreePathhelper(root.right, result, path);
                path.RemoveAt(path.Count - 1);
            }
            return result;
        }


    }
}
