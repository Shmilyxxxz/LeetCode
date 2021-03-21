using System;

namespace LeetCode0092
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
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

            int currentIndex = 0;
            ListNode FirstNode = new ListNode();
            FirstNode.next = head;
            ListNode currentNode = FirstNode.next;
            ListNode BeforeLeft = new ListNode();
            ListNode AfterRight = new ListNode();

            while (currentNode.next != null)
            {
                if (currentIndex == left - 1)
                {
                    BeforeLeft = currentNode;
                    AfterRight = currentNode.next;
                }

                //复制下一个节点
                ListNode nextNode = currentNode.next;
                if ((currentIndex >= left) && (currentIndex < right))
                {
                    //转向下一个节点
                    currentNode.next.next = currentNode;
                }
                //移动当前指针
                currentNode = nextNode;
                currentIndex++;

                //跳出循环
                if (currentIndex == left)
                {
                    //1->4 2->5 
                    ListNode temp = currentNode.next;
                    BeforeLeft.next = currentNode;
                    AfterRight.next = temp;
                    break;
                }
            }
            return FirstNode.next;

        }
    }

    public class Solution2
    {
        public ListNode reverseBetween(ListNode head, int left, int right)
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
