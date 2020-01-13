using System;
using System.Diagnostics;
using System.Threading;
using StorageForPainDLL;


namespace OOP_Laba3_mk2
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch time = new Stopwatch();
            time.Start();

            Storage storage = new Storage();
            int countItems = 30;
            int countActions = 50;
            FillStorage(countItems, storage);
            ChooseAction(countActions, storage);

            time.Stop();
            Console.WriteLine("\nПрограмма выполнена за {0} секунд", (time.ElapsedMilliseconds / 1000.0).ToString());
            Console.ReadKey();
        }

        private static void FillStorage (int count, Storage storage)
        {
            for (int i = 0; i < count; i++)
            {
                Random rnd = new Random();
                int rand;
                rand = rnd.Next(0, 3);
                Vbr core = new Vbr(rnd);
                if (rand == 0)
                {
                    storage.AddItem(new Circle(core));
                }
                else if (rand == 1)
                {
                    storage.AddItem(new Triangle(core));
                }
                else
                {
                    storage.AddItem(new Square(core));
                }
                Thread.Sleep(20);
            }
            //return storage;
        }

        private static void ChooseAction (int count, Storage storage)
        {
            Random rnd = new Random();
            for (int i = 0; i < count; i++)
            {
                int rand;
                Vbr core = new Vbr(rnd);
                rand = rnd.Next(0, 6);
                if (rand == 0) //Добавление элемента
                {
                    int buf = rnd.Next(0, 2);
                    if (buf == 0)
                    {
                        storage.AddItem(new Circle(core));
                    }
                    else if (buf == 1)
                    {
                        storage.AddItem(new Triangle(core));
                    }
                    else
                    {
                        storage.AddItem(new Square(core));
                    }
                    Console.WriteLine("Успешно добавлен элемент");
                }
                else if (rand == 1)
                {
                    if (storage.GetMaxIndex() != 0)
                    {
                        storage.DeleteItem(rnd.Next(1, storage.GetMaxIndex()));
                        Console.WriteLine("Успешно удален элемент по индексу");
                    }
                }
                else if (rand == 2)
                {
                    if (storage.GetMaxIndex() != 0)
                    {
                        storage.DeleteItem();
                        Console.WriteLine("Успешно удален последний элемент");
                    }
                }
                else if (rand == 3)
                {
                    Console.WriteLine("Элементов в хранилище - {0}", storage.GetMaxIndex());
                }
                else if (rand == 4)
                {
                    if (storage.GetMaxIndex() != 0)
                    {
                        storage.GetItem().Display();
                    }
                }
                else
                {
                    if (storage.GetMaxIndex() != 0)
                    {
                        storage.GetItem(rnd.Next(1, storage.GetMaxIndex())).Display();
                    }
                }
                Thread.Sleep(20);
            }
        }
    }


}
