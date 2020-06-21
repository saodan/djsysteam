using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GIS
{
    public partial class 地图名 : Form
    {
        public 地图名()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public string name()
        {
            return textBox1.Text;
        }
    }
}
