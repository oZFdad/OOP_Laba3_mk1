using System;
using System.Drawing;
using System.Windows.Forms;
using StorageForPainDLL;


namespace OOP_Laba4_mk1
{
    public partial class Form1 : Form
    {
        private Storage _storage = new Storage(10);
        private bool creatCircleOnPicture = true;
        public Pen pen = new Pen(Color.Red);
        public Form1()
        {
            InitializeComponent();
        }

        private void painBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (creatCircleOnPicture)
            {
                Circle circle = new Circle(e.X, e.Y, 100);
                _storage.AddItem(circle);
                labelNumber.Text = "Объектов в хранилище " + Convert.ToString(_storage.GetMaxIdex());
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
                Bitmap bmp = new Bitmap(painBox.Width, painBox.Height);
                for (int i = 1; i <= _storage.GetMaxIdex(); i++)
                {
                    _storage.GetItem(i).Draw(bmp);
                }
                painBox.BackgroundImage = bmp;
            }
        }

        private void btPaint_Click(object sender, EventArgs e)
        {
            if (_storage.GetMaxIdex() != 0)
            {
                Bitmap bmp = new Bitmap(painBox.Width, painBox.Height);
                //Graphics graph = Graphics.FromImage(bmp);
                //Pen pen = new Pen(Color.Red);
                ////pen.Color = Color.Blue;
                //Shape circle;
                //for (int i = 1; i <= _storage.GetMaxIdex(); i++)
                //{
                //    circle = _storage.GetItem(i);
                //    graph.DrawEllipse(pen, circle.x - circle.r / 2, circle.y - circle.r / 2, circle.r, circle.r);
                //}
                for(int i = 1; i <= _storage.GetMaxIdex(); i++)
                {
                    _storage.GetItem(i).Draw(bmp);
                }
                creatCircleOnPicture = false;
                painBox.BackgroundImage = bmp;
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            _storage.DeleteAll();
            labelNumber.Text = "Объектов в хранилище " + Convert.ToString(_storage.GetMaxIdex());
            Bitmap bmp = new Bitmap(painBox.Width, painBox.Height);
            Graphics graph = Graphics.FromImage(bmp);
            creatCircleOnPicture = true;
            painBox.BackgroundImage = bmp;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                for(int i = 1; i <= _storage.GetMaxIdex(); i++)
                {
                    if (_storage.GetItem(i).flag)
                    {
                        _storage.DeleteItem(i);
                        i--;
                    }
                }
                Bitmap bmp = new Bitmap(painBox.Width, painBox.Height);
                for (int i = 1; i <= _storage.GetMaxIdex(); i++)
                {
                    _storage.GetItem(i).Draw(bmp);
                }
                painBox.BackgroundImage = bmp;
                labelNumber.Text = "Объектов в хранилище " + Convert.ToString(_storage.GetMaxIdex());
            }
        }

        private void painBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(pen, 1, 1, 400, 400);
        }
    }
}
