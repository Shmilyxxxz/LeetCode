using System;
using System.Collections.Generic;

namespace LeetCode00525
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            new Solution().FindMaxLength(new int[] {1,1,0,0 });
        }
    }

    public class Solution
    {
        public int FindMaxLength(int[] nums)
        {
            int L = nums.Length;
            int[] newNums = new int[L];

            Dictionary<int, int> record = new Dictionary<int, int>();
            record.Add(0, -1);

            //for (int i = 0; i < L; i++)
            //{
            //}

            int curruntSum = 0;
            int maxLengh = 0;
            for (int i = 0; i < L; i++)
            {
                if (0 == nums[i])
                    newNums[i] = -1;
                else
                    newNums[i] = 1;

                curruntSum += newNums[i];
                if (record.ContainsKey(curruntSum))
                {
                    var index = record[curruntSum];
                    maxLengh = Math.Max(maxLengh, i - index);
                }
                else
                {
                    record.Add(curruntSum, i);
                }
            }
            return maxLengh;



        }   
    }

}
