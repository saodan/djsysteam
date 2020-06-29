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
    public partial class 修改界址点 : Form
    {
        Recordset recordset = null;
        public 修改界址点(Recordset recordset)
        {
            this.recordset = recordset;
            InitializeComponent();
        }

        private void 修改界址点_Load(object sender, EventArgs e)
        {
            label4.Text = recordset.GetFieldValue("X").ToString();
            label5.Text = recordset.GetFieldValue("Y").ToString();
            textBox1.Text = recordset.GetFieldValue("界址点号").ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (recordset.SetFieldValue("界址点号", textBox1.Text.ToString()))
                    MessageBox.Show("修改成功");
                recordset.Update();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
