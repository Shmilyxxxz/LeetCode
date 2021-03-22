using System;


/*
Input: head = [1,2,3,4,5], left = 2, right = 4
Output: [1,4,3,2,5]
*/
namespace LeetCode0092
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ListNode head = new ListNode(0);
            ListNode current = head;
            for(int i =1;i<=5;i++)
            {
                current.next = new ListNode(i);
                current = current.next;
            }

            var result = new Solution().ReverseBetween(head,2, 4);

            current = result;
            do
            {
                Console.WriteLine($"{current.val} ");
                current = current.next;
            }
            while (current.next != null);
        }
    }


    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }


    public class Solution
    {
        public ListNode ReverseBetween(ListNode head, int left, int right)
        {
            // 设置 dummyNode 是这一类问题的一般做法
            ListNode dummyNode = new ListNode(-1);
            dummyNode.next = head;
            ListNode pre = dummyNode;
            for (int i = 0; i < left - 1; i++)
            {
                pre = pre.next;
            }
            ListNode cur = pre.next;
            ListNode next;
            for (int i = 0; i < right - left; i++)
            {
                next = cur.next;
                cur.next = next.next;
                next.next = pre.next;
                pre.next = next;
            }
            return dummyNode.next;
        }
    }


}
