using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StorageForPain;


namespace OOP_Laba4_mk1
{
    public partial class Form1 : Form
    {
        private Storage _storage = new Storage(10);
        public Form1()
        {
            InitializeComponent();
        }

        private void painBox_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void painBox_MouseDown(object sender, MouseEventArgs e)
        {
            
        }
    }
}
