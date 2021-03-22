/*
 *  273. 整数转换英文表示
    将非负整数 num 转换为其对应的英文表示。
    
    示例 1：
    输入：num = 123
    输出："One Hundred Twenty Three"
    
    示例 2：
    输入：num = 12345
    输出："Twelve Thousand Three Hundred Forty Five"
    
    示例 3：
    输入：num = 1234567
    输出："One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven"
    
    示例 4：
    输入：num = 1234567891
    输出："One Billion Two Hundred Thirty Four Million Five Hundred Sixty Seven Thousand Eight Hundred Ninety One"

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/integer-to-english-words
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
 */
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace LeetCode0273
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int num = Convert.ToInt32(Console.ReadLine());
                if(num>=0)
                {
                    string str = NumberToWords(num);
                    Console.WriteLine($"{num}:{str}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static string NumberToWords(int num)
        {
            StringBuilder result = new StringBuilder();
            int UnitIndex = 0;
            
            while(num>0)
            {
                if (num % 1000 != 0)
                {
                    //Add the unit 
                    result.Insert(0, ThousandUnit[UnitIndex]);
                    result.Insert(0,GetUnderThousandChar(num%1000));
                }
                UnitIndex++;
                num /= 1000;
            }
            return result.ToString();
        }
        static string GetUnderThousandChar(int num)
        {
            StringBuilder result = new StringBuilder();
            if (num > 999)
                return null;
            if (num < 20)
            {
                result.Append(ZeroToTwenty.GetValueOrDefault(num));
            }
            else if (num < 100)
            {
                result.Append(TenValue.GetValueOrDefault(num / 10));
                result.Append(ZeroToTwenty.GetValueOrDefault(num % 10)) ;
            }
            else
            {
                result.Append(ZeroToTwenty.GetValueOrDefault(num / 100));
                result.Append(" Hundred ");
                result.Append(GetUnderThousandChar(num / 10));
                //result.Append(ZeroToTwenty.GetValueOrDefault(num % 10));
            }

            return result.ToString();
        }

        static Dictionary<int, string> ZeroToTwenty = new Dictionary<int, string>()
        {
            {0,""},
            {1,"One" },
            {2,"Two" },
            {3,"Three" },
            {4,"Four" },
            {5,"Five" },
            {6,"Six" },
            {7,"Seven" },
            {8,"Eight" },
            {9,"Nine" },
            {10,"Ten" },
            {11,"One" },
            {12,"Two" },
            {13,"Three" },
            {14,"Four" },
            {15,"Five" },
            {16,"Six" },
            {17,"Seven" },
            {18,"Eight" },
            {19,"Nine" },
        };

        static Dictionary<int, string> TenValue = new Dictionary<int, string>()
        {
            {0,"" },
            {1,"" },
            {2,"Twenty " },
            {3,"Thirty " },
            {4,"Forty " },
            {5,"Fifty " },
            {6,"Sixty " },
            {7,"Seventy " },
            {8,"Eightty " },
            {9,"Ninty " },
        };

        static string[] ThousandUnit = new string[]
            {
                " ",
                " Thousand ",
                " Million ",
                " Billion "
            };







    }
}
