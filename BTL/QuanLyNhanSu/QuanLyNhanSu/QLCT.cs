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
    public partial class QLCT : Form
    {
        Functions fnc = new Functions();
        public QLCT()
        {
            InitializeComponent();
        }

        private void QLCT_Load(object sender, EventArgs e)
        {
            string sqlLoadCT = "select * from CongTrinh";
            fnc.loadcombo(comboBoxCT, sqlLoadCT, "tenCT", "idCT");
            string sqlLoadNV = "select * from NghiepVu";
            fnc.loadcombo(comboBoxNV, sqlLoadNV, "tenNV", "idNV");
            refresh();
            buttonAdd.Enabled = false;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
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

            string sqlSearch = "select NS.idNS,NS.hoTen, NS.gioiTinh,NS.diaChi,NS.sdt,NS.email,NS.cmnd,NV.tenNV from NhanSu as NS inner join NghiepVu as NV on NV.idNV=NS.idNghiepVu where NS.idNghiepVu = '" + comboBoxNV.SelectedValue + "' or (NS.diaChi = '%"+comboBoxDC.Text+ "%' or NS.gioiTinh like N'" + gioiTinh + "' or NS.hoTen like N'" + textBoxTen.Text + "') and NS.idNS not in (select idNS from CongTrinh_NhanSu where status='True')";
            fnc.loadData(dataGridViewNhanSu, sqlSearch);
        }

        private void dataGridViewNhanSu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridViewNhanSu.CurrentRow.Index;
            textBoxTenChoose.Text = dataGridViewNhanSu.Rows[index].Cells[1].Value.ToString();
            textBoxMa.Text = dataGridViewNhanSu.Rows[index].Cells[0].Value.ToString();
            buttonAdd.Enabled = true;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Today;
            string sqlInsert = "insert into CongTrinh_NhanSu values('"+textBoxMa.Text+ "','" + comboBoxCT.SelectedValue + "','" + dt.Date + "','True')";
            fnc.actionData(sqlInsert);

            refresh();

            buttonAdd.Enabled = false;
            buttonDelete.Enabled = false;
            buttonUpdate.Enabled = false;
            clear();
        }

        private void dataGridViewNS_CT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridViewNS_CT.CurrentRow.Index;
            comboBoxCT.SelectedIndex = comboBoxCT.FindString(dataGridViewNS_CT.Rows[index].Cells[3].Value.ToString());
            textBoxMa.Text = dataGridViewNS_CT.Rows[index].Cells[0].Value.ToString();
            textBoxTenChoose.Text = dataGridViewNS_CT.Rows[index].Cells[1].Value.ToString();
        }
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string sqlInsert = "update CongTrinh_NhanSu set idCT = '" + comboBoxCT.SelectedValue + "' where idNS = '" + textBoxMa.Text + "'";
            fnc.actionData(sqlInsert);
            refresh();
            buttonAdd.Enabled = false;
            buttonDelete.Enabled = false;
            buttonUpdate.Enabled = false;
            clear();
        }

        private void clear()
        {
            textBoxMa.Text = "";
            textBoxTenChoose.Text = "";
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            buttonAdd.Enabled = false;
            buttonDelete.Enabled = false;
            buttonUpdate.Enabled = false;
            clear();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string sqlInsert = "delete from CongTrinh_NhanSu where idNS = '" + textBoxMa.Text + "'";
            fnc.actionData(sqlInsert);
            refresh();
            buttonAdd.Enabled = false;
            buttonDelete.Enabled = false;
            buttonUpdate.Enabled = false;
            clear();
        }

        private void buttonSuccess_Click(object sender, EventArgs e)
        {
            string sqlInsert = "update CongTrinh_NhanSu set status = 'False' where idNS = '" + textBoxMa.Text + "'";
            fnc.actionData(sqlInsert);
            refresh();
            buttonAdd.Enabled = false;
            buttonDelete.Enabled = false;
            buttonUpdate.Enabled = false;
            clear();
        }

        private void buttonNoSuccess_Click(object sender, EventArgs e)
        {
            string sqlInsert = "update CongTrinh_NhanSu set status = 'True' where idNS = '" + textBoxMa.Text + "'";
            fnc.actionData(sqlInsert);
            refresh();
            buttonAdd.Enabled = false;
            buttonDelete.Enabled = false;
            buttonUpdate.Enabled = false;
            clear();
        }

        private void refresh()
        {
            string sqlLoadCT_NS = "select NS.idNS,NS.hoTen,NV.tenNV,CT.tenCT,CT_NS.ngayBDLam, CT_NS.status from NhanSu as NS, NghiepVu as NV, CongTrinh as CT , CongTrinh_NhanSu as CT_NS where NS.idNS = CT_NS.idNS and CT.idCT = CT_NS.idCT and NV.idNV=NS.idNghiepVu";
            fnc.loadData(dataGridViewNS_CT, sqlLoadCT_NS);
            string sqlLoadNS = "select NS.idNS,NS.hoTen, NS.gioiTinh,NS.diaChi,NS.sdt,NS.email,NS.cmnd,NV.tenNV from NhanSu as NS inner join NghiepVu as NV on NV.idNV=NS.idNghiepVu where NS.idNS not in (select idNS from CongTrinh_NhanSu where status='True')";
            fnc.loadData(dataGridViewNhanSu, sqlLoadNS);
        }
    }
}
