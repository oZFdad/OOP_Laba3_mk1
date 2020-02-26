using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using StorageForPainDLL;

namespace OOP_Laba6_mk1
{
    public partial class Form1 : Form
    {
        private Storage _storage = new Storage(10);
        private bool creatShapeOnPicture = true;
        private Color[] _colors;

        public Form1()
        {
            InitializeComponent();
            _colors = typeof(Color).GetProperties(BindingFlags.Static | BindingFlags.Public)
                .Where(p => p.PropertyType == typeof(Color))
                .Select(p => (Color)p.GetValue(null)).ToArray();

            cbColorChange.Items.AddRange(_colors.Select(c => c.Name).ToArray());
            
            _storage.AddStorageObserver(new TreeViewStorageObserver(treeViewShape));
            cbShapeChange.Text = "Circle";
        }

        private void DeleteMarkedItems()
        {
            for (int i = 1; i <= _storage.GetMaxIndex(); i++)
            {
                if (_storage.GetItem(i).Flag)
                {
                    _storage.DeleteItem(i);
                    i--;
                }
            }
            painBox.Refresh();
        }

        private Color GetCurrentSelectedColor()
        {
            var colorName = (string)cbColorChange.SelectedItem;
            var color = _colors.FirstOrDefault(c => c.Name == colorName);
            if (color == default(Color))
            {
                MessageBox.Show("Выберите цвет", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return color;
        }

        private void painBox_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 1; i <= _storage.GetMaxIndex(); i++)
            {
                var shape = _storage.GetItem(i);
                if (shape.CheckPoint(e.X, e.Y))
                {
                    if (shape.Flag)
                    {
                        shape.Flag = false;
                    }
                    else
                    {
                        shape.Flag = true;
                    }
                    creatShapeOnPicture = false;
                }
            }
            if (creatShapeOnPicture)
            {
                var change = cbShapeChange.Text;
                if (change == "Circle")
                {
                    Circle shape = new Circle(e.X, e.Y, 100);
                    if (shape.CheckBorder(painBox.Width, painBox.Height))
                    {
                        _storage.AddItem(shape);
                    }
                }
                else if (change == "Square")
                {
                    Square shape = new Square(e.X, e.Y, 100);
                    if (shape.CheckBorder(painBox.Width, painBox.Height))
                    {
                        _storage.AddItem(shape);
                    }
                }
                else if (change == "Triangle")
                {
                    Triangle shape = new Triangle(e.X, e.Y, 100);
                    if (shape.CheckBorder(painBox.Width, painBox.Height))
                    {
                        _storage.AddItem(shape);
                    }
                }
                else
                {
                    MessageBox.Show("Выберите тип фигуры", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
            creatShapeOnPicture = true;
            painBox.Refresh();
        }
        
        private void ChangeShapeRadius(int dr)
        {
            for (int i = 1; i <= _storage.GetMaxIndex(); i++)
            {
                if (_storage.GetItem(i).Flag)
                {
                    _storage.GetItem(i).ChangeR(dr, painBox.Width, painBox.Height);
                }
            }

            painBox.Refresh();
        }

        private void btRUp_Click(object sender, EventArgs e)
        {
            ChangeShapeRadius(1);
        }

        private void btRDown_Click(object sender, EventArgs e)
        {
            ChangeShapeRadius(-1);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            painBox.Focus();
            var shapesMoved = false;
            
            for (int i = 1; i <= _storage.GetMaxIndex(); i++)
            {
                var shape = _storage.GetItem(i);
                if (shape.Flag)
                {
                    var dx = 0;
                    var dy = 0;
                    switch (e.KeyCode)
                    {
                        case Keys.Left:
                            dx = -1;
                            break;
                        case Keys.Right:
                            dx = 1;
                            break;
                        case Keys.Up:
                            dy = -1;
                            break;
                        case Keys.Down:
                            dy = 1;
                            break;
                        case Keys.Delete:
                            if (shape.Flag)
                            {
                                _storage.DeleteItem(i);
                                RemoveMoveObserverFromShapes(shape);
                                i--;
                            }
                            break;
                        default:
                            break;
                    }

                    if (dx != 0 || dy != 0)
                    {
                        shape.Move(dx, dy, painBox.Width, painBox.Height);
                        shapesMoved = true;
                    }
                }
                
            }

            if (shapesMoved)
            {
                ProcessStickyShapes();
            }

            painBox.Refresh();
        }

        private void ProcessStickyShapes()
        {
            for (var i = 1; i <= _storage.GetMaxIndex(); i++)
            {
                if (_storage.GetItem(i).Sticky)
                {
                    ProcessStickyShape(_storage.GetItem(i));
                }
            }
        }

        private void painBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics pain = e.Graphics;
            for (int i = 1; i <= _storage.GetMaxIndex(); i++)
            {
                _storage.GetItem(i).Draw(pain);
            }
        }

        private void cbColorChange_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var shape in GetSelectedShapes())
            {
                shape.color = GetCurrentSelectedColor();
            }
            
            painBox.Refresh();
        }

