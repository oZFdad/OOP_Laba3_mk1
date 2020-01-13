using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
        }

        private void DeleteMarkedItems()
        {
            for (int i = 1; i <= _storage.GetMaxIdex(); i++)
            {
                if (_storage.GetItem(i).flag)
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
            for (int i = 1; i <= _storage.GetMaxIdex(); i++)
            {
                var shape = _storage.GetItem(i);
                if (shape.CheckPoint(e.X, e.Y))
                {
                    if (shape.flag)
                    {
                        shape.flag = false;
                    }
                    else
                    {
                        shape.flag = true;
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
                    MessageBox.Show("Выберите тип фигуры", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                }
            }
            creatShapeOnPicture = true;
            painBox.Refresh();
        }

        private void btRUp_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= _storage.GetMaxIdex(); i++)
            {
                if (_storage.GetItem(i).flag&&_storage.GetItem(i).CheckBorder(painBox.Width,painBox.Height))
                {
                    _storage.GetItem(i).ChangeR(1);
                    if (!_storage.GetItem(i).CheckBorder(painBox.Width, painBox.Height))
                    {
                        _storage.GetItem(i).ChangeR(-1);
                    }
                    //_storage.GetItem(i).CheckBorderChangeR(painBox.Width, painBox.Height);
                }
            }
            painBox.Refresh();
        }

        private void btRDown_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= _storage.GetMaxIdex(); i++)
            {
                if (_storage.GetItem(i).flag)
                {
                    _storage.GetItem(i).ChangeR(-1);
                }
            }
            painBox.Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            for (int i = 1; i <= _storage.GetMaxIdex(); i++)
            {
                if (e.KeyCode == Keys.Left)
                {
                    if (_storage.GetItem(i).flag&&_storage.GetItem(i).CheckBorder(painBox.Width,painBox.Height))
                    {
                        _storage.GetItem(i).Move(-1, 0);
                        if (!_storage.GetItem(i).CheckBorder(painBox.Width, painBox.Height))
                        {
                            _storage.GetItem(i).Move(1, 0);
                        }
                        //_storage.GetItem(i).CheckBorderMove(painBox.Width, painBox.Height);
                    }
                }
                if (e.KeyCode == Keys.Right)
                {
                    if (_storage.GetItem(i).flag&&_storage.GetItem(i).CheckBorder(painBox.Width,painBox.Height))
                    {
                        _storage.GetItem(i).Move(1, 0);
                        if (!_storage.GetItem(i).CheckBorder(painBox.Width, painBox.Height))
                        {
                            _storage.GetItem(i).Move(-1, 0);
                        }
                        //_storage.GetItem(i).CheckBorderMove(painBox.Width, painBox.Height);
                    }
                }
                if (e.KeyCode == Keys.Up)
                {
                    if (_storage.GetItem(i).flag&&_storage.GetItem(i).CheckBorder(painBox.Width,painBox.Height))
                    {
                        _storage.GetItem(i).Move(0, -1);
                        if (!_storage.GetItem(i).CheckBorder(painBox.Width, painBox.Height))
                        {
                            _storage.GetItem(i).Move(0, 1);
                        }
                        //_storage.GetItem(i).CheckBorderMove(painBox.Width, painBox.Height);
                    }
                }
                if (e.KeyCode == Keys.Down)
                {
                    if (_storage.GetItem(i).flag&&_storage.GetItem(i).CheckBorder(painBox.Width,painBox.Height))
                    {
                        _storage.GetItem(i).Move(0, 1);
                        if (!_storage.GetItem(i).CheckBorder(painBox.Width, painBox.Height))
                        {
                            _storage.GetItem(i).Move(0, -1);
                        }
                        //_storage.GetItem(i).CheckBorderMove(painBox.Width, painBox.Height);
                    }
                }
                if (e.KeyCode == Keys.Delete)
                {
                    if (_storage.GetItem(i).flag)
                    {
                        _storage.DeleteItem(i);
                        i--;
                    }
                }
            }
            painBox.Refresh();
        }

        private void btChangeColor_Click(object sender, EventArgs e)
        {
            
        }

        private void painBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics pain = e.Graphics;
            for (int i = 1; i <= _storage.GetMaxIdex(); i++)
            {
                _storage.GetItem(i).Draw(pain);
            }
        }

        private void cbColorChange_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 1; i <= _storage.GetMaxIdex(); i++)
            {
                if (_storage.GetItem(i).flag)
                {
                    _storage.GetItem(i).color = GetCurrentSelectedColor();
                }
            }
            painBox.Refresh();
        }

        private void btCreatGroup_Click(object sender, EventArgs e)
        {
            Storage bufStorage = new Storage();
            for (int i = 1; i <= _storage.GetMaxIdex(); i++)
            {
                if (_storage.GetItem(i).flag)
                {
                    bufStorage.AddItem(_storage.GetItem(i));
                    _storage.DeleteItem(i);
                    i--;
                }
            }
            if (bufStorage.GetMaxIdex() != 0)
            {
                _storage.AddItem(new Group(bufStorage));
            }
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
            for (int i = 1; i <= _storage.GetMaxIdex(); i++)
            {
                if (_storage.GetItem(i).GetType() == typeof(Group))
                {
                    if (_storage.GetItem(i).flag)
                    {
                        bufStorageGroup.AddItem(_storage.GetItem(i));
                        _storage.DeleteItem(i);
                        i--;
                    }
                }
            }
            for(int i = 1; i <= bufStorageGroup.GetMaxIdex(); i++)
            {
                Group bufGroup = (Group)bufStorageGroup.GetItem(i);
                for(int j = 1; j <= bufGroup._group.GetMaxIdex(); j++)
                {
                    _storage.AddItem(bufGroup._group.GetItem(j));
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = 0;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
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
    }
}
