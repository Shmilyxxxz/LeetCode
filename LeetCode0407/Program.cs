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
            Console.WriteLine(new Solution().TrapRainWater(test));
            Console.WriteLine(new Solution2().TrapRainWater(test));
        }
    }

    public class Solution
    {
        public int TrapRainWater(int[][] heightMap)
        {
            int m = heightMap.Length;
            int n = heightMap[0].Length;
            int[] dirs = { -1, 0, 1, 0, -1 };
            int maxHeight = 0;

            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    maxHeight = Math.Max(maxHeight, heightMap[i][j]);
                }
            }
            int[,] water = new int[m, n];
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    water[i, j] = maxHeight;
                }
            }

            Queue<int[]> qu = new Queue<int[]>();
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (i == 0 || i == m - 1 || j == 0 || j == n - 1)
                    {
                        if (water[i, j] > heightMap[i][j])
                        {
                            water[i, j] = heightMap[i][j];
                            qu.Enqueue(new int[] { i, j });
                        }
                    }
                }
            }

            while (qu.Count > 0)
            {
                int[] curr = qu.Dequeue();
                int x = curr[0];
                int y = curr[1];
                for (int i = 0; i < 4; ++i)
                {
                    int nx = x + dirs[i], ny = y + dirs[i + 1];
                    if (nx < 0 || nx >= m || ny < 0 || ny >= n)
                    {
                        continue;
                    }
                    if (water[x, y] < water[nx, ny] && water[nx, ny] > heightMap[nx][ny])
                    {
                        water[nx, ny] = Math.Max(water[x, y], heightMap[nx][ny]);
                        qu.Enqueue(new int[] { nx, ny });
                    }
                }
            }

            int res = 0;
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    res += water[i, j] - heightMap[i][j];
                }
            }
            return res;
        }
    }


    public class Solution2
    {
        public int TrapRainWater(int[][] heightMap)
        {
            int m = heightMap.Length;
            int n = heightMap[0].Length;

            bool IsEdge(int z, int x)
            {
                if (0 == z)
                {
                    return true;
                }
                if (0 == x)
                {
                    return true;
                }
                if (n-1 == z)
                {
                    return true;
                }
                if (m-1 == x)
                {
                    return true;
                }
                return false;
            }

            int max = 0;
            Queue<int[]> qu = new Queue<int[]>();
            int[,] waterHight = new int[m,n];

            //get the max water height
            for (int z = 0; z < m; z++)
            {
                for (int x = 0; x < n; x++)
                {
                    max = max > heightMap[z][x] ? max : heightMap[z][x];
                }
            }

            //initialze the water heigt map
            for (int z = 0; z < m; z++)
            {
                for (int x = 0; x < n; x++)
                {
                    waterHight[z, x] = max;
                }
            }

            //initialze the queue
            for (int z = 0; z < m; z++)
            {
                for (int x = 0; x < n; x++)
                {
                    if (IsEdge(z, x))
                    {
                        if(waterHight[z,x]>heightMap[z][x])
                        {
                            waterHight[z, x] = heightMap[z][x];
                        }
                        qu.Enqueue(new int[] { x, z });
                    }
                }
            }
            int[] dir = new int[] { -1, 0, 1, 0, -1 };
            while(qu.Count>0)
            {
                int[] cur = qu.Dequeue();
                int x = cur[0];
                int z = cur[1];
                //check the 4 point around (x,z), if one point is higher than the (x,z),enqueue it
                for(int i =0;i<4;i++)
                {
                    int newx = x + dir[i];
                    int newz = z + dir[i + 1];
                    if (newx < 0 || newx >= n||newz<0||newz>=m)
                        continue;
                    if (waterHight[z, x] > waterHight[newz, newx])
                    {
                        if (waterHight[newz, newx] > heightMap[newz][newx])
                        {
                            waterHight[newz, newx] = heightMap[newz][newx];
                            qu.Enqueue(new int[] { newz, newx });
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
