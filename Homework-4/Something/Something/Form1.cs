using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Something
{
    public partial class Form1 : Form
    {
        protected int n;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            n = Convert.ToInt32(textBox1.Text);
            if(n >= 1000 || n<= 0)
            {
                label2.Text = "Notification : Vui lòng nhập số nguyên dương 0 < n < 1000";
                label2.ForeColor = Color.Red;
            } else
            {
                label2.Text = "Notification: Nhập số thành công";
                label2.ForeColor = Color.Green;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Helper hp = new Helper(n);
            label3.Text = "Số nguyên tố nhỏ hơn n: " + hp.nguyenTo();
            label4.Text = "Số chính phương nhỏ hơn n: " + hp.chinhPhuong();
            label5.Text = "Số hoàn chỉnh nhỏ hơn n: " + hp.hoanChinh();

        }
    }
}
