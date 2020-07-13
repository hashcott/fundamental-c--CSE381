using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        protected double a, b;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text ="Tổng a+b = " + (a + b);
            label4.Text ="Hiệu a-b = " + (a - b);
            label5.Text ="Tích a*b = " + (a * b);
            label6.Text ="Thương a/b = " + (a / b);
        }


        private void textBox1_Leave(object sender, EventArgs e)
        {
            a = Convert.ToDouble(textBox1.Text);

        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            b = Convert.ToDouble(textBox2.Text);
        }

      
    }
}
