using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StorageForPainDLL;


namespace OOP_Laba4_mk1
{
    public partial class Form1 : Form
    {
        private Storage _storage = new Storage(10);
        public Form1()
        {
            InitializeComponent();
        }

        private void painBox_MouseDown(object sender, MouseEventArgs e)
        {
            Circle circle = new Circle(e.X, e.Y, 100);
            _storage.CreatItem(circle);
            labelNumber.Text ="Объектов в хранилище " + Convert.ToString(_storage.GetMaxIdex());
        }

        private void btPaint_Click(object sender, EventArgs e)
        {
            if (_storage.GetMaxIdex() != 0)
            {
                Bitmap bmp = new Bitmap(painBox.Width, painBox.Height);
                Graphics graph = Graphics.FromImage(bmp);
                Pen pen = new Pen(Color.Red);
                Shape circle;
                for (int i = 1; i <= _storage.GetMaxIdex(); i++)
                {
                    circle = _storage.GetItem(i);
                    graph.DrawEllipse(pen, circle.x - circle.r / 2, circle.y - circle.r / 2, circle.r, circle.r);
                }
                painBox.BackgroundImage = bmp;
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            _storage.DeleteAll();
            labelNumber.Text = "Объектов в хранилище " + Convert.ToString(_storage.GetMaxIdex());
            Bitmap bmp = new Bitmap(painBox.Width, painBox.Height);
            Graphics graph = Graphics.FromImage(bmp);
            painBox.BackgroundImage = bmp;
        }
    }
}
