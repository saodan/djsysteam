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
    public partial class 新建数据集 : Form
    {
        DatasetVectorInfo VectorInfo = new DatasetVectorInfo();
        public 新建数据集()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "请选择数据集类型")
            {
                VectorInfo.Name = textBox1.Text;
                VectorInfo.Type = GetDatasetType(comboBox1.Text);
                this.Hide();
            }
            else
            {
                MessageBox.Show("请选择数据集类型");
            }
        }
        public DatasetVectorInfo con()
        {
            return VectorInfo;
        }
        public bool isMap()
        {
            if (comboBox2.Text == "是")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private DatasetType GetDatasetType(String typeName)
        {
            DatasetType result = DatasetType.Point;
            try
            {

                switch (typeName)
                {
                    case "点数据集":
                        result = DatasetType.Point;
                        break;
                    case "线数据集":
                        result = DatasetType.Line;
                        break;
                    case "面数据集":
                        result = DatasetType.Region;
                        break;
                    default:
                        result = DatasetType.Line;
                        break;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
    }
}
