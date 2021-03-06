using System;
using System.Drawing;
using System.IO;

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

        public override string Name => "Triangle";

        public override void Display()
        {
            Console.WriteLine("Это правильный треугольник с координатами центра описаной окружности Х={0} Y={1} и радиусом R={2}", X, Y, R);
        }

        private void CountPoints()
        {
            _points[0].X = (int)(X - R / 2 * Math.Sqrt(3));
            _points[0].Y = (Y + R / 2);
            _points[1].X = X;
            _points[1].Y = Y - R;
            _points[2].X = (int)(X + R / 2 * Math.Sqrt(3));
            _points[2].Y = (Y + R / 2);
            _points[3].X = _points[0].X;
            _points[3].Y = _points[0].Y;
        }

        public override bool Move(int dx, int dy, int painBoxWidth, int painBoxHeight)
        {
            if (base.Move(dx, dy, painBoxWidth, painBoxHeight))
            {
                CountPoints();
                return true;
            }

            return false;
        }

        public override bool ChangeR(int dr, int painBoxWidth, int painBoxHeight)
        {
            if (base.ChangeR(dr, painBoxWidth, painBoxHeight))
            {
                CountPoints();
                return true;
            }

            return false;
        }

        public override bool CheckPoint(int dx, int dy)
        {
            var p1 = (_points[0].X - dx) * (_points[1].Y - _points[0].Y) - (_points[1].X - _points[0].X) * (_points[0].Y - dy);
            var p2 = (_points[1].X - dx) * (_points[2].Y - _points[1].Y) - (_points[2].X - _points[1].X) * (_points[1].Y - dy);
            var p3 = (_points[2].X - dx) * (_points[0].Y - _points[2].Y) - (_points[0].X - _points[2].X) * (_points[2].Y - dy);
            if (p1 <= 0 && p2 <= 0 && p3 <= 0|| p1 >= 0 && p2 >= 0 && p3 >= 0)
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
            graph.DrawLines(GetPen(), _points);
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

        public override void Load(string shapeLine, StreamReader reader, ShapeFactory shapeFactory)
        {
            base.Load(shapeLine, reader, shapeFactory);
            CountPoints();
        }

        public override bool Intersect(Shape shape, bool checkOpposite = true)
        {
            var points = shape.GetPoints();
            foreach (var point in points)
            {
                if (CheckPoint(point.X, point.Y)) return true;
            }

            return checkOpposite && shape.Intersect(this, false);
        }

        public override Point[] GetPoints()
        {
            return _points;
        }
    }
}