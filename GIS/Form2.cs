using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GIS
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = null;
            SqlCommand comm = null;

            try
            {
                string ConStr = "server=(local);uid=sa;pwd=3279221;database=空间数据库";
                conn = new SqlConnection(ConStr);
                conn.Open();
                string sql = string.Format("select * from dbo.用户表 where name='{0}' and password='{1}'", user.Text, password.Text);
                comm = new SqlCommand(sql, conn);
                if (comm.ExecuteScalar() == null)
                {
                    MessageBox.Show("密码或用户名错误");
                    return;
                }
                else 
                {
                    Form1 form = new Form1();
                    form.ShowDialog();
                }
                this.Hide();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
