using System;
using System.Threading;
using System.Threading.Tasks;
namespace asynchronous
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t1 = Task1();
            Task t2 = Task2();
            Task.WaitAll(t1,t2);
        }
        public static bool isPrime(int n)
        {

            bool check = true;
            if (n < 2) return false;
            for (int i = 2; i < n; i++)
                if (n % i == 0) check = false;
            if (check) return true;
            else return false;
        }

        public static void PrintPrimeT1(int n, ConsoleColor color)
        {
            
            for (int i = 0; i <= n; i++)
            {
                if (isPrime(i))
                {
                    Console.ForegroundColor = color;
                    Console.WriteLine(i);
                    Thread.Sleep(2000);
                }
            }
        }
        public static void PrintPrimeT2(int n, ConsoleColor color)
        {
            
            for (int i = 0; i <= n; i++)
            {
                if (isPrime(i))
                {
                    Console.ForegroundColor = color;
                    Console.WriteLine(i);
                    Thread.Sleep(3000);
                }
            }
        }
        public static async Task Task1()
        {
            Task t1 = new Task(
                () =>
                {
                    PrintPrimeT1(100,ConsoleColor.Blue);

                }
            );
            t1.Start();
            await t1;
            Console.WriteLine("T1 Finished");
        }
        public static async Task Task2()
        {
            Task t2 = new Task(
                () =>
                {
                    PrintPrimeT2(100,ConsoleColor.Red);

                }
            );
            t2.Start();
            await t2;
            Console.WriteLine("T2 Finished");
        }
    }
}
