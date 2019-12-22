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
        public Pen pen = new Pen(Color.Red);
        private Color[] _colors;

        public Form1()
        {
            InitializeComponent();
            _colors = typeof(Color).GetProperties(BindingFlags.Static | BindingFlags.Public)
                .Where(p => p.PropertyType == typeof(Color))
                .Select(p => (Color)p.GetValue(null)).ToArray();

            cbColorChange.Items.AddRange(_colors.Select(c => c.Name).ToArray());
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
            Bitmap bmp = new Bitmap(painBox.Width, painBox.Height);
            //var color = GetCurrentSelectedColor();
            //if (color == default(Color)) return;

            if (creatShapeOnPicture)
            {
                var change = cbShapeChange.Text;
                if (change == "Circle")
                {
                    Circle shape = new Circle(e.X, e.Y, 100);
                    _storage.CreatItem(shape);
                }
                else if (change == "Square")
                {
                    Square shape = new Square(e.X, e.Y, 100);
                    _storage.CreatItem(shape);
                }
                else if (change=="Triangle")
                {
                    Triangle shape = new Triangle(e.X, e.Y, 100);
                    _storage.CreatItem(shape);
                }
                else
                {
                    return;
                }
            }
            else
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
                    }
                }
            }
            for (int i = 1; i <= _storage.GetMaxIdex(); i++)
            {
                _storage.GetItem(i).Draw(bmp);
            }
            painBox.BackgroundImage = bmp;
        }

        private void bt_Click(object sender, EventArgs e)
        {
            if (creatShapeOnPicture)
            {
                creatShapeOnPicture = false;
                btOnOffEdit.Text = "Включить режим добавления объектов";
            }
            else
            {
                creatShapeOnPicture = true;
                btOnOffEdit.Text = "Выключить режим добавления объектов";
            }
        }

        private void btRUp_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(painBox.Width, painBox.Height);
            for (int i = 1; i <= _storage.GetMaxIdex(); i++)
            {
                if (_storage.GetItem(i).flag)
                {
                    _storage.GetItem(i).ChangeR(10);
                    _storage.GetItem(i).CheckBorderChangeR(painBox.Width, painBox.Height);
                }
            }
            for (int i = 1; i <= _storage.GetMaxIdex(); i++)
            {
                _storage.GetItem(i).Draw(bmp);
            }
            painBox.BackgroundImage = bmp;
        }

        private void btRDown_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(painBox.Width, painBox.Height);
            for (int i = 1; i <= _storage.GetMaxIdex(); i++)
            {
                if (_storage.GetItem(i).flag)
                {
                    _storage.GetItem(i).ChangeR(-10);
                }
            }
            for (int i = 1; i <= _storage.GetMaxIdex(); i++)
            {
                _storage.GetItem(i).Draw(bmp);
            }
            painBox.BackgroundImage = bmp;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Bitmap bmp = new Bitmap(painBox.Width, painBox.Height);
            for (int i = 1; i <= _storage.GetMaxIdex(); i++)
            {
                if (e.KeyCode == Keys.Left)
                {
                    if (_storage.GetItem(i).flag)
                    {
                        _storage.GetItem(i).Move(-10, 0);
                        _storage.GetItem(i).CheckBorderMove(painBox.Width, painBox.Height);
                    }
                }
                if (e.KeyCode == Keys.Right)
                {
                    if (_storage.GetItem(i).flag)
                    {
                        _storage.GetItem(i).Move(10, 0);
                        _storage.GetItem(i).CheckBorderMove(painBox.Width, painBox.Height);
                    }
                }
                if (e.KeyCode == Keys.Up)
                {
                    if (_storage.GetItem(i).flag)
                    {
                        _storage.GetItem(i).Move(0, -10);
                        _storage.GetItem(i).CheckBorderMove(painBox.Width, painBox.Height);
                    }
                }
                if (e.KeyCode == Keys.Down)
                {
                    if (_storage.GetItem(i).flag)
                    {
                        _storage.GetItem(i).Move(0, 10);
                        _storage.GetItem(i).CheckBorderMove(painBox.Width, painBox.Height);
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
            
            for (int i = 1; i <= _storage.GetMaxIdex(); i++)
            {
                _storage.GetItem(i).Draw(bmp);
            }
            painBox.BackgroundImage = bmp;
        }

        private void btChangeColor_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(painBox.Width, painBox.Height);
            for (int i = 1; i <= _storage.GetMaxIdex(); i++)
            {
                if (_storage.GetItem(i).flag)
                {
                    _storage.GetItem(i).color = GetCurrentSelectedColor();
                }
            }
            for (int i = 1; i <= _storage.GetMaxIdex(); i++)
            {
                _storage.GetItem(i).Draw(bmp);
            }
            painBox.BackgroundImage = bmp;
        }
    }
}
