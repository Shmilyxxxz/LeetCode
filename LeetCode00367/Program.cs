using System;

namespace LeetCode00367
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
        public bool IsPerfectSquare(int num)
        {
            int left = 1;
            int right = num;
            while (left<=right)
            {
                int mid = left + (right-left)/2;
                long square = (long)mid * mid;
                if(square == num)
                {
                    return true;
                }
                else if(square > num)
                {
                    right = mid-1;
                }
                else if(square < num)
                {
                    left = mid+1;
                }
            }
            return false;
        }
    }

}
