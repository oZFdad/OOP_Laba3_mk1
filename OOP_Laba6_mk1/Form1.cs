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

namespace OOP_Laba6_mk1
{
    public partial class Form1 : Form
    {
        private Storage _storage = new Storage(10);
        private bool creatShapeOnPicture = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void painBox_MouseDown(object sender, MouseEventArgs e)
        {
            Bitmap bmp = new Bitmap(painBox.Width, painBox.Height);
            if (creatShapeOnPicture)
            {
                var i = cbShapeChange.Text;
                if (i == "Circle")
                {
                    Circle shape = new Circle(e.X, e.Y, 100);
                    _storage.CreatItem(shape);
                }
                else if (i == "Square")
                {
                    Square shape = new Square(e.X, e.Y, 100);
                    _storage.CreatItem(shape);
                }
                else if (i=="Triangle")
                {
                    Triangle shape = new Triangle(e.X, e.Y, 100);
                    _storage.CreatItem(shape);
                }
                else
                {

                }
                _storage.GetItem().Draw(bmp);
                painBox.BackgroundImage = bmp;
            }
        }

        private void bt_Click(object sender, EventArgs e)
        {
            if (creatShapeOnPicture)
            {
                creatShapeOnPicture = false;
                btOnOffEdit.Text = "Включить режим редактирования";
            }
            else
            {
                creatShapeOnPicture = true;
                btOnOffEdit.Text = "Выключить режим редактирования";
            }
        }
    }
}
