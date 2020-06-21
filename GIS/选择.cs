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
    public partial class 选择 : Form
    {
        List<string> list = new List<string>();
        public 选择(List<string> list)
        {
            this.list = list;
            InitializeComponent();
        }

        private void 选择_Load(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            TreeNode treeNode = treeView1.Nodes.Add("选择数据集");
            foreach (string str in list)
            {
                treeNode.Nodes.Add(str);
            }
            treeView1.ExpandAll();
        }
        bool t = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Text == "选择数据集")
            {
                MessageBox.Show("请不要选择根节点");
                return;
            }
            else
            {
                foreach (string str in list)
                {
                    if (treeView1.SelectedNode.Text == str)
                        t = true;
                }
            }
            if (t == false)
            {
                MessageBox.Show("请选择数据集");
                return;
            }
            this.Hide();
        }
        public string name()
        {
            return treeView1.SelectedNode.Text;
        }
    }
}
