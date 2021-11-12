using System;

namespace LeetCode0375
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(new Solution().GetMoneyAmount(20));

        }
    }

    public class Solution
    {
        public int GetMoneyAmount(int n)
        {
            int[,] f = new int[n + 1, n + 1];
            for (int i = n - 1; i >= 1; i--)
            {
                for(int j = i+1;j<=n;j++)
                {
                    int minCost = int.MaxValue;
                    for(int k = i;k<j;k++)
                    {
                        int cost = k + Math.Max(f[i,k-1],f[k+1,j]);
                        minCost = Math.Min(cost,minCost);
                    }
                    f[i, j] = minCost;
                }
            }
            return f[1, n];
        }
    }
}
