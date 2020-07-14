using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace QuanLyNhanSu
{
    public partial class NghiepVu : Form
    {
        Functions fnc = new Functions();
        public NghiepVu()
        {
            InitializeComponent();
        }

        private void NghiepVu_Load(object sender, EventArgs e)
        {
            textBoxMa.Text = fnc.ReturnUniqueValue();
            string sql = "select * from NghiepVu";
            fnc.loadData(dataGridView1, sql);
            dataGridView1.Columns[0].HeaderText = "Mã nghiệp vụ";
            dataGridView1.Columns[1].HeaderText = "Tên nghiệp vụ";
            dataGridView1.Columns[2].HeaderText = "Mức lương đề nghị";

            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control i in Controls)
            {
                if (i is TextBox && i.Text.Length == 0)
                {
                    if (MessageBox.Show("Bạn phải nhập tất cả các trường", "Cảnh báo", MessageBoxButtons.OK) == DialogResult.OK)
                    {
                        return;
                    }
                }
            }
            string sqlEx = "insert into NghiepVu values('"+textBoxMa.Text + "',N'" + textBoxTen.Text + "','" + Convert.ToInt32(textBoxMucLuong.Text) + "')";
            fnc.actionData(sqlEx);
            string sql = "select * from NghiepVu";
            fnc.loadData(dataGridView1, sql);
            clear();
        }
        private void clear()
        {
            textBoxMa.Text = fnc.ReturnUniqueValue();
            textBoxTen.Text = "";
            textBoxMucLuong.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true; 
            int index = dataGridView1.CurrentRow.Index;
            textBoxMa.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            textBoxTen.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            textBoxMucLuong.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clear();
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn muốn sửa "+textBoxTen.Text+"?", "Cảnh báo",
         MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            string sqlEx = "update NghiepVu set idNV='" + textBoxMa.Text + "',TenNV=N'" + textBoxTen.Text + "',mucluongDeNghi='" + Convert.ToInt32(textBoxMucLuong.Text) + "' where idNV='"+textBoxMa.Text+"'";
            fnc.actionData(sqlEx);
            string sql = "select * from NghiepVu";
            fnc.loadData(dataGridView1, sql);
            clear();
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa " + textBoxTen.Text + "?", "Cảnh báo",
        MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            string sqlEx = "delete from NghiepVu where idNV='"+textBoxMa.Text+"'";
            fnc.actionData(sqlEx);
            string sql = "select * from NghiepVu";
            fnc.loadData(dataGridView1, sql);
            clear();
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }
    }
}
