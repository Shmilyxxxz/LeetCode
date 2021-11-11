using System;
using System.Collections;
using System.Collections.Generic;

namespace LeetCode0030
{
    class Program
    {
        static void Main()
        {
            string s = "foodoodoofoofoo908foofoodoo";
            string[] words = new string[]
            {
                "foo",
                "doo",
                "foo"
            };
            var result = new Solution().FindSubString(s, words);
            Console.WriteLine($"result :{result}");
        }

    }


    class Solution
    {

        public IList<int> FindSubString(string s, string[] words)
        {
            List<int> result = new List<int>();

            int n = s.Length;
            int i = words.Length;
            int j = words[0].Length;

            Dictionary<string, int> wordsList = new Dictionary<string, int>();
            foreach (string e in words)
            {
                if (wordsList.ContainsKey(e))
                    wordsList[e]++;
                else
                    wordsList.Add(e, 1);
            }

            for (int m = 0; m <= n - i * j; m++)
            {
                bool checkSubstring = true;
                Dictionary<string, int> subStringList = new Dictionary<string, int>();
                for (int x = 0; x < j; x++)
                {
                    string subString = s.Substring(m + x * i, i);
                    if (wordsList.ContainsKey(subString))
                    {
                        if (subStringList.ContainsKey(subString))
                        {
                            subStringList[subString]++;
                        }
                        else
                        {
                            subStringList.TryAdd(subString, 1);
                        }

                        if (wordsList[subString] < subStringList[subString])
                        {
                            checkSubstring = false;
                            break;
                        }

                    }
                    else
                    {
                        checkSubstring = false;
                        break;
                    }
                }

                if (checkSubstring)
                {
                    result.Add(m);
                }

            }
            return result;
        }


    }
}