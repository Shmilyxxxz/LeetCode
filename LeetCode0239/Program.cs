/*
    239. 滑动窗口最大值

    给你一个整数数组 nums，有一个大小为 k 的滑动窗口从数组的最左侧移动到数组的最右侧。你只可以看到在滑动窗口内的 k 个数字。滑动窗口每次只向右移动一位。

    返回滑动窗口中的最大值。

    示例 1：

    输入：nums = [1,3,-1,-3,5,3,6,7], k = 3
    输出：[3,3,5,5,6,7]
    解释：
    滑动窗口的位置                最大值
    ---------------               -----
    [1  3  -1] -3  5  3  6  7       3
     1 [3  -1  -3] 5  3  6  7       3
     1  3 [-1  -3  5] 3  6  7       5
     1  3  -1 [-3  5  3] 6  7       5
     1  3  -1  -3 [5  3  6] 7       6
     1  3  -1  -3  5 [3  6  7]      7
    示例 2：

    输入：nums = [1], k = 1
    输出：[1]
    示例 3：

    输入：nums = [1,-1], k = 1
    输出：[1,-1]
    示例 4：

    输入：nums = [9,11], k = 2
    输出：[11]
    示例 5：

    输入：nums = [4,-2], k = 2
    输出：[4]

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/sliding-window-maximum
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
*/


using System;
using System.Collections.Generic;

namespace leetCode239
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入数组并以空格为间隔");

            var numsStr = Convert.ToString(Console.ReadLine()).Split(" ");
            var nums = Array.ConvertAll<string, int>(numsStr, x => Convert.ToInt32(x));

            Console.WriteLine("滑动窗长度");
            int windowLenght = Convert.ToInt32(Console.ReadLine());
            while (windowLenght > nums.Length)
            {
                Console.WriteLine("滑动窗过长，请重新输入");
                windowLenght = Convert.ToInt32(Console.ReadLine());
            }

            Solution solution = new Solution();
            var result = solution.MaxSlidingWindow(nums, windowLenght);

            for (int i = 0; i > result.Length; i++)
            {
                Console.WriteLine($"{result[i]} ");
            }

            Console.ReadLine();
        }
    }

    public class Solution
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            //initial
            LinkedList<int> queue = new LinkedList<int>();
            int[] resultArray = new int[nums.Length - k + 1];
            for (int i = 0; i < nums.Length; i++)
            {
                while ((queue.Count != 0) && (nums[queue.Last.Value] <= nums[i]))
                {
                    queue.RemoveLast();
                }
            }

            int[] array = new int[k];
            int Max = 0;

            for (int index = 0; index < k; index++)
            {
                array[index] = nums[index];
                Max = Max < array[index] ? array[index] : Max;
            }
            resultArray[0] = Max;


            //check the Max Value
            for (int i = k; i < nums.Length; i++)
            {
                if (nums[k] > nums[i - k])
                {
                    Max = Max < nums[k] ? nums[k] : Max;
                }
                resultArray[1 + i - k] = Max;
            }

            return resultArray;
        }
    }


    public class PriorityQueue
    {
        private int[] array;
        private int size;

        public PriorityQueue()
        {
            size = 32;
            array = new int[size];
        }

        public PriorityQueue(int queueSize)
        {
            size = queueSize;
            array = new int[size];
        }

        public void EnQueue(int key)
        {
            if (size >= array.Length)
            {
                //扩展队列长度
            }
            array[size++] = key;
            //上浮

        }

        public void DeQueue()
        {

            //下沉
        }


    }


}
