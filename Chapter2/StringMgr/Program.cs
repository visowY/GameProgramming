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
//            Test2();
              Test3();
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
            
            
            //C:\windows\testb.txt 
            //提取文件名

//            string input = @"C:\windows\testb.txt";
//
//            var match = Regex.Match(input, @"[a-zA-Z]+\.[a-zA-Z]+");
//            
//            Console.WriteLine(match.Value);
            
            //使用提取组实现

            //提取组， 对已经提取的数字实现分组功能
            
            //贪婪模式
            
            
            



        }

        #endregion
        
        #region 正则替换

        public static void Test3()
        {
//            string msg = "你好aaaa好aaa，哈哈a，好aa";

//            msg = Regex.Replace(msg, @"a+", "A");
//            Console.WriteLine(msg);
    
              //在正则替换中使用提取组  
//            string msg2 = "hello 'welcome' to 'china'";
//            msg2 = Regex.Replace(msg2, @"'(.+?)'", "[$1]");
//            Console.WriteLine(msg2);
            
              //
//              string msg3 = "我的生日是05/21/2010耶";
//              msg3 = Regex.Replace(msg3, @"(\d+)/(\d+)/(\d+)", "$3-$1-$2");
//              Console.WriteLine(msg3);
            
            //隐藏手机号码
//            string msg4 = "仰仗123456789 马戏120987766";
//            msg4 = Regex.Replace(msg4, @"(\d{3})\d{3}(\d+)", "$1***$2");
//            Console.WriteLine(msg4);

            //邮箱*号替换
//            string msg5 = "我的邮箱 643493305@qq.com";
//            msg5 = Regex.Replace(msg5, @"(\w+)(@\w+.com)", () =>return "$2";
//            }, RegexOptions.ECMAScript);

            //单词边界
            
            //反向引用=

            string msg6 = "AAAABBBBBBBCCCCCCC";
            msg6 = Regex.Replace(msg6, @"(.)\1+", "$1");  // \1 标示引用分组
            Console.WriteLine(msg6);

        }

        #endregion 
    }
}