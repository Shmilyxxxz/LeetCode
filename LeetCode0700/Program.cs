using System;

namespace LeetCode0700
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }


    //二叉搜索树满足如下性质：
    //左子树所有节点的元素值均小于根的元素值；
    //右子树所有节点的元素值均大于根的元素值。
    public class Solution
    {
        public TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null)
            {
                return null;
            }
            if (val == root.val)
            {
                return root;
            }
            return SearchBST(val < root.val ? root.left : root.right, val);
        }
    }

}
