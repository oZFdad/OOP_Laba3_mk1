using System;
using System.Threading;

namespace Storage
{
    public abstract class Shape
    {
        protected int x, y;
        protected double r;
        protected bool flag = false;

        public Shape(Vbr value)
        {
            x = value.x;
            y = value.y;
            r = value.r;
        }

        public Shape(int x1, int y1, double r1)
        {
            x = x1;
            y = y1;
            r = r1;
        }

        public abstract void Display();
        public abstract void Move(Vbr track);
        public abstract void ChangeR(Vbr track); // изменение радиуса
    }

    class Triangle : Shape
    {
        public Triangle(Vbr value) : base(value)
        {
        }

        public override void ChangeR(Vbr track)
        {
            
        }

        public override void Display()
        {
            Console.WriteLine("Это правильный треугольник с координатами центра описаной окружности Х={0} Y={1} и радиусом R={2}", x, y, r );
        }

        public override void Move(Vbr track)
        {
            
        }
    }

    class Square : Shape
    {
        public Square(Vbr value) : base(value)
        {
        }

        public override void ChangeR(Vbr track)
        {
          
        }

        public override void Display()
        {
            Console.WriteLine("Это квадрат с координатами центра описаной окружности Х={0} Y={1} и радиусом R={2}", x, y, r);
        }

        public override void Move(Vbr track)
        {
            
        }
    }

    public class Circle : Shape
    {
        public Circle(Vbr value) : base(value)
        {
        }

        public Circle(int x1, int y1, double r1) : base (x1, y1, r1)
        {
        }

        public override void ChangeR(Vbr track)
        {
            
        }

        public override void Display()
        {
            Console.WriteLine("Это окружность с центром Х={0} Y={1} и радиусом R={2}", x, y, r);
        }

        public override void Move(Vbr track)
        {
            
        }
    }

    public class Storage
    {
        Shape [] box;
        int maxIndex, currentIndex=0, maxSize; // количество элементов, индекс текущего выбраного элемента, размер хранилища
        public Storage(int value)
        {
            maxIndex = value;
            maxSize = value + value / 5; // предполагалось, что будет всего 5 команд, теоретически не более 20% из них будут командами  добавления элемента
            box = new Shape [maxSize];
            Vbr rnd = new Vbr();
            for (int i = 0; i < value; i++)
            {
                if (rnd.item == 0)
                {
                    box[i] = new Triangle(rnd);
                }
                else if (rnd.item == 1)
                {
                    box[i] = new Square(rnd);
                }
                else
                {
                    box[i] = new Circle(rnd);
                }
                Thread.Sleep(20);
                rnd = new Vbr();
                Console.WriteLine("Создание {0}-го элемента завершено",i);
            }
        }

        Storage(Storage oldStorage) // первый вариант расширения хранилища (но что то пошло не так), оставим как конструктор копирования, может пригодится
        {
            maxIndex = oldStorage.maxIndex;
            maxSize = oldStorage.maxSize + oldStorage.maxSize / 5;
            box = new Shape[maxSize];
            for(int i = 0; i < maxIndex; i++)
            {
                box[i] = oldStorage.box[i];
            }
        }

        public void CreateItem (int index, Shape item) //добавление элемента
        {
            if (CheckSpace())
            {
                Shape[] bufer = new Shape[maxSize + maxSize / 5]; // увеличение размерности
                for(int i = 0; i < maxSize; i++)
                {
                    bufer[i] = box[i];
                }
                box = bufer;
            }
            for(int i = maxIndex - 1; i >= index; i--) //сдвиг элементов
            {
                box[i + 1] = box[i];
            }
            box[index] = item;
            maxIndex++;
            Console.WriteLine("Добавлен новый элемент на {0}-ю позицию", index);
        }

        public void DeleteItem (int index)//удаление элемента
        {
            if (index < maxIndex)
            {
                for(int i = index; i < maxIndex - 1; i++)
                {
                    box[i] = box[i + 1];
                }
                maxIndex--;
                Array.Clear(box, maxIndex, 1);
                Console.WriteLine("Удален {0}-й элемент", index);
            }
        }

        public int GetCurrentIndex()//получение текущего указателя
        {
            return currentIndex;
        }

        public void Next()//+1 к указателю
        {
            if (currentIndex<maxIndex)
            {
                currentIndex++;
                Console.WriteLine("Указатель перемещен на {0}-ю позицию", currentIndex);
            }
        }

        public void Return()//-1 к указателю
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                Console.WriteLine("Указатель перемещен на {0}-ю позицию", currentIndex);
            }
        }

        public void UseThisItem() // показать на ком указатель
        {
            if (currentIndex < maxIndex)
            {
                box[currentIndex].Display();
            }
        }

        public void UseCurentItem(int index) // что лежит под указателем
        {
            if (index < maxIndex)
            {
                box[index].Display();
                currentIndex = index;
            }
        }

        public void UseNextItem() // показать кто лежит дальше по указателю
        {
            if (currentIndex < maxIndex - 1)
            {
                box[currentIndex + 1].Display();
            }
        }

        public void UseAllItem() // показать все элементы
        {
            for(int i = 0; i < maxIndex; i++)
            {
                box[i].Display();
            }
        }

        private bool CheckSpace() // проверка свободных мест
        {
            if(maxIndex >= maxSize)
            {
                return true;
            }
            return false;
        }

        public int CheckMaxIndex() // сколько итемов лежит
        {
            return maxIndex;
        }

        public void LetsDoSomething (int iterator)
        {
            Vbr rnd = new Vbr();
            for(int i = 0; i < iterator; i++)
            {
                Console.WriteLine();
                Console.WriteLine("{0}-я итерация", i + 1);
                if (rnd.toBe == 0)
                {
                    Console.WriteLine("В хранилище {0} элементов",CheckMaxIndex());
                }
                else if (rnd.toBe == 1)
                {
                    UseAllItem();
                }
                else if (rnd.toBe == 2)
                {
                    UseNextItem();
                }
                else if (rnd.toBe == 3)
                {
                    Random key = new Random();
                    UseCurentItem(key.Next(0,maxIndex));
                }
                else if (rnd.toBe == 4)
                {
                    UseThisItem();
                }
                else if (rnd.toBe == 5)
                {
                    Return();
                }
                else if (rnd.toBe == 6)
                {
                    Next();
                }
                else if (rnd.toBe == 7)
                {
                    Console.WriteLine("Указатель на {0}-м индексе", GetCurrentIndex()); // проверь

                }
                else if (rnd.toBe == 8)
                {
                    Random key = new Random();
                    DeleteItem(key.Next(0, maxIndex));
                }
                else
                {
                    Random key = new Random();
                    CreateItem(key.Next(0, maxIndex), new Circle(rnd));
                }
                Thread.Sleep(20);
                rnd = new Vbr();
            }
        }
    }
    
    public class Vbr
    {
        public int x,y,item,toBe;
        public double r;

        public Vbr()
        {
            Random rnd = new Random();
            x = rnd.Next(-100, 100);
            y = rnd.Next(-100, 100);
            r = rnd.NextDouble()*10;
            item = rnd.Next(0, 3);
            toBe = rnd.Next(0, 10);
        }

        public Vbr Next()
        {
            return new Vbr();
        }
    }
}