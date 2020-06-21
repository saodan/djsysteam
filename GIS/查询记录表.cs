using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SuperMap.Data;

namespace GIS
{
    public partial class 查询记录表 : Form
    {
        Recordset recordset = null;
        public 查询记录表(Recordset recordset)
        {
            this.recordset = recordset;
            InitializeComponent();
        }

        private void 查询记录表_Load(object sender, EventArgs e)
        {
            this.skinDataGridView1.Columns.Clear();
            this.skinDataGridView1.Rows.Clear();
            this.Text = recordset.Dataset.Name;
            for (int i = 0; i < recordset.FieldCount; i++)
            {
                String fieldName = recordset.GetFieldInfos()[i].Name;
                this.skinDataGridView1.Columns.Add(fieldName, fieldName);
            }
            DataGridViewRow row = null;
            while (!recordset.IsEOF)
            {
                row = new DataGridViewRow();
                for (int i = 0; i < recordset.FieldCount; i++)
                {
                    Object fieldValue = recordset.GetFieldValue(i);
                    DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                    if (fieldValue != null)
                    {
                        cell.ValueType = fieldValue.GetType();
                        cell.Value = fieldValue;
                    }

                    row.Cells.Add(cell);
                }

                this.skinDataGridView1.Rows.Add(row);

                recordset.MoveNext();
            }
            this.skinDataGridView1.Update();

        }

        private void skinDataGridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Execl files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "导出到Excel";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName == "")
            {
                return;
            }
            Stream myStream = saveFileDialog.OpenFile();
            StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));
            string str = "";
            try
            {
                for (int i = 0; i < skinDataGridView1.ColumnCount; i++)
                {
                    if (skinDataGridView1.Columns[i].Visible == false || skinDataGridView1.Columns[i].DataPropertyName == "")
                    {
                        continue;
                    }
                    str += skinDataGridView1.Columns[i].HeaderText;
                    str += "\t";
                }
                sw.WriteLine(str);
                for (int j = 0; j < skinDataGridView1.Rows.Count - 1; j++)
                {
                    string strTemp = "";
                    for (int k = 0; k < skinDataGridView1.Columns.Count; k++)
                    {
                        if (skinDataGridView1.Columns[k].Visible == false || skinDataGridView1.Columns[k].DataPropertyName == "")
                        {
                            continue;
                        }
                        object obj = skinDataGridView1.Rows[j].Cells[k].Value;
                        if (obj != null)
                        {
                            strTemp += skinDataGridView1.Rows[j].Cells[k].Value.ToString();
                        }
                        else
                        {
                            strTemp = "";
                        }
                        strTemp += "\t";
                    }
                    sw.WriteLine(strTemp);
                }
                sw.Close();
                myStream.Close();
                MessageBox.Show("成功导出到Excel文件：\n" + saveFileDialog.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sw.Close();
                myStream.Close();
            }
        }
    }
}
