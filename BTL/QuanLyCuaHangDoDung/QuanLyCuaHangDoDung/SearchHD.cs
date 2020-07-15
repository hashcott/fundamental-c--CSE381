using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangDoDung
{
    public partial class SearchHD : Form
    {
        Functions fnc = new Functions();
        public SearchHD()
        {
            InitializeComponent();
        }
        private void SearchHD_Load(object sender, EventArgs e)
        {
            string sqlKH = "select * from KhachHang";
            fnc.loadcombo(comboBoxSearchByKH, sqlKH, "tenKH", "idKH");
        }
        private void buttonSearchByKH_Click(object sender, EventArgs e)
        {
            string sql = "select * from HoaDon where idKH ='" + comboBoxSearchByKH.SelectedValue + "'";
            fnc.loadData(dataGridViewHD, sql);
        }

        private void dataGridViewHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridViewHD.CurrentRow.Index;
            string MaHD = dataGridViewHD.Rows[index].Cells[0].Value.ToString();
            string MaKH = dataGridViewHD.Rows[index].Cells[1].Value.ToString();

            string sql = "select DoDung.tenDD, HD_DD.soLuong from HoaDon, HD_DD, DoDung where HD_DD.idHD = '"+MaHD+"' and HoaDon.idKH = '" + MaKH + "' and HoaDon.idHD= HD_DD.idHD and HD_DD.idDD = DoDung.idDD ";
            fnc.loadData(dataGridViewCTHD, sql);
        }

        private void buttonSearchByDate_Click(object sender, EventArgs e)
        {
            string sql = "select * from HoaDon where day(ngayHD) ='" + dateTimePickerNgay.Value.Day + "' and month(ngayHD) ='" + dateTimePickerNgay.Value.Month + "' and year(ngayHD) ='" + dateTimePickerNgay.Value.Year + "'";
            fnc.loadData(dataGridViewHD, sql);
        }

      
    }
}
