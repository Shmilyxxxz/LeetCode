using System;

namespace LeetCode0097
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var result1 = new Solution().IsInterleave
                (
                "aabcc",
                "dbbca",
                "aadbbcbcac"
                );

            var result2 = new Solution().IsInterleave
                (
                "aabcc",
                "dbbca",
                "aadbbbaccc"
                );

            Console.WriteLine($"{result1}   {result2}");

        }
    }

    public class Solution
    {
        public bool IsInterleave(string s1, string s2, string s3)
        {
            int m = s1.Length;
            int n = s2.Length;
            int t = s3.Length;

            if (m + n != t)
                return false;

            //构建动态规划的初始函数时，最好添加一个前置
            bool[,] f = new bool[m+1,n+1];
            f[0, 0] = true;

            //for (int i = 0; i <= m; ++i)
            //{
            //    for (int j = 0; j <= n; ++j)
            //    {
            //        int p = i + j - 1;
            //        if (i > 0)
            //        {
            //            f[i, j] |= (f[i - 1, j] && (s1[i - 1] == s3[p]));
            //        }
            //        if (j > 0)
            //        {
            //            f[i, j] |= (f[i, j - 1] && (s2[j - 1] == s3[p]));
            //        }
            //    }
            //}
            for (int i = 1; i <= m; i++)
            {
                f[i, 0] = (f[i - 1, 0] && (s1[i - 1] == s3[i - 1]));
            }
            for (int j = 1; j <= n; j++)
            {
                f[0, j] = (f[0, j] && (s1[j - 1] == s3[j - 1]));
            }

            ////按照动态方程编写循环
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    int p = i + j - 1;
                    f[i, j] = ((f[i - 1, j] && (s1[i - 1] == s3[p])) || (f[i, j - 1] && (s2[j - 1] == s3[p])));
                }
            }
            return f[m, n];
            
                                                                                   

        }
    }
}