        private void btCreatGroup_Click(object sender, EventArgs e)
        {
            Storage bufStorage = new Storage();
            for (int i = 1; i <= _storage.GetMaxIndex(); i++)
            {
                var shape = _storage.GetItem(i);
                if (shape.Flag)
                {
                    bufStorage.AddItem(shape);
                    RemoveMoveObserverFromShapes(shape);
                    _storage.DeleteItem(i);
                    i--;
                }
            }
            if (bufStorage.GetMaxIndex() != 0)
            {
                _storage.AddItem(new Group(bufStorage));
            }
            ProcessStickyShapes();
        }

        private List<Shape> GetSelectedShapes()
        {
            var result = new List<Shape>();
            for (var i = 1; i <= _storage.GetMaxIndex(); i++)
            {
                if (_storage.GetItem(i).Flag)
                {
                    result.Add(_storage.GetItem(i));
                }
            }

            return result;
        }
/*
        private void btUnGroup_Click(object sender, EventArgs e) // разгруппироввать все и вся
        {
            for (int i = 1; i <= _storage.GetMaxIdex(); i++)
            {
                if (_storage.GetItem(i).GetType() == typeof(Group))
                {
                    if (_storage.GetItem(i).flag)
                    {
                        Group bufGroup = (Group)_storage.GetItem(i);
                        _storage.DeleteItem(i);
                        i--;
                        for (int j = 1; j <= bufGroup._group.GetMaxIdex(); j++)
                        {
                            _storage.AddItem(bufGroup._group.GetItem(j));
                        }
                    }       
                }
            }
        }
*/
        private void btUnGroup_Click(object sender, EventArgs e) //удаление только выделеных групп
        {
            Storage bufStorageGroup = new Storage();
            for (int i = 1; i <= _storage.GetMaxIndex(); i++)
            {
                var shape = _storage.GetItem(i);
                if (shape.GetType() == typeof(Group))
                {
                    if (shape.Flag)
                    {
                        bufStorageGroup.AddItem(shape);
                        RemoveMoveObserverFromShapes(shape);
                        _storage.DeleteItem(i);
                        i--;
                    }
                }
            }
            for(int i = 1; i <= bufStorageGroup.GetMaxIndex(); i++)
            {
                Group bufGroup = (Group)bufStorageGroup.GetItem(i);
                for(int j = 1; j <= bufGroup.GroupStorage.GetMaxIndex(); j++)
                {
                    _storage.AddItem(bufGroup.GroupStorage.GetItem(j));
                }
            }
            
            ProcessStickyShapes();
        }

        private void RemoveMoveObserverFromShapes(IShapeChangeObserver observer)
        {
            for (var i = 1; i <= _storage.GetMaxIndex(); i++)
            {
                _storage.GetItem(i).RemoveShapeChangeObserver(observer);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = 0;
        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Shape|*.shape",
                DefaultExt = "shape",
                Multiselect = false
            };
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var shapefactory = new ShapeFactory();
                _storage.LoadFromFile(dialog.FileName, shapefactory);
                painBox.Refresh();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                Filter = "Shape|*.shape",
                AddExtension = true,
                DefaultExt = "shape",
                OverwritePrompt = true
            };
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                _storage.SaveToFile(dialog.FileName);
            }
        }

        private void treeViewShape_AfterCheck(object sender, TreeViewEventArgs e)
        {
            ((IFlagObserver)e.Node.Tag).Update(e.Node.Checked);
            painBox.Refresh();
        }

        private void btChangeSticky_Click(object sender, EventArgs e)
        {
            foreach (var shape in GetSelectedShapes())
            {
                shape.Sticky = !shape.Sticky;
                if (shape.Sticky)
                {
                    ProcessStickyShape(shape);
                }
                else
                {
                    shape.RemoveAllObservers();
                }
            }
            
            painBox.Refresh();
        }

        private void ProcessStickyShape(Shape shape)
        {
            for (var i = 1; i <= _storage.GetMaxIndex(); i++)
            {
                var s = _storage.GetItem(i);
                if (s == shape) continue;

                if (s.Intersect(shape))
                {
                    shape.AddShapeChangeObserver(s);
                }
            }
        }
    }

    
}
