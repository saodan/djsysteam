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
    public partial class 基本属性 : Form
    {
        Recordset recordset;
        public 基本属性(Recordset recordset)
        {
            this.recordset = recordset;
            InitializeComponent();
        }
        bool tt = false;
        private void button1_Click(object sender, EventArgs e)
        {
            try {
                if (xzqh.Text.Length > 0)
                {
                    if(xzqh.Text.Length!=6)
                    {
                        MessageBox.Show("行政区划必须为六位");
                        return;
                    }
                    object value = getvalue(recordset.GetFieldInfos()[label_xzqh.Text.Remove(label_xzqh.Text.Length-1)].Type, xzqh.Text);
                    recordset.SetFieldValue(label_xzqh.Text.Remove(label_xzqh.Text.Length - 1), value);
                }
                else
                {
                    MessageBox.Show(label_xzqh.Text.Remove(label_xzqh.Text.Length - 1) + " 不能为空");
                    return;
                }

                if (jd.Text.Length > 0)
                {
                    if (jd.Text.Length != 3)
                    {
                        MessageBox.Show("街道号必须为3位");
                        return;
                    }
                    object value = getvalue(recordset.GetFieldInfos()[label_jd.Text.Remove(label_jd.Text.Length - 1)].Type, jd.Text);
                    recordset.SetFieldValue(label_jd.Text.Remove(label_jd.Text.Length - 1), value);
                }
                else
                {
                    MessageBox.Show(label_jd.Text.Remove(label_jd.Text.Length - 1) + "不能为空");
                    return;
                }
                if (jf.Text.Length > 0)
                {
                    if (jf.Text.Length != 2)
                    {
                        MessageBox.Show("街坊必须为2位");
                        return;
                    }
                    object value = getvalue(recordset.GetFieldInfos()[label_jf.Text.Remove(label_jf.Text.Length - 1)].Type, jf.Text);
                    recordset.SetFieldValue(label_jf.Text.Remove(label_jf.Text.Length - 1), value);
                }
                else
                {
                    MessageBox.Show(label_jf.Text.Remove(label_jf.Text.Length - 1) + " 不能为空");
                    return;
                }

                if (zdh.Text.Length > 0) {
                    object value = getvalue(recordset.GetFieldInfos()[zdh_l.Text.Remove(zdh_l.Text.Length-1)].Type, jd.Text+jf.Text+zdh.Text);
                    recordset.SetFieldValue(zdh_l.Text.Remove(zdh_l.Text.Length-1), value);
                }
                else
                {
                    MessageBox.Show(zdh_l.Text.Remove(zdh_l.Text.Length - 1) + " 不能为空");
                    return;
                }
                if (tdlylb.Text.Length > 0)
                {
                    object value = getvalue(recordset.GetFieldInfos()[label_tdlylb.Text.Remove(label_tdlylb.Text.Length - 1)].Type, tdlylb.Text);
                    recordset.SetFieldValue(label_tdlylb.Text.Remove(label_tdlylb.Text.Length - 1), value);
                }
                else
                {
                    MessageBox.Show(label_tdlylb.Text.Remove(label_tdlylb.Text.Length - 1) + " 不认为空");
                    return;
                }
                if (qlr.Text.Length > 0)
                {
                    object value = getvalue(recordset.GetFieldInfos()[label_qlr.Text.Remove(label_qlr.Text.Length - 1)].Type, qlr.Text);
                    recordset.SetFieldValue(label_qlr.Text.Remove(label_qlr.Text.Length - 1), value);
                }
                else
                {
                    MessageBox.Show(qlr.Text.Remove(qlr.Text.Length - 1) + " 不能为空");
                    return;
                }
                if (recordset.Update())
                    MessageBox.Show("添加宗地成功");
                tt = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private object getvalue(FieldType fieldType, string value)
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
            if (tt == false)
                recordset.Delete();
            this.Hide();
        }

        private void 基本属性_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tt == false)
                recordset.Delete();
        }
    }
}
