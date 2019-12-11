using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Storage;


namespace OOP_Laba4_mk1
{
    public partial class Form1 : Form
    {
        private Storage.Storage _storage = new Storage.Storage(20);
        public Form1()
        {
            InitializeComponent();
        }

        private void painBox_MouseUp(object sender, MouseEventArgs e)
        {
            _storage.CreateItem(_storage.GetCurrentIndex(),new Circle(e.X,e.Y,5.000));
            _storage.Next();
        }

        private void painBox_MouseDown(object sender, MouseEventArgs e)
        {
            
        }
    }
}
