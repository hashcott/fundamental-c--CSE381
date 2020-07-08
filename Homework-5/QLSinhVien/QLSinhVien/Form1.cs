using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSinhVien
{
   
    public partial class Form1 : Form
    {
        List<Person> People = new List<Person>();
        protected string ms;
        protected string ht;
        protected string ng;
        protected bool gt;
        protected string qq;
        protected string l;
        protected string k;
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = this.People;

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            ms = textBox1.Text;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            ht = textBox2.Text;
        }

        private void dateTimePicker1_Leave(object sender, EventArgs e)
        {
            ng = dateTimePicker1.Value.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            qq = comboBox1.Text;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            l = comboBox2.Text;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            k = comboBox3.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            People.Add(new Person()
            {
                msv = ms,
                hoTen = ht,
                ngaySinh = ng,
                gioiTinh= handleSex(gt),
                queQuan = qq,
                lop = l,
                Khoa = k
            });
            dataGridView1.Rows.Add(People.ToArray());
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gt = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gt = false;
        }
        private string handleSex(bool gt)
        {
            if (gt) return "Nam";
            return "Nữ";
        }
    }
}
