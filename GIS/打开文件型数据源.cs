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
    public partial class 打开文件型数据源 : Form
    {
        DatasourceConnectionInfo ConnectionInfo = new DatasourceConnectionInfo();
        public 打开文件型数据源()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text== "ImagePlus引擎")
            {
                OpenFileDialog fileDlg = new OpenFileDialog();
                fileDlg.Filter = "支持的影像文件(*.tif,*.sit,*.bmp,*.png,*.sct,*.tga,*.raw)|*.tif;*.sit;*.bmp;*.png;*.sct;*.tga;*.raw";
                if (fileDlg.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = fileDlg.FileName;
                }
            }
            else if(comboBox1.Text == "UDB引擎")
            {
                OpenFileDialog fileDlg = new OpenFileDialog();
                fileDlg.Filter = "UDB数据文件(*.udb)|*.udb";
                if (fileDlg.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = fileDlg.FileName;
                }
            }
            else if(comboBox1.Text == "UDBX引擎")
            {
                OpenFileDialog fileDlg = new OpenFileDialog();
                fileDlg.Filter = "UDBX数据文件(*.udbx)|*.udbx";
                if (fileDlg.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = fileDlg.FileName;
                }
            }
            else
            {
                MessageBox.Show("请选择引擎类型");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "ImagePlus引擎")
            {
                ConnectionInfo.EngineType = EngineType.ImagePlugins;
                ConnectionInfo.Alias = System.IO.Path.GetFileNameWithoutExtension(textBox1.Text);
                ConnectionInfo.Server = textBox1.Text;
                this.Hide();
            }
            else if (comboBox1.Text == "UDB引擎")
            {
                ConnectionInfo.EngineType = EngineType.UDB;
                ConnectionInfo.Alias = ConnectionInfo.Alias = System.IO.Path.GetFileNameWithoutExtension(textBox1.Text);
                ConnectionInfo.Server = textBox1.Text;
                this.Hide();
            }
            else if (comboBox1.Text == "UDBX引擎")
            {
                ConnectionInfo.EngineType = EngineType.UDBX;

                ConnectionInfo.Alias = System.IO.Path.GetFileNameWithoutExtension(textBox1.Text);
                ConnectionInfo.Server = textBox1.Text;
                this.Hide();
            }
            else
            {
                MessageBox.Show("请选择引擎类型");
            }
        }
        public DatasourceConnectionInfo con()
        {
            return ConnectionInfo;
        }
    }
}
