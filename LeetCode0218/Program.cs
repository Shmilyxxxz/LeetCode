using System;
using System.Collections.Generic;

namespace LeetCode218
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //List<int[]> test = new List<int[]>();
            //test.Add(new int[] { 1, 2, 3 });
            //test.Add(new int[] { 2, 2, 3 });
            //test.Add(new int[] { 1, 2, 3 });
            //test.Add(new int[] { 4, 2, 3 });
            //test.Add(new int[] { 2, 2, 3 });
            //test.Add(new int[] { 1, 2, 3 });
            //test.Add(new int[] { 3, 2, 3 });

            //test.Sort((x, y) => x[0] >= y[0]?1:-1);

            //Console.Read();

            int[][] source = new int[][]
            {
                new int[] {2,9,10},
                new int[] {3,7,15},
                new int[] {5,12,12},
                new int[] {15,20,10},
                new int[] {19,24,8},
            };

            var result = new Solution().GetSkyLine(source);


        }
    }

    public class Solution
    {
        public IList<IList<int>> GetSkyLine(int[][] array)
        {

            List<IList<int>> result = new List<IList<int>>();

            List<int[]> edgeList = new List<int[]>();
            List<int> hightList = new List<int>();
            //构建左右边界队列
            int length = array.Length;


            for (int i = 0; i < length; i++)
            {
                //add edga
                edgeList.Add(new int[]{ array[i][0], array[i][2], 1 });
                edgeList.Add(new int[] { array[i][1], array[i][2], -1 });
            }
            edgeList.Sort((x,y)=>x[0]>y[0]?1:-1);

            int MaxHeight = 0;
            for(int i =0;i< edgeList.Count;i++)
            {
                if (edgeList[i][2] == 1) //左边界
                {
                    hightList.Add(edgeList[i][1]);
                    hightList.Sort();
                    //MaxHeight = MaxHeight > edgeList[i][2] ? MaxHeight : edgeList[i][2];

                    if (MaxHeight < edgeList[i][1])  //新值大于边界
                    {
                        MaxHeight = edgeList[i][1];
                        result.Add(new List<int>(new int[] { edgeList[i][0], edgeList[i][1] }));
                    }
                }
                else//右边界
                {
                    int temp = edgeList[i][1];
                    hightList.Remove(edgeList[i][1]);
                    if (MaxHeight == temp)
                    {
                        if (hightList.Count == 0)
                            MaxHeight = 0;
                        else
                            MaxHeight = hightList[hightList.Count - 1];
                        result.Add(new List<int>(new int[] { edgeList[i][0], MaxHeight }));
                    }
                }

            }

            return result;

        }
    }





}
