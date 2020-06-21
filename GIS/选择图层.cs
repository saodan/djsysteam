using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SuperMap.Mapping;

namespace GIS
{
    public partial class 选择图层 : Form
    {
        Map map = new Map();
        public 选择图层(Map map)
        {
            this.map = map;
            InitializeComponent();
        }

        private void 选择图层_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Clear();
            for (int i = 0; i < map.Layers.Count; i++)
            {
                comboBox1.Items.Add(map.Layers[i].Name);
                comboBox2.Items.Add(map.Layers[i].Name);
            }
        }
        public string namelayer1()
        {
            return comboBox1.Text;
        }
        public string namelayer2()
        {
            return comboBox2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
