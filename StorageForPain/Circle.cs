using System;
using System.Drawing;

namespace StorageForPainDLL
{
    public class Circle : Shape
    {
        public Circle(Vbr value) : base(value)
        {
        }

        public Circle(int x1, int y1, int r1) : base(x1, y1, r1)  
        {
        }

        public override string Name => "Circle";

        public override void Display()
        {
            Console.WriteLine("Это окружность с центром Х={0} Y={1} и радиусом R={2}", X, Y, R);
        }

        public override bool CheckPoint(int dx, int dy)
        {
            dx = X - dx;
            dy = Y - dy;
            if (dx * dx + dy * dy <= R * R)
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
            graph.DrawEllipse(GetPen(), X - R, Y - R, 2*R, 2*R);
        }

        public override bool CheckBorder(int width, int height)
        {
            if (X - R <= 0)
            {
                return false;
            }
            if (X + R >= width)
            {
                return false;
            }
            if (Y - R <= 0)
            {
                return false;
            }
            if (Y + R >= height)
            {
                return false;
            }
            return true;
        }

        public override bool Intersect(Shape shape, bool checkOpposite = true)
        {
            if (shape is Circle)
            {
                return R + shape.R > DistCalc.GetDistance(X, Y, shape.X, shape.Y);
            }

            var points = shape.GetPoints();
            foreach (var point in points)
            {
                if (DistCalc.GetDistance(X, Y, point.X, point.Y) < R)
                {
                    return true;
                }
            }

            return checkOpposite && shape.Intersect(this, false);
        }

        public override Point[] GetPoints()
        {
            return new[] {new Point(X, Y)};
        }
    }
}