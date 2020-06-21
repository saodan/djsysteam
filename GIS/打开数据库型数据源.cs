using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SuperMap.Data;

namespace GIS
{
    public partial class 打开数据库型数据源 : Form
    {
        DatasourceConnectionInfo Workspace1 = new DatasourceConnectionInfo();
        public 打开数据库型数据源()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Workspace1.EngineType = EngineType.SQLPlus;
            Workspace1.Server = textBox1.Text;
            Workspace1.Database = textBox6.Text;
            Workspace1.User = textBox5.Text;
            Workspace1.Password = textBox4.Text;
            Workspace1.Driver = "SQL Server";
            Workspace1.Alias = textBox6.Text;
            this.Hide();
        }
        public DatasourceConnectionInfo con()
        {
            return this.Workspace1;
        }
    }
}
