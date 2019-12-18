﻿using System;
using System.Threading;

namespace StorageForPain
{
    public class Vbr
    {
        public int x, y;
        public double r;

        public Vbr(Random rnd)
        {
            x = rnd.Next(-100, 100);
            y = rnd.Next(-100, 100);
            r = rnd.NextDouble() * 10;
        }

        public Vbr(int x, int y, double r)
        {
            this.x = x;
            this.y = y;
            this.r = r;
        }
    }

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

        //public Circle(int x1, int y1, double r1) : base(x1, y1, r1)  //как правильно?
        //{
        //}

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
        int _maxSize, _currentIndex, _index = 0;

        public Storage()
        {
            _maxSize = 10;
            _box = new Shape[_maxSize];
        }

        public Storage(int maxSize)
        {
            _maxSize = maxSize;
            _box = new Shape[_maxSize];
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
            Shape[] _bufer = new Shape[_maxSize + _maxSize/2];
            for(int i = 0; i < _maxSize; i++)
            {
                _bufer[i] = _box[i];
            }
            
            _box = _bufer;
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
            int rand = rnd.Next(0, 2);
            for (int i = 0; i < numbers; i++)
            {
                Vbr core = new Vbr(rnd);
                if (i == 0)
                {
                    CreatItem(new Circle(core));
                }
                else if (i == 1)
                {
                    CreatItem(new Triangle(core));
                }
                else
                {
                    CreatItem(new Square(core));
                }
            }
        }

        public void DeleteItem (int index)
        {
            if (index < _index)
            {
                for (int i = index; i < _index - 1; i++)
                {
                    _box[i] = _box[i + 1];
                }
                _index--;
                Array.Clear(_box,_index, 1);
                //Console.WriteLine("Удален {0}-й элемент", index);
            }
        }

        public void DeleteItem()
        {
            _index--;
            Array.Clear(_box, _index, 1);
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
                Vbr core = new Vbr(rnd);
                rnd.Next(0, 5);
                if (i == 0) //Добавление элемента
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
                else if (i == 1)
                {
                    DeleteItem(rnd.Next(1, _index));
                    Console.WriteLine("Успешно удален элемент");
                }
                else if (i == 2)
                {
                    DeleteItem();
                    Console.WriteLine("Успешно удален элемент");
                }
                else if (i == 3)
                {
                    Console.WriteLine(GetMaxIdex());
                }
                else if (i == 4)
                {
                    GetItem().Display();
                }
                else
                {
                    GetItem(rnd.Next(1, _index)).Display();
                }
            }
            Vbr random = new Vbr(rnd);
        }
    }
}