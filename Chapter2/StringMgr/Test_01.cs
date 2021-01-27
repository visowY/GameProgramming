using System;

namespace StringMgr
{
    public class Test_01
    {
        public static void Test()
        {
            var myString = "my \"so-called\" life";
            myString = "Go to your c\\: drive";
            myString = @"Go to your c\: drive";
            myString = string.Format("{0:C}", 123.45);
            Console.WriteLine(myString);
        }

    }
}