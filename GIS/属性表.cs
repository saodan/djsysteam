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
    public partial class 属性表 : Form
    {
        Dataset dataset = null;
        public 属性表(Dataset dataset)
        {
            this.dataset = dataset;
            InitializeComponent();
        }

        private void 属性表_Load(object sender, EventArgs e)
        {
            DatasetVector vector = dataset as DatasetVector;
            this.Text = vector.Name;
            Recordset recordset = vector.GetRecordset(false, CursorType.Dynamic);
            this.skinDataGridView1.Columns.Clear();
            this.skinDataGridView1.Rows.Clear();

            for (int i = 0; i < recordset.FieldCount; i++)
            {
                String fieldName = recordset.GetFieldInfos()[i].Name;
                this.skinDataGridView1.Columns.Add(fieldName, fieldName);
            }
            DataGridViewRow row = null;
            row = new DataGridViewRow();
            bool tt = true;
            while (!recordset.IsEOF)
            {
                tt = true;
                row = new DataGridViewRow();
                if (this.skinDataGridView1.Rows[0].Cells["SmID"].Value!=null)
                {
                    for (int j = 0; j < this.skinDataGridView1.Rows.Count; j++)
                    {
                        if (this.skinDataGridView1.Rows[j].Cells["SmID"].Value != null)
                            if (this.skinDataGridView1.Rows[j].Cells["SmID"].Value.ToString() == recordset.GetFieldValue("SmID").ToString())
                            {
                                tt = false;
                                break;
                            }
                    }
                }                
                for (int i = 0; i < recordset.FieldCount; i++)
                {
                    if (tt == false)
                        break;
                    Object fieldValue = recordset.GetFieldValue(i);
                    DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                    if (fieldValue != null)
                    {
                        cell.ValueType = fieldValue.GetType();
                        cell.Value = fieldValue;
                    }

                    row.Cells.Add(cell);
                }
                if(tt==true)
                    this.skinDataGridView1.Rows.Add(row);             
                recordset.MoveNext();
            }
            this.skinDataGridView1.Update();

            recordset.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ToExcel(this.skinDataGridView1);
        }
        public void ToExcel(DataGridView dataGridView1)
        {
            try
            {
                //没有数据的话就不往下执行  
                if (dataGridView1.Rows.Count == 0)
                    return;
                //实例化一个Excel.Application对象  
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

                //让后台执行设置为不可见，为true的话会看到打开一个Excel，然后数据在往里写  
                excel.Visible = true;

                //新增加一个工作簿，Workbook是直接保存，不会弹出保存对话框，加上Application会弹出保存对话框，值为false会报错  
                excel.Application.Workbooks.Add(true);
                //生成Excel中列头名称  
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    if (dataGridView1.Columns[i].Visible == true)
                    {
                        excel.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
                    }

                }
                //把DataGridView当前页的数据保存在Excel中  
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    System.Windows.Forms.Application.DoEvents();
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        if (this.skinDataGridView1.Columns[j].Visible == true)
                        {
                            if (dataGridView1[j, i].ValueType == typeof(string))
                            {
                                excel.Cells[i + 2, j + 1] = "'" + dataGridView1[j, i].Value.ToString();
                            }
                            else
                            {
                                excel.Cells[i + 2, j + 1] = dataGridView1[j, i].Value.ToString();
                            }
                        }

                    }
                }

                //设置禁止弹出保存和覆盖的询问提示框  
                excel.DisplayAlerts = false;
                excel.AlertBeforeOverwriting = false;

                //保存工作簿  
                excel.Application.Workbooks.Add(true).Save();
                //保存excel文件  
                excel.Save("D:" + "\\KKHMD.xls");

                //确保Excel进程关闭  
                excel.Quit();
                excel = null;
                GC.Collect();//如果不使用这条语句会导致excel进程无法正常退出，使用后正常退出
                MessageBox.Show(this, "文件已经成功导出！", "信息提示");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示");
            }

        }
    }
}
