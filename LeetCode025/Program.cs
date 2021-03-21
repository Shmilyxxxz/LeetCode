using System;
using System.Collections.Generic;

namespace LeetCode025
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode rootNode = new ListNode(0);
            ListNode CurrentNode = rootNode;


            List<ListNode> nodeList = new List<ListNode>() { rootNode };
            for(int i =1;i<=37;i++)
            {
                ListNode nextNode = new ListNode(i);
                CurrentNode.next = nextNode;
                CurrentNode = nextNode;
                nodeList.Add(nextNode);
            }

            var result = new Solution().ReverseKGroup(rootNode, 10);
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
        public ListNode ReverseKGroup(ListNode head, int k)
        {

            List<ListNode[]> NodeList = new List<ListNode[]>();

            int nodeCount = 1;

            ListNode StartNode = head;
            ListNode current = head;
            while(current.next!=null)
            {
                current = current.next;
                if (nodeCount % k == 0)
                {
                    var temp = GetHeadNode(StartNode, k);
                    NodeList.Add(temp);
                    StartNode = current;
                }

                nodeCount++;
            }

            if(NodeList.Count>1)
            {
                for (int i = 0; i < NodeList.Count - 1; i++)
                {
                    NodeList[i][1].next = NodeList[i+1][0];
                }


            }

            if(nodeCount%k!=0)
            {
                NodeList[NodeList.Count - 1][1].next = StartNode;
            }
            return NodeList[0][0];

        }

        public ListNode[] GetHeadNode(ListNode head, int k)
        {
            ListNode EndNode = head;

            ListNode current = head;
            ListNode previous = null;// new ListNode(0,current);
            ListNode next = current.next;


            for (int i = 0; i < k; i++)
            {
                current.next = previous;
                previous = current;
                current = next;
                next = current.next;
            }

            //current.next = previous;
            //EndNode.next = current;

            return new ListNode[2]{ previous, EndNode };
        }


    }


}
