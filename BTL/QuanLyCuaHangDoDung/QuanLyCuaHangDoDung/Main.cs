using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangDoDung
{
    public partial class Main : Form
    {
        Functions fnc = new Functions();
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            string sqlLDD = "select * from LoaiDoDung";
            fnc.loadData(dataGridViewLDD, sqlLDD);
            string sqlNSX = "select * from NhaSanXuat";
            fnc.loadData(dataGridViewNSX, sqlNSX);
            string sqlCL = "select * from ChatLieu";
            fnc.loadData(dataGridViewCL, sqlCL);
            string sqlDD = "select * from DoDung";
            fnc.loadData(dataGridViewDD, sqlDD);
            string sqlKH = "select * from KhachHang";
            fnc.loadData(dataGridViewKhachHang, sqlKH);
            refreshCB();
            // Loại đồ dùng
            textBoxMaLDD.Text = fnc.ReturnUniqueValue();
            buttonEditLDD.Enabled = false;
            buttonDeleLDD.Enabled = false;
            // Nhà sản xuất
            textBoxMaNSX.Text = fnc.ReturnUniqueValue();
            buttonDeleNSX.Enabled = false;
            buttonEditNSX.Enabled = false;
            // CHẤT LIỆU
            textBoxMaCL.Text = fnc.ReturnUniqueValue();
            buttonDeleCL.Enabled = false;
            buttonEditCL.Enabled = false;
            // Đồ dùng
            textBoxMaDD.Text = fnc.ReturnUniqueValue();
            buttonEditDD.Enabled = false;
            buttonDeleDD.Enabled = false;
            // Khách Hàng
            textBoxMaKH.Text = fnc.ReturnUniqueValue();
            buttonDeleKH.Enabled = false;
            buttonEditKH.Enabled = false;

            // Hóa Đơn
            textBoxMaHD.Text = fnc.ReturnUniqueValue();

        }
        private void refreshCB()
        {
            string sqlLoaiDD = "select * from LoaiDoDung";
            string sqlNSX = "select * from NhaSanXuat";
            string sqlCL = "select * from ChatLieu";
            string sqlKH = "select * from KhachHang";
            fnc.loadcombo(comboBoxLDD, sqlLoaiDD, "tenLDD", "idLDD");
            fnc.loadcombo(comboBoxHDLDD, sqlLoaiDD, "tenLDD", "idLDD");

            fnc.loadcombo(comboBoxNSX, sqlNSX, "tenNSX", "idNSX");
            fnc.loadcombo(comboBoxHDNSX, sqlNSX, "tenNSX", "idNSX");

            fnc.loadcombo(comboBoxCL, sqlCL, "tenCL", "idCL");
            fnc.loadcombo(comboBoxHDCL, sqlCL, "tenCL", "idCL");

            fnc.loadcombo(comboBoxKH, sqlKH, "tenKH", "idKH");

        }
        // Loại đồ dùng
        private void buttonAddLDD_Click(object sender, EventArgs e)
        {
            string sql = "insert into LoaiDoDung values('" + textBoxMaLDD.Text + "',N'" + textBoxTenLDD.Text + "')";
            fnc.actionData(sql);
            string sqlLoaiDD = "select * from LoaiDoDung";
            fnc.loadData(dataGridViewLDD, sqlLoaiDD);
            clearLDD();
            refreshCB();
        }

        private void dataGridViewLoaiDD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridViewLDD.CurrentRow.Index;
            textBoxMaLDD.Text = dataGridViewLDD.Rows[index].Cells[0].Value.ToString();
            textBoxTenLDD.Text = dataGridViewLDD.Rows[index].Cells[1].Value.ToString();
            textBoxMaLDD.Enabled = false;
            buttonEditLDD.Enabled = true;
            buttonDeleLDD.Enabled = true;
            buttonAddLDD.Enabled = false;
        }

        private void buttonEditLDD_Click(object sender, EventArgs e)
        {
            string sql = "update LoaiDoDung set tenLDD = N'" + textBoxTenLDD.Text + "' where idLDD = '" + textBoxMaLDD.Text + "'";
            fnc.actionData(sql);
            string sqlLoaiDD = "select * from LoaiDoDung";
            fnc.loadData(dataGridViewLDD, sqlLoaiDD);
            textBoxMaLDD.Enabled = true;
            buttonEditLDD.Enabled = false;
            buttonDeleLDD.Enabled = false;
            buttonAddLDD.Enabled = true;
            refreshCB();
            clearLDD();
        }

        private void buttonDeleLDD_Click(object sender, EventArgs e)
        {
            string sql = "delete from LoaiDoDung where idLDD = '" + textBoxMaLDD.Text + "'";
            fnc.actionData(sql);
            string sqlLoaiDD = "select * from LoaiDoDung";
            fnc.loadData(dataGridViewLDD, sqlLoaiDD);
            textBoxMaLDD.Enabled = true;
            buttonEditLDD.Enabled = false;
            buttonDeleLDD.Enabled = false;
            buttonAddLDD.Enabled = true;
            refreshCB();
            clearLDD();
            textBoxMaLDD.Enabled = true;
        }
        private void clearLDD()
        {
            textBoxMaLDD.Text = fnc.ReturnUniqueValue();
            textBoxTenLDD.Text = "";
        }
        // NSX
        private void buttonAddNSX_Click(object sender, EventArgs e)
        {
            string sql = "insert into NhaSanXuat values('" + textBoxMaNSX.Text + "',N'" + textBoxTenNSX.Text + "')";
            fnc.actionData(sql);
            string sqlNSX = "select * from NhaSanXuat";
            fnc.loadData(dataGridViewNSX, sqlNSX);
            clearNSX();
            refreshCB();
        }

        private void buttonEditNSX_Click(object sender, EventArgs e)
        {
            string sql = "update NhaSanXuat set tenNSX = N'" + textBoxTenNSX.Text + "'where idNSX = '" + textBoxMaNSX.Text + "'";
            fnc.actionData(sql);
            string sqlNSX = "select * from NhaSanXuat";
            fnc.loadData(dataGridViewNSX, sqlNSX);
            clearNSX();
            refreshCB();
            textBoxMaNSX.Enabled = true;
            buttonAddNSX.Enabled = true;
            buttonEditNSX.Enabled = false;
            buttonDeleNSX.Enabled = false;
        }

        private void dataGridViewNSX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridViewNSX.CurrentRow.Index;
            textBoxMaNSX.Text = dataGridViewNSX.Rows[index].Cells[0].Value.ToString();
            textBoxTenNSX.Text = dataGridViewNSX.Rows[index].Cells[1].Value.ToString();
            textBoxMaNSX.Enabled = false;
            buttonAddNSX.Enabled = false;
            buttonEditNSX.Enabled = true;
            buttonDeleNSX.Enabled = true;
        }

        private void buttonDeleNSX_Click(object sender, EventArgs e)
        {
            string sql = "delete from NhaSanXuat where idNSX = '" + textBoxMaNSX.Text + "'";
            fnc.actionData(sql);
            string sqlNSX = "select * from NhaSanXuat";
            fnc.loadData(dataGridViewNSX, sqlNSX);
            clearNSX();
            refreshCB();
            textBoxMaNSX.Enabled = true;
            buttonAddNSX.Enabled = true;
            buttonEditNSX.Enabled = false;
            buttonDeleNSX.Enabled = false;
        }
        private void clearNSX()
        {
            textBoxMaNSX.Text = fnc.ReturnUniqueValue();
            textBoxTenNSX.Text = "";
        }
        // Chất liệu

        private void buttonAddCL_Click(object sender, EventArgs e)
        {
            string sql = "insert into ChatLieu values('" + textBoxMaCL.Text + "',N'" + textBoxTenCL.Text + "')";
            fnc.actionData(sql);
            string sqlCL = "select * from ChatLieu";
            fnc.loadData(dataGridViewCL, sqlCL);
            refreshCB();
            clearCL();

        }

        private void buttonEditCL_Click(object sender, EventArgs e)
        {
            string sql = "update ChatLieu set tenCL = N'" + textBoxTenCL.Text + "' where idCL = '" + textBoxMaCL.Text + "'";
            fnc.actionData(sql);
            string sqlCL = "select * from ChatLieu";
            fnc.loadData(dataGridViewCL, sqlCL);
            textBoxMaCL.Enabled = true;
            buttonAddCL.Enabled = true;
            buttonEditCL.Enabled = false;
            buttonDeleCL.Enabled = false;
            refreshCB();
            clearCL();
        }

        private void dataGridViewCL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridViewCL.CurrentRow.Index;
            textBoxMaCL.Text = dataGridViewCL.Rows[index].Cells[0].Value.ToString();
            textBoxTenCL.Text = dataGridViewCL.Rows[index].Cells[1].Value.ToString();
            textBoxMaNSX.Enabled = false;
            buttonAddCL.Enabled = false;
            buttonEditCL.Enabled = true;
            buttonDeleCL.Enabled = true;
        }

        private void buttonDeleCL_Click(object sender, EventArgs e)
        {
            string sql = "delete from ChatLieu where idCL = '" + textBoxMaCL.Text + "'";
            fnc.actionData(sql);
            string sqlCL = "select * from ChatLieu";
            fnc.loadData(dataGridViewCL, sqlCL);
            textBoxMaCL.Enabled = true;
            buttonAddCL.Enabled = true;
            buttonEditCL.Enabled = false;
            buttonDeleCL.Enabled = false;
            refreshCB();
            clearCL();
        }

        private void clearCL()
        {
            textBoxMaCL.Text = fnc.ReturnUniqueValue();
            textBoxTenCL.Text = "";
        }
        // Đồ Dùng
        private void buttonAddDD_Click(object sender, EventArgs e)
        {
            string sql = "insert into DoDung values('" + textBoxMaDD.Text + "',N'" + textBoxTenDD.Text + "','" + numericUpDownSL.Value + "','" + textBoxDonGia.Text + "','" + comboBoxLDD.SelectedValue + "','" + comboBoxNSX.SelectedValue + "','" + comboBoxCL.SelectedValue + "')";
            fnc.actionData(sql);
            string sqlDD = "select * from DoDung";
            fnc.loadData(dataGridViewDD, sqlDD);
            clearDD();
        }

        private void dataGridViewDD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridViewDD.CurrentRow.Index;
            textBoxMaDD.Text = dataGridViewDD.Rows[index].Cells[0].Value.ToString();
            textBoxTenDD.Text = dataGridViewDD.Rows[index].Cells[1].Value.ToString();
            numericUpDownSL.Text = dataGridViewDD.Rows[index].Cells[2].Value.ToString();
            textBoxDonGia.Text = dataGridViewDD.Rows[index].Cells[3].Value.ToString();
            comboBoxLDD.SelectedIndex = comboBoxLDD.FindString(dataGridViewDD.Rows[index].Cells[4].Value.ToString());
            comboBoxNSX.SelectedIndex = comboBoxNSX.FindString(dataGridViewDD.Rows[index].Cells[4].Value.ToString());
            comboBoxCL.SelectedIndex = comboBoxCL.FindString(dataGridViewDD.Rows[index].Cells[4].Value.ToString());
            textBoxMaDD.Enabled = false;
            buttonEditDD.Enabled = true;
            buttonDeleDD.Enabled = true;
            buttonAddDD.Enabled = false;
        }

        private void buttonEditDD_Click(object sender, EventArgs e)
        {
            string sql = "update DoDung set tenDD = N'" + textBoxTenDD.Text + "',soLuong = '" + numericUpDownSL.Value + "',donGia = '" + textBoxDonGia.Text + "',idLS = '" + comboBoxLDD.SelectedValue + "',idNSX = '" + comboBoxNSX.SelectedValue + "',idCL = '" + comboBoxCL.SelectedValue + "' where idDD ='" + textBoxMaDD.Text + "'";
            fnc.actionData(sql);
            string sqlDD = "select * from DoDung";
            fnc.loadData(dataGridViewDD, sqlDD);
            textBoxMaDD.Enabled = true;
            buttonEditDD.Enabled = false;
            buttonDeleDD.Enabled = false;
            buttonAddDD.Enabled = true;
            clearDD();
        }

        private void buttonDeleDD_Click(object sender, EventArgs e)
        {
            string sql = "delete from DoDung where idDD ='" + textBoxMaDD.Text + "'";
            fnc.actionData(sql);
            string sqlDD = "select * from DoDung";
            fnc.loadData(dataGridViewDD, sqlDD);
            textBoxMaDD.Enabled = true;
            buttonEditDD.Enabled = false;
            buttonDeleDD.Enabled = false;
            buttonAddDD.Enabled = true;
            clearDD();
        }
        private void clearDD()
        {
            textBoxMaDD.Text = fnc.ReturnUniqueValue();
            textBoxTenDD.Text = "";
            numericUpDownSL.Value = 0;
            textBoxDonGia.Text = "";
        }

        // Khách hàng
        private void buttonAddKH_Click(object sender, EventArgs e)
        {
            string sql = "insert into KhachHang values('" + textBoxMaKH.Text + "',N'" + textBoxTenKH.Text + "',N'" + textBoxDiaChi.Text + "', '" + textBoxSDT.Text + "')";
            fnc.actionData(sql);
            string sqlKH = "select * from KhachHang";
            fnc.loadData(dataGridViewKhachHang, sqlKH);
            clearKH();

        }

        private void buttonEditKH_Click(object sender, EventArgs e)
        {
            string sql = "update KhachHang set tenKH = N'" + textBoxTenKH.Text + "',diaChi = N'" + textBoxDiaChi.Text + "', sdt = '" + textBoxSDT.Text + "' where idKH = '" + textBoxMaKH.Text + "'";
            fnc.actionData(sql);
            string sqlKH = "select * from KhachHang";
            fnc.loadData(dataGridViewKhachHang, sqlKH);
            textBoxMaKH.Enabled = true;
            buttonDeleKH.Enabled = false;
            buttonEditKH.Enabled = false;
            buttonAddKH.Enabled = true;
            clearKH();
        }

        private void dataGridViewKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridViewKhachHang.CurrentRow.Index;
            textBoxMaKH.Text = dataGridViewKhachHang.Rows[index].Cells[0].Value.ToString();
            textBoxTenKH.Text = dataGridViewKhachHang.Rows[index].Cells[1].Value.ToString();
            textBoxDiaChi.Text = dataGridViewKhachHang.Rows[index].Cells[2].Value.ToString();
            textBoxSDT.Text = dataGridViewKhachHang.Rows[index].Cells[3].Value.ToString();
            textBoxMaKH.Enabled = false;
            buttonDeleKH.Enabled = true;
            buttonEditKH.Enabled = true;
            buttonAddKH.Enabled = false;

        }

        private void buttonDeleKH_Click(object sender, EventArgs e)
        {
            string sql = "delete from KhachHang where idKH = '" + textBoxMaKH.Text + "'";
            fnc.actionData(sql);
            string sqlKH = "select * from KhachHang";
            fnc.loadData(dataGridViewKhachHang, sqlKH);
            textBoxMaKH.Enabled = true;
            buttonDeleKH.Enabled = false;
            buttonEditKH.Enabled = false;
            buttonAddKH.Enabled = true;
            clearKH();

        }
        private void clearKH()
        {
            textBoxMaKH.Text = fnc.ReturnUniqueValue();
            textBoxTenKH.Text = "";
            textBoxDiaChi.Text = "";
            textBoxSDT.Text = "";
        }

        // Thanh Toán
        private void comboBoxKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select * from KhachHang where idKH='" + comboBoxKH.SelectedValue + "'";
            SqlDataReader reader = fnc.getData(sql);
            while(reader.Read())
            {
                textBoxHDTenKH.Text = reader.GetValue(1).ToString();
                textBoxDCKH.Text = reader.GetValue(2).ToString();
                textBoxSDTKH.Text = reader.GetValue(3).ToString();
            }
        }

        private void buttonLocNSX_Click(object sender, EventArgs e)
        {
            comboBoxDD.Text = "";
            string sql = "select * from DoDung where idNSX = '" + comboBoxHDNSX.SelectedValue + "'";
            fnc.loadcombo(comboBoxDD,sql,"tenDD","idDD");
        }

        private void buttonLocLDD_Click(object sender, EventArgs e)
        {
            comboBoxDD.Text = "";
            string sql = "select * from DoDung where idLDD = '" + comboBoxHDLDD.SelectedValue + "'";
            fnc.loadcombo(comboBoxDD, sql, "tenDD", "idDD");
        }

        private void buttonLocCL_Click(object sender, EventArgs e)
        {
            comboBoxDD.Text = "";
            string sql = "select * from DoDung where idCL = '" + comboBoxHDCL.SelectedValue + "'";
            fnc.loadcombo(comboBoxDD, sql, "tenDD", "idDD");
        }

        private void buttonLocAll_Click(object sender, EventArgs e)
        {
            comboBoxDD.Text = "";
            string sql = "select * from DoDung where idCL = '" + comboBoxHDCL.SelectedValue + "' and idLDD = '" + comboBoxHDLDD.SelectedValue + "' and idNSX = '" + comboBoxHDNSX.SelectedValue + "'";
            fnc.loadcombo(comboBoxDD, sql, "tenDD", "idDD");
        }

        private void comboBoxDD_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select soLuong,donGia from DoDung where idDD='" + comboBoxDD.SelectedValue + "'";
            SqlDataReader reader = fnc.getData(sql);
            while (reader.Read())
            {
                numericUpDownHDSL.Maximum = Convert.ToInt32(reader.GetValue(0).ToString());
                textBoxDG.Text = reader.GetValue(1).ToString();
            }
        }

        private void buttonAddCart_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(comboBoxDD.SelectedText.ToString());
            foreach (DataGridViewRow row in dataGridViewCart.Rows)
            { 
                if(comboBoxDD.SelectedValue == row.Cells["idDD"].Value)
                {
                    row.Cells["soLuong"].Value = numericUpDownHDSL.Value;
                   MessageBox.Show(dataGridViewCart.EndEdit().ToString());
                    return;
                }
            }
            dataGridViewCart.Rows.Add(comboBoxDD.SelectedValue, comboBoxDD.Text , numericUpDownHDSL.Value, textBoxDG.Text);
        }

        int total = 0;

        private void dataGridViewCart_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach(DataGridViewRow row in dataGridViewCart.Rows)
            {
                total += Convert.ToInt32(row.Cells["soLuong"].Value) * Convert.ToInt32(row.Cells["dg"].Value);
            }
            textBoxTT.Text = total.ToString();
        }

        private void buttonTT_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn thanh toán ?", "Thanh Toán", MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes)
            {
                return;
            }
            string sql = "insert into HoaDon values('" + textBoxMaHD.Text + "','" + comboBoxKH.SelectedValue + "','" + DateTime.Today.Date + "','" + textBoxTT.Text + "')";
            fnc.actionData(sql);
            foreach (DataGridViewRow row in dataGridViewCart.Rows)
            {
                string sqlInsert = "insert into HD_DD values('" + textBoxMaHD.Text + "','" + row.Cells["idDD"].Value.ToString() + "','" + row.Cells["soLuong"].Value + "')";
                fnc.actionData(sqlInsert);
            }
            dataGridViewCart.Rows.Clear();
            clearTT();
        }
        private void clearTT()
        {
            textBoxMaHD.Text = "";
            textBoxHDTenKH.Text = "";
            textBoxSDTKH.Text = "";
            textBoxDCKH.Text = "";
            textBoxTT.Text = "";
        }

        private void buttonThongKe_Click(object sender, EventArgs e)
        {
            string sql;
            if(radioButtonNSX.Checked)
            {
                sql = "select TK.idNSX, NhaSanXuat.tenNSX, TK.total_sl from (select NhaSanXuat.idNSX,sum(HD_DD.soLuong) as total_sl from HD_DD, DoDung, NhaSanXuat where HD_DD.idDD = DoDung.idDD and DoDung.idNSX = NhaSanXuat.idNSX group by NhaSanXuat.idNSX) as TK inner join NhaSanXuat on NhaSanXuat.idNSX = TK.idNSX order by TK.total_sl DESC;";
                fnc.loadData(dataGridViewTK, sql);
            }
            if(radioButtonLDD.Checked)
            {
                sql = "select TK.idLDD, LoaiDoDung.tenLDD, TK.total_sl from (select LoaiDoDung.idLDD,sum(HD_DD.soLuong) as total_sl from HD_DD, DoDung, LoaiDoDung where HD_DD.idDD = DoDung.idDD and DoDung.idLDD = LoaiDoDung.idLDD group by LoaiDoDung.idLDD) as TK inner join LoaiDoDung on LoaiDoDung.idLDD = TK.idLDD order by TK.total_sl DESC;";
                fnc.loadData(dataGridViewTK, sql);
            }
            if(radioButtonDD.Checked)
            {
                sql = "select TK.idDD,DoDung.tenDD,TK.total_sl from (select DoDung.idDD, sum(HD_DD.soLuong) as total_sl from HD_DD, DoDung where HD_DD.idDD = DoDung.idDD group by DoDung.idDD) as TK inner join DoDung on TK.idDD = DoDung.idDD order by TK.total_sl desc;";
                fnc.loadData(dataGridViewTK, sql);
            }
            if(radioButtonKH.Checked)
            {
                sql = "select TK.idKH,KhachHang.tenKH,TK.total_sl from (select KhachHang.idKH, sum(HD_DD.soLuong) as total_sl from HD_DD, KhachHang, HoaDon where HD_DD.idHD = HoaDon.idHD and HoaDon.idKH = KhachHang.idKH group by KhachHang.idKH) as TK inner join KhachHang on TK.idKH = KhachHang.idKH order by TK.total_sl desc;";
                fnc.loadData(dataGridViewTK, sql);
            }
        }
    }
}
