/*
 *  348 设计井字棋
    请在 n × n 的棋盘上，实现一个判定井字棋（Tic-Tac-Toe）胜负的神器，判断每一次玩家落子后，是否有胜出的玩家。

    在这个井字棋游戏中，会有 2 名玩家，他们将轮流在棋盘上放置自己的棋子。

    在实现这个判定器的过程中，你可以假设以下这些规则一定成立：

          1. 每一步棋都是在棋盘内的，并且只能被放置在一个空的格子里；

          2. 一旦游戏中有一名玩家胜出的话，游戏将不能再继续；

          3. 一个玩家如果在同一行、同一列或者同一斜对角线上都放置了自己的棋子，那么他便获得胜利。

    示例:

    给定棋盘边长 n = 3, 玩家 1 的棋子符号是 "X"，玩家 2 的棋子符号是 "O"。

    TicTacToe toe = new TicTacToe(3);

    toe.move(0, 0, 1); -> 函数返回 0 (此时，暂时没有玩家赢得这场对决)
    |X| | |
    | | | |    // 玩家 1 在 (0, 0) 落子。
    | | | |

    toe.move(0, 2, 2); -> 函数返回 0 (暂时没有玩家赢得本场比赛)
    |X| |O|
    | | | |    // 玩家 2 在 (0, 2) 落子。
    | | | |

    toe.move(2, 2, 1); -> 函数返回 0 (暂时没有玩家赢得比赛)
    |X| |O|
    | | | |    // 玩家 1 在 (2, 2) 落子。
    | | |X|

    toe.move(1, 1, 2); -> 函数返回 0 (暂没有玩家赢得比赛)
    |X| |O|
    | |O| |    // 玩家 2 在 (1, 1) 落子。
    | | |X|

    toe.move(2, 0, 1); -> 函数返回 0 (暂无玩家赢得比赛)
    |X| |O|
    | |O| |    // 玩家 1 在 (2, 0) 落子。
    |X| |X|

    toe.move(1, 0, 2); -> 函数返回 0 (没有玩家赢得比赛)
    |X| |O|
    |O|O| |    // 玩家 2 在 (1, 0) 落子.
    |X| |X|

    toe.move(2, 1, 1); -> 函数返回 1 (此时，玩家 1 赢得了该场比赛)
    |X| |O|
    |O|O| |    // 玩家 1 在 (2, 1) 落子。
    |X|X|X|

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/design-tic-tac-toe
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
 */


using System;

namespace leetCode3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class TicTacToe
    {
        private int[,] Array;
        private int[] rowSum;
        private int[] colunmSum;
        private int diagonal;
        private int reverseDiagonal;
        private int winnerSum;
        /** Initialize your data structure here. */
        public TicTacToe(int n)
        {
            Array = new int[n, n];
            rowSum = new int[n];
            colunmSum = new int[n];
            diagonal = 0;
            reverseDiagonal = 0;
            winnerSum = n;
        }

        /** Player {player} makes a move at ({row}, {col}).
            @param row The row of the board.
            @param col The column of the board.
            @param player The player, can be either 1 or 2.
            @return The current winning condition, can be either:
                    0: No one wins.
                    1: Player 1 wins.
                    2: Player 2 wins. */
        public int Move(int row, int col, int player)
        {
            int playerFlag = (player == 1)?(1) : (-1) ;

            Array[row, col] = player;

            rowSum[row] += playerFlag;
            if (rowSum[row] == winnerSum)
                return player;

            colunmSum[col] += playerFlag;
            if (colunmSum[col] == winnerSum)
                return player;

            if(row==col)
            {
                diagonal += playerFlag;
                if (diagonal == winnerSum)
                    return player;
            }

            if (row+col-1==winnerSum)
            {
                reverseDiagonal += playerFlag;
                if (reverseDiagonal == winnerSum)
                    return player;
            }
            return 0;
        }
    }

    /**
     * Your TicTacToe object will be instantiated and called as such:
     * TicTacToe obj = new TicTacToe(n);
     * int param_1 = obj.Move(row,col,player);
     */


}
