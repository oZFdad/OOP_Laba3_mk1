using System;
using System.Drawing;
using System.Threading;

namespace StorageForPainDLL
{
    public class Vbr  //генератор случайных входных данных для создания фигур
    {
        public int x, y, r;

        public Vbr(Random rnd)
        {
            x = rnd.Next(-100, 100);
            y = rnd.Next(-100, 100);
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
        public bool flag = false;
        public Color color = Color.Red;

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
        public virtual void Move(int dx, int dy)
        {
            x += dx;
            y += dy;
        }
        public virtual void ChangeR(int dr)
        {
            r += dr;
            if (r < 1)
            {
                r = 1;
            }
        }
        public abstract bool CheckPoint(int _x, int _y);
        public abstract void Draw(Bitmap bmp);
        public void EditColor(Color newColor)
        {
            color = newColor;
        }
        public abstract void CheckBorderMove(int width, int height);
        public abstract void CheckBorderChangeR(int width, int height);
    }

    public class Triangle : Shape
    {
        private Point[] _points = new Point[4];
        public Triangle(Vbr value) : base(value)
        {
        }

        public Triangle(int x1, int y1, int r1) : base(x1, y1, r1) 
        {
            _points[0].X = (int)(x1 - r1 / 2 * Math.Sqrt(3));
            _points[0].Y = (y1 + r1 / 2);
            _points[1].X = x1;
            _points[1].Y = y1 - r1;
            _points[2].X = (int)(x1 + r1 / 2 * Math.Sqrt(3));
            _points[2].Y = (y1 + r1 / 2);
            _points[3].X = _points[0].X;
            _points[3].Y = _points[0].Y;
        }

        public override void Display()
        {
            Console.WriteLine("Это правильный треугольник с координатами центра описаной окружности Х={0} Y={1} и радиусом R={2}", x, y, r);
        }

        private void CountPoints()
        {
            _points[0].X = (int)(x - r / 2 * Math.Sqrt(3));
            _points[0].Y = (y + r / 2);
            _points[1].X = x;
            _points[1].Y = y - r;
            _points[2].X = (int)(x + r / 2 * Math.Sqrt(3));
            _points[2].Y = (y + r / 2);
            _points[3].X = _points[0].X;
            _points[3].Y = _points[0].Y;
        }

        public override void Move(int dx, int dy)
        {
            x += dx;
            y += dy;
            for(int i = 0; i < _points.Length; i++)
            {
                _points[i].X += dx;
                _points[i].Y += dy;
            }
        }

        public override void ChangeR(int dr)
        {
            r += dr;
            if (r < 1)
            {
                r = 1;
            }
            CountPoints();
        }

