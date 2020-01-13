using System.Drawing;
using System.IO;

namespace StorageForPainDLL
{
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

        public Shape()
        {

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
        public abstract bool CheckBorder(int width, int height);

        public virtual void Save(StreamWriter writer)
        {
            
        }
    }
}