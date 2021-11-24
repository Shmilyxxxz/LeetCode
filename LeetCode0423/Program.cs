﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode0423
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
        public string OriginalDigits(string s)
        {
            //zero one two three four five six seven eight nine ten 
            //zero z
            //one o -w -u -z
            //two w
            //three r-z
            //four u
            //five f-u
            //six x
            //seven s-x
            //eight g
            //nine i-x-v

            Dictionary<char, int> c = new Dictionary<char, int>();
            foreach (char ch in s)
            {
                if (!c.ContainsKey(ch))
                {
                    c.Add(ch, 0);
                }
                ++c[ch];
            }

            int[] cnt = new int[10];
            cnt[0] = c.ContainsKey('z') ? c['z'] : 0;
            cnt[2] = c.ContainsKey('w') ? c['w'] : 0;
            cnt[4] = c.ContainsKey('u') ? c['u'] : 0;
            cnt[6] = c.ContainsKey('x') ? c['x'] : 0;
            cnt[8] = c.ContainsKey('g') ? c['g'] : 0;

            cnt[3] = (c.ContainsKey('h') ? c['h'] : 0) - cnt[8];
            cnt[5] = (c.ContainsKey('f') ? c['f'] : 0) - cnt[4];
            cnt[7] = (c.ContainsKey('s') ? c['s'] : 0) - cnt[6];

            cnt[1] = (c.ContainsKey('o') ? c['o'] : 0) - cnt[0] - cnt[2] - cnt[4];

            cnt[9] = (c.ContainsKey('i') ? c['i'] : 0) - cnt[5] - cnt[6] - cnt[8];

            StringBuilder ans = new StringBuilder();
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < cnt[i]; ++j)
                {
                    ans.Append((char)(i + '0'));
                }
            }
            return ans.ToString();
        }
    }



}
