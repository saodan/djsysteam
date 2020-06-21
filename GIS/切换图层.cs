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
    public partial class 切换图层 : Form
    {
        Map map = new Map();
        public 切换图层(Map map)
        {
            this.map = map;
            InitializeComponent();
        }

        private void 切换图层_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            for (int i = 0; i < map.Layers.Count; i++)
            {
                comboBox1.Items.Add(map.Layers[i].Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public string name()
        {
            return comboBox1.Text;
        }
    }
}
