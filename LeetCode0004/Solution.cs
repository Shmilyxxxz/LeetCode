using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace LeetCode0004
{
    public class Solution
    {
        int[] sourceA;
        int[] sourceB;

        int m = 0;
        int n = 0;

        public void GenerateSourceArray()
        {
            Random r = new Random();
            while (m+n==0)
            {
                m = r.Next(0, 20);
                n = r.Next(0, 20);
            }

            sourceA = new int[m];
            sourceB = new int[n];

            if(m!=0)
                sourceA[0] = 1;
            if (n != 0)
                sourceB[0] = 1;

            WriteLine($"A count : {m}\r\n");
            for(int i = 1; i<m;i++)
            {
                sourceA[i] = sourceA[i - 1] + r.Next(0, 10) ;
                WriteLine($"source[{i}] : {sourceA[i]}\r\n");
            }
            WriteLine($"B count : {n}\r\n");
            for (int i = 1; i < n; i++)
            {
                sourceB[i] = sourceB[i - 1] + r.Next(0, 10);
                WriteLine($"source[{i}] : {sourceB[i]}\r\n");
            }
        }




        public int GetMiniValue(int k)
        {
            int indexA = 0;
            int indexB = 0;
            //int kValue = k;
            while(true)
            {
                if (indexA == m)
                    return sourceB[indexB + k - 1];
                if (indexB == n)
                    return sourceA[indexA + k - 1];
                if (k == 1)
                    return Math.Min(sourceA[indexA], sourceB[indexB]);

                int halfk = k / 2;
                int newIndexA = Math.Min(indexA + halfk, m) - 1;
                int newIndexB = Math.Min(indexB + halfk, n) - 1;

                int Apivot = sourceA[newIndexA];
                int Bpivot = sourceB[newIndexB];
                if (Apivot <= Bpivot)
                {
                    k = k - (newIndexA- indexA + 1);
                    indexA = newIndexA + 1 ;
                }
                else
                {
                    k =k - (newIndexB- indexB + 1);
                    indexB = newIndexB + 1;
                }
            }
        }


        public int GetMiddleIndex(int value)
        {
            if (value % 2 == 0)
                return value / 2 - 1;
            else
                return value / 2;
        }


        public double GetResult()
        {
            GenerateSourceArray();

            double result = 0;
            int count = m + n;
            if(count % 2==0)
            {
                result = (GetMiniValue(count / 2 ) + GetMiniValue((count / 2) + 1)) / 2;
            }
            else
            {
                result = GetMiniValue((count / 2)+1);
            }

            WriteLine($"result:{result}");
            return result;
        }


    }
}
