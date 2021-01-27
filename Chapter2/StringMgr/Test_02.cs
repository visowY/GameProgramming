using System;
using System.Text.RegularExpressions;

namespace StringMgr
{
    public class Test_02
    {
        public  static void Test()
        {
            Regex reg =new Regex("^cat");
//            reg.Match("catdog");
            Console.WriteLine(reg.Match("catdog"));
            
        }
    }
}