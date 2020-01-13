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
}