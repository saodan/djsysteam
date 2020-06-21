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
    public partial class 新建文件型数据源 : Form
    {
        DatasourceConnectionInfo ConnectionInfo = new DatasourceConnectionInfo();
        public 新建文件型数据源()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "UDB引擎")
            {
                ConnectionInfo.EngineType = EngineType.UDB;
                ConnectionInfo.Alias = textBox2.Text;
                ConnectionInfo.Server = System.IO.Path.Combine(textBox1.Text + @"\" + textBox2.Text + "." + "udb");
                this.Hide();
            }
            else if (comboBox1.Text == "UDBX引擎")
            {
                ConnectionInfo.EngineType = EngineType.UDBX;
                ConnectionInfo.Alias = textBox2.Text;
                ConnectionInfo.Server = System.IO.Path.Combine(textBox1.Text + @"\" + textBox2.Text + "." + "udbx");
                this.Hide();
            }
            else
            {
                MessageBox.Show("请选择引擎类型");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folder.SelectedPath;
            }
        }
        public DatasourceConnectionInfo con()
        {
            return ConnectionInfo;
        }
    }
}
