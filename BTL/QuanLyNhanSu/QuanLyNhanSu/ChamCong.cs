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
    public partial class ChamCong : Form
    {
        Functions fnc = new Functions();
        public ChamCong()
        {
            InitializeComponent();
        }

        private void ChamCong_Load(object sender, EventArgs e)
        {
            string sqlLoadCT = "select * from CongTrinh";
            fnc.loadcombo(comboBoxCT, sqlLoadCT, "tenCT", "idCT");
            string sqlLoadNV = "select * from NghiepVu";
            fnc.loadcombo(comboBoxNV, sqlLoadNV, "tenNV", "idNV");
            refresh();
            buttonCC.Enabled = false;
            buttonDelete.Enabled = false;
            buttonCancel.Enabled = false;
        }

        private void dataGridViewChuaChamCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridViewChuaChamCong.CurrentRow.Index;
            textBoxMa.Text = dataGridViewChuaChamCong.Rows[index].Cells[0].Value.ToString();
            textBoxMaCT.Text = dataGridViewChuaChamCong.Rows[index].Cells[3].Value.ToString();
            buttonCC.Enabled = true;
            buttonDelete.Enabled = false;
            buttonCancel.Enabled = true;
        }

        private void buttonCC_Click(object sender, EventArgs e)
        {
            string sqlInsert = "insert into ChamCong values('" + textBoxMa.Text + "','" + dateTimePicker1.Value.Date + "','" + textBoxMaCT.Text + "')";
            fnc.actionData(sqlInsert);
            refresh();
            clear();
        }

        private void refresh()
        {
            string sqlLoadChuaCham = "select NS.idNS,NS.hoTen,NV.tenNV,CT.idCT,CT.tenCT from NhanSu as NS, NghiepVu as NV, CongTrinh as CT , CongTrinh_NhanSu as CT_NS where NS.idNS = CT_NS.idNS and CT.idCT = CT_NS.idCT and NV.idNV=NS.idNghiepVu and NS.idNS in (select idNS from CongTrinh_NhanSu where status='True') and NS.idNS not in (select idNS from ChamCong where day(ngayChamCong) = " + DateTime.Today.Day + " and month(ngayChamCong) = " + DateTime.Today.Month + ")";
            fnc.loadData(dataGridViewChuaChamCong, sqlLoadChuaCham);
            string sqlLoadDaCham = "select NS.idNS,NS.hoTen,NV.tenNV,CT.idCT,CT.tenCT from NhanSu as NS, NghiepVu as NV, CongTrinh as CT , CongTrinh_NhanSu as CT_NS where NS.idNS = CT_NS.idNS and CT.idCT = CT_NS.idCT and NV.idNV=NS.idNghiepVu and NS.idNS in (select idNS from CongTrinh_NhanSu where status='True') and NS.idNS in (select idNS from ChamCong where day(ngayChamCong) = " + DateTime.Today.Day + " and month(ngayChamCong) = " + DateTime.Today.Month + ")";
            fnc.loadData(dataGridViewDaChamCong, sqlLoadDaCham);
        }
        private void clear()
        {
            textBoxMa.Text = "";
            textBoxMaCT.Text = "";
            dateTimePicker1.Value = DateTime.Today.Date;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string sqlDele = "delete from ChamCong where idNS='"+textBoxMa.Text+"' and ngayChamCong = '"+dateTimePicker1.Value.Date+"'";
            fnc.actionData(sqlDele);
            refresh();
            clear();
        }

        private void dataGridViewDaChamCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridViewDaChamCong.CurrentRow.Index;
            textBoxMa.Text = dataGridViewDaChamCong.Rows[index].Cells[0].Value.ToString();
            textBoxMaCT.Text = dataGridViewDaChamCong.Rows[index].Cells[3].Value.ToString();
            buttonCC.Enabled = false;
            buttonDelete.Enabled = true;
            buttonCancel.Enabled = true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            clear();
            buttonCC.Enabled = false;
            buttonDelete.Enabled = false;
            buttonCancel.Enabled = false;
        }
    }
}
