using System;
using System.Collections.Generic;

namespace LeetCode0407
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //[[1,4,3,1,3,2],[3,2,1,3,2,4],[2,3,3,2,3,1]]
            int[][]  test = new int[][] { new int[] { 1, 4, 3, 1, 3, 2 }, new int[] { 3, 2, 1, 3, 2, 4 }, new int[] { 2, 3, 3, 2, 3, 1 } };
            //Console.WriteLine(new Solution().TrapRainWater(test));
            Console.WriteLine(new Solution2().TrapRainWater(test));
            Console.ReadLine();
        }
    }

    //public class Solution
    //{
    //    public int TrapRainWater(int[][] heightMap)
    //    {
    //        int m = heightMap.Length;
    //        int n = heightMap[0].Length;
    //        int[] dirs = { -1, 0, 1, 0, -1 };
    //        int maxHeight = 0;

    //        for (int i = 0; i < m; ++i)
    //        {
    //            for (int j = 0; j < n; ++j)
    //            {
    //                maxHeight = Math.Max(maxHeight, heightMap[i][j]);
    //            }
    //        }
    //        int[,] water = new int[m, n];
    //        for (int i = 0; i < m; ++i)
    //        {
    //            for (int j = 0; j < n; ++j)
    //            {
    //                water[i, j] = maxHeight;
    //            }
    //        }

    //        Queue<int[]> qu = new Queue<int[]>();
    //        for (int i = 0; i < m; ++i)
    //        {
    //            for (int j = 0; j < n; ++j)
    //            {
    //                if (i == 0 || i == m - 1 || j == 0 || j == n - 1)
    //                {
    //                    if (water[i, j] > heightMap[i][j])
    //                    {
    //                        water[i, j] = heightMap[i][j];
    //                        qu.Enqueue(new int[] { i, j });
    //                    }
    //                }
    //            }
    //        }

    //        while (qu.Count > 0)
    //        {
    //            int[] curr = qu.Dequeue();
    //            int x = curr[0];
    //            int y = curr[1];
    //            for (int i = 0; i < 4; ++i)
    //            {
    //                int nx = x + dirs[i], ny = y + dirs[i + 1];
    //                if (nx < 0 || nx >= m || ny < 0 || ny >= n)
    //                {
    //                    continue;
    //                }
    //                if (water[x, y] < water[nx, ny] && water[nx, ny] > heightMap[nx][ny])
    //                {
    //                    water[nx, ny] = Math.Max(water[x, y], heightMap[nx][ny]);
    //                    qu.Enqueue(new int[] { nx, ny });
    //                }
    //            }
    //        }

    //        int res = 0;
    //        for (int i = 0; i < m; ++i)
    //        {
    //            for (int j = 0; j < n; ++j)
    //            {
    //                res += water[i, j] - heightMap[i][j];
    //            }
    //        }
    //        return res;
    //    }
    //}


    public class Solution2
    {
        public int TrapRainWater(int[][] heightMap)
        {
            int m = heightMap.Length;
            int n = heightMap[0].Length;

            //0<=x<m,0<=y<n
            bool IsEdge(int x, int y)
            {
                if (0 == x)
                {
                    return true;
                }
                if (0 == y)
                {
                    return true;
                }
                if (n-1 == x)
                {
                    return true;
                }
                if (m-1 == y)
                {
                    return true;
                }
                return false;
            }

            int max = 0;
            Queue<int[]> qu = new Queue<int[]>();
            int[,] waterHight = new int[m,n];


            int[] dir = new int[] { -1, 0, 1, 0, -1 };

            //get the max water height
            for (int x = 0; x < m; x++)
            {
                for (int y = 0; y < n; y++)
                {
                    max = max > heightMap[x][y] ? max : heightMap[x][y];
                }
            }

            //initialze the water heigt map
            for (int x = 0; x < m; x++)
            {
                for (int y = 0; y < n; y++)
                {
                    waterHight[x, y] = max;
                }
            }

            //initialze the queue
            for (int x = 0; x < m; x++)
            {
                for (int y = 0; y < n; y++)
                {
                    if (IsEdge(x, y))
                    {
                        if (waterHight[x, y] > heightMap[x][y])
                        {
                            waterHight[x, y] = heightMap[x][y];
                            qu.Enqueue(new int[] { x, y });// attention!
                        }
                        //qu.Enqueue(new int[] { x, y });
                    }
                }
            }

            while(qu.Count>0)
            {
                int[] cur = qu.Dequeue();
                int x = cur[0];
                int y = cur[1];
                //check the 4 point around (x,z), if one point is higher than the (x,z),enqueue it
                for(int i =0;i<4;i++)
                {
                    int newx = x + dir[i];
                    int newy = y + dir[i + 1];
                    if (newx < 0 || newx >= m || newy < 0 || newy >= n)
                        continue;
                    if (waterHight[x, y] < waterHight[newx, newy])
                    {
                        if (waterHight[newx, newy] > heightMap[newx][newy])
                        {
                            waterHight[newx, newy] = Math.Max(waterHight[x,y],heightMap[newx][newy]);
                            qu.Enqueue(new int[] { newx, newy });
                        }
                    }
                }

            }

            int res = 0;
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    res += waterHight[i, j] - heightMap[i][j];
                }
            }
            return res;

        }
    }


}
