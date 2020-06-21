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
using SuperMap.Layout;

namespace GIS
{
    public partial class 打印地图 : Form
    {
        Workspace workspace1 = new Workspace();
        public 打印地图(Workspace workspace1)
        {
            this.workspace1 = workspace1;
            InitializeComponent();
        }

        private void 打印地图_Load(object sender, EventArgs e)
        {
            mapLayoutControl1.MapLayout.Workspace = workspace1;
            InitializeLayout();
            mapLayoutControl1.TrackMode = TrackMode.Edit;
            mapLayoutControl1.MapLayout.Zoom(4);
            toolStripComboBox1.Items.Clear();
            foreach (String printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                toolStripComboBox1.Items.Add(printer);
            }
        }
        int m_mapID;
        private void InitializeLayout()
        {
            try
            {
                LayoutElements elements = mapLayoutControl1.MapLayout.Elements;
                // 构造GeoMap
                // Create the GeoMap object.
                GeoMap geoMap = new GeoMap();

                geoMap.MapName = "地籍图";
                    

                // 设置GeoMap对象的外切矩形
                // Set the exterior rectangle. 
                Rectangle2D rect = new Rectangle2D(new Point2D(850, 1300), new Size2D(
                        1500, 1500));
                GeoRectangle geoRect = new GeoRectangle(rect, 0);
                geoMap.Shape = geoRect;
                elements.AddNew(geoMap);
                m_mapID = elements.GetID();

                // 构造指北针
                // Initialize the GeoNorthArrow
                GeoNorthArrow northArrow = new GeoNorthArrow(
                                            NorthArrowStyleType.EightDirection,
                                            new Rectangle2D(new Point2D(1400, 2250), new Size2D(350, 350)),
                                            0);

                northArrow.BindingGeoMapID = m_mapID;

                elements.AddNew(northArrow);

                // 构造比例尺
                // Initialize the scale
                GeoMapScale scale = new GeoMapScale(m_mapID, new Point2D(125, 400), 50, 50);
                scale.LeftDivisionCount = 2;
                scale.ScaleUnit = Unit.Kilometer;
                scale.SegmentCount = 4;

                elements.AddNew(scale);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        int t = 0;
        public void LockMap(Boolean isLocked)
        {
            try
            {
                Int32 mapID = -1;
                if (isLocked)
                {
                    mapID = m_mapID;
                }

                mapLayoutControl1.ActiveGeoMapID = mapID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void toolStripButtonLockMap_Click(object sender, EventArgs e)
        {
            bool islock = toolStripButtonLockMap.CheckState == CheckState.Checked;
            LockMap(islock);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {           
            GeoText text = new GeoText();
            // 设置文本子对象的属性
            TextPart textPart = new TextPart();
            textPart.AnchorPoint = new Point2D(250, 500);
            textPart.Rotation = 30;
            textPart.Text = "城市地籍图";
            textPart.X = 250;
            textPart.Y = 500;
            textPart.Offset(10.0, 20.0);
            // 设置文本风格
            TextStyle textStyle = new TextStyle();
            textStyle.Shadow = true;
            textStyle.Alignment = TextAlignment.TopCenter;
            textStyle.FontName = "宋体";
            textStyle.FontHeight = 10.0;
            textStyle.FontWidth = 10.0;
            textStyle.Weight = 500;
            textStyle.BackColor = System.Drawing.Color.White;
            textStyle.ForeColor = System.Drawing.Color.Black;
            Geometry geometry  = new GeoText(textPart,textStyle);
            LayoutElements elements = mapLayoutControl1.MapLayout.Elements;
            elements.AddNew(geometry);
        }

        private void 打印地图_FormClosing(object sender, FormClosingEventArgs e)
        {
            mapLayoutControl1.Dispose();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                mapLayoutControl1.MapLayout.Printer.PrinterName = toolStripComboBox1.Text;
                mapLayoutControl1.MapLayout.Printer.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
