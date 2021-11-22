using System;

namespace LeetCode0397
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public class Solution
        {
            public int IntegerReplacement(int n)
            {
                int step = 0;
                if (1 == n)
                    return 0;
                if (0==n%2)
                {
                    step++;
                    return step + IntegerReplacement(n / 2);
                }
                else
                {
                    step += 2;
                    if (1==n%4)
                    {
                        return step + IntegerReplacement(n / 2);
                    }
                    else 
                    {
                        if (3 == n)
                        {
                            return step;
                        }
                        else
                        {

                            return step + IntegerReplacement(n / 2 + 1);
                        }
                    }
                }
            }
        }
    }
}
