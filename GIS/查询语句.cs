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
    public partial class 查询语句 : Form
    {
        public 查询语句()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public string con()
        {
            return this.textBox1.Text;
        }
    }
}
