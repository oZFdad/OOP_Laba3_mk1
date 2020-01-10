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
        public abstract void Draw(Graphics graph);
        public void EditColor(Color newColor)
        {
            color = newColor;
        }
        
        public abstract bool CheckBorder(int width, int height);
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

        public override void Draw(Graphics graph)
        {
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

        public override bool CheckBorder(int width, int height)
        {
            if (_points[0].X <= 0)
            {
                return false;
            }
            if (_points[2].X >= width)
            {
                return false;
            }
            if (_points[1].Y <= 0)
            {
                return false;
            }
            if (_points[0].Y >= height)
            {
                return false;
            }
            return true;
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

        public override void Draw(Graphics graph)
        {
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
        
        public override bool CheckBorder(int width, int height)
        {
            if (x - r / Math.Sqrt(2) <= 0)
            {
                return false;
            }
            if (x + r / Math.Sqrt(2) >= width)
            {
                return false;
            }
            if (y - r / Math.Sqrt(2) <= 0)
            {
                return false;
            }
            if (y + r / Math.Sqrt(2) >= height)
            {
                return false;
            }
            return true;
        }
    }

    public class Circle : Shape
    {
        public Circle(Vbr value) : base(value)
        {
        }

        public Circle(int x1, int y1, int r1) : base(x1, y1, r1)  
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

        public override void Draw(Graphics graph)
        {
            Pen pen;
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

        public override bool CheckBorder(int width, int height)
        {
            if (x - r <= 0)
            {
                return false;
            }
            if (x + r >= width)
            {
                return false;
            }
            if (y - r <= 0)
            {
                return false;
            }
            if (y + r >= height)
            {
                return false;
            }
            return true;
        }
    }

    public class Group : Shape
    {
        private Storage group;

        public Group(Vbr value) : base(value)
        {
        }

        public Group(int x1, int y1, int r1) : base(x1, y1, r1)
        {
        }

        public override bool CheckBorder(int width, int height)
        {
            throw new NotImplementedException();
        }

        public override bool CheckPoint(int _x, int _y)
        {
            throw new NotImplementedException();
        }

        public override void Display()
        {
            throw new NotImplementedException();
        }

        public override void Draw(Graphics graph)
        {
            throw new NotImplementedException();
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

        private bool CheckSpace() 
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

        public void AddItem (Shape item)
        {
            if (!CheckSpace()) 
            {
                AddSpace();
            }
            _box[lenght] = item;
            lenght++;
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
    }
}