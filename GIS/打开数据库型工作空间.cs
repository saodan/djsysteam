using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SuperMap.Data;
using SuperMap.Mapping;
using SuperMap.UI;


namespace GIS
{
    public partial class 打开数据库型工作空间 : Form
    {
        public WorkspaceConnectionInfo Workspace1 = new WorkspaceConnectionInfo();
        public 打开数据库型工作空间()
        { 
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Workspace1.Server = textBox1.Text;
            Workspace1.Database = textBox6.Text;
            Workspace1.User = textBox5.Text;
            Workspace1.Password = textBox4.Text;
            Workspace1.Name = textBox3.Text;
            Workspace1.Type = WorkspaceType.SQL;
            Workspace1.Driver = "SQL Server";
            this.Hide();
        }
        public WorkspaceConnectionInfo con()
        {
            return this.Workspace1;
        }
        public string name()
        {
            return textBox3.Text;
        }

        private void 打开数据库型工作空间_Load(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
