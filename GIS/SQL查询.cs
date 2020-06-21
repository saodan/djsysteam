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
    public partial class SQL查询 : Form
    {
        DatasetVector vector = null;
        public SQL查询(DatasetVector vector)
        {
            this.vector = vector;
            InitializeComponent();
        }

        private void SQL查询_Load(object sender, EventArgs e)
        {
            GX();
        }
        private void GX()
        {
            treeView1.Nodes.Clear();
            comboBox1.Items.Clear();
            TreeNode treeNode = treeView1.Nodes.Add("可选字段");
            foreach(FieldInfo info in vector.FieldInfos)
            {
                treeNode.Nodes.Add(info.Name);
                comboBox1.Items.Add(info.Name);
            }
            treeView1.ExpandAll();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                recordset = vector.GetRecordset(false, CursorType.Dynamic);
                comboBox2.Items.Clear();
                while (!recordset.IsEOF)
                {
                    if(recordset.GetFieldValue(comboBox1.Text)!=null)
                        comboBox2.Items.Add(recordset.GetFieldValue(comboBox1.Text));
                    recordset.MoveNext();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        Recordset recordset = null;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                QueryParameter query = new QueryParameter();
                query.AttributeFilter = textBox1.Text;
                query.CursorType = CursorType.Static;
                recordset = vector.Query(query);
                查询记录表 open = new 查询记录表(recordset);
                this.Hide();
                open.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public Recordset con()
        {
            return recordset;
        }
    }
}
