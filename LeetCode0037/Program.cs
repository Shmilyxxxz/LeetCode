using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode037
{
    class Program           
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            char[][] source = new char[9][];


            //var result = new Solution().SolveSudoku(source);
        }
    }

    //public class Solution
    //{
    //    const int GridsNumber = 3;
    //    const int GridSize = 3;
    //    const char SpaceValue = '.';
    //    const char MinValue = '1';
    //    const char MaxValue = '9';

    //    public void SolveSudoku(char[][] board, char addValue, out bool hasSpace, out bool isError)
    //    {
    //        List<BitArray> RowList = new List<BitArray>();
    //        List<BitArray> ColumnList = new List<BitArray>();
    //        List<BitArray> SquareList = new List<BitArray>();

    //        for (int i=0;i<9;i++)
    //        {
    //            RowList.Add(new BitArray(9, false));
    //            ColumnList.Add(new BitArray(9, false));
    //            SquareList.Add(new BitArray(9, false));
    //        }

    //        //i是column 表示横坐标，j是row表示纵坐标，
    //        for (int i = 0; i < 9; i++)
    //        {
    //            for (int j = 0; j < 9; j++)
    //            {
    //                if(board[i][j]==SpaceValue)
    //                {

    //                }
    //                else //轮询到数字，修改Row Column Square
    //                {
    //                    int value = (int)board[i][j];
    //                    ColumnList[i][value] = true;
    //                    RowList[j][value] = true;
    //                    SquareList[(j/3)*3+i/3][value] = true;
    //                }
    //            }
    //        }    
    //    }

    //    //public char check





    //}

    public class Solution3
    {
        const int GridsNumber = 3;
        const int GridSize = 3;
        const char SpaceValue = '.';
        const char MinValue = '1';
        const char MaxValue = '9';

        public void SolveSudoku(char[][] board, char addValue, out bool hasSpace, out bool isError)
        {
            const char Error = default;

            bool hasModify;

            isError = false;

            do
            {
                hasSpace = false;
                hasModify = false;

                for (int i = 0; i < GridsNumber * GridSize; i++)
                {
                    for (int j = 0; j < GridsNumber * GridSize; j++)
                    {
                        if (board[i][j] == SpaceValue)
                        {
                            char value = Error;

                            for (char v = MinValue; v <= MaxValue; v++)
                            {
                                if (Can(board, i, j, v))
                                {
                                    if (value == Error)
                                    {
                                        value = v;
                                    }
                                    else
                                    {
                                        value = SpaceValue;

                                        break;
                                    }
                                }
                            }

                            if (value == Error)
                            {
                                isError = true;

                                return;
                            }

                            if (value == SpaceValue)
                            {
                                hasSpace = true;

                                continue;
                            }

                            board[i][j] = value;
                            board[i][j] += addValue;

                            hasModify = true;
                        }
                    }
                }

            } while (hasModify);
        }

        public void Recovery(char[][] board, bool isError)
        {
            for (int i = 0; i < GridsNumber * GridSize; i++)
            {
                for (int j = 0; j < GridsNumber * GridSize; j++)
                {
                    if (board[i][j] >= SpaceValue + MinValue)
                    {
                        if (isError)
                        {
                            // 错误的棋盘，还原。
                            board[i][j] = SpaceValue;
                        }
                        else
                        {
                            // 正确的棋盘，置为正常。
                            board[i][j] -= SpaceValue;
                        }
                    }
                }
            }
        }

        public void SolveSudoku(char[][] board)
        {
        Loop:

            SolveSudoku(board, default, out var hasSpace, out var isError);

            if (isError)
            {
                throw new NotSupportedException("Wrong board");
            }

            if (hasSpace)
            {
                char[] possibles = new char[4];

                for (int i = 0; i < GridsNumber * GridSize; i++)
                {
                    for (int j = 0; j < GridsNumber * GridSize; j++)
                    {
                        if (board[i][j] == SpaceValue)
                        {
                            int possibleCount = 0;

                            for (char v = MinValue; v <= MaxValue; v++)
                            {
                                if (Can(board, i, j, v))
                                {
                                    if (possibleCount < possibles.Length)
                                    {
                                        possibles[possibleCount] = v;
                                    }

                                    ++possibleCount;
                                }
                            }


                            if (possibleCount < possibles.Length)
                            {
                                int nonErrorCount = 0;

                                for (int k = 0; k < possibleCount; k++)
                                {
                                    board[i][j] = possibles[k];
                                    board[i][j] += SpaceValue;

                                    SolveSudoku(board, SpaceValue, out hasSpace, out isError);

                                    if (!isError && !hasSpace)
                                    {
                                        Recovery(board, false);

                                        goto Finish;
                                    }

                                    Recovery(board, true);

                                    if (!isError)
                                    {
                                        possibles[nonErrorCount] = possibles[k];

                                        ++nonErrorCount;
                                    }
                                }

                                if (nonErrorCount == 1)
                                {
                                    board[i][j] = possibles[0];

                                    goto Loop;
                                }
                            }
                        }
                    }
                }
            }

        Finish:

            Print(board);
        }

        public static void Print(char[][] board)
        {
            for (int i = 0; i < GridsNumber * GridSize; i++)
            {
                for (int j = 0; j < GridsNumber * GridSize; j++)
                {
                    Console.Write(board[i][j]);
                    Console.Write(' ');
                }

                Console.WriteLine();
            }

            Console.WriteLine("+++++++++++++++++");
        }

        public static bool Equal(char value, char comparison)
        {
            return value == comparison || value == comparison + SpaceValue;
        }

        public static bool Can(char[][] board, int x, int y, char value)
        {
            // 检查行是否有
            foreach (var item in board[x])
            {
                if (Equal(item, value))
                {
                    return false;
                }
            }

            // 检查列是否有
            foreach (var item in board)
            {
                if (Equal(item[y], value))
                {
                    return false;
                }
            }

            // 检查方格内是否有
            var tx = (x / GridSize) * GridSize;
            var ty = (y / GridSize) * GridSize;

            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    if (Equal(board[tx + i][ty + j], value))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }


    public class Solution2
    {
        //九列
        List<Dictionary<int, bool>> liCol = new List<Dictionary<int, bool>>();
        //九行
        List<Dictionary<int, bool>> liRow = new List<Dictionary<int, bool>>();
        //3*3格子 九个
        List<Dictionary<int, bool>> liBox = new List<Dictionary<int, bool>>();
        char[][] boardAllres = null;
        public void SolveSudoku(char[][] board)
        {
            //判断一共有多少个数字
            int hasNumCount = 0;
            Dictionary<int, bool> dicAllTemp = new Dictionary<int, bool>();
            //创建一个键值对集合存储数字是否出现过 
            for (int i = 1; i <= 9; i++)
            {
                dicAllTemp.Add(i, false);
            }
            for (int i = 0; i < 9; i++)
            {
                //存储对应的九列
                liCol.Add(new Dictionary<int, bool>(dicAllTemp));
                //存储对应的九行
                liRow.Add(new Dictionary<int, bool>(dicAllTemp));
                //存储对应的九个3*3格子
                liBox.Add(new Dictionary<int, bool>(dicAllTemp));
            }
            //遍历整个集合 将已出现的数字赋值为true 
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (board[i][j] != '.')
                    {
                        int temp = board[i][j] - 48;
                        liRow[i][temp] = true;
                        liCol[j][temp] = true;
                        int count = (i / 3) * 3 + j / 3;
                        liBox[count][temp] = true;
                        hasNumCount++;
                    }
                }
            }
            Recursive(board, hasNumCount, 0, 0);
            board = boardAllres;
        }

        public bool Recursive(char[][] board, int hasNumCount, int i, int j)
        {
            //81个数字代表已经填满了 直接返回结果
            if (hasNumCount == 81)
            {
                boardAllres = board;
                return true;
            }
            for (; i < board.Length; i++)
            {
                for (j = 0; j < board[0].Length; j++)
                {
                    if (board[i][j] == '.')
                    {
                        //查出该行对应的所有未使用的数字 一次遍历填入
                        List<int> liRes = liRow[i].Where(e => e.Value == false).Select(e => e.Key).ToList();
                        foreach (var item in liRes)
                        {
                            //判读位于那个格子 
                            int count = (i / 3) * 3 + j / 3;
                            if (liCol[j][item] == false && liBox[count][item] == false && liRow[i][item] == false)
                            {
                                //总数+1 对应的位置赋值为true
                                hasNumCount++;
                                liRow[i][item] = true;
                                liCol[j][item] = true;
                                liBox[count][item] = true;
                                //之所以加48为了将数字转为char类型存进去
                                board[i][j] = (char)(item + 48);
                                //递归 存在不符合就返回 结果为true只有一种情况 那就是已经完成了
                                if (Recursive(board, hasNumCount, i, 0))
                                {
                                    return true;
                                }
                                //不符合 将操作撤回到之前 
                                hasNumCount--;
                                board[i][j] = '.';
                                liRow[i][item] = false;
                                liCol[j][item] = false;
                                liBox[count][item] = false;
                            }
                        }
                        return false;
                    }
                }
            }
            return false;
        }
    }

    //public class Solution
    //{
    //    public void SolveSudoku(char[][] board)
    //    {
    //        BitArray[] Row = new BitArray[9];
    //        BitArray[] Column = new BitArray[9];
    //        BitArray[] Square = new BitArray[9];
    //        for(int i=0;i<9;i++)
    //        {
    //            Row[i] = new BitArray(9);
    //            Column[i] = new BitArray(9);
    //            Square[i] = new BitArray(9);
    //        }

    //        int[,] restCount = new int[9, 9];
    //        int result = 0;

    //        do
    //        {
    //            for (int i = 0; i < 9; i++)
    //            {
    //                for (int j = 0; j < 9; j++)
    //                {
    //                    // value is unknown
    //                    //if(board[i][j]!=Convert.ToChar("."))
    //                    if (board[i][j] != '.')
    //                    {
    //                        var value = CheckValue(Row[i], Column[j], Square[i / 3 + j / 3], out restCount[i, j]);
    //                        if (restCount[i, j] == 1)
    //                        {
    //                            board[i][j] = value;

    //                            Row[i][j] = true;
    //                            Column[j][i] = true;
    //                            Square[i / 3 + j / 3][i % 3 + j % 3] = true;
    //                            result++;
    //                        }
    //                    }
    //                    // value is known
    //                    else
    //                    {
    //                        Row[i][j] = true;
    //                        Column[j][i] = true;
    //                        Square[i / 3 + j / 3][i % 3 + j % 3] = true;
    //                        result++;
    //                    }

    //                }
    //            }
    //        } while (result != 81);
    //    }

    //    public char CheckValue(BitArray a, BitArray b, BitArray c, out int count)
    //    {
    //        char result = '.' ;
    //        count = 0;
    //        BitArray r = new BitArray(a);
    //        r = r.Or(b).Or(c);
    //        for(int i=0; i<9;i++)
    //        {
    //            if(!r[i])
    //            {
    //                result = (char)i;
    //            }
    //            else
    //            {
    //                count++;
    //            }
    //        }

    //        if(count!=1)
    //        {
    //            result = '.';
    //        }

    //        return result ;
    //    }



    //}




}
