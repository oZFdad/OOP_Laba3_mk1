using System;
using System.Threading;

namespace StorageForPainDLL
{
    public class Vbr
    {
        public int x, y, r;
        //public double r;

        public Vbr(Random rnd)
        {
            x = rnd.Next(-100, 100);
            y = rnd.Next(-100, 100);
            //r = rnd.NextDouble() * 10;
            r = rnd.Next(0, 50);
        }

        public Vbr(int x, int y, int r)
        {
            this.x = x;
            this.y = y;
            this.r = r;
        }
    }

    public abstract class Shape
    {
        public int x, y, r;
        //public double r;
        public bool flag = false;

        public Shape(Vbr value)
        {
            x = value.x;
            y = value.y;
            r = value.r;
        }

        public Shape(int x1, int y1, int r1)
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
            Console.WriteLine("Это правильный треугольник с координатами центра описаной окружности Х={0} Y={1} и радиусом R={2}", x, y, r);
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

        public Circle(int x1, int y1, int r1) : base(x1, y1, r1)  //как правильно?
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
        Shape[] _box;
        int _maxSize, _index = 0;

        public Storage()
        {
            _maxSize = 10;
            _box = new Shape[_maxSize + 1];
        }

        public Storage(int maxSize)
        {
            _maxSize = maxSize;
            _box = new Shape[_maxSize + 1];
        }

        private bool CheckSpace() // проверка свободных мест
        {
            if (_index < _maxSize)
            {
                return true;
            }
            return false;
        }

        private void AddSpace()
        {
            Shape[] _bufer = new Shape[_maxSize * 2 + 1];
            for(int i = 0; i < _maxSize; i++)
            {
                _bufer[i] = _box[i];
            }
            _box = _bufer;
            _maxSize = _maxSize * 2;
        }

        public void CreatItem (Shape item)
        {
            if (CheckSpace()==false) // сломал голову, как правильно ????
            {
                AddSpace();
            }
            _box[_index] = item;
            _index++;
        }

        public void CreatRandomItems (int numbers)
        {
            Random rnd = new Random();
            int rand;
            for (int i = 0; i < numbers; i++)
            {
                rand = rnd.Next(0, 3);
                Vbr core = new Vbr(rnd);
                if (rand == 0)
                {
                    CreatItem(new Circle(core));
                }
                else if (rand == 1)
                {
                    CreatItem(new Triangle(core));
                }
                else
                {
                    CreatItem(new Square(core));
                }
                Thread.Sleep(20);
            }
        }

        public void DeleteItem (int index)
        {
            if (_index > 0)
            {
                if (index < _index)
                {
                    for (int i = index; i < _index - 1; i++)
                    {
                        _box[i] = _box[i + 1];
                    }
                    _index--;
                    Array.Clear(_box, _index, 1);
                    //Console.WriteLine("Удален {0}-й элемент", index);
                }
            }
            else
            {
                Console.WriteLine("В хранилище больше нет фигур");
            }
        }

        public void DeleteItem()
        {
            if (_index > 0)
            {
                _index--;
                Array.Clear(_box, _index, 1);
            }
            else
            {
                Console.WriteLine("В хранилище больше нет фигур");
            }
        }

        public void DeleteAll()
        {
            Array.Clear(_box, 0, _index);
            _index = 0;
        }

        public int GetMaxIdex()
        {
            return _index;
        }

        public Shape GetItem(int index)
        {
            return _box[index-1];
        }

        public Shape GetItem()
        {
            return _box[_index-1];
        }

        public void LetsDoSomething(int iterator)
        {
            Random rnd = new Random();
            for(int i = 0; i < iterator; i++)
            {
                int rand;
                Vbr core = new Vbr(rnd);
                rand = rnd.Next(0, 6);
                if (rand == 0) //Добавление элемента
                {
                    int buf = rnd.Next(0, 2);
                    if (buf == 0)
                    {
                        CreatItem(new Circle(core));
                    }
                    else if (buf == 1)
                    {
                        CreatItem(new Triangle(core));
                    }
                    else
                    {
                        CreatItem(new Square(core));
                    }
                    Console.WriteLine("Успешно добавлен элемент");
                }
                else if (rand == 1)
                {
                    if (_index != 0)
                    {
                        DeleteItem(rnd.Next(1, _index));
                        Console.WriteLine("Успешно удален элемент по индексу");
                    }
                }
                else if (rand == 2)
                {
                    if (_index != 0)
                    {
                        DeleteItem();
                        Console.WriteLine("Успешно удален последний элемент");
                    }
                }
                else if (rand == 3)
                {
                    Console.WriteLine(GetMaxIdex());
                }
                else if (rand == 4)
                {
                    if (_index != 0)
                    {
                        GetItem().Display();
                    }
                }
                else
                {
                    if (_index != 0)
                    {
                        GetItem(rnd.Next(1, _index)).Display();
                    }
                }
                Thread.Sleep(20);
            }
            //Vbr random = new Vbr(rnd);
        }
    }
}