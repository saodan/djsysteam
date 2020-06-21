namespace GIS
{
    partial class 基本属性
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
            this.label_xzqh = new System.Windows.Forms.Label();
            this.xzqh = new System.Windows.Forms.TextBox();
            this.label_jd = new System.Windows.Forms.Label();
            this.jd = new System.Windows.Forms.TextBox();
            this.label_jf = new System.Windows.Forms.Label();
            this.jf = new System.Windows.Forms.TextBox();
            this.zdh_l = new System.Windows.Forms.Label();
            this.zdh = new System.Windows.Forms.TextBox();
            this.tdlylb = new System.Windows.Forms.ComboBox();
            this.label_tdlylb = new System.Windows.Forms.Label();
            this.label_qlr = new System.Windows.Forms.Label();
            this.qlr = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_xzqh
            // 
            this.label_xzqh.AutoSize = true;
            this.label_xzqh.Location = new System.Drawing.Point(13, 13);
            this.label_xzqh.Name = "label_xzqh";
            this.label_xzqh.Size = new System.Drawing.Size(65, 12);
            this.label_xzqh.TabIndex = 0;
            this.label_xzqh.Text = "行政区划：";
            // 
            // xzqh
            // 
            this.xzqh.Location = new System.Drawing.Point(84, 10);
            this.xzqh.Name = "xzqh";
            this.xzqh.Size = new System.Drawing.Size(272, 21);
            this.xzqh.TabIndex = 1;
            // 
            // label_jd
            // 
            this.label_jd.AutoSize = true;
            this.label_jd.Location = new System.Drawing.Point(12, 47);
            this.label_jd.Name = "label_jd";
            this.label_jd.Size = new System.Drawing.Size(41, 12);
            this.label_jd.TabIndex = 0;
            this.label_jd.Text = "街道：";
            // 
            // jd
            // 
            this.jd.Location = new System.Drawing.Point(59, 44);
            this.jd.Name = "jd";
            this.jd.Size = new System.Drawing.Size(55, 21);
            this.jd.TabIndex = 1;
            // 
            // label_jf
            // 
            this.label_jf.AutoSize = true;
            this.label_jf.Location = new System.Drawing.Point(132, 47);
            this.label_jf.Name = "label_jf";
            this.label_jf.Size = new System.Drawing.Size(41, 12);
            this.label_jf.TabIndex = 0;
            this.label_jf.Text = "街坊：";
            // 
            // jf
            // 
            this.jf.Location = new System.Drawing.Point(179, 44);
            this.jf.Name = "jf";
            this.jf.Size = new System.Drawing.Size(55, 21);
            this.jf.TabIndex = 1;
            // 
            // zdh_l
            // 
            this.zdh_l.AutoSize = true;
            this.zdh_l.Location = new System.Drawing.Point(254, 47);
            this.zdh_l.Name = "zdh_l";
            this.zdh_l.Size = new System.Drawing.Size(53, 12);
            this.zdh_l.TabIndex = 0;
            this.zdh_l.Text = "宗地号：";
            // 
            // zdh
            // 
            this.zdh.Location = new System.Drawing.Point(301, 44);
            this.zdh.Name = "zdh";
            this.zdh.Size = new System.Drawing.Size(55, 21);
            this.zdh.TabIndex = 1;
            // 
            // tdlylb
            // 
            this.tdlylb.FormattingEnabled = true;
            this.tdlylb.Items.AddRange(new object[] {
            "011 水田",
            "012 水浇地",
            "013 旱地",
            "021 果园",
            "022 茶园",
            "023 其他园地",
            "031 有林地",
            "032 灌木林地",
            "033 其他林地",
            "041 天然牧草地",
            "042 人工牧草地",
            "043 其他草地",
            "051 批发零售用地",
            "052 住宿餐饮用地",
            "053 商务金融用地",
            "054 其他商服用地",
            "061 工业用地",
            "062 采矿用地",
            "063 仓储用地",
            "071 城镇住宅用地",
            "072 农村宅基地",
            "081 机关团体用地",
            "082 新闻出版用地",
            "083 科教用地",
            "084 医卫慈善用地",
            "085 文体设施用地",
            "086 公共设施用地",
            "087 公园与绿地",
            "088 风景名胜设施用地",
            "091 军事设施用地",
            "092 使领馆用地",
            "093 监教场所用地",
            "094 宗教用地",
            "095 殡葬用地",
            "101 铁路用地",
            "102 公路用地",
            "103 街巷用地",
            "104 农村道路",
            "105 机场用地",
            "106 港口码头用地",
            "107 管道运输用地",
            "111 河流水面",
            "112 湖泊水面",
            "113 水库水面",
            "114 坑塘水面",
            "115 沿海滩涂",
            "116 内陆滩涂",
            "117 沟渠",
            "118 水工建筑用地",
            "119 冰川及永久积雪",
            "121 空闲地",
            "122 设施农用地",
            "123 田坎",
            "124 盐碱地",
            "125 沼泽地",
            "126 沙地",
            "127 裸地"});
            this.tdlylb.Location = new System.Drawing.Point(97, 81);
            this.tdlylb.Name = "tdlylb";
            this.tdlylb.Size = new System.Drawing.Size(258, 20);
            this.tdlylb.TabIndex = 7;
            // 
            // label_tdlylb
            // 
            this.label_tdlylb.AutoSize = true;
            this.label_tdlylb.Location = new System.Drawing.Point(13, 84);
            this.label_tdlylb.Name = "label_tdlylb";
            this.label_tdlylb.Size = new System.Drawing.Size(89, 12);
            this.label_tdlylb.TabIndex = 6;
            this.label_tdlylb.Text = "土地利用类别：";
            // 
            // label_qlr
            // 
            this.label_qlr.AutoSize = true;
            this.label_qlr.Location = new System.Drawing.Point(13, 114);
            this.label_qlr.Name = "label_qlr";
            this.label_qlr.Size = new System.Drawing.Size(53, 12);
            this.label_qlr.TabIndex = 9;
            this.label_qlr.Text = "权利人：";
            // 
            // qlr
            // 
            this.qlr.Location = new System.Drawing.Point(97, 111);
            this.qlr.Name = "qlr";
            this.qlr.Size = new System.Drawing.Size(259, 21);
            this.qlr.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(59, 138);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "确认";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(220, 138);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "退出";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // 基本属性
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 169);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label_qlr);
            this.Controls.Add(this.qlr);
            this.Controls.Add(this.tdlylb);
            this.Controls.Add(this.label_tdlylb);
            this.Controls.Add(this.zdh);
            this.Controls.Add(this.jf);
            this.Controls.Add(this.jd);
            this.Controls.Add(this.xzqh);
            this.Controls.Add(this.zdh_l);
            this.Controls.Add(this.label_jf);
            this.Controls.Add(this.label_jd);
            this.Controls.Add(this.label_xzqh);
            this.Name = "基本属性";
            this.Text = "宗地基本属性";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.基本属性_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_xzqh;
        private System.Windows.Forms.TextBox xzqh;
        private System.Windows.Forms.Label label_jd;
        private System.Windows.Forms.TextBox jd;
        private System.Windows.Forms.Label label_jf;
        private System.Windows.Forms.TextBox jf;
        private System.Windows.Forms.Label zdh_l;
        private System.Windows.Forms.TextBox zdh;
        private System.Windows.Forms.ComboBox tdlylb;
        private System.Windows.Forms.Label label_tdlylb;
        private System.Windows.Forms.Label label_qlr;
        private System.Windows.Forms.TextBox qlr;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}