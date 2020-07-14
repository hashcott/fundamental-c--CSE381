using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace QuanLyNhanSu
{
    class Functions
    {
        public string ReturnUniqueValue()
        {
            //uuid
            Guid g = Guid.NewGuid();
            return g.ToString();
        }
        public SqlConnection connect()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
              "Data Source= DESKTOP-ND4LBNG\\SQLEXPRESS;" +
              "Initial Catalog=QuanLyNhanSu;" +
              "Integrated Security=SSPI;";
            try {
                conn.Open();
            } catch(Exception)
            {
                MessageBox.Show("Không thể kết nối");
            }
            return conn;
        }
        public void loadData(DataGridView dt, string sqlString)
        {
            SqlConnection cn = connect();
            SqlDataAdapter data = new SqlDataAdapter(sqlString,cn);
            DataTable tb = new DataTable();
            data.Fill(tb);
            dt.DataSource = tb;
            cn.Close();
        }
        public void actionData(string sqlEx)
        {
          
            SqlConnection cn = connect();
            SqlCommand data = new SqlCommand(sqlEx, cn);
            data.ExecuteNonQuery();
            cn.Close();
        }
        public void loadcombo(ComboBox cb, string sqlString, string display, string value)
        {
            SqlConnection cn = connect();
            SqlDataAdapter data = new SqlDataAdapter(sqlString, cn);
            DataTable tb = new DataTable();
            data.Fill(tb);
            cb.DataSource = tb;
            cb.DisplayMember = display;
            cb.ValueMember = value;
        }
    }
}
