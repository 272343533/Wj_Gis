namespace TDObject.UI
{
    partial class frmTotalHY
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 78D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2D, 78D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(3D, 54D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(4D, 24D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(5D, 324D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint6 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(6D, 82D);
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("投资类型分析");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("管理区企业数量");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("营业额统计");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("税收统计");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("产能统计");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("通用设备制造业");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("金属制品业");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("非金属矿物制品业");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("电气机械和器材制造业");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("橡胶和塑料制品业");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("木材加工和木");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("化学原料和化学制品制造业");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("专用设备制造业");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("文教、工美、体育和娱乐用品制造业");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("金属制品业");
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.04378F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.95622F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1009, 601);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(285, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(721, 595);
            this.panel1.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.Azure;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Location = new System.Drawing.Point(689, -1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(33, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Ⅹ";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.IsXValueIndexed = true;
            series1.Label = "111";
            series1.LabelAngle = 45;
            series1.LabelToolTip = "#VAL";
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Star4;
            series1.Name = "管理区分析1";
            dataPoint1.AxisLabel = "运东";
            dataPoint1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataPoint1.Label = "78家企业";
            dataPoint1.LabelToolTip = "78家企业";
            dataPoint1.LegendText = "运东";
            dataPoint1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
            dataPoint2.AxisLabel = "运西";
            dataPoint2.Label = "78家企业";
            dataPoint2.LegendText = "运西";
            dataPoint3.AxisLabel = "邱舍工业区";
            dataPoint3.Label = "54家企业";
            dataPoint3.LegendText = "邱舍工业区";
            dataPoint4.AxisLabel = "屯村社区";
            dataPoint4.Label = "24家企业";
            dataPoint4.LegendText = "屯村社区";
            dataPoint5.AxisLabel = "同里科技产业园";
            dataPoint5.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataPoint5.Label = "324家企业";
            dataPoint5.LegendText = "同里科技产业园";
            dataPoint5.MarkerColor = System.Drawing.Color.Empty;
            dataPoint6.AxisLabel = "同里社区";
            dataPoint6.LegendText = "同里社区";
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            series1.Points.Add(dataPoint4);
            series1.Points.Add(dataPoint5);
            series1.Points.Add(dataPoint6);
            series1.ToolTip = "#VALX";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(721, 595);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            title1.Name = "Title1";
            title1.Text = "行业管理区分析";
            this.chart1.Titles.Add(title1);
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioButton3);
            this.panel2.Controls.Add(this.radioButton2);
            this.panel2.Controls.Add(this.radioButton1);
            this.panel2.Controls.Add(this.treeView2);
            this.panel2.Controls.Add(this.treeView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(276, 595);
            this.panel2.TabIndex = 4;
            // 
            // radioButton3
            // 
            this.radioButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(180, 570);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(47, 16);
            this.radioButton3.TabIndex = 9;
            this.radioButton3.Text = "饼图";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.Click += new System.EventHandler(this.radioButton2_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(106, 570);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(59, 16);
            this.radioButton2.TabIndex = 8;
            this.radioButton2.Text = "折线图";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Click += new System.EventHandler(this.radioButton2_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(29, 571);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(59, 16);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "柱状图";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Click += new System.EventHandler(this.radioButton2_Click);
            // 
            // treeView2
            // 
            this.treeView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.treeView2.Font = new System.Drawing.Font("楷体", 12F);
            this.treeView2.ForeColor = System.Drawing.Color.Blue;
            this.treeView2.Location = new System.Drawing.Point(3, 436);
            this.treeView2.Name = "treeView2";
            treeNode1.Name = "节点3";
            treeNode1.Text = "投资类型分析";
            treeNode2.Name = "节点1";
            treeNode2.Text = "管理区企业数量";
            treeNode3.Name = "节点4";
            treeNode3.Text = "营业额统计";
            treeNode4.Name = "节点5";
            treeNode4.Text = "税收统计";
            treeNode5.Name = "节点0";
            treeNode5.Text = "产能统计";
            this.treeView2.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            this.treeView2.Size = new System.Drawing.Size(270, 128);
            this.treeView2.TabIndex = 2;
            this.treeView2.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView2_AfterSelect);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.treeView1.Font = new System.Drawing.Font("楷体", 12F);
            this.treeView1.ForeColor = System.Drawing.Color.Blue;
            this.treeView1.FullRowSelect = true;
            this.treeView1.Location = new System.Drawing.Point(0, 3);
            this.treeView1.Name = "treeView1";
            treeNode6.Name = "节点0";
            treeNode6.Tag = "320584400222";
            treeNode6.Text = "通用设备制造业";
            treeNode7.Name = "节点1";
            treeNode7.Tag = "320584400223";
            treeNode7.Text = "金属制品业";
            treeNode8.Name = "节点2";
            treeNode8.Tag = "320584400224";
            treeNode8.Text = "非金属矿物制品业";
            treeNode9.Name = "节点3";
            treeNode9.Tag = "320584101203";
            treeNode9.Text = "电气机械和器材制造业";
            treeNode10.Name = "节点4";
            treeNode10.Tag = "320584101202";
            treeNode10.Text = "橡胶和塑料制品业";
            treeNode11.Name = "节点5";
            treeNode11.Tag = "320584101205";
            treeNode11.Text = "木材加工和木";
            treeNode12.Name = "节点0";
            treeNode12.Tag = "320584101209";
            treeNode12.Text = "化学原料和化学制品制造业";
            treeNode13.Name = "节点1";
            treeNode13.Tag = "320584101200";
            treeNode13.Text = "专用设备制造业";
            treeNode14.Name = "320584101204";
            treeNode14.Text = "文教、工美、体育和娱乐用品制造业";
            treeNode15.Name = "节点0";
            treeNode15.Tag = "";
            treeNode15.Text = "金属制品业";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15});
            this.treeView1.Size = new System.Drawing.Size(273, 427);
            this.treeView1.TabIndex = 4;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // frmTotalHY
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 601);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTotalHY";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "按行业统计";
            this.Load += new System.EventHandler(this.FrmRegionTotal_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}