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
    public partial class ThongKe : Form
    {
        Functions fnc = new Functions();
        public ThongKe()
        {
            InitializeComponent();
        }
        private void ThongKe_Load(object sender, EventArgs e)
        {
            
        }
        private void buttonThongKe_Click(object sender, EventArgs e)
        {
            string sql;
            if (radioButtonNSX.Checked)
            {
                sql = "select TK.idNSX, NhaSanXuat.tenNSX, TK.total_sl from (select NhaSanXuat.idNSX,sum(HD_DD.soLuong) as total_sl from HD_DD, DoDung, NhaSanXuat where HD_DD.idDD = DoDung.idDD and DoDung.idNSX = NhaSanXuat.idNSX group by NhaSanXuat.idNSX) as TK inner join NhaSanXuat on NhaSanXuat.idNSX = TK.idNSX order by TK.total_sl DESC;";
                fnc.loadData(dataGridViewTK, sql);
                dataGridViewTK.Columns[0].HeaderText = "Mã NSX";
                dataGridViewTK.Columns[1].HeaderText = "Tên NSX";
                dataGridViewTK.Columns[2].HeaderText = "Số Lượng Bán Được";
            }
            if (radioButtonLDD.Checked)
            {

                sql = "select TK.idLDD, LoaiDoDung.tenLDD, TK.total_sl from (select LoaiDoDung.idLDD,sum(HD_DD.soLuong) as total_sl from HD_DD, DoDung, LoaiDoDung where HD_DD.idDD = DoDung.idDD and DoDung.idLDD = LoaiDoDung.idLDD group by LoaiDoDung.idLDD) as TK inner join LoaiDoDung on LoaiDoDung.idLDD = TK.idLDD order by TK.total_sl DESC;";
                fnc.loadData(dataGridViewTK, sql);
                dataGridViewTK.Columns[0].HeaderText = "Mã Loại Đồ Dùng";
                dataGridViewTK.Columns[1].HeaderText = "Tên Loại Đồ Dùng";
                dataGridViewTK.Columns[2].HeaderText = "Số Lượng Bán Được";
            }
            if (radioButtonDD.Checked)
            {
                sql = "select TK.idDD,DoDung.tenDD,TK.total_sl from (select DoDung.idDD, sum(HD_DD.soLuong) as total_sl from HD_DD, DoDung where HD_DD.idDD = DoDung.idDD group by DoDung.idDD) as TK inner join DoDung on TK.idDD = DoDung.idDD order by TK.total_sl desc;";
                fnc.loadData(dataGridViewTK, sql);
                dataGridViewTK.Columns[0].HeaderText = "Mã Đồ Dùng";
                dataGridViewTK.Columns[1].HeaderText = "Tên Đồ Dùng";
                dataGridViewTK.Columns[2].HeaderText = "Số Lượng Bán Được";
            }
            if (radioButtonKH.Checked)
            {
                sql = "select TK.idKH,KhachHang.tenKH,TK.total_sl from (select KhachHang.idKH, sum(HD_DD.soLuong) as total_sl from HD_DD, KhachHang, HoaDon where HD_DD.idHD = HoaDon.idHD and HoaDon.idKH = KhachHang.idKH group by KhachHang.idKH) as TK inner join KhachHang on TK.idKH = KhachHang.idKH order by TK.total_sl desc;";
                fnc.loadData(dataGridViewTK, sql);
                dataGridViewTK.Columns[0].HeaderText = "Mã Khách Hàng";
                dataGridViewTK.Columns[1].HeaderText = "Tên Khách Hàng";
                dataGridViewTK.Columns[2].HeaderText = "Số Lượng Mua";
            }
        }

      
    }
}
