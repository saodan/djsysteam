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
    public partial class 字段管理 : Form
    {
        DatasetVector dataset = null;
        public 字段管理(DatasetVector dataset)
        {
            this.dataset = dataset;
            InitializeComponent();
        }
        TreeNode treeNode;
        private void 字段管理_Load(object sender, EventArgs e)
        {
            GX();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FieldInfo field = new FieldInfo();
                field.IsRequired = getbool();
                if (getbool())
                {
                    field.DefaultValue = "0";
                }
                field.Type = GetField(comboBox1.Text);
                field.Name = textBox1.Text;
                field.Caption = textBox2.Text;
                int index = dataset.FieldInfos.Add(field);
                treeNode.Nodes.Add(dataset.FieldInfos[index].Caption);
                comboBox3.Items.Add(dataset.FieldInfos[index].Caption);
                comboBox4.Items.Add(dataset.FieldInfos[index].Caption);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private FieldType GetField(string type)
        {
            switch (type)
            {
                case "16位整型":
                    return FieldType.Int16;
                case "32位整型":
                    return FieldType.Int32;
                case "64位整型":
                    return FieldType.Int64;
                case "单精度":
                    return FieldType.Single;
                case "双精度":
                    return FieldType.Double;
                case "文本型":
                    return FieldType.Text;
                case "宽字符":
                    return FieldType.WText;
                case "字符型":
                    return FieldType.Char;
                case "字节":
                    return FieldType.Byte;
                case "日期":
                    return FieldType.DateTime;
                case "布尔":
                    return FieldType.Boolean;
                case "二进制":
                    return FieldType.LongBinary;
                case "未知类型":
                    return FieldType.Double;
                default:
                    return FieldType.Double;

            }
        }
        private bool getbool()
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

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if ((control as GroupBox) != null)
                {
                    foreach (Control tempcontrol in control.Controls)
                    {
                        if (tempcontrol is TextBox)
                        {
                            //清掉含有TexBox控件上的内容
                            tempcontrol.Text = "";
                        }
                        else if (tempcontrol is ComboBox)
                        {
                            tempcontrol.Text = "";
                        }
                    }
                }
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FieldInfo field1 = null;
            foreach (FieldInfo field in dataset.FieldInfos)
            {
                if (field.Caption == comboBox3.Text)
                {
                    field1 = field;
                    break;
                }
            }
            DialogResult result = MessageBox.Show("是否删除" + comboBox3.Text + "字段，删除后无法撤回", "提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (dataset.FieldInfos.Remove(field1.Name))
                {
                    MessageBox.Show("删除成功");
                    GX();
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FieldInfo field1=null;
            foreach(FieldInfo field in dataset.FieldInfos)
            {
                if (field.Caption == comboBox4.Text)
                {
                    field1 = field;
                    break;
                }
            }
            string str = textBox5.Text;
            dataset.FieldInfos[field1.Name].Caption = str;
            GX();
        }
        private void GX()
        {
            comboBox4.Items.Clear();
            comboBox3.Items.Clear();
            treeView1.Nodes.Clear();
            treeNode = treeView1.Nodes.Add("字段名称");
            FieldInfos fieldInfos = dataset.FieldInfos;
            foreach (FieldInfo f in fieldInfos)
            {
                treeNode.Nodes.Add(f.Caption);
                comboBox3.Items.Add(f.Caption);
                comboBox4.Items.Add(f.Caption);
            }
            treeView1.ExpandAll();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
