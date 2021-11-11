using System;

namespace LeetCode0032
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is leetcode 032");

            string sourece = "(()((())))";

            var result = new Solution().LongestValidParentheses(sourece);

            Console.WriteLine($"{sourece} : LongestValidParentheses is {result})");
        }
    }




    public class Solution
    {
        public int LongestValidParentheses(string s)
        {
            int[] f = new int[s.Length];
            int max = 0;
            char left = Convert.ToChar("(");
            char right = Convert.ToChar(")");

            for (int i = 1;i<s.Length;i++)
            {
                //((
                if(s[i]== left)
                {
                    f[i] = 0;
                }
                else
                {
                    //()
                    if(s[i-1]==left)
                    {
                        f[i] = 1 + f[i - 1];
                    }
                    else
                    {
                        //)))
                        if (f[i - 1] != 0)
                        {
                            // (())
                            if(i - f[i - 1] * 2 - 1>=0)
                            {
                                if (s[i - f[i - 1] * 2 - 1] == left)
                                {
                                    f[i] = f[i - 1] + 1 + f[i-f[i-1]];
                                }
                                //else
                                //{
                                //    f[i] = 0;
                                //}
                            }
                            //else
                            //{
                            //    f[i] = 0;
                            //}

                        }
                        //else
                        //{
                        //    f[i] = 0;
                        //}
                    }

                }
            }
            foreach(var e in f)
            {
                max = max > e ? max : e;
            }
            return max*2;
        }
    }





}
