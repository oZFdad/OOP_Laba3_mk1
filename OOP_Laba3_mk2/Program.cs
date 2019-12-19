using System;
using System.Diagnostics;
using StorageForPain;


namespace OOP_Laba3_mk2
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch time = new Stopwatch();
            time.Start();

            Storage storage = new Storage();
            storage.CreatRandomItems(30);
            storage.LetsDoSomething(50);

            time.Stop();
            Console.WriteLine("\nПрограмма выполнена за {0} секунд", (time.ElapsedMilliseconds / 1000.0).ToString());
            Console.ReadKey();
        }
    }
}
