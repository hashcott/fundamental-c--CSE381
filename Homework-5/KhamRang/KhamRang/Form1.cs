using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KhamRang
{
    public partial class Form1 : Form
    {
        protected int tongTien;
        protected int caoVoi, tayTrang, chupHinh, layCao, hanRang;

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            caoVoi = checkBox1.Checked ? 100000 : 0;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            tayTrang = checkBox2.Checked ? 1200000 : 0;

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            chupHinh = checkBox3.Checked ? 150000 : 0;

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            hanRang = Convert.ToInt32(numericUpDown2.Value) * 90000;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            layCao = checkBox4.Checked ? 100000 : 0;

        }

        

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tongTien = caoVoi + tayTrang + chupHinh + layCao + hanRang;
            textBox2.Text = Convert.ToString(tongTien);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
