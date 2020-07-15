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
    public partial class MainMaterial : Form
    {
        private Form activeForm = null;
        public MainMaterial()
        {
            InitializeComponent();
        }

        private void buttonTK_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ThongKe());
        }

        private void buttonBH_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BanHang());
        }

        private void buttonDM_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DanhMuc());
        }

        private void buttonTKHD_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SearchHD());
        }

        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
                activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                panelMain.Controls.Add(childForm);
                childForm.BringToFront();
                childForm.Show();
                this.Text = childForm.Text;  
        }

        private void MainMaterial_Load(object sender, EventArgs e)
        {
            OpenChildForm(new ThongKe());
        }
    }
}
