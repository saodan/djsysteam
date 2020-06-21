namespace GIS
{
    partial class 打印地图
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(打印地图));
            this.mapLayoutControl1 = new SuperMap.UI.MapLayoutControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonLockMap = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapLayoutControl1
            // 
            this.mapLayoutControl1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mapLayoutControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mapLayoutControl1.IsCursorCustomized = false;
            this.mapLayoutControl1.IsGridSnapable = false;
            this.mapLayoutControl1.IsHorizontalScrollbarVisible = true;
            this.mapLayoutControl1.IsSnapEnabled = true;
            this.mapLayoutControl1.IsVerticalScrollbarVisible = true;
            this.mapLayoutControl1.IsWaitCursorEnabled = true;
            this.mapLayoutControl1.LayoutAction = SuperMap.UI.Action.Select2;
            this.mapLayoutControl1.Location = new System.Drawing.Point(12, 45);
            this.mapLayoutControl1.MapAction = SuperMap.UI.Action.Null;
            this.mapLayoutControl1.Name = "mapLayoutControl1";
            this.mapLayoutControl1.RefreshAtTracked = true;
            this.mapLayoutControl1.RefreshInInvalidArea = false;
            this.mapLayoutControl1.Size = new System.Drawing.Size(918, 692);
            this.mapLayoutControl1.TabIndex = 0;
            this.mapLayoutControl1.TrackMode = SuperMap.UI.TrackMode.Edit;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonLockMap,
            this.toolStripButton1,
            this.toolStripLabel1,
            this.toolStripComboBox1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(942, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonLockMap
            // 
            this.toolStripButtonLockMap.CheckOnClick = true;
            this.toolStripButtonLockMap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonLockMap.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLockMap.Image")));
            this.toolStripButtonLockMap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLockMap.Margin = new System.Windows.Forms.Padding(10, 1, 10, 2);
            this.toolStripButtonLockMap.Name = "toolStripButtonLockMap";
            this.toolStripButtonLockMap.Size = new System.Drawing.Size(60, 22);
            this.toolStripButtonLockMap.Text = "锁定地图";
            this.toolStripButtonLockMap.Click += new System.EventHandler(this.toolStripButtonLockMap_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(60, 22);
            this.toolStripButton1.Text = "添加标题";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(56, 22);
            this.toolStripLabel1.Text = "选择打印";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(60, 22);
            this.toolStripButton2.Text = "打印地图";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // 打印地图
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 749);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.mapLayoutControl1);
            this.Name = "打印地图";
            this.Text = "打印地图";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.打印地图_FormClosing);
            this.Load += new System.EventHandler(this.打印地图_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SuperMap.UI.MapLayoutControl mapLayoutControl1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonLockMap;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
    }
}