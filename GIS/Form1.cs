using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SuperMap.Data;
using SuperMap.Mapping;
using SuperMap.UI;
using SuperMap.Data.Conversion;
using SuperMap.Analyst.SpatialAnalyst;
using SuperMap.Data.Topology;

namespace GIS
{
    public partial class Form1 : CCWin.CCSkinMain
    {
        WorkspaceConnectionInfo connectionInfo;
        public Form1()
        {
            InitializeComponent();
            x = this.Width;
            y = this.Height;
            setTag(this);
        }
        private float x;//定义当前窗体的宽度
        private float y;//定义当前窗体的高度
        private void setTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ";" + con.Height + ";" + con.Left + ";" + con.Top + ";" + con.Font.Size;
                if (con.Controls.Count > 0)
                {
                    setTag(con);
                }
            }
        }
        private void setControls(float newx, float newy, Control cons)
        {
            try {
                foreach (Control con in cons.Controls)
                {
                    if (con.Tag != null)
                    {
                        string[] mytag = con.Tag.ToString().Split(new char[] { ';' });
                        con.Width = Convert.ToInt32(System.Convert.ToSingle(mytag[0]) * newx);
                        con.Height = Convert.ToInt32(System.Convert.ToSingle(mytag[1]) * newy);
                        con.Left = Convert.ToInt32(System.Convert.ToSingle(mytag[2]) * newx);
                        con.Top = Convert.ToInt32(System.Convert.ToSingle(mytag[3]) * newy);
                        Single currentSize = System.Convert.ToSingle(mytag[4]) * newy;
                        con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                        if (con.Controls.Count > 0)
                        {
                            setControls(newx, newy, con);
                        }
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            mapControl1.Map.Workspace = workspace1;
            this.skinDataGridView1.Hide();
            layersControl1.Map = mapControl1.Map;
            layersControl1.LayersTree.NodeContextMenuStrips[LayersTreeNodeDataType.Layer] = layer;
            workspaceControl1.WorkspaceTree.Workspace = new Workspace();
            workspaceControl1.WorkspaceTree.NodeContextMenuStrips[WorkspaceTreeNodeDataType.MapName] = map;
            workspaceControl1.WorkspaceTree.NodeContextMenuStrips[WorkspaceTreeNodeDataType.Workspace] = workspace;
            workspaceControl1.WorkspaceTree.NodeContextMenuStrips[WorkspaceTreeNodeDataType.Datasources] = datasources;
            workspaceControl1.WorkspaceTree.NodeContextMenuStrips[WorkspaceTreeNodeDataType.Datasource] = datasource;
            workspaceControl1.WorkspaceTree.NodeContextMenuStrips[WorkspaceTreeNodeDataType.DatasetVector] = dataset;
            workspaceControl1.WorkspaceTree.NodeContextMenuStrips[WorkspaceTreeNodeDataType.DatasetGrid] = tu;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            float newx = (this.Width) / x;
            float newy = (this.Height) / y;
            setControls(newx, newy, this);
        }
        Workspace workspace1 = new Workspace();
        private void 工作空间ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            mapControl1.Map.Close();
            workspace1.Close();
            workspace1.Dispose();

        }

        private void 文件型ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                mapControl1.Map.Close();
                workspace1.Close();
                打开文件型工作空间 open = new 打开文件型工作空间();
                open.ShowDialog();
                WorkspaceConnectionInfo connectionInfo = open.con();
                workspace1.Open(connectionInfo);
                mapControl1.Map.Workspace = workspace1;
                workspaceControl1.WorkspaceTree.Workspace = workspace1;
                layersControl1.Map = mapControl1.Map;
                if (workspace1.Maps.Count <= 0)
                {
                    MessageBox.Show("当前工作空间无地图");
                    return;
                }
                else
                {
                    mapControl1.Map.Open(workspace1.Maps[0]);
                    mapControl1.Map.Refresh();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void sQLSever工作空间ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                打开数据库型工作空间 open = new 打开数据库型工作空间();
                open.ShowDialog();
                WorkspaceConnectionInfo connectionInfo = open.con();
                mapControl1.Map.Close();
                workspace1.Close();
                if (workspace1.Open(connectionInfo))
                {
                    MessageBox.Show("成功打开数据库工作空间");
                }
                else
                {
                    MessageBox.Show("打开数据库工作空间失败");
                    return;
                }
                workspaceControl1.WorkspaceTree.Workspace = workspace1;
                workspaceControl1.Refresh();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (workspace1.Save())
            {
                MessageBox.Show("工作空间保存成功");
            }
        }

        private void sQL工作空间ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                打开数据库型工作空间 open = new 打开数据库型工作空间();
                open.ShowDialog();
                WorkspaceConnectionInfo connectionInfo = open.con();
                if (workspace1.Create(connectionInfo))
                {
                    DialogResult result = MessageBox.Show("工作空间创建成功,是否打开此工作空间", "提示", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        mapControl1.Map.Close();
                        workspace1.Close();
                        if (workspace1.Open(connectionInfo))
                        {
                            MessageBox.Show("成功打开数据库工作空间");
                        }
                        else
                        {
                            MessageBox.Show("打开数据库工作空间失败");
                            return;
                        }
                        workspaceControl1.WorkspaceTree.Workspace = workspace1;
                        workspaceControl1.Refresh();
                    }
                }
                else
                {
                    MessageBox.Show("创建失败");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 文件型工作空间ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                文件型工作空间 open = new 文件型工作空间();
                open.ShowDialog();
                WorkspaceConnectionInfo connectionInfo = open.con();
                if (workspace1.Create(connectionInfo))
                {
                    DialogResult result = MessageBox.Show("工作空间创建成功,是否打开此工作空间", "提示", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        mapControl1.Map.Close();
                        workspace1.Close();
                        if (workspace1.Open(connectionInfo))
                        {
                            MessageBox.Show("成功打开文件型工作空间");
                        }
                        else
                        {
                            MessageBox.Show("打开文件型工作空间失败");
                            return;
                        }
                        workspaceControl1.WorkspaceTree.Workspace = workspace1;
                        workspaceControl1.Refresh();
                    }
                }
                else
                {
                    MessageBox.Show("创建失败");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 文件型工作空间ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                文件型工作空间 open = new 文件型工作空间();
                open.ShowDialog();
                connectionInfo = open.con();
                string name = open.name();
                workspace1.Caption = name;
                workspace1.Save();
                if (workspace1.SaveAs(connectionInfo))
                {
                    MessageBox.Show("另存成功");
                }
                else
                {
                    MessageBox.Show("另存失败");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void sQLSever工作空间ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                打开数据库型工作空间 open = new 打开数据库型工作空间();
                open.ShowDialog();
                connectionInfo = open.con();
                string name = open.name();
                workspace1.Caption = name;
                workspace1.Save();
                if (workspace1.SaveAs(connectionInfo))
                {
                    MessageBox.Show("另存成功");
                }
                else
                {
                    MessageBox.Show("另存失败");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void 数据库型ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                打开数据库型数据源 open = new 打开数据库型数据源();
                open.ShowDialog();
                DatasourceConnectionInfo connectionInfo = open.con();
                Datasource datasources = workspace1.Datasources.Open(connectionInfo);
                if (datasources != null)
                {
                    MessageBox.Show("成功打开数据源");
                }
                else
                {
                    MessageBox.Show("打开数据源失败");
                    return;
                }
                workspaceControl1.WorkspaceTree.Workspace = workspace1;
                workspaceControl1.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 数据库型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                打开数据库型数据源 open = new 打开数据库型数据源();
                open.ShowDialog();
                DatasourceConnectionInfo connectionInfo = open.con();
                Datasource datasources = workspace1.Datasources.Create(connectionInfo);
                if (datasources != null)
                {
                    DialogResult result = MessageBox.Show("成功创建数据库型数据源，是否打开此数据源", "提示", MessageBoxButtons.YesNo);
                    if (DialogResult.Yes == result)
                    {
                        workspaceControl1.WorkspaceTree.Workspace = workspace1;
                        workspaceControl1.Refresh();
                    }
                }
                else
                {
                    MessageBox.Show("创建失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 文件型ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                打开文件型数据源 open = new 打开文件型数据源();
                open.ShowDialog();
                DatasourceConnectionInfo connectionInfo = open.con();
                Datasource datasources = workspace1.Datasources.Open(connectionInfo);
                if (datasources != null)
                {
                    MessageBox.Show("成功打开数据源");
                }
                else
                {
                    MessageBox.Show("打开数据源失败");
                    return;
                }
                workspaceControl1.WorkspaceTree.Workspace = workspace1;
                workspaceControl1.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 文件型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                新建文件型数据源 open = new 新建文件型数据源();
                open.ShowDialog();
                DatasourceConnectionInfo connectionInfo = open.con();
                Datasource datasources = workspace1.Datasources.Create(connectionInfo);
                if (datasources != null)
                {
                    DialogResult result = MessageBox.Show("成功创建文件型数据源，是否打开此数据源", "提示", MessageBoxButtons.YesNo);
                    if (DialogResult.Yes == result)
                    {
                        workspaceControl1.WorkspaceTree.Workspace = workspace1;
                        workspaceControl1.Refresh();
                    }

                }
                else
                {
                    MessageBox.Show("创建数据源失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 打开文件型工作空间ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                mapControl1.Map.Close();
                workspace1.Close();
                打开文件型工作空间 open = new 打开文件型工作空间();
                open.ShowDialog();
                WorkspaceConnectionInfo connectionInfo = open.con();
                workspace1.Open(connectionInfo);
                mapControl1.Map.Workspace = workspace1;
                workspaceControl1.WorkspaceTree.Workspace = workspace1;
                layersControl1.Map = mapControl1.Map;
                if (workspace1.Maps.Count <= 0)
                {
                    MessageBox.Show("当前工作空间无地图");
                    return;
                }
                else
                {
                    mapControl1.Map.Open(workspace1.Maps[0]);
                    mapControl1.Map.Refresh();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 打开数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                打开数据库型工作空间 open = new 打开数据库型工作空间();
                open.ShowDialog();
                WorkspaceConnectionInfo connectionInfo = open.con();
                mapControl1.Map.Close();
                workspace1.Close();
                if (workspace1.Open(connectionInfo))
                {
                    MessageBox.Show("成功打开数据库工作空间");
                }
                else
                {
                    MessageBox.Show("打开数据库工作空间失败");
                    return;
                }
                workspaceControl1.WorkspaceTree.Workspace = workspace1;
                workspaceControl1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 保存工作空间ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (workspace1.Save())
            {
                MessageBox.Show("工作空间保存成功");
            }
        }

        private void 另存工作空间ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 文件型工作空间ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                文件型工作空间 open = new 文件型工作空间();
                open.ShowDialog();
                connectionInfo = open.con();
                string name = open.name();
                workspace1.Caption = name;
                workspace1.Save();
                if (workspace1.SaveAs(connectionInfo))
                {
                    MessageBox.Show("另存成功");
                }
                else
                {
                    MessageBox.Show("另存失败");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 数据库型工作空间ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                打开数据库型工作空间 open = new 打开数据库型工作空间();
                open.ShowDialog();
                connectionInfo = open.con();
                string name = open.name();
                workspace1.Caption = name;
                workspace1.Save();
                if (workspace1.SaveAs(connectionInfo))
                {
                    MessageBox.Show("另存成功");
                }
                else
                {
                    MessageBox.Show("另存失败");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 关闭工作空间ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = workspaceControl1.WorkspaceTree.SelectedNode.Text;
            DialogResult result = MessageBox.Show("是否关闭\"" + name + "\"工作空间", "提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                mapControl1.Map.Close();
                workspace1.Close();
            }
        }

        private void 重命名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            重命名 open = new 重命名();
            open.ShowDialog();
            workspace1.Caption = open.name();
            WorkspaceConnectionInfo connectionInfo = workspace1.ConnectionInfo;
            workspace1.SaveAs(connectionInfo);
            workspaceControl1.Refresh();
        }

        private void 打开文件型数据源ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                打开文件型数据源 open = new 打开文件型数据源();
                open.ShowDialog();
                DatasourceConnectionInfo connectionInfo = open.con();
                Datasource datasources = workspace1.Datasources.Open(connectionInfo);
                if (datasources != null)
                {
                    MessageBox.Show("成功打开数据源");
                }
                else
                {
                    MessageBox.Show("打开数据源失败");
                    return;
                }
                workspaceControl1.WorkspaceTree.Workspace = workspace1;
                workspaceControl1.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 打开数据库型数据源ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                打开数据库型数据源 open = new 打开数据库型数据源();
                open.ShowDialog();
                DatasourceConnectionInfo connectionInfo = open.con();
                Datasource datasources = workspace1.Datasources.Open(connectionInfo);
                if (datasources != null)
                {
                    MessageBox.Show("成功打开数据源");
                }
                else
                {
                    MessageBox.Show("打开数据源失败");
                    return;
                }
                workspaceControl1.WorkspaceTree.Workspace = workspace1;
                workspaceControl1.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 新建文件型数据源ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                新建文件型数据源 open = new 新建文件型数据源();
                open.ShowDialog();
                DatasourceConnectionInfo connectionInfo = open.con();
                Datasource datasources = workspace1.Datasources.Create(connectionInfo);
                if (datasources != null)
                {
                    DialogResult result = MessageBox.Show("成功创建文件型数据源，是否打开此数据源", "提示", MessageBoxButtons.YesNo);
                    if (DialogResult.Yes == result)
                    {
                        workspaceControl1.WorkspaceTree.Workspace = workspace1;
                        workspaceControl1.Refresh();
                    }

                }
                else
                {
                    MessageBox.Show("创建数据源失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 新建数据库型数据源ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                打开数据库型数据源 open = new 打开数据库型数据源();
                open.ShowDialog();
                DatasourceConnectionInfo connectionInfo = open.con();
                Datasource datasources = workspace1.Datasources.Create(connectionInfo);
                if (datasources != null)
                {
                    DialogResult result = MessageBox.Show("成功创建数据库型数据源，是否打开此数据源", "提示", MessageBoxButtons.YesNo);
                    if (DialogResult.Yes == result)
                    {
                        workspaceControl1.WorkspaceTree.Workspace = workspace1;
                        workspaceControl1.Refresh();
                    }
                }
                else
                {
                    MessageBox.Show("创建失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 关闭数据源所有ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否关闭所有数据源", "提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string name = string.Empty;
                int j = workspace1.Datasources.Count;
                for (int i = 0; i < j; i++)
                {
                    name += string.Format("\"{0}\" ", workspace1.Datasources[0].Alias);
                    workspace1.Datasources.Close(0);
                }
                MessageBox.Show("数据源" + name + "已关闭");
                workspaceControl1.WorkspaceTree.Workspace = workspace1;
                workspaceControl1.WorkspaceTree.Refresh();
            }
        }

        private void 新建数据集ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                新建数据集 open = new 新建数据集();
                open.ShowDialog();
                DatasetVectorInfo vectorInfo = open.con();
                DatasetVector datasetVector = workspace1.Datasources[workspaceControl1.WorkspaceTree.SelectedNode.Text].Datasets.Create(vectorInfo);
                if (open.isMap())
                {
                    mapControl1.Map.Layers.Add(datasetVector, true);
                    mapControl1.Map.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 删除数据集ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> list = new List<string>();
                int i = workspace1.Datasources[workspaceControl1.WorkspaceTree.SelectedNode.Text].Datasets.Count;
                for (int j = 0; j < i; j++)
                {
                    list.Add(workspace1.Datasources[workspaceControl1.WorkspaceTree.SelectedNode.Text].Datasets[j].Name);
                }
                选择 open = new 选择(list);
                open.ShowDialog();
                string name = open.name();
                DialogResult result = MessageBox.Show("是否删除" + name + "数据集，" + "删除后无法撤回", "提示", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (workspace1.Datasources[workspaceControl1.WorkspaceTree.SelectedNode.Text].Datasets.Delete(name))
                    {
                        MessageBox.Show("成功删除" + name + "数据集");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 重命名ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                重命名 open = new 重命名();
                open.ShowDialog();
                workspace1.Datasources.ModifyAlias(workspaceControl1.WorkspaceTree.SelectedNode.Text, open.name());
                workspaceControl1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = workspaceControl1.WorkspaceTree.SelectedNode.Text;
            DialogResult result = MessageBox.Show("是否关闭数据源" + name, "提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                workspace1.Datasources[workspaceControl1.WorkspaceTree.SelectedNode.Text].Close();
                MessageBox.Show("数据源" + name + "已关闭");
                workspaceControl1.WorkspaceTree.Workspace = workspace1;
                workspaceControl1.WorkspaceTree.Refresh();
            }
        }

        private void 浏览属性表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DatasetVector datasets = workspace1.Datasources[workspaceControl1.WorkspaceTree.SelectedNode.Parent.Name].Datasets[workspaceControl1.WorkspaceTree.SelectedNode.Text] as DatasetVector;
                
                属性表 open = new 属性表(datasets.GetRecordset(false,CursorType.Dynamic));
                open.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 添加到地图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                mapControl1.Map.Layers.Add(workspace1.Datasources[workspaceControl1.WorkspaceTree.SelectedNode.Parent.Name].Datasets[workspaceControl1.WorkspaceTree.SelectedNode.Text], true);
                mapControl1.Map.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 重命名数据集ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                重命名 open = new 重命名();
                open.ShowDialog();
                workspace1.Datasources[workspaceControl1.WorkspaceTree.SelectedNode.Parent.Name].Datasets.Rename(workspaceControl1.WorkspaceTree.SelectedNode.Text, open.name());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void 删除数据集ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("确认删除数据源" + workspaceControl1.WorkspaceTree.SelectedNode.Parent.Name + "中的数据集" + workspaceControl1.WorkspaceTree.SelectedNode.Text + "，删除后无法撤销", "提示", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                    workspace1.Datasources[workspaceControl1.WorkspaceTree.SelectedNode.Parent.Name].Datasets.Delete(workspaceControl1.WorkspaceTree.SelectedNode.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 导出数据集ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                导出为shp open = new 导出为shp(workspace1.Datasources[workspaceControl1.WorkspaceTree.SelectedNode.Parent.Name].Datasets[workspaceControl1.WorkspaceTree.SelectedNode.Text]);
                open.ShowDialog();
                ExportSetting export = open.con();
                DataExport data = new DataExport();
                data.ExportSettings.Add(export);
                ExportResult result = data.Run();
                if (result.FailedSettings.Length == 0)
                {
                    MessageBox.Show("文件导出成功，导出到" + open.name());
                }
                else
                {
                    MessageBox.Show("文件导出失败");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 导入数据集ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                导入数据集 open = new 导入数据集(workspace1.Datasources[workspaceControl1.WorkspaceTree.SelectedNode.Text]);
                open.ShowDialog();
                ImportSetting import = open.con();
                DataImport dataImport = new DataImport();
                dataImport.ImportSettings.Add(import);
                ImportResult result = dataImport.Run();
                if (result.FailedSettings.Length == 0)
                {
                    MessageBox.Show("文件导入成功");
                }
                else
                {
                    MessageBox.Show("文件导入失败");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 字段管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                字段管理 open = new 字段管理(workspace1.Datasources[workspaceControl1.WorkspaceTree.SelectedNode.Parent.Name].Datasets[workspaceControl1.WorkspaceTree.SelectedNode.Text] as DatasetVector);
                open.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void mapControl1_GeometryAdded(object sender, GeometryEventArgs e)
        {
            DatasetVector vector = e.Layer.Dataset as DatasetVector;
            if (vector.Name.Contains("权属线"))
            {
                Recordset recordset = vector.GetRecordset(false, CursorType.Dynamic);
                recordset.MoveLast();
                recordset.Edit();
                基本属性 open = new 基本属性(recordset);
                open.ShowDialog();
            }
            if (vector.Name.Contains("界址点"))
            {
                Recordset recordset = vector.GetRecordset(false, CursorType.Dynamic);
                recordset.MoveLast();
                recordset.Edit();
                recordset.SetFieldValue("X", recordset.GetGeometry().InnerPoint.X);
                recordset.SetFieldValue("Y", recordset.GetGeometry().InnerPoint.Y);
                recordset.SetFieldValue("界址点号", recordset.GetFieldValue("SmID").ToString());
                recordset.Update();
            }
        }

        private void 矩形ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.CreateRectangle;
        }

        private void 圆角矩形ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.CreateRoundRectangle;
        }

        private void 平行四边形ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.CreateParallelogram;
        }

        private void 圆心圆ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.CreateCircle;
        }

        private void 椭圆ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.CreateEllipse;
        }

        private void 斜椭圆ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.CreateObliqueEllipse;
        }

        private void 多边形ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.CreatePolygon;
        }

        private void 平行线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.CreateParallel;
        }

        private void 三点圆ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.CreateCircle3P;
        }

        private void 三点圆弧ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.CreateArc3P;
        }

        private void 扇形ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.CreatePie;
        }

        private void 矩形ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.CreateRectangle;
        }

        private void 圆角矩形ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.CreateRoundRectangle;
        }

        private void 平行四边形ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.CreateParallelogram;
        }

        private void 圆心圆ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.CreateCircle;
        }

        private void 椭圆ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.CreateEllipse;
        }

        private void 斜椭圆ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.CreateObliqueEllipse;
        }

        private void 三点圆ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.CreateCircle3P;
        }

        private void 扇形ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.CreatePie;
        }

        private void 添加节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.VertexAdd;
        }

        private void 移动节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.VertexEdit;
        }

        private void 全图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapControl1.Map.ViewEntire();
            mapControl1.Map.Refresh();
        }

        private void 地图放大ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.ZoomIn;
        }

        private void 地图缩小ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.ZoomOut;
        }

        private void 地图漫游ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.Pan;
        }

        private void sQL查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string name = workspaceControl1.WorkspaceTree.SelectedNode.Parent.Name;
                DatasetVector vector = workspace1.Datasources[workspaceControl1.WorkspaceTree.SelectedNode.Parent.Name].Datasets[workspaceControl1.WorkspaceTree.SelectedNode.Text] as DatasetVector;
                mapControl1.Map.Layers.Clear();
                mapControl1.Map.Refresh();
                mapControl1.Map.Layers.Add(vector, true);
                mapControl1.Map.Refresh();
                SQL查询 open = new SQL查询(vector);
                open.ShowDialog();
                Recordset recordset = open.con();
                Selection selection = mapControl1.Map.Layers[vector.Name + "@" + name].Selection;
                selection.FromRecordset(recordset);
                mapControl1.Map.Refresh();
                recordset.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 属性查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int layerCount = mapControl1.Map.Layers.Count;
                if (layerCount == 0)
                {
                    MessageBox.Show("请先打开一个矢量数据集！");
                    return;
                }
                查询语句 open = new 查询语句();
                open.ShowDialog();
                if (open.con().Length == 0)
                {
                    MessageBox.Show("查询信息不能为空");
                    return;
                }
                QueryParameter queryParameter = new QueryParameter();
                queryParameter.AttributeFilter = open.con();
                queryParameter.CursorType = CursorType.Static;

                Boolean hasGeometry = false;
                foreach (Layer layer in mapControl1.Map.Layers)
                {
                    if (layer.Name == "权属线@数据源1")
                    {
                        DatasetVector dataset = layer.Dataset as DatasetVector;

                        if (dataset == null)
                        {
                            continue;
                        }
                        Recordset recordset = dataset.Query(queryParameter);
                        if (recordset.RecordCount > 0)
                        {
                            hasGeometry = true;
                        }
                        属性表 open1 = new 属性表(recordset);
                        open1.Show();
                        Selection selection = layer.Selection;

                        selection.FromRecordset(recordset); 
                    }
                }
                if (!hasGeometry)
                {
                    MessageBox.Show("没有符合查询条件的结果或查询条件有误，请重新确认后查询！");
                }
                queryParameter.Dispose();
                mapControl1.Refresh();
                hasGeometry = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 关闭属性表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.skinDataGridView1.Hide();
        }

        private void 点击选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.Select;
        }
        string NAME = null;
        private void 打开属性表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Layer layer in mapControl1.Map.Layers)
            {
                if (layer.IsSelectable)
                {
                    NAME = layer.Name;
                    break;
                }
            }
            Selection[] selection = mapControl1.Map.FindSelection(true);
            //判断选择集是否为空
            if (selection == null || selection.Length == 0)
            {
                MessageBox.Show("请选择要查询属性的空间对象");
                return;
            }
            this.skinDataGridView1.Show();
            //将选择集转换为记录
            Recordset recordset = selection[0].ToRecordset();

            this.skinDataGridView1.Columns.Clear();
            this.skinDataGridView1.Rows.Clear();

            for (int i = 0; i < recordset.FieldCount; i++)
            {
                if (recordset.GetFieldInfos()[i].Name.Contains("Sm"))
                    continue;
                //定义并获得字段名称
                String fieldName = recordset.GetFieldInfos()[i].Name;

                //将得到的字段名称添加到dataGridView列中
                this.skinDataGridView1.Columns.Add(fieldName, fieldName);
            }
            //初始化row
            DataGridViewRow row = null;
            //根据选中记录的个数，将选中对象的信息添加到dataGridView中显示
            while (!recordset.IsEOF)
            {
                row = new DataGridViewRow();
                for (int i = 0; i < recordset.FieldCount; i++)
                {
                    if (recordset.GetFieldInfos()[i].Name.Contains("Sm"))
                        continue;
                    //定义并获得字段值
                    Object fieldValue = recordset.GetFieldValue(i);

                    //将字段值添加到dataGridView中对应的位置
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
            recordset.Dispose();

        }
        Selection selection;
        string ID;
        Recordset recordset1;
        private void skinDataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                ID = skinDataGridView1.Rows[skinDataGridView1.CurrentCell.RowIndex].Cells["宗地号"].Value.ToString();
                DatasetVector vector = mapControl1.Map.Layers[NAME].Dataset as DatasetVector;
                QueryParameter query = new QueryParameter();
                query.CursorType = CursorType.Static;
                query.AttributeFilter = string.Format("宗地号=\'{0}\'", ID);
                recordset1 = vector.Query(query);
                selection = mapControl1.Map.Layers[NAME].Selection;
                selection.FromRecordset(recordset1);
                mapControl1.Map.ViewBounds = recordset1.Bounds;
                timer1.Enabled = true;
                mapControl1.Map.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void 自由选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.Select2;
        }

        private void 移除图层ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定移除" + layersControl1.LayersTree.SelectedNode.Text + "图层", "提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                mapControl1.Map.Layers.Remove(layersControl1.LayersTree.SelectedNode.Text);
                mapControl1.Map.Refresh();
            }
        }

        private void 选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void 切换选择图层ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                切换图层 open = new 切换图层(mapControl1.Map);
                open.ShowDialog();
                foreach (Layer layer in mapControl1.Map.Layers)
                {
                    if (layer.Name == open.name())
                    {
                        layer.IsSelectable = true;
                        mapControl1.Map.Refresh();
                    }
                    else
                    {
                        layer.IsSelectable = false;
                        mapControl1.Map.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 关闭属性表ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.skinDataGridView1.Hide();
        }
        private void 符号风格设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Resources resources = workspace1.Resources;
            DatasetType type = mapControl1.Map.Layers[layersControl1.LayersTree.SelectedNode.Text].Dataset.Type;
            if (type == DatasetType.Point)
            {
                //构造一个点几何风格对象
                GeoStyle geoStyle = new GeoStyle();
                geoStyle.LineColor = Color.Red;
                geoStyle.MarkerSymbolID = 0;

                // 打开点符号库管理器
                GeoStyle geoStyle1 = SymbolDialog.ShowDialog(resources, geoStyle, SymbolType.Marker);
                LayerSettingVector layer = new LayerSettingVector();
                layer.Style = geoStyle1;
                mapControl1.Map.Layers[layersControl1.LayersTree.SelectedNode.Text].AdditionalSetting = layer;
                mapControl1.Map.Refresh();
            }
            else if (type == DatasetType.Region)
            {
                //构造一个面几何风格对象
                GeoStyle geoStyle = new GeoStyle();
                geoStyle.LineColor = Color.Red;
                geoStyle.FillSymbolID = 2;
                geoStyle.FillForeColor = Color.YellowGreen;

                // 打开填充符号选择器
                GeoStyle geoStyle1 = SymbolDialog.ShowDialog(resources, geoStyle, SymbolType.Fill);
                LayerSettingVector layer = new LayerSettingVector();
                layer.Style = geoStyle1;
                mapControl1.Map.Layers[layersControl1.LayersTree.SelectedNode.Text].AdditionalSetting = layer;
                mapControl1.Map.Refresh();
            }
            else
            {
                //构造一个线几何风格对象
                GeoStyle geoStyle = new GeoStyle();
                geoStyle.LineColor = Color.Red;
                geoStyle.LineSymbolID = 25;

                // 打开线型符号选择器
                GeoStyle geoStyle1 = SymbolDialog.ShowDialog(resources, geoStyle, SymbolType.Line);
                LayerSettingVector layer = new LayerSettingVector();
                layer.Style = geoStyle1;
                mapControl1.Map.Layers[layersControl1.LayersTree.SelectedNode.Text].AdditionalSetting = layer;
                mapControl1.Map.Refresh();
            }

        }

        private void 保存为地图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                地图名 open = new 地图名();
                open.ShowDialog();
                string name = open.name();
                string xml = mapControl1.Map.ToXML();
                int k = workspace1.Maps.Add(name, xml);
                if (k > 0)
                {
                    MessageBox.Show("地图" + "\"" + name + "\"" + "保存成功");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 打开地图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapControl1.Map.Close();
            mapControl1.Map.Open(workspaceControl1.WorkspaceTree.SelectedNode.Text);
            mapControl1.Map.Refresh();
        }

        private void 删除地图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = workspaceControl1.WorkspaceTree.SelectedNode.Text;
            DialogResult result = MessageBox.Show("确认删除地图" + "\"" + name + "\"", "提示", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == result)
            {
                if (workspace1.Maps.Remove(name))
                {
                    MessageBox.Show("地图" + "\"" + name + "\"" + "删除成功");
                }
            }
        }
        Dictionary<double, double> ts = new Dictionary<double, double>();
        List<double> Xx = new List<double>();
        List<double> Yy = new List<double>();
        GeoStyle geoStyle_P = new GeoStyle();

        private void 退出程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mapControl1.Map.Layers.Count > 0)
            {
                DialogResult result1 = MessageBox.Show("是否将当前图层保存为地图", "提示", MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes)
                {
                    地图名 open = new 地图名();
                    open.ShowDialog();
                    string name = open.name();
                    string xml = mapControl1.Map.ToXML();
                    int k = workspace1.Maps.Add(name, xml);
                    if (k > 0)
                    {
                        MessageBox.Show("地图" + "\"" + name + "\"" + "保存成功");
                    }
                }
            }
            DialogResult result = MessageBox.Show("是否保存当前数据操作", "提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                workspace1.Save();
            }
            Application.Exit();
        }
        private void 宗地合并ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("宗地合并成功");
        }

        private void 删除界址点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Selection[] selection = mapControl1.Map.FindSelection(true);
            Recordset recordset = selection[0].ToRecordset();
            if (recordset.Dataset.Name != "界址点")
            {
                MessageBox.Show("请选择要删除的界址点要素");
                return;
            }
            recordset.Edit();
            DialogResult result = MessageBox.Show("确定删除要素", "提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                if (recordset.Delete())
                    MessageBox.Show("删除成功");
            mapControl1.Map.Refresh();
        }
        private void 自由选择ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.Select2;
        }

        private void 添加到地图ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                mapControl1.Map.Layers.Add(workspace1.Datasources[workspaceControl1.WorkspaceTree.SelectedNode.Parent.Name].Datasets[workspaceControl1.WorkspaceTree.SelectedNode.Text], true);
                mapControl1.Map.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 新增宗地ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mapControl1.Map.Layers["权属线@数据源1"].IsEditable != true)
            {

                MessageBox.Show("请打开权属线图层编辑状态");
                return;
            }
            MessageBox.Show("已打开权属线图层编辑状态");
        }

        private void 修改宗地ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 选择宗地ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请只选择一个宗地");
        }

        private void 修改属性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Selection[] selection = mapControl1.Map.FindSelection(true);
            if (selection == null || selection.Length != 1)
            {
                MessageBox.Show("请只选择一条记录");
                return;
            }
             
            Recordset recordset = selection[0].ToRecordset();
            recordset.Edit();
            属性 open = new 属性(recordset);
            open.ShowDialog();

        }

        private void 删除要素ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Selection[] selection = mapControl1.Map.FindSelection(true);
            Recordset recordset = selection[0].ToRecordset();
            recordset.Edit();
            DialogResult result = MessageBox.Show("确定删除要素", "提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                if (recordset.Delete())
                    MessageBox.Show("删除成功");
            mapControl1.Map.Refresh();
        }

        private void 打印地图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            打印地图 dy = new 打印地图(workspace1);
            dy.ShowDialog();
        }

        private void 点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.CreatePoint;
        }

        private void 折线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.CreatePolyline;
        }

        private void 保存地图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                地图名 open = new 地图名();
                open.ShowDialog();
                string name = open.name();
                string xml = mapControl1.Map.ToXML();
                int k = workspace1.Maps.Add(name, xml);
                if (k > 0)
                {
                    MessageBox.Show("地图" + "\"" + name + "\"" + "保存成功");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 添加注记ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.CreateText;
        }

        private void 添加节点ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.CreatePie;
        }

        private void 移动节点ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.VertexAdd;
        }

        private void 图层设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mapControl1.Map.Layers.Count < 1)
            {
                MessageBox.Show("请载入缓冲区分析图层");
                return;
            }

            选择图层 open1 = new 选择图层(mapControl1.Map);
            open1.ShowDialog();
            foreach (Layer layer in mapControl1.Map.Layers)
            {
                if (layer.Name == open1.namelayer1())
                {
                    layer.IsSelectable = true;
                    mapControl1.Map.Refresh();
                }
                else
                {
                    layer.IsSelectable = false;
                    mapControl1.Map.Refresh();
                }
            }
            MessageBox.Show("请选择缓冲区分析对象再点击\"缓冲区分析\"选项");
            namelayer1 = open1.namelayer1();
            namelayer2 = open1.namelayer2();
        }
        string namelayer1 = "初始";
        string namelayer2 = "初始";
        double jl;
        private void 缓冲区分析ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            try
            {
                if (namelayer1 == "初始" || namelayer2 == "初始")
                {
                    MessageBox.Show("请完成图层设置");
                    namelayer1 = "初始";
                    namelayer2 = "初始";
                    return;
                }

                缓冲区参数 open = new 缓冲区参数(mapControl1.Map);
                open.ShowDialog();

                Selection[] selections = mapControl1.Map.FindSelection(true);
                if (selections == null || selections.Length == 0)
                {
                    MessageBox.Show("请选择查询对象");
                    namelayer1 = "初始";
                    namelayer2 = "初始";
                    return;
                }
                Recordset re = selections[0].ToRecordset();
                DatasetVectorInfo datasetVectorInfo = new DatasetVectorInfo(open.name(), DatasetType.Region);
                string name = mapControl1.Map.Layers[namelayer1].Dataset.Datasource.Alias;
                DatasetVector vector = workspace1.Datasources[name].Datasets.Create(datasetVectorInfo);
                jl = open.JL();
                BufferAnalystForDataset3(re, vector);
                mapControl1.Map.Layers.Add(vector, true);
                mapControl1.Map.Refresh();
                QueryParameter parameter = new QueryParameter();
                parameter.SpatialQueryObject = vector;
                parameter.SpatialQueryMode = open.Qtype();
                Layer layer1 = mapControl1.Map.Layers[namelayer2];
                DatasetVector dataset = layer1.Dataset as DatasetVector;

                NAME = layer1.Name;
                Recordset recordset2 = dataset.Query(parameter);
                selection = layer1.Selection;
                selection.FromRecordset(recordset2);

                selection.Style.LineColor = Color.Red;
                selection.Style.LineWidth = 0.6;
                selection.SetStyleOptions(StyleOptions.FillSymbolID, true);
                selection.Style.FillSymbolID = 1;
                selection.IsDefaultStyleEnabled = false;
                mapControl1.Refresh();

                this.skinDataGridView1.Show();
                this.skinDataGridView1.Columns.Clear();
                this.skinDataGridView1.Rows.Clear();
                Recordset recordset = recordset2;

                this.skinDataGridView1.Columns.Clear();
                this.skinDataGridView1.Rows.Clear();

                for (int i = 0; i < recordset.FieldCount; i++)
                {
                    if (recordset.GetFieldInfos()[i].Name.Contains("Sm"))
                        continue;
                    //定义并获得字段名称
                    String fieldName = recordset.GetFieldInfos()[i].Name;

                    //将得到的字段名称添加到dataGridView列中
                    this.skinDataGridView1.Columns.Add(fieldName, fieldName);
                }
                //初始化row
                DataGridViewRow row = null;
                //根据选中记录的个数，将选中对象的信息添加到dataGridView中显示
                while (!recordset.IsEOF)
                {
                    row = new DataGridViewRow();
                    for (int i = 0; i < recordset.FieldCount; i++)
                    {
                        if (recordset.GetFieldInfos()[i].Name.Contains("Sm"))
                            continue;
                        //定义并获得字段值
                        Object fieldValue = recordset.GetFieldValue(i);

                        //将字段值添加到dataGridView中对应的位置
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
                recordset.Dispose();
                namelayer1 = "初始";
                namelayer2 = "初始";

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void BufferAnalystForDataset3(Recordset sourceDataset, DatasetVector resultDataset)
        {

            BufferAnalystParameter bufferAnalystParam = new BufferAnalystParameter();
            bufferAnalystParam.EndType = BufferEndType.Round;
            bufferAnalystParam.LeftDistance = jl;
            BufferAnalyst.CreateBuffer(sourceDataset, resultDataset, bufferAnalystParam, true, true);
        }

        private void 关闭属性表ToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            this.skinDataGridView1.Hide();
        }

        private void 界址点坐标修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Selection[] selection = mapControl1.Map.FindSelection(true);
            if (selection == null || selection.Length != 1)
            {
                MessageBox.Show("请只选择一条记录");
                return;
            }
            DatasetVector vector = selection[0].Dataset as DatasetVector;
            Recordset recordset = vector.GetRecordset(false, CursorType.Dynamic);
            recordset.MoveLast();
            recordset.Edit();
            修改界址点 open = new 修改界址点(recordset);
            open.ShowDialog();
        }

        private void 界址点新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.CreatePoint;
        }

        private void mapControl1_GeometrySelected(object sender, GeometrySelectedEventArgs e)
        {
            Selection[] selection = mapControl1.Map.FindSelection(true);
            Recordset recordset = selection[0].ToRecordset();
            if (recordset.Dataset.Name.Contains("19") && selection.Length == 1)
            {
                try
                {
                    MessageBox.Show("四川省"+recordset.GetFieldValue("CityNameC").ToString()
                        +"截止2020年6月24日，新型冠状病毒肺炎："+"\n"+"确诊人数："+recordset.GetFieldValue("QZ").ToString()
                        +"\n"+"死亡人数："+recordset.GetFieldValue("SW").ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
