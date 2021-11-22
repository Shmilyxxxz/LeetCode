using System;

namespace LeetCode0384
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }


    public class Solution
    {
        public int[] originalArray;
        public int[] nums;
        public Solution(int[] nums)
        {
            this.nums = nums;
            originalArray = new int[nums.Length];
            this.nums.CopyTo(originalArray, 0);
        }

        public int[] Reset()
        {
            originalArray.CopyTo(nums, 0);
            return nums;
        }

        public int[] Shuffle()
        {
            Random random = new Random();
            for (int i = 0; i < nums.Length; ++i)
            {
                int j = random.Next(i, nums.Length);
                int temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
            }
            return nums;
        }
    }

}
