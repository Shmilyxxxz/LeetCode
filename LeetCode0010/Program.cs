using System;

namespace LeetCode0010
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string s1 = "aaad";
            string s2 = ".*a*b*d*";

            var result = new Solution().IsMatch(s1,s2);
            Console.WriteLine($"{result}");
        }
    }

    public class Solution
    {

        char r = Convert.ToChar(".");
        char x = Convert.ToChar("*");

        public bool IsMatch(string s,string p)
        {

            char[ ] sArray = ("&"+ s).ToCharArray();
            char[ ] pArray = ("&"+ p).ToCharArray();

            
            int m = s.Length;
            int n = p.Length;

            if(m==0||n==0)
            {
                if (n == 0)
                    if (m == 0)
                        return true;
                    else
                        return false;
            }

            bool[,] f = new bool[m+1, n+1];
            f[0, 0] = true;

            

            for(int i = 1; i<=m ; i++ )
            {
                for(int j = 1; j<=n; j++)
                {
                    if (pArray[j].Equals(x))
                    {
                        if (EuqualChar(sArray,pArray,i,j-1))
                        {
                            f[i, j] = f[i , j - 2] || f[i - 1, j - 2] || f[i-1, j];
                        }
                        else
                        {
                            f[i, j] = f[i-1, j-2];
                        }
                    }
                    else
                    {
                        if (EuqualChar(sArray, pArray, i, j))
                            f[i, j] = f[i - 1, j - 1];
                        else
                            f[i, j] = false;
                    }

                }
            }
            return f[m, n];
        }

        public bool EuqualChar(char[] s,char[] p,int si,int pi)
        {      
            if(p[pi].Equals(r)||(s[si]==p[pi]))
            {
                return true;
            }
            return false;
        }





    }

}
