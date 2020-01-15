using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace StorageForPainDLL
{
    public abstract class Shape : IShapeChangeObserver
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
        private readonly List<IShapeChangeObserver> _shapeChangeObservers = new List<IShapeChangeObserver>();
        
        public Color color = Color.Red;

        /*
        protected Color _color = Color.Red;
        public virtual Color ColorProperty
        {
            get { return _color; }
            set { _color = value; }
        }
        */

        public abstract string Name { get; }
        
        private bool _updating = false;

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

        public virtual bool Move(int dx, int dy, int painBoxWidth, int painBoxHeight)
        {
            if (_updating) return true;
            _updating = true;
            
            X += dx;
            Y += dy;

            if (!CheckBorder(painBoxWidth, painBoxHeight) || !CallChangeObservers(dx, dy, painBoxWidth, painBoxHeight))
            {
                X -= dx;
                Y -= dy;
                _updating = false;
                return false;
            }

            _updating = false;
            return true;
        }
        
        public virtual bool ChangeR(int dr, int painBoxWidth, int painBoxHeight)
        {
            var oldR = R;
            R += dr;
            if (R < 1)
            {
                R = 1;
            }

            if (!CheckBorder(painBoxWidth, painBoxHeight))
            {
                R = oldR;
                return false;
            }
            
            return true;
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

        public void AddShapeChangeObserver(IShapeChangeObserver shapeChangeObserver)
        {
            if (!_shapeChangeObservers.Contains(shapeChangeObserver))
            {
                _shapeChangeObservers.Add(shapeChangeObserver);
            }
        }

        public void RemoveShapeChangeObserver(IShapeChangeObserver shapeChangeObserver)
        {
            _shapeChangeObservers.Remove(shapeChangeObserver);
        }

        public void RemoveAllObservers()
        {
            _shapeChangeObservers.Clear();
        }
        
        private bool CallChangeObservers(int x, int y, int width, int height)
        {
            int i;
            var success = true;
            for (i = 0; i < _shapeChangeObservers.Count; i++)
            {
                if (!_shapeChangeObservers[i].Update(x, y, width, height))
                {
                    success = false;
                    break;
                }
            }

            if (success) return true;
            
            for (var j = i - 1; j > 0; j--)
            {
                _shapeChangeObservers[i].Update(-x, -y, width, height);
            }
            
            return false;
        }

        public abstract bool Intersect(Shape shape, bool checkOpposite = true);
        public abstract Point[] GetPoints();

        public bool Update(int dx, int dy, int width, int height)
        { 
            return Move(dx, dy, width, height);
        }
    }
}