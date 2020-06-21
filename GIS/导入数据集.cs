using System;
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
    public partial class 导入数据集 : Form
    {
        Datasource ConnectionInfo;
        ImportSetting import = new ImportSettingSHP();
        public 导入数据集(Datasource ConnectionInfo)
        {
            this.ConnectionInfo = ConnectionInfo;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arcgis（*.shp）|*.shp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "覆盖同名数据集")
            {
                import.ImportMode = ImportMode.Overwrite;
            }
            else if (comboBox1.Text == "追加")
            {
                import.ImportMode = ImportMode.Append;
            }
            else
            {
                import.ImportMode = ImportMode.None;
            }
            import.SourceFilePath = textBox1.Text;
            import.TargetDatasetName = textBox2.Text;
            import.TargetDatasource = ConnectionInfo;
            this.Hide();
        }
        public ImportSetting con()
        {
            return this.import;
        }
    }
}
