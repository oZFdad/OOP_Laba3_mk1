using System;

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
}