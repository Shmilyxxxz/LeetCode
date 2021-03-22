/*
 * 330. 按要求补齐数组
 * 给定一个已排序的正整数数组 nums，和一个正整数 n 。从 [1, n] 区间内选取任意个数字补充到 nums 中，使得 [1, n] 区间内的任何数字都可以用 nums 中某几个数字的和来表示。
 * 请输出满足上述要求的最少需要补充的数字个数。
 * 来源：力扣（LeetCode）
 * 链接：https://leetcode-cn.com/problems/patching-array
 * 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
 */

using System;
using System.Collections.Generic;

namespace leetcode330
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int[] nums = new int[] {2,3,3,5};
            int n = 30;
            int result = GetCounts(nums,n);
            Console.WriteLine($"{result}");
            Console.ReadLine();


        }

        private static int GetCounts(int[] nums, int n)
        {
            int length = nums.Length;
            int count = 0;
            int ArrayIndex = 0;
            long x = 1;
            while (x<=n)
            {
                if ((ArrayIndex< length) &&(nums[ArrayIndex] <= x))
                {
                    x += nums[ArrayIndex++];
                    ArrayIndex++;
                }
                else
                {
                    Console.WriteLine($"补充值：{x}");
                    x *= 2;
                    count++;
                }
            }
            return count;
        }
    }
}
