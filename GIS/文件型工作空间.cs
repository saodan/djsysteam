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
    public partial class 文件型工作空间 : Form
    {
        WorkspaceConnectionInfo ConnectionInfo = new WorkspaceConnectionInfo();
        public 文件型工作空间()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folder = new FolderBrowserDialog();
                if (folder.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = folder.SelectedPath;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = comboBox1.Text.ToString();
            
            ConnectionInfo.Type = this.GetType(str);
            ConnectionInfo.Server = System.IO.Path.Combine(textBox1.Text ,textBox3.Text + "." + str);
            ConnectionInfo.Name = textBox3.Text;
            ConnectionInfo.Password = textBox2.Text;
            this.Hide();
        }
        public WorkspaceConnectionInfo con()
        {
            return this.ConnectionInfo;
        }
        public string name()
        {
            return textBox3.Text;
        }
        private WorkspaceType GetType(String type)
        {
            WorkspaceType result = WorkspaceType.Default;

            switch (type.ToUpper())
            {
                case "SMWU":
                    {
                        result = WorkspaceType.SMWU;
                    }
                    break;
                case "SXWU":
                    {
                        result = WorkspaceType.SXWU;
                    }
                    break;
                default:
                    break;
            }

            return result;
        }

        private void 文件型工作空间_Load(object sender, EventArgs e)
        {

        }
    }
}
