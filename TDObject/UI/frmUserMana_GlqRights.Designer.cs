namespace TDObject.UI
{
    partial class frmUserMana_GlqRights
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
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("吴江经济开发区", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode5,
            treeNode8});
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.qyTvOrg1 = new QyTech.SkinForm.Component.qyTvOrg();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.SystemColors.Control;
            this.treeView1.CheckBoxes = true;
            this.treeView1.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.ForeColor = System.Drawing.Color.Blue;
            this.treeView1.FullRowSelect = true;
            this.treeView1.Location = new System.Drawing.Point(64, 203);
            this.treeView1.Name = "treeView1";
            treeNode1.Checked = true;
            treeNode1.Name = "节点1";
            treeNode1.Tag = "320584400223";
            treeNode1.Text = "运东";
            treeNode2.Checked = true;
            treeNode2.Name = "节点2";
            treeNode2.Tag = "320584400224";
            treeNode2.Text = "运西";
            treeNode3.Checked = true;
            treeNode3.Name = "节点4";
            treeNode3.Tag = "320584101210";
            treeNode3.Text = "邱舍工业区";
            treeNode4.Checked = true;
            treeNode4.Name = "节点5";
            treeNode4.Tag = "320584101211";
            treeNode4.Text = "屯村社区";
            treeNode5.Checked = true;
            treeNode5.Name = "节点3";
            treeNode5.Tag = "3205844001";
            treeNode5.Text = "屯村街道办";
            treeNode6.Name = "节点1";
            treeNode6.Tag = "320584400215";
            treeNode6.Text = "同里科技产业园";
            treeNode7.Checked = true;
            treeNode7.Name = "节点41";
            treeNode7.Tag = "320584101212";
            treeNode7.Text = "同里社区";
            treeNode8.Checked = true;
            treeNode8.Name = "节点0";
            treeNode8.Tag = "3205844001";
            treeNode8.Text = "同里街道办";
            treeNode9.Checked = true;
            treeNode9.Name = "节点0";
            treeNode9.Tag = "320584400";
            treeNode9.Text = "吴江经济开发区";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode9});
            this.treeView1.Size = new System.Drawing.Size(182, 179);
            this.treeView1.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 23;
            this.label2.Text = "管理区权限";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "管理员",
            "浏览人员"});
            this.comboBox1.Location = new System.Drawing.Point(86, 11);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(149, 20);
            this.comboBox1.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "操作权限";
            // 
            // button4
            // 
            this.button4.Image = global::TDObject.Properties.Resources.ok_16px_1134004_easyicon_net;
            this.button4.Location = new System.Drawing.Point(46, 429);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(162, 23);
            this.button4.TabIndex = 20;
            this.button4.Text = "确定权限";
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(158, 388);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 23);
            this.button3.TabIndex = 19;
            this.button3.Text = "清除";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(102, 388);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "反选";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(46, 388);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "全选";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // qyTvOrg1
            // 
            this.qyTvOrg1.Location = new System.Drawing.Point(85, 85);
            this.qyTvOrg1.Name = "qyTvOrg1";
            this.qyTvOrg1.Size = new System.Drawing.Size(150, 150);
            this.qyTvOrg1.TabIndex = 25;
            // 
            // frmUserMana_GlqRights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 471);
            this.Controls.Add(this.qyTvOrg1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "frmUserMana_GlqRights";
            this.Text = "frmUserMana_GlqRights";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private QyTech.SkinForm.Component.qyTvOrg qyTvOrg1;
    }
}