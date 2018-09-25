namespace TDObject.UI
{
    partial class FrmRegionTotal
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("运东");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("运西");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("邱舍工业区");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("屯村社区");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("屯村街道办", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("同里科技产业园");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("同里社区");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("同里街道办", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("吴江经济技术开发区", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode5,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("投资类型分析");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("行业企业数量");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("土地面积统计");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("税收统计");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("销售额统计");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("能耗统计");
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation1 = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 78D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2D, 78D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(3D, 54D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(4D, 24D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(5D, 324D);
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvT2_12 = new System.Windows.Forms.DataGridView();
            this.dgvT2_11 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkRent = new System.Windows.Forms.CheckBox();
            this.chkYd = new System.Windows.Forms.CheckBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.cboYearMonth = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvT2_12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvT2_11)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.04378F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.95622F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 31);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 395F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1226, 400);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvT2_12);
            this.panel1.Controls.Add(this.dgvT2_11);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(346, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(877, 394);
            this.panel1.TabIndex = 3;
            // 
            // dgvT2_12
            // 
            this.dgvT2_12.AllowUserToAddRows = false;
            this.dgvT2_12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvT2_12.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvT2_12.Location = new System.Drawing.Point(13, 169);
            this.dgvT2_12.Name = "dgvT2_12";
            this.dgvT2_12.RowTemplate.Height = 23;
            this.dgvT2_12.Size = new System.Drawing.Size(861, 222);
            this.dgvT2_12.TabIndex = 14;
            // 
            // dgvT2_11
            // 
            this.dgvT2_11.AllowUserToAddRows = false;
            this.dgvT2_11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvT2_11.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvT2_11.Location = new System.Drawing.Point(13, 9);
            this.dgvT2_11.Name = "dgvT2_11";
            this.dgvT2_11.RowTemplate.Height = 23;
            this.dgvT2_11.Size = new System.Drawing.Size(861, 154);
            this.dgvT2_11.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkRent);
            this.panel2.Controls.Add(this.chkYd);
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.cboYearMonth);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.radioButton3);
            this.panel2.Controls.Add(this.radioButton2);
            this.panel2.Controls.Add(this.radioButton1);
            this.panel2.Controls.Add(this.treeView1);
            this.panel2.Controls.Add(this.treeView2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(337, 394);
            this.panel2.TabIndex = 4;
            // 
            // chkRent
            // 
            this.chkRent.AutoSize = true;
            this.chkRent.Location = new System.Drawing.Point(276, 187);
            this.chkRent.Name = "chkRent";
            this.chkRent.Size = new System.Drawing.Size(48, 16);
            this.chkRent.TabIndex = 52;
            this.chkRent.Text = "租赁";
            this.chkRent.UseVisualStyleBackColor = true;
            this.chkRent.CheckedChanged += new System.EventHandler(this.chkYd_CheckedChanged);
            // 
            // chkYd
            // 
            this.chkYd.AutoSize = true;
            this.chkYd.Location = new System.Drawing.Point(222, 187);
            this.chkYd.Name = "chkYd";
            this.chkYd.Size = new System.Drawing.Size(48, 16);
            this.chkYd.TabIndex = 51;
            this.chkYd.Text = "用地";
            this.chkYd.UseVisualStyleBackColor = true;
            this.chkYd.CheckedChanged += new System.EventHandler(this.chkYd_CheckedChanged);
            // 
            // btnExport
            // 
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(140, 184);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 50;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // cboYearMonth
            // 
            this.cboYearMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYearMonth.FormattingEnabled = true;
            this.cboYearMonth.Location = new System.Drawing.Point(46, 187);
            this.cboYearMonth.Name = "cboYearMonth";
            this.cboYearMonth.Size = new System.Drawing.Size(78, 20);
            this.cboYearMonth.TabIndex = 49;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 48;
            this.label6.Text = "年月";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(197, 372);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(47, 16);
            this.radioButton3.TabIndex = 6;
            this.radioButton3.Text = "饼图";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.Click += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(123, 372);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(59, 16);
            this.radioButton2.TabIndex = 5;
            this.radioButton2.Text = "折线图";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Click += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(46, 373);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(59, 16);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "柱状图";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.treeView1.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.ForeColor = System.Drawing.Color.Black;
            this.treeView1.FullRowSelect = true;
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "节点1";
            treeNode1.Tag = "WJKFQ02";
            treeNode1.Text = "运东";
            treeNode2.Name = "节点2";
            treeNode2.Tag = "WJKFQ01";
            treeNode2.Text = "运西";
            treeNode3.Name = "节点4";
            treeNode3.Tag = "WJKFQ06";
            treeNode3.Text = "邱舍工业区";
            treeNode4.Name = "节点5";
            treeNode4.Tag = "WJKFQ05";
            treeNode4.Text = "屯村社区";
            treeNode5.Name = "节点0";
            treeNode5.Tag = "WJKFQ05，WJKFQ06";
            treeNode5.Text = "屯村街道办";
            treeNode6.Name = "节点1";
            treeNode6.Tag = "WJKFQ03";
            treeNode6.Text = "同里科技产业园";
            treeNode7.Name = "节点41";
            treeNode7.Tag = "WJKFQ04";
            treeNode7.Text = "同里社区";
            treeNode8.Name = "节点1";
            treeNode8.Tag = "WJKFQ03，WJKFQ04";
            treeNode8.Text = "同里街道办";
            treeNode9.Name = "节点0";
            treeNode9.Tag = "WJKFQ01,WJKFQ02,WJKFQ03,WJKFQ04,WJKFQ05,WJKFQ06";
            treeNode9.Text = "吴江经济技术开发区";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode9});
            this.treeView1.Size = new System.Drawing.Size(331, 173);
            this.treeView1.TabIndex = 3;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // treeView2
            // 
            this.treeView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.treeView2.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView2.ForeColor = System.Drawing.Color.Black;
            this.treeView2.LineColor = System.Drawing.Color.White;
            this.treeView2.Location = new System.Drawing.Point(6, 213);
            this.treeView2.Name = "treeView2";
            treeNode10.ForeColor = System.Drawing.Color.Black;
            treeNode10.Name = "节点3";
            treeNode10.Text = "投资类型分析";
            treeNode11.Name = "节点0";
            treeNode11.Text = "行业企业数量";
            treeNode12.Name = "节点0";
            treeNode12.Text = "土地面积统计";
            treeNode13.Name = "节点5";
            treeNode13.Text = "税收统计";
            treeNode14.Name = "节点4";
            treeNode14.Text = "销售额统计";
            treeNode15.Name = "节点1";
            treeNode15.Text = "能耗统计";
            this.treeView2.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15});
            this.treeView2.Size = new System.Drawing.Size(331, 154);
            this.treeView2.TabIndex = 2;
            this.treeView2.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView2_AfterSelect);
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            lineAnnotation1.Name = "LineAnnotation1";
            lineAnnotation1.ToolTip = "3444";
            this.chart1.Annotations.Add(lineAnnotation1);
            this.chart1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            chartArea1.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX.IsInterlaced = true;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(9, 437);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.LabelToolTip = "#VAL";
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Star4;
            series1.Name = "行业分析";
            dataPoint1.AxisLabel = "电子资讯";
            dataPoint1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataPoint1.Label = "78家企业";
            dataPoint1.LabelToolTip = "78家企业";
            dataPoint1.LegendText = "电子资讯";
            dataPoint1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
            dataPoint2.AxisLabel = "金融保险";
            dataPoint2.Label = "78家企业";
            dataPoint2.LegendText = "金融保险";
            dataPoint3.AxisLabel = "服务业";
            dataPoint3.Label = "54家企业";
            dataPoint3.LegendText = "服务业";
            dataPoint4.AxisLabel = "批发零售";
            dataPoint4.Label = "24家企业";
            dataPoint4.LegendText = "批发零售";
            dataPoint5.AxisLabel = "传统制造";
            dataPoint5.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataPoint5.Label = "324家企业";
            dataPoint5.LegendText = "传统制造";
            dataPoint5.MarkerColor = System.Drawing.Color.Empty;
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            series1.Points.Add(dataPoint4);
            series1.Points.Add(dataPoint5);
            series1.ToolTip = "#AXISLABEL";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1217, 250);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            title1.Name = "Title1";
            title1.Text = "行业类型分析";
            this.chart1.Titles.Add(title1);
            // 
            // FrmRegionTotal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 699);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRegionTotal";
            this.Text = "按管理区统计";
            this.Load += new System.EventHandler(this.FrmRegionTotal_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmRegionTotal_MouseMove);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.chart1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvT2_12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvT2_11)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.DataGridView dgvT2_11;
        private System.Windows.Forms.DataGridView dgvT2_12;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ComboBox cboYearMonth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.CheckBox chkRent;
        private System.Windows.Forms.CheckBox chkYd;
    }
}