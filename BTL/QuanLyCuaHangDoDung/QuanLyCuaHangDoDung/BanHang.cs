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
    public partial class BanHang : Form
    {
        Functions fnc = new Functions();
        public BanHang()
        {
            InitializeComponent();
        }

        private void BanHang_Load(object sender, EventArgs e)
        {
            string sqlLoaiDD = "select * from LoaiDoDung";
            string sqlNSX = "select * from NhaSanXuat";
            string sqlCL = "select * from ChatLieu";
            string sqlKH = "select * from KhachHang";
            // Hóa Đơn
            textBoxMaHD.Text = fnc.ReturnUniqueValue();
            fnc.loadcombo(comboBoxHDLDD, sqlLoaiDD, "tenLDD", "idLDD");

            fnc.loadcombo(comboBoxHDNSX, sqlNSX, "tenNSX", "idNSX");

            fnc.loadcombo(comboBoxHDCL, sqlCL, "tenCL", "idCL");

            fnc.loadcombo(comboBoxKH, sqlKH, "tenKH", "idKH");
        }
        // Thanh Toán
        private void comboBoxKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select * from KhachHang where idKH='" + comboBoxKH.SelectedValue + "'";
            SqlDataReader reader = fnc.getData(sql);
            while (reader.Read())
            {
                textBoxHDTenKH.Text = reader.GetValue(1).ToString();
                textBoxDCKH.Text = reader.GetValue(2).ToString();
                textBoxSDTKH.Text = reader.GetValue(3).ToString();
            }
        }
        private void comboBoxDD_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select soLuong,donGia from DoDung where idDD='" + comboBoxDD.SelectedValue + "'";
            SqlDataReader reader = fnc.getData(sql);
            while (reader.Read())
            {
                //MessageBox.Show(reader.GetValue(0).ToString());
                numericUpDownHDSL.Maximum = Convert.ToInt32(reader.GetValue(0).ToString());
                textBoxDG.Text = reader.GetValue(1).ToString();
            }
        }
        private void buttonLocNSX_Click(object sender, EventArgs e)
        {
            comboBoxDD.Text = "";
            string sql = "select * from DoDung where idNSX = '" + comboBoxHDNSX.SelectedValue + "'";
            fnc.loadcombo(comboBoxDD, sql, "tenDD", "idDD");
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

        private void buttonAddCart_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(comboBoxDD.SelectedText.ToString());
            foreach (DataGridViewRow row in dataGridViewCart.Rows)
            {
                if (comboBoxDD.SelectedValue == row.Cells["idDD"].Value)
                {
                    row.Cells["soLuong"].Value = numericUpDownHDSL.Value;
                    return;
                }
            }
            dataGridViewCart.Rows.Add(comboBoxDD.SelectedValue, comboBoxDD.Text, numericUpDownHDSL.Value, textBoxDG.Text);
        }


        private void dataGridViewCart_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int total = 0;
            foreach (DataGridViewRow row in dataGridViewCart.Rows)
            {
                total += Convert.ToInt32(row.Cells["soLuong"].Value) * Convert.ToInt32(row.Cells["dg"].Value);
            }
            textBoxTT.Text = total.ToString();
        }

        private void buttonTT_Click(object sender, EventArgs e)
        {
            if (textBoxHDTenKH.Text == "")
            {
                MessageBox.Show("Bạn phải chọn khách hàng !!!");
                return;
            }
            if (dataGridViewCart.Rows.Count == 0)
            {
                MessageBox.Show("Phải có ít nhất một đồ dùng trong giỏ hàng !!!");
                return;
            }
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
                string sqlUp = "update DoDung set soLuong= soLuong -'"+ row.Cells["soLuong"].Value + "' where idDD ='"+row.Cells["idDD"].Value.ToString() +"'";
                fnc.actionData(sqlUp);
                fnc.actionData(sqlInsert);
            }
            dataGridViewCart.Rows.Clear();
            clearTT();
        }

        private void buttonDeleCart_Click(object sender, EventArgs e)
        {
            int index = dataGridViewCart.CurrentRow.Index;
            dataGridViewCart.Rows.Remove(dataGridViewCart.Rows[index]);
        }
        private void clearTT()
        {
            textBoxMaHD.Text = fnc.ReturnUniqueValue();
            textBoxHDTenKH.Text = "";
            textBoxSDTKH.Text = "";
            textBoxDCKH.Text = "";
            textBoxTT.Text = "";
        }
        private void dataGridViewCart_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            int total = 0;
            foreach (DataGridViewRow row in dataGridViewCart.Rows)
            {
                total += Convert.ToInt32(row.Cells["soLuong"].Value) * Convert.ToInt32(row.Cells["dg"].Value);
            }
            textBoxTT.Text = total.ToString();
        }

        private void dataGridViewCart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int total = 0;
            foreach (DataGridViewRow row in dataGridViewCart.Rows)
            {
                total += Convert.ToInt32(row.Cells["soLuong"].Value) * Convert.ToInt32(row.Cells["dg"].Value);
            }
            textBoxTT.Text = total.ToString();
        }
    }
}
