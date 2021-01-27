using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace StringMgr
{
    internal class Program
    {
        public static void Main(string[] args)
        {
//            Test1();
            Test2();
        }

        #region 匹配

        //元字符
        public static void Test1()
        {
            //注意完全匹配 & 部分匹配的区别
//            Console.WriteLine(Regex.IsMatch("643493306@123.com", @"^\d+@\w+\.com$"));

            //请用户输入一个 10 - 25 任意数字

//            while (true)
//            {
//                string m = Console.ReadLine();
//
//               var b =  Regex.IsMatch(m, @"^(1[0-9])|(2[0-5])$");
//               Console.WriteLine(b);
//            }

//            //判断身份证号码
//
//            while (true)
//            {
//                Console.WriteLine("输入身份证号码");
//                string idNu = Console.ReadLine();
//                 
//            }

            //判断是否是合法邮箱
            /*
             *  xxx @ .com   //  xx @ .cn 
             */
//
//            while (true)
//            {
//                Console.WriteLine("输入邮箱地址");
//                string input = Console.ReadLine();
//
//                Regex.IsMatch(input, @"^[1-9a-zA-Z._]+@[1-9a-zA-Z]+\.(com|cn)$");
//            }

            //匹配ip地址

//            string pattern = @"^(\d{1,3}\.){3}\d{1,3}$";
//            
//            CwRepeatReg(pattern);

            //判断是否是合法日期格式

//            string pattern = @"^(\d{4}-(0[1-9]|1[12])-[0-3]\d)$";
//            CwRepeatReg(pattern);

            //判断是否是合法的url地址
        }


        public static void CwRepeatReg(string pattern)
        {
            while (true)
            {
                Console.WriteLine("请输入需要验证的字符串");
                String input = Console.ReadLine();
                var b = Regex.IsMatch(input, pattern);
                Console.WriteLine(b);
                Console.WriteLine("===============");
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        #endregion

        #region 字符串提取

        public static void Test2()
        {
//            string s = "大叫好啊，hello， 2021年 1月 12日 是个好热字 啊， 9090，8888";
//
//            var k = Regex.Match(s, @"\d+"); // match 提取1个匹配
//
//            Console.WriteLine(k.Value);
//
//            var m = Regex.Matches(s, @"\d+"); //matchs 提取字符串中的所有匹配
//            foreach (Match o in m)
//            {
//                Console.WriteLine(o.Value);
//            }

            //提取所有的邮箱地址
            
            
            //提取组， 对已经提取的数字实现分组功能
        }

        #endregion
    }
}