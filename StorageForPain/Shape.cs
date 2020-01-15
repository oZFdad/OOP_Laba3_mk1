using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace StorageForPainDLL
{
    public abstract class Shape : IMove
    {
        public int X;
        public int Y;
        public int R;
        
        public bool Sticky = false;

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
        private readonly List<IMoveObserver> _gummyShapeObservers = new List<IMoveObserver>();
        
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
            X = value.x;
            Y = value.y;
            R = value.r;
        }

        public Shape(int x1, int y1, int r1)
        {
            X = x1;
            Y = y1;
            R = r1;
        }

        public Shape()
        {

        }

        public abstract void Display();

        public virtual void Move(int dx, int dy)
        {
            X += dx;
            Y += dy;
            CallGummyObservers(X,Y,0);
        }
        public virtual void ChangeR(int dr)
        {
            R += dr;
            if (R < 1)
            {
                R = 1;
            }

            CallGummyObservers(0, 0, R);
        }
        public abstract bool CheckPoint(int _x, int _y);
        public abstract void Draw(Graphics graph);
        public abstract bool CheckBorder(int width, int height);

        protected Pen GetPen()
        {
            Pen pen;
            if (Flag)
            {
                pen = new Pen(color, 10);
            }
            else
            {
                pen = new Pen(color, 2);
            }

            if (Sticky)
            {
                pen.DashStyle = DashStyle.Dash;
            }

            return pen;
        }
        
        public virtual void Save(StreamWriter writer, int spacing)
        {
            writer.Write(new string(' ', spacing));
            writer.WriteLine($"{Name} {X} {Y} {R} {color.Name} {Flag}");
        }

        public virtual void Load(string shapeLine, StreamReader reader)
        {
            var parts = shapeLine.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            X = int.Parse(parts[1]);
            Y = int.Parse(parts[2]);
            R = int.Parse(parts[3]);
            color = Color.FromName(parts[4]);
            Flag = bool.Parse(parts[5]);
        }

        public void AddFlagObserver(IFlagObserver flagObserver)
        {
            _flagObservers.Add(flagObserver);
        }

        public void AddMoveShapeObserver(IMoveObserver moveObserver)
        {
            _gummyShapeObservers.Add(moveObserver);
        }
        
        private void CallGummyObservers(int x, int y, int r)
        {
            foreach (var observer in _gummyShapeObservers)
            {
                observer.Update(this, x, y, r);
            }
        }

        public abstract bool Intersect(Shape shape, bool checkOpposite = true);
        public abstract Point[] GetPoints();
    }
}