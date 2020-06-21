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
    public partial class 打开文件型工作空间 : Form
    {
        WorkspaceConnectionInfo ConnectionInfo = new WorkspaceConnectionInfo();
        public 打开文件型工作空间()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDig = new OpenFileDialog();
                openFileDig.Filter = "SXWU files (*.sxwu)|*.sxwu|SMWU files (*.smwu)|*.smwu";

                if (openFileDig.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = openFileDig.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConnectionInfo = new WorkspaceConnectionInfo(textBox1.Text);
            ConnectionInfo.Password = textBox2.Text;
            this.Hide();
        }
        public WorkspaceConnectionInfo con()
        {
            return this.ConnectionInfo;
        }

        private void 打开文件型工作空间_Load(object sender, EventArgs e)
        {

        }
    }
}
