using System;
using System.Threading;

namespace Storage
{
    public class Vbr
    {
        public int x, y, item, toBe;
        public double r;

        public Vbr(Random rnd)
        {
            x = rnd.Next(-100, 100);
            y = rnd.Next(-100, 100);
            r = rnd.NextDouble() * 10;
            item = rnd.Next(0, 3);
            toBe = rnd.Next(0, 10);
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
        }

        public Storage(int maxSize)
        {
            _maxSize = maxSize;
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
            return _box[index - 1];
        }

        public Shape GetItem()
        {
            return _box[_index - 1];
        }
    }
}