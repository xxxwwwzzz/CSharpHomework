using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a1 = textBox1.Text;
            string a2 = textBox2.Text;
            double b1 = double.Parse(a1);
            double b2 = double.Parse(a2);
            double c = b1 * b2;
            textBox3.Text = ""+c;
        }


    }
}
