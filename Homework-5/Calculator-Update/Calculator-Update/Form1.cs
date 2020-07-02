using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_Update
{
    public partial class Form1 : Form
    {

        protected int result;
        protected string operatorKey;

        public Form1()
        {
            InitializeComponent();
        }

        private void thayĐổiMàuSắcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.button1.BackColor = colorDialog1.Color;
                this.button2.BackColor = colorDialog1.Color;
                this.button3.BackColor = colorDialog1.Color;
                this.button4.BackColor = colorDialog1.Color;
                this.button5.BackColor = colorDialog1.Color;
                this.button6.BackColor = colorDialog1.Color;
                this.button7.BackColor = colorDialog1.Color;
                this.button8.BackColor = colorDialog1.Color;
                this.button9.BackColor = colorDialog1.Color;
                this.button10.BackColor = colorDialog1.Color;
                this.button11.BackColor = colorDialog1.Color;
                this.button12.BackColor = colorDialog1.Color;
                this.button13.BackColor = colorDialog1.Color;
                this.button14.BackColor = colorDialog1.Color;
                this.button15.BackColor = colorDialog1.Color;
                this.button16.BackColor = colorDialog1.Color;
            }
        }

        private void thayĐổiFontChữToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                this.Font = fontDialog1.Font;
            }
        }

        private void button_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            textBox1.Text += button.Text;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            result = 0;
            operatorKey = "";
            textBox1.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operatorKey = button.Text;
            result = int.Parse(textBox1.Text);
            textBox1.Text = "";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            switch(operatorKey)
            {
                case "+":
                    textBox1.Text = (result + int.Parse(textBox1.Text)).ToString();
                    break;
                case "-":
                    textBox1.Text = (result - int.Parse(textBox1.Text)).ToString();
                    break;
                case "*":
                    textBox1.Text = (result * int.Parse(textBox1.Text)).ToString();
                    break;
                case "/":
                    textBox1.Text = (result / int.Parse(textBox1.Text)).ToString();
                    break;
            }
        }
    }
}
