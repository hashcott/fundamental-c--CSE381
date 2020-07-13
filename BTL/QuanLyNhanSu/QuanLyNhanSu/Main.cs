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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

         private void customizeDesing()
        {
            panelDanhMucSubmenu.Visible = false;
        }

        private void hideSubMenu()
        {
            if(panelDanhMucSubmenu.Visible == true)
            {
                panelDanhMucSubmenu.Visible = false;
            }
        }
        private void showSubMenu(Panel submenu)
        {
            if(submenu.Visible == false)
            {
                hideSubMenu();
                submenu.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showSubMenu(panelDanhMucSubmenu);
        }

        private void buttonNhanSu_Click(object sender, EventArgs e)
        {
            openChildForm(new NhanSu());
            hideSubMenu();
        }

        private void buttonNghiepVu_Click(object sender, EventArgs e)
        {
            openChildForm(new NghiepVu());
            hideSubMenu();
        }

        private void buttonDuAn_Click(object sender, EventArgs e)
        {
            openChildForm(new CongTrinh());
            hideSubMenu();
        }

        private void buttonQLDuAn_Click(object sender, EventArgs e)
        {
            openChildForm(new QLCT());
            hideSubMenu();
        }

        private void buttonChamCong_Click(object sender, EventArgs e)
        {
            openChildForm(new ChamCong());
            hideSubMenu();
        }

        private Form activeForm = null;
        private void openChildForm (Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
    }
}
