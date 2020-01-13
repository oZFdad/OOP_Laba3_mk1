using System;
using System.Drawing;

namespace StorageForPainDLL
{
    public class Group : Shape
    {
        public Storage GroupStorage = new Storage(10);

        public Group(Vbr value) : base(value)
        {
        }

        public Group(int x1, int y1, int r1) : base(x1, y1, r1)
        {
        }

        public Group(Storage storage) : base ()
        {
            GroupStorage = storage;
            flag = true;
        }

        public override bool CheckBorder(int width, int height)
        {
            for (int i = 1; i <= GroupStorage.GetMaxIdex(); i++)
            {
                if (GroupStorage.GetItem(i).CheckBorder(width, height)==false)
                {
                    return false;
                }
            }
            return true;
        }

        public override bool CheckPoint(int _x, int _y)
        {
            for (int i = 1; i <= GroupStorage.GetMaxIdex(); i++)
            {
                if (GroupStorage.GetItem(i).CheckPoint(_x, _y))
                {
                    return true;
                }
            }
            return false;
        }

        public override void Display()
        {
            throw new NotImplementedException();
        }

        public override void Draw(Graphics graph)
        {
            for (int i = 1; i <= GroupStorage.GetMaxIdex(); i++)
            {
                GroupStorage.GetItem(i).color = color;
                GroupStorage.GetItem(i).flag = flag;
                GroupStorage.GetItem(i).Draw(graph);
            }
        }

        public override void Move(int dx, int dy)
        {
            for (int i = 1; i <= GroupStorage.GetMaxIdex(); i++)
            {
                GroupStorage.GetItem(i).Move(dx, dy);
            }
        }
        public override void ChangeR(int dr)
        {
            for (int i = 1; i <= GroupStorage.GetMaxIdex(); i++)
            {
                GroupStorage.GetItem(i).ChangeR(dr);
            }
        }
    }
}