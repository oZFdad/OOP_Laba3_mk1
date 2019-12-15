
using System;
using System.Diagnostics;

namespace OOP_Laba3_mk1
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch time = new Stopwatch();
            time.Start();
            Storage storage = new Storage(100);
            storage.LetsDoSomething(100);
            time.Stop();
            Console.WriteLine("\nПрограмма выполнена за {0} секунд", (time.ElapsedMilliseconds / 1000.0).ToString());
            Console.ReadKey();
        }
    }
}
