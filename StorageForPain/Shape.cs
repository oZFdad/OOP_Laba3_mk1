using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace StorageForPainDLL
{
    public abstract class Shape
    {
        public int x, y, r;
        public bool gummy = false;

        private bool _flag;
        public bool Flag
        {
            get { return _flag; }
            set
            {
                if (_flag == value) return;
                
                _flag = value;
                foreach (var observer in _flagObservers)
                {
                    observer.Update(_flag);
                }
            }
        }

        private readonly List<IFlagObserver> _flagObservers = new List<IFlagObserver>();
        private readonly List<IGummyShapeObserver> _gummyShapeObservers = new List<IGummyShapeObserver>();
        
        public Color color = Color.Red;

        //Example
        protected Color _color = Color.Red;
        public virtual Color ColorProperty
        {
            get { return _color; }
            set { _color = value; }
        }
        //Example

        public abstract string Name { get; }

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
            CallGummyObservers(x,y,0);
        }
        public virtual void ChangeR(int dr)
        {
            r += dr;
            if (r < 1)
            {
                r = 1;
            }

            CallGummyObservers(0, 0, r);
        }
        public abstract bool CheckPoint(int _x, int _y);
        public abstract void Draw(Graphics graph);
        public abstract bool CheckBorder(int width, int height);

        public virtual void Save(StreamWriter writer, int spacing)
        {
            writer.Write(new string(' ', spacing));
            writer.WriteLine($"{Name} {x} {y} {r} {color.Name} {Flag}");
        }

        public virtual void Load(string shapeLine, StreamReader reader)
        {
            var parts = shapeLine.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            x = int.Parse(parts[1]);
            y = int.Parse(parts[2]);
            r = int.Parse(parts[3]);
            color = Color.FromName(parts[4]);
            Flag = bool.Parse(parts[5]);
        }

        public void AddFlagObserver(IFlagObserver flagObserver)
        {
            _flagObservers.Add(flagObserver);
        }

        public void AddGummyShapeObserver(IGummyShapeObserver gummyShapeObserver)
        {
            _gummyShapeObservers.Add(gummyShapeObserver);
        }
        
        private void CallGummyObservers(int x, int y, int r)
        {
            foreach (var observer in _gummyShapeObservers)
            {
                observer.Update(this, x, y, r);
            }
        }
    }
}