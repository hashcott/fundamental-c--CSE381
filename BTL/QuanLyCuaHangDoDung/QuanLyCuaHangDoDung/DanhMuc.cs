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
    public partial class DanhMuc : Form
    {
        Functions fnc = new Functions();
        public DanhMuc()
        {
            InitializeComponent();
        }

        private void DanhMuc_Load(object sender, EventArgs e)
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

          
            fnc.loadcombo(comboBoxLDD, sqlLDD, "tenLDD", "idLDD");

            fnc.loadcombo(comboBoxNSX, sqlNSX, "tenNSX", "idNSX");

            fnc.loadcombo(comboBoxCL, sqlCL, "tenCL", "idCL");

        }
        // Loại đồ dùng
        private void buttonAddLDD_Click(object sender, EventArgs e)
        {
            if(textBoxTenLDD.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên loại đồ dùng !!!");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn thêm "+ textBoxTenLDD.Text + " ?", "Thêm", MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes)
            {
                return;
            }
            string sql = "insert into LoaiDoDung values('" + textBoxMaLDD.Text + "',N'" + textBoxTenLDD.Text + "')";
            fnc.actionData(sql);
            string sqlLoaiDD = "select * from LoaiDoDung";
            fnc.loadData(dataGridViewLDD, sqlLoaiDD);
            fnc.loadcombo(comboBoxLDD, sqlLoaiDD, "tenLDD", "idLDD");
            clearLDD();
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
            if (textBoxTenLDD.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên loại đồ dùng !!!");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn sửa " + textBoxTenLDD.Text + " ?", "Sửa", MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes)
            {
                return;
            }
            string sql = "update LoaiDoDung set tenLDD = N'" + textBoxTenLDD.Text + "' where idLDD = '" + textBoxMaLDD.Text + "'";
            fnc.actionData(sql);
            string sqlLoaiDD = "select * from LoaiDoDung";
            fnc.loadData(dataGridViewLDD, sqlLoaiDD);
            fnc.loadcombo(comboBoxLDD, sqlLoaiDD, "tenLDD", "idLDD");
            textBoxMaLDD.Enabled = true;
            buttonEditLDD.Enabled = false;
            buttonDeleLDD.Enabled = false;
            buttonAddLDD.Enabled = true;
            clearLDD();
        }

        private void buttonDeleLDD_Click(object sender, EventArgs e)
        {
           
            DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn xóa " + textBoxTenLDD.Text + " ?", "Xóa", MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes)
            {
                return;
            }
            if (!fnc.checkDelete("select * from LoaiDoDung inner join DoDung on '"+textBoxMaLDD.Text+"' = DoDung.idLDD"))
            {
                MessageBox.Show("Bạn không thể xóa dữ liệu được liên kết với bảng khác !!!");
                return;
            }
            string sql = "delete from LoaiDoDung where idLDD = '" + textBoxMaLDD.Text + "'";
            fnc.actionData(sql);
            string sqlLoaiDD = "select * from LoaiDoDung";
            fnc.loadData(dataGridViewLDD, sqlLoaiDD);
            fnc.loadcombo(comboBoxLDD, sqlLoaiDD, "tenLDD", "idLDD");

            textBoxMaLDD.Enabled = true;
            buttonEditLDD.Enabled = false;
            buttonDeleLDD.Enabled = false;
            buttonAddLDD.Enabled = true;
            clearLDD();
            textBoxMaLDD.Enabled = true;
        }

        private void buttonCancelLDD_Click(object sender, EventArgs e)
        {
            buttonEditLDD.Enabled = false;
            buttonDeleLDD.Enabled = false;
            buttonAddLDD.Enabled = true;
            textBoxMaLDD.Text = fnc.ReturnUniqueValue();
            textBoxTenLDD.Text = "";
        }
        private void clearLDD()
        {
            textBoxMaLDD.Text = fnc.ReturnUniqueValue();
            textBoxTenLDD.Text = "";
        }
        // NSX
        private void buttonAddNSX_Click(object sender, EventArgs e)
        {
            if (textBoxTenNSX.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên nhà xuất bản !!!");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn sửa " + textBoxTenNSX.Text + " ?", "Thêm", MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes)
            {
                return;
            }
            string sql = "insert into NhaSanXuat values('" + textBoxMaNSX.Text + "',N'" + textBoxTenNSX.Text + "')";
            fnc.actionData(sql);
            string sqlNSX = "select * from NhaSanXuat";
            fnc.loadData(dataGridViewNSX, sqlNSX);
            fnc.loadcombo(comboBoxNSX, sqlNSX, "tenNSX", "idNSX");
            clearNSX();
        }

        private void buttonEditNSX_Click(object sender, EventArgs e)
        {
            if (textBoxTenNSX.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên nhà xuất bản !!!");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn sửa " + textBoxTenNSX.Text + " ?", "Sửa", MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes)
            {
                return;
            }
            string sql = "update NhaSanXuat set tenNSX = N'" + textBoxTenNSX.Text + "'where idNSX = '" + textBoxMaNSX.Text + "'";
            fnc.actionData(sql);
            string sqlNSX = "select * from NhaSanXuat";
            fnc.loadData(dataGridViewNSX, sqlNSX);
            fnc.loadcombo(comboBoxNSX, sqlNSX, "tenNSX", "idNSX");

            clearNSX();
            buttonAddNSX.Enabled = true;
            buttonEditNSX.Enabled = false;
            buttonDeleNSX.Enabled = false;
        }

        private void dataGridViewNSX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridViewNSX.CurrentRow.Index;
            textBoxMaNSX.Text = dataGridViewNSX.Rows[index].Cells[0].Value.ToString();
            textBoxTenNSX.Text = dataGridViewNSX.Rows[index].Cells[1].Value.ToString();
            buttonAddNSX.Enabled = false;
            buttonEditNSX.Enabled = true;
            buttonDeleNSX.Enabled = true;
        }

        private void buttonDeleNSX_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn xóa " + textBoxTenNSX.Text + " ?", "Xóa", MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes)
            {
                return;
            }
            if (!fnc.checkDelete("select * from NhaSanXuat inner join DoDung on '" + textBoxMaNSX.Text + "' = DoDung.idNSX"))
            {
                MessageBox.Show("Bạn không thể xóa dữ liệu được liên kết với bảng khác !!!");
                return;
            }
            string sql = "delete from NhaSanXuat where idNSX = '" + textBoxMaNSX.Text + "'";
            fnc.actionData(sql);
            string sqlNSX = "select * from NhaSanXuat";
            fnc.loadData(dataGridViewNSX, sqlNSX);
            fnc.loadcombo(comboBoxNSX, sqlNSX, "tenNSX", "idNSX");

            clearNSX();
            buttonAddNSX.Enabled = true;
            buttonEditNSX.Enabled = false;
            buttonDeleNSX.Enabled = false;
        }
        private void buttonCancelNSX_Click(object sender, EventArgs e)
        {
            clearNSX();
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
            if (textBoxTenCL.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên CHẤT LIỆU !!!");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn thêm " + textBoxTenCL.Text + " ?", "Thêm", MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes)
            {
                return;
            }
            string sql = "insert into ChatLieu values('" + textBoxMaCL.Text + "',N'" + textBoxTenCL.Text + "')";
            fnc.actionData(sql);
            string sqlCL = "select * from ChatLieu";
            fnc.loadData(dataGridViewCL, sqlCL);
            fnc.loadcombo(comboBoxCL, sqlCL, "tenCL", "idCL");

            clearCL();

        }

        private void buttonEditCL_Click(object sender, EventArgs e)
        {
            if (textBoxTenCL.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên CHẤT LIỆU !!!");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn sửa " + textBoxTenCL.Text + " ?", "Sửa", MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes)
            {
                return;
            }
            string sql = "update ChatLieu set tenCL = N'" + textBoxTenCL.Text + "' where idCL = '" + textBoxMaCL.Text + "'";
            fnc.actionData(sql);
            string sqlCL = "select * from ChatLieu";
            fnc.loadData(dataGridViewCL, sqlCL);
            fnc.loadcombo(comboBoxCL, sqlCL, "tenCL", "idCL");

            buttonAddCL.Enabled = true;
            buttonEditCL.Enabled = false;
            buttonDeleCL.Enabled = false;
            clearCL();
        }

        private void dataGridViewCL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridViewCL.CurrentRow.Index;
            textBoxMaCL.Text = dataGridViewCL.Rows[index].Cells[0].Value.ToString();
            textBoxTenCL.Text = dataGridViewCL.Rows[index].Cells[1].Value.ToString();
            buttonAddCL.Enabled = false;
            buttonEditCL.Enabled = true;
            buttonDeleCL.Enabled = true;
        }

        private void buttonDeleCL_Click(object sender, EventArgs e)
        {
        
            DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn xóa " + textBoxTenCL.Text + " ?", "Xóa", MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes)
            {
                return;
            }
            if(!fnc.checkDelete("select * from ChatLieu inner join DoDung on '" + textBoxMaCL.Text + "' = DoDung.idCL"))
            {
                MessageBox.Show("Bạn không thể xóa dữ liệu được liên kết với bảng khác !!!");
                return;
            }
            string sql = "delete from ChatLieu where idCL = '" + textBoxMaCL.Text + "'";
            fnc.actionData(sql);
            string sqlCL = "select * from ChatLieu";
            fnc.loadData(dataGridViewCL, sqlCL);
            fnc.loadcombo(comboBoxCL, sqlCL, "tenCL", "idCL");

            buttonAddCL.Enabled = true;
            buttonEditCL.Enabled = false;
            buttonDeleCL.Enabled = false;
            clearCL();
        }
        private void buttonCancelCL_Click(object sender, EventArgs e)
        {
            clearCL();
            buttonAddCL.Enabled = true;
            buttonEditCL.Enabled = false;
            buttonDeleCL.Enabled = false;
        }

        private void clearCL()
        {
            textBoxMaCL.Text = fnc.ReturnUniqueValue();
            textBoxTenCL.Text = "";
        }
        // Đồ Dùng
        private void buttonAddDD_Click(object sender, EventArgs e)
        {
            if (textBoxTenDD.Text == "")
            {
                MessageBox.Show("Bạn phải nhập TÊN CHẤT LIỆU !!!");
                return;
            }
            int Result;
            bool isSuccess = int.TryParse(textBoxDonGia.Text, out Result);
            if (isSuccess != true)
            {
                MessageBox.Show("Bạn phải nhập tên Đơn Gía BẰNG SỐ !!!");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn thêm " + textBoxTenDD.Text + " ?", "Thêm", MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes)
            {
                return;
            }
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
            comboBoxLDD.SelectedValue = dataGridViewDD.Rows[index].Cells[4].Value.ToString();
            comboBoxNSX.SelectedValue = dataGridViewDD.Rows[index].Cells[5].Value.ToString();
            comboBoxCL.SelectedValue = dataGridViewDD.Rows[index].Cells[6].Value.ToString();
            buttonEditDD.Enabled = true;
            buttonDeleDD.Enabled = true;
            buttonAddDD.Enabled = false;
        }

        private void buttonEditDD_Click(object sender, EventArgs e)
        {
            if (textBoxTenDD.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên CHẤT LIỆU !!!");
                return;
            }
            int Result;
            bool isSuccess = int.TryParse(textBoxDonGia.Text, out Result);
            if (isSuccess != true)
            {
                MessageBox.Show("Bạn phải nhập tên CHẤT LIỆU BẰNG SỐ !!!");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn sửa " + textBoxTenDD.Text + " ?", "Sửa", MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes)
            {
                return;
            }
            string sql = "update DoDung set tenDD = N'" + textBoxTenDD.Text + "',soLuong = '" + numericUpDownSL.Value + "',donGia = '" + textBoxDonGia.Text + "',idLDD = '" + comboBoxLDD.SelectedValue + "',idNSX = '" + comboBoxNSX.SelectedValue + "',idCL = '" + comboBoxCL.SelectedValue + "' where idDD ='" + textBoxMaDD.Text + "'";
            fnc.actionData(sql);
            string sqlDD = "select * from DoDung";
            fnc.loadData(dataGridViewDD, sqlDD);
            buttonEditDD.Enabled = false;
            buttonDeleDD.Enabled = false;
            buttonAddDD.Enabled = true;
            clearDD();
        }

        private void buttonDeleDD_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn xóa " + textBoxTenDD.Text + " ?", "Xoá", MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes)
            {
                return;
            }
            if (!fnc.checkDelete("select * from DoDung inner join HD_DD on HD_DD.idDD = '" + textBoxMaDD.Text + "'"))
            {
                MessageBox.Show("Bạn không thể xóa dữ liệu được liên kết với bảng khác !!!");
                return;
            }
            string sql = "delete from DoDung where idDD ='" + textBoxMaDD.Text + "'";
            fnc.actionData(sql);
            string sqlDD = "select * from DoDung";
            fnc.loadData(dataGridViewDD, sqlDD);
            buttonEditDD.Enabled = false;
            buttonDeleDD.Enabled = false;
            buttonAddDD.Enabled = true;
            clearDD();
        }
        private void buttonCancelDD_Click(object sender, EventArgs e)
        {
            clearDD();
            buttonEditDD.Enabled = false;
            buttonDeleDD.Enabled = false;
            buttonAddDD.Enabled = true;
        }
        private void clearDD()
        {
            textBoxMaDD.Text = fnc.ReturnUniqueValue();
            textBoxTenDD.Text = "";
            numericUpDownSL.Value = 1;
            textBoxDonGia.Text = "";
        }

        // Khách hàng
        private void buttonAddKH_Click(object sender, EventArgs e)
        {
            if (textBoxTenKH.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên khách hàng !!!");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn thêm " + textBoxTenKH.Text + " ?", "Thêm", MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes)
            {
                return;
            }
            string sql = "insert into KhachHang values('" + textBoxMaKH.Text + "',N'" + textBoxTenKH.Text + "',N'" + textBoxDiaChi.Text + "', '" + textBoxSDT.Text + "')";
            fnc.actionData(sql);
            string sqlKH = "select * from KhachHang";
            fnc.loadData(dataGridViewKhachHang, sqlKH);
            clearKH();

        }

        private void buttonEditKH_Click(object sender, EventArgs e)
        {
            if (textBoxTenKH.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên khách hàng !!!");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn sửa " + textBoxTenKH.Text + " ?", "Sửa", MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes)
            {
                return;
            }
            string sql = "update KhachHang set tenKH = N'" + textBoxTenKH.Text + "',diaChi = N'" + textBoxDiaChi.Text + "', sdt = '" + textBoxSDT.Text + "' where idKH = '" + textBoxMaKH.Text + "'";
            fnc.actionData(sql);
            string sqlKH = "select * from KhachHang";
            fnc.loadData(dataGridViewKhachHang, sqlKH);
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
            buttonDeleKH.Enabled = true;
            buttonEditKH.Enabled = true;
            buttonAddKH.Enabled = false;

        }

        private void buttonDeleKH_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn xóa " + textBoxTenKH.Text + " ?", "Xóa", MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes)
            {
                return;
            }
            if (!fnc.checkDelete("select * from KhachHang inner join HoaDon on HoaDon.idKH = '" + textBoxMaKH.Text + "'"))
            {
                MessageBox.Show("Bạn không thể xóa dữ liệu được liên kết với bảng khác !!!");
                return;
            }
            string sql = "delete from KhachHang where idKH = '" + textBoxMaKH.Text + "'";
            fnc.actionData(sql);
            string sqlKH = "select * from KhachHang";
            fnc.loadData(dataGridViewKhachHang, sqlKH);
            buttonDeleKH.Enabled = false;
            buttonEditKH.Enabled = false;
            buttonAddKH.Enabled = true;
            clearKH();

        }

        private void buttonCancelKH_Click(object sender, EventArgs e)
        {
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

       
    }
}
