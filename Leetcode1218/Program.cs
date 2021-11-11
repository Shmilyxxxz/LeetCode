using System;
using System.Collections.Generic;

namespace Leetcode1218
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] test = new int[] { 1, 5, 7, 8, 5, 3, 4, 2, 1};
            new Solution().LongestSubsequence(test, -2);
        }
    }



    public class Solution
    {
        public int LongestSubsequence(int[] arr, int difference)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            dic.Add(arr[0], 1);
            int max = 1;
            for(int i=1;i<arr.Length;i++)
            {
                int prev = dic.ContainsKey(arr[i] - difference)?dic[arr[i] - difference]:0;
                if (dic.ContainsKey(arr[i] - difference))
                {
                    if (dic.ContainsKey(arr[i]))
                    {
                        dic[arr[i]] = prev + 1;
                    }
                    else
                    {
                        dic.Add(arr[i], prev + 1);
                    }
                    max = Math.Max(max, dic[arr[i]]);
                }

                //    if (dic.ContainsKey(arr[i] - difference))
                //{
                //    if(dic.ContainsKey(arr[i]))
                //    {
                //        dic[arr[i]] = dic[(arr[i] - difference)] + 1;
                //    }
                //    else
                //    {
                //        dic.Add(arr[i], dic[(arr[i] - difference)] + 1);
                //    }
                //    if (max < dic[arr[i]])
                //        max = dic[arr[i]];
                //}
                //else
                //{
                //    if (dic.ContainsKey(arr[i]))
                //    {
                //        dic[arr[i]] = 1;
                //    }
                //    else
                //        dic.Add(arr[i] , 1);
                //}
            }
            return max;
        }
    }
}
