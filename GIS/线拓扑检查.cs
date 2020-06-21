using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SuperMap.Data;
using SuperMap.Data.Topology;

namespace GIS
{
    public partial class 线拓扑检查 : Form
    {
        Workspace workspace1 = new Workspace();
        public 线拓扑检查(Workspace workspace1)
        {
            this.workspace1 = workspace1;
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void 选择线数据集_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox4.Items.Clear();
            comboBox7.Items.Clear();
            this.groupBox1.Enabled = false;
            foreach(Datasource datasource in workspace1.Datasources)
            {
                comboBox7.Items.Add(datasource.Alias);
                comboBox1.Items.Add(datasource.Alias);
                comboBox4.Items.Add(datasource.Alias);
            }
        }

        private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            if(comboBox3.Text== "线不能和面相交或被包含"||comboBox3.Text== "线与线无相交"|| comboBox3.Text== "线端点必须被点覆盖"||comboBox3.Text== "线与线无相交"||comboBox3.Text== "线与线无重叠"||comboBox3.Text== "线被多条线完全覆盖"||comboBox3.Text== "线被面边界覆盖"||comboBox3.Text== "线不能和面相交或被包含"||comboBox3.Text== "节点距离必须大于容限"||comboBox3.Text== "节点之间必须相互匹配"||comboBox3.Text== "线段相交处必须存在交点")
            {
                comboBox5.Items.Clear();
                this.groupBox1.Enabled = true;
            }
            else
            {
                comboBox5.Items.Clear();
                this.groupBox1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            foreach(Dataset dataset in workspace1.Datasources[comboBox1.Text].Datasets)
            {
                if(dataset.Type==DatasetType.Line)
                    comboBox2.Items.Add(dataset.Name);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox5.Items.Clear();
            if (comboBox3.Text.Contains("点"))
            {
                foreach(Dataset dataset in workspace1.Datasources[comboBox4.Text].Datasets)
                {
                    if (dataset.Type == DatasetType.Point)
                        comboBox5.Items.Add(dataset.Name);
                }
            }
            else if (comboBox3.Text.Contains("面"))
            {
                foreach (Dataset dataset in workspace1.Datasources[comboBox4.Text].Datasets)
                {
                    if (dataset.Type == DatasetType.Region)
                        comboBox5.Items.Add(dataset.Name);
                }
            }
            else
            {
                foreach (Dataset dataset in workspace1.Datasources[comboBox4.Text].Datasets)
                {
                    if (dataset.Type == DatasetType.Line)
                        comboBox5.Items.Add(dataset.Name);
                }
            }
        }
        private TopologyRule topologyRule(string type)
        {
            switch (type)
            {
                case "线内无相交":
                    return TopologyRule.LineNoIntersection;
                case "线内无重叠":
                    return TopologyRule.LineNoOverlap;
                case "线内无悬线":
                    return TopologyRule.LineNoDangles;
                case "线内无假结点":
                    return TopologyRule.LineNoPseudonodes;
                case "线与线无重叠":
                    return TopologyRule.LineNoOverlapWith;
                case "线内无相交或无内部接触":
                    return TopologyRule.LineNoIntersectOrInteriorTouch;
                case "线内无自交叠":
                    return TopologyRule.LineNoSelfOverlap;
                case "线内无自相交":
                    return TopologyRule.LineNoSelfIntersect;
                case "线被多条线完全覆盖":
                    return TopologyRule.LineBeCoveredByLineClass;
                case "线被面边界覆盖":
                    return TopologyRule.LineCoveredByRegionBoundary;
                case "线端点必须被点覆盖":
                    return TopologyRule.LineEndpointCoveredByPoint;
                case "线与线无相交":
                    return TopologyRule.LineNoIntersectionWith;
                case "线不能和面相交或被包含":
                    return TopologyRule.LineNoIntersectionWithRegion;
                case "无复杂对象":
                    return TopologyRule.NoMultipart;
                case "节点距离必须大于容限":
                    return TopologyRule.VertexDistanceGreaterThanTolerance;
                case "节点之间必须互相匹配":
                    return TopologyRule.VertexMatchWithEachOther;
                case "线段相交处必须存在交点":
                    return TopologyRule.LineExistIntersectVertex;
                case "线或面边界无冗余节点":
                    return TopologyRule.NoRedundantVertex;
                case "线内无打折":
                    return TopologyRule.LineNoSharpAngle;
                default:
                    return TopologyRule.LineNoIntersection;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public string dcdatasourceName()
        {
            return comboBox1.Text;
        }
        public string dcdatasetName()
        {
            return comboBox2.Text;
        }
        public string ckdatasourceName()
        {
            return comboBox4.Text;
        }
        public string ckdatasetName()
        {
            return comboBox5.Text;
        }
        public string jgdatasourceName()
        {
            return comboBox7.Text;
        }
        public double rx()
        {
            return double.Parse(textBox1.Text);
        }
        public TopologyRule rule()
        {
            return topologyRule(comboBox3.Text);
        }
        public string name()
        {
            return textBox2.Text;
        }

        public bool ck()
        {
            return this.groupBox1.Enabled;
        }
        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
