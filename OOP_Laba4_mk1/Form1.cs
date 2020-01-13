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
                    creatCircleOnPicture = false;
                }
            }
            if (creatCircleOnPicture)
            {
                Circle circle = new Circle(e.X, e.Y, 100);
                _storage.AddItem(circle);
            }
            creatCircleOnPicture = true;
            painBox.Refresh();
        }

        private void btDelMarked_Click(object sender, EventArgs e)
        {
            DeleteMarkedItems();
        }

        private void btDelAll_Click(object sender, EventArgs e)
        {
            _storage.DeleteAll();
            painBox.Refresh();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteMarkedItems();
            }
        }

        private void painBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics pain = e.Graphics;
            for (int i = 1; i <= _storage.GetMaxIndex(); i++)
            {
                _storage.GetItem(i).Draw(pain);
            }
            labelNumber.Text = "Объектов в хранилище " + Convert.ToString(_storage.GetMaxIndex());
        }
    }
}
