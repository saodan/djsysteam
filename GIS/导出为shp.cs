﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SuperMap.Data.Conversion;
using SuperMap.Data;

namespace GIS
{
    public partial class 导出为shp : Form
    {
        ExportSetting export = new ExportSetting();
        Dataset dataset = null;
        public 导出为shp(Dataset dataset)
        {
            this.dataset = dataset;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            export.SourceData = dataset;
            export.TargetFilePath = textBox1.Text + @"\"+ textBox2.Text;
            export.TargetFileType = FileType.SHP;
            if (comboBox1.Text == "否")
            {
                export.IsOverwrite = false;
            }
            else
            {
                export.IsOverwrite = true;
            }
            this.Hide();
        }
        public ExportSetting con()
        {
            return export;
        }
        public string name()
        {
            return textBox1.Text;
        }
    }
}
