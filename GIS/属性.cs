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
    public partial class 属性 : Form
    {
        Recordset recordset;
        public 属性(Recordset recordset)
        {
            this.recordset = recordset;
            InitializeComponent();
        }

        private void 属性_Load(object sender, EventArgs e)
        {
            zdmj.Text = recordset.GetFieldValue("SmArea").ToString();
            jzmj.Text = recordset.GetFieldValue("SmArea").ToString();
            jzwzdmj.Text = recordset.GetFieldValue("SmArea").ToString();
            if(recordset.GetFieldValue("宗地号") != null)
                zdh.Text = recordset.GetFieldValue("宗地号").ToString();
            if (recordset.GetFieldValue("土地利用类别") != null)
                tdlylb.Text = recordset.GetFieldValue("土地利用类别").ToString();
            if (recordset.GetFieldValue("权利人") != null)
                qlr.Text = recordset.GetFieldValue("权利人").ToString();
            if (recordset.GetFieldValue("行政区划") != null)
                xzqh.Text = recordset.GetFieldValue("行政区划").ToString();
            if (recordset.GetFieldValue("法人代表") != null)
                frdb.Text = recordset.GetFieldValue("法人代表").ToString();
            if (recordset.GetFieldValue("身份证") != null)
                sfz1.Text = recordset.GetFieldValue("身份证").ToString();
            if (recordset.GetFieldValue("电话") != null)
                tel1.Text = recordset.GetFieldValue("电话").ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (zdh.Text.Length != 0)
                {
                    object value = getvalue(recordset.GetFieldInfos()[label_zdh.Text.Remove(label_zdh.Text.Length - 1)].Type, zdh.Text);
                    recordset.SetFieldValue(label_zdh.Text.Remove(label_zdh.Text.Length - 1), value);
                }
                if (tdlylb.Text.Length != 0)
                {
                    object value = getvalue(recordset.GetFieldInfos()[label_tdlylb.Text.Remove(label_tdlylb.Text.Length-1)].Type, tdlylb.Text);
                    recordset.SetFieldValue(label_tdlylb.Text.Remove(label_tdlylb.Text.Length-1), value);
                }
                if (qlr.Text.Length != 0)
                {
                    object value = getvalue(recordset.GetFieldInfos()[label_qlr.Text.Remove(label_qlr.Text.Length-1)].Type, qlr.Text);
                    recordset.SetFieldValue(label_qlr.Text.Remove(label_qlr.Text.Length-1), value);
                }
                if (xzqh.Text.Length != 0)
                {
                    object value = getvalue(recordset.GetFieldInfos()[label_qh.Text.Remove(label_qh.Text.Length-1)].Type, xzqh.Text);
                    recordset.SetFieldValue(label_qh.Text.Remove(label_qh.Text.Length-1), value);
                }
                if (frdb.Text.Length != 0)
                {
                    object value = getvalue(recordset.GetFieldInfos()[label_frdb.Text.Remove(label_frdb.Text.Length-1)].Type, frdb.Text);
                    recordset.SetFieldValue(label_frdb.Text.Remove(label_frdb.Text.Length-1), value);
                }
                if (sfz1.Text.Length != 0)
                {
                    object value = getvalue(recordset.GetFieldInfos()[label_sfz.Text.Remove(label_sfz.Text.Length-1)].Type, sfz1.Text);
                    recordset.SetFieldValue(label_sfz.Text.Remove(label_sfz.Text.Length-1), value);
                }
                if (tel1.Text.Length != 0)
                {
                    object value = getvalue(recordset.GetFieldInfos()[lable_tel.Text.Remove(lable_tel.Text.Length-1)].Type, tel1.Text);
                    recordset.SetFieldValue(lable_tel.Text.Remove(lable_tel.Text.Length-1), value);
                }
                MessageBox.Show("修改成功");
                recordset.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            } 
        }
        private object getvalue(FieldType fieldType,string value)
        {
            switch (fieldType)
            {
                case FieldType.Int16:
                    return Convert.ToInt16(value);
                case FieldType.Int32:
                    return Convert.ToInt32(value);
                case FieldType.Int64:
                    return Convert.ToInt64(value);
                case FieldType.Single:
                    return Convert.ToSingle(value);
                case FieldType.WText:
                    return Convert.ToString(value);
                default:
                    return Convert.ToString(value);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            recordset.Update();
        }

        private void 属性_FormClosing(object sender, FormClosingEventArgs e)
        {
            recordset.Update();
        }
    }
}
