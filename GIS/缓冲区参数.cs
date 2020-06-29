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

namespace GIS
{
    public partial class 缓冲区参数 : Form
    {
        Map map = new Map();
        public 缓冲区参数(Map map)
        {
            this.map = map;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public string name()
        {
            return textBox2.Text;
        }
        public double JL()
        {
            return double.Parse(textBox1.Text);
        }

        private void 缓冲区参数_Load(object sender, EventArgs e)
        {

        }
        public SpatialQueryMode Qtype()
        {
            return Type(comboBox3.Text);
        }
        private SpatialQueryMode Type(string name)
        {
            switch (name)
            {
                case "包含查询":
                    return SpatialQueryMode.Contain;
                case "相交查询":
                    return SpatialQueryMode.Intersect;
                case "分离查询":
                    return SpatialQueryMode.Disjoint;
                default:
                    return SpatialQueryMode.Contain;
            }
        }
    }
}
