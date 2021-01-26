using System;
using System.Threading;

namespace AysncProGramming
{
    public class Test_01
    {
        public const int Repetitions = 1_000;


        public static void Test()
        {
            ThreadStart threadStart = DoWork;
            Thread thread = new Thread(threadStart);
            thread.Start();
            for (int count = 0; count < Repetitions; count++)
            {
                Console.Write('-');
            }

            thread.Join();
        }


        public static void DoWork()
        {
            for (int count = 0; count < Repetitions; count++)
            {
                Console.Write('+');
            }
        }
    }
    
    
}