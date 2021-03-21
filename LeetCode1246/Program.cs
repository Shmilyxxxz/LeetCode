using System;

namespace LeetCode1246
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
        public int MinimunMoves(int[] arr)
        {
            int l = arr.Length;
            int[,] dp = new int[l, l];
            //len==1
            for(int i=0;i<l;i++)
            {
                dp[i, i] = 1;
            }
            //len==2
            for(int i =0;i<l-1; i++)
            {
                if (arr[i] == arr[i + 1])
                    dp[i, i + 1] = 1;
                else
                    dp[i, i + 1] = 2;
            }
            //len>2
            for(int len =2;len<l;len++)
            {
                for(int i =0;i<l-len;i++)
                {
                    dp[i, i + len] = len + 1;
                    for(int k=0;k<len;k++)
                    {
                        if(dp[i, i + len]>dp[i,i+k]+ dp[i+k, i - k + len])
                        {
                            dp[i, i + len] = dp[i, i + k] + dp[i + k, i - k + len];
                        }
                        if((arr[i]==arr[i+len])&& (dp[i ,i+ len] > dp[i+1, i +len-1]))
                        {
                            dp[i, i + len] = dp[i + 1, i + len - 1];
                        }
                    }
                }
            }
            return dp[0, l - 1];
        }


    }
}
