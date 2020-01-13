using System;
using System.Drawing;

namespace StorageForPainDLL
{
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
}