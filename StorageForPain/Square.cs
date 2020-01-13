using System;
using System.Drawing;

namespace StorageForPainDLL
{
    public class Square : Shape
    {
        public Square(Vbr value) : base(value)
        {
        }

        public Square(int x1, int y1, int r1) : base(x1, y1, r1)
        {
        }

        public override string Name => "Square";

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
            if (Flag)
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
}