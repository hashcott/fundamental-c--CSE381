using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiaoDienMenu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Width = 680;
            this.Height = 480;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(backColor.ShowDialog() == DialogResult.OK) {
                this.BackColor = backColor.Color;
            }
        }

        private void backImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(backImage.ShowDialog() == DialogResult.OK)
            {
                Image myimage = new Bitmap(backImage.FileName);
                this.BackgroundImage = myimage;
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(fontDialog1.ShowDialog() == DialogResult.OK)
            {
                this.Font = fontDialog1.Font;
            }
        }
    }
}
