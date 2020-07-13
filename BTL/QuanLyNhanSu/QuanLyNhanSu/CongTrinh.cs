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
    public partial class CongTrinh : Form
    {
        Functions fnc = new Functions();
        public CongTrinh()
        {
            InitializeComponent();
        }

        private void CongTrinh_Load(object sender, EventArgs e)
        {
           
            textBoxMa.Text = fnc.ReturnUniqueValue();
            string sql = "select * from CongTrinh";
            fnc.loadData(dataGridViewDuAn, sql);
            dataGridViewDuAn.Columns[0].HeaderText = "Mã dự án";
            dataGridViewDuAn.Columns[1].HeaderText = "Tên dự án";
            dataGridViewDuAn.Columns[2].HeaderText = "Địa chỉ thi công";
            dataGridViewDuAn.Columns[3].HeaderText = "Ngày bắt đầu";
            dataGridViewDuAn.Columns[4].HeaderText = "Ngày kết thúc (dự kiến)";
            dataGridViewDuAn.Columns[5].HeaderText = "Số lượng nhân sự cần";
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlInsert = "insert into CongTrinh values('" + textBoxMa.Text + "',N'" + textBoxTen.Text + "',N'" + textBoxDC.Text + "','" + dateTimePickerBD.Value.Date + "','" + dateTimePickerKT.Value.Date + "','" + numberNhanSu.Value + "')";
            fnc.actionData(sqlInsert);
            string sql = "select * from CongTrinh";
            fnc.loadData(dataGridViewDuAn, sql);
            clear();
        }

        private void clear()
        {
            textBoxMa.Text = fnc.ReturnUniqueValue();
            textBoxTen.Text = "";
            textBoxDC.Text = "";
            dateTimePickerBD.Value = DateTime.Today;
            dateTimePickerKT.Value = DateTime.Today;
            numberNhanSu.Value = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            clear();
        }

        private void dataGridViewDuAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridViewDuAn.CurrentRow.Index;
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            if (dataGridViewDuAn.Rows[index].Cells[0].Value.ToString() == "") return;
            textBoxMa.Text = dataGridViewDuAn.Rows[index].Cells[0].Value.ToString();
            textBoxTen.Text = dataGridViewDuAn.Rows[index].Cells[1].Value.ToString();
            textBoxDC.Text = dataGridViewDuAn.Rows[index].Cells[2].Value.ToString();
            dateTimePickerBD.Value = DateTime.Parse(dataGridViewDuAn.Rows[index].Cells[3].Value.ToString());
            dateTimePickerKT.Value = DateTime.Parse(dataGridViewDuAn.Rows[index].Cells[4].Value.ToString());
            numberNhanSu.Value = Convert.ToInt32(dataGridViewDuAn.Rows[index].Cells[5].Value.ToString());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sqlInsert = "update CongTrinh set idCT = '" + textBoxMa.Text + "', tenCT = N'" + textBoxTen.Text + "',diaDiem = N'" + textBoxDC.Text + "',ngayBD = '" + dateTimePickerBD.Value.Date + "',ngayKTDuKien = '" + dateTimePickerKT.Value.Date + "', soLuongNS = '" + numberNhanSu.Value + "' where idCT = '"+textBoxMa.Text+"'";
            fnc.actionData(sqlInsert);
            string sql = "select * from CongTrinh";
            fnc.loadData(dataGridViewDuAn, sql);
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sqlInsert = "delete from CongTrinh where idCT = '" + textBoxMa.Text + "'";
            fnc.actionData(sqlInsert);
            string sql = "select * from CongTrinh";
            fnc.loadData(dataGridViewDuAn, sql);
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            clear();
        }
    }
}
