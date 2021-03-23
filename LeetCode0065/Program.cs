using System;

namespace LeetCode0065
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
        //["2", "0089", "-0.1", "+3.14", "4.", "-.9", "2e10", "-90E3", "3e+7", "+6e-1", "53.5e93", "-123.456e789"]
        //["abc", "1a", "1e", "e3", "99e2.5", "--6", "-+3", "95a54e53"]
        public bool IsNumber(string s)
        {
            
            int startIndex = 0;
            int endIndex = s.Length - 1;
            //delete the space at the start and end position.
            for(int i =0;i<s.Length;i++)
            {
                if(s[i]!=' ')
                {
                    startIndex = i;
                    break;
                }
            }
            for (int i = s.Length; i >=0 ; i--)
            {
                if (s[i] != ' ')
                {
                    endIndex = i;
                    break;
                }
            }
            char[] resource = s.Substring(startIndex, endIndex - startIndex).ToCharArray();

            int[,] transMt = new int[9, 6]{
                {3,1,0,4,-1,-1},
                {3,-1,-1,4,-1,-1},
                {2,-1,8,-1,5,-1},
                {3,-1,8,2,5,-1},
                {2,-1,-1,-1,-1,-1},
                {7,6,-1,-1,-1,-1},
                {7,-1,-1,-1,-1,-1},
                {7,-1,8,-1,-1,-1},
                {-1,-1,8,-1,-1,-1},
            };

            int finishSta = 0b110001100; //0b表示二进制数
            int state = 0;
            for (int i = 0; i < s.Length; i++)
            {
                state = transMt[state, hehe(s[i])];
                if (state == -1)
                {
                    return false;
                }
            }
            return (finishSta & (1 << state)) != 0;

            //State result = State.STATE_INITIAL;
            //for(int i=0;i<resource.Length;i++)
            //{
            //    var chartype = ConverttoCharType(resource[i]);
            //    switch (result)
            //    {
            //        case State.STATE_INITIAL:
            //            break;
            //        case State.STATE_SIGH:
            //            break;
            //        case State.STATE_INTERGER:
            //            break;
            //        case State.STATE_POINT:
            //            break;
            //        case State.STATE_POINT_WITHOUT_INIT:
            //            break;
            //        case State.STATE_FRACTIONM:
            //            break;
            //        case State.STATE_EXP:
            //            break;
            //        case State.STATE_EXP_SIGH:
            //            break;
            //        case State.STATE_EXP_NUMBER:
            //            break;
            //        case State.STATE_END:
            //            break;
            //    }


            //}

            //return result == State.STATE_INTERGER || result == State.STATE_POINT || result == State.STATE_FRACTIONM ||
            //    result == State.STATE_EXP_NUMBER|| result == State.STATE_END;
            
        }

        private int hehe(char v)
        {
            switch (v)
            {
                case '+':
                case '-':
                    return 1;
                case ' ':
                    return 2;
                case '.':
                    return 3;
                case 'e':
                    return 4;
                default:
                    if (v >= '0' && v <= '9') return 0;
                    else return 5;
            }
        }

        CharType ConverttoCharType(char ch)
        {
            if (ch >= '0' && ch <= '9')
            {
                return CharType.CHAR_NUMBER;
            }
            else if (ch == 'e' || ch == 'E')
            {
                return CharType.CHAR_EXP;
            }
            else if (ch == '.')
            {
                return CharType.CHAR_POINT;
            }
            else if (ch == '+' || ch == '-')
            {
                return CharType.CHAR_SIGN;
            }
            else
            {
                return CharType.CHAR_ILLEGAL;
            }
        }

        enum State
        {
            STATE_INITIAL,
            STATE_SIGH,
            STATE_INTERGER,
            STATE_POINT,
            STATE_POINT_WITHOUT_INIT,
            STATE_FRACTIONM,
            STATE_EXP,
            STATE_EXP_SIGH,
            STATE_EXP_NUMBER,
            STATE_END   //不删除结尾空格的情况下才需要使用
        }

        enum CharType
        {
            CHAR_NUMBER,
            CHAR_EXP,
            CHAR_POINT,
            CHAR_SIGN,
            CHAR_ILLEGAL,
        };





    }




}