        public override bool CheckPoint(int dx, int dy)
        {
            var p1 = (_points[0].X - dx) * (_points[1].Y - _points[0].Y) - (_points[1].X - _points[0].X) * (_points[0].Y - dy);
            var p2 = (_points[1].X - dx) * (_points[2].Y - _points[1].Y) - (_points[2].X - _points[1].X) * (_points[1].Y - dy);
            var p3 = (_points[2].X - dx) * (_points[0].Y - _points[2].Y) - (_points[0].X - _points[2].X) * (_points[2].Y - dy);
            if(p1 <= 0 && p2 <= 0 && p3 <= 0|| p1 >= 0 && p2 >= 0 && p3 >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Draw(Bitmap bmp)
        {
            Graphics graph = Graphics.FromImage(bmp);
            Pen pen;
            if (flag)
            {
                pen = new Pen(color, 10);
            }
            else
            {
                pen = new Pen(color);
            }
            graph.DrawLines(pen, _points);
        }

        public override void CheckBorderMove(int width, int height) // достаточное условие, не предусматривает вращения
        {
            if (_points[0].X <= 0)
            {
                x = (int)Math.Ceiling(r / 2 * Math.Sqrt(3));
            }
            if (_points[2].X >= width)
            {
                x = width - (int)Math.Ceiling(r / 2 * Math.Sqrt(3)) - 1;
            }
            if (_points[1].Y <= 0)
            {
                y = r;
            }
            if (_points[0].Y >= height)
            {
                y = height - r / 2 - 1;
            }
            CountPoints();
        }

        public override void CheckBorderChangeR(int width, int height)
        {
            if (_points[0].X <= 0)
            {
                r = (int)Math.Ceiling(x * 2 / Math.Sqrt(3));
            }
            if (_points[2].X >= width)
            {
                r = (int)Math.Ceiling((width -  x) * 2 / Math.Sqrt(3)) - 1;
            }
            if (_points[1].Y <= 0)
            {
                r = y;
            }
            if (_points[0].Y >= height)//
            {
                r = (height - y) * 2 - 1;
            }
            CountPoints();
        }
    }

    public class Square : Shape
    {
        public Square(Vbr value) : base(value)
        {
        }

        public Square(int x1, int y1, int r1) : base(x1, y1, r1)
        {
        }

        public override void Display()
        {
            Console.WriteLine("Это квадрат с координатами центра описаной окружности Х={0} Y={1} и радиусом R={2}", x, y, r);
        }

        public override bool CheckPoint(int dx, int dy)
        {
            if (dx >= (float)(x - r / Math.Sqrt(2)) && dx <= (float)(x + r / Math.Sqrt(2)) && dy >= (float)(y - r / Math.Sqrt(2)) && dy <= (float)(y + r / Math.Sqrt(2)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Draw(Bitmap bmp)
        {
            Graphics graph = Graphics.FromImage(bmp);
            Pen pen;
            if (flag)
            {
                pen = new Pen(color, 10);
            }
            else
            {
                pen = new Pen(color);
            }
            graph.DrawRectangle(pen, (float)(x - r / Math.Sqrt(2)), (float)(y - r / Math.Sqrt(2)), (float)(2 * r / Math.Sqrt(2)), (float)(2 * r / Math.Sqrt(2)));
        }

        public override void CheckBorderMove(int width, int height)
        {
            if (x - r / Math.Sqrt(2) <= 0)
            {
                x = (int)Math.Ceiling(r / Math.Sqrt(2));
            }
            if (x + r / Math.Sqrt(2) >= width)
            {
                x = width - (int)Math.Ceiling(r / Math.Sqrt(2)) - 1;
            }
            if (y - r / Math.Sqrt(2) <= 0)
            {
                y = (int)Math.Ceiling(r / Math.Sqrt(2));
            }
            if (y + r / Math.Sqrt(2) >= height)
            {
                y = height - (int)Math.Ceiling(r / Math.Sqrt(2)) - 1;
            }
        }
        public override void CheckBorderChangeR(int width, int height)
        {
            if (x - r / Math.Sqrt(2) <= 0)
            {
                r = (int)Math.Ceiling(x * Math.Sqrt(2));
            }
            if (x + r / Math.Sqrt(2) >= width)
            {
                r = (int)Math.Ceiling((width - x) * Math.Sqrt(2)) - 1;
            }
            if (y - r / Math.Sqrt(2) <= 0)
            {
                r = (int)Math.Ceiling(y * Math.Sqrt(2)) - 1;
            }
            if (y + r / Math.Sqrt(2) >= height)
            {
                r = (int)Math.Ceiling((height - y) * Math.Sqrt(2)) - 1;
            }
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

        public override void Display()
        {
            Console.WriteLine("Это окружность с центром Х={0} Y={1} и радиусом R={2}", x, y, r);
        }

        public override bool CheckPoint(int dx, int dy)
        {
            dx = x - dx;
            dy = y - dy;
            if (dx * dx + dy * dy <= r * r)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Draw(Bitmap bmp)
        {
            Pen pen;
            Graphics graph = Graphics.FromImage(bmp);
            if (flag)
            {
                pen = new Pen(color, 10);
            }
            else
            {
                pen = new Pen(color);
            }
            graph.DrawEllipse(pen, x - r, y - r, 2*r, 2*r);
        }

        public override void CheckBorderMove(int width, int height)
        {
            if (x - r <= 0)
            {
                x = r;
            }
            if (x + r >= width)
            {
                x = width - r -1;
            }
            if (y - r <= 0)
            {
                y = r;
            }
            if (y + r >= height)
            {
                y = height - r - 1;
            }
        }
        public override void CheckBorderChangeR(int width, int height)
        {
            if (x - r <= 0)
            {
                r = x;
            }
            if (x + r >= width)
            {
                r = width - x - 1;
            }
            if (y - r <= 0)
            {
                r = y;
            }
            if (y + r >= height)
            {
                r = height - y - 1;
            }
        }
    }

    public class Storage
    {
        Shape[] _box;
        int _maxSize, lenght = 0;

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
            if (lenght < _maxSize)
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
            if (!CheckSpace()) // сломал голову, как правильно ????
            {
                AddSpace();
            }
            _box[lenght] = item;
            lenght++;
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
            if (lenght > 0)
            {
                if (index <= lenght)
                {
                    for (int i = index - 1; i < lenght - 1; i++)
                    {
                        _box[i] = _box[i + 1];
                    }
                    lenght--;
                    Array.Clear(_box, lenght, 1);
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
            if (lenght > 0)
            {
                lenght--;
                Array.Clear(_box, lenght, 1);
            }
            else
            {
                Console.WriteLine("В хранилище больше нет фигур");
            }
        }

        public void DeleteAll()
        {
            Array.Clear(_box, 0, lenght);
            lenght = 0;
        }

        public int GetMaxIdex()
        {
            return lenght;
        }

        public Shape GetItem(int index)
        {
            return _box[index-1];
        }

        public Shape GetItem()
        {
            return _box[lenght-1];
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
                    if (lenght != 0)
                    {
                        DeleteItem(rnd.Next(1, lenght));
                        Console.WriteLine("Успешно удален элемент по индексу");
                    }
                }
                else if (rand == 2)
                {
                    if (lenght != 0)
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
                    if (lenght != 0)
                    {
                        GetItem().Display();
                    }
                }
                else
                {
                    if (lenght != 0)
                    {
                        GetItem(rnd.Next(1, lenght)).Display();
                    }
                }
                Thread.Sleep(20);
            }
            //Vbr random = new Vbr(rnd);
        }
    }
}