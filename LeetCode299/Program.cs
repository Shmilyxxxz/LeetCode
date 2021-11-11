using System;
using System.Text;

namespace LeetCode0299
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            new Solution().GetHint("1123","0111");
        }
    }

    public class Solution
    {
        public string GetHint(string secret, string guess)
        {
            int bulls = 0;
            int cows = 0;
            int[] s_cows = new int[10];
            int[] g_cows = new int[10];
            for(int i=0;i<secret.Length;i++)
            {
                if(secret[i]==guess[i])
                {
                    bulls++;
                }
                else
                {
                    g_cows[guess[i] - '0'] = g_cows[guess[i] - '0']+1;
                    s_cows[secret[i] - '0'] = s_cows[secret[i] - '0']+1;
                }
            }
            for(int i =0;i<10;i++)
            {
                cows += Math.Min(g_cows[i], s_cows[i]);
            }
            return new StringBuilder($"{bulls}A{cows}B").ToString();

        }
    }
}
