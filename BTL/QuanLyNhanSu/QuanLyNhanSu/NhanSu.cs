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
    public partial class NhanSu : Form
    {
        Functions fnc = new Functions();
        public NhanSu()
        {
            InitializeComponent();
        }

        private void NhanSu_Load(object sender, EventArgs e)
        {

            //Initial Default data for combobox Nghiệp Vụ
            string sqlNV = "select * from NghiepVu";
            fnc.loadcombo(comboBoxNV, sqlNV,"tenNV","idNV");

            // Set unique key
            textBoxMa.Text = fnc.ReturnUniqueValue();

            //Initial Default data for dataGridView
            string sqlNS = "select NS.idNS,NS.hoTen, NS.gioiTinh,NS.diaChi,NS.sdt,NS.email,NS.cmnd,NV.tenNV from NhanSu as NS inner join NghiepVu as NV on NV.idNV=NS.idNghiepVu";
            fnc.loadData(dataGridView3, sqlNS);
            buttonCancel.Enabled = false;
            buttonDelete.Enabled = false;
            buttonUpdate.Enabled = false;
        }

        // Insert Nhân Sự
        private void buttonAdd_Click(object sender, EventArgs e)   {
            // Validate input
            foreach (Control i in Controls)
            {
                if (i is TextBox && i.Text.Length == 0)
                {
                    if (MessageBox.Show("Bạn phải nhập tất cả các trường", "Cảnh báo", MessageBoxButtons.OK) == DialogResult.OK)
                    {
                        return;
                    }
                }
                if(i is TextBox && i.Name == "textBoxCMND")
                { 
                    if (MessageBox.Show("Chứng minh nhân dân bạn phải nhập bằng số", "Cảnh báo", MessageBoxButtons.OK) == DialogResult.OK)
                    {
                        return;
                    }
                }
                //if (i is TextBox && i.Name == "textBoxCMND" && !int.TryParse(i.Text, out int n))
                //{
                //    if (MessageBox.Show("Chứng minh nhân dân bạn phải nhập bằng số", "Cảnh báo", MessageBoxButtons.OK) == DialogResult.OK)
                //    {
                //        return;
                //    }
                //}
            }
            string gioiTinh = "";
            if(radioButtonNam.Checked)
            {
                gioiTinh = "Nam";
            } else if(radioButtonNu.Checked)
            {
                gioiTinh = "Nữ";
            } else if(radioButtonUndifined.Checked)
            {
                gioiTinh = "Chưa xác định";
            }


            string sqlEx = "insert into NhanSu values('" + textBoxMa.Text + "',N'" + textBoxTen.Text + "',N'" + gioiTinh + "',N'" + comboBoxDC.Text + "','" + textBoxSDT.Text + "','" + textBoxEmail.Text + "','" + textBoxCMND.Text + "',N'" + comboBoxNV.SelectedValue + "')";
            fnc.actionData(sqlEx);
            string sqlNS = "select NS.idNS,NS.hoTen, NS.gioiTinh,NS.diaChi,NS.sdt,NS.email,NS.cmnd,NV.tenNV from NhanSu as NS inner join NghiepVu as NV on NV.idNV=NS.idNghiepVu";
            fnc.loadData(dataGridView3, sqlNS);
            clear();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle Button click
            buttonAdd.Enabled = false;
            buttonCancel.Enabled = true;
            buttonUpdate.Enabled = true;
            buttonDelete.Enabled = true;
            int index = dataGridView3.CurrentRow.Index;
            textBoxMa.Text = dataGridView3.Rows[index].Cells[0].Value.ToString();
            textBoxTen.Text = dataGridView3.Rows[index].Cells[1].Value.ToString();

            radioButtonNam.Checked = dataGridView3.Rows[index].Cells[2].Value.ToString() == "Nam";
            radioButtonNu.Checked = dataGridView3.Rows[index].Cells[2].Value.ToString() == "Nữ";
            radioButtonUndifined.Checked = dataGridView3.Rows[index].Cells[2].Value.ToString() == "Chưa xác định";

            comboBoxDC.Text = dataGridView3.Rows[index].Cells[3].Value.ToString();
            textBoxSDT.Text = dataGridView3.Rows[index].Cells[4].Value.ToString();
            textBoxEmail.Text = dataGridView3.Rows[index].Cells[5].Value.ToString();
            textBoxCMND.Text = dataGridView3.Rows[index].Cells[6].Value.ToString();
            comboBoxNV.SelectedIndex = comboBoxNV.FindString(dataGridView3.Rows[index].Cells[7].Value.ToString());
        }

        // Update Nhân Sự
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string gioiTinh = "";
            if (radioButtonNam.Checked)
            {
                gioiTinh = "Nam";
            }
            else if (radioButtonNu.Checked)
            {
                gioiTinh = "Nữ";
            }
            else if (radioButtonUndifined.Checked)
            {
                gioiTinh = "Chưa xác định";
            }


            string sqlEx = "update NhanSu set idNS='" + textBoxMa.Text + "',hoTen = N'" + textBoxTen.Text + "',gioiTinh = N'" + gioiTinh + "',diaChi = N'" + comboBoxDC.Text + "',sdt = '" + textBoxSDT.Text + "',email = '" + textBoxEmail.Text + "',cmnd = '" + textBoxCMND.Text + "',idNghiepVu = '" + comboBoxNV.SelectedValue + "' where idNS='"+ textBoxMa.Text + "'";
            fnc.actionData(sqlEx);
            string sqlNS = "select NS.idNS,NS.hoTen, NS.gioiTinh,NS.diaChi,NS.sdt,NS.email,NS.cmnd,NV.tenNV from NhanSu as NS inner join NghiepVu as NV on NV.idNV=NS.idNghiepVu";
            fnc.loadData(dataGridView3, sqlNS);
            clear();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            buttonAdd.Enabled = true;
            buttonCancel.Enabled = false;
            buttonDelete.Enabled = false;
            buttonUpdate.Enabled = false;
            clear();
        }
        private void clear()
        {
            textBoxMa.Text = fnc.ReturnUniqueValue();
            textBoxTen.Text = "";
            textBoxSDT.Text = "";
            comboBoxDC.Text = "";
            textBoxCMND.Text = "";
            textBoxEmail.Text = "";
            radioButtonNam.Checked = false;
            radioButtonNu.Checked = false;
            radioButtonUndifined.Checked = false;
            comboBoxNV.SelectedValue = "";
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string sqlEx = "delete from NhanSu where idNS='" + textBoxMa.Text + "'";
            fnc.actionData(sqlEx);
            string sqlNS = "select NS.idNS,NS.hoTen, NS.gioiTinh,NS.diaChi,NS.sdt,NS.email,NS.cmnd,NV.tenNV from NhanSu as NS inner join NghiepVu as NV on NV.idNV=NS.idNghiepVu";
            fnc.loadData(dataGridView3, sqlNS);
            clear();
        }
    }
}
