using System;
using System.Drawing;

namespace StorageForPainDLL
{
    public class Square : Shape
    {
        private readonly double sqr2 = Math.Sqrt(2);
        
        public Square(Vbr value) : base(value)
        {
        }

        public Square(int x1, int y1, int r1) : base(x1, y1, r1)
        {
        }

        public override string Name => "Square";

        public override void Display()
        {
            Console.WriteLine("Это квадрат с координатами центра описаной окружности Х={0} Y={1} и радиусом R={2}", X, Y, R);
        }

        public override bool CheckPoint(int dx, int dy)
        {
            if (dx >= (float)(X - R / Math.Sqrt(2)) && dx <= (float)(X + R / Math.Sqrt(2)) && dy >= (float)(Y - R / Math.Sqrt(2)) && dy <= (float)(Y + R / Math.Sqrt(2)))
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
            graph.DrawRectangle(GetPen(),
                (float) (X - R / Math.Sqrt(2)),
                (float) (Y - R / Math.Sqrt(2)),
                (float) (2 * R / Math.Sqrt(2)),
                (float) (2 * R / Math.Sqrt(2)));
        }
        
        public override bool CheckBorder(int width, int height)
        {
            if (X - R / Math.Sqrt(2) <= 0)
            {
                return false;
            }
            if (X + R / Math.Sqrt(2) >= width)
            {
                return false;
            }
            if (Y - R / Math.Sqrt(2) <= 0)
            {
                return false;
            }
            if (Y + R / Math.Sqrt(2) >= height)
            {
                return false;
            }
            return true;
        }

        public override bool Intersect(Shape shape, bool checkOpposite = true)
        {
            var points = shape.GetPoints();
            var delta = R / sqr2;
            var rect = new Rectangle((int)(X - delta), (int)(Y - delta), (int)delta*2, (int)delta*2);
            
            foreach (var point in points)
            {
                if (rect.Contains(point)) return true;
            }

            return checkOpposite && shape.Intersect(this, false);
        }

        public override Point[] GetPoints()
        {
            var points = new Point[4];
            var delta = R / sqr2;
            points[0] = new Point((int)(X - delta), (int)(Y - delta));
            points[1] = new Point((int)(X + delta), (int)(Y - delta));
            points[2] = new Point((int)(X + delta), (int)(Y + delta));
            points[3] = new Point((int)(X - delta), (int)(Y + delta));
            return points;
        }
    }
}