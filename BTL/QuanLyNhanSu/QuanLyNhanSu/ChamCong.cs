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

            string sqlLoadCTT = "select * from CongTrinh";
            fnc.loadcombo(comboBoxCTT, sqlLoadCTT, "tenCT", "idCT");
            textBoxMon.Text = DateTime.Today.Month.ToString();
            textBoxYear.Text = DateTime.Today.Year.ToString();
            refreshTT();
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
            string sqlInsert = "insert into ChamCong values('" + textBoxMa.Text + "','" + dateTimePicker1.Value.Date + "','" + textBoxMaCT.Text + "','False')";
            fnc.actionData(sqlInsert);
            refresh();
            clear();
        }

        private void refresh()
        {
            string sqlLoadChuaCham = "select NS.idNS,NS.hoTen,NV.tenNV,CT.idCT,CT.tenCT from NhanSu as NS, NghiepVu as NV, CongTrinh as CT , CongTrinh_NhanSu as CT_NS where NS.idNS = CT_NS.idNS and CT.idCT = CT_NS.idCT and NV.idNV=NS.idNghiepVu and NS.idNS in (select idNS from CongTrinh_NhanSu where status='False') and NS.idNS not in (select idNS from ChamCong where day(ngayChamCong) = " + DateTime.Today.Day + " and month(ngayChamCong) = " + DateTime.Today.Month + ")";
            fnc.loadData(dataGridViewChuaChamCong, sqlLoadChuaCham);
            string sqlLoadDaCham = "select NS.idNS,NS.hoTen,NV.tenNV,CT.idCT,CT.tenCT from NhanSu as NS, NghiepVu as NV, CongTrinh as CT , CongTrinh_NhanSu as CT_NS where NS.idNS = CT_NS.idNS and CT.idCT = CT_NS.idCT and NV.idNV=NS.idNghiepVu and NS.idNS in (select idNS from CongTrinh_NhanSu where status='False') and NS.idNS in (select idNS from ChamCong where day(ngayChamCong) = " + DateTime.Today.Day + " and month(ngayChamCong) = " + DateTime.Today.Month + ")";
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

        private void buttonSR_Click(object sender, EventArgs e)
        {
            refreshTT();
        }
        private void refreshTT()
        {
            string sqlLoadChuaTT = "select NhanSu.idNS, NhanSu.hoTen, JN.count_cc as soNgayLam from NhanSu,(select count(idNS) as count_cc,idNS from ChamCong where month(ngayChamCong) = '"+textBoxMon.Text+"' and year(ngayChamCong) = '"+textBoxYear.Text+"' and status='False' group by idNS) as JN where NhanSu.idNS = JN.idNS;";
            fnc.loadData(dataGridViewChuaThanhToan, sqlLoadChuaTT);
            string sqlLoadDaTT = "select NhanSu.idNS, NhanSu.hoTen, JN.count_cc as soNgayLam from NhanSu,(select count(idNS) as count_cc,idNS from ChamCong where month(ngayChamCong) = '" + textBoxMon.Text + "' and year(ngayChamCong) = '" + textBoxYear.Text + "' and status='True' group by idNS) as JN where NhanSu.idNS = JN.idNS;";
            fnc.loadData(dataGridViewThanhToan, sqlLoadDaTT);
        }

        private void dataGridViewChuaThanhToan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridViewChuaThanhToan.CurrentRow.Index;
            textBoxTenTT.Text = dataGridViewChuaThanhToan.Rows[index].Cells[1].Value.ToString();
            textBoxMaTT.Text = dataGridViewChuaThanhToan.Rows[index].Cells[0].Value.ToString();
        }

        private void buttonTT_Click(object sender, EventArgs e)
        {
            string sqlUpdate = "update ChamCong set status='True' where month(ngayChamCong) = '" + textBoxMon.Text + "' and year(ngayChamCong) = '" + textBoxYear.Text + "' and idNS='" + textBoxMaTT.Text + "'";
            fnc.actionData(sqlUpdate);
            refreshTT();
        }

        private void buttonChuaTT_Click(object sender, EventArgs e)
        {
            string sqlUpdate = "update ChamCong set status='False' where month(ngayChamCong) = '" + textBoxMon.Text + "' and year(ngayChamCong) = '" + textBoxYear.Text + "' and idNS='" + textBoxMaTT.Text + "'";
            fnc.actionData(sqlUpdate);
            refreshTT();
            refresh();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string sqlLoadChuaCham = "select NS.idNS,NS.hoTen,NV.tenNV,CT.idCT,CT.tenCT from NhanSu as NS, NghiepVu as NV, CongTrinh as CT , CongTrinh_NhanSu as CT_NS where NS.idNS = CT_NS.idNS and CT.idCT = CT_NS.idCT and NV.idNV=NS.idNghiepVu and NS.idNS in (select idNS from CongTrinh_NhanSu where status='False') and NS.idNS not in (select idNS from ChamCong where day(ngayChamCong) = " + dateTimePicker1.Value.Day + " and month(ngayChamCong) = " + dateTimePicker1.Value.Month + ")";
            fnc.loadData(dataGridViewChuaChamCong, sqlLoadChuaCham);
            string sqlLoadDaCham = "select NS.idNS,NS.hoTen,NV.tenNV,CT.idCT,CT.tenCT from NhanSu as NS, NghiepVu as NV, CongTrinh as CT , CongTrinh_NhanSu as CT_NS where NS.idNS = CT_NS.idNS and CT.idCT = CT_NS.idCT and NV.idNV=NS.idNghiepVu and NS.idNS in (select idNS from CongTrinh_NhanSu where status='False') and NS.idNS in (select idNS from ChamCong where day(ngayChamCong) = " + dateTimePicker1.Value.Day + " and month(ngayChamCong) = " + dateTimePicker1.Value.Month + ")";
            fnc.loadData(dataGridViewDaChamCong, sqlLoadDaCham);
        }
    }
}
