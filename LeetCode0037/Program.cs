using System;
using System.Collections;
using System.Collections.Generic;

namespace LeetCode037
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            char[][] source = new char[][]
            {
                new char[] {'.','.','.','.','.','.','.','.','.'},
                new char[] {'.','.','.','.','.','.','.','.','.'},
                new char[] {'.','.','.','.','.','.','.','.','.'},
                new char[] {'.','.','.','.','.','.','.','.','.'},
                new char[] {'.','.','.','.','.','.','.','.','.'},
                new char[] {'.','.','.','.','.','.','.','.','.'},
                new char[] {'.','.','.','.','.','.','.','.','.'},
                new char[] {'.','.','.','.','.','.','.','.','.'},
                new char[] {'.','.','.','.','.','.','.','.','.'}
            };

            //var result = new Solution().SolveSudoku(source);
        }
    }



    public class Solution
    {
        public void SolveSudoku(char[][] board)
        {
            BitArray[] Row = new BitArray[9];
            BitArray[] Column = new BitArray[9];
            BitArray[] Square = new BitArray[9];

            int[,] restCount = new int[9, 9];

            for (int i=0;i<9;i++)
            {
                for(int j=0;j<9;j++)
                {
                    // value is unknown
                    //if(board[i][j]!=Convert.ToChar("."))
                    if (board[i][j] != '.')
                    {
                        var value = ChekcValue(Row[i],Column[j],Square[i/3+j/3],out restCount[i,j]);
                        if(restCount[i, j]==1)
                        {
                            board[i][j] = value;

                            Row[i][j] = true;
                            Column[j][i] = true;
                            Square[i / 3 + j / 3][i % 3 + j % 3] = true;
                        }
                    }
                    // value is known
                    else
                    {
                        Row[i][j] = true;
                        Column[j][i] = true;
                        Square[i / 3 + j / 3][i % 3 + j % 3] = true;
                    }

                }
            }
        }

        public char ChekcValue(BitArray a, BitArray b, BitArray c, out int count)
        {
            char result = '.' ;
            count = 0;
            var r = a.Or(b).Or(c);
            for(int i=0; i<9;i++)
            {
                if(!r[i])
                {
                    result = (char)i;
                }
                else
                {
                    count++;
                }
            }

            if(count!=1)
            {
                result = '.';
            }

            return result ;
        }



    }




}
